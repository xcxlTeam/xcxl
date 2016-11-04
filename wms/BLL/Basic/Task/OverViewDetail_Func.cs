using BLL.Basic.User;
using BLL.Common;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Basic.Task
{
    public class OverViewDetail_Func
    {
        public bool GetOverViewDetailByPage(ref List<OverViewDetailInfo> modelList, OverViewDetailInfo model, ref DividPage page, UserInfo user, ref string strError)
        { 
            if (page == null) page = new DividPage();
            List<OverViewDetailInfo> lstModel = new List<OverViewDetailInfo>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_OverViewDetail", GetFilterSql(model, user)))
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

        private string GetFilterSql(OverViewDetailInfo model, UserInfo user)
        {
            try
            {
                string strSql = " Where ISNULL(MaterialNo,TMaterialNo) is not null ";
                bool hadWhere = true;

                if (model.Task_ID >= 1)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " Task_ID = " + model.Task_ID + " ";
                    hadWhere = true;
                }

                if (model.Status >= 1)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " Status = " + model.Status + " ";
                    hadWhere = true;
                }

                if (model.IsQualityComp >= 1)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " IsQualityComp = " + model.IsQualityComp + " ";
                    hadWhere = true;
                }


                return strSql;
            }
            catch
            {
                return string.Empty;
            }
        }

        private OverViewDetailInfo GetModelFromDataReader(SqlDataReader dr)
        {
            OverViewDetailInfo model = new OverViewDetailInfo();
            model.ID = dr["ID"].ToInt32();
            model.ToAreaNo = dr["ToAreaNo"].ToDBString();
            model.MaterialNo = dr["MaterialNo"].ToDBString();
            model.MaterialDesc = dr["MaterialDesc"].ToDBString();
            model.TaskQty = dr["TaskQty"].ToDecimal();
            model.QualityQty = dr["QualityQty"].ToDecimal();
            model.RemainQty = dr["RemainQty"].ToDecimal();
            model.ShelveQty = dr["ShelveQty"].ToDecimal();
            model.Status = dr["Status"].ToInt32();
            model.IsQualityComp = dr["IsQualityComp"].ToInt32();
            model.KeeperUserNo = dr["KeeperUserNo"].ToDBString();
            model.OperatorUserNo = dr["OperatorUserNo"].ToDBString();
            model.CompleteDateTime = dr["CompleteDateTime"].ToDateTimeNull();
            model.Task_ID = dr["Task_ID"].ToInt32();
            model.TMaterialNo = dr["TMaterialNo"].ToDBString();
            model.TMaterialDesc = dr["TMaterialDesc"].ToDBString();
            model.OperatorDateTime = dr["OperatorDateTime"].ToDateTimeNull();
            model.ReviewQty = dr["ReviewQty"].ToDecimal();
            model.PackCount = dr["PackCount"].ToInt32();
            model.ShelvePackCount = dr["ShelvePackCount"].ToInt32();
            model.VoucherNo = dr["VoucherNo"].ToDBString();
            model.RowNo = dr["RowNo"].ToDBString();
            model.CreateDate = dr["CreateDate"].ToDateTimeNull();
            model.TrackNo = dr["TrackNo"].ToDBString();
            model.Unit = dr["Unit"].ToDBString();
            model.UnQualityQty = dr["UnQualityQty"].ToDecimal();
            model.PostQty = dr["PostQty"].ToDecimal();
            model.StrStatus = dr["StrStatus"].ToDBString();
            model.StrIsQualityComp = dr["StrIsQualityComp"].ToDBString();
            model.KeeperUserName = dr["KeeperUserName"].ToDBString();
            model.OperatorUserName = dr["OperatorUserName"].ToDBString();

            return model;
        }
    }
}
