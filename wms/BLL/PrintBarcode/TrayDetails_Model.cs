using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.PrintBarcode
{
    public class TrayDetails_Model
    {
        public List<string> listBarcode { get; set; }

        public string cinvcode { get; set; }
        public string cinvname { get; set; }
        public string cinvstd { get; set; }
        /// <summary>
        /// 生产订单行号
        /// </summary>
        public string ROWNO { get; set; }
        /// <summary>
        /// 销售订单行号
        /// </summary>
        public string SOROWNO { get; set; }

        public double Qty { get; set; }
    }
}
