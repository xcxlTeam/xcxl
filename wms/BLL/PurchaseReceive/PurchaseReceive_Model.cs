using BLL.DeliveryReceive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.PurchaseReceive
{
    public class PurchaseReceive_Model
    {
        public int ID { get; set; }

        public string PONo { get; set; } //PO号

        public string SupCode { get; set; } //供应商代码
        public string SupName { get; set; } //供应商名称

        public string RowNo { get; set; }   //PO行号

        public string MaterialNo { get; set; }  //物料编码

        public string MaterialDesc { get; set; }

        public string Plant { get; set; }//京信工厂

        public string PlantName { get; set; }//工厂名称

        public string Operator { get; set; }//创建人编号

        public DateTime CreateDate { get; set; }//创建时间

        public String Message { get; set; } //失败消息

        public List<Dictionary<string, string>> Items { get; set; }

        public String Row { get; set; } //表长度

        public String Status { get; set; } //状态 S成功 E 失败

        public String Type { get; set; } //S 成功 or E 失败

        public Dghead Dghead { get; set; }
    }
}
