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
        private ProdDetails GetModelFromDataReader(SqlDataReader dr)
        {
            ProdDetails model = new ProdDetails();
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

        private ProdHead GetHeadModelFromDataReader(SqlDataReader dr, string prodMgrID)
        {
            ProdHead model = new ProdHead();
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
            model.ProdMgrID = prodMgrID;

            return model;
        }
        public bool GetProdDetailByProdOrdID(ProdHead model, ref ProdHead prod, ref string strError)
        {
            ReadAPI_DB DB = new ReadAPI_DB();
            try
            {
                string prodmgrID = string.Empty;
                using (SqlDataReader dr = DB.ReadData(ReadApiType.PRODBOOK_1, model.ProdOrdID))
                {
                    if (dr.Read())
                    {
                        prodmgrID = dr["ProdMgrID"].ToDBString();
                    }
                }
                if (string.IsNullOrEmpty(prodmgrID))
                {
                    strError = "该订单暂无制法数据";
                    return false;
                }
                using (SqlDataReader dr = DB.ReadData(ReadApiType.PROD, model.ProdOrdID))
                {
                    while (dr.Read())
                    {
                        if (prod == null)
                        {
                            prod = (GetHeadModelFromDataReader(dr, prodmgrID));
                            prod.lstDetails = new List<ProdDetails>();
                        }
                        prod.lstDetails.Add(GetModelFromDataReader(dr));
                    }
                    if (prod == null)
                    {
                        throw new Exception("未找到数据！");
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

        void calcData(List<ProdHead> lstProd, UserInfo user)
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

            List<ProdHead> lstMetaData = new List<ProdHead>();
            List<ProdDetails> lstMetaDetails = new List<ProdDetails>();
            List<ProdDetails> lstGroupDetails = new List<ProdDetails>();//按物料和建筑编号分组的需求信息
            ProdHead TmpProd = new ProdHead();
            foreach (var item in lstProd)
            {
                GetProdDetailByProdOrdID(item, ref TmpProd, ref strError);
                lstMetaData.Add(TmpProd);
            }
            List<string> lstMinvtID = new List<string>();
            foreach (var item in lstMetaData)
            {
                lstMinvtID = lstMinvtID.Union<string>(item.lstDetails.Select(s => s.MInvtID).Distinct().ToList()).ToList();
            }
            foreach (var item in lstMetaData)
            {
                item.BuildingNo = lstB.FirstOrDefault(s => s.lstP.Exists(x => x.pCode.Equals(item.ProdMgrID))).bNo;
                foreach (var detail in item.lstDetails)
                {
                    detail.ProdMgrID = item.ProdMgrID;
                    detail.BuildingNo = item.BuildingNo;
                    detail.iGrade = lstB.FirstOrDefault(s => s.bNo.Equals(detail.BuildingNo)).iGrade;
                }
                lstMetaDetails.AddRange(item.lstDetails);
            }
            foreach (var item in lstMetaDetails)
            {
                ProdDetails model = lstGroupDetails.Find(s => s.BuildingNo.Equals(item.BuildingNo) && s.MInvtID.Equals(item.MInvtID));
                if (model == null)
                {
                    lstGroupDetails.Add(item);
                }
                else
                {
                    model.QtyReq += item.QtyReq;
                }
            }
            lstGroupDetails = (from model in lstGroupDetails orderby model.InvtID, model.iGrade select model).ToList();
            string strArrayMaterialNo = string.Empty;
            foreach (var item in lstMinvtID)
            {
                strArrayMaterialNo += item;
            }
            strArrayMaterialNo = strArrayMaterialNo.Substring(0, strArrayMaterialNo.Length - 1);
            #region 获取线边仓及车间仓库存
            Stock_DB stb = new Stock_DB();
            List<StockHead_Model> lstStockSum = new List<StockHead_Model>();
            stb.QueryStockSumForTransfer(out lstStockSum, strArrayMaterialNo, out strError);
            #endregion
            List<StockReader> lstReader = new List<StockReader>();
            foreach (var item in lstGroupDetails)
            {
                StockReader sr = lstReader.Find(s => s.InvtID.Equals(item.InvtID));
                bool bFound = true;
                if (string.IsNullOrEmpty(sr.InvtID))
                {
                    bFound = false;
                    sr = new StockReader();
                    sr.InvtID = item.InvtID;
                    sr.workshopStock = lstStockSum.FirstOrDefault(model => model.MaterialNo == item.InvtID && model.WarehouseNo == item.BuildingNo).iQuantity;
                    sr.currentStock = lstStockSum.FirstOrDefault(model => model.MaterialNo == item.InvtID && model.WarehouseNo == "01").iQuantity;
                }
                if (bFound)//获取当前料车间库存
                {
                    sr.workshopStock = lstStockSum.FirstOrDefault(model => model.MaterialNo == item.InvtID && model.WarehouseNo == item.BuildingNo).iQuantity;
                }
                if (item.SceneMaterial.Trim().Equals("1"))//现场物料，不用返还
                {
                    item.sInvType = "现场物料";
                    if (item.QtyReq <= sr.workshopStock)
                    {
                        item.iOperate = 0;
                        item.sOperate = "无动作";
                    }
                    else
                    {
                        item.iOperate = 1;
                        item.sOperate = "领料";
                        if (item.QtyReq - sr.workshopStock <= sr.currentStock - sr.useageStock)
                        {
                            item.dTransfer = item.QtyReq - sr.workshopStock;
                            sr.useageStock += item.QtyReq - sr.workshopStock;
                        }
                        else
                        {
                            item.dTransfer = sr.currentStock - sr.useageStock;
                            sr.useageStock = sr.currentStock;
                        }
                    }
                }
                else if (bMustReturn(item))
                {
                    item.sInvType = "必返品";
                    item.iOperate = -2;
                    if (item.QtyReq <= sr.workshopStock)
                    {
                        //item.iOperate = item.QtyReq == sr.workshopStock ? 0 : -2;
                        item.sOperate = item.QtyReq == sr.workshopStock ? "无动作" : "返料";
                        item.dTransfer = sr.workshopStock - item.QtyReq;
                    }
                    else
                    {
                        //item.iOperate = 1;
                        item.sOperate = "领料";
                        if (item.QtyReq - sr.workshopStock <= sr.currentStock - sr.useageStock)
                        {
                            item.dTransfer = item.QtyReq - sr.workshopStock;
                            sr.useageStock += item.QtyReq - sr.workshopStock;
                        }
                        else
                        {
                            item.dTransfer = sr.currentStock - sr.useageStock;
                            sr.useageStock = sr.currentStock;
                        }
                    }
                }
                else//普通料
                {
                    item.sInvType = "普通料";
                    if (item.QtyReq <= sr.workshopStock)
                    {
                        item.iOperate = item.QtyReq == sr.workshopStock ? 0 : -1;
                        item.sOperate = item.QtyReq == sr.workshopStock ? "无动作" : "返料";
                        item.dTransfer = sr.workshopStock - item.QtyReq;
                    }
                    else
                    {
                        item.iOperate = 1;
                        item.sOperate = "领料";
                        if (item.QtyReq - sr.workshopStock <= sr.currentStock - sr.useageStock)
                        {
                            item.dTransfer = item.QtyReq - sr.workshopStock;
                            sr.useageStock += item.QtyReq - sr.workshopStock;
                        }
                        else
                        {
                            item.dTransfer = sr.currentStock - sr.useageStock;
                            sr.useageStock = sr.currentStock;
                        }
                    }
                }

                if (!bFound)
                    lstReader.Add(sr);
            }



        }
        /// <summary>
        /// 根据物料代码判断是否必返料
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool bMustReturn(Inventory model)
        {
            string str = model.InvtType;
            if (str.Length > 1 && (str.Substring(1, 1).Equals("1") || str.Substring(1, 1).Equals("0")))
            {
                return true;
            }
            return false;
        }

        public struct StockReader
        {
            public string InvtID { get; set; }
            /// <summary>
            /// 建筑编号
            /// </summary>
            public string bNo { get; set; }
            /// <summary>
            /// 车间库存总量
            /// </summary>
            public decimal workshopStock { get; set; }
            /// <summary>
            /// 大库现存量
            /// </summary>
            public decimal currentStock { get; set; }
            /// <summary>
            /// 已用量
            /// </summary>
            public decimal useageStock { get; set; }

        }


    }
}
