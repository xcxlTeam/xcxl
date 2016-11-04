using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BLL.Common;
using BLL.DeliveryReceive;
using BLL.Basic.User;
using BLL.PrintBarcode;

namespace BLL.Task
{
    public class Task_DB
    {
        /// <summary>
        /// 获取上架任务
        /// </summary>
        /// <returns></returns>
        public List<Task_Model> GetTaskInfo(UserInfo userModel, Barcode_Model barcodeMdl) 
        {
            try
            {
                List<Task_Model> lstTask = new List<Task_Model>();

                string strSql = string.Empty;

                if (string.IsNullOrEmpty(barcodeMdl.SERIALNO))
                {
                    strSql = string.Format("select * from V_GETTASKINFO where F_USERINWAREHOUSE(warehouse_id,'{0}')>0", userModel.WarehouseCode);
                }
                else 
                {
                    if (barcodeMdl.VOUCHERTYPE == "50" || barcodeMdl.VOUCHERTYPE == "60")
                    {
                        strSql = string.Format("select * from V_GETTASKINFO a where F_USERINWAREHOUSE(a.warehouse_id,'{0}')>0 and taskno = '{1}'", userModel.WarehouseCode, barcodeMdl.DELIVERYNO);
                    }
                    else 
                    {
                        //strSql = string.Format("select * from V_GETTASKINFO a where F_USERINWAREHOUSE(a.warehouse_id,'{0}')>0 and deliveryno = '{1}'", userModel.WarehouseCode, barcodeMdl.DELIVERYNO);
                        strSql = string.Format(@"SELECT ID,TaskNo,'生产订单' VoucherTypeName
  , IsShelvePost, IsQuality, CreateDateTime, DeliveryNo MaterialDoc
  , VoucherType, DeliveryNo, (select top 1 username from T_USER where T_USER.userno =[T_TASK].receiveuserno and isdel = 1) ReceiveUserName
        FROM[T_TASK] where deliveryno = '{0}'", barcodeMdl.DELIVERYNO);

                    }

                }
                

                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        Task_Model TM = new Task_Model();
                        TM.ID = Convert.ToInt32(dr["ID"]);
                        TM.TaskNo = dr["taskno"].ToDBString();
                        TM.ReceiveUserName = dr["receiveusername"].ToDBString();
                        TM.VoucherTypeName = dr["vouchertypename"].ToDBString();
                        TM.IsShelvePost = dr["isshelvepost"].ToInt32();
                        TM.IsQuality = dr["IsQuality"].ToInt32();
                        TM.CreateDateTime =dr["CreateDateTime"].ToDateTime();
                        TM.MaterialDoc = dr["materialdoc"].ToDBString();
                        TM.VoucherType = dr["VoucherType"].ToInt32();
                        TM.DeliveryNo = dr["deliveryno"].ToDBString();
                        lstTask.Add(TM);
                    }
                }
                return lstTask;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }


        public Task_Model GetTaskDetailsInfo(string strTaskNo) 
        {
            try
            {
                Task_Model TM = new Task_Model();
                TM.lstTaskDetails = new List<TaskDetails_Model>();

                string strSql = string.Format("select * from V_GETTASKDETAILSINFO where taskno = '{0}'", strTaskNo);

                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        TM.ID = dr["task_id"].ToInt32();
                        TM.TaskNo = dr["taskno"].ToDBString();
                        TM.TaskStatus = dr["taskstatus"].ToInt32();
                        TM.IsShelvePost = dr["isshelvepost"].ToInt32();
                        TM.IsQuality = dr["isquality"].ToInt32();
                        TM.VoucherType = dr["VoucherType"].ToInt32();
                        TM.Plant = dr["plant"].ToDBString();
                        TM.DeliveryNo = dr["deliveryno"].ToDBString();

                        TaskDetails_Model TDM = new TaskDetails_Model();
                        TDM.ID = dr["id"].ToInt32();
                        TDM.MaterialNo = dr["materialno"].ToDBString();
                        TDM.MaterialDesc = dr["materialdesc"].ToDBString();
                        TDM.MaterialStd = dr["MaterialStd"].ToDBString();
                        TDM.TaskQty = dr["taskqty"].ToDecimal();
                        TDM.QuanlityQty = dr["qualityqty"].ToDecimal();
                        TDM.RemainQty = dr["remainqty"].ToDecimal();
                        TDM.ShelveQty = dr["shelveqty"].ToDecimal();
                        TDM.RowNo = dr["RowNo"].ToDBString();
                        TDM.VoucherNo = dr["VoucherNo"].ToDBString();
                        TDM.PackCount = dr["PackCount"].ToDecimal();
                        TDM.ShelvePackCount = dr["ShelvePackCount"].ToDecimal();
                        TDM.RemainPackCount = dr["RemainPackCount"].ToDecimal();
                        TM.lstTaskDetails.Add(TDM);
                    }
                }
                strSql = string.Format(@"SELECT A.warehouseno FROM T_WAREHOUSE A JOIN T_TASKWAREHOUSE B ON A.id=B.warehouse_id JOIN T_TASK C ON B.task_id=C.id
WHERE C.taskno = '{0}'", strTaskNo);
                TM.WareHouseNo = OperationSql.ExecuteScalar(CommandType.Text, strSql, null).ToString();
                return TM;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }


