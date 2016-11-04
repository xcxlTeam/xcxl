using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using NPOI.HSSF.UserModel;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Diagnostics;
using NPOI.OpenXmlFormats.Spreadsheet;

namespace ExcelLibrary
{
    public class ExcelLibrary_Func
    {
        private const string pukey = "12345678";
        private const string pvkey = "abcdefg";
        private readonly static DateTime ExcelMinDate = new DateTime(1899, 12, 31);

        #region 公共方法
        /// <summary>
        /// 弹出保存对话框
        /// </summary>
        /// <param name="strFileName">保存文件路径</param>
        /// <returns>是否保存</returns>
        public static bool ShowSaveToExcelDialog(ref string strFileName)
        {
            //申明保存对话框   
            SaveFileDialog dlg = new SaveFileDialog();
            //默认文件后缀   
            dlg.DefaultExt = "xlsx ";
            //文件后缀列表   
            dlg.Filter = "EXCEL 工作簿(*.XLSX,*.XLS)|*.xlsx;*.xls|所有文件(*.*)|*.* ";
            //默然路径是桌面路径   
            if (string.IsNullOrEmpty(strFileName))
            {
                strFileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                dlg.InitialDirectory = strFileName;
            }
            else if (Directory.Exists(strFileName))
            {
                dlg.InitialDirectory = strFileName;
            }
            else if (File.Exists(strFileName))
            {
                dlg.InitialDirectory = Path.GetDirectoryName(strFileName);
                dlg.FileName = Path.GetFileName(strFileName);
            }
            else
            {
                if (strFileName.IndexOf('/') == -1 && strFileName.IndexOf('\\') == -1)
                {
                    strFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), strFileName);
                }
                dlg.FileName = strFileName;
                dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            //打开保存对话框   
            if (dlg.ShowDialog() == DialogResult.Cancel) return false;
            //返回文件路径   
            strFileName = dlg.FileName;
            File.Delete(strFileName);

            return true;
        }

