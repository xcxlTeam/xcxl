using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.TOOL
{
    public class SafeConvert
    {
        private static DateTime err_Time = new DateTime(0001, 1, 1, 0, 0, 0, 0);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DBValue"></param>
        /// <returns></returns>
        public static string DB2String(object DBValue)
        {
            return DBValue != System.DBNull.Value ? DBValue.ToString() : "";
        }

        public static int DB2Int(object DBValue)
        {
            int iReturn = 0;
            try
            {
                if (DBValue != System.DBNull.Value) iReturn = Convert.ToInt32(DBValue);
            }
            catch
            {
                iReturn = -10;
            }
            return iReturn;
        }

        public static DateTime DB2DateTime(object DBValue)
        {
            DateTime dateReturn = err_Time;
            try
            {
                if (DBValue != System.DBNull.Value) dateReturn = Convert.ToDateTime(DBValue);
            }
            catch
            {
                dateReturn = err_Time;
            }
            return dateReturn;
        }

        public static Decimal DB2Decimal(object DBValue)
        {
            Decimal dReturn = 0;
            try
            {
                if (DBValue != System.DBNull.Value) dReturn = Convert.ToDecimal(DBValue);
            }
            catch
            {
                dReturn = -10;
            }
            return dReturn;
        }

        public static double DB2Double(object DBValue)
        {
            double dReturn = 0;
            try
            {
                if (DBValue != System.DBNull.Value) dReturn = Convert.ToDouble(DBValue);
            }
            catch
            {
                dReturn = -10;
            }
            return dReturn;
        }

        /// <summary>
        /// 取取小数点后两位值
        /// </summary>
        /// <param name="DBValue"></param>
        /// <returns></returns>
        public static Decimal DB2Decimal2(object DBValue)
        {
            Decimal dReturn = 0;
            try
            {
                if (DBValue != System.DBNull.Value)
                {
                    dReturn = Convert.ToDecimal(DBValue);
                    Decimal.Round(dReturn, 2);
                }
            }
            catch
            {
                dReturn = -10;
            }
            return dReturn;
        }

        public static Boolean DB2Bool(object DBValue)
        {
            bool blnReturn = false;
            try
            {
                if (DBValue != System.DBNull.Value) blnReturn = Convert.ToBoolean(DBValue);
            }
            catch
            {
                blnReturn = false;
            }
            return blnReturn;
        }
        /// <summary>
        /// 去除小数点后无效的零
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string RemoveTailZero(double b)//100.00->100;100.0100->100.01
        {
            string s = b.ToString();
            if (s.IndexOf(".") == -1)
                return s;
            int i, len = s.Length;
            for (i = 0; i < len; i++)
                if (s.Substring(len - 1 - i, 1) != "0")
                    break;
            if (s.Substring(len - i - 1, 1) == ".")
                return s.Substring(0, len - i - 1);
            return s.Substring(0, len - i);
        }
    }

}
