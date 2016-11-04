using WMS.Common;
using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WMS.Query
{
    internal class Query_Func
    {
        public static List<ComboBoxItem> GetOrderType()
        {
            List<ComboBoxItem> lstItem = new List<ComboBoxItem>();
            lstItem.Add(new ComboBoxItem() { ID = VoucherType.采购订单.ToInt32(), Name = VoucherType.采购订单.ToString() });
            lstItem.Add(new ComboBoxItem() { ID = VoucherType.送货单.ToInt32(), Name = VoucherType.送货单.ToString() });
            return lstItem;
        }

        #region 入库查询

        public static bool GetTaskTransListByPage(ref List<TaskTransInfo> modelList, TaskTransInfo model, ref DividPage page, ref string strError)
        {
            return WMSWebService.service.GetTaskTransListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }

        #endregion

        #region 出库查询

        #endregion

        #region 移库查询

        #endregion

        #region 库存查询

        public static bool GetStockListByPage(ref List<Stock_Model> modelList, Stock_Model model, ref DividPage page, ref string strError)
        {
            return WMSWebService.service.GetStockListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }

        #endregion

        #region 库存明细

        public static bool GetStockDetailListByPage(ref List<Stock_Model> modelList, Stock_Model model, ref DividPage page, ref string strError)
        {
            return WMSWebService.service.GetStockDetailListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }

        #endregion

        #region 收货查询

        public static bool GetReceiveTransListByPage(ref List<ReceiveTransInfo> modelList, ReceiveTransInfo model, ref DividPage page, ref string strError)
        {
            return WMSWebService.service.GetReceiveTransListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }

        #endregion

        #region 打印记录查询

        public static bool GetPrintRecordListByPage(ref List<Barcode_Model> modelList, Barcode_Model model, ref DividPage page, ref string strError)
        {
            return WMSWebService.service.GetPrintRecordListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }
        #endregion
    }
}
