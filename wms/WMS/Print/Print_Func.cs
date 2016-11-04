using WMS.Common;
using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ThoughtWorks.QRCode.Codec;

namespace WMS.Print
{
    internal class Print_Func
    {
        public static List<ComboBoxItem> GetOrderType()
        {
            List<ComboBoxItem> lstItem = new List<ComboBoxItem>();
            lstItem.Add(new ComboBoxItem() { ID = VoucherType.采购订单.ToInt32(), Name = VoucherType.采购订单.ToString() });
            lstItem.Add(new ComboBoxItem() { ID = VoucherType.送货单.ToInt32(), Name = VoucherType.送货单.ToString() });
            lstItem.Add(new ComboBoxItem() { ID = VoucherType.无过账快速入.ToInt32(), Name = VoucherType.无过账快速入.ToString() });
            lstItem.Add(new ComboBoxItem() { ID = VoucherType.需过账快速入.ToInt32(), Name = VoucherType.需过账快速入.ToString() });
            lstItem.Add(new ComboBoxItem() { ID = VoucherType.生产订单.ToInt32(), Name = VoucherType.生产订单.ToString() });
            lstItem.Add(new ComboBoxItem() { ID = VoucherType.生产退料.ToInt32(), Name = VoucherType.生产退料.ToString() });
            //lstItem.Add(new ComboBoxItem() { ID = VoucherType.无过账快速出.ToInt32(), Name = VoucherType.无过账快速出.ToString() });
            //lstItem.Add(new ComboBoxItem() { ID = VoucherType.需过账快速出.ToInt32(), Name = VoucherType.需过账快速出.ToString() });

            return lstItem;
        }

        public static bool CheckConfig()
        {
            Print_Var.InnerPrinter = OperXml.GetValue("InnerPrinter");
            Print_Var.OutboxPrinter = OperXml.GetValue("OutboxPrinter");

            Print_Var.InnerDPI = OperXml.GetValue("InnerDPI").ToInt32();
            Print_Var.OutboxDPI = OperXml.GetValue("OutboxDPI").ToInt32();

            Print_Var.InnerPrintNum = OperXml.GetValue("InnerPrintNum").ToInt32();
            Print_Var.OutboxPrintNum = OperXml.GetValue("OutboxPrintNum").ToInt32();


            if (string.IsNullOrEmpty(Print_Var.InnerPrinter))
            {
                return Common_Func.ErrorMessage("未能获取到【5㎝*3㎝】标签打印机名称，请配置后重试！", "载入失败");
            }
            if (string.IsNullOrEmpty(Print_Var.OutboxPrinter))
            {
                return Common_Func.ErrorMessage("未能获取到【8㎝*6㎝】标签打印机名称，请配置后重试！", "载入失败");
            }

            return true;
        }

        public static bool CheckLinked()
        {
            //if (!PrintLibrary.PrintLibrary_Func.GetPrinterLinkStatus(Print_Var.InnerPrinter))
            //{
            //    return Common_Func.ErrorMessage("内盒标签打印机未连接到当前计算机，请检查后重试！", "载入失败");
            //}
            //if (!PrintLibrary.PrintLibrary_Func.GetPrinterLinkStatus(Print_Var.OutboxPrinter))
            //{
            //    return Common_Func.ErrorMessage("外箱标签打印机未连接到当前计算机，请检查后重试！", "载入失败");
            //}

            return true;
        }

        public static bool CheckPrinter(bool isChange = true)
        {
            if (!CheckConfig())
            {
                if (isChange)
                {
                    if (ChangePrinter()) return true;
                }

                return false;
            }

            if (!CheckLinked()) return false;

            return true;
        }

        public static bool ChangePrinter()
        {
            bool isOK = false;

            using (FrmPrinterSet frm = new FrmPrinterSet())
            {
                isOK = frm.ShowDialog() == System.Windows.Forms.DialogResult.OK;
            }

            return isOK;
        }

        public static List<ComboBoxItem> GetPrinterDPI()
        {
            List<ComboBoxItem> lst = new List<ComboBoxItem>();
            lst.Add(new ComboBoxItem() { ID = 200, Name = "200dpi" });
            lst.Add(new ComboBoxItem() { ID = 300, Name = "300dpi" });
            //lst.Add(new ComboBoxItem() { ID = 600, Name = "600dpi" });

            return lst;
        }

