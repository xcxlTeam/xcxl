using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BLL.Voucher
{
    public class ReadAPI_DB
    {
        public SqlDataReader ReadData(ReadApiType iType, params object[] list)
        {
            string strSql = string.Empty;
            int iNo = Convert.ToInt32(iType);
            switch (iNo)
            {
                case 1:
                    if (list != null && list.Count<object>() > 0)
                    {
                        strSql = string.Format("select top 100000000 * from xMES_ItemMST where invtid='{0}'", list[0].ToString());
                    }
                    break;
                case 2:
                    if (list != null && list.Count<object>() > 0)
                    {
                        strSql = string.Format(@"select top 100000000 a.*,b.Allergic,b.SceneMaterial,b.UserFlag,b.InvtType,b.ShelfLife,b.StkUnit from xMES_Purchase a 
                        join xMES_ItemMST b on a.invtid=b.invtid where PoNbr='{0}'", list[0].ToString());
                    }
                    break;
                case 3:
                    if (list != null && list.Count<object>() > 0)
                    {
                        int iCount = list.Count<object>();
                        if (iCount == 1)
                            strSql = string.Format("select top 100000000 * from xMES_TranSF_To01 where InvtID='{0}'", list[0].ToString());
                        if (iCount == 2)
                            strSql = string.Format("select top 100000000 * from xMES_TranSF_To01 where InvtID='{0}' and LotSerNbr='{1}'", list[0].ToString(), list[1].ToString());
                        if (iCount == 3)
                            strSql = string.Format("select top 100000000 * from xMES_TranSF_To01 where InvtID='{0}' and LotSerNbr='{1}' and CONVERT(varchar(100), TranDate, 23)='{2}'", list[0].ToString(), list[1].ToString(), Convert.ToDateTime(list[2]).ToString("yyyy-MM-dd"));
                    }
                    break;
                case 4:
                    if (list != null && list.Count<object>() > 0)
                    {
                        strSql = string.Format("select top 100000000 * from xMES_BOM where InvtID='{0}'", list[0].ToString());
                    }
                    break;
                case 5:
                    if (list != null && list.Count<object>() > 0)
                    {
                        int iCount = list.Count<object>();
                        if (iCount == 1)
                            strSql = string.Format("select top 100000000 * from xMES_PackingSlip where ShipperID='{0}'", list[0].ToString());
                        if (iCount == 2)
                            strSql = string.Format("select top 100000000 * from xMES_PackingSlip where ShipperID='{0}' and CONVERT(varchar(100),ShipDateAct, 23)='{1}'", list[0].ToString(), Convert.ToDateTime(list[1]).ToString("yyyy-MM-dd"));
                    }
                    break;
                case 6:
                    if (list != null && list.Count<object>() > 0)
                    {
                        int iCount = list.Count<object>();
                        if (iCount == 1)
                            strSql = string.Format("select top 100000000 * from xMES_Prod a join xMES_ItemMST b on a.invtid=b.invtid where ProdOrdID='{0}'", list[0].ToString());
                        if (iCount == 2)
                            strSql = string.Format("select top 100000000 * from xMES_Prod a join xMES_ItemMST b on a.invtid=b.invtid where ProdOrdID='{0}' and CONVERT(varchar(100),StartDate, 23)='{1}'", list[0].ToString(), Convert.ToDateTime(list[1]).ToString("yyyy-MM-dd"));
                        if (iCount == 3)
                            strSql = string.Format("select top 100000000 * from xMES_Prod a join xMES_ItemMST b on a.invtid=b.invtid where ProdOrdID='{0}' and CONVERT(varchar(100),StartDate, 23)='{1}'  and CONVERT(varchar(100),EndDate, 23)='{2}'", list[0].ToString(), Convert.ToDateTime(list[1]).ToString("yyyy-MM-dd"), Convert.ToDateTime(list[2]).ToString("yyyy-MM-dd"));
                    }
                    break;
                case 7:
                    if (list != null && list.Count<object>() > 0)
                    {
                        int iCount = list.Count<object>();
                        if (iCount == 1)
                            strSql = string.Format("select top 100000000 * from xMES_TranSF_To03 where InvtID='{0}'", list[0].ToString());
                        if (iCount == 2)
                            strSql = string.Format("select top 100000000 * from xMES_TranSF_To03 where InvtID='{0}' and LotSerNbr='{1}'", list[0].ToString(), list[1].ToString());
                        if (iCount == 3)
                            strSql = string.Format("select top 100000000 * from xMES_TranSF_To03 where InvtID='{0}' and LotSerNbr='{1}' and CONVERT(varchar(100), TranDate, 23)='{2}'", list[0].ToString(), list[1].ToString(), Convert.ToDateTime(list[2]).ToString("yyyy-MM-dd"));
                    }
                    break;
                case 8:
                    if (list != null && list.Count<object>() > 0)
                    {
                        int iCount = list.Count<object>();
                        if (iCount == 1)
                            strSql = string.Format("select top 100000000 * from xMES_ProdBook_1 where ProdOrdID='{0}'", list[0].ToString());
                        if (iCount == 2)
                            strSql = string.Format("select top 100000000 * from xMES_ProdBook_1 where ProdOrdID='{0}' and CONVERT(varchar(100),StartDate, 23)='{1}'", list[0].ToString(), Convert.ToDateTime(list[1]).ToString("yyyy-MM-dd"));
                        if (iCount == 3)
                            strSql = string.Format("select top 100000000 * from xMES_ProdBook_1 where ProdOrdID='{0}' and CONVERT(varchar(100),StartDate, 23)='{1}'  and CONVERT(varchar(100),EndDate, 23)='{2}'", list[0].ToString(), Convert.ToDateTime(list[1]).ToString("yyyy-MM-dd"), Convert.ToDateTime(list[2]).ToString("yyyy-MM-dd"));
                    }
                    break;
                case 9:
                    if (list != null && list.Count<object>() > 0)
                    {
                        int iCount = list.Count<object>();
                        if (iCount == 1)
                            strSql = string.Format("select top 100000000 * from xMES_ProdBook_2 where ProdOrdID='{0}'", list[0].ToString());
                        if (iCount == 2)
                            strSql = string.Format("select top 100000000 * from xMES_ProdBook_2 where ProdOrdID='{0}' and CONVERT(varchar(100),StartDate, 23)='{1}'", list[0].ToString(), Convert.ToDateTime(list[1]).ToString("yyyy-MM-dd"));
                        if (iCount == 3)
                            strSql = string.Format("select top 100000000 * from xMES_ProdBook_2 where ProdOrdID='{0}' and CONVERT(varchar(100),StartDate, 23)='{1}'  and CONVERT(varchar(100),EndDate, 23)='{2}'", list[0].ToString(), Convert.ToDateTime(list[1]).ToString("yyyy-MM-dd"), Convert.ToDateTime(list[2]).ToString("yyyy-MM-dd"));
                    }
                    break;
                case 10:
                    if (list != null && list.Count<object>() > 0)
                    {
                        int iCount = list.Count<object>();
                        if (iCount == 1)
                            strSql = string.Format("select top 100000000 * from xMES_ProdBook_3 where ProdOrdID='{0}'", list[0].ToString());
                        if (iCount == 2)
                            strSql = string.Format("select top 100000000 * from xMES_ProdBook_3 where ProdOrdID='{0}' and CONVERT(varchar(100),StartDate, 23)='{1}'", list[0].ToString(), Convert.ToDateTime(list[1]).ToString("yyyy-MM-dd"));
                        if (iCount == 3)
                            strSql = string.Format("select top 100000000 * from xMES_ProdBook_3 where ProdOrdID='{0}' and CONVERT(varchar(100),StartDate, 23)='{1}'  and CONVERT(varchar(100),EndDate, 23)='{2}'", list[0].ToString(), Convert.ToDateTime(list[1]).ToString("yyyy-MM-dd"), Convert.ToDateTime(list[2]).ToString("yyyy-MM-dd"));
                    }
                    break;
                case 11:
                    if (list != null && list.Count<object>() > 0)
                    {
                        int iCount = list.Count<object>();
                        if (iCount == 1)
                            strSql = string.Format("select top 100000000 * from xMES_TranSF_To04 where InvtID='{0}'", list[0].ToString());
                        if (iCount == 2)
                            strSql = string.Format("select top 100000000 * from xMES_TranSF_To04 where InvtID='{0}' and LotSerNbr='{1}'", list[0].ToString(), list[1].ToString());
                        if (iCount == 3)
                            strSql = string.Format("select top 100000000 * from xMES_TranSF_To04 where InvtID='{0}' and LotSerNbr='{1}' and CONVERT(varchar(100), TranDate, 23)='{2}'", list[0].ToString(), list[1].ToString(), Convert.ToDateTime(list[2]).ToString("yyyy-MM-dd"));
                    }
                    break;
            }

            return OperationSql.ExecuteReaderForERP(CommandType.Text, strSql, null);
        }



    }

    public enum ReadApiType
    {
        INVENTORY=1,
        RECEIPT,
        TRANSFER_TO01,
        BOM,
        PACKINGSLIP,
        PROD,
        TRANSFER_TO03,
        PRODBOOK_1,
        PRODBOOK_2,
        PRODBOOK_3,
        TRANSFER_TO04
    }
}
