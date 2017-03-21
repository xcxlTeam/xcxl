using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BLL.Common;

namespace BLL.Basic.MustReturnMaterial
{
    public class SpecialReturnMaterial_DB
    {
        public SqlDataReader GetSpecialList(string fieldName)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT {0} FROM T_SpecialReturnMaterial WHERE IsDel = 1", fieldName);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }

        private SqlParameter[] GetParameterFromModel(SpecialReturnMaterial model)
        {
            int i;
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),                        
               
               new SqlParameter("@v_ID", model.ID.ToSqlValue()),
               new SqlParameter("@v_IsDel", model.IsDel.ToSqlValue()),
               new SqlParameter("@v_Creater", model.Creater.ToSqlValue()),
               new SqlParameter("@v_CreateTime", model.CreateTime.ToSqlValue()),
               new SqlParameter("@v_Modifyer", model.Modifyer.ToSqlValue()),
               new SqlParameter("@v_ModifyTime", model.ModifyTime.ToSqlValue()),
               new SqlParameter("@v_InvtID", model.InvtID.ToSqlValue()),

              };
            i = 0;
            param[i++].Direction = ParameterDirection.Output;
            param[i++].Direction = ParameterDirection.InputOutput;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;


            i = 0;
            param[i++].Size = 1000;
            param[i++].Size = 18;
            param[i++].Size = 10;
            param[i++].Size = 20;
            param[i++].Size = 50;
            param[i++].Size = 20;
            param[i++].Size = 50;
            param[i++].Size = 20;


            return param;
        }


        public bool SaveSpecialReturnMaterial(ref SpecialReturnMaterial model)
        {
            SqlParameter[] param = GetParameterFromModel(model);

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_SaveSpecialReturnMaterial", param);

            string ErrorMsg = param[0].Value.ToDBString();
            if (ErrorMsg.StartsWith("execution error"))
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

        public bool DeleteSpecialReturnMaterialByID(SpecialReturnMaterial model)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),

               new SqlParameter("@v_ID", model.ID.ToSqlValue()),
               
            };
            param[0].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_DeleteSpecialReturnMaterialByID", param);

            string ErrorMsg = param[0].Value.ToDBString();
            if (ErrorMsg.StartsWith("execution error"))
            {
                throw new Exception(ErrorMsg);
            }
            else
            {
                return true;
            }
        }

        public SqlDataReader GetSpecialReturnMaterialByID(SpecialReturnMaterial model)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM T_SpecialReturnMaterial WHERE ID = {0}", model.ID);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }
    }
}
