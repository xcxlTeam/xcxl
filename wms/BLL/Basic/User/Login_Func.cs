using BLL.JSONUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Common;
using BLL.Basic.UserGroup;
using BLL.Basic.Menu;
using BLL.Basic.Warehouse;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;

namespace BLL.Basic.User
{
    public class Login_Func
    {
        private Login_DB _db = new Login_DB();

        private const string pukey = "XianDa00";
        private const string pvkey = "CombaWMS";

        private static string JiaMi(string MingWen)
        {
            try
            {
                if (string.IsNullOrEmpty(MingWen))
                {
                    return string.Empty;
                }

                string strCipherText = "";
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray;
                inputByteArray = Encoding.Default.GetBytes(MingWen);
                des.Key = Encoding.Default.GetBytes(pukey);
                des.IV = Encoding.Default.GetBytes(pvkey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                StringBuilder ret = new StringBuilder();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                strCipherText = ret.ToString();
                return strCipherText;
            }
            catch
            {
                return string.Empty;
            }

        }

        #region PC

        public bool UserLogin(ref UserInfo user, ref string strError)
        {
            try
            {
                if (_db.UserLogin(ref user, ref strError))
                {
                    if (!string.IsNullOrEmpty(user.LoginIP))
                    {
                        _db.UpdateLoginTime(user);
                    }

                    UserGroup_Func UGF = new UserGroup_Func();
                    List<UserGroupInfo> lstGroup = new List<UserGroupInfo>();
                    if (UGF.GetUserGroupListByUser(ref lstGroup, user, false, null, ref strError))
                    {
                        user.lstUserGroup = lstGroup;
                    }

                    Menu_Func MF = new Menu_Func();
                    List<MenuInfo> lstMenu = new List<MenuInfo>();
                    if (MF.GetMenuListByUser(ref lstMenu, user, true, null, ref strError))
                    {
                        user.lstMenu = lstMenu;
                    }

                    Warehouse_Func WHF = new Warehouse_Func();
                    List<WarehouseInfo> lstWarehouse = new List<WarehouseInfo>();
                    if (WHF.GetWarehouseListByUser(ref lstWarehouse, user, false, null, ref strError))
                    {
                        user.lstWarehouse = lstWarehouse;
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Common_Func.IsSqlError(ex.Message, ref strError);
                return false;
            }
        }

        public bool ChangeUserPassword(UserInfo user, UserInfo ChangeUser, ref string strError)
        {
            if (user == null || user.ID == 0)
            {
                strError = "用户信息获取失败!";
                return false;
            }
            if (ChangeUser.ID == 0)
            {
                strError = "密码修改人信息获取失败!";
                return false;
            }

            if (user.ID != ChangeUser.ID)
            {
                if (!ChangeUser.BIsAdmin)
                {
                    strError = "非管理员不能修改其他用户的密码!";
                    return false;
                }
            }

            user.Modifyer = ChangeUser.UserNo;
            return _db.ChangeUserPassword(user, ref strError);
        }

        public bool UpdateLoginTime(ref UserInfo user, ref string strError)
        {
            try
            {
                user.LoginTime = DateTime.Now;
                return _db.UpdateLoginTime(user);
            }
            catch (Exception ex)
            {
                strError = ex.Message; ;
                return false;
            }
        }

        public bool ClearLoginTime(UserInfo user, UserInfo ClearUser, ref string strError)
        {
            if (user == null || user.ID == 0)
            {
                strError = "用户信息获取失败!";
                return false;
            }
            if (ClearUser.ID == 0)
            {
                strError = "登录信息清除人信息获取失败!";
                return false;
            }

            if (user.ID != ClearUser.ID && !ClearUser.BIsAdmin)
            {
                strError = "非管理员不能清除其他用户的登录信息!";
                return false;

            }

            return _db.ClearLoginTime(user, ref strError);
        }
        #endregion

        #region Android
        //UFSoft.U8.Framework.Login.UI.clsLogin netLogin = new UFSoft.U8.Framework.Login.UI.clsLogin();
        public string UserLoginForAndroid(string strUserJson)
        {
            UserInfo user = new UserInfo();
            string strError = string.Empty;
            try
            {
                user = JSONHelper.JsonToObject<UserInfo>(strUserJson);
                string password = user.Password;
                //user.Password = JiaMi(user.Password);
                //user.Password = netLogin.EnPassWord(user.Password);

                bool bResult = _db.UserLogin(ref user, ref strError);

                user.Password = password;

                if (bResult)
                {
                    //#region U8APILogin
                    //U8DAL.U8API.U8APICommon co = U8DAL.U8API.U8APICommon.GetU8APICommon();
                    //strError = co.errMsg;
                    //if (!string.IsNullOrEmpty(strError))
                    //{
                    //    user.Status = "E";
                    //    user.Message = strError;
                    //    return JSONHelper.ObjectToJson(user);
                    //} 
                    //#endregion

                    if (!string.IsNullOrEmpty(user.LoginIP))
                    {
                        user.LoginTime = DateTime.Now;
                        _db.UpdateLoginTime(user);
                    }

                    user.Status = "S";
                    user.LoginTime = null;
                    user.CreateTime = null;
                    user.ModifyTime = null;

                    user.lstUserGroup = null;
                    //UserGroup_Func UGF = new UserGroup_Func();
                    //List<UserGroupInfo> lstGroup = new List<UserGroupInfo>();
                    //if (UGF.GetUserGroupListByUser(ref lstGroup, user, false,null, ref strError))
                    //{
                    //    user.lstUserGroup = lstGroup;
                    //}

                    Menu_Func MF = new Menu_Func();
                    List<MenuInfo> lstMenu = new List<MenuInfo>();
                    if (MF.GetMenuListByUser(ref lstMenu, user, false, null, ref strError))
                    {
                        user.lstMenu = lstMenu;
                    }

                    Warehouse_Func WHF = new Warehouse_Func();
                    List<WarehouseInfo> lstWarehouse = new List<WarehouseInfo>();
                    if (WHF.GetWarehouseListByUser(ref lstWarehouse, user, false, null, ref strError))
                    {
                        user.lstWarehouse = lstWarehouse;
                    }

                    return JSONHelper.ObjectToJson(user);
                }
                else
                {
                    user.Status = "E";
                    user.Message = strError;
                    return JSONHelper.ObjectToJson(user);
                }
            }
            catch (Exception ex)
            {
                user.Status = "E";
                user.Message = "Web异常：" + ex.Message + ex.StackTrace;
                if (Common_Func.IsSqlError(user.Message, ref strError)) user.Message = strError;
                return JSONHelper.ObjectToJson(user);
            }
        }

        public string ChangeUserPasswordForAndroid(string strUserJson)
        {
            UserInfo user = new UserInfo();
            string strError = string.Empty;
            try
            {
                user = JSONHelper.JsonToObject<UserInfo>(strUserJson);

                if (user == null || user.ID == 0)
                {
                    user.Status = "E";
                    user.Message = "用户信息获取失败!请重新登陆!";
                    return JSONHelper.ObjectToJson(user);
                }
                if (user.Password == user.RePassword)
                {
                    user.Status = "S";
                    user.LoginTime = null;
                    user.CreateTime = null;
                    user.ModifyTime = null;

                    return JSONHelper.ObjectToJson(user);
                }

                user.Modifyer = user.UserNo;
                user.Password = JiaMi(user.Password);
                //user.Password = netLogin.EnPassWord(user.Password);
                bool bResult = _db.ChangeUserPassword(user, ref strError);

                if (bResult)
                {
                    user.RePassword = user.Password;
                    user.Status = "S";
                    user.LoginTime = null;
                    user.CreateTime = null;
                    user.ModifyTime = null;

                    return JSONHelper.ObjectToJson(user);
                }
                else
                {
                    user.Status = "E";
                    user.Message = strError;
                    return JSONHelper.ObjectToJson(user);
                }
            }
            catch (Exception ex)
            {
                user.Status = "E";
                user.Message = "Web异常：" + ex.Message + ex.StackTrace;
                if (Common_Func.IsSqlError(user.Message, ref strError)) user.Message = strError;
                return JSONHelper.ObjectToJson(user);
            }
        }

        public string UpdateLoginTimeForAndroid(string strUserJson)
        {
            UserInfo user = new UserInfo();
            string strError = string.Empty;
            try
            {
                user = JSONHelper.JsonToObject<UserInfo>(strUserJson);

                if (user == null || user.ID == 0)
                {
                    user.Status = "E";
                    user.Message = "用户信息获取失败!请重新登陆!";
                    return JSONHelper.ObjectToJson(user);
                }

                user.LoginTime = DateTime.Now;
                bool bResult = _db.UpdateLoginTime(user);

                if (bResult)
                {
                    user.Status = "S";
                    user.LoginTime = null;
                    user.CreateTime = null;
                    user.ModifyTime = null;

                    return JSONHelper.ObjectToJson(user);
                }
                else
                {
                    user.Status = "E";
                    user.Message = strError;
                    return JSONHelper.ObjectToJson(user);
                }
            }
            catch (Exception ex)
            {
                user.Status = "E";
                user.Message = "Web异常：" + ex.Message + ex.StackTrace;
                if (Common_Func.IsSqlError(user.Message, ref strError)) user.Message = strError;
                return JSONHelper.ObjectToJson(user);
            }
        }

        public string ClearLoginTimeForAndroid(string strUserJson)
        {
            UserInfo user = new UserInfo();
            string strError = string.Empty;
            try
            {
                user = JSONHelper.JsonToObject<UserInfo>(strUserJson);

                if (user == null || user.ID == 0)
                {
                    user.Status = "E";
                    user.Message = "用户信息获取失败!请重新登陆!";
                    return JSONHelper.ObjectToJson(user);
                }

                bool bResult = _db.ClearLoginTime(user, ref strError);

                if (bResult)
                {
                    user.Status = "S";
                    user.LoginTime = null;
                    user.CreateTime = null;
                    user.ModifyTime = null;

                    return JSONHelper.ObjectToJson(user);
                }
                else
                {
                    user.Status = "E";
                    user.Message = strError;
                    return JSONHelper.ObjectToJson(user);
                }
            }
            catch (Exception ex)
            {
                user.Status = "E";
                user.Message = "Web异常：" + ex.Message + ex.StackTrace;
                if (Common_Func.IsSqlError(user.Message, ref strError)) user.Message = strError;
                return JSONHelper.ObjectToJson(user);
            }
        }

        #endregion

    }
}
