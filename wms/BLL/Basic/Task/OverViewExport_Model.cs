using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Basic.Task
{
    public class OverViewExportInfo
    {
        private int _VoucherType;

        public int VoucherType
        {
            get { return _VoucherType; }
            set { _VoucherType = value; }
        }
        private int _TaskType;

        public int TaskType
        {
            get { return _TaskType; }
            set { _TaskType = value; }
        }
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
        private string _SupCusNo;

        public string SupCusNo
        {
            get { return _SupCusNo; }
            set { _SupCusNo = value; }
        }
        private string _SupCusName;

        public string SupCusName
        {
            get { return _SupCusName; }
            set { _SupCusName = value; }
        }
        private int _TaskStatus;

        public int TaskStatus
        {
            get { return _TaskStatus; }
            set { _TaskStatus = value; }
        }
        private DateTime? _TaskIssued;

        public DateTime? TaskIssued
        {
            get { return _TaskIssued; }
            set { _TaskIssued = value; }
        }
        private string _ReceiveUserNo;

        public string ReceiveUserNo
        {
            get { return _ReceiveUserNo; }
            set { _ReceiveUserNo = value; }
        }
        private string _ReceiveUserName;

        public string ReceiveUserName
        {
            get { return _ReceiveUserName; }
            set { _ReceiveUserName = value; }
        }
        private string _Plant;

        public string Plant
        {
            get { return _Plant; }
            set { _Plant = value; }
        }
        private string _PlantName;

        public string PlantName
        {
            get { return _PlantName; }
            set { _PlantName = value; }
        }
        private string _Remark;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        private string _Reason;

        public string Reason
        {
            get { return _Reason; }
            set { _Reason = value; }
        }
        private int _IsShelvePost;

        public int IsShelvePost
        {
            get { return _IsShelvePost; }
            set { _IsShelvePost = value; }
        }
        private int _IsQuality;

        public int IsQuality
        {
            get { return _IsQuality; }
            set { _IsQuality = value; }
        }
        private int _IsReceivePost;

        public int IsReceivePost
        {
            get { return _IsReceivePost; }
            set { _IsReceivePost = value; }
        }
        private int _PostStatus;

        public int PostStatus
        {
            get { return _PostStatus; }
            set { _PostStatus = value; }
        }
        private string _StrVoucherType;

        public string StrVoucherType
        {
            get { return _StrVoucherType; }
            set { _StrVoucherType = value; }
        }
        private string _StrTaskType;

        public string StrTaskType
        {
            get { return _StrTaskType; }
            set { _StrTaskType = value; }
        }
        private string _StrIsQuality;

        public string StrIsQuality
        {
            get { return _StrIsQuality; }
            set { _StrIsQuality = value; }
        }
        private string _StrIsShelvePost;

        public string StrIsShelvePost
        {
            get { return _StrIsShelvePost; }
            set { _StrIsShelvePost = value; }
        }
        private string _StrIsReceivePost;

        public string StrIsReceivePost
        {
            get { return _StrIsReceivePost; }
            set { _StrIsReceivePost = value; }
        }
        private string _StrTaskStatus;

        public string StrTaskStatus
        {
            get { return _StrTaskStatus; }
            set { _StrTaskStatus = value; }
        }
        private string _StrPostStatus;

        public string StrPostStatus
        {
            get { return _StrPostStatus; }
            set { _StrPostStatus = value; }
        }
        private string _MaterialDoc;

        public string MaterialDoc
        {
            get { return _MaterialDoc; }
            set { _MaterialDoc = value; }
        }
        private string _WarehouseCode;

        public string WarehouseCode
        {
            get { return _WarehouseCode; }
            set { _WarehouseCode = value; }
        }
        private string _WarehouseName;

        public string WarehouseName
        {
            get { return _WarehouseName; }
            set { _WarehouseName = value; }
        }
        private string _CreateUserNo;

        public string CreateUserNo
        {
            get { return _CreateUserNo; }
            set { _CreateUserNo = value; }
        }
        private string _CreateUserName;

        public string CreateUserName
        {
            get { return _CreateUserName; }
            set { _CreateUserName = value; }
        }
        private DateTime? _CreateDateTime;

        public DateTime? CreateDateTime
        {
            get { return _CreateDateTime; }
            set { _CreateDateTime = value; }
        }
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private int _Task_ID;

        public int Task_ID
        {
            get { return _Task_ID; }
            set { _Task_ID = value; }
        }
        private string _ToAreaNo;

        public string ToAreaNo
        {
            get { return _ToAreaNo; }
            set { _ToAreaNo = value; }
        }

        private string _RowNo;

        public string RowNo
        {
            get { return _RowNo; }
            set { _RowNo = value; }
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
        private decimal _TaskQty;

        public decimal TaskQty
        {
            get { return _TaskQty; }
            set { _TaskQty = value; }
        }
        private decimal _QualityQty;

        public decimal QualityQty
        {
            get { return _QualityQty; }
            set { _QualityQty = value; }
        }
        private decimal _RemainQty;

        public decimal RemainQty
        {
            get { return _RemainQty; }
            set { _RemainQty = value; }
        }
        private decimal _ShelveQty;

        public decimal ShelveQty
        {
            get { return _ShelveQty; }
            set { _ShelveQty = value; }
        }
        private decimal _UnQualityQty;

        public decimal UnQualityQty
        {
            get { return _UnQualityQty; }
            set { _UnQualityQty = value; }
        }
        private decimal _PostQty;

        public decimal PostQty
        {
            get { return _PostQty; }
            set { _PostQty = value; }
        }
        private int _Status;

        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        private int _IsQualityComp;

        public int IsQualityComp
        {
            get { return _IsQualityComp; }
            set { _IsQualityComp = value; }
        }
        private string _OperatorUserNo;

        public string OperatorUserNo
        {
            get { return _OperatorUserNo; }
            set { _OperatorUserNo = value; }
        }
        private string _OperatorUserName;

        public string OperatorUserName
        {
            get { return _OperatorUserName; }
            set { _OperatorUserName = value; }
        }
        private DateTime? _OperatorDateTime;

        public DateTime? OperatorDateTime
        {
            get { return _OperatorDateTime; }
            set { _OperatorDateTime = value; }
        }
        private string _Unit;

        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        private string _StrStatus;

        public string StrStatus
        {
            get { return _StrStatus; }
            set { _StrStatus = value; }
        }
        private string _StrIsQualityComp;

        public string StrIsQualityComp
        {
            get { return _StrIsQualityComp; }
            set { _StrIsQualityComp = value; }
        }
        private DateTime? _CompleteDateTime;

        public DateTime? CompleteDateTime
        {
            get { return _CompleteDateTime; }
            set { _CompleteDateTime = value; }
        }


        public int WarehouseID { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