        public Task_Model GetSupplierInfoByMaterialDoc(string strMaterialDoc) 
        {
            try
            {
                string strSql = string.Format("select * from V_GETSUPPLIERINFOBYMATERIALDOC where a.materialdoc = {0}",strMaterialDoc);
                Task_Model TM = new Task_Model();
                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    if (dr.Read())
                    {
                        TM.SupCusNo = dr["supplierno"].ToString();
                        TM.SupCusName = dr["suppliername"].ToString();
                        TM.DeliveryNo = dr["deliveryno"].ToString();                        
                    }
                }
                return TM;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }


        public bool CreateQuanlityReturnVoucher(string strQuanlityXml,ref string strReturnNo, BLL.Basic.User.UserInfo userModel,ref string strErrMsg) 
        {
            try
            {
                int iResult = 0;

                SqlParameter[] cmdParms = new SqlParameter[] 
            {
                new SqlParameter("strQuanlityXml", SqlDbType.Image),
                new SqlParameter("struserno", SqlDbType.NVarChar),
                new SqlParameter("strreturnno", SqlDbType.NVarChar,50,strReturnNo),
                //new SqlParameter("bresult", SqlDbType.Int,ParameterDirection.Output),
                new SqlParameter("bresult", SqlDbType.Int),

                new SqlParameter("strerrmsg", SqlDbType.NVarChar,100,strErrMsg)
            };

                cmdParms[0].Value = strQuanlityXml;
                cmdParms[1].Value = userModel.UserNo;


                OperationSql.ExecuteNonQuery2( CommandType.StoredProcedure, "p_createquanlityreturnvoucher", cmdParms);
                iResult = Convert.ToInt32(cmdParms[3].Value.ToString());
                strReturnNo = cmdParms[2].Value.ToString();
                strErrMsg = cmdParms[4].Value.ToString();

                return iResult == 1 ? true : false;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public bool InStock(string strToAreaNo,string strTaskXml, UserInfo userModel, ref string strErrMsg) 
        {
            #region 验证货位是否合法
            string strsql = string.Format("select 1 from v_area where AREATYPE=1 and AREANO='{0}'", strToAreaNo);
            if (OperationSql.ExecuteScalar(CommandType.Text, strsql, null) == null)
            {
                strErrMsg = "货位不存在或者不是正式货位！";
                return false;
            } 
            #endregion
            try
            {
                int iResult = 0;

                SqlParameter[] cmdParms = new SqlParameter[] 
            {
                new SqlParameter("strToAreaNo", SqlDbType.NVarChar),
                new SqlParameter("Task_xml", SqlDbType.Xml),
                new SqlParameter("strUserNo", SqlDbType.NVarChar),
                //new SqlParameter("bResult", SqlDbType.Int,ParameterDirection.Output),
                new SqlParameter("bResult", SqlDbType.Int),

                //new SqlParameter("strErrMsg", SqlDbType.NVarChar,1000,strErrMsg,ParameterDirection.Output)
                new SqlParameter("strErrMsg", SqlDbType.NVarChar,1000,strErrMsg)

            };

                cmdParms[0].Value = strToAreaNo;
                cmdParms[1].Value = strTaskXml;
                cmdParms[2].Value = userModel.UserNo;

                cmdParms[3].Direction = ParameterDirection.Output;
                cmdParms[4].Direction = ParameterDirection.Output;

                OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "p_instock", cmdParms);
                iResult = Convert.ToInt32(cmdParms[3].Value.ToString());
                strErrMsg = cmdParms[4].Value.ToString();

                return iResult == 1 ? true : false;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }


        public int CheckBarCodeIsInStock(string strBarcode)
        {
            try
            {
                string strSql = string.Format("select count(1) from t_stock where serialno = '{0}'", strBarcode);
                
                return Convert.ToInt32(OperationSql.ExecuteScalar(System.Data.CommandType.Text, strSql));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.TargetSite);
            }
        }

        /// <summary>
        /// 查看物料被哪个用户锁定
        /// </summary>
        /// <param name="taskDetailsMdl"></param>
        /// <param name="userMdl"></param>
        /// <returns></returns>
        public string QueryUserNameByTaskDetails(TaskDetails_Model taskDetailsMdl, BLL.Basic.User.UserInfo userMdl)
        {
            try
            {
                string strUserName = string.Empty;
                string strSql = "select b.UserName from t_taskdetails a left join t_user b on a.operatoruserno = b.userno where a.id = {0} " +
                                " and  a.operatoruserno!='{1}'";
                strSql = string.Format(strSql, taskDetailsMdl.ID, userMdl.UserNo);
                return (string)OperationSql.ExecuteScalar(System.Data.CommandType.Text, strSql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.TargetSite);
            }

        }


        

        /// <summary>
        /// 锁定物料操作人
        /// </summary>
        /// <param name="taskDetailsMdl"></param>
        /// <param name="userMdl"></param>
        /// <returns></returns>
        public int LockTaskOperUser(TaskDetails_Model taskDetailsMdl, BLL.Basic.User.UserInfo userMdl)
        {
            try
            {
                string strSql = "update t_taskdetails set operatoruserno='{0}' where id = '{1}'";
                strSql = string.Format(strSql, userMdl.UserNo, taskDetailsMdl.ID);
                return OperationSql.ExecuteNonQuery2(System.Data.CommandType.Text, strSql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.TargetSite);
            }
        }

        public bool UnLockTaskOperUser( string strTaskXml, BLL.Basic.User.UserInfo userModel, ref string strErrMsg)
        {
            try
            {
                int iResult = 0;

                SqlParameter[] cmdParms = new SqlParameter[] 
            {                
                new SqlParameter("Task_xml", SqlDbType.Image),
                new SqlParameter("strUserNo", SqlDbType.NVarChar),
                //new SqlParameter("bResult", SqlDbType.Int,ParameterDirection.Output),
                new SqlParameter("bResult", SqlDbType.Int),

                //new SqlParameter("strErrMsg", SqlDbType.NVarChar,1000,strErrMsg,ParameterDirection.Output)
                new SqlParameter("strErrMsg", SqlDbType.NVarChar,1000,strErrMsg)

            };


                cmdParms[0].Value = strTaskXml;
                cmdParms[1].Value = userModel.UserNo;

                OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "p_unlockoperuser", cmdParms);
                iResult = Convert.ToInt32(cmdParms[2].Value.ToString());
                strErrMsg = cmdParms[3].Value.ToString();

                return iResult == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CheckAreaByNo(string strAreaNo)
        {
            try
            {
                string strSql = string.Format("select count(1) from t_area where areano = '{0}' and isdel = '1'", strAreaNo);
                return Convert.ToInt32(OperationSql.ExecuteScalar(System.Data.CommandType.Text, strSql));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.TargetSite);
            }
        }


        public int CheckAreaIsLock(string strAreaNo)
        {
            try
            {
                string strSql = string.Format("select count(1) from t_area where areano = '{0}' and areastatus = '1'", strAreaNo);
                return Convert.ToInt32(OperationSql.ExecuteScalar(System.Data.CommandType.Text, strSql));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.TargetSite);
            }

        }

