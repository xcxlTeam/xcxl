using BLL.Basic.User;
using BLL.Common;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.PrintBarcode
{
   public class PrintRecord_Func
    {

        public bool GetPrintRecordListByPage(ref List<Barcode_Model> modelList, Barcode_Model model, ref DividPage page, UserInfo user, ref string strError)
        {
            if (page == null) page = new DividPage();
            List<Barcode_Model> lstModel = new List<Barcode_Model>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "v_printrecord", GetFilterSql(model, user), "barcodetype, strbarcodetype, supcode, supname, vouchertype, strvouchertype, sum(printqty) printqty", "Order by SupCode, BarcodeType, VoucherType, sum(PrintQty) desc"))
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

        private string GetFilterSql(Barcode_Model model, UserInfo user)
        {
            try
            {
                string strSql = "";
                bool hadWhere = false;


                if (!string.IsNullOrEmpty(model.SUPCODE))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (SUPCODE LIKE '%" + model.SUPCODE + "%' OR SUPNAME LIKE '%" + model.SUPCODE + "%') ";
                    hadWhere = true;
                }

                if (model.BARCODETYPE >= 1)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " BARCODETYPE = '" + model.BARCODETYPE + "' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.VOUCHERTYPE))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " VOUCHERTYPE = '" + model.VOUCHERTYPE + "' ";
                    hadWhere = true;
                }
                else
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (VOUCHERTYPE = '10' or VOUCHERTYPE = '70') ";
                    hadWhere = true;
                }

                if (model.StartTime != null)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " PrintTime >= " + model.StartTime.ToDateTime().Date.ToSqlTimeString() + " ";
                    hadWhere = true;
                }

                if (model.EndTime != null)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " PrintTime <= " + model.EndTime.ToDateTime().AddDays(1).Date.ToSqlTimeString() + " ";
                    hadWhere = true;
                }

                strSql += " group by barcodetype, strbarcodetype, supcode, supname, vouchertype, strvouchertype ";

                return strSql;
            }
            catch
            {
                return string.Empty;
            }
        }

        private Barcode_Model GetModelFromDataReader(SqlDataReader dr)
        {
            Barcode_Model model = new Barcode_Model();
            model.BARCODETYPE = dr["BARCODETYPE"].ToDecimal();
            model.StrBarcodeType = dr["StrBarcodeType"].ToDBString();
            model.SUPCODE = dr["SUPCODE"].ToDBString();
            model.SUPNAME = dr["SUPNAME"].ToDBString();
            model.VOUCHERTYPE = dr["VOUCHERTYPE"].ToDBString();
            model.StrVoucherType = dr["StrVoucherType"].ToDBString();
            model.PRINTQTY = dr["PRINTQTY"].ToDecimal();

            return model;
        }
    }
}
