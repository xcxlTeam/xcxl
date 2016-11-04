using JXBLL.Common;
using System;
using Oracle.DataAccess.Types;
using System.Data.SqlClient;


namespace JXBLL.Basic.Check
{
    [OracleCustomTypeMappingAttribute("CheckDetailsInfo_List")]
    public class CheckDetailsInfo_ListFactory : IOracleyTypeFactory
    {
        #region ISqlArrayTypeFactory Members

        public Array CreateArray(int numElems)
        {
            return new CheckDetailsInfo[numElems];
        }

        public Array CreateStatusArray(int numElems)
        {
            return null;
        }

        #endregion
    }

    [SqlCustomTypeMappingAttribute("CheckDetailsInfo")]
    public class CheckDetailsFactory : ISqlCustomTypeFactory
    {
        public ISqlCustomType CreateObject()
        {
            return new CheckDetailsInfo();
        }
    }

    public class CheckDetailsInfo : ISqlCustomType
    {
        public CheckDetailsInfo()
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
        private int _CheckID;

        [SqlObjectMappingAttribute("CheckID")]
        public int CheckID
        {
            get { return _CheckID; }
            set { _CheckID = value; }
        }
        private string _WarehouseNo;

        [SqlObjectMappingAttribute("WarehouseNo")]
        public string WarehouseNo
        {
            get { return _WarehouseNo; }
            set { _WarehouseNo = value; }
        }
        private string _HouseNo;

        [SqlObjectMappingAttribute("HouseNo")]
        public string HouseNo
        {
            get { return _HouseNo; }
            set { _HouseNo = value; }
        }
        private string _AreaNo;

        [SqlObjectMappingAttribute("AreaNo")]
        public string AreaNo
        {
            get { return _AreaNo; }
            set { _AreaNo = value; }
        }
        private string _MaterialNo;

        [SqlObjectMappingAttribute("MaterialNo")]
        public string MaterialNo
        {
            get { return _MaterialNo; }
            set { _MaterialNo = value; }
        }
        private string _MaterialDesc;

        [SqlObjectMappingAttribute("MaterialDesc")]
        public string MaterialDesc
        {
            get { return _MaterialDesc; }
            set { _MaterialDesc = value; }
        }
        private decimal _AccountQty;

        [SqlObjectMappingAttribute("AccountQty")]
        public decimal AccountQty
        {
            get { return _AccountQty; }
            set { _AccountQty = value; }
        }
        private decimal _ScanQty;

        [SqlObjectMappingAttribute("ScanQty")]
        public decimal ScanQty
        {
            get { return _ScanQty; }
            set { _ScanQty = value; }
        }
        private int _Status;

        [SqlObjectMappingAttribute("Status")]
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        private DateTime? _StockTime;

        [SqlObjectMappingAttribute("StockTime")]
        public DateTime? StockTime
        {
            get { return _StockTime; }
            set { _StockTime = value; }
        }
        private string _Operator;

        [SqlObjectMappingAttribute("Operator")]
        public string Operator
        {
            get { return _Operator; }
            set { _Operator = value; }
        }
        private DateTime? _OperationTime;

        [SqlObjectMappingAttribute("OperationTime")]
        public DateTime? OperationTime
        {
            get { return _OperationTime; }
            set { _OperationTime = value; }
        }
        private int _ProfitLoss;

        [SqlObjectMappingAttribute("ProfitLoss")]
        public int ProfitLoss
        {
            get { return _ProfitLoss; }
            set { _ProfitLoss = value; }
        }
        private decimal _DifferenceQty;

        [SqlObjectMappingAttribute("DifferenceQty")]
        public decimal DifferenceQty
        {
            get { return _DifferenceQty; }
            set { _DifferenceQty = value; }
        }
        private string _Keeper;

