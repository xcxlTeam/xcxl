using BLL.DeliveryReceive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Basic.UserGroup
{
    public class UserGroupInfo : Common.BasicInfo
    {
        public UserGroupInfo()
            : base() 
        {
            Dghead = new Dghead();
        }

        private string _UserGroupNo;

        public string UserGroupNo
        {
            get { return _UserGroupNo; }
            set { _UserGroupNo = value; }
        }
        private string _UserGroupName;

        public string UserGroupName
        {
            get { return _UserGroupName; }
            set { _UserGroupName = value; }
        }
        private string _UserGroupAbbName;

        public string UserGroupAbbName
        {
            get { return _UserGroupAbbName; }
            set { _UserGroupAbbName = value; }
        }
        private int _UserGroupType;

        public int UserGroupType
        {
            get { return _UserGroupType; }
            set { _UserGroupType = value; }
        }
        private int _UserGroupStatus;

        public int UserGroupStatus
        {
            get { return _UserGroupStatus; }
            set { _UserGroupStatus = value; }
        }
        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
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

        public string StrUserGroupType { get; set; }

        public string StrUserGroupStatus { get; set; }

        public bool BIsChecked { get; set; }
    }
}