        public static bool GetPrintInfo(VoucherType type, Barcode_Model order, ref List<Barcode_Model> lstBarcode, ref string strError)
        {
            if (string.IsNullOrEmpty(order.VOUCHERNO))
            {
                strError = "单据编号不能为空";
                return false;
            }

            switch (type)
            {
                //case VoucherType.送货单:
                //    return GetDeliveryInfoForPrint(order.VOUCHERNO, ref lstBarcode, ref strError);

                //case VoucherType.生产退料:
                //    return GetProductionReturnForPrint(order.VOUCHERNO, ref lstBarcode, ref strError);

                //case VoucherType.生产订单:
                //    return GetProductionInfoForPrint(order.VOUCHERNO, ref lstBarcode, ref strError);

                case VoucherType.采购订单:
                    if (string.IsNullOrEmpty(order.Supplier))
                    {
                        strError = "供应商不能为空";
                        return false;
                    }
                    //return GetPurchaseInfoForPrint(order.VOUCHERNO, order.Supplier, ref lstBarcode, ref strError);
                    return true;

                case VoucherType.无过账快速入:
                case VoucherType.需过账快速入:
                    return GetFastInInfoForPrint(order, ref lstBarcode, ref strError);

                default:
                    strError = "找不到对应的单据类型";
                    return false;
            }
        }
        //public static bool GetSupplierInfoForSAP(ref Supplier_Model SupplierInfo, ref string strError)
        //{
        //    return WMSWebService.service.GetSupplierInfoForSAP(ref SupplierInfo, ref strError);
        //}

        #region ZPL

        public static bool SendStringToPrinter(string strPrintCode)
        {
            return PrintLibrary.RawPrinterHelper.SendStringToPrinter(Print_Var.OutboxPrinter, strPrintCode);
        }
        public static PrintLibrary.Barcode_Model GetPrintBarcodeByServiceBarcode(Barcode_Model barcode)
        {
            return PrintLibrary.PrintLibrary_Func.ConvertToModel<PrintLibrary.Barcode_Model>(barcode);
        }


