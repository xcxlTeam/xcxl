using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using SAP.Middleware.Connector;
using System.Net;
using System.IO;
using BLL.Basic.User;
using BLL.PrintBarcode;


namespace Test
{
    public partial class Form1 : Form
    {
        localhost.WebService localWebTest = new localhost.WebService();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strJson = "{\"CreateDate\":\"\",\"DeliveryNo\":\"400006153\",\"DocDate\":\"\",\"EndTime\":\"\",\"materialDocModel\":{\"MaterialDoc\":\"\",\"MaterialDocDate\":\"\",\"MaterialDocPost\":\"\",\"MaterialDocType\":0},\"lstDeliveryDetail\":[{\"Barcode\":\"10@710004-000806-0000@2015091400005@1509140005\",\"ClaimArriveTime\":\"\",\"WorkCode\":\"\",\"CorrespondDepartment\":\"\",\"CreateTime\":\"\",\"VoucherNo\":\"400006153\",\"Unit\":\"\",\"StorageLoc\":\"\",\"DeliveryAddress\":\"\",\"DeliveryNo\":\"400006153\",\"SerialNo\":\"2015091400005\",\"RowNo\":\"\",\"ReserveRowNo\":\"\",\"ReserveNumber\":\"\",\"JingxinName\":\"\",\"MaterialDesc\":\"MJS-ODV065R15B18JJ,Ⅳ2,集束天线\",\"MaterialNo\":\"710004-000806-0000\",\"ReceiveTime\":\"\",\"Plant\":\"2000\",\"PlantName\":\"京信技术工厂\",\"PrdReturnReason\":\"\",\"PrdVersion\":\"\",\"QualityQty\":0,\"PackCount\":1,\"ReadyDeliveryNum\":0,\"ReceiveQty\":10,\"OldReceiveQty\":5,\"IsUrgent\":1,\"IsROHS\":0,\"InRoadDeliveryNum\":0,\"ID\":0,\"CurrentlyDeliveryNum\":15,\"CurrentUnQualityQty\":0,\"UnQualityQty\":0,\"CurrentQualityQty\":0,\"CurrentPostQty\":0,\"WaitDeliveryNum\":0,\"ClaimDeliveryNum\":0}],\"MoveType\":\"\",\"Plant\":\"2000\",\"PlantName\":\"京信技术工厂\",\"PostDate\":\"\",\"StartTime\":\"\",\"Status\":\"S\",\"SupCode\":\"\",\"SupName\":\"\",\"IsShelvePost\":2,\"IsReceivePost\":1,\"VoucherType\":40,\"IsQuality\":1,\"ID\":0}";


            for (int i = 0; i < 100; i++)
            {
                BLL.DeliveryReceive.DeliveryReceive_Model DeliveryInfo = BLL.JSONUtil.JSONHelper.JsonToObject<BLL.DeliveryReceive.DeliveryReceive_Model>(strJson);

                string strDeliveryXml = BLL.XMLUtil.XmlUtil.Serializer(typeof(BLL.DeliveryReceive.DeliveryReceive_Model), DeliveryInfo);

                localWebTest.WriteLog(strDeliveryXml);
            }


            //try
            //{
            //    var sap_comm = SAP_Common.CreateInstance();
            //    string strMaterialDoc = string.Empty;
            //    string functionName = \"ZBAPI_GOODSMVT_CREATE_01\";
            //    Dictionary<string, string> lstParameters = new Dictionary<string, string>();
            //    Dictionary<string, Dictionary<string, object>> lstStructures = new Dictionary<string, Dictionary<string, object>>();
            //    Dictionary<string, object> header = new Dictionary<string, object>();
            //    header.Add(\"PSTNG_DATE\", DateTime.Now.ToString(\"yyyy-MM-dd\"));
            //    header.Add(\"DOC_DATE\", DateTime.Now.ToString(\"yyyy-MM-dd\"));
            //    header.Add(\"REF_DOC_NO\", string.Empty);
            //    header.Add(\"BILL_OF_LADING\", string.Empty);
            //    header.Add(\"GR_GI_SLIP_NO\", \"\");
            //    header.Add(\"PR_UNAME\", \"WMSDEMO\");
            //    header.Add(\"HEADER_TXT\", \"测试抬头文本\");
            //    header.Add(\"BAR_CODE\", string.Empty);

            //    lstStructures.Add(\"GOODSMVT_HEADER\", header);


            //    Dictionary<string, string> ParametersOutput = null;
            //    Dictionary<string, IRfcStructure> StructureOutputs = new Dictionary<string, IRfcStructure>();
            //    StructureOutputs.Add(\"GOODSMVT_HEADRET\", null);
            //    Dictionary<string, IRfcTable> rtbsOutput = new Dictionary<string, IRfcTable>();

            //    rtbsOutput.Add(\"RETURN\", null);

            //    IRfcTable rfcTable = sap_comm.CreateIrfcTable(functionName, \"GOODSMVT_ITEM\");
            //    rfcTable.Insert();
            //    rfcTable.CurrentRow.SetValue(\"MATERIAL\", \"102001-000001-00\");
            //    rfcTable.CurrentRow.SetValue(\"PLANT\", \"2000\");
            //    rfcTable.CurrentRow.SetValue(\"STGE_LOC\", \"1101\");
            //    rfcTable.CurrentRow.SetValue(\"PO_NUMBER\", \"4500188475\");
            //    rfcTable.CurrentRow.SetValue(\"PO_ITEM\", \"10\");
            //    rfcTable.CurrentRow.SetValue(\"MOVE_TYPE\", \"103\");
            //    rfcTable.CurrentRow.SetValue(\"ENTRY_QNT\", \"10\");
            //    rfcTable.CurrentRow.SetValue(\"BASE_UOM\", \"只\");
            //    rfcTable.CurrentRow.SetValue(\"MVT_IND\", \"B\");
            //    rfcTable.CurrentRow.SetValue(\"GR_RCPT\", \"WMSDEMO\");

