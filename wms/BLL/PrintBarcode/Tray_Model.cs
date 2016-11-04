using BLL.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.PrintBarcode
{
    [Serializable]
    public class Tray_Model
    {
        public List<TrayDetails_Model> listDetails { get; set; }

        public int TrayID { get; set; }

        public string TrayNO { get; set; }

        public double TrayQty { get; set; }
    }
}
