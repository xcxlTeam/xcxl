using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Stock
{
    public class Stock_Model 
    {
        private int _StockType;

        public int StockType
        {
            get { return _StockType; }
            set { _StockType = value; }
        }
        private string _Barcode;

        public string Barcode
        {
            get { return _Barcode; }
            set { _Barcode = value; }
        }
        private string _SerialNo;

        public string SerialNo
        {
            get { return _SerialNo; }
            set { _SerialNo = value; }
        }
        private string _MaterialNo;

        public string MaterialNo
        {
            get { return _MaterialNo; }
            set { _MaterialNo = value; }
        }
        private string _MaterialDesc;

        public string MaterialDesc
        {
            get { return _MaterialDesc; }
            set { _MaterialDesc = value; }
        }

        private string _MaterialStd;

        public string MaterialStd
        {
            get { return _MaterialStd; }
            set { _MaterialStd = value; }
        }

        private string _WarehouseNo;

        public string WarehouseNo
        {
            get { return _WarehouseNo; }
            set { _WarehouseNo = value; }
        }
        private string _HouseNo;

        public string HouseNo
        {
            get { return _HouseNo; }
            set { _HouseNo = value; }
        }
        private string _AreaNo;

        public string AreaNo
        {
            get { return _AreaNo; }
            set { _AreaNo = value; }
        }
        private double _Qty;

        public double Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        private string _TempMaterialNo;

        public string TempMaterialNo
        {
            get { return _TempMaterialNo; }
            set { _TempMaterialNo = value; }
        }
        private string _TempMaterialDesc;

        public string TempMaterialDesc
        {
            get { return _TempMaterialDesc; }
            set { _TempMaterialDesc = value; }
        }
        private string _PickAreaNo;

        public string PickAreaNo
        {
            get { return _PickAreaNo; }
            set { _PickAreaNo = value; }
        }
        private string _CelAreaNo;

        public string CelAreaNo
        {
            get { return _CelAreaNo; }
            set { _CelAreaNo = value; }
        }
        private string _BatchNo;

        public string BatchNo
        {
            get { return _BatchNo; }
            set { _BatchNo = value; }
        }
        private string _SN;

        public string SN
        {
            get { return _SN; }
            set { _SN = value; }
        }

        private string _Creater;

        public string Creater
        {
            get { return _Creater; }
            set { _Creater = value; }
        }
        private DateTime _CreateTime;

        public DateTime CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public string VoucherNo { get; set; }


        //辅助字段

        public string StrStockType { get; set; }

        public string WarehouseName { get; set; }

        public string HouseName { get; set; }

        public string AreaName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public bool OnlyOwnWarehouse { get; set; }

        #region 用于产线查询
        /// <summary>
        /// 产线
        /// </summary>
        public string ProductLineNo { get; set; }
        /// <summary>
        /// 已保存过账数量
        /// </summary>
        public double ErpQty { get; set; }
        /// <summary>
        /// 已保存未过账数量
        /// </summary>
        public double SaveQty { get; set; }
        /// <summary>
        /// 已组托未保存数量
        /// </summary>
        public double TrayQty { get; set; }
        /// <summary>
        /// 总数量（上述三个数量之和）
        /// </summary>
        public double TotalQty { get; set; } 
        #endregion

        public string cvencode { get; set; }
        public string cvenname { get; set; }
    }

    public class QueryConditions
    {
        public string MaterialNo { get; set; }
        public string MaterialDesc { get; set; }
        public string MaterialStd { get; set; }

        public string ProductLineNo { get; set; }
        public string VoucherNo { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 发票号
        /// </summary>
        public string cSBVCode { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string cCusName { get; set; }
        /// <summary>
        /// 销售订单
        /// </summary>
        public string cSOCode { get; set; }
    }
}
