using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Quality
{
    public class QuanlityExportInfo
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _DeliveryNo;

        public string DeliveryNo
        {
            get { return _DeliveryNo; }
            set { _DeliveryNo = value; }
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
        private string _Plant;

        public string Plant
        {
            get { return _Plant; }
            set { _Plant = value; }
        }
        private string _MaterialDoc;

        public string MaterialDoc
        {
            get { return _MaterialDoc; }
            set { _MaterialDoc = value; }
        }
        private DateTime _CreateDate;

        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        private int _PrintedQty;

        public int PrintedQty
        {
            get { return _PrintedQty; }
            set { _PrintedQty = value; }
        }
        private DateTime? _PrintTime;

        public DateTime? PrintTime
        {
            get { return _PrintTime; }
            set { _PrintTime = value; }
        }
        private string _MoveType;

        public string MoveType
        {
            get { return _MoveType; }
            set { _MoveType = value; }
        }
        private string _VoucherNo;

        public string VoucherNo
        {
            get { return _VoucherNo; }
            set { _VoucherNo = value; }
        }
        private string _RowNo;

        public string RowNo
        {
            get { return _RowNo; }
            set { _RowNo = value; }
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
        private decimal _ReceiveQty;

        public decimal ReceiveQty
        {
            get { return _ReceiveQty; }
            set { _ReceiveQty = value; }
        }
        private string _Unit;

        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        private string _PrdVersion;

        public string PrdVersion
        {
            get { return _PrdVersion; }
            set { _PrdVersion = value; }
        }
        private decimal _QualityQty;

        public decimal QualityQty
        {
            get { return _QualityQty; }
            set { _QualityQty = value; }
        }
        private decimal _UnQualityQty;

        public decimal UnQualityQty
        {
            get { return _UnQualityQty; }
            set { _UnQualityQty = value; }
        }
        private int _QualityType;

        public int QualityType
        {
            get { return _QualityType; }
            set { _QualityType = value; }
        }
        private string _StrQualityType;

        public string StrQualityType
        {
            get { return _StrQualityType; }
            set { _StrQualityType = value; }
        }



        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
