using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Basic.Task
{
    public class TaskTransInfo : Common.BasicInfo
    {
        private int _TaskType;

        public int TaskType
        {
            get { return _TaskType; }
            set { _TaskType = value; }
        }
        private string _FromWarehouseNo;

        public string FromWarehouseNo
        {
            get { return _FromWarehouseNo; }
            set { _FromWarehouseNo = value; }
        }
        private string _ToWarehouseNo;

        public string ToWarehouseNo
        {
            get { return _ToWarehouseNo; }
            set { _ToWarehouseNo = value; }
        }
        private string _FromHouseNo;

        public string FromHouseNo
        {
            get { return _FromHouseNo; }
            set { _FromHouseNo = value; }
        }
        private string _ToHouseNo;

        public string ToHouseNo
        {
            get { return _ToHouseNo; }
            set { _ToHouseNo = value; }
        }
        private string _FromAreaNo;

        public string FromAreaNo
        {
            get { return _FromAreaNo; }
            set { _FromAreaNo = value; }
        }
        private string _ToAreaNo;

        public string ToAreaNo
        {
            get { return _ToAreaNo; }
            set { _ToAreaNo = value; }
        }
        private string _TaskNo;

        public string TaskNo
        {
            get { return _TaskNo; }
            set { _TaskNo = value; }
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
        private int _VoucherType;

        public int VoucherType
        {
            get { return _VoucherType; }
            set { _VoucherType = value; }
        }
        private string _SupCusCode;

        public string SupCusCode
        {
            get { return _SupCusCode; }
            set { _SupCusCode = value; }
        }
        private string _SupCusName;

        public string SupCusName
        {
            get { return _SupCusName; }
            set { _SupCusName = value; }
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
        private decimal _Qty;

        public decimal Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        private int _TaskDetail_ID;

        public int TaskDetail_ID
        {
            get { return _TaskDetail_ID; }
            set { _TaskDetail_ID = value; }
        }
        private string _SN;

        public string SN
        {
            get { return _SN; }
            set { _SN = value; }
        }
        private string _DeliveryNo;

        public string DeliveryNo
        {
            get { return _DeliveryNo; }
            set { _DeliveryNo = value; }
        }
        private string _AndalaNo;

        public string AndalaNo
        {
            get { return _AndalaNo; }
            set { _AndalaNo = value; }
        }


        //辅助字段

        public string FromWarehouseName { get; set; }

        public string ToWarehouseName { get; set; }

        public string FromHouseName { get; set; }

        public string ToHouseName { get; set; }

        public string FromAreaName { get; set; }

        public string ToAreaName { get; set; }

        public string StrTaskType { get; set; }

        public string StrVoucherType { get; set; }

        public bool OnlyOwnWarehouse { get; set; }

    }
}
