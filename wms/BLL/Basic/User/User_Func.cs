using BLL.Basic.User;
using BLL.Common;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace BLL.Basic.User
{
    public class User_Func
    {
        private User_DB _db = new User_DB();

        public bool ExistsUserNo(UserInfo model, bool bIncludeDel, UserInfo user, ref string strError)
        {
            try
            {
                return _db.ExistsUserNo(model, bIncludeDel);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public bool SaveUser(ref UserInfo model, UserInfo user, ref string strError)
        {
            try
            {
                if (model.ID <= 0)
                {
                    model.Creater = user.UserNo;
                }
                else
                {
                    model.Modifyer = user.UserNo;
                }
                if(!model.Password.Equals("不要加密或更新"))
                {
                    UFSoft.U8.Framework.Login.UI.clsLogin netLogin = new UFSoft.U8.Framework.Login.UI.clsLogin();
                    model.Password = netLogin.EnPassWord(model.Password);
                }

                return _db.SaveUser(ref model);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }


        public bool DeleteUserByID(UserInfo model, UserInfo user, ref string strError)
        {
            try
            {
                return _db.DeleteUserByID(model);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }


        public bool GetUserByID(ref UserInfo model, UserInfo user, ref string strError)
        {
            try
            {
                using (SqlDataReader dr = _db.GetUserByID(model))
                {
                    if (dr.Read())
                    {
                        model = (GetModelFromDataReader(dr));
                        return true;
                    }
                    else
                    {
                        strError = "找不到任何数据";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
            finally
            {
            }
        }

        public bool GetKeeperList(ref List<UserInfo> modelList,ref string strError)
        {
            try
            {
                List<UserInfo> lstModel = new List<UserInfo>();
                using (SqlDataReader dr = _db.GetKeeperList())
                {
                    if (dr.Read())
                    {
                        while (dr.Read())
                        {
                            lstModel.Add(GetModelFromDataReader(dr));
                        }
                        return true;
                    }
                    else
                    {
                        strError = "找不到任何数据";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
            finally
            {
            }
        }

        public bool GetUserListByPage(ref List<UserInfo> modelList, UserInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            if (page == null) page = new DividPage();
            List<UserInfo> lstModel = new List<UserInfo>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_User", GetFilterSql(model, user), "*", "Order By UserNo,PinYin,ID Desc"))
                {
                    while (dr.Read())
                    {
                        lstModel.Add(GetModelFromDataReader(dr));
                    }
                }

                modelList = lstModel;
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
            finally
            {
            }
        }

        private string GetFilterSql(UserInfo model, UserInfo user)
        {
            try
            {
                string strSql = " Where ISNULL(IsDel,1) = 1 ";
                bool hadWhere = true;


                if (!string.IsNullOrEmpty(model.UserNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " UserNo Like '%" + model.UserNo + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.UserName))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (UserName Like '%" + model.UserName + "%' OR PinYin Like '%" + model.UserName + "%') ";
                    hadWhere = true;
                }

                if (model.IsOnline >= 1)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " LoginIP is " + (model.IsOnline.ToBoolean() ? "not" : "") + " null ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.Creater))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " Creater Like '%" + model.Creater + "%' ";
                    hadWhere = true;
                }

                if (model.StartTime != null)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " CreateTime >= " + model.StartTime.ToDateTime().Date.ToSqlTimeString() + " ";
                    hadWhere = true;
                }

                if (model.EndTime != null)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " CreateTime <= " + model.EndTime.ToDateTime().AddDays(1).Date.ToSqlTimeString() + " ";
                    hadWhere = true;
                }


                return strSql;
            }
            catch
            {
                return string.Empty;
            }
        }

        internal UserInfo GetModelFromDataReader(SqlDataReader dr)
        {
            UserInfo model = new UserInfo();
            model.ID = dr["ID"].ToInt32();
            model.UserNo = dr["UserNo"].ToDBString();
            model.UserName = dr["UserName"].ToDBString();
            model.Password = dr["Password"].ToDBString();
            model.UserType = dr["UserType"].ToInt32();
            model.PinYin = dr["PinYin"].ToDBString();
            model.Duty = dr["Duty"].ToDBString();
            model.Tel = dr["Tel"].ToDBString();
            model.Mobile = dr["Mobile"].ToDBString();
            model.Email = dr["Email"].ToDBString();
            model.Sex = dr["Sex"].ToInt32();
            model.IsPick = dr["IsPick"].ToInt32();
            model.IsReceive = dr["IsReceive"].ToInt32();
            model.IsQuality = dr["IsQuality"].ToInt32();
            model.UserStatus = dr["UserStatus"].ToInt32();
            model.Address = dr["Address"].ToDBString();
            model.GroupCode = dr["GroupCode"].ToDBString();
            model.WarehouseCode = dr["WarehouseCode"].ToDBString();
            model.Description = dr["Description"].ToDBString();
            model.LoginIP = dr["LoginIP"].ToDBString();
            model.LoginTime = dr["LoginTime"].ToDateTimeNull();
            if (Common_Func.readerExists(dr, "LoginDevice")) model.LoginDevice = dr["LoginDevice"].ToDBString();

            model.IsDel = dr["ISDEL"].ToInt32();
            model.Creater = dr["CREATER"].ToDBString();
            model.CreateTime = dr["CREATETIME"].ToDateTime();
            model.Modifyer = dr["MODIFYER"].ToDBString();
            model.ModifyTime = dr["MODIFYTIME"].ToDateTimeNull();

            if (Common_Func.readerExists(dr, "IsAdmin")) model.BIsAdmin = dr["IsAdmin"].ToBoolean();
            if (Common_Func.readerExists(dr, "StrUserType")) model.StrUserType = dr["StrUserType"].ToDBString();
            if (Common_Func.readerExists(dr, "StrUserStatus")) model.StrUserStatus = dr["StrUserStatus"].ToDBString();
            if (Common_Func.readerExists(dr, "StrSex")) model.StrSex = dr["StrSex"].ToDBString();
            if (Common_Func.readerExists(dr, "GroupName")) model.GroupName = dr["GroupName"].ToDBString();
            if (Common_Func.readerExists(dr, "WarehouseName")) model.WarehouseName = dr["WarehouseName"].ToDBString();

            model.RePassword = model.Password;
            model.StrIsAdmin = model.BIsAdmin ? "管理员" : "标准用户";
            model.BIsPick = model.IsPick.ToBoolean();
            model.BIsReceive = model.IsReceive.ToBoolean();
            model.BIsQuality = model.IsQuality.ToBoolean();
            model.StrIsPick = model.BIsPick ? "拣货" : "不拣货";
            model.StrIsReceive = model.BIsReceive ? "收货" : "不收货";
            model.StrIsQuality = model.BIsQuality ? "提示" : "不提示";
            model.BIsOnline = !string.IsNullOrEmpty(model.LoginIP);
            model.IsOnline = model.BIsOnline.ToInt32();

            return model;
        }
    }
}
