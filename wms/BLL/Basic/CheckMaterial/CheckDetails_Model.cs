using System;


namespace BLL.Check
{
    public class CheckDetailsInfo
    {
        public CheckDetailsInfo()
            : base()
        {

        }

        private int _ID;

        //[OracleObjectMappingAttribute("ID")]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private int _CheckID;

        //[OracleObjectMapping("CheckID")]
        public int CheckID
        {
            get { return _CheckID; }
            set { _CheckID = value; }
        }
        private string _WarehouseNo;

        //[OracleObjectMapping("WarehouseNo")]
        public string WarehouseNo
        {
            get { return _WarehouseNo; }
            set { _WarehouseNo = value; }
        }
        private string _HouseNo;

        //[OracleObjectMapping("HouseNo")]
        public string HouseNo
        {
            get { return _HouseNo; }
            set { _HouseNo = value; }
        }
        private string _AreaNo;

        //[OracleObjectMapping("AreaNo")]
        public string AreaNo
        {
            get { return _AreaNo; }
            set { _AreaNo = value; }
        }
        private string _MaterialNo;

        //[OracleObjectMapping("MaterialNo")]
        public string MaterialNo
        {
            get { return _MaterialNo; }
            set { _MaterialNo = value; }
        }
        private string _MaterialDesc;

        //[OracleObjectMapping("MaterialDesc")]
        public string MaterialDesc
        {
            get { return _MaterialDesc; }
            set { _MaterialDesc = value; }
        }
        private decimal _AccountQty;

        //[OracleObjectMapping("AccountQty")]
        public decimal AccountQty
        {
            get { return _AccountQty; }
            set { _AccountQty = value; }
        }
        private decimal _ScanQty;

        //[OracleObjectMapping("ScanQty")]
        public decimal ScanQty
        {
            get { return _ScanQty; }
            set { _ScanQty = value; }
        }
        private int _Status;

        //[OracleObjectMapping("Status")]
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        private DateTime? _StockTime;

        //[OracleObjectMapping("StockTime")]
        public DateTime? StockTime
        {
            get { return _StockTime; }
            set { _StockTime = value; }
        }
        private string _Operator;

        //[OracleObjectMapping("Operator")]
        public string Operator
        {
            get { return _Operator; }
            set { _Operator = value; }
        }
        private DateTime? _OperationTime;

        //[OracleObjectMapping("OperationTime")]
        public DateTime? OperationTime
        {
            get { return _OperationTime; }
            set { _OperationTime = value; }
        }
        private int _ProfitLoss;

        //[OracleObjectMapping("ProfitLoss")]
        public int ProfitLoss
        {
            get { return _ProfitLoss; }
            set { _ProfitLoss = value; }
        }
        private decimal _DifferenceQty;

        //[OracleObjectMapping("DifferenceQty")]
        public decimal DifferenceQty
        {
            get { return _DifferenceQty; }
            set { _DifferenceQty = value; }
        }
        private string _Keeper;

        //[OracleObjectMapping("Keeper")]
        public string Keeper
        {
            get { return _Keeper; }
            set { _Keeper = value; }
        }
        


        //辅助字段


        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int CheckType { get; set; }
        public string SerialNo{get;set;}

        public string MaterialStd { get; set; }

        public string WarehouseName { get; set; }

        public string HouseName { get; set; }

        public string AreaName { get; set; }

        public string StrStatus { get; set; }

        public int HaveDiff { get; set; }

        public string StrHaveDiff { get; set; }

        public string StrProfitLoss { get; set; }

        public int CheckYetMonth { get; set; }

        public bool BIsChecked { get; set; }


        public string CheckNo { get; set; }
        public string strCheckType { get; set; }

        public string ScanAreaNo { get; set; }
        public string ScanAreaName { get; set; }

        public string ScanHouseNo { get; set; }
        public string ScanHouseName { get; set; }

        public string ScanWarehouseNo { get; set; }
        public string ScanWarehouseName { get; set; }

    }
}
