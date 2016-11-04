using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.DeliveryReceive
{
    public class Items
    {
        public string Supplier { get; set; } // 供应商名称+编号
        public string Comba { get; set; } //京信名称
        public string DeliveryNo { get; set; } //送货单号
        public string CreateTime { get; set; } //创建时间
        public string RowNo { get; set; } //PO行号
        public string VoucherNo { get; set; } //PO号
        public string MaterialNo { get; set; } //物料编号
        public string MaterialDesc { get; set; }//物料描述
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
        public string VersionNum { get; set; } //对应版本号

        public string Tele{get;set;} //电话
        public string ObjectId{get;set;} //ObjectId



    }
}
