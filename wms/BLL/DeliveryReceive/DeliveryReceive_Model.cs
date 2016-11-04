using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.MaterialDocument;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace BLL.DeliveryReceive
{
    [Serializable]
    public class DeliveryReceive_Model
    {
      
        public int ID { get; set; }

        
        public string DeliveryNo { get; set; } //送货单号

        
        public string SupName { get; set; } //供应商名称

        
        public string SupCode { get; set; } //供应商代码

       
        public string Plant { get; set; }//京信工厂

        
        public string PlantName { get; set; }//工厂名称

       
        public string Operator { get; set; }//创建人编号

        
        public DateTime CreateDate { get; set; }//创建时间

       
        public List<DeliveryReceiveDetail_Model> lstDeliveryDetail { get; set; }

        
        public MaterialDoc_Model materialDocModel { get; set; }

        [XmlIgnoreAttribute]
        public string Message { get; set; } //失败消息

        [XmlIgnoreAttribute]
        public List<Dictionary<string, string>> Items { get; set; }

        [XmlIgnoreAttribute]
        public string Row { get; set; } //表长度

        [XmlIgnoreAttribute]
        public string Status { get; set; } //状态 S成功 E 失败

        [XmlIgnoreAttribute]
        public string Type { get; set; } //S 成功 or E 失败

        [XmlIgnoreAttribute]
        public Dghead Dghead { get; set; }

        /// <summary>
        /// 单据类型
        /// </summary>
        
        public int VoucherType { get; set; }

        /// <summary>
        /// 是否质检
        /// </summary>
        
        public int IsQuality { get; set; }

        /// <summary>
        /// 是否收货过账
        /// </summary>
        
        public int IsReceivePost { get; set; }

        /// <summary>
        /// 是否上架后过账
        /// </summary>
        
        public int IsShelvePost { get; set; }
        /// <summary>
        /// 任务号
        /// </summary>
        
        public string TaskNo { get; set; }

       
        public string VoucherNo { get; set; }
        
        public string MaterialDoc { get; set; }
        
        public DateTime? StartTime { get; set; }
        
        public DateTime? EndTime { get; set; }
        
        public DateTime? DocDate { get; set; }
        
        public DateTime? PostDate { get; set; }

        
        public string MoveType { get; set; }
        
        public string Titel { get; set; }
       
        public string OutSideSupCode { get; set; }
        
        public string OutSideSupName { get; set; }
        
        public string Barcode { get; set; }
        
        public string MaterialNo { get; set; }
       
        public int PrintedQty { get; set; }   //打印数量
       
        public List<MaterialDoc_Model> lstMaterialDoc { get; set; }

        /// <summary>
        /// 外协发料备注
        /// </summary>
        
        public string OsDeliveryRemark { get; set; }

        /// <summary>
        /// 外协PO收货备注
        /// </summary>
       
        public string POReamrk { get; set; }
        /// <summary>
        /// 入库原因
        /// </summary>
        
        public string Reson { get; set; }

     
        public DateTime? PrintTime{get;set;}
    }
}
