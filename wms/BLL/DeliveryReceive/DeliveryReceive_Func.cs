using BLL.HTTPUtils;
using BLL.JSONUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using System.Xml;
using BLL.Basic.User;
using BLL.PrintBarcode;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using System.IO;
using BLL.Material;
using BLL.ReceiveGoods;
using System.Configuration;

namespace BLL.DeliveryReceive
{
    public class DeliveryReceive_Func : Receive_Post
    {
        //string strURL = WebConfigurationManager.AppSettings["DeliveryReceiveURL"] + "&";
        string strURL = ConfigurationManager.AppSettings["SrmUrl"];
        //string strURL = "http://192.168.0.144:9980/portal/rest/sup/getDeliverGoodsInfoFromSrm?systemName=SRM&";
        string strAppend = "Code=";

        public string GetDeliveryInfoForAndroid(string strDeliveryNo, string strUserJson)
        {
            string strJson = string.Empty;
            DeliveryReceive_DB DRD = new DeliveryReceive_DB();
            DeliveryReceive_Model deliveryReceiveModel = new DeliveryReceive_Model();
            UserInfo userModel;

            //获取字符串
            string strResult = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(strDeliveryNo))
                {
                    deliveryReceiveModel.Status = "E";
                    deliveryReceiveModel.Message = "送货单号不能为空！";
                    return JSONHelper.ObjectToJson<DeliveryReceive_Model>(deliveryReceiveModel);
                }

                if (DRD.CheckDeliveryNoIsExist(strDeliveryNo) >= 1)
                {
                    deliveryReceiveModel.Status = "E";
                    deliveryReceiveModel.Message = "送货单已经收货,送货单号：" + strDeliveryNo;
                    return JSONHelper.ObjectToJson<DeliveryReceive_Model>(deliveryReceiveModel);
                }

                userModel = JSONHelper.JsonToObject<UserInfo>(strUserJson);

                //调用SRM接口
                strResult = HTTPUtils.HTTPUtils.GetResultXML(strURL, strAppend + strDeliveryNo, null);
                //解析SRM接口数据
                DeliveryReceive_Model deliveryReceiveMdl = JSONHelper.JsonToObject<DeliveryReceive_Model>(strResult);

                if (deliveryReceiveMdl.Type.Equals("E"))
                {
                    deliveryReceiveMdl.Status = "E";
                    return JSONHelper.ObjectToJson<DeliveryReceive_Model>(deliveryReceiveMdl);
                }

                if (deliveryReceiveMdl.Items.Count <= 0)
                {
                    deliveryReceiveMdl.Status = "E";
                    deliveryReceiveMdl.Message = "SRM接口调用成功，但没有送货单数据！";

                    return JSONHelper.ObjectToJson<DeliveryReceive_Model>(deliveryReceiveMdl);
                }

                deliveryReceiveModel = DeliveryReceive_Http.CreateDeliveryInfo(deliveryReceiveMdl);

                foreach (var item in deliveryReceiveModel.lstDeliveryDetail)
                {
                    item.IsUrgent = DRD.GetIsUrgent(item.MaterialNo) == 0 ? 2 : 1;
                }

                deliveryReceiveModel.Status = "S";
                strJson = JSONHelper.ObjectToJson(deliveryReceiveModel);

