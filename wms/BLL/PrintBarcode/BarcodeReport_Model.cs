using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BLL.PrintBarcode
{
    public class BarcodeReport_RowDetail
    {
        private string _innerouter;
        /// <summary>
        /// 外箱还是内盒
        /// </summary>
        public string innerouter
        {
            get { return _innerouter; }
            set { _innerouter = value; }
        }
        private string _id;
        /// <summary>
        /// 保存外箱条码表ID
        /// </summary>
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        private bool _isInner;
        /// <summary>
        /// 是否为内盒
        /// </summary>
        public bool isInner
        {
            get { return _isInner; }
            set { _isInner = value; }
        }
        private string _serialno;
        /// <summary>
        /// 条码短码
        /// </summary>
        public string serialno
        {
            get { return _serialno; }
            set { _serialno = value; }
        }
        private string _iFlag;
        /// <summary>
        /// 状态
        /// </summary>
        public string iFlag
        {
            get { return _iFlag; }
            set { _iFlag = value; }
        }
        private string _areano;
        /// <summary>
        /// 货位
        /// </summary>
        public string areano
        {
            get { return _areano; }
            set { _areano = value; }
        }
    }
    public class BarcodeReport_Model
    {
        private string _voucherno;
        private string _rowno;
        private string _SoCode;
        private string _ordercode;
        private string _plantno;
        private string _materialno;
        private string _materialdesc;
        private string _materialstd;
        private string _batchno;
        private decimal _outpackqty;
        private decimal _voucherQty;
        private decimal _QualifiedInQty;
        private decimal _printQty;
        private decimal _barcodeQty;
        /// <summary>
        /// 生产订单号
        /// </summary>
        public string voucherno
        {
            get { return _voucherno; }
            set { _voucherno = value; }
        }
        /// <summary>
        /// 生产订单行号
        /// </summary>
        public string rowno
        {
            get { return _rowno; }
            set { _rowno = value; }
        }
        /// <summary>
        /// 销售订单号
        /// </summary>
        public string SoCode
        {
            get { return _SoCode; }
            set { _SoCode = value; }
        }
        /// <summary>
        /// 合同号
        /// </summary>
        public string ordercode
        {
            get { return _ordercode; }
            set { _ordercode = value; }
        }
        /// <summary>
        /// 生产线
        /// </summary>
        public string plantno
        {
            get { return _plantno; }
            set { _plantno = value; }
        }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string materialno
        {
            get { return _materialno; }
            set { _materialno = value; }
        }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string materialdesc
        {
            get { return _materialdesc; }
            set { _materialdesc = value; }
        }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string materialstd
        {
            get { return _materialstd; }
            set { _materialstd = value; }
        }
        /// <summary>
        /// 订单数量
        /// </summary>
        public decimal voucherQty
        {
            get { return _voucherQty; }
            set { _voucherQty = value; }
        }
        /// <summary>
        /// 外箱包装量
        /// </summary>
        public decimal outpackqty
        {
            get { return _outpackqty; }
            set { _outpackqty = value; }
        }
        /// <summary>
        /// 序列号
        /// </summary>
        public string batchno
        {
            get { return _batchno; }
            set { _batchno = value; }
        }
        /// <summary>
        /// 已打印数量
        /// </summary>
        public decimal printQty
        {
            get { return _printQty; }
            set { _printQty = value; }
        }
        /// <summary>
        /// 已打印条码个数
        /// </summary>
        public decimal barcodeQty
        {
            get { return _barcodeQty; }
            set { _barcodeQty = value; }
        }
        /// <summary>
        /// 累计入库数量
        /// </summary>
        public decimal QualifiedInQty
        {
            get { return _QualifiedInQty; }
            set { _QualifiedInQty = value; }
        }
    }

    public class BarcodeReportDetail_Model
    {
        string _outbarcode;
        /// <summary>
        /// 外箱条码
        /// </summary>
        public string outbarcode
        {
            get { return _outbarcode; }
            set { _outbarcode = value; }
        }
        string _innerbarcode;
        /// <summary>
        /// 内盒条码
        /// </summary>
        public string innerbarcode
        {
            get { return _innerbarcode; }
            set { _innerbarcode = value; }
        }
        string _qty;
        /// <summary>
        /// 数量
        /// </summary>
        public string qty
        {
            get { return _qty; }
            set { _qty = value; }
        }
        string _areano;
        /// <summary>
        /// 货位
        /// </summary>
        public string areano
        {
            get { return _areano; }
            set { _areano = value; }
        }
        string _iFlag;
        /// <summary>
        /// 条码状态 null而且TRAYID也是null则是未组托,如果TRAYID不为null则是已组托未入库,1是保存未过账,2是入库(取临时货位),3是上架（取正式货位）,4是出库,5是调拨
        /// </summary>
        public string iFlag
        {
            get { return _iFlag; }
            set { _iFlag = value; }
        }
    }

    public class BarcodeTrace_Model
    {
        private string _voucherno;
        private string _rowno;
        private string _SoCode;
        private string _ordercode;
        private string _plantno;
        private string _materialno;
        private string _materialdesc;
        private string _materialstd;
        private string _batchno;
        private decimal _outpackqty;
        private decimal _voucherQty;
        private decimal _QualifiedInQty;
        private decimal _printQty;
        private decimal _barcodeQty;
        private string _TransMoveCode;
        private string _TransMoverowno;
        private string _TransMovecwhName;
        private string _StockOutCode;
        private string _StockOutrowno;
        private string _CusName;
        private string _StockOutdate;
        private string _POdate;
        private decimal _transmoveQty;
        private decimal _stockoutQty;
        /// <summary>
        /// 发货数量
        /// </summary>
        public decimal stockoutQty
        {
            get { return _stockoutQty; }
            set { _stockoutQty = value; }
        }
        /// <summary>
        /// 调拨数量
        /// </summary>
        public decimal transmoveQty
        {
            get { return _transmoveQty; }
            set { _transmoveQty = value; }
        }
        /// <summary>
        /// 生产日期
        /// </summary>
        public string POdate
        {
            get { return _POdate; }
            set { _POdate = value; }
        }
        /// <summary>
        /// 发货日期
        /// </summary>
        public string StockOutdate
        {
            get { return _StockOutdate; }
            set { _StockOutdate = value; }
        }
        /// <summary>
        /// 发货客户名称
        /// </summary>
        public string CusName
        {
            get { return _CusName; }
            set { _CusName = value; }
        }
        /// <summary>
        /// 销售发票行号
        /// </summary>
        public string StockOutrowno
        {
            get { return _StockOutrowno; }
            set { _StockOutrowno = value; }
        }
        /// <summary>
        /// 销售发票单据号
        /// </summary>
        public string StockOutCode
        {
            get { return _StockOutCode; }
            set { _StockOutCode = value; }
        }
        /// <summary>
        /// 调拨仓库
        /// </summary>
        public string TransMovecwhName
        {
            get { return _TransMovecwhName; }
            set { _TransMovecwhName = value; }
        }
        /// <summary>
        /// 调拨单行号
        /// </summary>
        public string TransMoverowno
        {
            get { return _TransMoverowno; }
            set { _TransMoverowno = value; }
        }

        /// <summary>
        /// 调拨单号
        /// </summary>
        public string TransMoveCode
        {
            get { return _TransMoveCode; }
            set { _TransMoveCode = value; }
        }
        /// <summary>
        /// 生产订单号
        /// </summary>
        public string voucherno
        {
            get { return _voucherno; }
            set { _voucherno = value; }
        }
        /// <summary>
        /// 生产订单行号
        /// </summary>
        public string rowno
        {
            get { return _rowno; }
            set { _rowno = value; }
        }
        /// <summary>
        /// 销售订单号
        /// </summary>
        public string SoCode
        {
            get { return _SoCode; }
            set { _SoCode = value; }
        }
        /// <summary>
        /// 合同号
        /// </summary>
        public string ordercode
        {
            get { return _ordercode; }
            set { _ordercode = value; }
        }
        /// <summary>
        /// 生产线
        /// </summary>
        public string plantno
        {
            get { return _plantno; }
            set { _plantno = value; }
        }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string materialno
        {
            get { return _materialno; }
            set { _materialno = value; }
        }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string materialdesc
        {
            get { return _materialdesc; }
            set { _materialdesc = value; }
        }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string materialstd
        {
            get { return _materialstd; }
            set { _materialstd = value; }
        }
        /// <summary>
        /// 订单数量
        /// </summary>
        public decimal voucherQty
        {
            get { return _voucherQty; }
            set { _voucherQty = value; }
        }
        /// <summary>
        /// 外箱包装量
        /// </summary>
        public decimal outpackqty
        {
            get { return _outpackqty; }
            set { _outpackqty = value; }
        }
        /// <summary>
        /// 序列号
        /// </summary>
        public string batchno
        {
            get { return _batchno; }
            set { _batchno = value; }
        }
        /// <summary>
        /// 已打印数量
        /// </summary>
        public decimal printQty
        {
            get { return _printQty; }
            set { _printQty = value; }
        }
        /// <summary>
        /// 已打印条码个数
        /// </summary>
        public decimal barcodeQty
        {
            get { return _barcodeQty; }
            set { _barcodeQty = value; }
        }
        /// <summary>
        /// 累计入库数量
        /// </summary>
        public decimal QualifiedInQty
        {
            get { return _QualifiedInQty; }
            set { _QualifiedInQty = value; }
        }
    }
}
