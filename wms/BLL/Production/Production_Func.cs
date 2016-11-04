using BLL.Basic.User;
using BLL.DeliveryReceive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.ReceiveGoods;

namespace BLL.Production
{
    public class Production_Func : Receive_Post
    {
        //public string GetProductionInfoForSAP(string strProductionNo)
        //{

        //    DeliveryReceive_DB DRD = new DeliveryReceive_DB();
        //    DeliveryReceive_Model ProductionModel = new DeliveryReceive_Model();
        //    Production_DB PDB=new Production_DB();
        //    try
        //    {
        //        bool bSucc = false;
               
        //        string strErrMsg = string.Empty;

        //        Production_SAP PSAP = new Production_SAP();
        //        bSucc = PSAP.GetProductionInfoForSAP(strProductionNo, ref ProductionModel, ref strErrMsg);

        //        if (bSucc == false)
        //        {
        //            ProductionModel.Status = "E";
        //            ProductionModel.Message = strErrMsg;
        //            return JSONUtil.JSONHelper.ObjectToJson<DeliveryReceive_Model>(ProductionModel);
        //        }

        //        //生产订单已经收货
        //        if (DRD.CheckDeliveryNoIsExist(strProductionNo) >= 1)
        //        {
        //            DeliveryReceiveDetail_Model DRDM = new DeliveryReceiveDetail_Model();
        //            //获取订单数量和已收货数量
        //            DRDM = PDB.GetProductionOldReceiveQty(strProductionNo);
        //            if ((DRDM.CurrentlyDeliveryNum - DRDM.OldReceiveQty) == 0)
        //            {
        //                ProductionModel.Status = "E";
        //                ProductionModel.Message = "生产订单号：" + strProductionNo + "已经收货完成，不能再收货！";
        //                return JSONUtil.JSONHelper.ObjectToJson<DeliveryReceive_Model>(ProductionModel);
        //            }
        //            else 
        //            {
        //                ProductionModel.lstDeliveryDetail[0].OldReceiveQty = DRDM.OldReceiveQty;
        //            }
        //        }

                

        //        ProductionModel.Status = "S";
        //        return JSONUtil.JSONHelper.ObjectToJson<DeliveryReceive_Model>(ProductionModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        ProductionModel.Status = "E";
        //        ProductionModel.Message = "Web异常" + ex.Message;
        //        return JSONUtil.JSONHelper.ObjectToJson<DeliveryReceive_Model>(ProductionModel);
        //    }
        //}

        //public bool GetProductionInfoForSAP(string strProductionNo, ref DeliveryReceive_Model DeliveryModel, ref string strErrMsg)
        //{
        //    DeliveryReceive_Model ProductionModel = new DeliveryReceive_Model();

        //    try
        //    {
        //        bool bSucc = false;

        //        Production_SAP PSAP = new Production_SAP();
        //        bSucc = PSAP.GetProductionInfoForSAP(strProductionNo, ref ProductionModel, ref strErrMsg);

        //        if (bSucc == false)
        //        {
        //            return false;
        //        }

        //        DeliveryModel = ProductionModel;
        //        return bSucc;
        //    }
        //    catch (Exception ex)
        //    {
        //        strErrMsg = "Web异常：" + ex.Message;
        //        return false;
        //    }
        //}

        public override bool ReceiveInfoPostToSAP(ref DeliveryReceive_Model ProductionModel, UserInfo userModel, ref string strErrMsg)
        {
            return true;
        }

        //public bool TaskInfoPostToSAP(ref DeliveryReceive_Model ProductionModel, UserInfo userModel, ref string strErrMsg)
        //{
        //    try
        //    {
        //        Production_SAP PSAP = new Production_SAP();
        //        return PSAP.PostProductionInfoToSAP(ref ProductionModel, userModel, ref strErrMsg);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public override bool CreateReceiveAndShelveTask(ref DeliveryReceive_Model DeliveryInfo, UserInfo userModel, ref string strErrMsg)
        {
            try
            {
                bool bSucc = false;
                string strTaskNo = string.Empty;
                ReceiveGoods_DB RGD = new ReceiveGoods_DB();
                string strReceiveGoodsXml = XMLUtil.XmlUtil.Serializer(typeof(DeliveryReceive_Model), DeliveryInfo);
                string strUserWareHouseXml = XMLUtil.XmlUtil.Serializer(typeof(UserInfo), userModel);

                TOOL.WriteLogMethod.WriteLog("方法：CreateReceiveAndShelveTask---Prd---操作人：" + userModel.UserName + strReceiveGoodsXml);

                bSucc = RGD.CreateReceiveAndShelveTask(strReceiveGoodsXml, strUserWareHouseXml, userModel, ref strTaskNo, ref strErrMsg);

                if (bSucc == true)
                {
                    DeliveryInfo.TaskNo = strTaskNo;
                }
                return bSucc;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public override string CreateMessage(DeliveryReceive_Model DeliveryInfo, bool bTask, string strTaskErrMsg)
        {
            if (bTask)
            {
                return "上架任务创建成功！" + "\r\n上架任务号：" + DeliveryInfo.TaskNo;
            }
            else
            {
                return "上架任务创建失败：" + strTaskErrMsg;
            }

        }

    }
}
