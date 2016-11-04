using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Basic.Task
{
    public class OverViewInfo : Common.BasicInfo
    {
        private string _TaskNo;

        public string TaskNo
        {
            get { return _TaskNo; }
            set { _TaskNo = value; }
        }
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
        private string _SupcusNo;

        public string SupcusNo
        {
            get { return _SupcusNo; }
            set { _SupcusNo = value; }
        }
        private string _SupcusName;

        public string SupcusName
        {
            get { return _SupcusName; }
            set { _SupcusName = value; }
        }
        private int _TaskStatus;

        public int TaskStatus
        {
            get { return _TaskStatus; }
            set { _TaskStatus = value; }
        }
        private string _AuditUserNo;

        public string AuditUserNo
        {
            get { return _AuditUserNo; }
            set { _AuditUserNo = value; }
        }
        private DateTime? _AuditDateTime;

        public DateTime? AuditDateTime
        {
            get { return _AuditDateTime; }
            set { _AuditDateTime = value; }
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
        private DateTime? _CreateDateTime;

        public DateTime? CreateDateTime
        {
            get { return _CreateDateTime; }
            set { _CreateDateTime = value; }
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
        private string _CreateUserNo;

        public string CreateUserNo
        {
            get { return _CreateUserNo; }
            set { _CreateUserNo = value; }
        }
        private int _IsShelvePost;

        public int IsShelvePost
        {
            get { return _IsShelvePost; }
            set { _IsShelvePost = value; }
        }
        private string _DeliveryNo;

        public string DeliveryNo
        {
            get { return _DeliveryNo; }
            set { _DeliveryNo = value; }
        }
        private int _IsQuality;

        public int IsQuality
        {
            get { return _IsQuality; }
            set { _IsQuality = value; }
        }
        private int _IsreceivePost;

        public int IsReceivePost
        {
            get { return _IsreceivePost; }
            set { _IsreceivePost = value; }
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
        private int _Receive_Id;

        public int Receive_Id
        {
            get { return _Receive_Id; }
            set { _Receive_Id = value; }
        }
        private int _PostStatus;

        public int PostStatus
        {
            get { return _PostStatus; }
            set { _PostStatus = value; }
        }
        private string _MaterialDoc;

        public string MaterialDoc
        {
            get { return _MaterialDoc; }
            set { _MaterialDoc = value; }
        }


        //辅助字段
        public string StrVoucherType { get; set; }
        public string StrTaskType { get; set; }
        public string StrIsQuality { get; set; }
        public string StrIsShelvePost { get; set; }
        public string StrIsReceivePost { get; set; }
        public string StrTaskStatus { get; set; }
        public int WarehouseID { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseName { get; set; }
        public string AuditUserName { get; set; }
        public string ReceiveUserName { get; set; }
        public string CreateUserName { get; set; }
        public string StrPostStatus { get; set; }
        public string MaterialNo { get; set; }

        public bool OnlyOwnWarehouse { get; set; }

    }
}
