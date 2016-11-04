using BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BLL.Basic.User;
using BLL.Stock;
using BLL.TOOL;
//using System.Data.SqlClient;
//using JXBLL.DBA;

namespace BLL.PrintBarcode
{
    public class Barcode_DB
    {

        internal SqlDataReader GetBarcodeInfo(string strBarcode)
        {
            string strSerialNo = string.Empty;

            if (MaterialBarcodeDecode.InvalidBarcode(strBarcode) == false)
            {
                if (strBarcode.ToLower().StartsWith("http"))
                {
                    strSerialNo = strBarcode.Substring(strBarcode.LastIndexOf("?") + 4);
                }
                else
                    strSerialNo = strBarcode;
            }
            else
            {
                strSerialNo = MaterialBarcodeDecode.GetSerialNo(strBarcode);
            }
            string strSql = string.Empty;
            strSql = string.Format("select * from V_OUTBARCODE where serialno = '{0}' ", strSerialNo);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }

        internal bool IsTrayPermit(Barcode_Model model, ref string strError)
        {
            strError = string.Empty;
            if (model == null || model.TrayID == 0)
            {
                strError = "托盘信息不存在！";
                return false;
            }
            string strSql = string.Empty;
            strSql = string.Format("  select COUNT(distinct MATERIALNO) from T_OUTBARCODE where trayid = {0} ", model.TrayID);
            object obj = OperationSql.ExecuteScalar(CommandType.Text, strSql, null);
            if (obj.ToInt32() > 1) { strError = "该托盘下存在多个物料，不能整托盘点！"; return false; }
            return true;
        }

        internal bool IsCheckOmitAddPermit(Barcode_Model model, ref string strError)
        {
            strError = string.Empty;
            if (model == null)
            {
                strError = "条码不存在！";
                return false;
            }
            string strSql = string.Empty;
            object obj;
            //strSql = string.Format("  select ISNULL(checkid,0) from T_stock where serialno = '{0}' ", model.SERIALNO);
            //object obj = OperationSql.ExecuteScalar(CommandType.Text, strSql, null);
            //if (obj==null) { strError = "请确认物料条码是否正确！"; return false; }
            //else if(!obj.ToString().Equals("0")) { strError = "请确认物料盘点是否已做盈亏处理！"; return false; }
            strSql = string.Format("SELECT (CASE WHEN(ISNULL((SELECT COUNT(*) FROM T_StockOutDetails WHERE serialno = '{0}'), 0) + ISNULL((SELECT COUNT(*) FROM T_TransMoveDetails B WHERE serialno = '{0}'), 0) > 0) THEN 1 ELSE 0 END ) AS RESULT", model.SERIALNO);
            obj = OperationSql.ExecuteScalar(CommandType.Text, strSql, null);
            if(obj.ToString().Equals("1"))
            {
                strError = "该条码已经发货出库！"; return false;
            }
            return true;
        }

        internal bool MaterialCheckAble(int checkID, Barcode_Model model, bool isTray)
        {
            string strSql = string.Empty;
            List<string> lstBarcode = new List<string>();
            if (isTray)
            {
                foreach (var item in model.tray_Model.listDetails)
                {
                    lstBarcode.AddRange(item.listBarcode);
                }
            }
            else
            {
                lstBarcode.Add(model.SERIALNO);
            }
            foreach (var item in lstBarcode)
            {
                strSql = string.Format("select count(1) from t_Stock where status <> 1 and checkid is not null and checkid <> {0}  and serialno = '{1}'", checkID, item);
                object obj = OperationSql.ExecuteScalar(CommandType.Text, strSql, null);
                if (obj.ToInt32() >= 1) return false; 
            }

            return true;
        }

        internal bool IsChecked(int checkID, Barcode_Model model,bool isTray)
        {
            string strSql = string.Empty;
            List<string> lstBarcode = new List<string>();
            if (isTray)
            {
                foreach (var item in model.tray_Model.listDetails)
                {
                    lstBarcode.AddRange(item.listBarcode);
                }
            }
            else
            {
                lstBarcode.Add(model.SERIALNO);
            }
            foreach (var item in lstBarcode)
            {
                strSql = string.Format("select count(1) from v_checktrans where checkid={0} and serialno='{1}'", checkID, item);
                object obj = OperationSql.ExecuteScalar(CommandType.Text, strSql, null);
                if (obj.ToInt32() >= 1) return false; 
            }

            return true;
        }

        internal bool MaterialOfCheck(int checkID, Barcode_Model model,bool isTray,ref string strErrMsg)
        {
            string strSql = string.Empty;
            strErrMsg= string.Empty;
            strSql = string.Format("select count(1) from t_check where id = {0} and checktype in (4,5)", checkID);
            object obj = OperationSql.ExecuteScalar(CommandType.Text, strSql, null);
            if (obj.ToInt32() <= 0) return true;

            int checktype = 0;
            strSql = string.Format("select CheckType from t_check where id = {0}", checkID);
            checktype = OperationSql.ExecuteScalar(CommandType.Text, strSql, null).ToInt32();
            List<string> lstBarcode = new List<string>();
            if (isTray)
            {
                foreach (var item in model.tray_Model.listDetails)
                {
                    lstBarcode.AddRange(item.listBarcode);
                }
            }
            else
            {
                lstBarcode.Add(model.SERIALNO);
            }
            foreach (var item in lstBarcode)
            {
                switch (checktype)
                {
                    case 4:
                        strSql = string.Format("select count(1) from v_CheckDetails where checkid = {0} and materialno = '{1}' ", checkID, model.MATERIALNO);
                        obj = OperationSql.ExecuteScalar(CommandType.Text, strSql, null);
                        //if (obj.ToInt32() <= 0) return false;
                        if (obj.ToInt32() <= 0)
                        {
                            //strSql = string.Format("select count(1) from T_CHECKTRANS where checkid = {0} and materialno = '{1}' ", checkID, model.MATERIALNO);
                            //obj = OperationSql.ExecuteScalar(CommandType.Text, strSql, null);
                            //if (obj.ToInt32() <= 0)
                                strErrMsg = "该物料不属于当前盘点单";
                        }
                        break;

                    case 5:
                        strSql = string.Format("select count(1) from v_CheckDetails where checkid = {0} and materialno = '{1}' ", checkID, item);
                        obj = OperationSql.ExecuteScalar(CommandType.Text, strSql, null);
                        if (obj.ToInt32() <= 0) return false;
                        break;
                }
            }

            return true;
        }

        /// <summary>
        /// 根据外箱的id获取对应的内盒对象
        /// </summary>
        /// <param name="Barcode_Model"></param>
        /// <param name="innerBarcode"></param>
        /// <returns></returns>
        public bool GetInnertBarcodeByOutBarcodeId(Barcode_Model Barcode_Model, ref Barcode_Model innerBarcode)
        {
            bool IsResult = false;

            DataSet ds;
            SqlParameter[] cmdParms = new SqlParameter[] {
                new SqlParameter("OutBoxId",SqlDbType.Int),
                //new SqlParameter("ref_cursor",SqlDbType.RefCursor,ParameterDirection.Output)
                new SqlParameter("ref_cursor",SqlDbType.NVarChar)

           };

            cmdParms[0].Value = Barcode_Model.ID;
            cmdParms[1].Value = ParameterDirection.Output;

            ds = OperationSql.ExecuteDataSetForCursor1(OperationSql.connectionString, CommandType.StoredProcedure, "PROC_GETOUTBOXINFO", cmdParms);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                innerBarcode.lstInnerBarcode = TOOL.DataTableToList.DataSetToList<InnerBarcode_Model>(ds.Tables[0]);
                IsResult = true;
            }

            return IsResult;
        }
        /// <summary>
        /// 获取外箱的信息
        /// </summary>
        /// <param name="Barcode_Model"></param>
        /// <param name="lstbarcode"></param>
        /// <returns></returns>
        public bool GetOutBarcodeInfo(Barcode_Model Barcode_Model, ref List<Barcode_Model> lstbarcode)
        {
            int iResult = 0;
            DataSet ds;
            SqlParameter[] cmdParms = new SqlParameter[] {
                new SqlParameter("VoucherNo",SqlDbType.NVarChar),
                new SqlParameter("RowNo",SqlDbType.NVarChar),
                new SqlParameter("DeliveryNo",SqlDbType.NVarChar),
                new SqlParameter("MaterialNo",SqlDbType.NVarChar),
                //new SqlParameter("IsResult",SqlDbType.Int, ParameterDirection.Output),
                new SqlParameter("IsResult",SqlDbType.Int),

                //new SqlParameter("ref_cursor",SqlDbType.RefCursor,ParameterDirection.Output)
                new SqlParameter("ref_cursor",SqlDbType.NVarChar)

           };
            cmdParms[0].Value = Barcode_Model.VOUCHERNO;
            cmdParms[1].Value = Barcode_Model.ROWNO;
            cmdParms[2].Value = Barcode_Model.DELIVERYNO;
            cmdParms[3].Value = Barcode_Model.MATERIALNO;

            cmdParms[4].Value = ParameterDirection.Output;
            cmdParms[5].Value = ParameterDirection.Output;

            ds = OperationSql.ExecuteDataSetForCursor1(OperationSql.connectionString, CommandType.StoredProcedure, "PROC_GETOUTBOXINFO", cmdParms);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lstbarcode = TOOL.DataTableToList.DataSetToList<Barcode_Model>(ds.Tables[0]);
                iResult = 1;
            }


