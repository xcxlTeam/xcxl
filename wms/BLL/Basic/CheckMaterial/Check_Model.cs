using BLL.Common;
using BLL.DeliveryReceive;
using BLL.PrintBarcode;
using System;
using System.Collections.Generic;

namespace BLL.Check
{
    public class CheckHeader
    {
        public CheckHeader()
            : base()
        {
            Dghead = new Dghead();

            lstCheck = new List<CheckInfo>();
        }

        private string _Operator;

        public string Operator
        {
            get { return _Operator; }
            set { _Operator = value; }
        }
        private List<CheckInfo> _lstCheck;

        public List<CheckInfo> lstCheck
        {
            get { return _lstCheck; }
            set { _lstCheck = value; }
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

    public class CheckInfo : BasicInfo
    {
        public CheckInfo()
            :base()
        {
            Dghead = new Dghead();

            lstDetails = new List<CheckDetailsInfo>();
            lstScanTrans = new List<CheckTransInfo>();
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

        private string _CheckNo;

        //[OracleObjectMapping("CheckNo")]
        public string CheckNo
        {
            get { return _CheckNo; }
            set { _CheckNo = value; }
        }
        private int _CheckType;

        //[OracleObjectMapping("CheckType")]
        public int CheckType
        {
            get { return _CheckType; }
            set { _CheckType = value; }
        }
        private string _DutyUser;

        //[OracleObjectMapping("DutyUser")]
        public string DutyUser
        {
            get { return _DutyUser; }
            set { _DutyUser = value; }
        }
        private string _CheckDesc;

        //[OracleObjectMapping("CheckDesc")]
        public string CheckDesc
        {
            get { return _CheckDesc; }
            set { _CheckDesc = value; }
        }
        private int _CheckStatus;

        //[OracleObjectMapping("CheckStatus")]
        public int CheckStatus
        {
            get { return _CheckStatus; }
            set { _CheckStatus = value; }
        }
        private DateTime? _BeginTime;

        //[OracleObjectMapping("BeginTime")]
        public DateTime? BeginTime
        {
            get { return _BeginTime; }
            set { _BeginTime = value; }
        }
        private DateTime? _DoneTime;

        //[OracleObjectMapping("DoneTime")]
        public DateTime? DoneTime
        {
            get { return _DoneTime; }
            set { _DoneTime = value; }
        }
        private string _Remarks;

        //[OracleObjectMapping("Remarks")]
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        private int _CheckStyle;

        public int CheckStyle
        {
            get { return _CheckStyle; }
            set { _CheckStyle = value; }
        }
        private int _MainCheckID;

        public int MainCheckID
        {
            get { return _MainCheckID; }
            set { _MainCheckID = value; }
        }



        //辅助字段

        public List<CheckDetailsInfo> lstDetails { get; set; }
        public List<CheckTransInfo> lstScanTrans { get; set; }

        public decimal SumScanQty { get; set; }
        public decimal DifferenceQty { get; set; }

        public string StrCheckType { get; set; }
        public string StrCheckStatus { get; set; }
        public string EditText { get; set; }
        public string StrCheckStyle { get; set; }

        public bool BIsMainCheck { get; set; }

        public int ReCheckCount { get; set; }
    }
}
