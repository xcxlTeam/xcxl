using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.DeliveryReceive;
using BLL.Basic.User;
using BLL.ProductionReturn;
using BLL.Production;
using BLL.PrintBarcode;


namespace BLL.Task
{
    public class Task_Func
    {
        public string GetTaskInfo(string strUserJson, string strBarcode)
        {
            TaskHead_Model taskHeadModel = new TaskHead_Model();
            try
            {
                string strBarcodeJson = string.Empty;
                Barcode_Model barcodeMdl = new Barcode_Model();

                UserInfo userModel = JSONUtil.JSONHelper.JsonToObject<UserInfo>(strUserJson);

                if (userModel == null || string.IsNullOrEmpty(userModel.UserNo))
                {
                    return GetFailJson(ref taskHeadModel, "没有用户信息！");
                }

                if (string.IsNullOrEmpty(strBarcode))
                {
                    //return GetFailJson(ref taskHeadModel, "请扫描或输入条码！");
                    barcodeMdl = new Barcode_Model();
                    barcodeMdl.Status = "S";
                }
                else
                {
                    ReceiveGoods.ReceiveGoods_Func RGF = new ReceiveGoods.ReceiveGoods_Func();
                    strBarcodeJson = RGF.GetBarCodeInfo(strBarcode);
                    barcodeMdl = JSONUtil.JSONHelper.JsonToObject<Barcode_Model>(strBarcodeJson);
                }

                if (barcodeMdl.Status == "E")
                {
                    return GetFailJson(ref taskHeadModel, barcodeMdl.Message);
                }

                Task_DB TDB = new Task_DB();
                List<Task_Model> lstTask = new List<Task_Model>();
                lstTask = TDB.GetTaskInfo(userModel, barcodeMdl);

                if (lstTask == null || lstTask.Count <= 0)
                {
                    return GetFailJson(ref taskHeadModel, "没有上架任务！");
                }

                taskHeadModel.lstTaskInfo = lstTask;

                taskHeadModel.Status = "S";
                return JSONUtil.JSONHelper.ObjectToJson<TaskHead_Model>(taskHeadModel);
            }
            catch (Exception ex)
            {
                return GetFailJson(ref taskHeadModel, ex.Message);
            }
        }

        public string GetProductTransTaskInfo(string strUserJson, string strBarcode)
        {
            TaskHead_Model taskHeadModel = new TaskHead_Model();
            try
            {
                string strBarcodeJson = string.Empty;
                Barcode_Model barcodeMdl = new Barcode_Model();

                UserInfo userModel = JSONUtil.JSONHelper.JsonToObject<UserInfo>(strUserJson);

                if (userModel == null || string.IsNullOrEmpty(userModel.UserNo))
                {
                    return GetFailJson(ref taskHeadModel, "没有用户信息！");
                }

                if (string.IsNullOrEmpty(strBarcode))
                {
                    return GetFailJson(ref taskHeadModel, "请扫描或输入条码！");
                }
                else
                {
                    ReceiveGoods.ReceiveGoods_Func RGF = new ReceiveGoods.ReceiveGoods_Func();
                    strBarcodeJson = RGF.GetBarCodeInfo(strBarcode);
                    barcodeMdl = JSONUtil.JSONHelper.JsonToObject<Barcode_Model>(strBarcodeJson);
                }

                if (barcodeMdl.Status == "E")
                {
                    return GetFailJson(ref taskHeadModel, barcodeMdl.Message);
                }

                Task_DB TDB = new Task_DB();
                List<Task_Model> lstTask = new List<Task_Model>();
                lstTask = TDB.GetTaskInfo(userModel, barcodeMdl);

                if (lstTask == null || lstTask.Count <= 0)
                {
                    return GetFailJson(ref taskHeadModel, "没有上架任务！");
                }
                return GetQulitiedTaskDetailsInfo(lstTask[0].TaskNo);

            }
            catch (Exception ex)
            {
                return GetFailJson(ref taskHeadModel, ex.Message);
            }
        }


