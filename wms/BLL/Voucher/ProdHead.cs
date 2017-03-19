using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Voucher
{
    /// <summary>
    /// 生产单
    /// </summary>
    public class ProdHead
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
        /// 制法
        /// </summary>
        public string ProdMgrID { get;set; }
        /// <summary>
        /// 建筑编号
        /// </summary>
        public string BuildingNo { get; set; }
        /// <summary>
        /// 订单需求明细
        /// </summary>
        public List<ProdDetails> lstDetails { get; set; }

        /// <summary>
        /// 状态 S成功 E 失败
        /// </summary>
        public String Status { get; set; }
        /// <summary>
        /// 失败消息
        /// </summary>
        public String Message { get; set; }


        #region 物料需求计算用
        /// <summary>
        /// 物料需求计算主表ID
        /// </summary>
        public int AllotID { get; set; }
        /// <summary>
        /// 物料需求计算单号
        /// </summary>
        public string AllotNo { get; set; }
        /// <summary>
        /// 物料需求计算用户编号
        /// </summary>
        public string AllotUserNo { get; set; }
        /// <summary>
        /// 物料需求计算日期
        /// </summary>
        public DateTime AllotDate { get; set; }
        #endregion



    }
}
