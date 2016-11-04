using BLL.Task;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.FastIn
{
    public class FastIn_DB
    {
        string dbstr(string str)
        {
            if(str == null || str.Equals(string.Empty))
            {
                return "null";
            }
            else
            {
                return "'" + str + "'";
            }
        }
        public bool GetNewTASKNO(ref string TASKNO, ref string ErrMsg)
        {
            try
            {

                string strSql = "select to_char(SYSDATE,'yyyymmdd')||lpad(seq_taskno.nextval, 4, '0')  from dual ";

                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        TASKNO = dr[0].ToString();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        bool GetNewTASKID(ref int ID, ref string ErrMsg)
        {
            try
            {

                string strSql = "select seq_task.nextval from dual ";

                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        ID = Convert.ToInt32(dr[0]);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        bool GetNewTASKVoucherID(ref int ID, ref string ErrMsg)
        {
            try
            {

                string strSql = "select seq_taskandvoucherno.nextval from dual ";

                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        ID = Convert.ToInt32(dr[0]);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SaveFastIn(Task_Model head, BLL.Basic.User.UserInfo userModel, ref string strErrMsg)
        {
            strErrMsg = string.Empty;
            //获取TASK表ID
            int NewTASKID = 0;
            if (!GetNewTASKID(ref NewTASKID, ref strErrMsg))
            {
                strErrMsg = "获取TASK表ID失败:" + strErrMsg;
                return false;
            }
            //sql List
            List<string> SQL_list = new List<string>();
            if(head.IsShelvePost == 1)
            {
                SQL_list.Add("insert into T_TASK(ID,VOUCHERTYPE,TASKTYPE,TASKNO,SUPCUSNAME,SUPCUSNO,TASKSTATUS,CREATEDATETIME,REMARK,REASON,CREATEUSERNO,ISSHELVEPOST,ISQUALITY,RECEIVEUSERNO,taskissued,PostStatus)" +
                               "values(" + NewTASKID.ToString() + ",50,1,'" + head.TaskNo + "'," + dbstr(head.SupCusName) + "," + dbstr(head.SupCusNo) + ",2,sysdate," + dbstr(head.Remark) + "," + dbstr(head.Reason) + ",'" + head.CreateUserNo + "',1,1,'" + head.CreateUserNo + "',sysdate,4) ");
            }
            else
            {
                SQL_list.Add("insert into T_TASK(ID,VOUCHERTYPE,TASKTYPE,TASKNO,SUPCUSNAME,SUPCUSNO,TASKSTATUS,CREATEDATETIME,REMARK,REASON,CREATEUSERNO,ISSHELVEPOST,ISQUALITY,RECEIVEUSERNO,taskissued,PostStatus)" +
                               "values(" + NewTASKID.ToString() + ",60,1,'" + head.TaskNo + "'," + dbstr(head.SupCusName) + "," + dbstr(head.SupCusNo) + ",2,sysdate," + dbstr(head.Remark) + "," + dbstr(head.Reason) + ",'" + head.CreateUserNo + "',2,1,'" + head.CreateUserNo + "',sysdate,4) ");
            }
            foreach (TaskDetails_Model tm in head.lstTaskDetails)
            {
                string sqlStr;
                string materialNo = tm.MaterialNo;
                string materialDESC = tm.MaterialDesc;
                string tmaterialNo = tm.TMaterialNo;
                string tmaterialDESC = tm.TMaterialDesc;
                decimal materialNUM = tm.TaskQty;


                sqlStr = "insert into T_TASKDETAILS(ID,TASK_ID,VOUCHERNO,MATERIALNO,MATERIALDESC,TMATERIALNO,TMATERIALDESC,TASKQTY,REMAINQTY)" +
                    "values(seq_taskdetails.nextval," + NewTASKID.ToString() + ",'" + head.TaskNo + "','" + materialNo + "','" + materialDESC + "','" + tmaterialNo + "','" + tmaterialDESC + "'," + materialNUM + "," + materialNUM + ")";
                SQL_list.Add(sqlStr);
            }
            foreach(BLL.Basic.Warehouse.WarehouseInfo wi in userModel.lstWarehouse)
            {
                SQL_list.Add("insert into T_TASKWAREHOUSE (ID,TASK_ID,WAREHOUSE_ID,USER_ID)values(seq_taskwarehouse.nextval," + NewTASKID.ToString() + "," + wi.ID + "," + userModel.ID + ") ");
            }
            try
            {
                int result = OperationSql.ExecuteNonQueryList(SQL_list);
                strErrMsg = "新增成功！快速入库单号：" + head.TaskNo;
                return true;
            }
            catch (Exception e)
            {
                strErrMsg = e.ToString();
                return false;
            }
        }

        public bool SavePostFastIn(Task_Model head, BLL.Basic.User.UserInfo userModel, TaskVoucher tv, ref string strErrMsg)
        {
            strErrMsg = string.Empty;
            //获取TASK表ID
            int NewTASKID = 0;
            if (!GetNewTASKID(ref NewTASKID, ref strErrMsg))
            {
                strErrMsg = "获取TASK表ID失败:" + strErrMsg;
                return false;
            }
            int NewVouchID = 0;
            if (!GetNewTASKVoucherID(ref NewVouchID, ref strErrMsg))
            {
                strErrMsg = "获取TASKANDVOUCHERNO表ID失败:" + strErrMsg;
                return false;
            }
            //sql List
            List<string> SQL_list = new List<string>();
            SQL_list.Add("insert into T_TASK(ID,VOUCHERTYPE,TASKTYPE,TASKNO,DELIVERYNO,SUPCUSNAME,TASKSTATUS,CREATEDATETIME,REMARK,REASON,SUPCUSNO,CREATEUSERNO,ISSHELVEPOST,ISQUALITY,RECEIVEUSERNO,taskissued,PostStatus)" +
                               "values(" + NewTASKID.ToString() + ",60,1,'" + head.TaskNo + "'," + dbstr(tv.VoucherNo) + "," + dbstr(head.SupCusName) + ",2,sysdate," + dbstr(head.Remark) + "," + dbstr(head.Reason) + "," + dbstr(head.SupCusNo) + ",'" + head.CreateUserNo + "',2,1,'" + head.CreateUserNo + "',sysdate,1) ");
            SQL_list.Add("insert into T_TASKANDVOUCHERNO(ID,VOUCHERNO,TASK_ID)" +
                                "values(" + NewVouchID.ToString() + "," + dbstr(tv.VoucherNo) + "," + NewTASKID.ToString() + ") ");

            foreach (TaskDetails_Model tm in head.lstTaskDetails)
            {
                string sqlStr;
                string materialNo = tm.MaterialNo;
                string materialDESC = tm.MaterialDesc;
                decimal materialNUM = tm.TaskQty;

                sqlStr = "insert into T_TASKDETAILS(ID,TASK_ID,VOUCHERNO,MATERIALNO,MATERIALDESC,TASKQTY,REMAINQTY)" +
                    "values(seq_taskdetails.nextval," + NewTASKID.ToString() + ",'" + head.TaskNo + "','" + materialNo + "','" + materialDESC + "'," + materialNUM + "," + materialNUM + ") ";
                SQL_list.Add(sqlStr);
            }
            foreach (TaskVoucherDetails tm in tv.body)
            {
                string sqlStr;
                string materialNo = tm.MaterialNo;
                string materialDESC = tm.MaterialDesc;
                decimal materialNUM = tm.Qty;

                sqlStr = "insert into T_TASKANDVOUCHERDETAILS(ID,HEAD_ID,MATERIALNO,MATERIALDESC,QTY,ROWNO,FACTORY,FACTORYNAME,STORE)" +
                    "values(seq_taskandvoucherdetails.nextval," + NewVouchID.ToString() + ",'" + materialNo + "','" + materialDESC + "'," + materialNUM + ",'" + tm.RowNo + "','" + tm.Factory + "','" + tm.FactoryName + "','" + tm.Store + "' ) ";
                SQL_list.Add(sqlStr);
            }
            foreach (BLL.Basic.Warehouse.WarehouseInfo wi in userModel.lstWarehouse)
            {
                SQL_list.Add("insert into T_TASKWAREHOUSE (ID,TASK_ID,WAREHOUSE_ID,USER_ID)values(seq_taskwarehouse.nextval," + NewTASKID.ToString() + "," + wi.ID + "," + userModel.ID + ") ");
            }
            try
            {
                int result = OperationSql.ExecuteNonQueryList(SQL_list);
                strErrMsg = "新增成功！快速入库单号：" + head.TaskNo;
                return true;
            }
            catch (Exception e)
            {
                strErrMsg = e.ToString();
                return false;
            }
        }
        bool IsInsertedTASKANDVOUCHERNO(string ID)
        {
            try
            {

                string strSql = "select * from T_TASKANDVOUCHERNO where task_id = " + ID;

                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateFastIn(string ID, Task_Model head, string[] lst_delID, ref string strErrMsg)
        {
            //strErrMsg = string.Empty;
            //sql List
            string vouchertype = string.Empty;
            if(head.IsShelvePost == 1)
            {
                vouchertype = "50";
            }
            else
            {
                vouchertype = "60";
            }
            List<string> SQL_list = new List<string>();
            SQL_list.Add("update T_TASK set VOUCHERTYPE=" + vouchertype.ToString() + ",SUPCUSNAME=" + dbstr(head.SupCusName) + ",REMARK=" + dbstr(head.Remark) + ",REASON=" + dbstr(head.Reason) + ",SUPCUSNO=" + dbstr(head.SupCusNo) + ",ISSHELVEPOST=" + head.IsShelvePost
                               + " where ID =" + ID + " ");

            foreach (TaskDetails_Model tm in head.lstTaskDetails)
            {
                string sqlStr;
                string materialNo = tm.MaterialNo;
                string materialDESC = tm.MaterialDesc;
                string tmaterialNo = tm.TMaterialNo;
                string tmaterialDESC = tm.TMaterialDesc;
                decimal materialNUM = tm.TaskQty;
                if(tm.ID < 0)
                {
                    sqlStr = "insert into T_TASKDETAILS(ID,TASK_ID,MATERIALNO,MATERIALDESC,TMATERIALNO,TMATERIALDESC,TASKQTY,REMAINQTY)" +
                    "values(seq_taskdetails.nextval," + ID + ",'" + materialNo + "','" + materialDESC + "','" + tmaterialNo + "','" + tmaterialDESC + "'," + materialNUM + "," + materialNUM + ")";
                    SQL_list.Add(sqlStr);
                }
                else
                {
                    if (!strErrMsg.Equals("old"))
                    {
                        sqlStr = "update T_TASKDETAILS set MATERIALNO='" + materialNo + "',MATERIALDESC='" + materialDESC + "',TMATERIALNO='" + tmaterialNo + "',TMATERIALDESC='" + tmaterialDESC + "',TASKQTY=" + materialNUM + ",REMAINQTY=" + materialNUM
                            + " where TASK_ID=" + ID + " and ID=" + tm.ID + " ";
                        SQL_list.Add(sqlStr);
                    }
                }
            }
            foreach(string delID in lst_delID)
            {
                SQL_list.Add("delete T_TASKDETAILS where ID=" + delID + " ");
            }
            try
            {
                int result = OperationSql.ExecuteNonQueryList(SQL_list);
                strErrMsg = "更新成功！";
                return true;
            }
            catch (Exception e)
            {
                strErrMsg = e.ToString();
                return false;
            }
        }
        
        public bool UpdatePostFastIn(string ID, Task_Model head, TaskVoucher tv, string[] lst_delID, ref string strErrMsg)
        {
            //strErrMsg = string.Empty;
            int NewVouchID = 0;
            if (!GetNewTASKVoucherID(ref NewVouchID, ref strErrMsg))
            {
                strErrMsg = "获取TASKANDVOUCHERNO表ID失败:" + strErrMsg;
                return false;
            }
            //sql List
            string vouchertype = "60";
            List<string> SQL_list = new List<string>();
            SQL_list.Add("update T_TASK set DELIVERYNO=" + dbstr(tv.VoucherNo) + ", VOUCHERTYPE=" + vouchertype.ToString() + ",SUPCUSNAME=" + dbstr(head.SupCusName) + ",REMARK=" + dbstr(head.Remark) + ",REASON=" + dbstr(head.Reason) + ",SUPCUSNO=" + dbstr(head.SupCusNo) + ",ISSHELVEPOST=2,PostStatus=1"
                               + " where ID =" + ID + " ");
            if (IsInsertedTASKANDVOUCHERNO(ID))
            {

            }
            else
            {
                SQL_list.Add("insert into T_TASKANDVOUCHERNO(ID,VOUCHERNO,TASK_ID,FACTORY,STORE)" +
                                "values(" + NewVouchID + "," + dbstr(tv.VoucherNo) + "," + ID + "," + dbstr(tv.Factory) + "," + dbstr(tv.Store) + ") ");
            }
            
            foreach (TaskDetails_Model tm in head.lstTaskDetails)
            {
                string sqlStr;
                string materialNo = tm.MaterialNo;
                string materialDESC = tm.MaterialDesc;
                string tmaterialNo = tm.TMaterialNo;
                string tmaterialDESC = tm.TMaterialDesc;
                decimal materialNUM = tm.TaskQty;
                if (tm.ID < 0)
                {
                    sqlStr = "insert into T_TASKDETAILS(ID,TASK_ID,MATERIALNO,MATERIALDESC,TMATERIALNO,TMATERIALDESC,TASKQTY,REMAINQTY)" +
                    "values(seq_taskdetails.nextval," + ID + ",'" + materialNo + "','" + materialDESC + "','" + tmaterialNo + "','" + tmaterialDESC + "'," + materialNUM + "," + materialNUM + ")";
                    SQL_list.Add(sqlStr);
                }
                else
                {
                    //sqlStr = "update T_TASKDETAILS set MATERIALNO='" + materialNo + "',MATERIALDESC='" + materialDESC + "',TMATERIALNO='" + tmaterialNo + "',TMATERIALDESC='" + tmaterialDESC + "',TASKQTY=" + materialNUM + ",REMAINQTY=" + materialNUM
                    // + " where TASK_ID=" + ID + " and ID=" + tm.ID + " ";
                }
                //SQL_list.Add(sqlStr);
            }
            foreach (string delID in lst_delID)
            {
                SQL_list.Add("delete T_TASKDETAILS where ID=" + delID + " ");
            }
            if (!strErrMsg.Equals("old"))
            {
                foreach (TaskVoucherDetails tm in tv.body)
                {
                    string sqlStr;
                    string materialNo = tm.MaterialNo;
                    string materialDESC = tm.MaterialDesc;
                    decimal materialNUM = tm.Qty;

                    sqlStr = "insert into T_TASKANDVOUCHERDETAILS(ID,HEAD_ID,MATERIALNO,MATERIALDESC,QTY,ROWNO,FACTORY,FACTORYNAME,STORE)" +
                        "values(seq_taskandvoucherdetails.nextval," + NewVouchID.ToString() + ",'" + materialNo + "','" + materialDESC + "'," + materialNUM + ",'" + tm.RowNo + "','" + tm.Factory + "','" + tm.FactoryName + "','" + tm.Store + "' ) ";
                    SQL_list.Add(sqlStr);
                }
            }
            try
            {
                int result = OperationSql.ExecuteNonQueryList(SQL_list);
                strErrMsg = "更新成功！";
                SQL_list.Clear();
                SQL_list.Add("update t_tasktrans set DELIVERYNO=" + dbstr(tv.VoucherNo) + " where TaskNo = " + dbstr(head.TaskNo) + " ");
                OperationSql.ExecuteNonQueryList(SQL_list);
                return true;
            }
            catch (Exception e)
            {
                strErrMsg = e.ToString();
                return false;
            }
            

        }

        public bool DeleteFastIn(string ID, BLL.Basic.User.UserInfo userModel, ref string strErrMsg)
        {
            strErrMsg = string.Empty;
            //检查已上架数量是否大于零
            try
            {

                string strSql = "select sum(SHELVEQTY) from T_TASKDETAILS where TASK_ID = " + ID + " group by TASK_ID having sum(SHELVEQTY) > 0 ";

                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        if(dr[0] != null && dr[0] != DBNull.Value && Convert.ToDecimal(dr[0]) > 0)
                        {
                            strErrMsg = "已上架数量大于零";
                            return false;
                        }
                    }
                }
                strSql = "select ISNULL(MATERIALDOC,'') from T_RECEIVEMATERIALDOC where TASK_ID = " + ID + " ";

                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        if (dr[0] != null && dr[0] != DBNull.Value && dr[0].ToString() != "")
                        {
                            strErrMsg = "该单据已过账";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //检查是否有voucher表数据
            string HEAD_ID = string.Empty;
            try
            {

                string strSql = "select ID from T_TASKANDVOUCHERNO where TASK_ID = " + ID + " ";

                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        HEAD_ID = dr[0].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //sql List
            List<string> SQL_list = new List<string>();
            SQL_list.Add("delete T_TASK where ID = " + ID);
            SQL_list.Add("delete T_TASKDETAILS where TASK_ID = " + ID);
            if(!HEAD_ID.Equals(string.Empty))
            {
                SQL_list.Add("delete T_TASKANDVOUCHERNO where ID = " + HEAD_ID);
                SQL_list.Add("delete T_TASKANDVOUCHERDETAILS where HEAD_ID = " + HEAD_ID); 
            }
            foreach (BLL.Basic.Warehouse.WarehouseInfo wi in userModel.lstWarehouse)
            {
                SQL_list.Add("delete T_TASKWAREHOUSE where TASK_ID = " + ID + " ");
            }
            try
            {
                int result = OperationSql.ExecuteNonQueryList(SQL_list);
                strErrMsg = "删除成功！";
                return true;
            }
            catch (Exception e)
            {
                strErrMsg = e.ToString();
                return false;
            }
            return true;
        }

        public bool GetFastInByID(string ID, ref Task_Model head, ref TaskVoucher tv, ref string strErrMsg)
        {
            try
            {

                string strSql = "select t_task.id,VOUCHERTYPE,TASKSTATUS,(CASE ISSHELVEPOST WHEN 1 THEN '不过' WHEN 2 THEN '过账' END) AS SHELVEPOST,t_receivematerialdoc.MATERIALDOC,ISNULL(t_taskandvoucherno.voucherno,'') as voucherno,TASKNO,(CASE TASKSTATUS WHEN 1 THEN '全部' WHEN 2 THEN '已下发' WHEN 3 THEN '未下发' WHEN 4 THEN '已完成' WHEN 5 THEN '已取消'WHEN 6 THEN 'SAP已过账 出库' WHEN 7 THEN '已过账' WHEN 8 THEN '已完成' WHEN 9 THEN '已分配' WHEN 10 THEN '未分配' WHEN 11 THEN '已复核' END) AS STATUS ,CREATEUSERNO,CREATEDATETIME,ISNULL(REASON,'') as REASON,ISNULL(REMARK,'') as REMARK,ISNULL(SUPCUSNAME,'') AS SUPCUSNAME,ISNULL(SUPCUSNO,'') AS SUPCUSNO,ISNULL(t_task.PostStatus,0） AS POSTSTATUS from t_task"
                + " left join t_receivematerialdoc on t_receivematerialdoc.task_id = t_task.id "
                + " left join t_taskandvoucherno on t_taskandvoucherno.task_id = t_task.id "
                + " where t_task.id =" + ID;

                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        head = new Task_Model();
                        head.ID = Convert.ToInt32(ID);
                        head.VoucherType = Convert.ToInt32(dr["VOUCHERTYPE"].ToString());
                        head.TaskStatus = Convert.ToInt32(dr["TASKSTATUS"].ToString());
                        head.ShelvePost = dr["SHELVEPOST"].ToString();
                        head.MaterialDoc = dr["MATERIALDOC"].ToString();
                        head.VoucherNo = dr["voucherno"].ToString();
                        head.TaskNo = dr["TASKNO"].ToString();
                        head.StatusName = dr["STATUS"].ToString();
                        head.CreateUserNo = dr["CREATEUSERNO"].ToString();
                        head.CreateDateTime = Convert.ToDateTime(dr["CREATEDATETIME"]);
                        head.Reason = dr["REASON"].ToString();
                        head.Remark = dr["REMARK"].ToString();
                        head.SupCusName = dr["SUPCUSNAME"].ToString();
                        head.SupCusNo = dr["SUPCUSNO"].ToString().TrimStart('0');
                        head.PostStatus = Convert.ToInt32(dr["POSTSTATUS"].ToString());
                        break;
                    }
                }
                if (head.VoucherType == 60 && head.VoucherNo.Length > 0)//如果已保存了单据数据
                {
                    //查询T_TASKANDVOUCHERNO表
                    strSql = "select ID,VOUCHERNO,TASK_ID from T_TASKANDVOUCHERNO where TASK_ID =" + ID;
                    using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                    {
                        while (dr.Read())
                        {
                            tv = new TaskVoucher();
                            tv.ID = Convert.ToInt32(dr["ID"].ToString());
                            tv.VoucherNo = dr["VOUCHERNO"].ToString();
                            tv.Task_ID = dr["TASK_ID"].ToString();
                            break;
                        }
                    }
                }
                strSql = "select ID,ISNULL(MATERIALNO,'')as MATERIALNO,ISNULL(MATERIALDESC,'') as MATERIALDESC,ISNULL(TMATERIALNO,'') as TMATERIALNO,ISNULL(TMATERIALDESC,'') as TMATERIALDESC,TASKQTY,SHELVEQTY from T_TASKDETAILS where TASK_ID =" + ID + " order by MATERIALNO";
                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    List<TaskDetails_Model> body = new List<TaskDetails_Model>();
                    while (dr.Read())
                    {
                        TaskDetails_Model detail = new TaskDetails_Model();
                        detail.ID = Convert.ToInt32(dr["ID"]);
                        detail.MaterialNo = dr["MATERIALNO"].ToString();
                        detail.MaterialDesc = dr["MATERIALDESC"].ToString();
                        detail.TMaterialNo = dr["TMATERIALNO"].ToString();
                        detail.TMaterialDesc = dr["TMATERIALDESC"].ToString();
                        detail.TaskQty = Convert.ToDecimal(dr["TASKQTY"]);
                        detail.ShelveQty = dr["SHELVEQTY"].Equals(DBNull.Value) ? 0 : Convert.ToDecimal(dr["SHELVEQTY"]);
                        body.Add(detail);
                    }
                    if(body.Count > 0)
                    {
                        head.lstTaskDetails = body;
                    }
                }
                if (tv != null && tv.ID != null)//如果已保存了单据数据
                {
                    strSql = "select ID,HEAD_ID,ISNULL(MATERIALNO,'')as MATERIALNO,ISNULL(MATERIALDESC,'') as MATERIALDESC,QTY,ROWNO,ISNULL(FACTORY,'') as FACTORY,ISNULL(FACTORYNAME,'') as FACTORYNAME,ISNULL(STORE,'') as STORE from T_TASKANDVOUCHERDETAILS where HEAD_ID =" + tv.ID + " order by MATERIALNO";
                    List<TaskVoucherDetails> details = new List<TaskVoucherDetails>();
                    using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                    {
                        while (dr.Read())
                        {
                            TaskVoucherDetails Vdetail = new TaskVoucherDetails();
                            Vdetail.ID = Convert.ToInt32(dr["ID"]);
                            Vdetail.HeadID = dr["HEAD_ID"].ToString();
                            Vdetail.MaterialNo = dr["MATERIALNO"].ToString();
                            Vdetail.MaterialDesc = dr["MATERIALDESC"].ToString();
                            Vdetail.Qty = Convert.ToDecimal(dr["QTY"]);
                            Vdetail.RowNo = dr["ROWNO"].ToString();
                            Vdetail.Factory = dr["FACTORY"].ToString();
                            Vdetail.FactoryName = dr["FACTORYNAME"].ToString();
                            Vdetail.Store = dr["STORE"].ToString();
                            details.Add(Vdetail);
                        }
                    }
                    if(details.Count > 0)
                    {
                        tv.body = details;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
        }

        //public bool PostFastInByID(string ID, JXBLL.Basic.User.UserInfo userModel, ref string strErrMsg)
        //{
        //    try
        //    {
        //        JXBLL.DeliveryReceive.DeliveryReceive_SAP DRSAP = new JXBLL.DeliveryReceive.DeliveryReceive_SAP();
        //        JXBLL.DeliveryReceive.DeliveryReceive_Model DeliveryInfo = null;
        //        DeliveryInfo = new DeliveryReceive.DeliveryReceive_Model();
        //        DeliveryInfo.IsQuality = 1;
        //        string strSql = "select t_task.id,VOUCHERTYPE,TASKSTATUS,(CASE ISSHELVEPOST WHEN 1 THEN '不过' WHEN 2 THEN '过账' END) AS SHELVEPOST,t_receivematerialdoc.MATERIALDOC,ISNULL(t_taskandvoucherno.voucherno,'') as voucherno,TASKNO,(CASE TASKSTATUS WHEN 1 THEN '全部' WHEN 2 THEN '已下发' WHEN 3 THEN '未下发' WHEN 4 THEN '已完成' WHEN 5 THEN '已取消'WHEN 6 THEN 'SAP已过账 出库' WHEN 7 THEN '已过账' WHEN 8 THEN '已完成' WHEN 9 THEN '已分配' WHEN 10 THEN '未分配' WHEN 11 THEN '已复核' END) AS STATUS ,CREATEUSERNO,CREATEDATETIME,ISNULL(REASON,'') as REASON,ISNULL(REMARK,'') as REMARK,ISNULL(SUPCUSNAME,'') AS SUPCUSNAME,ISNULL(SUPCUSNO,'') AS SUPCUSNO from t_task"
        //        + " left join t_receivematerialdoc on t_receivematerialdoc.task_id = t_task.id "
        //        + " left join t_taskandvoucherno on t_taskandvoucherno.task_id = t_task.id "
        //        + " where t_task.id =" + ID;

        //        using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
        //        {
        //            while (dr.Read())
        //            {
        //                DeliveryInfo.MaterialDoc = dr["MATERIALDOC"].ToString();
        //                DeliveryInfo.Reson = dr["REASON"].ToString();
        //                DeliveryInfo.OsDeliveryRemark = dr["REMARK"].ToString();
        //                DeliveryInfo.VoucherType = Convert.ToInt32(dr["VOUCHERTYPE"]);
        //                if (DeliveryInfo.MaterialDoc.Equals(""))
        //                {
        //                    break;
        //                }
        //                strErrMsg = "该单据已过账";
        //                return false;
        //                break;
        //            }
        //        }
        //        string VoucherNo = string.Empty;
        //        strSql = "select ID,VOUCHERNO,TASK_ID from T_TASKANDVOUCHERNO where TASK_ID =" + ID;
        //        string HEAD_ID = string.Empty;
        //        using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
        //        {
        //            while (dr.Read())
        //            {
        //                HEAD_ID = dr["ID"].ToString();
        //                VoucherNo = dr["VOUCHERNO"].ToString();
        //                break;
        //            }
        //        }
        //        if(VoucherNo.Equals(string.Empty) || VoucherNo.Equals(DBNull.Value))
        //        {
        //            strErrMsg = "该单据还没有绑定单据号";
        //            return false;
        //        }
        //        strSql = "select ID,HEAD_ID,ISNULL(MATERIALNO,'')as MATERIALNO,ISNULL(MATERIALDESC,'') as MATERIALDESC,QTY,ROWNO,ISNULL(FACTORY,'') as FACTORY,ISNULL(FACTORYNAME,'') as FACTORYNAME,ISNULL(STORE,'') as STORE from T_TASKANDVOUCHERDETAILS where HEAD_ID =" + HEAD_ID + " order by MATERIALNO";
        //        DeliveryInfo.lstDeliveryDetail = new List<DeliveryReceive.DeliveryReceiveDetail_Model>();
        //        using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
        //        {
        //            while (dr.Read())
        //            {
        //                JXBLL.DeliveryReceive.DeliveryReceiveDetail_Model Vdetail = new JXBLL.DeliveryReceive.DeliveryReceiveDetail_Model();
        //                Vdetail.MaterialNo = dr["MATERIALNO"].ToString();
        //                Vdetail.VoucherNo = VoucherNo;
        //                Vdetail.Unit = "";
        //                Vdetail.ReceiveQty = Convert.ToDecimal(dr["QTY"]);
        //                Vdetail.RowNo = dr["ROWNO"].ToString();
        //                Vdetail.Plant = dr["FACTORY"].ToString();
        //                Vdetail.StorageLoc = dr["STORE"].ToString();
        //                DeliveryInfo.lstDeliveryDetail.Add(Vdetail);
        //            }
        //        }
        //        bool bSucc = DRSAP.PostReceiveGoodsInfoToSAP(ref DeliveryInfo, userModel, ref strErrMsg);
        //        if(!bSucc)
        //        {
        //            return false;
        //        }
        //        strSql = "select seq_materialdoc.nextval from dual ";
        //        string materialdocID = string.Empty;
        //        using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
        //        {
        //            while (dr.Read())
        //            {
        //                materialdocID = dr[0].ToString();
        //                break;
        //            }
        //        }
        //        List<string> SQL_list = new List<string>();
        //        strSql = "insert into T_RECEIVEMATERIALDOC (ID,MATERIALDOC,DOCDATE,POSTDATE,CREATEDATE,POSTUSER,TASK_ID,MATERIALDOCTYPE)values(" + materialdocID + "," + dbstr(DeliveryInfo.materialDocModel.MaterialDoc) + "," + dbstr(DeliveryInfo.materialDocModel.MaterialDocDate) + ",sysdate,sysdate," + dbstr(userModel.UserNo) + "," + ID + ",60) ";
        //        SQL_list.Add(strSql);
        //        strSql = "update t_task set PostStatus = 3 where ID = " + ID + " ";
        //        SQL_list.Add(strSql);
        //        int result = OperationSql.ExecuteNonQueryList(SQL_list);
        //        strErrMsg = "过账成功！";
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        strErrMsg = ex.Message;
        //        return false;
        //    }
        //}

        public bool GetVoucherByNo(string NO, ref TaskVoucher tv, ref string strErrMsg)
        {
            try
            {

                string strSql = "select ID,VOUCHERNO,TASK_ID from T_TASKANDVOUCHERNO where VOUCHERNO =" + NO;
                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        tv = new TaskVoucher();
                        tv.ID = Convert.ToInt32(dr["ID"]);
                        tv.VoucherNo = dr["VOUCHERNO"].ToString();
                        tv.Task_ID = dr["TASK_ID"].ToString();
                        return true; ;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
        }
    }
}
