using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BLL.DeliveryReceive
{
    public class DeliveryReceive_Http
    {


        /// <summary>
        /// 判断获取数据是否成功
        /// </summary>
        /// <param name="xmldoc"></param>
        /// <returns></returns>
        public static bool IsDataSuccess(XmlDocument xmldoc)
        {
            XmlElement root = null;
            root = xmldoc.DocumentElement;

            XmlNode xnode = root.SelectSingleNode("TYPE");

            if ("S" == xnode.InnerText)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 如果获取数据不成功，返回错误信息
        /// </summary>
        /// <param name="strxml"></param>
        /// <returns></returns>
        public static string getErrorMessage(XmlDocument xmldoc)
        {
            string errorMessage = null;
            if (IsDataSuccess(xmldoc) == false)
            {
                XmlElement root = null;
                root = xmldoc.DocumentElement;

                XmlNode xnode = root.SelectSingleNode("MESSAGE");

                errorMessage = xnode.InnerText;
            }
            return errorMessage;
        }
        /// <summary>
        /// 返回送货单列表
        /// </summary>
        /// <param name="xmldoc"></param>
        /// <returns></returns>
        public static List<PrintBarcode.Barcode_Model> getSendOrderList(XmlDocument xmldoc)
        {
            // PrintBarcode.Barcode_Model deliveryModel = new PrintBarcode.Barcode_Model();
            //DeliveryReceive_Model model = new DeliveryReceive_Model();
            List<PrintBarcode.Barcode_Model> lstBarcode = new List<PrintBarcode.Barcode_Model>();

            string deliveryNo = "Null"; //送货单号
            string supName = "Null"; //获取供应商名称
            string supCode = "Null"; //获取供应商编码
            string factory = "Null"; //京信工厂
            string factoryName = "Null"; //京信工厂名称

            XmlElement root = null;
            root = xmldoc.DocumentElement;

            XmlNodeList sup = null;
            sup = root.SelectNodes("/root/DGHEAD");

            foreach (XmlNode x in sup)
            {
                if (x.ChildNodes.Count != 0)
                {
                    supName = string.IsNullOrEmpty(x["SUPNAME"].InnerText) ? "Null" : x["SUPNAME"].InnerText;
                    supCode = string.IsNullOrEmpty(x["SUPCODE"].InnerText) ? "Null" : x["SUPCODE"].InnerText;
                }

            }


            //获取Item列表
            XmlNodeList listnodes = null;
            listnodes = root.SelectNodes("/root/ITEMS/Item");
            PrintBarcode.Barcode_Func func = new PrintBarcode.Barcode_Func();

            foreach (XmlNode node in listnodes)
            {
                PrintBarcode.Barcode_Model send = new PrintBarcode.Barcode_Model();
                send.VOUCHERTYPE = "10";
                send.BARCODETYPE = 10;
                send.Supplier = node["SUPPLIER"].InnerText;
                send.Comba = node["COMBA"].InnerText;
                send.DELIVERYNO = node["KEYCODE"].InnerText;
                send.CreateTime = node["CREATEDTIME"].InnerText;
                send.ROWNO = node["1"].InnerText;
                send.VOUCHERNO = node["2"].InnerText;
                send.MATERIALNO = node["3"].InnerText;
                send.MATERIALDESC = node["4"].InnerText;
                send.ClaimArriveTime = string.IsNullOrEmpty(node["5"].InnerText) ? string.Empty : node["5"].InnerText;
                send.Unit = node["6"].InnerText;
                send.CURRENTLYDELIVERYNUM = string.IsNullOrEmpty(node["7"].InnerText) ? 0 : Int32.Parse(node["7"].InnerText);
                send.ClaimDeliveryNum = getValue(node["8"].InnerText);
                send.ReadyDeliveryNum = getValue(node["9"].InnerText);
                send.WaitDeliveryNum = getValue(node["10"].InnerText);
                send.InRoadDeliveryNum = getValue(node["11"].InnerText);
                send.ReceiveTime = node["12"].InnerText;
                send.DeliveryAddress = node["13"].InnerText;
                send.CorrespondDepartment = node["14"].InnerText;
                send.WorkCode = node["15"].InnerText;
                send.JingxinName = node["16"].InnerText;
                send.Plant = node["17"].InnerText;
                send.PRDVERSION = node["18"].InnerText;

                send.SUPNAME = supName;
                send.SUPCODE = supCode;

                deliveryNo = send.DELIVERYNO;
                factory = send.Plant;

                func.GetPurchaseByDelivery(ref send);

                //deliveryModel.lstDeliveryDetail = new List<DeliveryReceiveDetail_Model>();
                //deliveryModel.lstDeliveryDetail.Add(send);

                lstBarcode.Add(send);
            }

            return lstBarcode;
        }

        public static DeliveryReceive_Model CreateDeliveryInfo(DeliveryReceive_Model deliveryReceiveModelForSRM)
        {
            string value;
            DeliveryReceive_Model deliveryReceiveMdl = new DeliveryReceive_Model();
            deliveryReceiveMdl.lstDeliveryDetail = new List<DeliveryReceiveDetail_Model>();

            deliveryReceiveMdl.SupCode = deliveryReceiveModelForSRM.Dghead.SupCode;
            deliveryReceiveMdl.SupName = deliveryReceiveModelForSRM.Dghead.SupName;
            deliveryReceiveMdl.VoucherType = 10;
            deliveryReceiveMdl.IsReceivePost = 2;
            deliveryReceiveMdl.IsShelvePost = 2;
            deliveryReceiveMdl.IsQuality = 2;
            deliveryReceiveMdl.materialDocModel = new MaterialDocument.MaterialDoc_Model() { MaterialDoc = string.Empty, MaterialDocDate = string.Empty };
            deliveryReceiveMdl.MoveType = string.Empty;

            foreach (var items in deliveryReceiveModelForSRM.Items)
            {
                DeliveryReceiveDetail_Model DRDM = new DeliveryReceiveDetail_Model();
                deliveryReceiveMdl.DeliveryNo = items.TryGetValue("KEYCODE", out value) == true ? value : string.Empty;
                deliveryReceiveMdl.Plant = items.TryGetValue("17", out value) == true ? value : string.Empty;
                deliveryReceiveMdl.PlantName = string.Empty;
                deliveryReceiveMdl.Titel = "送货单：" + deliveryReceiveMdl.DeliveryNo;

                DRDM.DeliveryNo = items.TryGetValue("KEYCODE", out value) == true ? value : string.Empty;
                DRDM.CreateTime = items.TryGetValue("CREATEDTIME", out value) == true ? value : string.Empty;
                DRDM.RowNo = items.TryGetValue("1", out value) == true ? value : string.Empty;
                DRDM.VoucherNo = items.TryGetValue("2", out value) == true ? value : string.Empty;
                DRDM.MaterialNo = items.TryGetValue("3", out value) == true ? value : string.Empty;
                DRDM.MaterialDesc = items.TryGetValue("4", out value) == true ? value : string.Empty;
                DRDM.ClaimArriveTime = items.TryGetValue("5", out value) == true ? value : string.Empty;
                DRDM.Unit = items.TryGetValue("6", out value) == true ? value : string.Empty;
                DRDM.CurrentlyDeliveryNum = items.TryGetValue("7", out value) == true ? Convert.ToInt32(value) : 0;
                DRDM.ClaimDeliveryNum = items.TryGetValue("8", out value) == true ? Convert.ToInt32(getValue(value)) : 0;
                DRDM.ReadyDeliveryNum = items.TryGetValue("9", out value) == true ? Convert.ToInt32(getValue(value)) : 0;
                DRDM.WaitDeliveryNum = items.TryGetValue("10", out value) == true ? Convert.ToInt32(getValue(value)) : 0;
                DRDM.InRoadDeliveryNum = items.TryGetValue("11", out value) == true ? Convert.ToInt32(getValue(value)) : 0;
                DRDM.ReceiveTime = items.TryGetValue("12", out value) == true ? value : string.Empty;
                DRDM.DeliveryAddress = items.TryGetValue("13", out value) == true ? value : string.Empty;
                DRDM.CorrespondDepartment = items.TryGetValue("14", out value) == true ? value : string.Empty;
                DRDM.WorkCode = items.TryGetValue("15", out value) == true ? value : string.Empty;
                DRDM.JingxinName = items.TryGetValue("16", out value) == true ? value : string.Empty;
                DRDM.Plant = items.TryGetValue("17", out value) == true ? value : string.Empty;
                DRDM.PrdVersion = items.TryGetValue("18", out value) == true ? value : string.Empty;
                DRDM.IsUrgent = 1;//默认是不加急的物料
                DRDM.PlantName = string.Empty;
                DRDM.StorageLoc = string.Empty;
                DRDM.PrdReturnReason = string.Empty;
                DRDM.Barcode = string.Empty;
                DRDM.SerialNo = string.Empty;
                DRDM.ReserveNumber = string.Empty;
                DRDM.ReserveRowNo = string.Empty;
                DRDM.TrackNo = string.Empty;
                deliveryReceiveMdl.lstDeliveryDetail.Add(DRDM);

            }
            return deliveryReceiveMdl;
        }

        /// <summary>
        /// 当字符串为空时，默认Int值为0
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        private static int getValue(string strValue)
        {
            return string.IsNullOrEmpty(strValue) ? 0 : Int32.Parse(strValue);
        }
    }
}
