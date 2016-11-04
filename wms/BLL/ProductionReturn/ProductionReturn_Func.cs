using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.DeliveryReceive;
using BLL.Basic.User;
using BLL.ReceiveGoods;

namespace BLL.ProductionReturn
{
    public class ProductionReturn_Func:Receive_Post
    {
        //public string GetProductionReturnInfoForSAP(string strPrdReturnNo) 
        //{
        //    DeliveryReceive_DB DRD = new DeliveryReceive_DB();
        //    DeliveryReceive_Model prdReturnInfo = new DeliveryReceive_Model();

        //    try
        //    {
        //        bool bSucc = false;
        //        string strErrMsg = string.Empty;

        //        if (DRD.CheckDeliveryNoIsExist(strPrdReturnNo) >= 1)
        //        {
        //            prdReturnInfo.Status = "E";
        //            prdReturnInfo.Message = "退料单已经收货,退料单号：" + strPrdReturnNo;
        //            return JSONUtil.JSONHelper.ObjectToJson<DeliveryReceive_Model>(prdReturnInfo);
        //        }

        //        ProductionReturn_SAP PRSAP = new ProductionReturn_SAP();
        //        bSucc= PRSAP.GetProductionReturnInfoForSAP(strPrdReturnNo,ref prdReturnInfo,ref strErrMsg);

        //        if (bSucc == false) 
        //        {
        //            prdReturnInfo.Status = "E";
        //            prdReturnInfo.Message = strErrMsg;
        //            return JSONUtil.JSONHelper.ObjectToJson<DeliveryReceive_Model>(prdReturnInfo);
        //        }

        //        prdReturnInfo.Status = "S";
        //        return JSONUtil.JSONHelper.ObjectToJson<DeliveryReceive_Model>(prdReturnInfo);
        //    }
        //    catch (Exception ex) 
        //    {
        //        prdReturnInfo.Status = "E";
        //        prdReturnInfo.Message = "Web异常"+ex.Message;
        //        return JSONUtil.JSONHelper.ObjectToJson<DeliveryReceive_Model>(prdReturnInfo);
        //    }
        //}
        //public bool GetProductionReturnInfoForSAPToPC(string strPrdReturnNo, ref DeliveryReceive_Model DeliveryModel, ref string strErrMsg)
        //{
        //    DeliveryModel = new DeliveryReceive_Model();

        //    try
        //    {
        //        bool bSucc = false;
        //        strErrMsg = string.Empty;

        //        ProductionReturn_SAP PRSAP = new ProductionReturn_SAP();
        //        bSucc = PRSAP.GetProductionReturnInfoForSAP(strPrdReturnNo, ref DeliveryModel, ref strErrMsg);

        //        if (bSucc == false)
        //        {
        //            DeliveryModel.Status = "E";
        //            DeliveryModel.Message = strErrMsg;
        //            return false;
        //        }

        //        DeliveryModel.Status = "S";
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        DeliveryModel.Status = "E";
        //        DeliveryModel.Message = "Web异常" + ex.Message;
        //        strErrMsg = DeliveryModel.Message;
        //        return false;
        //    }
        //}

        public override bool ReceiveInfoPostToSAP(ref DeliveryReceive_Model PrdReturnModel, UserInfo userModel, ref string strErrMsg)
        {
            return true;           
        }


        //public bool TaskInfoPostToSAP(ref DeliveryReceive_Model PrdReturnModel, UserInfo userModel, ref string strErrMsg) 
        //{
        //    try
        //    {
        //        bool bSucc = false;
        //        ProductionReturn_SAP PSAP = new ProductionReturn_SAP();

        //        //var lstNewPrdReturnDetails = PrdReturnModel.lstDeliveryDetail.GroupBy(t => t.TrackNo);

        //        //foreach (var item in lstNewPrdReturnDetails) 
        //        //{
        //        //    PrdReturnModel.lstDeliveryDetail.Where(t => t.TrackNo == item.FirstOrDefault().TrackNo);
        //        //    bSucc = PSAP.PostProductionReturnInfoToSAP(ref PrdReturnModel, userModel, ref strErrMsg);
        //        //}
        //        //return bSucc;
        //        return PSAP.PostProductionReturnInfoToSAP(ref PrdReturnModel, userModel, ref strErrMsg);
        //    }
        //    catch (Exception ex) 
        //    {
        //        strErrMsg = "Web异常：" + ex;
        //        return false;
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

                TOOL.WriteLogMethod.WriteLog("方法：CreateReceiveAndShelveTask--PrdRet---操作人：" + userModel.UserName + strReceiveGoodsXml);
                bSucc = RGD.CreateReceiveAndShelveTask(strReceiveGoodsXml, strUserWareHouseXml, userModel, ref strTaskNo, ref strErrMsg);

                if (bSucc == true)
                {
                    DeliveryInfo.TaskNo = strTaskNo;
                }
                return bSucc;

                //DeliveryInfo.lstDeliveryDetail = DeliveryInfo.lstDeliveryDetail.GroupBy(s => s.MaterialNo).Select(g => new DeliveryReceiveDetail_Model()
                //{
                //    MaterialNo = g.Key,
                //    MaterialDesc = g.FirstOrDefault().MaterialDesc,
                //    ReceiveQty = g.Sum(a => a.ReceiveQty),
                //    PackCount = g.Sum(a => a.PackCount),
                //    CurrentlyDeliveryNum = g.Sum(a=>a.CurrentlyDeliveryNum),
                //    VoucherNo = g.FirstOrDefault().VoucherNo,
                //    Unit = g.FirstOrDefault().Unit,
                //    Plant = g.FirstOrDefault().Plant,
                //    RowNo=string.Empty,ClaimArriveTime = g.FirstOrDefault().ClaimArriveTime,
                //    ClaimDeliveryNum = g.FirstOrDefault().ClaimDeliveryNum,
                //    ReadyDeliveryNum = g.FirstOrDefault().ReadyDeliveryNum,
                //    WaitDeliveryNum = g.FirstOrDefault().WaitDeliveryNum,
                //    InRoadDeliveryNum = g.FirstOrDefault().InRoadDeliveryNum,
                //    ReceiveTime = g.FirstOrDefault().ReceiveTime,
                //    DeliveryAddress = g.FirstOrDefault().DeliveryAddress,
                //    CorrespondDepartment = g.FirstOrDefault().CorrespondDepartment,
                //    WorkCode = g.FirstOrDefault().WorkCode,
                //    JingxinName = g.FirstOrDefault().JingxinName,
                //    PlantName = g.FirstOrDefault().PlantName,
                //    PrdVersion = g.FirstOrDefault().PrdVersion,
                //    StorageLoc  =g.FirstOrDefault().StorageLoc,
                //    IsUrgent = g.FirstOrDefault().IsUrgent,
                //    PrdReturnReason = g.FirstOrDefault().PrdReturnReason,


                //}).ToList();
                
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