            return iResult == 1 ? true : false;
        }

        public bool CreateBarcodeInfo(Barcode_Model Barcode_Model, ref List<Barcode_Model> lstBarcode, ref List<InnerBarcode_Model> lstInnerBarcode, ref string strErrMsg)
        {
            if (!string.IsNullOrEmpty(Barcode_Model.WorkCode))
            {
                OperationSql.ExecuteNonQuery2(CommandType.Text, "INSERT INTO T_P_WEBLOG(TEXT) VALUES('" + Barcode_Model.WorkCode + "')", null);
            }

            int iResult = 0;
            DataSet ds;
            DataTable dtOutBarcode = new DataTable();
            DataTable dtInnerBarcode = new DataTable();

            #region Parameter

            SqlParameter[] cmdParms = new SqlParameter[] {

                new SqlParameter("v_VoucherNo",SqlDbType.NVarChar),
                new SqlParameter("v_RowNo",SqlDbType.NVarChar),
                new SqlParameter("v_DeliveryNo",SqlDbType.NVarChar),
                new SqlParameter("v_VoucherType",SqlDbType.Int),
                new SqlParameter("v_MaterialNo",SqlDbType.NVarChar),
                new SqlParameter("v_MaterialDesc",SqlDbType.NVarChar),
                new SqlParameter("v_CustomerNo",SqlDbType.NVarChar),
                new SqlParameter("v_CostomerName",SqlDbType.NVarChar),
                new SqlParameter("v_SupplierNo",SqlDbType.NVarChar),
                new SqlParameter("v_SupplierName",SqlDbType.NVarChar),
                new SqlParameter("v_BatchNo",SqlDbType.NVarChar),
                new SqlParameter("v_OutPackQty",SqlDbType.Int),
                new SqlParameter("v_InnerPackQty",SqlDbType.Int),
                new SqlParameter("v_VoucherQty",SqlDbType.Int),
                new SqlParameter("v_BatchQty",SqlDbType.Int),
                new SqlParameter("v_NoPack",SqlDbType.Int),
                new SqlParameter("v_PrintQty",SqlDbType.Int),
                new SqlParameter("v_BarcodeType",SqlDbType.Int),
                new SqlParameter("v_Prdversion",SqlDbType.NVarChar),
                new SqlParameter("v_PlatedGold",SqlDbType.Int),
                new SqlParameter("v_PlatedSilver",SqlDbType.Int),
                new SqlParameter("v_PlatedTin",SqlDbType.Int),
                new SqlParameter("v_Others",SqlDbType.Int),
                new SqlParameter("v_IsROHS",SqlDbType.Int),
                new SqlParameter("v_Operator",SqlDbType.NVarChar),
                new SqlParameter("v_TrackNo",SqlDbType.NVarChar),
                new SqlParameter("v_ReserveNumber",SqlDbType.NVarChar),
                new SqlParameter("v_ReserveRowNo",SqlDbType.NVarChar),
                new SqlParameter("v_Department",SqlDbType.NVarChar),
                new SqlParameter("v_Reason",SqlDbType.NVarChar),
                new SqlParameter("v_AndalaNo",SqlDbType.NVarChar),
                new SqlParameter("v_ReserveUser",SqlDbType.NVarChar),
                new SqlParameter("v_ShowSup",SqlDbType.Int),
                new SqlParameter("Barcode_Cur",new object()),
                new SqlParameter("ErrString",SqlDbType.VarChar,100) ,
                new SqlParameter("bResult",SqlDbType.Int)

            };
            cmdParms[33].Direction = ParameterDirection.Output;
            cmdParms[35].Direction = ParameterDirection.Output;
            cmdParms[35].Direction = ParameterDirection.Output;



            int i = 0;
            cmdParms[i++].Value = Barcode_Model.VOUCHERNO;
            cmdParms[i++].Value = Barcode_Model.ROWNO;
            cmdParms[i++].Value = Barcode_Model.DELIVERYNO;
            cmdParms[i++].Value = Barcode_Model.VOUCHERTYPE;
            cmdParms[i++].Value = Barcode_Model.MATERIALNO;
            cmdParms[i++].Value = Barcode_Model.MATERIALDESC;
            cmdParms[i++].Value = Barcode_Model.CUSCODE;
            cmdParms[i++].Value = Barcode_Model.CUSNAME;
            cmdParms[i++].Value = Barcode_Model.SUPCODE;
            cmdParms[i++].Value = Barcode_Model.SUPNAME;
            cmdParms[i++].Value = Barcode_Model.BATCHNO;
            cmdParms[i++].Value = Barcode_Model.OUTPACKQTY;
            cmdParms[i++].Value = Barcode_Model.INNERPACKQTY;
            cmdParms[i++].Value = Barcode_Model.VOUCHERQTY;
            cmdParms[i++].Value = Barcode_Model.BATCHQTY;
            cmdParms[i++].Value = Barcode_Model.NOPACK;
            cmdParms[i++].Value = Barcode_Model.PRINTQTY;
            cmdParms[i++].Value = Barcode_Model.BARCODETYPE;
            cmdParms[i++].Value = Barcode_Model.PRDVERSION;
            cmdParms[i++].Value = Barcode_Model.PLATEDGOLD;
            cmdParms[i++].Value = Barcode_Model.PLATEDSILVER;
            cmdParms[i++].Value = Barcode_Model.PLATEDTIN;
            cmdParms[i++].Value = Barcode_Model.OTHERS;
            cmdParms[i++].Value = Barcode_Model.ISROHS;
            cmdParms[i++].Value = Barcode_Model.OPERATOR;
            cmdParms[i++].Value = Barcode_Model.TrackNo;
            cmdParms[i++].Value = Barcode_Model.ReserveNumber;
            cmdParms[i++].Value = Barcode_Model.ReserveRowNo;
            cmdParms[i++].Value = Barcode_Model.Department;
            cmdParms[i++].Value = Barcode_Model.Reason;
            cmdParms[i++].Value = Barcode_Model.AndalaNo;
            cmdParms[i++].Value = Barcode_Model.ReserveUser;
            cmdParms[i++].Value = Barcode_Model.SHOWSUP;

            cmdParms[i++].Value = ParameterDirection.Output;
            cmdParms[i++].Value = ParameterDirection.Output;
            cmdParms[i++].Value = ParameterDirection.Output;

            #endregion


            ds = OperationSql.ExecuteDataSetForCursor(ref iResult, ref strErrMsg, OperationSql.connectionString, CommandType.StoredProcedure, "PROC_CREATEBOXBARCODE", cmdParms);


            if (iResult == 1)
            {
                lstBarcode = TOOL.DataTableToList.DataSetToList<Barcode_Model>(ds.Tables[0]);

                strErrMsg = string.Empty;
            }
            return iResult == 1 ? true : false;
        }

        public bool GetInnerBarcodeListByOutBarcodeList(List<Barcode_Model> lstBarcode, ref List<InnerBarcode_Model> lstInnerBarcode)
        {
            string strOutID = string.Empty;
            foreach (Barcode_Model model in lstBarcode)
            {
                strOutID += model.ID + ',';
            }
            strOutID = strOutID.Trim(',');

            string strSql = string.Empty;
            strSql = "SELECT A.OUTBARCODE AS OUTBARCODE,B.OUTBARCODE AS INNERBARCODE FROM T_OUTBARCODE A,T_OUTBARCODE B WHERE A.ID = B.PARENTID AND B.VOUCHERTYPE = 20 AND B.PARENTID IN (" + strOutID + ")";
            lstInnerBarcode = new List<InnerBarcode_Model>();
            InnerBarcode_Model barcode;
            using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, strSql, null))
            {
                barcode = new InnerBarcode_Model();
                barcode.OutBarcode = dr["OUTBARCODE"].ToString();
                barcode.InnerBarcode = dr["INNERBARCODE"].ToString();
                lstInnerBarcode.Add(barcode);
            }

            return true;
        }

        public bool GetOutBarcodeListByBarcode(Barcode_Model param, ref List<Barcode_Model> lstOutBarcode, ref string strError)
        {
            string strSql = "";
            strSql = string.Format("SELECT * FROM T_OUTBARCODE WHERE VOUCHERNO = '{0}' AND DELIVERYNO = '{1}' AND MATERIALNO = '{2}' ", param.VOUCHERNO, param.DELIVERYNO, param.MATERIALNO);
            DataSet ds = OperationSql.ExecuteDataSet(CommandType.Text, strSql);

            if (ds == null || ds.Tables[0].Rows.Count <= 0) return false;

            lstOutBarcode = TOOL.DataTableToList.DataSetToList<Barcode_Model>(ds.Tables[0]);

            return true;
        }

        public SqlDataReader GetOutBarcodeListByBarcode(Barcode_Model model)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM T_OUTBARCODE WHERE VOUCHERNO = '{0}' AND DELIVERYNO = '{1}' AND MATERIALNO = '{2}' ", model.VOUCHERNO, model.DELIVERYNO, model.MATERIALNO);
            if (!string.IsNullOrEmpty(model.ROWNO)) strSql += " AND ROWNO = '" + model.ROWNO + "' ";

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }

        public SqlDataReader GetOutBarcodeListByID(Barcode_Model model)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM T_OUTBARCODE WHERE ID = {0} ", model.ID);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }

        public int GetPrintedQtyByFilter(string strTable, string strFilter)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT ISNULL(sum(PrintQty),0) PrintedQty FROM {0} {1} ", strTable, strFilter);

            object obj = OperationSql.ExecuteScalar(CommandType.Text, strSql, null);
            if (obj == null || obj == DBNull.Value) return 0;

            return Convert.ToInt32(obj);
        }

        public List<Barcode_Model> GetFastInInfo(Barcode_Model taskInfo)
        {
            List<Barcode_Model> lst = new List<Barcode_Model>();
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM v_getfastininfo WHERE deliveryno = '{0}' ", taskInfo.VOUCHERNO);
            using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, strSql, null))
            {
                if (dr == null) return null;

                Barcode_Model model;
                while (dr.Read())
                {
                    model = new Barcode_Model();
                    //model.VOUCHERNO = dr["VOUCHERNO"].ToDBString();
                    model.VOUCHERNO = dr["DELIVERYNO"].ToDBString();
                    model.DELIVERYNO = dr["DELIVERYNO"].ToDBString();
                    model.VOUCHERTYPE = dr["VOUCHERTYPE"].ToDBString();
                    model.SUPCODE = dr["SUPCUSNO"].ToDBString();
                    model.SUPNAME = dr["SUPCUSNAME"].ToDBString();
                    model.MATERIALNO = dr["MATERIALNO"].ToDBString();
                    model.MATERIALDESC = dr["MATERIALDESC"].ToDBString();
                    model.CURRENTLYDELIVERYNUM = dr["TaskQty"].ToDecimal();
                    model.PrintedQty = dr["PrintedQty"].ToInt32();
                    model.StrVoucherType = dr["StrVoucherType"].ToDBString();
                    model.TrackNo = dr["VOUCHERNO"].ToDBString();
                    model.ISROHS = 1;

                    lst.Add(model);
                }
                if (dr != null && !dr.IsClosed) dr.Close();
            }

            return lst;
        }


        public bool SaveOutBarcde(ref Barcode_Model model)
        {
            SqlParameter[] param = GetParameterFromModel(model);

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_SaveOutBarcode", param);

            string ErrorMsg = param[0].Value.ToDBString();
            if (ErrorMsg.StartsWith("执行错误"))
            {
                throw new Exception(ErrorMsg);
            }
            else
            {
                model.ID = param[1].Value.ToInt32();
                return true;
            }
        }

        private SqlParameter[] GetParameterFromModel(Barcode_Model model)
        {
            int i;
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),

               new SqlParameter("@v_id",model.ID.ToSqlValue()),
               new SqlParameter("@v_voucherno",model.VOUCHERNO.ToSqlValue()),
               new SqlParameter("@v_rowno",model.ROWNO.ToSqlValue()),
               new SqlParameter("@v_deliveryno",model.DELIVERYNO.ToSqlValue()),
               new SqlParameter("@v_vouchertype",model.VOUCHERTYPE.ToSqlValue()),
               new SqlParameter("@v_materialno",model.MATERIALNO.ToSqlValue()),
               new SqlParameter("@v_materialdesc",model.MATERIALDESC.ToSqlValue()),
               new SqlParameter("@v_cuscode",model.CUSCODE.ToSqlValue()),
               new SqlParameter("@v_cusname",model.CUSNAME.ToSqlValue()),
               new SqlParameter("@v_supcode",model.SUPCODE.ToSqlValue()),
               new SqlParameter("@v_supname",model.SUPNAME.ToSqlValue()),
               new SqlParameter("@v_batchno",model.BATCHNO.ToSqlValue()),
               new SqlParameter("@v_outpackqty",model.OUTPACKQTY.ToSqlValue()),
               new SqlParameter("@v_innerpackqty",model.INNERPACKQTY.ToSqlValue()),
               new SqlParameter("@v_voucherqty",model.VOUCHERQTY.ToSqlValue()),
               new SqlParameter("@v_batchqty",model.BATCHQTY.ToSqlValue()),
               new SqlParameter("@v_qty",model.QTY.ToSqlValue()),
               new SqlParameter("@v_nopack",model.NOPACK.ToSqlValue()),
               new SqlParameter("@v_printqty",model.PRINTQTY.ToSqlValue()),
               new SqlParameter("@v_barcode",model.BARCODE.ToSqlValue()),
               new SqlParameter("@v_barcodetype",model.BARCODETYPE.ToSqlValue()),
               new SqlParameter("@v_serialno",model.SERIALNO.ToSqlValue()),
               new SqlParameter("@v_barcodeno",model.BARCODENO.ToSqlValue()),
               new SqlParameter("@v_prdversion",model.PRDVERSION.ToSqlValue()),
               new SqlParameter("@v_platedgold",model.PLATEDGOLD.ToSqlValue()),
               new SqlParameter("@v_platedsilver",model.PLATEDSILVER.ToSqlValue()),
               new SqlParameter("@v_platedtin",model.PLATEDTIN.ToSqlValue()),
               new SqlParameter("@v_others",model.OTHERS.ToSqlValue()),
               new SqlParameter("@v_operator",model.OPERATOR.ToSqlValue()),
               new SqlParameter("@v_operationdate",model.OPERATIONDATE.ToSqlValue()),
               new SqlParameter("@v_barcodeimg",model.BARCODEIMG.ToSqlValue()),
               new SqlParameter("@v_outcount",model.OUTCOUNT.ToSqlValue()),
               new SqlParameter("@v_innercount",model.INNERCOUNT.ToSqlValue()),
               new SqlParameter("@v_mantissaqty",model.MANTISSAQTY.ToSqlValue()),
               new SqlParameter("@v_isrohs",model.ISROHS.ToSqlValue()),
               new SqlParameter("@v_sn",model.SN.ToSqlValue()),
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

            i = 0;
            param[i++].Size = 1000;
            param[i++].Size = 18;
            param[i++].Size = 50;
            param[i++].Size = 10;
            param[i++].Size = 50;
            param[i++].Size = 10;
            param[i++].Size = 50;
            param[i++].Size = 100;
            param[i++].Size = 50;
            param[i++].Size = 100;
            param[i++].Size = 50;
            param[i++].Size = 100;
            param[i++].Size = 50;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 100;
            param[i++].Size = 18;
            param[i++].Size = 30;
            param[i++].Size = 18;
            param[i++].Size = 50;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 30;
            param[i++].Size = 30;
            param[i++].Size = 100;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 30;

            return param;
        }


        internal bool PrintBarcode(Barcode_Model Barcode_Model, ref string strErrMsg)
        {
            string strVoucherNo = string.Empty;
            switch (Barcode_Model.VOUCHERQTY.ToInt32())
            {
                case 10:
                    strVoucherNo = Barcode_Model.DELIVERYNO;
                    break;

                default:
                    strVoucherNo = Barcode_Model.VOUCHERNO;
                    break;
            }

            string strSql = string.Empty;
            strSql = string.Format("insert into t_printrecord (barcodetype, barcodeid, serialno, supcode, supname, printqty, printer, printtime, vouchertype, voucherno, rowno) values ({0}, {1}, '{2}', '{3}', '{4}', {5}, '{6}', sysdate, {7}, '{8}', '{9}')", Barcode_Model.BARCODETYPE, Barcode_Model.ID, Barcode_Model.SERIALNO, Barcode_Model.SUPCODE, Barcode_Model.SUPNAME, Barcode_Model.PRINTQTY, Barcode_Model.OPERATOR, Barcode_Model.VOUCHERTYPE, strVoucherNo, Barcode_Model.ROWNO);

            int i = OperationSql.ExecuteNonQuery2(CommandType.Text, strSql, null);
            if (i <= 0)
            {
                strErrMsg = "数据库操作失败,未能插入打印记录";
                return false;
            }

            return true;
        }

        internal SqlDataReader GetPurchaseByDelivery(Barcode_Model model)
        {
            string strSql = string.Empty;
            strSql = string.Format("select * from (select batchno, innerpackqty from t_Innerbarcode where voucherno = '{0}' and rowno = '{2}' order by operationdate desc) where rownum <= 1 ", model.VOUCHERNO, model.DELIVERYNO, model.ROWNO);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }


        internal bool CheckSerialNo(string SerialNo, string BatchNo, ref string strErrMsg)
        {
            //SerialNo箱号(流水号)4位
            //BatchNo标签打印日期6位+生成部门编码1位+(外箱)W
            //qty标签数量
            //barcodetype两位条码类型
            //11国外的成品外箱
            //15国内的成品外箱
            //10国外的成品内箱
            //14国内的成品内箱

            //查询T_SerialNo表中BatchNo的当前值
            string strSql = @"select SerialNo from T_SerialNo where SerialNo >= " + Convert.ToInt16(SerialNo).ToString() + " and BatchNo = '" + BatchNo + "'";
            using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, strSql, null))
            {
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        strErrMsg = "流水号已使用，请从" + (dr["SerialNo"].ToInt32() + 1).ToString() + "开始输入";
                        return false;
                    }
                    if (dr != null && !dr.IsClosed) dr.Close();
                }
            }
            return true;
        }

        internal bool NewCheckSerialNo(string SerialNo, int qty, string BatchNo, ref string strErrMsg)
        {
            int a = Convert.ToInt16(SerialNo);
            int b = qty;
            string strSql = @"select SerialNosArea from T_SerialArea where BatchNo = '" + BatchNo + "'";
            using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, strSql, null))
            {
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        string SerialNosArea = dr["SerialNosArea"].ToString();
                        string[] str_array = SerialNosArea.Split('@');
                        for (int i = 0; i < str_array.Length; i++)
                        {
                            int x = Convert.ToInt16(str_array[i].Split(',')[0]);
                            int y = Convert.ToInt16(str_array[i].Split(',')[1]);

                            if (a > (x + y - 1))
                                continue;
                            if (a >= x)
                            {
                                strErrMsg = "流水号" + x.ToString() + "到" + (x + y - 1).ToString() + "已使用，请重新输入正确的流水号!";
                                return false;
                            }
                            else
                            {
                                if ((a + b) > x)
                                {
                                    strErrMsg = "流水号" + x.ToString() + "到" + (x + y - 1).ToString() + "已使用，请重新输入正确的流水号!";
                                    return false;
                                }
                            }
                            continue;
                        }
                    }
                    if (dr != null && !dr.IsClosed) dr.Close();
                }
            }
            return true;
        }

        internal bool SaveInnerProductBarcodeForRead(List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            SqlTransaction myTran;
            myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = myTran;
            try
            {
                string BatchNo = label_lst[0].printdate + label_lst[0].plantno;
                string strSql = "";
                int r;
                for (int i = 0; i < label_lst.Count; i++)
                {
                    if (label_lst[i].outpackqty.Equals(""))
                    {
                        label_lst[i].outpackqty = "1";
                    }
                    //获取ID
                    cmd.CommandText = "P_GetNewSeqVal_SEQ_OUTBARCODEID";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                    cmd.Parameters.Clear();
                    if (label_lst[i].prdversion != null)
                    {
                        strSql += @"insert T_OUTBARCODE (id,barcodetype,voucherno,rowno,socode,outpackqty,qty,materialno,materialdesc,materialstd,barcode,cusname,Remark,operationdate,plantno,serialno,batchno,prdversion) values ("
                    + ID.ToString() + ",'" + label_lst[i].labeltype + "', '" + label_lst[i].POCode + "'," + label_lst[i].iMoSeq + ",'" + label_lst[i].ordercode + "'," + label_lst[i].outpackqty + "," + label_lst[i].outpackqty + ",'"
                    + label_lst[i].materialno + "','" + label_lst[i].materialdesc + "','" + label_lst[i].invstd + "','" + label_lst[i].barcode + "','" + label_lst[i].CUName + "','" + label_lst[i].Remark
                    + "',GETDATE(),'" + label_lst[i].plantno + "','" + label_lst[i].BarcodeExpress + "','" + BatchNo + "','" + label_lst[i].prdversion + "');";
                    }
                    else
                    {
                        strSql += @"insert T_OUTBARCODE (id,barcodetype,voucherno,rowno,socode,outpackqty,qty,materialno,materialdesc,materialstd,barcode,cusname,Remark,operationdate,plantno,serialno,batchno) values ("
                    + ID.ToString() + ",'" + label_lst[i].labeltype + "', '" + label_lst[i].POCode + "'," + label_lst[i].iMoSeq + ",'" + label_lst[i].ordercode + "'," + label_lst[i].outpackqty + "," + label_lst[i].outpackqty + ",'"
                    + label_lst[i].materialno + "','" + label_lst[i].materialdesc + "','" + label_lst[i].invstd + "','" + label_lst[i].barcode + "','" + label_lst[i].CUName + "','" + label_lst[i].Remark
                    + "',GETDATE(),'" + label_lst[i].plantno + "','" + label_lst[i].BarcodeExpress + "','" + BatchNo + "');";
                    }
                    if (strSql.Length > 5000)
                    {
                        cmd.CommandText = strSql;
                        cmd.CommandType = CommandType.Text;
                        r = cmd.ExecuteNonQuery();
                        if (r == 0)
                        {
                            strErrMsg = strSql + "保存数据失败";
                            myTran.Rollback();
                            conn.Close();
                            return false;
                        }
                        strSql = "";
                    }
                }
                if (strSql.Length > 0)
                {
                    cmd.CommandText = strSql;
                    cmd.CommandType = CommandType.Text;
                    r = cmd.ExecuteNonQuery();
                    if (r == 0)
                    {
                        strErrMsg = strSql + "保存数据失败";
                        myTran.Rollback();
                        conn.Close();
                        return false;
                    }
                }
                //更新T_SerialNo
                strSql = @"select SerialNosArea from T_SerialArea where BatchNo = '" + BatchNo + "'"; //@"select SerialNo from SerialNosArea where BatchNo = '" + BatchNo + "'";
                bool checkedSerialNo = false;
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            checkedSerialNo = true;
                            break;
                        }
                        if (dr != null && !dr.IsClosed) dr.Close();
                    }
                }
                if (!checkedSerialNo)
                {
                    strSql = @"insert T_SerialArea (SerialNosArea,BatchNo) values ('" + (Convert.ToInt16(label_lst[0].packno)).ToString() + "," + label_lst.Count.ToString() + "','" + BatchNo + "')";
                }
                else
                {
                    strSql = @"update T_SerialArea set SerialNosArea = SerialNosArea + '@" + (Convert.ToInt16(label_lst[0].packno)).ToString() + "," + label_lst.Count.ToString() + "' where BatchNo = '" + BatchNo + "'";
                }
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                r = cmd.ExecuteNonQuery();
                if (r == 0)
                {
                    strErrMsg = strSql + "保存数据失败";
                    myTran.Rollback();
                    conn.Close();
                    return false;
                }
                myTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                myTran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        internal bool CreateeOuterProductBarcodeForRead(ProductLabel_Model labelModel, int qty, ref List<ProductLabel_Model> label_inner, ref List<ProductLabel_Model> label_outer, ref string strErrMsg)
        {
            try
            {
                label_inner = new List<ProductLabel_Model>();
                string strSql = "";
                int OutSerialNo = GetSerialNo(labelModel.printdate + labelModel.plantno + "W") + 1;
                int InnerSerialNo = Convert.ToInt16(labelModel.packno);
                string BatchNo = labelModel.printdate + labelModel.plantno;
                label_outer = new List<ProductLabel_Model>();
                label_inner = new List<ProductLabel_Model>();
                for (int i = 0; i < qty; i++)
                {
                    ProductLabel_Model detail = new ProductLabel_Model();
                    detail.prdversion = labelModel.prdversion;
                    detail.iMoSeq = labelModel.iMoSeq;
                    detail.IsOuter = "W";
                    detail.labeltype = labelModel.labeltype;
                    detail.POCode = labelModel.POCode;
                    detail.ordercode = labelModel.ordercode;
                    detail.outpackqty = labelModel.outpackqty;
                    detail.materialno = labelModel.materialno;
                    detail.materialdesc = labelModel.materialdesc;
                    detail.invstd = labelModel.invstd;
                    detail.CUName = labelModel.CUName;
                    detail.Remark = labelModel.Remark;
                    detail.printdate = labelModel.printdate;
                    detail.plantno = labelModel.plantno;
                    detail.packno = (OutSerialNo + i).ToString().PadLeft(4, '0');
                    detail.BarcodeExpress = labelModel.printdate + labelModel.plantno + "W" + detail.packno;
                    detail.barcode = labelModel.labeltype + "@" + labelModel.materialno + "@" + labelModel.ordercode + "@" + labelModel.POCode + "@" + Convert.ToInt16(labelModel.outpackqty).ToString().PadLeft(4, '0') + "@" + detail.BarcodeExpress;
                    label_outer.Add(detail);
                    for (int j = 0; j < Convert.ToInt16(detail.outpackqty); j++)
                    {
                        ProductLabel_Model inner = new ProductLabel_Model();
                        inner.prdversion = labelModel.prdversion;
                        inner.iMoSeq = labelModel.iMoSeq;
                        inner.labeltype = labelModel.labeltype.Equals("11") ? "10" : "14";
                        inner.POCode = labelModel.POCode;
                        inner.ordercode = labelModel.ordercode;
                        inner.outpackqty = "";
                        inner.materialno = labelModel.materialno;
                        inner.materialdesc = labelModel.materialdesc;
                        inner.invstd = labelModel.invstd;
                        inner.CUName = labelModel.CUName;
                        inner.Remark = labelModel.Remark;
                        inner.printdate = labelModel.printdate;
                        inner.plantno = labelModel.plantno;
                        inner.packno = (InnerSerialNo).ToString().PadLeft(4, '0');
                        InnerSerialNo++;
                        inner.BarcodeExpress = labelModel.printdate + labelModel.plantno + inner.packno;
                        inner.barcode = labelModel.labeltype + "@" + labelModel.materialno + "@" + labelModel.ordercode + "@" + labelModel.POCode + "@0001@" + inner.BarcodeExpress;
                        label_inner.Add(inner);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
        }

        internal bool SaveOuterProductBarcodeForRead(List<ProductLabel_Model> label_inner, List<ProductLabel_Model> label_outer, ref string strErrMsg)
        {
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            SqlTransaction myTran;
            myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = myTran;
            try
            {
                string strSql = "";
                int r;
                for (int i = 0; i < label_outer.Count; i++)
                {
                    if (label_outer[i].outpackqty.Equals(""))
                    {
                        label_outer[i].outpackqty = "1";
                    }
                    //获取ID
                    cmd.CommandText = "P_GetNewSeqVal_SEQ_OUTBARCODEID";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                    cmd.Parameters.Clear();
                    if (label_outer[i].prdversion != null)
                    {
                        strSql += @"insert T_OUTBARCODE (id,barcodetype,voucherno,rowno,socode,outpackqty,qty,materialno,materialdesc,materialstd,barcode,cusname,Remark,operationdate,plantno,serialno,batchno,prdversion) values ("
                    + ID.ToString() + ",'" + label_outer[i].labeltype + "', '" + label_outer[i].POCode + "'," + label_outer[i].iMoSeq + ",'" + label_outer[i].ordercode + "'," + label_outer[i].outpackqty + "," + label_outer[i].outpackqty + ",'"
                    + label_outer[i].materialno + "','" + label_outer[i].materialdesc + "','" + label_outer[i].invstd + "','" + label_outer[i].barcode + "','" + label_outer[i].CUName + "','" + label_outer[i].Remark
                    + "',GETDATE(),'" + label_outer[i].plantno + "','" + label_outer[i].BarcodeExpress + "','" + label_outer[i].printdate + label_outer[i].plantno + "W','" + label_outer[i].prdversion + "');";
                    }
                    else
                    {
                        strSql += @"insert T_OUTBARCODE (id,barcodetype,voucherno,rowno,socode,outpackqty,qty,materialno,materialdesc,materialstd,barcode,cusname,Remark,operationdate,plantno,serialno,batchno) values ("
                    + ID.ToString() + ",'" + label_outer[i].labeltype + "', '" + label_outer[i].POCode + "'," + label_outer[i].iMoSeq + ",'" + label_outer[i].ordercode + "'," + label_outer[i].outpackqty + "," + label_outer[i].outpackqty + ",'"
                    + label_outer[i].materialno + "','" + label_outer[i].materialdesc + "','" + label_outer[i].invstd + "','" + label_outer[i].barcode + "','" + label_outer[i].CUName + "','" + label_outer[i].Remark
                    + "',GETDATE(),'" + label_outer[i].plantno + "','" + label_outer[i].BarcodeExpress + "','" + label_outer[i].printdate + label_outer[i].plantno + "W');";
                    }

                    for (int j = 0; j < Convert.ToInt16(label_outer[i].outpackqty); j++)
                    {
                        //获取InnerID
                        cmd.CommandText = "P_GetNewSeqVal_SEQ_INNERBARCODEID";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                        cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        int InnerID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                        cmd.Parameters.Clear();
                        if (label_inner[j].prdversion != null)
                        {
                            strSql += @"insert T_INNERBARCODE (id,barcodetype,voucherno,rowno,socode,innerpackqty,qty,outpackqty,materialno,materialdesc,materialstd,barcode,cusname,Remark,operationdate,plantno,serialno,outbox_id,batchno,prdversion) values ("
                            + InnerID.ToString() + ",'" + label_inner[0].labeltype + "', '" + label_inner[0].POCode + "'," + label_inner[0].iMoSeq + ",'" + label_inner[0].ordercode + "',1,1," + label_outer[i].outpackqty + ",'"
                            + label_inner[0].materialno + "','" + label_inner[0].materialdesc + "','" + label_inner[0].invstd + "','" + label_inner[i * Convert.ToInt16(label_outer[i].outpackqty) + j].barcode + "','" + label_inner[0].CUName + "','" + label_inner[0].Remark
                            + "',GETDATE(),'" + label_inner[0].plantno + "','" + label_inner[i * Convert.ToInt16(label_outer[i].outpackqty) + j].BarcodeExpress + "'," + ID.ToString() + ",'" + label_outer[i].printdate + label_outer[i].plantno + "','" + label_inner[j].prdversion + "');";
                        }
                        else
                        {
                            strSql += @"insert T_INNERBARCODE (id,barcodetype,voucherno,rowno,socode,innerpackqty,qty,outpackqty,materialno,materialdesc,materialstd,barcode,cusname,Remark,operationdate,plantno,serialno,outbox_id,batchno) values ("
                            + InnerID.ToString() + ",'" + label_inner[0].labeltype + "', '" + label_inner[0].POCode + "'," + label_inner[0].iMoSeq + ",'" + label_inner[0].ordercode + "',1,1," + label_outer[i].outpackqty + ",'"
                            + label_inner[0].materialno + "','" + label_inner[0].materialdesc + "','" + label_inner[0].invstd + "','" + label_inner[i * Convert.ToInt16(label_outer[i].outpackqty) + j].barcode + "','" + label_inner[0].CUName + "','" + label_inner[0].Remark
                            + "',GETDATE(),'" + label_inner[0].plantno + "','" + label_inner[i * Convert.ToInt16(label_outer[i].outpackqty) + j].BarcodeExpress + "'," + ID.ToString() + ",'" + label_outer[i].printdate + label_outer[i].plantno + "');";
                        }

                    }
                    if (strSql.Length > 5000)
                    {
                        cmd.CommandText = strSql;
                        cmd.CommandType = CommandType.Text;
                        r = cmd.ExecuteNonQuery();
                        if (r == 0)
                        {
                            strErrMsg = strSql + "保存数据失败";
                            myTran.Rollback();
                            conn.Close();
                            return false;
                        }
                        strSql = "";
                    }
                }
                if (strSql.Length > 0)
                {
                    cmd.CommandText = strSql;
                    cmd.CommandType = CommandType.Text;
                    r = cmd.ExecuteNonQuery();
                    if (r == 0)
                    {
                        strErrMsg = strSql + "保存数据失败";
                        myTran.Rollback();
                        conn.Close();
                        return false;
                    }
                }
                //更新T_SerialNo
                strSql = @"select SerialNosArea from T_SerialArea where BatchNo = '" + label_outer[0].printdate + label_outer[0].plantno + "W'";
                bool checkedSerialNo = false;
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            checkedSerialNo = true;
                            break;
                        }
                        if (dr != null && !dr.IsClosed) dr.Close();
                    }
                }
                if (!checkedSerialNo)
                {
                    strSql = @"insert T_SerialArea (SerialNosArea,BatchNo) values ('" + (Convert.ToInt16(label_outer[0].packno)).ToString() + "," + label_outer.Count.ToString() + "','" + label_outer[0].printdate + label_outer[0].plantno + "W')";
                }
                else
                {
                    strSql = @"update T_SerialArea set SerialNosArea = SerialNosArea + '@" + (Convert.ToInt16(label_outer[0].packno)).ToString() + "," + label_outer.Count.ToString() + "' where BatchNo = '" + label_outer[0].printdate + label_outer[0].plantno + "W'";
                }
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                r = cmd.ExecuteNonQuery();
                if (r == 0)
                {
                    strErrMsg = strSql + "保存数据失败";
                    myTran.Rollback();
                    conn.Close();
                    return false;
                }
                strSql = @"select SerialNosArea from T_SerialArea where BatchNo = '" + label_outer[0].printdate + label_outer[0].plantno + "'";
                checkedSerialNo = false;
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            checkedSerialNo = true;
                            break;
                        }
                        if (dr != null && !dr.IsClosed) dr.Close();
                    }
                }
                if (!checkedSerialNo)
                {
                    strSql = @"insert T_SerialArea (SerialNosArea,BatchNo) values ('" + (Convert.ToInt16(label_inner[0].packno)).ToString() + "," + label_inner.Count.ToString() + "','" + label_outer[0].printdate + label_outer[0].plantno + "')";
                }
                else
                {
                    strSql = @"update T_SerialArea set SerialNosArea = SerialNosArea + '@" + (Convert.ToInt16(label_inner[0].packno)).ToString() + "," + label_inner.Count.ToString() + "' where BatchNo = '" + label_outer[0].printdate + label_outer[0].plantno + "'";
                }
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                r = cmd.ExecuteNonQuery();
                if (r == 0)
                {
                    strErrMsg = strSql + "保存数据失败";
                    myTran.Rollback();
                    conn.Close();
                    return false;
                }
                myTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                myTran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        internal int GetSerialNo(string BatchNo)
        {
            //查询T_SerialNo表中BatchNo的当前值
            string strSql = @"select SerialNosArea from T_SerialArea where BatchNo = '" + BatchNo + "'";//@"select SerialNo from T_SerialNo where BatchNo = '" + BatchNo + "'";
            using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, strSql, null))
            {
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        string SerialNosArea = dr["SerialNosArea"].ToString();
                        string[] str_array = SerialNosArea.Split('@');
                        int x = Convert.ToInt16(str_array[str_array.Length - 1].Split(',')[0]);
                        int y = Convert.ToInt16(str_array[str_array.Length - 1].Split(',')[1]);
                        return x + y - 1;
                    }
                    if (dr != null && !dr.IsClosed) dr.Close();
                }
            }
            return 0;
        }

        internal bool CreateInnerProductBarcode(ProductLabel_Model labelModel, int qty, ref List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            SqlTransaction myTran;
            myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = myTran;
            try
            {
                label_lst = new List<ProductLabel_Model>();
                string BatchNo = labelModel.printdate + labelModel.plantno;
                string strSql = "";
                //labeltype,POCode,ordercode,SOCode,ContractNo,outpackqty,materialno,barcode,invstd,CUName,Remark,printdate,plantno,packno,BarcodeExpress,
                //string strSql = @"insert T_INNERBARCODE (id,barcodetype,POCode,voucherno,innerpackqty,materialno,materialdesc,invstd,barcode,cusname,Remark,operationdate,deliveryno,serialno,) values (" 
                //    + ID + ",'" + labelModel.labeltype + "', '" + labelModel.POCode + "','" + labelModel.ordercode + "'," + labelModel.outpackqty + ",'"
                //    + labelModel.materialno + "','" + labelModel.materialdesc + "','" + labelModel.invstd + "','" + labelModel.barcode + "','" + labelModel.CUName
                //    + "','" + labelModel.Remark + "',GETDATE()," + labelModel.plantno + "','" + labelModel.packno + "','" + labelModel.BarcodeExpress + "')";
                //新增T_INNERBARCODE表中的记录
                for (int i = 0; i < qty; i++)
                {
                    ProductLabel_Model detail = new ProductLabel_Model();
                    detail.IsOuter = "W";
                    detail.labeltype = labelModel.labeltype;
                    detail.POCode = labelModel.POCode;
                    detail.ordercode = labelModel.ordercode;
                    detail.outpackqty = labelModel.outpackqty;
                    detail.materialno = labelModel.materialno;
                    detail.materialdesc = labelModel.materialdesc;
                    detail.invstd = labelModel.invstd;
                    detail.CUName = labelModel.CUName;
                    detail.Remark = labelModel.Remark;
                    detail.printdate = labelModel.printdate;
                    detail.plantno = labelModel.plantno;
                    detail.packno = (Convert.ToInt16(labelModel.packno) + i).ToString().PadLeft(4, '0');
                    detail.BarcodeExpress = labelModel.printdate + labelModel.plantno + detail.packno;
                    detail.barcode = labelModel.labeltype + "@" + labelModel.materialno + "@" + labelModel.ordercode + "@" + labelModel.POCode + "@" + Convert.ToInt16(labelModel.outpackqty).ToString().PadLeft(4, '0') + "@" + detail.BarcodeExpress;
                    label_lst.Add(detail);
                    //获取ID
                    cmd.CommandText = "P_GetNewSeqVal_SEQ_OUTBARCODEID";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                    cmd.Parameters.Clear();
                    strSql += @"insert T_OUTBARCODE (id,barcodetype,voucherno,socode,outpackqty,qty,materialno,materialdesc,materialstd,barcode,cusname,Remark,operationdate,plantno,serialno,batchno) values ("
                    + ID.ToString() + ",'" + labelModel.labeltype + "', '" + labelModel.POCode + "','" + labelModel.ordercode + "'," + labelModel.outpackqty + "," + labelModel.outpackqty + ",'"
                    + labelModel.materialno + "','" + labelModel.materialdesc + "','" + labelModel.invstd + "','" + detail.barcode + "','" + labelModel.CUName + "','" + labelModel.Remark
                    + "',GETDATE(),'" + labelModel.plantno + "','" + detail.BarcodeExpress + "','" + BatchNo + "');";
                }
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                int r = cmd.ExecuteNonQuery();
                if (r == 0)
                {
                    strErrMsg = strSql + "保存数据失败";
                    myTran.Rollback();
                    conn.Close();
                    return false;
                }
                //更新T_SerialNo
                strSql = @"select SerialNo from T_SerialNo where BatchNo = '" + BatchNo + "'";
                bool checkedSerialNo = false;
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            checkedSerialNo = true;
                            break;
                        }
                        if (dr != null && !dr.IsClosed) dr.Close();
                    }
                }
                if (!checkedSerialNo)
                {
                    strSql = @"insert T_SerialNo (SerialNo,BatchNo) values (" + (Convert.ToInt16(label_lst[qty - 1].packno)).ToString() + ",'" + BatchNo + "')";
                }
                else
                {
                    strSql = @"update T_SerialNo set SerialNo = " + (Convert.ToInt16(label_lst[qty - 1].packno)).ToString() + " where BatchNo = '" + BatchNo + "'";
                }
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                r = cmd.ExecuteNonQuery();
                if (r == 0)
                {
                    strErrMsg = strSql + "保存数据失败";
                    myTran.Rollback();
                    conn.Close();
                    return false;
                }
                myTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                myTran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        internal bool CreateOuterProductBarcode(ProductLabel_Model labelModel, int qty, ref List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            SqlTransaction myTran;
            myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = myTran;
            try
            {
                label_lst = new List<ProductLabel_Model>();
                string strSql = "";
                int OutSerialNo = GetSerialNo(labelModel.printdate + labelModel.plantno + "W") + 1;
                int InnerSerialNo = Convert.ToInt16(labelModel.packno);
                string BatchNo = labelModel.printdate + labelModel.plantno;
                for (int i = 0; i < qty; i++)
                {
                    ProductLabel_Model detail = new ProductLabel_Model();
                    detail.IsOuter = "W";
                    detail.labeltype = labelModel.labeltype;
                    detail.POCode = labelModel.POCode;
                    detail.ordercode = labelModel.ordercode;
                    detail.outpackqty = labelModel.outpackqty;
                    detail.materialno = labelModel.materialno;
                    detail.materialdesc = labelModel.materialdesc;
                    detail.invstd = labelModel.invstd;
                    detail.CUName = labelModel.CUName;
                    detail.Remark = labelModel.Remark;
                    detail.printdate = labelModel.printdate;
                    detail.plantno = labelModel.plantno;
                    detail.packno = (OutSerialNo + i).ToString().PadLeft(4, '0');
                    detail.BarcodeExpress = labelModel.printdate + labelModel.plantno + "W" + detail.packno;
                    detail.barcode = labelModel.labeltype + "@" + labelModel.materialno + "@" + labelModel.ordercode + "@" + labelModel.POCode + "@" + Convert.ToInt16(labelModel.outpackqty).ToString().PadLeft(4, '0') + "@" + detail.BarcodeExpress;
                    label_lst.Add(detail);
                    //获取ID
                    cmd.CommandText = "P_GetNewSeqVal_SEQ_OUTBARCODEID";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                    cmd.Parameters.Clear();
                    strSql += @"insert T_OUTBARCODE (id,barcodetype,voucherno,socode,outpackqty,qty,materialno,materialdesc,materialstd,barcode,cusname,Remark,operationdate,plantno,serialno,batchno) values ("
                    + ID.ToString() + ",'" + labelModel.labeltype + "', '" + labelModel.POCode + "','" + labelModel.ordercode + "'," + labelModel.outpackqty + "," + labelModel.outpackqty + ",'"
                    + labelModel.materialno + "','" + labelModel.materialdesc + "','" + labelModel.invstd + "','" + detail.barcode + "','" + labelModel.CUName + "','" + labelModel.Remark
                    + "',GETDATE(),'" + labelModel.plantno + "','" + detail.BarcodeExpress + "','" + BatchNo + "W');";
                    for (int j = 0; j < Convert.ToInt16(detail.outpackqty); j++)
                    {
                        ProductLabel_Model inner = new ProductLabel_Model();
                        inner.labeltype = labelModel.labeltype.Equals("11") ? "10" : "14";
                        inner.POCode = labelModel.POCode;
                        inner.ordercode = labelModel.ordercode;
                        inner.outpackqty = "0001";
                        inner.materialno = labelModel.materialno;
                        inner.materialdesc = labelModel.materialdesc;
                        inner.invstd = labelModel.invstd;
                        inner.CUName = labelModel.CUName;
                        inner.Remark = labelModel.Remark;
                        inner.printdate = labelModel.printdate;
                        inner.plantno = labelModel.plantno;
                        inner.packno = (InnerSerialNo).ToString().PadLeft(4, '0');
                        InnerSerialNo++;
                        inner.BarcodeExpress = labelModel.printdate + labelModel.plantno + inner.packno;
                        inner.barcode = labelModel.labeltype + "@" + labelModel.materialno + "@" + labelModel.ordercode + "@" + labelModel.POCode + "@0001@" + inner.BarcodeExpress;
                        label_lst.Add(inner);
                        //获取InnerID
                        cmd.CommandText = "P_GetNewSeqVal_SEQ_INNERBARCODEID";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                        cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        int InnerID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                        cmd.Parameters.Clear();
                        strSql += @"insert T_INNERBARCODE (id,barcodetype,voucherno,socode,innerpackqty,qty,outpackqty,materialno,materialdesc,materialstd,barcode,cusname,Remark,operationdate,plantno,serialno,outbox_id,batchno) values ("
                            + InnerID.ToString() + ",'" + labelModel.labeltype + "', '" + labelModel.POCode + "','" + labelModel.ordercode + "',1,1," + detail.outpackqty + ",'"
                            + labelModel.materialno + "','" + labelModel.materialdesc + "','" + labelModel.invstd + "','" + inner.barcode + "','" + labelModel.CUName + "','" + labelModel.Remark
                            + "',GETDATE(),'" + labelModel.plantno + "','" + inner.BarcodeExpress + "'," + (ID + i).ToString() + ",'" + BatchNo + "');";
                    }
                }
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                int r = cmd.ExecuteNonQuery();
                if (r == 0)
                {
                    strErrMsg = strSql + "保存数据失败";
                    myTran.Rollback();
                    conn.Close();
                    return false;
                }
                //更新T_SerialNo
                strSql = @"select SerialNo from T_SerialNo where BatchNo = '" + BatchNo + "W'";
                bool checkedSerialNo = false;
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            checkedSerialNo = true;
                            break;
                        }
                        if (dr != null && !dr.IsClosed) dr.Close();
                    }
                }
                if (!checkedSerialNo)
                {
                    strSql = @"insert T_SerialNo (SerialNo,BatchNo) values (" + (OutSerialNo + qty - 1).ToString() + ",'" + BatchNo + "W')";
                }
                else
                {
                    strSql = @"update T_SerialNo set SerialNo = " + (OutSerialNo + qty - 1).ToString() + " where BatchNo = '" + BatchNo + "W'";
                }
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                r = cmd.ExecuteNonQuery();
                if (r == 0)
                {
                    strErrMsg = strSql + "保存数据失败";
                    myTran.Rollback();
                    conn.Close();
                    return false;
                }
                strSql = @"select SerialNo from T_SerialNo where BatchNo = '" + BatchNo + "'";
                checkedSerialNo = false;
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            checkedSerialNo = true;
                            break;
                        }
                        if (dr != null && !dr.IsClosed) dr.Close();
                    }
                }
                if (!checkedSerialNo)
                {
                    strSql = @"insert T_SerialNo (SerialNo,BatchNo) values (" + (InnerSerialNo - 1).ToString() + ",'" + BatchNo + "')";
                }
                else
                {
                    strSql = @"update T_SerialNo set SerialNo = " + (InnerSerialNo - 1).ToString() + " where BatchNo = '" + BatchNo + "'";
                }
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                r = cmd.ExecuteNonQuery();
                if (r == 0)
                {
                    strErrMsg = strSql + "保存数据失败";
                    myTran.Rollback();
                    conn.Close();
                    return false;
                }
                myTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                myTran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        internal bool ImportStock(List<Stock_Model> dt, ref string strErrMsg)
        {
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            SqlTransaction myTran;
            myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = myTran;
            try
            {
                string strSql = "";
                for (int i = 0; i < dt.Count; i++)
                {
                    //判断是否有相同的期初库存
                    int ID = -1;
                    cmd.CommandText = @"select ID from T_STOCK where batchno = '期初' and materialno = '" + dt[i].MaterialNo + "' and warehouseno = '" + dt[i].WarehouseNo + "' and houseno = '" + dt[i].HouseNo + "' and areano = '" + dt[i].AreaNo + "' ;";
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                ID = dr["ID"].ToInt32();
                                break;
                            }
                            if (dr != null && !dr.IsClosed) dr.Close();
                        }
                    }
                    if (ID >= 0)
                    {
                        strSql += @"update T_STOCK set qty=qty + " + dt[i].Qty.ToString("F0") + " where ID = " + ID.ToString() + ";";
                    }
                    else
                    {
                        //校验U8数据
                        bool U8checked = false;
                        string querysql = @"select cinvname,cinvstd from inventory where cinvcode = '" + dt[i].MaterialNo + "'";
                        using (SqlDataReader dr = OperationSql.ExecuteReaderForU8(CommandType.Text, querysql, null))
                        {
                            if (dr != null)
                            {
                                while (dr.Read())
                                {
                                    dt[i].MaterialDesc = dr["cinvname"].ToString();
                                    dt[i].MaterialStd = dr["cinvstd"].ToString();
                                    U8checked = true;
                                    break;
                                }
                                if (dr != null && !dr.IsClosed) dr.Close();
                            }
                        }
                        if (!U8checked)
                        {
                            strErrMsg = "第" + (i + 1).ToString() + "行的物料编码" + dt[i].MaterialNo + "在U8中不存在!";
                            myTran.Rollback();
                            conn.Close();
                            return false;
                        }
                        //获取ID
                        cmd.CommandText = "P_GetNewSeqVal_SEQ_STOCK";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                        cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                        cmd.Parameters.Clear();
                        Stock_Model stockmodel = dt[i];
                        strSql += @"insert T_STOCK (id,materialno,materialdesc,materialstd,warehouseno,houseno,areano,qty,status,isdel,batchno) values(" + ID.ToString() + ",'" + stockmodel.MaterialNo + "','" + stockmodel.MaterialDesc + "','" + stockmodel.MaterialStd + "','" + stockmodel.WarehouseNo + "','" + stockmodel.HouseNo + "','" + stockmodel.AreaNo + "'," + stockmodel.Qty.ToString("F0") + ",1,0,'期初');";
                    }
                }
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                int r = cmd.ExecuteNonQuery();
                if (r == 0)
                {
                    strErrMsg = strSql + "保存数据失败";
                    myTran.Rollback();
                    conn.Close();
                    return false;
                }
                myTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                myTran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        
        //internal bool CreateInitialProductBarcode(Stock_Model stockmodel, ProductLabel_Model labelModel, int qty, ref List<ProductLabel_Model> label_lst, ref string strErrMsg)
        //{
        //    string connString = OperationSql.connectionString;
        //    SqlCommand cmd = new SqlCommand();
        //    SqlConnection conn = new SqlConnection();
        //    SqlDataAdapter adp = new SqlDataAdapter();
        //    conn.ConnectionString = connString;
        //    try
        //    {
        //        conn.Open();
        //    }
        //    catch (Exception ex)
        //    {
        //        strErrMsg = ex.Message;
        //        return false;
        //    }
        //    SqlTransaction myTran;
        //    myTran = conn.BeginTransaction();
        //    cmd.Connection = conn;
        //    cmd.Transaction = myTran;
        //    try
        //    {
        //        label_lst = new List<ProductLabel_Model>();
        //        //string BatchNo = labelModel.printdate + labelModel.plantno;
        //        string strSql = "";
        //        //获取流水号
        //        int SerialNo = 1;
        //        cmd.CommandText = @"select SerialNo from T_SerialNo where BatchNo = '151120X'";
        //        cmd.CommandType = CommandType.Text;
        //        using (SqlDataReader dr = cmd.ExecuteReader())
        //        //using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, @"select SerialNo from T_SerialNo where BatchNo = '151112X'", null))
        //        {
        //            if (dr != null)
        //            {
        //                while (dr.Read())
        //                {
        //                    SerialNo = dr["SerialNo"].ToInt32() + 1;
        //                }
        //                if (dr != null && !dr.IsClosed) dr.Close();
        //            }
        //        }
        //        for (int i = 0; i < qty; i++)
        //        {
        //            ProductLabel_Model detail = new ProductLabel_Model();
        //            detail.IsOuter = "W";
        //            detail.labeltype = labelModel.labeltype;
        //            detail.outpackqty = labelModel.outpackqty;
        //            detail.materialno = labelModel.materialno;
        //            detail.materialdesc = labelModel.materialdesc;
        //            detail.invstd = labelModel.invstd;
        //            detail.Remark = labelModel.Remark;
        //            detail.printdate = "151120";
        //            detail.plantno = "X";
        //            detail.Locale = stockmodel.AreaNo; //stockmodel.WarehouseNo + "-" + stockmodel.HouseNo + "-" + stockmodel.AreaNo;
        //            //获取ID
        //            cmd.CommandText = "P_GetNewSeqVal_SEQ_OUTBARCODEID";
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
        //            cmd.Parameters["@id"].Direction = ParameterDirection.Output;
        //            cmd.ExecuteNonQuery();
        //            int ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);

        //            detail.packno = (SerialNo + i).ToString().PadLeft(6, '0');
        //            detail.BarcodeExpress = "151120X" + detail.packno;
        //            detail.barcode = labelModel.labeltype + "@" + labelModel.materialno + "@@@" + Convert.ToInt64(labelModel.outpackqty).ToString().PadLeft(4, '0') + "@" + detail.BarcodeExpress;
        //            label_lst.Add(detail);

        //            cmd.Parameters.Clear();
        //            strSql += @"insert T_OUTBARCODE (id,barcodetype,outpackqty,qty,materialno,materialdesc,materialstd,barcode,Remark,operationdate,plantno,serialno,batchno,iFlag) values ("
        //            + ID.ToString() + ",'" + labelModel.labeltype + "', " + labelModel.outpackqty + "," + labelModel.outpackqty + ",'"
        //            + labelModel.materialno + "','" + labelModel.materialdesc + "','" + labelModel.invstd + "','" + detail.barcode + "','" + labelModel.Remark
        //            + "',GETDATE(),'" + labelModel.plantno + "','" + detail.BarcodeExpress + "','151120X',2);";
        //            //获取STOCK_ID
        //            cmd.CommandText = "P_GetNewSeqVal_SEQ_STOCK";
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
        //            cmd.Parameters["@id"].Direction = ParameterDirection.Output;
        //            cmd.ExecuteNonQuery();
        //            int STOCK_ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
        //            cmd.Parameters.Clear();
        //            strSql += @"insert T_STOCK (id,materialno,materialdesc,materialstd,warehouseno,houseno,areano,qty,barcode,serialno,batchno,createtime,status,isdel) values(" + STOCK_ID.ToString() + ",'" + stockmodel.MaterialNo + "','" + stockmodel.MaterialDesc + "','" + stockmodel.MaterialStd + "','" + stockmodel.WarehouseNo + "','" + stockmodel.HouseNo + "','" + stockmodel.AreaNo + "'," + Convert.ToInt16(labelModel.outpackqty).ToString() + ",'" + detail.barcode + "','" + detail.BarcodeExpress + "','151120X',GETDATE(),1,0);";
        //            strSql += @"update T_STOCK set qty=qty - " + Convert.ToInt16(labelModel.outpackqty).ToString() + " where batchno = '期初' and materialno = '" + stockmodel.MaterialNo + "' and warehouseno = '" + stockmodel.WarehouseNo + "' and houseno = '" + stockmodel.HouseNo + "' and areano = '" + stockmodel.AreaNo + "' ;";
        //        }
        //        cmd.CommandText = strSql;
        //        cmd.CommandType = CommandType.Text;
        //        int r = cmd.ExecuteNonQuery();
        //        if (r == 0)
        //        {
        //            strErrMsg = strSql + "保存数据失败";
        //            myTran.Rollback();
        //            conn.Close();
        //            return false;
        //        }
        //        //更新T_SerialNo
        //        strSql = @"select SerialNo from T_SerialNo where BatchNo = '151120X'";
        //        bool checkedSerialNo = false;
        //        cmd.CommandText = strSql;
        //        cmd.CommandType = CommandType.Text;
        //        using (SqlDataReader dr = cmd.ExecuteReader())
        //        {
        //            if (dr != null)
        //            {
        //                while (dr.Read())
        //                {
        //                    checkedSerialNo = true;
        //                    break;
        //                }
        //                if (dr != null && !dr.IsClosed) dr.Close();
        //            }
        //        }
        //        if (!checkedSerialNo)
        //        {
        //            strSql = @"insert T_SerialNo (SerialNo,BatchNo) values (" + (Convert.ToInt64(label_lst[qty - 1].packno)).ToString() + ",'151120X')";
        //        }
        //        else
        //        {
        //            strSql = @"update T_SerialNo set SerialNo = " + (Convert.ToInt64(label_lst[qty - 1].packno)).ToString() + " where BatchNo = '151120X'";
        //        }
        //        cmd.CommandText = strSql;
        //        cmd.CommandType = CommandType.Text;
        //        r = cmd.ExecuteNonQuery();
        //        if (r == 0)
        //        {
        //            strErrMsg = strSql + "保存数据失败";
        //            myTran.Rollback();
        //            conn.Close();
        //            return false;
        //        }
        //        myTran.Commit();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        strErrMsg = ex.Message;
        //        myTran.Rollback();
        //        return false;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        internal bool RemoveStock(List<Stock_Model> dt, ref string strErrMsg)
        {
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            SqlTransaction myTran;
            myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = myTran;
            try
            {
                string strSql = "";
                for (int i = 0; i < dt.Count; i++)
                {
                    //判断是否有相同的期初库存
                    int ID = -1;
                    cmd.CommandText = @"select ID from T_STOCK where (batchno like '%X%' or batchno = '期初') and materialno = '" + dt[i].MaterialNo + "' and warehouseno = '" + dt[i].WarehouseNo + "' and houseno = '" + dt[i].HouseNo + "' and areano = '" + dt[i].AreaNo + "' ;";
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                ID = dr["ID"].ToInt32();
                                break;
                            }
                            if (dr != null && !dr.IsClosed) dr.Close();
                        }
                    }
                    if (ID >= 0)
                    {
                        strSql += @"delete T_STOCK where (batchno like '%X%' or batchno = '期初') and materialno = '" + dt[i].MaterialNo + "' and warehouseno = '" + dt[i].WarehouseNo + "' and houseno = '" + dt[i].HouseNo + "' and areano = '" + dt[i].AreaNo + "' ;";
                    }
                }
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                int r = cmd.ExecuteNonQuery();
                if (r == 0)
                {
                    strErrMsg = strSql + "删除数据失败";
                    myTran.Rollback();
                    conn.Close();
                    return false;
                }
                myTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                myTran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        internal bool CreateInitialProductBarcode(Stock_Model stockmodel, ProductLabel_Model labelModel, int qty, ref List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            SqlTransaction myTran;
            myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = myTran;
            try
            {
                label_lst = new List<ProductLabel_Model>();
                //string BatchNo = labelModel.printdate + labelModel.plantno;
                string strSql = "";
                //获取流水号
                int SerialNo = 1;
                cmd.CommandText = @"select SerialNo from T_SerialNo where BatchNo = '151120X'";
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                //using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, @"select SerialNo from T_SerialNo where BatchNo = '151112X'", null))
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            SerialNo = dr["SerialNo"].ToInt32() + 1;
                        }
                        if (dr != null && !dr.IsClosed) dr.Close();
                    }
                }
                for (int i = 0; i < qty; i++)
                {
                    ProductLabel_Model detail = new ProductLabel_Model();
                    detail.IsOuter = "W";
                    detail.labeltype = labelModel.labeltype;
                    detail.outpackqty = labelModel.outpackqty;
                    detail.materialno = labelModel.materialno;
                    detail.materialdesc = labelModel.materialdesc;
                    detail.invstd = labelModel.invstd;
                    detail.Remark = labelModel.Remark;
                    detail.printdate = "151120";
                    detail.plantno = "X";
                    detail.Locale = stockmodel.AreaNo; //stockmodel.WarehouseNo + "-" + stockmodel.HouseNo + "-" + stockmodel.AreaNo;
                    //获取ID
                    cmd.CommandText = "P_GetNewSeqVal_SEQ_OUTBARCODEID";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                    detail.packno = (SerialNo + i).ToString().PadLeft(6, '0');
                    detail.BarcodeExpress = "151120X" + detail.packno;
                    detail.barcode = labelModel.labeltype + "@" + labelModel.materialno + "@@@" + Convert.ToInt64(labelModel.outpackqty).ToString().PadLeft(4, '0') + "@" + detail.BarcodeExpress;
                    label_lst.Add(detail);

                    cmd.Parameters.Clear();
                    strSql += @"insert T_OUTBARCODE (id,barcodetype,outpackqty,qty,materialno,materialdesc,materialstd,barcode,Remark,operationdate,plantno,serialno,batchno,iFlag) values ("
                    + ID.ToString() + ",'" + labelModel.labeltype + "', " + labelModel.outpackqty + "," + labelModel.outpackqty + ",'"
                    + labelModel.materialno + "','" + labelModel.materialdesc + "','" + labelModel.invstd + "','" + detail.barcode + "','" + labelModel.Remark
                    + "',GETDATE(),'" + labelModel.plantno + "','" + detail.BarcodeExpress + "','151120X',2);";
                    //获取STOCK_ID
                    cmd.CommandText = "P_GetNewSeqVal_SEQ_STOCK";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int STOCK_ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                    cmd.Parameters.Clear();
                    strSql += @"insert T_STOCK (id,materialno,materialdesc,materialstd,warehouseno,houseno,areano,qty,barcode,serialno,batchno,createtime,status,isdel) values(" + STOCK_ID.ToString() + ",'" + stockmodel.MaterialNo + "','" + stockmodel.MaterialDesc + "','" + stockmodel.MaterialStd + "','" + stockmodel.WarehouseNo + "','" + stockmodel.HouseNo + "','" + stockmodel.AreaNo + "'," + Convert.ToInt16(labelModel.outpackqty).ToString() + ",'" + detail.barcode + "','" + detail.BarcodeExpress + "','151120X',GETDATE(),1,0);";
                    strSql += @"update T_STOCK set qty=qty - " + Convert.ToInt16(labelModel.outpackqty).ToString() + " where batchno = '期初' and materialno = '" + stockmodel.MaterialNo + "' and warehouseno = '" + stockmodel.WarehouseNo + "' and houseno = '" + stockmodel.HouseNo + "' and areano = '" + stockmodel.AreaNo + "' ;";
                }
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                int r = cmd.ExecuteNonQuery();
                if (r == 0)
                {
                    strErrMsg = strSql + "保存数据失败";
                    myTran.Rollback();
                    conn.Close();
                    return false;
                }
                //更新T_SerialNo
                strSql = @"select SerialNo from T_SerialNo where BatchNo = '151120X'";
                bool checkedSerialNo = false;
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            checkedSerialNo = true;
                            break;
                        }
                        if (dr != null && !dr.IsClosed) dr.Close();
                    }
                }
                if (!checkedSerialNo)
                {
                    strSql = @"insert T_SerialNo (SerialNo,BatchNo) values (" + (Convert.ToInt64(label_lst[qty - 1].packno)).ToString() + ",'151120X')";
                }
                else
                {
                    strSql = @"update T_SerialNo set SerialNo = " + (Convert.ToInt64(label_lst[qty - 1].packno)).ToString() + " where BatchNo = '151120X'";
                }
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                r = cmd.ExecuteNonQuery();
                if (r == 0)
                {
                    strErrMsg = strSql + "保存数据失败";
                    myTran.Rollback();
                    conn.Close();
                    return false;
                }
                myTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                myTran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        internal bool GetplantnoForPrint(string cInvCode, ref string plantno, ref string strErrMsg)
        {
            try
            {
                string strSql = @"select isnull(cinvDefine3,'') from inventory where cInvCode = '" + cInvCode + @"' ";
                string plantname = "";
                using (SqlDataReader dr = OperationSql.ExecuteReaderForU8(CommandType.Text, strSql, null))
                {
                    if (dr == null) return false;
                    while (dr.Read())
                    {
                        plantname = dr[0].ToString();
                    }
                    if (dr != null && !dr.IsClosed) dr.Close();
                }
                if (plantname.Equals(""))
                {
                    return false;
                }
                else
                {
                    strSql = @"select plantno from T_PLANT where plantname = '" + plantname + @"' ";
                    using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, strSql, null))
                    {
                        if (dr == null) return false;
                        while (dr.Read())
                        {
                            plantno = dr[0].ToString();
                        }
                        if (dr != null && !dr.IsClosed) dr.Close();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
        }

        internal bool RePrintByBarcode(bool isBunding, string serialno, int qty, ref List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            //labelModel = null;
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            cmd.Connection = conn;
            SqlCommand innercmd = new SqlCommand();
            SqlConnection innerconn = new SqlConnection();
            innerconn.ConnectionString = connString;
            innerconn.Open();
            innercmd.Connection = innerconn;
            try
            {
                label_lst = new List<ProductLabel_Model>();
                string strSql = "";
                //先查询外箱
                strSql = @"select * from T_OUTBARCODE where id >= (select id from T_OUTBARCODE where serialno = '" + serialno + "') and id < (select id from T_OUTBARCODE where serialno = '" + serialno + "') + " + qty.ToString();
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            //barcodetype,voucherno,socode,outpackqty,qty,materialno,materialdesc,materialstd,barcode,cusname,Remark,operationdate,plantno,serialno,batchno
                            ProductLabel_Model labelModel = new ProductLabel_Model();
                            labelModel = new ProductLabel_Model();
                            labelModel.IsOuter = "W";
                            labelModel.ID = dr["ID"].ToDBString();
                            labelModel.labeltype = dr["barcodetype"].ToDBString();
                            labelModel.POCode = dr["voucherno"].ToDBString();
                            labelModel.ordercode = dr["socode"].ToDBString();
                            labelModel.outpackqty = dr["outpackqty"].ToDBString();
                            labelModel.materialno = dr["materialno"].ToDBString();
                            labelModel.materialdesc = dr["materialdesc"].ToDBString();
                            labelModel.invstd = dr["materialstd"].ToDBString();
                            labelModel.CUName = dr["cusname"].ToDBString();
                            labelModel.Remark = dr["Remark"].ToDBString();
                            labelModel.printdate = dr["operationdate"].ToDBString();
                            labelModel.plantno = dr["plantno"].ToDBString();
                            //labelModel.packno = dr["barcodetype"].ToDBString();
                            labelModel.BarcodeExpress = dr["serialno"].ToDBString();
                            labelModel.barcode = dr["barcode"].ToDBString();
                            labelModel.prdversion = dr["prdversion"].ToDBString();
                            label_lst.Add(labelModel);
                            //判断是否绑定内盒
                            if (isBunding)
                            {
                                strSql = @"select * from T_INNERBARCODE where outbox_id = " + labelModel.ID;

                                innercmd.CommandText = strSql;
                                innercmd.CommandType = CommandType.Text;
                                using (SqlDataReader innerdr = innercmd.ExecuteReader())
                                {
                                    if (innerdr != null)
                                    {
                                        while (innerdr.Read())
                                        {
                                            ProductLabel_Model inner = new ProductLabel_Model();
                                            inner.IsOuter = "";
                                            inner.ID = innerdr["ID"].ToDBString();
                                            inner.labeltype = innerdr["barcodetype"].ToDBString();
                                            inner.POCode = innerdr["voucherno"].ToDBString();
                                            inner.ordercode = innerdr["socode"].ToDBString();
                                            inner.outpackqty = innerdr["innerpackqty"].ToDBString();
                                            inner.materialno = innerdr["materialno"].ToDBString();
                                            inner.materialdesc = innerdr["materialdesc"].ToDBString();
                                            inner.invstd = innerdr["materialstd"].ToDBString();
                                            inner.CUName = innerdr["cusname"].ToDBString();
                                            inner.Remark = innerdr["Remark"].ToDBString();
                                            inner.printdate = innerdr["operationdate"].ToDBString();
                                            inner.plantno = innerdr["plantno"].ToDBString();
                                            //labelModel.packno = dr["barcodetype"].ToDBString();
                                            inner.BarcodeExpress = innerdr["serialno"].ToDBString();
                                            inner.barcode = innerdr["barcode"].ToDBString();
                                            inner.prdversion = innerdr["prdversion"].ToDBString();
                                            label_lst.Add(inner);
                                        }
                                        if (innerdr != null && !innerdr.IsClosed) innerdr.Close();
                                    }
                                }
                            }
                            //break;
                        }
                        if (dr != null && !dr.IsClosed) dr.Close();
                    }
                }
                if (label_lst.Count == 0)
                {
                    //查询内箱
                    strSql = "select * from T_INNERBARCODE where id >= (select id from T_INNERBARCODE where serialno = '" + serialno + "') and id < (select id from T_INNERBARCODE where serialno = '" + serialno + "') + " + qty.ToString();
                    cmd.CommandText = strSql;
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                ProductLabel_Model labelModel = new ProductLabel_Model();
                                labelModel.IsOuter = "";
                                labelModel.ID = dr["ID"].ToDBString();
                                labelModel.labeltype = dr["barcodetype"].ToDBString();
                                labelModel.POCode = dr["voucherno"].ToDBString();
                                labelModel.ordercode = dr["socode"].ToDBString();
                                labelModel.outpackqty = dr["innerpackqty"].ToDBString();
                                labelModel.materialno = dr["materialno"].ToDBString();
                                labelModel.materialdesc = dr["materialdesc"].ToDBString();
                                labelModel.invstd = dr["materialstd"].ToDBString();
                                labelModel.CUName = dr["cusname"].ToDBString();
                                labelModel.Remark = dr["Remark"].ToDBString();
                                labelModel.printdate = dr["operationdate"].ToDBString();
                                labelModel.plantno = dr["plantno"].ToDBString();
                                //labelModel.packno = dr["barcodetype"].ToDBString();
                                labelModel.BarcodeExpress = dr["serialno"].ToDBString();
                                labelModel.barcode = dr["barcode"].ToDBString();
                                labelModel.prdversion = dr["prdversion"].ToDBString();
                                label_lst.Add(labelModel);
                                //break;
                            }
                            if (dr != null && !dr.IsClosed) dr.Close();
                        }
                    }
                }
                if (label_lst.Count == 0)
                {
                    strErrMsg = "找不到条码";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            finally
            {
                conn.Close();
                innerconn.Close();
            }
        }

        internal bool RePrintChangeSave(List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            SqlTransaction myTran;
            myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = myTran;
            string strSql = "";
            try
            {
                //if (label_lst[0].IsOuter.Equals("W"))
                //{
                //    strSql = @"update T_OUTBARCODE set remark = '" + label_lst[0].Remark + @"', materialstd = '" + label_lst[0].invstd + @"',cusname = '" + label_lst[0].CUName + @"', socode = '" + label_lst[0].ordercode + "' where ID >= " + label_lst[0].ID + @" and ID <= " + label_lst[label_lst.Count - 1].ID + ";";
                //}
                //else
                //{
                //    strSql = @"update T_INNERBARCODE set remark = '" + label_lst[0].Remark + @"', materialstd = '" + label_lst[0].invstd + @"',cusname = '" + label_lst[0].CUName + @"', socode = '" + label_lst[0].ordercode + "' where ID >= " + label_lst[0].ID + @" and ID <= " + label_lst[label_lst.Count - 1].ID + ";";
                //}
                //cmd.CommandText = strSql;
                //cmd.CommandType = CommandType.Text;
                //int r = cmd.ExecuteNonQuery();
                //if (r == 0)
                //{
                //    strErrMsg = strSql + "保存数据失败";
                //    myTran.Rollback();
                //    conn.Close();
                //    return false;
                //}
                int i = 0;
                foreach (ProductLabel_Model labelModel in label_lst)
                {

                    if (labelModel.IsOuter.Equals("W"))
                    {
                        strSql += @"update T_OUTBARCODE set barcode = '" + labelModel.barcode + @"', remark = '" + label_lst[0].Remark + @"', materialstd = '" + label_lst[0].invstd + @"',cusname = '" + label_lst[0].CUName + @"', socode = '" + label_lst[0].ordercode + "' where serialno = '" + labelModel.BarcodeExpress + @"';";
                    }
                    else
                    {
                        strSql += @"update T_INNERBARCODE set barcode = '" + labelModel.barcode + @"', remark = '" + label_lst[0].Remark + @"', materialstd = '" + label_lst[0].invstd + @"',cusname = '" + label_lst[0].CUName + @"', socode = '" + label_lst[0].ordercode + "' where serialno = '" + labelModel.BarcodeExpress + @"';";
                    }
                    i++;
                    if (i > 9)
                    {
                        cmd.CommandText = strSql;
                        cmd.CommandType = CommandType.Text;
                        int r = cmd.ExecuteNonQuery();
                        if (r == 0)
                        {
                            strErrMsg = strSql + "保存数据失败";
                            myTran.Rollback();
                            conn.Close();
                            return false;
                        }
                        i = 0;
                        strSql = "";
                    }
                }
                if (i > 0)
                {
                    cmd.CommandText = strSql;
                    cmd.CommandType = CommandType.Text;
                    int r = cmd.ExecuteNonQuery();
                    if (r == 0)
                    {
                        strErrMsg = strSql + "保存数据失败";
                        myTran.Rollback();
                        conn.Close();
                        return false;
                    }
                    i = 0;
                    strSql = "";
                }
                myTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        internal bool PrintDelete(List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            SqlTransaction myTran;
            myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = myTran;
            string strSql = "";
            string SerialArea = "";
            string ReplaceArea = "";
            List<int> replaceserial = new List<int>();
            List<int> innerserial = new List<int>();
            string innerBatchNo = "";
            string BatchNo = "";
            if (label_lst[0].BarcodeExpress.IndexOf("W") > 0)
            {
                BatchNo = label_lst[0].BarcodeExpress.Substring(0, 8);
            }
            else
            {
                BatchNo = label_lst[0].BarcodeExpress.Substring(0, 7);
            }
            try
            {
                int i = 0;
                strSql = "select TRAYID from T_OUTBARCODE where TRAYID is not null and serialno in (";
                foreach (ProductLabel_Model labelModel in label_lst)
                {
                    if (labelModel.IsOuter.Equals("W"))
                    {
                        strSql = strSql + labelModel.BarcodeExpress + ",";
                        if (BatchNo.Length > 7)
                        {
                            replaceserial.Add(int.Parse(labelModel.BarcodeExpress.Substring(8)));
                        }
                        else
                        {
                            replaceserial.Add(int.Parse(labelModel.BarcodeExpress.Substring(7)));
                        }
                    }
                    else
                    {
                        innerserial.Add(int.Parse(labelModel.BarcodeExpress.Substring(7)));
                        innerBatchNo = labelModel.BarcodeExpress.Substring(0, 7);
                    }
                }
                strSql = strSql + ")";
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = null;
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    strErrMsg = "条码已组托，不能删除";
                    return false;
                }
                else
                {
                    reader.Close();
                }
                strSql = "";
                foreach (ProductLabel_Model labelModel in label_lst)
                {

                    if (labelModel.IsOuter.Equals("W"))
                    {
                        strSql += @"delete T_OUTBARCODE where TRAYID is null and serialno = '" + labelModel.BarcodeExpress + @"';";
                    }
                    else
                    {
                        strSql += @"delete T_INNERBARCODE where serialno = '" + labelModel.BarcodeExpress + @"';";
                    }
                    i++;
                    if (i > 9)
                    {
                        cmd.CommandText = strSql;
                        cmd.CommandType = CommandType.Text;
                        int r = cmd.ExecuteNonQuery();
                        if (r == 0)
                        {
                            strErrMsg = strSql + "删除数据失败";
                            myTran.Rollback();
                            conn.Close();
                            return false;
                        }
                        i = 0;
                        strSql = "";
                    }
                }
                if (i > 0)
                {
                    cmd.CommandText = strSql;
                    cmd.CommandType = CommandType.Text;
                    int r = cmd.ExecuteNonQuery();
                    if (r == 0)
                    {
                        strErrMsg = strSql + "删除数据失败";
                        myTran.Rollback();
                        conn.Close();
                        return false;
                    }
                    i = 0;
                    strSql = "";
                }
                myTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        internal bool QueryPrintSerialNo(string BatchNo, ref List<string> querylist, ref string strErrMsg)
        {
            try
            {
                List<int> lst_a = new List<int>();
                List<int> lst_b = new List<int>();
                string strSql = @"select SerialNosArea from T_SerialArea where BatchNo = '" + BatchNo + "'";
                using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, strSql, null))
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            string SerialNosArea = dr["SerialNosArea"].ToString();
                            string[] str_array = SerialNosArea.Split('@');
                            for (int i = 0; i < str_array.Length; i++)
                            {
                                int x = Convert.ToInt16(str_array[i].Split(',')[0]);
                                int y = Convert.ToInt16(str_array[i].Split(',')[1]);
                                lst_a.Add(x);
                                lst_b.Add(x + y - 1);
                            }
                        }
                        if (dr != null && !dr.IsClosed) dr.Close();
                    }
                }
                if (lst_a.Count == 0)
                {
                    querylist = null;
                    strErrMsg = "没有该批次的序列号";
                    return false;
                }
                lst_a.Sort();
                lst_b.Sort();
                querylist = new List<string>();
                for (int i = 0; i < lst_a.Count; i++)
                {
                    querylist.Add(lst_a[i].ToString() + "到" + lst_b[i].ToString() + "的序列号已使用");
                }
                return true;
            }
            catch (Exception ex)
            {
                querylist = null;
                strErrMsg = ex.Message;
                return false;
            }
        }

        public bool ResetBarCode(string strArraySerialNo, UserInfo userMoel, ref string strErrMsg)
        {
            string[] ArraySerialNo = strArraySerialNo.Split(',');

            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = OperationSql.connectionString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }

            SqlTransaction myTran;
            myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = myTran;
            SqlDataReader reader = null;
            string sql = null;
            try
            {
                foreach (var item in ArraySerialNo)
                {
                    sql = string.Format("select ISNULL(iFlag,0) from t_outbarcode where SERIALNO='{0}'", item);
                    cmd.CommandText = sql;
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (!reader[0].ToString().Equals("2") && !reader[0].ToString().Equals("3"))
                        {
                            strErrMsg = "该功能只针对已经入库的成品条码！";
                            reader.Close();
                            throw new Exception(strErrMsg);
                        }
                        reader.Close();
                    }
                    else
                    {
                        strErrMsg = "序列号：" + item + "不存在！";
                        reader.Close();
                        throw new Exception(strErrMsg);
                    }

                }
                foreach (var item in ArraySerialNo)
                {
                    sql = string.Format("update T_OUTBARCODE SET iFlag=NULL WHERE SERIALNO='{0}'", item);
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    sql = string.Format("DELETE FROM T_STOCK WHERE SERIALNO='{0}'", item);
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                myTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                myTran.Rollback();
                return false;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
                conn.Close();
            }
        }

        public bool GetPrintedProductCount(string MoCode, string rowno, ref int qty, ref string strErrMsg)
        {
            string strSql = @"select sum(qty) as sum from T_OUTBARCODE where voucherno = '" + MoCode + "' and rowno = '" + rowno + "' group by voucherno,rowno ";
            bool isPrinted = false;
            try
            {
                using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, strSql, null))
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            qty = dr["sum"].ToInt32();
                            isPrinted = true;
                            break;
                        }
                        if (dr != null && !dr.IsClosed) dr.Close();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
        }

        public bool QueryBarcodeDetailsReport(string barcode, string voucherno, string rowno, string Socode, string Covenantcode, string materialno, string materialdesc, string materialstd, out List<BarcodeReport_Model> lst, out string strErrMsg)
        {
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                lst = null;
                return false;
            }
            //SqlTransaction myTran;
            //myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            //cmd.Transaction = myTran;
            try
            {
                //先获取ERP中的生产订单号及行号，并通过已有条件进行筛选
                string sql = @"IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_NAME =N'temp_voucher') Drop Table [temp_voucher]";
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                sql = @"select voucherno,rowno into [temp_voucher] from T_OUTBARCODE where (voucherno is not null and rowno is not null) ";//外箱
                if (barcode != null)
                {
                    sql = sql + "and serialno = '" + barcode + "' ";
                }
                if (voucherno != null)
                {
                    sql = sql + "and voucherno = '" + voucherno + "' ";
                }
                if (Covenantcode != null)
                {
                    sql = sql + "and Socode = '" + Covenantcode + "' ";
                }
                if (materialno != null)
                {
                    sql = sql + "and materialno = '" + materialno + "' ";
                }
                if (materialdesc != null)
                {
                    sql = sql + "and materialdesc = '" + materialdesc + "' ";
                }
                if (materialstd != null)
                {
                    sql = sql + "and materialstd = '" + materialstd + "' ";
                }

                sql = sql + " group by voucherno,rowno; ";
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                sql = @"insert into [temp_voucher](voucherno,rowno) select voucherno,rowno from T_INNERBARCODE where (1=1) ";//内盒
                if (barcode != null)
                {
                    sql = sql + "and serialno = '" + barcode + "' ";
                }
                if (voucherno != null)
                {
                    sql = sql + "and voucherno = '" + voucherno + "' ";
                }
                if (Covenantcode != null)
                {
                    sql = sql + "and Socode = '" + Covenantcode + "' ";
                }
                if (materialno != null)
                {
                    sql = sql + "and materialno = '" + materialno + "' ";
                }
                if (materialdesc != null)
                {
                    sql = sql + "and materialdesc = '" + materialdesc + "' ";
                }
                if (materialstd != null)
                {
                    sql = sql + "and materialstd = '" + materialstd + "' ";
                }

                sql = sql + " group by voucherno,rowno; ";
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                //再从ERP数据库中获取销售订单号及订单数量，并通过已有条件进行筛选
                sql = @"if exists(select 1 from master.dbo.sysservers where srvname='ITSV')
begin
    EXEC sp_dropserver 'ITSV','droplogins' 
end   ";
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                sql = @" exec sp_addlinkedserver   'ITSV', '', 'SQLOLEDB ', '" + OperationSql.GetU8BaseInfo().DBService + @"'; ";
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                sql = @" exec sp_addlinkedsrvlogin 'ITSV', 'false ',null, '" + OperationSql.GetU8BaseInfo().sqlUser + "', '" + OperationSql.GetU8BaseInfo().sqlPassword + @"' ;";
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                sql = @"IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_NAME =N'temp_2') Drop Table [temp_2] ";
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                sql = @"select m2.Define22 as LineCode,m2.Define24 as ordercode,m2.SoCode ,m1.MoCode,m2.SortSeq,m2.InvCode,i.cInvName,i.cInvStd,m2.Qty,m2.QualifiedInQty,m2.Define25 
    into [temp_2] from [ITSV].[UFDATA_" + OperationSql.GetU8BaseInfo().accID + "_" + OperationSql.GetU8BaseInfo().year + @"].dbo.mom_order m1
    inner join [ITSV].[UFDATA_" + OperationSql.GetU8BaseInfo().accID + "_" + OperationSql.GetU8BaseInfo().year + @"].dbo.mom_orderdetail m2 on  m1.Moid=m2.Moid 
    inner join [ITSV].[UFDATA_" + OperationSql.GetU8BaseInfo().accID + "_" + OperationSql.GetU8BaseInfo().year + @"].dbo.mom_morder m4 on m4.MoDId = m2.MoDId  
    inner join [ITSV].[UFDATA_" + OperationSql.GetU8BaseInfo().accID + "_" + OperationSql.GetU8BaseInfo().year + @"].dbo.inventory i on m2.InvCode=i.cInvCode 
    inner join [temp_voucher] on ([temp_voucher].voucherno= m1.MoCode and  [temp_voucher].rowno= m2.SortSeq)
    where (1=1)  ";
                if (voucherno != null)
                {
                    sql = sql + "and m1.MoCode = '" + voucherno + "' ";
                }
                if (Socode != null)
                {
                    sql = sql + "and Socode = '" + Socode + "' ";
                }
                if (materialno != null)
                {
                    sql = sql + "and m2.InvCode = '" + materialno + "' ";
                }
                if (materialdesc != null)
                {
                    sql = sql + "and i.cInvName = '" + materialdesc + "' ";
                }
                if (materialstd != null)
                {
                    sql = sql + "and i.cInvStd = '" + materialstd + "' ";
                }
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                int r = cmd.ExecuteNonQuery();
                if (r == 0)
                {
                    strErrMsg = sql + "生成临时数据失败";
                    lst = null;
                    //myTran.Rollback();
                    conn.Close();
                    return false;
                }
                //统计累计数量
                sql = @"select voucherno,rowno,[temp_2].SoCode,materialno,materialdesc,materialstd,[temp_2].ordercode,plantno,batchno,outpackqty,[temp_2].Qty as voucherQty,[temp_2].QualifiedInQty as QualifiedInQty,SUM(T_OUTBARCODE.qty) as printQty,COUNT(rowno) as barcodeQty from T_OUTBARCODE
    inner join [temp_2] on ([temp_2].MoCode= T_OUTBARCODE.voucherno and  [temp_2].SortSeq= T_OUTBARCODE.rowno)
    group by voucherno,rowno,[temp_2].SoCode,materialno,materialdesc,materialstd,[temp_2].ordercode,plantno,batchno,outpackqty,[temp_2].Qty, [temp_2].QualifiedInQty";

                lst = new List<BarcodeReport_Model>();
                using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, sql, null))
                {
                    if (dr == null)
                    {
                        strErrMsg = "查询数据失败";
                        return false;
                    }
                    BarcodeReport_Model model;
                    while (dr.Read())
                    {
                        model = new BarcodeReport_Model();
                        model.voucherno = dr["voucherno"].ToDBString();//生产订单
                        model.rowno = dr["rowno"].ToDBString();//生产订单行号
                        model.SoCode = dr["SoCode"].ToDBString();//销售订单号
                        model.materialno = dr["materialno"].ToDBString();//物料编码
                        model.materialdesc = dr["materialdesc"].ToDBString();//物料名称
                        model.materialstd = dr["materialstd"].ToDBString();//规格型号
                        model.ordercode = dr["ordercode"].ToDBString();//合同号
                        model.plantno = dr["plantno"].ToDBString();//生产线
                        model.batchno = dr["batchno"].ToDBString();//序列号
                        model.outpackqty = dr["outpackqty"].ToDecimal();//外箱包装量
                        model.voucherQty = dr["voucherQty"].ToDecimal();//订单数量
                        model.QualifiedInQty = dr["QualifiedInQty"].ToDecimal();//累计入库数量
                        model.printQty = dr["printQty"].ToDecimal();//已打印数量
                        model.barcodeQty = dr["barcodeQty"].ToDecimal();//已打印条码个数

                        lst.Add(model);
                    }
                }
                //myTran.Commit();
                conn.Close();
                strErrMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                lst = null;
                //myTran.Rollback();
                conn.Close();
                return false;
            }
        }

        public bool QueryBarcodeDetailsReportRowDetail(BarcodeReport_Model row, out List<BarcodeReport_RowDetail> lst, out string strErrMsg)
        {
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                lst = null;
                return false;
            }
            cmd.Connection = conn;
            try
            {
                //先获取外箱
                string sql = @"select T_OUTBARCODE.id,T_OUTBARCODE.batchno,TRAYID,T_OUTBARCODE.serialno,iFlag, areano from T_OUTBARCODE left join T_STOCK on T_OUTBARCODE.serialno = T_STOCK.serialno where T_OUTBARCODE.voucherno = '" + row.voucherno + "' and T_OUTBARCODE.rowno = '" + row.rowno + "'";
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                lst = new List<BarcodeReport_RowDetail>();
                using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, sql, null))
                {
                    if (dr == null)
                    {
                        strErrMsg = "查询数据失败";
                        return false;
                    }
                    BarcodeReport_RowDetail model;
                    while (dr.Read())
                    {
                        model = new BarcodeReport_RowDetail();
                        model.innerouter = "外箱";
                        model.isInner = dr["batchno"].ToDBString().Contains('W');
                        model.serialno = dr["serialno"].ToDBString();
                        model.areano = dr["areano"].ToDBString();
                        //iFlag为null且TRAYID为null是已打印保存未组托,iFlag为null但TRAYID不为null是已组托未下线入库,1是保存未过账,2入库,3上架,4出库,5调拨中
                        if (dr["iFlag"].ToDBString().Equals(string.Empty))
                        {
                            if (dr["TRAYID"].ToDBString().Equals(string.Empty))
                            {
                                model.iFlag = "已打印未组托";
                            }
                            else
                            {
                                model.iFlag = "已组托未入库";
                            }
                        }
                        else if (dr["iFlag"].ToDBString().Equals("1"))
                        {
                            model.iFlag = "已保存未过账";
                        }
                        else if (dr["iFlag"].ToDBString().Equals("2"))
                        {
                            model.iFlag = "已入库未上架";
                        }
                        else if (dr["iFlag"].ToDBString().Equals("3"))
                        {
                            model.iFlag = "已上架";
                        }
                        else if (dr["iFlag"].ToDBString().Equals("4"))
                        {
                            model.iFlag = "已出库";
                        }
                        else if (dr["iFlag"].ToDBString().Equals("5"))
                        {
                            model.iFlag = "调拨中";
                        }
                        else
                        {
                            model.iFlag = "未定义";
                        }
                        model.id = dr["id"].ToDBString();
                        lst.Add(model);
                    }
                }
                for (int i = 0; i < lst.Count; i++)
                {
                    //如果有关联内盒查询相关内盒
                    if (lst[i].isInner)
                    {
                        sql = @"select T_INNERBARCODE.serialno,areano from T_INNERBARCODE left join T_STOCK on T_INNERBARCODE.serialno = T_STOCK.serialno where T_INNERBARCODE.outbox_id = " + lst[i].id;
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, sql, null))
                        {
                            if (dr == null)
                            {
                                strErrMsg = "查询数据失败";
                                return false;
                            }
                            while (dr.Read())
                            {
                                BarcodeReport_RowDetail model = new BarcodeReport_RowDetail();
                                model.isInner = false;
                                model.innerouter = "内盒";
                                model.iFlag = lst[i].iFlag;
                                model.serialno = dr["serialno"].ToDBString();
                                model.areano = dr["areano"].ToDBString();
                                lst.Insert(i + 1, model);
                                i++;
                            }
                        }
                    }
                }
                conn.Close();
                strErrMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                lst = null;
                conn.Close();
                return false;
            }
        }
        //select * from T_INNERBARCODE where outbox_id = 69634
        //
        internal bool CreateAutomaticProductBarcode(ProductLabel_Model labelModel, ref string strErrMsg)
        {
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            SqlTransaction myTran;
            myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = myTran;
            try
            {
                string BatchNo = labelModel.printdate + labelModel.plantno;
                string strSql = "";
                int r;
                labelModel.outpackqty = "1";
                //获取ID
                cmd.CommandText = "P_GetNewSeqVal_SEQ_OUTBARCODEID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                cmd.Parameters.Clear();
                strSql += @"insert T_OUTBARCODE (id,barcodetype,voucherno,rowno,socode,outpackqty,qty,materialno,materialdesc,materialstd,barcode,cusname,Remark,operationdate,plantno,serialno,batchno,prdversion) values ("
                + ID.ToString() + ",'" + labelModel.labeltype + "', '" + labelModel.POCode + "'," + labelModel.iMoSeq + ",'" + labelModel.ordercode + "',1,1,'"
                + labelModel.materialno + "','" + labelModel.materialdesc + "','" + labelModel.invstd + "','" + labelModel.barcode + "','" + labelModel.CUName + "','" + labelModel.Remark
                + "',GETDATE(),'" + labelModel.plantno + "','" + labelModel.BarcodeExpress + "','" + BatchNo + "','" + labelModel.prdversion + "');";
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                r = cmd.ExecuteNonQuery();
                if (r == 0)
                {
                    strErrMsg = strSql + "保存数据失败";
                    myTran.Rollback();
                    conn.Close();
                    return false;
                }
                //更新T_SerialNo
                strSql = @"select SerialNosArea from T_SerialArea where BatchNo = '" + BatchNo + "'"; //@"select SerialNo from SerialNosArea where BatchNo = '" + BatchNo + "'";
                bool checkedSerialNo = false;
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            checkedSerialNo = true;
                            break;
                        }
                        if (dr != null && !dr.IsClosed) dr.Close();
                    }
                }
                if (!checkedSerialNo)
                {
                    strSql = @"insert T_SerialArea (SerialNosArea,BatchNo) values ('" + (Convert.ToInt16(labelModel.packno)).ToString() + ",1','" + BatchNo + "')";
                }
                else
                {
                    strSql = @"update T_SerialArea set SerialNosArea = SerialNosArea + '@" + (Convert.ToInt16(labelModel.packno)).ToString() + ",1' where BatchNo = '" + BatchNo + "'";
                }
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                r = cmd.ExecuteNonQuery();
                if (r == 0)
                {
                    strErrMsg = strSql + "保存数据失败";
                    myTran.Rollback();
                    conn.Close();
                    return false;
                }
                myTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                myTran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool QueryBarcodeTraceReport(string barcode, string voucherno, string CusName, string Socode, string Covenantcode, string materialno, string materialdesc, string materialstd, string StockOutCode, string TransMoveCode, out List<BarcodeTrace_Model> lst, out string strErrMsg)
        {
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                lst = null;
                return false;
            }
            //SqlTransaction myTran;
            //myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.CommandTimeout = 0;
            //cmd.Transaction = myTran;
            try
            {
                //先获取ERP中的生产订单号,调拨单号，销售发票单据号及行号，并通过已有条件进行筛选
                string sql = @"IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_NAME =N'temp_trace') Drop Table [temp_trace]";
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                sql = @"select distinct T_OUTBARCODE.voucherno as POCode,T_OUTBARCODE.rowno as POrowno,CONVERT(varchar(20),operationdate ,111) as POdate,
T_TransMoveRecord.voucherno as TransMoveCode, T_TransMoveDetails.rowno as TransMoverowno,T_TransMoveRecord.ciwhcode as TransMovecwhcode,
T_StockOutRecord.voucherno as StockOutCode, T_StockOutDetails.rowno as StockOutrowno,T_StockOutRecord.cCusCode as CusCode,CONVERT(varchar(20),T_StockOutRecord.createtime ,111) as StockOutdate,T_StockOutRecord.cSocode as SoCode,T_OUTBARCODE.materialno as InvCode
into [temp_trace]
from T_OUTBARCODE
left join T_StockOutDetails on T_StockOutDetails.serialno = T_OUTBARCODE.serialno
left join T_StockOutRecord on T_StockOutRecord.id = T_StockOutDetails.id
left join T_TransMoveDetails on T_TransMoveDetails.serialno = T_OUTBARCODE.serialno
left join T_TransMoveRecord on T_TransMoveRecord.id = T_TransMoveDetails.id where (1=1) ";//外箱
                if (barcode != null)
                {
                    sql = sql + "and T_OUTBARCODE.serialno = '" + barcode + "' ";
                }
                if (voucherno != null)
                {
                    sql = sql + "and T_OUTBARCODE.voucherno = '" + voucherno + "' ";
                }
                if (Covenantcode != null)
                {
                    sql = sql + "and T_OUTBARCODE.Socode = '" + Covenantcode + "' ";
                }
                if (materialno != null)
                {
                    sql = sql + "and T_OUTBARCODE.materialno = '" + materialno + "' ";
                }
                if (materialdesc != null)
                {
                    sql = sql + "and T_OUTBARCODE.materialdesc = '" + materialdesc + "' ";
                }
                if (materialstd != null)
                {
                    sql = sql + "and T_OUTBARCODE.materialstd = '" + materialstd + "' ";
                }
                if (Socode != null)
                {
                    sql = sql + "and T_StockOutRecord.cSocode = '" + Socode + "' ";
                }
                if (StockOutCode != null)
                {
                    sql = sql + "and T_StockOutRecord.voucherno = '" + StockOutCode + "' ";
                }
                if (TransMoveCode != null)
                {
                    sql = sql + "and T_TransMoveRecord.voucherno = '" + TransMoveCode + "' ";
                }
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                sql = @"insert into [temp_trace](POCode,POrowno,POdate,TransMoveCode,TransMoverowno,TransMovecwhcode,StockOutCode,StockOutrowno,CusCode,StockOutdate,SoCode,InvCode) select distinct T_INNERBARCODE.voucherno as POCode,T_INNERBARCODE.rowno as POrowno,CONVERT(varchar(20),operationdate ,111) as POdate,
T_TransMoveRecord.voucherno as TransMoveCode, T_TransMoveDetails.rowno as TransMoverowno,T_TransMoveRecord.ciwhcode as TransMovecwhcode,
T_StockOutRecord.voucherno as StockOutCode, T_StockOutDetails.rowno as StockOutrowno,T_StockOutRecord.cCusCode as CusCode,CONVERT(varchar(20),T_StockOutRecord.createtime ,111) as StockOutdate,T_StockOutRecord.cSocode as SoCode,T_INNERBARCODE.materialno as InvCode from T_INNERBARCODE 
left join T_StockOutDetails on T_StockOutDetails.serialno = T_INNERBARCODE.serialno
left join T_StockOutRecord on T_StockOutRecord.id = T_StockOutDetails.id
left join T_TransMoveDetails on T_TransMoveDetails.serialno = T_INNERBARCODE.serialno
left join T_TransMoveRecord on T_TransMoveRecord.id = T_TransMoveDetails.id where (1=1) ";//内盒
                if (barcode != null)
                {
                    sql = sql + "and T_INNERBARCODE.serialno = '" + barcode + "' ";
                }
                if (voucherno != null)
                {
                    sql = sql + "and T_INNERBARCODE.voucherno = '" + voucherno + "' ";
                }
                if (Covenantcode != null)
                {
                    sql = sql + "and T_INNERBARCODE.Socode = '" + Covenantcode + "' ";
                }
                if (materialno != null)
                {
                    sql = sql + "and T_INNERBARCODE.materialno = '" + materialno + "' ";
                }
                if (materialdesc != null)
                {
                    sql = sql + "and T_INNERBARCODE.materialdesc = '" + materialdesc + "' ";
                }
                if (materialstd != null)
                {
                    sql = sql + "and T_INNERBARCODE.materialstd = '" + materialstd + "' ";
                }
                if (Socode != null)
                {
                    sql = sql + "and T_StockOutRecord.cSocode = '" + Socode + "' ";
                }
                if (StockOutCode != null)
                {
                    sql = sql + "and T_StockOutRecord.voucherno = '" + StockOutCode + "' ";
                }
                if (TransMoveCode != null)
                {
                    sql = sql + "and T_TransMoveRecord.voucherno = '" + TransMoveCode + "' ";
                }
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                sql = @"IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_NAME =N'temp_trace2') Drop Table [temp_trace2]";
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                sql = @"select distinct * into [temp_trace2] from temp_trace where POCode is not null or TransMoveCode is not null or StockOutCode is not null ";
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                //再从ERP数据库中获取销售订单号及订单数量，并通过已有条件进行筛选
                sql = @"if exists(select 1 from master.dbo.sysservers where srvname='ITSV')
begin
    EXEC sp_dropserver 'ITSV','droplogins' 
end   ";
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                sql = @" exec sp_addlinkedserver   'ITSV', '', 'SQLOLEDB ', '" + OperationSql.GetU8BaseInfo().DBService + @"'; ";
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                sql = @" exec sp_addlinkedsrvlogin 'ITSV', 'false ',null, '" + OperationSql.GetU8BaseInfo().sqlUser + "', '" + OperationSql.GetU8BaseInfo().sqlPassword + @"' ;";
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                sql = @"IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_NAME =N'temp_3') Drop Table [temp_3] ";
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                sql = @"select [temp_trace2].SoCode as cSocode,m2.Define22 as LineCode,m2.Define24 as ordercode,m2.SoCode,m1.MoCode,m2.SortSeq,[temp_trace2].InvCode,i.cInvName,i.cInvStd,m2.Qty,m2.QualifiedInQty,m2.Define25,[temp_trace2].POdate as POdate,
[temp_trace2].TransMoveCode, [temp_trace2].TransMoverowno,wh.cwhname as TransMovecwhName,[temp_trace2].StockOutCode,[temp_trace2].StockOutrowno,cus.ccusabbname as CusName,[temp_trace2].StockOutdate
    into [temp_3] from [temp_trace2]
    left join [ITSV].[UFDATA_" + OperationSql.GetU8BaseInfo().accID + "_" + OperationSql.GetU8BaseInfo().year + @"].dbo.mom_order m1 on [temp_trace2].POCode= m1.MoCode 
    left join [ITSV].[UFDATA_" + OperationSql.GetU8BaseInfo().accID + "_" + OperationSql.GetU8BaseInfo().year + @"].dbo.mom_orderdetail m2 on  (m1.Moid=m2.Moid and [temp_trace2].POrowno= m2.SortSeq)
    left join [ITSV].[UFDATA_" + OperationSql.GetU8BaseInfo().accID + "_" + OperationSql.GetU8BaseInfo().year + @"].dbo.mom_morder m4 on m4.MoDId = m2.MoDId  
    inner join [ITSV].[UFDATA_" + OperationSql.GetU8BaseInfo().accID + "_" + OperationSql.GetU8BaseInfo().year + @"].dbo.inventory i on [temp_trace2].InvCode=i.cInvCode 
    left join [ITSV].[UFDATA_" + OperationSql.GetU8BaseInfo().accID + "_" + OperationSql.GetU8BaseInfo().year + @"].dbo.customer cus on cus.ccuscode = [temp_trace2].CusCode
    left join [ITSV].[UFDATA_" + OperationSql.GetU8BaseInfo().accID + "_" + OperationSql.GetU8BaseInfo().year + @"].dbo.Warehouse wh on wh.cwhcode = [temp_trace2].TransMovecwhcode
    where (1=1)  ";
                if (voucherno != null)
                {
                    sql = sql + "and m1.MoCode = '" + voucherno + "' ";
                }
                if (Socode != null)
                {
                    sql = sql + "and [temp_trace2].SoCode = '" + Socode + "' ";
                }
                if (materialno != null)
                {
                    sql = sql + "and [temp_trace2].InvCode = '" + materialno + "' ";
                }
                if (materialdesc != null)
                {
                    sql = sql + "and i.cInvName = '" + materialdesc + "' ";
                }
                if (CusName != null)
                {
                    sql = sql + "and cus.ccusabbname like '%" + CusName + "%' ";
                }
                if (materialstd != null)
                {
                    sql = sql + "and i.cInvStd = '" + materialstd + "' ";
                }
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                int r = cmd.ExecuteNonQuery();
                if (r == 0)
                {
                    strErrMsg = sql + "生成临时数据失败";
                    lst = null;
                    //myTran.Rollback();
                    conn.Close();
                    return false;
                }
                //统计累计数量
                sql = @"
select [temp_3].POdate,ordercode,[temp_3].cSocode,[temp_3].SoCode,MoCode,SortSeq,InvCode,cInvName,cInvStd,[temp_3].LineCode,
[temp_3].Qty as voucherQty, [temp_3].QualifiedInQty as QualifiedInQty,
SUM(T_OUTBARCODE.qty) as printQty, 
TransMoveCode,TransMoverowno,SUM(T_TransMoveDetails.qty) as transmoveQty,[temp_3].TransMovecwhName,
StockOutCode,StockOutrowno,[temp_3].CusName, SUM(T_StockOutDetails.qty) as stockoutQty, [temp_3].StockOutdate from temp_3
left join T_OUTBARCODE on (T_OUTBARCODE.voucherno = temp_3.MoCode and T_OUTBARCODE.rowno = temp_3.SortSeq)
left join T_TransMoveRecord on T_TransMoveRecord.voucherno=[temp_3].TransMoveCode 
left join T_TransMoveDetails on T_TransMoveDetails.id = T_TransMoveRecord.id and T_TransMoveDetails.rowno=[temp_3].TransMoverowno and (T_TransMoveDetails.serialno=T_OUTBARCODE.serialno or ([temp_3].MoCode is NULL and T_TransMoveDetails.serialno like '151120X%'))
left join T_StockOutRecord on T_StockOutRecord.voucherno=[temp_3].StockOutCode
left join T_StockOutDetails on T_StockOutDetails.id = T_StockOutRecord.id and T_StockOutDetails.rowno=[temp_3].StockOutrowno and (T_StockOutDetails.serialno=T_OUTBARCODE.serialno or ([temp_3].MoCode is NULL and T_StockOutDetails.serialno like '151120X%'))
group by [temp_3].cSocode,[temp_3].TransMovecwhName,[temp_3].StockOutdate,[temp_3].POdate,[temp_3].Qty,[temp_3].QualifiedInQty,LineCode,ordercode,[temp_3].SoCode,MoCode,SortSeq,InvCode,cInvName,cInvStd,TransMoveCode,TransMoverowno,StockOutCode,StockOutrowno,[temp_3].CusName
having (1=1) ";
                if (voucherno != null)
                {
                    sql = sql + "and MoCode = '" + voucherno + "' ";
                }
                if (Socode != null)
                {
                    sql = sql + "and [temp_3].cSocode = '" + Socode + "' ";
                }
                if (materialno != null)
                {
                    sql = sql + "and InvCode = '" + materialno + "' ";
                }
                if (materialdesc != null)
                {
                    sql = sql + "and cInvName = '" + materialdesc + "' ";
                }
                if (CusName != null)
                {
                    sql = sql + "and [temp_3].CusName like '%" + CusName + "%' ";
                }
                if (materialstd != null)
                {
                    sql = sql + "and cInvStd = '" + materialstd + "' ";
                }
                lst = new List<BarcodeTrace_Model>();
                using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, sql, null))
                {
                    if (dr == null)
                    {
                        strErrMsg = "查询数据失败";
                        return false;
                    }
                    BarcodeTrace_Model model;
                    while (dr.Read())
                    {
                        model = new BarcodeTrace_Model();
                        model.voucherno = dr["MoCode"].ToDBString();//生产订单
                        model.rowno = dr["SortSeq"].ToDBString();//生产订单行号
                        model.SoCode = dr["cSocode"].ToDBString();//销售订单号
                        model.materialno = dr["InvCode"].ToDBString();//物料编码
                        model.materialdesc = dr["cInvName"].ToDBString();//物料名称
                        model.materialstd = dr["cInvStd"].ToDBString();//规格型号
                        model.ordercode = dr["ordercode"].ToDBString();//合同号
                        model.plantno = dr["LineCode"].ToDBString();//生产线
                        //model.batchno = dr["batchno"].ToDBString();//序列号
                        //model.outpackqty = dr["outpackqty"].ToDecimal();//外箱包装量
                        model.voucherQty = dr["voucherQty"].ToDecimal();//订单数量
                        model.QualifiedInQty = dr["QualifiedInQty"].ToDecimal();//累计入库数量
                        model.printQty = dr["printQty"].ToDecimal();//已打印数量
                        //model.barcodeQty = dr["barcodeQty"].ToDecimal();//已打印条码个数
                        model.POdate = dr["POdate"].ToDBString();//生产日期
                        model.TransMovecwhName = dr["TransMovecwhName"].ToDBString();//调拨仓库
                        model.TransMoveCode = dr["TransMoveCode"].ToDBString();
                        model.TransMoverowno = dr["TransMoverowno"].ToDBString();
                        model.CusName = dr["CusName"].ToDBString();//发货客户名称
                        model.StockOutdate = dr["StockOutdate"].ToDBString();//发货日期
                        model.StockOutCode = dr["StockOutCode"].ToDBString();//销售发票单据号
                        model.StockOutrowno = dr["StockOutrowno"].ToDBString();
                        model.transmoveQty = dr["transmoveQty"].ToDecimal();//调拨数量
                        model.stockoutQty = dr["stockoutQty"].ToDecimal();//发货数量
                        lst.Add(model);
                    }
                }
                //myTran.Commit();
                conn.Close();
                strErrMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                lst = null;
                //myTran.Rollback();
                conn.Close();
                return false;
            }
        }

        public bool QueryBarcodeTraceReportRowDetail(BarcodeTrace_Model row, out List<BarcodeReport_RowDetail> lst, out string strErrMsg)
        {
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                lst = null;
                return false;
            }
            cmd.Connection = conn;
            try
            {
                //先获取外箱
                string sql = "";
                if (row.voucherno == null || row.voucherno.Equals(string.Empty))
                {
                    sql = @"select T_OUTBARCODE.id,T_OUTBARCODE.batchno,TRAYID,T_OUTBARCODE.serialno,iFlag, areano from T_OUTBARCODE left join T_STOCK on T_OUTBARCODE.serialno = T_STOCK.serialno where T_OUTBARCODE.voucherno is NULL and T_OUTBARCODE.rowno is NULL";
                }
                else
                {
                    sql = @"select T_OUTBARCODE.id,T_OUTBARCODE.batchno,TRAYID,T_OUTBARCODE.serialno,iFlag, areano from T_OUTBARCODE left join T_STOCK on T_OUTBARCODE.serialno = T_STOCK.serialno where T_OUTBARCODE.voucherno = '" + row.voucherno + "' and T_OUTBARCODE.rowno = '" + row.rowno + "'";
                }
                
                if(row.TransMoveCode != null && row.TransMoveCode.Length > 0)
                {
                    sql += " and T_OUTBARCODE.serialno in (select serialno from T_TransMoveDetails left join T_TransMoveRecord on T_TransMoveDetails.id = T_TransMoveRecord.id where T_TransMoveRecord.voucherno = '" + row.TransMoveCode + "' and T_TransMoveDetails.rowno = '" + row.TransMoverowno + "')";
                }
                if (row.StockOutCode != null && row.StockOutCode.Length > 0)
                {
                    sql += " and T_OUTBARCODE.serialno in (select serialno from T_StockOutDetails left join T_StockOutRecord on T_StockOutDetails.id = T_StockOutRecord.id where T_StockOutRecord.voucherno = '" + row.StockOutCode + "' and T_StockOutDetails.rowno = '" + row.StockOutrowno + "')";
                }
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                lst = new List<BarcodeReport_RowDetail>();
                using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, sql, null))
                {
                    if (dr == null)
                    {
                        strErrMsg = "查询数据失败";
                        return false;
                    }
                    BarcodeReport_RowDetail model;
                    while (dr.Read())
                    {
                        model = new BarcodeReport_RowDetail();
                        model.innerouter = "外箱";
                        model.isInner = dr["batchno"].ToDBString().Contains('W');
                        model.serialno = dr["serialno"].ToDBString();
                        model.areano = dr["areano"].ToDBString();
                        //iFlag为null且TRAYID为null是已打印保存未组托,iFlag为null但TRAYID不为null是已组托未下线入库,1是保存未过账,2入库,3上架,4出库,5调拨中
                        if (dr["iFlag"].ToDBString().Equals(string.Empty))
                        {
                            if (dr["TRAYID"].ToDBString().Equals(string.Empty))
                            {
                                model.iFlag = "已打印未组托";
                            }
                            else
                            {
                                model.iFlag = "已组托未入库";
                            }
                        }
                        else if (dr["iFlag"].ToDBString().Equals("1"))
                        {
                            model.iFlag = "已保存未过账";
                        }
                        else if (dr["iFlag"].ToDBString().Equals("2"))
                        {
                            model.iFlag = "已入库未上架";
                        }
                        else if (dr["iFlag"].ToDBString().Equals("3"))
                        {
                            model.iFlag = "已上架";
                        }
                        else if (dr["iFlag"].ToDBString().Equals("4"))
                        {
                            model.iFlag = "已出库";
                        }
                        else if (dr["iFlag"].ToDBString().Equals("5"))
                        {
                            model.iFlag = "调拨中";
                        }
                        else
                        {
                            model.iFlag = "未定义";
                        }
                        model.id = dr["id"].ToDBString();
                        lst.Add(model);
                    }
                }
                for (int i = 0; i < lst.Count; i++)
                {
                    //如果有关联内盒查询相关内盒
                    if (lst[i].isInner)
                    {
                        sql = @"select T_INNERBARCODE.serialno,areano from T_INNERBARCODE left join T_STOCK on T_INNERBARCODE.serialno = T_STOCK.serialno where T_INNERBARCODE.outbox_id = " + lst[i].id;
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, sql, null))
                        {
                            if (dr == null)
                            {
                                strErrMsg = "查询数据失败";
                                return false;
                            }
                            while (dr.Read())
                            {
                                BarcodeReport_RowDetail model = new BarcodeReport_RowDetail();
                                model.isInner = false;
                                model.innerouter = "内盒";
                                model.iFlag = lst[i].iFlag;
                                model.serialno = dr["serialno"].ToDBString();
                                model.areano = dr["areano"].ToDBString();
                                lst.Insert(i + 1, model);
                                i++;
                            }
                        }
                    }
                }
                conn.Close();
                strErrMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                lst = null;
                conn.Close();
                return false;
            }
        }

        internal bool GetAutomaticProductByBarcode(string serialno, ref ProductLabel_Model labelModel, ref string strErrMsg)
        {
            //labelModel = null;
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            cmd.Connection = conn;
            SqlCommand innercmd = new SqlCommand();
            SqlConnection innerconn = new SqlConnection();
            innerconn.ConnectionString = connString;
            innerconn.Open();
            innercmd.Connection = innerconn;
            try
            {
                string strSql = "";
                //先查询外箱
                strSql = @"select * from T_OUTBARCODE where  serialno = '" + serialno + "'";
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            //barcodetype,voucherno,socode,outpackqty,qty,materialno,materialdesc,materialstd,barcode,cusname,Remark,operationdate,plantno,serialno,batchno
                            labelModel = new ProductLabel_Model();
                            labelModel = new ProductLabel_Model();
                            labelModel.IsOuter = "W";
                            labelModel.ID = dr["ID"].ToDBString();
                            labelModel.labeltype = dr["barcodetype"].ToDBString();
                            labelModel.POCode = dr["voucherno"].ToDBString();
                            labelModel.ordercode = dr["socode"].ToDBString();
                            labelModel.outpackqty = dr["outpackqty"].ToDBString();
                            labelModel.materialno = dr["materialno"].ToDBString();
                            labelModel.materialdesc = dr["materialdesc"].ToDBString();
                            labelModel.invstd = dr["materialstd"].ToDBString();
                            labelModel.CUName = dr["cusname"].ToDBString();
                            labelModel.Remark = dr["Remark"].ToDBString();
                            labelModel.printdate = dr["operationdate"].ToDBString();
                            labelModel.plantno = dr["plantno"].ToDBString();
                            //labelModel.packno = dr["barcodetype"].ToDBString();
                            labelModel.BarcodeExpress = dr["serialno"].ToDBString();
                            labelModel.barcode = dr["barcode"].ToDBString();
                            labelModel.prdversion = dr["prdversion"].ToDBString();
                        }
                        if (dr != null && !dr.IsClosed) dr.Close();
                    }
                }
                if (labelModel == null)
                {
                    strErrMsg = "找不到条码";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            finally
            {
                conn.Close();
                innerconn.Close();
            }
        }

        internal List<MaterialLabel_Model> GetPULstForPrint(string cpoid, string cvenabbname, string begindate, string enddate, ref string strErrMsg)
        {
            try
            {
                string strSql = @"select * from zpurpoheader where  cvoucherstate = '审核' ";
                if (!cpoid.Equals(""))
                {
                    strSql = strSql + " and cpoid like N'%" + cpoid + "%' ";
                }
                if (!cvenabbname.Equals(""))
                {
                    strSql = strSql + " and cvenabbname like N'%" + cvenabbname + "%' ";
                }
                if(!begindate.Equals(""))
                {
                    if(!enddate.Equals(""))
                    {
                        strSql = strSql + " and cmaketime between '" + begindate + "' and DATEADD(DD, 1, '" + enddate + "') ";
                    }
                    else
                    {
                        strSql = strSql + " and cmaketime > '" + begindate + "'";
                    }
                }
                else
                {
                    if(!enddate.Equals(""))
                    {
                        strSql = strSql + " and cmaketime < '" + enddate + "'";
                    }
                }
                SqlDataReader dr = OperationSql.ExecuteReaderForU8(CommandType.Text, strSql, null);
                if (dr == null) return null;
                List<MaterialLabel_Model> lst = new List<MaterialLabel_Model>(); ;
                while (dr.Read())
                {
                    MaterialLabel_Model head = new MaterialLabel_Model();
                    head.cvencode = dr["cvencode"].ToDBString();
                    head.cvenabbname = dr["cvenabbname"].ToDBString();
                    head.cpoid = dr["cpoid"].ToDBString();//cpoid;
                    strSql = @"Select zPurpotail.*,'' as editprop  ,extend_b_cinvcode_v_inventory_cvenname From  zPurpotail  left join (select cvenname as extend_b_cinvcode_v_inventory_cvenname,cinvcode as keyextend_b_cinvcode_v_inventory_cinvcode from v_inventory) extend_b_cinvcode_v_inventory on keyextend_b_cinvcode_v_inventory_cinvcode=zpurpotail.cinvcode  Where POID = N'" + dr["poid"].ToDBString() + "' order by ivouchrowno";

                    using (SqlDataReader drow = OperationSql.ExecuteReaderForU8(CommandType.Text, strSql, null))
                    {
                        //lst = new List<MaterialLabel_Model>();
                        while (drow.Read())
                        {
                            MaterialLabel_Model model = new MaterialLabel_Model();
                            model.cvencode = head.cvencode;
                            model.cvenabbname = head.cvenabbname;
                            model.cpoid = head.cpoid;
                            model.materialno = drow["cinvcode"].ToDBString();
                            model.materialdesc = drow["cinvname"].ToDBString();
                            model.invstd = drow["cinvstd"].ToDBString();
                            model.iquantity = drow["iquantity"].ToDouble();
                            model.ivouchrowno = drow["ivouchrowno"].ToDBString();
                            string sql = "select sum(qty) as PrintedQTY from T_OUTBARCODE where barcodetype = '00' and voucherno = '" + head.cpoid + "' and rowno = '" + model.ivouchrowno + "'";
                            SqlDataReader drsum = OperationSql.ExecuteReader(CommandType.Text, sql, null);
                            if (drsum == null)
                            {
                                model.PrintedQTY = 0;
                                model.ImprintedQTY = model.iquantity;
                            }
                            else
                            {
                                drsum.Read();
                                model.PrintedQTY = drsum["PrintedQTY"].ToDouble();
                                model.ImprintedQTY = model.iquantity - model.PrintedQTY;
                                if (model.ImprintedQTY < 0)
                                {
                                    model.ImprintedQTY = 0;
                                }
                                drsum.Close();
                            }
                            lst.Add(model);
                        }
                        if (drow != null && !drow.IsClosed) drow.Close();
                    }
                }
                if (dr != null && !dr.IsClosed) dr.Close();
                return lst;
            }
            catch(Exception ex)
            {
                strErrMsg = ex.Message;
                return null;
            }
            
        }

        internal Vendor VendorLogin(string cvencode)
        {
            string strSql = @"select * from T_Vendor where cvencode = '" + cvencode + "'";
            SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, strSql, null);
            if (dr == null) return null;
            dr.Read();
            Vendor vendor = new Vendor();
            vendor.cVenCode = cvencode;
            vendor.cVenAbbName = dr["cVenName"].ToDBString();
            vendor.password = dr["password"].ToDBString();
            return vendor;
        }

        internal bool VendorChangePW(string cvencode, string password)
        {
            string strSql = @"update T_Vendor set password = '" + password + "' where cvencode = '" + cvencode + "'";
            int i = OperationSql.ExecuteNonQuery(CommandType.Text, strSql, null);
            if(i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal List<MaterialLabel_Model> VenGetPULstForPrint(string cvencode, string cpoid, ref string strErrMsg)
        {
            string strSql = @"select * from zpurpoheader where cvoucherstate = '审核' and cpoid like N'%" + cpoid + "%' and cvencode = '" + cvencode + "'";
            SqlDataReader dr = OperationSql.ExecuteReaderForU8(CommandType.Text, strSql, null);
            if (dr == null) return null;
            List<MaterialLabel_Model> lst = new List<MaterialLabel_Model>();
            while(dr.Read())
            {
                MaterialLabel_Model head = new MaterialLabel_Model();
                head.cvencode = dr["cvencode"].ToDBString();
                head.cvenabbname = dr["cvenabbname"].ToDBString();
                head.cpoid = dr["cpoid"].ToDBString();//cpoid;
                strSql = @"Select zPurpotail.*,'' as editprop  ,extend_b_cinvcode_v_inventory_cvenname From  zPurpotail  left join (select cvenname as extend_b_cinvcode_v_inventory_cvenname,cinvcode as keyextend_b_cinvcode_v_inventory_cinvcode from v_inventory) extend_b_cinvcode_v_inventory on keyextend_b_cinvcode_v_inventory_cinvcode=zpurpotail.cinvcode  Where cbclosedate is null and POID = N'" + dr["poid"].ToDBString() + "' order by ivouchrowno";
            
                using (SqlDataReader drow = OperationSql.ExecuteReaderForU8(CommandType.Text, strSql, null))
                {
                    //lst = new List<MaterialLabel_Model>();
                    while (drow.Read())
                    {
                        MaterialLabel_Model model = new MaterialLabel_Model();
                        model.cvencode = head.cvencode;
                        model.cvenabbname = head.cvenabbname;
                        model.cpoid = head.cpoid;
                        model.materialno = drow["cinvcode"].ToDBString();
                        model.materialdesc = drow["cinvname"].ToDBString();
                        model.invstd = drow["cinvstd"].ToDBString();
                        model.iquantity = drow["iquantity"].ToDouble();
                        model.ivouchrowno = drow["ivouchrowno"].ToDBString();
                        string sql = "select sum(qty) as PrintedQTY from T_OUTBARCODE where barcodetype = '00' and voucherno = '" + head.cpoid + "' and rowno = '" + model.ivouchrowno + "'";
                        SqlDataReader drsum = OperationSql.ExecuteReader(CommandType.Text, sql, null);
                        if(drsum == null)
                        {
                            model.PrintedQTY = 0;
                            model.ImprintedQTY = model.iquantity;
                        }
                        else
                        {
                            drsum.Read();
                            model.PrintedQTY = drsum["PrintedQTY"].ToDouble();
                            model.ImprintedQTY = model.iquantity - model.PrintedQTY;
                            if (model.ImprintedQTY < 0)
                            {
                                model.ImprintedQTY = 0;
                            }
                            drsum.Close();
                        }
                        lst.Add(model);
                    }
                    if (drow != null && !drow.IsClosed) drow.Close();
                }
            }
            if (dr != null && !dr.IsClosed) dr.Close();
            return lst;
        }
        public bool CreateMaterialBarcodeForPU(MaterialLabel_Model labelModel, int qty, string PackQty, string EndPackQty, ref List<MaterialLabel_Model> label_lst, ref string strErrMsg)
        {
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            SqlTransaction myTran;
            myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = myTran;
            try
            {
                string strSql = "";
                string BatchNo = DateTime.Today.ToString("yyMMdd"); ;
                int r;
                label_lst = new List<MaterialLabel_Model>();
                for (int i = 0; i < qty; i++)
                {
                    MaterialLabel_Model detail = new MaterialLabel_Model();
                    detail.prdversion = labelModel.prdversion;
                    detail.cpoid = labelModel.cpoid;
                    detail.ivouchrowno = labelModel.ivouchrowno;
                    detail.labeltype = labelModel.labeltype;//"00"
                    if(i == qty -1)
                    {
                        detail.outpackqty = EndPackQty;
                    }
                    else
                    {
                        detail.outpackqty = PackQty;
                    }
                    
                    detail.materialno = labelModel.materialno;
                    detail.materialdesc = labelModel.materialdesc;
                    detail.invstd = labelModel.invstd;
                    detail.cvencode = labelModel.cvencode;
                    detail.cvenabbname = labelModel.cvenabbname;
                    detail.batchno = labelModel.batchno;
                    detail.printdate = BatchNo;// DateTime.Today.ToString("yyMMdd");//labelModel.printdate;
                    detail.Remark = qty.ToString() + "/" + (i + 1).ToString().PadLeft(4, '0');
                    detail.packno = (Convert.ToInt16(GetSerialNo(BatchNo)) + i + 1).ToString().PadLeft(5, '0');
                    detail.BarcodeExpress = BatchNo + detail.packno;
                    detail.barcode = detail.labeltype + "@" + detail.materialno + "@" + detail.cvencode + "@" + detail.batchno + "@" + Convert.ToInt16(detail.outpackqty).ToString().PadLeft(4, '0') + "@" + BatchNo + "@" + detail.packno;
                    label_lst.Add(detail);
                }
                for (int i = 0; i < label_lst.Count; i++)
                {

                    //获取ID
                    cmd.CommandText = "P_GetNewSeqVal_SEQ_OUTBARCODEID";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                    cmd.Parameters.Clear();

                    strSql += @"insert T_OUTBARCODE (id,barcodetype,voucherno,rowno,outpackqty,qty,materialno,materialdesc,materialstd,barcode,supcode,supname,Remark,operationdate,serialno,batchno,prdversion) values ("
                    + ID.ToString() + ",'" + label_lst[i].labeltype + "', '" + label_lst[i].cpoid + "','" + label_lst[i].ivouchrowno + "'," + label_lst[i].outpackqty + "," + label_lst[i].outpackqty + ",'"
                    + label_lst[i].materialno + "','" + label_lst[i].materialdesc + "','" + label_lst[i].invstd + "','" + label_lst[i].barcode + "','" + label_lst[i].cvencode + "','" + label_lst[i].cvenabbname + "','" + label_lst[i].Remark
                    + "',GETDATE(),'" + label_lst[i].BarcodeExpress + "','" + BatchNo + "','" + label_lst[i].prdversion + "');";

                    if (strSql.Length > 5000)
                    {
                        cmd.CommandText = strSql;
                        cmd.CommandType = CommandType.Text;
                        r = cmd.ExecuteNonQuery();
                        if (r == 0)
                        {
                            strErrMsg = strSql + "保存数据失败";
                            myTran.Rollback();
                            conn.Close();
                            return false;
                        }
                        strSql = "";
                    }
                }
                if (strSql.Length > 0)
                {
                    cmd.CommandText = strSql;
                    cmd.CommandType = CommandType.Text;
                    r = cmd.ExecuteNonQuery();
                    if (r == 0)
                    {
                        strErrMsg = strSql + "保存数据失败";
                        myTran.Rollback();
                        conn.Close();
                        return false;
                    }
                }
                //更新T_SerialNo
                strSql = @"select SerialNosArea from T_SerialArea where BatchNo = '" + BatchNo + "'"; //@"select SerialNo from SerialNosArea where BatchNo = '" + BatchNo + "'";
                bool checkedSerialNo = false;
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            checkedSerialNo = true;
                            break;
                        }
                        if (dr != null && !dr.IsClosed) dr.Close();
                    }
                }
                if (!checkedSerialNo)
                {
                    strSql = @"insert T_SerialArea (SerialNosArea,BatchNo) values ('" + (Convert.ToInt16(label_lst[0].packno)).ToString() + "," + label_lst.Count.ToString() + "','" + BatchNo + "')";
                }
                else
                {
                    strSql = @"update T_SerialArea set SerialNosArea = SerialNosArea + '@" + (Convert.ToInt16(label_lst[0].packno)).ToString() + "," + label_lst.Count.ToString() + "' where BatchNo = '" + BatchNo + "'";
                }
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                r = cmd.ExecuteNonQuery();
                if (r == 0)
                {
                    strErrMsg = strSql + "保存数据失败";
                    myTran.Rollback();
                    conn.Close();
                    return false;
                }
                myTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                myTran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        internal bool VenQueryPrintLst(string cvencode, string cpoid, string rowno, string materialno, string materialdesc, string invstd, string BarcodeExpress, ref  List<MaterialLabel_Model> list, ref string strErrMsg)
        {
            try
            {
                list = new List<MaterialLabel_Model>();
                //先在BARCODE库里查出单号
                string strSql = @"select distinct voucherno from T_OUTBARCODE where barcodetype = '00' ";
                //如果是通过条码查询，则只查询条码所在该行的数据
                if (!BarcodeExpress.Equals(""))
                {
                    strSql = @"select voucherno,rowno  from T_OUTBARCODE where barcodetype = '00' " + " and serialno = '" + BarcodeExpress + "' ";
                    
                    SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, strSql, null);
                    if (dr == null) return false;
                    dr.Read();
                    string voucherno = dr["voucherno"].ToDBString();
                    string ivouchrowno = dr["rowno"].ToDBString();
                    //从U8中获取单据数据
                    strSql = @"select * from zpurpoheader where (cstate = 1 or cstate = 2) and cpoid = N'" + voucherno + "' and cvencode = '" + cvencode + "'";
                    SqlDataReader U8dr = OperationSql.ExecuteReaderForU8(CommandType.Text, strSql, null);
                    if (U8dr == null) return false;
                    U8dr.Read();
                    string poid = U8dr["poid"].ToDBString();
                    list = new List<MaterialLabel_Model>();
                    MaterialLabel_Model head = new MaterialLabel_Model();
                    head.cvencode = U8dr["cvencode"].ToDBString();
                    head.cvenabbname = U8dr["cvenabbname"].ToDBString();
                    head.cpoid = U8dr["cpoid"].ToDBString();//cpoid;
                    strSql = @"Select zPurpotail.*,'' as editprop  ,extend_b_cinvcode_v_inventory_cvenname From  zPurpotail  left join (select cvenname as extend_b_cinvcode_v_inventory_cvenname,cinvcode as keyextend_b_cinvcode_v_inventory_cinvcode from v_inventory) extend_b_cinvcode_v_inventory on keyextend_b_cinvcode_v_inventory_cinvcode=zpurpotail.cinvcode  Where POID = N'" + poid + "' and ivouchrowno = " + ivouchrowno;

                    using (SqlDataReader drow = OperationSql.ExecuteReaderForU8(CommandType.Text, strSql, null))
                    {
                        //lst = new List<MaterialLabel_Model>();
                        while (drow.Read())
                        {
                            MaterialLabel_Model model = new MaterialLabel_Model();
                            model.cvencode = head.cvencode;
                            model.cvenabbname = head.cvenabbname;
                            model.cpoid = head.cpoid;
                            model.materialno = drow["cinvcode"].ToDBString();
                            model.materialdesc = drow["cinvname"].ToDBString();
                            model.invstd = drow["cinvstd"].ToDBString();
                            model.iquantity = drow["iquantity"].ToDouble();
                            model.ivouchrowno = drow["ivouchrowno"].ToDBString();
                            string sql = "select sum(qty) as PrintedQTY from T_OUTBARCODE where barcodetype = '00' and voucherno = '" + head.cpoid + "' and rowno = '" + model.ivouchrowno + "'";
                            SqlDataReader drsum = OperationSql.ExecuteReader(CommandType.Text, sql, null);
                            if (drsum == null)
                            {
                                model.PrintedQTY = 0;
                                model.ImprintedQTY = model.iquantity;
                            }
                            else
                            {
                                drsum.Read();
                                model.PrintedQTY = drsum["PrintedQTY"].ToDouble();
                                model.ImprintedQTY = model.iquantity - model.PrintedQTY;
                                if (model.ImprintedQTY < 0)
                                {
                                    model.ImprintedQTY = 0;
                                }
                                drsum.Close();
                            }
                            list.Add(model);
                        }
                        if (drow != null && !drow.IsClosed) drow.Close();
                    }
                    if (U8dr != null && !U8dr.IsClosed) U8dr.Close();
                    if (dr != null && !dr.IsClosed) dr.Close();
                    return true;
                }
                else
                {
                    if (!cpoid.Equals(""))
                    {
                        strSql = @"select * from zpurpoheader where (cstate = 1 or cstate = 2) and cpoid like N'%" + cpoid + "%' and cvencode = '" + cvencode + "'";
                    }
                    else
                    {
                        string voucherno = "(";
                        using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, strSql, null))
                        {
                            if (dr == null) return false;
                            while (dr.Read())
                            {
                                voucherno = voucherno + "'" + dr["voucherno"].ToDBString() + "',";
                            }
                            voucherno = voucherno.Substring(0, voucherno.Length - 1) + ")";
                            if (dr != null && !dr.IsClosed) dr.Close();
                        }
                        strSql = @"select * from zpurpoheader where (cstate = 1 or cstate = 2) and cpoid in " + voucherno + " and cvencode = '" + cvencode + "'";
                    }
                    //从U8中获取单据数据
                    using (SqlDataReader U8dr = OperationSql.ExecuteReaderForU8(CommandType.Text, strSql, null))
                    {
                        if (U8dr == null) return false;
                        while (U8dr.Read())
                        {
                            string poid = U8dr["poid"].ToDBString();
                            MaterialLabel_Model head = new MaterialLabel_Model();
                            head.cvencode = U8dr["cvencode"].ToDBString();
                            head.cvenabbname = U8dr["cvenabbname"].ToDBString();
                            head.cpoid = U8dr["cpoid"].ToDBString();//cpoid;
                            strSql = @"Select zPurpotail.*,'' as editprop  ,extend_b_cinvcode_v_inventory_cvenname From  zPurpotail  left join (select cvenname as extend_b_cinvcode_v_inventory_cvenname,cinvcode as keyextend_b_cinvcode_v_inventory_cinvcode from v_inventory) extend_b_cinvcode_v_inventory on keyextend_b_cinvcode_v_inventory_cinvcode=zpurpotail.cinvcode  Where POID = N'" + poid + "' ";
                            if (!rowno.Equals(""))
                            {
                                strSql = strSql + " and ivouchrowno = '" + rowno + "' ";
                            }
                            if (!materialno.Equals(""))
                            {
                                strSql = strSql + " and cinvcode like N'%" + materialno + "%' ";
                            }
                            if (!materialdesc.Equals(""))
                            {
                                strSql = strSql + " and cinvname like N'%" + materialno + "%' ";
                            }
                            if (!invstd.Equals(""))
                            {
                                strSql = strSql + " and cinvstd like N'%" + invstd + "%' ";
                            }
                            strSql = strSql + " order by POID, ivouchrowno";

                            using (SqlDataReader drow = OperationSql.ExecuteReaderForU8(CommandType.Text, strSql, null))
                            {
                                //lst = new List<MaterialLabel_Model>();
                                while (drow.Read())
                                {
                                    MaterialLabel_Model model = new MaterialLabel_Model();
                                    model.cvencode = head.cvencode;
                                    model.cvenabbname = head.cvenabbname;
                                    model.cpoid = head.cpoid;
                                    model.materialno = drow["cinvcode"].ToDBString();
                                    model.materialdesc = drow["cinvname"].ToDBString();
                                    model.invstd = drow["cinvstd"].ToDBString();
                                    model.iquantity = drow["iquantity"].ToDouble();
                                    model.ivouchrowno = drow["ivouchrowno"].ToDBString();
                                    string sql = "select sum(qty) as PrintedQTY from T_OUTBARCODE where barcodetype = '00' and voucherno = '" + head.cpoid + "' and rowno = '" + model.ivouchrowno + "'";
                                    SqlDataReader drsum = OperationSql.ExecuteReader(CommandType.Text, sql, null);
                                    if (drsum == null)
                                    {
                                        model.PrintedQTY = 0;
                                        model.ImprintedQTY = model.iquantity;
                                    }
                                    else
                                    {
                                        drsum.Read();
                                        model.PrintedQTY = drsum["PrintedQTY"].ToDouble();
                                        model.ImprintedQTY = model.iquantity - model.PrintedQTY;
                                        if (model.ImprintedQTY < 0)
                                        {
                                            model.ImprintedQTY = 0;
                                        }
                                        drsum.Close();
                                    }
                                    list.Add(model);
                                }
                                if (drow != null && !drow.IsClosed) drow.Close();
                            }
                        }
                        if (U8dr != null && !U8dr.IsClosed) U8dr.Close();
                        return true;
                    }
                    
                }
                
            }
            catch(Exception ex)
            {
                list = null;
                strErrMsg = ex.Message;
                return false;
            }
        }

        internal bool VenQueryPrintDetails(MaterialLabel_Model model, ref  List<MaterialLabel_Model> list, ref string strErrMsg)
        {
            try
            {
                list = new List<MaterialLabel_Model>();
                string strSql = @"select * from T_OUTBARCODE where barcodetype = '00'  and voucherno = '" + model.cpoid + "' and rowno = '" + model.ivouchrowno + "'";
                using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, strSql, null))
                {
                    while (dr.Read())
                    {
                        MaterialLabel_Model rowmodel = new MaterialLabel_Model();
                        rowmodel.cvencode = model.cvencode;
                        rowmodel.cvenabbname = model.cvenabbname;
                        rowmodel.cpoid = model.cpoid;
                        rowmodel.materialno = model.materialno;
                        rowmodel.materialdesc = model.materialdesc;
                        rowmodel.invstd = model.invstd;
                        rowmodel.ivouchrowno = model.ivouchrowno;
                        rowmodel.iquantity = dr["qty"].ToDouble();
                        rowmodel.prdversion = dr["prdversion"].ToDBString();
                        rowmodel.labeltype = dr["barcodetype"].ToDBString();//"00";
                        rowmodel.outpackqty = dr["outpackqty"].ToDBString();
                        rowmodel.batchno = dr["batchno"].ToDBString();
                        //rowmodel.printdate = dr["operationdate"].ToDBString();
                        rowmodel.Remark = dr["Remark"].ToDBString();
                        rowmodel.BarcodeExpress = dr["serialno"].ToDBString();
                        rowmodel.packno = rowmodel.BarcodeExpress.Substring(6);
                        rowmodel.barcode = dr["barcode"].ToDBString();
                        list.Add(rowmodel);
                    }
                    if (dr != null && !dr.IsClosed) dr.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                list = null;
                strErrMsg = ex.Message;
                return false;
            }
        }

        internal bool ImportMaterialStock(List<Stock_Model> dt, ref string strErrMsg)
        {
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            SqlTransaction myTran;
            myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = myTran;
            try
            {
                string strSql = "";
                for (int i = 0; i < dt.Count; i++)
                {
                    //判断是否有相同的期初库存
                    int ID = -1;
                    cmd.CommandText = @"select ID from T_STOCK_MaterialImport where batchno = '期初' and materialno = '" + dt[i].MaterialNo + "' and warehouseno = '" + dt[i].WarehouseNo + "' and houseno = '" + dt[i].HouseNo + "' and areano = '" + dt[i].AreaNo + "' ";
                    if (!(dt[i].cvencode.Equals(string.Empty) || dt[i].cvencode.Equals("")))
                    {
                        cmd.CommandText = cmd.CommandText + " and returnsupcode = '" + dt[i].cvencode + "'";
                    }
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                ID = dr["ID"].ToInt32();
                                break;
                            }
                            if (dr != null && !dr.IsClosed) dr.Close();
                        }
                    }
                    if (ID >= 0)
                    {
                        strSql += @"update T_STOCK_MaterialImport set qty=qty + " + dt[i].Qty.ToString("F0") + " where ID = " + ID.ToString() + ";";
                    }
                    else
                    {
                        //校验U8数据
                        bool U8checked = false;
                        string querysql = @"select cinvname,cinvstd from inventory where cinvcode = '" + dt[i].MaterialNo + "'";
                        using (SqlDataReader dr = OperationSql.ExecuteReaderForU8(CommandType.Text, querysql, null))
                        {
                            if (dr != null)
                            {
                                while (dr.Read())
                                {
                                    dt[i].MaterialDesc = dr["cinvname"].ToString();
                                    dt[i].MaterialStd = dr["cinvstd"].ToString();
                                    U8checked = true;
                                    break;
                                }
                                if (dr != null && !dr.IsClosed) dr.Close();
                            }
                        }
                        if (!U8checked)
                        {
                            strErrMsg = "第" + (i + 1).ToString() + "行的物料编码" + dt[i].MaterialNo + "在U8中不存在!";
                            myTran.Rollback();
                            conn.Close();
                            return false;
                        }
                        querysql = @"select bProxyWh from Warehouse where bProxyWh = '1' and cWhCode = '" + dt[i].WarehouseNo + "'";
                        using (SqlDataReader dr1 = OperationSql.ExecuteReaderForU8(CommandType.Text, querysql, null))
                        {
                            if (dr1 != null)
                            {
                                while (dr1.Read())
                                {
                                    if (dt[i].cvencode.Equals(string.Empty) || dt[i].cvencode.Equals(""))
                                    {
                                        strErrMsg = "第" + (i + 1).ToString() + "行的物料编码" + dt[i].MaterialNo + "在U8中的仓库代码" + dt[i].WarehouseNo + "是代管仓，必须填写供应商代码";
                                        myTran.Rollback();
                                        conn.Close();
                                        return false;
                                    }
                                    else
                                    {
                                        dt[i].cvenname = OperationSql.ExecuteScalarForU8(CommandType.Text, "select cVenAbbName from Vendor where cVenCode = '" + dt[i].cvencode + "'", null).ToDBString();
                                        if (dt[i].cvenname.Equals(string.Empty) || dt[i].cvenname.Equals(""))
                                        {
                                            strErrMsg = "第" + (i + 1).ToString() + "行的物料编码" + dt[i].MaterialNo + "在U8中的供应商代码" + dt[i].cvencode + "不存在";
                                            myTran.Rollback();
                                            conn.Close();
                                            return false;
                                        }
                                    }
                                    break;
                                }
                                if (dr1 != null && !dr1.IsClosed) dr1.Close();
                            }
                        }
                        //获取ID
                        cmd.CommandText = "P_GetNewSeqVal_SEQ_STOCK_MaterialImport";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                        cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                        cmd.Parameters.Clear();
                        Stock_Model stockmodel = dt[i];
                        if (dt[i].cvencode.Equals(string.Empty) || dt[i].cvencode.Equals(""))
                        {
                            strSql += @"insert T_STOCK_MaterialImport (id,materialno,materialdesc,materialstd,warehouseno,houseno,areano,qty,status,isdel,batchno) values(" + ID.ToString() + ",'" + stockmodel.MaterialNo + "','" + stockmodel.MaterialDesc + "','" + stockmodel.MaterialStd + "','" + stockmodel.WarehouseNo + "','" + stockmodel.HouseNo + "','" + stockmodel.AreaNo + "'," + stockmodel.Qty.ToString("F0") + ",1,0,'期初');";
                        }
                        else
                        {
                            strSql += @"insert T_STOCK_MaterialImport (id,materialno,materialdesc,materialstd,warehouseno,houseno,areano,qty,status,isdel,batchno,returnsupcode,returnsupname) values(" + ID.ToString() + ",'" + stockmodel.MaterialNo + "','" + stockmodel.MaterialDesc + "','" + stockmodel.MaterialStd + "','" + stockmodel.WarehouseNo + "','" + stockmodel.HouseNo + "','" + stockmodel.AreaNo + "'," + stockmodel.Qty.ToString("F0") + ",1,0,'期初','" + dt[i].cvencode + "','" + dt[i].cvenname + "');";
                        }
                    }
                }
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                int r = cmd.ExecuteNonQuery();
                if (r == 0)
                {
                    strErrMsg = strSql + "保存数据失败";
                    myTran.Rollback();
                    conn.Close();
                    return false;
                }
                myTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                myTran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        internal bool CreateInitialMaterialBarcode(Stock_Model stockmodel, MaterialLabel_Model labelModel, int qty, ref List<MaterialLabel_Model> label_lst, ref string strErrMsg)
        {
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            SqlTransaction myTran;
            myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = myTran;
            try
            {
                label_lst = new List<MaterialLabel_Model>();
                //string BatchNo = labelModel.printdate + labelModel.plantno;
                string strSql = "";
                //获取流水号
                int SerialNo = 1;
                cmd.CommandText = @"select SerialNo from T_SerialNo where BatchNo = '160804X'";
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                //using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, @"select SerialNo from T_SerialNo where BatchNo = '151112X'", null))
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            SerialNo = dr["SerialNo"].ToInt32() + 1;
                        }
                        if (dr != null && !dr.IsClosed) dr.Close();
                    }
                }
                for (int i = 0; i < qty; i++)
                {
                    MaterialLabel_Model detail = new MaterialLabel_Model();
                    detail.prdversion = "3";
                    detail.labeltype = "09";
                    detail.outpackqty = labelModel.outpackqty;
                    detail.materialno = labelModel.materialno;
                    detail.materialdesc = labelModel.materialdesc;
                    detail.invstd = labelModel.invstd;
                    detail.batchno = "160804X";
                    detail.printdate = DateTime.Today.ToString("yyMMdd");//labelModel.printdate;
                    detail.Remark = qty.ToString() + "/" + (i + 1).ToString().PadLeft(4, '0');
                    detail.packno = (SerialNo + i).ToString().PadLeft(6, '0');
                    detail.BarcodeExpress = "160804X" + detail.packno;
                    detail.barcode = detail.labeltype + "@" + detail.materialno + "@@" + detail.batchno + "@" + Convert.ToInt16(detail.outpackqty).ToString().PadLeft(4, '0') + "@160804X@" + detail.packno;
                    detail.cvencode = labelModel.cvencode;
                    detail.cvenabbname = labelModel.cvenabbname;
                    label_lst.Add(detail);
                    detail.Locale = stockmodel.AreaNo; //stockmodel.WarehouseNo + "-" + stockmodel.HouseNo + "-" + stockmodel.AreaNo;
                    //获取ID
                    cmd.CommandText = "P_GetNewSeqVal_SEQ_OUTBARCODEID";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                    cmd.Parameters.Clear();
                    if (label_lst[i].cvencode.Length > 0)
                    {
                        strSql += @"insert T_OUTBARCODE (id,barcodetype,outpackqty,qty,materialno,materialdesc,materialstd,barcode,Remark,operationdate,serialno,batchno,prdversion,supcode,supname) values ("
                            + ID.ToString() + ",'" + label_lst[i].labeltype + "'," + label_lst[i].outpackqty + "," + label_lst[i].outpackqty + ",'"
                            + label_lst[i].materialno + "','" + label_lst[i].materialdesc + "','" + label_lst[i].invstd + "','" + label_lst[i].barcode + "','" + label_lst[i].Remark
                            + "',GETDATE(),'" + label_lst[i].BarcodeExpress + "','160804X','" + label_lst[i].prdversion + "','" + label_lst[i].cvencode + "','" + label_lst[i].cvenabbname + "');";
                    }
                    else
                    {
                        strSql += @"insert T_OUTBARCODE (id,barcodetype,outpackqty,qty,materialno,materialdesc,materialstd,barcode,Remark,operationdate,serialno,batchno,prdversion) values ("
                    + ID.ToString() + ",'" + label_lst[i].labeltype + "'," + label_lst[i].outpackqty + "," + label_lst[i].outpackqty + ",'"
                    + label_lst[i].materialno + "','" + label_lst[i].materialdesc + "','" + label_lst[i].invstd + "','" + label_lst[i].barcode + "','" + label_lst[i].Remark
                    + "',GETDATE(),'" + label_lst[i].BarcodeExpress + "','160804X','" + label_lst[i].prdversion + "');";
                    }
                    //strSql += @"insert T_OUTBARCODE (id,barcodetype,outpackqty,qty,materialno,materialdesc,materialstd,barcode,Remark,operationdate,serialno,batchno,prdversion) values ("
                    //+ ID.ToString() + ",'" + label_lst[i].labeltype + "'," + label_lst[i].outpackqty + "," + label_lst[i].outpackqty + ",'"
                    //+ label_lst[i].materialno + "','" + label_lst[i].materialdesc + "','" + label_lst[i].invstd + "','" + label_lst[i].barcode + "','" + label_lst[i].Remark
                    //+ "',GETDATE(),'" + label_lst[i].BarcodeExpress + "','160804X','" + label_lst[i].prdversion + "');";
                    //获取STOCK_ID
                    cmd.CommandText = "P_GetNewSeqVal_SEQ_STOCK";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int STOCK_ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                    cmd.Parameters.Clear();
                    if (label_lst[i].cvencode.Length > 0)
                    {
                        strSql += @"insert T_STOCK (id,materialno,materialdesc,materialstd,warehouseno,houseno,areano,qty,barcode,serialno,batchno,createtime,status,isdel) values(" + STOCK_ID.ToString() + ",'" + stockmodel.MaterialNo + "','" + stockmodel.MaterialDesc + "','" + stockmodel.MaterialStd + "','" + stockmodel.WarehouseNo + "','" + stockmodel.HouseNo + "','" + stockmodel.AreaNo + "'," + Convert.ToInt16(labelModel.outpackqty).ToString() + ",'" + detail.barcode + "','" + detail.BarcodeExpress + "','160804X',GETDATE(),1,0);";
                        strSql += @"update T_STOCK_MaterialImport set qty=qty - " + Convert.ToInt16(labelModel.outpackqty).ToString() + " where batchno = '期初' and materialno = '" + stockmodel.MaterialNo + "' and warehouseno = '" + stockmodel.WarehouseNo + "' and houseno = '" + stockmodel.HouseNo + "' and areano = '" + stockmodel.AreaNo + "' and returnsupcode ='" + label_lst[i].cvencode + "' ;";
                    }
                    else
                    {
                        strSql += @"insert T_STOCK (id,materialno,materialdesc,materialstd,warehouseno,houseno,areano,qty,barcode,serialno,batchno,createtime,status,isdel) values(" + STOCK_ID.ToString() + ",'" + stockmodel.MaterialNo + "','" + stockmodel.MaterialDesc + "','" + stockmodel.MaterialStd + "','" + stockmodel.WarehouseNo + "','" + stockmodel.HouseNo + "','" + stockmodel.AreaNo + "'," + Convert.ToInt16(labelModel.outpackqty).ToString() + ",'" + detail.barcode + "','" + detail.BarcodeExpress + "','160804X',GETDATE(),1,0);";
                        strSql += @"update T_STOCK_MaterialImport set qty=qty - " + Convert.ToInt16(labelModel.outpackqty).ToString() + " where batchno = '期初' and materialno = '" + stockmodel.MaterialNo + "' and warehouseno = '" + stockmodel.WarehouseNo + "' and houseno = '" + stockmodel.HouseNo + "' and areano = '" + stockmodel.AreaNo + "' ;";
                    }
                    
                }
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                int r = cmd.ExecuteNonQuery();
                if (r == 0)
                {
                    strErrMsg = strSql + "保存数据失败";
                    myTran.Rollback();
                    conn.Close();
                    return false;
                }
                //更新T_SerialNo
                strSql = @"select SerialNo from T_SerialNo where BatchNo = '160804X'";
                bool checkedSerialNo = false;
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            checkedSerialNo = true;
                            break;
                        }
                        if (dr != null && !dr.IsClosed) dr.Close();
                    }
                }
                if (!checkedSerialNo)
                {
                    strSql = @"insert T_SerialNo (SerialNo,BatchNo) values (" + (Convert.ToInt64(label_lst[qty - 1].packno)).ToString() + ",'160804X')";
                }
                else
                {
                    strSql = @"update T_SerialNo set SerialNo = " + (Convert.ToInt64(label_lst[qty - 1].packno)).ToString() + " where BatchNo = '160804X'";
                }
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                r = cmd.ExecuteNonQuery();
                if (r == 0)
                {
                    strErrMsg = strSql + "保存数据失败";
                    myTran.Rollback();
                    conn.Close();
                    return false;
                }
                myTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                myTran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        internal List<MaterialLabel_Model> GetOMLstForPrint(string ccode, string cvenabbname, string begindate, string enddate, ref string strErrMsg)
        {
            try
            {
                string strSql = @"select * from om_mohead where  cvoucherstate = '审核' ";
                if (!ccode.Equals(""))
                {
                    strSql = strSql + " and ccode like N'%" + ccode + "%' ";
                }
                if (!cvenabbname.Equals(""))
                {
                    strSql = strSql + " and cvenabbname like N'%" + cvenabbname + "%' ";
                }
                if (!begindate.Equals(""))
                {
                    if (!enddate.Equals(""))
                    {
                        strSql = strSql + " and dcreatetime between '" + begindate + "' and DATEADD(DD, 1, '" + enddate + "') ";
                    }
                    else
                    {
                        strSql = strSql + " and dcreatetime > '" + begindate + "'";
                    }
                }
                else
                {
                    if (!enddate.Equals(""))
                    {
                        strSql = strSql + " and dcreatetime < '" + enddate + "'";
                    }
                }
                SqlDataReader dr = OperationSql.ExecuteReaderForU8(CommandType.Text, strSql, null);
                if (dr == null) return null;
                List<MaterialLabel_Model> lst = new List<MaterialLabel_Model>(); ;
                while (dr.Read())
                {
                    MaterialLabel_Model head = new MaterialLabel_Model();
                    head.cvencode = dr["cvencode"].ToDBString();
                    head.cvenabbname = dr["cvenabbname"].ToDBString();
                    head.cpoid = dr["ccode"].ToDBString();
                    strSql = @"Select iquantity,ivouchrowno,cinvname,cinvstd, OM_MODetails.* From  OM_MODetails  left join  inventory on inventory.cInvCode=OM_MODetails.cinvcode where  cbCloser is null and MOID = N'" + dr["moid"].ToDBString() + "' order by ivouchrowno";

                    using (SqlDataReader drow = OperationSql.ExecuteReaderForU8(CommandType.Text, strSql, null))
                    {
                        //lst = new List<MaterialLabel_Model>();
                        while (drow.Read())
                        {
                            MaterialLabel_Model model = new MaterialLabel_Model();
                            model.cvencode = head.cvencode;
                            model.cvenabbname = head.cvenabbname;
                            model.cpoid = head.cpoid;
                            model.materialno = drow["cinvcode"].ToDBString();
                            model.materialdesc = drow["cinvname"].ToDBString();
                            model.invstd = drow["cinvstd"].ToDBString();
                            model.iquantity = drow["iquantity"].ToDouble();
                            model.ivouchrowno = drow["ivouchrowno"].ToDBString();
                            string sql = "select sum(qty) as PrintedQTY from T_OUTBARCODE where vouchertype = '70' and barcodetype = '00' and voucherno = '" + head.cpoid + "' and rowno = '" + model.ivouchrowno + "'";
                            SqlDataReader drsum = OperationSql.ExecuteReader(CommandType.Text, sql, null);
                            if (drsum == null)
                            {
                                model.PrintedQTY = 0;
                                model.ImprintedQTY = model.iquantity;
                            }
                            else
                            {
                                drsum.Read();
                                model.PrintedQTY = drsum["PrintedQTY"].ToDouble();
                                model.ImprintedQTY = model.iquantity - model.PrintedQTY;
                                if (model.ImprintedQTY < 0)
                                {
                                    model.ImprintedQTY = 0;
                                }
                                drsum.Close();
                            }
                            lst.Add(model);
                        }
                        if (drow != null && !drow.IsClosed) drow.Close();
                    }
                }
                if (dr != null && !dr.IsClosed) dr.Close();
                return lst;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return null;
            }

        }

        public bool CreateMaterialBarcodeForOM(MaterialLabel_Model labelModel, int qty, string PackQty, string EndPackQty, ref List<MaterialLabel_Model> label_lst, ref string strErrMsg)
        {
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            SqlTransaction myTran;
            myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = myTran;
            try
            {
                string strSql = "";
                string BatchNo = DateTime.Today.ToString("yyMMdd"); ;
                int r;
                label_lst = new List<MaterialLabel_Model>();
                for (int i = 0; i < qty; i++)
                {
                    MaterialLabel_Model detail = new MaterialLabel_Model();
                    detail.prdversion = labelModel.prdversion;
                    detail.cpoid = labelModel.cpoid;
                    detail.ivouchrowno = labelModel.ivouchrowno;
                    detail.labeltype = labelModel.labeltype;//"00"
                    if (i == qty - 1)
                    {
                        detail.outpackqty = EndPackQty;
                    }
                    else
                    {
                        detail.outpackqty = PackQty;
                    }

                    detail.materialno = labelModel.materialno;
                    detail.materialdesc = labelModel.materialdesc;
                    detail.invstd = labelModel.invstd;
                    detail.cvencode = labelModel.cvencode;
                    detail.cvenabbname = labelModel.cvenabbname;
                    detail.batchno = labelModel.batchno;
                    detail.printdate = BatchNo;// DateTime.Today.ToString("yyMMdd");//labelModel.printdate;
                    detail.Remark = qty.ToString() + "/" + (i + 1).ToString().PadLeft(4, '0');
                    detail.packno = (Convert.ToInt16(GetSerialNo(BatchNo)) + i + 1).ToString().PadLeft(5, '0');
                    detail.BarcodeExpress = BatchNo + detail.packno;
                    detail.barcode = detail.labeltype + "@" + detail.materialno + "@" + detail.cvencode + "@" + detail.batchno + "@" + Convert.ToInt16(detail.outpackqty).ToString().PadLeft(4, '0') + "@" + BatchNo + "@" + detail.packno;
                    label_lst.Add(detail);
                }
                for (int i = 0; i < label_lst.Count; i++)
                {

                    //获取ID
                    cmd.CommandText = "P_GetNewSeqVal_SEQ_OUTBARCODEID";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                    cmd.Parameters.Clear();

                    strSql += @"insert T_OUTBARCODE (id,barcodetype,vouchertype,voucherno,rowno,outpackqty,qty,materialno,materialdesc,materialstd,barcode,supcode,supname,Remark,operationdate,serialno,batchno,prdversion) values ("
                    + ID.ToString() + ",'" + label_lst[i].labeltype + "', '70','" + label_lst[i].cpoid + "','" + label_lst[i].ivouchrowno + "'," + label_lst[i].outpackqty + "," + label_lst[i].outpackqty + ",'"
                    + label_lst[i].materialno + "','" + label_lst[i].materialdesc + "','" + label_lst[i].invstd + "','" + label_lst[i].barcode + "','" + label_lst[i].cvencode + "','" + label_lst[i].cvenabbname + "','" + label_lst[i].Remark
                    + "',GETDATE(),'" + label_lst[i].BarcodeExpress + "','" + BatchNo + "','" + label_lst[i].prdversion + "');";

                    if (strSql.Length > 5000)
                    {
                        cmd.CommandText = strSql;
                        cmd.CommandType = CommandType.Text;
                        r = cmd.ExecuteNonQuery();
                        if (r == 0)
                        {
                            strErrMsg = strSql + "保存数据失败";
                            myTran.Rollback();
                            conn.Close();
                            return false;
                        }
                        strSql = "";
                    }
                }
                if (strSql.Length > 0)
                {
                    cmd.CommandText = strSql;
                    cmd.CommandType = CommandType.Text;
                    r = cmd.ExecuteNonQuery();
                    if (r == 0)
                    {
                        strErrMsg = strSql + "保存数据失败";
                        myTran.Rollback();
                        conn.Close();
                        return false;
                    }
                }
                //更新T_SerialNo
                strSql = @"select SerialNosArea from T_SerialArea where BatchNo = '" + BatchNo + "'"; //@"select SerialNo from SerialNosArea where BatchNo = '" + BatchNo + "'";
                bool checkedSerialNo = false;
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            checkedSerialNo = true;
                            break;
                        }
                        if (dr != null && !dr.IsClosed) dr.Close();
                    }
                }
                if (!checkedSerialNo)
                {
                    strSql = @"insert T_SerialArea (SerialNosArea,BatchNo) values ('" + (Convert.ToInt16(label_lst[0].packno)).ToString() + "," + label_lst.Count.ToString() + "','" + BatchNo + "')";
                }
                else
                {
                    strSql = @"update T_SerialArea set SerialNosArea = SerialNosArea + '@" + (Convert.ToInt16(label_lst[0].packno)).ToString() + "," + label_lst.Count.ToString() + "' where BatchNo = '" + BatchNo + "'";
                }
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                r = cmd.ExecuteNonQuery();
                if (r == 0)
                {
                    strErrMsg = strSql + "保存数据失败";
                    myTran.Rollback();
                    conn.Close();
                    return false;
                }
                myTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                myTran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        internal bool GetMaterialLabelInfo(string cinvcode, string cinvname, string cinvstd, ref MaterialLabel_Model model, ref string strErrMsg)
        {
            try
            {
                string strSql = @"select top 1 * from inventory where (1=1)";
                if (!cinvcode.Equals(""))
                {
                    strSql = strSql + " and cInvCode like N'%" + cinvcode + "%' ";
                }
                if (!cinvname.Equals(""))
                {
                    strSql = strSql + " and cInvName like N'%" + cinvname + "%' ";
                }
                if (!cinvstd.Equals(""))
                {
                    strSql = strSql + " and cInvStd like N'%" + cinvstd + "%' ";
                }
                SqlDataReader dr = OperationSql.ExecuteReaderForU8(CommandType.Text, strSql, null);
                if (dr == null) return false;
                while (dr.Read())
                {
                    model = new MaterialLabel_Model();
                    model.materialno = dr["cInvCode"].ToDBString();
                    model.materialdesc = dr["cInvName"].ToDBString();
                    model.invstd = dr["cInvStd"].ToDBString();
                    break;
                }
                if (dr != null && !dr.IsClosed) dr.Close();
                return true;
            }
            catch(Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
        }

        internal bool CreateMaterialBarcodeForNull(MaterialLabel_Model labelModel, Stock_Model stmodel, int qty, string PackQty, string EndPackQty, ref List<MaterialLabel_Model> label_lst, ref string strErrMsg)
        {
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            SqlTransaction myTran;
            myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = myTran;
            try
            {
                string strSql = "";
                string BatchNo = DateTime.Today.ToString("yyMMdd"); ;
                int r;
                label_lst = new List<MaterialLabel_Model>();
                for (int i = 0; i < qty; i++)
                {
                    MaterialLabel_Model detail = new MaterialLabel_Model();
                    detail.prdversion = labelModel.prdversion;
                    detail.labeltype = labelModel.labeltype;//"00"
                    if (i == qty - 1)
                    {
                        detail.outpackqty = EndPackQty;
                    }
                    else
                    {
                        detail.outpackqty = PackQty;
                    }
                    if (labelModel.cvencode != null && labelModel.cvencode.Length > 0)
                    {
                        detail.cvencode = labelModel.cvencode;
                        detail.cvenabbname = labelModel.cvenabbname;
                    }
                    detail.materialno = labelModel.materialno;
                    detail.materialdesc = labelModel.materialdesc;
                    detail.invstd = labelModel.invstd;
                    detail.batchno = labelModel.batchno;
                    detail.printdate = BatchNo;// DateTime.Today.ToString("yyMMdd");//labelModel.printdate;
                    detail.Remark = qty.ToString() + "/" + (i + 1).ToString().PadLeft(4, '0');
                    detail.packno = (Convert.ToInt16(GetSerialNo(BatchNo)) + i + 1).ToString().PadLeft(5, '0');
                    detail.BarcodeExpress = BatchNo + detail.packno;
                    detail.barcode = detail.labeltype + "@" + detail.materialno + "@@" + detail.batchno + "@" + Convert.ToInt16(detail.outpackqty).ToString().PadLeft(4, '0') + "@" + BatchNo + "@" + detail.packno;
                    label_lst.Add(detail);
                }
                for (int i = 0; i < label_lst.Count; i++)
                {

                    //获取ID
                    cmd.CommandText = "P_GetNewSeqVal_SEQ_OUTBARCODEID";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                    cmd.Parameters.Clear();
                    if (label_lst[i].cvencode.Length > 0)
                    {
                        strSql += @"insert T_OUTBARCODE (id,barcodetype,outpackqty,qty,materialno,materialdesc,materialstd,barcode,Remark,operationdate,serialno,batchno,prdversion,supcode,supname) values ("
                    + ID.ToString() + ",'" + label_lst[i].labeltype + "'," + label_lst[i].outpackqty + "," + label_lst[i].outpackqty + ",'"
                    + label_lst[i].materialno + "','" + label_lst[i].materialdesc + "','" + label_lst[i].invstd + "','" + label_lst[i].barcode + "','" + label_lst[i].Remark
                    + "',GETDATE(),'" + label_lst[i].BarcodeExpress + "','" + BatchNo + "','" + label_lst[i].prdversion + "','" + label_lst[i].cvencode + "','" + label_lst[i].cvenabbname + "');";
                    }
                    else
                    {
                        strSql += @"insert T_OUTBARCODE (id,barcodetype,outpackqty,qty,materialno,materialdesc,materialstd,barcode,Remark,operationdate,serialno,batchno,prdversion) values ("
                    + ID.ToString() + ",'" + label_lst[i].labeltype + "'," + label_lst[i].outpackqty + "," + label_lst[i].outpackqty + ",'"
                    + label_lst[i].materialno + "','" + label_lst[i].materialdesc + "','" + label_lst[i].invstd + "','" + label_lst[i].barcode + "','" + label_lst[i].Remark
                    + "',GETDATE(),'" + label_lst[i].BarcodeExpress + "','" + BatchNo + "','" + label_lst[i].prdversion + "');";
                    }
                    //strSql += @"insert T_OUTBARCODE (id,barcodetype,outpackqty,qty,materialno,materialdesc,materialstd,barcode,Remark,operationdate,serialno,batchno,prdversion) values ("
                    //+ ID.ToString() + ",'" + label_lst[i].labeltype + "'," + label_lst[i].outpackqty + "," + label_lst[i].outpackqty + ",'"
                    //+ label_lst[i].materialno + "','" + label_lst[i].materialdesc + "','" + label_lst[i].invstd + "','" + label_lst[i].barcode + "','" + label_lst[i].Remark
                    //+ "',GETDATE(),'" + label_lst[i].BarcodeExpress + "','" + BatchNo + "','" + label_lst[i].prdversion + "');";
                    if (stmodel != null)
                    {
                        //获取STOCK_ID
                        cmd.CommandText = "P_GetNewSeqVal_SEQ_STOCK";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                        cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        int STOCK_ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                        cmd.Parameters.Clear();
                        strSql += @"insert T_STOCK (id,materialno,materialdesc,materialstd,warehouseno,houseno,areano,qty,barcode,serialno,batchno,createtime,status,isdel) values(" + STOCK_ID.ToString() + ",'" + label_lst[i].materialno + "','" + label_lst[i].materialdesc + "','" + label_lst[i].invstd + "','" + stmodel.WarehouseNo + "','" + stmodel.HouseNo + "','" + stmodel.AreaNo + "'," + Convert.ToInt16(labelModel.outpackqty).ToString() + ",'" + label_lst[i].barcode + "','" + label_lst[i].BarcodeExpress + "','" + BatchNo + "',GETDATE(),1,0);";
                    }
                    
                    if (strSql.Length > 5000)
                    {
                        cmd.CommandText = strSql;
                        cmd.CommandType = CommandType.Text;
                        r = cmd.ExecuteNonQuery();
                        if (r == 0)
                        {
                            strErrMsg = strSql + "保存数据失败";
                            myTran.Rollback();
                            conn.Close();
                            return false;
                        }
                        strSql = "";
                    }
                }
                if (strSql.Length > 0)
                {
                    cmd.CommandText = strSql;
                    cmd.CommandType = CommandType.Text;
                    r = cmd.ExecuteNonQuery();
                    if (r == 0)
                    {
                        strErrMsg = strSql + "保存数据失败";
                        myTran.Rollback();
                        conn.Close();
                        return false;
                    }
                }
                //更新T_SerialNo
                strSql = @"select SerialNosArea from T_SerialArea where BatchNo = '" + BatchNo + "'"; //@"select SerialNo from SerialNosArea where BatchNo = '" + BatchNo + "'";
                bool checkedSerialNo = false;
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            checkedSerialNo = true;
                            break;
                        }
                        if (dr != null && !dr.IsClosed) dr.Close();
                    }
                }
                if (!checkedSerialNo)
                {
                    strSql = @"insert T_SerialArea (SerialNosArea,BatchNo) values ('" + (Convert.ToInt16(label_lst[0].packno)).ToString() + "," + label_lst.Count.ToString() + "','" + BatchNo + "')";
                }
                else
                {
                    strSql = @"update T_SerialArea set SerialNosArea = SerialNosArea + '@" + (Convert.ToInt16(label_lst[0].packno)).ToString() + "," + label_lst.Count.ToString() + "' where BatchNo = '" + BatchNo + "'";
                }
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                r = cmd.ExecuteNonQuery();
                if (r == 0)
                {
                    strErrMsg = strSql + "保存数据失败";
                    myTran.Rollback();
                    conn.Close();
                    return false;
                }
                myTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                myTran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        internal bool CheckbProxyWhBycWhCode(string cWhCode, ref string strErrMsg)
        {
            try
            {
                string querysql = @"select bProxyWh from Warehouse where bProxyWh = '1' and cWhCode = '" + cWhCode + "'";
                using (SqlDataReader dr = OperationSql.ExecuteReaderForU8(CommandType.Text, querysql, null))
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            return true;
                        }
                        if (dr != null && !dr.IsClosed) dr.Close();
                    }
                }
                return false;
            }
            catch(Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
        }

        internal bool GetVendorByCode(string cvencode, ref Vendor vendor, ref string strErrMsg)
        {
            try
            {
                string querysql = @"select * from Vendor where cvencode = '" + cvencode + "'";
                using (SqlDataReader dr = OperationSql.ExecuteReaderForU8(CommandType.Text, querysql, null))
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            vendor = new Vendor();
                            vendor.cVenCode = dr["cVenCode"].ToDBString();
                            vendor.cVenAbbName = dr["cVenAbbName"].ToDBString();
                            return true;
                        }
                        if (dr != null && !dr.IsClosed) dr.Close();
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
        }

        public bool QueryMaterialBarcodeReport(string barcode, string voucherno, string ArrivalCode, string InCode, string OutCode, string materialno, string materialdesc, string materialstd, out List<BarcodeReport_Model> lst, out string strErrMsg)
        {
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                lst = null;
                return false;
            }
            //SqlTransaction myTran;
            //myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            //cmd.Transaction = myTran;
            try
            {
                //如果有条码，先通过条码获取采购订单号
                string sql = "";
                string pucode = null;
                if(barcode != null && barcode.Length > 0)
                {
                    sql = @"select voucherno from T_OUTBARCODE where barcodetype = '00' and serialno = '" + barcode + "'";
                    using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, sql, null))
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                pucode = dr["voucherno"].ToDBString();
                                break;
                            }
                            if (dr != null && !dr.IsClosed) dr.Close();
                        }
                    }
                }
                sql = @"select m.voucherno,m.rowno,arrival.cCode as acode,pin.cCode as pcode,mout.cCode as mcode,m.materialno,m.materialdesc,m.materialstd,m.batchno,sum(m.qty) as mqty,sum(arrival.qty) as aqty,sum(pin.qty) as pqty,sum(mout.qty) as oqty
