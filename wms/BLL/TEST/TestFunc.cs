using BLL.Basic.User;
using BLL.DeliveryReceive;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BLL.Common;
namespace BLL.TEST
{
    public class TestFunc
    {
        //public bool PostReceiveUnQualityReturnToSAP(ref DeliveryReceive_Model DeliveryInfo, UserInfo userModel, ref string strErrMsg) 
        //{
        //    DeliveryReceive_SAP DRSAP = new DeliveryReceive_SAP();
        //    return DRSAP.PostReceiveUnQualityReturnToSAP(ref DeliveryInfo, userModel, ref strErrMsg);
        //} 


        public bool TestReadData(int iNo, out System.Data.DataSet ds)
        {
            //System.Data.DataSet ds = new System.Data.DataSet();
            string strSql = "";
            switch(iNo)
            {
                case 1:
                    strSql = "select top 1000 * from xMES_ItemMST";
                    break;
                case 2:
                    strSql = "select top 1000 * from xMES_Purchase";
                    break;
                case 3:
                    strSql = "select top 1000 * from xMES_TranSF_To01";
                    break;
                case 4:
                    strSql = "select top 1000 * from xMES_BOM";
                    break;
                case 5:
                    strSql = "select top 1000 * from xMES_PackingSlip";
                    break;
                case 6:
                    strSql = "select top 1000 * from xMES_Prod";
                    break;
                case 7:
                    strSql = "select top 1000 * from xMES_TranSF_To03";
                    break;
                case 8:
                    strSql = "select top 1000 * from xMES_ProdBook_1";
                    break;
                case 9:
                    strSql = "select top 1000 * from xMES_ProdBook_2";
                    break;
                case 10:
                    strSql = "select top 1000 * from xMES_ProdBook_3";
                    break;
                case 11:
                    strSql = "select top 1000 * from xMES_TranSF_To04";
                    break;
            }
            string strMessage="";
            OperationSql.GetDataset(strSql, out ds, out strMessage);
            return true;
        }

        private SqlParameter[] GetParameterForRecipt()
        {
            int i;
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),                        
               
               //new SqlParameter("@v_ID", SqlDbType.NVarChar,1000),
              
              };
            i = 0;
            param[i++].Direction = ParameterDirection.Output;
            //param[i++].Direction = ParameterDirection.Output;

            i = 0;
            param[i++].Size = 1000;
            //param[i++].Size = 20;

            return param;
        }

        public bool TestReceipt(ref string strError,out System.Data.DataSet ds)
        {
            ds = new DataSet();
            try
            {
                //SqlParameter[] param = GetParameterForRecipt();

                //OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "", param);

                //strError = param[0].Value.ToDBString();


                string sql = "xMES_sp_Return";   //存储过程名称myproc  
                SqlDataAdapter da = new SqlDataAdapter(sql, OperationSql.ERPConnStr);
                //设置命令对象类型           
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //填充数据  
                da.Fill(ds);
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }
    }
}
