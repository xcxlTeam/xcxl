using BLL.Basic.User;
using BLL.Common;
using BLL.JSONUtil;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BLL.Check
{
    public class Check_Func
    {
        private Check_DB _db = new Check_DB();


        public bool SaveCheck(ref CheckInfo model, UserInfo user, ref string strError)
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
                if (model.CheckStatus == 0)
                {
                    model.CheckStatus = 1;
                    model.StartTime = DateTime.Now;
                    model.DoneTime = DateTime.Now;

                }

                return _db.SaveCheck(ref model);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }


        public bool DeleteCheckByID(CheckInfo model, UserInfo user, ref string strError)
        {
            try
            {
                return _db.DeleteCheckByID(model);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }


        public bool GetCheckByID(ref CheckInfo model, UserInfo user, ref string strError)
        {
            try
            {
                CheckDetails_Func cdf = new CheckDetails_Func();
                using (SqlDataReader dr = _db.GetCheckByID(model))
                {
                    if (dr.Read())
                    {
                        model = (GetModelFromDataReader(dr));
                        //model.lstDetails = cdf.GetCheckDetailsListByCheckID(model.ID, ref strError);
                        if (!string.IsNullOrEmpty(strError)) return false;
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


        public bool GetCheckListByPage(ref List<CheckInfo> modelList, CheckInfo model, ref DividPage page, UserInfo user, ref string strError)
        {

            List<CheckInfo> lstModel = new List<CheckInfo>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_Check", GetFilterSql(model, user), "*", "Order By ID Desc"))
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

        private string GetFilterSql(CheckInfo model, UserInfo user)
        {
            try
            {
                string strSql = " Where ISNULL(IsDel,1) = 1 ";
                bool hadWhere = true;


                if (!string.IsNullOrEmpty(model.CheckNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " CheckNo Like '%" + model.CheckNo + "%' ";
                    hadWhere = true;
                }

                if (model.CheckType >= 1)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " CheckType = " + model.CheckType + " ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.DutyUser))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    if (model.CheckStatus == 10)
                    {
                        strSql += string.Format(" (case checktype when 5 then DutyUser when 4 then DutyUser  else '{0}' end) = '{0}' ", model.DutyUser);
                    }
                    else
                    {
                        //strSql += " DutyUser Like '%" + model.DutyUser + "%' ";
                        strSql += " DutyUser = '" + model.DutyUser + "' ";
                    }
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.CheckDesc))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " CheckDesc Like '%" + model.CheckDesc + "%' ";
                    hadWhere = true;
                }

                if (model.CheckStatus >= 1)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    if (model.CheckStatus == 10)
                    {
                        strSql += " CheckStatus in (1,2) ";
                    }
                    else
                    {
                        strSql += " CheckStatus = " + model.CheckStatus + " ";
                    }
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.Remarks))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " Remarks Like '%" + model.Remarks + "%' ";
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

        private CheckInfo GetModelFromDataReader(SqlDataReader dr)
        {
            CheckInfo model = new CheckInfo();
            model.ID = dr["ID"].ToInt32();
            model.CheckNo = dr["CheckNo"].ToDBString();
            model.CheckType = dr["CheckType"].ToInt32();
            model.DutyUser = dr["DutyUser"].ToDBString();
            model.CheckDesc = dr["CheckDesc"].ToDBString();
            model.CheckStatus = dr["CheckStatus"].ToInt32();
            model.BeginTime = dr["BeginTime"].ToDateTimeNull();
            model.DoneTime = dr["DoneTime"].ToDateTimeNull();
            model.Remarks = dr["Remarks"].ToDBString();
            model.IsDel = dr["ISDEL"].ToInt32();
            model.Creater = dr["CREATER"].ToDBString();
            model.CreateTime = dr["CREATETIME"].ToDateTime();
            model.Modifyer = dr["MODIFYER"].ToDBString();
            model.ModifyTime = dr["MODIFYTIME"].ToDateTimeNull();
            if (Common_Func.readerExists(dr, "CheckStyle")) model.CheckStyle = dr["CheckStyle"].ToInt32();
            if (Common_Func.readerExists(dr, "MainCheckID")) model.MainCheckID = dr["MainCheckID"].ToInt32();
            if (Common_Func.readerExists(dr, "ReCheckCount")) model.ReCheckCount = dr["ReCheckCount"].ToInt32();

            if (Common_Func.readerExists(dr, "EditText")) model.EditText = dr["EditText"].ToDBString();
            if (Common_Func.readerExists(dr, "StrCheckType")) model.StrCheckType = dr["StrCheckType"].ToDBString();
            if (Common_Func.readerExists(dr, "StrCheckStatus")) model.StrCheckStatus = dr["StrCheckStatus"].ToDBString();
            if (Common_Func.readerExists(dr, "DifferenceQty")) model.DifferenceQty = dr["DifferenceQty"].ToDecimal();
            if (Common_Func.readerExists(dr, "StrCheckStyle")) model.StrCheckStyle = dr["StrCheckStyle"].ToDBString();

            model.StrCreateTime = model.CreateTime.ToSqlTimeString();
            model.StrModifyTime = model.ModifyTime.ToSqlTimeString();
            model.BIsMainCheck = model.CheckStyle == 1;
            if (!model.BIsMainCheck) model.EditText = "查看";

            return model;
        }

        public string GetCheckListForAndroid(string strUserJson)
        {
            List<CheckInfo> lstModel = new List<CheckInfo>();
            CheckHeader model = new CheckHeader();
            string strError = string.Empty;


            try
            {
                UserInfo user = JSONHelper.JsonToObject<UserInfo>(strUserJson);
                if (user == null || string.IsNullOrEmpty(user.UserNo))
                {
                    model.Status = "E";
                    model.Message = "传入用户错误!盘点单列表获取失败!";
                    return JSONHelper.ObjectToJson(model);
                }

                CheckInfo info = new CheckInfo() { CheckStatus = 10, DutyUser = user.UserNo };
                DividPage page = new DividPage() { CurrentPageShowCounts = -1 };
                bool bResult = GetCheckListByPage(ref lstModel, info, ref page, user, ref strError);

                if (bResult)
                {
                    CheckDetails_Func cdf = new CheckDetails_Func();
                    foreach (var item in lstModel)
                    {
                        item.lstDetails = cdf.GetCheckMaterialListByCheckID(item.ID,ref strError);
                    }
                    model.Status = "S";
                    model.lstCheck = lstModel;
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

        public bool UpdateCheckStatusByID(CheckInfo model, UserInfo user, ref string strError)
        {
            try
            {
                return _db.UpdateCheckStatusByID(model);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public bool ProfitLossDeal(CheckInfo model, UserInfo user, ref string strError)
        {
            try
            {
                return _db.Proc_ProfitLossDeal(model);
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

        public string GetCheckScanTransForAndroid(string strCheckJson, string strUserJson)
        {
            CheckInfo model = new CheckInfo();
            string strError = string.Empty;

            try
            {
                model = JSONHelper.JsonToObject<CheckInfo>(strCheckJson);
                if (model == null || model.ID <= 0)
                {
                    model = new CheckInfo();
                    model.Status = "E";
                    model.Message = "盘点单信息获取失败!";
                    return JSONHelper.ObjectToJson(model);
                }

                UserInfo user = JSONHelper.JsonToObject<UserInfo>(strUserJson);
                if (user == null || string.IsNullOrEmpty(user.UserNo))
                {
                    model.Status = "E";
                    model.Message = "用户信息获取失败!";
                    return JSONHelper.ObjectToJson(model);
                }

                bool bResult = GetCheckScanTrans(ref model, user, ref strError);

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

        private bool GetCheckScanTrans(ref CheckInfo model, UserInfo user, ref string strError)
        {
            try
            {
                CheckTrans_Func ctf = new CheckTrans_Func();
                model.lstScanTrans = ctf.GetCheckTransListByCheck(model, user, ref strError);
                if (model.lstScanTrans != null) model.SumScanQty = model.lstScanTrans.Sum(t => t.ScanQty);

                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public bool VerifyCheckStockChange(CheckInfo model, UserInfo user, ref string strError)
        {
            try
            {
                return _db.VerifyCheckStockChange(model);
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

        public bool ReCheckByCheck(CheckInfo model, ref CheckInfo reCheck, UserInfo user, ref string strError)
        {
            try
            {
                if (!_db.ReCheckByCheck(model, ref reCheck, user, ref strError))
                {
                    return false;
                }
                else
                {
                    if (!GetCheckByID(ref reCheck, user, ref strError))
                    {
                        strError = string.Format("复盘成功,获取复盘信息失败!{0}{1}:{2}", Environment.NewLine, reCheck.ID, strError);
                        return false;
                    }

                    return true;
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

    }
}
