using BLL.Basic.User;
using BLL.Common;
using BLL.PrintBarcode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Check
{
    internal class CheckTrans_DB
    {
        private SqlParameter[] GetParameterFromModel(CheckTransInfo model)
        {
            int i;
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),

               new SqlParameter("@v_ID", SqlDbType.Int),
               new SqlParameter("@v_CheckID", SqlDbType.Int),
               new SqlParameter("@v_WarehouseNo",SqlDbType.NVarChar),
               new SqlParameter("@v_HouseNo", SqlDbType.NVarChar),
               new SqlParameter("@v_AreaNo", SqlDbType.NVarChar),
               new SqlParameter("@v_MaterialNo", SqlDbType.NVarChar),
               new SqlParameter("@v_MaterialDesc", SqlDbType.NVarChar),
               new SqlParameter("@v_Barcode", SqlDbType.NVarChar),
               new SqlParameter("@v_SerialNo", SqlDbType.NVarChar),
               new SqlParameter("@v_BatchNo", SqlDbType.NVarChar),
               new SqlParameter("@v_SN", SqlDbType.NVarChar),
               new SqlParameter("@v_ScanQty", SqlDbType.Decimal),
               new SqlParameter("@v_Operator", SqlDbType.NVarChar),
               new SqlParameter("@v_OperationTime", SqlDbType.DateTime),
               new SqlParameter("@v_MaterialStd", SqlDbType.NVarChar),
              };
            i = 1;
            param[i++].Value = model.ID;
            param[i++].Value = model.CheckID;
            param[i++].Value = model.WarehouseNo;
            param[i++].Value = model.HouseNo;
            param[i++].Value = model.AreaNo;
            param[i++].Value = model.MaterialNo;
            param[i++].Value = model.MaterialDesc;
            param[i++].Value = model.Barcode;
            param[i++].Value = model.SerialNo;
            param[i++].Value = model.BatchNo;
            param[i++].Value = model.SN;
            param[i++].Value = model.ScanQty;
            param[i++].Value = model.Operator;
            param[i++].Value = model.OperationTime;
            param[i++].Value = model.MaterialStd;



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


            i = 0;
            param[i++].Size = 1000;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 50;
            param[i++].Size = 50;
            param[i++].Size = 100;
            param[i++].Size = 100;
            param[i++].Size = 200;
            param[i++].Size = 50;
            param[i++].Size = 50;
            param[i++].Size = 50;
            param[i++].Size = 50;
            param[i++].Size = 18;
            param[i++].Size = 50;
            param[i++].Size = 30;
            param[i++].Size = 100;

            return param;
        }

        private SqlParameter[] GetListParameterFromModel(CheckTransInfo model)
        {
            int i;
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),

               new SqlParameter("@v_ID", SqlDbType.Int),
               new SqlParameter("@v_CheckID", SqlDbType.Int),
               new SqlParameter("@v_WarehouseNo",SqlDbType.NVarChar),
               new SqlParameter("@v_HouseNo", SqlDbType.NVarChar),
               new SqlParameter("@v_AreaNo", SqlDbType.NVarChar),
               new SqlParameter("@v_MaterialNo", SqlDbType.NVarChar),
               new SqlParameter("@v_MaterialDesc", SqlDbType.NVarChar),
               new SqlParameter("@v_Operator", SqlDbType.NVarChar),
               new SqlParameter("@v_OperationTime", SqlDbType.DateTime),
               new SqlParameter("@v_MaterialStd", SqlDbType.NVarChar),
               new SqlParameter("@xmlCheck", SqlDbType.Xml),

              };
            TrayDetails_Model traydetails = new TrayDetails_Model();
            traydetails.listBarcode = new List<string>();
            foreach (TrayDetails_Model item in model.ScanBarcode.tray_Model.listDetails)
            {
                traydetails.listBarcode.AddRange(item.listBarcode);
            }

            i = 1;
            param[i++].Value = model.ID;
            param[i++].Value = model.CheckID;
            param[i++].Value = model.WarehouseNo;
            param[i++].Value = model.HouseNo;
            param[i++].Value = model.AreaNo;
            param[i++].Value = model.MaterialNo;
            param[i++].Value = model.MaterialDesc;
            param[i++].Value = model.Operator;
            param[i++].Value = model.OperationTime;
            param[i++].Value = model.MaterialStd;
            param[i++].Value = XMLUtil.XmlUtil.Serializer(typeof(TrayDetails_Model), traydetails);

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
            param[i++].Direction = ParameterDirection.InputOutput;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;

            i = 0;
            param[i++].Size = 1000;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 50;
            param[i++].Size = 50;
            param[i++].Size = 100;
            param[i++].Size = 100;
            param[i++].Size = 200;
            param[i++].Size = 50;
            param[i++].Size = 30;
            param[i++].Size = 100;

            return param;
        }

        internal bool SaveCheckTrans(ref CheckTransInfo model)
        {
            model.OperationTime = DateTime.Now;
            SqlParameter[] param = GetParameterFromModel(model);

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_SaveCheckTrans", param);

            string ErrorMsg = param[0].Value.ToDBString();
            if (ErrorMsg.StartsWith("执行错误"))
            {
                throw new Exception(ErrorMsg);
            }
            else
            {
                model.ID = param[1].Value.ToInt32();
                model.OperationTime = param[param.Length - 1].Value.ToDateTime();
                return true;
            }
        }

        internal bool SaveCheckTransList(ref CheckTransInfo model)
        {
            model.OperationTime = DateTime.Now;
            SqlParameter[] param = GetListParameterFromModel(model);

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_SaveCheckTransList", param);

            string ErrorMsg = param[0].Value.ToDBString();
            if (ErrorMsg.StartsWith("执行错误"))
            {
                throw new Exception(ErrorMsg);
            }
            else
            {
                model.ID = param[1].Value.ToInt32();
                model.OperationTime = param[param.Length - 1].Value.ToDateTime();
                return true;
            }
        }

        private SqlParameter[] GetParameterFromModel(List<CheckTransInfo> modelList, UserInfo user)
        {
            int i;
            SqlParameter[] param = new SqlParameter[]{
               //new OracleParameter("@ErrorMsg",OracleDbType.NVarchar2,1000),
               
               //new OracleParameter("@v_Operator", user.UserNo.ToOracleValue()),
               //new OracleParameter("@xmlTransList", XMLUtil.XmlUtil.Serializer(typeof(CheckTransInfo),modelList)),
              };

            i = 0;
            param[i++].Direction = ParameterDirection.Output;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;

            i = 0;
            param[i++].Size = 1000;
            param[i++].Size = 50;
            //param[i++].Size = 4000;

            return param;
        }

        internal bool SaveCheckTransList(List<CheckTransInfo> modelList, UserInfo user)
        {
            SqlParameter[] param = GetParameterFromModel(modelList, user);

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_SaveCheckTransList", param);

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

        private SqlParameter[] GetParameterFromModel(string xmlTransList, UserInfo user)
        {
            int i;
            SqlParameter[] param = new SqlParameter[]{
               //new OracleParameter("@ErrorMsg",OracleDbType.NVarchar2,1000),
               
               //new OracleParameter("@v_Operator", user.UserNo.ToOracleValue()),
               //new OracleParameter("@xmlTransList", xmlTransList),
              };

            i = 0;
            param[i++].Direction = ParameterDirection.Output;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;

            i = 0;
            param[i++].Size = 1000;
            param[i++].Size = 50;
            //param[i++].Size = 4000;

            return param;
        }

        internal bool SaveCheckTransList(string xmlTransList, UserInfo user)
        {
            SqlParameter[] param = GetParameterFromModel(xmlTransList, user);

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_SaveCheckTransList", param);

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

        internal SqlDataReader GetCheckTransByID(CheckTransInfo model)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM T_CheckTrans WHERE ID = {0}", model.ID);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }


        internal SqlDataReader GetCheckTransListByCheck(CheckInfo check)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM T_CheckTrans WHERE CheckID = {0}", check.ID);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }
    }
}
