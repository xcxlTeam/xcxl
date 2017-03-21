using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Voucher
{
    public class ReceiptHead 
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
        /// 单位
        /// </summary>
        public string PurchUnit { get; set; }

        public string BatNbr { get; set; }

        public string RcptNbr { get; set; }
       

        public List<ReceiptDetails> lstDetails { get; set; }

        /// <summary>
        /// 状态 S成功 E 失败
        /// </summary>
        public String Status { get; set; }
        /// <summary>
        /// 失败消息
        /// </summary>
        public String Message { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderState { get; set; }
        /// <summary>
        /// 退货类型
        /// </summary>
        public string ReceiptType { get; set; }

    }

}
