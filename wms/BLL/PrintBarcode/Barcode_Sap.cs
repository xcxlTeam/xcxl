using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXBLL.PrintBarcode
{
    class Barcode_Sap
    {

        #region 生产订单
        public bool GetProductionInfoForSAP(string strProductionNo, ref List<Barcode_Model> lstBarcode, ref string strError)
        {
            try
            {
                strProductionNo = string.IsNullOrEmpty(strProductionNo) ? "" : strProductionNo;
                var sap_comm = SAP_Common.SAP_Common.CreateInstance();
                IRfcTable rtbInput = null;
                string tableindex = null;
                string functionName = "ZLS_AUFNR_DETAIL_READ";
                Dictionary<string, string> lstParameters = new Dictionary<string, string>();
                lstParameters.Add("AUFNR", strProductionNo.PadLeft(12, '0'));
                Dictionary<string, Dictionary<string, object>> lstStructures = null;
                List<string> ParameterNamesForOut = null;
                Dictionary<string, string> ParametersOutput = null;
                List<string> StructureNamesForOut = null;
                Dictionary<string, IRfcStructure> StructureOutputs = null;
                List<string> tableNamesForOut = new List<string>() { "AU_HEADER", "RETURN" };
                Dictionary<string, IRfcTable> rtbsOutput = null;

                bool bSucc = sap_comm.getSapFunctionToTable(functionName, lstParameters, lstStructures, rtbInput, tableindex, ParameterNamesForOut, out ParametersOutput, StructureNamesForOut,
                        out StructureOutputs, tableNamesForOut, out rtbsOutput, ref strError);

                if (bSucc == false)
                {
                    return bSucc;
                }

                lstBarcode = CreateProductionDetails(rtbsOutput["AU_HEADER"]);

                return new Barcode_Func().GetMaterialInfoByBarcodeList(40, ref lstBarcode, ref strError);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private List<Barcode_Model> CreateProductionDetails( IRfcTable rtb)
        {

            List<Barcode_Model> lstBarcode = null;
            if (rtb != null)
            {
                if (rtb.RowCount > 0)
                    lstBarcode = new List<Barcode_Model>();

                Barcode_Model barcode;
                foreach (var itemRtb in rtb)
                {
                    barcode = new Barcode_Model();
                    barcode.DELIVERYNO = itemRtb.GetString("AUFNR").TrimStart('0');
                    barcode.CreateTime = string.Empty;
                    barcode.ROWNO = string.Empty;
                    barcode.VOUCHERNO = itemRtb.GetString("AUFNR").TrimStart('0');
                    barcode.MATERIALNO = itemRtb.GetString("MATNR");
                    barcode.MATERIALDESC = itemRtb.GetString("MAKTX");
                    barcode.ClaimArriveTime = string.Empty;
                    barcode.Unit = string.Empty;
                    barcode.CURRENTLYDELIVERYNUM = itemRtb.GetInt("GAMNG");
                    barcode.ClaimDeliveryNum = 0;
                    barcode.ReadyDeliveryNum = 0;
                    barcode.WaitDeliveryNum = 0;
                    barcode.InRoadDeliveryNum = 0;
                    barcode.ReceiveTime = string.Empty;
                    barcode.DeliveryAddress = string.Empty;
                    barcode.CorrespondDepartment = string.Empty;
                    barcode.WorkCode = string.Empty;
                    barcode.JingxinName = string.Empty;
                    barcode.Plant = itemRtb.GetString("WERKS");
                    barcode.AndalaNo = string.Empty;
                    barcode.TrackNo = string.Empty;
                    barcode.Reason = string.Empty;
                    barcode.PRDVERSION = string.Empty;
                    barcode.ReserveNumber = string.Empty;
                    barcode.ReserveRowNo = string.Empty;
                    barcode.ISROHS = 1;

                    lstBarcode.Add(barcode);
                }
            }
            return lstBarcode;
        }

        #endregion

        #region 生产退料

        public bool GetProductionReturnInfoForSAP(string strPrdReturnNo, ref List<Barcode_Model> lstBarcode, ref string strError)
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
                List<string> tableNamesForOut = new List<string>() { "IT_SCTL", "RETURN" };
                Dictionary<string, IRfcTable> rtbsOutput = null;

                bool bSucc = sap_comm.getSapFunctionToTable(functionName, lstParameters, lstStructures, rtbInput, tableindex, ParameterNamesForOut, out ParametersOutput, StructureNamesForOut,
                        out StructureOutputs, tableNamesForOut, out rtbsOutput, ref strError);

                if (bSucc == false)
                {
                    return bSucc;
                }

                lstBarcode = CreateProductionReturnDetails(rtbsOutput["IT_SCTL"]);

                return new Barcode_Func().GetMaterialInfoByBarcodeList(30, ref lstBarcode, ref strError);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Barcode_Model> CreateProductionReturnDetails(IRfcTable rtb)
        {

            List<Barcode_Model> lstBarcode = null;
            if (rtb != null)
            {
                if (rtb.RowCount > 0)
                    lstBarcode = new List<Barcode_Model>();

                Barcode_Model barcode;
                foreach (var itemRtb in rtb)
                {
                    barcode = new Barcode_Model();
                    barcode.DELIVERYNO = itemRtb.GetString("BEDNR");
                    barcode.CreateTime = string.Empty;
                    barcode.ROWNO = itemRtb.GetString("BSPOS");
                    barcode.TrackNo = itemRtb.GetString("AUFNR");
                    barcode.VOUCHERNO = itemRtb.GetString("BEDNR");
                    barcode.MATERIALNO = itemRtb.GetString("MATNR");
                    barcode.MATERIALDESC = itemRtb.GetString("MAKTX");
                    barcode.ClaimArriveTime = string.Empty;
                    barcode.Unit = string.Empty;
                    barcode.CURRENTLYDELIVERYNUM = itemRtb.GetInt("MENGE");
                    barcode.ClaimDeliveryNum = 0;
                    barcode.ReadyDeliveryNum = 0;
                    barcode.WaitDeliveryNum = 0;
                    barcode.InRoadDeliveryNum = 0;
                    barcode.ReceiveTime = string.Empty;
                    barcode.DeliveryAddress = string.Empty;
                    barcode.CorrespondDepartment = itemRtb.GetString("DEPARTMENT");
                    barcode.WorkCode = string.Empty;
                    barcode.JingxinName = string.Empty;
                    barcode.Plant = itemRtb.GetString("WERKS");
                    barcode.PRDVERSION = string.Empty;
                    barcode.Reason = itemRtb.GetString("PMTXT");
                    barcode.ReserveNumber = itemRtb.GetString("RSNUM");
                    barcode.ReserveRowNo = itemRtb.GetString("RSPOS");
                    barcode.ISROHS = 1;

                    if (!string.IsNullOrEmpty(barcode.TrackNo)) barcode.TrackNo = barcode.TrackNo.TrimStart('0');
                    if (Common.Common_Func.IsAllZero(barcode.ReserveNumber)) barcode.ReserveNumber = string.Empty;
                    if (Common.Common_Func.IsAllZero(barcode.ReserveRowNo)) barcode.ReserveRowNo = string.Empty;

                    lstBarcode.Add(barcode);
                }
            }
            return lstBarcode;
        }
        #endregion
    }
}
