using JXBLL.Basic.User;
using JXBLL.OutStock;
using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXBLL.MaterialRequestProduct
{
    public class MaterialRequestProduct_SAP
    {
        /// <summary>
        /// 生产作业单领料
        /// </summary>
        /// <param name="OutStockModel"></param>
        /// <param name="strErrMsg"></param>
        /// <returns></returns>
        public bool GetMaterialRequestByProductInfoForSAP( ref OutStock_Model OutStockModel, ref string strErrMsg)
        {
            try
            {
                var sap_comm = SAP_Common.SAP_Common.CreateInstance();
                IRfcTable rtbInput = null;
                string tableindex = null;
                string functionName = "ZLS_AUFNR_READ";
                Dictionary<string, string> lstParameters = new Dictionary<string, string>();
                lstParameters.Add("I_AUFNR", OutStockModel.VoucherNo.PadLeft(12, '0'));//作业领料单(生产订单)

                Dictionary<string, Dictionary<string, object>> lstStructures = null;
                List<string> ParameterNamesForOut = null;
                Dictionary<string, string> ParametersOutput = null;
                List<string> StructureNamesForOut = null;
                Dictionary<string, IRfcStructure> StructureOutputs = null;
                List<string> tableNamesForOut = new List<string>() { "I_RESB", "RETURN" };
                Dictionary<string, IRfcTable> rtbsOutput = null;

                bool bSucc = sap_comm.getSapFunctionToTable(functionName, lstParameters, lstStructures, rtbInput, tableindex, ParameterNamesForOut, out ParametersOutput, StructureNamesForOut,
                        out StructureOutputs, tableNamesForOut, out rtbsOutput, ref strErrMsg);

                if (bSucc == false)
                {
                    return bSucc;
                }

                OutStockModel.IsOutStockPost = 1;
                OutStockModel.IsUnderShelvePost = 2;
                OutStockModel.VoucherType = 120;                                

                
                OutStockModel.lstOutStockDetails = CreateMaterialRequestByProductDetails(ref OutStockModel, rtbsOutput["I_RESB"]);

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private List<OutStockDetails_Model> CreateMaterialRequestByProductDetails(ref OutStock_Model OutStockModel, IRfcTable rtb)
        {

            List<OutStockDetails_Model> lstPrdReturnDetails = null;
            if (rtb != null)
            {
                if (rtb.RowCount > 0)
                    lstPrdReturnDetails = new List<OutStockDetails_Model>();
                foreach (var itemRtb in rtb)
                {
                    OutStockModel.VoucherNo = itemRtb.GetString("AUFNR").TrimStart('0');
                    OutStockModel.Plant = itemRtb.GetString("WERKS");
                    OutStockModel.PlantName = itemRtb.GetString("NAME1");
                    OutStockModel.MoveType = itemRtb.GetString("BWART");

                    OutStockDetails_Model item = new OutStockDetails_Model();
                    item.VoucherNo = itemRtb.GetString("AUFNR").TrimStart('0');
                    item.RowNo = string.Empty;                 
                    item.MaterialNo = itemRtb.GetString("MATNR");
                    item.MaterialDesc = itemRtb.GetString("MAKTX");
                    item.Unit = itemRtb.GetString("MEINS");
                    item.Plant = itemRtb.GetString("WERKS");
                    item.PlantName = itemRtb.GetString("NAME1");
                    item.StorageLoc = itemRtb.GetString("LGORT");
                    item.OutStockQty = itemRtb.GetInt("ZBDMNG");
                    item.ProRecoil = itemRtb.GetString("RGEKZ");
                    item.ProDel = itemRtb.GetString("XLOEK");
                    item.ProVirtual = itemRtb.GetString("DUMPS");
                    item.ReserveNumber = itemRtb.GetString("RSNUM");
                    item.ReserveRowNo = itemRtb.GetString("RSPOS");
                    lstPrdReturnDetails.Add(item);
                }
            }
            return null;
        }



        public bool PostMaterialRequestToSAPByProduct(ref Task.Task_Model taskInfo, UserInfo userModel, ref string strErrMsg)
        {

            try
            {

                var sap_comm = SAP_Common.SAP_Common.CreateInstance();
                string strMaterialDoc = string.Empty;
                string functionName = "ZBAPI_GOODSMVT_CREATE_03";
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

                rfcTable.CurrentRow.SetValue("MOVE_TYPE", "261");


                rfcTable.CurrentRow.SetValue("ENTRY_QNT", item.CurrentPostQty);
                rfcTable.CurrentRow.SetValue("BASE_UOM", item.Unit);
                rfcTable.CurrentRow.SetValue("MVT_IND", "F");                
                rfcTable.CurrentRow.SetValue("GR_RCPT", string.Empty);

            }
            return rfcTable;
        }

    }
}
