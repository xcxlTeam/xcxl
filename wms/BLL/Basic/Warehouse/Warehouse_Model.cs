using BLL.DeliveryReceive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Basic.Warehouse
{
    public class WarehouseInfo : Common.BasicInfo
    {
        public WarehouseInfo()
            : base()
        {
            Dghead = new Dghead();
        }

        private string _WarehouseNo;

        public string WarehouseNo
        {
            get { return _WarehouseNo; }
            set { _WarehouseNo = value; }
        }
        private string _WarehouseName;

        public string WarehouseName
        {
            get { return _WarehouseName; }
            set { _WarehouseName = value; }
        }
        private int _WarehouseType;

        public int WarehouseType
        {
            get { return _WarehouseType; }
            set { _WarehouseType = value; }
        }
        private string _ContactUser;

        public string ContactUser
        {
            get { return _ContactUser; }
            set { _ContactUser = value; }
        }
        private string _ContactPhone;

        public string ContactPhone
        {
            get { return _ContactPhone; }
            set { _ContactPhone = value; }
        }
        private int _HouseCount;

        public int HouseCount
        {
            get { return _HouseCount; }
            set { _HouseCount = value; }
        }
        private int _HouseUsingCount;

        public int HouseUsingCount
        {
            get { return _HouseUsingCount; }
            set { _HouseUsingCount = value; }
        }
        private string _LocationDesc;

        public string LocationDesc
        {
            get { return _LocationDesc; }
            set { _LocationDesc = value; }
        }
        private int _WarehouseStatus;

        public int WarehouseStatus
        {
            get { return _WarehouseStatus; }
            set { _WarehouseStatus = value; }
        }
        private string _Address;

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
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


        //辅助字段

        public string HouseNo { get; set; }

        public string HouseName { get; set; }

        public bool BIsLock { get; set; }

        public bool BIsChecked { get; set; }

        public string StrWarehouseType { get; set; }

        public string StrWarehouseStatus { get; set; }

        public int AreaCount { get; set; }

        public int AreaUsingCount { get; set; }

        public decimal HouseRate { get; set; }

        public decimal AreaRate { get; set; }
    }
}
