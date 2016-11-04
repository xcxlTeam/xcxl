using BLL.Basic.User;
using BLL.Common;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace BLL.Basic.Warehouse
{
    public class Warehouse_Func
    {
        private Warehouse_DB _db = new Warehouse_DB();

        public bool ExistsWarehouseNo(WarehouseInfo model, bool bIncludeDel, UserInfo user, ref string strError)
        {
            try
            {
                return _db.ExistsWarehouseNo(model, bIncludeDel);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public bool SaveWarehouse(ref WarehouseInfo model, UserInfo user, ref string strError)
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
                return _db.SaveWarehouse(ref model);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }


        public bool DeleteWarehouseByID(WarehouseInfo model, UserInfo user, ref string strError)
        {
            try
            {
                return _db.DeleteWarehouseByID(model);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }


        public bool GetWarehouseByID(ref WarehouseInfo model, UserInfo user, ref string strError)
        {
            try
            {
                using (SqlDataReader dr = _db.GetWarehouseByID(model))
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

        public bool GetWarehouseListByPage(ref List<WarehouseInfo> modelList, WarehouseInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            if (page == null) page = new DividPage();
            List<WarehouseInfo> lstModel = new List<WarehouseInfo>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_Warehouse", GetFilterSql(model, user), "*", "Order By WarehouseNo,ID Desc"))
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

        public bool GetWarehouseList(ref List<WarehouseInfo> modelList, WarehouseInfo model, UserInfo user, ref string strError)
        {
            List<WarehouseInfo> lstModel = new List<WarehouseInfo>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryAll("V_Warehouse", GetFilterSql(model, user), "*", "Order By WarehouseNo,ID Desc"))
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

        private string GetFilterSql(WarehouseInfo model, UserInfo user)
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
                    strSql += " ID In (Select WarehouseID From T_House Where HouseNo LIKE '%" + model.HouseNo + "%' OR HouseName Like '%" + model.HouseNo + "%') ";
                    hadWhere = true;
                }

                //if (!string.IsNullOrEmpty(model.HouseName))
                //{
                //    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                //    strSql += " ID In (Select WarehouseID From T_House Where HouseName LIKE '%" + model.HouseName + "%') ";
                //    hadWhere = true;
                //}

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

        public string GetWarehouseBycWhCode(string WarehouseNo)
        {
            WarehouseInfo model = new WarehouseInfo();
            try
            {
                if (string.IsNullOrEmpty(WarehouseNo))
                {
                    model.Status = "E";
                    model.Message = "仓库编码不能为空！";
                    return JSONUtil.JSONHelper.ObjectToJson<WarehouseInfo>(model);
                }
                model.WarehouseNo = WarehouseNo;
                using (SqlDataReader dr = _db.GetWarehouseBycWhCode(model))
                {
                    if (dr.Read())
                    {
                        model.WarehouseNo = dr["cwhcode"].ToDBString();
                        model.WarehouseName = dr["cwhname"].ToDBString();
                        model.Status = "S";
                        return JSONUtil.JSONHelper.ObjectToJson<WarehouseInfo>(model);
                    }
                    else
                    {
                        model.Status = "E";
                        model.Message = "找不到任何数据";
                        return JSONUtil.JSONHelper.ObjectToJson<WarehouseInfo>(model);
                    }
                }
            }
            catch (Exception ex)
            {
                model.Status = "E";
                model.Message = ex.Message;
                return JSONUtil.JSONHelper.ObjectToJson<WarehouseInfo>(model);
            }
            finally
            {
            }
        }

        public WarehouseInfo GetWarehouseInfo(string WarehouseNo)
        {
            WarehouseInfo model = new WarehouseInfo();
            try
            {
                if (string.IsNullOrEmpty(WarehouseNo))
                {
                    model.Status = "E";
                    model.Message = "仓库编码不能为空！";
                    return model;
                }
                model.WarehouseNo = WarehouseNo;
                using (SqlDataReader dr = _db.GetWarehouseBycWhCode(model))
                {
                    if (dr.Read())
                    {
                        model.WarehouseNo = dr["cwhcode"].ToDBString();
                        model.WarehouseName = dr["cwhname"].ToDBString();
                        model.Status = "S";
                        return model;
                    }
                    else
                    {
                        model.Status = "E";
                        model.Message = "找不到任何数据";
                        return model;
                    }
                }
            }
            catch (Exception ex)
            {
                model.Status = "E";
                model.Message = ex.Message;
                return model;
            }
            finally
            {
            }
        }


        private WarehouseInfo GetModelFromDataReader(SqlDataReader dr)
        {
            WarehouseInfo model = new WarehouseInfo();
            model.ID = dr["ID"].ToInt32();
            model.WarehouseNo = dr["WAREHOUSENO"].ToDBString();
            model.WarehouseName = dr["WAREHOUSENAME"].ToDBString();
            model.WarehouseType = dr["WAREHOUSETYPE"].ToInt32();
            model.ContactUser = dr["CONTACTUSER"].ToDBString();
            model.ContactPhone = dr["CONTACTPHONE"].ToDBString();
            model.HouseCount = dr["HOUSECOUNT"].ToInt32();
            model.HouseUsingCount = dr["HOUSEUSINGCOUNT"].ToInt32();
            model.Address = dr["ADDRESS"].ToDBString();
            model.LocationDesc = dr["LOCATIONDESC"].ToDBString();
            model.WarehouseStatus = dr["WarehouseStatus"].ToInt32();
            model.IsDel = dr["ISDEL"].ToInt32();
            model.Creater = dr["CREATER"].ToDBString();
            model.CreateTime = dr["CREATETIME"].ToDateTime();
            model.Modifyer = dr["MODIFYER"].ToDBString();
            model.ModifyTime = dr["MODIFYTIME"].ToDateTimeNull();

            if (Common_Func.readerExists(dr, "IsChecked")) model.BIsChecked = dr["IsChecked"].ToBoolean();
            if (Common_Func.readerExists(dr, "StrWarehouseStatus")) model.StrWarehouseStatus = dr["StrWarehouseStatus"].ToDBString();
            if (Common_Func.readerExists(dr, "AreaCount")) model.AreaCount = dr["AreaCount"].ToInt32();
            if (Common_Func.readerExists(dr, "AreaUsingCount")) model.AreaUsingCount = dr["AreaUsingCount"].ToInt32();

            model.HouseRate = model.HouseCount >= 1 ? model.HouseUsingCount.ToDecimal() / model.HouseCount.ToDecimal() : 0;
            model.AreaRate = model.AreaCount >= 1 ? model.AreaUsingCount.ToDecimal() / model.AreaCount.ToDecimal() : 0;

            return model;
        }

        public bool GetWarehouseListByUser(ref List<WarehouseInfo> modelList, UserInfo User, bool IncludNoCheck, UserInfo user, ref string strError)
        {
            List<WarehouseInfo> lstModel = new List<WarehouseInfo>();
            try
            {
                using (SqlDataReader dr = _db.GetWarehouseListByUserID(User, IncludNoCheck))
                {
                    if (dr == null) return true;
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
                strError = "获取用户仓库列表失败！" + ex.Message + "\r\n" + ex.TargetSite;
                return false;
            }
            finally
            {
            }
        }
    }
}
