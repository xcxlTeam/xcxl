using JXBLL.Basic.User;
using JXBLL.OutStock;
using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXBLL.MaterialRequestOutSide
{
    public class MaterialRequestOutSide_SAP
    {
        public bool GetMaterialRequestOutSideForSAP(ref OutStock_Model OutStockModel, ref string strErrMsg)
        {
            try
            {
                var sap_comm = SAP_Common.SAP_Common.CreateInstance();
                IRfcTable rtbInput = null;
                string tableindex = null;
                string functionName = "ZLS_WX_DETAIL_READ";
                Dictionary<string, string> lstParameters = new Dictionary<string, string>();
                lstParameters.Add("EBELN", OutStockModel.VoucherNo);

                Dictionary<string, Dictionary<string, object>> lstStructures = null;
                List<string> ParameterNamesForOut = null;
                Dictionary<string, string> ParametersOutput = null;
                List<string> StructureNamesForOut = null;
                Dictionary<string, IRfcStructure> StructureOutputs = null;
                List<string> tableNamesForOut = new List<string>() { "WX_HEADER"," WX_ITEM", "RETURN" };
                Dictionary<string, IRfcTable> rtbsOutput = null;

                bool bSucc = sap_comm.getSapFunctionToTable(functionName, lstParameters, lstStructures, rtbInput, tableindex, ParameterNamesForOut, out ParametersOutput, StructureNamesForOut,
                        out StructureOutputs, tableNamesForOut, out rtbsOutput, ref strErrMsg);

                if (bSucc == false)
                {
                    return bSucc;
                }

                //创建表头信息
                OutStockModel = CreateMaterialRequestOutSideHead(rtbsOutput["WX_HEADER"]);

                if (OutStockModel == null || string.IsNullOrEmpty(OutStockModel.VoucherNo)) 
                {
                    strErrMsg = "获取SAP外协领料单表头信息失败！";
                    return false;
                }

                OutStockModel.IsOutStockPost = 1;
                OutStockModel.IsUnderShelvePost = 2;
                OutStockModel.VoucherType = 130;


                OutStockModel.lstOutStockDetails = CreateMaterialRequestByProductDetails(ref OutStockModel, rtbsOutput["WX_ITEM"]);

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private OutStock_Model CreateMaterialRequestOutSideHead(IRfcTable rtb)
        {

            OutStock_Model OSM = new OutStock_Model();
            if (rtb != null && rtb.Count>0)
            {
                OSM.VoucherNo = rtb[0].GetString("EBELN");
                OSM.SupCode = rtb[0].GetString("LIFNR");
                OSM.SupName = rtb[0].GetString("NAME1");                
            }
            return OSM;
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
                    OutStockModel.Plant = itemRtb.GetString("WERKS");
                    OutStockModel.PlantName = itemRtb.GetString("WNAME");
                    OutStockModel.MoveType = string.Empty;

                    OutStockDetails_Model item = new OutStockDetails_Model();
                    item.VoucherNo = itemRtb.GetString("EBELN");
                    item.RowNo = itemRtb.GetString("EBELP");
                    item.MaterialNo = itemRtb.GetString("MATNR");
                    item.MaterialDesc = itemRtb.GetString("MAKTX");
                    item.Unit = itemRtb.GetString("MEINS");
                    item.Plant = itemRtb.GetString("WERKS");
                    item.PlantName = itemRtb.GetString("WNAME");
                    item.StorageLoc = itemRtb.GetString("LGORT");
                    item.OutStockQty = itemRtb.GetInt("BDMNG");
                    item.OldOutStockQtySAP = itemRtb.GetInt("YFSL");
                    item.WaitOutStockQty = itemRtb.GetInt("KFSL");
                    item.RemainStockQtySAP = itemRtb.GetInt("YLKC");
                    lstPrdReturnDetails.Add(item);
                }
            }
            return null;
        }


        public bool PostMaterialRequestToSAPByOutSide(ref Task.Task_Model taskInfo, string strStorageLoc,UserInfo userModel, ref string strErrMsg)
        {

            try
            {

                var sap_comm = SAP_Common.SAP_Common.CreateInstance();
                string strMaterialDoc = string.Empty;
                string functionName = "ZLS_WX_MBLNR_CREATE";
                Dictionary<string, string> lstParameters = new Dictionary<string, string>();
                lstParameters.Add("EBELN", taskInfo.VoucherNo);
                lstParameters.Add("EBELP", string.Empty);
                lstParameters.Add("WERKS", taskInfo.Plant);
                lstParameters.Add("LGORT", strStorageLoc);

                Dictionary<string, Dictionary<string, object>> lstStructures = new Dictionary<string, Dictionary<string, object>>();
                

                Dictionary<string, string> ParametersOutput = null;
                Dictionary<string, IRfcStructure> StructureOutputs = new Dictionary<string, IRfcStructure>();
                StructureOutputs.Add("T_MATDOC", null);

                Dictionary<string, IRfcTable> rtbsOutput = new Dictionary<string, IRfcTable>();

                rtbsOutput.Add("RETURN", null);

                string strRfcTableName = "T_WXGZ";
                IRfcTable rfcTable = CreateIrfcTableForTaskInfo(sap_comm, taskInfo, userModel, functionName, strRfcTableName);

                string strMaterialNo = string.Empty;

                bool bSucc = sap_comm.PostSapFunctionFromTable(functionName, lstParameters, lstStructures, ref ParametersOutput, ref StructureOutputs, ref rtbsOutput
                                                            , "T_WXGZ", rfcTable, ref strErrMsg);

                if (bSucc == true)
                {
                    //DeliveryInfo.materialDocModel = new MaterialDoc_Model();
                    taskInfo.materialDocModel = sap_comm.GetMaterialDoc(taskInfo.VoucherType, StructureOutputs["T_WXGZ"]);
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
                //rfcTable.CurrentRow.SetValue("ORDERID", item.VoucherNo);
                rfcTable.CurrentRow.SetValue("MATNR", item.MaterialNo);
                //rfcTable.CurrentRow.SetValue("PLANT", item.Plant);
                //rfcTable.CurrentRow.SetValue("STGE_LOC", item.StorageLoc);
                //rfcTable.CurrentRow.SetValue("PO_NUMBER", item.VoucherNo);
                //rfcTable.CurrentRow.SetValue("PO_ITEM", item.RowNo);

                //rfcTable.CurrentRow.SetValue("MOVE_TYPE", taskInfo.MoveType);


                rfcTable.CurrentRow.SetValue("SFSL", item.CurrentPostQty);
                rfcTable.CurrentRow.SetValue("YLFH", item.RemainStockQty);
                rfcTable.CurrentRow.SetValue("ZYLFLAG", "X");                

            }
            return rfcTable;
        }
    }
}
