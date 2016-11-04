using BLL.Basic.User;
using BLL.Common;
using BLL.TOOL;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using BLL.PrintBarcode;

namespace BLL.Stock
{
    public class Stock_Func
    {
        public string GetStockInfoByMaterialNo(string strBarcodeOrMaterialNo, string strUserJson)
        {
            StockHead_Model stockHeadModel = new StockHead_Model();
            try
            {
                bool bSucc = false;

                if (string.IsNullOrEmpty(strBarcodeOrMaterialNo))
                {
                    stockHeadModel.Status = "E";
                    stockHeadModel.Message = "请先扫描条码或输入物料编号！";
                    return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
                }

                UserInfo userModel = JSONUtil.JSONHelper.JsonToObject<UserInfo>(strUserJson);
                if (userModel == null || string.IsNullOrEmpty(userModel.UserNo))
                {
                    stockHeadModel.Status = "E";
                    stockHeadModel.Message = "没有获取用户信息！";
                    return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
                }

                Barcode_Model Barcode_Model = new Barcode_Model();
                ReceiveGoods.ReceiveGoods_Func RGF = new ReceiveGoods.ReceiveGoods_Func();
                bSucc = RGF.GetBarCodeInfoForQueryStock(strBarcodeOrMaterialNo, ref Barcode_Model);

                if (bSucc == true)
                {
                    stockHeadModel.lstStockInfo = GetStockByMaterialNo(Barcode_Model.MATERIALNO);
                }
                else
                {
                    stockHeadModel.lstStockInfo = GetStockByMaterialNo(strBarcodeOrMaterialNo);
                }

                if (stockHeadModel.lstStockInfo == null || stockHeadModel.lstStockInfo.Count == 0)
                {
                    stockHeadModel.Status = "E";
                    stockHeadModel.Message = "您扫描的物料或条码没有库存！";
                    return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
                }

                stockHeadModel.Status = "S";
                return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
            }
            catch (Exception ex)
            {
                stockHeadModel.Status = "E";
                stockHeadModel.Message = "Web异常:" + ex.Message;
                return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
            }


        }

        public string GetStockInfoByArrayMaterialNo(string strVoucherNo,string strArrayMaterialNo, string strUserJson)
        {
            StockHead_Model stockHeadModel = new StockHead_Model();
            try
            {
                if (string.IsNullOrEmpty(strArrayMaterialNo))
                {
                    stockHeadModel.Status = "E";
                    stockHeadModel.Message = "请先扫描条码或输入物料编号！";
                    return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
                }

                UserInfo userModel = JSONUtil.JSONHelper.JsonToObject<UserInfo>(strUserJson);
                if (userModel == null || string.IsNullOrEmpty(userModel.UserNo))
                {
                    stockHeadModel.Status = "E";
                    stockHeadModel.Message = "没有获取用户信息！";
                    return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
                }

                stockHeadModel.lstStockInfo = GetStockByArrayMaterialNo(strVoucherNo,strArrayMaterialNo);

                if (stockHeadModel.lstStockInfo == null || stockHeadModel.lstStockInfo.Count == 0)
                {
                    stockHeadModel.Status = "E";
                    stockHeadModel.Message = "您扫描的物料或条码没有库存！";
                    return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
                }

                stockHeadModel.Status = "S";
                return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
            }
            catch (Exception ex)
            {
                stockHeadModel.Status = "E";
                stockHeadModel.Message = "Web异常:" + ex.Message;
                return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
            }


        }

