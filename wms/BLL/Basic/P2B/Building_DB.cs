using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BLL.Common;

namespace BLL.Basic.P2B
{

    internal class Building_DB
    {
        private SqlParameter[] GetParameterFromModel(Building model)
        {
            int i;
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),                        
               
               new SqlParameter("@v_ID", model.ID.ToSqlValue()),
               new SqlParameter("@v_bNo", model.bNo.ToSqlValue()),
               new SqlParameter("@v_bName", model.bName.ToSqlValue()),
               new SqlParameter("@v_IsDel", model.IsDel.ToSqlValue()),
               new SqlParameter("@v_Creater", model.Creater.ToSqlValue()),
               new SqlParameter("@v_CreateTime", model.CreateTime.ToSqlValue()),
               new SqlParameter("@v_Modifyer", model.Modifyer.ToSqlValue()),
               new SqlParameter("@v_ModifyTime", model.ModifyTime.ToSqlValue()),
              };
            i = 0;
            param[i++].Direction = ParameterDirection.Output;
            param[i++].Direction = ParameterDirection.InputOutput;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Output;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Output;

            i = 0;
            param[i++].Size = 1000;
            param[i++].Size = 18;
            param[i++].Size = 20;
            param[i++].Size = 50;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 18;

            return param;
        }

        public bool ExistsbNo(Building model, bool bIncludeDel)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),
               
               new SqlParameter("@v_bNo", model.bNo.ToSqlValue()),
               new SqlParameter("@IncludeDel", bIncludeDel.ToSqlValue()),
            };
            param[0].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_ExistsbNo", param);

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

        public bool SaveBuilding(ref Building model)
        {
            SqlParameter[] param = GetParameterFromModel(model);

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_SaveBuilding", param);

            string ErrorMsg = param[0].Value.ToDBString();
            if (ErrorMsg.StartsWith("执行错误"))
            {
                throw new Exception(ErrorMsg);
            }
            else
            {
                model.ID = param[1].Value.ToInt32();
                model.CreateTime = param[param.Length - 3].Value.ToDateTime();
                model.ModifyTime = param[param.Length - 1].Value.ToDateTimeNull();
                return true;
            }
        }

        public bool DeleteBuildingByID(Building model)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),

               new SqlParameter("@v_ID", model.ID.ToSqlValue()),
               
            };
            param[0].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_DeleteBuildingByID", param);

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

        public SqlDataReader GetBuildingByID(Building model)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM V_Building WHERE ID = {0}", model.ID);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }

    }
}
