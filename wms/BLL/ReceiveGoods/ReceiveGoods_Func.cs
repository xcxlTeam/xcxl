using BLL.Basic.User;
using BLL.DeliveryReceive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.PrintBarcode;
using BLL.TOOL;
using BLL.Common;
using System.Data.SqlClient;

namespace BLL.ReceiveGoods
{
    public class ReceiveGoods_Func
    {
        public string GetBarCodeInfo(string strBarCode)
        {
            Barcode_Model barcodeMdl = new Barcode_Model();
            try
            {
                string strSerialNo = string.Empty;

                if (MaterialBarcodeDecode.InvalidBarcode(strBarCode) == false)
                {
                    if (strBarCode.ToLower().StartsWith("http"))
                    {
                        strSerialNo = strBarCode.Substring(strBarCode.LastIndexOf("?") + 4);
                    }
                    else
                        strSerialNo = strBarCode;
                    barcodeMdl.Status = "S";
                }
                else
                {
                    if (MaterialBarcodeDecode.GetBarcodeType(strBarCode).EndsWith("1") || MaterialBarcodeDecode.GetBarcodeType(strBarCode).EndsWith("5")|| MaterialBarcodeDecode.GetBarcodeType(strBarCode).StartsWith("0"))
                    {
                        barcodeMdl.Status = "S";
                        strSerialNo = MaterialBarcodeDecode.GetSerialNo(strBarCode);
                    }
                    else
                    {
                        barcodeMdl.Status = "E";
                        barcodeMdl.Message = "您扫描的不是外箱条码，请确认！";
                    }
                }

                if (barcodeMdl.Status == "E")
                {
                    return JSONUtil.JSONHelper.ObjectToJson<Barcode_Model>(barcodeMdl);
                }

                ReceiveGoods_DB RGD = new ReceiveGoods_DB();

                barcodeMdl = RGD.GetBarCodeInfo(strSerialNo);

                if (barcodeMdl == null || string.IsNullOrEmpty(barcodeMdl.SERIALNO))
                {
                    barcodeMdl.Status = "E";
                    barcodeMdl.Message = "您扫描的条码不存在，请确认！";
                    return JSONUtil.JSONHelper.ObjectToJson<Barcode_Model>(barcodeMdl);
                }
                string strErrorMsg = "";
                if (RGD.IsChecking(barcodeMdl, ref strErrorMsg))
                {
                    barcodeMdl.Status = "E";
                    barcodeMdl.Message = strErrorMsg;
                    return JSONUtil.JSONHelper.ObjectToJson<Barcode_Model>(barcodeMdl);
                }

                barcodeMdl.Status = "S";
                return JSONUtil.JSONHelper.ObjectToJson<Barcode_Model>(barcodeMdl);
            }
            catch (Exception ex)
            {
                barcodeMdl.Status = "E";
                barcodeMdl.Message = "Web异常：" + ex.Message + ex.StackTrace;
                return JSONUtil.JSONHelper.ObjectToJson<Barcode_Model>(barcodeMdl);
            }
        }

