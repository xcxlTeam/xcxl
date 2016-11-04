using BLL.Common;
using BLL.Basic.User;
using BLL.JSONUtil;
using PrintBarcode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using BLL.Material;
using System.Data.SqlClient;
using System.Configuration;
using BLL.DeliveryReceive;
using System.Data;
using BLL.Stock;


namespace BLL.PrintBarcode
{
    public class Barcode_Func
    {
        private Barcode_DB _db = new Barcode_DB();

        /// <summary>
        /// 根据外箱的i获取内盒的对象
        /// </summary>
        /// <param name="Barcode_Model"></param>
        /// <param name="innerBarcode"></param>
        /// <returns></returns>
        public bool GetInnerBarcodeByOutBarcodeId(Barcode_Model Barcode_Model, ref Barcode_Model innerBarcode)
        {
            bool isResult = false;
            Barcode_DB barcodeDB = new Barcode_DB();
            isResult = barcodeDB.GetInnertBarcodeByOutBarcodeId(Barcode_Model, ref innerBarcode);
            return isResult;
        }
        public bool GetInnerBarcodeListByOutBarcodeList(List<Barcode_Model> lstBarcode, ref List<InnerBarcode_Model> lstInnerBarcode)
        {
            bool isResult = false;
            isResult = _db.GetInnerBarcodeListByOutBarcodeList(lstBarcode, ref lstInnerBarcode);
            return isResult;
        }

        /// <summary>
        /// 获取外盒的对象
        /// </summary>
        /// <param name="Barcode_Model"></param>
        /// <param name="lstBarcode"></param>
        /// <returns></returns>
        public bool GetOutBarcodeInfo(Barcode_Model Barcode_Model, ref List<Barcode_Model> lstBarcode)
        {
            bool IsResult = false;

            Barcode_DB barcodeDB = new Barcode_DB();
            IsResult = barcodeDB.GetOutBarcodeInfo(Barcode_Model, ref lstBarcode);

            return IsResult;

        }
        public bool CreateBarcodeInfo(Barcode_Model Barcode_Model, ref List<Barcode_Model> lstBarcode, ref string strErrMsg)
        {
            try
            {
                bool bSucc = false;
                List<InnerBarcode_Model> lstInnerBarcode = new List<InnerBarcode_Model>();
                GenerationQRCode genQRCode = new GenerationQRCode();
                if (string.IsNullOrEmpty(Barcode_Model.CUSNAME)) Barcode_Model.CUSNAME = "京信通信";
                bSucc = _db.CreateBarcodeInfo(Barcode_Model, ref lstBarcode, ref lstInnerBarcode, ref strErrMsg);

                if (bSucc == false)
                {
                    return bSucc;
                }

                string[] arr;
                int count;
                foreach (var item in lstBarcode)
                {
                    arr = new string[2];
                    count = Common.Common_Func.SpiltString(item.MATERIALDESC, 25, ref arr);
                    if (count <= 1)
                    {
                        item.MATERIALDESCLINE1 = arr[0].Trim();
                        item.MATERIALDESCLINE2 = " ";
                    }
                    else if (count == 2)
                    {
                        item.MATERIALDESCLINE1 = arr[0].Trim();
                        item.MATERIALDESCLINE2 = arr[1].Trim();
                    }
                    else
                    {
                        item.MATERIALDESCLINE1 = arr[0].Trim();
                        item.MATERIALDESCLINE2 = arr[1].Trim() + "...";
                    }

                    arr = new string[2];
                    count = Common.Common_Func.SpiltString(item.CUSNAME, 40, ref arr);
                    if (count >= 2)
                    {
                        item.CUSNAME = arr[0].Trim() + "...";
                    }

                    arr = new string[2];
                    count = Common.Common_Func.SpiltString(item.SUPNAME, 44, ref arr);
                    if (count >= 2)
                    {
                        item.SUPNAME = arr[0].Trim() + "...";
                    }

                    item.BARCODEIMG = ConvertImageToString(genQRCode.CreateQRCode(item.BARCODE));
                }

                return bSucc;
            }
            catch (Exception ex)
            {
                strErrMsg = "web异常：" + ex.Message + ex.StackTrace;
                return false;
            }
        }

        public Barcode_Model GetCheckBarcode(string strBarcode, ref string strError)
        {
            Barcode_Model model = new Barcode_Model();
            using (SqlDataReader dr = _db.GetBarcodeInfo(strBarcode))
            {
                if (dr.Read())
                {
                    model = (GetModelFromDataReader(dr, false));
                }
                else
                {
                    strError = "找不到对应条码";
                    return null;
                }
            }
            return model;
        }

        public Barcode_Model GetCheckBarcode(int checkID, string strBarcode, bool isTray, ref string strError)
        {
            Barcode_Model model = new Barcode_Model();
            try
            {
                using (SqlDataReader dr = _db.GetBarcodeInfo(strBarcode))
                {
                    if (dr.Read())
                    {
                        model = (GetModelFromDataReader(dr, false));
                    }
                    else
                    {
                        strError = "找不到对应条码";
                        return null;
                    }
                }
                if(model.iFlag==4)
                {
                    strError = "对应条码已经出库！";
                    return null;
                }
                if (isTray)
                {
                    if (!_db.IsTrayPermit(model, ref strError))
                    {
                        return null;
                    }
                    Tray_Func tf = new Tray_Func();
                    Tray_Model tray = new Tray_Model();
                    if (tf.GetTrayInfoByTrayID(model, ref tray))
                        model.tray_Model = tray;
                    if (model.tray_Model == null)
                    {
                        strError = "托盘信息有误！";
                        return null;
                    }
                }
                if (!_db.MaterialCheckAble(checkID, model, isTray))
                {
                    strError = "该物料已经被锁定!";
                    return null;
                }

                if (!_db.IsChecked(checkID, model, isTray))
                {
                    strError = "该物料已经被扫描!";
                    return null;
                }

                if (!_db.MaterialOfCheck(checkID, model, isTray, ref strError))
                {
                    if (string.IsNullOrEmpty(strError))
                    {
                        strError = "扫描物料不属于当前盘点!";
                        return null;
                    }
                }

                if (model.QTY <= 0)
                {
                    strError = "该物料数量为零!";
                    return null;
                }

                if (model.ID <= 0)
                {
                    strError = "物料信息缺失!";
                    return null;
                }

                return model;
            }
            catch (Exception ex)
            {
                strError = "Web异常：" + ex.Message + ex.StackTrace;
                return null;
            }
            finally
            {
            }
        }