        [SqlObjectMappingAttribute("Keeper")]
        public string Keeper
        {
            get { return _Keeper; }
            set { _Keeper = value; }
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
        public int CheckType { get; set; }

        public string WarehouseName { get; set; }

        public string HouseName { get; set; }

        public string AreaName { get; set; }

        public string StrStatus { get; set; }

        public int HaveDiff { get; set; }

        public string StrHaveDiff { get; set; }

        public int CheckYetMonth { get; set; }

        public bool BIsChecked { get; set; }


        public void FromCustomObject(SqlConnection con, IntPtr pUdt)
        {
            SqlUdt.SetValue(con, pUdt, "ID", ID.ToSqlValue());
            SqlUdt.SetValue(con, pUdt, "CheckID", CheckID.ToSqlValue());
            SqlUdt.SetValue(con, pUdt, "WarehouseNo", WarehouseNo.ToSqlValue());
            SqlUdt.SetValue(con, pUdt, "HouseNo", HouseNo.ToSqlValue());
            SqlUdt.SetValue(con, pUdt, "AreaNo", AreaNo.ToSqlValue());
            SqlUdt.SetValue(con, pUdt, "MaterialNo", MaterialNo.ToSqlValue());
            SqlUdt.SetValue(con, pUdt, "MaterialDesc", MaterialDesc.ToSqlValue());
            SqlUdt.SetValue(con, pUdt, "AccountQty", AccountQty.ToSqlValue());
            SqlUdt.SetValue(con, pUdt, "ScanQty", ScanQty.ToSqlValue());
            SqlUdt.SetValue(con, pUdt, "Status", Status.ToSqlValue());
            SqlUdt.SetValue(con, pUdt, "StockTime", StockTime.ToSqlValue());
            SqlUdt.SetValue(con, pUdt, "Operator", Operator.ToSqlValue());
            SqlUdt.SetValue(con, pUdt, "OperationTime", OperationTime.ToSqlValue());
            SqlUdt.SetValue(con, pUdt, "ProfitLoss", ProfitLoss.ToSqlValue());
            SqlUdt.SetValue(con, pUdt, "DifferenceQty", DifferenceQty.ToSqlValue());
            SqlUdt.SetValue(con, pUdt, "IsDel", IsDel.ToSqlValue());
            SqlUdt.SetValue(con, pUdt, "Creater", Creater.ToSqlValue());
            SqlUdt.SetValue(con, pUdt, "CreateTime", CreateTime.ToSqlValue());
            SqlUdt.SetValue(con, pUdt, "Modifyer", Modifyer.ToSqlValue());
            SqlUdt.SetValue(con, pUdt, "ModifyTime", ModifyTime.ToSqlValue());
        }

        public void ToCustomObject(SqlConnection con, IntPtr pUdt)
        {
            ID = SqlUdt.GetValue(con, pUdt, "ID").ToInt32();
            CheckID = SqlUdt.GetValue(con, pUdt, "CheckID").ToInt32();
            WarehouseNo = SqlUdt.GetValue(con, pUdt, "WarehouseNo").ToDBString();
            HouseNo = SqlUdt.GetValue(con, pUdt, "HouseNo").ToDBString();
            AreaNo = SqlUdt.GetValue(con, pUdt, "AreaNo").ToDBString();
            MaterialNo = SqlUdt.GetValue(con, pUdt, "MaterialNo").ToDBString();
            MaterialDesc = SqlUdt.GetValue(con, pUdt, "MaterialDesc").ToDBString();
            AccountQty = SqlUdt.GetValue(con, pUdt, "AccountQty").ToDecimal();
            ScanQty = SqlUdt.GetValue(con, pUdt, "ScanQty").ToDecimal();
            Status = SqlUdt.GetValue(con, pUdt, "Status").ToInt32();
            StockTime = SqlUdt.GetValue(con, pUdt, "StockTime").ToDateTimeNull();
            Operator = SqlUdt.GetValue(con, pUdt, "Operator").ToDBString();
            OperationTime = SqlUdt.GetValue(con, pUdt, "OperationTime").ToDateTimeNull();
            ProfitLoss = SqlUdt.GetValue(con, pUdt, "ProfitLoss").ToInt32();
            DifferenceQty = SqlUdt.GetValue(con, pUdt, "DifferenceQty").ToDecimal();
            IsDel = SqlUdt.GetValue(con, pUdt, "ISDEL").ToInt32();
            Creater = SqlUdt.GetValue(con, pUdt, "CREATER").ToDBString();
            CreateTime = SqlUdt.GetValue(con, pUdt, "CREATETIME").ToDateTime();
            Modifyer = SqlUdt.GetValue(con, pUdt, "MODIFYER").ToDBString();
            ModifyTime = SqlUdt.GetValue(con, pUdt, "MODIFYTIME").ToDateTimeNull();
        }
    }
}
