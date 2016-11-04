using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL.OutSideReceive
{
    public class OutSideReceive_DB
    {
        public bool SaveOutSideDeliveryInfo(string strReceiveGoodsXml, BLL.Basic.User.UserInfo userModel, ref string strErrMsg)
        {
            try
            {
                int iResult = 0;

                SqlParameter[] cmdParms = new SqlParameter[] 
            {
                new SqlParameter("deliveryinfo_xml", SqlDbType.Image),                
                new SqlParameter("struserno", SqlDbType.NVarChar),               
                
                //new SqlParameter("bresult", SqlDbType.Int,ParameterDirection.Output),
                new SqlParameter("bresult", SqlDbType.Int),

                //new SqlParameter("strerrmsg", SqlDbType.NVarChar,100,strErrMsg,ParameterDirection.Output)
                new SqlParameter("strerrmsg", SqlDbType.NVarChar,100,strErrMsg)

            };

                cmdParms[0].Value = strReceiveGoodsXml;                
                cmdParms[1].Value = userModel.UserNo;



                OperationSql.ExecuteNonQuery2( CommandType.StoredProcedure, "p_saveoutsidedelivery", cmdParms);
                iResult = Convert.ToInt32(cmdParms[2].Value.ToString());                
                strErrMsg = cmdParms[3].Value.ToString();

                return iResult == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
