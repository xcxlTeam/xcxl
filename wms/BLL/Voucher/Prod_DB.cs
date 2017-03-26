using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using BLL.Basic.User;

namespace BLL.Voucher
{
    public class Prod_DB
    {
        public SqlDataReader GetLastProdHead()
        {
            string strSql = string.Empty;
            strSql = string.Format("select count(1) from T_TransferMain where ISNULL(OrderState,0)<2");
            object oRes=OperationSql.ExecuteScalar(CommandType.Text,strSql, null);
            if (oRes==null||Convert.ToInt32(oRes)>1)
            {
                return null;
            }
            strSql = string.Format(@"SELECT [id]
                  ,[AllotNo]
                  ,[dTime]
                  ,[UserCode]
                  ,[OrderState]
              FROM [Barcode].[dbo].[T_TransferMain] where ISNULL(OrderState,0)<2");
            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);

        }

        public SqlDataReader GetLastProdDetails()
        {
            string strSql = string.Empty;
            strSql = string.Format("select 1 from T_TransferMain where ISNULL(OrderState,0)<2");
            object oRes = OperationSql.ExecuteScalar(CommandType.Text, strSql, null);
            if (oRes == null || Convert.ToInt32(oRes) > 1)
            {
                return null;
            }
            strSql = string.Format(@"SELECT [id]
                  ,[mID]
                  ,[RowNo]
                  ,[cInvCode]
                  ,[BuildingNo]
                  ,[QtyReq]
                  ,[QtyTransfer]
                  ,[iOperate]
                  ,[sOperate]
                  ,[sInvType]
                  ,[WorkShopStock]
              FROM [Barcode].[dbo].[T_TRANSFERDETAIL]
              where mID=(SELECT [id] FROM [Barcode].[dbo].[T_TransferMain] where ISNULL(OrderState,0)<2)");
            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);

        }

    }
}