            //    string strErrMsg = string.Empty;
            //    string strMaterialNo = string.Empty;

            //    bool bSucc = sap_comm.PostSapFunctionFromTable(functionName, lstParameters, lstStructures, ref ParametersOutput, ref StructureOutputs, ref rtbsOutput
            //                                                , \"GOODSMVT_ITEM\", rfcTable, ref strErrMsg);
            //    if (bSucc == false)
            //    {
            //        MessageBox.Show(strErrMsg);
            //    }
            //    else 
            //    {
            //        IRfcStructure _GOODSMVT_HEADRET = StructureOutputs[\"GOODSMVT_HEADRET\"];
            //        MessageBox.Show(_GOODSMVT_HEADRET.GetString(\"MAT_DOC\") + _GOODSMVT_HEADRET.GetString(\"DOC_YEAR\"));                    
            //    }
            //}
            //catch (RfcFunctionNotFoundException ex)
            //{
            //    throw new RfcFunctionNotFoundException(ex.Message);
            //}

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //string strUrl = "http://192.168.0.144:9980/portal/rest/sup/getDeliverGoodsInfoFromSrm?systemName=SRM&\";
            //string strErrMsg = string.Empty;


            //Encoding encoding = Encoding.Default;
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);
            //request.Method = "post\";
            //request.Accept = \"text/html, application/xhtml+xml, */*\";
            //request.ContentType = \"application/x-www-form-urlencoded\";
            //byte[] buffer = encoding.GetBytes(\"Code=15050030527\");
            //request.ContentLength = buffer.Length;
            //request.GetRequestStream().Write(buffer, 0, buffer.Length);
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding(\"utf-8\")))
            //{
            //    MessageBox.Show(reader.ReadToEnd());
            //    MessageBox.Show(response.StatusCode.ToString());
            //}

            //MessageBox.Show(HttpPostWebRequest(strUrl, 60, \"Code=1505003052\", true, \"gb2312\", out strErrMsg));
            //MessageBox.Show(strErrMsg);
        }

        /// <summary>
        /// 获取请求结果
        /// </summary>
        /// <param name=\"requestUrl\">请求地址</param>
        /// <param name=\"timeout\">超时时间(秒)</param>
        /// <param name=\"requestXML\">请求xml内容</param>
        /// <param name=\"isPost\">是否post提交</param>
        /// <param name=\"encoding\">编码格式 例如:utf-8</param>
        /// <param name=\"msg\">抛出的错误信息</param>
        /// <returns>返回请求结果</returns>
        public string HttpPostWebRequest(string requestUrl, int timeout, string requestXML, bool isPost, string encoding, out string msg)
        {
            msg = string.Empty;
            string result = string.Empty;
            try
            {
                byte[] bytes = System.Text.Encoding.GetEncoding(encoding).GetBytes(requestXML);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
                request.ContentType = "application/x-www-form-urlencoded";
                request.Referer = requestUrl;
                request.Method = isPost ? "POST" : "GET";
                request.ContentLength = bytes.Length;
                request.Timeout = timeout * 1000;
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                if (responseStream != null)
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding(encoding));
                    result = reader.ReadToEnd();
                    reader.Close();
                    responseStream.Close();
                    request.Abort();
                    response.Close();
                    return result.Trim();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message + ex.StackTrace;
            }

            return result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //IRfcTable rtbInput = null;
            //string tableindex = null;
            //var sap_comm = SAP_Common.CreateInstance();
            //string strMaterialDoc = string.Empty;
            //string functionName = \"ZLS_GET_MAT_WMS\";
            //Dictionary<string, string> lstParameters = new Dictionary<string, string>();
            //lstParameters.Add(\"I_MATNR\", \"102001-000001-00\");
            //Dictionary<string, Dictionary<string, object>> lstStructures =null;
            //List<string> ParameterNamesForOut = null;            
            //Dictionary<string, string> ParametersOutput = null;
            //List<string> StructureNamesForOut = null;
            //Dictionary<string, IRfcStructure> StructureOutputs = null;
            //List<string> tableNamesForOut = new List<string>() { \"T_MATNR\" };
            //Dictionary<string, IRfcTable> rtbsOutput = null;

            //bool bSucc = sap_comm.getSapFunctionToTable(functionName, lstParameters, lstStructures, rtbInput, tableindex, ParameterNamesForOut, out ParametersOutput, StructureNamesForOut,
            //        out StructureOutputs, tableNamesForOut, out rtbsOutput);
            //localhost.TaskDetails_Model TM = new localhost.TaskDetails_Model();
            //string strErrMsg = \"\";
            //localWebTest.GetMaterialInfoForSAP(\"102001-000055-00\", ref TM, ref strErrMsg);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //IRfcTable rtbInput = null;
            //string tableindex = null;
            //var sap_comm = SAP_Common.CreateInstance();
            //string strMaterialDoc = string.Empty;
            //string functionName = \"ZLS_LIFNR_READ_WMS\";
            //Dictionary<string, string> lstParameters = new Dictionary<string, string>();
            //lstParameters.Add(\"IM_NAME\", \"深圳\");
            //Dictionary<string, Dictionary<string, object>> lstStructures = null;
            //List<string> ParameterNamesForOut = null;
            //Dictionary<string, string> ParametersOutput = null;
            //List<string> StructureNamesForOut = null;
            //Dictionary<string, IRfcStructure> StructureOutputs = null;
            //List<string> tableNamesForOut = new List<string>() { \"T_LFA1\" };
            //Dictionary<string, IRfcTable> rtbsOutput = null;

