using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.PrintBarcode
{
    public class InnerBarcode_Model
    {
        public decimal id { get; set; }

        public string InnerBarcode { get; set; }

        public decimal InnerQty { get; set; }

        public decimal PrintQty { get; set; }

        public decimal OutBox_ID { get; set; }

        public string SerialNo { get; set; }

        public string BatchNo { get; set; }

        public string OutBarcode { get; set; } 
    }
}
