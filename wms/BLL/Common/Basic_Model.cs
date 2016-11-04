using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Common
{
    public class BasicInfo
    {

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _No;

        public string No
        {
            get { return _No; }
            set { _No = value; }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private int _IsDel;

        public int IsDel
        {
            get { return _IsDel; }
            set { _IsDel = value; }
        }

        private string _Creater;

        public string Creater
        {
            get { return _Creater; }
            set { _Creater = value; }
        }
        private DateTime? _CreateTime;

        public DateTime? CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }

        private string _Modifyer;

        public string Modifyer
        {
            get { return _Modifyer; }
            set { _Modifyer = value; }
        }
        private DateTime? _ModifyTime;

        public DateTime? ModifyTime
        {
            get { return _ModifyTime; }
            set { _ModifyTime = value; }
        }


        public string StrCreateTime { get; set; }
        public string StrModifyTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

    }

    public class TreeInfo : BasicInfo
    {
        private int _ParentID;

        public int ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }

        private string _ParentName;

        public string ParentName
        {
            get { return _ParentName; }
            set { _ParentName = value; }
        }

        private int _Mnemonic;

        public int Mnemonic
        {
            get { return _Mnemonic; }
            set { _Mnemonic = value; }
        }

        private string _MnemonicCode;

        public string MnemonicCode
        {
            get { return _MnemonicCode; }
            set { _MnemonicCode = value; }
        }

        private string _NodeUrl;

        public string NodeUrl
        {
            get { return _NodeUrl; }
            set { _NodeUrl = value; }
        }

        private int _NodeLevel;

        public int NodeLevel
        {
            get { return _NodeLevel; }
            set { _NodeLevel = value; }
        }

        private int _NodeSort;

        public int NodeSort
        {
            get { return _NodeSort; }
            set { _NodeSort = value; }
        }

        private int _IsEnd;

        public int IsEnd
        {
            get { return _IsEnd; }
            set { _IsEnd = value; }
        }

        private string _IcoName;

        public string IcoName
        {
            get { return _IcoName; }
            set { _IcoName = value; }
        }

        private string _ToolTipText;

        public string ToolTipText
        {
            get { return _ToolTipText; }
            set { _ToolTipText = value; }
        }

        private int _IsChecked;

        public int IsChecked
        {
            get { return _IsChecked; }
            set { _IsChecked = value; }
        }

        private int _SonQty;

        public int SonQty
        {
            get { return _SonQty; }
            set { _SonQty = value; }
        }
    }
}
