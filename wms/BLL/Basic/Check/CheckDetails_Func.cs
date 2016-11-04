using JXBLL.Basic.User;
using JXBLL.Common;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace JXBLL.Basic.Check
{
    public class CheckDetails_Func
    {
        private CheckDetails_DB _db = new CheckDetails_DB();

        public bool GetCheckDetailsByID(ref CheckDetailsInfo model, UserInfo user, ref string strError)
        {
            try
            {
                using (SqlDataReader dr = _db.GetCheckDetailsByID(model))
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


        public bool GetCheckDetailsListByPage(ref List<CheckDetailsInfo> modelList, CheckDetailsInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            if (page == null) page = new DividPage();
            List<CheckDetailsInfo> lstModel = new List<CheckDetailsInfo>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_CheckDetails", GetFilterSql(model, user), GetFieldsSql(model, user), "Order By CheckID Desc,ID Desc"))
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

        private string GetFilterSql(CheckDetailsInfo model, UserInfo user)
        {
            try
            {
                string strSql = " Where NVL(IsDel,1) = 1 ";
                bool hadWhere = true;


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

                if (model.Status >= 1)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " Status = " + model.Status + " ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.Operator))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " Operator Like '%" + model.Operator + "%' ";
                    hadWhere = true;
                }

                if (model.ProfitLoss >= 1)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " ProfitLoss = " + model.ProfitLoss + " ";
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

                switch (model.CheckType)
                {
                    case 1:
                        strSql += " group by CheckID, WarehouseNo, WarehouseName ";
                        break;

                    case 2:
                        strSql += " group by CheckID, WarehouseNo, WarehouseName, HouseNo, HouseName ";
                        break;

                    case 3:
                        strSql += " group by CheckID, WarehouseNo, WarehouseName, HouseNo, HouseName, AreaNo, AreaName ";
                        break;

                    case 4:
                        strSql += " group by CheckID, MaterialNo, MaterialDesc ";
                        break;

                    default:
                        break;
                }

                return strSql;
            }
            catch
            {
                return string.Empty;
            }
        }

        private string GetFieldsSql(CheckDetailsInfo model, UserInfo user)
        {
            string strSql = "*";
            switch (model.CheckType)
            {
                case 1:
                    strSql = "CheckID, WarehouseNo, WarehouseName, Max(AccountQty) AccountQty";
                    break;

                case 2:
                    strSql = "CheckID, WarehouseNo, WarehouseName, HouseNo, HouseName, Max(AccountQty) AccountQty";
                    break;

                case 3:
                    strSql = "CheckID, WarehouseNo, WarehouseName, HouseNo, HouseName, AreaNo, AreaName, Max(AccountQty) AccountQty";
                    break;

                case 4:
                    strSql = "CheckID, MaterialNo, MaterialDesc, Max(AccountQty) AccountQty";
                    break;

                default:
                    break;
            }
            return strSql;
        }

        private CheckDetailsInfo GetModelFromDataReader(SqlDataReader dr)
        {
            CheckDetailsInfo model = new CheckDetailsInfo();
            if (Common_Func.readerExists(dr, "ID")) model.ID = dr["ID"].ToInt32();
            if (Common_Func.readerExists(dr, "CheckID")) model.CheckID = dr["CheckID"].ToInt32();
            if (Common_Func.readerExists(dr, "WarehouseNo")) model.WarehouseNo = dr["WarehouseNo"].ToDBString();
            if (Common_Func.readerExists(dr, "HouseNo")) model.HouseNo = dr["HouseNo"].ToDBString();
            if (Common_Func.readerExists(dr, "AreaNo")) model.AreaNo = dr["AreaNo"].ToDBString();
            if (Common_Func.readerExists(dr, "MaterialNo")) model.MaterialNo = dr["MaterialNo"].ToDBString();
            if (Common_Func.readerExists(dr, "MaterialDesc")) model.MaterialDesc = dr["MaterialDesc"].ToDBString();
            if (Common_Func.readerExists(dr, "AccountQty")) model.AccountQty = dr["AccountQty"].ToDecimal();
            if (Common_Func.readerExists(dr, "ScanQty")) model.ScanQty = dr["ScanQty"].ToDecimal();
            if (Common_Func.readerExists(dr, "Status")) model.Status = dr["Status"].ToInt32();
            if (Common_Func.readerExists(dr, "StockTime")) model.StockTime = dr["StockTime"].ToDateTimeNull();
            if (Common_Func.readerExists(dr, "Operator")) model.Operator = dr["Operator"].ToDBString();
            if (Common_Func.readerExists(dr, "OperationTime")) model.OperationTime = dr["OperationTime"].ToDateTimeNull();
            if (Common_Func.readerExists(dr, "ProfitLoss")) model.ProfitLoss = dr["ProfitLoss"].ToInt32();
            if (Common_Func.readerExists(dr, "DifferenceQty")) model.DifferenceQty = dr["DifferenceQty"].ToDecimal();
            if (Common_Func.readerExists(dr, "IsDel")) model.IsDel = dr["ISDEL"].ToInt32();
            if (Common_Func.readerExists(dr, "Creater")) model.Creater = dr["CREATER"].ToDBString();
            if (Common_Func.readerExists(dr, "CreateTime")) model.CreateTime = dr["CREATETIME"].ToDateTime();
            if (Common_Func.readerExists(dr, "Modifyer")) model.Modifyer = dr["MODIFYER"].ToDBString();
            if (Common_Func.readerExists(dr, "ModifyTime")) model.ModifyTime = dr["MODIFYTIME"].ToDateTimeNull();

            if (Common_Func.readerExists(dr, "WarehouseName")) model.WarehouseName = dr["WarehouseName"].ToDBString();
            if (Common_Func.readerExists(dr, "HouseName")) model.HouseName = dr["HouseName"].ToDBString();
            if (Common_Func.readerExists(dr, "AreaName")) model.AreaName = dr["AreaName"].ToDBString();
            if (Common_Func.readerExists(dr, "StrStatus")) model.StrStatus = dr["StrStatus"].ToDBString();
            if (Common_Func.readerExists(dr, "IsChecked")) model.BIsChecked = dr["IsChecked"].ToBoolean();

            model.StrHaveDiff = model.HaveDiff.ToBoolean() ? "有差异" : "无差异";

            return model;
        }

        public bool GetCheckDetailsSelectListByPage(ref List<CheckDetailsInfo> modelList, CheckDetailsInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            if (page == null) page = new DividPage();
            List<CheckDetailsInfo> lstModel = new List<CheckDetailsInfo>();
            try
            {
                string ViewName = string.Empty;
                string FiltSql = string.Empty;
                string SortSql = string.Empty;
                if (!GetSelectListFilterSql(model, user, ref ViewName, ref FiltSql, ref SortSql))
                {
                    strError = "获取盘点选择视图错误";
                    return false;
                }

                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, ViewName, FiltSql, "V.*", SortSql))
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

        private bool GetSelectListFilterSql(CheckDetailsInfo model, UserInfo user, ref string ViewName, ref string FiltSql, ref string SortSql)
        {
            string strSql = string.Empty;
            bool hadWhere = false;
            try
            {

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

                if (model.HaveDiff >= 1)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " nvl(HaveDiff,2) = " + model.HaveDiff + " ";
                    hadWhere = true;
                }

                if (model.CheckYetMonth >= 1)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " nvl(CheckTime,to_date('1900-01-01','yyyy-mm-dd')) <= add_months(" + DateTime.Now.Date.ToSqlTimeString() + ",-" + model.CheckYetMonth + ") ";
                    hadWhere = true;
                }

                if (model.StartTime != null)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " StockTime >= " + model.StartTime.ToDateTime().Date.ToSqlTimeString() + " ";
                    hadWhere = true;
                }

                if (model.EndTime != null)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " nvl(StockTime,to_date('1900-01-01','yyyy-mm-dd')) <= " + model.EndTime.ToDateTime().AddDays(1).Date.ToSqlTimeString() + " ";
                    hadWhere = true;
                }
            }
            catch
            {
                strSql = string.Empty;
            }

            switch (model.CheckType)
            {
                case 1:
                    if (model.CheckID <= 0)
                    {
                        ViewName = "V_CheckWarehouse V";
                    }
                    else
                    {
                        ViewName = string.Format("(select (case when t.warehouseno is not null then 2 else 1 end) IsChecked, v.* from V_CheckWarehouse v left join ( select distinct WAREHOUSENO from v_Checkdetails where CheckID = {0}) t on v.WAREHOUSENO = t.warehouseno) V", model.CheckID);
                    }
                    FiltSql = strSql;
                    SortSql = "Order By nvl(StockTime,to_date('1900-01-01','yyyy-mm-dd')) desc,WarehouseNo,WarehouseName";
                    return true;

                case 2:
                    if (model.CheckID <= 0)
                    {
                        ViewName = "V_CheckHouse V";
                    }
                    else
                    {
                        ViewName = string.Format("(select (case when t.houseno is not null then 2 else 1 end) IsChecked, v.* from V_CheckHouse v left join ( select distinct WAREHOUSENO, HOUSENO from v_Checkdetails where CheckID = {0}) t on v.WAREHOUSENO = t.warehouseno and v.HOUSENO = t.houseno) V", model.CheckID);
                    }
                    FiltSql = strSql;
                    SortSql = "Order By nvl(StockTime,to_date('1900-01-01','yyyy-mm-dd')) desc,HouseNo,HouseName";
                    return true;

                case 3:
                    if (model.CheckID <= 0)
                    {
                        ViewName = "V_CheckArea V";
                    }
                    else
                    {
                        ViewName = string.Format("(select (case when t.areano is not null then 2 else 1 end) IsChecked, v.* from V_CheckArea v left join ( select distinct WAREHOUSENO, HOUSENO, AREANO from v_Checkdetails where CheckID = {0}) t on v.WAREHOUSENO = t.warehouseno and v.HOUSENO = t.houseno and v.AREANO = t.areano) V", model.CheckID);
                    }
                    FiltSql = strSql;
                    SortSql = "Order By nvl(StockTime,to_date('1900-01-01','yyyy-mm-dd')) desc,AreaNo,AreaName";
                    return true;

                case 4:
                    if (model.CheckID <= 0)
                    {
                        ViewName = "V_CheckMaterial V";
                    }
                    else
                    {
                        ViewName = string.Format("(select (case when t.materialno is not null then 2 else 1 end) IsChecked, v.* from V_CheckMaterial v left join ( select distinct MATERIALNO from v_Checkdetails where CheckID = {0}) t on v.MATERIALNO = t.materialno) V", model.CheckID);
                    }
                    FiltSql = strSql;
                    SortSql = "Order By nvl(StockTime,to_date('1900-01-01','yyyy-mm-dd')) desc,MaterialNo,MaterialDesc";
                    return true;

                default:
                    return false;
            }
        }
    }
}