from (select * from T_OUTBARCODE where barcodetype = '00') as m
left join (select voucherno,cCode,serialno,qty,rowno from T_ArrivalDetails
inner join T_ArrivalRecord on T_ArrivalDetails.id = T_ArrivalRecord.id) as arrival on arrival.serialno = m.serialno
left join (select voucherno,cCode,serialno,qty,rowno from T_PuStoreInDetails
inner join T_PuStoreInRecord on T_PuStoreInDetails.id = T_PuStoreInRecord.id) as pin on pin.serialno = m.serialno
left join (select voucherno,cCode,serialno,qty,rowno from T_MaterialOutDetails
inner join T_MaterialOutRecord on T_MaterialOutDetails.id = T_MaterialOutRecord.id) as mout on mout.serialno = m.serialno
group by m.voucherno,m.rowno,arrival.cCode,pin.cCode,mout.cCode,m.materialno,m.materialdesc,m.materialstd,m.batchno
having (1=1)  ";
                if (pucode != null && voucherno == null)
                {
                    sql = sql + "and m.voucherno = '" + pucode + "' ";
                }
                if (voucherno != null)
                {
                    sql = sql + "and m.voucherno = '" + voucherno + "' ";
                }
                if (ArrivalCode != null)
                {
                    sql = sql + "and arrival.cCode = '" + ArrivalCode + "' ";
                }
                if (InCode != null)
                {
                    sql = sql + "and pin.cCode = '" + InCode + "' ";
                }
                if (OutCode != null)
                {
                    sql = sql + "and mout.cCode = '" + OutCode + "' ";
                }
                if (materialno != null)
                {
                    sql = sql + "and materialno = '" + materialno + "' ";
                }
                if (materialdesc != null)
                {
                    sql = sql + "and materialdesc = '" + materialdesc + "' ";
                }
                if (materialstd != null)
                {
                    sql = sql + "and materialstd = '" + materialstd + "' ";
                }

                lst = new List<BarcodeReport_Model>();
                using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, sql, null))
                {
                    if (dr == null)
                    {
                        strErrMsg = "查询数据失败";
                        return false;
                    }
                    BarcodeReport_Model model;
                    while (dr.Read())
                    {
                        model = new BarcodeReport_Model();
                        model.voucherno = dr["voucherno"].ToDBString();//采购订单
                        model.rowno = dr["rowno"].ToDBString();//采购订单行号
                        model.SoCode = dr["acode"].ToDBString();//到货号
                        model.ordercode = dr["pcode"].ToDBString();//入库单号
                        model.plantno = dr["mcode"].ToDBString();//出库单号
                        model.materialno = dr["materialno"].ToDBString();//物料编码
                        model.materialdesc = dr["materialdesc"].ToDBString();//物料名称
                        model.materialstd = dr["materialstd"].ToDBString();//规格型号
                        model.batchno = dr["batchno"].ToDBString();//批次号
                        model.printQty = dr["mqty"].ToDecimal();//已打印数量
                        model.voucherQty = dr["aqty"].ToDecimal();//到货数量
                        model.outpackqty = dr["pqty"].ToDecimal();//入库数量
                        model.QualifiedInQty = dr["oqty"].ToDecimal();//出库数量
                        lst.Add(model);
                    }
                }
                //myTran.Commit();
                conn.Close();
                strErrMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                lst = null;
                //myTran.Rollback();
                conn.Close();
                return false;
            }
        }

        public bool QueryMaterialBarcodeReportRowDetail(BarcodeReport_Model row, out List<BarcodeReport_RowDetail> lst, out string strErrMsg)
        {
            string connString = OperationSql.connectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                lst = null;
                return false;
            }
            cmd.Connection = conn;
            try
            {
                string sql = @"select m.id,m.serialno,m.iFlag,m.qty,T_STOCK.areano
from (select * from T_OUTBARCODE where barcodetype = '00') as m
left join (select voucherno,cCode,serialno,qty,rowno from T_ArrivalDetails
inner join T_ArrivalRecord on T_ArrivalDetails.id = T_ArrivalRecord.id) as arrival on arrival.serialno = m.serialno
left join (select voucherno,cCode,serialno,qty,rowno from T_PuStoreInDetails
inner join T_PuStoreInRecord on T_PuStoreInDetails.id = T_PuStoreInRecord.id) as pin on pin.serialno = m.serialno
left join (select voucherno,cCode,serialno,qty,rowno from T_MaterialOutDetails
inner join T_MaterialOutRecord on T_MaterialOutDetails.id = T_MaterialOutRecord.id) as mout on mout.serialno = m.serialno
left join T_STOCK on T_STOCK.serialno = m.serialno and (m.iFlag = '2' or m.iFlag = '3')  ";
                sql = sql + "where m.voucherno = '" + row.voucherno + "' and m.rowno = '" + row.rowno + "'";

                if (row.SoCode != null)
                {
                    sql = sql + "and arrival.cCode = '" + row.SoCode + "' ";
                }
                if (row.ordercode != null)
                {
                    sql = sql + "and pin.cCode = '" + row.ordercode + "' ";
                }
                if (row.plantno != null)
                {
                    sql = sql + "and mout.cCode = '" + row.plantno + "' ";
                }
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                lst = new List<BarcodeReport_RowDetail>();
                using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, sql, null))
                {
                    if (dr == null)
                    {
                        strErrMsg = "查询数据失败";
                        return false;
                    }
                    BarcodeReport_RowDetail model;
                    while (dr.Read())
                    {
                        model = new BarcodeReport_RowDetail();
                        model.serialno = dr["serialno"].ToDBString();
                        model.areano = dr["areano"].ToDBString();
                        //iFlag为null且TRAYID为null是已打印保存未组托,iFlag为null但TRAYID不为null是已组托未下线入库,1是保存未过账,2入库,3上架,4出库,5调拨中
                        if (dr["iFlag"].ToDBString().Equals(string.Empty))
                        {
                            model.iFlag = "已打印";
                        }
                        else if (dr["iFlag"].ToDBString().Equals("1"))
                        {
                            model.iFlag = "入库已保存未过账";
                        }
                        else if (dr["iFlag"].ToDBString().Equals("2"))
                        {
                            model.iFlag = "入库已过账";
                        }
                        else if (dr["iFlag"].ToDBString().Equals("3"))
                        {
                            model.iFlag = "已上架";
                        }
                        else if (dr["iFlag"].ToDBString().Equals("4"))
                        {
                            model.iFlag = "已出库";
                        }
                        else if (dr["iFlag"].ToDBString().Equals("10"))
                        {
                            model.iFlag = "采购到货";
                        }
                        else
                        {
                            model.iFlag = "未定义";
                        }
                        model.id = dr["id"].ToDBString();
                        lst.Add(model);
                    }
                }
                conn.Close();
                strErrMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                lst = null;
                conn.Close();
                return false;
            }
        }