            //bool bSucc = sap_comm.getSapFunctionToTable(functionName, lstParameters, lstStructures, rtbInput, tableindex, ParameterNamesForOut, out ParametersOutput, StructureNamesForOut,
            //        out StructureOutputs, tableNamesForOut, out rtbsOutput);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //IRfcTable rtbInput = null;
            //string tableindex = null;
            //var sap_comm = SAP_Common.CreateInstance();
            //string strMaterialDoc = string.Empty;
            //string functionName = \"ZLS_LIFNR_NAME_READ\";
            //Dictionary<string, string> lstParameters = new Dictionary<string, string>();
            //lstParameters.Add(\"IM_LIFNR\", \"600212\");
            //Dictionary<string, Dictionary<string, object>> lstStructures = null;
            //List<string> ParameterNamesForOut = null;
            //Dictionary<string, string> ParametersOutput = null;
            //List<string> StructureNamesForOut = null;
            //Dictionary<string, IRfcStructure> StructureOutputs = null;
            //List<string> tableNamesForOut = new List<string>() { \"T_LFA1\" };
            //Dictionary<string, IRfcTable> rtbsOutput = null;

            //bool bSucc = sap_comm.getSapFunctionToTable(functionName, lstParameters, lstStructures, rtbInput, tableindex, ParameterNamesForOut, out ParametersOutput, StructureNamesForOut,
            //        out StructureOutputs, tableNamesForOut, out rtbsOutput);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string strJson = string.Empty;

            //JXBLL.ProductionReturn.ProductionReturn_Func PRF = new JXBLL.ProductionReturn.ProductionReturn_Func();

            //strJson = PRF.GetProductionReturnInfoForSAP(\"B115011505\");
            //MessageBox.Show(\"ad\");

