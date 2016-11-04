using BLL.Common;
using BLL.Task;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.FastIn
{
    public class FastIn_Func
    {
        #region 快速入查询

        public bool QueryFastInList(Task_Model taskModel, string BeginTime, string EndTime, ref DividPage dividpage, ref List<Task_Model> lsttask, ref string strErrMsg)
        {
            if (dividpage == null) dividpage = new DividPage();
            lsttask = new List<Task_Model>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref dividpage, "v_queryfastinlist", GetFilterSql(taskModel, BeginTime, EndTime), "*", "Order by CREATEDATETIME desc"))
                {
                    while (dr.Read())
                    {
                        lsttask.Add(GetModelFromDataReader(dr));
                    }
                    dividpage.CurrentPageRecordCounts = lsttask.Count;
                }
                if (lsttask == null || lsttask.Count == 0)
                {
                    strErrMsg = "没有快速入库单信息！";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
        }

        public bool DeleteFastIn(string ID, BLL.Basic.User.UserInfo userModel, ref string strErrMsg)
        {
            return new FastIn_DB().DeleteFastIn(ID, userModel, ref strErrMsg);
        }

        public bool GetFastInInfo(Task_Model taskModel, ref DividPage dividpage, ref List<Task_Model> lsttask, ref string strErrMsg)
        {
            if (dividpage == null) dividpage = new DividPage();
            lsttask = new List<Task_Model>();
            try
            {
                //using (SqlDataReader dr = Common_DB.QueryByDividPage(ref dividpage, "v_fastin", GetFilterSql(taskModel)))
                //{
                //    while (dr.Read())
                //    {
                //        lsttask.Add(GetModelFromDataReader(dr));
                //    }
                //    dividpage.CurrentPageRecordCounts = lsttask.Count;
                //}
                if (lsttask == null || lsttask.Count == 0)
                {
                    strErrMsg = "没有快速入库单信息！";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
        }

        private string GetFilterSql(Task_Model task_Model, string BeginTime, string EndTime)
        {
            //单据号，制单人，物料凭证，任务号，日期，状态，供应商,出库类型,任务类型
            string VOUCHERNO = task_Model.VoucherNo;//单据号
            string MaterialDoc = task_Model.MaterialDoc;//物料凭证号
            string TASKNO = task_Model.TaskNo;//上架任务号
            string STATUS = task_Model.TaskStatus.ToString();//状态
            string SupCusNo = task_Model.SupCusNo;//供应商
            string CREATEUSERNO = task_Model.CreateUserNo;//制单人

            //VOUCHERTYPE=50快速入
            string sql = @" where (VOUCHERTYPE= '50' or VOUCHERTYPE= '60') ";
            if (VOUCHERNO != null && VOUCHERNO.Length > 0)
            {
                sql += " and VOUCHERNO = '" + VOUCHERNO + "' ";
            }
            if (MaterialDoc != null && MaterialDoc.Length > 0)
            {
                sql += " and MATERIALDOC = '" + MaterialDoc + "' ";
            }
            if (CREATEUSERNO != null && CREATEUSERNO.Length > 0)
            {
                sql += " and CREATEUSERNO like '%" + CREATEUSERNO + "%' ";
            }
            if (STATUS != null && STATUS.Length > 0 && STATUS != "1")
            {
                sql += " and TASKSTATUS = " + STATUS + " ";
            }
            if (SupCusNo != null && SupCusNo.Length > 0)
            {
                sql += " and SUPCUSNO = '" + SupCusNo + "' ";
            }
            if (TASKNO != null && TASKNO.Length > 0)
            {
                sql += " and TASKNO = '" + TASKNO + "' ";
            }
            if (BeginTime != null && EndTime != null && BeginTime.Length > 0 && EndTime.Length > 0)
            {
                sql += "and createdatetime between to_date('" + BeginTime + "','YYYY/MM/DD') and to_date('" + EndTime + "','YYYY/MM/DD') + 1";
            }
            else if (BeginTime != null && BeginTime.Length > 0)
            {
                sql += "and createdatetime>=to_date('" + BeginTime + "','YYYY/MM/DD') ";
            }
            else if (EndTime != null && EndTime.Length > 0)
            {
                sql += "and createdatetime<=to_date('" + EndTime + "','YYYY/MM/DD') + 1 ";
            }
            return sql;
        }

        public Task_Model GetModelFromDataReader(SqlDataReader dr)
        {
            //序号，物料凭证，单据号，上架任务号，状态，制单人，制单日期，入库原因，备注，供应商
            Task_Model TMM = new Task_Model();
            //TMM.ID = Convert.ToInt32(drTask_Model"ID"]);
            TMM.ID = Convert.ToInt32(dr["ID"]);
            TMM.ShelvePost = dr["SHELVEPOST"].ToString();
            TMM.MaterialDoc = dr["MATERIALDOC"].ToString();
            TMM.VoucherNo = dr["voucherno"].ToString();
            TMM.TaskNo = dr["TASKNO"].ToString();
            TMM.StatusName = dr["STATUS"].ToString();
            TMM.CreateUserNo = dr["CREATEUSERNO"].ToString();
            if (dr["CREATEDATETIME"] is DBNull)
                TMM.CreateDateTime = DateTime.MinValue;
            else
                TMM.CreateDateTime = DateTime.Parse(dr["CREATEDATETIME"].ToString());
            TMM.Reason = dr["REASON"].ToString();
            TMM.Remark = dr["REMARK"].ToString();
            TMM.SupCusName = dr["SUPCUSNAME"].ToString();
            TMM.SupCusNo = dr["SUPCUSNO"].ToString();
            return TMM;
        }

        #endregion

        #region 快速入保存
        public bool GetNewTASKNO(ref string TASKNO, ref string ErrMsg)
        {
            return new FastIn_DB().GetNewTASKNO(ref TASKNO, ref ErrMsg);
        }
        public bool SaveFastIn(Task_Model head, BLL.Basic.User.UserInfo userModel, ref string strErrMsg)
        {
            return new FastIn_DB().SaveFastIn(head, userModel, ref strErrMsg);
        }

        public bool SavePostFastIn(Task_Model head, BLL.Basic.User.UserInfo userModel, TaskVoucher tv, ref string strErrMsg)
        {
            return new FastIn_DB().SavePostFastIn(head, userModel, tv, ref strErrMsg);
        }
        #endregion

        #region 快速入修改
        public bool GetFastInByID(string ID, ref Task_Model head, ref TaskVoucher tv, ref string strErrMsg)
        {
            return new FastIn_DB().GetFastInByID(ID, ref head, ref tv, ref strErrMsg);
        }

        public bool UpdateFastIn(string ID, Task_Model head, string[] lst_delID, ref string strErrMsg)
        {
            return new FastIn_DB().UpdateFastIn(ID, head, lst_delID, ref strErrMsg);
        }

        public bool UpdatePostFastIn(string ID, Task_Model head, TaskVoucher tv, string[] lst_delID, ref string strErrMsg)
        {
            return new FastIn_DB().UpdatePostFastIn(ID, head, tv, lst_delID, ref strErrMsg);
        }
        public bool GetVoucherByNo(string NO, ref TaskVoucher tv, ref string strErrMsg)
        {
            return new FastIn_DB().GetVoucherByNo(NO, ref tv, ref strErrMsg);
        }
        #endregion

        #region 快速入过账
        //public bool PostFastIn(string ID, JXBLL.Basic.User.UserInfo userModel, ref string strErrMsg)
        //{
        //    return new FastIn_DB().PostFastInByID(ID, userModel, ref strErrMsg);
        //}
        #endregion
    }
}
