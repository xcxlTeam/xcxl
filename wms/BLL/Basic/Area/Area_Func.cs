using BLL.Basic.User;
using BLL.Common;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using BLL.JSONUtil;

namespace BLL.Basic.Area
{
    public class Area_Func
    {
        private Area_DB _db = new Area_DB();

        public bool ExistsAreaNo(AreaInfo model, bool bIncludeDel, UserInfo user, ref string strError)
        {
            try
            {
                return _db.ExistsAreaNo(model, bIncludeDel);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public string GetAreaInfo(string strAreaNo, string strUserJson)
        {
            string strErrMsg = string.Empty;
            AreaInfo Info = new AreaInfo();
            Info.AreaNo = strAreaNo;

            #region MyRegion

            try
            {

                if (string.IsNullOrEmpty(strAreaNo))
                {
                    return GetReturnJson(false, Info, "货位编码不能为空！");
                }

                UserInfo userModel = JSONUtil.JSONHelper.JsonToObject<UserInfo>(strUserJson);

                if (userModel == null || string.IsNullOrEmpty(userModel.UserNo))
                {
                    return GetReturnJson(false, Info, "没有获取用户信息！");
                }

                bool res = _db.ExistsAreaNo(Info, false);
                if (res)
                {
                    res = GetAreaByAreaNo(ref Info, userModel, ref strErrMsg);
                }

                return GetReturnJson(res, Info, strErrMsg);
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return GetReturnJson(false, Info, strErrMsg);
            }
            finally
            {

            }
            #endregion
        }

        public bool GetAreaInfoByAreaNo(string strAreaNo, ref AreaInfo Info, ref string strErrMsg)
        {
            strErrMsg = string.Empty;
            Info = new AreaInfo();
            Info.AreaNo = strAreaNo;

            #region MyRegion

            try
            {

                if (string.IsNullOrEmpty(strAreaNo))
                {
                    strErrMsg = "货位编码不能为空";
                    return false;
                }


                bool res = _db.ExistsAreaNo(Info, false);
                if (res)
                {
                    res = GetAreaByAreaNo(ref Info, null, ref strErrMsg);
                }
                else
                    strErrMsg = "货位不存在！";

                return res;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            finally
            {

            }
            #endregion
        }

        private string GetReturnJson(bool bSucc, AreaInfo Info, string strErrMsg)
        {
            Info.Status = bSucc == true ? "S" : "E";
            Info.Message = strErrMsg;
            return JSONUtil.JSONHelper.ObjectToJson<AreaInfo>(Info);
        }

        public bool SaveArea(ref AreaInfo model, UserInfo user, ref string strError)
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
                return _db.SaveArea(ref model);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }


        public bool DeleteAreaByID(AreaInfo model, UserInfo user, ref string strError)
        {
            try
            {
                return _db.DeleteAreaByID(model);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }


        public bool GetAreaByID(ref AreaInfo model, UserInfo user, ref string strError)
        {
            try
            {
                using (SqlDataReader dr = _db.GetAreaByID(model))
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

        public bool GetAreaByAreaNo(ref AreaInfo model, UserInfo user, ref string strError)
        {
            try
            {
                using (SqlDataReader dr = _db.GetAreaByAreaNo(model))
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


        public bool GetAreaListByPage(ref List<AreaInfo> modelList, AreaInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            if (page == null) page = new DividPage();
            List<AreaInfo> lstModel = new List<AreaInfo>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_Area", GetFilterSql(model, user), "*", "Order By WarehouseNo,HouseNo,AreaNo,ID Desc"))
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

        public bool GetAreaList(ref List<AreaInfo> modelList, AreaInfo model, UserInfo user, ref string strError)
        {
            List<AreaInfo> lstModel = new List<AreaInfo>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryAll("V_Area", GetFilterSql(model, user), "*", "Order By WarehouseNo,HouseNo,AreaNo,ID Desc"))
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
        }

        private string GetFilterSql(AreaInfo model, UserInfo user)
        {
            try
            {
                string strSql = " Where ISNULL(IsDel,1) = 1 ";
                bool hadWhere = true;


                if (!string.IsNullOrEmpty(model.WarehouseNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (WarehouseNo LIKE '%" + model.WarehouseNo + "%' OR WarehouseName Like '%" + model.WarehouseNo + "%') ";
                    hadWhere = true;
                }

                //if (!string.IsNullOrEmpty(model.WarehouseName))
                //{
                //    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                //    strSql += " WarehouseName LIKE '%" + model.WarehouseName + "%' ";
                //    hadWhere = true;
                //}

                if (!string.IsNullOrEmpty(model.HouseNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (HouseNo LIKE '%" + model.HouseNo + "%' OR HouseName Like '%" + model.HouseNo + "%') ";
                    hadWhere = true;
                }

                //if (!string.IsNullOrEmpty(model.HouseName))
                //{
                //    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                //    strSql += " HouseName LIKE '%" + model.HouseName + "%' ";
                //    hadWhere = true;
                //}

                if (!string.IsNullOrEmpty(model.AreaNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (AreaNo LIKE '%" + model.AreaNo + "%' OR AreaName Like '%" + model.AreaNo + "%') ";
                    hadWhere = true;
                }

                //if (!string.IsNullOrEmpty(model.AreaName))
                //{
                //    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                //    strSql += " AreaName LIKE '%" + model.AreaName + "%' ";
                //    hadWhere = true;
                //}

                if (model.HouseID >= 1)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " HouseID = " + model.HouseID + " ";
                    hadWhere = true;
                }

                if (model.AreaType >= 1)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " AreaType = " + model.AreaType + " ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.Address))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " Address Like '%" + model.Address + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.Creater))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " Creater Like '%" + model.Creater + "%' ";
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

        private AreaInfo GetModelFromDataReader(SqlDataReader dr)
        {
            AreaInfo model = new AreaInfo();
            model.ID = dr["ID"].ToInt32();
            model.AreaNo = dr["AREANO"].ToDBString();
            model.AreaName = dr["AREANAME"].ToDBString();
            model.AreaType = dr["AREATYPE"].ToInt32();
            model.ContactUser = dr["CONTACTUSER"].ToDBString();
            model.ContactPhone = dr["CONTACTPHONE"].ToDBString();
            model.Address = dr["ADDRESS"].ToDBString();
            model.LocationDesc = dr["LOCATIONDESC"].ToDBString();
            model.AreaStatus = dr["AreaStatus"].ToInt32();
            model.HouseID = dr["HOUSEID"].ToInt32();
            model.IsDel = dr["ISDEL"].ToInt32();
            model.Creater = dr["CREATER"].ToDBString();
            model.CreateTime = dr["CREATETIME"].ToDateTime();
            model.Modifyer = dr["MODIFYER"].ToDBString();
            model.ModifyTime = dr["MODIFYTIME"].ToDateTimeNull();

            if (Common_Func.readerExists(dr, "HouseNo")) model.HouseNo = dr["HouseNo"].ToDBString();
            if (Common_Func.readerExists(dr, "isHost")) model.isHost = dr["isHost"].ToInt32()==1;
            if (Common_Func.readerExists(dr, "HouseName")) model.HouseName = dr["HouseName"].ToDBString();
            if (Common_Func.readerExists(dr, "WarehouseNo")) model.WarehouseNo = dr["WarehouseNo"].ToDBString();
            if (Common_Func.readerExists(dr, "WarehouseName")) model.WarehouseName = dr["WarehouseName"].ToDBString();
            if (Common_Func.readerExists(dr, "StrAreaStatus")) model.StrAreaStatus = dr["StrAreaStatus"].ToDBString();

            return model;
        }

        public bool GetAreaByNo(ref AreaInfo model, UserInfo user, ref string strError)
        {

            using (SqlDataReader dr = _db.GetAreaByNo(model.AreaNo))
            {
                if (dr.Read())
                {
                    model = (GetModelFromDataReader(dr));
                }
                else
                {
                    strError = "该货位信息不存在";
                    return false;
                }
            }

            if (model.IsDel.ToBoolean())
            {
                strError = "该货位已删除";
                return false;
            }

            //if (model.AreaStatus != 1)
            //{
            //    strError = "该货位已锁定";
            //    return false;
            //}

            return true;
        }

        public string GetCheckAreaForAndroid(int checkID, string strAreaNo, string strUserJson)
        {
            AreaInfo model = new AreaInfo();
            string strError = string.Empty;

            try
            {
                if (checkID <= 0)
                {
                    model.Status = "E";
                    model.Message = "盘点信息获取失败!";
                    return JSONHelper.ObjectToJson(model);
                }

                UserInfo user = JSONHelper.JsonToObject<UserInfo>(strUserJson);
                if (user == null || string.IsNullOrEmpty(user.UserNo))
                {
                    model.Status = "E";
                    model.Message = "用户信息获取失败!";
                    return JSONHelper.ObjectToJson(model);
                }

                model.AreaNo = strAreaNo;
                if (!GetAreaByNo(ref model, user, ref strError))
                {
                    model.Status = "E";
                    model.Message = strError;
                    return JSONHelper.ObjectToJson(model);
                }

                if (model.AreaStatus != 1 && model.CheckID != 0 && model.CheckID != checkID)
                {
                    model.Status = "E";
                    model.Message = "该货位已经被锁定";
                    return JSONHelper.ObjectToJson(model);
                }

                if (!_db.AreaOfCheck(checkID, model))
                {
                    model.Status = "E";
                    model.Message = "扫描货位不属于当前盘点!";
                    return JSONHelper.ObjectToJson(model);
                }

                model.Status = "S";
                return JSONHelper.ObjectToJson(model);
            }
            catch (Exception ex)
            {
                model.Status = "E";
                model.Message = "Web异常：" + ex.Message + ex.StackTrace;
                //if (Common_Func.IsOracleError(model.Message, ref strError)) model.Message = strError;
                return JSONHelper.ObjectToJson(model);
            }
        }

        public bool IsAreaChecking(AreaInfo model, ref string strError)
        {
            try
            {
                using (SqlDataReader dr = _db.IsAreaChecking(model))
                {
                    if (dr.Read())
                    {
                        if (dr[0].ToInt32() != 1 && !string.IsNullOrEmpty(dr[1].ToString()))
                        {
                            strError = "该货位正在盘点！";
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return true;
            }
            finally
            {
            }
        }


    }
}
