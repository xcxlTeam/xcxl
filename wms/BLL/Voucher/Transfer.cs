using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Voucher
{
    public class Transfer:Inventory
    {
        /// <summary>
        /// 状态 S成功 E 失败
        /// </summary>
        public String Status { get; set; }
        /// <summary>
        /// 失败消息
        /// </summary>
        public String Message { get; set; }
        /// <summary>
        /// BatchNumber
        /// </summary>
        public string BatNbr	{get;set;}	
        /// <summary>
        /// 出仓
        /// </summary>
        public string SiteID	{get;set;}	
		/// <summary>
		/// 入仓
		/// </summary>
        public string ToSiteID	{get;set;}
        /// <summary>
        /// 操作人
        /// </summary>
        public string RefNbr { get; set; }
		/// <summary>
		/// 出库位
		/// </summary>
        public string WhseLoc	{get;set;}		
        /// <summary>
        /// 入库位
        /// </summary>
        public string ToWhseloc	{get;set;}	
	    /// <summary>
	    /// 批号
	    /// </summary>
        public string LotSerNbr	{get;set;}	
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Qty	{get;set;}
        /// <summary>
        /// 转库单日期
        /// </summary>
        public string TranDate { get; set; }		
	
    }
}
