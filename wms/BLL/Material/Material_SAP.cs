using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXBLL.DeliveryReceive;
using SAP.Middleware.Connector;
using JXBLL.PrintBarcode;
using JXBLL.OutStock;

namespace JXBLL.Material
{
    public class Material_SAP
    {
        public bool GetMaterialInfoForSAPByBarcode(List<Barcode_Model> lstBarCode, ref List<Material_Model> lstMateial, ref string strErrMsg)
        {
            var sap_comm = SAP_Common.SAP_Common.CreateInstance();
            string functionName = "ZLS_GET_MAT_WMS";
            Dictionary<string, string> lstParameters = null;
            Dictionary<string, Dictionary<string, object>> lstStructures = null;


            string tableindex = "I_MATNR";
            List<string> ParameterNamesForOut = null;
            Dictionary<string, string> ParametersOutput = null;
            List<string> StructureNamesForOut = null;
            Dictionary<string, IRfcStructure> StructureOutputs = null;
            List<string> tableNamesForOut = new List<string>() { "T_MATNR", "RETURN" };
            Dictionary<string, IRfcTable> rtbsOutput = null;

            IRfcTable rtbInput = CreateIrfcTableForMaterialInfo(sap_comm, lstBarCode, functionName, tableindex);

            bool bSucc = sap_comm.getSapFunctionToTable(functionName, lstParameters, lstStructures, rtbInput, tableindex, ParameterNamesForOut, out ParametersOutput, StructureNamesForOut,
                        out StructureOutputs, tableNamesForOut, out rtbsOutput, ref strErrMsg);

            if (bSucc == false)
            {
                return bSucc;
            }

            lstMateial = CreateIsRoshDeliveryDetailsMaterial(rtbsOutput["T_MATNR"]);

            return bSucc;
        }


        public bool GetMaterialInfoForSAP(string strMaterialNo, ref Task.TaskDetails_Model taskDetailsModel, ref string strErrMsg)
        {
            var sap_comm = SAP_Common.SAP_Common.CreateInstance();
            string functionName = "ZLS_GET_MAT_WMS";
            Dictionary<string, string> lstParameters = null;
            Dictionary<string, Dictionary<string, object>> lstStructures = null;


            string tableindex = "I_MATNR";
            List<string> ParameterNamesForOut = null;
            Dictionary<string, string> ParametersOutput = null;
            List<string> StructureNamesForOut = null;
            Dictionary<string, IRfcStructure> StructureOutputs = null;
            List<string> tableNamesForOut = new List<string>() { "T_MATNR", "RETURN" };
            Dictionary<string, IRfcTable> rtbsOutput = null;

            IRfcTable rtbInput = CreateIrfcTableForMaterialInfo(sap_comm, strMaterialNo, functionName, tableindex);

            bool bSucc = sap_comm.getSapFunctionToTable(functionName, lstParameters, lstStructures, rtbInput, tableindex, ParameterNamesForOut, out ParametersOutput, StructureNamesForOut,
                        out StructureOutputs, tableNamesForOut, out rtbsOutput, ref strErrMsg);

            if (bSucc == false)
            {
                return bSucc;
            }

            taskDetailsModel = CreateDetailsMaterial(rtbsOutput["T_MATNR"]);

            return bSucc;
        }

        private IRfcTable CreateIrfcTableForMaterialInfo(SAP_Common.SAP_Common sap_comm, List<Barcode_Model> lstBarCode, string functionName, string strRfcTableName)
        {
            IRfcTable rfcTable = sap_comm.CreateIrfcTable(functionName, strRfcTableName);

            if (rfcTable != null)
            {
                foreach (var item in lstBarCode)
                {
                    rfcTable.Insert();
                    rfcTable.CurrentRow.SetValue("MATNR", item.MATERIALNO);
                }
            }

            return rfcTable;
        }