        public Barcode_Model GetCheckOmitAddBarcode(string strBarcode, bool isTray, ref string strError)
        {
            Barcode_Model model = new Barcode_Model();
            try
            {
                using (SqlDataReader dr = _db.GetBarcodeInfo(strBarcode))
                {
                    if (dr.Read())
                    {
                        model = (GetModelFromDataReader(dr, false));
                    }
                    else
                    {
                        strError = "找不到对应条码";
                        return null;
                    }
                }

                if(model.iFlag!=4)
                {
                    strError = "对应条码并未出库，无需补录";
                    return null;
                }

                if (!_db.IsCheckOmitAddPermit(model, ref strError))
                {
                    return null;
                }
                if (model.QTY <= 0)
                {
                    strError = "该物料数量为零!";
                    return null;
                }

                if (model.ID <= 0)
                {
                    strError = "物料信息缺失!";
                    return null;
                }

                return model;
            }
            catch (Exception ex)
            {
                strError = "Web异常：" + ex.Message + ex.StackTrace;
                return null;
            }
            finally
            {
            }
        }


        private Barcode_Model GetModelFromDataReader(SqlDataReader dr, bool getPrintInfo = true)
        {
            Barcode_Model model = new Barcode_Model();
            model.ID = dr["ID"].ToDecimal();
            model.VOUCHERNO = dr["VOUCHERNO"].ToDBString();
            model.ROWNO = dr["ROWNO"].ToDBString();
            model.DELIVERYNO = dr["DELIVERYNO"].ToDBString();
            model.VOUCHERTYPE = dr["VOUCHERTYPE"].ToDBString();
            model.MATERIALNO = dr["MATERIALNO"].ToDBString();
            model.MATERIALSTD = dr["MATERIALSTD"].ToDBString();
            model.MATERIALDESC = dr["MATERIALDESC"].ToDBString();
            model.CUSCODE = dr["CUSCODE"].ToDBString();
            model.CUSNAME = dr["CUSNAME"].ToDBString();
            model.SUPCODE = dr["SUPCODE"].ToDBString();
            model.SUPNAME = dr["SUPNAME"].ToDBString();
            model.BATCHNO = dr["BATCHNO"].ToDBString();
            model.OUTPACKQTY = dr["OUTPACKQTY"].ToDecimal();
            model.INNERPACKQTY = dr["INNERPACKQTY"].ToDecimal();
            model.VOUCHERQTY = dr["VOUCHERQTY"].ToDecimal();
            model.BATCHQTY = dr["BATCHQTY"].ToDecimal();
            model.QTY = dr["QTY"].ToDecimal();
            model.NOPACK = dr["NOPACK"].ToDecimal();
            model.PRINTQTY = dr["PRINTQTY"].ToDecimal();
            model.BARCODE = dr["BARCODE"].ToDBString();
            model.BARCODETYPE = dr["BARCODETYPE"].ToDecimal();
            model.SERIALNO = dr["SERIALNO"].ToDBString();
            model.BARCODENO = dr["BARCODENO"].ToDecimal();
            model.PRDVERSION = dr["PRDVERSION"].ToDBString();
            model.PLATEDGOLD = dr["PLATEDGOLD"].ToDecimal();
            model.PLATEDSILVER = dr["PLATEDSILVER"].ToDecimal();
            model.PLATEDTIN = dr["PLATEDTIN"].ToDecimal();
            model.OTHERS = dr["OTHERS"].ToDecimal();
            model.OPERATOR = dr["OPERATOR"].ToDBString();
            model.OPERATIONDATE = dr["OPERATIONDATE"].ToDateTime();
            model.BARCODEIMG = dr["BARCODEIMG"].ToDBString();
            model.OUTCOUNT = dr["OUTCOUNT"].ToDecimal();
            model.INNERCOUNT = dr["INNERCOUNT"].ToDecimal();
            model.MANTISSAQTY = dr["MANTISSAQTY"].ToDecimal();
            model.ISROHS = dr["ISROHS"].ToDecimal();
            model.OUTBOX_ID = dr["OUTBOX_ID"].ToDecimal();
            model.INNER_ID = dr["INNER_ID"].ToDecimal();
            model.SN = dr["SN"].ToDBString();
            model.TrackNo = dr["TrackNo"].ToDBString();
            model.ReserveNumber = dr["ReserveNumber"].ToDBString();
            model.ReserveRowNo = dr["ReserveRowNo"].ToDBString();
            model.Department = dr["Department"].ToDBString();
            model.Reason = dr["Reason"].ToDBString();
            model.AndalaNo = dr["AndalaNo"].ToDBString();
            model.SHOWSUP = dr["ShowSup"].ToInt32();
            model.TrayID = dr["TrayID"].ToInt32();
            model.iFlag= dr["iFlag"].ToInt32();

            if (Common_Func.readerExists(dr, "StrBarcodeType")) model.StrBarcodeType = dr["StrBarcodeType"].ToDBString();
            if (Common_Func.readerExists(dr, "StrVoucherType")) model.StrVoucherType = dr["StrVoucherType"].ToDBString();
            if (Common_Func.readerExists(dr, "AreaNo")) model.AreaNo = dr["AreaNo"].ToDBString();
            if (Common_Func.readerExists(dr, "HouseNo")) model.HouseNo = dr["HouseNo"].ToDBString();
            if (Common_Func.readerExists(dr, "WarehouseNo")) model.WarehouseNo = dr["WarehouseNo"].ToDBString();
            if (Common_Func.readerExists(dr, "AreaName")) model.AreaName = dr["AreaName"].ToDBString();
            if (Common_Func.readerExists(dr, "HouseName")) model.HouseName = dr["HouseName"].ToDBString();
            if (Common_Func.readerExists(dr, "WarehouseName")) model.WarehouseName = dr["WarehouseName"].ToDBString();
            if (Common_Func.readerExists(dr, "CreateTime")) model.CreateTime = dr["CreateTime"].ToDBString();

            return model;
        }

        public string GetCheckBarcodeForAndroid(int checkID, string strBarcode, bool isTray)
        {
            Barcode_Model model = new Barcode_Model();
            string strError = string.Empty;

            try
            {
                model = GetCheckBarcode(checkID, strBarcode, isTray, ref strError);
                if (model == null)
                {
                    model = new Barcode_Model();
                    model.Status = "E";
                    model.Message = "条码信息获取失败!" + strError;
                    return JSONHelper.ObjectToJson(model);
                }

                model.Status = "S";
                if (!string.IsNullOrEmpty(strError))
                    model.Message = strError;
                return JSONHelper.ObjectToJson(model);
            }
            catch (Exception ex)
            {
                model.Status = "E";
                model.Message = "Web异常：" + ex.Message + ex.StackTrace;
                return JSONHelper.ObjectToJson(model);
            }
            finally
            {
            }
        }

        public string GetBarcodeInfoForAndroid(string strBarcode)
        {
            Barcode_Model model = new Barcode_Model();
            try
            {
                using (SqlDataReader dr = _db.GetBarcodeInfo(strBarcode))
                {
                    if (dr.Read())
                    {
                        model = (GetModelFromDataReader(dr, false));
                    }
                    else
                    {
                        model.Status = "E";
                        model.Message = "找不到对应条码";
                        return JSONHelper.ObjectToJson(model);
                    }
                }

                model.Status = "S";
                return JSONHelper.ObjectToJson(model);
            }
            catch (Exception ex)
            {
                model.Status = "E";
                model.Message = "Web异常：" + ex.Message + ex.StackTrace;
                return JSONHelper.ObjectToJson(model);
            }
            finally
            {
            }
        }

