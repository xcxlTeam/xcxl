using BLL.Basic.User;
using BLL.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BLL.Basic.P2B
{
    public class Building_Func
   {
        private Building_DB _db = new Building_DB();

        public bool ExistsbNo(Building model, bool bIncludeDel, UserInfo user, ref string strError)
       {
           try
           {
               return _db.ExistsbNo(model, bIncludeDel);
           }
           catch (Exception ex)
           {
               strError = ex.Message;
               return false;
           }
       }

       public bool SaveBuilding(ref Building model, UserInfo user, ref string strError)
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
               return _db.SaveBuilding(ref model);
           }
           catch (Exception ex)
           {
               strError = ex.Message;
               return false;
           }
       }


       public bool DeleteBuildingByID(Building model, UserInfo user, ref string strError)
       {
           try
           {
               return _db.DeleteBuildingByID(model);
           }
           catch (Exception ex)
           {
               strError = ex.Message;
               return false;
           }
       }


       public bool GetBuildingByID(ref Building model, UserInfo user, ref string strError)
       {
           try
           {
               using (SqlDataReader dr = _db.GetBuildingByID(model))
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


       public bool GetBuildingListByPage(ref List<Building> modelList, Building model, ref DividPage page, UserInfo user, ref string strError)
       {
           if (page == null) page = new DividPage();
           List<Building> lstModel = new List<Building>();
           try
           {
               using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_Building", GetFilterSql(model, user), "*", "Order By bNo,ID Desc"))
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

       public bool GetBuildingList(ref List<Building> modelList, Building model, UserInfo user, ref string strError)
       {
           List<Building> lstModel = new List<Building>();
           try
           {
               using (SqlDataReader dr = Common_DB.QueryAll("V_Building", GetFilterSql(model, user), "*", "Order By bNo,ID Desc"))
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

       private string GetFilterSql(Building model, UserInfo user)
       {
           try
           {
               string strSql = " Where ISNULL(IsDel,1) = 1 ";
               bool hadWhere = true;

               if (!string.IsNullOrEmpty(model.bNo))
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " (bNo LIKE '%" + model.bNo + "%' OR bName Like '%" + model.bNo + "%') ";
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

       private Building GetModelFromDataReader(SqlDataReader dr)
       {
           Building model = new Building();
           model.ID = dr["ID"].ToInt32();
           model.bNo = dr["bNo"].ToDBString();
           model.bName = dr["bName"].ToDBString();
           model.IsDel = dr["ISDEL"].ToInt32();
           model.Creater = dr["CREATER"].ToDBString();
           model.CreateTime = dr["CREATETIME"].ToDateTime();
           model.iGrade = dr["iGrade"].ToInt32();
           model.Modifyer = dr["MODIFYER"].ToDBString();
           model.ModifyTime = dr["MODIFYTIME"].ToDateTimeNull();
           model.WareHouseNo = dr["WareHouseNo"].ToDBString();


           return model;
       }
    }
}
