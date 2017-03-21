using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BLL.Common;

namespace BLL.Basic.MustReturnMaterial
{
    public class SpecialReturnMaterial:Common.BasicInfo
    {
        /// <summary>
        /// 物料属性代码				
        /// </summary>
        public string InvtType { get; set; }
        /// <summary>
        /// 物料号
        /// </summary>
        public string InvtID { get; set; }
        /// <summary>
        /// 中文名称
        /// </summary>
        public string CHDesc { get; set; }
        /// <summary>
        /// 英文名称
        /// </summary>
        public string Descr { get; set; }
    }
    public  class MustReturnRule
    {
        public static string PropertyName { get; set; }

        public static int PropertyIndex { get; set; }

        public static List<string> lstPermit { get; set; }
    }
    /// <summary>
    /// 通用规则（元素指定位置的字符在结果集中）
    /// </summary>
    public class CommonRule : MustReturnRule
    {
        public CommonRule()
            : base()
        {
            PropertyName = "InvtType";
            PropertyIndex = 1;
            lstPermit = new List<string> { "0", "1" };
        }
    }
    /// <summary>
    /// 特殊规则（元素本身在结果集中）
    /// </summary>
    public class SpecialRule : MustReturnRule
    {
        public SpecialRule()
            : base()
        {
            PropertyName = "InvtID";
            PropertyIndex = -1;
            lstPermit = GetSpecialList(PropertyName);
        }

        public static List<string> GetSpecialList(string fieldName)
        {
            List<string> lstPermit = new List<string>();
            try
            {
                SpecialReturnMaterial_DB _db = new SpecialReturnMaterial_DB();
                using (SqlDataReader dr = _db.GetSpecialList(fieldName))
                {
                    while (dr.Read())
                    {
                        lstPermit.Add(dr[0].ToDBString());
                    }
                    if (lstPermit.Count == 0)
                    {
                        return null;
                    }
                }
                return lstPermit;
            }
            catch
            {
                return null;
            }
        }
    }

}
