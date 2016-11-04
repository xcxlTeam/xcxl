using BLL.Basic.User;
using BLL.Common;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace BLL.Basic.Task
{
   public class OverViewExport_Func
   {
       public bool GetOverViewExportListByPage(ref List<OverViewExportInfo> modelList, OverViewExportInfo model, ref DividPage page, UserInfo user, ref string strError)
       {
           if (page == null) page = new DividPage();
           List<OverViewExportInfo> lstModel = new List<OverViewExportInfo>();
           try
           {
               using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_OverViewExport", GetFilterSql(model, user), "*", "Order By CreateDateTime Desc"))
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

       private string GetFilterSql(OverViewExportInfo model, UserInfo user)
       {
           try
           {
               string strSql = "";
               bool hadWhere = false;

               if (model.TaskType >= 1)
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " TaskType = " + model.TaskType + " ";
                   hadWhere = true;
               }

               if (model.VoucherType >= 1)
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " VoucherType = " + model.VoucherType + " ";
                   hadWhere = true;
               }

               if (model.TaskStatus >= 1)
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " TaskStatus = " + model.TaskStatus + " ";
                   hadWhere = true;
               }

               if (model.PostStatus >= 1)
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " PostStatus = " + model.PostStatus + " ";
                   hadWhere = true;
               }

               if (model.IsQuality >= 1)
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " IsQuality = " + model.IsQuality + " ";
                   hadWhere = true;
               }

               if (model.IsShelvePost >= 1)
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " IsShelvePost = " + model.IsShelvePost + " ";
                   hadWhere = true;
               }

               if (model.IsReceivePost >= 1)
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " IsReceivePost = " + model.IsReceivePost + " ";
                   hadWhere = true;
               }

               if (!string.IsNullOrEmpty(model.TaskNo))
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " TaskNo LIKE '%" + model.TaskNo + "%' ";
                   hadWhere = true;
               }

               if (!string.IsNullOrEmpty(model.DeliveryNo))
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " (case vouchertype when 50 then taskno when 60 then taskno else deliveryno end) LIKE '%" + model.DeliveryNo + "%' ";
                   hadWhere = true;
               }

               if (!string.IsNullOrEmpty(model.MaterialDoc))
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " MaterialDoc LIKE '%" + model.MaterialDoc + "%' ";
                   hadWhere = true;
               }

               if (!string.IsNullOrEmpty(model.ReceiveUserNo))
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " (ReceiveUserNo LIKE '%" + model.ReceiveUserNo + "%' OR ReceiveUserName LIKE '%" + model.ReceiveUserNo + "%') ";
                   hadWhere = true;
               }

               if (!string.IsNullOrEmpty(model.SupCusNo))
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " (SupCusNo LIKE '%" + model.SupCusNo + "%' OR SupCusName LIKE '%" + model.SupCusNo + "%') ";
                   hadWhere = true;
               }

               if (!string.IsNullOrEmpty(model.Plant))
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " (Plant LIKE '%" + model.Plant + "%' OR PlantName LIKE '%" + model.Plant + "%') ";
                   hadWhere = true;
               }

               if (model.StartTime != null)
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " CreateDateTime >= " + model.StartTime.ToDateTime().Date.ToSqlTimeString() + " ";
                   hadWhere = true;
               }

               if (model.EndTime != null)
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " CreateDateTime <= " + model.EndTime.ToDateTime().AddDays(1).Date.ToSqlTimeString() + " ";
                   hadWhere = true;
               }

               if (model.WarehouseID > 0)
               {
                   strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                   strSql += " Task_ID IN  (SELECT TASK_ID FROM t_taskwarehouse WHERE WAREHOUSE_ID = " + model.WarehouseID + ") ";
                   hadWhere = true;
               }


               return strSql;
           }
           catch
           {
               return string.Empty;
           }
       }

       private OverViewExportInfo GetModelFromDataReader(SqlDataReader dr)
       {
           OverViewExportInfo model = new OverViewExportInfo();
           model.ID = dr["ID"].ToInt32();
           model.TaskNo = dr["TaskNo"].ToDBString();
           model.VoucherType = dr["VoucherType"].ToInt32();
           model.TaskType = dr["TaskType"].ToInt32();
           model.SupCusNo = dr["SupcusNo"].ToDBString();
           model.SupCusName = dr["SupcusName"].ToDBString();
           model.TaskStatus = dr["TaskStatus"].ToInt32();
           model.TaskIssued = dr["TaskIssued"].ToDateTimeNull();
           model.ReceiveUserNo = dr["ReceiveUserNo"].ToDBString();
           model.CreateDateTime = dr["CreateDateTime"].ToDateTimeNull();
           model.Remark = dr["Remark"].ToDBString();
           model.Reason = dr["Reason"].ToDBString();
           model.CreateUserNo = dr["CreateUserNo"].ToDBString();
           model.IsShelvePost = dr["IsShelvePost"].ToInt32();
           model.DeliveryNo = dr["DeliveryNo"].ToDBString();
           model.IsQuality = dr["IsQuality"].ToInt32();
           model.IsReceivePost = dr["IsReceivePost"].ToInt32();
           model.Plant = dr["Plant"].ToDBString();
           model.PlantName = dr["PlantName"].ToDBString();
           model.StrVoucherType = dr["StrVoucherType"].ToDBString();
           model.StrTaskType = dr["StrTaskType"].ToDBString();
           model.StrIsQuality = dr["StrIsQuality"].ToDBString();
           model.StrIsShelvePost = dr["StrIsShelvePost"].ToDBString();
           model.StrIsReceivePost = dr["StrIsReceivePost"].ToDBString();
           model.StrTaskStatus = dr["StrTaskStatus"].ToDBString();
           model.WarehouseCode = dr["WarehouseCode"].ToDBString();
           model.WarehouseName = dr["WarehouseName"].ToDBString();
           model.ReceiveUserName = dr["ReceiveUserName"].ToDBString();
           model.CreateUserName = dr["CreateUserName"].ToDBString();
           model.PostStatus = dr["PostStatus"].ToInt32();
           model.StrPostStatus = dr["StrPostStatus"].ToDBString();
           model.MaterialDoc = dr["MaterialDoc"].ToDBString();

           model.Task_ID = dr["Task_ID"].ToInt32();
           model.ToAreaNo = dr["ToAreaNo"].ToDBString();
           model.VoucherNo = dr["VoucherNo"].ToDBString();
           model.RowNo = dr["RowNo"].ToDBString();
           model.MaterialNo = dr["MaterialNo"].ToDBString();
           model.MaterialDesc = dr["MaterialDesc"].ToDBString();
           model.Status = dr["Status"].ToInt32();
           model.TaskQty = dr["TaskQty"].ToDecimal();
           model.QualityQty = dr["QualityQty"].ToDecimal();
           model.RemainQty = dr["RemainQty"].ToDecimal();
           model.ShelveQty = dr["ShelveQty"].ToDecimal();
           model.UnQualityQty = dr["UnQualityQty"].ToDecimal();
           model.PostQty = dr["PostQty"].ToDecimal();
           model.Unit = dr["Unit"].ToDBString();
           model.StrStatus = dr["StrStatus"].ToDBString();
           model.IsQualityComp = dr["IsQualityComp"].ToInt32();
           model.StrIsQualityComp = dr["StrIsQualityComp"].ToDBString();
           model.OperatorUserNo = dr["OperatorUserNo"].ToDBString();
           model.OperatorUserName = dr["OperatorUserName"].ToDBString();
           model.CompleteDateTime = dr["CompleteDateTime"].ToDateTimeNull();
           model.OperatorDateTime = dr["OperatorDateTime"].ToDateTimeNull();

           switch (model.VoucherType)
           {
               case 50:
               case 60:
                   if (string.IsNullOrEmpty(model.CreateUserName))
                   {
                       model.ReceiveUserNo = model.CreateUserNo;
                       model.ReceiveUserName = model.CreateUserName;
                   }
                   break;
           }

           return model;
       }
    }
}