        public static bool PrintBoxBarcode(VoucherType type, Barcode_Model barcode)
        {
            PrintLibrary.Barcode_Model PrintInfo = GetPrintBarcodeByServiceBarcode(barcode);
            if (PrintInfo == null)
            {
                return false;
            }

            switch (type)
            {
                case VoucherType.采购订单:
                    return PrintLibrary.PrintLibrary_Func.PrintPurchaseReceiveInnerByBarcode(GetPrintBarcodeByServiceBarcode(barcode), Print_Var.OutboxPrinter, Print_Var.OutboxDPI);

                case VoucherType.任意单据:
                case VoucherType.送货单:
                    return PrintLibrary.PrintLibrary_Func.PrintDeliveryReceiceOutBarcode(PrintInfo, Print_Var.OutboxPrinter, Print_Var.OutboxDPI);

                case VoucherType.无过账快速入:
                case VoucherType.需过账快速入:
                    PrintInfo.DELIVERYNO = barcode.TrackNo;
                    return PrintLibrary.PrintLibrary_Func.PrintDeliveryReceiceOutBarcode(PrintInfo, Print_Var.OutboxPrinter, Print_Var.OutboxDPI);

                case VoucherType.生产订单:
                    return PrintLibrary.PrintLibrary_Func.PrintProductionOrderOutBarcode(PrintInfo, Print_Var.OutboxPrinter, Print_Var.OutboxDPI);

                case VoucherType.生产退料:
                //return PrintLibrary.PrintLibrary_Func.PrintProductionReturnOutBarcode(PrintInfo, Print_Var.OutboxPrinter, Print_Var.OutboxDPI);

                case VoucherType.检验退料单:
                    return PrintLibrary.PrintLibrary_Func.PrintQualityReturnOutBarcode(PrintInfo, Print_Var.OutboxPrinter, Print_Var.OutboxDPI);

                default:
                    return false;
            }
        }
        public static string GetBoxPrintStr(VoucherType type, Barcode_Model barcode)
        {
            PrintLibrary.Barcode_Model PrintInfo = GetPrintBarcodeByServiceBarcode(barcode);
            if (PrintInfo == null)
            {
                return string.Empty;
            }

            switch (type)
            {
                case VoucherType.采购订单:
                    return PrintLibrary.PrintLibrary_Func.GetPurchaseReceiveInnerPrintStr(GetPrintBarcodeByServiceBarcode(barcode), Print_Var.OutboxDPI);

                case VoucherType.任意单据:
                case VoucherType.送货单:
                    return PrintLibrary.PrintLibrary_Func.GetDeliveryReceiceOutPrintStr(PrintInfo, Print_Var.OutboxDPI);

                case VoucherType.无过账快速入:
                case VoucherType.需过账快速入:
                    PrintInfo.DELIVERYNO = barcode.TrackNo;
                    return PrintLibrary.PrintLibrary_Func.GetDeliveryReceiceOutPrintStr(PrintInfo, Print_Var.OutboxDPI);

                case VoucherType.生产订单:
                    return PrintLibrary.PrintLibrary_Func.GetProductionOrderOutPrintStr(PrintInfo, Print_Var.OutboxDPI);

                case VoucherType.生产退料:
                //return PrintLibrary.PrintLibrary_Func.GetProductionOrderOutPrintStr(PrintInfo, Print_Var.OutboxDPI);

                case VoucherType.检验退料单:
                    return PrintLibrary.PrintLibrary_Func.GetQualityReturnOutPrintStr(PrintInfo, Print_Var.OutboxDPI);

                default:
                    return string.Empty;
            }
        }
        public static string GetBoxContentStr(VoucherType type, Barcode_Model barcode)
        {
            PrintLibrary.Barcode_Model PrintInfo = GetPrintBarcodeByServiceBarcode(barcode);
            if (PrintInfo == null)
            {
                return string.Empty;
            }

            switch (type)
            {
                case VoucherType.采购订单:
                    return PrintLibrary.PrintLibrary_Func.GetPurchaseReceiveInnerContentStr(GetPrintBarcodeByServiceBarcode(barcode), Print_Var.OutboxDPI);

                case VoucherType.任意单据:
                case VoucherType.送货单:
                    return PrintLibrary.PrintLibrary_Func.GetDeliveryReceiceOutContentStr(PrintInfo, Print_Var.OutboxDPI);

                case VoucherType.无过账快速入:
                case VoucherType.需过账快速入:
                    PrintInfo.DELIVERYNO = barcode.TrackNo;
                    return PrintLibrary.PrintLibrary_Func.GetDeliveryReceiceOutContentStr(PrintInfo, Print_Var.OutboxDPI);

                case VoucherType.生产订单:
                    return PrintLibrary.PrintLibrary_Func.GetProductionOrderOutContentStr(PrintInfo, Print_Var.OutboxDPI);

                case VoucherType.生产退料:
                //return PrintLibrary.PrintLibrary_Func.GetProductionReturnOutContentStr(PrintInfo, Print_Var.OutboxDPI);

                case VoucherType.检验退料单:
                    return PrintLibrary.PrintLibrary_Func.GetQualityReturnOutContentStr(PrintInfo, Print_Var.OutboxDPI);

                default:
                    return string.Empty;
            }
        }
        public static string GetBoxLogoStr(VoucherType type)
        {
            switch (type)
            {
                case VoucherType.采购订单:
                    return PrintLibrary.PrintLibrary_Func.GetPurchaseReceiveInnerLogoStr(Print_Var.OutboxDPI);

                case VoucherType.任意单据:
                case VoucherType.无过账快速入:
                case VoucherType.需过账快速入:
                case VoucherType.送货单:
                    return PrintLibrary.PrintLibrary_Func.GetDeliveryReceiceOutLogoStr(Print_Var.OutboxDPI, type.ToInt32());

                case VoucherType.生产订单:
                    return PrintLibrary.PrintLibrary_Func.GetProductionOrderOutLogoStr(Print_Var.OutboxDPI);

                case VoucherType.生产退料:
                //return PrintLibrary.PrintLibrary_Func.GetProductionReturnOutLogoStr(Print_Var.OutboxDPI);

                case VoucherType.检验退料单:
                    return PrintLibrary.PrintLibrary_Func.GetQualityReturnOutLogoStr(Print_Var.OutboxDPI);

                default:
                    return string.Empty;
            }
        }
        public static string GetBoxClearStr(VoucherType type)
        {
            switch (type)
            {
                case VoucherType.采购订单:
                    return PrintLibrary.PrintLibrary_Func.GetPurchaseReceiveInnerClearStr();

                case VoucherType.任意单据:
                case VoucherType.无过账快速入:
                case VoucherType.需过账快速入:
                case VoucherType.送货单:
                    return PrintLibrary.PrintLibrary_Func.GetDeliveryReceiceOutClearStr();

                case VoucherType.生产订单:
                    return PrintLibrary.PrintLibrary_Func.GetProductionOrderOutClearStr();

                case VoucherType.生产退料:
                //return PrintLibrary.PrintLibrary_Func.GetProductionReturnOutClearStr();

                case VoucherType.检验退料单:
                    return PrintLibrary.PrintLibrary_Func.GetQualityReturnOutClearStr();

                default:
                    return string.Empty;
            }
        }


