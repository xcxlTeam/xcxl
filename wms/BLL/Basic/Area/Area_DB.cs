using System;
using BLL.Common;
using System.Data.SqlClient;
using System.Data;


namespace BLL.Basic.Area
{
    internal class Area_DB
    {
        private SqlParameter[] GetParameterFromModel(AreaInfo model)
        {
            int i;
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),
               
               new SqlParameter("@v_ID", model.ID.ToSqlValue()),
               new SqlParameter("@v_AreaNo", model.AreaNo.ToSqlValue()),
               new SqlParameter("@v_AreaName", model.AreaName.ToSqlValue()),
               new SqlParameter("@v_AreaType", model.AreaType.ToSqlValue()),
               new SqlParameter("@v_ContactUser", model.ContactUser.ToSqlValue()),
               new SqlParameter("@v_ContactPhone", model.ContactPhone.ToSqlValue()),
               new SqlParameter("@v_Address", model.Address.ToSqlValue()),
               new SqlParameter("@v_LocationDesc", model.LocationDesc.ToSqlValue()),
               new SqlParameter("@v_AreaStatus", model.AreaStatus.ToSqlValue()),
               new SqlParameter("@v_HouseID", model.HouseID.ToSqlValue()),
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
            param[i++].Size = 50;
            param[i++].Size = 200;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 50;
            param[i++].Size = 30;
            param[i++].Size = 50;
            param[i++].Size = 30;

            return param;
        }

        internal SqlDataReader GetAreaByNo(string strAreaNo)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM V_Area WHERE AreaNo = '{0}'", strAreaNo);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }

        internal bool AreaOfCheck(int checkID, AreaInfo area)
        {
            string strSql = string.Empty;
            strSql = string.Format("select count(1) from t_check where id = {0} and checktype in (1,2,3,5)", checkID);
            object obj = OperationSql.ExecuteScalar(CommandType.Text, strSql, null);
            if (obj.ToInt32() <= 0) return true;

            int checktype = 0;
            strSql = string.Format("select CheckType from t_check where id = {0}", checkID);
            checktype = OperationSql.ExecuteScalar(CommandType.Text, strSql, null).ToInt32();

            switch (checktype)
            {
                case 1:
                    strSql = string.Format("select count(1) from v_CheckDetails where checkid = {0} and warehouseno = '{1}' ", checkID, area.WarehouseNo);
                    obj = OperationSql.ExecuteScalar(CommandType.Text, strSql, null);
                    if (obj.ToInt32() <= 0) return false;
                    break;

                case 2:
                    strSql = string.Format("select count(1) from v_CheckDetails where checkid = {0} and warehouseno = '{1}' and houseno = '{2}' ", checkID, area.WarehouseNo, area.HouseNo);
                    obj = OperationSql.ExecuteScalar(CommandType.Text, strSql, null);
                    if (obj.ToInt32() <= 0) return false;
                    break;

                case 3:
                    strSql = string.Format("select count(1) from v_CheckDetails where checkid = {0} and areano = '{1}' ", checkID, area.AreaNo);
                    obj = OperationSql.ExecuteScalar(CommandType.Text, strSql, null);
                    if (obj.ToInt32() <= 0) return false;
                    break;

                case 5:
                    //strSql = string.Format("select count(1) from v_CheckDetails A join v_area B on A.WAREHOUSENO = B.warehouseno where A.checkid = {0} and A.warehouseno = '{1}' and B.areano = '{2}' ", checkID, area.WarehouseNo, area.AreaNo);
                    strSql = string.Format("select count(1) from v_CheckDetails where checkid = {0} and nvl(warehouseno,'{1}') = '{1}' ", checkID, area.WarehouseNo);
                    obj = OperationSql.ExecuteScalar(CommandType.Text, strSql, null);
                    if (obj.ToInt32() <= 0) return false;
                    break;
            }

            return true;
        }

