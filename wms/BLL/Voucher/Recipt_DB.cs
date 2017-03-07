using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BLL.Common;
using BLL.Basic.User;

namespace BLL.Voucher
{
    public class Recipt_DB
    {
        public bool PostReceipt(ref ReceiptHead model,UserInfo user, ref string strError)
        {
            System.Data.DataSet ds = new DataSet();
            try
            {
                if (!UploadTempReceipt(ref model))
                    return false;

                #region 调ERP存储过程过账
                string sql = "xMES_sp_Receipt";   //存储过程名称
                SqlDataAdapter da = new SqlDataAdapter(sql, OperationSql.ERPConnStr);
                //设置命令对象类型           
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //填充数据  
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Columns.Count > 0)
                {
                    if (ds.Tables[0].Columns.Count == 1)
                    {
                        strError = ds.Tables[0].Rows[0][0].ToDBString();
                        return false;
                    }
                    if (ds.Tables[0].Columns.Count == 2)
                    {
                        model.BatNbr = ds.Tables[0].Rows[0][0].ToDBString();
                        model.RcptNbr = ds.Tables[0].Rows[0][1].ToDBString();
                    }
                } 
                #endregion
                //if(!SaveReceipt(ref model,user))
                //    return false;
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public bool SaveReceipt(ref ReceiptHead model,UserInfo user)
        {
            SqlParameter[] param = GetParameterFromModel(model,user);

            param[0].Value = XMLUtil.XmlUtil.Serializer(typeof(ReceiptHead), model);
            param[1].Value = user.UserNo;
            param[2].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_SaveRecipt", param);

            string ErrorMsg = param[2].Value.ToDBString();
            if (ErrorMsg.StartsWith("执行错误"))
            {
                throw new Exception(ErrorMsg);
            }
            else
            {
                throw new Exception(ErrorMsg);
                //return true;
            }
        }

        public bool UploadTempReceipt(ref ReceiptHead model)
        {
            string strError = string.Empty;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = OperationSql.ERPConnStr;

            string sql = null;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                model.Status = "E";
                model.Message = strError;
                return false;
            }
            SqlTransaction myTran;
            myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = myTran;
            DataSet result = new DataSet();

            try
            {
                foreach (var item in model.lstDetails)
                {
                    sql = string.Format(@"INSERT INTO [Mes_PurchaseOrder]
           ([OrderNum]
           ,[RowNum]
           ,[Invcode]
           ,[InNum]
           ,[NetWt]
           ,[StdTareWt]
           ,[VbatchCode]
           ,[VbatchNum]
           ,[OldbatchCode]
           ,[Producttime])
     VALUES
           ('{0}','{1}','{2}',{3},{4},{5},'{6}',{7},'{8}',getdate())", item.PoNbr,item.LineRef,item.InvtID,item.iQty,item.NetWt,
                                                                 item.StdTareWt,item.cBatch, item.batchQty, item.VendBatch);
                    cmd.CommandText = sql;
                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        strError = "数据保存失败!";
                        model.Status = "E";
                        model.Message = strError;
                        myTran.Rollback();
                        return false;
                    }
                }
                myTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                model.Status = "E";
                model.Message = strError;
                myTran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        private SqlParameter[] GetParameterFromModel(ReceiptHead model,UserInfo user)
        {
            int i;
            SqlParameter[] param = new SqlParameter[]{
                                   
               new SqlParameter("data_xml", SqlDbType.Xml),
               new SqlParameter("strUserNo", SqlDbType.NVarChar),
               new SqlParameter("strErrMsg",SqlDbType.NVarChar,1000),    
              };
            i = 0;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Output;

            i = 0;
            param[i++].Size = 3000;
            param[i++].Size = 20;
            param[i++].Size = 1000;

            return param;
        }


    }
}
