using BLL.Basic.User;
using BLL.Common;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace BLL.Basic.Task
{
    public class TaskTrans_Func
    {
        TaskTrans_DB _db = new TaskTrans_DB();

        public bool ExistsTaskTransNo(TaskTransInfo model, bool bIncludeDel, UserInfo user, ref string strError)
        {
            try
            {
                return _db.ExistsTaskTransNo(model, bIncludeDel);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public bool SaveTaskTrans(ref TaskTransInfo model, UserInfo user, ref string strError)
        {
            try
            {
                return _db.SaveTaskTrans(ref model);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }


        public bool DeleteTaskTransByID(TaskTransInfo model, UserInfo user, ref string strError)
        {
            try
            {
                return _db.DeleteTaskTransByID(model);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }


        public bool GetTaskTransByID(ref TaskTransInfo model, UserInfo user, ref string strError)
        {
            try
            {
                using (SqlDataReader dr = _db.GetTaskTransByID(model))
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


        public bool GetTaskTransListByPage(ref List<TaskTransInfo> modelList, TaskTransInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            if (page == null) page = new DividPage();
            List<TaskTransInfo> lstModel = new List<TaskTransInfo>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_TaskTrans", GetFilterSql(model, user), "*", "Order By CreateDate desc,TaskNo,FromAreaNo,ToAreaNo,SerialNo"))
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

        private string GetFilterSql(TaskTransInfo model, UserInfo user)
        {
            try
            {
                string strSql = " Where SerialNo is not null ";
                bool hadWhere = true;

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

                if (!string.IsNullOrEmpty(model.FromWarehouseNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (FromWarehouseNo LIKE '%" + model.FromWarehouseNo + "%' OR FromWarehouseName LIKE '%" + model.FromWarehouseNo + "%') ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.ToWarehouseNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (ToWarehouseNo LIKE '%" + model.ToWarehouseNo + "%' OR ToWarehouseName LIKE '%" + model.ToWarehouseNo + "%') ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.FromHouseNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (FromHouseNo LIKE '%" + model.FromHouseNo + "%' OR FromHouseName LIKE '%" + model.FromHouseNo + "%') ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.ToHouseNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (ToHouseNo LIKE '%" + model.ToHouseNo + "%' OR ToHouseName LIKE '%" + model.ToHouseNo + "%') ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.FromAreaNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (FromHouseNo LIKE '%" + model.FromAreaNo + "%' OR FromHouseName LIKE '%" + model.FromAreaNo + "%') ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.ToAreaNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (ToAreaNo LIKE '%" + model.ToAreaNo + "%' OR ToAreaName LIKE '%" + model.ToAreaNo + "%') ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.MaterialNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (MaterialNo LIKE '%" + model.MaterialNo + "%' OR MaterialDesc LIKE '%" + model.MaterialNo + "%') ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.SerialNo))
                {
                    string[] arr = model.SerialNo.Split('@');
                    if (arr.Length == 4) model.SerialNo = arr[2];

                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " SerialNo LIKE '%" + model.SerialNo + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.SN))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " SN LIKE '%" + model.SN + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.AndalaNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " AndalaNo LIKE '%" + model.AndalaNo + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.DeliveryNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " DeliveryNo LIKE '%" + model.DeliveryNo + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.Creater))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (Creater LIKE '%" + model.Creater + "%' OR CreaterNo LIKE '%" + model.Creater + "%') ";
                    hadWhere = true;
                }

                if (model.StartTime != null)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere); 
                    strSql += " CreateDate >= '" + model.StartTime.ToDateTime().Date.ToString("yyyy-MM-dd 00:00:00") + "' ";
                    hadWhere = true;
                }

                if (model.EndTime != null)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " CreateDate <= '" + model.EndTime.ToDateTime().AddDays(1).Date.ToString("yyyy-MM-dd 00:00:00") + "' ";
                    hadWhere = true;
                }


                return strSql;
            }
            catch
            {
                return string.Empty;
            }
        }

        private TaskTransInfo GetModelFromDataReader(SqlDataReader dr)
        {
            TaskTransInfo model = new TaskTransInfo();
            model.ID = dr["ID"].ToInt32();
            model.TaskType = dr["TaskType"].ToInt32();
            model.FromWarehouseNo = dr["FromWarehouseNo"].ToDBString();
            model.ToWarehouseNo = dr["ToWarehouseNo"].ToDBString();
            model.FromHouseNo = dr["FromHouseNo"].ToDBString();
            model.ToHouseNo = dr["ToHouseNo"].ToDBString();
            model.FromAreaNo = dr["FromAreaNo"].ToDBString();
            model.ToAreaNo = dr["ToAreaNo"].ToDBString();
            model.TaskNo = dr["TaskNo"].ToDBString();
            model.Barcode = dr["Barcode"].ToDBString();
            model.SerialNo = dr["SerialNo"].ToDBString();
            model.VoucherType = dr["VoucherType"].ToInt32();
            model.DeliveryNo = dr["DeliveryNo"].ToDBString();
            model.SupCusCode = dr["SupCusCode"].ToDBString();
            model.SupCusName = dr["SupCusName"].ToDBString();
            model.MaterialNo = dr["MaterialNo"].ToDBString();
            model.MaterialDesc = dr["MaterialDesc"].ToDBString();
            model.Qty = dr["Qty"].ToDecimal();
            model.CreateTime = dr["CreateDate"].ToDateTimeNull();
            if (Common_Func.readerExists(dr, "TaskDetail_ID")) model.TaskDetail_ID = dr["TaskDetail_ID"].ToInt32();
            if (Common_Func.readerExists(dr, "SN")) model.SN = dr["SN"].ToDBString();
            if (Common_Func.readerExists(dr, "AndalaNo")) model.AndalaNo = dr["AndalaNo"].ToDBString();

            if (Common_Func.readerExists(dr, "FromWarehouseName")) model.FromWarehouseName = dr["FromWarehouseName"].ToDBString();
            if (Common_Func.readerExists(dr, "ToWarehouseName")) model.ToWarehouseName = dr["ToWarehouseName"].ToDBString();
            if (Common_Func.readerExists(dr, "FromHouseName")) model.FromHouseName = dr["FromHouseName"].ToDBString();
            if (Common_Func.readerExists(dr, "ToHouseName")) model.ToHouseName = dr["ToHouseName"].ToDBString();
            if (Common_Func.readerExists(dr, "FromAreaName")) model.FromAreaName = dr["FromAreaName"].ToDBString();
            if (Common_Func.readerExists(dr, "ToAreaName")) model.ToAreaName = dr["ToAreaName"].ToDBString();
            if (Common_Func.readerExists(dr, "StrTaskType")) model.StrTaskType = dr["StrTaskType"].ToDBString();
            if (Common_Func.readerExists(dr, "StrVoucherType")) model.StrVoucherType = dr["StrVoucherType"].ToDBString();

            return model;
        }
    }
}