        ///// <summary>
        ///// 获取IQC质检数据
        ///// </summary>
        ///// <param name="strMaterialDoc">质检通知书</param>
        ///// <returns></returns>
        //public bool GetQalityForIQCInfo(string strMaterialDoc, ref List<IQCWebservice.CheckInfo> lstCheckInfo, ref string strErrMsg)
        //{
        //    lstCheckInfo = Tool.IQCWebCommon.GetCommon("http://192.168.0.167/IQCInterface/IQCWebService.asmx", 6000).IQCWeb.GetCheckInfoList(strMaterialDoc).ToList();

        //    if (lstCheckInfo == null || lstCheckInfo.Count <= 0)
        //    {
        //        strErrMsg = "没有获取到质检数据！";
        //        return false;
        //    }
        //    return true;
        //}

        /// <summary>
        /// 获取上架任务明细
        /// </summary>
        /// <param name="strTaskNo"></param>
        /// <returns></returns>
        public string GetQulitiedTaskDetailsInfo(string strTaskNo)
        {
            TaskHead_Model taskHeadModel = new TaskHead_Model();
            try
            {
                string strErrMsg = string.Empty;
                Task_DB TD = new Task_DB();
                Task_Model taskModel = new Task_Model();
                taskModel = TD.GetTaskDetailsInfo(strTaskNo);

                if (taskModel.lstTaskDetails == null || taskModel.lstTaskDetails.Count <= 0)
                {
                    return GetFailJson(ref taskHeadModel, "没有任务明细！");
                }

                //foreach (var item in taskModel.lstTaskDetails)
                //{
                //    item.ToAreaNo = TD.GetAreaNoByMaterialNo(item.MaterialNo);
                //}
                taskHeadModel.lstTaskInfo = new List<Task_Model>();
                taskHeadModel.lstTaskInfo.Add(taskModel);

                return GetSuccessJson(ref taskHeadModel);
            }
            catch (Exception ex)
            {
                return GetFailJson(ref taskHeadModel, ex.Message);
            }
        }

        //public string GetUnQulitiedDetailsInfo(string strMaterialDoc)
        //{
        //    TaskHead_Model taskHeadModel = new TaskHead_Model();
        //    try
        //    {
        //        bool bSucc = false;
        //        string strErrMsg = string.Empty;

        //        Task_Model taskModel = new Task_Model();

        //        List<IQCWebservice.CheckInfo> lstCheckInfo = new List<IQCWebservice.CheckInfo>();

        //        bSucc = GetQalityForIQCInfo(strMaterialDoc, ref lstCheckInfo, ref strErrMsg);

        //        if (bSucc == false)
        //        {
        //            return GetFailJson(ref taskHeadModel, strErrMsg);
        //        }

        //        //根据检验通知书获取供应商
        //        Task_DB TDB = new Task_DB();
        //        taskModel = TDB.GetSupplierInfoByMaterialDoc(strMaterialDoc);
        //        if (taskModel == null || string.IsNullOrEmpty(taskModel.SupCusNo))
        //        {
        //            return GetFailJson(ref taskHeadModel, "没有获取到该物料凭证对应的供应商信息！");
        //        }

        //        //转换成task_model
        //        GetUnQuanlityInfo(ref taskModel, lstCheckInfo);

        //        taskHeadModel.lstTaskInfo[0] = new Task_Model();
        //        taskHeadModel.lstTaskInfo[0] = taskModel;

        //        return GetSuccessJson(ref taskHeadModel);

        //    }
        //    catch (Exception ex)
        //    {
        //        return GetFailJson(ref taskHeadModel, ex.Message);
        //    }
        //}

        //private void GetUnQuanlityInfo(ref Task_Model TM, List<IQCWebservice.CheckInfo> lstCheckInfo)
        //{
        //    foreach (var item in lstCheckInfo)
        //    {
        //        TaskDetails_Model TDM = new TaskDetails_Model();
        //        TDM.MaterialNo = item.Sap;
        //        TDM.MaterialDesc = item.SapDetail;
        //        TDM.UnQuanlityQty = item.NotGoodNum;
        //        TDM.UnQuanlityReson = item.Memo;

