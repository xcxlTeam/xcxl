using WMS.Common;
using WMS.WebService;
using System.Collections.Generic;

namespace WMS.Check
{
    public class Check_Func
    {
        public static List<ComboBoxItem> GetIsDifference()
        {
            List<ComboBoxItem> lstItem = new List<ComboBoxItem>();
            lstItem.Add(new ComboBoxItem() { ID = 1, Name = "无差异" });
            lstItem.Add(new ComboBoxItem() { ID = 2, Name = "有差异" });
            return lstItem;
        }

        public static List<ComboBoxItem> GetProfitLoss()
        {
            List<ComboBoxItem> lstItem = new List<ComboBoxItem>();
            lstItem.Add(new ComboBoxItem() { ID = 1, Name = "平衡" });
            lstItem.Add(new ComboBoxItem() { ID = 2, Name = "盘盈" });
            lstItem.Add(new ComboBoxItem() { ID = 3, Name = "盘亏" });
            return lstItem;
        }

        #region 盘点设置

        public static bool SaveCheck(ref CheckInfo model, ref string strError)
        {
            return WMSWebService.service.SaveCheck(ref model, Common_Var.CurrentUser, ref strError);
        }


        public static bool DeleteCheckByID(CheckInfo model, ref string strError)
        {
            return WMSWebService.service.DeleteCheckByID(model, Common_Var.CurrentUser, ref strError);
        }


        public static bool GetCheckByID(ref CheckInfo model, ref string strError)
        {
            return WMSWebService.service.GetCheckByID(ref model, Common_Var.CurrentUser, ref strError);
        }


        public static bool GetCheckListByPage(ref List<CheckInfo> modelList, CheckInfo model, ref DividPage page, ref string strError)
        {
            return WMSWebService.service.GetCheckListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }


        public static bool GetCheckDetailsByID(ref CheckDetailsInfo model, ref string strError)
        {
            return WMSWebService.service.GetCheckDetailsByID(ref model, Common_Var.CurrentUser, ref strError);
        }


        public static bool GetCheckDetailsListByPage(ref List<CheckDetailsInfo> modelList, CheckDetailsInfo model, ref DividPage page, ref string strError)
        {
            return WMSWebService.service.GetCheckDetailsListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }

        public static bool GetCheckDetailsSelectListByPage(ref List<CheckDetailsInfo> modelList, CheckDetailsInfo model, ref DividPage page, ref string strError)
        {
            return WMSWebService.service.GetCheckDetailsSelectListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }

        public static bool ProfitLossAnalyse(ref List<CheckDetailsInfo> modelList, CheckDetailsInfo model, ref string strError)
        {
            return WMSWebService.service.ProfitLossAnalyse(ref modelList, model, Common_Var.CurrentUser, ref strError);
        }

        public static bool ProfitLossDeal(CheckInfo model, ref string strError)
        {
            return WMSWebService.service.ProfitLossDeal(model, Common_Var.CurrentUser, ref strError);
        }

        public static bool GetCheckAnalyseListByPage(ref List<CheckDetailsInfo> modelList, CheckDetailsInfo model, ref DividPage page, ref string strError)
        {
            return WMSWebService.service.GetCheckAnalyseListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }

        public static bool UpdateCheckStatusByID(CheckInfo model, ref string strError)
        {
            return WMSWebService.service.UpdateCheckStatusByID(model, Common_Var.CurrentUser, ref strError);
        }

        public static bool VerifyCheckStockChange(CheckInfo model, ref string strError)
        {
            return WMSWebService.service.VerifyCheckStockChange(model, Common_Var.CurrentUser, ref strError);
        }

        public static bool GetProfitLossListByPage(ref List<ProfitLossInfo> modelList, ProfitLossInfo model, ref DividPage page, ref string strError)
        {
            return WMSWebService.service.GetProfitLossListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }
        public static bool ReCheckByCheck(CheckInfo model, ref CheckInfo reCheck, ref string strError)
        {
            return WMSWebService.service.ReCheckByCheck(model, ref reCheck, Common_Var.CurrentUser, ref strError);
        }

        #endregion

    }
}
