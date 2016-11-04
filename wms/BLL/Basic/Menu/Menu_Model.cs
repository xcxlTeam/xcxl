using BLL.DeliveryReceive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Basic.Menu
{
    public class MenuInfo : Common.TreeInfo
    {
        public MenuInfo()
            : base()
        {
            Dghead = new Dghead();
        }

        private string _MenuNo;

        public string MenuNo
        {
            get { return _MenuNo; }
            set { _MenuNo = value; }
        }
        private string _MenuName;

        public string MenuName
        {
            get { return _MenuName; }
            set { _MenuName = value; }
        }
        private string _MenuAbbName;

        public string MenuAbbName
        {
            get { return _MenuAbbName; }
            set { _MenuAbbName = value; }
        }
        private int _MenuType;

        public int MenuType
        {
            get { return _MenuType; }
            set { _MenuType = value; }
        }
        private string _ProjectName;

        public string ProjectName
        {
            get { return _ProjectName; }
            set { _ProjectName = value; }
        }
        private int _SafeLevel;

        public int SafeLevel
        {
            get { return _SafeLevel; }
            set { _SafeLevel = value; }
        }
        private int _MenuStatus;

        public int MenuStatus
        {
            get { return _MenuStatus; }
            set { _MenuStatus = value; }
        }
        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        private int _IsDefault;

        public int IsDefault
        {
            get { return _IsDefault; }
            set { _IsDefault = value; }
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

        public string StrMenuType { get; set; }

        public string StrMenuStatus { get; set; }

        public bool BIsDefault { get; set; }

        public bool BIsChecked { get; set; }

        public bool BHaveParameter { get; set; }
    }
}
