using BLL.DeliveryReceive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Basic.User
{
    /// </summary>
    [Serializable]
    public class UserInfo : Common.BasicInfo
    {
        //无参构造函数
        public UserInfo()
            : base() 
        {
            Dghead = new Dghead();

            lstUserGroup = new List<UserGroup.UserGroupInfo>();
            lstMenu = new List<Menu.MenuInfo>();
            lstWarehouse = new List<Warehouse.WarehouseInfo>();
        }
        

        //私有变量
        private string userNo;
        private string userName;
        private string password;
        private int userType;
        private string pinYin;
        private string duty;
        private string tel;
        private string mobile;
        private string email;
        private int sex;
        private int isPick;
        private int isReceive;
        private int isQuality;
        private int userStatus;
        private string address;
        private string groupCode;
        private string warehouseCode;
        private string description;
        private string loginIP;
        private DateTime? loginTime;
        private string loginDevice;



        //公开属性

        public string UserNo
        {
            get
            {
                return userNo;
            }
            set
            {
                userNo = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public int UserType
        {
            get
            {
                return userType;
            }
            set
            {
                userType = value;
            }
        }

        public string PinYin
        {
            get
            {
                return pinYin;
            }
            set
            {
                pinYin = value;
            }
        }

        public string Duty
        {
            get
            {
                return duty;
            }
            set
            {
                duty = value;
            }
        }

        public string Tel
        {
            get
            {
                return tel;
            }
            set
            {
                tel = value;
            }
        }

        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public int Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }

        public int IsPick
        {
            get { return isPick; }
            set { isPick = value; }
        }

        public int IsReceive
        {
            get { return isReceive; }
            set { isReceive = value; }
        }

        public int IsQuality
        {
            get { return isQuality; }
            set { isQuality = value; }
        }

        public int UserStatus
        {
            get { return userStatus; }
            set { userStatus = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string GroupCode
        {
            get { return groupCode; }
            set { groupCode = value; }
        }

        public string WarehouseCode
        {
            get { return warehouseCode; }
            set { warehouseCode = value; }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public string LoginIP
        {
            get
            {
                return loginIP;
            }
            set
            {
                loginIP = value;
            }
        }

        public DateTime? LoginTime
        {
            get { return loginTime; }
            set { loginTime = value; }
        }

        public string LoginDevice
        {
            get { return loginDevice; }
            set { loginDevice = value; }
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

        /// <summary>
        /// 确认密码
        /// </summary>
        public string RePassword { get; set; }
        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool BIsAdmin { get; set; }
        public string StrIsAdmin { get; set; }
        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// 仓库编号
        /// </summary>
        public string WarehouseNo { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WarehouseName { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public string StrUserType { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        public string StrUserStatus { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public string StrSex { get; set; }
        /// <summary>
        /// 是否拣货
        /// </summary>
        public bool BIsPick { get; set; }
        public string StrIsPick { get; set; }
        /// <summary>
        /// 是否收货
        /// </summary>
        public bool BIsReceive { get; set; }
        public string StrIsReceive { get; set; }
        /// <summary>
        /// 是否提示质检
        /// </summary>
        public bool BIsQuality { get; set; }
        public string StrIsQuality { get; set; }
        /// <summary>
        /// 所属用户组
        /// </summary>
        public List<UserGroup.UserGroupInfo> lstUserGroup { get; set; }
        /// <summary>
        /// 菜单权限
        /// </summary>
        public List<Menu.MenuInfo> lstMenu { get; set; }
        /// <summary>
        /// 负责仓库
        /// </summary>
        public List<Warehouse.WarehouseInfo> lstWarehouse { get; set; }

        public int IsOnline { get; set; }

        public bool BIsOnline { get; set; }
    }
}