        public string GetBarCodeInfoForRefuseArrival(string strBarCode)
        {
            Barcode_Model barcodeMdl = new Barcode_Model();
            try
            {
                string strSerialNo = string.Empty;

                if (MaterialBarcodeDecode.InvalidBarcode(strBarCode) == false)
                {
                    if (strBarCode.ToLower().StartsWith("http"))
                    {
                        strSerialNo = strBarCode.Substring(strBarCode.LastIndexOf("?") + 4);
                    }
                    else
                        strSerialNo = strBarCode;
                    barcodeMdl.Status = "S";
                }
                else
                {
                    if (MaterialBarcodeDecode.GetBarcodeType(strBarCode).EndsWith("1") || MaterialBarcodeDecode.GetBarcodeType(strBarCode).EndsWith("5") || MaterialBarcodeDecode.GetBarcodeType(strBarCode).StartsWith("0"))
                    {
                        barcodeMdl.Status = "S";
                        strSerialNo = MaterialBarcodeDecode.GetSerialNo(strBarCode);
                    }
                    else
                    {
                        barcodeMdl.Status = "E";
                        barcodeMdl.Message = "您扫描的不是外箱条码，请确认！";
                    }
                }

                if (barcodeMdl.Status == "E")
                {
                    return JSONUtil.JSONHelper.ObjectToJson<Barcode_Model>(barcodeMdl);
                }

                ReceiveGoods_DB RGD = new ReceiveGoods_DB();

                barcodeMdl = RGD.GetBarCodeInfo(strSerialNo);

                if (barcodeMdl == null || string.IsNullOrEmpty(barcodeMdl.SERIALNO))
                {
                    barcodeMdl.Status = "E";
                    barcodeMdl.Message = "您扫描的条码不存在，请确认！";
                    return JSONUtil.JSONHelper.ObjectToJson<Barcode_Model>(barcodeMdl);
                }
                string strErrorMsg = "";
                if (RGD.IsChecking(barcodeMdl, ref strErrorMsg))
                {
                    barcodeMdl.Status = "E";
                    barcodeMdl.Message = strErrorMsg;
                    return JSONUtil.JSONHelper.ObjectToJson<Barcode_Model>(barcodeMdl);
                }

                barcodeMdl.ArrivalRowNo = RGD.GetArrivalRowNo(barcodeMdl);

                barcodeMdl.Status = "S";
                return JSONUtil.JSONHelper.ObjectToJson<Barcode_Model>(barcodeMdl);
            }
            catch (Exception ex)
            {
                barcodeMdl.Status = "E";
                barcodeMdl.Message = "Web异常：" + ex.Message + ex.StackTrace;
                return JSONUtil.JSONHelper.ObjectToJson<Barcode_Model>(barcodeMdl);
            }
        }

