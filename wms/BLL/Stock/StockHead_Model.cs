using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Stock
{
    public class StockHead_Model
    {
        public StockHead_Model() { }
        public StockHead_Model(Stock_Model child)
        {
            this.MaterialNo = child.MaterialNo;
            this.BatchNo = child.BatchNo;
            this.MaterialCHDesc = child.MaterialCHDesc;
            this.MaterialENDesc = child.MaterialENDesc;
            this.ShelfLife = child.ShelfLife;
            this.iQuantity = child.Qty;
            this.iNum = child.Num;
            this.lstStockInfo = new List<Stock_Model> { child };

        }
        public List<Stock_Model> lstStockInfo { get; set; }

        public string Status { get; set; } //状态 S成功 E 失败

        public string Message { get; set; } //失败消息

        public string WarehouseNo { get; set; }

        public string HouseNo { get; set; }

        public string AreaNo { get; set; }

        public string WarehouseName { get; set; }

        public string HouseName { get; set; }

        public string AreaName { get; set; }

        public string MaterialNo { get; set; }
        /// <summary>
        /// 英文名称
        /// </summary>
        public string MaterialENDesc { get; set; }
        /// <summary>
        /// 中文名称
        /// </summary>
        public string MaterialCHDesc { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        public string BatchNo { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public decimal iQuantity { get; set; }
        /// <summary>
        /// 库存件数
        /// </summary>
        public int iNum { get; set; }
        public decimal fOutQuantity { get; set; }
        public int fOutNum { get; set; }
        public decimal fInQuantity { get; set; }
        public int fInNum { get; set; }
        public decimal fTransInQuantity { get; set; }
        public int fTransInNum { get; set; }
        public decimal fTransOutQuantity { get; set; }
        public int fTransOutNum { get; set; }
        public decimal fPlanQuantity { get; set; }
        public int fPlanNum { get; set; }
        public decimal fDisableQuantity { get; set; }
        public int fDisableNum { get; set; }
        public decimal fStopQuantity { get; set; }
        public int fStopNum { get; set; }
        public string dMdate { get; set; }
        public string dVdate { get; set; }
        /// <summary>
        /// 保质期(天)				
        /// </summary>
        public int ShelfLife { get; set; }

    }
}
