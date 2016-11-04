
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace BLL.DeliveryReceive
{
    public class DeliveryReceive_DB
    {

        public int GetIsUrgent(string strMaterialNo) 
        {
            string strSql = string.Format("select count(1) from t_stock where materialno = '{0}'", strMaterialNo);
            return Convert.ToInt32(OperationSql.ExecuteScalar(System.Data.CommandType.Text, strSql));
        }


        public int CheckDeliveryNoIsExist(string strDeliveryNo) 
        {
            try
            {
                string strSql = string.Format("select count(1) from t_receive where deliveryno = '{0}'", strDeliveryNo);
                return Convert.ToInt32(OperationSql.ExecuteScalar(System.Data.CommandType.Text, strSql));
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }


        
    }
}
