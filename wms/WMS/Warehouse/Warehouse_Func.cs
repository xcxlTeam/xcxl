using WMS.Common;
using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Warehouse
{
    internal class Warehouse_Func
    {

        #region 临时物料

        //public static bool ExistsTempMaterialNo(TempMaterialInfo model, ref string strError)
        //{
        //    return WMSWebService.service.ExistsTempMaterialNo(model, false, Common_Var.CurrentUser, ref strError);
        //}


        public static bool SaveTempMaterial(ref TempMaterialInfo model, ref string strError)
        {
            return WMSWebService.service.SaveTempMaterial(ref model, Common_Var.CurrentUser, ref strError);
        }


        public static bool DeleteTempMaterialByID(TempMaterialInfo model, ref string strError)
        {
            return WMSWebService.service.DeleteTempMaterialByID(model, Common_Var.CurrentUser, ref strError);
        }


        public static bool GetTempMaterialByID(ref TempMaterialInfo model, ref string strError)
        {
            return WMSWebService.service.GetTempMaterialByID(ref model, Common_Var.CurrentUser, ref strError);
        }


        public static bool GetTempMaterialListByPage(ref List<TempMaterialInfo> modelList, TempMaterialInfo model, ref DividPage page, ref string strError)
        {
            //TempMaterialInfo[] modelArray = modelList.ToArray();
            //bool bResult = WMSWebService.service.GetAreaListByPage(ref modelArray, model, ref page, Common_Var.CurrentUser, ref strError);
            //if (bResult) modelList = modelArray.ToList();
            //return bResult;
            return WMSWebService.service.GetTempMaterialListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }

        public static bool GetTempMaterialNo(ref TempMaterialInfo model, ref string strError)
        {
            return WMSWebService.service.GetTempMaterialNo(ref model, Common_Var.CurrentUser, ref strError);
        }

        public static bool GetMaterialInfo(ref TempMaterialInfo model, ref string strError)
        {
            return WMSWebService.service.GetMaterialInfo(ref model, 1, Common_Var.CurrentUser, ref strError);
        }

        #endregion
    }
}
