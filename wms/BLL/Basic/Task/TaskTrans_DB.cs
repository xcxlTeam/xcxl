using BLL.Common;
using System.Data.SqlClient;
using System;
using System.Data;

namespace BLL.Basic.Task
{
    internal class TaskTrans_DB
    {

        private SqlParameter[] GetParameterFromModel(TaskTransInfo model)
        {

            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),
               
               new SqlParameter("@v_ID", model.ID.ToSqlValue()),

               new SqlParameter("@v_Creater", model.Creater.ToSqlValue()),
               new SqlParameter("@v_CreateTime", model.CreateTime.ToSqlValue()),
               new SqlParameter("@v_Modifyer", model.Modifyer.ToSqlValue()),
               new SqlParameter("@v_ModifyTime", model.ModifyTime.ToSqlValue()),
               new SqlParameter("@v_IsDel", model.IsDel.ToSqlValue()),
              };
            param[0].Direction = ParameterDirection.Output;
            param[1].Direction = ParameterDirection.InputOutput;
            return param;
        }



        public bool ExistsTaskTransNo(TaskTransInfo model, bool bIncludeDel)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),
               
               //new SqlParameter("@v_TaskTransNo", model.TaskTransNo.ToDBValue()),
               new SqlParameter("@IncludeDel", bIncludeDel.ToSqlValue()),
            };
            param[0].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_ExistsTaskTransNo", param);

            string ErrorMsg = param[0].Value.ToDBString();
            if (ErrorMsg.StartsWith("执行错误"))
            {
                throw new Exception(ErrorMsg);
            }
            else
            {
                return string.IsNullOrEmpty(ErrorMsg);
            }
        }

        public bool SaveTaskTrans(ref TaskTransInfo model)
        {
            SqlParameter[] param = GetParameterFromModel(model);

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_SaveTaskTrans", param);

            string ErrorMsg = param[0].Value.ToDBString();
            if (ErrorMsg.StartsWith("执行错误"))
            {
                throw new Exception(ErrorMsg);
            }
            else
            {
                model.ID = param[1].ToInt32();
                return true;
            }
        }


        public bool DeleteTaskTransByID(TaskTransInfo model)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),

               new SqlParameter("@v_ID", model.ID.ToSqlValue()),
               
            };
            param[0].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_DeleteTaskTransByID", param);

            string ErrorMsg = param[0].Value.ToDBString();
            if (ErrorMsg.StartsWith("执行错误"))
            {
                throw new Exception(ErrorMsg);
            }
            else
            {
                return true;
            }
        }


        public SqlDataReader GetTaskTransByID(TaskTransInfo model)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM TTaskTrans WHERE ID = {0}", model.ID);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }
    }
}
