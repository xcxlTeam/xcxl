using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Supplier
{
    public class Supplier_U8
    {
        public bool GetSupplierInfoForU8( ref Supplier_Model SupplierInfo, ref string strErrMsg)
        {
            try
            {
                //var sap_comm = SAP_Common.SAP_Common.CreateInstance();
                //IRfcTable rtbInput = null;
                //string tableindex = null;
                //string functionName = "ZLS_LIFNR_READ_WMS";
                //Dictionary<string, string> lstParameters = new Dictionary<string, string>();
                //lstParameters.Add("IM_LIFNR", SupplierInfo.SupplierCode);
                //Dictionary<string, Dictionary<string, object>> lstStructures = null;
                //List<string> ParameterNamesForOut = null;
                //Dictionary<string, string> ParametersOutput = null;
                //List<string> StructureNamesForOut = null;
                //Dictionary<string, IRfcStructure> StructureOutputs = null;
                //List<string> tableNamesForOut = new List<string>() { "T_LFA1","RETURN" };
                //Dictionary<string, IRfcTable> rtbsOutput = null;

                //bool bSucc = sap_comm.getSapFunctionToTable(functionName, lstParameters, lstStructures, rtbInput, tableindex, ParameterNamesForOut, out ParametersOutput, StructureNamesForOut,
                //        out StructureOutputs, tableNamesForOut, out rtbsOutput, ref strErrMsg);

                //if (bSucc == false)
                //{
                //    return bSucc;
                //}

                //SupplierInfo = CreateSupplierInfo(rtbsOutput["T_LFA1"]);

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //private Supplier_Model CreateSupplierInfo(IRfcTable rtb)
        //{

        //    Supplier_Model SupplierInfo = new Supplier_Model();
        //    if (rtb != null)
        //    {                
        //        foreach (var itemRtb in rtb)
        //        {
        //            SupplierInfo.SupplierCode = itemRtb.GetString("LIFNR");
        //            SupplierInfo.SupplierName = itemRtb.GetString("NAME1");

        //            if (!string.IsNullOrEmpty(SupplierInfo.SupplierCode) && SupplierInfo.SupplierCode.StartsWith("0000"))
        //            {
        //                SupplierInfo.SupplierCode = SupplierInfo.SupplierCode.Substring(4);
        //            }
        //        }
        //    }
        //    return SupplierInfo;
        //}
    }
}
