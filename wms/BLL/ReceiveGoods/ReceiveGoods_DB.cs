using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BLL.PrintBarcode;
using BLL.Basic.User;
using BLL.DeliveryReceive;
using BLL.Common;
using BLL.Basic.Warehouse;
using BLL.MaterialDocument;
using BLL.Basic.Area;
using System.Text.RegularExpressions;

namespace BLL.ReceiveGoods
{
    public class ReceiveGoods_DB
    {
        public Barcode_Model GetBarCodeInfo(string strSerialNo)
        {
            try
            {
                string strSql = string.Format("select supcode,SUPNAME,ID,VOUCHERTYPE,DELIVERYNO,VOUCHERNO,ROWNO,QTY, OUTPACKQTY,BARCODE,BARCODETYPE,SERIALNO,MATERIALNO,MATERIALDESC,MATERIALSTD,BATCHNO,ROWNO,TrayID,ISNULL(iFlag,0) iFlag,[ProductLineNo] cProductLineCode,SoCode,ArrivalCode from t_outbarcode where serialno = '{0}'", strSerialNo);
                Barcode_Model barcodeMdl = new Barcode_Model();
                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    if (dr.Read())
                    {
                        barcodeMdl.ID = dr["id"].ToDecimal();
                        barcodeMdl.DELIVERYNO = dr["DELIVERYNO"].ToDBString();
                        barcodeMdl.VOUCHERNO = dr["VOUCHERNO"].ToDBString();
                        barcodeMdl.ROWNO= dr["ROWNO"].ToDBString();
                        barcodeMdl.OUTPACKQTY = dr["OUTPACKQTY"].ToDecimal();
                        barcodeMdl.labeltype= dr["BARCODETYPE"].ToDBString();
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
                        barcodeMdl.iFlag= dr["iFlag"].ToInt32();
                        barcodeMdl.cProductLineCode= dr["cProductLineCode"].ToDBString();//产线
                        barcodeMdl.SoCode= dr["SoCode"].ToDBString();
                        barcodeMdl.ArrivalCode = dr["ArrivalCode"].ToDBString();
                        barcodeMdl.SUPCODE = dr["SUPCODE"].ToDBString();
                        barcodeMdl.SUPNAME = dr["SUPNAME"].ToDBString();


                    }
                }
                
                if (barcodeMdl.TrayID != 0)
                {
                    Tray_Func tf = new Tray_Func();
                    Tray_Model tray = new Tray_Model();
                    if (tf.GetTrayInfoByTrayID(barcodeMdl, ref tray))
                        barcodeMdl.tray_Model = tray;
                }
                return barcodeMdl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetArrivalRowNo(Barcode_Model model)
        {
            string strSql = string.Format(@"select a.ivouchrowno from pu_arrbody a
 join pu_ArrHead b on a.id = b.id
 join copypolist c on a.iposid = c.id
 where c.cordercode = '{0}' and c.ivouchrowno = '{1}' and b.ccode = '{2}'", model.VOUCHERNO,model.ROWNO,model.ArrivalCode);
            return OperationSql.ExecuteScalarForU8(CommandType.Text, strSql, null).ToInt32();
        }

        internal bool IsChecking(Barcode_Model barcodeMdl, ref string strErrorMsg)
        {
            string strSql = "";
            if (barcodeMdl.iFlag != 0&&barcodeMdl.iFlag!=10)
            {
                if(barcodeMdl.labeltype.Equals("10")|| barcodeMdl.labeltype.Equals("14"))
                {
                    strSql = string.Format("select a.serialno from T_OUTBARCODE a join T_INNERBARCODE b on a.id=b.outbox_id where b.serialno = '{0}'", barcodeMdl.SERIALNO);
                    string oSerialno = OperationSql.ExecuteScalar(CommandType.Text, strSql, null).ToDBString();
                    if (string.IsNullOrEmpty(oSerialno))
                        return false;
                    barcodeMdl.SERIALNO = oSerialno;
                }
                strSql = string.Format("select b.areastatus,b.CheckID [ACheckID],a.status,a.CheckID [SCheckID] from t_stock a join T_AREA b on a.areano=b.areano where serialno='{0}'", barcodeMdl.SERIALNO);
                using (SqlDataReader sdr = OperationSql.ExecuteReader(CommandType.Text, strSql, null))
                {
                    if (sdr.Read())
                    {
                        if (sdr[0].ToInt32() != 1 && !string.IsNullOrEmpty(sdr[1].ToString()))
                        {
                            strErrorMsg = "该条码所在货位正在盘点！";
                            return true;
                        }
                        if (sdr[2].ToInt32() != 1 && !string.IsNullOrEmpty(sdr[3].ToString()))
                        {
                            strErrorMsg = "该物料正在盘点！";
                            return true;
                        }
                    }
                    else
                    {
                        if (barcodeMdl.iFlag != 4 && barcodeMdl.iFlag != 5)
                        {
                            strErrorMsg = "该条码库存有误！";
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool CreateReceiveAndShelveTask(string strReceiveGoodsXml, string strUserWareHouseXml, UserInfo userModel, ref string strTaskNo, ref string strErrMsg)
        {
            try
            {
                int iResult = 0;

                SqlParameter[] cmdParms = new SqlParameter[]
            {
                new SqlParameter("deliveryinfo_xml", SqlDbType.Image),
                new SqlParameter("strUserWareHouseXml", SqlDbType.Image),
                new SqlParameter("struserno", SqlDbType.NVarChar),
                new SqlParameter("struserid", SqlDbType.NVarChar),
                //new SqlParameter("strtaskno", SqlDbType.NVarChar,100,strTaskNo,ParameterDirection.Output),
                new SqlParameter("strtaskno", SqlDbType.NVarChar,100,strTaskNo),

                //new SqlParameter("bresult", SqlDbType.Int,ParameterDirection.Output),
                new SqlParameter("bresult", SqlDbType.Int),

                //new SqlParameter("strerrmsg", SqlDbType.NVarChar,100,strErrMsg,ParameterDirection.Output)
                new SqlParameter("strerrmsg", SqlDbType.NVarChar,100,strErrMsg)

            };

                cmdParms[0].Value = strReceiveGoodsXml;
                cmdParms[1].Value = strUserWareHouseXml;
                cmdParms[2].Value = userModel.UserNo;
                cmdParms[3].Value = userModel.ID;


                OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "p_receivecreateshelvetask", cmdParms);
                iResult = Convert.ToInt32(cmdParms[5].Value.ToString());
                strTaskNo = cmdParms[4].Value.ToString();
                strErrMsg = cmdParms[6].Value.ToString();

                return iResult == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 创建上架任务
        /// </summary>
        /// <param name="vouchcode"></param>
        /// <param name="vouchtype"></param>
        /// <param name="userModel"></param>
        /// <param name="strTaskNo"></param>
        /// <param name="strErrMsg"></param>
        /// <returns></returns>
        public bool CreateShelveTask(string vouchcode, string vouchtype,string cwhcode, UserInfo userModel, ref string strTaskNo, ref string strErrMsg)
        {
            DeliveryReceive_Model drm = new DeliveryReceive_Model();

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
                    case "08"://其他入库单
                        {
                            
                            //TODO:取其他入库单表头
                            sql = string.Format("select cCode as MaterialDoc,CONVERT(varchar(100), dDate, 23) as MaterialDocDate,cast(cVouchType as int) as MaterialDocType from rdrecord08 where cCode='{0}'", vouchcode);
                            OperationSql.GetDatasetForU8(sql, out result, out strErrMsg);
                            if (!string.IsNullOrEmpty(strErrMsg))
                                return false;
                            drm.lstMaterialDoc = TOOL.DataTableToList.DataSetToList<MaterialDoc_Model>(result.Tables[0]);
                            if (drm.lstMaterialDoc != null && drm.lstMaterialDoc.Count > 0)
                                drm.materialDocModel = drm.lstMaterialDoc[0];
                            drm.DeliveryNo = drm.materialDocModel.MaterialDoc;
                            drm.IsQuality = 1;//成品不走质检流程，直接赋已质检
                            drm.VoucherType = 40;
                            //TODO:取其他入库单表体
                            sql = string.Format(@"select rd.cCode as VoucherNo,rds.irowno RowNo,rds.cInvCode MaterialNo,i.cInvName MaterialDesc,i.cinvstd MaterialStd,
rds.iQuantity ReceiveQty, rd.cWhCode StorageLoc
 from rdrecord08 rd
join rdrecords08 rds on rd.ID = rds.ID
join inventory i on rds.cInvCode = i.cInvCode
 where rd.cCode='{0}'", vouchcode);
                            OperationSql.GetDatasetForU8(sql, out result, out strErrMsg);
                            if (!string.IsNullOrEmpty(strErrMsg))
                                return false;
                            drm.lstDeliveryDetail = TOOL.DataTableToList.DataSetToList<DeliveryReceiveDetail_Model>(result.Tables[0]);


                        }
                        break;
                }
            }
            catch (Exception) 
            {

                throw;
            }
            #region 原先存储过程中定义的变量
            //           --------------------?? delivery ?? ----------------------------
            int rec_id;
            string rec_no;
            string rec_supplierno;
            string rec_suppliername;
            int rec_isquality;
            int rec_isreceivepost;
            int rec_isshelvepost;
            int rec_vouchertype;
            string rec_plant;
            string rec_plantname;
            string rec_movetype;

            //           -------------------?? delivetydetails ?? -----------------------
            int recd_id;
            string recd_voucherno;
            string recd_rowno;
            string recd_materialno;
            string recd_materialdesc;
            string recd_materialstd;
            double recd_deliveryqty;
            double recd_receiveqty;
            string recd_unit;
            int recd_packcount;
            string recd_storageloc;
            string recd_plant;
            string recd_plantname;
            string recd_workcode;
            string recd_prdversion;
            int recd_isurgent;
            string recd_deliveryaddress;
            string recd_jingxinname;
            string recd_prdreturnreason;
            string recd_trackno;
            string recd_reservenumber;
            string recd_reserverowno;
            //           -----------------?? materialdoc ?? ------------------------------
            int md_id;
            string md_doc;
            string md_docdate;
            DateTime md_postdate;
            int md_type;

            //           ----------------?? task ?? ----------------------------------------
            int t_id;
            int t_vouchertypr;
            int t_tasktype;
            string t_taskno;
            string t_supcusname;
            int t_status;
            string t_supcusno;
            int t_ispost;

            //           ---------------?? taskdetails ?? -----------------------------------
            int td_id;
            int td_taskid;
            string td_toareano;
            string td_materialno;
            string td_materialdesc;
            double td_taskqty;
            double td_qualityqty;
            double td_remainqty;
            double td_shelveqty;
            int td_status;
            double td_isqualitycomp;
            double td_tmaterialno;
            string td_tmaterialdesc;
            double td_reviewqty;
            double td_packqty;
            double td_shelvepackqty;
            string td_barcode;
            string td_serialno;
            string td_sn = "";
            //           ----------------userinfo---------------------------- -
            string useer_no = userModel.UserNo; ;
            int user_id = userModel.ID;


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


                //-----------------------插入收货表头，任务表头数据------------------------

                //设置要调用的存储过程的名称  
                //cmd.CommandText = "P_GetNewSeqVal_SEQ_RECEIVE";
                //指定SqlCommand对象传给数据库的是存储过程的名称而不是sql语句  
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                //指定"@ID"为输出参数  
                cmd.Parameters[0].Direction = ParameterDirection.Output;
                ////执行  
                //cmd.ExecuteNonQuery();
                //rec_id = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                cmd.CommandText = "P_GetNewSeqVal_SEQ_TASK";
                cmd.ExecuteNonQuery();
                t_id = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                cmd.CommandText = "P_GetNewSeqVal_SEQ_TASKNO";
                cmd.ExecuteNonQuery();
                t_taskno = DateTime.Now.ToString("yyyyMMdd") + Convert.ToString(cmd.Parameters["@ID"].Value).PadLeft(4, '0');

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();

                //     when 'DeliveryNo' then
                rec_no = drm.DeliveryNo;
                //     when 'SupCode' then
                rec_supplierno = drm.SupCode;
                //     when 'SupName' then
                rec_suppliername = drm.SupName;
                //     when 'IsQuality' then
                rec_isquality = drm.IsQuality;
                //     when 'IsReceivePost' then
                rec_isreceivepost = drm.IsReceivePost;
                //     when 'IsShelvePost' then
                rec_isshelvepost = drm.IsShelvePost;
                //     when 'VoucherType' then
                rec_vouchertype = drm.VoucherType;
                //     when 'Plant' then
                rec_plant = drm.Plant;
                //     when 'PlantName' then
                rec_plantname = drm.PlantName;
                //     when 'MoveType' then
                rec_movetype = drm.MoveType;

                //           insert into t_receive(id, deliveryno, supplierno, suppliername, creater, createdate,
                //plant, plantname, isquality, isreceivepost, isshelvepost, vouchertype, movetype)
                //values
                //(rec_id, rec_no, rec_supplierno, rec_suppliername, struserno, sysdate, rec_plant, rec_plantname,
                //rec_isquality, rec_isreceivepost, rec_isshelvepost, rec_vouchertype, rec_movetype);
     //           sql = string.Format(@"insert into t_receive(id,deliveryno,supplierno,suppliername,creater,createdate,
     //plant,plantname,isquality,isreceivepost,isshelvepost,vouchertype,movetype) values
     //({0}, '{1}', '{2}', '{3}', '{4}', getdate(), '{5}', '{6}',{7}, {8}, {9}, {10}, '{11}'); ", rec_id, rec_no, rec_supplierno, rec_suppliername, useer_no, rec_plant, rec_plantname,
     //rec_isquality, rec_isreceivepost, rec_isshelvepost, rec_vouchertype, rec_movetype);
     //           cmd.CommandText = sql;
     //           cmd.ExecuteNonQuery();

                //           insert into t_task(id, vouchertype, tasktype, taskno, supcusname, taskstatus, createdatetime, supcusno,
                //createuserno, receive_id, deliveryno, isquality, isreceivepost, isshelvepost, plant, plantname, receiveuserno, taskissued, movetype)
                //values
                //(t_id, rec_vouchertype, '1', t_taskno, rec_suppliername, (case rec_isquality when 1 then 2 when 2 then 3 end),sysdate,rec_supplierno,struserno,
                //rec_id,rec_no,rec_isquality,rec_isreceivepost,rec_isshelvepost,rec_plant,rec_plantname,struserno,
                //(case rec_isquality when 1 then sysdate  end),rec_movetype);
                sql = string.Format(@"insert into t_task(id,vouchertype,tasktype,taskno,supcusname,taskstatus,createdatetime,supcusno,
     createuserno,receive_id,deliveryno,isquality,isreceivepost,isshelvepost,plant,plantname,receiveuserno,taskissued,movetype)
     values
     ({0},{1},'1','{2}','{3}',{4},getdate(),'{5}','{6}',
     {7},'{8}',{9},{10},{11},'{12}','{13}','{14}',{15},'{16}');"
        , t_id, rec_vouchertype, t_taskno, rec_suppliername, rec_isquality == 1 ? 2 : 3, rec_supplierno, useer_no,
                "null", rec_no, rec_isquality, rec_isreceivepost, rec_isshelvepost, rec_plant, rec_plantname, useer_no, rec_isquality == 1 ? "getdate()" : "null", rec_movetype);
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
                md_doc = drm.materialDocModel.MaterialDoc;
                //when 'MaterialDocDate' then
                md_docdate = drm.materialDocModel.MaterialDocDate;
                //when 'MaterialDocType' then
                md_type = drm.materialDocModel.MaterialDocType;

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
                foreach (var item in drm.lstDeliveryDetail)
                {
                    //cmd.CommandText = "P_GetNewSeqVal_SEQ_RECEIVEDETAILS";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                    cmd.Parameters[0].Direction = ParameterDirection.Output;
                    //cmd.ExecuteNonQuery();
                    //recd_id = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                    cmd.CommandText = "P_GETNEWSEQVAL_SEQ_TASKDETAILS";
                    cmd.ExecuteNonQuery();
                    td_id = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                    //cmd.CommandText = "P_GETNEWSEQVAL_SEQ_RECTRANS";
                    //cmd.ExecuteNonQuery();
                    //rectrans_id = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Clear();

                    //when 'VoucherNo' then
                    recd_voucherno = item.VoucherNo;
                    //when 'RowNo' then
                    recd_rowno = item.RowNo;
                    //when 'MaterialNo' then
                    recd_materialno = item.MaterialNo;
                    //when 'MaterialDesc' then
                    recd_materialdesc = item.MaterialDesc;
                    recd_materialstd = item.MaterialStd;

                    //when 'CurrentlyDeliveryNum' then
                    recd_deliveryqty = item.CurrentlyDeliveryNum;
                    //when 'ReceiveQty' then
                    recd_receiveqty = (double)item.ReceiveQty;
                    //when 'Unit' then
                    recd_unit = item.Unit;
                    //when 'PackCount' then
                    recd_packcount = item.PackCount;
                    //when 'StorageLoc' then
                    recd_storageloc = item.StorageLoc;
                    //when 'Plant' then
                    recd_plant = item.Plant;
                    //when 'PlantName' then
                    recd_plantname = item.PlantName;
                    //when 'WorkCode' then
                    recd_workcode = item.WorkCode;
                    //when 'PrdVersion' then
                    recd_prdversion = item.PrdVersion;
                    //when 'IsUrgent' then
                    recd_isurgent = item.IsUrgent;
                    //when 'DeliveryAddress' then
                    recd_deliveryaddress = item.DeliveryAddress;
                    //when 'JingxinName' then
                    recd_jingxinname = item.JingxinName;
                    //when 'PrdReturnReason' then
                    recd_prdreturnreason = item.PrdReturnReason;
                    //when 'Barcode' then
                    td_barcode = item.Barcode;
                    //when 'SerialNo' then
                    td_serialno = item.SerialNo;
                    //when 'TrackNo' then
                    recd_trackno = item.TrackNo;
                    //when 'ReserveNumber' then
                    recd_reservenumber = item.ReserveNumber;
                    //when 'ReserveRowNo' then
                    recd_reserverowno = item.ReserveRowNo;

                    //               insert into t_receivedetails(id, receive_id, voucherno, rowno, materialno, materialdesc, deliveryqty, receiveqty, unit,
                    //createdate, packcount, storageloc, plant, plantname, workcode, prdversion, isurgent, deliveryaddress, customername, trackno, reservenumber, reserverowno)
                    //values
                    //(recd_id, rec_id, recd_voucherno, recd_rowno, recd_materialno, recd_materialdesc, recd_deliveryqty, recd_receiveqty, recd_unit,
                    //sysdate, recd_packcount, recd_storageloc, recd_plant, recd_plantname, recd_workcode,
                    //recd_prdversion, recd_isurgent, recd_deliveryaddress, recd_jingxinname, recd_trackno, recd_reservenumber, recd_reserverowno);
                    //                    sql = string.Format(@"insert into t_receivedetails(id,receive_id,voucherno,rowno,materialno,materialdesc,deliveryqty,receiveqty,unit,
                    //     createdate,packcount,storageloc,plant,plantname,workcode,prdversion,isurgent,deliveryaddress,customername,trackno,reservenumber,reserverowno)
                    //     values
                    //     ({0},{1},'{2}','{3}','{4}','{5}',{6},{7},'{8}',
                    //     getdate(),{9},'{10}','{11}','{12}','{13}',
                    //     '{14}',{15},'{16}','{17}','{18}','{19}','{20}');",
                    //recd_id, rec_id, recd_voucherno, recd_rowno, recd_materialno, recd_materialdesc, recd_deliveryqty, recd_receiveqty, recd_unit,
                    //      recd_packcount, recd_storageloc, recd_plant, recd_plantname, recd_workcode,
                    //     recd_prdversion, recd_isurgent, recd_deliveryaddress, recd_jingxinname, recd_trackno, recd_reservenumber, recd_reserverowno);
                    //                    cmd.CommandText = sql;
                    //                    cmd.ExecuteNonQuery();

                    //               insert into t_taskdetails(id, toareano, materialno, materialdesc, taskqty, qualityqty, remainqty, shelveqty, status, isqualitycomp, task_id,
                    //packcount, shelvepackcount, voucherno, rowno, createdate, trackno, reservenumber, reserverowno)
                    //values
                    //(td_id, '', recd_materialno, recd_materialdesc, recd_receiveqty, 0,
                    //(case rec_isquality when 1 then recd_receiveqty when 2 then 0 end),0,1,rec_isquality,t_id,recd_packcount,0,
                    //recd_voucherno,recd_rowno,sysdate,recd_trackno,recd_reservenumber ,recd_reserverowno  );
                    sql = string.Format(@"insert into t_taskdetails(id,toareano,materialno,materialdesc,materialstd,taskqty,
     qualityqty,remainqty,shelveqty,status,isqualitycomp,task_id,
     packcount,shelvepackcount,voucherno,rowno,createdate,trackno,reservenumber,reserverowno)
     values
     (  {0},'','{1}','{2}','{3}',
     {4},{5},{4},0,1,{6},{7},
     0,{8},'{9}',null,getdate(),'{10}','{11}' ,'{12}');",
     td_id, recd_materialno, recd_materialdesc,recd_materialstd, recd_receiveqty,
     rec_isquality == 1 ? recd_receiveqty : 0, rec_isquality, t_id, recd_packcount,
     recd_voucherno, recd_trackno, recd_reservenumber, recd_reserverowno);
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    //if (!string.IsNullOrEmpty(td_serialno))
                    //{
                    //    sql = string.Format("select MAX(sn) from t_outbarcode where serialno = '{0}'", td_serialno);
                    //    cmd.CommandText = sql;
                    //    td_sn = cmd.ExecuteScalar().ToString();
                    //}

                    //               insert into t_receivetrans(id, taskno, deliveryno, voucherno, materialno, materialdesc, receivetype, supplierno,
                    //suppliername, materialdoc, materialdocdate, deliveryqty, receiveqty, packcount, barcode, serialno, rowno, creater, createdate, sn, Andalano)
                    //values(rectrans_id, t_taskno, rec_no, recd_voucherno, recd_materialno, recd_materialdesc, rec_vouchertype, rec_supplierno,
                    //rec_suppliername, md_doc, md_docdate, recd_deliveryqty, recd_receiveqty, recd_packcount, td_barcode, td_serialno, recd_rowno,
                    //(select username from t_user where userno = struserno ),sysdate,td_sn,(select ANDALANO from t_outbarcode where serialno = td_serialno));

     //               sql = string.Format(@"insert into t_receivetrans (id,taskno,deliveryno,voucherno,materialno,materialdesc,receivetype,supplierno,
     //suppliername,materialdoc,materialdocdate,deliveryqty,receiveqty,packcount,barcode,serialno,rowno,creater,createdate,sn,Andalano)
     //values({0},'{1}','{2}','{3}','{4}','{5}',{6},'{7}',
     //'{8}','{9}','{10}',{11},{12},{13},'{14}','{15}','{16}',
     //(select username from t_user where userno = '{17}' and ISNULL(isdel,0)<>2 ),getdate(),'{18}',(select ANDALANO from t_outbarcode where serialno = '{19}'));",
     //    rectrans_id, t_taskno, rec_no, recd_voucherno, recd_materialno, recd_materialdesc, rec_vouchertype, rec_supplierno,
     //rec_suppliername, md_doc, md_docdate, recd_deliveryqty, recd_receiveqty, recd_packcount, td_barcode, td_serialno, recd_rowno,
     //useer_no, td_sn, td_serialno);
     //               cmd.CommandText = sql;
     //               cmd.ExecuteNonQuery();

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


        public List<DeliveryReceiveDetail_Model> GetQualityDetailInfo(DeliveryReceive_Model DeliveryInfo)
        {
            try
            {
                string strSql = string.Format("select * from V_GETQUALITYDETAILINFO where receive_id = {0} and voucherno = '{1}' order by rowno asc ", DeliveryInfo.ID, DeliveryInfo.VoucherNo);
                List<DeliveryReceiveDetail_Model> lstDeliveryDetailInfo = new List<DeliveryReceiveDetail_Model>();

                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        DeliveryReceiveDetail_Model DRM = new DeliveryReceiveDetail_Model();
                        DRM.ID = dr["ID"].ToInt32();
                        DRM.RowNo = dr["RowNo"].ToDBString();
                        DRM.MaterialNo = dr["MaterialNo"].ToDBString();
                        DRM.MaterialDesc = dr["MaterialDesc"].ToDBString();
                        DRM.ReceiveQty = (decimal)dr["ReceiveQty"];
                        DRM.Unit = dr["Unit"].ToDBString();
                        DRM.PrdVersion = dr["PrdVersion"].ToDBString();
                        DRM.QualityQty = (decimal)dr["QualityQty"];
                        DRM.UnQualityQty = (decimal)dr["UnQualityQty"];
                        DRM.VoucherNo = dr["VoucherNo"].ToDBString();
                        DRM.QualityType = dr["qualitytype"].ToDBString();//string.Empty;//Common_Func.GetComboBoxItem(Common_Func.GetParentMenuByMenu);
                        lstDeliveryDetailInfo.Add(DRM);
                    }
                }
                return lstDeliveryDetailInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<ComboBoxItem> GetQualityType()
        {
            return Common_Func.GetComboBoxItem("SELECT ParameterID AS ID,ParameterName AS NAME FROM T_PARAMETER WHERE GROUPNAME = 'QualityType' ORDER BY ParameterID");
        }

        public bool SaveQualityDetailInfo(string strDeliveryXml, UserInfo userModel, ref string strErrMsg)
        {
            try
            {
                int iResult = 0;

                SqlParameter[] cmdParms = new SqlParameter[]
            {


                new SqlParameter("deliverydetailinfo_xml", SqlDbType.Image),
                new SqlParameter("struserno", SqlDbType.NVarChar),                
                //new SqlParameter("bresult", SqlDbType.Int,ParameterDirection.Output),
                new SqlParameter("bresult", SqlDbType.Int),

                //new SqlParameter("strerrmsg", SqlDbType.NVarChar,100,strErrMsg,ParameterDirection.Output)
                new SqlParameter("strerrmsg", SqlDbType.NVarChar,100,strErrMsg)

            };

                cmdParms[0].Value = strDeliveryXml;
                cmdParms[1].Value = userModel.UserNo;


                OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "p_updatequalityqty", cmdParms);
                iResult = Convert.ToInt32(cmdParms[2].Value.ToString());
                strErrMsg = cmdParms[3].Value.ToString();

                return iResult == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool PrintQuality(DeliveryReceive_Model deliveryMdl, UserInfo userModel, ref string strErrMsg)
        {
            try
            {
                string strSql = "";
                strSql = string.Format("update t_receive set printqty = ISNULL(printqty,0) + {0} where ID = {1}  ", 1, deliveryMdl.ID);
                int i = OperationSql.ExecuteNonQuery2(CommandType.Text, strSql);
                if (i <= 0)
                {
                    strErrMsg = string.Format("未更新质检主表任何行:{0}", strSql);
                    return false;
                }

                strSql = string.Format("update t_receivedetails set printqty = ISNULL(printqty,0) + {0}, printtime = sysdate where receive_id = {1} and voucherno = '{2}' ", 1, deliveryMdl.ID, deliveryMdl.VoucherNo);
                i = OperationSql.ExecuteNonQuery2(CommandType.Text, strSql);
                if (i <= 0)
                {
                    strErrMsg = string.Format("未更新质检子表任何行:{0}", strSql);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
