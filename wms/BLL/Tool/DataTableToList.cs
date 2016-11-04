using System;
using System.Data;
using System.Configuration;
using System.Linq;

using System.Xml.Linq;
using System.Collections.Generic;
using System.Reflection;



namespace BLL.TOOL
{
    public class DataTableToList
    {

        public static List<T> DataSetToList<T>(DataTable p_DataTable)
        {
            if (p_DataTable == null || p_DataTable.Rows.Count < 0)
                return null;

            //DataTable p_Data = p_DataSet.Tables[p_TableIndex];
            // 返回值初始化 
            List<T> result = new List<T>();
            try
            {
                for (int j = 0; j < p_DataTable.Rows.Count; j++)
                {
                    T _t = (T)Activator.CreateInstance(typeof(T));
                    PropertyInfo[] propertys = _t.GetType().GetProperties();
                    foreach (PropertyInfo pi in propertys)
                    {
                        for (int i = 0; i < p_DataTable.Columns.Count; i++)
                        {
                            // 属性与字段名称一致的进行赋值 
                            if (pi.Name.ToLower().Equals(p_DataTable.Columns[i].ColumnName.ToLower()))
                            {
                                object value = p_DataTable.Rows[j][i];
                                // 数据库NULL值单独处理 
                                if (value != DBNull.Value)
                                {
                                    if (pi.PropertyType.FullName.ToLower().Equals("system.double")
                                        && value.GetType().ToString().ToLower().Equals("system.decimal"))//把decimal转换成double
                                    {
                                        pi.SetValue(_t, SafeConvert.DB2Double(value), null);
                                    }
                                    else if (pi.PropertyType.FullName.ToLower().Equals("system.decimal")
                                        && value.GetType().ToString().ToLower().Equals("system.double"))//把decimal转换成double
                                    {
                                        pi.SetValue(_t, SafeConvert.DB2Decimal(value), null);
                                    }
                                    else if (pi.PropertyType.FullName.ToLower().Equals("system.string")
                                       && (value.GetType().ToString().ToLower().Equals("system.int32")))
                                    {
                                        pi.SetValue(_t, SafeConvert.DB2String(value), null);
                                    }
                                    else if (pi.PropertyType.FullName.ToLower().Equals("system.int32")
                                      && (value.GetType().ToString().ToLower().Equals("system.string")))
                                    {
                                        pi.SetValue(_t, SafeConvert.DB2Int(value), null);
                                    }
                                    else if (pi.PropertyType.FullName.ToLower().Equals("system.string")
                                       && (value.GetType().ToString().ToLower().Equals("system.int64")))
                                    {
                                        pi.SetValue(_t, SafeConvert.DB2String(value), null);
                                    }
                                    else if (pi.PropertyType.FullName.ToLower().Equals("system.int32")
                                       && (value.GetType().ToString().ToLower().Equals("system.int64")))
                                    {
                                        pi.SetValue(_t, SafeConvert.DB2Int(value), null);
                                    }
                                    else if (pi.PropertyType.FullName.ToLower().Equals("system.string")
                                        && (value.GetType().ToString().ToLower().Equals("system.datetime")))
                                    {
                                        pi.SetValue(_t, value.ToString(), null);
                                    }
                                    else if (pi.PropertyType.FullName.ToLower().Equals("system.string")
                                        && (value.GetType().ToString().ToLower().Equals("system.byte")))
                                    {
                                        pi.SetValue(_t, value.ToString(), null);
                                    }
                                    else if (pi.PropertyType.FullName.ToLower().Equals("system.string")
                                        && (value.GetType().ToString().ToLower().Equals("system.int16")))
                                    {
                                        pi.SetValue(_t, value.ToString(), null);
                                    }
                                    else if (pi.PropertyType.FullName.ToLower().Equals("system.string")
                                        && (value.GetType().ToString().ToLower().Equals("system.decimal")))
                                    {
                                        pi.SetValue(_t, value.ToString(), null);
                                    }
                                    else if (pi.PropertyType.FullName.ToLower().Equals("system.string")
                                        && (value.GetType().ToString().ToLower().Equals("system.double")))
                                    {
                                        pi.SetValue(_t, value.ToString(), null);
                                    }
                                    else if (pi.PropertyType.FullName.ToLower().Equals("system.string")
                                        && (value.GetType().ToString().ToLower().Equals("system.boolean")))
                                    {
                                        pi.SetValue(_t, bool.Parse(value.ToString())?"1":"0", null);
                                    }
                                    else
                                        pi.SetValue(_t, value, null);

                                }
                                else
                                    pi.SetValue(_t, null, null);
                                break;
                            }
                        }
                    }
                    result.Add(_t);
                }
            }
            catch (Exception ex)
            {

                return null;
            }
            return result;
        }

        public static T DataRowToModel<T>(DataRow p_DataRow)
        {
            T _t = (T)Activator.CreateInstance(typeof(T));
            if (p_DataRow == null)
                return _t;
            try
            {
                PropertyInfo[] propertys = _t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    for (int i = 0; i < p_DataRow.Table.Columns.Count; i++)
                    {
                        // 属性与字段名称一致的进行赋值 
                        if (pi.Name.ToLower().Equals(p_DataRow.Table.Columns[i].ColumnName.ToLower()))
                        {
                            object value = p_DataRow[pi.Name];
                            // 数据库NULL值单独处理 
                            if (value != DBNull.Value)
                            {
                                if (pi.PropertyType.FullName.ToLower().Equals("system.double")
                                    && value.GetType().ToString().ToLower().Equals("system.decimal"))//把decimal转换成double
                                {
                                    pi.SetValue(_t, SafeConvert.DB2Double(value), null);
                                }
                                else
                                    pi.SetValue(_t, value, null);

                            }
                            else
                                pi.SetValue(_t, null, null);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
            return _t;
        }
    }
}