//通过日期和仓库查询报表        
//select serialno,voucherno as invoucherno,rowno as inrowno,materialno,materialdesc,materialstd,qty as inqty 
//into tempquery1 from T_ProductInDetails
//inner join T_ProductInRecord on T_ProductInRecord.id = T_ProductInDetails.id
//where createtime between '2016-06-29' and '2016-06-30' and cwhcode = '131' 

//select serialno,voucherno as TMvoucherno,rowno as TMrowno,qty as TMqty 
//into tempquery2 from T_TransMoveDetails
//inner join T_TransMoveRecord on T_TransMoveRecord.id = T_TransMoveDetails.id
//where T_TransMoveDetails.serialno in (select serialno from T_ProductInDetails
//inner join T_ProductInRecord on T_ProductInRecord.id = T_ProductInDetails.id
//where createtime between '2016-06-29' and '2016-06-30' and cwhcode = '131')

//select serialno,voucherno as SOvoucherno,rowno as SOrowno,qty as SOqty 
//into tempquery3 from T_StockOutDetails
//inner join T_StockOutRecord on T_StockOutRecord.id = T_StockOutDetails.id
//where T_StockOutDetails.serialno in (select serialno from T_ProductInDetails
//inner join T_ProductInRecord on T_ProductInRecord.id = T_ProductInDetails.id
//where createtime between '2016-06-29' and '2016-06-30' and cwhcode = '131')

//select materialno,materialdesc,materialstd,invoucherno,inrowno,sum(inqty) as inqty,
//TMvoucherno,TMrowno,sum(TMqty) as TMqty,SOvoucherno,SOrowno,sum(SOqty) as SOqty
//from tempquery1
//left join tempquery2 on tempquery1.serialno = tempquery2.serialno
//left join tempquery3 on tempquery1.serialno = tempquery3.serialno
//group by materialno,materialdesc,materialstd,invoucherno,inrowno,
//TMvoucherno,TMrowno,SOvoucherno,SOrowno
    }
}
