using BLL.DeliveryReceive;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Common;

namespace BLL.Production
{
    public class Production_DB
    {
        /// <summary>
        /// 获取已经收货数量
        /// </summary>
        /// <param name="strPrdVoucherNo"></param>
        /// <returns></returns>
        public DeliveryReceiveDetail_Model GetProductionOldReceiveQty(string strPrdVoucherNo) 
        {
            try
            {
                string strSql = string.Format("select deliveryqty , sum(receiveqty) as oldreceiveqty from t_receive a left join t_receivedetails b on a.id = b.receive_id where a.deliveryno ='{0}' group by deliveryqty", strPrdVoucherNo);
                DeliveryReceiveDetail_Model DRDM = new DeliveryReceiveDetail_Model();
                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    if (dr.Read())
                    {
                        DRDM.CurrentlyDeliveryNum = dr["deliveryqty"].ToInt32();
                        DRDM.OldReceiveQty = dr["oldreceiveqty"].ToInt32();                        
                    }
                }
                return DRDM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