        public static bool PrintArea(string strAreaNo)
        {
            return PrintLibrary.PrintLibrary_Func.PrintArea(strAreaNo, Print_Var.OutboxPrinter, Print_Var.OutboxDPI);
        }
        public static string GetAreaPrintStr(string strAreaNo)
        {
            return PrintLibrary.PrintLibrary_Func.GetAreaPrintStr(strAreaNo, Print_Var.OutboxDPI);
        }
        public static string GetTempAreaPrintStr(string strAreaNo)
        {
            return PrintLibrary.PrintLibrary_Func.GetTempAreaPrintStr(strAreaNo);
        }
        #endregion

        ///// <summary>
        ///// 获取送货单打印信息
        ///// </summary>
        //public static bool GetDeliveryInfoForPrint(string strDeliveryNo, ref List<Barcode_Model> lstBarcode, ref string strError)
        //{
        //    try
        //    {
        //        return WMSWebService.service.GetDeliveryInfoForPrint(strDeliveryNo, ref lstBarcode, ref strError);
        //    }
        //    catch (Exception ex)
        //    {
        //        strError = ex.Message;
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// 获取采购单打印信息
        ///// </summary>
        //public static bool GetPurchaseInfoForPrint(string strPoCode, string strSupCode, ref List<Barcode_Model> lstBarcode, ref string strError)
        //{
        //    try
        //    {
        //        return WMSWebService.service.GetPurchaseInfoForPrint(strPoCode, ref lstBarcode, strSupCode, ref strError);
        //    }
        //    catch (Exception ex)
        //    {
        //        strError = ex.Message;
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// 获取生产订单打印信息
        ///// </summary>
        //public static bool GetProductionInfoForPrint(string strProductionNo, ref List<Barcode_Model> lstBarcode, ref string strError)
        //{
        //    try
        //    {
        //        return WMSWebService.service.GetProductionInfoForPrint(strProductionNo, ref lstBarcode, ref strError);
        //    }
        //    catch (Exception ex)
        //    {
        //        strError = ex.Message;
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// 获取生产退料单打印信息
        ///// </summary>
        //public static bool GetProductionReturnForPrint(string strProductionNo, ref List<Barcode_Model> lstBarcode, ref string strError)
        //{
        //    try
        //    {
        //        return WMSWebService.service.GetProductionReturnInfoForPrint(strProductionNo, ref lstBarcode, ref strError);
        //    }
        //    catch (Exception ex)
        //    {
        //        strError = ex.Message;
        //        return false;
        //    }
        //}

        public static bool GetFastInInfoForPrint(Barcode_Model TaskInfo, ref  List<Barcode_Model> lstBarcode, ref string strError)
        {
            return WMSWebService.service.GetFastInInfoForPrint(TaskInfo, ref lstBarcode, ref strError);
        }

