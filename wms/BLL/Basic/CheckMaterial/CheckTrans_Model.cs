using BLL.Basic.Area;
using BLL.Common;
using BLL.DeliveryReceive;
using BLL.PrintBarcode;
using System;
using System.Collections.Generic;

namespace BLL.Check
{
    public class CheckTransHeader
    {
        public CheckTransHeader()
            : base()
        {
            Dghead = new Dghead();

            lstCheckTrans = new List<CheckTransInfo>();
        }

        private string _Operator;

        public string Operator
        {
            get { return _Operator; }
            set { _Operator = value; }
        }
        private List<CheckTransInfo> _lstCheckTrans;

        public List<CheckTransInfo> lstCheckTrans
        {
            get { return _lstCheckTrans; }
            set { _lstCheckTrans = value; }
        }



        /// <summary>
        /// 状态 S成功 E 失败
        /// </summary>
        public String Status { get; set; }
        /// <summary>
        /// S 成功 or E 失败
        /// </summary>
        public String Type { get; set; }
        /// <summary>
        /// 供应商信息
        /// </summary>
        public Dghead Dghead { get; set; }
        /// <summary>
        /// 失败消息
        /// </summary>
        public String Message { get; set; }
    }

    public class CheckTransInfo : BasicInfo
    {

        /// <summary>
        /// 状态 S成功 E 失败
        /// </summary>
        public String Status { get; set; }
        /// <summary>
        /// S 成功 or E 失败
        /// </summary>
        public String Type { get; set; }
        /// <summary>
        /// 供应商信息
        /// </summary>
        public Dghead Dghead { get; set; }
        /// <summary>
        /// 失败消息
        /// </summary>
        public String Message { get; set; }

        private int _CheckID;

        public int CheckID
        {
            get { return _CheckID; }
            set { _CheckID = value; }
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
        private decimal _ScanQty;

        public decimal ScanQty
        {
            get { return _ScanQty; }
            set { _ScanQty = value; }
        }
        private string _Operator;

        public string Operator
        {
            get { return _Operator; }
            set { _Operator = value; }
        }
        private DateTime _OperationTime;

        public DateTime OperationTime
        {
            get { return _OperationTime; }
            set { _OperationTime = value; }
        }



        //辅助字段
        public AreaInfo ScanArea { get; set; }
        public Barcode_Model ScanBarcode { get; set; }

        public string WarehouseName { get; set; }
        public string MaterialStd { get; set; }

        public string HouseName { get; set; }
        public string AreaName { get; set; }

    }
}
