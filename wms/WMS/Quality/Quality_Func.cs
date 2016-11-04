using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.WebService;
using WMS.Common;

namespace WMS.Quality
{
    public class Quality_Func
    {
        public static bool GetQualityList(ref List<DeliveryReceive_Model> lstDelivery, DeliveryReceive_Model DeliveryModel, ref DividPage page,  ref string strErrMsg) 
        {
            return WMSWebService.service.GetQualityListByPage(ref lstDelivery, DeliveryModel, ref page, Common_Var.CurrentUser, ref strErrMsg);
        }
        
        public static bool GetQualityDetails(DeliveryReceive_Model DeliveryModel,ref List<DeliveryReceiveDetail_Model> lstDelivert,ref string strErrMsg)
        {
            return WMSWebService.service.GetQualityDetailInfo(DeliveryModel,ref lstDelivert,Common_Var.CurrentUser,ref strErrMsg);
        }

        public static bool SaveQualityDetailInfo(DeliveryReceive_Model DeliveryModel, ref string strErrMsg) 
        {
            return WMSWebService.service.SaveQualityDetailInfo(DeliveryModel, Common_Var.CurrentUser, ref strErrMsg);
        }

        public static bool GetQualityExportListByPage(ref List<QuanlityExportInfo> modelList, QuanlityExportInfo model, ref DividPage page, ref string strError)
        {
            return WMSWebService.service.GetQualityExportListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }
        
    }
}
