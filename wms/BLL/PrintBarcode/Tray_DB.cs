using BLL.Basic.User;
using BLL.Common;
using BLL.Task;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BLL.PrintBarcode
{
    public class Tray_DB
    {
        public bool GetTrayInfoByTrayID(Barcode_Model Barcode_Model, ref Tray_Model trayInfo)
        {
            bool IsResult = false;

            DataSet ds;

            string sql = null, errMsg = string.Empty;
            sql = string.Format(@"select TRAYID,TrayNO,qty,materialno,materialdesc,materialstd,serialno,rowno from T_TRAY JOIN T_OUTBARCODE ON T_TRAY.ID=T_OUTBARCODE.TRAYID where T_TRAY.ID={0}", Barcode_Model.TrayID);
            OperationSql.GetDataset(sql, out ds, out errMsg);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                trayInfo = TOOL.DataTableToList.DataRowToModel<Tray_Model>(ds.Tables[0].Rows[0]);
                trayInfo.listDetails = new List<TrayDetails_Model>();
                TrayDetails_Model model;
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    TrayDetails_Model tdm = trayInfo.listDetails.Find(delegate (TrayDetails_Model v)
                    {
                        return v.cinvcode.ToUpper().Equals(item["materialno"].ToString().ToUpper())
&& (string.IsNullOrEmpty(item["rowno"].ToDBString()) || v.ROWNO.Equals(item["rowno"].ToDBString()));
                    });
                    if (tdm == null)
                    {
                        model = new TrayDetails_Model();
                        model.Qty = ObjectExtend.ToDouble(item["qty"]);
                        model.cinvcode = item["materialno"].ToString();
                        model.cinvname = item["materialdesc"].ToString();
                        model.cinvstd = item["materialstd"].ToString();

                        model.ROWNO = item["rowno"].ToDBString();
                        model.listBarcode = new List<string>() { item["serialno"].ToString() };
                        trayInfo.listDetails.Add(model);
                    }
                    else
                    {
                        tdm.listBarcode.Add(item["serialno"].ToString());
                        tdm.Qty += ObjectExtend.ToDouble(item["qty"]);
                    }
                }

                IsResult = true;
            }

            return IsResult;
        }

        public bool GetTrayInfoByTrayID2(Barcode_Model Barcode_Model, ref Tray_Model trayInfo)
        {
            bool IsResult = false;

            DataSet ds;

            string sql = null, errMsg = string.Empty;
            sql = string.Format(@"select voucherno,TRAYID,TrayNO,qty,materialno,materialdesc,materialstd,serialno,rowno from T_TRAY JOIN T_OUTBARCODE ON T_TRAY.ID=T_OUTBARCODE.TRAYID where T_TRAY.ID={0}", Barcode_Model.TrayID);
            OperationSql.GetDataset(sql, out ds, out errMsg);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].Columns.Add("socode", typeof(System.String));
                ds.Tables[0].Columns.Add("sorowno", typeof(System.String));
                //SqlDataReader sqlreader = null;
                //using (SqlConnection conOne = new SqlConnection(OperationSql.U8ConnStr))
                //{
                //    conOne.Open();
                //    SqlCommand command = new SqlCommand();
                //    command.Connection = conOne;
                //    foreach (DataRow item in ds.Tables[0].Rows)
                //    {
                //        sql = string.Format("select ISNULL(ordercode,'') socode,ISNULL(orderseq,'') sorowno from v_st_mom_orderdetail where mocode = '{0}' and MoSeq='{1}'", item["voucherno"].ToDBString(), item["rowno"].ToDBString());
                //        command.CommandText = sql;
                //        sqlreader = command.ExecuteReader();
                //        if (sqlreader.Read())
                //        {
                //            item["socode"] = sqlreader["socode"].ToDBString();
                //            item["sorowno"] = sqlreader["sorowno"].ToDBString();
                //        }
                //        if (sqlreader != null && !sqlreader.IsClosed)
                //            sqlreader.Close();
                //    }
                //}
                trayInfo = TOOL.DataTableToList.DataRowToModel<Tray_Model>(ds.Tables[0].Rows[0]);
                trayInfo.listDetails = new List<TrayDetails_Model>();
                TrayDetails_Model model;
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    TrayDetails_Model tdm = trayInfo.listDetails.Find(delegate (TrayDetails_Model v)
                    {
                        return v.cinvcode.ToUpper().Equals(item["materialno"].ToString().ToUpper())
&& (string.IsNullOrEmpty(item["sorowno"].ToDBString()) || item["sorowno"].ToDBString().Equals("0") || v.SOROWNO.Equals(item["sorowno"].ToDBString()));
                    });
                    if (tdm == null)
                    {
                        model = new TrayDetails_Model();
                        model.Qty = ObjectExtend.ToDouble(item["qty"]);
                        model.cinvcode = item["materialno"].ToString();
                        model.cinvname = item["materialdesc"].ToString();
                        model.cinvstd = item["materialstd"].ToString();

                        model.SOROWNO = item["sorowno"].ToDBString();
                        model.listBarcode = new List<string>() { item["serialno"].ToString() };
                        trayInfo.listDetails.Add(model);
                    }
                    else
                    {
                        tdm.listBarcode.Add(item["serialno"].ToString());
                        tdm.Qty += ObjectExtend.ToDouble(item["qty"]);
                    }
                }

                IsResult = true;
            }

            return IsResult;
        }

        public bool GetTrayInfoByTrayIDForOutStock(Barcode_Model Barcode_Model, ref Tray_Model trayInfo)
        {
            bool IsResult = false;
            string connString = OperationSql.U8ConnStr;
            DataSet ds = new DataSet();
            string errMsg = "";
            SqlCommand view = new SqlCommand();
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
                errMsg = ex.Message;
                return false;
            }
            cmd.Connection = conn;

            string sqlHead = string.Format(@"select ISNULL(orderseq,'') sorowno,TRAYID,TrayNO,bar.qty,materialno,serialno
FROM  ITSV.Barcode.DBO.T_TRAY tray join ITSV.Barcode.DBO.T_OUTBARCODE bar  ON tray.ID=bar.TRAYID
left JOIN v_st_mom_orderdetail m ON m.MoSeq=bar.rowno and bar.voucherno=m.MoCode where 1=1 and tray.ID={0}", Barcode_Model.TrayID);
            string WMSdbserver = "", WMSdbuser = "", WMSdbpwd = "";
            string tmp = OperationSql.connectionString;
            string tmp1 = "";
            tmp1 = tmp.Substring(tmp.IndexOf("Data Source="));
            WMSdbserver = tmp1.Substring(12, tmp1.IndexOf(";") - 12);
            tmp1 = tmp.Substring(tmp.IndexOf("UID="));
            WMSdbuser = tmp1.Substring(4, tmp1.IndexOf(";") - 4);
            tmp1 = tmp.Substring(tmp.IndexOf("Pwd="));
            WMSdbpwd = tmp1.Substring(4, tmp1.Length - 4);

            string CreatelinkServer = "";
            CreatelinkServer = (@"if exists(select 1 from master.dbo.sysservers where srvname='ITSV')
begin
    EXEC sp_dropserver 'ITSV','droplogins' 
end   
exec sp_addlinkedserver   'ITSV', '', 'SQLOLEDB ', '" + WMSdbserver + @"'; 
exec sp_addlinkedsrvlogin 'ITSV', 'false ',null, '" + WMSdbuser + "', '" + WMSdbpwd + @"' ;");

            DataTable dt1 = new DataTable("head");
            ds.Tables.Add(dt1);

            try
            {
                cmd.CommandText = CreatelinkServer;
                cmd.ExecuteNonQuery();
                cmd.CommandText = sqlHead;
                adp.SelectCommand = cmd;
                adp.Fill(ds.Tables["head"]);

                if (ds.Tables["head"].Rows.Count < 1)
                {
                    errMsg = "生产订单不存在或状态不正确！";
                    return false;
                }
                if (ds != null && ds.Tables.Count > 0 && ds.Tables["head"].Rows.Count > 0)
                {
                    trayInfo = TOOL.DataTableToList.DataRowToModel<Tray_Model>(ds.Tables[0].Rows[0]);
                    trayInfo.listDetails = new List<TrayDetails_Model>();
                    TrayDetails_Model model;
                    foreach (DataRow item in ds.Tables["head"].Rows)
                    {
                        TrayDetails_Model tdm = trayInfo.listDetails.Find(delegate (TrayDetails_Model v)
                        {
                            return v.cinvcode.ToUpper().Equals(item["materialno"].ToString().ToUpper())
&& (string.IsNullOrEmpty(item["sorowno"].ToDBString()) || item["sorowno"].ToDBString().Equals("0") || v.SOROWNO.Equals(item["sorowno"].ToDBString()));
                        });
                        if (tdm == null)
                        {
                            model = new TrayDetails_Model();
                            model.Qty = ObjectExtend.ToDouble(item["qty"]);
                            model.cinvcode = item["materialno"].ToString();
                            model.SOROWNO = item["sorowno"].ToDBString();
                            model.listBarcode = new List<string>() { item["serialno"].ToString() };
                            trayInfo.listDetails.Add(model);
                        }
                        else
                        {
                            tdm.listBarcode.Add(item["serialno"].ToString());
                            tdm.Qty += ObjectExtend.ToDouble(item["qty"]);
                        }
                        IsResult = true;
                    }
                }
                return IsResult;

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }

        }


        public bool UpdateTrayInfo(Barcode_Model Barcode_Model)
        {
            bool IsResult = false;

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
                return IsResult;
            }
            SqlTransaction myTran;
            myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = myTran;
            DataSet result = new DataSet();
            string sql;
            object o;
            try
            {
                int trayID = 0;//托ID
                string trayNO = string.Empty;//托号
                string productlineNo = Barcode_Model.cProductLineCode;//产线编码
                if (Barcode_Model.tray_Model.TrayID == 0)//还没有托号记录则手动生成
                {
                    //设置要调用的存储过程的名称  
                    cmd.CommandText = "P_GetNewSeqVal_SEQ_TRAYID";
                    //指定SqlCommand对象传给数据库的是存储过程的名称而不是sql语句  
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter SQLid = cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                    //指定"@ID"为输出参数  
                    SQLid.Direction = ParameterDirection.Output;
                    //执行  
                    cmd.ExecuteNonQuery();
                    trayID = Convert.ToInt32(cmd.Parameters["@ID"].Value);


                    cmd.CommandText = "P_GetNewSeqVal_SEQ_TRAY";
                    //执行  
                    cmd.ExecuteNonQuery();
                    trayNO = DateTime.Now.ToString("yyMMdd") + Convert.ToString(cmd.Parameters["@ID"].Value).PadLeft(4, '0');
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.Text;

                    if (string.IsNullOrEmpty(Barcode_Model.cProductLineCode))
                        sql = string.Format("insert into T_TRAY (ID,TrayNO,[createDt]) values ({0},'{1}',getdate())", trayID, trayNO);
                    else
                        sql = string.Format("insert into T_TRAY (ID,TrayNO,[ProductLineNo],[createDt]) values ({0},'{1}','{2}',getdate())", trayID, trayNO, productlineNo);
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    sql = string.Format("select serialno,qty from T_OUTBARCODE where trayid={0}", Barcode_Model.tray_Model.TrayID);
                    cmd.CommandText = sql;
                    adp.SelectCommand = cmd;
                    adp.Fill(result);
                    //拆托
                    foreach (DataRow dr in result.Tables[0].Rows)
                    {
                        bool IsFound = false;
                        foreach (var item in Barcode_Model.tray_Model.listDetails)
                        {
                            if (item.listBarcode.Contains(dr["serialno"].ToString()))
                            {
                                IsFound = true;
                                break;
                            }
                        }
                        if (!IsFound)
                        {
                            sql = string.Format("update T_OUTBARCODE set trayid=null,ProductLineNo=null where serialno='{0}';update T_TRAY SET TrayQty=ISNULL(TrayQty,0)-{2},[lastModifyDt]=getdate(),[lastModifyType]=-1 WHERE id={1}", dr["serialno"].ToString(), Barcode_Model.tray_Model.TrayID, dr["qty"].ToString());
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                int lastModifyType = 0;//组
                if (trayID == 0)
                {
                    trayID = Barcode_Model.tray_Model.TrayID;
                    lastModifyType = 1;//拼
                }

                //拼托
                foreach (var item in Barcode_Model.tray_Model.listDetails)
                {
                    foreach (var detail in item.listBarcode)
                    {
                        sql = string.Format("select serialno from T_OUTBARCODE where serialno='{0}' and trayid={1}", detail, trayID);
                        cmd.CommandText = sql;
                        o = cmd.ExecuteScalar();
                        if (o == null || o == DBNull.Value || string.IsNullOrEmpty(o.ToString()))
                        {
                            sql = string.Format("select qty from T_OUTBARCODE where serialno='{0}'", detail);
                            cmd.CommandText = sql;
                            o = cmd.ExecuteScalar();
                            if (string.IsNullOrEmpty(productlineNo))
                                sql = string.Format("update T_OUTBARCODE set trayid={1} where serialno='{0}';update T_TRAY SET TrayQty=ISNULL(TrayQty,0)+{2},[lastModifyDt]=getdate(),[lastModifyType]={3} WHERE id={1}", detail, trayID, o.ToString(), lastModifyType);
                            else
                                sql = string.Format("update T_OUTBARCODE set trayid={1},ProductLineNo='{3}' where serialno='{0}';update T_TRAY SET TrayQty=ISNULL(TrayQty,0)+{2},[lastModifyDt]=getdate(),[lastModifyType]={4} WHERE id={1}", detail, trayID, o.ToString(), productlineNo, lastModifyType);

                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                myTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                myTran.Rollback();
                return false;
            }
            finally
            {
                conn.Dispose();
                conn.Close();
            }

        }

        public bool UpdateTrayInfoPro(Barcode_Model Barcode_Model,ref string strErrMsg)
        {
            bool IsResult = false;

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
                return IsResult;
            }
            SqlTransaction myTran;
            myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = myTran;
            DataSet result = new DataSet();
            string sql;
            object o;
            try
            {
                int trayID = 0;//托ID
                string trayNO = string.Empty;//托号
                string productlineNo = Barcode_Model.cProductLineCode;//产线编码
                if (Barcode_Model.tray_Model.TrayID == 0)//还没有托号记录则手动生成
                {
                    //设置要调用的存储过程的名称  
                    cmd.CommandText = "P_GetNewSeqVal_SEQ_TRAYID";
                    //指定SqlCommand对象传给数据库的是存储过程的名称而不是sql语句  
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter SQLid = cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                    //指定"@ID"为输出参数  
                    SQLid.Direction = ParameterDirection.Output;
                    //执行  
                    cmd.ExecuteNonQuery();
                    trayID = Convert.ToInt32(cmd.Parameters["@ID"].Value);


                    cmd.CommandText = "P_GetNewSeqVal_SEQ_TRAY";
                    //执行  
                    cmd.ExecuteNonQuery();
                    trayNO = DateTime.Now.ToString("yyMMdd") + Convert.ToString(cmd.Parameters["@ID"].Value).PadLeft(4, '0');
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.Text;

                    if (string.IsNullOrEmpty(Barcode_Model.cProductLineCode))
                        sql = string.Format("insert into T_TRAY (ID,TrayNO,[createDt]) values ({0},'{1}',getdate())", trayID, trayNO);
                    else
                        sql = string.Format("insert into T_TRAY (ID,TrayNO,[ProductLineNo],[createDt]) values ({0},'{1}','{2}',getdate())", trayID, trayNO, productlineNo);
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    sql = string.Format("select serialno,qty from T_OUTBARCODE where trayid={0}", Barcode_Model.tray_Model.TrayID);
                    cmd.CommandText = sql;
                    adp.SelectCommand = cmd;
                    adp.Fill(result);
                    //拆托
                    foreach (DataRow dr in result.Tables[0].Rows)
                    {
                        bool IsFound = false;
                        foreach (var item in Barcode_Model.tray_Model.listDetails)
                        {
                            if (item.listBarcode.Contains(dr["serialno"].ToString()))
                            {
                                IsFound = true;
                                break;
                            }
                        }
                        if (!IsFound)
                        {
                            sql = string.Format("update T_OUTBARCODE set trayid=null,ProductLineNo=null where serialno='{0}';update T_TRAY SET TrayQty=ISNULL(TrayQty,0)-{2},[lastModifyDt]=getdate(),[lastModifyType]=-1 WHERE id={1}", dr["serialno"].ToString(), Barcode_Model.tray_Model.TrayID, dr["qty"].ToString());
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                int lastModifyType = 0;//组
                if (trayID == 0)
                {
                    trayID = Barcode_Model.tray_Model.TrayID;
                    lastModifyType = 1;//拼
                }

                //拼托
                foreach (var item in Barcode_Model.tray_Model.listDetails)
                {
                    foreach (var detail in item.listBarcode)
                    {
                        sql = string.Format("select serialno from T_OUTBARCODE where serialno='{0}' and trayid={1}", detail, trayID);
                        cmd.CommandText = sql;
                        o = cmd.ExecuteScalar();
                        if (o == null || o == DBNull.Value || string.IsNullOrEmpty(o.ToString()))
                        {
                            sql = string.Format("select qty from T_OUTBARCODE where serialno='{0}'", detail);
                            cmd.CommandText = sql;
                            o = cmd.ExecuteScalar();
                            if (string.IsNullOrEmpty(productlineNo))
                                sql = string.Format("update T_OUTBARCODE set trayid={1} where serialno='{0}';update T_TRAY SET TrayQty=ISNULL(TrayQty,0)+{2},[lastModifyDt]=getdate(),[lastModifyType]={3} WHERE id={1}", detail, trayID, o.ToString(), lastModifyType);
                            else
                                sql = string.Format("update T_OUTBARCODE set trayid={1},ProductLineNo='{3}' where serialno='{0}';update T_TRAY SET TrayQty=ISNULL(TrayQty,0)+{2},[lastModifyDt]=getdate(),[lastModifyType]={4} WHERE id={1}", detail, trayID, o.ToString(), productlineNo, lastModifyType);

                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                    }
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
                conn.Dispose();
                conn.Close();
            }

        }


    }
}
