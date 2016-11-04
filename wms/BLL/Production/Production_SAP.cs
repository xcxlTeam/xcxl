using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXBLL.DeliveryReceive;
using SAP.Middleware.Connector;
using JXBLL.Basic.User;

namespace JXBLL.Production
{
    public class Production_SAP
    {
        /// <summary>
        /// 获取生产订单数据(半成品入库模块)
        /// </summary>
        /// <param name="strProductionNo"></param>
        /// <param name="ProductionModel"></param>
        /// <param name="strErrMsg"></param>
        /// <returns></returns>
        public bool GetProductionInfoForSAP(string strProductionNo, ref DeliveryReceive_Model ProductionModel, ref string strErrMsg) 
        {
            try
            {
                strProductionNo = string.IsNullOrEmpty(strProductionNo) ? "" : strProductionNo;
                var sap_comm = SAP_Common.SAP_Common.CreateInstance();
                IRfcTable rtbInput = null;
                string tableindex = null;
                string functionName = "ZLS_AUFNR_DETAIL_READ";
                Dictionary<string, string> lstParameters = new Dictionary<string, string>();
                lstParameters.Add("AUFNR", strProductionNo.PadLeft(12,'0'));
                Dictionary<string, Dictionary<string, object>> lstStructures = null;
                List<string> ParameterNamesForOut = null;
                Dictionary<string, string> ParametersOutput = null;
                List<string> StructureNamesForOut = null;
                Dictionary<string, IRfcStructure> StructureOutputs = null;
                List<string> tableNamesForOut = new List<string>() { "AU_HEADER", "RETURN" };
                Dictionary<string, IRfcTable> rtbsOutput = null;

                bool bSucc = sap_comm.getSapFunctionToTable(functionName, lstParameters, lstStructures, rtbInput, tableindex, ParameterNamesForOut, out ParametersOutput, StructureNamesForOut,
                        out StructureOutputs, tableNamesForOut, out rtbsOutput, ref strErrMsg);

                if (bSucc == false)
                {
                    return bSucc;
                }
                ProductionModel.DeliveryNo = strProductionNo;
                ProductionModel.IsReceivePost = 1;
                ProductionModel.IsShelvePost = 2;
                ProductionModel.VoucherType = 40;
                ProductionModel.IsQuality = 1;//不质检
                ProductionModel.SupName = string.Empty;
                ProductionModel.SupCode = string.Empty;
                //ProductionModel.Plant = string.Empty;
                //ProductionModel.PlantName = string.Empty;
                ProductionModel.materialDocModel = new MaterialDocument.MaterialDoc_Model() { MaterialDoc=string.Empty,MaterialDocDate =string.Empty};

                ProductionModel.lstDeliveryDetail = CreateProductionDetails(ref ProductionModel,rtbsOutput["AU_HEADER"]);

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<DeliveryReceiveDetail_Model> CreateProductionDetails(ref DeliveryReceive_Model ProductionModel, IRfcTable rtb)
        {

            List<DeliveryReceiveDetail_Model> lstPrdReturnDetails = null;
            if (rtb != null)
            {
                if (rtb.RowCount > 0)
                    lstPrdReturnDetails = new List<DeliveryReceiveDetail_Model>();
                foreach (var itemRtb in rtb)
                {
                    ProductionModel.Plant = itemRtb.GetString("WERKS");
                    ProductionModel.PlantName = itemRtb.GetString("NAME1");
                    ProductionModel.MoveType = string.Empty;

                    DeliveryReceiveDetail_Model item = new DeliveryReceiveDetail_Model();
                    item.DeliveryNo = itemRtb.GetString("AUFNR").TrimStart('0'); 
                    item.CreateTime = string.Empty;
                    item.RowNo = string.Empty;
                    item.VoucherNo = itemRtb.GetString("AUFNR").TrimStart('0'); 
                    item.MaterialNo = itemRtb.GetString("MATNR");
                    item.MaterialDesc = itemRtb.GetString("MAKTX");
                    item.ClaimArriveTime = string.Empty;
                    item.Unit = string.Empty;
                    item.CurrentlyDeliveryNum = itemRtb.GetInt("GAMNG");
                    item.ClaimDeliveryNum = 0;
                    item.ReadyDeliveryNum = 0;
                    item.WaitDeliveryNum = 0;
                    item.InRoadDeliveryNum = 0;
                    item.ReceiveTime = string.Empty;
                    item.DeliveryAddress = string.Empty;
                    item.CorrespondDepartment = string.Empty;
                    item.WorkCode = string.Empty;
                    item.JingxinName = string.Empty;
                    item.Plant = itemRtb.GetString("WERKS");
                    item.PlantName = itemRtb.GetString("NAME1");
                    item.PrdVersion = string.Empty;
                    item.ReceiveQty = 0;
                    item.IsUrgent = 1;
                    item.PackCount = 0;
                    item.StorageLoc = string.Empty;
                    item.PrdReturnReason = string.Empty;
                    item.Barcode = string.Empty;
                    item.SerialNo = string.Empty;
                    item.ReserveNumber = string.Empty;
                    item.ReserveRowNo = string.Empty;
                    item.OldReceiveQty = itemRtb.GetInt("WEMNG");
                    item.TrackNo = string.Empty;
                    lstPrdReturnDetails.Add(item);
                }
            }
            return lstPrdReturnDetails;
        }


        public bool PostProductionInfoToSAP(ref DeliveryReceive_Model ProductionModel, UserInfo userModel, ref string strErrMsg)
        {
            try
            {

                var sap_comm = SAP_Common.SAP_Common.CreateInstance();
                string strMaterialDoc = string.Empty;
                string functionName = "ZBAPI_GOODSMVT_CREATE_02";//"BAPI_GOODSMVT_CREATE";
                Dictionary<string, string> lstParameters = new Dictionary<string, string>();

                Dictionary<string, Dictionary<string, object>> lstStructures = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object> header = new Dictionary<string, object>();
                header.Add("PSTNG_DATE", DateTime.Now.ToString("yyyy-MM-dd"));
                header.Add("DOC_DATE", DateTime.Now.ToString("yyyy-MM-dd"));
                header.Add("REF_DOC_NO", string.Empty);
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
                IRfcTable rfcTable = CreateIrfcTableForProductionInfo(sap_comm, ProductionModel, userModel, functionName, strRfcTableName);


                string strMaterialNo = string.Empty;

                bool bSucc = sap_comm.PostSapFunctionFromTable(functionName, lstParameters, lstStructures, ref ParametersOutput, ref StructureOutputs, ref rtbsOutput
                                                            , "GOODSMVT_ITEM", rfcTable, ref strErrMsg);

                if (bSucc == true)
                {
                    //PrdReturnModel.materialDocModel = new MaterialDoc_Model();
                    ProductionModel.materialDocModel = sap_comm.GetMaterialDoc(40,StructureOutputs["GOODSMVT_HEADRET"]);
                }

                return bSucc;
            }
            catch (RfcAbapRuntimeException ex)
            {
                throw ex;
            }
        }


        private IRfcTable CreateIrfcTableForProductionInfo(SAP_Common.SAP_Common sap_comm, DeliveryReceive_Model ProductionModel, UserInfo userModel, string functionName, string strRfcTableName)
        {
            IRfcTable rfcTable = sap_comm.CreateIrfcTable(functionName, strRfcTableName);
            //过账前，过滤掉收货数量为零的数据
            var lstDeliveryDetail = ProductionModel.lstDeliveryDetail.Where(t => t.CurrentPostQty > 0).ToList();

            foreach (var item in lstDeliveryDetail)
            {

                rfcTable.Insert();
                rfcTable.CurrentRow.SetValue("ORDERID", item.VoucherNo.PadLeft(12,'0'));
                rfcTable.CurrentRow.SetValue("MATERIAL", item.MaterialNo);
                rfcTable.CurrentRow.SetValue("PLANT", item.Plant);
                rfcTable.CurrentRow.SetValue("STGE_LOC", item.StorageLoc);
                rfcTable.CurrentRow.SetValue("MOVE_TYPE", "101");
                rfcTable.CurrentRow.SetValue("ENTRY_QNT", item.CurrentPostQty);
                rfcTable.CurrentRow.SetValue("BASE_UOM", item.Unit);                
                rfcTable.CurrentRow.SetValue("MVT_IND", "F");//TODO:移动标识填什么
                rfcTable.CurrentRow.SetValue("GR_RCPT", string.Empty);
            }
            return rfcTable;
        }
    }
}