        private IRfcTable CreateIrfcTableForMaterialInfo(SAP_Common.SAP_Common sap_comm, string strMaterialNo, string functionName, string strRfcTableName)
        {
            IRfcTable rfcTable = sap_comm.CreateIrfcTable(functionName, strRfcTableName);

            rfcTable.Insert();
            rfcTable.CurrentRow.SetValue("MATNR", strMaterialNo);

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
                item.MaterialNo = itemRtb.GetString("MATNR");
                item.MaterialDesc = itemRtb.GetString("MAKTX");
                item.Unit = itemRtb.GetString("MEINS");
                item.ROHS = itemRtb.GetString("NORMT");

                lstMaterial.Add(item);
            }
            return lstMaterial;
        }

        private Task.TaskDetails_Model CreateDetailsMaterial(IRfcTable rtb)
        {
            Task.TaskDetails_Model taskDetailsModel = new Task.TaskDetails_Model();

            taskDetailsModel.MaterialNo = rtb[0].GetString("MATNR");
            taskDetailsModel.MaterialDesc = rtb[0].GetString("MAKTX");
            taskDetailsModel.Unit = rtb[0].GetString("MEINS");
            taskDetailsModel.IsROHS = rtb[0].GetString("NORMT") == "ROHS" ? 2 : 1;
            return taskDetailsModel;
        }


        public bool GetMaterialKeeperForSAP( OutStock_Model OutStockModel,ref List<Material_Model> lstMaterial, ref string strErrMsg)
        {
            try
            {
                var sap_comm = SAP_Common.SAP_Common.CreateInstance();
                string functionName = "ZLS_WLBG_DETAIL_READ";
                Dictionary<string, string> lstParameters = null;
                Dictionary<string, Dictionary<string, object>> lstStructures = null;


                string tableindex = "T_MATNR";
                List<string> ParameterNamesForOut = null;
                Dictionary<string, string> ParametersOutput = null;
                List<string> StructureNamesForOut = null;
                Dictionary<string, IRfcStructure> StructureOutputs = null;
                List<string> tableNamesForOut = new List<string>() { "T_WLBG", "RETURN" };
                Dictionary<string, IRfcTable> rtbsOutput = null;

                IRfcTable rtbInput = CreateIrfcTableForMaterialInfo(sap_comm, OutStockModel.lstOutStockDetails, functionName, tableindex);

                bool bSucc = sap_comm.getSapFunctionToTable(functionName, lstParameters, lstStructures, rtbInput, tableindex, ParameterNamesForOut, out ParametersOutput, StructureNamesForOut,
                            out StructureOutputs, tableNamesForOut, out rtbsOutput, ref strErrMsg);

                if (bSucc == false)
                {
                    return bSucc;
                }

                lstMaterial = CreateMaterialKeeper(rtbsOutput["T_WLBG"]);

                return bSucc;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IRfcTable CreateIrfcTableForMaterialInfo(SAP_Common.SAP_Common sap_comm, List<OutStockDetails_Model> lstOutStockDetails, string functionName, string strRfcTableName)
        {
            IRfcTable rfcTable = sap_comm.CreateIrfcTable(functionName, strRfcTableName);

            if (rfcTable != null)
            {
                foreach (var item in lstOutStockDetails)
                {
                    rfcTable.Insert();
                    rfcTable.CurrentRow.SetValue("MATNR", item.MaterialNo);
                }
            }

            return rfcTable;
        }

        private  List<Material_Model> CreateMaterialKeeper(IRfcTable rtb)
        {
            List<Material_Model> lstMaterialKeeper = new List<Material_Model>();

            if (rtb != null && rtb.Count > 0) 
            {
                foreach (var itemRtb in rtb)
                {
                    Material_Model item = new Material_Model();
                    item.MaterialNo = itemRtb.GetString("MATNR");
                    item.MaterialDesc = itemRtb.GetString("MAKTX");
                    item.MaterialKeeperNo = itemRtb.GetString("ZCNUM");
                    item.MaterialLeeperName = itemRtb.GetString("ZCNAME");
                    item.StorageLoc = itemRtb.GetString("LGORT");
                    lstMaterialKeeper.Add(item);
                }
            }
            return lstMaterialKeeper;
        }
        
    }
}
