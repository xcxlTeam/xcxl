using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.DeliveryReceive
{
    /// <summary>
    /// 内箱标签字段数据
    /// </summary>
    public class InnerBarcode_Model
    {
  
        public int Id{get;set;}  //Id 
        public int OutBox_Id { get; set; } //外箱表ID
        public string InnerBarcode{get;set;} //内盒条码
        public int SerialNo {get;set;} //条码流水号
        public int InnerQty{get;set;} //包装数量
        public int PrintQty{get;set;} //打印份数
        public string Operator {get;set;} //操作人
        public DateTime OperationDate{get;set;} //操作时间
    }
}
