using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXBLL.OutStock;
using SAP.Middleware.Connector;
using JXBLL.Basic.User;

namespace JXBLL.MaterialRequest
{
    public class MaterialRequest_SAP
    {

        

        public bool GetMaterialRequestInfoForSAP(ref OutStock_Model OutStockModel,ref string strErrMsg)
        {
            try
            {
                var sap_comm = SAP_Common.SAP_Common.CreateInstance();
                
                string tableindex = "I_BEDNR";
                string functionName = "ZLS_BEDNR_READ";
                Dictionary<string, string> lstParameters = new Dictionary<string, string>();
                lstParameters.Add("I_BWART", SelectVoucherType(OutStockModel.VoucherType));//261-生产补料 311-库位转储 221-研发领料 201 成本中心领料
                Dictionary<string, Dictionary<string, object>> lstStructures = null;
                List<string> ParameterNamesForOut = null;
                Dictionary<string, string> ParametersOutput = null;
                List<string> StructureNamesForOut = null;
                Dictionary<string, IRfcStructure> StructureOutputs = null;
                List<string> tableNamesForOut = new List<string>() { "I_REQ", "RETURN" };
                Dictionary<string, IRfcTable> rtbsOutput = null;

                IRfcTable rtbInput = CreateIrfcTableForMaterialInfo(sap_comm, OutStockModel, functionName, tableindex);

                bool bSucc = sap_comm.getSapFunctionToTable(functionName, lstParameters, lstStructures, rtbInput, tableindex, ParameterNamesForOut, out ParametersOutput, StructureNamesForOut,
                        out StructureOutputs, tableNamesForOut, out rtbsOutput, ref strErrMsg);

                if (bSucc == false)
                {
                    return bSucc;
                }

                OutStockModel.IsOutStockPost = 1;
                OutStockModel.IsUnderShelvePost = 2;
                
                OutStockModel.lstOutStockDetails = CreateMaterialRequestDetails(ref OutStockModel, rtbsOutput["I_REQ"]);

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string SelectVoucherType(int iVoucherType) 
        {
            string strMoveType = string.Empty;
            switch (iVoucherType) 
            {
                case 80:
                    strMoveType = "261";
                    break;
                case 90:
                    strMoveType = "311";
                    break;
                case 100:
                    strMoveType = "221";
                    break;
                case 110:
                    strMoveType = "201";
                    break;
                default:
                    strMoveType = string.Empty;
                    break;
            }
            return strMoveType;
        }

        
        private IRfcTable CreateIrfcTableForMaterialInfo(SAP_Common.SAP_Common sap_comm, OutStock_Model outStockModel, string functionName, string strRfcTableName)
        {
            IRfcTable rfcTable = sap_comm.CreateIrfcTable(functionName, strRfcTableName);
            string[] ArrayVoucherNo = outStockModel.VoucherNo.Split(',');
            if (rfcTable != null)
            {
                for (int i = 0; i < ArrayVoucherNo.Count(); i++)
                {
                    rfcTable.Insert();
                    rfcTable.CurrentRow.SetValue("BEDNR", ArrayVoucherNo[i]);
                }
            }

            return rfcTable;
        }


        private List<OutStockDetails_Model> CreateMaterialRequestDetails(ref OutStock_Model OutStockModel, IRfcTable rtb)
        {

            List<OutStockDetails_Model> lstPrdReturnDetails = null;
            if (rtb != null)
            {
                if (rtb.RowCount > 0)
                    lstPrdReturnDetails = new List<OutStockDetails_Model>();
                foreach (var itemRtb in rtb)
                {
                    OutStockModel.VoucherNo = itemRtb.GetString("BEDNR");
                    OutStockModel.Plant = itemRtb.GetString("WERKS");
                    OutStockModel.PlantName = itemRtb.GetString("NAME1");
                    OutStockModel.MoveType = itemRtb.GetString("BWART");

                    OutStockDetails_Model item = new OutStockDetails_Model();
                    item.VoucherNo = itemRtb.GetString("BEDNR");
                    item.RowNo = itemRtb.GetString("BSPOS");
                    item.MaterialNo = itemRtb.GetString("MATNR");
                    item.MaterialDesc = itemRtb.GetString("MAKTX");
                    item.Unit = itemRtb.GetString("MEINS");
                    item.Plant = itemRtb.GetString("WERKS");
                    item.PlantName = itemRtb.GetString("NAME1");
                    item.StorageLoc = itemRtb.GetString("LGORT");
                    item.OutStockQty = itemRtb.GetInt("BDMNG");
                    
                    item.ProDel = itemRtb.GetString("XLOEK");
                    
                    item.ReserveNumber = itemRtb.GetString("RSNUM");
                    //item.ReserveRowNo = itemRtb.GetString("RSPOS");
                    item.RequstReason = itemRtb.GetString("CR_TXT");
                    lstPrdReturnDetails.Add(item);
                }
            }
            return lstPrdReturnDetails;
        }


        public bool PostMaterialRequestToSAP(ref Task.Task_Model taskInfo, UserInfo userModel, ref string strErrMsg)
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
                IRfcTable rfcTable = CreateIrfcTableForTaskInfo(sap_comm, taskInfo, userModel, functionName, strRfcTableName);

                string strMaterialNo = string.Empty;

                bool bSucc = sap_comm.PostSapFunctionFromTable(functionName, lstParameters, lstStructures, ref ParametersOutput, ref StructureOutputs, ref rtbsOutput
                                                            , "GOODSMVT_ITEM", rfcTable, ref strErrMsg);

                if (bSucc == true)
                {
                    //DeliveryInfo.materialDocModel = new MaterialDoc_Model();
                    taskInfo.materialDocModel = sap_comm.GetMaterialDoc(taskInfo.VoucherType, StructureOutputs["GOODSMVT_HEADRET"]);
                }

                return bSucc;
            }
            catch (RfcAbapRuntimeException ex)
            {
                throw ex;
            }

        }


        private IRfcTable CreateIrfcTableForTaskInfo(SAP_Common.SAP_Common sap_comm, Task.Task_Model taskInfo, UserInfo userModel, string functionName, string strRfcTableName)
        {
            IRfcTable rfcTable = sap_comm.CreateIrfcTable(functionName, strRfcTableName);
            //过账前，过滤掉下架数量为零的数据
            var lstTaskInfo = taskInfo.lstTaskDetails.Where(t => t.CurrentPostQty > 0).ToList();

            foreach (var item in lstTaskInfo)
            {
                rfcTable.Insert();
                rfcTable.CurrentRow.SetValue("ORDERID", item.VoucherNo);
                rfcTable.CurrentRow.SetValue("MATERIAL", item.MaterialNo);
                rfcTable.CurrentRow.SetValue("PLANT", item.Plant);
                rfcTable.CurrentRow.SetValue("STGE_LOC", item.StorageLoc);
                rfcTable.CurrentRow.SetValue("PO_NUMBER", item.VoucherNo);
                rfcTable.CurrentRow.SetValue("PO_ITEM", item.RowNo);

                rfcTable.CurrentRow.SetValue("MOVE_TYPE",taskInfo.MoveType );


                rfcTable.CurrentRow.SetValue("ENTRY_QNT", item.CurrentPostQty);
                rfcTable.CurrentRow.SetValue("BASE_UOM", item.Unit);
                rfcTable.CurrentRow.SetValue("MVT_IND", "F");
                rfcTable.CurrentRow.SetValue("GR_RCPT", string.Empty);

            }
            return rfcTable;
        }
    }
}
