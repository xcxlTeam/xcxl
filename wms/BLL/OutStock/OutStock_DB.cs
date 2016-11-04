using BLL.Basic.Area;
using BLL.Basic.User;
using BLL.Basic.Warehouse;
using BLL.Common;
using BLL.MaterialDocument;
using BLL.PrintBarcode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BLL.OutStock
{
    public class OutStock_DB
    {
        public bool CreateOutStokTask(OutStock_Model outStockModel, ref string strErrMsg)
        {
            return true;
        }

        /// <summary>
        /// 生成下架任务
        /// </summary>
        /// <param name="vouchcode"></param>
        /// <param name="vouchtype"></param>
        /// <param name="cwhcode"></param>
        /// <param name="userModel"></param>
        /// <param name="strTaskNo"></param>
        /// <param name="strErrMsg"></param>
        /// <returns></returns>
        public bool CreateUnShelveTask(string vouchcode, string vouchtype, string cwhcode, UserInfo userModel, ref string strTaskNo, ref string strErrMsg)
        {
            OutStock_Model osm = new OutStock_Model();

            WarehouseInfo whm = new WarehouseInfo();
            whm.WarehouseNo = cwhcode;
            Warehouse_Func wf = new Warehouse_Func();
            if (!wf.ExistsWarehouseNo(whm, false, userModel, ref strErrMsg))
                return false;
            wf.GetWarehouseByID(ref whm, userModel, ref strErrMsg);
            DataSet result = new DataSet();
            string sql;
            try
            {
                switch (vouchtype)
                {
                    case "-10"://红字成品入库单
                        {

                            //TODO:取单据表头
                            sql = string.Format("select cCode as MaterialDoc,CONVERT(varchar(100), dDate, 23) as MaterialDocDate,cast(cVouchType as int) as MaterialDocType from rdrecord10 where cCode='{0}'", vouchcode);
                            OperationSql.GetDatasetForU8(sql, out result, out strErrMsg);
                            if (!string.IsNullOrEmpty(strErrMsg))
                                return false;
                            List<MaterialDoc_Model> lstMaterialDoc = TOOL.DataTableToList.DataSetToList<MaterialDoc_Model>(result.Tables[0]);
                            if (lstMaterialDoc != null && lstMaterialDoc.Count > 0)
                                osm.materialDocModel = lstMaterialDoc[0];
                            osm = TOOL.DataTableToList.DataSetToList<OutStock_Model>(result.Tables[0])[0];
                            osm.IsOutStockPost = 1;
                            osm.IsUnderShelvePost = 0;
                            osm.VoucherType = 70;
                            //TODO:取单据表体
                            sql = string.Format(@"select rd.cCode as VoucherNo,rds.iRSRowNO RowNo,rds.cInvCode MaterialNo,i.cInvName MaterialDesc,i.cinvstd MaterialStd,
rds.iQuantity OutStockQty, rd.cWhCode StorageLoc
 from rdrecord10 rd
join rdrecords10 rds on rd.ID = rds.ID
join inventory i on rds.cInvCode = i.cInvCode
 where rd.cCode='{0}'", vouchcode);
                            OperationSql.GetDatasetForU8(sql, out result, out strErrMsg);
                            if (!string.IsNullOrEmpty(strErrMsg))
                                return false;
                            osm.lstOutStockDetails = TOOL.DataTableToList.DataSetToList<OutStockDetails_Model>(result.Tables[0]);
                        }
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
            #region 原先存储过程中定义的变量
            //           --------------------?? outstock ?? ----------------------------
            int out_id;
            string out_no;
            int out_isoutstockpost;
            int out_isundershelvepost;
            int out_vouchertype;
            string out_movetype;

            //           -------------------?? outstockdetails ?? -----------------------
            int outd_id;
            string outd_voucherno;
            string outd_rowno;
            string outd_materialno;
            string outd_materialdesc;
            string outd_materialstd;
            double outd_outstockqty;
            string outd_unit;
            //           ----------------?? task ?? ----------------------------------------
            int t_id;
            string t_taskno;

            //           ---------------?? taskdetails ?? -----------------------------------
            int td_id;
            //           ----------------userinfo---------------------------- -
            string useer_no = userModel.UserNo; ;
            int user_id = userModel.ID;
            //           -----------------?? materialdoc ?? ------------------------------
            int md_id;
            string md_doc;
            string md_docdate;
            DateTime md_postdate;
            int md_type;


            //           ----------------warehouse----------------------------
            int warehouse_id;
            int taskwarehouse_id;

            int rectrans_id;
            #endregion



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

            try
            {

                //-----------------------插入任务表头数据------------------------
                //设置要调用的存储过程的名称  
                cmd.CommandText = "P_GetNewSeqVal_SEQ_OUTSTOCK";
                //指定SqlCommand对象传给数据库的是存储过程的名称而不是sql语句  
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                //指定"@ID"为输出参数  
                cmd.Parameters[0].Direction = ParameterDirection.Output;
                //执行  
                cmd.ExecuteNonQuery();
                out_id = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                cmd.CommandText = "P_GetNewSeqVal_SEQ_TASK";
                cmd.ExecuteNonQuery();
                t_id = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                cmd.CommandText = "P_GetNewSeqVal_SEQ_TASKNO";
                cmd.ExecuteNonQuery();
                t_taskno = DateTime.Now.ToString("yyyyMMdd") + Convert.ToString(cmd.Parameters["@ID"].Value).PadLeft(4, '0');

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();

                out_no = osm.MaterialDoc;
                out_isoutstockpost = osm.IsOutStockPost;
                out_isundershelvepost = osm.IsUnderShelvePost;
                out_vouchertype = osm.VoucherType;
                out_movetype = osm.MoveType;

                //            --插入出库主表数据
                //insert into t_outstock(id, voucherno, vouchertype, customercode, customername, createdate, creater, isoutstockpost, isundershelvepost, plant, plantname, movetype)
                //values(ot_id, outStockRow.VoucherNo, outStockRow.VoucherType, outStockRow.CustomerCode, outStockRow.CustomerName, sysdate, strUserNo, outStockRow.IsOutStockPost,
                //outStockRow.IsUnderShelvePost, outStockRow.Plant, outStockRow.PlantName, outStockRow.Movetype);
                sql = string.Format(@"insert into t_outstock(id,voucherno,vouchertype,customercode,customername,createdate,creater,isoutstockpost,isundershelvepost,movetype)
    values({0},'{1}','{2}','{3}','{4}',getdate(),'{5}','{6}',
    '{7}','{8}'); ", out_id, out_no, out_vouchertype, "", "", useer_no, out_isoutstockpost, out_isundershelvepost, out_movetype);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                //           insert into t_task(id, vouchertype, tasktype, taskno, supcusname, taskstatus, createdatetime, supcusno,
                //createuserno, receive_id, deliveryno, isquality, isreceivepost, isshelvepost, plant, plantname, receiveuserno, taskissued, movetype)
                //values
                //(t_id, rec_vouchertype, '1', t_taskno, rec_suppliername, (case rec_isquality when 1 then 2 when 2 then 3 end),sysdate,rec_supplierno,struserno,
                //rec_id,rec_no,rec_isquality,rec_isreceivepost,rec_isshelvepost,rec_plant,rec_plantname,struserno,
                //(case rec_isquality when 1 then sysdate  end),rec_movetype);
                sql = string.Format(@"insert into t_task(id,vouchertype,tasktype,taskno,supcusname,taskstatus,createdatetime,supcusno,
     createuserno,receive_id,deliveryno,isquality,isreceivepost,isshelvepost,receiveuserno,taskissued,movetype)
     values
     ({0},{1},'2','{2}','{3}',{4},getdate(),'{5}','{6}',
     {7},'{8}',{9},{10},{11},'{12}',{13},'{14}');"
        , t_id, out_vouchertype, t_taskno, "", 2, "", useer_no,
                out_id, out_no, 1, out_isoutstockpost, out_isundershelvepost, useer_no, "getdate()", out_movetype);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                //--------------------插入物料凭证数据------------------------
                cmd.CommandText = "P_GetNewSeqVal_SEQ_MATERIALDOC";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                cmd.Parameters[0].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                md_id = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();

                //when 'MaterialDoc' then
                md_doc = osm.materialDocModel.MaterialDoc;
                //when 'MaterialDocDate' then
                md_docdate = osm.materialDocModel.MaterialDocDate;
                //when 'MaterialDocType' then
                md_type = osm.materialDocModel.MaterialDocType;

                sql = string.Format(@"insert into t_receivematerialdoc(id,receive_id,materialdoc,docdate,postdate,createdate,postuser,task_id,
         materialdoctype,taskdoctype)
         values({0},{1},'{2}','{3}',getdate(),getdate(),'{4}',{5},{6},1);", md_id, "null", md_doc, md_docdate, useer_no, t_id, md_type);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                //----------------------插入任务对应仓库数据-------------------------- -
                cmd.CommandText = "P_GetNewSeqVal_SEQ_TASKWAREHOUSE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                cmd.Parameters[0].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                taskwarehouse_id = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();

                //when 'ID' then
                warehouse_id = whm.ID;

                //         insert into t_taskwarehouse(id, task_id, warehouse_id, user_id)
                //values
                //(taskwarehouse_id, t_id, warehouse_id, struserid);
                sql = string.Format(@" insert into t_taskwarehouse (id,task_id,warehouse_id,user_id)
       values
       ({0},{1}, {2},{3} );", taskwarehouse_id, t_id, warehouse_id, user_id);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                //----------------------插入任务明细数据-------------------------- -
                foreach (var item in osm.lstOutStockDetails)
                {
                    cmd.CommandText = "P_GetNewSeqVal_SEQ_OUTSTOCKDETAILS";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                    cmd.Parameters[0].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    outd_id = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                    cmd.CommandText = "P_GETNEWSEQVAL_SEQ_TASKDETAILS";
                    cmd.ExecuteNonQuery();
                    td_id = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Clear();

                    //when 'VoucherNo' then
                    outd_voucherno = item.VoucherNo;
                    //when 'RowNo' then
                    outd_rowno = item.RowNo;
                    //when 'MaterialNo' then
                    outd_materialno = item.MaterialNo;
                    //when 'MaterialDesc' then
                    outd_materialdesc = item.MaterialDesc;
                    outd_materialstd = item.MaterialStd;

                    //when 'CurrentlyDeliveryNum' then
                    outd_outstockqty = item.OutStockQty;
                    //when 'Unit' then
                    outd_unit = item.Unit;

                    sql = string.Format(@"insert into t_outstockdetails(id,outstock_id,voucherno,materialno,materialdesc,rowno,unit,
    outstockqty,oldoutstockqty ) values   
    ( {0},{1},'{2}','{3}','{4}','{5}','{6}',{7},{7})",
outd_id, out_id, outd_voucherno, outd_materialno, outd_materialdesc, outd_rowno, outd_unit, outd_outstockqty);
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    sql = string.Format(@"insert into t_taskdetails(id,materialno,materialdesc,materialstd,taskqty,
                    qualityqty,remainqty,shelveqty,status,isqualitycomp,task_id,
                    packcount,shelvepackcount,voucherno,rowno,createdate)
                    values
                    (  {0},'{1}','{2}','{3}',
                    {4},0,{4},0,1,1,{5},
                    0,0,{6},'{7}',getdate());",
     td_id, outd_materialno, outd_materialdesc, outd_materialstd, outd_outstockqty,
     t_id, outd_voucherno, outd_rowno);
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
                conn.Dispose();
                conn.Close();
            }

        }


        public Barcode_Model GetBarCodeInfo(string strSerialNo, string labeltype)
        {
            try
            {
                string strSql = string.Format("select a.supcode,a.supname,a.ID,VOUCHERTYPE,DELIVERYNO,VOUCHERNO,ROWNO,a.QTY, OUTPACKQTY,a.BARCODE,BARCODETYPE,a.SERIALNO,a.MATERIALNO,a.MATERIALDESC,a.MATERIALSTD,a.BATCHNO,ROWNO,TrayID,ISNULL(iFlag,0) iFlag,[ProductLineNo] cProductLineCode,SoCode,areano,ArrivalCode from t_outbarcode a left join T_STOCK b on a.serialno=b.serialno where a.serialno = '{0}'", strSerialNo);
                Barcode_Model barcodeMdl = new Barcode_Model();
                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    if (dr.Read())
                    {
                        barcodeMdl.ID = dr["id"].ToDecimal();
                        barcodeMdl.DELIVERYNO = dr["DELIVERYNO"].ToDBString();
                        barcodeMdl.VOUCHERNO = dr["VOUCHERNO"].ToDBString();
                        barcodeMdl.ROWNO = dr["ROWNO"].ToDBString();
                        barcodeMdl.OUTPACKQTY = dr["OUTPACKQTY"].ToDecimal();
                        barcodeMdl.labeltype = dr["BARCODETYPE"].ToDBString();
                        barcodeMdl.QTY = dr["QTY"].ToDecimal();
                        barcodeMdl.BARCODE = dr["barcode"].ToDBString();
                        barcodeMdl.SERIALNO = dr["serialno"].ToDBString();
                        barcodeMdl.MATERIALNO = dr["materialno"].ToDBString();
                        barcodeMdl.MATERIALDESC = dr["materialdesc"].ToDBString();
                        barcodeMdl.MATERIALSTD = dr["materialstd"].ToDBString();//规格型号
                        barcodeMdl.BATCHNO = dr["batchno"].ToDBString();
                        //barcodeMdl.ROWNO = dr["rowno"].ToDBString();
                        barcodeMdl.VOUCHERTYPE = dr["VOUCHERTYPE"].ToDBString();
                        barcodeMdl.TrayID = dr["TrayID"].ToInt32();
                        barcodeMdl.iFlag = dr["iFlag"].ToInt32();
                        barcodeMdl.cProductLineCode = dr["cProductLineCode"].ToDBString();//产线
                        barcodeMdl.SoCode = dr["SoCode"].ToDBString();
                        barcodeMdl.AreaNo = dr["AreaNo"].ToDBString();
                        barcodeMdl.ArrivalCode = dr["ArrivalCode"].ToDBString();
                        barcodeMdl.SUPCODE = dr["SUPCODE"].ToDBString();
                        barcodeMdl.SUPNAME = dr["SUPNAME"].ToDBString();

                    }
                }

                if (string.IsNullOrEmpty(barcodeMdl.SERIALNO))
                {
                    strSql = string.Format("select top 1 b.serialno OUTBARCODENO,a.ID,b.VOUCHERTYPE,b.DELIVERYNO,a.VOUCHERNO,a.QTY, a.OUTPACKQTY,a.BARCODE,a.BARCODETYPE,a.SERIALNO,a.MATERIALNO,a.MATERIALDESC,a.MATERIALSTD,a.BATCHNO,b.ROWNO,0 TrayID,ISNULL(iFlag,0) iFlag,[ProductLineNo] cProductLineCode,a.SoCode,c.AreaNo from T_INNERBARCODE a join T_OUTBARCODE b on a.outbox_id=b.id left join T_STOCK c on b.serialno=c.serialno where a.serialno = '{0}'", strSerialNo);
                    using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                    {
                        if (dr.Read())
                        {
                            barcodeMdl.ID = dr["id"].ToDecimal();
                            barcodeMdl.DELIVERYNO = dr["DELIVERYNO"].ToDBString();
                            barcodeMdl.VOUCHERNO = dr["VOUCHERNO"].ToDBString();
                            barcodeMdl.ROWNO = dr["ROWNO"].ToDBString();
                            barcodeMdl.OUTPACKQTY = dr["OUTPACKQTY"].ToDecimal();
                            barcodeMdl.labeltype = dr["BARCODETYPE"].ToDBString();
                            barcodeMdl.QTY = dr["QTY"].ToDecimal();
                            barcodeMdl.BARCODE = dr["barcode"].ToDBString();
                            barcodeMdl.SERIALNO = dr["serialno"].ToDBString();
                            barcodeMdl.MATERIALNO = dr["materialno"].ToDBString();
                            barcodeMdl.MATERIALDESC = dr["materialdesc"].ToDBString();
                            barcodeMdl.MATERIALSTD = dr["materialstd"].ToDBString();//规格型号
                            barcodeMdl.BATCHNO = dr["batchno"].ToDBString();
                            //barcodeMdl.ROWNO = dr["rowno"].ToDBString();
                            barcodeMdl.VOUCHERTYPE = dr["VOUCHERTYPE"].ToDBString();
                            barcodeMdl.TrayID = dr["TrayID"].ToInt32();
                            barcodeMdl.iFlag = dr["iFlag"].ToInt32();
                            barcodeMdl.cProductLineCode = dr["cProductLineCode"].ToDBString();//产线
                            barcodeMdl.SoCode = dr["SoCode"].ToDBString();
                            barcodeMdl.OUTBARCODENO = dr["OUTBARCODENO"].ToDBString();
                            barcodeMdl.AreaNo = dr["AreaNo"].ToDBString();



                        }
                    }
                    if (string.IsNullOrEmpty(barcodeMdl.SERIALNO))
                        return null;
                    else
                    {
                        if (!string.IsNullOrEmpty(labeltype) && !labeltype.Equals("10") && !labeltype.Equals("14"))
                        {
                            throw new Exception("本次扫描必须都为外箱条码！");
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(labeltype) && !labeltype.Equals("11") && !labeltype.Equals("15"))
                    {
                        throw new Exception("本次扫描必须都为内盒条码！");
                    }
                }
                //strSql = string.Format("select ISNULL(ordercode,'') socode,ISNULL(orderseq,'') sorowno from v_st_mom_orderdetail where mocode = '{0}' and MoSeq='{1}'", barcodeMdl.VOUCHERNO, barcodeMdl.ROWNO);
                //using (SqlDataReader dr = OperationSql.ExecuteReaderForU8(System.Data.CommandType.Text, strSql))
                //{
                //    if (dr.Read())
                //    {
                //        barcodeMdl.SoCode = dr["socode"].ToDBString();
                //        barcodeMdl.sorowno = dr["sorowno"].ToDBString();
                //    }
                //}
                //barcodeMdl.SoCode = "";
                barcodeMdl.sorowno = "";
                if (barcodeMdl.TrayID != 0)
                {
                    Tray_Func tf = new Tray_Func();
                    Tray_Model tray = new Tray_Model();
                    if (tf.GetTrayInfoByTrayIDForOutStock(barcodeMdl, ref tray))
                        barcodeMdl.tray_Model = tray;
                }
                return barcodeMdl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Barcode_Model GetBarCodeInfoForReturn(string strSerialNo, string labeltype)
        {
            try
            {
                string strSql = string.Format("select ID,VOUCHERTYPE,DELIVERYNO,VOUCHERNO,ROWNO,QTY, OUTPACKQTY,BARCODE,BARCODETYPE,SERIALNO,MATERIALNO,MATERIALDESC,MATERIALSTD,BATCHNO,ROWNO,TrayID,ISNULL(iFlag,0) iFlag,[ProductLineNo] cProductLineCode,SoCode from t_outbarcode where serialno = '{0}'", strSerialNo);
                Barcode_Model barcodeMdl = new Barcode_Model();
                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    if (dr.Read())
                    {
                        barcodeMdl.ID = dr["id"].ToDecimal();
                        barcodeMdl.DELIVERYNO = dr["DELIVERYNO"].ToDBString();
                        barcodeMdl.VOUCHERNO = dr["VOUCHERNO"].ToDBString();
                        barcodeMdl.ROWNO = dr["ROWNO"].ToDBString();
                        barcodeMdl.OUTPACKQTY = dr["OUTPACKQTY"].ToDecimal();
                        barcodeMdl.labeltype = dr["BARCODETYPE"].ToDBString();
                        barcodeMdl.QTY = dr["QTY"].ToDecimal();
                        barcodeMdl.BARCODE = dr["barcode"].ToDBString();
                        barcodeMdl.SERIALNO = dr["serialno"].ToDBString();
                        barcodeMdl.MATERIALNO = dr["materialno"].ToDBString();
                        barcodeMdl.MATERIALDESC = dr["materialdesc"].ToDBString();
                        barcodeMdl.MATERIALSTD = dr["materialstd"].ToDBString();//规格型号
                        barcodeMdl.BATCHNO = dr["batchno"].ToDBString();
                        barcodeMdl.ROWNO = dr["rowno"].ToDBString();
                        barcodeMdl.VOUCHERTYPE = dr["VOUCHERTYPE"].ToDBString();
                        barcodeMdl.TrayID = dr["TrayID"].ToInt32();
                        barcodeMdl.iFlag = dr["iFlag"].ToInt32();
                        barcodeMdl.cProductLineCode = dr["cProductLineCode"].ToDBString();//产线
                        barcodeMdl.SoCode = dr["SoCode"].ToDBString();
                    }
                }

                if (string.IsNullOrEmpty(barcodeMdl.SERIALNO))
                {
                    strSql = string.Format("  select a.ID,b.VOUCHERTYPE,b.DELIVERYNO,a.VOUCHERNO,a.QTY, a.OUTPACKQTY,a.BARCODE,a.BARCODETYPE,a.SERIALNO,a.MATERIALNO,a.MATERIALDESC,a.MATERIALSTD,a.BATCHNO,b.ROWNO,0 TrayID,ISNULL(iFlag,0) iFlag,[ProductLineNo] cProductLineCode,a.SoCode from T_INNERBARCODE a join T_OUTBARCODE b on a.outbox_id=b.id where a.serialno = '{0}'", strSerialNo);
                    using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                    {
                        if (dr.Read())
                        {
                            barcodeMdl.ID = dr["id"].ToDecimal();
                            barcodeMdl.DELIVERYNO = dr["DELIVERYNO"].ToDBString();
                            barcodeMdl.VOUCHERNO = dr["VOUCHERNO"].ToDBString();
                            barcodeMdl.ROWNO = dr["ROWNO"].ToDBString();
                            barcodeMdl.OUTPACKQTY = dr["OUTPACKQTY"].ToDecimal();
                            barcodeMdl.labeltype = dr["BARCODETYPE"].ToDBString();
                            barcodeMdl.QTY = dr["QTY"].ToDecimal();
                            barcodeMdl.BARCODE = dr["barcode"].ToDBString();
                            barcodeMdl.SERIALNO = dr["serialno"].ToDBString();
                            barcodeMdl.MATERIALNO = dr["materialno"].ToDBString();
                            barcodeMdl.MATERIALDESC = dr["materialdesc"].ToDBString();
                            barcodeMdl.MATERIALSTD = dr["materialstd"].ToDBString();//规格型号
                            barcodeMdl.BATCHNO = dr["batchno"].ToDBString();
                            barcodeMdl.ROWNO = dr["rowno"].ToDBString();
                            barcodeMdl.VOUCHERTYPE = dr["VOUCHERTYPE"].ToDBString();
                            barcodeMdl.TrayID = dr["TrayID"].ToInt32();
                            barcodeMdl.iFlag = dr["iFlag"].ToInt32();
                            barcodeMdl.cProductLineCode = dr["cProductLineCode"].ToDBString();//产线
                            barcodeMdl.SoCode = dr["SoCode"].ToDBString();
                        }
                    }
                    if (string.IsNullOrEmpty(barcodeMdl.SERIALNO))
                        return null;
                    else
                    {
                        if (!string.IsNullOrEmpty(labeltype) && !labeltype.Equals("10") && !labeltype.Equals("14"))
                        {
                            throw new Exception("本次扫描必须都为外箱条码！");
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(labeltype) && !labeltype.Equals("11") && !labeltype.Equals("15"))
                    {
                        throw new Exception("本次扫描必须都为内盒条码！");
                    }
                }
                //strSql = string.Format("select ISNULL(orderseq,'') sorowno,ISNULL(ordercode,'') socode from v_st_mom_orderdetail where mocode = '{0}' and MoSeq={1}", barcodeMdl.VOUCHERNO, barcodeMdl.ROWNO);
                //using (SqlDataReader dr = OperationSql.ExecuteReaderForU8(System.Data.CommandType.Text, strSql))
                //{
                //    if (dr.Read())
                //    {
                //        if (!string.IsNullOrEmpty(dr["socode"].ToDBString()))
                //            barcodeMdl.SoCode = dr["socode"].ToDBString();
                //        barcodeMdl.sorowno = dr["sorowno"].ToDBString();
                //    }
                //}
                strSql = string.Format("select 1 from t_stockoutdetails where serialno='{0}'", barcodeMdl.SERIALNO);
                object oResult = OperationSql.ExecuteScalar(CommandType.Text, strSql);
                if (oResult == null || oResult == DBNull.Value)
                {
                    strSql = string.Format("select a.serialno from t_stockoutdetails a join T_INNERBARCODE b on a.serialno=b.serialno  where b.serialno='{0}'", barcodeMdl.SERIALNO);
                    oResult = OperationSql.ExecuteScalar(CommandType.Text, strSql);
                    if (barcodeMdl.iFlag != 4 || oResult == null || oResult == DBNull.Value)
                    {
                        barcodeMdl = null;
                        throw new Exception("该条码并未出库！");
                    }
                    else if (!char.IsLetter(oResult.ToString().Last()))
                    {
                        barcodeMdl = null;
                        throw new Exception("违规操作，该条码是按外箱出库的，不能还回内箱！");
                    }
                    else
                    {
                        strSql = string.Format(@"select a.areano from T_STOCK a join T_OUTBARCODE b on a.serialno=b.serialno
join T_SplitRecord c on c.old_outboxid = b.id
join T_SplitDetails d on c.id = d.id
where d.serialno = '{0}' order by c.createrdate desc", barcodeMdl.SERIALNO);
                        oResult = OperationSql.ExecuteScalar(CommandType.Text, strSql);
                        barcodeMdl.AndalaNo = oResult.ToString();
                    }
                }
                else
                {
                    if (barcodeMdl.iFlag != 4)
                    {
                        barcodeMdl = null;
                        throw new Exception("该条码并未出库！");
                    }
                }


                if (barcodeMdl.TrayID != 0)
                {
                    Tray_Func tf = new Tray_Func();
                    Tray_Model tray = new Tray_Model();
                    if (tf.GetTrayInfoByTrayIDForOutStock(barcodeMdl, ref tray))
                        barcodeMdl.tray_Model = tray;
                }

                return barcodeMdl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }
}
