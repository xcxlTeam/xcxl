using BLL.Basic.User;
using BLL.DeliveryReceive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
