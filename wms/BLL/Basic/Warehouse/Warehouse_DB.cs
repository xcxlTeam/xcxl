using BLL.Basic.User;
using BLL.Common;
using System.Data.SqlClient;
using System;
using System.Data;

namespace BLL.Basic.Warehouse
{
    internal class Warehouse_DB
    {

        private SqlParameter[] GetParameterFromModel(WarehouseInfo model)
        {
            int i;
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),
               
               new SqlParameter("@v_ID", model.ID.ToSqlValue()),
               new SqlParameter("@v_WarehouseNo", model.WarehouseNo.ToSqlValue()),
               new SqlParameter("@v_WarehouseName", model.WarehouseName.ToSqlValue()),
               new SqlParameter("@v_WarehouseType", model.WarehouseType.ToSqlValue()),
               new SqlParameter("@v_ContactUser", model.ContactUser.ToSqlValue()),
               new SqlParameter("@v_ContactPhone", model.ContactPhone.ToSqlValue()),
               new SqlParameter("@v_HouseCount", model.HouseCount.ToSqlValue()),
               new SqlParameter("@v_HouseUsingCount", model.HouseUsingCount.ToSqlValue()),
               new SqlParameter("@v_Address", model.Address.ToSqlValue()),
               new SqlParameter("@v_LocationDesc", model.LocationDesc.ToSqlValue()),
               new SqlParameter("@v_WarehouseStatus", model.WarehouseStatus.ToSqlValue()),
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
            param[i++].Size = 18;
            param[i++].Size = 50;
            param[i++].Size = 50;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 50;
            param[i++].Size = 200;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 50;
            param[i++].Size = 30;
            param[i++].Size = 50;
            param[i++].Size = 30;

            return param;
        }



        public bool ExistsWarehouseNo(WarehouseInfo model, bool bIncludeDel)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),
               
               new SqlParameter("@v_WarehouseNo", model.WarehouseNo.ToSqlValue()),
               new SqlParameter("@IncludeDel", bIncludeDel.ToSqlValue()),
            };
            param[0].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_ExistsWarehouseNo", param);

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

        public bool SaveWarehouse(ref WarehouseInfo model)
        {
            model.CreateTime = DateTime.Now;
            model.ModifyTime = DateTime.Now;
            SqlParameter[] param = GetParameterFromModel(model);

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_SaveWarehouse", param);

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


        public bool DeleteWarehouseByID(WarehouseInfo model)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),

               new SqlParameter("@v_ID", model.ID.ToSqlValue()),
               
            };
            param[0].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_DeleteWarehouseByID", param);

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


        public SqlDataReader GetWarehouseByID(WarehouseInfo model)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM V_Warehouse WHERE ID = {0} or WarehouseNo='{1}'", model.ID,model.WarehouseNo);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }


        public SqlDataReader GetWarehouseBycWhCode(WarehouseInfo model)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT cwhcode,cwhname FROM Warehouse WHERE cwhcode = '{0}'", model.WarehouseNo);

            return OperationSql.ExecuteReaderForU8(CommandType.Text, strSql, null);
        }

        internal SqlDataReader GetWarehouseListByUserID(UserInfo User, bool IncludNoCheck)
        {
            string strSql = string.Empty;
            if (User.ID >= 1)
            {
                strSql = string.Format("SELECT DISTINCT 2 AS IsChecked,T_Warehouse.* FROM T_Warehouse WHERE ISDEL <> 2 AND WarehouseStatus <> 2 AND ID IN (SELECT WarehouseID FROM T_UserWithWarehouse WHERE UserID = {0}) ", User.ID);
                if (IncludNoCheck) strSql += string.Format("UNION SELECT DISTINCT 1 AS IsChecked,T_Warehouse.* FROM T_Warehouse WHERE ISDEL <> 2 AND WarehouseStatus <> 2 AND ID NOT IN (SELECT WarehouseID FROM T_UserWithWarehouse WHERE UserID = {0}) ", User.ID);
                strSql = string.Format("SELECT * FROM ({0}) T ORDER BY ID ", strSql);
            }
            else
            {
                if (IncludNoCheck) strSql = "SELECT DISTINCT 1 AS IsChecked,T_Warehouse.* FROM T_Warehouse WHERE ISDEL <> 2 AND WarehouseStatus <> 2";
                else strSql = "SELECT DISTINCT 2 AS IsChecked,T_Warehouse.* FROM T_Warehouse WHERE 1 = 2";
            }
            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }
    }
}
