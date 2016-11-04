using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXBLL.SAP_Common;
using SAP.Middleware.Connector;
using JXBLL.Basic.User;
using JXBLL.MaterialDocument;
using JXBLL.Material;
using JXBLL.PrintBarcode;

namespace JXBLL.DeliveryReceive
{
    public class DeliveryReceive_SAP
    {
        /// <summary>
        /// 送货单收货过账
        /// </summary>
        /// <param name="DeliveryInfo"></param>
        /// <param name="userModel"></param>
        /// <param name="strErrMsg"></param>
        /// <returns></returns>
        public bool PostReceiveGoodsInfoToSAP(ref DeliveryReceive_Model DeliveryInfo, UserInfo userModel, ref string strErrMsg) 
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
                header.Add("REF_DOC_NO", (DeliveryInfo.VoucherType==60)?DeliveryInfo.Reson:DeliveryInfo.DeliveryNo);
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
                    //DeliveryInfo.materialDocModel = new MaterialDoc_Model();
                    DeliveryInfo.materialDocModel = sap_comm.GetMaterialDoc(DeliveryInfo.IsQuality==1?60:10,StructureOutputs["GOODSMVT_HEADRET"]);
                }

                return bSucc;
            }
            catch (RfcAbapRuntimeException ex)
            {
                throw ex;
            }
            
        }

        private IRfcTable CreateIrfcTableForDeliveryInfo(SAP_Common.SAP_Common sap_comm, DeliveryReceive_Model DeliveryInfo, UserInfo userModel, string functionName, string strRfcTableName)
        {
            IRfcTable rfcTable = sap_comm.CreateIrfcTable(functionName, strRfcTableName);
            //过账前，过滤掉收货数量为零的数据
            var lstDeliveryDetail= DeliveryInfo.lstDeliveryDetail.Where(t=>t.ReceiveQty>0).ToList();

            foreach (var item in lstDeliveryDetail)
            {

                rfcTable.Insert();
                rfcTable.CurrentRow.SetValue("MATERIAL", item.MaterialNo);
                rfcTable.CurrentRow.SetValue("PLANT", item.Plant);
                rfcTable.CurrentRow.SetValue("STGE_LOC", item.StorageLoc);
                rfcTable.CurrentRow.SetValue("PO_NUMBER", item.VoucherNo);
                rfcTable.CurrentRow.SetValue("PO_ITEM", item.RowNo);

               rfcTable.CurrentRow.SetValue("MOVE_TYPE", DeliveryInfo.IsQuality == 1 ? "101" : "103");
                
                
                rfcTable.CurrentRow.SetValue("ENTRY_QNT", item.ReceiveQty);
                rfcTable.CurrentRow.SetValue("BASE_UOM", item.Unit);
                rfcTable.CurrentRow.SetValue("MVT_IND", "B");
                //rfcTable.CurrentRow.SetValue("GR_RCPT", userModel.Name);
                rfcTable.CurrentRow.SetValue("GR_RCPT", string.Empty);

            }
            return rfcTable;
        }

        /// <summary>
        /// 获取SAP PO信息
        /// </summary>
        /// <param name="strPONo"></param>
        /// <param name="DelivryModel"></param>
        /// <param name="strErrMsg"></param>
        public bool GetPOInfoForSAP(string strPONo,ref DeliveryReceive_Model DelivryModel,ref string strErrMsg)
        {
            try
            {
                var sap_comm = SAP_Common.SAP_Common.CreateInstance();
                IRfcTable rtbInput = null;
                string tableindex = null;
                string functionName = "ZLS_EBELN_READ";
                Dictionary<string, string> lstParameters = new Dictionary<string, string>();
                lstParameters.Add("I_EBELN", strPONo);
                Dictionary<string, Dictionary<string, object>> lstStructures = null;
                List<string> ParameterNamesForOut = null;
                Dictionary<string, string> ParametersOutput = null;
                List<string> StructureNamesForOut = new List<string>() { "EBELN_HEAD"};
                Dictionary<string, IRfcStructure> StructureOutputs = null;
                List<string> tableNamesForOut = new List<string>() { "E_EBELN", "RETURN" };
                Dictionary<string, IRfcTable> rtbsOutput = null;

                bool bSucc = sap_comm.getSapFunctionToTable(functionName, lstParameters, lstStructures, rtbInput, tableindex, ParameterNamesForOut, out ParametersOutput, StructureNamesForOut,
                        out StructureOutputs, tableNamesForOut, out rtbsOutput, ref strErrMsg);

                if (bSucc == false)
                {
                    return bSucc;
                }

                CreateHeader(ref DelivryModel, StructureOutputs["EBELN_HEAD"]);
                DelivryModel.lstDeliveryDetail= CreateDetail(rtbsOutput["E_EBELN"]);              

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void CreateHeader(ref DeliveryReceive_Model DeliveryModel, IRfcStructure iRfcStructure) 
        {
            if (iRfcStructure != null)
            {
                DeliveryModel.VoucherNo = iRfcStructure.GetString("EBELN");
                DeliveryModel.SupCode = iRfcStructure.GetString("LIFNR");
                DeliveryModel.SupName = iRfcStructure.GetString("NAME1");
            }            
        }

        private List<DeliveryReceiveDetail_Model> CreateDetail( IRfcTable rtb) 
        {
            List<DeliveryReceiveDetail_Model> lstDeliveryDetail = new List<DeliveryReceiveDetail_Model>();
            if (rtb != null && rtb.Count>0) 
            {
                foreach (var itemRtb in rtb) 
                {
                    DeliveryReceiveDetail_Model DDM = new DeliveryReceiveDetail_Model();
                    DDM.VoucherNo = itemRtb.GetString("EBELN");
                    DDM.RowNo = itemRtb.GetString("EBELP");
                    DDM.MaterialNo = itemRtb.GetString("MATNR");
                    DDM.MaterialDesc = itemRtb.GetString("TXZ01");
                    DDM.CurrentlyDeliveryNum = itemRtb.GetInt("MENGE");
                    DDM.Plant = itemRtb.GetString("WERKS");
                    DDM.PlantName = itemRtb.GetString("NAME1");
                    DDM.StorageLoc = itemRtb.GetString("LGORT");
                    lstDeliveryDetail.Add(DDM);
                }                
            }
            return lstDeliveryDetail;
        }

        /// <summary>
        /// 送货单上架后过账
        /// </summary>
        /// <param name="DeliveryInfo"></param>
        /// <param name="userModel"></param>
        /// <param name="strErrMsg"></param>
        /// <returns></returns>
        public bool PostTaskInfoToSAP(ref DeliveryReceive_Model DeliveryInfo, UserInfo userModel, ref string strErrMsg)
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
                header.Add("HEADER_TXT", string.Empty);
                header.Add("BAR_CODE", string.Empty);
                lstStructures.Add("GOODSMVT_HEADER", header);

                Dictionary<string, string> ParametersOutput = null;
                Dictionary<string, IRfcStructure> StructureOutputs = new Dictionary<string, IRfcStructure>();
                StructureOutputs.Add("GOODSMVT_HEADRET", null);

                Dictionary<string, IRfcTable> rtbsOutput = new Dictionary<string, IRfcTable>();

                rtbsOutput.Add("RETURN", null);

                string strRfcTableName = "GOODSMVT_ITEM";
                IRfcTable rfcTable = CreateIrfcTableForTaskInfo(sap_comm, DeliveryInfo, userModel, functionName, strRfcTableName);


                string strMaterialNo = string.Empty;

                bool bSucc = sap_comm.PostSapFunctionFromTable(functionName, lstParameters, lstStructures, ref ParametersOutput, ref StructureOutputs, ref rtbsOutput
                                                            , "GOODSMVT_ITEM", rfcTable, ref strErrMsg);

                if (bSucc == true)
                {
                    //DeliveryInfo.materialDocModel = new MaterialDoc_Model();
                    DeliveryInfo.materialDocModel = sap_comm.GetMaterialDoc(50, StructureOutputs["GOODSMVT_HEADRET"]);
                }

                return bSucc;
            }
            catch (RfcAbapRuntimeException ex)
            {
                throw ex;
            }

        }


        private IRfcTable CreateIrfcTableForTaskInfo(SAP_Common.SAP_Common sap_comm, DeliveryReceive_Model DeliveryInfo, UserInfo userModel, string functionName, string strRfcTableName)
        {
            IRfcTable rfcTable = sap_comm.CreateIrfcTable(functionName, strRfcTableName);
            //过账前，过滤掉收货数量为零的数据
            var lstDeliveryDetail = DeliveryInfo.lstDeliveryDetail.Where(t => t.CurrentPostQty > 0).ToList();

            foreach (var item in lstDeliveryDetail)
            {

                rfcTable.Insert();
                rfcTable.CurrentRow.SetValue("MATERIAL", item.MaterialNo);
                rfcTable.CurrentRow.SetValue("PLANT", item.Plant);
                rfcTable.CurrentRow.SetValue("STGE_LOC", item.StorageLoc);
                rfcTable.CurrentRow.SetValue("PO_NUMBER", item.VoucherNo);
                rfcTable.CurrentRow.SetValue("PO_ITEM", item.RowNo);

                rfcTable.CurrentRow.SetValue("MOVE_TYPE", "105");


                rfcTable.CurrentRow.SetValue("ENTRY_QNT", item.CurrentPostQty);
                rfcTable.CurrentRow.SetValue("BASE_UOM", item.Unit);
                rfcTable.CurrentRow.SetValue("MVT_IND", "B");
                //rfcTable.CurrentRow.SetValue("GR_RCPT", userModel.Name);
                rfcTable.CurrentRow.SetValue("GR_RCPT", string.Empty);

                rfcTable.CurrentRow.SetValue("REF_DOC", DeliveryInfo.MaterialDoc);
                rfcTable.CurrentRow.SetValue("REF_DOC_YR", DeliveryInfo.DocDate);

            }
            return rfcTable;
        }


        /// <summary>
        /// 原材料不合格退货过账
        /// </summary>
        /// <param name="DeliveryInfo">送货单号</param>
        /// <param name="userModel">用户</param>
        /// <param name="strErrMsg">错误信息</param>
        /// <returns>返回结果</returns>
        public bool PostReceiveUnQualityReturnToSAP(ref DeliveryReceive_Model DeliveryInfo, UserInfo userModel, ref string strErrMsg)
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
                header.Add("HEADER_TXT", string.Empty);
                header.Add("BAR_CODE", string.Empty);
                lstStructures.Add("GOODSMVT_HEADER", header);

                Dictionary<string, string> ParametersOutput = null;
                Dictionary<string, IRfcStructure> StructureOutputs = new Dictionary<string, IRfcStructure>();
                StructureOutputs.Add("GOODSMVT_HEADRET", null);

                Dictionary<string, IRfcTable> rtbsOutput = new Dictionary<string, IRfcTable>();

                rtbsOutput.Add("RETURN", null);

                string strRfcTableName = "GOODSMVT_ITEM";
                IRfcTable rfcTable = CreateIrfcTableForReceiveUnQualityReturn(sap_comm, DeliveryInfo, userModel, functionName, strRfcTableName);


                string strMaterialNo = string.Empty;

                bool bSucc = sap_comm.PostSapFunctionFromTable(functionName, lstParameters, lstStructures, ref ParametersOutput, ref StructureOutputs, ref rtbsOutput
                                                            , "GOODSMVT_ITEM", rfcTable, ref strErrMsg);

                if (bSucc == true)
                {
                    //DeliveryInfo.materialDocModel = new MaterialDoc_Model();
                    DeliveryInfo.materialDocModel = sap_comm.GetMaterialDoc(DeliveryInfo.IsQuality == 1 ? 60 : 10, StructureOutputs["GOODSMVT_HEADRET"]);
                }

                return bSucc;
            }
            catch (RfcAbapRuntimeException ex)
            {
                throw ex;
            }

        }


        private IRfcTable CreateIrfcTableForReceiveUnQualityReturn(SAP_Common.SAP_Common sap_comm, DeliveryReceive_Model DeliveryInfo, UserInfo userModel, string functionName, string strRfcTableName)
        {
            IRfcTable rfcTable = sap_comm.CreateIrfcTable(functionName, strRfcTableName);
            //过账前，过滤掉不合格数量为零的数据
            var lstDeliveryDetail = DeliveryInfo.lstDeliveryDetail.Where(t => t.UnQualityQty > 0).ToList();

            foreach (var item in lstDeliveryDetail)
            {

                rfcTable.Insert();
                rfcTable.CurrentRow.SetValue("MATERIAL", item.MaterialNo);
                rfcTable.CurrentRow.SetValue("PLANT", item.Plant);
                rfcTable.CurrentRow.SetValue("STGE_LOC", item.StorageLoc);
                rfcTable.CurrentRow.SetValue("PO_NUMBER", item.VoucherNo);
                rfcTable.CurrentRow.SetValue("PO_ITEM", item.RowNo);

                rfcTable.CurrentRow.SetValue("MOVE_TYPE", "124");


                rfcTable.CurrentRow.SetValue("ENTRY_QNT", item.UnQualityQty);
                rfcTable.CurrentRow.SetValue("BASE_UOM", item.Unit);
                rfcTable.CurrentRow.SetValue("MVT_IND", "B");
                rfcTable.CurrentRow.SetValue("GR_RCPT", string.Empty);


            }
            return rfcTable;
        }


        public bool GetRoshFlagForSap(List<Barcode_Model> lstBarcode, ref List<Material_Model> lstMateial, ref string strErrMsg)
        {
            try
            {
                var sap_comm = SAP_Common.SAP_Common.CreateInstance();
                string functionName = "ZLS_ROHS_READ";
                Dictionary<string, string> lstParameters = null;
                Dictionary<string, Dictionary<string, object>> lstStructures = null;


                string tableindex = "T_MATNR";
                List<string> ParameterNamesForOut = null;
                Dictionary<string, string> ParametersOutput = null;
                List<string> StructureNamesForOut = null;
                Dictionary<string, IRfcStructure> StructureOutputs = null;
                List<string> tableNamesForOut = new List<string>() { "T_MATNR", "RETURN" };
                Dictionary<string, IRfcTable> rtbsOutput = null;

                IRfcTable rtbInput = CreateIrfcTableForMaterialInfo(sap_comm, lstBarcode, functionName, tableindex);

                bool bSucc = sap_comm.getSapFunctionToTable(functionName, lstParameters, lstStructures, rtbInput, tableindex, ParameterNamesForOut, out ParametersOutput, StructureNamesForOut,
                            out StructureOutputs, tableNamesForOut, out rtbsOutput, ref strErrMsg);

                if (bSucc == false)
                {
                    return bSucc;
                }

                lstMateial = CreateIsRoshDeliveryDetailsMaterial(rtbsOutput["T_MATNR"]);

                return bSucc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


        private IRfcTable CreateIrfcTableForMaterialInfo(SAP_Common.SAP_Common sap_comm, List<Barcode_Model> lstBarcode, string functionName, string strRfcTableName)
        {
            IRfcTable rfcTable = sap_comm.CreateIrfcTable(functionName, strRfcTableName);

            if (rfcTable != null)
            {
                foreach (var item in lstBarcode)
                {
                    rfcTable.Insert();
                    rfcTable.CurrentRow.SetValue("EBELN", item.VOUCHERNO);
                    rfcTable.CurrentRow.SetValue("EBELP", item.ROWNO);
                }
            }

            return rfcTable;
        }


        private List<Material_Model> CreateIsRoshDeliveryDetailsMaterial(IRfcTable rtb)
        {
            List<Material_Model> lstMaterial = null;
            if (rtb.RowCount > 0)
                lstMaterial = new List<Material_Model>();
            foreach (var itemRtb in rtb)
            {
                Material_Model item = new Material_Model();
                item.VoucherNo = itemRtb.GetString("EBELN");
                item.RowNo = itemRtb.GetString("EBELP");
                item.MaterialNo = itemRtb.GetString("MATNR");
                item.ROHS = itemRtb.GetString("RFLAG");
                lstMaterial.Add(item);
            }
            return lstMaterial;
        }

    }
}
