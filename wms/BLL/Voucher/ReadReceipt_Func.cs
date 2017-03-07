using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BLL.Common;
using System.Data;
using BLL.Basic.User;

namespace BLL.Voucher
{
    public class ReadReceipt_Func
    {
        private ReceiptDetails GetModelFromDataReader(SqlDataReader dr)
        {
            ReceiptDetails model = new ReceiptDetails();
            model.Address = dr["Address"].ToCHString();
            model.LineRef = dr["LineRef"].ToDBString();
            model.Name = dr["Name"].ToCHString();
            model.Phone = dr["Phone"].ToDBString();
            model.PoNbr = dr["PoNbr"].ToDBString();
            model.PromDate = dr["PromDate"].ToDateTime();
            model.QtyOrd = dr["QtyOrd"].ToDecimal();
            model.QtyRcvd = dr["QtyRcvd"].ToDecimal();
            model.VendID = dr["VendID"].ToInt32();
            model.PurchUnit = dr["PurchUnit"].ToDBString();

            model.Allergic = dr["Allergic"].ToCHString();
            model.CHDesc = dr["CHDesc"].ToCHString();
            model.Descr = dr["Descr"].ToDBString();
            model.InvtID = dr["InvtID"].ToDBString();
            model.InvtType = dr["InvtType"].ToDBString();
            model.NetWt = dr["NetWt"].ToDecimal();
            model.SceneMaterial = dr["SceneMaterial"].ToDBString();
            model.ShelfLife = dr["ShelfLife"].ToInt32();
            model.StdGrossWt = dr["StdGrossWt"].ToDecimal();
            model.StdTareWt = dr["StdTareWt"].ToDecimal();
            model.StkUnit = dr["StkUnit"].ToDBString();

            return model;
        }

        private ReceiptHead GetHeadModelFromDataReader(SqlDataReader dr)
        {
            ReceiptHead model = new ReceiptHead();
            model.Address = dr["Address"].ToCHString();
            model.Name = dr["Name"].ToCHString();
            model.Phone = dr["Phone"].ToDBString();
            model.PoNbr = dr["PoNbr"].ToDBString();
            model.VendID = dr["VendID"].ToInt32();
            model.PurchUnit = dr["PurchUnit"].ToDBString();

            return model;
        }


        public string GetReceiptByPoNbr(string strPoNo,string strUserJson)
        {
            ReadAPI_DB DB = new ReadAPI_DB();
            ReceiptHead model = null;
            bool bSucc = false;
            string strError = string.Empty;
            try
            {
                UserInfo user=JSONUtil.JSONHelper.JsonToObject<UserInfo>(strUserJson);
                using (SqlDataReader dr = DB.ReadData(ReadApiType.RECEIPT, strPoNo))
                {
                    while (dr.Read())
                    {
                        if(model==null)
                        { 
                            model = (GetHeadModelFromDataReader(dr));
                            model.lstDetails = new List<ReceiptDetails>();
                        }
                        model.lstDetails.Add(GetModelFromDataReader(dr));
                    }
                    bSucc = true;
                    return GetReturnJson(bSucc, model, strError);
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                model=new ReceiptHead();
                return GetReturnJson(bSucc, model, strError);
            }
            finally
            {
            }
        }

        public string PostReciptInfo(string strReceiveJson, string strUserJson)
        {
            bool bSucc = false;
            string strErrMsg = string.Empty;
            string strPostAndTask = string.Empty;
            ReceiptHead DeliveryInfo = new ReceiptHead();
            Recipt_DB DRD = new Recipt_DB();
            UserInfo userModel = new UserInfo();

            try
            {
                if (string.IsNullOrEmpty(strReceiveJson))
                {
                    return GetReturnJson(false, DeliveryInfo, "没有过账数据！");
                }

                DeliveryInfo = JSONUtil.JSONHelper.JsonToObject<ReceiptHead>(strReceiveJson);

                if (DeliveryInfo == null || DeliveryInfo.lstDetails == null || DeliveryInfo.lstDetails.Count <= 0)
                {
                    return GetReturnJson(false, DeliveryInfo, "解析客户端数据出错！");
                }

                if (DeliveryInfo.lstDetails.Where(t => t.iQty > 0).Count() == 0)
                {
                    return GetReturnJson(false, DeliveryInfo, "收货数量都为零，请确认！");
                }

                userModel = JSONUtil.JSONHelper.JsonToObject<UserInfo>(strUserJson);

                if (userModel == null || string.IsNullOrEmpty(userModel.UserNo))
                {
                    return GetReturnJson(false, DeliveryInfo, "没有获取用户信息！");
                }
                bSucc = DRD.PostReceipt(ref DeliveryInfo,userModel, ref strErrMsg);
                if (bSucc == false)
                {
                    return GetReturnJson(false, DeliveryInfo, strErrMsg);
                }

                return GetReturnJson(bSucc, DeliveryInfo, strErrMsg);

            }
            catch (Exception ex)
            {
                TOOL.WriteLogMethod.WriteLog("方法：PostReciptInfo---操作人：" + userModel.UserName + strReceiveJson);
                return GetReturnJson(false, DeliveryInfo, "Web异常：" + ex.Message + ex.StackTrace);
            }
        }


        private string GetReturnJson(bool bSucc, ReceiptHead DeliveryInfo, string strErrMsg)
        {
            DeliveryInfo.Status = bSucc == true ? "S" : "E";
            DeliveryInfo.Message = strErrMsg;
            return JSONUtil.JSONHelper.ObjectToJson<ReceiptHead>(DeliveryInfo);
        }


    }
}
