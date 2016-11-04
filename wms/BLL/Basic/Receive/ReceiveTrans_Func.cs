using BLL.Basic.User;
using BLL.Common;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Basic.Receive
{
    public class ReceiveTrans_Func
    {


        public bool GetReceiveTransListByPage(ref List<ReceiveTransInfo> modelList, ReceiveTransInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            if (page == null) page = new DividPage();
            List<ReceiveTransInfo> lstModel = new List<ReceiveTransInfo>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_ReceiveTrans", GetFilterSql(model, user)))
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

        private string GetFilterSql(ReceiveTransInfo model, UserInfo user)
        {
            try
            {
                string strSql = " Where SerialNo IS NOT NULL ";
                bool hadWhere = true;

                if (model.ReceiveType >= 1)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " ReceiveType = " + model.ReceiveType + " ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.DeliveryNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " DeliveryNo LIKE '%" + model.DeliveryNo + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.TaskNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " TaskNo LIKE '%" + model.TaskNo + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.VoucherNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " VoucherNo LIKE '%" + model.VoucherNo + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.MaterialDoc))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " MaterialDoc LIKE '%" + model.MaterialDoc + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.MaterialNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (MaterialNo LIKE '%" + model.MaterialNo + "%' OR MaterialDesc LIKE '%" + model.MaterialNo + "%') ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.SupplierNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (SupplierNo LIKE '%" + model.SupplierNo + "%' OR SupplierName LIKE '%" + model.SupplierNo + "%') ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.SerialNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (SerialNo LIKE '%" + model.SerialNo + "%' OR Barcode LIKE '%" + model.SerialNo + "%') ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.SN))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " SN LIKE '%" + model.SN + "%' ";
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
                    strSql += " CreateDate >= " + model.StartTime.ToDateTime().Date.ToSqlTimeString() + " ";
                    hadWhere = true;
                }

                if (model.EndTime != null)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " CreateDate <= " + model.EndTime.ToDateTime().AddDays(1).Date.ToSqlTimeString() + " ";
                    hadWhere = true;
                }


                return strSql;
            }
            catch
            {
                return string.Empty;
            }
        }

        private ReceiveTransInfo GetModelFromDataReader(SqlDataReader dr)
        {
            ReceiveTransInfo model = new ReceiveTransInfo();
            model.ID = dr["ID"].ToInt32();
            model.TaskNo = dr["TaskNo"].ToDBString();
            model.DeliveryNo = dr["DeliveryNo"].ToDBString();
            model.VoucherNo = dr["VoucherNo"].ToDBString();
            model.MaterialNo = dr["MaterialNo"].ToDBString();
            model.MaterialDesc = dr["MaterialDesc"].ToDBString();
            model.ReceiveType = dr["ReceiveType"].ToInt32();
            model.SupplierNo = dr["SupplierNo"].ToDBString();
            model.SupplierName = dr["SupplierName"].ToDBString();
            model.MaterialDoc = dr["MaterialDoc"].ToDBString();
            model.MaterialDocDate = dr["MaterialDocDate"].ToDBString();
            model.ReceiveQty = dr["ReceiveQty"].ToDecimal();
            model.PackCount = dr["PackCount"].ToDecimal();
            model.Barcode = dr["Barcode"].ToDBString();
            model.SerialNo = dr["SerialNo"].ToDBString();
            model.Creater = dr["Creater"].ToDBString();
            model.CreateDate = dr["CreateDate"].ToDateTime();
            model.DeliveryQty = dr["DeliveryQty"].ToDecimal();
            model.RowNo = dr["RowNo"].ToDBString();
            model.SN = dr["SN"].ToDBString();
            return model;
        }
    }
}
