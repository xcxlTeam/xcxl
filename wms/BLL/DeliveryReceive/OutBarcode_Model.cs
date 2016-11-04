using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.DeliveryReceive
{
    /// <summary>
    /// 外箱标签模版字段数据
    /// </summary>
    public class OutBarcode_Model
    {
        public int Id { get; set; } //外箱标表D
        public int InnerBox_Id { get; set; } //内盒表ID
        public string VoucherNo { get; set; } //订单号
        public string RowNo { get; set; } //行号
        public string DeliveryNo { get; set; } //送货单号
        public int VoucherType { get; set; } //单据类型
        public string MaterialNo { get; set; } //物料编号
        public string MaterialDESC { get; set; } //物料描述
        public string SupplierNo { get; set; } //供应商编号
        public string SupplierName { get; set; } //供应商名称
        public int Qty { get; set; } //订单数量(送货单数量)
        public string BatchNo { get; set; } //生产批号
        public int OutPackQty { get; set; } //外箱包装数量
        public int NoPack { get; set; } //有无包装1-有包装 2-无包装
        public int PrintQty { get; set; } //外箱打印份数
        public string OutBarCode { get; set; } //外箱条码
        public string SerialNo { get; set; } //条码流水号
        public string Prdversion { get; set; } //产品版本
        public int PlatedSilver { get; set; } //是否镀银 1-是2-否
        public int PlatedGold { get; set; } //是否镀金 1-是2-否
        public int Others { get; set; } //是否其他选项 1-是 2-否
        public string Operator { get; set; } //操作人名称
        public DateTime OperationDate { get; set; } //操作时间

    }
}
