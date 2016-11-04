using BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BLL.DeliveryReceive
{
    [Serializable]
    public class DeliveryReceiveDetail_Model
    {
        
        public string Comba { get; set; } //京信名称
       
        public string DeliveryNo { get; set; } //送货单号

        
        public string CreateTime { get; set; } //创建时间

       
        public string RowNo { get; set; } //PO行号

        
        public string VoucherNo { get; set; } //PO号

        
        public string MaterialNo { get; set; } //物料编号

        
        public string MaterialDesc { get; set; }//物料描述

        public string MaterialStd { get; set; }//物料规格

        public string ClaimArriveTime { get; set; }//要求到货时间

       
        public string Unit { get; set; }//单位

        
        public int CurrentlyDeliveryNum { get; set; }//当前交货数量

       
        public int ClaimDeliveryNum { get; set; }//要求交货数量

       
        public int ReadyDeliveryNum { get; set; }//已交货数量

        
        public int WaitDeliveryNum { get; set; }//待交货数量

       
        public int InRoadDeliveryNum { get; set; }//在途数量

        
        public string ReceiveTime { get; set; } //接收时间

        
        public string DeliveryAddress { get; set; }//交货地址

        
        public string CorrespondDepartment { get; set; }//对应部门

      
        public string WorkCode { get; set; }  //作业单号

        public string JingxinName { get; set; } //京信名称

        
        public string Plant { get; set; }//京信工厂

        
        public string PlantName { get; set; }//京信工厂

        
        public string PrdVersion { get; set; } //对应版本号        

        
        public string StorageLoc { get; set; }//库存地点

       
        public decimal ReceiveQty { get; set; }//实际收货数量

        
        public int IsUrgent { get; set; }//是否加急 1-不加急 2-加急

        
        public int PackCount { get; set; }//箱子个数

        
        public string PrdReturnReason { get; set; }//生产退料原因

       
        public string Barcode { get; set; }

        
        public string SerialNo { get; set; }

        
        public List<OutBarcode_Model> lstOutBarCode { get; set; }

        
        public int IsROHS { get; set; }//1-不显示rohs 2-显示

        /// <summary>
        /// 需求跟踪号，生产退料
        /// </summary>
        
        public string TrackNo { get; set; }

        /// <summary>
        /// 预留项目号，生产退料
        /// </summary>
        
        public string ReserveNumber { get; set; }

        /// <summary>
        /// 合格数量
        /// </summary>
        
        public decimal QualityQty { get; set; }

        /// <summary>
        /// 本次合格数量
        /// </summary>
       
        public decimal? CurrentQualityQty { get; set; }

        /// <summary>
        /// 不合格数量
        /// </summary>
       
        public decimal UnQualityQty { get; set; }

        /// <summary>
        /// 本次不合格数量
        /// </summary>
        
        public decimal? CurrentUnQualityQty { get; set; }

        /// <summary>
        /// 选中状态
        /// </summary>
        
        public bool OKSelect { get; set; }

        /// <summary>
        /// 检验类型
        /// </summary>
       
        public string QualityType { get; set; }

      
        public int ID { get; set; }

        /// <summary>
        /// 本次过账数量
        /// </summary>
        
        public decimal CurrentPostQty { get; set; }

        
        public string StrROHS { get; set; }

        /// <summary>
        /// 预留行号
        /// </summary>
        
        public string ReserveRowNo { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        
        public string OrderNum { get; set; }
        /// <summary>
        /// 已收货数量
        /// </summary>
       
        public decimal OldReceiveQty { get; set; }

        /// <summary>
        /// 缺陷等级
        /// </summary>
        
        public List<ComboBoxItem> lstCmb { get; set; }

       
        public int RowNumber { get; set; }
 
    }
}
