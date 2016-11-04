using JXBLL.Basic.User;
using JXBLL.Common;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace JXBLL.Basic.Check
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
                using (SqlDataReader dr = _db.GetCheckByID(model))
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


        public bool GetCheckListByPage(ref List<CheckInfo> modelList, CheckInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            if (page == null) page = new DividPage();
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
                string strSql = " Where NVL(IsDel,1) = 1 ";
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
                    strSql += " DutyUser Like '%" + model.DutyUser + "%' ";
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
                    strSql += " CheckStatus = " + model.CheckStatus + " ";
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

            if (Common_Func.readerExists(dr, "StrCheckType")) model.StrCheckType = dr["StrCheckType"].ToDBString();
            if (Common_Func.readerExists(dr, "StrCheckStatus")) model.StrCheckStatus = dr["StrCheckStatus"].ToDBString();

            model.EditText = model.CheckStatus == 1 ? "编辑" : "查看";

            return model;
        }

    }
}
