using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.FastIn
{
    public class TaskVoucher
    {
        public int ID { get; set; }
        public string VoucherNo { get; set; }
        public string Task_ID { get; set; }
        public string Factory { get; set; }
        public string Store { get; set; }

        public List<TaskVoucherDetails> body { get; set; }
    }

    public class TaskVoucherDetails
    {
        public int ID { get; set; }
        public string HeadID { get; set; }
        public string MaterialNo { get; set; }
        public string MaterialDesc { get; set; }
        public decimal Qty { get; set; }
        public string RowNo { get; set; }
        public string Factory { get; set; }
        public string FactoryName { get; set; }
        public string Store { get; set; }
    }
}
