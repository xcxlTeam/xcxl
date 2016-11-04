using BLL.Basic.User;
using BLL.Common;
using BLL.JSONUtil;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace BLL.Check
{
  public  class ProfitLoss_Func
    {
      private ProfitLoss_DB _db = new ProfitLoss_DB();

      public bool GetProfitLossListByPage(ref List<ProfitLossInfo> modelList, ProfitLossInfo model, ref DividPage page, UserInfo user, ref string strError)
      {

          List<ProfitLossInfo> lstModel = new List<ProfitLossInfo>();
          try
          {
              using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_ProfitLoss", GetFilterSql(model, user), "*", "Order By CheckID Desc, AreaNo, MaterialNo, AccountQty Desc, ScanQty Desc"))
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

      private string GetFilterSql(ProfitLossInfo model, UserInfo user)
      {
          try
          {
              string strSql = "where (WarehouseNo is not null or ScanWarehouseNo is not null) ";
              bool hadWhere = true;


              if (!string.IsNullOrEmpty(model.CheckNo))
              {
                  strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                  strSql += " CheckNo Like '%" + model.CheckNo + "%' ";
                  hadWhere = true;
              }

              if (model.CheckID >= 1)
              {
                  strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                  strSql += " CheckID = " + model.CheckID + " ";
                  hadWhere = true;
              }

              if (!string.IsNullOrEmpty(model.WarehouseNo))
              {
                  strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                  strSql += " (WarehouseNo Like '%" + model.WarehouseNo + "%' or WarehouseName Like '%" + model.WarehouseNo + "%') ";
                  hadWhere = true;
              }

              if (!string.IsNullOrEmpty(model.HouseNo))
              {
                  strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                  strSql += " (HouseNo Like '%" + model.HouseNo + "%' or HouseName Like '%" + model.HouseNo + "%') ";
                  hadWhere = true;
              }

              if (!string.IsNullOrEmpty(model.AreaNo))
              {
                  strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                  strSql += " (AreaNo Like '%" + model.AreaNo + "%' or AreaName Like '%" + model.AreaNo + "%') ";
                  hadWhere = true;
              }

              if (!string.IsNullOrEmpty(model.ScanWarehouseNo))
              {
                  strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                  strSql += " (ScanWarehouseNo Like '%" + model.ScanWarehouseNo + "%' or ScanWarehouseName Like '%" + model.ScanWarehouseNo + "%') ";
                  hadWhere = true;
              }

              if (!string.IsNullOrEmpty(model.ScanHouseNo))
              {
                  strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                  strSql += " (ScanHouseNo Like '%" + model.ScanHouseNo + "%' or ScanHouseName Like '%" + model.ScanHouseNo + "%') ";
                  hadWhere = true;
              }

              if (!string.IsNullOrEmpty(model.ScanAreaNo))
              {
                  strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                  strSql += " (ScanAreaNo Like '%" + model.ScanAreaNo + "%' or ScanAreaName Like '%" + model.ScanAreaNo + "%') ";
                  hadWhere = true;
              }

              if (!string.IsNullOrEmpty(model.MaterialNo))
              {
                  strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                  strSql += " (MaterialNo Like '%" + model.MaterialNo + "%' or MaterialDesc Like '%" + model.MaterialNo + "%') ";
                  hadWhere = true;
              }

              if (!string.IsNullOrEmpty(model.SerialNo))
              {
                  strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                  strSql += " SerialNo Like '%" + model.SerialNo + "%' ";
                  hadWhere = true;
              }

              if (!string.IsNullOrEmpty(model.BatchNo))
              {
                  strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                  strSql += " BatchNo Like '%" + model.BatchNo + "%' ";
                  hadWhere = true;
              }

              if (!string.IsNullOrEmpty(model.SN))
              {
                  strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                  strSql += " SN Like '%" + model.SN + "%' ";
                  hadWhere = true;
              }

              return strSql;
          }
          catch
          {
              return string.Empty;
          }
      }

      private ProfitLossInfo GetModelFromDataReader(SqlDataReader dr)
      {
          ProfitLossInfo model = new ProfitLossInfo();
          if (Common_Func.readerExists(dr, "CheckID")) model.CheckID = dr["CheckID"].ToInt32();
          if (Common_Func.readerExists(dr, "WarehouseNo")) model.WarehouseNo = dr["WarehouseNo"].ToDBString();
          if (Common_Func.readerExists(dr, "HouseNo")) model.HouseNo = dr["HouseNo"].ToDBString();
          if (Common_Func.readerExists(dr, "AreaNo")) model.AreaNo = dr["AreaNo"].ToDBString();
          if (Common_Func.readerExists(dr, "ScanWarehouseNo")) model.ScanWarehouseNo = dr["ScanWarehouseNo"].ToDBString();
          if (Common_Func.readerExists(dr, "ScanHouseNo")) model.ScanHouseNo = dr["ScanHouseNo"].ToDBString();
          if (Common_Func.readerExists(dr, "ScanAreaNo")) model.ScanAreaNo = dr["ScanAreaNo"].ToDBString();
          if (Common_Func.readerExists(dr, "Barcode")) model.Barcode = dr["Barcode"].ToDBString();
          if (Common_Func.readerExists(dr, "SerialNo")) model.SerialNo = dr["SerialNo"].ToDBString();
          if (Common_Func.readerExists(dr, "BatchNo")) model.BatchNo = dr["BatchNo"].ToDBString();
          if (Common_Func.readerExists(dr, "SN")) model.SN = dr["SN"].ToDBString();
          if (Common_Func.readerExists(dr, "MaterialNo")) model.MaterialNo = dr["MaterialNo"].ToDBString();
          if (Common_Func.readerExists(dr, "MaterialDesc")) model.MaterialDesc = dr["MaterialDesc"].ToDBString();
          if (Common_Func.readerExists(dr, "AccountQty")) model.AccountQty = dr["AccountQty"].ToDecimal();
          if (Common_Func.readerExists(dr, "ScanQty")) model.ScanQty = dr["ScanQty"].ToDecimal();

          if (Common_Func.readerExists(dr, "WarehouseName")) model.WarehouseName = dr["WarehouseName"].ToDBString();
          if (Common_Func.readerExists(dr, "HouseName")) model.HouseName = dr["HouseName"].ToDBString();
          if (Common_Func.readerExists(dr, "AreaName")) model.AreaName = dr["AreaName"].ToDBString();
          if (Common_Func.readerExists(dr, "WarehouseName")) model.WarehouseName = dr["WarehouseName"].ToDBString();
          if (Common_Func.readerExists(dr, "HouseName")) model.HouseName = dr["HouseName"].ToDBString();
          if (Common_Func.readerExists(dr, "AreaName")) model.AreaName = dr["AreaName"].ToDBString();

          model.DifferenceQty = model.AccountQty - model.ScanQty;
          if(model.DifferenceQty<0)
          {
              model.ProfitLoss = 2;
              model.StrProfitLoss = "盘盈";
          }
          else if (model.DifferenceQty > 0)
          {
              model.ProfitLoss = 3;
              model.StrProfitLoss = "盘亏";
          }
          else
          {
              model.ProfitLoss = 1;
              model.StrProfitLoss = "平衡";
          }
          model.DifferenceQty = Math.Abs(model.DifferenceQty);

          return model;
      }
    }
}