        public string GetStockInfoBySerialNo(string strBarCode, string strUserJson)
        {
            StockHead_Model stockHeadModel = new StockHead_Model();
            try
            {
                if (string.IsNullOrEmpty(strBarCode))
                {
                    stockHeadModel.Status = "E";
                    stockHeadModel.Message = "请先扫描条码！";
                    return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
                }

                UserInfo userModel = JSONUtil.JSONHelper.JsonToObject<UserInfo>(strUserJson);
                if (userModel == null || string.IsNullOrEmpty(userModel.UserNo))
                {
                    stockHeadModel.Status = "E";
                    stockHeadModel.Message = "没有获取用户信息！";
                    return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
                }


                string strSerialNo = string.Empty;
                if (MaterialBarcodeDecode.InvalidBarcode(strBarCode) == false)
                {
                    if (strBarCode.ToLower().StartsWith("http"))
                    {
                        strSerialNo = strBarCode.Substring(strBarCode.LastIndexOf("?") + 4);
                    }
                    else
                        strSerialNo = strBarCode;
                }
                else
                {
                    strSerialNo = MaterialBarcodeDecode.GetSerialNo(strBarCode);
                }

                stockHeadModel.lstStockInfo = GetStockBySerialNo(strSerialNo);

                if (stockHeadModel.lstStockInfo == null || stockHeadModel.lstStockInfo.Count == 0)
                {
                    stockHeadModel.Status = "E";
                    stockHeadModel.Message = "您扫描的物料或条码没有库存！";
                    return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
                }

                stockHeadModel.Status = "S";
                return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
            }
            catch (Exception ex)
            {
                stockHeadModel.Status = "E";
                stockHeadModel.Message = "Web异常:" + ex.Message;
                return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
            }


        }

        public string GetCapacityByProductLineNo(string strProductLineNo, string strUserJson)
        {
            StockHead_Model stockHeadModel = new StockHead_Model();
            try
            {
                if (string.IsNullOrEmpty(strProductLineNo))
                {
                    stockHeadModel.Status = "E";
                    stockHeadModel.Message = "请输入产线！";
                    return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
                }

                UserInfo userModel = JSONUtil.JSONHelper.JsonToObject<UserInfo>(strUserJson);
                if (userModel == null || string.IsNullOrEmpty(userModel.UserNo))
                {
                    stockHeadModel.Status = "E";
                    stockHeadModel.Message = "没有获取用户信息！";
                    return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
                }

                Stock_DB SD = new Stock_DB();
                QueryConditions conditions = new QueryConditions();
                conditions.ProductLineNo = strProductLineNo;
                conditions.StartTime = DateTime.Today;
                conditions.EndTime = DateTime.Today;
                stockHeadModel.lstStockInfo = SD.GetCapacity(conditions);

                if (stockHeadModel.lstStockInfo == null || stockHeadModel.lstStockInfo.Count == 0)
                {
                    stockHeadModel.Status = "E";
                    stockHeadModel.Message = "您输入的产线没有记录！";
                    return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
                }

                stockHeadModel.Status = "S";
                return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
            }
            catch (Exception ex)
            {
                stockHeadModel.Status = "E";
                stockHeadModel.Message = "Web异常:" + ex.Message;
                return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
            }

        }

