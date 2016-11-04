using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using BLL.DeliveryReceive;
using System.Xml.Serialization;

namespace BLL.PrintBarcode
{
    public class Barcode_Model
    {
        #region Model
        private decimal _id;
        private string _voucherno;
        private string _rowno;
        private string _deliveryno;
        private string _vouchertype;
        private string _materialno;
        private string _materialdesc;
        private string _cuscode;
        private string _cusname;
        private string _supcode;
        private string _supname;
        private string _batchno;
        private decimal _outpackqty;
        private decimal _innerpackqty;
        private decimal _voucherqty;
        private decimal _batchqty;
        private decimal _qty;
        private decimal _nopack;
        private decimal _printqty;
        private string _barcode;
        private decimal _barcodetype;
        private string _serialno;
        private decimal _barcodeno;
        private string _prdversion;
        private decimal _platedgold;
        private decimal _platedsilver;
        private decimal _platedtin;
        private decimal _others;
        private string _operator;
        private DateTime _operationdate;
        private string _barcodeimg;
        private decimal _outcount;
        private decimal _innercount;
        private decimal _mantissaqty;
        private decimal _isrohs;
        private decimal _outbox_id;
        private decimal _inner_id;
        private string _sn;
        /// <summary>
        /// 外箱标表D
        /// </summary>
        public decimal ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public string VOUCHERNO
        {
            set { _voucherno = value; }
            get { return _voucherno; }
        }
        /// <summary>
        /// 行号
        /// </summary>
        public string ROWNO
        {
            set { _rowno = value; }
            get { return _rowno; }
        }
        /// <summary>
        /// 送货单号
        /// </summary>
        public string DELIVERYNO
        {
            set { _deliveryno = value; }
            get { return _deliveryno; }
        }
        /// <summary>
        /// 单据类型
        /// </summary>
        public string VOUCHERTYPE
        {
            set { _vouchertype = value; }
            get { return _vouchertype; }
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
        /// 客户编号
        /// </summary>
        public string CUSCODE
        {
            set { _cuscode = value; }
            get { return _cuscode; }
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CUSNAME
        {
            set { _cusname = value; }
            get { return _cusname; }
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
        /// 生产批号
        /// </summary>
        public string BATCHNO
        {
            set { _batchno = value; }
            get { return _batchno; }
        }
        /// <summary>
        /// 外箱包装数量
        /// </summary>
        public decimal OUTPACKQTY
        {
            set { _outpackqty = value; }
            get { return _outpackqty; }
        }
        /// <summary>
        /// 内盒包装数量
        /// </summary>
        public decimal INNERPACKQTY
        {
            set { _innerpackqty = value; }
            get { return _innerpackqty; }
        }
        /// <summary>
        /// 订单数量(送货单数量)
        /// </summary>
        public decimal VOUCHERQTY
        {
            set { _voucherqty = value; }
            get { return _voucherqty; }
        }
        /// <summary>
        /// 批次数量
        /// </summary>
        public decimal BATCHQTY
        {
            set { _batchqty = value; }
            get { return _batchqty; }
        }
        /// <summary>
        /// 外箱数量
        /// </summary>
        public decimal QTY
        {
            set { _qty = value; }
            get { return _qty; }
        }
        /// <summary>
        /// 有无包装1-有包装 2-无包装
        /// </summary>
        public decimal NOPACK
        {
            set { _nopack = value; }
            get { return _nopack; }
        }
        /// <summary>
        /// 外箱打印份数
        /// </summary>
        public decimal PRINTQTY
        {
            set { _printqty = value; }
            get { return _printqty; }
        }
        /// <summary>
        /// 外箱条码
        /// </summary>
        public string BARCODE
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 条码类型
        /// </summary>
        public decimal BARCODETYPE
        {
            set { _barcodetype = value; }
            get { return _barcodetype; }
        }
        /// <summary>
        /// 条码流水号
        /// </summary>
        public string SERIALNO
        {
            set { _serialno = value; }
            get { return _serialno; }
        }
        /// <summary>
        /// 本箱序号
        /// </summary>
        public decimal BARCODENO
        {
            set { _barcodeno = value; }
            get { return _barcodeno; }
        }
        /// <summary>
        /// 产品版本
        /// </summary>
        public string PRDVERSION
        {
            set { _prdversion = value; }
            get { return _prdversion; }
        }
        /// <summary>
        /// 是否镀金 1-是2-否
        /// </summary>
        public decimal PLATEDGOLD
        {
            set { _platedgold = value; }
            get { return _platedgold; }
        }
        /// <summary>
        /// 是否镀银 1-是2-否
        /// </summary>
        public decimal PLATEDSILVER
        {
            set { _platedsilver = value; }
            get { return _platedsilver; }
        }
        /// <summary>
        /// 是否镀锡 1-是2-否
        /// </summary>
        public decimal PLATEDTIN
        {
            set { _platedtin = value; }
            get { return _platedtin; }
        }
        /// <summary>
        /// 是否其他选项 1-是 2-否
        /// </summary>
        public decimal OTHERS
        {
            set { _others = value; }
            get { return _others; }
        }
        /// <summary>
        /// 操作人名称
        /// </summary>
        public string OPERATOR
        {
            set { _operator = value; }
            get { return _operator; }
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OPERATIONDATE
        {
            set { _operationdate = value; }
            get { return _operationdate; }
        }
        /// <summary>
        /// 二维码
        /// </summary>
        public string BARCODEIMG
        {
            set { _barcodeimg = value; }
            get { return _barcodeimg; }
        }
        /// <summary>
        /// 外箱个数
        /// </summary>
        public decimal OUTCOUNT
        {
            set { _outcount = value; }
            get { return _outcount; }
        }
        /// <summary>
        /// 内盒个数
        /// </summary>
        public decimal INNERCOUNT
        {
            set { _innercount = value; }
            get { return _innercount; }
        }
        /// <summary>
        /// 尾数
        /// </summary>
        public decimal MANTISSAQTY
        {
            set { _mantissaqty = value; }
            get { return _mantissaqty; }
        }
        /// <summary>
        /// ROHS 2-是1-否
        /// </summary>
        public decimal ISROHS
        {
            set { _isrohs = value; }
            get { return _isrohs; }
        }
        /// <summary>
        /// 外箱ID
        /// </summary>
        public decimal OUTBOX_ID
        {
            set { _outbox_id = value; }
            get { return _outbox_id; }
        }
        /// <summary>
        /// 内盒ID
        /// </summary>
        public decimal INNER_ID
        {
            set { _inner_id = value; }
            get { return _inner_id; }
        }
        /// <summary>
        /// 来料批次
        /// </summary>
        public string SN
        {
            get { return _sn; }
            set { _sn = value; }
        }

        #endregion Model
        public string OUTBARCODENO { get; set; }//对应外箱条码
        public string Supplier { get; set; } // 供应商名称+编号
        public string Comba { get; set; } //京信名称
        public string CreateTime { get; set; } //创建时间
        public string ClaimArriveTime { get; set; }//要求到货时间
        public string Unit { get; set; }//单位
        public decimal CURRENTLYDELIVERYNUM { get; set; }//当前交货数量
        public decimal ClaimDeliveryNum { get; set; }//要求交货数量
        public decimal ReadyDeliveryNum { get; set; }//已交货数量
        public int WaitDeliveryNum { get; set; }//待交货数量
        public decimal InRoadDeliveryNum { get; set; }//在途数量
        public string ReceiveTime { get; set; } //接收时间
        public string DeliveryAddress { get; set; }//交货地址
        public string CorrespondDepartment { get; set; }//对应部门
        public string WorkCode { get; set; }  //作业单号
        public string JingxinName { get; set; } //京信名称
        public string Plant { get; set; }//京信工厂
        public string VERSIONNUM { get; set; } //对应版本号

        public string STORAGELOC { get; set; }//库存地点

        public decimal RECEIVEQTY { get; set; }//实际收货数量

        public bool BIsRoSH { get; set; }//是否显示ROSH图标



        /// <summary>
        /// 镀层物料
        /// </summary>
        public string Plated { get; set; }
        public bool BPlatedGold { get; set; }//是否镀金
        public bool BPlatedSilver { get; set; }//是否镀银
        public bool BPlatedTin { get; set; }//是否镀锡
        public bool BPlatedOther { get; set; }//是否其他

        public string StrBarcodeType { get; set; }
        public string StrVoucherType { get; set; }

        [XmlIgnoreAttribute]
        public List<InnerBarcode_Model> lstInnerBarcode { get; set; }

        public String Message { get; set; } //失败消息

        //[XmlIgnoreAttribute]
        //public List<Dictionary<string, string>> Items { get; set; }

        public String Row { get; set; } //表长度

        public String Status { get; set; } //状态 S成功 E 失败

        public String Type { get; set; } //S 成功 or E 失败

        public Dghead Dghead { get; set; }

        public int PrintedQty { get; set; }

        /// <summary>
        /// 需求跟踪号，生产退料
        /// </summary>
        public string TrackNo { get; set; }

        /// <summary>
        /// 预留项目号，生产退料
        /// </summary>
        public string ReserveNumber { get; set; }

        /// <summary>
        /// 预留行号，生产退料
        /// </summary>
        public string ReserveRowNo { get; set; }

        /// <summary>
        /// 退仓部门，生产退料
        /// </summary>
        public string Department { get; set; }
        public string DepartmentName { get; set; }

        /// <summary>
        /// 退仓原因，生产退料
        /// </summary>
        public string Reason { get; set; }

        public string AndalaNo { get; set; }

        public string ReserveUser { get; set; }

        public decimal SHOWSUP { get; set; }
        public bool BSHOWSUP { get; set; }

        public string MATERIALDESCLINE1 { get; set; }
        public string MATERIALDESCLINE2 { get; set; }

        public string AreaNo { get; set; }

        public string AreaName { get; set; }

        public string HouseNo { get; set; }

        public string HouseName { get; set; }

        public string WarehouseNo { get; set; }

        public string WarehouseName { get; set; }

        public int iBarcodeType { get; set; }
        public int iVoucherType { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string MATERIALSTD { get;  set; }
        public int TrayID { get;  set; }
        public string labeltype { get; set; }
       
        /// <summary>
        /// 条码状态：NULL/0:初始打印状态|1:保存未过账|2:过账未上架|3:过账已上架
        /// </summary>
        public int iFlag { get; set; }

        public Tray_Model tray_Model { get; set; }

        /// <summary>
        /// 产线代码
        /// </summary>
        public string cProductLineCode { get; set; }

        /// <summary>
        /// 销售订单号/合同号
        /// </summary>
        public string SoCode { get; set; }
        /// <summary>
        /// 销售订单行号
        /// </summary>
        public string sorowno { get; set; }
        /// <summary>
        /// 到货单
        /// </summary>
        public string ArrivalCode { get; set; }
        /// <summary>
        /// 到货单行号
        /// </summary>
        public int ArrivalRowNo { get; set; }
    }
}
