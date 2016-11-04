using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.PrintBarcode
{
    public class Tray_Func
    {
        /// <summary>
        /// 根据托盘id获取托盘对象
        /// </summary>
        /// <param name="Barcode_Model"></param>
        /// <param name="tray"></param>
        /// <returns></returns>
        public bool GetTrayInfoByTrayID(Barcode_Model Barcode_Model, ref Tray_Model tray)
        {
            bool isResult = false;
            Tray_DB trayDB = new Tray_DB();
            isResult = trayDB.GetTrayInfoByTrayID(Barcode_Model, ref tray);
            return isResult;
        }

        public bool GetTrayInfoByTrayIDForOutStock(Barcode_Model Barcode_Model, ref Tray_Model tray)
        {
            bool isResult = false;
            Tray_DB trayDB = new Tray_DB();
            isResult = trayDB.GetTrayInfoByTrayID2(Barcode_Model, ref tray);
            return isResult;
        }

        public bool UpdateTrayInfo(string BarcodeInfo)
        {
            Barcode_Model barcodeMdl = new Barcode_Model();
            barcodeMdl=JSONUtil.JSONHelper.JsonToObject<Barcode_Model>(BarcodeInfo);
            bool isResult = false;
            isResult = UpdateTrayInfo(barcodeMdl);
            return isResult;
        }

        public string UpdateTrayInfoPro(string BarcodeInfo)
        {
            Barcode_Model barcodeMdl = new Barcode_Model();
            barcodeMdl = JSONUtil.JSONHelper.JsonToObject<Barcode_Model>(BarcodeInfo);
            bool isResult = false;
            Tray_DB trayDB = new Tray_DB();
            string strErrMsg = null;
            isResult = trayDB.UpdateTrayInfoPro(barcodeMdl, ref strErrMsg);
            return GetReturnJson(isResult, barcodeMdl, strErrMsg);
        }

        public bool UpdateTrayInfo(Barcode_Model Barcode_Model)
        {
            bool isResult = false;
            Tray_DB trayDB = new Tray_DB();
            string strErrMsg = string.Empty;
            isResult = trayDB.UpdateTrayInfo(Barcode_Model);
            return isResult;
        }

        private string GetReturnJson(bool bSucc, Barcode_Model Info, string strErrMsg)
        {
            Info.Status = bSucc == true ? "S" : "E";
            Info.Message = strErrMsg;
            return JSONUtil.JSONHelper.ObjectToJson<Barcode_Model>(Info);
        }
    }
}
