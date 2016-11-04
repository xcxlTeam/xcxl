using BLL.Basic.Area;
using BLL.Basic.User;
using BLL.Common;
using BLL.JSONUtil;
using BLL.PrintBarcode;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BLL.Check
{
    public class CheckTrans_Func
    {
        private CheckTrans_DB _db = new CheckTrans_DB();

        public bool SaveCheckTrans(ref CheckTransInfo model, UserInfo user, ref string strError)
        {
            try
            {
                if (model.ID <= 0)
                {
                    model.Creater = user.UserNo;
                }
                else
                {
                    model.Modifyer = user.UserNo;
                }
                return _db.SaveCheckTrans(ref model);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public string SaveCheckTransForAndroid(string strCheckTransJson, string strAreaJson, string strUserJson)
        {
            CheckTransInfo model = new CheckTransInfo();
            string strError = string.Empty;

            try
            {
                model = JSONHelper.JsonToObject<CheckTransInfo>(strCheckTransJson);
                if (model == null || string.IsNullOrEmpty(model.Barcode))
                {
                    model = new CheckTransInfo();
                    model.Status = "E";
                    model.Message = "盘点扫描信息获取失败!请重新扫描!";
                    return JSONHelper.ObjectToJson(model);
                }

                UserInfo user = JSONHelper.JsonToObject<UserInfo>(strUserJson);
                if (user == null || string.IsNullOrEmpty(user.UserNo))
                {
                    model.Status = "E";
                    model.Message = "用户信息获取失败!";
                    return JSONHelper.ObjectToJson(model);
                }

                AreaInfo area = JSONHelper.JsonToObject<AreaInfo>(strAreaJson);
                if (area == null || string.IsNullOrEmpty(area.AreaNo))
                {
                    model.Status = "E";
                    model.Message = "货位信息获取失败!";
                    return JSONHelper.ObjectToJson(model);
                }

                PrintBarcode.Barcode_Func bfunc = new PrintBarcode.Barcode_Func();
                model.ScanBarcode = bfunc.GetCheckBarcode(model.CheckID, model.Barcode, false, ref strError);
                if (model.ScanBarcode == null)
                {
                    model.Status = "E";
                    model.Message = "条码信息获取失败!" + strError;
                    return JSONHelper.ObjectToJson(model);
                }

                model.AreaNo = area.AreaNo;
                model.HouseNo = area.HouseNo;
                model.WarehouseNo = area.WarehouseNo;

                model.Operator = user.UserNo;
                model.Barcode = model.ScanBarcode.BARCODE;
                model.SerialNo = model.ScanBarcode.SERIALNO;
                model.BatchNo = model.ScanBarcode.BATCHNO;
                model.SN = model.ScanBarcode.SN;
                model.MaterialNo = model.ScanBarcode.MATERIALNO;
                model.MaterialDesc = model.ScanBarcode.MATERIALDESC;

                bool bResult = SaveCheckTrans(ref model, user, ref strError);

                if (bResult)
                {
                    model.Status = "S";
                    return JSONHelper.ObjectToJson(model);
                }
                else
                {
                    model.Status = "E";
                    model.Message = strError;
                    return JSONHelper.ObjectToJson(model);
                }
            }
            catch (Exception ex)
            {
                model.Status = "E";
                model.Message = "Web异常：" + ex.Message + ex.StackTrace;
                return JSONHelper.ObjectToJson(model);
            }
        }

        public bool SaveCheckTransList(List<CheckTransInfo> modelList, UserInfo user, ref string strError)
        {
            try
            {
                return _db.SaveCheckTransList(modelList, user);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public bool SaveCheckTransList(ref CheckTransInfo modelList, UserInfo user, ref string strError)
        {
            try
            {
                return _db.SaveCheckTransList(ref modelList);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public string SaveCheckTransListForAndroid(string strCheckTransHeaderJson, string strUserJson)
        {
            CheckTransHeader model = new CheckTransHeader();
            string strError = string.Empty;

            try
            {
                model = JSONHelper.JsonToObject<CheckTransHeader>(strCheckTransHeaderJson);
                if (model == null || model.lstCheckTrans == null || model.lstCheckTrans.Count <= 0)
                {
                    model = new CheckTransHeader();
                    model.Status = "E";
                    model.Message = "盘点扫描信息获取失败!请重新扫描!";
                    return JSONHelper.ObjectToJson(model);
                }

                UserInfo user = JSONHelper.JsonToObject<UserInfo>(strUserJson);
                if (user == null || string.IsNullOrEmpty(user.UserNo))
                {
                    model.Status = "E";
                    model.Message = "用户信息获取失败!";
                    return JSONHelper.ObjectToJson(model);
                }

                bool bResult = SaveCheckTransList(model.lstCheckTrans, user, ref strError);

                if (bResult)
                {
                    model.Status = "S";
                    return JSONHelper.ObjectToJson(model);
                }
                else
                {
                    model.Status = "E";
                    model.Message = strError;
                    return JSONHelper.ObjectToJson(model);
                }
            }
            catch (Exception ex)
            {
                model.Status = "E";
                model.Message = "Web异常：" + ex.Message + ex.StackTrace;
                //if (Common_Func.IsOracleError(model.Message, ref strError)) model.Message = strError;
                return JSONHelper.ObjectToJson(model);
            }
        }

        public bool GetCheckTransByID(ref CheckTransInfo model, UserInfo user, ref string strError)
        {
            try
            {
                using (SqlDataReader dr = _db.GetCheckTransByID(model))
                {
                    if (dr.Read())
                    {
                        model = (GetModelFromDataReader(dr));
                        return true;
                    }
                    else
                    {
                        strError = "找不到任何数据";
                        return false;
                    }
                }
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


        public bool GetCheckTransListByPage(ref List<CheckTransInfo> modelList, CheckTransInfo model, ref DividPage page, UserInfo user, ref string strError)
        {

            List<CheckTransInfo> lstModel = new List<CheckTransInfo>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_CheckTrans", GetFilterSql(model, user), "*", "Order By CheckID Desc,ID Desc"))
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

        private string GetFilterSql(CheckTransInfo model, UserInfo user)
        {
            try
            {
                string strSql = "";
                bool hadWhere = false;


                if (model.ID >= 1)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " ID = " + model.ID + " ";
                    hadWhere = true;
                }

                if (model.CheckID >= 1)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " CheckID = " + model.CheckID + " ";
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

                if (!string.IsNullOrEmpty(model.MaterialNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (MaterialNo LIKE '%" + model.MaterialNo + "%' OR MaterialDesc LIKE '%" + model.MaterialNo + "%') ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.Operator))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " Operator Like '%" + model.Operator + "%' ";
                    hadWhere = true;
                }

                if (model.StartTime != null)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " OperationTime >= " + model.StartTime.ToDateTime().Date.ToSqlTimeString() + " ";
                    hadWhere = true;
                }

                if (model.EndTime != null)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " OperationTime <= " + model.EndTime.ToDateTime().AddDays(1).Date.ToSqlTimeString() + " ";
                    hadWhere = true;
                }

                return strSql;
            }
            catch
            {
                return string.Empty;
            }
        }

        private CheckTransInfo GetModelFromDataReader(SqlDataReader dr)
        {
            CheckTransInfo model = new CheckTransInfo();
            if (Common_Func.readerExists(dr, "ID")) model.ID = dr["ID"].ToInt32();
            if (Common_Func.readerExists(dr, "CheckID")) model.CheckID = dr["CheckID"].ToInt32();
            if (Common_Func.readerExists(dr, "WarehouseNo")) model.WarehouseNo = dr["WarehouseNo"].ToDBString();
            if (Common_Func.readerExists(dr, "HouseNo")) model.HouseNo = dr["HouseNo"].ToDBString();
            if (Common_Func.readerExists(dr, "AreaNo")) model.AreaNo = dr["AreaNo"].ToDBString();
            if (Common_Func.readerExists(dr, "MaterialNo")) model.MaterialNo = dr["MaterialNo"].ToDBString();
            if (Common_Func.readerExists(dr, "MaterialDesc")) model.MaterialDesc = dr["MaterialDesc"].ToDBString();
            if (Common_Func.readerExists(dr, "Barcode")) model.Barcode = dr["Barcode"].ToDBString();
            if (Common_Func.readerExists(dr, "SerialNo")) model.SerialNo = dr["SerialNo"].ToDBString();
            if (Common_Func.readerExists(dr, "BatchNo")) model.BatchNo = dr["BatchNo"].ToDBString();
            if (Common_Func.readerExists(dr, "ScanQty")) model.ScanQty = dr["ScanQty"].ToDecimal();
            if (Common_Func.readerExists(dr, "Operator")) model.Operator = dr["Operator"].ToDBString();
            if (Common_Func.readerExists(dr, "OperationTime")) model.OperationTime = dr["OperationTime"].ToDateTime();

            if (Common_Func.readerExists(dr, "WarehouseName")) model.WarehouseName = dr["WarehouseName"].ToDBString();
            if (Common_Func.readerExists(dr, "HouseName")) model.HouseName = dr["HouseName"].ToDBString();
            if (Common_Func.readerExists(dr, "AreaName")) model.AreaName = dr["AreaName"].ToDBString();

            return model;
        }

        public string SaveCheckTransScan(int checkID, string strBarcode, string strAreaNo, string strUserJson, bool isTray)
        {
            CheckTransInfo model = new CheckTransInfo();
            string strError = string.Empty;

            try
            {
                //AreaInfo area = JSONHelper.JsonToObject<AreaInfo>(strAreaNo);


                UserInfo user = JSONHelper.JsonToObject<UserInfo>(strUserJson);
                if (user == null || string.IsNullOrEmpty(user.UserNo))
                {
                    model.Status = "E";
                    model.Message = "用户信息获取失败!";
                    return JSONHelper.ObjectToJson(model);
                }
                Area_Func func = new Area_Func();
                AreaInfo area = new AreaInfo();
                area.AreaNo = strAreaNo;
                string strErrMsg = null;
                if (!func.GetAreaByAreaNo(ref area, user, ref strErrMsg))
                {
                    throw new Exception(strErrMsg);
                }
                if (area == null || string.IsNullOrEmpty(area.AreaNo))
                {
                    model.Status = "E";
                    model.Message = "货位信息获取失败!";
                    return JSONHelper.ObjectToJson(model);
                }

                PrintBarcode.Barcode_Func bfunc = new PrintBarcode.Barcode_Func();
                model.ScanBarcode = bfunc.GetCheckBarcode(checkID, strBarcode, isTray, ref strError);
                if (model.ScanBarcode == null)
                {
                    model.Status = "E";
                    model.Message = "条码信息获取失败!" + strError;
                    return JSONHelper.ObjectToJson(model);
                }
                List<string> lstBarcode = new List<string>();
                bool res = true;
                model.CheckID = checkID;
                model.AreaNo = area.AreaNo;
                model.HouseNo = area.HouseNo;
                model.WarehouseNo = area.WarehouseNo;

                model.Operator = user.UserNo;
                model.Barcode = model.ScanBarcode.BARCODE;
                model.SerialNo = model.ScanBarcode.SERIALNO;
                model.BatchNo = model.ScanBarcode.BATCHNO;
                model.SN = model.ScanBarcode.SN;
                model.MaterialNo = model.ScanBarcode.MATERIALNO;
                model.MaterialDesc = model.ScanBarcode.MATERIALDESC;

                model.ScanQty = model.ScanBarcode.QTY;
                if (isTray)
                {
                    res = SaveCheckTransList(ref model, user, ref strError);
                }
                else
                {
                   
                    res = SaveCheckTrans(ref model, user, ref strError);
                }
                

                if (res)
                {
                    model.Status = "S";
                    return JSONHelper.ObjectToJson(model);
                }
                else
                {
                    model.Status = "E";
                    model.Message = strError;
                    return JSONHelper.ObjectToJson(model);
                }
            }
            catch (Exception ex)
            {
                model.Status = "E";
                model.Message = "Web异常：" + ex.Message + ex.StackTrace;
                //if (Common_Func.IsOracleError(model.Message, ref strError)) model.Message = strError;
                return JSONHelper.ObjectToJson(model);
            }
        }

        public string SaveCheckTransScanPro(int checkID, string strBarcode, string strAreaNo, string strUserJson, bool isTray)
        {
            CheckTransInfo model = new CheckTransInfo();
            string strError = string.Empty;

            try
            {
                //AreaInfo area = JSONHelper.JsonToObject<AreaInfo>(strAreaNo);


                UserInfo user = JSONHelper.JsonToObject<UserInfo>(strUserJson);
                if (user == null || string.IsNullOrEmpty(user.UserNo))
                {
                    model.Status = "E";
                    model.Message = "用户信息获取失败!";
                    return JSONHelper.ObjectToJson(model);
                }
                Area_Func func = new Area_Func();
                AreaInfo area = new AreaInfo();
                area.AreaNo = strAreaNo;
                string strErrMsg = null;
                if (!func.GetAreaByAreaNo(ref area, user, ref strErrMsg))
                {
                    throw new Exception(strErrMsg);
                }
                if (area == null || string.IsNullOrEmpty(area.AreaNo))
                {
                    model.Status = "E";
                    model.Message = "货位信息获取失败!";
                    return JSONHelper.ObjectToJson(model);
                }

                PrintBarcode.Barcode_Func bfunc = new PrintBarcode.Barcode_Func();
                model.ScanBarcode = bfunc.GetCheckBarcode(checkID, strBarcode, isTray, ref strError);
                if (model.ScanBarcode == null)
                {
                    model.Status = "E";
                    model.Message = "条码信息获取失败!" + strError;
                    return JSONHelper.ObjectToJson(model);
                }
                List<string> lstBarcode = new List<string>();
                if (isTray)
                {
                    foreach (var item in model.ScanBarcode.tray_Model.listDetails)
                    {
                        lstBarcode.AddRange(item.listBarcode);
                    }
                }
                else
                {
                    lstBarcode.Add(model.ScanBarcode.SERIALNO);
                }
                bool res = true;
                List<Barcode_Model> lstScanBar = new List<Barcode_Model>();
                foreach (var item in lstBarcode)
                {
                    Barcode_Model bar = bfunc.GetCheckBarcode(item, ref strError);
                    if (bar != null && !string.IsNullOrEmpty(bar.SERIALNO))
                        lstScanBar.Add(bar);
                }
                foreach (var item in lstScanBar)
                {
                    model = new CheckTransInfo();
                    model.CheckID = checkID;

                    model.AreaNo = area.AreaNo;
                    model.HouseNo = area.HouseNo;
                    model.WarehouseNo = area.WarehouseNo;

                    model.Operator = user.UserNo;
                    model.Barcode = item.BARCODE;
                    model.SerialNo = item.SERIALNO;
                    model.BatchNo = item.BATCHNO;
                    model.SN = item.SN;
                    model.MaterialNo = item.MATERIALNO;
                    model.MaterialDesc = item.MATERIALDESC;
                    model.ScanQty = item.QTY;
                    res = SaveCheckTrans(ref model, user, ref strError);
                    if (!res)
                        break;
                }

                if (res)
                {
                    model.Status = "S";
                    return JSONHelper.ObjectToJson(model);
                }
                else
                {
                    model.Status = "E";
                    model.Message = strError;
                    return JSONHelper.ObjectToJson(model);
                }
            }
            catch (Exception ex)
            {
                model.Status = "E";
                model.Message = "Web异常：" + ex.Message + ex.StackTrace;
                //if (Common_Func.IsOracleError(model.Message, ref strError)) model.Message = strError;
                return JSONHelper.ObjectToJson(model);
            }
        }


        public List<CheckTransInfo> GetCheckTransListByCheck(CheckInfo check, UserInfo user, ref string strError)
        {

            List<CheckTransInfo> lstModel = new List<CheckTransInfo>();
            try
            {
                using (SqlDataReader dr = _db.GetCheckTransListByCheck(check))
                {
                    while (dr.Read())
                    {
                        lstModel.Add(GetModelFromDataReader(dr));
                    }
                }

                return lstModel;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return lstModel;
            }
            finally
            {
            }
        }
    }
}
