using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BLL.Common;

namespace BLL.Voucher
{
    public class ReadReceipt_Func
    {
        private Receipt GetModelFromDataReader(SqlDataReader dr)
        {
            Receipt model = new Receipt();
            model.Address = dr["Allergic"].ToCHString();
            model.LineRef = dr["LineRef"].ToDBString();
            model.Name = dr["Name"].ToCHString();
            model.Phone = dr["Name"].ToDBString();
            model.PoNbr = dr["PoNbr"].ToDBString();
            model.PromDate = dr["PromDate"].ToDateTime();
            model.QtyOrd = dr["QtyOrd"].ToDecimal();
            model.QtyRcvd = dr["QtyRcvd"].ToDecimal();
            model.VendID = dr["VendID"].ToInt32();
            model.PurchUnit = dr["PurchUnit"].ToDBString();

            model.Allergic = dr["Allergic"].ToCHString();
            model.CHDesc = dr["CHDesc"].ToCHString();
            model.Descr = dr["Descr"].ToDBString();
            model.InvtID = dr["InvtID"].ToDBString();
            model.InvtType = dr["InvtType"].ToDBString();
            model.NetWt = dr["NetWt"].ToDecimal();
            model.SceneMaterial = dr["SceneMaterial"].ToDBString();
            model.ShelfLife = dr["ShelfLife"].ToInt32();
            model.StdGrossWt = dr["StdGrossWt"].ToDecimal();
            model.StdTareWt = dr["StdTareWt"].ToDecimal();
            model.StkUnit = dr["StkUnit"].ToDBString();

            return model;
        }

        public bool GetReceiptByPoNbr(ref Receipt model, ref string strError)
        {
            ReadAPI_DB DB = new ReadAPI_DB();
            try
            {
                using (SqlDataReader dr = DB.ReadData(ReadApiType.RECEIPT, model.PoNbr))
                {
                    if (dr.Read())
                    {
                        model = (GetModelFromDataReader(dr));
                    }
                    return true;
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


    }
}
