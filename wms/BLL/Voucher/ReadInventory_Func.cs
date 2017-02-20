using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BLL.Common;

namespace BLL.Voucher
{
    public class ReadInventory_Func
    {
        private Inventory GetModelFromDataReader(SqlDataReader dr)
        {
            Inventory model = new Inventory();
            model.Allergic = dr["Allergic"].ToDBString();
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

        public bool GetInventoryByInvtID(ref Inventory model, ref string strError)
        {
            ReadAPI_DB DB = new ReadAPI_DB();
            try
            {
                using (SqlDataReader dr = DB.ReadData(ReadApiType.INVENTORY, model.InvtID))
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
