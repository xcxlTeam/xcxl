using JXBLL.DeliveryReceive;
using JXBLL.Common;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Sql.DataAccess.Types;
using System.Data.SqlClient;

namespace JXBLL.Basic.Check
{
    [SqlCustomTypeMappingAttribute("CheckInfo")]
    public class CheckFactory : ISqlCustomTypeFactory
    {
        public ISqlCustomType CreateObject()
        {
            return new CheckInfo();
        }
    }

    public class CheckInfo : ISqlCustomType
    {
        public CheckInfo()
            : base()
        {

        }

        private int _ID;

        [SqlObjectMappingAttribute("ID")]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _CheckNo;

        [SqlObjectMappingAttribute("CheckNo")]
        public string CheckNo
        {
            get { return _CheckNo; }
            set { _CheckNo = value; }
        }
        private int _CheckType;

        [SqlObjectMappingAttribute("CheckType")]
        public int CheckType
        {
            get { return _CheckType; }
            set { _CheckType = value; }
        }
        private string _DutyUser;

        [SqlObjectMappingAttribute("DutyUser")]
        public string DutyUser
        {
            get { return _DutyUser; }
            set { _DutyUser = value; }
        }
        private string _CheckDesc;

        [SqlObjectMappingAttribute("CheckDesc")]
        public string CheckDesc
        {
            get { return _CheckDesc; }
            set { _CheckDesc = value; }
        }
        private int _CheckStatus;

        [SqlObjectMappingAttribute("CheckStatus")]
        public int CheckStatus
        {
            get { return _CheckStatus; }
            set { _CheckStatus = value; }
        }
        private DateTime? _BeginTime;

        [SqlObjectMappingAttribute("BeginTime")]
        public DateTime? BeginTime
        {
            get { return _BeginTime; }
            set { _BeginTime = value; }
        }
        private DateTime? _DoneTime;

        [SqlObjectMappingAttribute("DoneTime")]
        public DateTime? DoneTime
        {
            get { return _DoneTime; }
            set { _DoneTime = value; }
        }
        private string _Remarks;

        [SqlObjectMappingAttribute("Remarks")]
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }

        private int _IsDel;

        [SqlObjectMappingAttribute("IsDel")]
        public int IsDel
        {
            get { return _IsDel; }
            set { _IsDel = value; }
        }

        private string _Creater;

        [SqlObjectMappingAttribute("Creater")]
        public string Creater
        {
            get { return _Creater; }
            set { _Creater = value; }
        }
        private DateTime? _CreateTime;

        [SqlObjectMappingAttribute("CreateTime")]
        public DateTime? CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }

        private string _Modifyer;

        [SqlObjectMappingAttribute("Modifyer")]
        public string Modifyer
        {
            get { return _Modifyer; }
            set { _Modifyer = value; }
        }
        private DateTime? _ModifyTime;

        [SqlObjectMappingAttribute("ModifyTime")]
        public DateTime? ModifyTime
        {
            get { return _ModifyTime; }
            set { _ModifyTime = value; }
        }



        //辅助字段


        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public List<CheckDetailsInfo> lstDetails { get; set; }
        public string StrCheckType { get; set; }
        public string StrCheckStatus { get; set; }
        public string EditText { get; set; }

        public void FromCustomObject(SqlConnection con, IntPtr pUdt)
        {
            if (ID != null) SqlUdt.SetValue(con, pUdt, "ID", ID.ToSqlValue());
            if (CheckNo != null) SqlUdt.SetValue(con, pUdt, "CheckNo", CheckNo.ToSqlValue());
            if (CheckType != null) SqlUdt.SetValue(con, pUdt, "CheckType", CheckType.ToSqlValue());
            if (DutyUser != null) SqlUdt.SetValue(con, pUdt, "DutyUser", DutyUser.ToSqlValue());
            if (CheckDesc != null) SqlUdt.SetValue(con, pUdt, "CheckDesc", CheckDesc.ToSqlValue());
            if (CheckStatus != null) SqlUdt.SetValue(con, pUdt, "CheckStatus", CheckStatus.ToSqlValue());
            if (BeginTime != null) SqlUdt.SetValue(con, pUdt, "BeginTime", BeginTime.ToSqlValue());
            if (DoneTime != null) SqlUdt.SetValue(con, pUdt, "DoneTime", DoneTime.ToSqlValue());
            if (Remarks != null) SqlUdt.SetValue(con, pUdt, "Remarks", Remarks.ToSqlValue());
            if (IsDel != null) SqlUdt.SetValue(con, pUdt, "IsDel", IsDel.ToSqlValue());
            if (Creater != null) SqlUdt.SetValue(con, pUdt, "Creater", Creater.ToSqlValue());
            if (CreateTime != null) SqlUdt.SetValue(con, pUdt, "CreateTime", CreateTime.ToSqlValue());
            if (Modifyer != null) SqlUdt.SetValue(con, pUdt, "Modifyer", Modifyer.ToSqlValue());
            if (ModifyTime != null) SqlUdt.SetValue(con, pUdt, "ModifyTime", ModifyTime.ToSqlValue());
        }

        public void ToCustomObject(SqlConnection con, IntPtr pUdt)
        {
            ID = SqlUdt.GetValue(con, pUdt, "ID").ToInt32();
            CheckNo = SqlUdt.GetValue(con, pUdt, "CheckNo").ToDBString();
            CheckType = SqlUdt.GetValue(con, pUdt, "CheckType").ToInt32();
            DutyUser = SqlUdt.GetValue(con, pUdt, "DutyUser").ToDBString();
            CheckDesc = SqlUdt.GetValue(con, pUdt, "CheckDesc").ToDBString();
            CheckStatus = SqlUdt.GetValue(con, pUdt, "CheckStatus").ToInt32();
            BeginTime = SqlUdt.GetValue(con, pUdt, "BeginTime").ToDateTimeNull();
            DoneTime = SqlUdt.GetValue(con, pUdt, "DoneTime").ToDateTimeNull();
            Remarks = SqlUdt.GetValue(con, pUdt, "Remarks").ToDBString();
            IsDel = SqlUdt.GetValue(con, pUdt, "ISDEL").ToInt32();
            Creater = SqlUdt.GetValue(con, pUdt, "CREATER").ToDBString();
            CreateTime = SqlUdt.GetValue(con, pUdt, "CREATETIME").ToDateTime();
            Modifyer = SqlUdt.GetValue(con, pUdt, "MODIFYER").ToDBString();
            ModifyTime = SqlUdt.GetValue(con, pUdt, "MODIFYTIME").ToDateTimeNull();
        }
    }
}
