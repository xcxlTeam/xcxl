using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.StorageLoc
{
    public class StorageLoc_Func
    {
        //public bool GetStorageLocByPlantForSAP(string strPlant, ref List<StorageLoc_Model> lstStorage, ref string strErrMsg) 
        //{
        //    try
        //    {
        //        StorageLoc_SAP SLA = new StorageLoc_SAP();
        //        return SLA.GetStorageLocByPlantForSAP(strPlant, ref lstStorage, ref strErrMsg);
        //    }
        //    catch (Exception ex) 
        //    {
        //        strErrMsg = ex.Message;
        //        return false;
               
        //    }
        //}

        //public string GetStorageLocByPlantForSAPToAndroid(string strPlant)
        //{
        //    StorageLocHead_Model storageLocHead=new StorageLocHead_Model();

        //    try
        //    {
        //        string strErrMsg = string.Empty;

        //        List<StorageLoc_Model> lstStorageLoc = new List<StorageLoc_Model>();
        //        StorageLoc_SAP SLA = new StorageLoc_SAP();
        //        bool bSucc= SLA.GetStorageLocByPlantForSAP(strPlant, ref lstStorageLoc, ref strErrMsg);

        //        if (bSucc == false) 
        //        {
        //            storageLocHead.Status = "E";
        //            storageLocHead.Message = strErrMsg;
        //            return JSONUtil.JSONHelper.ObjectToJson<StorageLocHead_Model>(storageLocHead);
        //        }

        //        storageLocHead.lstStorage = lstStorageLoc;
        //        storageLocHead.Status = "S";
        //        return JSONUtil.JSONHelper.ObjectToJson<StorageLocHead_Model>(storageLocHead);

        //    }
        //    catch (Exception ex)
        //    {
        //        storageLocHead.Status = "E";
        //        storageLocHead.Message = "Web异常：" + ex.Message + ex.StackTrace;
        //        return JSONUtil.JSONHelper.ObjectToJson<StorageLocHead_Model>(storageLocHead);
        //    }

        //}


    }
}
