using BLL.Common;
using System.Data.SqlClient;
using System;
using System.Data;


namespace BLL.Basic.User
{
    internal class User_DB
    {

        private SqlParameter[] GetParameterFromModel(UserInfo model)
        {
            int i;
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),
               
               new SqlParameter("@v_ID", model.ID.ToSqlValue()),
               new SqlParameter("@v_UserNo", model.UserNo.ToSqlValue()),
               new SqlParameter("@v_UserName", model.UserName.ToSqlValue()),
               new SqlParameter("@v_Password", model.Password.ToSqlValue()),
               new SqlParameter("@v_UserType", model.UserType.ToSqlValue()),
               new SqlParameter("@v_PinYin", model.PinYin.ToSqlValue()),
               new SqlParameter("@v_Duty", model.Duty.ToSqlValue()),
               new SqlParameter("@v_Tel", model.Tel.ToSqlValue()),
               new SqlParameter("@v_Mobile", model.Mobile.ToSqlValue()),
               new SqlParameter("@v_Email", model.Email.ToSqlValue()),
               new SqlParameter("@v_Sex", model.Sex.ToSqlValue()),
               new SqlParameter("@v_IsPick", model.IsPick.ToSqlValue()),
               new SqlParameter("@v_IsReceive", model.IsReceive.ToSqlValue()),
               new SqlParameter("@v_IsQuality", model.IsQuality.ToSqlValue()),
               new SqlParameter("@v_UserStatus", model.UserStatus.ToSqlValue()),
               new SqlParameter("@v_Address", model.Address.ToSqlValue()),
               new SqlParameter("@v_GroupCode", model.GroupCode.ToSqlValue()),
               new SqlParameter("@v_WarehouseCode", model.WarehouseCode.ToSqlValue()),
               new SqlParameter("@v_Description", model.Description.ToSqlValue()),
               new SqlParameter("@v_LoginIP", model.LoginIP.ToSqlValue()),
               new SqlParameter("@v_LoginTime", model.LoginTime.ToSqlValue()),
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
            param[i++].Size = 50;
            param[i++].Size = 18;
            param[i++].Size = 50;
            param[i++].Size = 50;
            param[i++].Size = 50;
            param[i++].Size = 50;
            param[i++].Size = 50;
            param[i++].Size = 50;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 50;
            param[i++].Size = 30;
            param[i++].Size = 50;
            param[i++].Size = 30;
            param[i++].Size = 50;
            param[i++].Size = 30;
            param[i++].Size = 18;
            param[i++].Size = 50;
            param[i++].Size = 30;
            param[i++].Size = 50;
            param[i++].Size = 30;

            return param;
        }



        public bool ExistsUserNo(UserInfo model, bool bIncludeDel)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),
               
               new SqlParameter("@v_UserNo", model.UserNo.ToSqlValue()),
               new SqlParameter("@IncludeDel", bIncludeDel.ToSqlValue()),
            };
            param[0].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_ExistsUserNo", param);

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

        public bool SaveUser(ref UserInfo model)
        {
            model.CreateTime = DateTime.Now;
            model.ModifyTime = DateTime.Now;
            SqlParameter[] param = GetParameterFromModel(model);

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_SaveUser", param);

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


        public bool DeleteUserByID(UserInfo model)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),

               new SqlParameter("@v_ID", model.ID.ToSqlValue()),
               
            };
            param[0].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_DeleteUserByID", param);

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


        public SqlDataReader GetUserByID(UserInfo model)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM V_User WHERE ID = {0}", model.ID);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }

        public SqlDataReader GetKeeperList()
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM V_User WHERE USERNAME in (select distinct keeper from t_keeperinfo)");

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }
    }
}