        //        TM.lstTaskDetails.Add(TDM);
        //    }
        //}


        public string CreateQuanlityReturnVoucher(string strQuanlityJson, string strUserJson)
        {
            TaskHead_Model taskHeadModel = new TaskHead_Model();
            try
            {
                string strQuanlityXml = string.Empty;
                string strReturnNo = string.Empty;
                string strErrMsg = string.Empty;
                Task_Model taskModel = JSONUtil.JSONHelper.JsonToObject<Task_Model>(strQuanlityJson);

                if (taskModel == null || string.IsNullOrEmpty(taskModel.SupCusNo))
                {
                    return GetFailJson(ref taskHeadModel, "没有对应的供应商信息！");
                }

                if (taskModel.lstTaskDetails == null || taskModel.lstTaskDetails.Count <= 0)
                {
                    return GetFailJson(ref taskHeadModel, "没有质检明细数据！");
                }

                Basic.User.UserInfo userModel = JSONUtil.JSONHelper.JsonToObject<Basic.User.UserInfo>(strUserJson);
                if (userModel == null || string.IsNullOrEmpty(userModel.UserNo))
                {
                    return GetFailJson(ref taskHeadModel, "用户编号为空！");
                }

                Task_DB TDB = new Task_DB();
                strQuanlityXml = XMLUtil.XmlUtil.Serializer(typeof(Task_Model), taskModel);
                bool bSucc = TDB.CreateQuanlityReturnVoucher(strQuanlityXml, ref strReturnNo, userModel, ref strErrMsg);
                if (bSucc == false)
                {
                    return GetFailJson(ref taskHeadModel, strErrMsg);
                }

                taskModel.TaskNo = strReturnNo;
                taskHeadModel.lstTaskInfo[0] = new Task_Model();
                taskHeadModel.lstTaskInfo[0] = taskModel;

                return GetSuccessJson(ref taskHeadModel);

            }
            catch (Exception ex)
            {
                return GetFailJson(ref taskHeadModel, ex.Message);
            }
        }

