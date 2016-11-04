using BLL.Basic.User;
using BLL.Common;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Quality
{
    public class QualityExport_Func
    {

        /// <summary>
        /// 获取检验通知书导出数据
        /// </summary>
        /// <param name="strErrMsg"></param>
        /// <returns></returns>
        public bool GetQualityExportListByPage(ref List<QuanlityExportInfo> modelList, QuanlityExportInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            if (page == null) page = new DividPage();
            List<QuanlityExportInfo> lstModel = new List<QuanlityExportInfo>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_GetQualityExportInfo", GetFilterSql(model, user), "*", "Order By CreateDate Desc"))
                {
                    while (dr.Read())
                    {
                        lstModel.Add(GetQualityExport_ModelFromDataReader(dr));
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

        private string GetFilterSql(QuanlityExportInfo model, UserInfo user)
        {
            try
            {
                string strSql = "";
                bool hadWhere = false;


                if (!string.IsNullOrEmpty(model.MaterialDoc))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " MaterialDoc Like '%" + model.MaterialDoc + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.VoucherNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " VoucherNo Like '%" + model.VoucherNo + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.DeliveryNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " DeliveryNo Like '%" + model.DeliveryNo + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.MaterialNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (MaterialNo LIKE '%" + model.MaterialNo + "%' OR MaterialDesc Like '%" + model.MaterialNo + "%') ";
                    hadWhere = true;
                }

                if (model.StartTime != null)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " createdate >= " + model.StartTime.ToDateTime().Date.ToSqlTimeString();
                    hadWhere = true;
                }

                if (model.EndTime != null)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " createdate <= " + model.EndTime.ToDateTime().AddDays(1).Date.ToSqlTimeString();
                    hadWhere = true;
                }


                return strSql;
            }
            catch
            {
                return string.Empty;
            }
        }

        private QuanlityExportInfo GetQualityExport_ModelFromDataReader(SqlDataReader dr)
        {
            QuanlityExportInfo model = new QuanlityExportInfo();
            model.ID = dr["ID"].ToInt32();
            model.CreateDate = dr["createdate"].ToDateTime();
            model.VoucherNo = dr["VoucherNo"].ToDBString();
            model.DeliveryNo = dr["DeliveryNo"].ToDBString();
            model.SupplierNo = dr["SupplierNo"].ToDBString();
            model.SupplierName = dr["SupplierName"].ToDBString();
            model.Plant = dr["Plant"].ToDBString();
            model.MoveType = dr["MoveType"].ToDBString();
            model.MaterialDoc = dr["MaterialDoc"].ToDBString();
            model.PrintedQty = dr["PrintedQty"].ToInt32();
            model.PrintTime = dr["PrintTime"].ToDateTimeNull();
            model.RowNo = dr["RowNo"].ToDBString();
            model.MaterialNo = dr["MaterialNo"].ToDBString();
            model.MaterialDesc = dr["MaterialDesc"].ToDBString();
            model.ReceiveQty = dr["ReceiveQty"].ToDecimal();
            model.Unit = dr["Unit"].ToDBString();
            model.PrdVersion = dr["PrdVersion"].ToDBString();
            model.QualityQty = dr["QualityQty"].ToDecimal();
            model.UnQualityQty = dr["UnQualityQty"].ToDecimal();
            model.QualityType = dr["QualityType"].ToInt32();
            model.StrQualityType = dr["StrQualityType"].ToDBString();

            return model;
        }
    }
}
