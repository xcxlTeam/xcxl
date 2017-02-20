using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BLL.Common;
using BLL.Basic.P2B;
using BLL.Basic.User;
using BLL.Stock;

namespace BLL.Voucher
{
    public class ReadProd_Func
    {
        private Prod GetModelFromDataReader(SqlDataReader dr)
        {
            Prod model = new Prod();
            model.ProdOrdID = dr["ProdOrdID"].ToDBString();
            model.StartDate = dr["StartDate"].ToDateTime();
            model.EndDate = dr["EndDate"].ToDateTime();
            model.PInvtID = dr["PInvtID"].ToDBString();
            model.QtytoProd = dr["QtytoProd"].ToDecimal();
            model.LotSerNbr = dr["LotSerNbr"].ToDBString();
            model.ProdDate = dr["ProdDate"].ToDateTime();
            model.ShipDate = dr["ShipDate"].ToDateTime();
            model.SiteID = dr["SiteID"].ToDBString();
            model.WhseLoc = dr["WhseLoc"].ToDBString();
            model.Remark2 = dr["Remark2"].ToCHString();
            model.SONbr = dr["SONbr"].ToDBString();
            model.MInvtID = dr["MInvtID"].ToDBString();
            model.QtyReq = dr["QtyReq"].ToDecimal();

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

        private Prod GetModelFromDataReader(SqlDataReader dr,string prodMgrID)
        {
            Prod model = new Prod();
            model.ProdOrdID = dr["ProdOrdID"].ToDBString();
            model.StartDate = dr["StartDate"].ToDateTime();
            model.EndDate = dr["EndDate"].ToDateTime();
            model.PInvtID = dr["PInvtID"].ToDBString();
            model.QtytoProd = dr["QtytoProd"].ToDecimal();
            model.LotSerNbr = dr["LotSerNbr"].ToDBString();
            model.ProdDate = dr["ProdDate"].ToDateTime();
            model.ShipDate = dr["ShipDate"].ToDateTime();
            model.SiteID = dr["SiteID"].ToDBString();
            model.WhseLoc = dr["WhseLoc"].ToDBString();
            model.Remark2 = dr["Remark2"].ToCHString();
            model.SONbr = dr["SONbr"].ToDBString();
            model.MInvtID = dr["MInvtID"].ToDBString();
            model.QtyReq = dr["QtyReq"].ToDecimal();
            model.ProdMgrID = prodMgrID;

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
        public bool GetProdDetailByProdOrdID(Prod model,ref List<Prod> lstProd, ref string strError)
        {
            ReadAPI_DB DB = new ReadAPI_DB();
            lstProd = new List<Prod>();
            try
            {
                string prodmgrID = string.Empty;
                using (SqlDataReader dr = DB.ReadData(ReadApiType.PRODBOOK_1, model.ProdOrdID))
                {
                    if(dr.Read())
                    {
                        prodmgrID = dr["ProdMgrID"].ToDBString();
                    }
                }
                if(string.IsNullOrEmpty(prodmgrID))
                {
                    strError = "该订单暂无制法数据";
                    return false;
                }
                using (SqlDataReader dr = DB.ReadData(ReadApiType.PROD, model.ProdOrdID))
                {
                    while(dr.Read())
                    {
                        model = (GetModelFromDataReader(dr, prodmgrID));
                        lstProd.Add(model);
                    }
                    if (lstProd.Count==0)
                    {
                        strError = "找不到任何数据";
                        return false;
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

        void calcData(List<Prod> lstProd,UserInfo user)
        {
            string strError = string.Empty;

            #region 制法及建筑获取
            Building_Func bf = new Building_Func();
            Preparation_Func pf = new Preparation_Func();
            List<Building> lstB = new List<Building>();
            Building b = new Building();
            List<Preparation> lstP = new List<Preparation>();
            Preparation p = new Preparation();
            bf.GetBuildingList(ref lstB, b, user, ref strError);
            pf.GetPreparationList(ref lstP, p, user, ref strError);
            foreach (var outer in lstP)
            {
                foreach (var inner in lstB)
                {
                    if (outer.bid == inner.ID)
                    {
                        if (inner.lstP != null)
                            lstP = new List<Preparation>();
                        inner.lstP.Add(outer);
                    }
                }
            } 
            #endregion

            List<Prod> lstMetaData=new List<Prod>();
            List<Prod> lstTmp=new List<Prod>();
            foreach (var item in lstProd)
            {
                GetProdDetailByProdOrdID(item, ref lstTmp, ref strError);
                lstMetaData.AddRange(lstTmp);
            }

            List<string> lstMinvtID = lstMetaData.Select(s=>s.MInvtID).Distinct().ToList();
            foreach (var item in lstMetaData)
            {
                item.BuildingNo=lstB.FirstOrDefault(s=>s.lstP.Exists(x=>x.pCode.Equals(item.ProdMgrID))).bNo;
            }
            string strArrayMaterialNo = string.Empty;
            foreach (var item in lstMinvtID)
            {
                strArrayMaterialNo += item + ",";
            }
            strArrayMaterialNo = strArrayMaterialNo.Substring(0, strArrayMaterialNo.Length-1);
            #region 获取线边仓及车间仓库存
            Stock_DB stb = new Stock_DB();
            List<StockHead_Model> lstStockSum=new List<StockHead_Model>();
            stb.QueryStockSumForTransfer(out lstStockSum, strArrayMaterialNo, out strError);
            #endregion
        }
    }
}
