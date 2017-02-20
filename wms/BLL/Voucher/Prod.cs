using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Voucher
{
    /// <summary>
    /// 生产单
    /// </summary>
    public class Prod : Inventory
    {
        
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime StartDate { get; set; }	//开始日期
        
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime EndDate { get; set; }	//结束日期						
        
        /// <summary>
        /// 生产单号
        /// </summary>
        public string ProdOrdID { get; set; }//生产单号ProdOrdID
        /// <summary>
        /// 产品编号
        /// </summary>
        public string PInvtID { get; set; }//产品编号
		/// <summary>
        /// 预订数量
		/// </summary>
        public decimal QtytoProd { get; set; }//预订数量	
		/// <summary>
        /// 批号
		/// </summary>
        public string LotSerNbr { get; set; }//批号	
		/// <summary>
        /// 计划时间
		/// </summary>
        public DateTime ProdDate { get; set; }//计划时间
		/// <summary>
        /// 出货日
		/// </summary>
        public DateTime ShipDate { get; set; }//出货日	
		/// <summary>
        /// 仓库
		/// </summary>
        public string SiteID { get; set; }//仓库	
		/// <summary>
        /// 库位
		/// </summary>
        public string WhseLoc { get; set; }//库位	
		/// <summary>
        /// Remark2
		/// </summary>
        public string Remark2 { get; set; }//Remark 2	
        /// <summary>
        /// 客户订单号
        /// </summary>
        public string SONbr { get; set; }//客户订单号
        /// <summary>
        /// 原料编号
        /// </summary>
        public string MInvtID { get; set; }//原料编号	
        /// <summary>
        /// 数量
        /// </summary>
        public decimal QtyReq { get; set; }//数量	
        /// <summary>
        /// 制法
        /// </summary>
        public string ProdMgrID { get;set; }
        /// <summary>
        /// 建筑编号
        /// </summary>
        public string BuildingNo { get; set; }

    }
}
