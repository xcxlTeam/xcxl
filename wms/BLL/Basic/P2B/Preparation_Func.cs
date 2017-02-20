using BLL.Basic.User;
using BLL.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BLL.Basic.P2B
{
    public class Preparation_Func
   {
        private Preparation_DB _db = new Preparation_DB();

       public bool ExistspCode(Preparation model, bool bIncludeDel, UserInfo user, ref string strError)
       {
           try
           {
               return _db.ExistspCode(model, bIncludeDel);
           }
           catch (Exception ex)
           {
               strError = ex.Message;
               return false;
           }
       }

       public bool SavePreparation(ref Preparation model, UserInfo user, ref string strError)
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
               return _db.SavePreparation(ref model);
           }
           catch (Exception ex)
           {
               strError = ex.Message;
               return false;
           }
       }


       public bool DeletePreparationByID(Preparation model, UserInfo user, ref string strError)
       {
           try
           {
               return _db.DeletePreparationByID(model);
           }
           catch (Exception ex)
           {
               strError = ex.Message;
               return false;
           }
       }


       public bool GetPreparationByID(ref Preparation model, UserInfo user, ref string strError)
       {
           try
           {
               using (SqlDataReader dr = _db.GetPreparationByID(model))
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


       public bool GetPreparationListByPage(ref List<Preparation> modelList, Preparation model, ref DividPage page, UserInfo user, ref string strError)
       {
           if (page == null) page = new DividPage();
           List<Preparation> lstModel = new List<Preparation>();
           try
           {
               using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_Preparation", GetFilterSql(model, user), "*", "Order By pCode,ID Desc"))
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

       public bool GetPreparationList(ref List<Preparation> modelList, Preparation model, UserInfo user, ref string strError)
       {
           List<Preparation> lstModel = new List<Preparation>();
           try
           {
               using (SqlDataReader dr = Common_DB.QueryAll("V_Preparation", GetFilterSql(model, user), "*", "Order By pCode,ID Desc"))
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
       }

       private string GetFilterSql(Preparation model, UserInfo user)
       {
           try
           {
               string strSql = " Where ISNULL(IsDel,1) = 1 ";
               bool hadWhere = true;

               if (!string.IsNullOrEmpty(model.pCode))
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " (pCode LIKE '%" + model.pCode + "%' OR pName Like '%" + model.pCode + "%') ";
                   hadWhere = true;
               }

               //if (!string.IsNullOrEmpty(model.pName))
               //{
               //    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
               //    strSql += " HouseName LIKE '%" + model.pName + "%' ";
               //    hadWhere = true;
               //}

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

       private Preparation GetModelFromDataReader(SqlDataReader dr)
       {
           Preparation model = new Preparation();
           model.ID = dr["ID"].ToInt32();
           model.pCode = dr["pCode"].ToDBString();
           model.pName = dr["pName"].ToDBString();
           model.IsDel = dr["ISDEL"].ToInt32();
           model.Creater = dr["CREATER"].ToDBString();
           model.CreateTime = dr["CREATETIME"].ToDateTime();
           model.Modifyer = dr["MODIFYER"].ToDBString();
           model.ModifyTime = dr["MODIFYTIME"].ToDateTimeNull();
           model.bid = dr["bid"].ToInt32();

           return model;
       }
    }
}
