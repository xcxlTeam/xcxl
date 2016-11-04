using BLL.Basic.User;
using BLL.Common;
using System.Data.SqlClient;
using System;
using System.Data;

namespace BLL.Basic.UserGroup
{
    class UserGroup_DB
    {

        private SqlParameter[] GetParameterFromModel(UserGroupInfo model)
        {
            int i;
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),
               
               new SqlParameter("@v_ID", model.ID.ToSqlValue()),
               new SqlParameter("@v_UserGroupNo", model.UserGroupNo.ToSqlValue()),
               new SqlParameter("@v_UserGroupName", model.UserGroupName.ToSqlValue()),
               new SqlParameter("@v_UserGroupAbbName", model.UserGroupAbbName.ToSqlValue()),
               new SqlParameter("@v_UserGroupType", model.UserGroupType.ToSqlValue()),
               new SqlParameter("@v_UserGroupStatus", model.UserGroupStatus.ToSqlValue()),
               new SqlParameter("@v_Description", model.Description.ToSqlValue()),
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
            param[i++].Direction = ParameterDirection.InputOutput;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.InputOutput;

            i = 0;
            param[i++].Size = 1000;
            param[i++].Size = 18;
            param[i++].Size = 20;
            param[i++].Size = 50;
            param[i++].Size = 50;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 200;
            param[i++].Size = 18;
            param[i++].Size = 50;
            param[i++].Size = 30;
            param[i++].Size = 50;
            param[i++].Size = 30;

            return param;
        }

        public bool ExistsUserGroupNo(UserGroupInfo model, bool bIncludeDel)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),
               
               new SqlParameter("@v_UserGroupNo", model.UserGroupNo.ToSqlValue()),
               new SqlParameter("@IncludeDel", bIncludeDel.ToSqlValue()),
            };
            param[0].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_ExistsUserGroupNo", param);

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

        public bool SaveUserGroup(ref UserGroupInfo model)
        {
            SqlParameter[] param = GetParameterFromModel(model);

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_SaveUserGroup", param);

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


        public bool DeleteUserGroupByID(UserGroupInfo model)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),

               new SqlParameter("@v_ID", model.ID.ToSqlValue()),
               
            };
            param[0].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_DeleteUserGroupByID", param);

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


        public SqlDataReader GetUserGroupByID(UserGroupInfo model)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM T_UserGroup WHERE ID = {0}", model.ID);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }

        internal SqlDataReader GetUserGroupListByUserID(UserInfo User, bool IncludNoCheck)
        {
            string strSql = string.Empty;
            if (User.ID >= 1)
            {
                strSql = string.Format("SELECT DISTINCT 2 AS IsChecked,T_UserGroup.* FROM T_UserGroup WHERE ISDEL <> 2 AND UserGroupStatus <> 2 AND ID IN (SELECT GroupID FROM T_UserWithGroup WHERE UserID = {0}) ", User.ID);
                if (IncludNoCheck) strSql += string.Format("UNION SELECT DISTINCT 1 AS IsChecked,T_UserGroup.* FROM T_UserGroup WHERE ISDEL <> 2 AND UserGroupStatus <> 2 AND ID NOT IN (SELECT GroupID FROM T_UserWithGroup WHERE UserID = {0}) ", User.ID);
                strSql = string.Format("SELECT * FROM ({0}) T ORDER BY ID ", strSql);
            }
            else
            {
                if (IncludNoCheck) strSql = "SELECT DISTINCT 1 AS IsChecked,T_UserGroup.* FROM T_UserGroup WHERE ISDEL <> 2 AND UserGroupStatus <> 2";
                else strSql = "SELECT DISTINCT 2 AS IsChecked,T_UserGroup.* FROM T_UserGroup WHERE 1 = 2";
            }
            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }
    }
}
