using BLL.MaterialDocument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.OutStock
{
    public class OutStock_Model
    {        
        /// <summary>
        /// 主表ID
        /// </summary>
        public int ID { set; get; }

      
        /// <summary>
        /// 单据号
        /// </summary>
        public string VoucherNo { get; set; }
        /// <summary>
        /// 单据类型,生产作业领料单(生产订单)、生产转储单、生产补料单、研发领料单
        /// </summary>
        public int VoucherType { get; set; }
        /// <summary>
        /// 任务号
        /// </summary>
        public string TaskNo { get; set; }

        public string SupCode { get; set; }

        public string SupName { get; set; }

        public string CustomerCode { get; set; }

        public string CustomerName { get; set; }

        public string Plant { get; set; }

        public string PlantName { get; set; }

        public string Creater { get; set; }
        public string Operator { get; set; }

        public DateTime CreateDate { get; set; }

        public List<OutStockDetails_Model> lstOutStockDetails { get; set; }

        public MaterialDoc_Model materialDocModel { get; set; }

        /// <summary>
        /// 是否出库过账
        /// </summary>
        public int IsOutStockPost { get; set; }

        /// <summary>
        /// 是否下架过账
        /// </summary>
        public int IsUnderShelvePost { get; set; }

       

        public string MaterialDoc { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string MoveType { get; set; }

        public string Remark { get; set; }
    }
}
