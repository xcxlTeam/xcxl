using BLL.Basic.Menu;
using BLL.Basic.User;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BLL.Common
{
    public class Common_Func
    {

        private static Dictionary<string, string> _comboBoxSql = new Dictionary<string, string> 
        {
            {"cbbSex","SELECT ParameterID AS ID,ParameterName AS NAME FROM T_PARAMETER WHERE GROUPNAME = 'User_Sex' ORDER BY ParameterID "},
            {"cbbUserType","SELECT ParameterID AS ID,ParameterName AS NAME FROM T_PARAMETER WHERE GROUPNAME = 'User_UserType' ORDER BY ParameterID "},
            {"cbbUserStatus","SELECT ParameterID AS ID,ParameterName AS NAME FROM T_PARAMETER WHERE GROUPNAME = 'User_UserStatus' ORDER BY ParameterID "},
            {"cbbMenuType","SELECT ParameterID AS ID,ParameterName AS NAME FROM T_PARAMETER WHERE GROUPNAME = 'Menu_MenuType' ORDER BY ParameterID "},
            {"cbbMenuStatus","SELECT ParameterID AS ID,ParameterName AS NAME FROM T_PARAMETER WHERE GROUPNAME = 'Menu_MenuStatus' ORDER BY ParameterID "},
            {"cbbUserGroupType","SELECT ParameterID AS ID,ParameterName AS NAME FROM T_PARAMETER WHERE GROUPNAME = 'UserGroup_UserGroupType' ORDER BY ParameterID "},
            {"cbbUserGroupStatus","SELECT ParameterID AS ID,ParameterName AS NAME FROM T_PARAMETER WHERE GROUPNAME = 'UserGroup_UserGroupStatus' ORDER BY ParameterID "},
            {"cbbAreaType","SELECT ParameterID AS ID,ParameterName AS NAME FROM T_PARAMETER WHERE GROUPNAME = 'Area_AreaType' ORDER BY ParameterID "},
            {"cbbAreaStatus","SELECT ParameterID AS ID,ParameterName AS NAME FROM T_PARAMETER WHERE GROUPNAME = 'Area_AreaStatus' ORDER BY ParameterID "},
            {"cbbHouseType","SELECT ParameterID AS ID,ParameterName AS NAME FROM T_PARAMETER WHERE GROUPNAME = 'House_HouseType' ORDER BY ParameterID "},
            {"cbbHouseStatus","SELECT ParameterID AS ID,ParameterName AS NAME FROM T_PARAMETER WHERE GROUPNAME = 'House_HouseStatus' ORDER BY ParameterID "},
            {"cbbWarehouseType","SELECT ParameterID AS ID,ParameterName AS NAME FROM T_PARAMETER WHERE GROUPNAME = 'Warehouse_WarehouseType' ORDER BY ParameterID "},
            {"cbbWarehouseStatus","SELECT ParameterID AS ID,ParameterName AS NAME FROM T_PARAMETER WHERE GROUPNAME = 'Warehouse_WarehouseStatus' ORDER BY ParameterID "},
            {"colQualityType","SELECT ParameterID AS ID,ParameterName AS NAME FROM T_PARAMETER WHERE GROUPNAME = 'QualityType' ORDER BY ParameterID "},
            {"cbbCheckType","SELECT ParameterID AS ID,ParameterName AS NAME FROM T_PARAMETER WHERE GROUPNAME = 'Check_CheckType' ORDER BY ParameterID "},
            {"cbbCheckStatus","SELECT ParameterID AS ID,ParameterName AS NAME FROM T_PARAMETER WHERE GROUPNAME = 'Check_CheckStatus' ORDER BY ParameterID "},

            
            {"cbbParentMenu","SELECT 0 AS ID,'根节点' AS NAME UNION SELECT * FROM (SELECT top 100000000000 ID,MENUNAME AS NAME FROM T_MENU WHERE MENUTYPE <= 2 ORDER BY MENUTYPE, NODELEVEL, ID) a"},
            {"cbbWarehouse","SELECT ID,WarehouseName AS NAME FROM T_Warehouse where ISDEL <> 2 AND WarehouseStatus <> 2 "},

            {"cbxType","SELECT ParameterID AS ID,ParameterName AS NAME FROM T_PARAMETER WHERE GROUPNAME = 'MaterialRequest_VoucherType' ORDER BY ParameterID "},
        };

        public static List<ComboBoxItem> GetComboBoxItem(string strSql)
        {
            List<ComboBoxItem> items = new List<ComboBoxItem>();
            using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, strSql))
            {
                while (dr.Read())
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.ID = int.Parse(dr["ID"].ToString());
                    item.Name = dr["Name"].ToString();
                    items.Add(item);
                }
            }

            return items;
        }

        public static bool GetComboBoxItem(string key, ref List<ComboBoxItem> comboxBoxItemList, ref string strError)
        {
            if (_comboBoxSql.ContainsKey(key))
            {
                string strSql = _comboBoxSql[key];
                try
                {
                    comboxBoxItemList = GetComboBoxItem(strSql);
                    return true;
                }
                catch (Exception ex)
                {
                    strError = "获取" + key + "失败！" + ex.Message + "\r\n" + ex.TargetSite;
                    return false;
                }
            }
            else
            {
                strError = "key  " + key + "的sql未找到!";
                return false;
            }
        }

        public static List<ComboBoxItem> GetParentMenuByMenu(MenuInfo menu)
        {
            List<ComboBoxItem> items = new List<ComboBoxItem>();
            Menu_DB _db = new Menu_DB();
            using (SqlDataReader dr = _db.GetParentSelectMenu(menu))
            {
                while (dr.Read())
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.ID = int.Parse(dr["ID"].ToString());
                    item.Name = dr["MenuName"].ToString();
                    items.Add(item);
                }
            }

            return items;
        }

        public static string AddWhereAnd(string strSql, bool hadWhere)
        {
            string strReturn = strSql;
            if (hadWhere == false)
            {
                strSql += " Where ";
            }
            else
            {
                strSql += " And ";
            }

            return strSql;

        }

        public static string AddWhereOr(string strSql, bool hadWhere)
        {
            string strReturn = strSql;
            if (hadWhere == false)
            {
                strSql += " Where ";
            }
            else
            {
                strSql += " Or ";
            }

            return strSql;

        }
        public static bool readerExists(SqlDataReader dr, string columnName)
        {
            if (string.IsNullOrEmpty(columnName)) return false;

            int count = dr.FieldCount;
            for (int i = 0; i < count; i++)
            {
                if (dr.GetName(i).ToUpper() == columnName.ToUpper()) return true;
            }
            return false;
        }

        public static bool CheckImportTable(int iType, UserInfo user, ref string strError)
        {
            switch (iType)
            {
                case 1:
                    Basic.Area.Area_DB areadb = new Basic.Area.Area_DB();
                    return areadb.CheckImportTable(ref strError);

                case 2:
                    Stock.Stock_DB stockdb = new Stock.Stock_DB();
                    return stockdb.CheckImportTable(ref strError);

                default:
                    strError = "找不到对应的导入类型";
                    return false;
            }
        }

        public static bool UpLoadSql(List<string> lstSql, UserInfo user, ref string strError)
        {
            if (lstSql == null || lstSql.Count <= 0)
            {
                strError = "上传数据不能为空";
                return false;
            }

            if (OperationSql.ExecuteNonQueryList(lstSql, ref strError) >= 1)
            {
                return true;
            }
            else
            {
                if (string.IsNullOrEmpty(strError))
                {
                    try
                    {
                        OperationSql.ExecuteNonQuery2(CommandType.Text, lstSql[0], null);
                        if (lstSql.Count >= 2) OperationSql.ExecuteNonQuery2(CommandType.Text, lstSql[1], null);
                    }
                    catch (Exception ex)
                    {
                        strError = ex.Message;
                    }
                }
                return false;
            }
        }

        //public static bool DealImport(int iType, UserInfo user, ref string strError)
        //{
        //    switch (iType)
        //    {
        //        case 1:
        //            Basic.Area.Area_DB areadb = new Basic.Area.Area_DB();
        //            return areadb.DealImport(ref strError);

        //        case 2:
        //            Stock.Stock_DB stockdb = new Stock.Stock_DB();
        //            return stockdb.DealImport(ref strError);

        //        default:
        //            strError = "找不到对应的导入类型";
        //            return false;
        //    }
        //}

        public static bool IsSqlError(string ErrorMsg, ref string strError)
        {
            try
            {
                int index = ErrorMsg.ToUpper().IndexOf("ORA-");
                if (index >= 0)
                {
                    strError = string.Format("数据库连接错误,请重试!{0}{1}", Environment.NewLine, ErrorMsg.Substring(ErrorMsg.IndexOf(':', index) + 1).Trim());
                    return true;
                }
                else
                {
                    strError = ErrorMsg;
                    return false;
                }
            }
            catch
            {
                strError = ErrorMsg;
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns>128B码：ChrW(204)</returns>
        public static string StrToCode128B(string barcode)
        {
            int checkB;
            int i, j;
            string temp;

            try
            {
                i = 0;
                checkB = 1; //开始位的码值为104 mod 103 =1

                while (i < barcode.Length)
                {
                    temp = barcode.Substring(i, 1);
                    j = temp[0].ToInt32();    //不过滤无效字符,比如汉字

                    if (j < 135)
                    {
                        j = j - 32;
                    }
                    else if (j > 134)
                    {
                        j = j - 100;
                    }

                    checkB = (checkB + (i + 1) * j) % 103;    //计算校验位
                    i++;
                }

                if (checkB > 0 && checkB < 95)    //有的资料直接求103的模,解说不充分,因为有的校验位超过127时,系统会"吃"掉它们(连带休止符).
                {
                    checkB = checkB + 32;
                }
                else if (checkB > 94)              //字体设置时,字模被定义了2个值.观察字体文件时能发现.
                {
                    checkB = checkB + 100;
                }

                return string.Format("{0}{1}{2}{3}", (char)204, barcode, checkB > 0 ? (char)checkB : (char)32, (char)206);
            }
            catch
            {
                return barcode;
            }
        }

        public static int SpiltString(string text, int length, ref string[] arr)
        {
            if (string.IsNullOrEmpty(text))
            {
                arr[0] = " ";
                return 1;
            }

            int count = 0;
            byte[] bytes = Encoding.GetEncoding(936).GetBytes(text);
            count = (int)Math.Ceiling(Convert.ToDouble(bytes.Length) / Convert.ToDouble(length));
            Array.Resize(ref arr, count);

            bool bBorrow = false;
            string strLine;
            string strTemp;
            char cEnd;

            if (count == 1)
            {
                arr[0] = text;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    byte[] line = new byte[length + 1];
                    int cur = 0;
                    for (int j = 0; j < length; j++)
                    {
                        if (bBorrow && j == 0) continue;

                        cur = i * length + j;
                        if (cur >= bytes.Length) break;

                        line[j] = bytes[cur];
                    }

                    bBorrow = false;
                    strLine = Encoding.GetEncoding(936).GetString(line).Trim('\0');
                    if (!string.IsNullOrEmpty(strLine) && strLine.Length >= 2)
                    {
                        strTemp = strLine.Substring(0, strLine.Length - 1);
                        if (!string.IsNullOrEmpty(strTemp))
                        {
                            cEnd = text[text.IndexOf(strTemp) + strTemp.Length];

                            if (strLine[strLine.Length - 1] != cEnd)
                            {
                                strLine = strTemp + cEnd;
                                bBorrow = true;
                            }
                        }
                    }

                    arr[i] = strLine;
                }
            }

            return count;
        }

        public static bool IsAllZero(string text)
        {
            return Regex.IsMatch(text, @"^[0]*$");
        }
    }
}