            //strJson = webTest.GetProductionReturnInfoForSAP(\"TEST09001\");
            //MessageBox.Show(\"ad\");
        }


        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

            Test.localhost.Barcode_Model[] lstBarcode = null;
            //string strJson = string.Empty;
            string strErrMsg = string.Empty;
            //JXBLL.DeliveryReceive.DeliveryReceive_Func DF = new JXBLL.DeliveryReceive.DeliveryReceive_Func();
            //List<Test.JingXinWebTest.Barcode_Model> lstBarcode = new List<Test.JingXinWebTest.Barcode_Model>();

            //DF.GetDeliveryInfo(\"15030016366\", ref lstBarcode, ref strErrMsg);
            //MessageBox.Show(\"213\");

            //bool bSucc = localWebTest.GetDeliveryInfoForPrint("15090031720", ref lstBarcode,ref strErrMsg);
            //JXBLL.DeliveryReceive.DeliveryReceive_Model DM= JXBLL.JSONUtil.JSONHelper.JsonToObject<JXBLL.DeliveryReceive.DeliveryReceive_Model>(strJosin);
            //localhost.Barcode_Model[] barcodeArray =null;
            //localWebTest.GetDeliveryInfoForPrint(\"15080031478\", ref barcodeArray, ref strErrMsg);
            MessageBox.Show("213");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //UserInfo uf = new UserInfo();
            //string strErrMsg =\"\";

            //JXBLL.DeliveryReceive.DeliveryReceive_Func DF = new JXBLL.DeliveryReceive.DeliveryReceive_Func();
            //DF.PostDelivery(uf, ref strErrMsg);
            //MessageBox.Show(\"213\");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string strJson = string.Empty;
            string strErrMsg = string.Empty;
            BLL.DeliveryReceive.DeliveryReceive_Func DF = new BLL.DeliveryReceive.DeliveryReceive_Func();
            strJson = DF.GetDeliveryInfoForAndroid("15030015326", string.Empty);
            MessageBox.Show("213");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //string strJson = string.Empty;
            //string strErrMsg = string.Empty;
            //JXBLL.ReceiveGoods.ReceiveGoods_Func DF = new JXBLL.ReceiveGoods.ReceiveGoods_Func();
            //strJson=DF.GetBarCodeInfo(\"10@102001-000001-00@201506080082\");
            //webTest.Url = \"http://192.168.0.215:8080/JXWebService.asmx\";
            //localWebTest.GetBarCodeInfo(\"201507170142\");
            string strJson = localWebTest.GetBarCodeInfo("15112420001");
            localhost.Barcode_Model model = BLL.JSONUtil.JSONHelper.JsonToObject<localhost.Barcode_Model>(strJson);
            MessageBox.Show("ad");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //web送货单
            //webTest.Url = \"http://192.168.0.215:8080/JXWebService.asmx\";
            //string strJson = webTest.GetDeliveryInfoForAndroid(\"15070031457\", string.Empty);
            //strJson = webTest.PostReceiveGoodsInfo(strJson, string.Empty);
            //MessageBox.Show(\"ad\");
            //本地送货单
            //string strErrMsg = \"\";
            //localhost.UserInfo userInfo = new localhost.UserInfo();
            //userInfo.UserNo = \"A003\";

            //localWebTest.UserLogin(ref userInfo, ref strErrMsg);

            //string strUserJson = JXBLL.JSONUtil.JSONHelper.ObjectToJson<localhost.UserInfo>(userInfo);

            //string strJson = localWebTest.GetDeliveryInfoForAndroid(\"15080031535\", strUserJson);//15050030527 

            //localhost.DeliveryReceive_Model deliveryModel = JXBLL.JSONUtil.JSONHelper.JsonToObject<localhost.DeliveryReceive_Model>(strJson);
            //deliveryModel.IsQuality = 2;
            //deliveryModel.lstDeliveryDetail.ToList().ForEach(t => t.ReceiveQty = 10);
            //strJson = JXBLL.JSONUtil.JSONHelper.ObjectToJson<localhost.DeliveryReceive_Model>(deliveryModel);
            //strJson = localWebTest.PostReceiveGoodsInfo(strJson, strUserJson);

            //MessageBox.Show(\"ad\");

            //web生产退料
            //webTest.Url = \"http://192.168.0.215:8080/JXWebService.asmx\";
            //string strJson = webTest.GetProductionReturnInfoForSAP(\"TEST150701\");
            //strJson = webTest.PostReceiveGoodsInfo(strJson, string.Empty);
            //MessageBox.Show(\"ad\");

            //本能生产退料过账
            //localWebTest.Url = \"http://localhost:4765/JXWebService.asmx\";
            //string strErrMsg = \"\";
            //localhost.UserInfo userInfo = new localhost.UserInfo();
            //userInfo.UserNo = \"A001\";

            //localWebTest.UserLogin(ref userInfo, ref strErrMsg);

            //string strUserJson = JXBLL.JSONUtil.JSONHelper.ObjectToJson<localhost.UserInfo>(userInfo);
            //string strJson = localWebTest.GetProductionReturnInfoForSAP(\"TEST081601\");
            //strJson = localWebTest.PostReceiveGoodsInfo(strJson, strUserJson);
            //MessageBox.Show(\"ad\");

            //web生产订单
            //webTest.Url = \"http://192.168.0.215:8080/JXWebService.asmx\";
            //string strJson = webTest.GetProductionInfoForSAP(\"000100157483\");
            //strJson = webTest.PostReceiveGoodsInfo(strJson, string.Empty);
            //MessageBox.Show(\"ad\");

            //webTest.Url = \"http://192.168.0.215:8080/JXWebService.asmx\";

            string strErrMsg = "";
            localhost.UserInfo userInfo = new localhost.UserInfo();
            userInfo.UserNo = "A001";
            userInfo.Password = "0199D61DE8A9F039";
            userInfo.LoginIP = "PC";
            localWebTest.UserLogin(ref userInfo, ref strErrMsg);

            string strUserJson = BLL.JSONUtil.JSONHelper.ObjectToJson<localhost.UserInfo>(userInfo);

            //string strJson = localWebTest.GetProductionInfoForSAP("400006173");
            //localhost.DeliveryReceive_Model deliveryModel = JXBLL.JSONUtil.JSONHelper.JsonToObject<localhost.DeliveryReceive_Model>(strJson);

            //deliveryModel.lstDeliveryDetail.ToList().ForEach(t => t.ReceiveQty = 10);
            //strJson = JXBLL.JSONUtil.JSONHelper.ObjectToJson<localhost.DeliveryReceive_Model>(deliveryModel);
            //strJson = localWebTest.PostReceiveGoodsInfo(strJson, strUserJson);

            MessageBox.Show("ad");

        }

        private void button14_Click(object sender, EventArgs e)
        {
            //JXBLL.ReceiveGoods.ReceiveGoods_Func RF = new JXBLL.ReceiveGoods.ReceiveGoods_Func();
            //RF.GetQalitiedForIQCInfo(\"5003011975\");
            //MessageBox.Show(\"ad\");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //bool bSucc = false;
            //string strErrMsg = string.Empty;
            //localhost.DeliveryReceive_Model DM = new localhost.DeliveryReceive_Model();
            //DM.ID = 137;
            //List<JXBLL.DeliveryReceive.DeliveryReceiveDetail_Model> lstDetails = new List<JXBLL.DeliveryReceive.DeliveryReceiveDetail_Model>();
            //localhost.DeliveryReceiveDetail_Model[] DDMA=null;
            ////bSucc=localWebTest.GetQualityDetailInfo(DM, ref DDMA, null, ref strErrMsg);
            ////DDM = new List<localhost.DeliveryReceiveDetail_Model>(DDMA);
            //JXBLL.DeliveryReceive.DeliveryReceiveDetail_Model DMD = new JXBLL.DeliveryReceive.DeliveryReceiveDetail_Model();
            //DMD.ID = 0;
            //DMD.RowNo = \"10\";
            //DMD.MaterialNo = \"asd\";
            //DMD.MaterialDesc = \"sad\";
            //DMD.PrdVersion = \"sad\";
            //DMD.Unit = \"ad\";
            //DMD.OKSelect = true;
            //DMD.VoucherNo = \"222\";
            //DMD.QualityType = \"asdad\";
            //lstDetails.Add(DMD);

            //JXBLL.ReceiveGoods.ReceiveGoods_Func RF = new JXBLL.ReceiveGoods.ReceiveGoods_Func();
            //bSucc = RF.SaveQualityDetailInfo(lstDetails, null, ref strErrMsg);
            //MessageBox.Show(\"ad\");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            localhost.DeliveryReceive_Model deliveryModel = new localhost.DeliveryReceive_Model();
            //bool bSucc= localWebTest.GetPOInfoForSAP("4700291163", ref deliveryModel, ref strErrMsg);
            MessageBox.Show("ad");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //string strErrMsg = "";
            //localhost.UserInfo userInfo = new localhost.UserInfo();
            //userInfo.UserNo = "admin";
            //userInfo.Password = "0199D61DE8A9F039";
            //userInfo.LoginIP = "PC";
            //localWebTest.UserLogin(ref userInfo, ref strErrMsg);
            ////string strUserJson = \"{\\"UserNo\\":\\"A001\\",\\"UserName\\":\\"袁德虎\\",\\"Password\\":\\"123456\\",\\"UserType\\":1,\\"PinYin\\":\\"A001\\",\\"Duty\\":\\"\\",\\"Tel\\":\\"\\",\\"Mobile\\":\\"\\",\\"Email\\":\\"\\",\\"Sex\\":\\"男\\",\\"IsPick\\":1,\\"IsReceive\\":1,\\"IsQuality\\":1,\\"UserStatus\\":1,\\"Address\\":\\"1\\",\\"GroupCode\\":\\"\\",\\"WarehouseCode\\":\\"1,2\\",\\"Description\\":\\"\\",\\"LoginIP\\":\\"\\",\\"LoginTime\\":null,\\"Status\\":\\"S\\",\\"Type\\":null,\\"Dghead\\":{\\"SupName\\":null,\\"SupCode\\":\\"600212\\"},\\"Message\\":null,\\"RePassword\\":\\"123456\\",\\"BIsAdmin\\":false,\\"GroupName\\":null,\\"WarehouseNo\\":null,\\"WarehouseName\\":null,\\"StrUserType\\":null,\\"BIsPick\\":false,\\"BIsReceive\\":false,\\"BIsQuality\\":false,\\"lstUserGroup\\":null,\\"lstMenu\\":null,\\"lstWarehouse\\":[{\\"WarehouseNo\\":\\"A1\\",\\"WarehouseName\\":\\"北区B栋1楼天馈原材料仓\\",\\"WarehouseType\\":1,\\"ContactUser\\":\\"\\",\\"ContactPhone\\":\\"\\",\\"HouseCount\\":14,\\"HouseUsingCount\\":0,\\"LocationDesc\\":\\"\\",\\"WarehouseStatus\\":1,\\"Address\\":\\"\\",\\"Status\\":null,\\"Type\\":null,\\"Dghead\\":{\\"SupName\\":null,\\"SupCode\\":null},\\"Message\\":null,\\"HouseNo\\":null,\\"HouseName\\":null,\\"BIsLock\\":false,\\"StrWarehouseStatus\\":null,\\"BIsChecked\\":false,\\"ID\\":1,\\"No\\":null,\\"Name\\":null,\\"IsDel\\":1,\\"Creater\\":\\"admin\\",\\"CreateTime\\":\\"\\",\\"Modifyer\\":\\"\\",\\"ModifyTime\\":null,\\"StrCreateTime\\":null,\\"StrModifyTime\\":null},{\\"WarehouseNo\\":\\"B1\\",\\"WarehouseName\\":\\"北区B栋1楼公共材料仓\\",\\"WarehouseType\\":1,\\"ContactUser\\":\\"\\",\\"ContactPhone\\":\\"\\",\\"HouseCount\\":22,\\"HouseUsingCount\\":0,\\"LocationDesc\\":\\"\\",\\"WarehouseStatus\\":1,\\"Address\\":\\"\\",\\"Status\\":null,\\"Type\\":null,\\"Dghead\\":{\\"SupName\\":null,\\"SupCode\\":null},\\"Message\\":null,\\"HouseNo\\":null,\\"HouseName\\":null,\\"BIsLock\\":false,\\"StrWarehouseStatus\\":null,\\"BIsChecked\\":false,\\"ID\\":2,\\"No\\":null,\\"Name\\":null,\\"IsDel\\":1,\\"Creater\\":\\"admin\\",\\"CreateTime\\":\\"\\",\\"Modifyer\\":\\"\\",\\"ModifyTime\\":null,\\"StrCreateTime\\":null,\\"StrModifyTime\\":null}],\\"ID\\":2,\\"No\\":null,\\"Name\\":null,\\"IsDel\\":1,\\"Creater\\":\\"admin\\",\\"CreateTime\\":\\"\\",\\"Modifyer\\":\\"\\",\\"ModifyTime\\":null,\\"StrCreateTime\\":null,\\"StrModifyTime\\":null}\";//JXBLL.JSONUtil.JSONHelper.ObjectToJson<localhost.UserInfo>(userInfo);
            ////string strUserJson = \"{\\"Address\\":\\"1\\",\\"lstWarehouse\\":[{\\"Address\\":\\"\\",\\"WarehouseNo\\":\\"A1\\",\\"WarehouseName\\":\\"北区B栋1楼天馈原材料仓\\",\\"ContactPhone\\":\\"\\",\\"ContactUser\\":\\"\\",\\"Creater\\":\\"admin\\",\\"Dghead\\":{},\\"LocationDesc\\":\\"\\",\\"Modifyer\\":\\"\\",\\"IsDel\\":1,\\"ID\\":1,\\"HouseUsingCount\\":0,\\"HouseCount\\":14,\\"BIsLock\\":false,\\"BIsChecked\\":false,\\"WarehouseStatus\\":1,\\"WarehouseType\\":1},{\\"Address\\":\\"\\",\\"WarehouseNo\\":\\"B1\\",\\"WarehouseName\\":\\"北区B栋1楼公共材料仓\\",\\"ContactPhone\\":\\"\\",\\"ContactUser\\":\\"\\",\\"Creater\\":\\"admin\\",\\"Dghead\\":{},\\"LocationDesc\\":\\"\\",\\"Modifyer\\":\\"\\",\\"IsDel\\":1,\\"ID\\":2,\\"HouseUsingCount\\":0,\\"HouseCount\\":22,\\"BIsLock\\":false,\\"BIsChecked\\":false,\\"WarehouseStatus\\":1,\\"WarehouseType\\":1}],\\"WarehouseCode\\":\\"1,2\\",\\"UserNo\\":\\"A001\\",\\"UserName\\":\\"袁德虎\\",\\"Creater\\":\\"admin\\",\\"Description\\":\\"\\",\\"Dghead\\":{\\"SupCode\\":\\"600212\\"},\\"Duty\\":\\"\\",\\"Email\\":\\"\\",\\"GroupCode\\":\\"\\",\\"Tel\\":\\"\\",\\"Status\\":\\"S\\",\\"LoginIP\\":\\"\\",\\"Mobile\\":\\"\\",\\"Modifyer\\":\\"\\",\\"Password\\":\\"29F658DE7880317A\\",\\"PinYin\\":\\"A001\\",\\"RePassword\\":\\"29F658DE7880317A\\",\\"Sex\\":\\"男\\",\\"ShowCalender\\":0,\\"IsReceive\\":1,\\"IsQuality\\":2,\\"IsPick\\":1,\\"IsDel\\":1,\\"IsAdmin\\":false,\\"ID\\":2,\\"BIsReceive\\":false,\\"BIsQuality\\":true,\\"UserStatus\\":1,\\"UserType\\":1,\\"BIsPick\\":false,\\"bIsPick\\":false,\\"bIsQuanlity\\":false,\\"BIsAdmin\\":false}\\";
            //string strUserJson = JXBLL.JSONUtil.JSONHelper.ObjectToJson<localhost.UserInfo>(userInfo);
            //string strJson = localWebTest.GetTaskInfo(strUserJson, "2015090300004");
            //MessageBox.Show("ad");

            string strErrMsg = "";
            localhost.UserInfo userInfo = new localhost.UserInfo();
            userInfo.UserNo = "admin";
            userInfo.ID = 1;
            userInfo.Password = "admin";
            userInfo.LoginIP = "PC";
            localWebTest.UserLogin(ref userInfo, ref strErrMsg);
            //string strUserJson = \"{\\"UserNo\\":\\"A001\\",\\"UserName\\":\\"袁德虎\\",\\"Password\\":\\"123456\\",\\"UserType\\":1,\\"PinYin\\":\\"A001\\",\\"Duty\\":\\"\\",\\"Tel\\":\\"\\",\\"Mobile\\":\\"\\",\\"Email\\":\\"\\",\\"Sex\\":\\"男\\",\\"IsPick\\":1,\\"IsReceive\\":1,\\"IsQuality\\":1,\\"UserStatus\\":1,\\"Address\\":\\"1\\",\\"GroupCode\\":\\"\\",\\"WarehouseCode\\":\\"1,2\\",\\"Description\\":\\"\\",\\"LoginIP\\":\\"\\",\\"LoginTime\\":null,\\"Status\\":\\"S\\",\\"Type\\":null,\\"Dghead\\":{\\"SupName\\":null,\\"SupCode\\":\\"600212\\"},\\"Message\\":null,\\"RePassword\\":\\"123456\\",\\"BIsAdmin\\":false,\\"GroupName\\":null,\\"WarehouseNo\\":null,\\"WarehouseName\\":null,\\"StrUserType\\":null,\\"BIsPick\\":false,\\"BIsReceive\\":false,\\"BIsQuality\\":false,\\"lstUserGroup\\":null,\\"lstMenu\\":null,\\"lstWarehouse\\":[{\\"WarehouseNo\\":\\"A1\\",\\"WarehouseName\\":\\"北区B栋1楼天馈原材料仓\\",\\"WarehouseType\\":1,\\"ContactUser\\":\\"\\",\\"ContactPhone\\":\\"\\",\\"HouseCount\\":14,\\"HouseUsingCount\\":0,\\"LocationDesc\\":\\"\\",\\"WarehouseStatus\\":1,\\"Address\\":\\"\\",\\"Status\\":null,\\"Type\\":null,\\"Dghead\\":{\\"SupName\\":null,\\"SupCode\\":null},\\"Message\\":null,\\"HouseNo\\":null,\\"HouseName\\":null,\\"BIsLock\\":false,\\"StrWarehouseStatus\\":null,\\"BIsChecked\\":false,\\"ID\\":1,\\"No\\":null,\\"Name\\":null,\\"IsDel\\":1,\\"Creater\\":\\"admin\\",\\"CreateTime\\":\\"\\",\\"Modifyer\\":\\"\\",\\"ModifyTime\\":null,\\"StrCreateTime\\":null,\\"StrModifyTime\\":null},{\\"WarehouseNo\\":\\"B1\\",\\"WarehouseName\\":\\"北区B栋1楼公共材料仓\\",\\"WarehouseType\\":1,\\"ContactUser\\":\\"\\",\\"ContactPhone\\":\\"\\",\\"HouseCount\\":22,\\"HouseUsingCount\\":0,\\"LocationDesc\\":\\"\\",\\"WarehouseStatus\\":1,\\"Address\\":\\"\\",\\"Status\\":null,\\"Type\\":null,\\"Dghead\\":{\\"SupName\\":null,\\"SupCode\\":null},\\"Message\\":null,\\"HouseNo\\":null,\\"HouseName\\":null,\\"BIsLock\\":false,\\"StrWarehouseStatus\\":null,\\"BIsChecked\\":false,\\"ID\\":2,\\"No\\":null,\\"Name\\":null,\\"IsDel\\":1,\\"Creater\\":\\"admin\\",\\"CreateTime\\":\\"\\",\\"Modifyer\\":\\"\\",\\"ModifyTime\\":null,\\"StrCreateTime\\":null,\\"StrModifyTime\\":null}],\\"ID\\":2,\\"No\\":null,\\"Name\\":null,\\"IsDel\\":1,\\"Creater\\":\\"admin\\",\\"CreateTime\\":\\"\\",\\"Modifyer\\":\\"\\",\\"ModifyTime\\":null,\\"StrCreateTime\\":null,\\"StrModifyTime\\":null}\";//JXBLL.JSONUtil.JSONHelper.ObjectToJson<localhost.UserInfo>(userInfo);
            //string strUserJson = \"{\\"Address\\":\\"1\\",\\"lstWarehouse\\":[{\\"Address\\":\\"\\",\\"WarehouseNo\\":\\"A1\\",\\"WarehouseName\\":\\"北区B栋1楼天馈原材料仓\\",\\"ContactPhone\\":\\"\\",\\"ContactUser\\":\\"\\",\\"Creater\\":\\"admin\\",\\"Dghead\\":{},\\"LocationDesc\\":\\"\\",\\"Modifyer\\":\\"\\",\\"IsDel\\":1,\\"ID\\":1,\\"HouseUsingCount\\":0,\\"HouseCount\\":14,\\"BIsLock\\":false,\\"BIsChecked\\":false,\\"WarehouseStatus\\":1,\\"WarehouseType\\":1},{\\"Address\\":\\"\\",\\"WarehouseNo\\":\\"B1\\",\\"WarehouseName\\":\\"北区B栋1楼公共材料仓\\",\\"ContactPhone\\":\\"\\",\\"ContactUser\\":\\"\\",\\"Creater\\":\\"admin\\",\\"Dghead\\":{},\\"LocationDesc\\":\\"\\",\\"Modifyer\\":\\"\\",\\"IsDel\\":1,\\"ID\\":2,\\"HouseUsingCount\\":0,\\"HouseCount\\":22,\\"BIsLock\\":false,\\"BIsChecked\\":false,\\"WarehouseStatus\\":1,\\"WarehouseType\\":1}],\\"WarehouseCode\\":\\"1,2\\",\\"UserNo\\":\\"A001\\",\\"UserName\\":\\"袁德虎\\",\\"Creater\\":\\"admin\\",\\"Description\\":\\"\\",\\"Dghead\\":{\\"SupCode\\":\\"600212\\"},\\"Duty\\":\\"\\",\\"Email\\":\\"\\",\\"GroupCode\\":\\"\\",\\"Tel\\":\\"\\",\\"Status\\":\\"S\\",\\"LoginIP\\":\\"\\",\\"Mobile\\":\\"\\",\\"Modifyer\\":\\"\\",\\"Password\\":\\"29F658DE7880317A\\",\\"PinYin\\":\\"A001\\",\\"RePassword\\":\\"29F658DE7880317A\\",\\"Sex\\":\\"男\\",\\"ShowCalender\\":0,\\"IsReceive\\":1,\\"IsQuality\\":2,\\"IsPick\\":1,\\"IsDel\\":1,\\"IsAdmin\\":false,\\"ID\\":2,\\"BIsReceive\\":false,\\"BIsQuality\\":true,\\"UserStatus\\":1,\\"UserType\\":1,\\"BIsPick\\":false,\\"bIsPick\\":false,\\"bIsQuanlity\\":false,\\"BIsAdmin\\":false}\\";
            string strUserJson = BLL.JSONUtil.JSONHelper.ObjectToJson<localhost.UserInfo>(userInfo);
            string strJson = localWebTest.GetProductTransTaskInfo(strUserJson, "15112420010");
            MessageBox.Show("ad");



        }

        private void button18_Click(object sender, EventArgs e)
        {
            string strJson = localWebTest.GetQulitiedTaskDetailsInfo("201508280186");
            MessageBox.Show("ad");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string strJson = localWebTest.CheckBarCodeIsInStock("201507261154");
            MessageBox.Show("ad");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            localhost.UserInfo userInfo = new localhost.UserInfo();
            userInfo.UserNo = "A001";

            localWebTest.UserLogin(ref userInfo, ref strErrMsg);
            string strUserJson = BLL.JSONUtil.JSONHelper.ObjectToJson<localhost.UserInfo>(userInfo);

            string strDetailJson = localWebTest.GetQulitiedTaskDetailsInfo("201507270251");
            BLL.Task.TaskHead_Model taskHead = BLL.JSONUtil.JSONHelper.JsonToObject<BLL.Task.TaskHead_Model>(strDetailJson);
            strDetailJson = BLL.JSONUtil.JSONHelper.ObjectToJson<BLL.Task.TaskDetails_Model>(taskHead.lstTaskInfo[0].lstTaskDetails[0]);
            string strJson = localWebTest.LockTaskOperUser(strDetailJson, strUserJson);
            MessageBox.Show("ad");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string strUserJson = localWebTest.CheckArea("C1A060401", null);
            MessageBox.Show("ad");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            localhost.UserInfo userInfo = new localhost.UserInfo();
            userInfo.UserNo = "admin";

            localWebTest.UserLogin(ref userInfo, ref strErrMsg);
            string strUserJson = BLL.JSONUtil.JSONHelper.ObjectToJson<localhost.UserInfo>(userInfo);

            string strDetailJson = localWebTest.GetProductTransTaskInfo(strUserJson, "16042651015");

            BLL.Task.TaskHead_Model taskHead = BLL.JSONUtil.JSONHelper.JsonToObject<BLL.Task.TaskHead_Model>(strDetailJson);
            taskHead.lstTaskInfo[0].lstTaskDetails[0].ScanQty = 1;
            taskHead.lstTaskInfo[0].lstTaskDetails[0].lstSerial = new List<BLL.Task.TaskSerial_Model>();
            BLL.Task.TaskSerial_Model BM = new BLL.Task.TaskSerial_Model();
            BM.SerialNo = "16042651015";
            taskHead.lstTaskInfo[0].lstTaskDetails[0].lstSerial.Add(BM);

            strDetailJson = BLL.JSONUtil.JSONHelper.ObjectToJson<BLL.Task.TaskHead_Model>(taskHead);

            //string strDetailJson = \"\";
            //strDetailJson = \"{\\"Status\\":\\"S\\",\\"lstTaskInfo\\":[{\\"lstTaskDetails\\":[{\\"VoucherNo\\":\\"4700291163\\",\\"MaterialDesc\\":\\"DB15,直针焊板带螺母(三排)\\",\\"MaterialNo\\":\\"102001 - 000055 - 00\\",\\"ToAreaNo\\":\\"C1A060401\\",\\"RowNo\\":\\"00020\\",\\"ReviewQty\\":0,\\"RemainQty\\":20,\\"ScanPackCount\\":0,\\"ScanQty\\":0,\\"ShelvePackCount\\":0,\\"ShelveQty\\":0,\\"Status\\":0,\\"RemainPackCount\\":2,\\"QuanlityQty\\":20,\\"PackCount\\":2,\\"TaskQty\\":20,\\"Task_ID\\":0,\\"OutStockQty\\":0,\\"UnQuanlityQty\\":0,\\"IsROHS\\":0,\\"IsQualityComp\\":0,\\"ID\\":379,\\"DeliveryQty\\":0},{\\"lstSerial\\":[{\\"SerialNo\\":\\"201507260594\\"}],\\"VoucherNo\\":\\"4700291163\\",\\"MaterialDesc\\":\\"DB9,90°弯孔插座(478168)\\",\\"MaterialNo\\":\\"102001 - 000001 - 00\\",\\"ToAreaNo\\":\\"\\",\\"RowNo\\":\\"00010\\",\\"ReviewQty\\":0,\\"RemainQty\\":80,\\"ScanPackCount\\":1,\\"ScanQty\\":10,\\"ShelvePackCount\\":0,\\"ShelveQty\\":0,\\"Status\\":0,\\"RemainPackCount\\":10,\\"QuanlityQty\\":80,\\"PackCount\\":10,\\"TaskQty\\":100,\\"Task_ID\\":0,\\"OutStockQty\\":0,\\"UnQuanlityQty\\":0,\\"IsROHS\\":0,\\"IsQualityComp\\":0,\\"ID\\":380,\\"DeliveryQty\\":0},{\\"VoucherNo\\":\\"4700291163\\",\\"MaterialDesc\\":\\"DB15,直针焊板带螺母(三排)\\",\\"MaterialNo\\":\\"102001 - 000055 - 00\\",\\"ToAreaNo\\":\\"C1A060401\\",\\"RowNo\\":\\"00030\\",\\"ReviewQty\\":0,\\"RemainQty\\":0,\\"ScanPackCount\\":0,\\"ScanQty\\":0,\\"ShelvePackCount\\":0,\\"ShelveQty\\":0,\\"Status\\":0,\\"RemainPackCount\\":0,\\"QuanlityQty\\":0,\\"PackCount\\":0,\\"TaskQty\\":0,\\"Task_ID\\":0,\\"OutStockQty\\":0,\\"UnQuanlityQty\\":0,\\"IsROHS\\":0,\\"IsQualityComp\\":0,\\"ID\\":381,\\"DeliveryQty\\":0}],\\"TaskNo\\":\\"201507290259\\",\\"Receive_ID\\":0,\\"IsShelvePost\\":2,\\"IsReceivePost\\":0,\\"TaskStatus\\":2,\\"TaskType\\":0,\\"IsQuality\\":2,\\"VoucherType\\":10,\\"IsPost\\":0,\\"ID\\":209}]}\";
            strDetailJson = localWebTest.InStock(strDetailJson, strUserJson, "13-C4-0-01");
            MessageBox.Show(strDetailJson);
            MessageBox.Show("ad");
        }


        private void button24_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            localhost.UserInfo userInfo = new localhost.UserInfo();
            userInfo.UserNo = "admin";

            localWebTest.UserLogin(ref userInfo, ref strErrMsg);

            string strUserJson = BLL.JSONUtil.JSONHelper.ObjectToJson<localhost.UserInfo>(userInfo);

            //string strJson = localWebTest.PostTaskInfoToSAP("385", "2101", strUserJson);

            //strJson = localWebTest.PostReceiveGoodsInfo(strJson, strUserJson);

            MessageBox.Show("ad");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            bool bSucc = false;
            localhost.UserInfo userInfo = new localhost.UserInfo();
            userInfo.UserNo = "A001";

            localWebTest.UserLogin(ref userInfo, ref strErrMsg);

            string strUserJson = BLL.JSONUtil.JSONHelper.ObjectToJson<localhost.UserInfo>(userInfo);

            string strJson = localWebTest.GetDeliveryInfoForAndroid("15080031554", strUserJson);//15050030527 

            localhost.DeliveryReceive_Model deliveryModel = BLL.JSONUtil.JSONHelper.JsonToObject<localhost.DeliveryReceive_Model>(strJson);
            deliveryModel.lstDeliveryDetail.ToList().ForEach(t => t.UnQualityQty = 2);
            strJson = BLL.JSONUtil.JSONHelper.ObjectToJson<localhost.DeliveryReceive_Model>(deliveryModel);
            //bSucc = localWebTest.PostReceiveUnQualityReturnToSAP(ref deliveryModel, userInfo, ref strErrMsg);

            MessageBox.Show("ad");
        }

        private void button26_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            localhost.UserInfo userInfo = new localhost.UserInfo();
            userInfo.UserNo = "admin";
            userInfo.Password = "0199D61DE8A9F039";

            localWebTest.UserLogin(ref userInfo, ref strErrMsg);
            string strUserJson = BLL.JSONUtil.JSONHelper.ObjectToJson<localhost.UserInfo>(userInfo);

            string strInStockJson = localWebTest.GetQulitiedTaskDetailsInfo("201509180473");
            strInStockJson = localWebTest.UnLockTaskOperUser(strInStockJson, strUserJson);

            MessageBox.Show("ad");
        }


        private void button28_Click(object sender, EventArgs e)
        {
            //localhost.BarcodeModel bar = new localhost.BarcodeModel();
            //localhost.Tray_Model tray = new localhost.Tray_Model();
            //bar.TrayID = 1;
            //localWebTest.GetTrayInfoByTrayID(bar, ref tray);
            //MessageBox.Show("ad");

            localhost.Barcode_Model bar = new localhost.Barcode_Model();
            localhost.Tray_Model tray = new localhost.Tray_Model();
            tray.TrayID = 24115;
            localhost.TrayDetails_Model model = new localhost.TrayDetails_Model();
            model.listBarcode = new string[] { "1605202W0426", "1605202W0427", "1605202W0428",
            "1605202W0429", "1605202W0430", "1605202W0431"};
            tray.listDetails = new localhost.TrayDetails_Model[] { model };

            bar.tray_Model = tray;
            localWebTest.UpdateTrayInfoTest(bar);

            MessageBox.Show("ad");
        }


        private void button30_Click(object sender, EventArgs e)
        {
            string vouchcode, vouchtype, cwhcode, strTaskNo = "", strErrMsg = "";
            vouchcode = "001321678";
            vouchtype = "-10";
            cwhcode = "13";
            localhost.UserInfo userModel = new localhost.UserInfo();
            userModel.UserNo = "demo1";
            userModel.ID = 604;
            localWebTest.CreateShelveTaskTest(vouchcode, vouchtype, cwhcode, userModel, ref strTaskNo, ref strErrMsg);
            MessageBox.Show("ad");
        }

        private void button31_Click(object sender, EventArgs e)
        {
            string json = localWebTest.GetCheckBarcodeForAndroid(7, "16031620001", false);
            BLL.PrintBarcode.Barcode_Model bar = BLL.JSONUtil.JSONHelper.JsonToObject<BLL.PrintBarcode.Barcode_Model>(json);
            MessageBox.Show("ad");
        }


    }
}