        /// <summary>
        /// 上架，生成库存
        /// </summary>
        /// <param name="strInStockInfoJson"></param>
        /// <param name="strAreaNo"></param>
        /// <returns></returns>
        public string InStock(string strInStockInfoJson, string strUserJson, string strAreaNo)
        {
            TaskHead_Model taskHeadModel = new TaskHead_Model();
            try
            {
                bool bSucc = false;
                string strErrMsg = string.Empty;

                taskHeadModel = JSONUtil.JSONHelper.JsonToObject<TaskHead_Model>(strInStockInfoJson);
                TOOL.WriteLogMethod.WriteLog("方法：InStock" + strInStockInfoJson);
                if (taskHeadModel.lstTaskInfo == null || taskHeadModel.lstTaskInfo.Count == 0)
                {
                    return GetFailJson(ref taskHeadModel, "没有任务表头数据！");
                }

                Task_Model taskModel = taskHeadModel.lstTaskInfo[0];

                if (taskModel == null || string.IsNullOrEmpty(taskModel.TaskNo))
                {
                    return GetFailJson(ref taskHeadModel, "没有任务表头数据！");
                }

                if (taskModel.lstTaskDetails == null || taskModel.lstTaskDetails.Count <= 0)
                {
                    return GetFailJson(ref taskHeadModel, "没有上架明细数据！");
                }

                //taskModel.lstTaskDetails.ForEach(t => t.ScanQty = t.RemainQty);
                //taskModel.lstTaskDetails[0].lstBarCode = new List<PrintBarcode.Barcode_Model>();
                //PrintBarcode.Barcode_Model BM = new PrintBarcode.Barcode_Model();
                //BM.SERIALNO = "201507140064";
                //taskModel.lstTaskDetails[0].lstBarCode.Add(BM);
                if (taskModel.lstTaskDetails.Where(t => t.ScanQty > 0).Count() == 0)
                {
                    return GetFailJson(ref taskHeadModel, "所有物料的上架数量都为零！");
                }

                if (string.IsNullOrEmpty(strAreaNo))
                {
                    return GetFailJson(ref taskHeadModel, "没有上架货位！");
                }

                Basic.User.UserInfo userModel = JSONUtil.JSONHelper.JsonToObject<Basic.User.UserInfo>(strUserJson);
                if (userModel == null || string.IsNullOrEmpty(userModel.UserNo))
                {
                    return GetFailJson(ref taskHeadModel, "没有用户信息！");
                }
                taskModel.lstTaskDetails = taskModel.lstTaskDetails.Where(t => t.ScanQty != 0).ToList();

                //上架生成库存
                string strTaskXml = XMLUtil.XmlUtil.Serializer(typeof(Task_Model), taskModel);
                //写入LOGO
                TOOL.WriteLogMethod.WriteLog("方法：InStock---操作人：" + userModel.UserName + strTaskXml);
                Task_DB TD = new Task_DB();
                bSucc = TD.InStock(strAreaNo, strTaskXml, userModel, ref strErrMsg);
                if (bSucc == false)
                {
                    return GetFailJson(ref taskHeadModel, strErrMsg);
                }

                taskHeadModel.Message = "保存上架数据成功！";
                return GetSuccessJson(ref taskHeadModel);
            }
            catch (Exception ex)
            {
                return GetFailJson(ref taskHeadModel, "Web异常：" + ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// 下架
        /// </summary>
        /// <param name="strOutStockInfoJson"></param>
        /// <param name="strAreaNo"></param>
        /// <returns></returns>
        public string OutStock(string strOutStockInfoJson, string strUserJson, string strAreaNo)
        {
            TaskHead_Model taskHeadModel = new TaskHead_Model();
            try
            {
                bool bSucc = false;
                string strErrMsg = string.Empty;

                taskHeadModel = JSONUtil.JSONHelper.JsonToObject<TaskHead_Model>(strOutStockInfoJson);
                TOOL.WriteLogMethod.WriteLog("方法：OutStock" + strOutStockInfoJson);
                if (taskHeadModel.lstTaskInfo == null || taskHeadModel.lstTaskInfo.Count == 0)
                {
                    return GetFailJson(ref taskHeadModel, "没有任务表头数据！");
                }

                Task_Model taskModel = taskHeadModel.lstTaskInfo[0];

                if (taskModel == null || string.IsNullOrEmpty(taskModel.TaskNo))
                {
                    return GetFailJson(ref taskHeadModel, "没有任务表头数据！");
                }

                if (taskModel.lstTaskDetails == null || taskModel.lstTaskDetails.Count <= 0)
                {
                    return GetFailJson(ref taskHeadModel, "没有下架明细数据！");
                }

                if (taskModel.lstTaskDetails.Where(t => t.ScanQty > 0).Count() == 0)
                {
                    return GetFailJson(ref taskHeadModel, "所有物料的下架数量都为零！");
                }

                if (string.IsNullOrEmpty(strAreaNo))
                {
                    return GetFailJson(ref taskHeadModel, "没有下架货位！");
                }

                Basic.User.UserInfo userModel = JSONUtil.JSONHelper.JsonToObject<Basic.User.UserInfo>(strUserJson);
                if (userModel == null || string.IsNullOrEmpty(userModel.UserNo))
                {
                    return GetFailJson(ref taskHeadModel, "没有用户信息！");
                }
                taskModel.lstTaskDetails = taskModel.lstTaskDetails.Where(t => t.ScanQty != 0).ToList();

                //下架
                string strTaskXml = XMLUtil.XmlUtil.Serializer(typeof(Task_Model), taskModel);
                //写入LOGO
                TOOL.WriteLogMethod.WriteLog("方法：OutStock---操作人：" + userModel.UserName + strTaskXml);
                Task_DB TD = new Task_DB();
                bSucc = TD.InStock(strAreaNo, strTaskXml, userModel, ref strErrMsg);
                if (bSucc == false)
                {
                    return GetFailJson(ref taskHeadModel, strErrMsg);
                }

                taskHeadModel.Message = "保存下架数据成功！";
                return GetSuccessJson(ref taskHeadModel);
            }
            catch (Exception ex)
            {
                return GetFailJson(ref taskHeadModel, "Web异常：" + ex.Message + ex.StackTrace);
            }
        }



        public string CheckBarCodeIsInStock(string strSerialNo)
        {
            TaskHead_Model taskHeadModel = new TaskHead_Model();

            try
            {
                Task_DB TDB = new Task_DB();
                int iResult = TDB.CheckBarCodeIsInStock(strSerialNo);
                if (iResult >= 1)//说明该条码已经上架
                {
                    return GetFailJson(ref taskHeadModel, "该箱码已经上架，请确认！");
                }
                return GetSuccessJson(ref taskHeadModel);
            }
            catch (Exception ex)
            {
                return GetFailJson(ref taskHeadModel, ex.Message);
            }

        }


        /// <summary>
        /// 锁定任务操作人
        /// </summary>
        /// <param name="taskDetailsMdl"></param>
        /// <param name="userMdl"></param>
        /// <param name="strErrMsg"></param>
        /// <returns></returns>
        public string LockTaskOperUser(string strTaskDetailsJson, string strUserJson)
        {
            TaskHead_Model taskHeadModel = new TaskHead_Model();

            try
            {
                int iLock = 0;
                string strUserName = string.Empty;

                TaskDetails_Model taskDetailsModel = JSONUtil.JSONHelper.JsonToObject<TaskDetails_Model>(strTaskDetailsJson);

                if (taskDetailsModel == null || (string.IsNullOrEmpty(taskDetailsModel.MaterialNo) && string.IsNullOrEmpty(taskDetailsModel.TMaterialNo)))
                {
                    return GetFailJson(ref taskHeadModel, "没有物料信息");
                }

                Basic.User.UserInfo userModel = JSONUtil.JSONHelper.JsonToObject<Basic.User.UserInfo>(strUserJson);
                if (userModel == null || string.IsNullOrEmpty(userModel.UserNo))
                {
                    return GetFailJson(ref taskHeadModel, "没有用户信息");
                }

                Task_DB TD = new Task_DB();
                strUserName = TD.QueryUserNameByTaskDetails(taskDetailsModel, userModel);
                if (!string.IsNullOrEmpty(strUserName))
                {
                    return GetFailJson(ref taskHeadModel, "物料：" + taskDetailsModel.MaterialNo + taskDetailsModel.TMaterialNo + "\r\n" + "被：" + strUserName + "锁定！");

                }
                iLock = TD.LockTaskOperUser(taskDetailsModel, userModel);

                if (iLock == 0)
                {
                    return GetFailJson(ref taskHeadModel, "物料：" + taskDetailsModel.MaterialNo + "锁定失败！");
                }
                return GetSuccessJson(ref taskHeadModel);
            }
            catch (Exception ex)
            {
                return GetFailJson(ref taskHeadModel, "Web异常：" + ex);
            }
        }


        public string UnLockTaskOperUser(string strInStockInfoJson, string strUserJson) 
        {
            TaskHead_Model taskHeadModel = new TaskHead_Model();

            try
            {
                bool bSucc = false;
                
                string strErrMsg = string.Empty;

                taskHeadModel = JSONUtil.JSONHelper.JsonToObject<TaskHead_Model>(strInStockInfoJson);
                TOOL.WriteLogMethod.WriteLog("方法：UnLockTaskOperUser" +strInStockInfoJson);

                if (taskHeadModel.lstTaskInfo == null || taskHeadModel.lstTaskInfo.Count == 0)
                {
                    return GetFailJson(ref taskHeadModel, "没有任务表头数据,解锁失败！");
                }

                Task_Model taskModel = taskHeadModel.lstTaskInfo[0];

                if (taskModel == null || string.IsNullOrEmpty(taskModel.TaskNo))
                {
                    return GetFailJson(ref taskHeadModel, "没有任务表头数据，解锁失败！");
                }

                if (taskModel.lstTaskDetails == null || taskModel.lstTaskDetails.Count <= 0)
                {
                    return GetFailJson(ref taskHeadModel, "没有任务明细数据，解锁失败！");
                }

                Basic.User.UserInfo userModel = JSONUtil.JSONHelper.JsonToObject<Basic.User.UserInfo>(strUserJson);
                if (userModel == null || string.IsNullOrEmpty(userModel.UserNo))
                {
                    return GetFailJson(ref taskHeadModel, "没有用户信息，解锁失败！");
                }

                string strTaskXml = XMLUtil.XmlUtil.Serializer(typeof(Task_Model), taskModel);
                //写入LOGO
                TOOL.WriteLogMethod.WriteLog("方法：UnLockTaskOperUser"+strTaskXml);
                Task_DB TD = new Task_DB();
                bSucc = TD.UnLockTaskOperUser( strTaskXml, userModel, ref strErrMsg);
                if (bSucc == false)
                {
                    return GetFailJson(ref taskHeadModel, strErrMsg);
                }

                taskHeadModel.Message = "上架数据解锁成功！";
                return GetSuccessJson(ref taskHeadModel);
            }
            catch (Exception ex)
            {
                return GetFailJson(ref taskHeadModel, "Web异常：" + ex);
            }
        }

        /// <summary>
        /// 验证库位是否存在或可用
        /// </summary>
        /// <param name="strAreaNo"></param>
        /// <param name="strUserJson"></param>
        /// <returns></returns>
        public string CheckArea(string strAreaNo, string strUserJson)
        {
            TaskHead_Model taskHeadModel = new TaskHead_Model();
            try
            {
                int iSucc = 0;
                Task_DB TD = new Task_DB();
                iSucc = TD.CheckAreaByNo(strAreaNo);
                if (iSucc == 0)
                {
                    return GetFailJson(ref taskHeadModel, "该库位已被删除或不存在！库位编码：" + strAreaNo);
                }
                iSucc = TD.CheckAreaIsLock(strAreaNo);
                if (iSucc == 0)
                {
                    return GetFailJson(ref taskHeadModel, "该库位已被锁定！库位编码：" + strAreaNo);
                }
                return GetSuccessJson(ref taskHeadModel);
            }
            catch (Exception ex)
            {
                return GetFailJson(ref taskHeadModel, "Web异常：" + ex);
            }
        }

        //public bool GetMaterialInfoForSAP(string strMaterialNo, ref Task.TaskDetails_Model taskDetailsModel, ref string strErrMsg)
        //{
        //    try
        //    {
        //        bool bSucc = false;
        //        Material.Material_SAP materialSAP = new Material.Material_SAP();
        //        bSucc = materialSAP.GetMaterialInfoForSAP(strMaterialNo, ref taskDetailsModel, ref strErrMsg);

        //        if (bSucc == false)
        //        {
        //            return bSucc;
        //        }

        //        if (taskDetailsModel == null || string.IsNullOrEmpty(taskDetailsModel.MaterialNo))
        //        {
        //            strErrMsg = "没有获取到SAP物料信息！";
        //            bSucc = false;
        //        }
        //        return bSucc;
        //    }
        //    catch (Exception ex)
        //    {
        //        strErrMsg = "Web异常：" + ex.Message;
        //        return false;
        //    }

        //}

        //public string PostTaskInfoToSAP(string strTaskID, string strStorageLoc, string strUserJson)
        //{
        //    TaskHead_Model taskHeadModel = new TaskHead_Model();
        //    try
        //    {
        //        bool bSucc = false;
        //        string strErrMsg = string.Empty;

        //        UserInfo userModel = JSONUtil.JSONHelper.JsonToObject<UserInfo>(strUserJson);

        //        if (userModel == null || string.IsNullOrEmpty(userModel.UserNo))
        //        {
        //            return GetFailJson(ref taskHeadModel, "没有用户信息！");
        //        }

        //        DeliveryReceive_Model deliveryModel = new DeliveryReceive_Model();
        //        Task_DB TDB = new Task_DB();

        //        deliveryModel = TDB.GetTaskInfoByID(strTaskID, userModel);

        //        if (deliveryModel == null || string.IsNullOrEmpty(deliveryModel.VoucherNo))
        //        {
        //            return GetFailJson(ref taskHeadModel, "任务表头为空,没有过账数据!");
        //        }
        //        if (deliveryModel.IsShelvePost == 1)
        //        {
        //            return GetFailJson(ref taskHeadModel, "该任务不能过账！任务号：" + deliveryModel.VoucherNo);
        //        }

        //        if (deliveryModel.lstDeliveryDetail == null || deliveryModel.lstDeliveryDetail.Count == 0)
        //        {
        //            return GetFailJson(ref taskHeadModel, "该任务过账数据为空！任务号：" + deliveryModel.VoucherNo);
        //        }

        //        if (deliveryModel.lstDeliveryDetail.Where(t => t.CurrentPostQty > 0).Count() == 0)
        //        {
        //            return GetFailJson(ref taskHeadModel, "该任务过账数量都为零！任务号：" + deliveryModel.VoucherNo);
        //        }


        //        if (string.IsNullOrEmpty(strStorageLoc))
        //        {
        //            return GetFailJson(ref taskHeadModel, "库存地点为空！");
        //        }

        //        deliveryModel.lstDeliveryDetail.ForEach(t => t.StorageLoc = strStorageLoc);

        //        bSucc = SelectTaskToPost(ref deliveryModel, userModel, ref  strErrMsg);

        //        if (bSucc == false)
        //        {
        //            return GetFailJson(ref taskHeadModel, strErrMsg);
        //        }



        //        Task_DB TD = new Task_DB();
        //        deliveryModel.lstDeliveryDetail = deliveryModel.lstDeliveryDetail.Where(t => t.CurrentPostQty > 0).ToList();
        //        string strDeliveryXml = XMLUtil.XmlUtil.Serializer(typeof(DeliveryReceive_Model), deliveryModel);
        //        bSucc = TD.UpdateTaskByPost(strDeliveryXml, userModel, ref strErrMsg);

        //        if (bSucc == false)
        //        {
        //            return GetFailJson(ref taskHeadModel, "过账成功，更新任务数据失败！" + strErrMsg);
        //        }
        //        else
        //        {
        //            taskHeadModel.Message = "过账成功！\r\n物料凭证：" + deliveryModel.materialDocModel.MaterialDoc + "\r\n" + "凭证年度:" + deliveryModel.materialDocModel.MaterialDocDate;
        //            return GetSuccessJson(ref taskHeadModel);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return GetFailJson(ref taskHeadModel, "Web异常：" + ex);
        //    }

        //}

        //private bool SelectTaskToPost(ref DeliveryReceive_Model deliveryModel, UserInfo userModel, ref string strErrMsg)
        //{
        //    bool bSucc = false;


        //    switch (deliveryModel.VoucherType)
        //    {
        //        case 10:
        //            bSucc = new DeliveryReceive_Func().TaskInfoPostToSAP(ref deliveryModel, userModel, ref strErrMsg);
        //            break;
        //        case 30:
        //            bSucc = new ProductionReturn_Func().TaskInfoPostToSAP(ref deliveryModel, userModel, ref strErrMsg);
        //            break;
        //        case 40:
        //            bSucc = new Production_Func().TaskInfoPostToSAP(ref deliveryModel, userModel, ref strErrMsg);
        //            break;
        //        default:
        //            break;
        //    }
        //    return bSucc;
        //}


        private string GetSuccessJson(ref TaskHead_Model taskHeadModel)
        {
            taskHeadModel.Status = "S";
            return JSONUtil.JSONHelper.ObjectToJson<TaskHead_Model>(taskHeadModel);
        }

        private string GetFailJson(ref TaskHead_Model taskHeadModel, string strErrMsg)
        {
            taskHeadModel.Status = "E";
            taskHeadModel.Message = strErrMsg;
            return JSONUtil.JSONHelper.ObjectToJson<TaskHead_Model>(taskHeadModel);
        }

    }
}
