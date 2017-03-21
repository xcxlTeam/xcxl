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
        /// 到货日期
        /// </summary>
        public string PromDate { get; set; }
        /// <summary>
        /// 批次数量
        /// </summary>
        public decimal batchQty { get; set; }
        /// <summary>
        /// 本批件数
        /// </summary>
        public int BatchNum { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal iQty { get; set; }
        /// <summary>
        /// 件数
        /// </summary>
        public int iNum { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string PurchUnit { get; set; }
        /// <summary>
        /// 来源地
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 无变形
        /// </summary>
        public bool Deformation { get; set; }

        /// <summary>
        /// 无渗漏
        /// </summary>
        public bool Leakage { get; set; }

        /// <summary>
        /// 防盗盖完好
        /// </summary>
        public bool chkLid { get; set; }

        /// <summary>
        /// 标签及内容齐全
        /// </summary>
        public bool Label { get; set; }

        /// <summary>
        /// 有无合格证明
        /// </summary>
        public bool Certificate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 中文名称相符
        /// </summary>
        public bool InvNameCH { get; set; }

        /// <summary>
        /// 英文名称相符
        /// </summary>
        public bool InvNameEN { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public string ProductionDate { get; set; }

        /// <summary>
        /// 收货日期
        /// </summary>
        public string ReceiveDate { get; set; }

        /// <summary>
        /// 是否保质期内
        /// </summary>
        public bool DueDate { get; set; }

        /// <summary>
        /// 拒收
        /// </summary>
        public bool Rejection { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        public string Warehouse { get; set; }

       
    }
}