        public bool PrintBarcode(Barcode_Model Barcode_Model, UserInfo user, ref string strErrMsg)
        {
            try
            {
                bool bSucc = false;
                Barcode_Model.OPERATOR = user.UserNo;
                bSucc = _db.PrintBarcode(Barcode_Model, ref strErrMsg);

                return bSucc;
            }
            catch (Exception ex)
            {
                strErrMsg = "web异常：" + ex.Message + ex.StackTrace;
                return false;
            }
        }

        private string ConvertImageToString(Image imgOrderNo)
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


        #region 获取单据打印信息

        public bool GetPurchaseByDelivery(ref Barcode_Model barcode)
        {
            using (SqlDataReader dr = _db.GetPurchaseByDelivery(barcode))
            {
                if (dr.Read())
                {
                    barcode.BATCHNO = dr["BATCHNO"].ToDBString();
                    barcode.INNERPACKQTY = dr["INNERPACKQTY"].ToDecimal();
                }
            }

            barcode.PrintedQty = GetPrintedQtyByBarcode(barcode);
            return true;
        }

        //public bool GetMaterialInfoByBarcodeList(int VoucherType, ref List<Barcode_Model> lstBarcode, ref string strError)
        //{
        //    List<Material_Model> lstMaterial = new List<Material_Model>();

        //    DeliveryReceive_SAP DSAP = new DeliveryReceive_SAP();
        //    if (!DSAP.GetRoshFlagForSap(lstBarcode, ref lstMaterial, ref strError))
        //    {
        //        strError = string.Format("获取SAP物料信息失败!{0}{1}", " ", strError);
        //        return false;
        //    }

        //    Material_Model material;
        //    foreach (Barcode_Model barcode in lstBarcode)
        //    {
        //        barcode.PrintedQty = GetPrintedQtyByBarcode(barcode);

        //        switch (VoucherType)
        //        {
        //            case 10:
        //            case 70:
        //                material = lstMaterial.Find(t => t.VoucherNo == barcode.VOUCHERNO && t.RowNo == barcode.ROWNO);
        //                break;

        //            default:
        //                material = lstMaterial.Find(t => t.MaterialNo == barcode.MATERIALNO);
        //                break;
        //        }
        //        if (material == null) continue;

        //        barcode.BIsRoSH = material.ROHS == "1";
        //        barcode.ISROHS = barcode.BIsRoSH.ToInt32();
        //    }

        //    return true;
        //}


        //public bool GetDeliveryInfoForPrint(string strDeliveryNo, ref List<Barcode_Model> lstBarcode, ref string strError)
        //{
        //    try
        //    {
        //        return new Barcode_Http().GetDeliveryInfo(strDeliveryNo, ref lstBarcode, ref strError);
        //    }
        //    catch (Exception ex)
        //    {
        //        strError = "Web异常：" + ex.Message;
        //        return false;
        //    }
        //}

        //public bool GetPurchaseInfoForPrint(string POCode, ref List<Barcode_Model> lstBarcode, string SupCode, ref string strError)
        //{
        //    try
        //    {
        //        return new Barcode_Http().GetPurchaseInfoForPrint(POCode, ref lstBarcode, SupCode, ref strError);
        //    }
        //    catch (Exception ex)
        //    {
        //        strError = "Web异常：" + ex.Message;
        //        return false;
        //    }
        //}

        public bool GetProductionInfoForPrint(string strProductionNo, ref List<Barcode_Model> lstBarcode, ref string strError)
        {
            try
            {
                //return new Barcode_Sap().GetProductionInfoForSAP(strProductionNo, ref lstBarcode, ref strError);
                return true;
            }
            catch (Exception ex)
            {
                strError = "Web异常：" + ex.Message;
                return false;
            }
        }

        //public bool GetProductionReturnInfoForPrint(string strPrdReturnNo, ref List<Barcode_Model> lstBarcode, ref string strError)
        //{
        //    try
        //    {
        //        return new Barcode_Sap().GetProductionReturnInfoForSAP(strPrdReturnNo, ref lstBarcode, ref strError);
        //    }
        //    catch (Exception ex)
        //    {
        //        strError = "Web异常：" + ex.Message;
        //        return false;
        //    }
        //}

        public bool GetFastInInfoForPrint(Barcode_Model TaskInfo, ref List<Barcode_Model> lstBarcode, ref string strError)
        {
            try
            {
                List<Barcode_Model> lst = new List<Barcode_Model>();
                lst = _db.GetFastInInfo(TaskInfo);

                if (lst != null && lst.Count >= 1)
                {
                    lstBarcode = lst;
                    return true;
                }
                else
                {
                    strError = "查询不到对应单据";
                    return false;
                }
            }
            catch (Exception ex)
            {
                strError = "Web异常：" + ex.Message;
                return false;
            }
        }
        #endregion

