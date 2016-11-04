using BLL.Basic.User;
using BLL.Common;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Basic.House
{
   public class House_Func
   {
       private House_DB _db = new House_DB();

       public bool ExistsHouseNo(HouseInfo model, bool bIncludeDel, UserInfo user, ref string strError)
       {
           try
           {
               return _db.ExistsHouseNo(model, bIncludeDel);
           }
           catch (Exception ex)
           {
               strError = ex.Message;
               return false;
           }
       }

       public bool SaveHouse(ref HouseInfo model, UserInfo user, ref string strError)
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
               return _db.SaveHouse(ref model);
           }
           catch (Exception ex)
           {
               strError = ex.Message;
               return false;
           }
       }


       public bool DeleteHouseByID(HouseInfo model, UserInfo user, ref string strError)
       {
           try
           {
               return _db.DeleteHouseByID(model);
           }
           catch (Exception ex)
           {
               strError = ex.Message;
               return false;
           }
       }


       public bool GetHouseByID(ref HouseInfo model, UserInfo user, ref string strError)
       {
           try
           {
               using (SqlDataReader dr = _db.GetHouseByID(model))
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


       public bool GetHouseListByPage(ref List<HouseInfo> modelList, HouseInfo model, ref DividPage page, UserInfo user, ref string strError)
       {
           if (page == null) page = new DividPage();
           List<HouseInfo> lstModel = new List<HouseInfo>();
           try
           {
               using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_House", GetFilterSql(model, user), "*", "Order By WarehouseNo,HouseNo,ID Desc"))
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

       public bool GetHouseList(ref List<HouseInfo> modelList, HouseInfo model, UserInfo user, ref string strError)
       {
           List<HouseInfo> lstModel = new List<HouseInfo>();
           try
           {
               using (SqlDataReader dr = Common_DB.QueryAll("V_House", GetFilterSql(model, user), "*", "Order By WarehouseNo,HouseNo,ID Desc"))
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

       private string GetFilterSql(HouseInfo model, UserInfo user)
       {
           try
           {
               string strSql = " Where ISNULL(IsDel,1) = 1 ";
               bool hadWhere = true;


               if (!string.IsNullOrEmpty(model.WarehouseNo))
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " (WarehouseNo LIKE '%" + model.WarehouseNo + "%' OR WarehouseName Like '%" + model.WarehouseNo + "%') ";
                   hadWhere = true;
               }

               //if (!string.IsNullOrEmpty(model.WarehouseName))
               //{
               //    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
               //    strSql += " WarehouseName LIKE '%" + model.WarehouseName + "%' ";
               //    hadWhere = true;
               //}

               if (!string.IsNullOrEmpty(model.HouseNo))
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " (HouseNo LIKE '%" + model.HouseNo + "%' OR HouseName Like '%" + model.HouseNo + "%') ";
                   hadWhere = true;
               }

               //if (!string.IsNullOrEmpty(model.HouseName))
               //{
               //    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
               //    strSql += " HouseName LIKE '%" + model.HouseName + "%' ";
               //    hadWhere = true;
               //}

               if (!string.IsNullOrEmpty(model.AreaNo))
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " ID In (Select HouseID From T_Area Where AreaNo LIKE '%" + model.AreaNo + "%' OR AreaName Like '%" + model.AreaNo + "%') ";
                   hadWhere = true;
               }

               //if (!string.IsNullOrEmpty(model.AreaName))
               //{
               //    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
               //    strSql += " ID In (Select HouseID From T_Area Where AreaName LIKE '%" + model.AreaName + "%') ";
               //    hadWhere = true;
               //}

               if (model.WarehouseID >=1)
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " WarehouseID = " + model.WarehouseID + " ";
                   hadWhere = true;
               }

               if (!string.IsNullOrEmpty(model.Address))
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " Address Like '%" + model.Address + "%' ";
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

       private HouseInfo GetModelFromDataReader(SqlDataReader dr)
       {
           HouseInfo model = new HouseInfo();
           model.ID = dr["ID"].ToInt32();
           model.HouseNo = dr["HOUSENO"].ToDBString();
           model.HouseName = dr["HOUSENAME"].ToDBString();
           model.HouseType = dr["HOUSETYPE"].ToInt32();
           model.ContactUser = dr["CONTACTUSER"].ToDBString();
           model.ContactPhone = dr["CONTACTPHONE"].ToDBString();
           model.AreaCount = dr["AREACOUNT"].ToInt32();
           model.AreaUsingCount = dr["AREAUSINGCOUNT"].ToInt32();
           model.Address = dr["ADDRESS"].ToDBString();
           model.LocationDesc = dr["LOCATIONDESC"].ToDBString();
           model.HouseStatus = dr["HouseStatus"].ToInt32();
           model.WarehouseID = dr["WAREHOUSEID"].ToInt32();
           model.IsDel = dr["ISDEL"].ToInt32();
           model.Creater = dr["CREATER"].ToDBString();
           model.CreateTime = dr["CREATETIME"].ToDateTime();
           model.Modifyer = dr["MODIFYER"].ToDBString();
           model.ModifyTime = dr["MODIFYTIME"].ToDateTimeNull();

           if (Common_Func.readerExists(dr, "WarehouseNo")) model.WarehouseNo = dr["WarehouseNo"].ToDBString();
           if (Common_Func.readerExists(dr, "WarehouseName")) model.WarehouseName = dr["WarehouseName"].ToDBString();
           if (Common_Func.readerExists(dr, "StrHouseStatus")) model.StrHouseStatus = dr["StrHouseStatus"].ToDBString();

           model.AreaRate = model.AreaCount >= 1 ? model.AreaUsingCount.ToDecimal() / model.AreaCount.ToDecimal() : 0;

           return model;
       }
    }
}
