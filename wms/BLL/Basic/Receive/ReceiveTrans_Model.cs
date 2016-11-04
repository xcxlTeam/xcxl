using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Basic.Receive
{
    public class ReceiveTransInfo : Common.BasicInfo
    {
        private string _TaskNo;

        public string TaskNo
        {
            get { return _TaskNo; }
            set { _TaskNo = value; }
        }
        private string _DeliveryNo;

        public string DeliveryNo
        {
            get { return _DeliveryNo; }
            set { _DeliveryNo = value; }
        }
        private string _VoucherNo;

        public string VoucherNo
        {
            get { return _VoucherNo; }
            set { _VoucherNo = value; }
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
        private int _ReceiveType;

        public int ReceiveType
        {
            get { return _ReceiveType; }
            set { _ReceiveType = value; }
        }
        private string _SupplierNo;

        public string SupplierNo
        {
            get { return _SupplierNo; }
            set { _SupplierNo = value; }
        }
        private string _SupplierName;

        public string SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
        }
        private string _MaterialDoc;

        public string MaterialDoc
        {
            get { return _MaterialDoc; }
            set { _MaterialDoc = value; }
        }
        private string _MaterialDocDate;

        public string MaterialDocDate
        {
            get { return _MaterialDocDate; }
            set { _MaterialDocDate = value; }
        }
        private decimal _ReceiveQty;

        public decimal ReceiveQty
        {
            get { return _ReceiveQty; }
            set { _ReceiveQty = value; }
        }
        private decimal _PackCount;

        public decimal PackCount
        {
            get { return _PackCount; }
            set { _PackCount = value; }
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
        private DateTime _CreateDate;

        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        private decimal _DeliveryQty;

        public decimal DeliveryQty
        {
            get { return _DeliveryQty; }
            set { _DeliveryQty = value; }
        }
        private string _RowNo;

        public string RowNo
        {
            get { return _RowNo; }
            set { _RowNo = value; }
        }
        private string _SN;

        public string SN
        {
            get { return _SN; }
            set { _SN = value; }
        }

    }
}
