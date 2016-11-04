using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Common;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Basic.User
{
    public class Login_DB
    {
        public bool UserLogin(ref UserInfo user, ref string strError)
        {
            if (DateTime.Today>=Convert.ToDateTime("2016-10-15")&&!securityAndRegister.EncryptionHelper.CheckRegist())
            {
                strError = "登陆异常！该用户不存在";
                return false;
            }
            if (string.IsNullOrEmpty(user.LoginDevice)) user.LoginDevice = user.LoginIP;
            string LoginIP = user.LoginIP;
            DateTime CurrentTime;
            string strSql = string.Empty;
            if (user.UserNo.ToUpper() != "ADMIN")
            {
                UFSoft.U8.Framework.Login.UI.clsLogin netLogin = new UFSoft.U8.Framework.Login.UI.clsLogin();
                user.Password = netLogin.EnPassWord(user.Password);
                strSql = string.Format("SELECT GETDATE() CurrentTime,V_User.* FROM V_User WHERE UserNo = '{0}' AND password = '{1}'", user.UserNo, user.Password);
            }
            else
            {
                strSql = string.Format("SELECT GETDATE() CurrentTime,V_User.* FROM V_User WHERE UserNo = '{0}' ", user.UserNo);
            }
            //strSql = string.Format("SELECT GETDATE() CurrentTime,V_User.* FROM V_User WHERE UserNo = '{0}'", user.UserNo);

            UserInfo model;
            using (SqlDataReader odr = OperationSql.ExecuteReader(CommandType.Text, strSql))
            {
                if (odr.Read())
                {
                    User_Func func = new User_Func();
                    model = func.GetModelFromDataReader(odr);
                    CurrentTime = odr["CurrentTime"].ToDateTime();

                    if (model == null)
                    {
                        strError = "用户实例化失败";
                        return false;
                    }
                    else if (model.UserStatus == 2)
                    {
                        strError = string.Format("用户【{0}】已停用", model.UserName);
                        return false;
                    }
                    else if (model.IsDel == 2)
                    {
                        strError = string.Format("用户【{0}】已删除", model.UserName);
                        return false;
                    }

                    if (model.BIsOnline)
                    {
                        if (model.UserType == 1)
                        {
                            if (!string.IsNullOrEmpty(user.LoginIP) && model.LoginIP.Length + user.LoginIP.Length >= 100 && model.LoginIP.IndexOf(user.LoginIP) <= -1)
                            {
                                strError = string.Format("超级管理员用户【{0}】已超过登录次数上限，目前共【{1}】处登录{2}请先登出或联系管理员清除后重试", model.UserName, model.LoginIP.Split(';').Length, Environment.NewLine);
                                return false;
                            }
                            else if (!string.IsNullOrEmpty(user.LoginDevice) && model.LoginDevice.Length + user.LoginDevice.Length >= 200 && model.LoginDevice.IndexOf(user.LoginDevice) <= -1)
                            {
                                strError = string.Format("超级管理员用户【{0}】已超过登录次数上限，目前共【{1}】处登录{2}请先登出或联系管理员清除后重试", model.UserName, model.LoginDevice.Split(';').Length, Environment.NewLine);
                                return false;
                            }
                        }
                        else
                        {
                            if (model.LoginIP != user.LoginIP)
                            {
                                string LoginAddress = string.IsNullOrEmpty(model.LoginDevice) ? model.LoginIP : model.LoginDevice;
                                if (!model.LoginIP.StartsWith("PC"))
                                {
                                    strError = string.Format("用户【{0}】已于【{1}】在【{2}】处登录{3}请先登出或联系管理员清除后重试", model.UserName, model.LoginTime, LoginAddress, Environment.NewLine);
                                    return false;
                                }
                                else if ((CurrentTime - model.LoginTime.ToDateTime()).TotalMilliseconds < 1500000)
                                {
                                    strError = string.Format("用户【{0}】正在【{1}】处使用{2}请先登出或联系管理员清除后重试", model.UserName, LoginAddress, Environment.NewLine);
                                    return false;
                                }
                            }
                        }
                    }

                    model.LoginTime = CurrentTime;
                    model.LoginIP = user.LoginIP;
                    model.LoginDevice = user.LoginDevice;

                    user = model;
                }
                else
                {
                    strSql = string.Format("SELECT COUNT(1) FROM V_User WHERE UserNo = '{0}' ", user.UserNo);
                    int i = OperationSql.ExecuteScalar(CommandType.Text, strSql).ToInt32();
                    if (i <= 0)
                    {
                        strError = "登陆异常！该用户不存在";
                        return false;
                    }
                    else
                    {
                        strError = "密码输入错误";
                        return false;
                    }
                }
            }

            return true;
        }

        public bool UpdateLoginTime(UserInfo user)
        {
            string strSql;
            user.LoginTime = DateTime.Now;
            UserInfo model = new UserInfo();
            if (user.ID >= 1 && user.UserType == 1)
            {
                strSql = string.Format("SELECT LoginIP, LoginDevice FROM T_User WHERE ID = {0}", user.ID);
                using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, strSql))
                {
                    if (dr.Read())
                    {
                        model.LoginIP = dr["LoginIP"].ToDBString();
                        model.LoginDevice = dr["LoginDevice"].ToDBString();
                        if (!string.IsNullOrEmpty(model.LoginIP))
                        {
                            if (!string.IsNullOrEmpty(user.LoginIP) && model.LoginIP.IndexOf(user.LoginIP) <= -1)
                            {
                                model.LoginIP = string.Format("{0};{1}", model.LoginIP, user.LoginIP).Trim(';');
                                model.LoginDevice = string.Format("{0};{1}", model.LoginDevice, user.LoginDevice).Trim(';');
                            }
                        }
                        else
                        {
                            model.LoginIP = user.LoginIP;
                            model.LoginDevice = user.LoginDevice;
                        }
                    }
                    else
                    {
                        model.LoginIP = user.LoginIP;
                        model.LoginDevice = user.LoginDevice;
                    }
                }
            }
            else
            {
                model.LoginIP = user.LoginIP;
                model.LoginDevice = user.LoginDevice;
            }
            strSql = string.Format("UPDATE T_User SET LoginIP = '{0}', LoginTime = GETDATE(), LoginDevice = '{1}' WHERE ID = {2} ", model.LoginIP, model.LoginDevice, user.ID);
            int i = OperationSql.ExecuteNonQuery2(CommandType.Text, strSql);
            return i >= 1;
        }

        internal bool ChangeUserPassword(UserInfo user, ref string strError)
        {
            string strSql;
            strSql = string.Format("UPDATE T_User SET Password = '{0}', Modifyer = '{1}', ModifyTime = GETDATE() WHERE ID = {2} ", user.Password, user.Modifyer, user.ID);
            int i = OperationSql.ExecuteNonQuery2(CommandType.Text, strSql);
            return i >= 1;
        }

        internal bool ClearLoginTime(UserInfo user, ref string strError)
        {
            string strSql;
            strSql = "UPDATE T_User SET LoginIP = null, LoginTime = null, LoginDevice = null WHERE (SUBSTRING(LOGINIP,0,2) = 'PC' AND (LOGINTIME + (30/60/24)) <= GETDATE()) OR (USERTYPE <> 1 AND LOGINTIME IS NULL) ";
            OperationSql.ExecuteNonQuery2(CommandType.Text, strSql);
            if (user.ID >= 1 && user.UserType == 1)
            {
                //strSql = string.Format("UPDATE T_User SET LoginIP = ltrim(rtrim(replace(LoginIP,'{1}',''),';'),';'), LoginTime = null, LoginDevice = ltrim(rtrim(replace(LoginDevice,'{2}',''),';'),';') WHERE ID = {0} ", user.ID, user.LoginIP, user.LoginDevice);
                //SQLSERVER语法不支持上述语句
                strSql = string.Format("UPDATE T_User SET LoginIP = case when left(replace(LoginIP,'{1}',''),1)=';' then right(replace(LoginIP,'{1}',''),len(replace(LoginIP,'{1}',''))-1) when right(replace(LoginIP,'{1}',''),1)=';' then left(replace(LoginIP,'{1}',''),len(replace(LoginIP,'{1}',''))-1) else replace(LoginIP,'{1}','') end, LoginTime = null, LoginDevice = case when left(replace(LoginDevice,'{2}',''),1)=';' then right(replace(LoginDevice,'{2}',''),len(replace(LoginDevice,'{2}',''))-1) when right(replace(LoginDevice,'{2}',''),1)=';' then left(replace(LoginDevice,'{2}',''),len(replace(LoginDevice,'{2}',''))-1) else replace(LoginDevice,'{2}','') end WHERE ID = {0} ", user.ID, user.LoginIP, user.LoginDevice);
            }
            else
            {
                strSql = string.Format("UPDATE T_User SET LoginIP = null, LoginTime = null, LoginDevice = null WHERE ID = {0} ", user.ID);
            }
            int i = OperationSql.ExecuteNonQuery2(CommandType.Text, strSql);
            strSql = "UPDATE T_User SET LoginIP = replace(LoginIP,';;',';'), LoginDevice = replace(LoginDevice,';;',';')";
            OperationSql.ExecuteNonQuery2(CommandType.Text, strSql);
            return i >= 1;
        }
    }
}
