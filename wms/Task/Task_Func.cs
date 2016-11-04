using JingXinWMS.Common;
using JingXinWMS.JXWebService;
using System.Collections.Generic;

namespace JingXinWMS.Task
{
    public class Task_Func
    {

        public static List<ComboBoxItem> GetYesOrNo()
        {
            List<ComboBoxItem> lstItem = new List<ComboBoxItem>();
            lstItem.Add(new ComboBoxItem() { ID = 1, Name = "是" });
            lstItem.Add(new ComboBoxItem() { ID = 2, Name = "否" });
            return lstItem;
        }

        public static List<ComboBoxItem> GetIsQuality()
        {
            List<ComboBoxItem> lstItem = new List<ComboBoxItem>();
            lstItem.Add(new ComboBoxItem() { ID = 1, Name = "不质检" });
            lstItem.Add(new ComboBoxItem() { ID = 2, Name = "质检" });
            return lstItem;
        }

        public static List<ComboBoxItem> GetOrderType(bool IsStockIn)
        {
            List<ComboBoxItem> lstItem = new List<ComboBoxItem>();
            if (IsStockIn)
            {
                //lstItem.Add(new ComboBoxItem() { ID = VoucherType.采购订单.ToInt32(), Name = VoucherType.采购订单.ToString() });
                lstItem.Add(new ComboBoxItem() { ID = VoucherType.送货单.ToInt32(), Name = VoucherType.送货单.ToString() });
                lstItem.Add(new ComboBoxItem() { ID = VoucherType.无过账快速入.ToInt32(), Name = VoucherType.无过账快速入.ToString() });
                lstItem.Add(new ComboBoxItem() { ID = VoucherType.需过账快速入.ToInt32(), Name = VoucherType.需过账快速入.ToString() });
                lstItem.Add(new ComboBoxItem() { ID = VoucherType.生产订单.ToInt32(), Name = VoucherType.生产订单.ToString() });
                lstItem.Add(new ComboBoxItem() { ID = VoucherType.生产退料.ToInt32(), Name = VoucherType.生产退料.ToString() });
            }
            else
            {
                lstItem.Add(new ComboBoxItem() { ID = VoucherType.无过账快速出.ToInt32(), Name = VoucherType.无过账快速出.ToString() });
                lstItem.Add(new ComboBoxItem() { ID = VoucherType.需过账快速出.ToInt32(), Name = VoucherType.需过账快速出.ToString() });
            }
            return lstItem;
        }

        public static List<ComboBoxItem> GetTaskStatus(bool IsStockIn)
        {
            List<ComboBoxItem> lstItem = new List<ComboBoxItem>();
            if (IsStockIn)
            {
                lstItem.Add(new ComboBoxItem() { ID = TaskType.已下发.ToInt32(), Name = TaskType.已下发.ToString() });
                lstItem.Add(new ComboBoxItem() { ID = TaskType.未下发.ToInt32(), Name = TaskType.未下发.ToString() });
                lstItem.Add(new ComboBoxItem() { ID = TaskType.已完成.ToInt32(), Name = TaskType.已完成.ToString() });
                //lstItem.Add(new ComboBoxItem() { ID = TaskType.已取消.ToInt32(), Name = TaskType.已取消.ToString() });
                //lstItem.Add(new ComboBoxItem() { ID = TaskType.SAP已过账.ToInt32(), Name = TaskType.SAP已过账.ToString() });
            }
            else
            {
                //lstItem.Add(new ComboBoxItem() { ID = TaskType.已过账.ToInt32(), Name = TaskType.已过账.ToString() });
                lstItem.Add(new ComboBoxItem() { ID = TaskType.已完成.ToInt32(), Name = TaskType.已完成.ToString() });
                lstItem.Add(new ComboBoxItem() { ID = TaskType.已分配.ToInt32(), Name = TaskType.已分配.ToString() });
                lstItem.Add(new ComboBoxItem() { ID = TaskType.未分配.ToInt32(), Name = TaskType.未分配.ToString() });
                lstItem.Add(new ComboBoxItem() { ID = TaskType.已复核.ToInt32(), Name = TaskType.已复核.ToString() });
            }
            return lstItem;
        }

        public static List<ComboBoxItem> GetPostStatus()
        {
            List<ComboBoxItem> lstItem = new List<ComboBoxItem>();
            lstItem.Add(new ComboBoxItem() { ID = PostStatus.未过账.ToInt32(), Name = PostStatus.未过账.ToString() });
            lstItem.Add(new ComboBoxItem() { ID = PostStatus.部分过账.ToInt32(), Name = PostStatus.部分过账.ToString() });
            lstItem.Add(new ComboBoxItem() { ID = PostStatus.已过账.ToInt32(), Name = PostStatus.已过账.ToString() });
            lstItem.Add(new ComboBoxItem() { ID = PostStatus.无过账.ToInt32(), Name = "" });   //PostStatus.无过账.ToString()
            return lstItem;
        }


        public static bool GetDeliveryInfoToSRM(ref DeliveryReceive_Model DeliveryModel, ref string strErrMsg)
        {
            return WebService.service.GetOutSideByDeliveryToSRM(ref DeliveryModel, Common_Var.CurrentUser, ref strErrMsg);
        }

        public static bool GetTaskMainListByPage(ref List<OverViewInfo> modelList, OverViewInfo model, ref DividPage page, ref string strError)
        {
            return WebService.service.GetTaskMainListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }

        public static bool GetTaskDetailListByPage(ref List<OverViewDetailInfo> modelList, OverViewDetailInfo model, ref DividPage page, ref string strError)
        {
            return WebService.service.GetTaskDetailListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }

        public static bool GetTaskTransListByPage(ref List<TaskTransInfo> modelList, TaskTransInfo model, ref DividPage page, ref string strError)
        {
            return WebService.service.GetTaskTransListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }

        //public static bool PostOutSideByDeliveryAndPOToSAP(ref DeliveryReceive_Model DeliveryInfo, ref string strError)
        //{
        //    return WebService.service.PostOutSideByDeliveryAndPOToSAP(ref DeliveryInfo, Common_Var.CurrentUser, ref strError);
        //}

        public static bool GetOverViewExportListByPage(ref List<OverViewExportInfo> modelList, OverViewExportInfo model, ref DividPage page, ref string strError)
        {
            return WebService.service.GetOverViewExportListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }

    }
}
