using BLL.DeliveryReceive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Basic.House
{
    public class HouseInfo : Common.BasicInfo
    {
        public HouseInfo()
            : base()
        {
            Dghead = new Dghead();
        }

        private string _HouseNo;

        public string HouseNo
        {
            get { return _HouseNo; }
            set { _HouseNo = value; }
        }
        private string _HouseName;

        public string HouseName
        {
            get { return _HouseName; }
            set { _HouseName = value; }
        }
        private int _HouseType;

        public int HouseType
        {
            get { return _HouseType; }
            set { _HouseType = value; }
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
        private int _AreaCount;

        public int AreaCount
        {
            get { return _AreaCount; }
            set { _AreaCount = value; }
        }
        private int _AreaUsingCount;

        public int AreaUsingCount
        {
            get { return _AreaUsingCount; }
            set { _AreaUsingCount = value; }
        }
        private string _LocationDesc;

        public string LocationDesc
        {
            get { return _LocationDesc; }
            set { _LocationDesc = value; }
        }
        private int _HouseStatus;

        public int HouseStatus
        {
            get { return _HouseStatus; }
            set { _HouseStatus = value; }
        }
        private int _WarehouseID;

        public int WarehouseID
        {
            get { return _WarehouseID; }
            set { _WarehouseID = value; }
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


        public string AreaNo { get; set; }

        public string AreaName { get; set; }

        public bool BIsLock { get; set; }

        public string WarehouseNo { get; set; }

        public string WarehouseName { get; set; }

        public string StrHouseStatus { get; set; }

        public decimal AreaRate { get; set; }
    }
}
