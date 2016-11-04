using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.PrintBarcode
{
    public class ProductLabel_Model
    {
        private string _ID;

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public BarcodeRule barcoderule;

        private string _labeltype;
        /// <summary>
        /// 标签类型分类2位
        /// </summary>
        public string labeltype
        {
            get { return _labeltype; }
            set { _labeltype = value; }
        }
        private string _materialno;
        /// <summary>
        /// 物料编号
        /// </summary>
        public string materialno
        {
            get { return _materialno; }
            set { _materialno = value; }
        }
        private string _materialdesc;
        /// <summary>
        /// 物料描述
        /// </summary>
        public string materialdesc
        {
            get { return _materialdesc; }
            set { _materialdesc = value; }
        }
        private string _ordercode;
        /// <summary>
        /// 生产/销售订单
        /// </summary>
        public string ordercode
        {
            get { return _ordercode; }
            set { _ordercode = value; }
        }
        private string _outpackqty;
        /// <summary>
        /// 包装量
        /// </summary>
        public string outpackqty
        {
            get { return _outpackqty; }
            set { _outpackqty = value; }
        }
        private string _printdate;
        /// <summary>
        /// 标签打印日期6位
        /// </summary>
        public string printdate
        {
            get { return _printdate; }
            set { _printdate = value; }
        }
        private string _barcode;
        /// <summary>
        /// 二维码
        /// </summary>
        public string barcode
        {
            get { return _barcode; }
            set { _barcode = value; }
        }
        private string _invstd;
        /// <summary>
        /// 规格型号
        /// </summary>
        public string invstd
        {
            get { return _invstd; }
            set { _invstd = value; }
        }
        private string _CUName;
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CUName
        {
            get { return _CUName; }
            set { _CUName = value; }
        }
        private string _Remark;
        /// <summary>
        /// 内部使用
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        private string _packno;
        /// <summary>
        /// 箱号
        /// </summary>
        public string packno
        {
            get { return _packno; }
            set { _packno = value; }
        }
        private string _plantno;
        /// <summary>
        /// 车间/产线名称
        /// </summary>
        public string plantno
        {
            get { return _plantno; }
            set { _plantno = value; }
        }
        private string _POCode;
        /// <summary>
        /// 生产订单
        /// </summary>
        public string POCode
        {
            get { return _POCode; }
            set { _POCode = value; }
        }
        private string _SOCode;
        /// <summary>
        /// 销售订单
        /// </summary>
        public string SOCode
        {
            get { return _SOCode; }
            set { _SOCode = value; }
        }
        private string _contractNo;
        /// <summary>
        /// 合同号
        /// </summary>
        public string ContractNo
        {
            get { return _contractNo; }
            set { _contractNo = value; }
        }

        private string _barcodeExpress;
        /// <summary>
        /// 条码明文
        /// </summary>
        public string BarcodeExpress
        {
            get { return _barcodeExpress; }
            set { _barcodeExpress = value; }
        }
        private string _barcodeEnd;
        /// <summary>
        /// 标签打印日期6位+生成部门编码1位+箱号(流水号)4位
        /// </summary>
        public string BarcodeEnd
        {
            get { return _barcodeEnd; }
            set { _barcodeEnd = value; }
        }
        private string _locale;
        /// <summary>
        /// 期初库存地点
        /// </summary>
        public string Locale
        {
            get { return _locale; }
            set { _locale = value; }
        }
        private string _qrbarcode;
        //二维码图片
        public string qrbarcode
        {
            get { return _qrbarcode; }
            set { _qrbarcode = value; }
        }
        private string _isOuter;
        //是否是外箱
        public string IsOuter
        {
            get { return _isOuter; }
            set { _isOuter = value; }
        }

        private int _iMoSeq;
        /// <summary>
        /// 订单行号
        /// </summary>
        public int iMoSeq
        {
            get { return _iMoSeq; }
            set { _iMoSeq = value; }
        }

        private string _smallQR;

        public string smallQR
        {
            get { return _smallQR; }
            set { _smallQR = value; }
        }

        private string _prdversion;
        /// <summary>
        /// 标签模板:默认不填为标准2*7；1为2.5*2.5的二维码是序列号；2为2.5*2.5的二维码是网址
        /// </summary>
        public string prdversion
        {
            get { return _prdversion; }
            set { _prdversion = value; }
        }

        private string _status;
        /// <summary>
        /// 自动线打印状态：默认不填为未打印；1为已打印；2为已贴标；3为已组托
        /// </summary>
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
        public ProductLabel_Model()
        {
            //标签类型分类2位@物料编码?位@ 销售订单号(生产订单)12位@包装量4位@标签打印日期6位+生成部门编码1位+箱号(流水号)4位
            barcoderule = new BarcodeRule();
            barcoderule.Fields = new List<string>();
            barcoderule.Fields.Add("labeltype");
            barcoderule.Fields.Add("materialno");
            barcoderule.Fields.Add("ordercode");
            barcoderule.Fields.Add("POCode");
            barcoderule.Fields.Add("outpackqty");
            barcoderule.Fields.Add("BarcodeEnd");
        }
    }
}
