using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXBLL.StorageLoc
{
    public class StorageLoc_SAP
    {
        public bool GetStorageLocByPlantForSAP(string strPlant, ref List<StorageLoc_Model> lstStorage, ref string strErrMsg) 
        {
            try
            {
                var sap_comm = SAP_Common.SAP_Common.CreateInstance();
                IRfcTable rtbInput = null;
                string tableindex = null;
                string functionName = "ZLS_PLANT_STORAGE";
                Dictionary<string, string> lstParameters = new Dictionary<string, string>();
                lstParameters.Add("IM_WERKS", strPlant);
                Dictionary<string, Dictionary<string, object>> lstStructures = null;
                List<string> ParameterNamesForOut = null;
                Dictionary<string, string> ParametersOutput = null;
                List<string> StructureNamesForOut =null;
                Dictionary<string, IRfcStructure> StructureOutputs = null;
                List<string> tableNamesForOut = new List<string>() { "TB_T001L" };
                Dictionary<string, IRfcTable> rtbsOutput = null;

                bool bSucc = sap_comm.getSapFunctionToTablePara(functionName, lstParameters, lstStructures, rtbInput, tableindex, ParameterNamesForOut, out ParametersOutput, StructureNamesForOut,
                        out StructureOutputs, tableNamesForOut, out rtbsOutput, ref strErrMsg);

                if (bSucc == false)
                {
                    return bSucc;
                }

                lstStorage = CreateStorage(rtbsOutput["TB_T001L"]);

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private List<StorageLoc_Model> CreateStorage(IRfcTable rtb)
        {

            List<StorageLoc_Model> lstStorage = null;
            if (rtb != null)
            {
                if (rtb.RowCount > 0)
                    lstStorage = new List<StorageLoc_Model>();
                foreach (var itemRtb in rtb)
                {
                    StorageLoc_Model item = new StorageLoc_Model();
                    item.StorageLoc = itemRtb.GetString("LGORT");
                    item.StorageLocName = itemRtb.GetString("LGOBE");

                    lstStorage.Add(item);
                }
            }
            return lstStorage;
        }



        


    }
}
