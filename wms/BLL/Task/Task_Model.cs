using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Task
{
    [Serializable]
    public class Task_Model
    {
        public int ID { get; set; }

        public int VoucherType { get; set; }

        public string VoucherTypeName { get; set; }

        public int TaskType { get; set; }

        public string TaskNo { get; set; }

        public string SupCusName { get; set; }

        public int TaskStatus { get; set; }

        public string StatusName { get; set; }

        public string AuditUserNo { get; set; }

        public DateTime? AuditDateTime { get; set; }

        public DateTime TaskIssued { get; set; }

        public string ReceiveUserNo { get; set; }

        public string ReceiveUserName { get; set; }

        public DateTime CreateDateTime { get; set; }

        public int IsQuality { get; set; }

        public string Remark { get; set; }

        public string Reason { get; set; }

        public string SupCusNo { get; set; }

        public string CreateUserNo { get; set; }

        public int Receive_ID { get; set; }

        public string DeliveryNo { get; set; }

        /// <summary>
        /// 是否收货过账
        /// </summary>
        public int IsReceivePost { get; set; }

        /// <summary>
        /// 是否上架后过账
        /// </summary>
        public int IsShelvePost { get; set; }
        
        public string MaterialDoc { get; set; }
        /// <summary>
        /// 单据号
        /// </summary>
        public string VoucherNo { get; set; }
        /// <summary>
        /// 是否过账（文字）
        /// </summary>
        public string ShelvePost { get; set; }

        public List<TaskDetails_Model> lstTaskDetails { get; set; }

        public string Plant { get; set; }

        public int PostStatus { get; set; }

        public MaterialDocument.MaterialDoc_Model materialDocModel { get; set; }

        public string MoveType { get; set; }

        public string WareHouseNo { get; set; }//仓库编码
    }
}
