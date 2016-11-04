using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.PrintBarcode
{
    /// <summary>
    /// 用于拆箱的条码实体类
    /// </summary>
    public class BarDesign
    {
        public string serialno { get; set; }
        public string barcodetype { get; set; }
        /// <summary>
        /// -1表示拆箱预留|0表示数量不修改|其他表示修改数量
        /// </summary>
        public double qty { get; set; }

    }
}
