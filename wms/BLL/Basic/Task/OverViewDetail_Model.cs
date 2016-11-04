using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Basic.Task
{
    public class OverViewDetailInfo : Common.BasicInfo 
    {
        private string _ToAreaNo;

        public string ToAreaNo
        {
            get { return _ToAreaNo; }
            set { _ToAreaNo = value; }
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
        private string _KeeperUserNo;

        public string KeeperUserNo
        {
            get { return _KeeperUserNo; }
            set { _KeeperUserNo = value; }
        }
        private string _OperatorUserNo;

        public string OperatorUserNo
        {
            get { return _OperatorUserNo; }
            set { _OperatorUserNo = value; }
        }
        private DateTime? _CompleteDateTime;

        public DateTime? CompleteDateTime
        {
            get { return _CompleteDateTime; }
            set { _CompleteDateTime = value; }
        }
        private int _Task_ID;

        public int Task_ID
        {
            get { return _Task_ID; }
            set { _Task_ID = value; }
        }
        private string _TMaterialNo;

        public string TMaterialNo
        {
            get { return _TMaterialNo; }
            set { _TMaterialNo = value; }
        }
        private string _TMaterialDesc;

        public string TMaterialDesc
        {
            get { return _TMaterialDesc; }
            set { _TMaterialDesc = value; }
        }
        private DateTime? _OperatorDateTime;

        public DateTime? OperatorDateTime
        {
            get { return _OperatorDateTime; }
            set { _OperatorDateTime = value; }
        }
        private decimal _ReviewQty;

        public decimal ReviewQty
        {
            get { return _ReviewQty; }
            set { _ReviewQty = value; }
        }
        private int _PackCount;

        public int PackCount
        {
            get { return _PackCount; }
            set { _PackCount = value; }
        }
        private int _ShelvePackCount;

        public int ShelvePackCount
        {
            get { return _ShelvePackCount; }
            set { _ShelvePackCount = value; }
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
        private DateTime? _CreateDate;

        public DateTime? CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        private string _TrackNo;

        public string TrackNo
        {
            get { return _TrackNo; }
            set { _TrackNo = value; }
        }
        private string _Unit;

        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
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


        public string StrStatus { get; set; }
        public string StrIsQualityComp { get; set; }
        public string KeeperUserName { get; set; }
        public string OperatorUserName { get; set; }


    }
}
