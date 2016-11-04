using System;
using BLL.Common;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Check
{
    internal class Check_DB
    {
        private SqlParameter[] GetParameterFromModel(CheckInfo model)
        {
            int i;
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar),

               new SqlParameter("@v_ID", SqlDbType.Int),
               new SqlParameter("@v_CheckNo", SqlDbType.NVarChar),
               new SqlParameter("@v_CheckType", SqlDbType.Int),
               new SqlParameter("@xmlCheck",SqlDbType.Xml),
              };
            
            param[1].Value = model.ID;
            param[2].Value = model.CheckNo;
            param[3].Value = model.CheckType;
            param[4].Value = XMLUtil.XmlUtil.Serializer(typeof(CheckInfo), model);

            i = 0;
            param[i++].Direction = ParameterDirection.Output;
            param[i++].Direction = ParameterDirection.InputOutput;
            param[i++].Direction = ParameterDirection.InputOutput;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;

            i = 0;
            param[i++].Size = 1000;
            param[i++].Size = 18;
            param[i++].Size = 50;
            param[i++].Size = 18;
            //param[i++].Size = 4000;

            return param;
        }


        public bool SaveCheck(ref CheckInfo model)
        {
            SqlParameter[] param = GetParameterFromModel(model);

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "PROC_SaveCheck", param);

            string ErrorMsg = param[0].Value.ToDBString();
            if (ErrorMsg.StartsWith("执行错误"))
            {
                throw new Exception(ErrorMsg);
            }
            else
            {
                model.ID = param[1].Value.ToInt32();
                model.CheckNo = param[2].Value.ToDBString();
                return true;
            }
        }


        public bool DeleteCheckByID(CheckInfo model)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),

               new SqlParameter("@v_ID", SqlDbType.Int),

            };

            param[1].Value = model.ID;
            param[0].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_DeleteCheckByID", param);

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


        public SqlDataReader GetCheckByID(CheckInfo model)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM V_Check WHERE ID = {0}", model.ID);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }

        public bool UpdateCheckStatusByID(CheckInfo model)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),

               new SqlParameter("@v_ID", SqlDbType.Int),
               new SqlParameter("@v_CheckStatus", SqlDbType.Int),

            };
            param[1].Value = model.ID;
            param[2].Value = model.CheckStatus;

            param[0].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_UpdateCheckStatusByID", param);

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

        internal bool Proc_ProfitLossDeal(CheckInfo model)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),

               new SqlParameter("@v_ID", SqlDbType.Int),

            };
            param[1].Value = model.ID;
            param[0].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_ProfitLossDeal", param);

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

        internal bool VerifyCheckStockChange(CheckInfo model)
        {
            string strSql = string.Empty;
            strSql = string.Format("select COUNT(1) from t_stock S join t_checkdetaillist L on L.checkid = {0} and S.SERIALNO = L.SERIALNO and (S.Areano <> L.AREANO or S.QTY <> L.QTY)", model.ID);
            object obj = OperationSql.ExecuteScalar(CommandType.Text, strSql, null);
            if (obj.ToInt32() <= 0) return false;

            return true;
        }

        internal bool ReCheckByCheck(CheckInfo model, ref CheckInfo reCheck, Basic.User.UserInfo user, ref string strError)
        {
            SqlParameter[] param = new SqlParameter[]{
               //new OracleParameter("@ErrorMsg",OracleDbType.NVarchar2,1000),

               //new OracleParameter("@v_UserID", user.ID.ToOracleValue()),
               //new OracleParameter("@xmlCheck", XMLUtil.XmlUtil.Serializer(typeof(CheckInfo),model)),
               //new OracleParameter("@v_ReCheckID",OracleDbType.Int32,18),
               
            };
            param[0].Direction = ParameterDirection.Output;
            param[1].Direction = ParameterDirection.Input;
            param[2].Direction = ParameterDirection.Input;
            param[3].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_ReCheck", param);

            strError = param[0].Value.ToDBString();
            if (strError.StartsWith("执行错误"))
            {
                //throw new Exception(strError);
                return false;
            }
            else
            {
                reCheck.ID = param[3].Value.ToInt32();
                return true;
            }
        }
    }
}