        public bool GetCapacityForWMS(ref List<Stock_Model> modelList, QueryConditions list, ref string strError)
        {
            Stock_DB SD = new Stock_DB();
            try
            {
                modelList = SD.GetCapacity(list);
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

        private List<Stock_Model> GetStockByMaterialNo(string strMaterialNo)
        {
            Stock_DB SD = new Stock_DB();
            return SD.GetStockByMaterialNo(strMaterialNo);
        }

        private List<Stock_Model> GetStockByArrayMaterialNo(string VoucherNo,string strArrayMaterialNo)
        {
            Stock_DB SD = new Stock_DB();
            return SD.GetStockByArrayMaterialNo(VoucherNo,strArrayMaterialNo);
        }

        private List<Stock_Model> GetStockBySerialNo(string strSerialNo)
        {
            Stock_DB SD = new Stock_DB();
            return SD.GetStockBySerialNo(strSerialNo);
        }

        public string GetStockByAreaNo(string strAreaNo, string strUserJson)
        {
            StockHead_Model stockHeadModel = new StockHead_Model();
            try
            {
                if (string.IsNullOrEmpty(strAreaNo))
                {
                    stockHeadModel.Status = "E";
                    stockHeadModel.Message = "请扫描或输入货位编号！";
                    return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
                }

                UserInfo userModel = JSONUtil.JSONHelper.JsonToObject<UserInfo>(strUserJson);
                if (userModel == null || string.IsNullOrEmpty(userModel.UserNo))
                {
                    stockHeadModel.Status = "E";
                    stockHeadModel.Message = "没有获取用户信息！";
                    return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
                }

                Stock_DB SD = new Stock_DB();
                stockHeadModel.lstStockInfo = SD.GetStockByAreaNo(strAreaNo);
                if (stockHeadModel.lstStockInfo == null || stockHeadModel.lstStockInfo.Count == 0)
                {
                    stockHeadModel.Status = "E";
                    stockHeadModel.Message = "该货位没有物料库存信息！";
                    return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
                }
                stockHeadModel.Status = "S";
                return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);

            }
            catch (Exception ex)
            {
                stockHeadModel.Status = "E";
                stockHeadModel.Message = "Web异常：" + ex.Message;
                return JSONUtil.JSONHelper.ObjectToJson<StockHead_Model>(stockHeadModel);
            }
        }


        public bool GetStockListByPage(ref List<Stock_Model> modelList, Stock_Model model, ref DividPage page, UserInfo user, ref string strError)
        {
            if (page == null) page = new DividPage();
            List<Stock_Model> lstModel = new List<Stock_Model>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_Stock", GetFilterSql(model, user), "*", "Order By CreateTime desc,WarehouseNo,HouseNo,AreaNo,MaterialNo,Qty"))
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

        public bool GetStockDetailListByPage(ref List<Stock_Model> modelList, Stock_Model model, ref DividPage page, UserInfo user, ref string strError)
        {
            if (page == null) page = new DividPage();
            List<Stock_Model> lstModel = new List<Stock_Model>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_StockDetail", GetFilterSql(model, user), "*", "Order By CreateTime desc,WarehouseNo,HouseNo,AreaNo,MaterialNo,Qty"))
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

        private string GetFilterSql(Stock_Model model, UserInfo user)
        {
            try
            {
                string strSql = " Where AreaNo is not null ";
                bool hadWhere = true;

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

                if (!string.IsNullOrEmpty(model.SerialNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " SerialNo LIKE '%" + model.SerialNo + "%' ";
                    hadWhere = true;
                }
                //if (model.BatchNo.Equals("NULL"))
                //{
                //    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                //    strSql += " BatchNo is null ";
                //    hadWhere = true;
                //}

                if (!string.IsNullOrEmpty(model.BatchNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " BatchNo LIKE '%" + model.BatchNo + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.SN))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " SN LIKE '%" + model.SN + "%' ";
                    hadWhere = true;
                }

                if (model.StartTime != null)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " CreateTime >= " + model.StartTime.ToDateTime().Date.ToSqlTimeString() + " ";
                    hadWhere = true;
                }

                if (model.EndTime != null)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " CreateTime <= " + model.EndTime.ToDateTime().AddDays(1).Date.ToSqlTimeString() + " ";
                    hadWhere = true;
                }

                return strSql;
            }
            catch
            {
                return string.Empty;
            }
        }

        private Stock_Model GetModelFromDataReader(SqlDataReader dr)
        {
            Stock_Model model = new Stock_Model();
            if (Common_Func.readerExists(dr, "StockType")) model.StockType = dr["StockType"].ToInt32();
            if (Common_Func.readerExists(dr, "Barcode")) model.Barcode = dr["Barcode"].ToDBString();
            if (Common_Func.readerExists(dr, "SerialNo")) model.SerialNo = dr["SerialNo"].ToDBString();
            if (Common_Func.readerExists(dr, "MaterialNo")) model.MaterialNo = dr["MaterialNo"].ToDBString();
            if (Common_Func.readerExists(dr, "MaterialDesc")) model.MaterialDesc = dr["MaterialDesc"].ToDBString();
            if (Common_Func.readerExists(dr, "WarehouseNo")) model.WarehouseNo = dr["WarehouseNo"].ToDBString();
            if (Common_Func.readerExists(dr, "HouseNo")) model.HouseNo = dr["HouseNo"].ToDBString();
            if (Common_Func.readerExists(dr, "AreaNo")) model.AreaNo = dr["AreaNo"].ToDBString();
            if (Common_Func.readerExists(dr, "Qty")) model.Qty = dr["Qty"].ToDouble();
            if (Common_Func.readerExists(dr, "TempMaterialNo")) model.TempMaterialNo = dr["TempMaterialNo"].ToDBString();
            if (Common_Func.readerExists(dr, "TempMaterialDesc")) model.TempMaterialDesc = dr["TempMaterialDesc"].ToDBString();
            if (Common_Func.readerExists(dr, "PickAreaNo")) model.PickAreaNo = dr["PickAreaNo"].ToDBString();
            if (Common_Func.readerExists(dr, "CelAreaNo")) model.CelAreaNo = dr["CelAreaNo"].ToDBString();
            if (Common_Func.readerExists(dr, "BatchNo")) model.BatchNo = dr["BatchNo"].ToDBString();
            if (Common_Func.readerExists(dr, "StrStockType")) model.StrStockType = dr["StrStockType"].ToDBString();
            if (Common_Func.readerExists(dr, "WarehouseName")) model.WarehouseName = dr["WarehouseName"].ToDBString();
            if (Common_Func.readerExists(dr, "HouseName")) model.HouseName = dr["HouseName"].ToDBString();
            if (Common_Func.readerExists(dr, "AreaName")) model.AreaName = dr["AreaName"].ToDBString();
            if (Common_Func.readerExists(dr, "SN")) model.SN = dr["SN"].ToDBString();
            if (Common_Func.readerExists(dr, "Creater")) model.Creater = dr["Creater"].ToDBString();
            if (Common_Func.readerExists(dr, "CreateTime")) model.CreateTime = dr["CreateTime"].ToDateTime();

            return model;
        }

        private Stock_DB _db = new Stock_DB();

        public bool GetSaleBillVouchCodeByCustomer(string ccusname, out List<string> list, out string strErrMsg)
        {
            return _db.GetSaleBillVouchCodeByCustomer(ccusname, out list, out strErrMsg);
        }
        public bool GetSaleBillVouchByCode(string code, out SaleBillVouch_Model model, out string strErrMsg)
        {
            return _db.GetSaleBillVouchByCode(code, out model, out strErrMsg);
        }
        public bool GetOldSaleBillVouch(SaleBillDetails_Model detail, out List<SaleBillDetails_Model> list, out string strErrMsg)
        {
            return _db.GetOldSaleBillVouch(detail, out list, out strErrMsg);
        }

        public bool GetSaleBillDetailsForTrans(SaleBillDetails_Model detail, out List<SaleBillDetails_Model> list, out string strErrMsg)
        {
            return _db.GetSaleBillDetailsForTrans(detail, out list, out strErrMsg);
        }

        public bool SaveTempTrans(string creater, SaleBillDetails_Model detail, out string strErrMsg)
        {
            return _db.SaveTempTrans(creater, detail, out strErrMsg);
        }

        public bool VerifyTempTrans(SaleBillDetails_Model detail, out string strErrMsg)
        {
            return _db.VerifyTempTrans(detail, out strErrMsg);
        }

        public bool DelTempTrans(SaleBillDetails_Model detail, out string strErrMsg)
        {
            return _db.DelTempTrans(detail, out strErrMsg);
        }

        public bool GiveUpTempTrans(SaleBillDetails_Model detail, out string strErrMsg)
        {
            return _db.GiveUpTempTrans(detail, out strErrMsg);
        }

        public bool QueryTempTrans(string cinvcode, string cinvstd, string ssocode, string ssbvcode, string dsocode, string dsbvcode, out List<SaleBillDetails_Model> list, out string strErrMsg)
        {
            return _db.QueryTempTrans(cinvcode, cinvstd, ssocode, ssbvcode, dsocode, dsbvcode, out list, out strErrMsg);
        }

        public bool QueryStockSumByWHcode(string WHcode,out List<Stock_Model> list, out string strErrMsg)
        {
            return _db.QueryStockSumByWHcode(WHcode, out list, out strErrMsg);
        }

        public bool SaveCheckOmitAdd(string strBarcode, Basic.Area.AreaInfo areaInfo, ref string strErrMsg)
        {
            return _db.SaveCheckOmitAdd(strBarcode, areaInfo, ref strErrMsg);
        }
    }
}