        public bool GetOutBarcodeListByBarcode(Barcode_Model param, ref List<Barcode_Model> lstOutBarcode, ref string strError)
        {
            List<Barcode_Model> lstModel = new List<Barcode_Model>();
            try
            {
                using (SqlDataReader dr = _db.GetOutBarcodeListByBarcode(param))
                {
                    while (dr.Read())
                    {
                        lstModel.Add(GetModelFromDataReader(dr));
                    }
                }

                lstOutBarcode = lstModel;
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
            finally
            {
            }
        }

        public bool GetOutBarcodeListByPage(ref List<Barcode_Model> modelList, Barcode_Model model, ref DividPage page, UserInfo user, ref string strError)
        {
            if (page == null) page = new DividPage();
            List<Barcode_Model> lstModel = new List<Barcode_Model>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_OUTBARCODE", GetFilterSql(model, user)))
                {
                    while (dr.Read())
                    {
                        lstModel.Add(GetModelFromDataReader(dr));
                    }
                }

                modelList = lstModel;
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
            finally
            {
            }
        }

        public bool GetStockBarcodeListByPage(ref List<Barcode_Model> modelList, Barcode_Model model, ref DividPage page, UserInfo user, ref string strError)
        {
            if (page == null) page = new DividPage();
            List<Barcode_Model> lstModel = new List<Barcode_Model>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_StockBarcode", GetFilterSql(model, user), "*", "Order By WarehouseNo,HouseNo,AreaNo,MaterialNo,SerialNo"))
                {
                    while (dr.Read())
                    {
                        lstModel.Add(GetModelFromDataReader(dr));
                    }
                }

                modelList = lstModel;
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
            finally
            {
            }
        }

        private string GetFilterSql(Barcode_Model model, UserInfo user)
        {
            try
            {
                string strSql = " Where SERIALNO IS NOT NULL ";
                bool hadWhere = true;


                if (!string.IsNullOrEmpty(model.VOUCHERNO))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    //strSql += " (CASE VOUCHERTYPE WHEN N'10' THEN DELIVERYNO ELSE VOUCHERNO END) LIKE '%" + model.VOUCHERNO + "%' ";
                    strSql += " VOUCHERNO LIKE '%" + model.VOUCHERNO + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.DELIVERYNO))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " DELIVERYNO LIKE '%" + model.DELIVERYNO + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.TrackNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " TrackNo LIKE '%" + model.TrackNo + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.AndalaNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " AndalaNo LIKE '%" + model.AndalaNo + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.ROWNO))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " ROWNO LIKE '%" + model.ROWNO + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.MATERIALNO))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (MATERIALNO LIKE '%" + model.MATERIALNO + "%' OR MATERIALDESC LIKE '%" + model.MATERIALNO + "%') ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.SERIALNO))
                {
                    string[] arr = model.SERIALNO.Split('@');
                    if (arr.Length == 4) model.SERIALNO = arr[2];

                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " SERIALNO LIKE '%" + model.SERIALNO + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.BATCHNO))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " BATCHNO LIKE '%" + model.BATCHNO + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.SN))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " SN LIKE '%" + model.SN + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.VOUCHERTYPE))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " VOUCHERTYPE = '" + model.VOUCHERTYPE + "' ";
                    hadWhere = true;
                }

                if (model.BARCODETYPE >= 1)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " BARCODETYPE = '" + model.BARCODETYPE + "' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.AreaNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (AreaNo LIKE '%" + model.AreaNo + "%' OR AreaName LIKE '%" + model.AreaNo + "%') ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.HouseNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (HouseNo LIKE '%" + model.HouseNo + "%' OR HouseName LIKE '%" + model.HouseNo + "%') ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.WarehouseNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (WarehouseNo LIKE '%" + model.WarehouseNo + "%' OR WarehouseName LIKE '%" + model.WarehouseNo + "%') ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.MATERIALNO))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (MaterialNo LIKE '%" + model.MATERIALNO + "%' OR MaterialDesc LIKE '%" + model.MATERIALNO + "%') ";
                    hadWhere = true;
                }


                return strSql;
            }
            catch
            {
                return string.Empty;
            }
        }

        private Barcode_Model GetModelFromDataReader(SqlDataReader dr)
        {
            Barcode_Model model = new Barcode_Model();
            model.ID = dr["ID"].ToDecimal();
            model.VOUCHERNO = dr["VOUCHERNO"].ToDBString();
            model.ROWNO = dr["ROWNO"].ToDBString();
            model.DELIVERYNO = dr["DELIVERYNO"].ToDBString();
            model.VOUCHERTYPE = dr["VOUCHERTYPE"].ToDBString();
            model.MATERIALNO = dr["MATERIALNO"].ToDBString();
            model.MATERIALDESC = dr["MATERIALDESC"].ToDBString();
            model.CUSCODE = dr["CUSCODE"].ToDBString();
            model.CUSNAME = dr["CUSNAME"].ToDBString();
            model.SUPCODE = dr["SUPCODE"].ToDBString();
            model.SUPNAME = dr["SUPNAME"].ToDBString();
            model.BATCHNO = dr["BATCHNO"].ToDBString();
            model.OUTPACKQTY = dr["OUTPACKQTY"].ToDecimal();
            model.INNERPACKQTY = dr["INNERPACKQTY"].ToDecimal();
            model.VOUCHERQTY = dr["VOUCHERQTY"].ToDecimal();
            model.BATCHQTY = dr["BATCHQTY"].ToDecimal();
            model.QTY = dr["QTY"].ToDecimal();
            model.NOPACK = dr["NOPACK"].ToDecimal();
            model.PRINTQTY = dr["PRINTQTY"].ToDecimal();
            model.BARCODE = dr["BARCODE"].ToDBString();
            model.BARCODETYPE = dr["BARCODETYPE"].ToDecimal();
            model.SERIALNO = dr["SERIALNO"].ToDBString();
            model.BARCODENO = dr["BARCODENO"].ToDecimal();
            model.PRDVERSION = dr["PRDVERSION"].ToDBString();
            model.PLATEDGOLD = dr["PLATEDGOLD"].ToDecimal();
            model.PLATEDSILVER = dr["PLATEDSILVER"].ToDecimal();
            model.PLATEDTIN = dr["PLATEDTIN"].ToDecimal();
            model.OTHERS = dr["OTHERS"].ToDecimal();
            model.OPERATOR = dr["OPERATOR"].ToDBString();
            model.OPERATIONDATE = dr["OPERATIONDATE"].ToDateTime();
            model.BARCODEIMG = dr["BARCODEIMG"].ToDBString();
            model.OUTCOUNT = dr["OUTCOUNT"].ToDecimal();
            model.INNERCOUNT = dr["INNERCOUNT"].ToDecimal();
            model.MANTISSAQTY = dr["MANTISSAQTY"].ToDecimal();
            model.ISROHS = dr["ISROHS"].ToDecimal();
            model.OUTBOX_ID = dr["OUTBOX_ID"].ToDecimal();
            model.INNER_ID = dr["INNER_ID"].ToDecimal();
            model.SN = dr["SN"].ToDBString();
            model.TrackNo = dr["TrackNo"].ToDBString();
            model.ReserveNumber = dr["ReserveNumber"].ToDBString();
            model.ReserveRowNo = dr["ReserveRowNo"].ToDBString();
            model.Department = dr["Department"].ToDBString();
            model.Reason = dr["Reason"].ToDBString();
            model.AndalaNo = dr["AndalaNo"].ToDBString();
            model.SHOWSUP = dr["ShowSup"].ToInt32();

            if (Common_Func.readerExists(dr, "StrBarcodeType")) model.StrBarcodeType = dr["StrBarcodeType"].ToDBString();
            if (Common_Func.readerExists(dr, "StrVoucherType")) model.StrVoucherType = dr["StrVoucherType"].ToDBString();
            if (Common_Func.readerExists(dr, "AreaNo")) model.AreaNo = dr["AreaNo"].ToDBString();
            if (Common_Func.readerExists(dr, "HouseNo")) model.HouseNo = dr["HouseNo"].ToDBString();
            if (Common_Func.readerExists(dr, "WarehouseNo")) model.WarehouseNo = dr["WarehouseNo"].ToDBString();
            if (Common_Func.readerExists(dr, "AreaName")) model.AreaName = dr["AreaName"].ToDBString();
            if (Common_Func.readerExists(dr, "HouseName")) model.HouseName = dr["HouseName"].ToDBString();
            if (Common_Func.readerExists(dr, "WarehouseName")) model.WarehouseName = dr["WarehouseName"].ToDBString();
            if (Common_Func.readerExists(dr, "CreateTime")) model.CreateTime = dr["CreateTime"].ToDBString();

            GenerationQRCode genQRCode = new GenerationQRCode();
            model.BARCODEIMG = ConvertImageToString(genQRCode.CreateQRCode(model.BARCODE));

            model.BPlatedGold = model.PLATEDGOLD.ToBoolean();
            model.BPlatedSilver = model.PLATEDSILVER.ToBoolean();
            model.BPlatedTin = model.PLATEDTIN.ToBoolean();
            model.BPlatedOther = model.OTHERS.ToBoolean();
            model.BSHOWSUP = model.SHOWSUP.ToBoolean();

            if (model.BPlatedGold)
            {
                model.Plated = "镀金";
            }
            else if (model.BPlatedSilver)
            {
                model.Plated = "镀银";
            }
            else if (model.BPlatedTin)
            {
                model.Plated = "镀锡";
            }
            else if (model.BPlatedOther)
            {
                model.Plated = "其他";
            }
            else
            {
                model.Plated = string.Empty;
            }

            string[] arr;
            int count;

            arr = new string[2];
            count = Common.Common_Func.SpiltString(model.MATERIALDESC, 25, ref arr);
            if (count <= 1)
            {
                model.MATERIALDESCLINE1 = arr[0].Trim();
                model.MATERIALDESCLINE2 = " ";
            }
            else if (count == 2)
            {
                model.MATERIALDESCLINE1 = arr[0].Trim();
                model.MATERIALDESCLINE2 = arr[1].Trim();
            }
            else
            {
                model.MATERIALDESCLINE1 = arr[0].Trim();
                model.MATERIALDESCLINE2 = arr[1].Trim() + "...";
            }

            arr = new string[2];
            count = Common.Common_Func.SpiltString(model.CUSNAME, 40, ref arr);
            if (count >= 2)
            {
                model.CUSNAME = arr[0].Trim();
            }

            arr = new string[2];
            count = Common.Common_Func.SpiltString(model.SUPNAME, 44, ref arr);
            if (count >= 2)
            {
                model.SUPNAME = arr[0].Trim() + "...";
            }

            return model;
        }

        public bool GetOutbarcodeByID(ref Barcode_Model model, UserInfo user, ref string strError)
        {
            Barcode_Model m = new Barcode_Model();
            try
            {
                using (SqlDataReader dr = _db.GetOutBarcodeListByID(model))
                {
                    if (dr.Read())
                    {
                        m = (GetModelFromDataReader(dr));
                    }
                }

                model = m;
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
            finally
            {
            }
        }

        public int GetPrintedQtyByBarcode(Barcode_Model model)
        {
            string strSql = " Where SERIALNO IS NOT NULL ";
            bool hadWhere = true;

            if (!string.IsNullOrEmpty(model.VOUCHERNO))
            {
                strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                strSql += " VOUCHERNO = '" + model.VOUCHERNO + "' ";
                hadWhere = true;
            }

            if (!string.IsNullOrEmpty(model.DELIVERYNO))
            {
                strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                strSql += " DELIVERYNO = '" + model.DELIVERYNO + "' ";
                hadWhere = true;
            }

            if (!string.IsNullOrEmpty(model.ROWNO))
            {
                strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                strSql += " ROWNO = '" + model.ROWNO + "' ";
                hadWhere = true;
            }

            if (!string.IsNullOrEmpty(model.MATERIALNO))
            {
                strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                strSql += " MATERIALNO = '" + model.MATERIALNO + "' ";
                hadWhere = true;
            }

            return _db.GetPrintedQtyByFilter(model.BARCODETYPE == 20 ? "T_InnerBarcode" : "T_OutBarcode", strSql);
        }


        public bool SaveOutBarcode(ref Barcode_Model model, UserInfo user, ref string strError)
        {
            try
            {
                if (model.ID <= 0)
                {
                    model.OPERATOR = user.UserNo;
                }
                else
                {
                    model.OPERATOR = user.UserNo;
                }

                if (_db.SaveOutBarcde(ref model))
                {
                    return GetOutbarcodeByID(ref model, user, ref strError);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public string TestMaterialOuterLabel(MaterialOuterLabel model, ref string strError)
        {
            try
            {
                return model.barcoderule.BuilderBarcode(model);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return "";
            }
        }

        public string TestMaterialInnerLabel(MaterialInnerLabel model, ref string strError)
        {
            try
            {
                return model.barcoderule.BuilderBarcode(model);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return "";
            }
        }

        public string TestProductLabel(ProductLabel_Model model, ref string strError)
        {
            try
            {
                return model.barcoderule.BuilderBarcode(model);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return "";
            }
        }


        public bool CheckSerialNo(string SerialNo, string BatchNo, ref string strErrMsg)
        {
            try
            {
                return _db.CheckSerialNo(SerialNo, BatchNo, ref strErrMsg);
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
        }

        public bool CreateInnerProductBarcode(ProductLabel_Model labelModel, int qty, ref List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            return _db.CreateInnerProductBarcode(labelModel, qty, ref label_lst, ref strErrMsg);
        }

        public bool CreateOuterProductBarcode(ProductLabel_Model labelModel, int qty, ref List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            return _db.CreateOuterProductBarcode(labelModel, qty, ref label_lst, ref strErrMsg);
        }

        public bool ImportStock(List<BLL.Stock.Stock_Model> dt, ref string strErrMsg)
        {
            return _db.ImportStock(dt, ref strErrMsg);
        }

        public bool RemoveStock(List<BLL.Stock.Stock_Model> dt, ref string strErrMsg)
        {
            return _db.RemoveStock(dt, ref strErrMsg);
        }

        public bool CreateInitialProductBarcode(BLL.Stock.Stock_Model stockmodel, ProductLabel_Model labelModel, int qty, ref List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            return _db.CreateInitialProductBarcode(stockmodel, labelModel, qty, ref label_lst, ref strErrMsg);
        }

        public bool GetplantnoForPrint(string cInvCode, ref string plantno, ref string strErrMsg)
        {
            return _db.GetplantnoForPrint(cInvCode, ref plantno, ref strErrMsg);
        }

        public class ImportPrint_Model
        {
            string _Barcode;

            public string Barcode
            {
                get { return _Barcode; }
                set { _Barcode = value; }
            }
            string _MaterialNo;

            public string MaterialNo
            {
                get { return _MaterialNo; }
                set { _MaterialNo = value; }
            }
            string _MaterialDesc;

            public string MaterialDesc
            {
                get { return _MaterialDesc; }
                set { _MaterialDesc = value; }
            }

            string _MaterialStd;

            public string MaterialStd
            {
                get { return _MaterialStd; }
                set { _MaterialStd = value; }
            }

            string _WarehouseNo;

            public string WarehouseNo
            {
                get { return _WarehouseNo; }
                set { _WarehouseNo = value; }
            }
            string _HouseNo;

            public string HouseNo
            {
                get { return _HouseNo; }
                set { _HouseNo = value; }
            }
            string _AreaNo;

            public string AreaNo
            {
                get { return _AreaNo; }
                set { _AreaNo = value; }
            }
            string _WarehouseName;

            public string WarehouseName
            {
                get { return _WarehouseName; }
                set { _WarehouseName = value; }
            }
            string _HouseName;

            public string HouseName
            {
                get { return _HouseName; }
                set { _HouseName = value; }
            }
            string _AreaName;

            public string AreaName
            {
                get { return _AreaName; }
                set { _AreaName = value; }
            }
            string _SN;

            public string SN
            {
                get { return _SN; }
                set { _SN = value; }
            }
            decimal _ImportQty;

            public decimal ImportQty
            {
                get { return _ImportQty; }
                set { _ImportQty = value; }
            }
            decimal _PrintQty;

            public decimal PrintQty
            {
                get { return _PrintQty; }
                set { _PrintQty = value; }
            }

            string _cvencode;

            public string cvencode
            {
                get { return _cvencode; }
                set { _cvencode = value; }
            }

            string _cvenname;

            public string cvenname
            {
                get { return _cvenname; }
                set { _cvenname = value; }
            }
        }

        public bool GetImportPrintStockByPage(ref List<ImportPrint_Model> modelList, BLL.Stock.Stock_Model model, ref DividPage page, UserInfo user, ref string strError)
        {
            if (page == null) page = new DividPage();
            List<ImportPrint_Model> lstModel = new List<ImportPrint_Model>();
            try
            {
                string strSql = " Where AreaNo is not null ";
                try
                {
                    bool hadWhere = true;

                    if (!string.IsNullOrEmpty(model.AreaNo))
                    {
                        strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                        strSql += " (AreaNo = '" + model.AreaNo + "') ";//" (AreaNo LIKE '%" + model.AreaNo + "%' OR AreaName LIKE '%" + model.AreaNo + "%') ";
                        hadWhere = true;
                    }

                    if (!string.IsNullOrEmpty(model.HouseNo))
                    {
                        strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                        strSql += " (HouseNo = '" + model.HouseNo + "') ";//" (HouseNo LIKE '%" + model.HouseNo + "%' OR HouseName LIKE '%" + model.HouseNo + "%') ";
                        hadWhere = true;
                    }

                    if (!string.IsNullOrEmpty(model.WarehouseNo))
                    {
                        strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                        strSql += " (WarehouseNo = '" + model.WarehouseNo + "') ";//" (WarehouseNo LIKE '%" + model.WarehouseNo + "%' OR WarehouseName LIKE '%" + model.WarehouseNo + "%') ";
                        hadWhere = true;
                    }

                    if (!string.IsNullOrEmpty(model.MaterialNo))
                    {
                        strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                        strSql += " (MaterialNo LIKE '%" + model.MaterialNo + "%' OR MaterialDesc LIKE '%" + model.MaterialNo + "%') ";
                        hadWhere = true;
                    }

                    if (!string.IsNullOrEmpty(model.Barcode))
                    {
                        strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                        strSql += " Barcode Like '%" + model.Barcode + "%' ";
                        hadWhere = true;
                    }

                    if (!string.IsNullOrEmpty(model.SN))
                    {
                        strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                        strSql += " SN LIKE '%" + model.SN + "%' ";
                        hadWhere = true;
                    }
                }
                catch
                {
                }

                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_ImportPrintStock", strSql, "*", "Order By WarehouseNo,HouseNo,AreaNo,MaterialNo"))
                {
                    while (dr.Read())
                    {
                        ImportPrint_Model ipm = new ImportPrint_Model();
                        if (Common_Func.readerExists(dr, "Barcode")) ipm.Barcode = dr["Barcode"].ToDBString();
                        if (Common_Func.readerExists(dr, "MaterialNo")) ipm.MaterialNo = dr["MaterialNo"].ToDBString();
                        if (Common_Func.readerExists(dr, "MaterialDesc")) ipm.MaterialDesc = dr["MaterialDesc"].ToDBString();
                        if (Common_Func.readerExists(dr, "MaterialStd")) ipm.MaterialStd = dr["MaterialStd"].ToDBString();
                        if (Common_Func.readerExists(dr, "WarehouseNo")) ipm.WarehouseNo = dr["WarehouseNo"].ToDBString();
                        if (Common_Func.readerExists(dr, "HouseNo")) ipm.HouseNo = dr["HouseNo"].ToDBString();
                        if (Common_Func.readerExists(dr, "AreaNo")) ipm.AreaNo = dr["AreaNo"].ToDBString();
                        if (Common_Func.readerExists(dr, "import_qty")) ipm.ImportQty = dr["import_qty"].ToDecimal();
                        if (Common_Func.readerExists(dr, "print_qty")) ipm.PrintQty = dr["print_qty"].ToDecimal();
                        if (Common_Func.readerExists(dr, "WarehouseName")) ipm.WarehouseName = dr["WarehouseName"].ToDBString();
                        if (Common_Func.readerExists(dr, "HouseName")) ipm.HouseName = dr["HouseName"].ToDBString();
                        if (Common_Func.readerExists(dr, "AreaName")) ipm.AreaName = dr["AreaName"].ToDBString();
                        if (Common_Func.readerExists(dr, "SN")) ipm.SN = dr["SN"].ToDBString();
                        lstModel.Add(ipm);
                    }
                }

                modelList = lstModel;
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
            finally
            {
            }
        }

        public bool RePrintByBarcode(bool isBunding, string serialno, int qty, ref List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            return _db.RePrintByBarcode(isBunding, serialno, qty, ref label_lst, ref strErrMsg);
        }

        public bool RePrintChangeSave(List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            return _db.RePrintChangeSave(label_lst, ref strErrMsg);
        }

        public bool PrintDelete(List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            return _db.PrintDelete(label_lst, ref strErrMsg);
        }
        public bool CreateInnerProductBarcodeForRead(ProductLabel_Model labelModel, int qty, ref List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            string BatchNo = labelModel.printdate + labelModel.plantno;
            label_lst = new List<ProductLabel_Model>();
            for (int i = 0; i < qty; i++)
            {
                ProductLabel_Model detail = new ProductLabel_Model();
                detail.prdversion = labelModel.prdversion;
                detail.iMoSeq = labelModel.iMoSeq;
                detail.IsOuter = "W";
                detail.labeltype = labelModel.labeltype;
                detail.POCode = labelModel.POCode;
                detail.ordercode = labelModel.ordercode;
                if (labelModel.outpackqty.Equals("1") || labelModel.outpackqty.Equals("0001"))
                {
                    detail.outpackqty = "";
                }
                else
                {
                    detail.outpackqty = labelModel.outpackqty;
                }

                detail.materialno = labelModel.materialno;
                detail.materialdesc = labelModel.materialdesc;
                detail.invstd = labelModel.invstd;
                detail.CUName = labelModel.CUName;
                detail.Remark = labelModel.Remark;
                detail.printdate = labelModel.printdate;
                detail.plantno = labelModel.plantno;
                detail.packno = (Convert.ToInt16(labelModel.packno) + i).ToString().PadLeft(4, '0');
                detail.BarcodeExpress = labelModel.printdate + labelModel.plantno + detail.packno;
                detail.barcode = labelModel.labeltype + "@" + labelModel.materialno + "@" + labelModel.ordercode + "@" + labelModel.POCode + "@" + Convert.ToInt16(labelModel.outpackqty).ToString().PadLeft(4, '0') + "@" + detail.BarcodeExpress;
                label_lst.Add(detail);
            }
            return true;
        }

        public bool SaveInnerProductBarcodeForRead(List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            return _db.SaveInnerProductBarcodeForRead(label_lst, ref strErrMsg);
        }

        public bool CreateeOuterProductBarcodeForRead(ProductLabel_Model labelModel, int qty, ref List<ProductLabel_Model> label_inner, ref List<ProductLabel_Model> label_outer, ref string strErrMsg)
        {
            return _db.CreateeOuterProductBarcodeForRead(labelModel, qty, ref label_inner, ref label_outer, ref strErrMsg);
        }

        public bool SaveOuterProductBarcodeForRead(List<ProductLabel_Model> label_inner, List<ProductLabel_Model> label_outer, ref string strErrMsg)
        {
            return _db.SaveOuterProductBarcodeForRead(label_inner, label_outer, ref strErrMsg);
        }

        public bool NewCheckSerialNo(string SerialNo, int qty, string BatchNo, ref string strErrMsg)
        {
            try
            {
                return _db.NewCheckSerialNo(SerialNo, qty, BatchNo, ref strErrMsg);
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
        }

        public bool QueryPrintSerialNo(string BatchNo, ref List<string> querylist, ref string strErrMsg)
        {
            return _db.QueryPrintSerialNo(BatchNo, ref querylist, ref strErrMsg);
        }

        public string ResetBarCode(string strArraySerialNo, string strUserJson)
        {
            string strErrMsg = string.Empty;

            #region MyRegion

            try
            {
                UserInfo userModel = JSONUtil.JSONHelper.JsonToObject<UserInfo>(strUserJson);

                if (userModel == null || string.IsNullOrEmpty(userModel.UserNo))
                {
                    return "E:没有获取用户信息！";
                }

                bool res = _db.ResetBarCode(strArraySerialNo, userModel, ref strErrMsg);
                if (res)
                    return "S";
                else
                    return "E:" + strErrMsg;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return "E:" + strErrMsg;
            }
            #endregion
        }

        public bool GetPrintedProductCount(string MoCode, string rowno, ref int qty, ref string strErrMsg)
        {
            return _db.GetPrintedProductCount(MoCode, rowno, ref qty, ref strErrMsg);
        }

        public bool QueryBarcodeDetailsReport(string barcode, string voucherno, string rowno, string Socode, string Covenantcode, string materialno, string materialdesc, string materialstd, out List<BarcodeReport_Model> lst, out string strErrMsg)
        {
            return _db.QueryBarcodeDetailsReport(barcode, voucherno, rowno, Socode, Covenantcode, materialno, materialdesc, materialstd, out lst, out strErrMsg);
        }

        public bool QueryBarcodeDetailsReportRowDetail(BarcodeReport_Model row, out List<BarcodeReport_RowDetail> lst, out string strErrMsg)
        {
            return _db.QueryBarcodeDetailsReportRowDetail(row, out lst, out strErrMsg);
        }

        public bool CreateAutomaticProductBarcode(ProductLabel_Model labelModel, ref string strErrMsg)
        {
            return _db.CreateAutomaticProductBarcode(labelModel, ref strErrMsg);
        }

        public bool QueryBarcodeTraceReport(string barcode, string voucherno, string CusName, string Socode, string Covenantcode, string materialno, string materialdesc, string materialstd, string StockOutCode, string TransMoveCode, out List<BarcodeTrace_Model> lst, out string strErrMsg)
        {
            return _db.QueryBarcodeTraceReport(barcode, voucherno, CusName, Socode, Covenantcode, materialno, materialdesc, materialstd, StockOutCode, TransMoveCode, out lst, out strErrMsg);
        }

        public bool QueryBarcodeTraceReportRowDetail(BarcodeTrace_Model row, out List<BarcodeReport_RowDetail> lst, out string strErrMsg)
        {
            return _db.QueryBarcodeTraceReportRowDetail(row, out lst, out strErrMsg);
        }

        public bool GetAutomaticProductByBarcode(string serialno, ref ProductLabel_Model labelModel, ref string strErrMsg)
        {
            return _db.GetAutomaticProductByBarcode(serialno, ref labelModel, ref strErrMsg);
        }

        public List<MaterialLabel_Model> GetPULstForPrint(string cpoid, string cvenabbname, string begindate, string enddate, ref string strErrMsg)
        {
            return _db.GetPULstForPrint(cpoid, cvenabbname, begindate, enddate, ref strErrMsg);
        }

        public Vendor VendorLogin(string cvencode)
        {
            return _db.VendorLogin(cvencode);
        }

        public bool VendorChangePW(string cvencode, string password)
        {
            return _db.VendorChangePW(cvencode, password);
        }

        public List<MaterialLabel_Model> VenGetPULstForPrint(string cvencode, string cpoid, ref string strErrMsg)
        {
            return _db.VenGetPULstForPrint(cvencode, cpoid, ref strErrMsg);
        }

        public bool CreateMaterialBarcodeForPU(MaterialLabel_Model labelModel, int qty, string PackQty, string EndPackQty, ref List<MaterialLabel_Model> label_lst, ref string strErrMsg)
        {
            return _db.CreateMaterialBarcodeForPU(labelModel, qty, PackQty, EndPackQty, ref label_lst, ref strErrMsg);
        }

        public bool VenQueryPrintLst(string cvencode, string cpoid, string rowno, string materialno, string materialdesc, string invstd, string BarcodeExpress, ref  List<MaterialLabel_Model> list, ref string strErrMsg)
        {
            return _db.VenQueryPrintLst(cvencode, cpoid, rowno, materialno, materialdesc, invstd, BarcodeExpress, ref list, ref strErrMsg);
        }

        public bool VenQueryPrintDetails(MaterialLabel_Model model, ref  List<MaterialLabel_Model> list, ref string strErrMsg)
        {
            return _db.VenQueryPrintDetails(model, ref list, ref strErrMsg);
        }

        public bool GetImportMaterialStockByPage(ref List<ImportPrint_Model> modelList, BLL.Stock.Stock_Model model, ref DividPage page, UserInfo user, ref string strError)
        {
            if (page == null) page = new DividPage();
            List<ImportPrint_Model> lstModel = new List<ImportPrint_Model>();
            try
            {
                string strSql = " Where AreaNo is not null ";
                try
                {
                    bool hadWhere = true;

                    if (!string.IsNullOrEmpty(model.AreaNo))
                    {
                        strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                        strSql += " (AreaNo = '" + model.AreaNo + "') ";//" (AreaNo LIKE '%" + model.AreaNo + "%' OR AreaName LIKE '%" + model.AreaNo + "%') ";
                        hadWhere = true;
                    }

                    if (!string.IsNullOrEmpty(model.HouseNo))
                    {
                        strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                        strSql += " (HouseNo = '" + model.HouseNo + "') ";//" (HouseNo LIKE '%" + model.HouseNo + "%' OR HouseName LIKE '%" + model.HouseNo + "%') ";
                        hadWhere = true;
                    }

                    if (!string.IsNullOrEmpty(model.WarehouseNo))
                    {
                        strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                        strSql += " (WarehouseNo = '" + model.WarehouseNo + "') ";//" (WarehouseNo LIKE '%" + model.WarehouseNo + "%' OR WarehouseName LIKE '%" + model.WarehouseNo + "%') ";
                        hadWhere = true;
                    }

                    if (!string.IsNullOrEmpty(model.MaterialNo))
                    {
                        strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                        strSql += " (MaterialNo LIKE '%" + model.MaterialNo + "%' OR MaterialDesc LIKE '%" + model.MaterialNo + "%') ";
                        hadWhere = true;
                    }

                    if (!string.IsNullOrEmpty(model.Barcode))
                    {
                        strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                        strSql += " Barcode Like '%" + model.Barcode + "%' ";
                        hadWhere = true;
                    }

                    if (!string.IsNullOrEmpty(model.SN))
                    {
                        strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                        strSql += " SN LIKE '%" + model.SN + "%' ";
                        hadWhere = true;
                    }
                }
                catch
                {
                }

                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_ImportMaterialStock", strSql, "*", "Order By WarehouseNo,HouseNo,AreaNo,MaterialNo"))
                {
                    while (dr.Read())
                    {
                        ImportPrint_Model ipm = new ImportPrint_Model();
                        if (Common_Func.readerExists(dr, "Barcode")) ipm.Barcode = dr["Barcode"].ToDBString();
                        if (Common_Func.readerExists(dr, "MaterialNo")) ipm.MaterialNo = dr["MaterialNo"].ToDBString();
                        if (Common_Func.readerExists(dr, "MaterialDesc")) ipm.MaterialDesc = dr["MaterialDesc"].ToDBString();
                        if (Common_Func.readerExists(dr, "MaterialStd")) ipm.MaterialStd = dr["MaterialStd"].ToDBString();
                        if (Common_Func.readerExists(dr, "WarehouseNo")) ipm.WarehouseNo = dr["WarehouseNo"].ToDBString();
                        if (Common_Func.readerExists(dr, "HouseNo")) ipm.HouseNo = dr["HouseNo"].ToDBString();
                        if (Common_Func.readerExists(dr, "AreaNo")) ipm.AreaNo = dr["AreaNo"].ToDBString();
                        if (Common_Func.readerExists(dr, "import_qty")) ipm.ImportQty = dr["import_qty"].ToDecimal();
                        if (Common_Func.readerExists(dr, "print_qty")) ipm.PrintQty = dr["print_qty"].ToDecimal();
                        if (Common_Func.readerExists(dr, "WarehouseName")) ipm.WarehouseName = dr["WarehouseName"].ToDBString();
                        if (Common_Func.readerExists(dr, "HouseName")) ipm.HouseName = dr["HouseName"].ToDBString();
                        if (Common_Func.readerExists(dr, "AreaName")) ipm.AreaName = dr["AreaName"].ToDBString();
                        if (Common_Func.readerExists(dr, "SN")) ipm.SN = dr["SN"].ToDBString();
                        if (Common_Func.readerExists(dr, "cvencode")) ipm.cvencode = dr["cvencode"].ToDBString();
                        if (Common_Func.readerExists(dr, "cvenname")) ipm.cvenname = dr["cvenname"].ToDBString();
                        lstModel.Add(ipm);
                    }
                }

                modelList = lstModel;
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
            finally
            {
            }
        }

        public bool ImportMaterialStock(List<Stock_Model> dt, ref string strErrMsg)
        {
            return _db.ImportMaterialStock(dt, ref strErrMsg);
        }

        public bool CreateInitialMaterialBarcode(Stock_Model stockmodel, MaterialLabel_Model labelModel, int qty, ref List<MaterialLabel_Model> label_lst, ref string strErrMsg)
        {
            return _db.CreateInitialMaterialBarcode(stockmodel, labelModel, qty, ref label_lst, ref strErrMsg);
        }

        public List<MaterialLabel_Model> GetOMLstForPrint(string ccode, string cvenabbname, string begindate, string enddate, ref string strErrMsg)
        {
            return _db.GetOMLstForPrint(ccode, cvenabbname, begindate, enddate, ref strErrMsg);
        }

        public bool CreateMaterialBarcodeForOM(MaterialLabel_Model labelModel, int qty, string PackQty, string EndPackQty, ref List<MaterialLabel_Model> label_lst, ref string strErrMsg)
        {
            return _db.CreateMaterialBarcodeForOM(labelModel, qty, PackQty, EndPackQty, ref label_lst, ref strErrMsg);
        }

        public bool GetMaterialLabelInfo(string cinvcode, string cinvname, string cinvstd, ref MaterialLabel_Model model, ref string strErrMsg)
        {
            return _db.GetMaterialLabelInfo(cinvcode, cinvname, cinvstd, ref model, ref strErrMsg);
        }

        public bool CreateMaterialBarcodeForNull(MaterialLabel_Model labelModel, Stock_Model stmodel, int qty, string PackQty, string EndPackQty, ref List<MaterialLabel_Model> label_lst, ref string strErrMsg)
        {
            return _db.CreateMaterialBarcodeForNull(labelModel, stmodel, qty, PackQty, EndPackQty, ref label_lst, ref strErrMsg);
        }

        public bool CheckbProxyWhBycWhCode(string cWhCode, ref string strErrMsg)
        {
            return _db.CheckbProxyWhBycWhCode(cWhCode, ref strErrMsg);
        }

        public bool GetVendorByCode(string cvencode, ref Vendor vendor, ref string strErrMsg)
        {
            return _db.GetVendorByCode(cvencode, ref vendor, ref strErrMsg);
        }

        public bool QueryMaterialBarcodeReport(string barcode, string voucherno, string ArrivalCode, string InCode, string OutCode, string materialno, string materialdesc, string materialstd, out List<BarcodeReport_Model> lst, out string strErrMsg)
        {
            return _db.QueryMaterialBarcodeReport(barcode, voucherno, ArrivalCode, InCode, OutCode, materialno, materialdesc, materialstd, out lst, out strErrMsg);
        }

        public bool QueryMaterialBarcodeReportRowDetail(BarcodeReport_Model row, out List<BarcodeReport_RowDetail> lst, out string strErrMsg)
        {
            return _db.QueryMaterialBarcodeReportRowDetail(row, out lst, out strErrMsg);
        }
    }
}