        public bool GetBarCodeInfoForQueryStock(string strBarCode, ref Barcode_Model Barcode_Model)
        {

            try
            {
                string strSerialNo = string.Empty;

                if (MaterialBarcodeDecode.InvalidBarcode(strBarCode) == false)
                {
                    strSerialNo = strBarCode;
                }
                else
                {
                    strSerialNo = MaterialBarcodeDecode.GetSerialNo(strBarCode);
                }

                ReceiveGoods_DB RGD = new ReceiveGoods_DB();

                Barcode_Model = RGD.GetBarCodeInfo(strSerialNo);

                if (Barcode_Model == null || string.IsNullOrEmpty(Barcode_Model.SERIALNO))
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 收货过账,送货单，生产退料
        /// </summary>
        /// <param name="userModel"></param>
        /// <param name="strErrMsg"></param>
        /// <returns></returns>
        public string PostReceiveGoodsInfo(string strReceiveJson, string strUserJson)
        {
            bool bSucc = false;
            string strErrMsg = string.Empty;
            string strPostAndTask = string.Empty;
            DeliveryReceive_Model DeliveryInfo = new DeliveryReceive_Model();
            DeliveryReceive_DB DRD = new DeliveryReceive_DB();

            try
            {
                if (string.IsNullOrEmpty(strReceiveJson))
                {
                    return GetReturnJson(false, DeliveryInfo, "没有过账数据！");
                }

                DeliveryInfo = JSONUtil.JSONHelper.JsonToObject<DeliveryReceive_Model>(strReceiveJson);
                //TODO:测试代码
                //DeliveryInfo.lstDeliveryDetail.ForEach(t => t.ReceiveQty = 20);

                if (DeliveryInfo == null || DeliveryInfo.lstDeliveryDetail == null || DeliveryInfo.lstDeliveryDetail.Count <= 0)
                {
                    return GetReturnJson(false, DeliveryInfo, "解析客户端数据出错！");
                }

                if (DeliveryInfo.lstDeliveryDetail.Where(t => t.ReceiveQty > 0).Count() == 0)
                {
                    return GetReturnJson(false, DeliveryInfo, "收货数量都为零，请确认！");
                }

                UserInfo userModel = JSONUtil.JSONHelper.JsonToObject<UserInfo>(strUserJson);

                if (userModel == null || string.IsNullOrEmpty(userModel.UserNo))
                {
                    return GetReturnJson(false, DeliveryInfo, "没有获取用户信息！");
                }


                //送货单或退料单，只能收货一次
                if (DeliveryInfo.VoucherType == 10 || DeliveryInfo.VoucherType == 30)
                {
                    if (DRD.CheckDeliveryNoIsExist(DeliveryInfo.DeliveryNo) >= 1)
                    {
                        return GetReturnJson(false, DeliveryInfo, "该单据已收货，单据号：" + DeliveryInfo.DeliveryNo);
                    }
                }
                TOOL.WriteLogMethod.WriteLog("方法：PostReceiveGoodsInfo---操作人：" + userModel.UserName + strReceiveJson);
                Receive_Post RPT = Receive_Factory.CreateFactoty(DeliveryInfo.VoucherType);
                bSucc = RPT.ReceiveInfoPostToSAP(ref DeliveryInfo, userModel, ref strErrMsg);

                if (bSucc == false)
                {
                    return GetReturnJson(false, DeliveryInfo, strErrMsg);
                }

                //创建上架任务
                bSucc = RPT.CreateReceiveAndShelveTask(ref DeliveryInfo, userModel, ref strErrMsg);

                return GetReturnJson(bSucc, DeliveryInfo, RPT.CreateMessage(DeliveryInfo, bSucc, strErrMsg));

            }
            catch (Exception ex)
            {
                return GetReturnJson(false, DeliveryInfo, "Web异常：" + ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// 获取检验通知书表头数据
        /// </summary>
        /// <param name="strErrMsg"></param>
        /// <returns></returns>
        public bool GetQualityListByPage(ref List<DeliveryReceive_Model> modelList, DeliveryReceive_Model model, ref DividPage page, UserInfo user, ref string strError)
        {
            if (page == null) page = new DividPage();
            List<DeliveryReceive_Model> lstModel = new List<DeliveryReceive_Model>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_GETQUALITYINFO", GetFilterSql(model, user)))
                {
                    while (dr.Read())
                    {
                        lstModel.Add(GetDeliveryReceive_ModelFromDataReader(dr));
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

        private string GetFilterSql(DeliveryReceive_Model model, UserInfo user)
        {
            try
            {
                string strSql = "";
                bool hadWhere = false;


                if (!string.IsNullOrEmpty(model.MaterialDoc))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " MaterialDoc Like '%" + model.MaterialDoc + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.VoucherNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " VoucherNo Like '%" + model.VoucherNo + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.DeliveryNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " DeliveryNo Like '%" + model.DeliveryNo + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.MaterialNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (ID || ',' || VOUCHERNO) In (Select (Receive_ID || ',' || VoucherNo) From V_GETQUALITYDETAILINFO Where MaterialNo LIKE '%" + model.MaterialNo + "%' OR MaterialDesc Like '%" + model.MaterialNo + "%') ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.SupCode))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (SupplierNo Like '%" + model.SupCode + "%' OR SupplierName Like '%" + model.SupCode + "%') ";
                    hadWhere = true;
                }

                if (model.StartTime != null)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " postdate >= " + model.StartTime.ToDateTime().Date.ToSqlTimeString();
                    hadWhere = true;
                }

                if (model.EndTime != null)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " postdate <= " + model.EndTime.ToDateTime().AddDays(1).Date.ToSqlTimeString();
                    hadWhere = true;
                }

                return strSql;
            }
            catch
            {
                return string.Empty;
            }
        }

        private DeliveryReceive_Model GetDeliveryReceive_ModelFromDataReader(SqlDataReader dr)
        {
            DeliveryReceive_Model model = new DeliveryReceive_Model();
            model.ID = dr["ID"].ToInt32();
            model.CreateDate = dr["createdate"].ToDateTime();
            model.DocDate = dr["PostDate"].ToDateTime();
            model.PostDate = dr["PostDate"].ToDateTime();
            model.VoucherNo = dr["VoucherNo"].ToDBString();
            model.DeliveryNo = dr["DeliveryNo"].ToDBString();
            model.SupCode = dr["SupplierNo"].ToDBString();
            model.SupName = dr["SupplierName"].ToDBString();
            model.Plant = dr["Plant"].ToDBString();
            model.MoveType = dr["MoveType"].ToDBString();
            model.MaterialDoc = dr["MaterialDoc"].ToDBString();
            model.PrintedQty = dr["PrintedQty"].ToInt32();
            model.PrintTime = dr["PrintTime"].ToDateTimeNull();

            model.Barcode = Common_Func.StrToCode128B(model.MaterialDoc);

            return model;
        }

        /// <summary>
        /// 获取检验通知书表体数据
        /// </summary>
        /// <param name="DeliveryInfo"></param>
        /// <param name="strErrMsg"></param>
        /// <returns></returns>
        public bool GetQualityDetailInfo(DeliveryReceive_Model DeliveryInfo, ref List<DeliveryReceiveDetail_Model> lstDeliveryDetailInfo, UserInfo userModel, ref string strErrMsg)
        {
            try
            {
                ReceiveGoods_DB RGD = new ReceiveGoods_DB();
                lstDeliveryDetailInfo = RGD.GetQualityDetailInfo(DeliveryInfo);
                if (lstDeliveryDetailInfo == null || lstDeliveryDetailInfo.Count == 0)
                {
                    strErrMsg = "没有获取到质检数据！";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = "Web异常：" + ex.Message;
                return false;
            }
        }

        public bool GetQualityDetailListByPage(ref List<DeliveryReceiveDetail_Model> modelList, DeliveryReceiveDetail_Model model, ref DividPage page, UserInfo user, ref string strError)
        {
            if (page == null) page = new DividPage();
            List<DeliveryReceiveDetail_Model> lstModel = new List<DeliveryReceiveDetail_Model>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_GETQUALITYDETAILINFO", GetFilterSql(model, user), "*", "Order By rowno Asc"))
                {
                    while (dr.Read())
                    {
                        lstModel.Add(GetDeliveryReceiveDetail_ModelFromDataReader(dr));
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

        private string GetFilterSql(DeliveryReceiveDetail_Model model, UserInfo user)
        {
            try
            {
                string strSql = "";
                bool hadWhere = false;

                if (model.ID >= 1)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " receive_id = " + model.ID + " ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.VoucherNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " VoucherNo = '" + model.VoucherNo + "' ";
                    hadWhere = true;
                }

                return strSql;
            }
            catch
            {
                return string.Empty;
            }
        }

        private DeliveryReceiveDetail_Model GetDeliveryReceiveDetail_ModelFromDataReader(SqlDataReader dr)
        {
            DeliveryReceiveDetail_Model model = new DeliveryReceiveDetail_Model();
            model.ID = dr["ID"].ToInt32();
            model.RowNo = dr["RowNo"].ToDBString();
            model.MaterialNo = dr["MaterialNo"].ToDBString();
            model.MaterialDesc = dr["MaterialDesc"].ToDBString();
            model.ReceiveQty = dr["ReceiveQty"].ToDecimal();
            model.Unit = dr["Unit"].ToDBString();
            model.PrdVersion = dr["PrdVersion"].ToDBString();
            model.QualityQty = dr["QualityQty"].ToDecimal();
            model.UnQualityQty = dr["UnQualityQty"].ToDecimal();
            model.VoucherNo = dr["VoucherNo"].ToDBString();
            model.QualityType = string.Empty;

            return model;
        }

        public bool SaveQualityDetailInfo(DeliveryReceive_Model DeliveryModel, UserInfo userModel, ref string strErrMsg)
        {
            try
            {

                if (DeliveryModel.lstDeliveryDetail == null || DeliveryModel.lstDeliveryDetail.Count == 0)
                {
                    strErrMsg = "没有质检数据！";
                    return false;
                }

                if (DeliveryModel.lstDeliveryDetail.Where(t => t.OKSelect == true).Count() == 0)
                {
                    strErrMsg = "请选中质检行！";
                    return false;
                }

                if (DeliveryModel.lstDeliveryDetail.Where(t => t.CurrentQualityQty > 0 || t.CurrentUnQualityQty > 0).Count() == 0)
                {
                    strErrMsg = "合格数量和不合格数量都为零，不能保存！";
                    return false;
                }

                if (CheckQualityQty(DeliveryModel.lstDeliveryDetail.Where(t => t.CurrentQualityQty > 0 || t.CurrentUnQualityQty > 0).ToList(), ref strErrMsg) == false)
                {
                    return false;
                }
                DeliveryModel.lstDeliveryDetail = DeliveryModel.lstDeliveryDetail.Where(t => t.OKSelect == true).ToList();
                string strDeliveryDetailXml = XMLUtil.XmlUtil.Serializer(typeof(DeliveryReceive_Model), DeliveryModel);
                TOOL.WriteLogMethod.WriteLog("方法：SaveQualityDetailInfo" + strDeliveryDetailXml);
                ReceiveGoods_DB RGD = new ReceiveGoods_DB();

                return RGD.SaveQualityDetailInfo(strDeliveryDetailXml, userModel, ref strErrMsg);

            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
        }

        private bool CheckQualityQty(List<DeliveryReceiveDetail_Model> lstDeliveryDetail, ref string strErrMsg)
        {
            bool bSucc = true;

            decimal? dCurrentUnQualityQty = 0;
            decimal? dCurrentQualityQty = 0;

            foreach (var item in lstDeliveryDetail)
            {
                if (item.OKSelect == true)
                {
                    dCurrentQualityQty = item.CurrentQualityQty == null ? 0 : item.CurrentQualityQty;
                    dCurrentUnQualityQty = item.CurrentUnQualityQty == null ? 0 : item.CurrentUnQualityQty;

                    if ((dCurrentQualityQty + dCurrentUnQualityQty + item.QualityQty + item.UnQualityQty) > item.ReceiveQty)
                    {
                        strErrMsg = "物料：" + item.MaterialNo + "行号：" + item.RowNo + "质检数量超出送检数量，请确认！";
                        bSucc = false;
                        break;
                    }

                    if (dCurrentUnQualityQty > 0 && (string.IsNullOrEmpty(item.QualityType) || item.QualityType == "0"))
                    {
                        strErrMsg = "物料：" + item.MaterialNo + "行号：" + item.RowNo + "录入不合格数量，请选择缺陷等级！";
                        bSucc = false;
                        break;
                    }

                    //if (dCurrentUnQualityQty <= 0 && !string.IsNullOrEmpty(item.QualityType) && item.QualityType != "0")
                    //{
                    //    strErrMsg = "物料：" + item.MaterialNo + "行号：" + item.RowNo + "未录入不合格数量，请取消选择缺陷等级！";
                    //    bSucc = false;
                    //    break;
                    //}
                }

            }
            return bSucc;
        }

        private string GetReturnJson(bool bSucc, DeliveryReceive_Model DeliveryInfo, string strErrMsg)
        {
            DeliveryInfo.Status = bSucc == true ? "S" : "E";
            DeliveryInfo.Message = strErrMsg;
            return JSONUtil.JSONHelper.ObjectToJson<DeliveryReceive_Model>(DeliveryInfo);
        }

        public bool PrintQuality(DeliveryReceive_Model deliveryMdl, UserInfo userModel, ref string strErrMsg)
        {
            ReceiveGoods_DB RGD = new ReceiveGoods_DB();
            if (!RGD.PrintQuality(deliveryMdl, userModel, ref strErrMsg))
            {
                strErrMsg = "更新打印次数失败!" + strErrMsg;
                return false;
            }

            return true;
        }


    }
}
