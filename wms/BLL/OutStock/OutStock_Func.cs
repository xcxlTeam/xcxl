using BLL.Basic.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.OutStock
{
    public class OutStock_Func
    {
        //public bool GetOutStockInfoForSAP(ref OutStock_Model outStockInfo, UserInfo userModel, ref string strErrMsg) 
        //{
        //    try
        //    {
        //        bool bSucc = false;

        //        if (outStockInfo.VoucherType == 0) 
        //        {
        //            strErrMsg = "领料单据类型错误，请确认！";
        //            return false;
        //        }

        //        if (string.IsNullOrEmpty(outStockInfo.VoucherNo)) 
        //        {
        //            strErrMsg = "请输入单据编号！";
        //            return false;
        //        }
                
        //        OutStock_Post OSP = OutStock_Factory.CreateFactoty(outStockInfo.VoucherType);                

        //        bSucc = OSP.GetMaterialRequestInfoForSAP(ref outStockInfo, userModel, ref strErrMsg);

        //        if (outStockInfo.lstOutStockDetails == null || outStockInfo.lstOutStockDetails.Count == 0)
        //        {
        //            strErrMsg = "领料单表体数据为空！";
        //            bSucc = false;
        //        }

        //        bSucc = GetMaterialKeeper(ref outStockInfo, ref strErrMsg);

        //        GetVoucherTypeName(outStockInfo);

        //        return bSucc;
        //    }
        //    catch (Exception ex) 
        //    {
        //        strErrMsg = "Web异常：" + ex.Message;
        //        return false;
        //    }
        //}

        //private bool GetMaterialKeeper(ref OutStock_Model outStockModel, ref string strErrMsg) 
        //{
        //    List<Material.Material_Model> lstMaterialKeeper = new List<Material.Material_Model>();
        //    Material.Material_SAP MSAP=new Material.Material_SAP();

        //    bool bSucc = MSAP.GetMaterialKeeperForSAP(outStockModel, ref lstMaterialKeeper, ref strErrMsg);

        //    if (bSucc == false) 
        //    {
        //        strErrMsg = strErrMsg + "\r\n物料对应保管员！";
        //        return bSucc;
        //    }

        //    if (lstMaterialKeeper == null || lstMaterialKeeper.Count == 0) 
        //    {
        //        strErrMsg = "获取物料对应保管员失败！";
        //        return false;
        //    }

        //    foreach (var item in outStockModel.lstOutStockDetails) 
        //    {
        //       var lstKeeper= lstMaterialKeeper.FindAll(delegate(Material.Material_Model OSDM) { return OSDM.MaterialNo == item.MaterialNo; });
        //       if (lstKeeper == null || lstKeeper.Count == 0) 
        //       {
        //           bSucc = false;
        //           strErrMsg = "物料：" + item.MaterialNo + " 行号：" + item.RowNo + " 没有对应保管员！";
        //           break;
        //       }
        //       if (lstKeeper.Count == 1) 
        //       {
        //           item.StorageLoc = lstKeeper[0].StorageLoc;
        //           item.MaterialKeeperName = lstKeeper[0].MaterialLeeperName;
        //           item.MaterialKeeperNo = lstKeeper[0].MaterialKeeperNo;
        //       }
        //    }

        //    return bSucc;

        //}

        private void GetVoucherTypeName(OutStock_Model outStockInfo)
        {
            int iVoucherType = outStockInfo.VoucherType;
            outStockInfo.lstOutStockDetails.ForEach(t => t.VoucherTypeName = SelectVoucherTypeName(iVoucherType));
        }

        /// <summary>
        /// 生成下架任务
        /// </summary>
        /// <param name="outStockModel"></param>
        /// <param name="strErrMsg"></param>
        /// <returns></returns>
        public bool CreateOutStokTask(OutStock_Model outStockModel, ref string strErrMsg) 
        {
            try
            {
                bool bSucc = false;

                if (outStockModel == null) 
                {
                    strErrMsg = "客户端传来实体类表头数据为空！";
                    return false;
                }

                if (outStockModel.lstOutStockDetails == null || outStockModel.lstOutStockDetails.Count == 0) 
                {
                    strErrMsg = "客户端传来实体类表体数据为空！";
                    return false;
                }

                if (outStockModel.lstOutStockDetails.Where(t => t.CurrentOutStockQty == 0).Count() == outStockModel.lstOutStockDetails.Count) 
                {
                    strErrMsg = "领料数量都为零，不能生成下架任务！";
                    return false;
                }

                return true;


            }
            catch (Exception ex) 
            {
                strErrMsg = "Web异常：" + ex.Message + ex.StackTrace;
                return false;
            }
        }

        private void GetMaterialSumByKeeper(OutStock_Model outStockModel) 
        {
            //var lstOutSrockDetails = outStockModel.lstOutStockDetails.GroupBy(s => s.MaterialKeeperNo).Select(g => new OutStockDetails_Model
            //{
            //    MaterialNo = g.FirstOrDefault().MaterialNo,
            //    MaterialDesc = g.FirstOrDefault().MaterialDesc,
            //    Plant = g.FirstOrDefault().Plant,
            //    StorageLoc = g.FirstOrDefault().StorageLoc,
            //    VoucherNo = g.
            //}).Where(t => t.VoterQty != 0).ToList();
        }

        private string SelectVoucherTypeName(int iVoucherType)
        {
            string strVoucherTypeName = string.Empty;
            switch (iVoucherType)
            {
                case 80:
                    strVoucherTypeName = "生产补料";
                    break;
                case 90:
                    strVoucherTypeName = "生产转储";
                    break;
                case 100:
                    strVoucherTypeName = "研发领料";
                    break;
                case 110:
                    strVoucherTypeName = "成本中心领料";
                    break;
                case 120:
                    strVoucherTypeName = "生产作业单领料";
                    break;
                case 130:
                    strVoucherTypeName = "外协领料";
                    break;
                case 140:
                    strVoucherTypeName = "换货单";
                    break;
                case 150:
                    strVoucherTypeName = "PO/负PO";
                    break;
                default:
                    strVoucherTypeName = string.Empty;
                    break;
            }
            return strVoucherTypeName;
        }
    }
}
