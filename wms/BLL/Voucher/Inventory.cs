using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Voucher
{
    public class Inventory
    {
        /// <summary>
        /// 过敏原
        /// </summary>
        public string Allergic { get; set; }
        /// <summary>
        /// 现场物料标记				
        /// </summary>
        public string SceneMaterial { get; set; }
        /// <summary>
        /// 生产移交已完成							
        /// </summary>
        public string UserFlag { get; set; }
        /// <summary>
        /// 物料属性代码				
        /// </summary>
        public string InvtType { get; set; }
        /// <summary>
        /// 保质期				
        /// </summary>
        public int ShelfLife { get; set; }
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
        /// <summary>
        /// 毛重
        /// </summary>
        public decimal StdGrossWt { get; set; }
        /// <summary>
        /// 净重
        /// </summary>
        public decimal NetWt { get; set; }
        /// <summary>
        /// 皮重
        /// </summary>
        public decimal StdTareWt { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string StkUnit { get; set; }
    }
}
