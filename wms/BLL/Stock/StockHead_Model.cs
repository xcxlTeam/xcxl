using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Stock
{
    public class StockHead_Model
    {
        public List<Stock_Model> lstStockInfo { get; set; }

        public string Status { get; set; } //状态 S成功 E 失败

        public string Message { get; set; } //失败消息

    }
}