                return strJson;

            }
            catch (Exception ex)
            {
                deliveryReceiveModel.Status = "E";
                deliveryReceiveModel.Message = "Web异常：" + ex.Message + ex.StackTrace;
                return JSONHelper.ObjectToJson<DeliveryReceive_Model>(deliveryReceiveModel);
            }

        }


        public bool GetDeliveryInfoToSRM(ref DeliveryReceive_Model DeliveryModel, UserInfo userModel, ref string strErrMsg)
        {
            string strJson = string.Empty;

            //获取字符串
            string strResult = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(DeliveryModel.DeliveryNo))
                {
                    strErrMsg = "送货单号不能为空！";
                    return false;
                }



                //调用SRM接口
                strResult = HTTPUtils.HTTPUtils.GetResultXML(strURL, strAppend + DeliveryModel.DeliveryNo, null);
                //解析SRM接口数据
                DeliveryReceive_Model deliveryReceiveMdl = JSONHelper.JsonToObject<DeliveryReceive_Model>(strResult);

                if (deliveryReceiveMdl.Type.Equals("E"))
                {
                    strErrMsg = "没有获取到送货单数据！";
                    return false;
                }

                if (deliveryReceiveMdl.Items.Count <= 0)
                {
                    strErrMsg = "SRM接口调用成功，但没有送货单数据！";
                    return false;
                }

                DeliveryModel = DeliveryReceive_Http.CreateDeliveryInfo(deliveryReceiveMdl);
                CreateOrderNum(ref DeliveryModel);
                return true;

            }
            catch (Exception ex)
            {
                strErrMsg = "Web异常：" + ex.Message;
                return false;
            }

        }

        private void CreateOrderNum(ref DeliveryReceive_Model DeliveryModel)
        {
            int iCount = 0;
            foreach (var item in DeliveryModel.lstDeliveryDetail)
            {
                iCount += 1;
                item.OrderNum = iCount.ToString();
            }
        }

        public bool GetDeliveryInfo(string strDeliveryNo, ref List<Barcode_Model> lstBarcode, ref string strErrMsg)
        {
            try
            {
                bool bSucc = false;
                //获取字符串
                string strResult = HTTPUtils.HTTPUtils.GetResultXML(strURL, strAppend + strDeliveryNo, null);

                if (strResult.IndexOf("送货单据号不存在") >= 0)
                {
                    strErrMsg = "送货单据号不存在";
                    return false;
                }

                XmlDocument xmldoc = JsonToXml.Json2Xml(strResult);

                if (DeliveryReceive_Http.IsDataSuccess(xmldoc))
                {
                    lstBarcode = DeliveryReceive_Http.getSendOrderList(xmldoc);
                }
                else
                {
                    strErrMsg = DeliveryReceive_Http.getErrorMessage(xmldoc);
                }

                List<Material_Model> lstMaterial = new List<Material_Model>();

                //Material_SAP materialSap = new Material_SAP();
                //bSucc = materialSap.GetMaterialInfoForSAPByBarcode(lstBarcode, ref lstMaterial, ref strErrMsg);
                //DeliveryReceive_SAP DSAP = new DeliveryReceive_SAP();
                //bSucc = DSAP.GetRoshFlagForSap(lstBarcode, ref lstMaterial, ref strErrMsg);

                if (bSucc == false)
                {
                    strErrMsg = string.Format("获取SAP物料信息失败!{0}{1}", Environment.NewLine, strErrMsg);
                    return false;
                }

                Material_Model temp;
                foreach (var item in lstBarcode)
                {
                    temp = lstMaterial.Find(t => t.MaterialNo == item.MATERIALNO && t.VoucherNo == item.VOUCHERNO && t.RowNo == item.ROWNO);
                    item.BIsRoSH = temp != null && temp.ROHS == "1";
                    item.ISROHS = item.BIsRoSH ? 2 : 1;
                }

                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = "Web异常：" + ex.Message;
                return false;
            }
        }

        //public override bool ReceiveInfoPostToSAP(ref DeliveryReceive_Model DeliveryInfo, UserInfo userModel, ref string strErrMsg)
        //{
        //    try
        //    {
        //        DeliveryReceive_SAP DRSAP = new DeliveryReceive_SAP();
        //        //TODO:测试代码------------
        //        //DeliveryInfo.IsQuality = 1;
        //        //-------------------------

        //        DeliveryInfo.IsShelvePost = DeliveryInfo.IsQuality == 1 ? 1 : 2;
        //        DeliveryInfo.materialDocModel.MaterialDocType = DeliveryInfo.IsQuality == 1 ? 60 : 10;
        //        return DRSAP.PostReceiveGoodsInfoToSAP(ref DeliveryInfo, userModel, ref strErrMsg);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public bool TaskInfoPostToSAP(ref DeliveryReceive_Model DeliveryInfo, UserInfo userModel, ref string strErrMsg)
        //{
        //    try
        //    {
        //        DeliveryReceive_SAP DRSAP = new DeliveryReceive_SAP();

        //        return DRSAP.PostTaskInfoToSAP(ref DeliveryInfo, userModel, ref strErrMsg);
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

                TOOL.WriteLogMethod.WriteLog("方法：CreateReceiveAndShelveTask---操作人："+userModel.UserName+ strReceiveGoodsXml);
                TOOL.WriteLogMethod.WriteLog("方法：CreateReceiveAndShelveTask---操作人：" + userModel.UserName + strUserWareHouseXml);

                bSucc = RGD.CreateReceiveAndShelveTask(strReceiveGoodsXml, strUserWareHouseXml, userModel, ref strTaskNo, ref strErrMsg);

                if (bSucc == true) { DeliveryInfo.TaskNo = strTaskNo; }

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
                return "过账成功！\r\n" + "物料凭证：" + DeliveryInfo.materialDocModel.MaterialDoc + "\r\n" + "凭证年度："
                    + DeliveryInfo.materialDocModel.MaterialDocDate + "\r\n上架任务创建成功！" + "\r\n上架任务号：" + DeliveryInfo.TaskNo;
            }
            else
            {
                return DeliveryInfo.Message = "过账成功！\r\n" + "物料凭证：" + DeliveryInfo.materialDocModel.MaterialDoc + "\r\n" + "凭证年度："
                        + DeliveryInfo.materialDocModel.MaterialDocDate + "\r\n上架任务创建失败：" + strTaskErrMsg;
            }

        }


        //public bool GetPOInfoForSAP(string strPONo, ref DeliveryReceive_Model DelivryModel, ref string strErrMsg)
        //{
        //    try
        //    {
        //        DeliveryReceive_SAP DRSAP = new DeliveryReceive_SAP();
        //        return DRSAP.GetPOInfoForSAP(strPONo, ref DelivryModel, ref strErrMsg);
        //    }
        //    catch (Exception ex)
        //    {
        //        strErrMsg = "Web异常：" + ex.Message;
        //        return false;
        //    }
        //}

    }
}
