using System;
using BLL.Common;
using System.Data;
using System.Collections.Generic;
using BLL.Material;
using BLL.OutStock;
using System.Data.SqlClient;

namespace BLL.Check
{
    internal class CheckDetails_DB
    {
        public SqlDataReader GetCheckDetailsByID(CheckDetailsInfo model)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM V_CheckDetails WHERE ID = {0}", model.ID);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }

        internal SqlDataReader GetCheckDetailsListByCheckID(int checkID)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM V_CheckDetails WHERE CheckID = {0}", checkID);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }

        internal SqlDataReader GetCheckMaterialListByCheckID(int checkID)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT materialno,MATERIALDESC,materialstd,SUM(ACCOUNTQTY) AccountQty FROM V_CheckDetails WHERE CheckID = {0} group by materialno,materialstd,MATERIALDESC", checkID);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }

        internal bool UpdateKeeperInfo(List<OutStockDetails_Model> lstKeeper, List<Material_Model> lstMaterial)
        {
            //SqlParameter[] param = new SqlParameter[]{
            //   new SqlParameter("@ErrorMsg",OracleDbType.NVarchar2,1000),

            //   new SqlParameter("@v_Keeper", lstKeeper[0].MaterialKeeperNo.ToOracleValue()),
            //   new SqlParameter("@xmlMaterial", XMLUtil.XmlUtil.Serializer(typeof(List<Material_Model>),lstMaterial)),

            //};
            //param[0].Direction = ParameterDirection.Output;
            //param[2].OracleDbType = OracleDbType.NClob;

            //OracleDBHelper.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_UpdateKeeperInfo", param);

            //string strError = param[0].Value.ToDBString();
            //if (strError.StartsWith("执行错误"))
            //{
            //    throw new Exception(strError);
            //    //return false;
            //}
            //else
            //{
            //    return true;
            //}

            return false;
        }

        internal bool UpdateCheckAnalyse(CheckDetailsInfo model, ref string strError)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),

               new SqlParameter("@v_ID", SqlDbType.Int),
               new SqlParameter("@v_CheckType", SqlDbType.Int),

            };
            
            param[0].Direction = ParameterDirection.Output;
            param[1].Value = model.CheckID;
            param[2].Value = model.CheckType;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_GetCheckAnalyse", param);

            strError = param[0].Value.ToDBString();
            if (strError.StartsWith("执行错误"))
            {
                //throw new Exception(strError);
                return false;
            }
            else
            {
                return true;
            }
        }

        internal SqlDataReader GetKeeperList(string keeperno)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT UserNo, UserName FROM v_User where userno like '%{0}%' or username like '%{0}%' Order By ID Desc ", keeperno);
            strSql = string.Format("SELECT UserNo, UserName FROM v_User where userno = '{0}' or username = '{0}' Order By ID Desc ", keeperno);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }

        internal bool NeedUpdateKeeperInfo(List<Material_Model> lstMaterial)
        {
            //OracleParameter[] param = new OracleParameter[]{
            //   new OracleParameter("@ErrorMsg",OracleDbType.NVarchar2,1000),

            //   new OracleParameter("@xmlMaterial", XMLUtil.XmlUtil.Serializer(typeof(List<Material_Model>),lstMaterial)),
               
            //};
            //param[0].Direction = ParameterDirection.Output;

            //OracleDBHelper.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_NeedUpdateKeeper", param);
            string strError = null;
            //strError = param[0].Value.ToDBString();
            if (string.IsNullOrEmpty(strError))
            {
                //throw new Exception(strError);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
