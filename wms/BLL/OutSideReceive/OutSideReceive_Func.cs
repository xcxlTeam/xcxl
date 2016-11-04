using BLL.Basic.User;
using BLL.DeliveryReceive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.OutSideReceive
{
    public class OutSideReceive_Func
    {
        public bool GetOutSideByDeliveryToSRM(ref DeliveryReceive_Model DeliveryModel, UserInfo userModel, ref string strErrMsg) 
        {
            try
            {
                DeliveryReceive_DB DRD = new DeliveryReceive_DB();

                if (DRD.CheckDeliveryNoIsExist(DeliveryModel.DeliveryNo) >= 1)
                {
                    strErrMsg = "送货单已经收货,送货单号：" + DeliveryModel.DeliveryNo;
                    return false;
                }

                DeliveryReceive_Func DRF = new DeliveryReceive_Func();
                return DRF.GetDeliveryInfoToSRM(ref DeliveryModel,userModel,ref strErrMsg);
            }
            catch (Exception ex) 
            {
                strErrMsg = "Web异常：" + ex.Message;
                return false;
            }
        }
        //public bool PostOutSideByDeliveryToSAP(ref DeliveryReceive_Model DeliveryInfo, UserInfo userModel, ref string strErrMsg) 
        //{
        //    try
        //    {
        //        bool bSucc = false;

        //        OutSideReceive_SAP ORSAP = new OutSideReceive_SAP();
        //        DeliveryReceive_DB DRD = new DeliveryReceive_DB();

        //        if (DRD.CheckDeliveryNoIsExist(DeliveryInfo.DeliveryNo) >= 1)
        //        {
        //            strErrMsg = "送货单已经收货,送货单号：" + DeliveryInfo.DeliveryNo;
        //            return false;
        //        }

        //        if (DeliveryInfo.lstDeliveryDetail.Where(t => t.OKSelect == true).Count() == 0) 
        //        {
        //            strErrMsg = "请选中过账行！";
        //            return false;
        //        }

        //        DeliveryInfo.lstDeliveryDetail = DeliveryInfo.lstDeliveryDetail.Where(t => t.OKSelect == true).ToList();

        //        bSucc = ORSAP.PostOutSideByDeliveryToSAP(ref DeliveryInfo, userModel, ref strErrMsg);

        //        if (bSucc == false)
        //        {
        //            return bSucc;
        //        }

        //        bSucc = ORSAP.PostOutSideByPOToSAP(ref DeliveryInfo, userModel, ref strErrMsg);

        //        if (bSucc == true)
        //        {
        //            strErrMsg = GetMaterialDoc(DeliveryInfo);
        //        }
        //        else 
        //        {
        //            return bSucc;
        //        }

        //        DeliveryInfo.VoucherType = 70;//外协送货单
        //        DeliveryInfo.IsQuality = 1;
        //        DeliveryInfo.IsReceivePost = 2;
        //        DeliveryInfo.IsShelvePost = 1;
        //        string strSaveMsg = string.Empty;
        //        string strOutSideDelivery = XMLUtil.XmlUtil.Serializer(typeof(DeliveryReceive_Model), DeliveryInfo);
        //        OutSideReceive_DB OSRD=new OutSideReceive_DB();
        //        TOOL.WriteLogMethod.WriteLog("方法：PostOutSideByDeliveryToSAP---操作人：" + userModel.UserName + strOutSideDelivery);
        //        //过账成功，插入数据库
        //        bSucc=OSRD.SaveOutSideDeliveryInfo(strOutSideDelivery, userModel, ref strSaveMsg);

        //        if (bSucc == false) 
        //        {
        //            strErrMsg = strErrMsg + "\r\n" + "数据写入失败：" + strSaveMsg;
        //        }

        //        return bSucc;
        //    }
        //    catch (Exception ex) 
        //    {
        //        strErrMsg = "Web异常：" + ex.Message;
        //        return false;
        //    }
        //}


        //public bool PostOutSideByDeliveryAndPOToSAP(ref DeliveryReceive_Model DeliveryInfo, UserInfo userModel, ref string strErrMsg)
        //{
        //    try
        //    {
        //        bool bSucc = false;

        //        OutSideReceive_SAP ORSAP = new OutSideReceive_SAP();
        //        DeliveryReceive_DB DRD = new DeliveryReceive_DB();

        //        if (DRD.CheckDeliveryNoIsExist(DeliveryInfo.DeliveryNo) >= 1)
        //        {
        //            strErrMsg = "送货单已经收货,送货单号：" + DeliveryInfo.DeliveryNo;
        //            return false;
        //        }

        //        if (DeliveryInfo.lstDeliveryDetail.Where(t => t.OKSelect == true).Count() == 0)
        //        {
        //            strErrMsg = "请选中过账行！";
        //            return false;
        //        }

        //        DeliveryInfo.lstDeliveryDetail = DeliveryInfo.lstDeliveryDetail.Where(t => t.OKSelect == true).ToList();

        //        bSucc = ORSAP.PostOutSideByDeliveryAndPOToSAP(ref DeliveryInfo, userModel, ref strErrMsg);

        //        if (bSucc == false)
        //        {
        //            return bSucc;
        //        }

        //        strErrMsg = GetMaterialDoc(DeliveryInfo);

        //        DeliveryInfo.VoucherType = 70;//外协送货单
        //        DeliveryInfo.IsQuality = 1;
        //        DeliveryInfo.IsReceivePost = 2;
        //        DeliveryInfo.IsShelvePost = 1;
        //        string strSaveMsg = string.Empty;
        //        string strOutSideDelivery = XMLUtil.XmlUtil.Serializer(typeof(DeliveryReceive_Model), DeliveryInfo);
        //        OutSideReceive_DB OSRD = new OutSideReceive_DB();
        //        TOOL.WriteLogMethod.WriteLog("方法：PostOutSideByDeliveryAndPOToSAP---操作人：" + userModel.UserName + strOutSideDelivery);
        //        //过账成功，插入数据库
        //        bSucc = OSRD.SaveOutSideDeliveryInfo(strOutSideDelivery, userModel, ref strSaveMsg);

        //        if (bSucc == false)
        //        {
        //            strErrMsg = strErrMsg + "\r\n" + "数据写入失败：" + strSaveMsg;
        //        }

        //        return bSucc;
        //    }
        //    catch (Exception ex)
        //    {
        //        strErrMsg = "Web异常：" + ex.Message;
        //        return false;
        //    }
        //}

        public string GetMaterialDoc(DeliveryReceive_Model DeliveryInfo) 
        {
            string strMsgDoc = "过账成功！\r\n"  ;
            foreach (var item in DeliveryInfo.lstMaterialDoc) 
            {
                strMsgDoc = strMsgDoc+"物料凭证：" + item.MaterialDoc + "\r\n" + "凭证年度："
                    + item.MaterialDocDate + "\r\n";
            }
            return strMsgDoc;
        }
    }
}
