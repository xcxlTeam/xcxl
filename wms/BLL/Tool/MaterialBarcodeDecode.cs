using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BLL.TOOL
{
    public class MaterialBarcodeDecode
    {
        private static int BarcodeType = 0;
        private static int SerialNo = 5;


        /// <summary>
        /// 检测条码是否为有效条码
        /// </summary>
        /// <param name="strBarcode"></param>
        /// <returns></returns>
        public static bool InvalidBarcode(string strBarcode)
        {
            string[] strSplit = strBarcode.Split('@');

            if (strSplit.Length == 6 || strSplit.Length == 7) return true;
            else return false;
        }

        /// <summary>
        /// 判断是否二维码
        /// </summary>
        /// <param name="strBarcode"></param>
        /// <returns></returns>
        public static bool InvalidTwoBarcode(string strBarcode)
        {
            string[] strSplit = strBarcode.Split('@');

            if (strSplit.Length == 2) return true;//二维码
            else return false;
        }

        /// <summary>
        /// 获取条码类型，10-外箱条码 20-内盒条码
        /// </summary>
        /// <param name="strBarcode"></param>
        /// <returns></returns>
        public static string GetBarcodeType(string strBarcode)
        {
            string[] strSplit = strBarcode.Split('@');
            return strSplit[BarcodeType];
        }

        /// <summary>
        /// 获取流水号
        /// </summary>
        /// <param name="strBarcode"></param>
        /// <returns></returns>
        public static string GetSerialNo(string strBarcode)
        {
            string[] strSplit = strBarcode.Split('@');
            if (strSplit.Length == 6)
                return strSplit[SerialNo];
            else
                return strSplit[SerialNo] + strSplit[SerialNo+1];

        }



    }
}
