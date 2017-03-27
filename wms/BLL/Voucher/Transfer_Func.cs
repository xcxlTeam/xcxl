using BLL.Basic.User;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BLL.Common;

namespace BLL.Voucher
{
    public class Transfer_Func
    {
        private Transfer GetModelFromDataReader(SqlDataReader dr)
        {
            Transfer model = new Transfer();
            model.BatNbr = dr["BatNbr"].ToCHString();
            model.SiteID = dr["SiteID"].ToDBString();
            model.ToSiteID = dr["ToSiteID"].ToDBString();
            model.RefNbr = dr["RefNbr"].ToDBString();
            model.InvtID = dr["InvtID"].ToDBString();
            model.WhseLoc = dr["WhseLoc"].ToDBString();
            model.ToWhseloc = dr["ToWhseloc"].ToDBString();
            model.LotSerNbr = dr["LotSerNbr"].ToDBString();
            model.Qty = dr["VendID"].ToDecimal();
            model.TranDate = dr["TranDate"].ToDBString();

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

        public string GetTransferTo01(string strMaterialNo,string strBatchNo,string startDate,string endDate, string strUserJson)
        {
            ReadAPI_DB DB = new ReadAPI_DB();
            Transfer model = null;
            bool bSucc = false;
            string strError = string.Empty;
            try
            {
                UserInfo user = JSONUtil.JSONHelper.JsonToObject<UserInfo>(strUserJson);
                using (SqlDataReader dr = DB.ReadData(ReadApiType.TRANSFER_TO01, strMaterialNo, strBatchNo,startDate,endDate))
                {
                    while (dr.Read())
                    {
                        if (model == null)
                        {
                            model = (GetModelFromDataReader(dr));
                        }
                    }
                    if (model == null)
                    {
                        throw new Exception("未找到数据！");
                    }
                    bSucc = true;
                    return GetReturnJson(bSucc, model, strError);
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                bSucc = false;
                model = new Transfer();
                return GetReturnJson(bSucc, model, strError);
            }
            finally
            {
            }
        }

        public string PostTransferInfo(string strReceiveJson, string strUserJson)
        {
            bool bSucc = false;
            string strErrMsg = string.Empty;
            string strPostAndTask = string.Empty;
            Transfer DeliveryInfo = new Transfer();
            List<Transfer> lstData;
            Transfer_DB DRD = new Transfer_DB();
            UserInfo userModel = new UserInfo();

            try
            {
                if (string.IsNullOrEmpty(strReceiveJson))
                {
                    return GetReturnJson(false, DeliveryInfo, "没有过账数据！");
                }

                lstData = JSONUtil.JSONHelper.JsonToObject<List<Transfer>>(strReceiveJson);

                if (lstData == null || lstData.Count <= 0)
                {
                    return GetReturnJson(false, DeliveryInfo, "解析客户端数据出错！");
                }

                if (lstData.Where(t => t.Qty == 0).Count() > 0)
                {
                    return GetReturnJson(false, DeliveryInfo, "转库数量不能为零，请确认！");
                }

                userModel = JSONUtil.JSONHelper.JsonToObject<UserInfo>(strUserJson);

                if (userModel == null || string.IsNullOrEmpty(userModel.UserNo))
                {
                    return GetReturnJson(false, DeliveryInfo, "没有获取用户信息！");
                }
                bSucc = DRD.PostTransfer(ref lstData, userModel, ref strErrMsg);
                if (bSucc == false)
                {
                    return GetReturnJson(false, DeliveryInfo, strErrMsg);
                }

                return GetReturnJson(bSucc, DeliveryInfo, strErrMsg);

            }
            catch (Exception ex)
            {
                TOOL.WriteLogMethod.WriteLog("方法：PostTransferInfo---操作人：" + userModel.UserName + strReceiveJson);
                return GetReturnJson(false, DeliveryInfo, "Web异常：" + ex.Message + ex.StackTrace);
            }
        }


        private string GetReturnJson(bool bSucc, Transfer DeliveryInfo, string strErrMsg)
        {
            DeliveryInfo.Status = bSucc == true ? "S" : "E";
            DeliveryInfo.Message = strErrMsg;
            return JSONUtil.JSONHelper.ObjectToJson<Transfer>(DeliveryInfo);
        }

    }
}
