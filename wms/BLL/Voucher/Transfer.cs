using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Voucher
{
    public class Transfer:Inventory
    {
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
        public DateTime TranDate { get; set; }		
	

							
								
								
								
								
								

			
								
								
								

    }
}