        public bool ExistsAreaNo(AreaInfo model, bool bIncludeDel)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),
               
               new SqlParameter("@v_AreaNo", model.AreaNo.ToSqlValue()),
               new SqlParameter("@IncludeDel", bIncludeDel.ToSqlValue()),
            };
            param[0].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_ExistsAreaNo", param);

            string ErrorMsg = param[0].Value.ToDBString();
            if(!string.IsNullOrEmpty(ErrorMsg))
            {
                throw new Exception(ErrorMsg);
            }
            return true;
            //if (ErrorMsg.StartsWith("执行错误"))
            //{
            //    throw new Exception(ErrorMsg);
            //}
            //else
            //{
            //    return string.IsNullOrEmpty(ErrorMsg);
            //}
        }

        public bool ExistsAreaNo(AreaInfo model, bool bIncludeDel,ref string ErrorMsg)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),

               new SqlParameter("@v_AreaNo", model.AreaNo.ToSqlValue()),
               new SqlParameter("@IncludeDel", bIncludeDel.ToSqlValue()),
            };
            param[0].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_ExistsAreaNo", param);

            ErrorMsg = param[0].Value.ToDBString();
            if (ErrorMsg.StartsWith("执行错误"))
            {
                throw new Exception(ErrorMsg);
            }
            else
            {
                return string.IsNullOrEmpty(ErrorMsg);
            }
        }

        public bool SaveArea(ref AreaInfo model)
        {
            SqlParameter[] param = GetParameterFromModel(model);

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_SaveArea", param);

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

        public bool DeleteAreaByID(AreaInfo model)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),

               new SqlParameter("@v_ID", model.ID.ToSqlValue()),
               
            };
            param[0].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_DeleteAreaByID", param);

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


        public SqlDataReader GetAreaByID(AreaInfo model)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM V_Area WHERE ID = {0}", model.ID);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }

        public SqlDataReader IsAreaChecking(AreaInfo model)
        {
            string strSql = string.Empty;
            strSql = string.Format("select areastatus,CheckID from T_AREA where areano='{0}'", model.AreaNo);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }

        public SqlDataReader GetAreaByAreaNo(AreaInfo model)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM V_Area WHERE AreaNo = '{0}'", model.AreaNo);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }


        #region Impoort


        public bool CheckImportTable(ref string strError)
        {
            try
            {
                string sql = @"
                create table T_P_IMPORTAREA
                (
                  warehouseid       NUMBER,
                  warehouseno       NVARCHAR2(50),
                  warehousename     NVARCHAR2(50),
                  warehouselocation NVARCHAR2(200),
                  warehousestatus   NUMBER,
                  houseid           NUMBER,
                  houseno           NVARCHAR2(50),
                  housename         NVARCHAR2(50),
                  houselocation     NVARCHAR2(200),
                  housestatus       NUMBER,
                  areaid            NUMBER,
                  areano            NVARCHAR2(50),
                  areaname          NVARCHAR2(50),
                  arealocation      NVARCHAR2(200),
                  areastatus        NUMBER,
                  areatype          NUMBER,
                  areatypename      NVARCHAR2(50),
                  importstatus      NUMBER,
                  importuser        NVARCHAR2(50),
                  importdate        DATE
                )
                ";

                OperationSql.ExecuteNonQuery2(CommandType.Text, sql);
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("ORA-00955") >= 0)
                    return true;
                strError = (ex.Message);
                return false;
            }
        }

        internal bool DealImport(ref string strError)
        {
            strError = string.Empty;
            SqlParameter[] para = new SqlParameter[]{
            new SqlParameter("ErrStrng",SqlDbType.NVarChar,200,ParameterDirection.Output,true,0,0,"ErrStrng",DataRowVersion.Default,strError)
            };
            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_ImportArea", para);
            strError = para[para.Length - 1].Value.ToString();
             
            if (string.IsNullOrEmpty(strError))
            {
                return true;
            }
            else if (strError.ToLower() == "null")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
