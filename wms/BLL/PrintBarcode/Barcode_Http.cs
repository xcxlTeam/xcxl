using BLL.JSONUtil;
using BLL.Material;
using BLL.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace BLL.PrintBarcode
{
    class Barcode_Http
    {

        #region 采购订单

        //public bool GetPurchaseInfoForPrint(string POCode, ref List<Barcode_Model> lstBarcode, string SupCode, ref string strError)
        //{
        //    if (SupCode.StartsWith("0000")) SupCode = SupCode.Substring(4);

        //    //string strURL = "http://192.168.0.144:9980/portal/rest/sup/getPoDetailsFromSrm?systemName=SRM&";
        //    string strURL = ConfigurationManager.AppSettings["SrmPOUrl"];
        //    string strParemater = string.Format("Code={0}&supCode={1}", POCode, SupCode);

        //    Barcode_Model deliveryReceiveModel = new Barcode_Model();

        //    //获取字符串
        //    string strResult = string.Empty;

        //    try
        //    {
        //        if (string.IsNullOrEmpty(POCode))
        //        {
        //            strError = "PO单号不能为空！";
        //            return false;
        //        }

        //        //调用SRM接口
        //        strResult = HTTPUtils.HTTPUtils.GetResultXML(strURL, strParemater, null);
        //        //解析SRM接口数据
        //        Barcode_Model barcode = JSONHelper.JsonToObject<Barcode_Model>(strResult);

        //        if (barcode.Type.Equals("E"))
        //        {
        //            strError = barcode.Message;
        //            return false;
        //        }

        //        if (barcode.Items.Count <= 0)
        //        {
        //            strError = "SRM接口调用成功，但没有采购订单数据！";
        //            return false;
        //        }

        //        lstBarcode = CreateBarcodeByPurchase(barcode);

        //        return new Barcode_Func().GetMaterialInfoByBarcodeList(70, ref lstBarcode, ref strError);

        //    }
        //    catch (Exception ex)
        //    {
        //        strError = "Web异常：" + ex.Message + ex.TargetSite;
        //        return false;
        //    }
        //}

        //public static List<Barcode_Model> CreateBarcodeByPurchase(Barcode_Model POBarcode)
        //{
        //    string value;
        //    List<Barcode_Model> lstBarcode = new List<Barcode_Model>();

        //    Barcode_Model barcode;
        //    foreach (var items in POBarcode.Items)
        //    {
        //        barcode = new Barcode_Model();
        //        barcode.VOUCHERTYPE = "70";
        //        barcode.BARCODETYPE = 20;
        //        barcode.SUPCODE = POBarcode.Dghead.SupCode;
        //        barcode.SUPNAME = POBarcode.Dghead.SupName;
        //        barcode.Comba = POBarcode.Dghead.Comba;
        //        barcode.Plant = POBarcode.Dghead.Factory;
        //        barcode.DELIVERYNO = string.Empty;
        //        barcode.VOUCHERNO = items.TryGetValue("3", out value) == true ? value : string.Empty;
        //        barcode.ROWNO = items.TryGetValue("4", out value) == true ? value.PadLeft(5, '0') : string.Empty;
        //        barcode.MATERIALNO = items.TryGetValue("5", out value) == true ? value : string.Empty;
        //        barcode.MATERIALDESC = items.TryGetValue("6", out value) == true ? value : string.Empty;
        //        barcode.WaitDeliveryNum = items.TryGetValue("8", out value) == true ? value.ToInt32() : 0;
        //        barcode.CURRENTLYDELIVERYNUM = barcode.WaitDeliveryNum;
        //        barcode.PRDVERSION = items.TryGetValue("10", out value) == true ? value : string.Empty;
        //        barcode.DeliveryAddress = items.TryGetValue("36", out value) == true ? value : string.Empty;
        //        barcode.ISROHS = 1;

        //        lstBarcode.Add(barcode);

        //    }
        //    return lstBarcode;
        //}

        #endregion

        #region 送货单

        //public bool GetDeliveryInfo(string POCode, ref List<Barcode_Model> lstBarcode, ref string strError)
        //{
        //    //string strURL = "http://192.168.0.144:9980/portal/rest/sup/getPoDetailsFromSrm?systemName=SRM&";
        //    string strURL = ConfigurationManager.AppSettings["SrmUrl"];
        //    string strParemater = string.Format("Code={0}", POCode);

        //    Barcode_Model deliveryReceiveModel = new Barcode_Model();

        //    //获取字符串
        //    string strResult = string.Empty;

        //    try
        //    {
        //        if (string.IsNullOrEmpty(POCode))
        //        {
        //            strError = "送货单号不能为空！";
        //            return false;
        //        }

        //        //调用SRM接口
        //        strResult = HTTPUtils.HTTPUtils.GetResultXML(strURL, strParemater, null);
        //        //解析SRM接口数据
        //        Barcode_Model barcode = JSONHelper.JsonToObject<Barcode_Model>(strResult);

        //        if (barcode.Type.Equals("E"))
        //        {
        //            strError = barcode.Message;
        //            return false;
        //        }

        //        if (barcode.Items.Count <= 0)
        //        {
        //            strError = "SRM接口调用成功，但没有送货单单数据！";
        //            return false;
        //        }

        //        lstBarcode = CreateBarcodeByDelivery(barcode);

        //        return new Barcode_Func().GetMaterialInfoByBarcodeList(10, ref lstBarcode, ref strError);

        //    }
        //    catch (Exception ex)
        //    {
        //        strError = "Web异常：" + ex.Message + ex.TargetSite;
        //        return false;
        //    }
        //}

        //public static List<Barcode_Model> CreateBarcodeByDelivery(Barcode_Model DEBarcode)
        //{
        //    string value;
        //    List<Barcode_Model> lstBarcode = new List<Barcode_Model>();
        //    Barcode_Func func = new Barcode_Func();

        //    Barcode_Model barcode;
        //    foreach (var items in DEBarcode.Items)
        //    {
        //        barcode = new Barcode_Model();
        //        barcode.VOUCHERTYPE = "10";
        //        barcode.BARCODETYPE = 10;
        //        barcode.SUPCODE = DEBarcode.Dghead.SupCode;
        //        barcode.SUPNAME = DEBarcode.Dghead.SupName;
        //        barcode.Comba = items.TryGetValue("COMBA", out value) == true ? value : string.Empty;
        //        barcode.Plant = items.TryGetValue("17", out value) == true ? value : string.Empty;
        //        barcode.Supplier = items.TryGetValue("SUPPLIER", out value) == true ? value : string.Empty;
        //        barcode.Comba = items.TryGetValue("COMBA", out value) == true ? value : string.Empty;
        //        barcode.DELIVERYNO = items.TryGetValue("KEYCODE", out value) == true ? value : string.Empty;
        //        barcode.CreateTime = items.TryGetValue("CREATEDTIME", out value) == true ? value : string.Empty;
        //        barcode.ROWNO = items.TryGetValue("1", out value) == true ? value : string.Empty;
        //        barcode.VOUCHERNO = items.TryGetValue("2", out value) == true ? value : string.Empty;
        //        barcode.MATERIALNO = items.TryGetValue("3", out value) == true ? value : string.Empty;
        //        barcode.MATERIALDESC = items.TryGetValue("4", out value) == true ? value : string.Empty;
        //        barcode.ClaimArriveTime = items.TryGetValue("5", out value) == true ? value : string.Empty;
        //        barcode.Unit = items.TryGetValue("6", out value) == true ? value : string.Empty;
        //        barcode.CURRENTLYDELIVERYNUM = items.TryGetValue("7", out value) == true ? value.ToDecimal() : 0;
        //        barcode.ClaimDeliveryNum = items.TryGetValue("8", out value) == true ? value.ToDecimal() : 0;
        //        barcode.ReadyDeliveryNum = items.TryGetValue("9", out value) == true ? value.ToDecimal() : 0;
        //        barcode.WaitDeliveryNum = items.TryGetValue("10", out value) == true ? value.ToInt32() : 0;
        //        barcode.InRoadDeliveryNum = items.TryGetValue("11", out value) == true ? value.ToDecimal() : 0;
        //        barcode.ReceiveTime = items.TryGetValue("12", out value) == true ? value : string.Empty;
        //        barcode.DeliveryAddress = items.TryGetValue("13", out value) == true ? value : string.Empty;
        //        barcode.CorrespondDepartment = items.TryGetValue("14", out value) == true ? value : string.Empty;
        //        barcode.WorkCode = items.TryGetValue("15", out value) == true ? value : string.Empty;
        //        barcode.JingxinName = items.TryGetValue("16", out value) == true ? value : string.Empty;
        //        barcode.Plant = items.TryGetValue("17", out value) == true ? value : string.Empty;
        //        barcode.PRDVERSION = items.TryGetValue("18", out value) == true ? value : string.Empty;
        //        barcode.ISROHS = 1;

        //        func.GetPurchaseByDelivery(ref barcode);

        //        lstBarcode.Add(barcode);

        //    }
        //    return lstBarcode;
        //}

        #endregion
    }
}
