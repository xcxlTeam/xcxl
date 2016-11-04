using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.PrintBarcode
{
    public class Vendor
    {
        private string _cVenCode;
        /// <summary>
        /// 供应商编码 
        /// </summary>
        public string cVenCode
        {
            get { return _cVenCode; }
            set { _cVenCode = value; }
        }

        private string _cVenAbbName;
        /// <summary>
        /// 供应商简称
        /// </summary>
        public string cVenAbbName
        {
            get { return _cVenAbbName; }
            set { _cVenAbbName = value; }
        }

        private string _password;

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
    public class MaterialLabel_Model
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
        private string _outpackqty;
        /// <summary>
        /// 包装量
        /// </summary>
        public string outpackqty
        {
            get { return _outpackqty; }
            set { _outpackqty = value; }
        }
        private string _batchno;
        /// <summary>
        /// 供应商批号(6位日期)
        /// </summary>
        public string batchno
        {
            get { return _batchno; }
            set { _batchno = value; }
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
        /// 标签打印日期6位+箱号(流水号)5位
        /// </summary>
        public string BarcodeEnd
        {
            get { return _barcodeEnd; }
            set { _barcodeEnd = value; }
        }
        private string _prdversion;
        /// <summary>
        /// 标签模板:3为7*7原料标签；4为7*7半成品标签；5为成品的2*7标准标签；6为成品的2*7双条码标签；7为2.5*2.5的二维码是序列号；8为2.5*2.5的二维码是网址
        /// </summary>
        public string prdversion
        {
            get { return _prdversion; }
            set { _prdversion = value; }
        }

        private string _status;
        /// <summary>
        /// 自动线打印状态：默认不填为未打印；1为已打印；2为已贴标；
        /// </summary>
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _cvencode;
        /// <summary>
        /// 供应商编码
        /// </summary>
        public string cvencode
        {
            get { return _cvencode; }
            set { _cvencode = value; }
        }

        private string _cvenabbname;
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string cvenabbname
        {
            get { return _cvenabbname; }
            set { _cvenabbname = value; }
        }

        private string _cpoid;
        /// <summary>
        /// 采购订单号
        /// </summary>
        public string cpoid
        {
            get { return _cpoid; }
            set { _cpoid = value; }
        }

        private string _ivouchrowno;
        /// <summary>
        /// 采购订单行号
        /// </summary>
        public string ivouchrowno
        {
            get { return _ivouchrowno; }
            set { _ivouchrowno = value; }
        }

        private double _iquantity;
        /// <summary>
        /// 单据数量
        /// </summary>
        public double iquantity
        {
            get { return _iquantity; }
            set { _iquantity = value; }
        }

        private double _printedQTY;
        /// <summary>
        /// 已打印数量
        /// </summary>
        public double PrintedQTY
        {
            get { return _printedQTY; }
            set { _printedQTY = value; }
        }
        private double _imprintedQTY;
        /// <summary>
        /// 未打印数量
        /// </summary>
        public double ImprintedQTY
        {
            get { return _imprintedQTY; }
            set { _imprintedQTY = value; }
        }
        private string _Remark;
        /// <summary>
        /// 备注(本次打印数量/打印序号)
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        public MaterialLabel_Model()
        {
            //标签类型分类2位@物料编码?位@ 供应商编码@包装量4位@标签打印日期6位@箱号(流水号)4位
            barcoderule = new BarcodeRule();
            barcoderule.Fields = new List<string>();
            barcoderule.Fields.Add("labeltype");
            barcoderule.Fields.Add("materialno");
            barcoderule.Fields.Add("cvencode");
            barcoderule.Fields.Add("outpackqty");
            barcoderule.Fields.Add("BarcodeEnd");
        }

        public string Locale { get; set; }
    }
}
