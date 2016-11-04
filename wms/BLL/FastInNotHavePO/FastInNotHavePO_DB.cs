using BLL.Common;
using BLL.Task;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL.FastInNotHavePO
{
    public class FastInNotHavePO_DB
    {
        //查询无PO快速入库数据
        public bool GetFastInNotHavePOInfo(Task_Model taskmo, ref DividPage dividpage, ref List<Task_Model> lsttask, ref string strErrMsg)
        {
            if (dividpage == null) dividpage = new DividPage();
            lsttask = new List<Task_Model>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref dividpage, GetSql(taskmo), GetFilterSql(taskmo)))
                {
                    Console.Write(GetSql(taskmo) +"\n"+GetFilterSql(taskmo));
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

        private string GetSql(Task_Model taskmo)
        {
            string sql = "select v.voucherno,r.MATERIALDOC, t.*  from t_task  t left join t_taskandvoucherno v on t.id = v.taskid left join t_receivematerialdoc r on  t.id = r.task_id where 1=1 ";

            connectSql(taskmo, ref sql);

            return sql;
        }

        private Task_Model GetModelFromDataReader(SqlDataReader dr)
        {
            //序号，物料凭证，单据号，上架任务号，状态，制单人，制单日期，入库原因，备注，供应商
            Task_Model task_Model = new Task_Model();
            task_Model.ID = Convert.ToInt32(dr["ID"]);

            task_Model.IsShelvePost = int.Parse(dr["ISSHELVEPOST"].ToString());
            switch (task_Model.IsShelvePost)
            {
                //case 1: task_Model.IsPost = "不过账"; break;
                //case 2: task_Model.IsPost = "过账"; break;
            }

            task_Model.MaterialDoc = dr["MATERIALDOC"].ToString();
            //task_Model.VoucherNo = dr["VOUCHERNO"].ToString();
            task_Model.TaskNo = dr["TASKNO"].ToString();

            int sta = Convert.ToInt32(dr["TASKSTATUS"]);
            switch (sta)
            {
                case 1: task_Model.StatusName = "全部"; break;
                case 2: task_Model.StatusName = "已下发"; break;
                case 3: task_Model.StatusName = "未下发"; break;
                case 4: task_Model.StatusName = "已完成"; break;
                case 5: task_Model.StatusName = "已取消"; break;
                case 6: task_Model.StatusName = "SAP已过账"; break;
            }
            task_Model.CreateUserNo = dr["CREATEUSERNO"].ToString();
            if (dr["CREATEDATETIME"] is DBNull)
                task_Model.CreateDateTime = DateTime.MinValue;
            else
                task_Model.CreateDateTime = DateTime.Parse(dr["CREATEDATETIME"].ToString());
            task_Model.Reason = dr["REASON"].ToString();
            task_Model.Remark = dr["Remark"].ToString();
            task_Model.SupCusName = dr["SUPCUSNAME"].ToString();

            return task_Model;
           
        }

        private string GetFilterSql(Task_Model taskmo)
        {
            string sql = "select count(1) as recordcounts   from t_task  t left join t_taskandvoucherno v on t.id = v.taskid left join t_receivematerialdoc r on  t.id = r.task_id where 1=1 ";

            connectSql(taskmo, ref sql);

            return sql;
        
        }

        private void connectSql(Task_Model taskmo,ref string sql)
        {
            string sqlTemp = string.Empty;

            //单据号，制单人，物料凭证，任务号，日期，状态，供应商,出库类型,任务类型
            string VOUCHERNO = string.Empty;
            string CREATEUSERNO = taskmo.CreateUserNo;
            string SAPMATERIALDOC = taskmo.MaterialDoc;
            string TASKNO = taskmo.TaskNo;
            string begintime = taskmo.CreateDateTime.ToString();
            //string endtime = taskmo.EndTime;
            string STATUS = taskmo.StatusName;
            string SupCusName = taskmo.SupCusName;

            if (string.IsNullOrEmpty(VOUCHERNO))
            {
                sqlTemp += " and v.voucherno = '" + VOUCHERNO + "'";
            }
            if (string.IsNullOrEmpty(CREATEUSERNO))
            {
                sqlTemp += " and CREATEUSERNO = '" + CREATEUSERNO + "'";
            }
            if (string.IsNullOrEmpty(SAPMATERIALDOC))
            {
                sqlTemp += " and r.MATERIALDOC = '" + SAPMATERIALDOC + "'";
            }
            if (string.IsNullOrEmpty(TASKNO))
            {
                sqlTemp += " and TASKNO ='" + TASKNO + "'";
            }

            if (string.IsNullOrEmpty(begintime))
            {
                sql += "and createdatetime>=to_date('" + begintime + "','YYYY/MM/DD') ";
            }
            
            if (STATUS != "1")
            {
                sql += " and Status = " + STATUS;
            }

            sql += sqlTemp;
        }

        //根据物料号获取物料描述
        public bool GetTempMaterialName(string materialNo, ref string materialDESC)
        {
            try
            {
                if (string.IsNullOrEmpty(materialNo))
                {
                    string sqlTemp = "select TEMPMATERIALDESC from T_TEMPMATERIAL where TEMPMATERIALNO='" + materialNo + "'";

                    using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, sqlTemp))
                    {
                        if (dr.Read())
                        {
                            materialDESC = dr["TEMPMATERIALDESC"].ToString();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }
        //插入数据
        public bool InsetMaterialDetail(List<TaskDetails_Model> tDtails, ref string msg)
        {
            //sql List
            List<string> SQL_list = new List<string>();
            if (tDtails.Count() > 0)
            {
                foreach (TaskDetails_Model tm in tDtails)
                {
                    string sqlStr;
                    string materialNo = tm.MaterialNo;
                    string materialDESC = tm.MaterialDesc;
                    decimal materialNUM = tm.QuanlityQty;


                    sqlStr = "insert into T_TASKDETAILS(MATERIALNO,MATERIALDESC,TASKQTY,)" +
                        "values('"+materialNo+"','"+materialDESC+"',"+materialNUM+")";

                    SQL_list.Add(sqlStr);
                }
            }
            try
            {
                int result = OperationSql.ExecuteNonQueryList(SQL_list);
                msg = "新增成功！";
                return true;
            }
            catch (Exception e)
            {
                msg = e.ToString();
                return false;
            }
        }

        //查询当前的物料号是否在临时物料表里
        public bool ExistsTempMaterialByMaterialNo(string materialNo)
        {
            string sql =  "select * from T_TEMPMATERIAL where TEMPMATERIALNO='" + materialNo + "'";

            using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text,sql))
            {
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