        public DeliveryReceive_Model GetTaskInfoByID(string strTaskID, UserInfo userModel) 
        {
            try
            {
                DeliveryReceive_Model deliveryModel = new DeliveryReceive_Model();
                deliveryModel.lstDeliveryDetail = new List<DeliveryReceiveDetail_Model>();
                string strSql = string.Format("select * from v_gettaskinfobyid where id = '{0}' and operatoruserno = '{1}'", strTaskID,userModel.UserNo);
                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        deliveryModel.ID = dr["id"].ToInt32();
                        deliveryModel.VoucherType = dr["VoucherType"].ToInt32();
                        deliveryModel.IsShelvePost = dr["IsShelvePost"].ToInt32();
                        deliveryModel.VoucherNo = dr["taskno"].ToDBString();
                        deliveryModel.DeliveryNo = dr["deliveryno"].ToDBString();
                        deliveryModel.MaterialDoc = dr["MaterialDoc"].ToDBString();
                        deliveryModel.DocDate = dr["docdate"].ToDateTimeNull();
                        deliveryModel.MoveType = dr["movetype"].ToDBString();

                        DeliveryReceiveDetail_Model deliveryDetailModel = new DeliveryReceiveDetail_Model();
                        deliveryDetailModel.ID = dr["taskdetailid"].ToInt32();
                        deliveryDetailModel.Plant = dr["plant"].ToDBString();
                        deliveryDetailModel.MaterialNo = dr["materialno"].ToDBString();
                        deliveryDetailModel.CurrentPostQty = dr["currentpostqty"].ToDecimal();
                        deliveryDetailModel.VoucherNo = dr["VoucherNo"].ToDBString();
                        deliveryDetailModel.RowNo = dr["RowNo"].ToDBString();
                        deliveryDetailModel.ReserveNumber = dr["ReserveNumber"].ToDBString();
                        deliveryDetailModel.TrackNo = dr["trackno"].ToDBString();
                        deliveryDetailModel.ReserveRowNo = dr["ReserveRowNo"].ToDBString();
                        deliveryModel.lstDeliveryDetail.Add(deliveryDetailModel);
                        
                    }
                }
                return deliveryModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.TargetSite);
            }
        }

        public bool UpdateTaskByPost(string strDeliveryXml, BLL.Basic.User.UserInfo userModel, ref string strErrMsg) 
        {
            try
            {
                int iResult = 0;

                SqlParameter[] cmdParms = new SqlParameter[] 
            {
                new SqlParameter("deliveryinfo_xml", SqlDbType.Image),                
                new SqlParameter("strUserNo", SqlDbType.NVarChar),
                //new SqlParameter("bResult", SqlDbType.Int,ParameterDirection.Output),
                new SqlParameter("bResult", SqlDbType.Int),

                new SqlParameter("strErrMsg", SqlDbType.NVarChar,200,strErrMsg)
            };

                cmdParms[0].Value = strDeliveryXml;
                cmdParms[1].Value = userModel.UserNo;

                TOOL.WriteLogMethod.WriteLog("方法：UpdateTaskByPost---操作人：" + userModel.UserName + strDeliveryXml);
                OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "p_updatetaskbypost", cmdParms);
                iResult = Convert.ToInt32(cmdParms[2].Value.ToString());
                strErrMsg = cmdParms[3].Value.ToString();

                return iResult == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetAreaNoByMaterialNo(string strMatraialNo) 
        {
            try
            {
                string strAreaNo = string.Empty;

                string strSql = string.Format("select ltrim(max(sys_connect_by_path(a.areano,';')),';') as areano from (select areano,row_number() over ( ORDER BY materialno) as numid from t_stock "+
                                "where  materialno = '{0}' and rownum < 4 group by areano,materialno) a start with a.numid =1 connect by   a.numid -1 = prior a.numid", strMatraialNo);
                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    if (dr.Read())
                    {
                        strAreaNo = dr["areano"].ToString();
                    }
                }
                return strAreaNo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.TargetSite);
            }
        }

    }
}
