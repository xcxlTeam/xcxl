using BLL.DeliveryReceive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Basic.TempMaterial
{
    public class TempMaterialInfo : Common.BasicInfo
    {
        public TempMaterialInfo()
            : base()
        {
            Dghead = new Dghead();
        }

        private string _TempMaterialNo;

        public string TempMaterialNo
        {
            get { return _TempMaterialNo; }
            set { _TempMaterialNo = value; }
        }
        private string _TempMaterialDesc;

        public string TempMaterialDesc
        {
            get { return _TempMaterialDesc; }
            set { _TempMaterialDesc = value; }
        }
        private string _MaterialNo;

        public string MaterialNo
        {
            get { return _MaterialNo; }
            set { _MaterialNo = value; }
        }
        private string _MaterialDesc;

        public string MaterialDesc
        {
            get { return _MaterialDesc; }
            set { _MaterialDesc = value; }
        }
        private string _SapMaterialDoc;

        public string SapMaterialDoc
        {
            get { return _SapMaterialDoc; }
            set { _SapMaterialDoc = value; }
        }
        private string _ReplaceUser;

        public string ReplaceUser
        {
            get { return _ReplaceUser; }
            set { _ReplaceUser = value; }
        }
        private DateTime? _ReplaceTime;

        public DateTime? ReplaceTime
        {
            get { return _ReplaceTime; }
            set { _ReplaceTime = value; }
        }
        private int _TempMaterialStatus;

        public int TempMaterialStatus
        {
            get { return _TempMaterialStatus; }
            set { _TempMaterialStatus = value; }
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

        public string StrTempMaterialStatus { get; set; }

        public string Unit { get; set; }

        public int IsRohs { get; set; }
    }
}
