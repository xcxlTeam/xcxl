using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Voucher
{
    public class ReceiptDetails:Inventory
    {
        /// <summary>
        /// 采购订单号
        /// </summary>
        public string PoNbr { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        public int VendID { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 供应商地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 供应商电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 货币
        /// </summary>
        public string CuryID { get; set; }
        /// <summary>
        /// 行号
        /// </summary>
        public string LineRef { get; set; }
        /// <summary>
        /// 订单数量
        /// </summary>
        public decimal QtyOrd { get; set; }
        /// <summary>
        /// 已接收数量
        /// </summary>
        public decimal QtyRcvd { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        public string cBatch { get; set; }
        /// <summary>
        /// 原厂批号
        /// </summary>
        public string VendBatch { get; set; }
        /// <summary>
        /// 批次数量
        /// </summary>
        public decimal batchQty { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal iQty { get; set; }
        /// <summary>
        /// 件数
        /// </summary>
        public int iNum { get; set; }
        /// <summary>
        /// 到货日期
        /// </summary>
        public DateTime PromDate { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string PurchUnit { get; set; }
    }
}
