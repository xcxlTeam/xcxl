using BLL.Basic.User;
using BLL.Common;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace BLL.Basic.UserGroup
{
   public class UserGroup_Func
   {
       private UserGroup_DB _db = new UserGroup_DB();

       public bool ExistsUserGroupNo(UserGroupInfo model, bool bIncludeDel, UserInfo user, ref string strError)
       {
           try
           {
               return _db.ExistsUserGroupNo(model, bIncludeDel);
           }
           catch (Exception ex)
           {
               strError = ex.Message;
               return false;
           }
       }

       public bool SaveUserGroup(ref UserGroupInfo model, UserInfo user, ref string strError)
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
               return _db.SaveUserGroup(ref model);
           }
           catch (Exception ex)
           {
               strError = ex.Message;
               return false;
           }
       }


       public bool DeleteUserGroupByID(UserGroupInfo model, UserInfo user, ref string strError)
       {
           try
           {
               return _db.DeleteUserGroupByID(model);
           }
           catch (Exception ex)
           {
               strError = ex.Message;
               return false;
           }
       }


       public bool GetUserGroupByID(ref UserGroupInfo model, UserInfo user, ref string strError)
       {
           try
           {
               using (SqlDataReader dr = _db.GetUserGroupByID(model))
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


       public bool GetUserGroupListByPage(ref List<UserGroupInfo> modelList, UserGroupInfo model, ref DividPage page, UserInfo user, ref string strError)
       {
           if (page == null) page = new DividPage();
           List<UserGroupInfo> lstModel = new List<UserGroupInfo>();
           try
           {
               using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_UserGroup", GetFilterSql(model, user), "*", "Order By UserGroupType,UserGroupNo,ID Desc"))
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

       private string GetFilterSql(UserGroupInfo model, UserInfo user)
       {
           try
           {
               string strSql = " Where ISNULL(IsDel,1) = 1 ";
               bool hadWhere = true;


               if (!string.IsNullOrEmpty(model.UserGroupNo))
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " UserGroupNo Like '%" + model.UserGroupNo + "%' ";
                   hadWhere = true;
               }

               if (!string.IsNullOrEmpty(model.UserGroupName))
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " UserGroupName Like '%" + model.UserGroupName + "%' ";
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

       private UserGroupInfo GetModelFromDataReader(SqlDataReader dr)
       {
           UserGroupInfo model = new UserGroupInfo();
           model.ID = dr["ID"].ToInt32();
           model.UserGroupNo = dr["UserGroupNo"].ToDBString();
           model.UserGroupName = dr["UserGroupName"].ToDBString();
           model.UserGroupAbbName = dr["UserGroupAbbName"].ToDBString();
           model.UserGroupType = dr["UserGroupType"].ToInt32();
           model.UserGroupStatus = dr["UserGroupStatus"].ToInt32();
           model.Description = dr["Description"].ToDBString();
           model.IsDel = dr["ISDEL"].ToInt32();
           model.Creater = dr["CREATER"].ToDBString();
           model.CreateTime = dr["CREATETIME"].ToDateTime();
           model.Modifyer = dr["MODIFYER"].ToDBString();
           model.ModifyTime = dr["MODIFYTIME"].ToDateTimeNull();

           if (Common_Func.readerExists(dr, "IsChecked")) model.BIsChecked = dr["IsChecked"].ToBoolean();
           if (Common_Func.readerExists(dr, "StrUserGroupType")) model.StrUserGroupType = dr["StrUserGroupType"].ToDBString();
           if (Common_Func.readerExists(dr, "StrUserGroupStatus")) model.StrUserGroupStatus = dr["StrUserGroupStatus"].ToDBString();

           return model;
       }

       public bool GetUserGroupListByUser(ref List<UserGroupInfo> modelList, UserInfo User, bool IncludNoCheck, UserInfo user, ref string strError)
       {
           List<UserGroupInfo> lstModel = new List<UserGroupInfo>();
           try
           {
               using (SqlDataReader dr = _db.GetUserGroupListByUserID(User, IncludNoCheck))
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
               strError = "获取用户仓库列表失败！" + ex.Message + "\r\n" + ex.TargetSite;
               return false;
           }
           finally
           {
           }
       }
    }
}
