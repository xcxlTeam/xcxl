using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.Common
{
    internal static class ObjectExtend
    {
        public static decimal ToDecimal(this object o)
        {
            if (o == null || o == DBNull.Value) return 0;
            if (string.IsNullOrEmpty(o.ToString())) return 0;

            try
            {
                return Convert.ToDecimal(o);
            }
            catch
            {
                return 0;
            }
        }
        public static decimal? ToDecimalNull(this object o)
        {
            if (o == null || o == DBNull.Value) return null;
            if (string.IsNullOrEmpty(o.ToString())) return null;

            try
            {
                return Convert.ToDecimal(o);
            }
            catch
            {
                return null;
            }
        }

        public static DateTime ToDateTime(this object o)
        {
            if (o == null || o == DBNull.Value) return DateTime.MinValue;
            if (string.IsNullOrEmpty(o.ToString())) return DateTime.MinValue;

            try
            {
                return Convert.ToDateTime(o);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public static DateTime? ToDateTimeNull(this object o)
        {
            if (o == null || o == DBNull.Value) return null;
            if (string.IsNullOrEmpty(o.ToString())) return null;

            try
            {
                return Convert.ToDateTime(o);
            }
            catch
            {
                return null;
            }
        }

        public static int ToInt32(this object o)
        {
            if (o == null || o == DBNull.Value) return 0;
            if (string.IsNullOrEmpty(o.ToString())) return 0;

            try
            {
                return Convert.ToInt32(o);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 2为True
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int ToInt32(this bool o)
        {
            try
            {
                return o ? 2 : 1;
            }
            catch
            {
                return 1;
            }
        }

        public static int? ToIntNull(this object o)
        {
            if (o == null || o == DBNull.Value) return null;
            if (string.IsNullOrEmpty(o.ToString())) return null;

            try
            {
                return Convert.ToInt32(o);
            }
            catch
            {
                return null;
            }
        }

        public static bool ToBoolean(this object o)
        {
            if (o == null || o == DBNull.Value) return false;
            if (string.IsNullOrEmpty(o.ToString())) return false;

            try
            {
                if (o.GetType() == typeof(int) || o.GetType() == typeof(decimal))
                {
                    return o.ToInt32().ToBoolean();
                }

                return Convert.ToBoolean(o);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 2为True
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool ToBoolean(this int o)
        {
            try
            {
                return o == 2;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 2为True
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool ToBoolean(this decimal o)
        {
            try
            {
                return o == 2;
            }
            catch
            {
                return false;
            }
        }

        public static string ToDBString(this object o)
        {
            if (o == null || o == DBNull.Value)
            {
                return string.Empty;
            }
            else if (o.ToString().ToLower() == "null")
            {
                return string.Empty;
            }
            else
            {
                return o.ToString();
            }
        }

        public static string ToOracleTimeString(this object o)
        {
            if (o == null) return "NULL";

            return string.Format("TO_DATE('{0}','yyyy-mm-dd hh24:mi:ss')", o.ToDateTime().ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public static object ToOracleValue(this object o)
        {
            if (o == null)
            {
                return DBNull.Value;
            }
            else
            {
                if (o.GetType() == typeof(bool))
                {
                    return o.ToBoolean() ? 2 : 1;
                }
                else
                {
                    return o;
                }
            }
        }
    }
}
