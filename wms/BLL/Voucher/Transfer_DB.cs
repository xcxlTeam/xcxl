using BLL.Basic.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BLL.Common;

namespace BLL.Voucher
{
    public class Transfer_DB
    {
        public bool PostTransfer(ref List<Transfer> lst, UserInfo user, ref string strError)
        {
            System.Data.DataSet ds = new DataSet();
            try
            {
                if (!UploadTempTransfer(ref lst,user.UserNo))
                    return false;

                #region 调ERP存储过程过账
                string sql = "xMES_sp_Transfer";   //存储过程名称
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
                }
                #endregion
                //if (!SaveReceipt(ref model, user))
                //    return false;
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public bool UploadTempTransfer(ref List<Transfer> lst,string strUserNo)
        {
            Transfer model;
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
                if (lst == null || lst.Count == 0)
                {
                    model = new Transfer();
                    lst.Add(model);
                }
                else
                    model = lst[0];
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
                foreach (var item in lst)
                {
                    sql = string.Format(@"INSERT INTO [Barcode].[dbo].[Mes_Transfer]
           ([FromSiteID]
           ,[ToSiteID]
           ,[PsnCode]
           ,[InvCode]
           ,[VbatchCode]
           ,[TransNum]
           ,[FromCsCode]
           ,[ToCsCode])
     VALUES
           ('{0}','{1}','{2}','{3}','{4}',{5},'{6}','{7}')", item.SiteID, item.ToSiteID, strUserNo, item.InvtID, item.LotSerNbr, item.Qty,
                                                                 item.WhseLoc, item.ToWhseloc);
                    cmd.CommandText = sql;
                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        if (lst == null || lst.Count == 0)
                        {
                            model = new Transfer();
                            lst.Add(model);
                        }
                        else
                            model = lst[0];
                        model.Status = "E";
                        strError = "数据保存失败!";
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
                if (lst == null || lst.Count == 0)
                {
                    model = new Transfer();
                    lst.Add(model);
                }
                else
                    model = lst[0];
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
    }
}