        public static bool CreateBarcodeInfo(Barcode_Model parameter, ref List<Barcode_Model> lstBarcode, ref string strError)
        {
            try
            {
                return WMSWebService.service.CreateBarcodeInfo(parameter, ref lstBarcode, ref strError);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public static bool GetOutBarcodeListByBarcode(Barcode_Model parameter, ref List<Barcode_Model> lstOutBarcode, ref string strError)
        {
            try
            {
                return WMSWebService.service.GetOutBarcodeListByBarcode(parameter, ref lstOutBarcode, ref strError);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public static bool GetCensorshipListByPage(ref List<DeliveryReceive_Model> lstMain, DeliveryReceive_Model queryMain, ref DividPage page, ref string strError)
        {
            return WMSWebService.service.GetQualityListByPage(ref lstMain, queryMain, ref page, Common_Var.CurrentUser, ref strError);
        }

        public static bool GetCensorshipDetailByPage(ref List<DeliveryReceiveDetail_Model> lstDetail, DeliveryReceiveDetail_Model queryDetail, ref DividPage page, ref string strError)
        {
            return WMSWebService.service.GetQualityDetailListByPage(ref lstDetail, queryDetail, ref page, Common_Var.CurrentUser, ref strError);
        }


        public static bool GetOutBarcodeListByPage(ref List<Barcode_Model> modelList, Barcode_Model model, ref DividPage page, ref string strError)
        {
            return WMSWebService.service.GetOutBarcodeListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }

        public static bool GetStockBarcodeListByPage(ref List<Barcode_Model> modelList, Barcode_Model model, ref DividPage page, ref string strError)
        {
            return WMSWebService.service.GetStockBarcodeListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }

        public static string GetBarCodeInfo(string strBarcode)
        {
            return WMSWebService.service.GetBarCodeInfo(strBarcode);
        }

        public static bool GetMaterialInfo(ref TempMaterialInfo model, int type, ref string strError)
        {
            return WMSWebService.service.GetMaterialInfo(ref model, type, Common_Var.CurrentUser, ref strError);
        }

        public static bool GetOutbarcodeByID(ref Barcode_Model model, ref string strError)
        {
            return WMSWebService.service.GetOutbarcodeByID(ref model, Common_Var.CurrentUser, ref strError);
        }

        public static bool SaveOutBarcode(ref Barcode_Model model, ref string strError)
        {
            return WMSWebService.service.SaveOutBarcode(ref model, Common_Var.CurrentUser, ref strError);
        }

        public static bool PrintBarcode(Barcode_Model barcodeModel, ref string strErrMsg)
        {
            return WMSWebService.service.PrintBarcode(barcodeModel, Common_Var.CurrentUser, ref strErrMsg);
        }

        public static bool PrintQuality(DeliveryReceive_Model deliveryMdl, ref string strErrMsg)
        {
            return WMSWebService.service.PrintQuality(deliveryMdl, Common_Var.CurrentUser, ref strErrMsg);
        }

        public static Image CreateQRCode(string strBarcode)
        {
            try
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeScale = 2;
                qrCodeEncoder.QRCodeVersion = 0;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                return qrCodeEncoder.Encode(strBarcode);
            }
            catch (Exception ex)
            {
                //throw new Exception("生成发料通知单二维码错误。");
                throw new Exception(ex.Message);
            }
        }
        public static string ConvertImageToString(Image imgOrderNo)
        {
            byte[] BImage = ImageToBytes(imgOrderNo, System.Drawing.Imaging.ImageFormat.Bmp);
            return Convert.ToBase64String(BImage);
        }

        /// 将图片Image转换成Byte[]
        /// </summary>
        /// <param name="Image">image对象</param>
        /// <param name="imageFormat">后缀名</param>
        /// <returns></returns>
        public static byte[] ImageToBytes(Image Image, System.Drawing.Imaging.ImageFormat imageFormat)
        {
            if (Image == null) { return null; }
            byte[] data;
            using (MemoryStream ms = new MemoryStream())
            {
                using (Bitmap Bitmap = new Bitmap(Image))
                {
                    Bitmap.Save(ms, imageFormat);
                    ms.Position = 0;
                    data = new byte[ms.Length];
                    ms.Read(data, 0, Convert.ToInt32(ms.Length));
                    ms.Flush();
                }
            }
            return data;
        }
    }
}
