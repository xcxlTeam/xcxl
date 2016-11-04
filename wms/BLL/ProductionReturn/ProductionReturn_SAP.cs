using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXBLL.DeliveryReceive;
using SAP.Middleware.Connector;
using JXBLL.Basic.User;

namespace JXBLL.ProductionReturn
{
    public class ProductionReturn_SAP
    {
        public bool GetProductionReturnInfoForSAP(string strPrdReturnNo,ref DeliveryReceive_Model PrdReturnModel,ref string strErrMsg)
        {
            try
            {
                var sap_comm = SAP_Common.SAP_Common.CreateInstance();
                IRfcTable rtbInput = null;
                string tableindex = null;                
                string functionName = "ZLS_TL_DETAIL_READ";
                Dictionary<string, string> lstParameters = new Dictionary<string, string>();
                lstParameters.Add("BEDNR", strPrdReturnNo);
                Dictionary<string, Dictionary<string, object>> lstStructures = null;
                List<string> ParameterNamesForOut = null;
                Dictionary<string, string> ParametersOutput = null;
                List<string> StructureNamesForOut = null;
                Dictionary<string, IRfcStructure> StructureOutputs = null;
                List<string> tableNamesForOut = new List<string>() { "IT_SCTL","RETURN" };
                Dictionary<string, IRfcTable> rtbsOutput = null;

                bool bSucc = sap_comm.getSapFunctionToTable(functionName, lstParameters, lstStructures, rtbInput, tableindex, ParameterNamesForOut, out ParametersOutput, StructureNamesForOut,
                        out StructureOutputs, tableNamesForOut, out rtbsOutput,ref strErrMsg);

                if(bSucc==false)
                {
                    return bSucc;
                }


                PrdReturnModel.DeliveryNo = strPrdReturnNo;
                PrdReturnModel.VoucherType = 30;
                PrdReturnModel.IsReceivePost = 1;//不过账
                PrdReturnModel.IsShelvePost = 2;
                PrdReturnModel.IsQuality = 1;//不质检
                PrdReturnModel.SupName = string.Empty;
                PrdReturnModel.SupCode = string.Empty;
                //PrdReturnModel.Plant = string.Empty;
                PrdReturnModel.PlantName = string.Empty;
                PrdReturnModel.materialDocModel = new MaterialDocument.MaterialDoc_Model() {MaterialDoc = string.Empty,MaterialDocDate = string.Empty};
                //PrdReturnModel.materialDocModel.MaterialDoc = string.Empty;
                
                PrdReturnModel.lstDeliveryDetail = CreateProductionReturnDetails(ref PrdReturnModel,rtbsOutput["IT_SCTL"]);

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<DeliveryReceiveDetail_Model> CreateProductionReturnDetails(ref DeliveryReceive_Model PrdReturnModel, IRfcTable rtb)
        {

            List<DeliveryReceiveDetail_Model> lstPrdReturnDetails = null;
            if (rtb != null)
            {
                if (rtb.RowCount > 0)
                    lstPrdReturnDetails = new List<DeliveryReceiveDetail_Model>();
                foreach (var itemRtb in rtb)
                {
                    PrdReturnModel.Plant = itemRtb.GetString("WERKS");
                    PrdReturnModel.MoveType = itemRtb.GetString("BWART");
                    
                    DeliveryReceiveDetail_Model item = new DeliveryReceiveDetail_Model();
                    item.DeliveryNo = itemRtb.GetString("BEDNR");
                    item.CreateTime = string.Empty;
                    item.RowNo = itemRtb.GetString("BSPOS");
                    item.TrackNo = itemRtb.GetString("AUFNR");
                    item.VoucherNo = itemRtb.GetString("BEDNR");
                    item.MaterialNo = itemRtb.GetString("MATNR");
                    item.MaterialDesc = itemRtb.GetString("MAKTX");
                    item.ClaimArriveTime = string.Empty;
                    item.Unit = string.Empty;
                    item.CurrentlyDeliveryNum = itemRtb.GetInt("MENGE");
                    item.ClaimDeliveryNum = 0;
                    item.ReadyDeliveryNum = 0;
                    item.WaitDeliveryNum = 0;
                    item.InRoadDeliveryNum = 0;
                    item.ReceiveTime = string.Empty;
                    item.DeliveryAddress = string.Empty;
                    item.CorrespondDepartment = itemRtb.GetString("DEPARTMENT");
                    item.WorkCode = string.Empty;
                    item.JingxinName = string.Empty;
                    item.Plant = itemRtb.GetString("WERKS");
                    item.PlantName = string.Empty;
                    item.PrdVersion = string.Empty;
                    item.ReceiveQty = itemRtb.GetInt("MENGE");
                    item.IsUrgent = 1;
                    item.PackCount = 0;
                    item.StorageLoc = itemRtb.GetString("LGORT");
                    item.PrdReturnReason = itemRtb.GetString("PMTXT");
                    item.Barcode = string.Empty;
                    item.SerialNo = string.Empty;
                    item.ReserveNumber = itemRtb.GetString("RSNUM");
                    item.ReserveRowNo = itemRtb.GetString("RSPOS");

                    if (!string.IsNullOrEmpty(item.TrackNo)) item.TrackNo = item.TrackNo.TrimStart('0');
                    if (Common.Common_Func.IsAllZero(item.ReserveNumber)) item.ReserveNumber = string.Empty;
                    if (Common.Common_Func.IsAllZero(item.ReserveRowNo)) item.ReserveRowNo = string.Empty;
                    lstPrdReturnDetails.Add(item);
                }
            }
            return lstPrdReturnDetails;
        }


        public bool PostProductionReturnInfoToSAP(ref DeliveryReceive_Model PrdReturnModel, UserInfo userModel, ref string strErrMsg) 
        {
            try
            {

                var sap_comm = SAP_Common.SAP_Common.CreateInstance();
                string strMaterialDoc = string.Empty;
                string functionName = "ZBAPI_GOODSMVT_CREATE_03";
                Dictionary<string, string> lstParameters = new Dictionary<string, string>();
                lstParameters.Add("I_BEDNR", PrdReturnModel.DeliveryNo);

                Dictionary<string, Dictionary<string, object>> lstStructures = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object> header = new Dictionary<string, object>();
                header.Add("PSTNG_DATE", DateTime.Now.ToString("yyyy-MM-dd"));
                header.Add("DOC_DATE", DateTime.Now.ToString("yyyy-MM-dd"));
                header.Add("REF_DOC_NO", PrdReturnModel.DeliveryNo);
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
                IRfcTable rfcTable = CreateIrfcTableForProductionReturnInfo(sap_comm, PrdReturnModel, userModel, functionName, strRfcTableName);


                string strMaterialNo = string.Empty;

                bool bSucc = sap_comm.PostSapFunctionFromTable(functionName, lstParameters, lstStructures, ref ParametersOutput, ref StructureOutputs, ref rtbsOutput
                                                            , "GOODSMVT_ITEM", rfcTable, ref strErrMsg);

                if (bSucc == true)
                {
                    //PrdReturnModel.materialDocModel = new MaterialDoc_Model();
                    PrdReturnModel.materialDocModel = sap_comm.GetMaterialDoc(30,StructureOutputs["GOODSMVT_HEADRET"]);
                }

                return bSucc;
            }
            catch (RfcAbapRuntimeException ex)
            {
                throw ex;
            }
        }


        private IRfcTable CreateIrfcTableForProductionReturnInfo(SAP_Common.SAP_Common sap_comm, DeliveryReceive_Model prdReturnInfo, UserInfo userModel, string functionName, string strRfcTableName)
        {
            IRfcTable rfcTable = sap_comm.CreateIrfcTable(functionName, strRfcTableName);
            //过账前，过滤掉收货数量为零的数据
            var lstDeliveryDetail = prdReturnInfo.lstDeliveryDetail.Where(t => t.CurrentPostQty > 0).ToList();

            foreach (var item in lstDeliveryDetail)
            {

                rfcTable.Insert();
                rfcTable.CurrentRow.SetValue("ORDERID", item.TrackNo.PadLeft(12,'0'));
                rfcTable.CurrentRow.SetValue("MATERIAL", item.MaterialNo);
                rfcTable.CurrentRow.SetValue("PLANT", item.Plant);
                rfcTable.CurrentRow.SetValue("STGE_LOC", item.StorageLoc);
                rfcTable.CurrentRow.SetValue("MOVE_TYPE", prdReturnInfo.MoveType);
                rfcTable.CurrentRow.SetValue("ENTRY_QNT", item.CurrentPostQty);
                rfcTable.CurrentRow.SetValue("BASE_UOM", item.Unit);
                rfcTable.CurrentRow.SetValue("MOVE_REAS", item.PrdReturnReason);
                rfcTable.CurrentRow.SetValue("RESERV_NO", item.ReserveNumber);
                rfcTable.CurrentRow.SetValue("RES_ITEM", item.ReserveRowNo);
                rfcTable.CurrentRow.SetValue("XSTOB", prdReturnInfo.MoveType=="262"?"X":string.Empty);
                
            }
            return rfcTable;
        }
    }
}
