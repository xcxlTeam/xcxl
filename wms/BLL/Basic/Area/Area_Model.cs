using BLL.DeliveryReceive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Basic.Area
{
    public class AreaInfo : Common.BasicInfo
    {
        public AreaInfo()
            : base()
        {
            Dghead = new Dghead();
        }


        private string _AreaNo;

        public string AreaNo
        {
            get { return _AreaNo; }
            set { _AreaNo = value; }
        }
        private string _AreaName;

        public string AreaName
        {
            get { return _AreaName; }
            set { _AreaName = value; }
        }
        private int _AreaType;

        public int AreaType
        {
            get { return _AreaType; }
            set { _AreaType = value; }
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
        private string _LocationDesc;

        public string LocationDesc
        {
            get { return _LocationDesc; }
            set { _LocationDesc = value; }
        }
        private int _AreaStatus;

        public int AreaStatus
        {
            get { return _AreaStatus; }
            set { _AreaStatus = value; }
        }
        private int _HouseID;

        public int HouseID
        {
            get { return _HouseID; }
            set { _HouseID = value; }
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

        public bool BIsLock { get; set; }
        /// <summary>
        /// 是否代管
        /// </summary>
        public bool isHost { get; set; }

        public string WarehouseNo { get; set; }

        public string WarehouseName { get; set; }

        public string HouseNo { get; set; }

        public string HouseName { get; set; }

        public string StrAreaStatus { get; set; }

        public int CheckID { get; set; }
    }
}