        /// <summary>
        /// 弹出打开对话框
        /// </summary>
        /// <param name="strFileName">打开文件路径</param>
        /// <returns>是否打开</returns>
        public static bool ShowOpenForExcelDialog(ref string strFileName)
        {
            //申明打开对话框   
            OpenFileDialog dlg = new OpenFileDialog();
            //默认文件后缀   
            dlg.DefaultExt = "xlsx ";
            //文件后缀列表
            dlg.Filter = "EXCEL 工作簿(*.XLSX,*.XLS)|*.xlsx;*.xls|所有文件(*.*)|*.* ";
            //默然路径是桌面路径   
            if (string.IsNullOrEmpty(strFileName))
            {
                strFileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                dlg.InitialDirectory = strFileName;
            }
            else if (Directory.Exists(strFileName))
            {
                dlg.InitialDirectory = strFileName;
            }
            else if (File.Exists(strFileName))
            {
                dlg.InitialDirectory = Path.GetDirectoryName(strFileName);
                dlg.FileName = Path.GetFileName(strFileName);
            }
            else
            {
                if (strFileName.IndexOf('/') == -1 && strFileName.IndexOf('\\') == -1)
                {
                    strFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), strFileName);
                }
                dlg.FileName = strFileName;
                dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            //检查文件是否存在
            dlg.CheckFileExists = true;
            dlg.CheckPathExists = true;
            //打开打开对话框   
            if (dlg.ShowDialog() == DialogResult.Cancel) return false;
            //返回文件路径  
            strFileName = dlg.FileName;
            return true;
        }

        /// <summary>
        /// DataTable是否存在DataColumn
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="columnName">列名</param>
        /// <returns>是否存在</returns>
        public static bool IsExistsDataColumn(DataTable dt, string columnName)
        {
            if (dt == null) return false;
            if (dt.Columns.Count <= 0) return false;

            try
            {
                return dt.Columns.IndexOf(columnName) >= 0;
            }
            catch { return false; }
        }

        /// <summary>
        /// 获取DataTable新列名
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="columnName">重复列名</param>
        /// <returns>新列名</returns>
        public static string GetNewDataColumnName(DataTable dt, string columnName)
        {
            int suffix = 1;
            while (IsExistsDataColumn(dt, columnName + suffix.ToString())) suffix++;
            return columnName + suffix.ToString();
        }

        /// <summary>
        /// 对象属性赋值
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="pi">对象属性</param>
        /// <param name="t">对象</param>
        /// <param name="value">属性值</param>
        /// <param name="pType">属性类型</param>
        public static void SetPropertyValue<T>(PropertyInfo pi, T t, object value, string pType = "") where T : new()
        {
            if (string.IsNullOrEmpty(pType)) pType = pi.PropertyType.Name;
            pType = pType.ToLower();
            switch (pType)
            {
                case "string":
                    pi.SetValue(t, value.ToString(), null);
                    break;
                case "byte":
                    pi.SetValue(t, Convert.ToByte(value), null);
                    break;
                case "int16":
                    pi.SetValue(t, Convert.ToInt16(value), null);
                    break;
                case "int":
                case "int32":
                    pi.SetValue(t, Convert.ToInt32(value), null);
                    break;
                case "int64":
                    pi.SetValue(t, Convert.ToInt64(value), null);
                    break;
                case "decimal":
                    pi.SetValue(t, Convert.ToDecimal(value), null);
                    break;
                case "double":
                    pi.SetValue(t, Convert.ToDouble(value), null);
                    break;
                case "bool":
                    pi.SetValue(t, Convert.ToBoolean(value), null);
                    break;
                case "datetime":
                    pi.SetValue(t, Convert.ToDateTime(value), null);
                    break;
                case "nullable`1":  // 可为null类型
                    if (value == null)
                        pi.SetValue(t, null, null);
                    else
                        SetPropertyValue<T>(pi, t, value, pi.PropertyType.GetGenericArguments()[0].Name);
                    break;
                default:
                    break;
            }
        }

        /// <summary>   
        /// 加密方法   
        /// </summary>   
        /// <param name="Source">待加密的串</param>   
        /// <returns>经过加密的串</returns>   
        public static string Encrypto(string Source)
        {

            try
            {
                if (string.IsNullOrEmpty(Source))
                {

                    return "";

                }

                string strCipherText = "";
                byte[] inputByteArray;
                inputByteArray = Encoding.Default.GetBytes(Source);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                des.Key = ASCIIEncoding.ASCII.GetBytes(pukey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(pvkey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                StringBuilder ret = new StringBuilder();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                strCipherText = ret.ToString();
                return strCipherText;
            }
            catch
            {
                return "";

            }
        }

        /// <summary>   
        /// 解密方法   
        /// </summary>   
        /// <param name="Source">待解密的串</param>   
        /// <returns>经过解密的串</returns>   
        public static string Decrypto(string Source)
        {
            if (string.IsNullOrEmpty(Source))
            {

                return "";

            }

            try
            {
                if (string.IsNullOrEmpty(Source) || Source.Length <= 0)
                    return null;

                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                int len;
                len = Source.Length / 2;
                byte[] inputByteArray = new byte[len];
                int x, i;
                for (x = 0; x < len; x++)
                {
                    i = Convert.ToInt32(Source.Substring(x * 2, 2), 16);
                    inputByteArray[x] = (byte)i;
                }
                des.Key = ASCIIEncoding.ASCII.GetBytes(pukey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(pvkey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Encoding.Default.GetString(ms.ToArray());
            }
            catch
            {
                return "";

            }
        }

        /// <summary>
        /// 弹出保存对话框
        /// </summary>
        /// <param name="strFileName">保存文件路径</param>
        /// <returns>是否保存</returns>
        public static bool ShowSaveToSqlDialog(ref string strFileName)
        {
            //申明保存对话框   
            SaveFileDialog dlg = new SaveFileDialog();
            //默认文件后缀   
            dlg.DefaultExt = "sql ";
            //文件后缀列表   
            dlg.Filter = "SQL 脚本(*.SQL,*.TXT)|*.sql;*.txt|所有文件(*.*)|*.* ";
            //默然路径是桌面路径   
            if (string.IsNullOrEmpty(strFileName))
            {
                strFileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                dlg.InitialDirectory = strFileName;
            }
            else if (Directory.Exists(strFileName))
            {
                dlg.InitialDirectory = strFileName;
            }
            else if (File.Exists(strFileName))
            {
                dlg.InitialDirectory = Path.GetDirectoryName(strFileName);
                dlg.FileName = Path.GetFileName(strFileName);
            }
            else
            {
                if (strFileName.IndexOf('/') == -1 && strFileName.IndexOf('\\') == -1)
                {
                    strFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), strFileName);
                }
                dlg.FileName = strFileName;
                dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            //打开保存对话框   
            if (dlg.ShowDialog() == DialogResult.Cancel) return false;
            //返回文件路径   
            strFileName = dlg.FileName;
            return true;
        }

        public static bool WriteSqlListToText(List<string> lstSql)
        {
            string fileNameString = string.Empty;
            if (!ShowSaveToSqlDialog(ref fileNameString)) return false;

            return WriteSqlListToText(fileNameString, lstSql);
        }

        public static bool WriteSqlListToText(string fileNameString, List<string> lstSql)
        {
            using (StreamWriter sw = new StreamWriter(fileNameString, false))
            {
                foreach (string sql in lstSql)
                {
                    sw.WriteLine(sql + ";");
                }

                sw.Close();
            }

            MessageBox.Show(fileNameString + "\n\n写入完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }
        #endregion


        #region 私有方法

        /// <summary>
        /// 设置Excel单元格的值给对象属性
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="pi">对象属性</param>
        /// <param name="t">对象</param>
        /// <param name="cell">Excel单元格</param>
        private static void SetPropertyByICell<T>(PropertyInfo pi, T t, ICell cell) where T : new()
        {
            try
            {
                if (cell == null) return;

                object cellvalue;
                switch (cell.CellType)
                {
                    case CellType.Numeric:
                    case CellType.Boolean:
                    case CellType.String:
                    case CellType.Blank:
                        cellvalue = GetValueByICell(cell);
                        SetPropertyValue<T>(pi, t, cellvalue);
                        break;

                    default:
                        break;
                }
            }
            catch { }
        }

        /// <summary>
        /// 获取工作薄的工作表名
        /// </summary>
        /// <param name="filename">工作簿地址</param>
        /// <returns>工作表名</returns>
        private List<string> GetSheets(string filename)
        {
            XSSFWorkbook workbook = new XSSFWorkbook(File.Open(filename, FileMode.Open));
            List<string> list = new List<string>();
            foreach (var item in workbook.GetCTWorkbook().sheets.sheet)
            {
                list.Add(item.name);
            }

            return list;
        }

        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="sheet">Excel工作表</param>
        /// <param name="rowstart">开始行</param>
        /// <param name="rowend">结束行</param>
        /// <param name="colstart">开始列</param>
        /// <param name="colend">结束列</param>
        private static void SetCellRangeAddress(ISheet sheet, int rowstart, int rowend, int colstart, int colend)
        {
            NPOI.SS.Util.CellRangeAddress cellRangeAddress = new NPOI.SS.Util.CellRangeAddress(rowstart, rowend, colstart, colend);
            sheet.AddMergedRegion(cellRangeAddress);
        }

        /// <summary>
        /// 获取Excel单元格的值
        /// </summary>
        /// <param name="cell">Excel单元格</param>
        /// <returns>单元格的值</returns>
        private static object GetValueByICell(ICell cell)
        {
            if (cell == null) return null;

            //cell.SetCellType(CellType.String);
            switch (cell.CellType)
            {
                case CellType.Numeric:
                    if (CellValueIsDate(cell))
                    {
                        return cell.DateCellValue;
                    }
                    else
                    {
                        return cell.NumericCellValue;
                    }

                case CellType.Boolean:
                    return cell.BooleanCellValue;

                case CellType.String:
                    return cell.StringCellValue;

                default:
                    return null;
            }
        }

        /// <summary>
        /// 判断Numeric单元格是否是时间
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static bool CellValueIsDate(ICell cell)
        {
            if (cell == null) return false;

            if (DateUtil.IsCellDateFormatted(cell) && DateUtil.IsValidExcelDate(cell.NumericCellValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 转换Oracle日期格式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool TransferOracleDate(ref object value)
        {
            if (value == null) return false;
            if (string.IsNullOrEmpty(value.ToString())) return false;
            if (!IsDateTimeFormat(value.ToString())) return false;
            //if (!IsComplexDateTime(value.ToString())) return false;

            try
            {
                DateTime t = Convert.ToDateTime(value);
                if (t <= DateTime.MinValue)
                {
                    value = "NULL";
                    return false;
                }
                else
                {
                    value = string.Format("TO_DATE('{0}','yyyy-mm-dd hh24:mi:ss')", t.ToString("yyyy-MM-dd HH:mm:ss"));
                    return true;
                }
            }
            catch { return false; }
        }
        /// <summary>
        /// 是否小数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?/d*[.]?/d*$");
        }
        /// <summary>
        /// 是否整型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsInt(string value)
        {
            return Regex.IsMatch(value, @"^[0-9]*$");
        }
        /// <summary>
        /// 是否无符号整型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsUnsign(string value)
        {
            return Regex.IsMatch(value, @"^/d*[.]?/d*$");
        }
        /// <summary>
        /// 是否为日期型字符串
        /// </summary>
        /// <param name="value">日期字符串(2008-05-08)</param>
        /// <returns></returns>
        private static bool IsDate(string value)
        {
            return Regex.IsMatch(value, @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$");
        }
        /// <summary>
        /// 是否为时间型字符串
        /// </summary>
        /// <param name="value">时间字符串(15:00:00)</param>
        /// <returns></returns>
        private static bool IsTime(string value)
        {
            return Regex.IsMatch(value, @"^((20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)$");
        }
        /// <summary>
        /// 是否为日期+时间型字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsDateTime(string value)
        {
            return
                Regex.IsMatch(value, @"^(((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)$ ");
        }

        private static bool IsDateTimeFormat(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            if (value.IndexOf(':') < 0) return false;

            value = value.Replace("/", "-");
            string[] arr = value.Split('-');
            if (arr.Length != 3) return false;

            if (!IsInt(arr[0]) || !IsInt(arr[1])) return false;

            return true;
        }

        /// <summary>
        /// 使用正则表达式判断是否为复杂日期类型
        /// </summary>
        /// <param name="str" type=string></param>
        /// <returns name="isDateTime" type=bool></returns>
        private static bool IsComplexDateTime(string value)
        {
            bool isDateTime = false;

            if (IsTime(value))
                isDateTime = true;
            else if (IsDateTime(value))
                isDateTime = true;
            // yyyy/MM/dd
            else if (Regex.IsMatch(value, "^(?<year>\\d{2,4})/(?<month>\\d{1,2})/(?<day>\\d{1,2})$"))
                isDateTime = true;
            // yyyy-MM-dd 
            else if (Regex.IsMatch(value, "^(?<year>\\d{2,4})-(?<month>\\d{1,2})-(?<day>\\d{1,2})$"))
                isDateTime = true;
            // yyyy.MM.dd 
            else if (Regex.IsMatch(value, "^(?<year>\\d{2,4})[.](?<month>\\d{1,2})[.](?<day>\\d{1,2})$"))
                isDateTime = true;
            // yyyy年MM月dd日
            else if (Regex.IsMatch(value, "^((?<year>\\d{2,4})年)?(?<month>\\d{1,2})月((?<day>\\d{1,2})日)?$"))
                isDateTime = true;
            // yyyy年MM月dd日
            else if (Regex.IsMatch(value, "^((?<year>\\d{2,4})年)?(正|一|二|三|四|五|六|七|八|九|十|十一|十二)月((一|二|三|四|五|六|七|八|九|十){1,3}日)?$"))
                isDateTime = true;

            // yyyy年MM月dd日
            else if (Regex.IsMatch(value, "^(零|〇|一|二|三|四|五|六|七|八|九|十){2,4}年((正|一|二|三|四|五|六|七|八|九|十|十一|十二)月((一|二|三|四|五|六|七|八|九|十){1,3}(日)?)?)?$"))
                isDateTime = true;
            // yyyy年
            //else if (Regex.IsMatch(str, "^(?<year>\\d{2,4})年$"))
            //    isDateTime = true;

            // 农历1
            else if (Regex.IsMatch(value, "^(甲|乙|丙|丁|戊|己|庚|辛|壬|癸)(子|丑|寅|卯|辰|巳|午|未|申|酉|戌|亥)年((正|一|二|三|四|五|六|七|八|九|十|十一|十二)月((一|二|三|四|五|六|七|八|九|十){1,3}(日)?)?)?$"))
                isDateTime = true;
            // 农历2
            else if (Regex.IsMatch(value, "^((甲|乙|丙|丁|戊|己|庚|辛|壬|癸)(子|丑|寅|卯|辰|巳|午|未|申|酉|戌|亥)年)?(正|一|二|三|四|五|六|七|八|九|十|十一|十二)月初(一|二|三|四|五|六|七|八|九|十)$"))
                isDateTime = true;

            // XX时XX分XX秒
            else if (Regex.IsMatch(value, "^(?<hour>\\d{1,2})(时|点)(?<minute>\\d{1,2})分((?<second>\\d{1,2})秒)?$"))
                isDateTime = true;
            // XX时XX分XX秒
            else if (Regex.IsMatch(value, "^((零|一|二|三|四|五|六|七|八|九|十){1,3})(时|点)((零|一|二|三|四|五|六|七|八|九|十){1,3})分(((零|一|二|三|四|五|六|七|八|九|十){1,3})秒)?$"))
                isDateTime = true;
            // XX分XX秒
            else if (Regex.IsMatch(value, "^(?<minute>\\d{1,2})分(?<second>\\d{1,2})秒$"))
                isDateTime = true;
            // XX分XX秒
            else if (Regex.IsMatch(value, "^((零|一|二|三|四|五|六|七|八|九|十){1,3})分((零|一|二|三|四|五|六|七|八|九|十){1,3})秒$"))
                isDateTime = true;

            // XX时
            else if (Regex.IsMatch(value, "\\b(?<hour>\\d{1,2})(时|点钟)\\b"))
                isDateTime = true;
            else
                isDateTime = false;

            return isDateTime;
        }

        /// <summary>
        /// 是否数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool ObjectIsNumeric(object value)
        {
            if (value == null) return false;
            if (string.IsNullOrEmpty(value.ToString())) return false;
            if (value is decimal || value is double || value is float) return true;
            if (!IsNumeric(value.ToString()) && !IsInt(value.ToString()) && !IsUnsign(value.ToString())) return false;

            try { Convert.ToDouble(value); }
            catch { return false; }
            return true;
        }

        /// <summary>
        /// 矫正错误的保存日期
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool CheckErrorDate(ref string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            if (!IsDateTimeFormat(value)) return false;
            if (!IsComplexDateTime(value.ToString())) return false;

            try
            {
                DateTime t = Convert.ToDateTime(value);
                if (t <= DateTime.MinValue)
                {
                    value = "";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch { return false; }
        }

        private static bool DataTableExists(DataSet ds, string tableName)
        {
            if (string.IsNullOrEmpty(tableName)) return false;

            foreach (DataTable dt in ds.Tables)
            {
                if (dt.TableName.ToUpper() == tableName.ToUpper()) return true;
            }
            return false;
        }

        private static bool DataColumnExists(DataTable dt, string columnName)
        {
            if (string.IsNullOrEmpty(columnName)) return false;

            foreach (DataColumn dc in dt.Columns)
            {
                if (dc.ColumnName.ToUpper() == columnName.ToUpper()) return true;
            }
            return false;
        }

        /// <summary>
        /// 初始化Excel参数 (.xls)
        /// </summary>
        /// <param name="fileNameString">文件路径(含完整文件名)</param>
        /// <param name="sheetname">工作表名</param>
        /// <param name="file">Excel文件对象</param>
        /// <param name="cellCount">总列数</param>
        /// <param name="rowCount">总行数</param>
        /// <param name="workbook">Excel工作簿</param>
        /// <param name="sheet">Excel工作表</param>
        /// <param name="headerRow">工作表首行</param>
        private static void InitHSSF(string fileNameString, ref string sheetname, ref FileStream file, ref int cellCount, ref int rowCount, out HSSFWorkbook workbook, out HSSFSheet sheet, out HSSFRow headerRow)
        {
            file = File.Open(fileNameString, FileMode.Open);
            //根据路径通过已存在的excel来创建HSSFWorkbook，即整个excel文档
            workbook = new HSSFWorkbook(file);
            //获取工作表
            sheet = (HSSFSheet)workbook.GetSheet(sheetname);
            //获取excel的第一个hsheet
            if (sheet == null) { sheetname = workbook.GetSheetAt(0).SheetName; sheet = (HSSFSheet)workbook.GetSheet(sheetname); }
            //获取hsheet的首行
            headerRow = (HSSFRow)sheet.GetRow(0);
            if (headerRow == null)
            {
                throw new Exception(sheetname + "工作簿没有数据");
            }
            //一行最后一个方格的编号 即总的列数
            cellCount = headerRow.LastCellNum;
            //最后一列的标号  即总的行数
            rowCount = sheet.LastRowNum;
            if (rowCount <= 0)
            {
                throw new Exception(sheetname + "工作簿数据格式不正确");
            }
        }
        /// <summary>
        /// 初始化Excel参数 (.xlsx)
        /// </summary>
        /// <param name="fileNameString">文件路径(含完整文件名)</param>
        /// <param name="sheetname">工作表名</param>
        /// <param name="file">Excel文件对象</param>
        /// <param name="cellCount">总列数</param>
        /// <param name="rowCount">总行数</param>
        /// <param name="workbook">Excel工作簿</param>
        /// <param name="sheet">Excel工作表</param>
        /// <param name="headerRow">工作表首行</param>
        private static void InitXSSF(string fileNameString, ref string sheetname, ref FileStream file, ref int cellCount, ref int rowCount, out XSSFWorkbook workbook, out XSSFSheet sheet, out XSSFRow headerRow)
        {
            file = File.Open(fileNameString, FileMode.Open);
            //根据路径通过已存在的excel来创建XSSFWorkbook，即整个excel文档
            workbook = new XSSFWorkbook(file);
            //获取工作表
            sheet = (XSSFSheet)workbook.GetSheet(sheetname);
            //获取excel的第一个sheet
            if (sheet == null) { sheetname = workbook.GetCTWorkbook().sheets.sheet[0].name; sheet = (XSSFSheet)workbook.GetSheet(sheetname); }
            //获取sheet的首行
            headerRow = (XSSFRow)sheet.GetRow(0);
            if (headerRow == null)
            {
                throw new Exception(sheetname + "工作簿没有数据");
            }
            //一行最后一个方格的编号 即总的列数
            cellCount = headerRow.LastCellNum;
            //最后一列的标号  即总的行数
            rowCount = sheet.LastRowNum;
            if (rowCount <= 0)
            {
                throw new Exception(sheetname + "工作簿数据格式不正确");
            }
        }

        #endregion


        /// <summary>
        /// 附加DataSet数据到Excel
        /// </summary>
        /// <param name="fileNameString">保存路径</param>
        /// <param name="ds">数据源</param>
        /// <param name="haveborder">是否有边框</param>
        /// <param name="excludecol">需要排除的列名 多个列名用,分隔</param>
        /// <param name="f">列头字体样式</param>
        /// <returns>保存结果</returns>
        public static bool AddDataSetToExcelByNPOI(string fileNameString, DataSet ds, bool haveborder = true, string excludecol = "", Font f = null)
        {
            if (!File.Exists(fileNameString))
            {
                MessageBox.Show(fileNameString + " 文件不存在\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string filename = Path.GetFullPath(fileNameString);
            string extensname = Path.GetExtension(fileNameString);
            bool isXSSF = extensname.ToLower() == (".xlsx");
            FileStream file = File.Open(fileNameString, FileMode.OpenOrCreate);
            string tempNameString = string.Format("{0}{1}{2}", filename, "_temp", extensname);

            excludecol = excludecol.ToLower();
            if (!string.IsNullOrEmpty(excludecol) && !excludecol.EndsWith(",")) excludecol += ',';
            try
            {
                using (FileStream ms = File.Open(tempNameString, FileMode.Create))
                {
                    if (isXSSF)
                    {
                        #region XLSX

                        XSSFWorkbook workbook = new XSSFWorkbook(file);
                        XSSFSheet sheet;

                        foreach (DataTable dt in ds.Tables)
                        {
                            if (workbook.GetSheet(dt.TableName) != null)
                            {
                                workbook.RemoveSheetAt(workbook.GetSheetIndex(dt.TableName));
                            }
                            sheet = (XSSFSheet)workbook.CreateSheet(dt.TableName);
                            int minWidth = 5;
                            int maxWidth = 255;
                            int[] arrColWidth = new int[dt.Columns.Count];

                            #region 表头信息

                            IRow headRow = sheet.CreateRow(0);
                            int headcol = 0;
                            foreach (DataColumn dc in dt.Columns)
                            {
                                if (excludecol.IndexOf(dc.ColumnName.ToLower() + ',') >= 0) continue;

                                arrColWidth[headcol] = Encoding.GetEncoding(936).GetBytes(dc.ColumnName.ToString()).Length;
                                if (arrColWidth[headcol] >= maxWidth) arrColWidth[headcol] = maxWidth - 1;
                                headRow.CreateCell(headcol++).SetCellValue(dc.ColumnName);
                            }

                            #endregion

                            #region 表体数据

                            int bodyrow = 1;
                            int bodycol;
                            string bodyvalue;
                            int bodycolwidth;
                            IRow dataRow;
                            XSSFCellStyle dataStyle;
                            dataStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                            dataStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                            dataStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                            dataStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                            dataStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                            dataStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
                            foreach (DataRow dr in dt.Rows)
                            {
                                dataRow = sheet.CreateRow(bodyrow++);

                                bodycol = 0;
                                foreach (DataColumn dc in dt.Columns)
                                {
                                    if (excludecol.IndexOf(dc.ColumnName.ToLower() + ',') >= 0) continue;

                                    bodyvalue = (dr[dc.ColumnName] == null || dr[dc.ColumnName] == DBNull.Value ? "" : dr[dc.ColumnName].ToString());
                                    bodycolwidth = Encoding.GetEncoding(936).GetBytes(bodyvalue).Length;
                                    if (bodycolwidth >= maxWidth) bodycolwidth = maxWidth - 1;
                                    if (bodycolwidth >= arrColWidth[bodycol]) arrColWidth[bodycol] = bodycolwidth;

                                    if (ObjectIsNumeric(bodyvalue)) dataRow.CreateCell(bodycol).SetCellValue(Convert.ToDouble(bodyvalue));
                                    else dataRow.CreateCell(bodycol).SetCellValue(bodyvalue);
                                    if (haveborder)
                                    {
                                        dataRow.GetCell(bodycol).CellStyle = dataStyle;
                                    }

                                    bodycol++;
                                }
                            }

                            #endregion

                            #region 表格样式

                            XSSFCellStyle headStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                            headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                            headStyle.VerticalAlignment = VerticalAlignment.Center;
                            if (haveborder)
                            {
                                headStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                                headStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                                headStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                                headStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                            }
                            XSSFFont font;
                            font = (XSSFFont)workbook.CreateFont();
                            if (f == null)
                            {
                                font.Boldweight = 800;
                                font.IsBold = true;
                                font.IsItalic = false;
                                //font.FontName = "Arial";
                                font.FontHeightInPoints = 12;
                                //font.Underline = FontUnderlineType.None;
                            }
                            else
                            {
                                font.Boldweight = 800;
                                font.IsBold = f.Bold;
                                font.IsItalic = f.Italic;
                                font.FontName = f.IsSystemFont ? f.SystemFontName : f.Name;
                                if (f.Underline) font.Underline = FontUnderlineType.Single;
                                font.FontHeightInPoints = (short)(f.SizeInPoints >= font.FontHeightInPoints ? Math.Ceiling(f.SizeInPoints) : font.FontHeightInPoints);
                            }
                            headStyle.SetFont(font);

                            for (int col = 0; col < headRow.Cells.Count; col++)
                            {
                                headRow.GetCell(col).CellStyle = headStyle;
                                sheet.SetColumnWidth(col, ((arrColWidth[col] >= minWidth ? arrColWidth[col] : minWidth) + 1) * 300);
                            }

                            #endregion
                        }


                        workbook.Write(ms);
                        //ms.Flush();
                        workbook = null;
                        sheet = null;
                        #endregion
                    }
                    else
                    {
                        #region XLS

                        HSSFWorkbook workbook = new HSSFWorkbook(file);
                        HSSFSheet sheet;

                        foreach (DataTable dt in ds.Tables)
                        {
                            if (workbook.GetSheet(dt.TableName) != null)
                            {
                                workbook.RemoveSheetAt(workbook.GetSheetIndex(dt.TableName));
                            }
                            sheet = (HSSFSheet)workbook.CreateSheet(dt.TableName);
                            int minWidth = 5;
                            int maxWidth = 255;
                            int[] arrColWidth = new int[dt.Columns.Count];

                            #region 表头信息

                            IRow headRow = sheet.CreateRow(0);
                            int headcol = 0;
                            foreach (DataColumn dc in dt.Columns)
                            {
                                if (excludecol.IndexOf(dc.ColumnName.ToLower() + ',') >= 0) continue;

                                arrColWidth[headcol] = Encoding.GetEncoding(936).GetBytes(dc.ColumnName.ToString()).Length;
                                if (arrColWidth[headcol] >= maxWidth) arrColWidth[headcol] = maxWidth - 1;
                                headRow.CreateCell(headcol++).SetCellValue(dc.ColumnName);
                            }

                            #endregion

                            #region 表体数据

                            int bodyrow = 1;
                            int bodycol;
                            string bodyvalue;
                            int bodycolwidth;
                            IRow dataRow;
                            HSSFCellStyle dataStyle;
                            dataStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                            dataStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                            dataStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                            dataStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                            dataStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                            dataStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
                            foreach (DataRow dr in dt.Rows)
                            {
                                dataRow = sheet.CreateRow(bodyrow++);

                                bodycol = 0;
                                foreach (DataColumn dc in dt.Columns)
                                {
                                    if (excludecol.IndexOf(dc.ColumnName.ToLower() + ',') >= 0) continue;

                                    bodyvalue = (dr[dc.ColumnName] == null || dr[dc.ColumnName] == DBNull.Value ? "" : dr[dc.ColumnName].ToString());
                                    bodycolwidth = Encoding.GetEncoding(936).GetBytes(bodyvalue).Length;
                                    if (bodycolwidth >= maxWidth) bodycolwidth = maxWidth - 1;
                                    if (bodycolwidth >= arrColWidth[bodycol]) arrColWidth[bodycol] = bodycolwidth;

                                    if (ObjectIsNumeric(bodyvalue)) dataRow.CreateCell(bodycol).SetCellValue(Convert.ToDouble(bodyvalue));
                                    else dataRow.CreateCell(bodycol).SetCellValue(bodyvalue);
                                    if (haveborder)
                                    {
                                        dataRow.GetCell(bodycol).CellStyle = dataStyle;
                                    }

                                    bodycol++;
                                }
                            }

                            #endregion

                            #region 表格样式

                            HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                            headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                            headStyle.VerticalAlignment = VerticalAlignment.Center;
                            if (haveborder)
                            {
                                headStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                                headStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                                headStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                                headStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                            }
                            HSSFFont font;
                            font = (HSSFFont)workbook.CreateFont();
                            if (f == null)
                            {
                                font.Boldweight = 800;
                                //font.IsBold = true;
                                font.IsItalic = false;
                                //font.FontName = "Arial";
                                font.FontHeightInPoints = 12;
                                //font.Underline = FontUnderlineType.None;
                            }
                            else
                            {
                                font.Boldweight = 800;
                                //font.IsBold = f.Bold;
                                font.IsItalic = f.Italic;
                                font.FontName = f.IsSystemFont ? f.SystemFontName : f.Name;
                                if (f.Underline) font.Underline = FontUnderlineType.Single;
                                font.FontHeightInPoints = (short)(f.SizeInPoints >= font.FontHeightInPoints ? Math.Ceiling(f.SizeInPoints) : font.FontHeightInPoints);
                            }
                            headStyle.SetFont(font);

                            for (int col = 0; col < headRow.Cells.Count; col++)
                            {
                                headRow.GetCell(col).CellStyle = headStyle;
                                sheet.SetColumnWidth(col, ((arrColWidth[col] >= minWidth ? arrColWidth[col] : minWidth) + 1) * 300);
                            }

                            #endregion
                        }

                        workbook.Write(ms);
                        //ms.Flush();
                        workbook = null;
                        sheet = null;
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (file != null) file.Dispose();
                file = null;
            }

            File.Copy(tempNameString, fileNameString, true);
            File.Delete(tempNameString);

            return true;
        }

        #region SaveToExcel
        /// <summary>
        /// 保存自定义数据到Excel
        /// </summary>
        /// <param name="lst">数据源</param>
        /// <returns>保存结果</returns>
        public static bool SaveCustomizeToExcelByNPOI(List<ExcelLibrary_Model> lst)
        {
            string fileNameString = string.Empty;
            if (!ShowSaveToExcelDialog(ref fileNameString)) return false;

            return SaveCustomizeToExcelByNPOI(fileNameString, lst);
        }

        public static bool SaveCustomizeToExcelByNPOI(ref string fileNameString, List<ExcelLibrary_Model> lst, bool HintOpen = false)
        {
            if (!ShowSaveToExcelDialog(ref fileNameString)) return false;

            if (SaveCustomizeToExcelByNPOI(fileNameString, lst))
            {
                if (HintOpen)
                {
                    if (MessageBox.Show(string.Format("是否打开文件{0}【{1}】?", Environment.NewLine, fileNameString), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                        Process.Start(fileNameString);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool SaveCustomizeToExcelByNPOI(string fileNameString, List<ExcelLibrary_Model> lst)
        {
            using (FileStream ms = File.Open(fileNameString, FileMode.OpenOrCreate))
            {
                XSSFWorkbook book = new XSSFWorkbook();
                ISheet sheet = book.CreateSheet("Sheet1");

                #region 填充内容

                int contextEndRow = 0;
                if (lst != null && lst.Count >= 1)
                {
                    IRow contextRow;
                    XSSFCellStyle contextStyle;
                    XSSFFont contextFont;
                    foreach (ExcelLibrary_Model cell in lst)
                    {
                        if (cell.RowIndex + cell.RowSpan >= contextEndRow) contextEndRow = cell.RowIndex + cell.RowSpan;

                        contextRow = sheet.CreateRow(cell.RowIndex);
                        contextRow.Height = (short)(cell.Height * 20);
                        contextStyle = (XSSFCellStyle)book.CreateCellStyle();
                        contextStyle.Alignment = (NPOI.SS.UserModel.HorizontalAlignment)cell.Alignment;
                        contextStyle.VerticalAlignment = (NPOI.SS.UserModel.VerticalAlignment)cell.VerticalAlignment;
                        contextStyle.BorderTop = (NPOI.SS.UserModel.BorderStyle)cell.BorderTop;
                        contextStyle.BorderLeft = (NPOI.SS.UserModel.BorderStyle)cell.BorderLeft;
                        contextStyle.BorderRight = (NPOI.SS.UserModel.BorderStyle)cell.BorderRight;
                        contextStyle.BorderBottom = (NPOI.SS.UserModel.BorderStyle)cell.BorderBottom;

                        if (cell.CellFont != null)
                        {
                            contextFont = (XSSFFont)book.CreateFont();
                            contextFont.Boldweight = 800;
                            contextFont.IsBold = cell.CellFont.Bold;
                            contextFont.IsItalic = cell.CellFont.Italic;
                            contextFont.FontName = cell.CellFont.IsSystemFont ? cell.CellFont.SystemFontName : cell.CellFont.Name;
                            if (cell.CellFont.Underline) contextFont.Underline = FontUnderlineType.Single;
                            contextFont.FontHeightInPoints = (short)(cell.CellFont.SizeInPoints >= contextFont.FontHeightInPoints ? Math.Ceiling(cell.CellFont.SizeInPoints) : contextFont.FontHeightInPoints);
                            contextStyle.SetFont(contextFont);
                        }

                        SetCellRangeAddress(sheet, cell.RowIndex, cell.RowIndex + cell.RowSpan - 1, cell.ColumnIndex, cell.ColumnIndex + cell.ColumnSpan - 1);
                        if (ObjectIsNumeric(cell.CellValue)) contextRow.CreateCell(cell.ColumnIndex).SetCellValue(Convert.ToDouble(cell.CellValue));
                        else contextRow.CreateCell(cell.ColumnIndex).SetCellValue(cell.CellValue.ToString());
                        contextRow.GetCell(cell.ColumnIndex).CellStyle = contextStyle;
                        sheet.SetColumnWidth(cell.ColumnIndex, cell.Width * 300);
                    }
                }

                #endregion

                book.Write(ms);
                //ms.Flush();
            }

            MessageBox.Show(fileNameString + "\n\n导出完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        /// <summary>
        /// 保存DataGridView数据到Excel
        /// </summary>
        /// <param name="dgv">数据源</param>
        /// <param name="includehide">是否包含隐藏列</param>
        /// <param name="excludecol">需要排除的列名 多个列名用,分隔</param>
        /// <param name="f">列头字体样式 默认使用DataGridView列头字体样式</param>
        /// <returns>保存结果</returns>
        public static bool SaveDataGridViewToExcelByNPOI(DataGridView dgv, bool haveborder = true, bool includehide = false, string excludecol = "", Font f = null)
        {
            string fileNameString = string.Empty;
            if (!ShowSaveToExcelDialog(ref fileNameString)) return false;

            return SaveDataGridViewToExcelByNPOI(fileNameString, dgv, haveborder, includehide, excludecol, f);
        }

        /// <summary>
        /// 保存DataGridView数据到Excel
        /// </summary>
        /// <param name="fileNameString">保存路径</param>
        /// <param name="dgv">数据源</param>
        /// <param name="HintOpen">是否提示打开</param>
        /// <param name="haveborder">是否有边框</param>
        /// <param name="includehide">是否包含隐藏列</param>
        /// <param name="excludecol">需要排除的列名 多个列名用,分隔</param>
        /// <param name="f">列头字体样式 默认使用DataGridView列头字体样式</param>
        /// <returns>保存结果</returns>
        public static bool SaveDataGridViewToExcelByNPOI(ref string fileNameString, DataGridView dgv, bool HintOpen = false, bool haveborder = true, bool includehide = false, string excludecol = "", Font f = null)
        {
            if (!ShowSaveToExcelDialog(ref fileNameString)) return false;

            if (SaveDataGridViewToExcelByNPOI(fileNameString, dgv, haveborder, includehide, excludecol, f))
            {
                if (HintOpen)
                {
                    if (MessageBox.Show(string.Format("是否打开文件{0}【{1}】?", Environment.NewLine, fileNameString), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                        Process.Start(fileNameString);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 保存DataGridView数据到Excel
        /// </summary>
        /// <param name="fileNameString">保存路径</param>
        /// <param name="dgv">数据源</param>
        /// <param name="haveborder">是否有边框</param>
        /// <param name="includehide">是否包含隐藏列</param>
        /// <param name="excludecol">需要排除的列名 多个列名用,分隔</param>
        /// <param name="f">列头字体样式 默认使用DataGridView列头字体样式</param>
        /// <returns>保存结果</returns>
        public static bool SaveDataGridViewToExcelByNPOI(string fileNameString, DataGridView dgv, bool haveborder = true, bool includehide = false, string excludecol = "", Font f = null)
        {
            //if (!File.Exists(fileNameString))
            //{
            //    File.Create(fileNameString).Close();
            //}

            excludecol = excludecol.ToLower();
            if (!string.IsNullOrEmpty(excludecol) && !excludecol.EndsWith(",")) excludecol += ',';

            using (FileStream ms = File.Open(fileNameString, FileMode.OpenOrCreate))
            {
                XSSFWorkbook book = new XSSFWorkbook();
                ISheet sheet = book.CreateSheet("Sheet1");
                int minWidth = 5;
                int maxWidth = 255;
                int[] arrColWidth = new int[dgv.Columns.Count];

                #region 表头信息

                IRow headRow = sheet.CreateRow(0);
                int headcol = 0;
                foreach (DataGridViewColumn dc in dgv.Columns)
                {
                    if (excludecol.IndexOf(dc.Name.ToLower() + ',') >= 0) continue;
                    if (!includehide && !dc.Visible) continue;

                    arrColWidth[headcol] = Encoding.GetEncoding(936).GetBytes(dc.HeaderText.ToString()).Length;
                    if (arrColWidth[headcol] >= maxWidth) arrColWidth[headcol] = maxWidth - 1;
                    headRow.CreateCell(headcol++).SetCellValue(dc.HeaderText);
                }

                #endregion

                #region 表体数据

                int bodyrow = 1;
                int bodycol;
                string bodyvalue;
                int bodycolwidth;
                IRow dataRow;
                XSSFCellStyle dataStyle;
                dataStyle = (XSSFCellStyle)book.CreateCellStyle();
                dataStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                dataStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                dataStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                dataStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                dataStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
                foreach (DataGridViewRow dr in dgv.Rows)
                {
                    dataRow = sheet.CreateRow(bodyrow++);

                    bodycol = 0;
                    foreach (DataGridViewColumn dc in dgv.Columns)
                    {
                        if (excludecol.IndexOf(dc.Name.ToLower() + ',') >= 0) continue;
                        if (!includehide && !dc.Visible) continue;

                        bodyvalue = (dr.Cells[dc.Name].Value == null ? "" : dr.Cells[dc.Name].Value.ToString());
                        bodycolwidth = Encoding.GetEncoding(936).GetBytes(bodyvalue).Length;
                        if (bodycolwidth >= maxWidth) bodycolwidth = maxWidth - 1;
                        if (bodycolwidth >= arrColWidth[bodycol]) arrColWidth[bodycol] = bodycolwidth;

                        if (ObjectIsNumeric(bodyvalue)) dataRow.CreateCell(bodycol).SetCellValue(Convert.ToDouble(bodyvalue));
                        else dataRow.CreateCell(bodycol).SetCellValue(bodyvalue);
                        if (haveborder)
                        {
                            dataRow.GetCell(bodycol).CellStyle = dataStyle;
                        }

                        bodycol++;
                    }
                }

                #endregion

                #region 表格样式

                XSSFCellStyle headStyle = (XSSFCellStyle)book.CreateCellStyle();
                headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                headStyle.VerticalAlignment = VerticalAlignment.Center;
                if (haveborder)
                {
                    headStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                    headStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                    headStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                    headStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                }
                XSSFFont font;
                bool userDGV = f == null;
                int col = 0;
                foreach (DataGridViewColumn dc in dgv.Columns)
                {
                    if (excludecol.IndexOf(dc.Name.ToLower() + ',') >= 0) continue;
                    if (!includehide && !dc.Visible) continue;

                    if (userDGV)
                    {
                        f = dc.DefaultCellStyle.Font;
                        if (f == null) f = dgv.ColumnHeadersDefaultCellStyle.Font;
                    }
                    font = (XSSFFont)book.CreateFont();
                    font.Boldweight = 800;
                    font.IsBold = f.Bold;
                    font.IsItalic = f.Italic;
                    font.FontName = f.IsSystemFont ? f.SystemFontName : f.Name;
                    if (f.Underline) font.Underline = FontUnderlineType.Single;
                    font.FontHeightInPoints = (short)(f.SizeInPoints >= font.FontHeightInPoints ? Math.Ceiling(f.SizeInPoints) : font.FontHeightInPoints);
                    headStyle.SetFont(font);

                    headRow.GetCell(col).CellStyle = headStyle;
                    sheet.SetColumnWidth(col, ((arrColWidth[col] >= minWidth ? arrColWidth[col] : minWidth) + 1) * 300);
                    col++;
                }

                #endregion

                book.Write(ms);
                //ms.Flush();
            }

            MessageBox.Show(fileNameString + "\n\n导出完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        /// <summary>
        /// 保存DataSet数据到Excel
        /// </summary>
        /// <param name="ds">数据源</param>
        /// <param name="excludecol">需要排除的列名 多个列名用,分隔</param>
        /// <param name="f">列头字体样式</param>
        /// <returns>保存结果</returns>
        public static bool SaveDataSetToExcelByNPOI(DataSet ds, bool haveborder = true, string excludecol = "", Font f = null)
        {
            string fileNameString = string.Empty;
            if (!ShowSaveToExcelDialog(ref fileNameString)) return false;

            return SaveDataSetToExcelByNPOI(fileNameString, ds, haveborder, excludecol, f);
        }

        /// <summary>
        /// 保存DataSet数据到Excel
        /// </summary>
        /// <param name="fileNameString">保存路径</param>
        /// <param name="ds">数据源</param>
        /// <param name="HintOpen">是否提示打开</param>
        /// <param name="haveborder">是否有边框</param>
        /// <param name="excludecol">需要排除的列名 多个列名用,分隔</param>
        /// <param name="f">列头字体样式</param>
        /// <returns>保存结果</returns>
        public static bool SaveDataSetToExcelByNPOI(ref string fileNameString, DataSet ds, bool HintOpen = false, bool haveborder = true, string excludecol = "", Font f = null)
        {
            if (!ShowSaveToExcelDialog(ref fileNameString)) return false;

            if (SaveDataSetToExcelByNPOI(fileNameString, ds, haveborder, excludecol, f))
            {
                if (HintOpen)
                {
                    if (MessageBox.Show(string.Format("是否打开文件{0}【{1}】?", Environment.NewLine, fileNameString), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                        Process.Start(fileNameString);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 保存DataSet数据到Excel
        /// </summary>
        /// <param name="fileNameString">保存路径</param>
        /// <param name="ds">数据源</param>
        /// <param name="haveborder">是否有边框</param>
        /// <param name="excludecol">需要排除的列名 多个列名用,分隔</param>
        /// <param name="f">列头字体样式</param>
        /// <returns>保存结果</returns>
        public static bool SaveDataSetToExcelByNPOI(string fileNameString, DataSet ds, bool haveborder = true, string excludecol = "", Font f = null)
        {
            //    if (!File.Exists(fileNameString))
            //    {
            //        File.Create(fileNameString).Close();
            //    }

            excludecol = excludecol.ToLower();
            if (!string.IsNullOrEmpty(excludecol) && !excludecol.EndsWith(",")) excludecol += ',';

            using (FileStream ms = File.Open(fileNameString, FileMode.OpenOrCreate))
            {
                XSSFWorkbook book = new XSSFWorkbook();
                foreach (DataTable dt in ds.Tables)
                {
                    ISheet sheet = book.CreateSheet(dt.TableName);
                    int minWidth = 5;
                    int maxWidth = 255;
                    int[] arrColWidth = new int[dt.Columns.Count];

                    #region 表头信息

                    IRow headRow = sheet.CreateRow(0);
                    int headcol = 0;
                    foreach (DataColumn dc in dt.Columns)
                    {
                        if (excludecol.IndexOf(dc.ColumnName.ToLower() + ',') >= 0) continue;

                        arrColWidth[headcol] = Encoding.GetEncoding(936).GetBytes(dc.ColumnName.ToString()).Length;
                        if (arrColWidth[headcol] >= maxWidth) arrColWidth[headcol] = maxWidth - 1;
                        headRow.CreateCell(headcol++).SetCellValue(dc.ColumnName);
                    }

                    #endregion

                    #region 表体数据

                    int bodyrow = 1;
                    int bodycol;
                    string bodyvalue;
                    int bodycolwidth;
                    IRow dataRow;
                    XSSFCellStyle dataStyle;
                    dataStyle = (XSSFCellStyle)book.CreateCellStyle();
                    dataStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                    dataStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                    dataStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                    dataStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                    dataStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
                    foreach (DataRow dr in dt.Rows)
                    {
                        dataRow = sheet.CreateRow(bodyrow++);

                        bodycol = 0;
                        foreach (DataColumn dc in dt.Columns)
                        {
                            if (excludecol.IndexOf(dc.ColumnName.ToLower() + ',') >= 0) continue;

                            bodyvalue = (dr[dc.ColumnName] == null || dr[dc.ColumnName] == DBNull.Value ? "" : dr[dc.ColumnName].ToString());
                            bodycolwidth = Encoding.GetEncoding(936).GetBytes(bodyvalue).Length;
                            if (bodycolwidth >= maxWidth) bodycolwidth = maxWidth - 1;
                            if (bodycolwidth >= arrColWidth[bodycol]) arrColWidth[bodycol] = bodycolwidth;

                            if (ObjectIsNumeric(bodyvalue)) dataRow.CreateCell(bodycol).SetCellValue(Convert.ToDouble(bodyvalue));
                            else dataRow.CreateCell(bodycol).SetCellValue(bodyvalue);
                            if (haveborder)
                            {
                                dataRow.GetCell(bodycol).CellStyle = dataStyle;
                            }

                            bodycol++;
                        }
                    }

                    #endregion

                    #region 表格样式

                    XSSFCellStyle headStyle = (XSSFCellStyle)book.CreateCellStyle();
                    headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                    headStyle.VerticalAlignment = VerticalAlignment.Center;
                    if (haveborder)
                    {
                        headStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                        headStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                        headStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                        headStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                    }
                    XSSFFont font;
                    font = (XSSFFont)book.CreateFont();
                    if (f == null)
                    {
                        font.Boldweight = 800;
                        font.IsBold = true;
                        font.IsItalic = false;
                        //font.FontName = "Arial";
                        font.FontHeightInPoints = 12;
                        //font.Underline = FontUnderlineType.None;
                    }
                    else
                    {
                        font.Boldweight = 800;
                        font.IsBold = f.Bold;
                        font.IsItalic = f.Italic;
                        font.FontName = f.IsSystemFont ? f.SystemFontName : f.Name;
                        if (f.Underline) font.Underline = FontUnderlineType.Single;
                        font.FontHeightInPoints = (short)(f.SizeInPoints >= font.FontHeightInPoints ? Math.Ceiling(f.SizeInPoints) : font.FontHeightInPoints);
                    }
                    headStyle.SetFont(font);

                    for (int col = 0; col < headRow.Cells.Count; col++)
                    {
                        headRow.GetCell(col).CellStyle = headStyle;
                        sheet.SetColumnWidth(col, ((arrColWidth[col] >= minWidth ? arrColWidth[col] : minWidth) + 1) * 300);
                    }

                    #endregion

                    book.Write(ms);
                    //ms.Flush();
                }
            }

            MessageBox.Show(fileNameString + "\n\n导出完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        /// <summary>
        /// 保存List_T数据到Excel
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="lst">数据源</param>
        /// <param name="excludecol">需要排除的列名 多个列名用,分隔</param>
        /// <param name="f">列头字体样式</param>
        /// <returns>保存结果</returns>
        public static bool SaveListToExcelByNPOI<T>(List<T> lst, bool haveborder = true, string excludecol = "", Dictionary<string, string> dicFields = null, Font f = null)
        {
            string fileNameString = string.Empty;
            if (!ShowSaveToExcelDialog(ref fileNameString)) return false;

            return SaveListToExcelByNPOI<T>(fileNameString, lst, haveborder, excludecol, dicFields, f);
        }

        /// <summary>
        /// 保存List_T数据到Excel
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="fileNameString">保存路径</param>
        /// <param name="lst">数据源</param>
        /// <param name="HintOpen">是否提示打开</param>
        /// <param name="haveborder">是否有边框</param>
        /// <param name="excludecol">需要排除的列名 多个列名用,分隔</param>
        /// <param name="f">列头字体样式</param>
        /// <returns>保存结果</returns>
        public static bool SaveListToExcelByNPOI<T>(ref string fileNameString, List<T> lst, bool HintOpen = false, bool haveborder = true, string excludecol = "", Dictionary<string, string> dicFields = null, Font f = null)
        {
            if (!ShowSaveToExcelDialog(ref fileNameString)) return false;

            if (SaveListToExcelByNPOI<T>(fileNameString, lst, haveborder, excludecol, dicFields, f))
            {
                if (HintOpen)
                {
                    if (MessageBox.Show(string.Format("是否打开文件{0}【{1}】?", Environment.NewLine, fileNameString), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                        Process.Start(fileNameString);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 保存List_T数据到Excel
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="fileNameString">保存路径</param>
        /// <param name="lst">数据源</param>
        /// <param name="haveborder">是否有边框</param>
        /// <param name="excludecol">需要排除的列名 多个列名用,分隔</param>
        /// <param name="f">列头字体样式</param>
        /// <returns>保存结果</returns>
        public static bool SaveListToExcelByNPOI<T>(string fileNameString, List<T> lst, bool haveborder = true, string excludecol = "", Dictionary<string, string> dicFields = null, Font f = null)
        {
            //if (!File.Exists(fileNameString))
            //{
            //    File.Create(fileNameString).Close();
            //}

            excludecol = excludecol.ToLower();
            if (!string.IsNullOrEmpty(excludecol) && !excludecol.EndsWith(",")) excludecol += ',';


            using (FileStream ms = File.Open(fileNameString, FileMode.OpenOrCreate))
            {
                XSSFWorkbook book = new XSSFWorkbook();
                ISheet sheet = book.CreateSheet("Sheet1");
                PropertyInfo[] arrPi = typeof(T).GetProperties();
                int minWidth = 5;
                int maxWidth = 255;
                int[] arrColWidth = new int[arrPi.Length];
                Type[] arrType = new Type[] { typeof(List<T>), typeof(DataSet), typeof(DataTable) };

                #region 表头信息

                IRow headRow = sheet.CreateRow(0);
                int headcol = 0;
                if (dicFields != null)
                {
                    foreach (KeyValuePair<string, string> field in dicFields)
                    {
                        if (excludecol.IndexOf(field.Key.ToLower() + ',') >= 0) continue;

                        PropertyInfo pi = arrPi.FirstOrDefault(t => t.Name == field.Key);
                        if (pi == null) continue;
                        if (arrType.Contains(pi.PropertyType)) continue;

                        arrColWidth[headcol] = Encoding.GetEncoding(936).GetBytes(field.Value).Length;
                        if (arrColWidth[headcol] >= maxWidth) arrColWidth[headcol] = maxWidth - 1;
                        headRow.CreateCell(headcol++).SetCellValue(field.Value);
                    }
                }
                else
                {
                    foreach (PropertyInfo pi in arrPi)
                    {
                        if (dicFields.ContainsKey(pi.Name)) continue;
                        if (pi.Name.ToLower() == "extensiondata") continue;
                        if (excludecol.IndexOf(pi.Name.ToLower() + ',') >= 0) continue;
                        if (arrType.Contains(pi.PropertyType)) continue;

                        arrColWidth[headcol] = Encoding.GetEncoding(936).GetBytes(pi.Name).Length;
                        if (arrColWidth[headcol] >= maxWidth) arrColWidth[headcol] = maxWidth - 1;
                        headRow.CreateCell(headcol++).SetCellValue(pi.Name);
                    }
                }

                #endregion

                #region 表体数据

                int bodyrow = 1;
                IRow dataRow;
                int bodycol;
                string bodyvalue;
                int bodycolwidth;
                XSSFCellStyle dataStyle;
                dataStyle = (XSSFCellStyle)book.CreateCellStyle();
                dataStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                dataStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                dataStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                dataStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
                foreach (T t in lst)
                {
                    dataRow = sheet.CreateRow(bodyrow++);

                    bodycol = 0;
                    if (dicFields != null)
                    {
                        foreach (KeyValuePair<string, string> field in dicFields)
                        {
                            if (excludecol.IndexOf(field.Key.ToLower() + ',') >= 0) continue;

                            PropertyInfo pi = arrPi.FirstOrDefault(p => p.Name == field.Key);
                            if (pi == null) continue;
                            if (arrType.Contains(pi.PropertyType)) continue;

                            bodyvalue = (pi.GetValue(t, null) == null ? "" : pi.GetValue(t, null).ToString());
                            bodycolwidth = Encoding.GetEncoding(936).GetBytes(bodyvalue).Length;
                            if (bodycolwidth >= maxWidth) bodycolwidth = maxWidth - 1;
                            if (bodycolwidth >= arrColWidth[bodycol]) arrColWidth[bodycol] = bodycolwidth;

                            if (ObjectIsNumeric(bodyvalue)) dataRow.CreateCell(bodycol).SetCellValue(Convert.ToDouble(bodyvalue));
                            else dataRow.CreateCell(bodycol).SetCellValue(bodyvalue);
                            if (haveborder)
                            {
                                dataRow.GetCell(bodycol).CellStyle = dataStyle;
                            }

                            bodycol++;
                        }
                    }
                    else
                    {
                        foreach (PropertyInfo pi in arrPi)
                        {
                            if (pi.Name.ToLower() == "extensiondata") continue;
                            if (excludecol.IndexOf(pi.Name.ToLower() + ',') >= 0) continue;
                            if (arrType.Contains(pi.PropertyType)) continue;

                            bodyvalue = (pi.GetValue(t, null) == null ? "" : pi.GetValue(t, null).ToString());
                            bodycolwidth = Encoding.GetEncoding(936).GetBytes(bodyvalue).Length;
                            if (bodycolwidth >= maxWidth) bodycolwidth = maxWidth - 1;
                            if (bodycolwidth >= arrColWidth[bodycol]) arrColWidth[bodycol] = bodycolwidth;

                            if (ObjectIsNumeric(bodyvalue)) dataRow.CreateCell(bodycol).SetCellValue(Convert.ToDouble(bodyvalue));
                            else dataRow.CreateCell(bodycol).SetCellValue(bodyvalue);
                            if (haveborder)
                            {
                                dataRow.GetCell(bodycol).CellStyle = dataStyle;
                            }

                            bodycol++;
                        }
                    }
                }

                #endregion

                #region 表格样式

                XSSFCellStyle headStyle = (XSSFCellStyle)book.CreateCellStyle();
                headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                headStyle.VerticalAlignment = VerticalAlignment.Center;
                if (haveborder)
                {
                    headStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                    headStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                    headStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                    headStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                }
                XSSFFont font;
                font = (XSSFFont)book.CreateFont();
                if (f == null)
                {
                    font.Boldweight = 800;
                    font.IsBold = true;
                    font.IsItalic = false;
                    //font.FontName = "Arial";
                    font.FontHeightInPoints = 12;
                    //font.Underline = FontUnderlineType.None;
                }
                else
                {
                    font.Boldweight = 800;
                    font.IsBold = f.Bold;
                    font.IsItalic = f.Italic;
                    font.FontName = f.IsSystemFont ? f.SystemFontName : f.Name;
                    if (f.Underline) font.Underline = FontUnderlineType.Single;
                    font.FontHeightInPoints = (short)(f.SizeInPoints >= font.FontHeightInPoints ? Math.Ceiling(f.SizeInPoints) : font.FontHeightInPoints);
                }
                headStyle.SetFont(font);

                for (int col = 0; col < headRow.Cells.Count; col++)
                {
                    headRow.GetCell(col).CellStyle = headStyle;
                    sheet.SetColumnWidth(col, ((arrColWidth[col] >= minWidth ? arrColWidth[col] : minWidth) + 1) * 300);
                }

                #endregion

                book.Write(ms);
                //ms.Flush();
            }

            MessageBox.Show(fileNameString + "\n\n导出完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }



        #endregion


        #region ReadByExcel
        /// <summary>
        /// 读取Excel转换为DataSet
        /// </summary>
        /// <param name="dsResult">读取结果</param>
        /// <param name="sheetname">工作表名(亦是DataTable名)</param>
        /// <param name="havetitle">是否包含标题</param>
        /// <returns>读取结果</returns>
        public static bool ReadExcelToDataSetByNPOI(ref DataSet dsResult, string sheetname = "Sheet1", bool havetitle = false)
        {
            dsResult = new DataSet();
            string fileNameString = string.Empty;
            if (!ShowOpenForExcelDialog(ref fileNameString)) return false;

            return ReadExcelToDataSetByNPOI(fileNameString, ref dsResult, sheetname, havetitle);
        }

        /// <summary>
        /// 读取Excel转换为DataSet
        /// </summary>
        /// <param name="fileNameString">文件路径</param>
        /// <param name="dsResult">读取结果</param>
        /// <param name="sheetname">工作表名(亦是DataTable名)</param>
        /// <param name="havetitle">是否包含标题</param>
        /// <returns>读取结果</returns>
        public static bool ReadExcelToDataSetByNPOI(string fileNameString, ref DataSet dsResult, string sheetname = "Sheet1", bool havetitle = false)
        {
            if (!File.Exists(fileNameString))
            {
                MessageBox.Show(fileNameString + " 文件不存在\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string extensname = Path.GetExtension(fileNameString);
            bool isXSSF = extensname.ToLower() == (".xlsx");
            dsResult = new DataSet();
            FileStream file = null;

            int cellCount = 0;
            int rowCount = 0;


            if (isXSSF)
            {
                #region XLSX

                XSSFWorkbook workbook;
                XSSFSheet sheet;
                XSSFRow headerRow;

                try
                {
                    InitXSSF(fileNameString, ref sheetname, ref file, ref cellCount, ref rowCount, out workbook, out sheet, out headerRow);

                    #region 表头信息
                    DataTable table = new DataTable(sheetname);
                    string colname = "";
                    if (havetitle)
                    {
                        for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                        {
                            colname = headerRow.GetCell(i).StringCellValue;
                            if (string.IsNullOrEmpty(colname))
                            {
                                MessageBox.Show("Excel格式不正确\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            if (IsExistsDataColumn(table, colname)) colname = GetNewDataColumnName(table, colname);
                            DataColumn column = new DataColumn(colname);
                            table.Columns.Add(column);
                        }
                    }
                    else
                    {
                        for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                        {
                            colname = "col" + i.ToString();
                            DataColumn column = new DataColumn(colname);
                            table.Columns.Add(column);
                        }
                    }

                    #endregion

                    #region 表体信息
                    XSSFRow row;
                    DataRow dataRow;
                    for (int i = havetitle ? (sheet.FirstRowNum + 1) : (sheet.FirstRowNum); i <= rowCount; i++)
                    {
                        row = (XSSFRow)sheet.GetRow(i);
                        dataRow = table.NewRow();

                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                                dataRow[j] = GetValueByICell(row.GetCell(j));
                        }

                        table.Rows.Add(dataRow);
                    }

                    dsResult.Tables.Add(table);

                    #endregion

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    if (file != null) file.Dispose();
                    file = null;
                    workbook = null;
                    sheet = null;
                }
                #endregion
            }
            else
            {
                #region XLS

                HSSFWorkbook workbook;
                HSSFSheet sheet;
                HSSFRow headerRow;

                try
                {
                    InitHSSF(fileNameString, ref sheetname, ref file, ref cellCount, ref rowCount, out workbook, out sheet, out headerRow);

                    #region 表头信息
                    DataTable table = new DataTable(sheetname);
                    string colname = "";
                    if (havetitle)
                    {
                        for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                        {
                            colname = headerRow.GetCell(i).StringCellValue;
                            if (string.IsNullOrEmpty(colname))
                            {
                                MessageBox.Show("Excel格式不正确\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            if (IsExistsDataColumn(table, colname)) colname = GetNewDataColumnName(table, colname);
                            DataColumn column = new DataColumn(colname);
                            table.Columns.Add(column);
                        }
                    }
                    else
                    {
                        for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                        {
                            colname = "col" + i.ToString();
                            DataColumn column = new DataColumn(colname);
                            table.Columns.Add(column);
                        }
                    }

                    #endregion

                    #region 表体信息
                    HSSFRow row;
                    DataRow dataRow;
                    for (int i = havetitle ? (sheet.FirstRowNum + 1) : (sheet.FirstRowNum); i <= rowCount; i++)
                    {
                        row = (HSSFRow)sheet.GetRow(i);
                        dataRow = table.NewRow();

                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                                dataRow[j] = GetValueByICell(row.GetCell(j));
                        }

                        table.Rows.Add(dataRow);
                    }

                    dsResult.Tables.Add(table);

                    #endregion

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    if (file != null) file.Dispose();
                    file = null;
                    workbook = null;
                    sheet = null;
                }
                #endregion
            }
        }

        /// <summary>
        /// 读取Excel转换为SQL语句
        /// (必须包含列名,对应数据库列名)
        /// </summary>
        /// <param name="strResult">读取结果</param>
        /// <param name="sheetname">工作表名(亦是数据库表名) 获取错误则默认取第一个工作表名</param>
        /// <param name="dicFields">工作表列名对应的字段名[列名,字段名] 默认相同</param>
        /// <param name="dicDefault">字段默认值[字段名,默认值]</param>
        /// <returns>读取结果</returns>
        public static bool ReadExcelToSqlstrByNPOI(ref string strResult, string sheetname = "Sheet1", Dictionary<string, string> dicFields = null, Dictionary<string, string> dicDefault = null)
        {
            strResult = string.Empty;
            string fileNameString = string.Empty;
            if (!ShowOpenForExcelDialog(ref fileNameString)) return false;

            return ReadExcelToSqlstrByNPOI(fileNameString, ref strResult, sheetname, dicFields, dicDefault);
        }

        /// <summary>
        /// 读取Excel转换为SQL语句
        /// (必须包含列名,对应数据库列名)
        /// </summary>
        /// <param name="fileNameString">文件路径</param>
        /// <param name="strResult">读取结果</param>
        /// <param name="sheetname">工作表名(亦是数据库表名) 获取错误则默认取第一个工作表名</param>
        /// <param name="dicFields">工作表列名对应的字段名[列名,字段名] 默认相同</param>
        /// <param name="dicDefault">字段默认值[字段名,默认值]</param>
        /// <returns>读取结果</returns>
        public static bool ReadExcelToSqlstrByNPOI(string fileNameString, ref string strResult, string sheetname = "Sheet1", Dictionary<string, string> dicFields = null, Dictionary<string, string> dicDefault = null)
        {
            if (!File.Exists(fileNameString))
            {
                MessageBox.Show(fileNameString + " 文件不存在\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string extensname = Path.GetExtension(fileNameString);
            bool isXSSF = extensname.ToLower() == (".xlsx");
            string tablename = sheetname;
            strResult = string.Empty;
            FileStream file = null;

            int cellCount = 0;
            int rowCount = 0;


            if (isXSSF)
            {
                #region XLSX

                XSSFWorkbook workbook;
                XSSFSheet sheet;
                XSSFRow headerRow;

                try
                {
                    InitXSSF(fileNameString, ref sheetname, ref file, ref cellCount, ref rowCount, out workbook, out sheet, out headerRow);

                    StringBuilder sbResult = new StringBuilder();
                    //工作表包含的列
                    Dictionary<string, string> dicExists = new Dictionary<string, string>();
                    //工作表不包含的列
                    Dictionary<string, string> dicNoExists = dicDefault;

                    #region 表头信息
                    StringBuilder sbInsert = new StringBuilder("INSERT INTO " + tablename + "(");
                    string colname = "";
                    for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                    {
                        colname = headerRow.GetCell(i).StringCellValue;
                        if (string.IsNullOrEmpty(colname))
                        {
                            MessageBox.Show("Excel格式不正确\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        if (dicFields != null && dicFields.Count >= 1)
                        {
                            if (dicFields.ContainsKey(colname))
                                colname = dicFields[colname];
                        }
                        if (dicDefault != null && dicDefault.Count >= 1)
                        {
                            if (dicDefault.ContainsKey(colname))
                            {
                                dicExists.Add(colname, dicDefault[colname]);
                                dicNoExists.Remove(colname);
                            }
                        }

                        sbInsert.Append(colname + ",");
                    }

                    if (sbInsert[sbInsert.Length - 1] == '(')
                    {
                        MessageBox.Show("Excel格式不正确\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        if (dicNoExists != null && dicNoExists.Count >= 1)
                        {
                            foreach (KeyValuePair<string, string> kv in dicNoExists)
                            {
                                sbInsert.Append(kv.Key + ",");
                            }
                        }
                    }

                    if (sbInsert[sbInsert.Length - 1] == ',')
                    {
                        sbInsert.Remove(sbInsert.Length - 1, 1);
                    }
                    sbInsert.Append(") ");

                    #endregion

                    #region 表体信息
                    StringBuilder sbValues;
                    IRow irow;
                    XSSFRow row;
                    object cellvalue;
                    for (int i = sheet.FirstRowNum + 1; i <= rowCount; i++)
                    {
                        irow = sheet.GetRow(i);
                        if (irow == null) continue;
                        sbValues = new StringBuilder("VALUES(");
                        row = (XSSFRow)irow;

                        bool isEmpty = true;
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            cellvalue = GetValueByICell(row.GetCell(j));
                            if (cellvalue != null && !string.IsNullOrEmpty(cellvalue.ToString())) isEmpty = false;
                            if (cellvalue == null && dicExists != null && dicExists.Count >= 1)
                            {
                                colname = headerRow.GetCell(j).StringCellValue;
                                if (string.IsNullOrEmpty(colname)) continue;
                                if (dicFields != null && dicFields.Count >= 1)
                                {
                                    if (dicFields.ContainsKey(colname))
                                        colname = dicFields[colname];
                                }
                                if (dicExists.ContainsKey(colname))
                                    cellvalue = dicExists[colname];
                            }


                            if (cellvalue == null)
                            {
                                sbValues.Append("'',");
                            }
                            else if (cellvalue.ToString() == "NULL")
                            {
                                sbValues.Append("NULL,");
                            }
                            else
                            {
                                sbValues.Append("'").Append(cellvalue).Append("',");
                            }
                        }
                        if (isEmpty) continue;

                        if (sbValues[sbValues.Length - 1] == '(')
                        {
                            MessageBox.Show("Excel格式不正确\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        else
                        {
                            if (dicNoExists != null && dicNoExists.Count >= 1)
                            {
                                foreach (KeyValuePair<string, string> kv in dicNoExists)
                                {
                                    sbValues.Append("'").Append(kv.Value == null ? "" : kv.Value).Append("',");
                                }
                            }
                        }

                        if (sbValues[sbValues.Length - 1] == ',')
                        {
                            sbValues.Remove(sbValues.Length - 1, 1);
                        }
                        sbValues.Append("); \n");
                        sbResult.Append(sbInsert).Append(sbValues);
                    }

                    #endregion

                    strResult = sbResult.ToString();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    if (file != null) file.Dispose();
                    file = null;
                    workbook = null;
                    sheet = null;
                }
                #endregion
            }
            else
            {
                #region XLS

                HSSFWorkbook workbook;
                HSSFSheet sheet;
                HSSFRow headerRow;

                try
                {
                    InitHSSF(fileNameString, ref sheetname, ref file, ref cellCount, ref rowCount, out workbook, out sheet, out headerRow);

                    StringBuilder sbResult = new StringBuilder();
                    //工作表包含的列
                    Dictionary<string, string> dicExists = new Dictionary<string, string>();
                    //工作表不包含的列
                    Dictionary<string, string> dicNoExists = dicDefault;

                    #region 表头信息
                    StringBuilder sbInsert = new StringBuilder("INSERT INTO " + tablename + "(");
                    string colname = "";
                    for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                    {
                        colname = headerRow.GetCell(i).StringCellValue;
                        if (string.IsNullOrEmpty(colname))
                        {
                            MessageBox.Show("Excel格式不正确\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        if (dicFields != null && dicFields.Count >= 1)
                        {
                            if (dicFields.ContainsKey(colname))
                                colname = dicFields[colname];
                        }
                        if (dicDefault != null && dicDefault.Count >= 1)
                        {
                            if (dicDefault.ContainsKey(colname))
                            {
                                dicExists.Add(colname, dicDefault[colname]);
                                dicNoExists.Remove(colname);
                            }
                        }

                        sbInsert.Append(colname + ",");
                    }

                    if (sbInsert[sbInsert.Length - 1] == '(')
                    {
                        MessageBox.Show("Excel格式不正确\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        if (dicNoExists != null && dicNoExists.Count >= 1)
                        {
                            foreach (KeyValuePair<string, string> kv in dicNoExists)
                            {
                                sbInsert.Append(kv.Key + ",");
                            }
                        }
                    }

                    if (sbInsert[sbInsert.Length - 1] == ',')
                    {
                        sbInsert.Remove(sbInsert.Length - 1, 1);
                    }
                    sbInsert.Append(") ");

                    #endregion

                    #region 表体信息
                    StringBuilder sbValues;
                    IRow irow;
                    HSSFRow row;
                    object cellvalue;
                    for (int i = sheet.FirstRowNum + 1; i <= rowCount; i++)
                    {
                        irow = sheet.GetRow(i);
                        if (irow == null) continue;
                        sbValues = new StringBuilder("VALUES(");
                        row = (HSSFRow)irow;

                        bool isEmpty = true;
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            cellvalue = GetValueByICell(row.GetCell(j));
                            if (cellvalue != null && !string.IsNullOrEmpty(cellvalue.ToString())) isEmpty = false;
                            if (cellvalue == null && dicExists != null && dicExists.Count >= 1)
                            {
                                colname = headerRow.GetCell(j).StringCellValue;
                                if (string.IsNullOrEmpty(colname)) continue;
                                if (dicFields != null && dicFields.Count >= 1)
                                {
                                    if (dicFields.ContainsKey(colname))
                                        colname = dicFields[colname];
                                }
                                if (dicExists.ContainsKey(colname))
                                    cellvalue = dicExists[colname];
                            }


                            if (cellvalue == null)
                            {
                                sbValues.Append("'',");
                            }
                            else if (cellvalue.ToString() == "NULL")
                            {
                                sbValues.Append("NULL,");
                            }
                            else
                            {
                                sbValues.Append("'").Append(cellvalue).Append("',");
                            }
                        }
                        if (isEmpty) continue;

                        if (sbValues[sbValues.Length - 1] == '(')
                        {
                            MessageBox.Show("Excel格式不正确\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        else
                        {
                            if (dicNoExists != null && dicNoExists.Count >= 1)
                            {
                                foreach (KeyValuePair<string, string> kv in dicNoExists)
                                {
                                    sbValues.Append("'").Append(kv.Value == null ? "" : kv.Value).Append("',");
                                }
                            }
                        }

                        if (sbValues[sbValues.Length - 1] == ',')
                        {
                            sbValues.Remove(sbValues.Length - 1, 1);
                        }
                        sbValues.Append("); \n");
                        sbResult.Append(sbInsert).Append(sbValues);
                    }

                    #endregion

                    strResult = sbResult.ToString();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    if (file != null) file.Dispose();
                    file = null;
                    workbook = null;
                    sheet = null;
                }
                #endregion
            }
        }

        /// <summary>
        /// 读取Excel转换为SQL语句
        /// (必须包含列名,对应数据库列名)
        /// </summary>
        /// <param name="strResult">读取结果</param>
        /// <param name="sheetname">工作表名(亦是数据库表名) 获取错误则默认取第一个工作表名</param>
        /// <param name="dicFields">工作表列名对应的字段名[列名,字段名] 默认相同</param>
        /// <param name="dicDefault">字段默认值[字段名,默认值]</param>
        /// <returns>读取结果</returns>
        public static bool ReadExcelToSqlListByNPOI(ref List<string> lstResult, string sheetname = "Sheet1", Dictionary<string, string> dicFields = null, Dictionary<string, string> dicDefault = null)
        {
            lstResult = new List<string>();
            string fileNameString = string.Empty;
            if (!ShowOpenForExcelDialog(ref fileNameString)) return false;

            return ReadExcelToSqlListByNPOI(fileNameString, ref lstResult, sheetname, dicFields, dicDefault);
        }

        /// <summary>
        /// 读取Excel转换为SQL语句
        /// (必须包含列名,对应数据库列名)
        /// </summary>
        /// <param name="fileNameString">文件路径</param>
        /// <param name="strResult">读取结果</param>
        /// <param name="sheetname">工作表名(亦是数据库表名) 获取错误则默认取第一个工作表名</param>
        /// <param name="dicFields">工作表列名对应的字段名[列名,字段名] 默认相同</param>
        /// <param name="dicDefault">字段默认值[字段名,默认值]</param>
        /// <returns>读取结果</returns>
        public static bool ReadExcelToSqlListByNPOI(string fileNameString, ref List<string> lstResult, string sheetname = "Sheet1", Dictionary<string, string> dicFields = null, Dictionary<string, string> dicDefault = null)
        {
            if (!File.Exists(fileNameString))
            {
                MessageBox.Show(fileNameString + " 文件不存在\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string extensname = Path.GetExtension(fileNameString);
            bool isXSSF = extensname.ToLower() == (".xlsx");
            string tablename = sheetname;
            lstResult = new List<string>();
            FileStream file = null;

            int cellCount = 0;
            int rowCount = 0;

            if (isXSSF)
            {
                #region XLSX

                XSSFWorkbook workbook;
                XSSFSheet sheet;
                XSSFRow headerRow;

                try
                {
                    InitXSSF(fileNameString, ref sheetname, ref file, ref cellCount, ref rowCount, out workbook, out sheet, out headerRow);

                    StringBuilder sbResult = new StringBuilder();
                    //工作表包含的列
                    Dictionary<string, string> dicExists = new Dictionary<string, string>();
                    //工作表不包含的列
                    Dictionary<string, string> dicNoExists = dicDefault;

                    #region 表头信息
                    StringBuilder sbInsert = new StringBuilder("INSERT INTO " + tablename + "(");
                    ICell cell;
                    string colname = "";
                    for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                    {
                        cell = headerRow.GetCell(i);
                        if (cell == null)
                        {
                            MessageBox.Show("Excel格式不正确,第" + (i + 1).ToString() + "列列头为空\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        colname = cell.StringCellValue.Trim();
                        if (string.IsNullOrEmpty(colname))
                        {
                            MessageBox.Show("Excel格式不正确,第" + (i + 1).ToString() + "列列头为空\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        if (sbInsert != null && sbInsert.ToString().IndexOf(colname + ",") >= 0)
                        {
                            MessageBox.Show("Excel格式不正确,第" + (i + 1).ToString() + "列列头有重复\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }


                        if (dicFields != null && dicFields.Count >= 1)
                        {
                            if (dicFields.ContainsKey(colname))
                                colname = dicFields[colname];
                        }
                        if (dicDefault != null && dicDefault.Count >= 1)
                        {
                            if (dicDefault.ContainsKey(colname))
                            {
                                dicExists.Add(colname, dicDefault[colname]);
                                dicNoExists.Remove(colname);
                            }
                        }

                        sbInsert.Append(colname + ",");
                    }

                    if (sbInsert[sbInsert.Length - 1] == '(')
                    {
                        MessageBox.Show("Excel格式不正确\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        if (dicNoExists != null && dicNoExists.Count >= 1)
                        {
                            foreach (KeyValuePair<string, string> kv in dicNoExists)
                            {
                                sbInsert.Append(kv.Key + ",");
                            }
                        }
                    }

                    if (sbInsert[sbInsert.Length - 1] == ',')
                    {
                        sbInsert.Remove(sbInsert.Length - 1, 1);
                    }
                    sbInsert.Append(") ");

                    #endregion

                    #region 表体信息
                    StringBuilder sbValues;
                    IRow irow;
                    XSSFRow row;
                    object cellvalue;
                    for (int i = sheet.FirstRowNum + 1; i <= rowCount; i++)
                    {
                        irow = sheet.GetRow(i);
                        if (irow == null) continue;
                        sbResult = new StringBuilder();
                        sbValues = new StringBuilder("VALUES(");
                        row = (XSSFRow)irow;

                        bool isEmpty = true;
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            cellvalue = GetValueByICell(row.GetCell(j));
                            if (cellvalue != null && !string.IsNullOrEmpty(cellvalue.ToString())) isEmpty = false;
                            if (cellvalue == null && dicExists != null && dicExists.Count >= 1)
                            {
                                colname = headerRow.GetCell(j).StringCellValue.Trim();
                                if (string.IsNullOrEmpty(colname)) continue;
                                if (dicFields != null && dicFields.Count >= 1)
                                {
                                    if (dicFields.ContainsKey(colname))
                                        colname = dicFields[colname];
                                }
                                if (dicExists.ContainsKey(colname))
                                    cellvalue = dicExists[colname];
                            }


                            if (cellvalue == null)
                            {
                                sbValues.Append("NULL,");
                            }
                            else
                                if (TransferOracleDate(ref cellvalue))
                            {
                                sbValues.Append(cellvalue).Append(",");
                            }
                            else if (cellvalue.ToString() == "NULL")
                            {
                                sbValues.Append("NULL,");
                            }
                            else
                            {
                                sbValues.Append("'").Append(cellvalue).Append("',");
                            }
                        }
                        if (isEmpty) continue;

                        if (sbValues[sbValues.Length - 1] == '(')
                        {
                            MessageBox.Show("Excel格式不正确\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        else
                        {
                            if (dicNoExists != null && dicNoExists.Count >= 1)
                            {
                                foreach (KeyValuePair<string, string> kv in dicNoExists)
                                {
                                    cellvalue = kv.Value;

                                    if (cellvalue == null)
                                    {
                                        sbValues.Append("NULL,");
                                    }
                                    else if (TransferOracleDate(ref cellvalue))
                                    {
                                        sbValues.Append(cellvalue).Append(",");
                                    }
                                    else if (cellvalue.ToString() == "NULL")
                                    {
                                        sbValues.Append("NULL,");
                                    }
                                    else
                                    {
                                        sbValues.Append("'").Append(cellvalue).Append("',");
                                    }
                                }
                            }
                        }

                        if (sbValues[sbValues.Length - 1] == ',')
                        {
                            sbValues.Remove(sbValues.Length - 1, 1);
                        }
                        sbValues.Append(") \n");
                        sbResult.Append(sbInsert).Append(sbValues);

                        lstResult.Add(sbResult.ToString());
                    }

                    #endregion

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    if (file != null) file.Dispose();
                    file = null;
                    workbook = null;
                    sheet = null;
                }
                #endregion
            }
            else
            {
                #region XLS

                HSSFWorkbook workbook;
                HSSFSheet sheet;
                HSSFRow headerRow;

                try
                {
                    InitHSSF(fileNameString, ref sheetname, ref file, ref cellCount, ref rowCount, out workbook, out sheet, out headerRow);

                    StringBuilder sbResult = new StringBuilder();
                    //工作表包含的列
                    Dictionary<string, string> dicExists = new Dictionary<string, string>();
                    //工作表不包含的列
                    Dictionary<string, string> dicNoExists = dicDefault;

                    #region 表头信息
                    StringBuilder sbInsert = new StringBuilder("INSERT INTO " + tablename + "(");
                    ICell cell;
                    string colname = "";
                    for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                    {
                        cell = headerRow.GetCell(i);
                        if (cell == null)
                        {
                            MessageBox.Show("Excel格式不正确,第" + (i + 1).ToString() + "列列头为空\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        colname = cell.StringCellValue;
                        if (string.IsNullOrEmpty(colname))
                        {
                            MessageBox.Show("Excel格式不正确,第" + (i + 1).ToString() + "列列头为空\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        if (sbInsert != null && sbInsert.ToString().IndexOf(colname + ",") >= 0)
                        {
                            MessageBox.Show("Excel格式不正确,第" + (i + 1).ToString() + "列列头有重复\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        if (dicFields != null && dicFields.Count >= 1)
                        {
                            if (dicFields.ContainsKey(colname))
                                colname = dicFields[colname];
                        }
                        if (dicDefault != null && dicDefault.Count >= 1)
                        {
                            if (dicDefault.ContainsKey(colname))
                            {
                                dicExists.Add(colname, dicDefault[colname]);
                                dicNoExists.Remove(colname);
                            }
                        }

                        sbInsert.Append(colname + ",");
                    }

                    if (sbInsert[sbInsert.Length - 1] == '(')
                    {
                        MessageBox.Show("Excel格式不正确\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        if (dicNoExists != null && dicNoExists.Count >= 1)
                        {
                            foreach (KeyValuePair<string, string> kv in dicNoExists)
                            {
                                sbInsert.Append(kv.Key + ",");
                            }
                        }
                    }

                    if (sbInsert[sbInsert.Length - 1] == ',')
                    {
                        sbInsert.Remove(sbInsert.Length - 1, 1);
                    }
                    sbInsert.Append(") ");

                    #endregion

                    #region 表体信息
                    StringBuilder sbValues;
                    IRow irow;
                    HSSFRow row;
                    object cellvalue;
                    for (int i = sheet.FirstRowNum + 1; i <= rowCount; i++)
                    {
                        irow = sheet.GetRow(i);
                        if (irow == null) continue;
                        sbResult = new StringBuilder();
                        sbValues = new StringBuilder("VALUES(");
                        row = (HSSFRow)irow;

                        bool isEmpty = true;
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            cellvalue = GetValueByICell(row.GetCell(j));
                            if (cellvalue != null && !string.IsNullOrEmpty(cellvalue.ToString())) isEmpty = false;
                            if (cellvalue == null && dicExists != null && dicExists.Count >= 1)
                            {
                                colname = headerRow.GetCell(j).StringCellValue;
                                if (string.IsNullOrEmpty(colname)) continue;
                                if (dicFields != null && dicFields.Count >= 1)
                                {
                                    if (dicFields.ContainsKey(colname))
                                        colname = dicFields[colname];
                                }
                                if (dicExists.ContainsKey(colname))
                                    cellvalue = dicExists[colname];
                            }


                            if (cellvalue == null)
                            {
                                sbValues.Append("NULL,");
                            }
                            else if (TransferOracleDate(ref cellvalue))
                            {
                                sbValues.Append(cellvalue).Append(",");
                            }
                            else if (cellvalue.ToString() == "NULL")
                            {
                                sbValues.Append("NULL,");
                            }
                            else
                            {
                                sbValues.Append("'").Append(cellvalue).Append("',");
                            }
                        }
                        if (isEmpty) continue;

                        if (sbValues[sbValues.Length - 1] == '(')
                        {
                            MessageBox.Show("Excel格式不正确\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        else
                        {
                            if (dicNoExists != null && dicNoExists.Count >= 1)
                            {
                                foreach (KeyValuePair<string, string> kv in dicNoExists)
                                {
                                    cellvalue = kv.Value;

                                    if (cellvalue == null)
                                    {
                                        sbValues.Append("NULL,");
                                    }
                                    else if (TransferOracleDate(ref cellvalue))
                                    {
                                        sbValues.Append(cellvalue).Append(",");
                                    }
                                    else if (cellvalue.ToString() == "NULL")
                                    {
                                        sbValues.Append("NULL,");
                                    }
                                    else
                                    {
                                        sbValues.Append("'").Append(cellvalue).Append("',");
                                    }
                                }
                            }
                        }

                        if (sbValues[sbValues.Length - 1] == ',')
                        {
                            sbValues.Remove(sbValues.Length - 1, 1);
                        }
                        sbValues.Append(") \n");
                        sbResult.Append(sbInsert).Append(sbValues);

                        lstResult.Add(sbResult.ToString());
                    }

                    #endregion

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    if (file != null) file.Dispose();
                    file = null;
                    workbook = null;
                    sheet = null;
                }
                #endregion
            }
        }

        /// <summary>
        /// 读取Excel转换为SQL语句
        /// </summary>
        /// <param name="dicResult">读取结果</param>
        /// <param name="primekey">主键名 获取失败则默认取第一个列名</param>
        /// <param name="sheetname">工作表名(亦是数据库表名) 获取错误则默认取第一个工作表名</param>
        /// <param name="bDelBefore">是否插入前先删除</param>
        /// <param name="dicFields">工作表列名对应的字段名[列名,字段名] 默认相同</param>
        /// <param name="dicDefault">字段默认值[字段名,默认值]</param>
        /// <returns>读取结果</returns>
        public static bool ReadExcelToSqlDictionaryByNPOI(ref Dictionary<string, string> dicResult, string primekey, string sheetname = "Sheet1", bool bDelBefore = false, Dictionary<string, string> dicFields = null, Dictionary<string, string> dicDefault = null)
        {
            dicResult = new Dictionary<string, string>();
            string fileNameString = string.Empty;
            if (!ShowOpenForExcelDialog(ref fileNameString)) return false;

            return ReadExcelToSqlDictionaryByNPOI(fileNameString, ref dicResult, primekey, sheetname, bDelBefore, dicFields, dicDefault);
        }

        /// <summary>
        /// 读取Excel转换为SQL语句
        /// </summary>
        /// <param name="fileNameString">文件路径</param>
        /// <param name="dicResult">读取结果</param>
        /// <param name="primekey">主键名 获取失败则默认取第一个列名</param>
        /// <param name="sheetname">工作表名(亦是数据库表名) 获取错误则默认取第一个工作表名</param>
        /// <param name="bDelBefore">是否插入前先删除</param>
        /// <param name="dicFields">工作表列名对应的字段名[列名,字段名] 默认相同</param>
        /// <param name="dicDefault">字段默认值[字段名,默认值]</param>
        /// <returns>读取结果</returns>
        public static bool ReadExcelToSqlDictionaryByNPOI(string fileNameString, ref Dictionary<string, string> dicResult, string primekey, string sheetname = "Sheet1", bool bDelBefore = false, Dictionary<string, string> dicFields = null, Dictionary<string, string> dicDefault = null)
        {
            if (!File.Exists(fileNameString))
            {
                MessageBox.Show(fileNameString + " 文件不存在\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string extensname = Path.GetExtension(fileNameString);
            bool isXSSF = extensname.ToLower() == (".xlsx");
            string tablename = sheetname;
            dicResult = new Dictionary<string, string>();
            FileStream file = null;

            int cellCount = 0;
            int rowCount = 0;


            if (isXSSF)
            {
                #region XLSX

                XSSFWorkbook workbook;
                XSSFSheet sheet;
                XSSFRow headerRow;

                try
                {
                    InitXSSF(fileNameString, ref sheetname, ref file, ref cellCount, ref rowCount, out workbook, out sheet, out headerRow);

                    int iPrimeKey = 0;
                    string strPrimeKey = string.Empty;
                    StringBuilder sbResult = new StringBuilder();
                    //工作表包含的列
                    Dictionary<string, string> dicExists = new Dictionary<string, string>();
                    //工作表不包含的列
                    Dictionary<string, string> dicNoExists = dicDefault;

                    #region 表头信息
                    StringBuilder sbInsert = new StringBuilder("INSERT INTO " + tablename + "(");
                    string colname = "";
                    for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                    {
                        colname = headerRow.GetCell(i).StringCellValue;
                        if (string.IsNullOrEmpty(colname))
                        {
                            MessageBox.Show("Excel格式不正确\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        if (dicFields != null && dicFields.Count >= 1)
                        {
                            if (dicFields.ContainsKey(colname))
                                colname = dicFields[colname];
                        }
                        if (dicDefault != null && dicDefault.Count >= 1)
                        {
                            if (dicDefault.ContainsKey(colname))
                            {
                                dicExists.Add(colname, dicDefault[colname]);
                                dicNoExists.Remove(colname);
                            }
                        }


                        if (colname.ToLower() == primekey.ToLower()) iPrimeKey = i;
                        sbInsert.Append(colname + ",");
                    }

                    if (sbInsert[sbInsert.Length - 1] == '(')
                    {
                        MessageBox.Show("Excel格式不正确\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        if (dicNoExists != null && dicNoExists.Count >= 1)
                        {
                            foreach (KeyValuePair<string, string> kv in dicNoExists)
                            {
                                sbInsert.Append(kv.Key + ",");
                            }
                        }
                    }

                    if (sbInsert[sbInsert.Length - 1] == ',')
                    {
                        sbInsert.Remove(sbInsert.Length - 1, 1);
                    }
                    sbInsert.Append(") ");


                    #endregion

                    #region 表体信息
                    StringBuilder sbValues;
                    XSSFRow row;
                    object cellvalue;
                    for (int i = sheet.FirstRowNum + 1; i <= rowCount; i++)
                    {
                        sbResult = new StringBuilder();
                        sbValues = new StringBuilder("VALUES(");
                        row = (XSSFRow)sheet.GetRow(i);

                        strPrimeKey = Convert.ToString(GetValueByICell(row.GetCell(iPrimeKey)));
                        bool isEmpty = true;
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            cellvalue = GetValueByICell(row.GetCell(j));
                            if (cellvalue != null && !string.IsNullOrEmpty(cellvalue.ToString())) isEmpty = false;
                            if (cellvalue == null && dicExists != null && dicExists.Count >= 1)
                            {
                                colname = headerRow.GetCell(j).StringCellValue;
                                if (string.IsNullOrEmpty(colname)) continue;
                                if (dicFields != null && dicFields.Count >= 1)
                                {
                                    if (dicFields.ContainsKey(colname))
                                        colname = dicFields[colname];
                                }
                                if (dicExists.ContainsKey(colname))
                                    cellvalue = dicExists[colname];
                            }


                            if (cellvalue == null)
                            {
                                sbValues.Append("'',");
                            }
                            else if (cellvalue.ToString() == "NULL")
                            {
                                sbValues.Append("NULL,");
                            }
                            else
                            {
                                sbValues.Append("'").Append(cellvalue).Append("',");
                            }
                        }
                        if (isEmpty) continue;

                        if (sbValues[sbValues.Length - 1] == '(')
                        {
                            MessageBox.Show("Excel格式不正确\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        else
                        {
                            if (dicNoExists != null && dicNoExists.Count >= 1)
                            {
                                foreach (KeyValuePair<string, string> kv in dicNoExists)
                                {
                                    sbValues.Append("'").Append(kv.Value == null ? "" : kv.Value).Append("',");
                                }
                            }
                        }

                        if (sbValues[sbValues.Length - 1] == ',')
                        {
                            sbValues.Remove(sbValues.Length - 1, 1);
                        }
                        sbValues.Append("); \n");
                        if (bDelBefore) sbResult.Append("DELETE " + tablename + " WHERE " + primekey + " = " + strPrimeKey + ";");
                        sbResult.Append(sbInsert).Append(sbValues);

                        if (dicResult.ContainsKey(strPrimeKey)) dicResult.Remove(strPrimeKey);
                        dicResult.Add(strPrimeKey, sbResult.ToString());
                    }

                    #endregion

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    if (file != null) file.Dispose();
                    file = null;
                    workbook = null;
                    sheet = null;
                }
                #endregion
            }
            else
            {
                #region XLS

                HSSFWorkbook workbook;
                HSSFSheet sheet;
                HSSFRow headerRow;

                try
                {
                    InitHSSF(fileNameString, ref sheetname, ref file, ref cellCount, ref rowCount, out workbook, out sheet, out headerRow);

                    int iPrimeKey = 0;
                    string strPrimeKey = string.Empty;
                    StringBuilder sbResult = new StringBuilder();
                    //工作表包含的列
                    Dictionary<string, string> dicExists = new Dictionary<string, string>();
                    //工作表不包含的列
                    Dictionary<string, string> dicNoExists = dicDefault;

                    #region 表头信息
                    StringBuilder sbInsert = new StringBuilder("INSERT INTO " + tablename + "(");
                    string colname = "";
                    for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                    {
                        colname = headerRow.GetCell(i).StringCellValue;
                        if (string.IsNullOrEmpty(colname))
                        {
                            MessageBox.Show("Excel格式不正确\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        if (dicFields != null && dicFields.Count >= 1)
                        {
                            if (dicFields.ContainsKey(colname))
                                colname = dicFields[colname];
                        }
                        if (dicDefault != null && dicDefault.Count >= 1)
                        {
                            if (dicDefault.ContainsKey(colname))
                            {
                                dicExists.Add(colname, dicDefault[colname]);
                                dicNoExists.Remove(colname);
                            }
                        }


                        if (colname.ToLower() == primekey.ToLower()) iPrimeKey = i;
                        sbInsert.Append(colname + ",");
                    }

                    if (sbInsert[sbInsert.Length - 1] == '(')
                    {
                        MessageBox.Show("Excel格式不正确\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        if (dicNoExists != null && dicNoExists.Count >= 1)
                        {
                            foreach (KeyValuePair<string, string> kv in dicNoExists)
                            {
                                sbInsert.Append(kv.Key + ",");
                            }
                        }
                    }

                    if (sbInsert[sbInsert.Length - 1] == ',')
                    {
                        sbInsert.Remove(sbInsert.Length - 1, 1);
                    }
                    sbInsert.Append(") ");


                    #endregion

                    #region 表体信息
                    StringBuilder sbValues;
                    HSSFRow row;
                    object cellvalue;
                    for (int i = sheet.FirstRowNum + 1; i <= rowCount; i++)
                    {
                        sbResult = new StringBuilder();
                        sbValues = new StringBuilder("VALUES(");
                        row = (HSSFRow)sheet.GetRow(i);

                        strPrimeKey = Convert.ToString(GetValueByICell(row.GetCell(iPrimeKey)));
                        bool isEmpty = true;
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            cellvalue = GetValueByICell(row.GetCell(j));
                            if (cellvalue != null && !string.IsNullOrEmpty(cellvalue.ToString())) isEmpty = false;
                            if (cellvalue == null && dicExists != null && dicExists.Count >= 1)
                            {
                                colname = headerRow.GetCell(j).StringCellValue;
                                if (string.IsNullOrEmpty(colname)) continue;
                                if (dicFields != null && dicFields.Count >= 1)
                                {
                                    if (dicFields.ContainsKey(colname))
                                        colname = dicFields[colname];
                                }
                                if (dicExists.ContainsKey(colname))
                                    cellvalue = dicExists[colname];
                            }


                            if (cellvalue == null)
                            {
                                sbValues.Append("'',");
                            }
                            else if (cellvalue.ToString() == "NULL")
                            {
                                sbValues.Append("NULL,");
                            }
                            else
                            {
                                sbValues.Append("'").Append(cellvalue).Append("',");
                            }
                        }
                        if (isEmpty) continue;

                        if (sbValues[sbValues.Length - 1] == '(')
                        {
                            MessageBox.Show("Excel格式不正确\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        else
                        {
                            if (dicNoExists != null && dicNoExists.Count >= 1)
                            {
                                foreach (KeyValuePair<string, string> kv in dicNoExists)
                                {
                                    sbValues.Append("'").Append(kv.Value == null ? "" : kv.Value).Append("',");
                                }
                            }
                        }

                        if (sbValues[sbValues.Length - 1] == ',')
                        {
                            sbValues.Remove(sbValues.Length - 1, 1);
                        }
                        sbValues.Append("); \n");
                        if (bDelBefore) sbResult.Append("DELETE " + tablename + " WHERE " + primekey + " = " + strPrimeKey + ";");
                        sbResult.Append(sbInsert).Append(sbValues);

                        if (dicResult.ContainsKey(strPrimeKey)) dicResult.Remove(strPrimeKey);
                        dicResult.Add(strPrimeKey, sbResult.ToString());
                    }

                    #endregion

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    if (file != null) file.Dispose();
                    file = null;
                    workbook = null;
                    sheet = null;
                }
                #endregion
            }
        }

        /// <summary>
        /// 读取Excel转换为List_T
        /// (必须包含列名,对应属性名)
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="lstResult">读取结果</param>
        /// <param name="sheetname">工作表名 获取错误则默认取第一个工作表名</param>
        /// <param name="dicFields">工作表列名对应的字段名[列名,字段名] 默认相同</param>
        /// <param name="dicDefault">字段默认值[字段名,默认值]</param>
        /// <returns>读取结果</returns>
        public static bool ReadExcelToListByNPOI<T>(ref List<T> lstResult, string sheetname = "Sheet1", Dictionary<string, string> dicFields = null, Dictionary<string, string> dicDefault = null) where T : new()
        {
            lstResult = new List<T>();
            string fileNameString = string.Empty;
            if (!ShowOpenForExcelDialog(ref fileNameString)) return false;

            return ReadExcelToListByNPOI<T>(fileNameString, ref lstResult, sheetname, dicFields, dicDefault);
        }

        /// <summary>
        /// 读取Excel转换为List_T
        /// (必须包含列名,对应属性名)
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="fileNameString">Excel文件路径</param>
        /// <param name="lstResult">读取结果</param>
        /// <param name="sheetname">工作表名 获取错误则默认取第一个工作表名</param>
        /// <param name="dicFields">工作表列名对应的字段名[列名,字段名] 默认相同</param>
        /// <param name="dicDefault">字段默认值[字段名,默认值]</param>
        /// <returns>读取结果</returns>
        public static bool ReadExcelToListByNPOI<T>(ref string fileNameString, ref List<T> lstResult, string sheetname = "Sheet1", Dictionary<string, string> dicFields = null, Dictionary<string, string> dicDefault = null) where T : new()
        {
            lstResult = new List<T>();

            if (!ShowOpenForExcelDialog(ref fileNameString)) return false;

            return ReadExcelToListByNPOI<T>(fileNameString, ref lstResult, sheetname, dicFields, dicDefault);
        }

        /// <summary>
        /// 读取Excel转换为List_T
        /// (必须包含列名,对应属性名)
        /// </summary>
        /// <param name="fileNameString">文件路径</param>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="lstResult">读取结果</param>
        /// <param name="sheetname">工作表名 获取错误则默认取第一个工作表名</param>
        /// <param name="dicFields">列名对应的字段名 默认相同</param>
        /// <returns>读取结果</returns>
        public static bool ReadExcelToListByNPOI<T>(string fileNameString, ref List<T> lstResult, string sheetname = "Sheet1", Dictionary<string, string> dicFields = null, Dictionary<string, string> dicDefault = null) where T : new()
        {
            if (!File.Exists(fileNameString))
            {
                MessageBox.Show(fileNameString + " 文件不存在\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string extensname = Path.GetExtension(fileNameString);
            bool isXSSF = extensname.ToLower() == (".xlsx");
            lstResult = new List<T>();
            FileStream file = null;

            int cellCount = 0;
            int rowCount = 0;


            if (isXSSF)
            {
                #region XLSX

                XSSFWorkbook workbook;
                XSSFSheet sheet;
                XSSFRow headerRow;

                try
                {
                    InitXSSF(fileNameString, ref sheetname, ref file, ref cellCount, ref rowCount, out workbook, out sheet, out headerRow);

                    PropertyInfo[] arrPi = typeof(T).GetProperties();
                    PropertyInfo pi;
                    string colname = "";

                    T t;
                    XSSFRow row;
                    for (int i = sheet.FirstRowNum + 1; i <= rowCount; i++)
                    {
                        t = new T();
                        row = (XSSFRow)sheet.GetRow(i);

                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            colname = headerRow.GetCell(j).StringCellValue;
                            if (string.IsNullOrEmpty(colname)) continue;
                            if (dicFields != null && dicFields.Count >= 1)
                            {
                                if (dicFields.ContainsKey(colname))
                                    colname = dicFields[colname];
                            }

                            pi = null;
                            pi = arrPi.FirstOrDefault<PropertyInfo>(p => p.Name.ToLower() == colname.ToLower());
                            if (pi == null) continue;

                            SetPropertyByICell<T>(pi, t, row.GetCell(j));
                        }

                        object pivalue;
                        foreach (KeyValuePair<string, string> kv in dicDefault)
                        {
                            pi = arrPi.FirstOrDefault<PropertyInfo>(p => p.Name.ToLower() == kv.Key.ToLower());
                            if (pi == null) continue;

                            pivalue = pi.GetValue(t, null);
                            if (pivalue == null)
                            {
                                SetPropertyValue<T>(pi, t, kv.Value);
                            }
                        }


                        lstResult.Add(t);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    if (file != null) file.Dispose();
                    file = null;
                    workbook = null;
                    sheet = null;
                }
                #endregion
            }
            else
            {
                #region XLS

                HSSFWorkbook workbook;
                HSSFSheet sheet;
                HSSFRow headerRow;

                try
                {
                    InitHSSF(fileNameString, ref sheetname, ref file, ref cellCount, ref rowCount, out workbook, out sheet, out headerRow);

                    PropertyInfo[] arrPi = typeof(T).GetProperties();
                    PropertyInfo pi;
                    string colname = "";

                    T t;
                    HSSFRow row;
                    for (int i = sheet.FirstRowNum + 1; i <= rowCount; i++)
                    {
                        t = new T();
                        row = (HSSFRow)sheet.GetRow(i);

                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            colname = headerRow.GetCell(j).StringCellValue;
                            if (string.IsNullOrEmpty(colname)) continue;
                            if (dicFields != null && dicFields.Count >= 1)
                            {
                                if (dicFields.ContainsKey(colname))
                                    colname = dicFields[colname];
                            }

                            pi = null;
                            pi = arrPi.FirstOrDefault<PropertyInfo>(p => p.Name.ToLower() == colname.ToLower());
                            if (pi == null) continue;

                            SetPropertyByICell<T>(pi, t, row.GetCell(j));
                        }

                        object pivalue;
                        foreach (KeyValuePair<string, string> kv in dicDefault)
                        {
                            pi = arrPi.FirstOrDefault<PropertyInfo>(p => p.Name.ToLower() == kv.Key.ToLower());
                            if (pi == null) continue;

                            pivalue = pi.GetValue(t, null);
                            if (pivalue == null)
                            {
                                SetPropertyValue<T>(pi, t, kv.Value);
                            }
                        }


                        lstResult.Add(t);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    if (file != null) file.Dispose();
                    file = null;
                    workbook = null;
                    sheet = null;
                }
                #endregion
            }
        }

        /// <summary>
        /// 测试中
        /// </summary>
        /// <param name="strResult">读取结果</param>
        /// <param name="sheetname">工作表名(亦是数据库表名) 获取错误则默认取第一个工作表名</param>
        /// <returns>读取结果</returns>
        public static bool ReadExcelToSqlstrByJET(ref string strResult, string sheetname = "Sheet1")
        {
            strResult = string.Empty;
            StringBuilder sbResult = new StringBuilder();
            string fileNameString = string.Empty;
            if (!ShowOpenForExcelDialog(ref fileNameString)) return false;

            try
            {
                sbResult.Append("exec sp_configure 'show advanced options',1;go");
                sbResult.Append("reconfigure;go");
                sbResult.Append("exec sp_configure 'Ad Hoc Distributed Queries',1;go");
                sbResult.Append("reconfigure;go");
                //sbResult.Append("INSERT INTO " + sheetname + "SELECT * FROM OPENROWSET('MICROSOFT.JET.OLEDB.4.0','Excel 5.0;HDR=YES;DATABASE=" + fileNameString + "'," + sheetname + "$);go");
                sbResult.Append("SELECT * INTO " + sheetname + " FROM OPENROWSET('MICROSOFT.JET.OLEDB.4.0','Excel 5.0;HDR=YES;DATABASE=" + fileNameString + "'," + sheetname + "$);go");
                sbResult.Append("reconfigure;go");
                sbResult.Append("exec sp_configure 'Ad Hoc Distributed Queries',0;go");
                sbResult.Append("reconfigure;go");
                sbResult.Append("exec sp_configure 'show advanced options',0;go");
                sbResult.Append("reconfigure;go");

                strResult = sbResult.ToString();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n读取失败! ", "错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
            }
        }

        #endregion
    }
}
