using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.PrintBarcode
{
    public class MaterialInnerLabel
    {
        public BarcodeRule barcoderule;

        private string _labeltype;
        private string _materialno;
        private string _materialdesc;
        private string _supcode;
        private string _supname;
        private string _printdate;
        private string _supbatch;
        private string _pocode;
        private string _barcode;
        private string _invstd;
        /// <summary>
        /// 规格型号
        /// </summary>
        public string INVSTD
        {
            get { return _invstd; }
            set { _invstd = value; }
        }
        /// <summary>
        /// 二维码
        /// </summary>
        public string Barcode
        {
            get { return _barcode; }
            set { _barcode = value; }
        }
        /// <summary>
        /// 采购订单号
        /// </summary>
        public string POCode
        {
            get { return _pocode; }
            set { _pocode = value; }
        }

        /// <summary>
        /// 标签类型分类2位
        /// </summary>
        public string LabelType
        {
            get { return _labeltype; }
            set { _labeltype = value; }
        }
        /// <summary>
        /// 物料编号
        /// </summary>
        public string MATERIALNO
        {
            set { _materialno = value; }
            get { return _materialno; }
        }
        /// <summary>
        /// 物料描述
        /// </summary>
        public string MATERIALDESC
        {
            set { _materialdesc = value; }
            get { return _materialdesc; }
        }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string SUPCODE
        {
            set { _supcode = value; }
            get { return _supcode; }
        }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SUPNAME
        {
            set { _supname = value; }
            get { return _supname; }
        }
        /// <summary>
        /// 标签打印日期6位
        /// </summary>
        public string PrintDate
        {
            get { return _printdate; }
            set { _printdate = value; }
        }
        /// <summary>
        /// 供应商生产批号包装量
        /// </summary>
        public string SupBatch
        {
            get { return _supbatch; }
            set { _supbatch = value; }
        }
        public MaterialInnerLabel()
        {
            //标签类型分类2位@物料编码？位@供应商编码？位@标签打印日期6位@供应商生产批号包装量
            barcoderule = new BarcodeRule();
            barcoderule.Fields = new List<string>();
            barcoderule.Fields.Add("LabelType");
            barcoderule.Fields.Add("MATERIALNO");
            barcoderule.Fields.Add("SUPCODE");
            barcoderule.Fields.Add("PrintDate");
            barcoderule.Fields.Add("SupBatch");
        }

    }
}
