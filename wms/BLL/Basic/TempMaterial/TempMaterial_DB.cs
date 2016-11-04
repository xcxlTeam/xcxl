using BLL.Common;
using System.Data.SqlClient;
using System;
using System.Data;

namespace BLL.Basic.TempMaterial
{
    internal class TempMaterial_DB
    {

        private SqlParameter[] GetParameterFromModel(TempMaterialInfo model)
        {
            int i;
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),
               
               new SqlParameter("@v_ID", model.ID.ToSqlValue()),
               new SqlParameter("@v_TempMaterialNo", model.TempMaterialNo.ToSqlValue()),
               new SqlParameter("@v_TempMaterialDesc", model.TempMaterialDesc.ToSqlValue()),
               new SqlParameter("@v_MaterialNo", model.MaterialNo.ToSqlValue()),
               new SqlParameter("@v_MaterialDesc", model.MaterialDesc.ToSqlValue()),
               new SqlParameter("@v_SapMaterialDoc", model.SapMaterialDoc.ToSqlValue()),
               new SqlParameter("@v_ReplaceUser", model.ReplaceUser.ToSqlValue()),
               new SqlParameter("@v_ReplaceTime", model.ReplaceTime.ToSqlValue()),
               new SqlParameter("@v_TempMaterialStatus", model.TempMaterialStatus.ToSqlValue()),
               new SqlParameter("@v_IsDel", model.IsDel.ToSqlValue()),
               new SqlParameter("@v_Creater", model.Creater.ToSqlValue()),
               new SqlParameter("@v_CreateTime", model.CreateTime.ToSqlValue()),
               new SqlParameter("@v_Modifyer", model.Modifyer.ToSqlValue()),
               new SqlParameter("@v_ModifyTime", model.ModifyTime.ToSqlValue()),
              };

            i = 0;
            param[i++].Direction = ParameterDirection.Output;
            param[i++].Direction = ParameterDirection.InputOutput;
            param[i++].Direction = ParameterDirection.InputOutput;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.InputOutput;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.InputOutput;

            i = 0;
            param[i++].Size = 1000;
            param[i++].Size = 18;
            param[i++].Size = 20;
            param[i++].Size = 50;
            param[i++].Size = 20;
            param[i++].Size = 50;
            param[i++].Size = 50;
            param[i++].Size = 20;
            param[i++].Size = 30;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 50;
            param[i++].Size = 30;
            param[i++].Size = 50;
            param[i++].Size = 30;

            return param;
        }



        public bool ExistsTempMaterialNo(TempMaterialInfo model, bool bIncludeDel)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),
               
               new SqlParameter("@v_TempMaterialNo", model.TempMaterialNo.ToSqlValue()),
               new SqlParameter("@IncludeDel", bIncludeDel.ToSqlValue()),
            };
            param[0].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_ExistsTempMaterialNo", param);

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

        public bool SaveTempMaterial(ref TempMaterialInfo model)
        {
            SqlParameter[] param = GetParameterFromModel(model);

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_SaveTempMaterial", param);

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


        public bool DeleteTempMaterialByID(TempMaterialInfo model)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),

               new SqlParameter("@v_ID", model.ID.ToSqlValue()),
               
            };
            param[0].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_DeleteTempMaterialByID", param);

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

        public string GetTempMaterialNo(TempMaterialInfo model)
        {
            string strSql = string.Empty;
            if (model.ID <= 0) strSql = "SELECT 'L' || TO_CHAR(SYSDATE,'YYYYMM') || CONCAT(SUBSTR('00000',1,5-LENGTH(SEQ_TEMPMATERIALNO.NEXTVAL)),SEQ_TEMPMATERIALNO.NEXTVAL) FROM DUAL";
            else strSql = string.Format("SELECT TempMaterialNo FROM T_TEMPMATERIAL WHERE ID = {0}", model.ID);

            object o;
            o = OperationSql.ExecuteScalar(CommandType.Text, strSql, null);
            return o.ToDBString();
        }


        public SqlDataReader GetTempMaterialByID(TempMaterialInfo model)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM V_TempMaterial WHERE ID = {0}", model.ID);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }


        public SqlDataReader GetTempMaterialByNo(TempMaterialInfo model)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM V_TempMaterial WHERE TempMaterialNo = '{0}'", string.IsNullOrEmpty(model.MaterialNo) ? model.TempMaterialNo : model.MaterialNo);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }
    }
}
