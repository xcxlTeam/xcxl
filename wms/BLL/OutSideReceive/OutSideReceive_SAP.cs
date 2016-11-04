using JXBLL.Basic.User;
using JXBLL.DeliveryReceive;
using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXBLL.OutSideReceive
{
    public class OutSideReceive_SAP
    {
        public bool PostOutSideByDeliveryToSAP(ref DeliveryReceive_Model DeliveryInfo, UserInfo userModel, ref string strErrMsg)
        {

            try
            {

                var sap_comm = SAP_Common.SAP_Common.CreateInstance();
                string strMaterialDoc = string.Empty;
                string functionName = "ZBAPI_GOODSMVT_CREATE_01";
                Dictionary<string, string> lstParameters = new Dictionary<string, string>();

                Dictionary<string, Dictionary<string, object>> lstStructures = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object> header = new Dictionary<string, object>();
                header.Add("PSTNG_DATE", DateTime.Now.ToString("yyyy-MM-dd"));//.ToString("yyyy-MM-dd HH:mm:ss")
                header.Add("DOC_DATE", DateTime.Now.ToString("yyyy-MM-dd"));
                header.Add("REF_DOC_NO", DeliveryInfo.DeliveryNo);
                header.Add("BILL_OF_LADING", string.Empty);
                header.Add("GR_GI_SLIP_NO", userModel.UserName);
                header.Add("PR_UNAME", string.Empty);
                header.Add("HEADER_TXT", DeliveryInfo.OsDeliveryRemark);
                header.Add("BAR_CODE", string.Empty);
                lstStructures.Add("GOODSMVT_HEADER", header);

                Dictionary<string, string> ParametersOutput = null;
                Dictionary<string, IRfcStructure> StructureOutputs = new Dictionary<string, IRfcStructure>();
                StructureOutputs.Add("GOODSMVT_HEADRET", null);

                Dictionary<string, IRfcTable> rtbsOutput = new Dictionary<string, IRfcTable>();

                rtbsOutput.Add("RETURN", null);

                string strRfcTableName = "GOODSMVT_ITEM";
                IRfcTable rfcTable = CreateIrfcTableForDeliveryInfo(sap_comm, DeliveryInfo, userModel, functionName, strRfcTableName);


                string strMaterialNo = string.Empty;

                bool bSucc = sap_comm.PostSapFunctionFromTable(functionName, lstParameters, lstStructures, ref ParametersOutput, ref StructureOutputs, ref rtbsOutput
                                                            , "GOODSMVT_ITEM", rfcTable, ref strErrMsg);

                if (bSucc == true)
                {
                    if(DeliveryInfo.lstMaterialDoc==null || DeliveryInfo.lstMaterialDoc.Count==0)
                    {
                        DeliveryInfo.lstMaterialDoc = new List<MaterialDocument.MaterialDoc_Model>();
                    }    
                 
                    MaterialDocument.MaterialDoc_Model MDM = new MaterialDocument.MaterialDoc_Model();
                    MDM = sap_comm.GetMaterialDoc(70, StructureOutputs["GOODSMVT_HEADRET"]);
                    DeliveryInfo.lstMaterialDoc.Add(MDM);
                }

                return bSucc;
            }
            catch (RfcAbapRuntimeException ex)
            {
                throw ex;
            }



        }

        private IRfcTable CreateIrfcTableForDeliveryInfo(SAP_Common.SAP_Common sap_comm,DeliveryReceive_Model DeliveryInfo, UserInfo userModel, string functionName, string strRfcTableName)
        {
            IRfcTable rfcTable = sap_comm.CreateIrfcTable(functionName, strRfcTableName);
            //过账前，过滤掉收货数量为零的数据
            var lstDeliveryDetail = DeliveryInfo.lstDeliveryDetail.Where(t => t.ReceiveQty > 0).ToList();

            foreach (var item in lstDeliveryDetail)
            {
                rfcTable.Insert();
                rfcTable.CurrentRow.SetValue("MATERIAL", item.MaterialNo);
                rfcTable.CurrentRow.SetValue("PLANT", item.Plant);
                rfcTable.CurrentRow.SetValue("STGE_LOC", item.StorageLoc);
                rfcTable.CurrentRow.SetValue("PO_NUMBER", item.VoucherNo);
                rfcTable.CurrentRow.SetValue("PO_ITEM", item.RowNo);
                rfcTable.CurrentRow.SetValue("MOVE_TYPE", "101");

                rfcTable.CurrentRow.SetValue("ENTRY_QNT", item.ReceiveQty);
                rfcTable.CurrentRow.SetValue("BASE_UOM", item.Unit);
                rfcTable.CurrentRow.SetValue("MVT_IND", "B");
                rfcTable.CurrentRow.SetValue("GR_RCPT", string.Empty);
            }
            return rfcTable;
        }


        public bool PostOutSideByPOToSAP(ref DeliveryReceive_Model DeliveryInfo, UserInfo userModel, ref string strErrMsg)
        {

            try
            {

                var sap_comm = SAP_Common.SAP_Common.CreateInstance();
                string strMaterialDoc = string.Empty;
                string functionName = "ZBAPI_GOODSMVT_CREATE_04";
                Dictionary<string, string> lstParameters = new Dictionary<string, string>();

                Dictionary<string, Dictionary<string, object>> lstStructures = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object> header = new Dictionary<string, object>();
                header.Add("PSTNG_DATE", DateTime.Now.ToString("yyyy-MM-dd"));//.ToString("yyyy-MM-dd HH:mm:ss")
                header.Add("DOC_DATE", DateTime.Now.ToString("yyyy-MM-dd"));
                header.Add("REF_DOC_NO", DeliveryInfo.DeliveryNo);
                header.Add("BILL_OF_LADING", string.Empty);
                header.Add("GR_GI_SLIP_NO", userModel.UserName);
                header.Add("PR_UNAME", string.Empty);
                header.Add("HEADER_TXT", DeliveryInfo.OsDeliveryRemark);
                header.Add("BAR_CODE", string.Empty);
                lstStructures.Add("GOODSMVT_HEADER", header);

                Dictionary<string, string> ParametersOutput = null;
                Dictionary<string, IRfcStructure> StructureOutputs = new Dictionary<string, IRfcStructure>();
                StructureOutputs.Add("GOODSMVT_HEADRET", null);

                Dictionary<string, IRfcTable> rtbsOutput = new Dictionary<string, IRfcTable>();

                rtbsOutput.Add("RETURN", null);

                string strRfcTableName = "GOODSMVT_ITEM";
                IRfcTable rfcTable = CreateIrfcTableForPOInfo(sap_comm, DeliveryInfo, userModel, functionName, strRfcTableName);


                string strMaterialNo = string.Empty;

                bool bSucc = sap_comm.PostSapFunctionFromTable(functionName, lstParameters, lstStructures, ref ParametersOutput, ref StructureOutputs, ref rtbsOutput
                                                            , "GOODSMVT_ITEM", rfcTable, ref strErrMsg);

                if (bSucc == true)
                {
                    if (DeliveryInfo.lstMaterialDoc == null || DeliveryInfo.lstMaterialDoc.Count == 0)
                    {
                        DeliveryInfo.lstMaterialDoc = new List<MaterialDocument.MaterialDoc_Model>();
                    }

                    MaterialDocument.MaterialDoc_Model MDM = new MaterialDocument.MaterialDoc_Model();
                    MDM = sap_comm.GetMaterialDoc(70, StructureOutputs["GOODSMVT_HEADRET"]);
                    DeliveryInfo.lstMaterialDoc.Add(MDM);                    
                }

                return bSucc;
            }
            catch (RfcAbapRuntimeException ex)
            {
                throw ex;
            }



        }


        private IRfcTable CreateIrfcTableForPOInfo(SAP_Common.SAP_Common sap_comm, DeliveryReceive_Model DeliveryInfo, UserInfo userModel, string functionName, string strRfcTableName)
        {
            IRfcTable rfcTable = sap_comm.CreateIrfcTable(functionName, strRfcTableName);
            //过账前，过滤掉收货数量为零的数据
            var lstDeliveryDetail = DeliveryInfo.lstDeliveryDetail.Where(t => t.ReceiveQty > 0).ToList();

            foreach (var item in lstDeliveryDetail)
            {
                rfcTable.Insert();
                //rfcTable.CurrentRow.SetValue("ORDERID", item.VoucherNo);
                rfcTable.CurrentRow.SetValue("MATERIAL", item.MaterialNo);
                rfcTable.CurrentRow.SetValue("PLANT", item.Plant);
                rfcTable.CurrentRow.SetValue("STGE_LOC", item.StorageLoc);                
                //rfcTable.CurrentRow.SetValue("PO_ITEM", item.RowNo);
                rfcTable.CurrentRow.SetValue("MOVE_TYPE", "541");
                rfcTable.CurrentRow.SetValue("ENTRY_QNT", item.ReceiveQty);
                rfcTable.CurrentRow.SetValue("BASE_UOM", item.Unit);
                rfcTable.CurrentRow.SetValue("VENDOR", DeliveryInfo.OutSideSupCode.PadLeft(10,'0'));
                //rfcTable.CurrentRow.SetValue("MVT_IND", "B");
                rfcTable.CurrentRow.SetValue("GR_RCPT", string.Empty);
            }
            return rfcTable;
        }


        public bool PostOutSideByDeliveryAndPOToSAP(ref DeliveryReceive_Model DeliveryInfo, UserInfo userModel, ref string strErrMsg)
        {

            try
            {

                var sap_comm = SAP_Common.SAP_Common.CreateInstance();
                string strMaterialDoc = string.Empty;
                string functionName = "ZBAPI_GOODSMVT_CREATE_WX";
                Dictionary<string, string> lstParameters = new Dictionary<string, string>();

                Dictionary<string, Dictionary<string, object>> lstStructures = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object> header = new Dictionary<string, object>();
                header.Add("PSTNG_DATE", DateTime.Now.ToString("yyyy-MM-dd"));//.ToString("yyyy-MM-dd HH:mm:ss")
                header.Add("DOC_DATE", DateTime.Now.ToString("yyyy-MM-dd"));
                header.Add("REF_DOC_NO", DeliveryInfo.DeliveryNo);
                header.Add("BILL_OF_LADING", string.Empty);
                header.Add("GR_GI_SLIP_NO", userModel.UserName);
                header.Add("PR_UNAME", string.Empty);
                header.Add("HEADER_TXT", DeliveryInfo.OsDeliveryRemark);
                header.Add("BAR_CODE", string.Empty);
                lstStructures.Add("GOODSMVT_HEADER", header);

                Dictionary<string, string> ParametersOutput = null;
                Dictionary<string, IRfcStructure> StructureOutputs = new Dictionary<string, IRfcStructure>();
                StructureOutputs.Add("GOODSMVT_HEADRET_01", null);
                StructureOutputs.Add("GOODSMVT_HEADRET_04", null);

                Dictionary<string, IRfcTable> rtbsOutput = new Dictionary<string, IRfcTable>();

                rtbsOutput.Add("RETURN", null);

                Dictionary<string, IRfcTable> lstTable = new Dictionary<string, IRfcTable>();
                lstTable.Add("GOODSMVT_ITEM_01", CreateIrfcTableForDeliveryInfo(sap_comm, DeliveryInfo, userModel, functionName, "GOODSMVT_ITEM_01"));
                lstTable.Add("GOODSMVT_ITEM_04", CreateIrfcTableForPOInfo(sap_comm, DeliveryInfo, userModel, functionName, "GOODSMVT_ITEM_04"));


                string strMaterialNo = string.Empty;

                bool bSucc = sap_comm.PostSapFunctionFromListTable(functionName, lstParameters, lstStructures, ref ParametersOutput, ref StructureOutputs, ref rtbsOutput
                                                            , lstTable, ref strErrMsg);

                if (bSucc == true)
                {                    
                    DeliveryInfo.lstMaterialDoc = new List<MaterialDocument.MaterialDoc_Model>();                   

                    MaterialDocument.MaterialDoc_Model MDM = new MaterialDocument.MaterialDoc_Model();
                    MDM = sap_comm.GetMaterialDoc(70, StructureOutputs["GOODSMVT_HEADRET_01"]);
                    DeliveryInfo.lstMaterialDoc.Add(MDM);

                    MaterialDocument.MaterialDoc_Model MDMPO = new MaterialDocument.MaterialDoc_Model();
                    MDMPO = sap_comm.GetMaterialDoc(70, StructureOutputs["GOODSMVT_HEADRET_04"]);
                    DeliveryInfo.lstMaterialDoc.Add(MDMPO);
                }
                return bSucc;
            }
            catch (RfcAbapRuntimeException ex)
            {
                throw ex;
            }



        }
    }
}
