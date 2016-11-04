using BLL.Basic.User;
using BLL.Common;
using BLL.Material;
using BLL.OutStock;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BLL.Check
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

            List<CheckDetailsInfo> lstModel = new List<CheckDetailsInfo>();

            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_CheckDetails", GetFilterAndGroupSql(model, user), GetFieldsSql(model, user), "Order By CheckID Desc"))
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
                    switch (model.CheckType)
                    {
                        case 1:
                            strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                            strSql += " (AreaNo LIKE '%" + model.AreaNo + "%' OR AreaName LIKE '%" + model.AreaNo + "%') ";
                            hadWhere = true;
                            break;

                        case 2:
                            strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                            strSql += " (HouseNo LIKE '%" + model.AreaNo + "%' OR HouseName LIKE '%" + model.AreaNo + "%') ";
                            hadWhere = true;
                            break;

                        case 3:
                            strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                            strSql += " (WarehouseNo LIKE '%" + model.AreaNo + "%' OR WarehouseName LIKE '%" + model.AreaNo + "%') ";
                            hadWhere = true;
                            break;

                        case 4:
                        case 5:
                            strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                            strSql += " (MaterialNo LIKE '%" + model.AreaNo + "%' OR MaterialDesc LIKE '%" + model.AreaNo + "%') ";
                            hadWhere = true;
                            break;
                    }
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

                if (model.HaveDiff >= 1)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    if (model.HaveDiff.ToBoolean())
                        strSql += " ProfitLoss <> 1 ";
                    else
                        strSql += " ProfitLoss = 1 ";
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

        private string GetFilterAndGroupSql(CheckDetailsInfo model, UserInfo user)
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
                    strSql += " (MaterialNo LIKE '%" + model.MaterialNo + "%' OR MaterialDesc LIKE '%" + model.MaterialNo + "%' OR MaterialStd LIKE '%" + model.MaterialNo + "%')";

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

                //if (!string.IsNullOrEmpty(model.Creater))
                //{
                //    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                //    strSql += " Creater Like '%" + model.Creater + "%' ";
                //    hadWhere = true;
                //}

                //if (model.StartTime != null)
                //{
                //    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                //    strSql += " CreateTime >= " + model.StartTime.ToDateTime().Date.ToOracleTimeString() + " ";
                //    hadWhere = true;
                //}

                //if (model.EndTime != null)
                //{
                //    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                //    strSql += " CreateTime <= " + model.EndTime.ToDateTime().AddDays(1).Date.ToOracleTimeString() + " ";
                //    hadWhere = true;
                //}

                switch (model.CheckType)
                {
                    case 1:
                        strSql += " group by CheckID,CheckNo, WarehouseNo, WarehouseName ";
                        break;

                    case 2:
                        strSql += " group by CheckID,CheckNo, WarehouseNo, WarehouseName, HouseNo, HouseName ";
                        break;

                    case 3:
                        strSql += " group by CheckID,CheckNo, WarehouseNo, WarehouseName, HouseNo, HouseName, AreaNo, AreaName ";
                        break;

                    case 4:
                        strSql += " group by CheckID,CheckNo, WarehouseNo, WarehouseName,MaterialNo ,MaterialDesc,MaterialStd";
                        break;

                    case 5:
                        strSql += " group by CheckID,CheckNo, Keeper, WarehouseNo, WarehouseName, MaterialNo ";
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
                    strSql = "CheckID,CheckNo, WarehouseNo, WarehouseName, Max(AccountQty) AccountQty, Max(StockTime) StockTime ";
                    break;

                case 2:
                    strSql = "CheckID,CheckNo, WarehouseNo, WarehouseName, HouseNo, HouseName, Max(AccountQty) AccountQty, Max(StockTime) StockTime ";
                    break;

                case 3:
                    strSql = "CheckID,CheckNo, WarehouseNo, WarehouseName, HouseNo, HouseName, AreaNo, AreaName, Max(AccountQty) AccountQty, Max(StockTime) StockTime ";
                    break;

                case 4:
                    strSql = "CheckID,CheckNo, WarehouseNo, WarehouseName, MaterialNo, MaterialDesc,MaterialStd, Max(AccountQty) AccountQty, Max(StockTime) StockTime ";
                    break;

                case 5:
                    strSql = "CheckID,CheckNo, Keeper, WarehouseNo, WarehouseName, MaterialNo, MaterialDesc,MaterialStd, Max(AccountQty) AccountQty, Max(StockTime) StockTime ";
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
            if (Common_Func.readerExists(dr, "MaterialStd")) model.MaterialStd = dr["MaterialStd"].ToDBString();
            if (Common_Func.readerExists(dr, "Keeper")) model.Keeper = dr["Keeper"].ToDBString();
            if (Common_Func.readerExists(dr, "AccountQty")) model.AccountQty = dr["AccountQty"].ToDecimal();
            if (Common_Func.readerExists(dr, "ScanQty")) model.ScanQty = dr["ScanQty"].ToDecimal();
            if (Common_Func.readerExists(dr, "Status")) model.Status = dr["Status"].ToInt32();
            if (Common_Func.readerExists(dr, "StockTime")) model.StockTime = dr["StockTime"].ToDateTimeNull();
            if (Common_Func.readerExists(dr, "Operator")) model.Operator = dr["Operator"].ToDBString();
            if (Common_Func.readerExists(dr, "OperationTime")) model.OperationTime = dr["OperationTime"].ToDateTimeNull();
            if (Common_Func.readerExists(dr, "ProfitLoss")) model.ProfitLoss = dr["ProfitLoss"].ToInt32();
            if (Common_Func.readerExists(dr, "DifferenceQty")) model.DifferenceQty = dr["DifferenceQty"].ToDecimal();
            //if (Common_Func.readerExists(dr, "IsDel")) model.IsDel = dr["ISDEL"].ToInt32();
            //if (Common_Func.readerExists(dr, "Creater")) model.Creater = dr["CREATER"].ToDBString();
            //if (Common_Func.readerExists(dr, "CreateTime")) model.CreateTime = dr["CREATETIME"].ToDateTime();
            //if (Common_Func.readerExists(dr, "Modifyer")) model.Modifyer = dr["MODIFYER"].ToDBString();
            //if (Common_Func.readerExists(dr, "ModifyTime")) model.ModifyTime = dr["MODIFYTIME"].ToDateTimeNull();

            if (Common_Func.readerExists(dr, "CheckNo")) model.CheckNo = dr["CheckNo"].ToDBString();
            if (Common_Func.readerExists(dr, "strCheckType")) model.strCheckType = dr["strCheckType"].ToDBString();
            if (Common_Func.readerExists(dr, "WarehouseName")) model.WarehouseName = dr["WarehouseName"].ToDBString();
            if (Common_Func.readerExists(dr, "HouseName")) model.HouseName = dr["HouseName"].ToDBString();
            if (Common_Func.readerExists(dr, "AreaName")) model.AreaName = dr["AreaName"].ToDBString();
            if (Common_Func.readerExists(dr, "StrStatus")) model.StrStatus = dr["StrStatus"].ToDBString();
            if (Common_Func.readerExists(dr, "IsChecked")) model.BIsChecked = dr["IsChecked"].ToBoolean();
            if (Common_Func.readerExists(dr, "StrProfitLoss")) model.StrProfitLoss = dr["StrProfitLoss"].ToDBString();
            if (Common_Func.readerExists(dr, "StrHaveDiff")) model.StrHaveDiff = dr["StrHaveDiff"].ToDBString();

            return model;
        }

        public bool GetCheckDetailsSelectListByPage(ref List<CheckDetailsInfo> modelList, CheckDetailsInfo model, ref DividPage page, UserInfo user, ref string strError)
        {

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
            string strSql = "";
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
                    strSql += " (MaterialNo LIKE '%" + model.MaterialNo + "%' OR MaterialDesc LIKE '%" + model.MaterialNo + "%' OR MaterialStd LIKE '%"+ model.MaterialNo+ "%')";
                    hadWhere = true;
                }

                if (model.HaveDiff >= 1)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " HaveDiff = " + model.HaveDiff + " ";
                    hadWhere = true;
                }

                if (model.AccountQty >= 1)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " AccountQty = " + model.AccountQty + " ";
                    hadWhere = true;
                }

                if (model.CheckYetMonth >= 1)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " ISNULL(CheckTime,cast('1900-01-01' as datetime)) <= add_months(" + DateTime.Now.Date.ToSqlTimeString() + ",-" + model.CheckYetMonth + ") ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.Keeper) && model.CheckType == 5)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " Keeper = '" + model.Keeper + "' ";
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
                    strSql += " isnull(StockTime,cast('1900-01-01' as datetime)) <= " + model.EndTime.ToDateTime().AddDays(1).Date.ToSqlTimeString() + " ";
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
                    ViewName = "V_CheckWarehouse V";
                    FiltSql = strSql;
                    SortSql = "Order By ISNULL(StockTime,cast('1900-01-01' as datetime)) desc,WarehouseNo,WarehouseName";
                    return true;

                case 2:
                    ViewName = "V_CheckHouse V";
                    FiltSql = strSql;
                    SortSql = "Order By ISNULL(StockTime,cast('1900-01-01' as datetime)) desc,HouseNo,HouseName";
                    return true;

                case 3:
                    ViewName = "V_CheckArea V";
                    FiltSql = strSql;
                    SortSql = "Order By ISNULL(StockTime,cast('1900-01-01' as datetime)) desc,AreaNo,AreaName";
                    return true;

                case 4:
                    ViewName = "V_CheckMaterial V";
                    FiltSql = strSql;
                    SortSql = "Order By ISNULL(StockTime,cast('1900-01-01' as datetime)) desc,MaterialNo,MaterialDesc";
                    return true;

                case 5:

                    GetKeeperMaterial(model);

                    ViewName = "V_CheckKeeper V";
                    FiltSql = strSql;
                    SortSql = "Order By ISNULL(StockTime,cast('1900-01-01' as datetime)) desc,Keeper,MaterialNo,MaterialDesc";
                    return true;

                default:
                    return false;
            }
        }

        private void GetKeeperMaterial(CheckDetailsInfo model)
        {
            ////获取保管员信息
            //List<OutStockDetails_Model> lstKeeper = GetKeeperList(model.Keeper);
            //if (lstKeeper == null || lstKeeper.Count <= 0)
            //    throw new Exception("获取不到对应的保管员信息!");

            //Material_SAP msap = new Material_SAP();
            //string strError = string.Empty;
            //List<Material_Model> lstMaterial = new List<Material_Model>();
            //if (!msap.GetMaterialNoByKeeperForSAP(lstKeeper, ref lstMaterial, ref strError))
            //    throw new Exception(strError);
            //if (lstMaterial == null || lstMaterial.Count <= 0)
            //    throw new Exception("获取不到保管员对应的SAP物料信息!");

            ////是否需要更新WMS保管员信息
            ////if (!_db.NeedUpdateKeeperInfo(lstMaterial)) return;

            ////更新WMS保管员信息
            ////while (lstMaterial.Count >= 20)
            ////{
            ////    _db.UpdateKeeperInfo(lstKeeper, lstMaterial.GetRange(0, 20));
            ////    lstMaterial.RemoveRange(0, 20);
            ////}
            //if (lstMaterial.Count >= 1)
            //    _db.UpdateKeeperInfo(lstKeeper, lstMaterial);
        }

        private List<OutStockDetails_Model> GetKeeperList(string keeperno)
        {
            List<OutStockDetails_Model> lstKeeper = new List<OutStockDetails_Model>();
            try
            {
                OutStockDetails_Model keeper;
                using (SqlDataReader dr = _db.GetKeeperList(keeperno))
                {
                    while (dr.Read())
                    {
                        keeper = new OutStockDetails_Model();
                        keeper.MaterialKeeperNo = dr["UserNo"].ToDBString();
                        keeper.MaterialKeeperName = dr["UserName"].ToDBString();
                        lstKeeper.Add(keeper);
                    }
                }

                return lstKeeper;
            }
            catch //(Exception ex)
            {
                return lstKeeper;
            }
        }


        public bool GetCheckAnalyseListByPage(ref List<CheckDetailsInfo> modelList, CheckDetailsInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            if (!_db.UpdateCheckAnalyse(model, ref strError)) return false;

            List<CheckDetailsInfo> lstModel = new List<CheckDetailsInfo>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_CheckAnalyse", GetFilterSql(model, user), "*", "Order by OperationTime desc"))
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

        public List<CheckDetailsInfo> GetCheckDetailsListByCheckID(int checkID, ref string strError)
        {
            List<CheckDetailsInfo> lstModel = new List<CheckDetailsInfo>();

            try
            {
                using (SqlDataReader dr = _db.GetCheckDetailsListByCheckID(checkID))
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

        public List<CheckDetailsInfo> GetCheckMaterialListByCheckID(int checkID, ref string strError)
        {
            List<CheckDetailsInfo> lstModel = new List<CheckDetailsInfo>();

            try
            {
                using (SqlDataReader dr = _db.GetCheckMaterialListByCheckID(checkID))
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

        public bool ProfitLossAnalyse(ref List<CheckDetailsInfo> modelList, CheckDetailsInfo model, UserInfo user, ref string strError)
        {
            strError = "方法已弃用";
            return false;

            //List<CheckDetailsInfo> lstModel = new List<CheckDetailsInfo>();

            //try
            //{
            //    using (SqlDataReader dr = _db.GetCheckDetailsListByCheckID(model.CheckID))
            //    {
            //        while (dr.Read())
            //        {
            //            lstModel.Add(GetModelFromDataReader(dr));
            //        }
            //    }

            //    modelList = lstModel;

            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    strError = ex.Message;
            //    return false;
            //}
            //finally
            //{
            //}
        }
    }
}
