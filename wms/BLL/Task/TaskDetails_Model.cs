using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.PrintBarcode;

namespace BLL.Task
{
    [Serializable]
    public class TaskDetails_Model
    {
        public int ID { get; set; }

        public int Task_ID { get; set; }        

        public string ToAreaNo { get; set; }

        public string MaterialNo { get; set; }        

        public string MaterialDesc { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string MaterialStd { get; set; }


        public decimal TaskQty { get; set; }

        public decimal QuanlityQty { get; set; }

        public decimal RemainQty { get; set; }

        public decimal ShelveQty { get; set; }

        public decimal ScanQty { get; set; }

        public int Status { get; set; }

        public int IsQualityComp { get; set; }

        public string QCUserNo { get; set; }

        public DateTime QCDateTime { get; set; }

        public string KeeperUserNo { get; set; }

        public string OperatorUserNo { get; set; }

        public DateTime CompleteDateTime { get; set; }

        public string TMaterialNo { get; set; }

        public string TMaterialDesc { get; set; }

        public decimal OutStockQty { get; set; }

        public decimal ReviewQty { get; set; }

        public string ReviewUserNo { get; set; }

        public decimal UnQuanlityQty { get; set; }

        public string UnQuanlityReson { get; set; }

        public decimal DeliveryQty { get; set; }
        
        public List<TaskSerial_Model> lstSerial { get; set; }

        public string Unit { get; set; }

        public int IsROHS { get; set; }

        public string RowNo { get; set; }
        public string Plant { get; set; }
        public string PlantName { get; set; }
        public string StorageLoc { get; set; }

        public string VoucherNo { get; set; }

        public decimal PackCount { get; set; }

        public int ScanPackCount { get; set; }

        public decimal RemainPackCount { get; set; }

        public decimal ShelvePackCount { get; set; }

        /// <summary>
        /// 当期下架过账数量
        /// </summary>
        public decimal CurrentPostQty { get; set; }

        /// <summary>
        /// SAP余量库存
        /// </summary>
        public decimal RemainStockQty { get; set; }
    }
}
