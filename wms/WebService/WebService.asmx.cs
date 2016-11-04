using System.Collections.Generic;
using System.Web.Services;
using BLL.Basic.Area;
using BLL.Basic.House;
using BLL.Basic.Menu;
using BLL.Basic.User;
using BLL.Basic.UserGroup;
using BLL.Basic.Warehouse;
using BLL.Common;
using BLL.PrintBarcode;
using BLL.DeliveryReceive;
using BLL.Basic.TempMaterial;
using BLL.Basic.Task;
//using JXBLL.Basic.Stock;
using BLL.ReceiveGoods;
using BLL.FastInNotHavePO;
using BLL.Task;
using BLL.FastIn;
using BLL.Stock;
using BLL.Basic.Receive;
using BLL.AppVersion;
using BLL.Quality;
using BLL.OutStock;
using BLL.Supplier;
using BLL.Check;

namespace WebService
{
    /// <summary>
    /// JXWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<ComboBoxItem> GetComboBoxItem(string strSql)
        {
            return Common_Func.GetComboBoxItem(strSql);
        }

        [WebMethod]
        public bool GetComboBoxItemByKey(string key, ref List<ComboBoxItem> comboxBoxItemList, ref string strError)
        {
            return Common_Func.GetComboBoxItem(key, ref comboxBoxItemList, ref strError);
        }

        #region 用户登陆

        [WebMethod(Description = "验证版本")]
        public bool VerifyVersion(string FileVersion, string FileName, string path)
        {
            AppVersion_Func func = new AppVersion_Func();
            return !func.VerifyVersion(FileVersion, FileName, path);
        }

        [WebMethod]
        public bool VerifyAppVersion(ref AppVersionInfo appversion, ref string strError)
        {
            AppVersion_Func func = new AppVersion_Func();
            return func.VerifyVersion(ref appversion, ref strError);
        }

        [WebMethod]
        public bool GetAppVersionByVersion(ref AppVersionInfo model, ref string strError)
        {
            AppVersion_Func func = new AppVersion_Func();
            return func.GetAppVersionByVersion(ref model, ref strError);
        }

        [WebMethod]
        public bool UserLogin(ref UserInfo user, ref string strError)
        {
            Login_Func func = new Login_Func();
            return func.UserLogin(ref user, ref strError);
        }

        [WebMethod]
        public bool UpdateLoginTime(ref UserInfo user, ref string strError)
        {
            Login_Func func = new Login_Func();
            return func.UpdateLoginTime(ref user, ref strError);
        }

        [WebMethod]
        public bool ChangeUserPassword(UserInfo user, UserInfo ChangeUser, ref string strError)
        {
            Login_Func func = new Login_Func();
            return func.ChangeUserPassword(user, ChangeUser, ref strError);
        }

        [WebMethod]
        public bool ClearLoginTime(UserInfo user, UserInfo ClearUser, ref string strError)
        {
            Login_Func func = new Login_Func();
            return func.ClearLoginTime(user, ClearUser, ref strError);
        }

        [WebMethod]
        public string UserLoginForAndroid(string strUserJson)
        {
            Login_Func func = new Login_Func();
            return func.UserLoginForAndroid(strUserJson);
        }

        [WebMethod]
        public string UpdateLoginTimeForAndroid(string strUserJson)
        {
            Login_Func func = new Login_Func();
            return func.UpdateLoginTimeForAndroid(strUserJson);
        }

        [WebMethod]
        public string ChangeUserPasswordForAndroid(string strUserJson)
        {
            Login_Func func = new Login_Func();
            return func.ChangeUserPasswordForAndroid(strUserJson);
        }

        [WebMethod]
        public string ClearLoginTimeForAndroid(string strUserJson)
        {
            Login_Func func = new Login_Func();
            return func.ClearLoginTimeForAndroid(strUserJson);
        }

        #endregion

        #region 基础设置

        #region 用户设置

        [WebMethod]
        public bool ExistsUserNo(UserInfo model, bool bIncludeDel, UserInfo user, ref string strError)
        {
            User_Func func = new User_Func();
            return func.ExistsUserNo(model, bIncludeDel, user, ref strError);
        }

        [WebMethod]
        public bool SaveUser(ref UserInfo model, UserInfo user, ref string strError)
        {
            User_Func func = new User_Func();
            return func.SaveUser(ref model, user, ref strError);
        }

        [WebMethod]
        public bool DeleteUserByID(UserInfo model, UserInfo user, ref string strError)
        {
            User_Func func = new User_Func();
            return func.DeleteUserByID(model, user, ref strError);
        }

        [WebMethod]
        public bool GetUserByID(ref UserInfo model, UserInfo user, ref string strError)
        {
            User_Func func = new User_Func();
            return func.GetUserByID(ref model, user, ref strError);
        }

        [WebMethod]
        public bool GetUserListByPage(ref List<UserInfo> modelList, UserInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            User_Func func = new User_Func();
            return func.GetUserListByPage(ref modelList, model, ref page, user, ref strError);
        }

        [WebMethod]
        public bool GetMenuListByUser(ref List<MenuInfo> menuList, UserInfo model, bool IncludNoCheck, UserInfo user, ref string strError)
        {
            Menu_Func func = new Menu_Func();
            return func.GetMenuListByUser(ref menuList, model, IncludNoCheck, user, ref strError);
        }

        [WebMethod]
        public bool GetUserGroupListByUser(ref List<UserGroupInfo> usergroupList, UserInfo model, bool IncludNoCheck, UserInfo user, ref string strError)
        {
            UserGroup_Func func = new UserGroup_Func();
            return func.GetUserGroupListByUser(ref usergroupList, model, IncludNoCheck, user, ref strError);
        }

        [WebMethod]
        public bool GetWarehouseListByUser(ref List<WarehouseInfo> warehouseList, UserInfo model, bool IncludNoCheck, UserInfo user, ref string strError)
        {
            Warehouse_Func func = new Warehouse_Func();
            return func.GetWarehouseListByUser(ref warehouseList, model, IncludNoCheck, user, ref strError);
        }
        #endregion

        #region 仓库设置

        [WebMethod]
        public bool ExistsWarehouseNo(WarehouseInfo model, bool bIncludeDel, UserInfo user, ref string strError)
        {
            Warehouse_Func func = new Warehouse_Func();
            return func.ExistsWarehouseNo(model, bIncludeDel, user, ref strError);
        }

        [WebMethod]
        public bool SaveWarehouse(ref WarehouseInfo model, UserInfo user, ref string strError)
        {
            Warehouse_Func func = new Warehouse_Func();
            return func.SaveWarehouse(ref model, user, ref strError);
        }

        [WebMethod]
        public bool DeleteWarehouseByID(WarehouseInfo model, UserInfo user, ref string strError)
        {
            Warehouse_Func func = new Warehouse_Func();
            return func.DeleteWarehouseByID(model, user, ref strError);
        }

        [WebMethod]
        public bool GetWarehouseByID(ref WarehouseInfo model, UserInfo user, ref string strError)
        {
            Warehouse_Func func = new Warehouse_Func();
            return func.GetWarehouseByID(ref model, user, ref strError);
        }

        [WebMethod]
        public bool GetWarehouseListByPage(ref List<WarehouseInfo> modelList, WarehouseInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            Warehouse_Func func = new Warehouse_Func();
            return func.GetWarehouseListByPage(ref modelList, model, ref page, user, ref strError);
        }

        [WebMethod]
        public bool GetWarehouseList(ref List<WarehouseInfo> modelList, WarehouseInfo model, UserInfo user, ref string strError)
        {
            Warehouse_Func func = new Warehouse_Func();
            return func.GetWarehouseList(ref modelList, model, user, ref strError);
        }
        #endregion

        #region 库区设置

        [WebMethod]
        public bool ExistsHouseNo(HouseInfo model, bool bIncludeDel, UserInfo user, ref string strError)
        {
            House_Func func = new House_Func();
            return func.ExistsHouseNo(model, bIncludeDel, user, ref strError);
        }

        [WebMethod]
        public bool SaveHouse(ref HouseInfo model, UserInfo user, ref string strError)
        {
            House_Func func = new House_Func();
            return func.SaveHouse(ref model, user, ref strError);
        }

        [WebMethod]
        public bool DeleteHouseByID(HouseInfo model, UserInfo user, ref string strError)
        {
            House_Func func = new House_Func();
            return func.DeleteHouseByID(model, user, ref strError);
        }

        [WebMethod]
        public bool GetHouseByID(ref HouseInfo model, UserInfo user, ref string strError)
        {
            House_Func func = new House_Func();
            return func.GetHouseByID(ref model, user, ref strError);
        }

        [WebMethod]
        public bool GetHouseListByPage(ref List<HouseInfo> modelList, HouseInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            House_Func func = new House_Func();
            return func.GetHouseListByPage(ref modelList, model, ref page, user, ref strError);
        }

        [WebMethod]
        public bool GetHouseList(ref List<HouseInfo> modelList, HouseInfo model, UserInfo user, ref string strError)
        {
            House_Func func = new House_Func();
            return func.GetHouseList(ref modelList, model, user, ref strError);
        }
        #endregion

        #region 货位设置

        [WebMethod]
        public bool ExistsAreaNo(AreaInfo model, bool bIncludeDel, UserInfo user, ref string strError)
        {
            Area_Func func = new Area_Func();
            return func.ExistsAreaNo(model, bIncludeDel, user, ref strError);
        }
        
        [WebMethod]
        public string GetAreaInfo(string strAreaNo, string strUserJson)
        {
            Area_Func func = new Area_Func();
            return func.GetAreaInfo(strAreaNo, strUserJson);
        }

        [WebMethod]
        public bool GetAreaInfoByAreaNo(string strAreaNo,ref AreaInfo Info,ref  string strErrMsg)
        {
            Area_Func func = new Area_Func();
            return func.GetAreaInfoByAreaNo(strAreaNo, ref Info, ref strErrMsg);
        }

        [WebMethod]
        public bool SaveArea(ref AreaInfo model, UserInfo user, ref string strError)
        {
            Area_Func func = new Area_Func();
            return func.SaveArea(ref model, user, ref strError);
        }

        [WebMethod]
        public bool DeleteAreaByID(AreaInfo model, UserInfo user, ref string strError)
        {
            Area_Func func = new Area_Func();
            return func.DeleteAreaByID(model, user, ref strError);
        }

        [WebMethod]
        public bool GetAreaByID(ref AreaInfo model, UserInfo user, ref string strError)
        {
            Area_Func func = new Area_Func();
            return func.GetAreaByID(ref model, user, ref strError);
        }

        [WebMethod]
        public bool GetAreaListByPage(ref List<AreaInfo> modelList, AreaInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            Area_Func func = new Area_Func();
            return func.GetAreaListByPage(ref modelList, model, ref page, user, ref strError);
        }

        [WebMethod]
        public bool GetAreaList(ref List<AreaInfo> modelList, AreaInfo model, UserInfo user, ref string strError)
        {
            Area_Func func = new Area_Func();
            return func.GetAreaList(ref modelList, model, user, ref strError);
        }
        #endregion

        #region 用户组设置

        [WebMethod]
        public bool ExistsUserGroupNo(UserGroupInfo model, bool bIncludeDel, UserInfo user, ref string strError)
        {
            UserGroup_Func func = new UserGroup_Func();
            return func.ExistsUserGroupNo(model, bIncludeDel, user, ref strError);
        }

        [WebMethod]
        public bool SaveUserGroup(ref UserGroupInfo model, UserInfo user, ref string strError)
        {
            UserGroup_Func func = new UserGroup_Func();
            return func.SaveUserGroup(ref model, user, ref strError);
        }

        [WebMethod]
        public bool DeleteUserGroupByID(UserGroupInfo model, UserInfo user, ref string strError)
        {
            UserGroup_Func func = new UserGroup_Func();
            return func.DeleteUserGroupByID(model, user, ref strError);
        }

        [WebMethod]
        public bool GetUserGroupByID(ref UserGroupInfo model, UserInfo user, ref string strError)
        {
            UserGroup_Func func = new UserGroup_Func();
            return func.GetUserGroupByID(ref model, user, ref strError);
        }

        [WebMethod]
        public bool GetUserGroupListByPage(ref List<UserGroupInfo> modelList, UserGroupInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            UserGroup_Func func = new UserGroup_Func();
            return func.GetUserGroupListByPage(ref modelList, model, ref page, user, ref strError);
        }

        [WebMethod]
        public bool GetMenuListByUserGroup(ref List<MenuInfo> menuList, UserGroupInfo model, bool IncludNoCheck, UserInfo user, ref string strError)
        {
            Menu_Func func = new Menu_Func();
            return func.GetMenuListByUserGroup(ref menuList, model, IncludNoCheck, user, ref strError);
        }

        [WebMethod]
        public bool SaveUserGroupMenuToDB(MenuInfo menu, UserGroupInfo model, UserInfo user, ref string strError)
        {
            Menu_Func func = new Menu_Func();
            return func.SaveUserGroupMenuToDB(menu, model, user, ref strError);
        }

        [WebMethod]
        public List<ComboBoxItem> GetParentMenuByMenu(MenuInfo menu)
        {
            return Common_Func.GetParentMenuByMenu(menu);
        }
        #endregion

        #region 菜单设置

        [WebMethod]
        public bool ExistsMenuNo(MenuInfo model, bool bIncludeDel, UserInfo user, ref string strError)
        {
            Menu_Func func = new Menu_Func();
            return func.ExistsMenuNo(model, bIncludeDel, user, ref strError);
        }

        [WebMethod]
        public bool SaveMenu(ref MenuInfo model, UserInfo user, ref string strError)
        {
            Menu_Func func = new Menu_Func();
            return func.SaveMenu(ref model, user, ref strError);
        }

        [WebMethod]
        public bool DeleteMenuByID(MenuInfo model, UserInfo user, ref string strError)
        {
            Menu_Func func = new Menu_Func();
            return func.DeleteMenuByID(model, user, ref strError);
        }

        [WebMethod]
        public bool GetMenuByID(ref MenuInfo model, UserInfo user, ref string strError)
        {
            Menu_Func func = new Menu_Func();
            return func.GetMenuByID(ref model, user, ref strError);
        }

        [WebMethod]
        public bool GetMenuListByPage(ref List<MenuInfo> modelList, MenuInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            Menu_Func func = new Menu_Func();
            return func.GetMenuListByPage(ref modelList, model, ref page, user, ref strError);
        }

        [WebMethod]
        public bool GetMenuNo(ref MenuInfo model, UserInfo user, ref string strError)
        {
            Menu_Func func = new Menu_Func();
            return func.GetMenuNo(ref model, user, ref strError);
        }
        #endregion

        #region Excel导入

        [WebMethod]
        public bool CheckImportTable(int iType, UserInfo user, ref string strError)
        {
            return Common_Func.CheckImportTable(iType, user, ref strError);
        }

        [WebMethod]
        public bool UpLoadSql(List<string> lstSql, UserInfo user, ref string strError)
        {
            return Common_Func.UpLoadSql(lstSql, user, ref strError);
        }

        //[WebMethod]
        //public bool DealImport(int iType, UserInfo user, ref string strError)
        //{
        //    return Common_Func.DealImport(iType, user, ref strError);
        //}
        #endregion

        #endregion

        #region 查询管理

        #region 记录查询

        [WebMethod]
        public bool GetTaskTransListByPage(ref List<TaskTransInfo> modelList, TaskTransInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            TaskTrans_Func func = new TaskTrans_Func();
            return func.GetTaskTransListByPage(ref modelList, model, ref page, user, ref strError);
        }

        [WebMethod]
        public bool GetReceiveTransListByPage(ref List<ReceiveTransInfo> modelList, ReceiveTransInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            ReceiveTrans_Func func = new ReceiveTrans_Func();
            return func.GetReceiveTransListByPage(ref modelList, model, ref page, user, ref strError);
        }

        #endregion

        #region 库存查询

        [WebMethod]
        public bool GetStockListByPage(ref List<Stock_Model> modelList, Stock_Model model, ref DividPage page, UserInfo user, ref string strError)
        {
            Stock_Func func = new Stock_Func();
            return func.GetStockListByPage(ref modelList, model, ref page, user, ref strError);
        }

        [WebMethod]
        public bool GetCapacityForWMS(ref List<Stock_Model> modelList, QueryConditions list, ref string strError)
        {
            Stock_Func func = new Stock_Func();
            return func.GetCapacityForWMS(ref modelList, list, ref strError);
        }


        [WebMethod]
        public string GetCapacityByProductLineNo(string strProductLineNo, string strUserJson)
        {
            Stock_Func func = new Stock_Func();
            return func.GetCapacityByProductLineNo(strProductLineNo, strUserJson);
        }
        #endregion

        #region 库存明细

        [WebMethod]
        public bool GetStockDetailListByPage(ref List<Stock_Model> modelList, Stock_Model model, ref DividPage page, UserInfo user, ref string strError)
        {
            Stock_Func func = new Stock_Func();
            return func.GetStockDetailListByPage(ref modelList, model, ref page, user, ref strError);
        }

        #endregion

        #endregion

        #region 仓库业务

        #region 快速入库
        [WebMethod]
        public bool QueryFastInList(Task_Model taskModel, string BeginTime, string EndTime, ref DividPage dividpage, ref List<Task_Model> lsttask, ref string strErrMsg)
        {
            BLL.FastIn.FastIn_Func fdb = new BLL.FastIn.FastIn_Func();
            return fdb.QueryFastInList(taskModel, BeginTime, EndTime, ref dividpage, ref lsttask, ref strErrMsg);
        }
        [WebMethod]
        public bool GetNewTASKNO(ref string TASKNO, ref string ErrMsg)
        {
            return new BLL.FastIn.FastIn_Func().GetNewTASKNO(ref TASKNO, ref ErrMsg);
        }
        [WebMethod]
        public bool SaveFastIn(Task_Model head, UserInfo userModel, ref string strErrMsg)
        {
            return new BLL.FastIn.FastIn_Func().SaveFastIn(head, userModel, ref strErrMsg);
        }
        [WebMethod]
        public bool SavePostFastIn(Task_Model head, UserInfo userModel, TaskVoucher tv, ref string strErrMsg)
        {
            return new BLL.FastIn.FastIn_Func().SavePostFastIn(head, userModel, tv, ref strErrMsg);
        }
        [WebMethod]
        public bool DeleteFastIn(string ID, UserInfo userModel, ref string strErrMsg)
        {
            return new BLL.FastIn.FastIn_Func().DeleteFastIn(ID, userModel, ref strErrMsg);
        }
        [WebMethod]
        public bool GetFastInByID(string ID, ref Task_Model head, ref TaskVoucher tv, ref string strErrMsg)
        {
            return new BLL.FastIn.FastIn_Func().GetFastInByID(ID, ref head, ref tv, ref strErrMsg);
        }
        [WebMethod]
        public bool UpdateFastIn(string ID, Task_Model head, string[] lst_delID, ref string strErrMsg)
        {
            return new BLL.FastIn.FastIn_Func().UpdateFastIn(ID, head, lst_delID, ref strErrMsg);
        }
        [WebMethod]
        public bool UpdatePostFastIn(string ID, Task_Model head, TaskVoucher tv, string[] lst_delID, ref string strErrMsg)
        {
            return new BLL.FastIn.FastIn_Func().UpdatePostFastIn(ID, head, tv, lst_delID, ref strErrMsg);
        }
        [WebMethod]
        public bool GetVoucherByNo(string NO, ref TaskVoucher tv, ref string strErrMsg)
        {
            return new BLL.FastIn.FastIn_Func().GetVoucherByNo(NO, ref tv, ref strErrMsg);
        }
        //[WebMethod]
        //public bool PostFastIn(string ID, UserInfo userModel, ref string strErrMsg)
        //{
        //    return new JXBLL.FastIn.FastIn_Func().PostFastIn(ID, userModel, ref strErrMsg);
        //}
        #endregion

        #region 无PO快速入库
        [WebMethod]
        //查询数据
        public bool GetFastInNotHavePOInfo(Task_Model taskmo, ref DividPage dividpage, ref List<Task_Model> lsttask, ref string strErrMsg)
        {
            FastInNotHavePO_Func func = new FastInNotHavePO_Func();
            return func.GetFastInNotHavePOInfo(taskmo, ref dividpage, ref lsttask, ref strErrMsg);
        }
        [WebMethod]
        public bool InsetMaterialDetail(List<TaskDetails_Model> tDtails, ref string msg)
        {
            FastInNotHavePO_Func func = new FastInNotHavePO_Func();
            return func.InsetMaterialDetail(tDtails, ref msg);
        }
        [WebMethod]
        public bool GetTempMaterialName(string materialNo, ref string materialDESC)
        {
            FastInNotHavePO_Func func = new FastInNotHavePO_Func();
            return func.GetTempMaterialName(materialNo, ref materialDESC);
        }
        [WebMethod]
        public bool ExistsTempMaterialByMaterialNo(string materialNo)
        {
            FastInNotHavePO_Func func = new FastInNotHavePO_Func();
            return func.ExistsTempMaterialByMaterialNo(materialNo);
        }
        #endregion

        #region 临时物料

        #region 获取临时物料信息
        [WebMethod]
        public bool GetTempMaterialByTempNo(string strMaterialNo, ref BLL.TempMaterial tempmaterial, ref string strErrMsg)
        {
            BLL.TempMaterial_Func TF = new BLL.TempMaterial_Func();
            return TF.GetTempMaterialByTempNo(strMaterialNo, ref tempmaterial, ref strErrMsg);
        }
        #endregion

        [WebMethod]
        public bool ExistsTempMaterialNo(TempMaterialInfo model, bool bIncludeDel, UserInfo user, ref string strError)
        {
            TempMaterial_Func func = new TempMaterial_Func();
            return func.ExistsTempMaterialNo(model, bIncludeDel, user, ref strError);
        }

        [WebMethod]
        public bool SaveTempMaterial(ref TempMaterialInfo model, UserInfo user, ref string strError)
        {
            TempMaterial_Func func = new TempMaterial_Func();
            return func.SaveTempMaterial(ref model, user, ref strError);
        }

        [WebMethod]
        public bool DeleteTempMaterialByID(TempMaterialInfo model, UserInfo user, ref string strError)
        {
            TempMaterial_Func func = new TempMaterial_Func();
            return func.DeleteTempMaterialByID(model, user, ref strError);
        }

        [WebMethod]
        public bool GetTempMaterialByID(ref TempMaterialInfo model, UserInfo user, ref string strError)
        {
            TempMaterial_Func func = new TempMaterial_Func();
            return func.GetTempMaterialByID(ref model, user, ref strError);
        }

        [WebMethod]
        public bool GetTempMaterialListByPage(ref List<TempMaterialInfo> modelList, TempMaterialInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            TempMaterial_Func func = new TempMaterial_Func();
            return func.GetTempMaterialListByPage(ref modelList, model, ref page, user, ref strError);
        }

        [WebMethod]
        public bool GetMaterialInfo(ref TempMaterialInfo model, int type, UserInfo user, ref string strError)
        {
            TempMaterial_Func func = new TempMaterial_Func();
            return func.GetMaterialInfo(ref model, type, user, ref strError);
        }

        [WebMethod]
        public bool GetTempMaterialNo(ref TempMaterialInfo model, UserInfo user, ref string strError)
        {
            TempMaterial_Func func = new TempMaterial_Func();
            return func.GetTempMaterialNo(ref model, user, ref strError);
        }

        #endregion

        #endregion

        #region 任务看板

        #region 入库任务

        [WebMethod]
        public bool GetTaskMainListByPage(ref List<OverViewInfo> modelList, OverViewInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            OverView_Func func = new OverView_Func();
            return func.GetOverViewListByPage(ref modelList, model, ref page, user, ref strError);
        }

        [WebMethod]
        public bool GetTaskDetailListByPage(ref List<OverViewDetailInfo> modelList, OverViewDetailInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            OverViewDetail_Func func = new OverViewDetail_Func();
            return func.GetOverViewDetailByPage(ref modelList, model, ref page, user, ref strError);
        }

        [WebMethod]
        public bool GetOverViewExportListByPage(ref List<OverViewExportInfo> modelList, OverViewExportInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            OverViewExport_Func func = new OverViewExport_Func();
            return func.GetOverViewExportListByPage(ref modelList, model, ref page, user, ref strError);
        }

        #endregion

        #region 出库任务

        #endregion

        #endregion

        #region 标签打印

        //[WebMethod]
        //public bool GetDeliveryInfoForPrint(string strDeliveryNo, ref List<Barcode_Model> lstBarcode, ref string strError)
        //{
        //    Barcode_Func func = new Barcode_Func();
        //    return func.GetDeliveryInfoForPrint(strDeliveryNo, ref lstBarcode, ref strError);
        //}

        //[WebMethod]
        //public bool GetPurchaseInfoForPrint(string POCode, ref List<Barcode_Model> lstBarcode, string SupCode, ref string strError)
        //{
        //    Barcode_Func func = new Barcode_Func();
        //    return func.GetPurchaseInfoForPrint(POCode, ref lstBarcode, SupCode, ref strError);
        //}

        [WebMethod]
        public bool GetProductionInfoForPrint(string strProductionNo, ref List<Barcode_Model> lstBarcode, ref string strError)
        {
            Barcode_Func func = new Barcode_Func();
            return func.GetProductionInfoForPrint(strProductionNo, ref lstBarcode, ref strError);
        }

        //[WebMethod]
        //public bool GetProductionReturnInfoForPrint(string strPrdReturnNo, ref List<Barcode_Model> lstBarcode, ref string strError)
        //{
        //    Barcode_Func func = new Barcode_Func();
        //    return func.GetProductionReturnInfoForPrint(strPrdReturnNo, ref lstBarcode, ref strError);
        //}

        [WebMethod]
        public bool GetFastInInfoForPrint(Barcode_Model TaskInfo, ref  List<Barcode_Model> lstBarcode, ref string strError)
        {
            Barcode_Func func = new Barcode_Func();
            return func.GetFastInInfoForPrint(TaskInfo, ref lstBarcode, ref strError);
        }

        [WebMethod]
        public bool SaveOutBarcode(ref Barcode_Model model, UserInfo user, ref string strError)
        {
            Barcode_Func func = new Barcode_Func();
            return func.SaveOutBarcode(ref model, user, ref strError);
        }

        [WebMethod]
        public bool PrintQuality(DeliveryReceive_Model deliveryMdl, UserInfo userModel, ref string strErrMsg)
        {
            ReceiveGoods_Func func = new ReceiveGoods_Func();
            return func.PrintQuality(deliveryMdl, userModel, ref strErrMsg);
        }
        [WebMethod]
        public bool PrintBarcode(Barcode_Model barcodeModel, UserInfo user, ref string strErrMsg)
        {
            Barcode_Func func = new Barcode_Func();
            return func.PrintBarcode(barcodeModel, user, ref strErrMsg);
        }

        [WebMethod]
        public bool GetPrintRecordListByPage(ref List<Barcode_Model> modelList, Barcode_Model model, ref DividPage page, UserInfo user, ref string strError)
        {
            PrintRecord_Func func = new PrintRecord_Func();
            return func.GetPrintRecordListByPage(ref modelList, model, ref page, user, ref strError);
        }

        [WebMethod]
        public bool GetStockBarcodeListByPage(ref List<Barcode_Model> modelList, Barcode_Model model, ref DividPage page, UserInfo user, ref string strError)
        {
            Barcode_Func func = new Barcode_Func();
            return func.GetStockBarcodeListByPage(ref modelList, model, ref page, user, ref strError);
        }

        #endregion

        #region 盘点管理


        [WebMethod]
        public bool SaveCheck(ref CheckInfo model, UserInfo user, ref string strError)
        {
            Check_Func func = new Check_Func();
            return func.SaveCheck(ref model, user, ref strError);
        }

        [WebMethod]
        public bool DeleteCheckByID(CheckInfo model, UserInfo user, ref string strError)
        {
            Check_Func func = new Check_Func();
            return func.DeleteCheckByID(model, user, ref strError);
        }

        [WebMethod]
        public bool GetCheckByID(ref CheckInfo model, UserInfo user, ref string strError)
        {
            Check_Func func = new Check_Func();
            return func.GetCheckByID(ref model, user, ref strError);
        }

        [WebMethod]
        public bool GetCheckListByPage(ref List<CheckInfo> modelList, CheckInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            Check_Func func = new Check_Func();
            return func.GetCheckListByPage(ref modelList, model, ref page, user, ref strError);
        }

        [WebMethod]
        public bool GetCheckDetailsByID(ref CheckDetailsInfo model, UserInfo user, ref string strError)
        {
            CheckDetails_Func func = new CheckDetails_Func();
            return func.GetCheckDetailsByID(ref model, user, ref strError);
        }

        [WebMethod]
        public bool GetCheckDetailsListByPage(ref List<CheckDetailsInfo> modelList, CheckDetailsInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            CheckDetails_Func func = new CheckDetails_Func();
            return func.GetCheckDetailsListByPage(ref modelList, model, ref page, user, ref strError);
        }

        [WebMethod]
        public bool GetCheckDetailsSelectListByPage(ref List<CheckDetailsInfo> modelList, CheckDetailsInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            CheckDetails_Func func = new CheckDetails_Func();
            return func.GetCheckDetailsSelectListByPage(ref modelList, model, ref page, user, ref strError);
        }

        [WebMethod]
        public bool SaveCheckTrans(ref CheckTransInfo model, UserInfo user, ref string strError)
        {
            CheckTrans_Func func = new CheckTrans_Func();
            return func.SaveCheckTrans(ref model, user, ref strError);
        }

        [WebMethod]
        public string GetCheckListForAndroid(string strUserJson)
        {
            Check_Func func = new Check_Func();
            return func.GetCheckListForAndroid(strUserJson);
        }

        [WebMethod]
        public string SaveCheckTransScan(int checkID, string strBarcode, string strAreaNo, string strUserJson,bool isTray)
        {
            CheckTrans_Func func = new CheckTrans_Func();
            return func.SaveCheckTransScan(checkID, strBarcode, strAreaNo, strUserJson, isTray);

        }

        [WebMethod]
        public bool SaveCheckOmitAdd(string strBarcode, AreaInfo areaInfo, ref string strErrMsg)
        {
            BLL.Stock.Stock_Func bf = new Stock_Func();
            return bf.SaveCheckOmitAdd(strBarcode, areaInfo, ref strErrMsg);
        }

        [WebMethod]
        public string SaveCheckTransForAndroid(string strCheckTransJson, string strAreaJson, string strUserJson)
        {
            CheckTrans_Func func = new CheckTrans_Func();
            return func.SaveCheckTransForAndroid(strCheckTransJson, strAreaJson, strUserJson);
        }

        [WebMethod]
        public string SaveCheckTransListForAndroid(string strCheckTransHeaderJson, string strUserJson)
        {
            CheckTrans_Func func = new CheckTrans_Func();
            return func.SaveCheckTransListForAndroid(strCheckTransHeaderJson, strUserJson);
        }

        [WebMethod]
        public bool GetCheckTransListByPage(ref List<CheckTransInfo> modelList, CheckTransInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            CheckTrans_Func func = new CheckTrans_Func();
            return func.GetCheckTransListByPage(ref modelList, model, ref page, user, ref strError);
        }

        [WebMethod]
        public bool UpdateCheckStatusByID(CheckInfo model, UserInfo user, ref string strError)
        {
            Check_Func func = new Check_Func();
            return func.UpdateCheckStatusByID(model, user, ref strError);
        }

        [WebMethod]
        public string GetCheckScanTransForAndroid(string strCheckJson, string strUserJson)
        {
            Check_Func func = new Check_Func();
            return func.GetCheckScanTransForAndroid(strCheckJson, strUserJson);
        }

        [WebMethod]
        public bool ProfitLossAnalyse(ref List<CheckDetailsInfo> modelList, CheckDetailsInfo model, UserInfo user, ref string strError)
        {
            CheckDetails_Func func = new CheckDetails_Func();
            return func.ProfitLossAnalyse(ref modelList, model, user, ref strError);
        }

        [WebMethod]
        public bool VerifyCheckStockChange(CheckInfo model, UserInfo user, ref string strError)
        {
            Check_Func func = new Check_Func();
            return func.VerifyCheckStockChange(model, user, ref strError);
        }

        [WebMethod]
        public bool ProfitLossDeal(CheckInfo model, UserInfo user, ref string strError)
        {
            Check_Func func = new Check_Func();
            return func.ProfitLossDeal(model, user, ref strError);
        }

        [WebMethod]
        public bool GetCheckAnalyseListByPage(ref List<CheckDetailsInfo> modelList, CheckDetailsInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            CheckDetails_Func func = new CheckDetails_Func();
            return func.GetCheckAnalyseListByPage(ref modelList, model, ref page, user, ref strError);
        }

        [WebMethod]
        public string GetBarcodeInfoForAndroid(string strBarcode)
        {
            Barcode_Func func = new Barcode_Func();
            return func.GetBarcodeInfoForAndroid(strBarcode);
        }

        [WebMethod]
        public Barcode_Model GetCheckBarcodeInfo(string strBarcode,ref string strError)
        {
            Barcode_Func func = new Barcode_Func();
            return func.GetCheckOmitAddBarcode(strBarcode,false,ref strError);
        }

        [WebMethod]
        public string GetCheckAreaForAndroid(int checkID, string strAreaNo, string strUserJson)
        {
            Area_Func func = new Area_Func();
            return func.GetCheckAreaForAndroid(checkID, strAreaNo, strUserJson);
        }

        [WebMethod]
        public string GetCheckBarcodeForAndroid(int checkID, string strBarcode,bool isTray)
        {
            Barcode_Func func = new Barcode_Func();
            return func.GetCheckBarcodeForAndroid(checkID, strBarcode, isTray);
        }

        [WebMethod]
        public bool GetProfitLossListByPage(ref List<ProfitLossInfo> modelList, ProfitLossInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            ProfitLoss_Func func = new ProfitLoss_Func();
            return func.GetProfitLossListByPage(ref modelList, model, ref page, user, ref strError);
        }

        [WebMethod]
        public bool ReCheckByCheck(CheckInfo model, ref CheckInfo reCheck, UserInfo user, ref string strError)
        {
            Check_Func func = new Check_Func();
            return func.ReCheckByCheck(model, ref reCheck, user, ref strError);
        }

        #endregion


        [WebMethod]
        public bool GetDeliveryInfoToSRM(ref DeliveryReceive_Model DeliveryModel, UserInfo userModel, ref string strErrMsg)
        {
            BLL.DeliveryReceive.DeliveryReceive_Func DRF = new DeliveryReceive_Func();
            return DRF.GetDeliveryInfoToSRM(ref DeliveryModel, userModel, ref strErrMsg);
        }

        [WebMethod]
        public bool GetOutBarcodeListByBarcode(Barcode_Model param, ref List<Barcode_Model> lstOutBarcode, ref string strError)
        {
            Barcode_Func BFC = new Barcode_Func();
            return BFC.GetOutBarcodeListByBarcode(param, ref lstOutBarcode, ref strError);
        }

        [WebMethod]
        public bool GetOutBarcodeListByPage(ref List<Barcode_Model> modelList, Barcode_Model model, ref DividPage page, UserInfo user, ref string strError)
        {
            Barcode_Func BFC = new Barcode_Func();
            return BFC.GetOutBarcodeListByPage(ref modelList, model, ref page, user, ref strError);
        }

        [WebMethod]
        public bool CreateBarcodeInfo(Barcode_Model barcodeModel, ref List<Barcode_Model> lstBarcode, ref string strErrMsg)
        {
            Barcode_Func BFC = new Barcode_Func();
            return BFC.CreateBarcodeInfo(barcodeModel, ref lstBarcode, ref strErrMsg);
        }

        [WebMethod]
        public bool GetOutBarcodeInfo(Barcode_Model barcodeModel, ref List<Barcode_Model> lstBarcode)
        {
            Barcode_Func barcode_func = new Barcode_Func();
            return barcode_func.GetOutBarcodeInfo(barcodeModel, ref lstBarcode);
        }
        [WebMethod]
        public bool GetOutbarcodeByID(ref Barcode_Model model, UserInfo user, ref string strError)
        {
            Barcode_Func barcode_func = new Barcode_Func();
            return barcode_func.GetOutbarcodeByID(ref model, user, ref strError);
        }
        [WebMethod]
        public bool GetInnerBarcodeInfoByOutBarcodeId(Barcode_Model barcodeModel, ref Barcode_Model innerBarcode)
        {
            Barcode_Func barcode_func = new Barcode_Func();
            return barcode_func.GetInnerBarcodeByOutBarcodeId(barcodeModel, ref innerBarcode);
        }

        #region 组托
        [WebMethod]
        public bool GetTrayInfoByTrayID(Barcode_Model barcodeModel, ref Tray_Model tray)
        {
            Tray_Func tray_func = new Tray_Func();
            return tray_func.GetTrayInfoByTrayID(barcodeModel, ref tray);
        }

        [WebMethod]
        public bool UpdateTrayInfo(string BarcodeInfo)
        {
            Tray_Func tray_func = new Tray_Func();
            return tray_func.UpdateTrayInfo(BarcodeInfo);
        }

        [WebMethod]
        public string UpdateTrayInfoForOut(string BarcodeInfo)
        {
            Tray_Func tray_func = new Tray_Func();
            return tray_func.UpdateTrayInfoPro(BarcodeInfo);
        }

        [WebMethod]
        public bool UpdateTrayInfoTest(Barcode_Model BarcodeModel)
        {
            Tray_Func tray_func = new Tray_Func();
            return tray_func.UpdateTrayInfo(BarcodeModel);
        }
        #endregion

        #region 根据送货单号获取信息
        [WebMethod(Description = "根据送货单获取数据，android用")]
        public string GetDeliveryInfoForAndroid(string strDeliveryNo, string strUserJson)
        {
            DeliveryReceive_Func drFunc = new DeliveryReceive_Func();
            return drFunc.GetDeliveryInfoForAndroid(strDeliveryNo, strUserJson);
        }
        #endregion


        [WebMethod]
        public bool GetInnerBarcodeListByOutBarcodeList(List<Barcode_Model> lstBarcode, ref List<BLL.PrintBarcode.InnerBarcode_Model> lstInnerBarcode)
        {
            Barcode_Func barcode_func = new Barcode_Func();
            return barcode_func.GetInnerBarcodeListByOutBarcodeList(lstBarcode, ref lstInnerBarcode);
        }

        [WebMethod]
        public string GetBarCodeInfo(string strBarCode)
        {
            ReceiveGoods_Func DRF = new ReceiveGoods_Func();
            return DRF.GetBarCodeInfo(strBarCode);
        }

        [WebMethod]
        public string GetBarCodeInfoForRefuseArrival(string strBarCode)
        {
            ReceiveGoods_Func DRF = new ReceiveGoods_Func();
            return DRF.GetBarCodeInfoForRefuseArrival(strBarCode);
        }


        [WebMethod]
        public string GetWarehouseInfo(string WarehouseNo)
        {

            Warehouse_Func DRF = new Warehouse_Func();
            return DRF.GetWarehouseBycWhCode(WarehouseNo);
        }

        #region 读取生产退料信息
        //[WebMethod]
        //public string GetProductionReturnInfoForSAP(string strPrdReturnNo)
        //{
        //    JXBLL.ProductionReturn.ProductionReturn_Func PRF = new JXBLL.ProductionReturn.ProductionReturn_Func();
        //    return PRF.GetProductionReturnInfoForSAP(strPrdReturnNo);
        //}

        #endregion

        #region 读取生产订单信息
        //[WebMethod]
        //public string GetProductionInfoForSAP(string strProductionNo)
        //{
        //    JXBLL.Production.Production_Func PF = new JXBLL.Production.Production_Func();
        //    return PF.GetProductionInfoForSAP(strProductionNo);
        //}

        #endregion

        #region 收货过账
        [WebMethod]
        public string PostReceiveGoodsInfo(string strReceiveJson, string strUserJson)
        {
            BLL.ReceiveGoods.ReceiveGoods_Func RF = new ReceiveGoods_Func();
            return RF.PostReceiveGoodsInfo(strReceiveJson, strUserJson);
        }
        [WebMethod]
        public string ResetBarCode(string strArraySerialNo, string strUserJson)
        {
            Barcode_Func UF = new Barcode_Func();
            return UF.ResetBarCode(strArraySerialNo, strUserJson);
        }

        #endregion

        #region 上架和质检
        [WebMethod]
        public string GetTaskInfo(string strUserJson, string strBarCode)
        {
            BLL.Task.Task_Func TF = new BLL.Task.Task_Func();
            return TF.GetTaskInfo(strUserJson, strBarCode);
        }

        [WebMethod]
        public string GetQulitiedTaskDetailsInfo(string strTaskNo)
        {
            BLL.Task.Task_Func TF = new BLL.Task.Task_Func();
            return TF.GetQulitiedTaskDetailsInfo(strTaskNo);
        }

        [WebMethod]
        public string GetProductTransTaskInfo(string strUserJson, string strBarCode)
        {
            BLL.Task.Task_Func TF = new BLL.Task.Task_Func();
            return TF.GetProductTransTaskInfo(strUserJson, strBarCode);
        }

        //[WebMethod]
        //public string GetUnQulitiedDetailsInfo(string strMaterialDoc)
        //{
        //    JXBLL.Task.Task_Func TF = new JXBLL.Task.Task_Func();
        //    return TF.GetUnQulitiedDetailsInfo(strMaterialDoc);
        //}

        [WebMethod]
        public string CreateQuanlityReturnVoucher(string strQuanlityJson, string strUserJson)
        {
            BLL.Task.Task_Func TF = new BLL.Task.Task_Func();
            return TF.CreateQuanlityReturnVoucher(strQuanlityJson, strUserJson);
        }

        [WebMethod]
        public string InStock(string strInStockInfoJson, string strUserJson, string strAreaNo)
        {
            BLL.Task.Task_Func TF = new BLL.Task.Task_Func();
            return TF.InStock(strInStockInfoJson, strUserJson, strAreaNo);
        }
        [WebMethod]
        public string CheckBarCodeIsInStock(string strSerialNo)
        {
            BLL.Task.Task_Func TF = new BLL.Task.Task_Func();
            return TF.CheckBarCodeIsInStock(strSerialNo);
        }

        [WebMethod]
        public string LockTaskOperUser(string strTaskDetailsJson, string strUserJson)
        {
            BLL.Task.Task_Func TF = new BLL.Task.Task_Func();
            return TF.LockTaskOperUser(strTaskDetailsJson, strUserJson);
        }

        [WebMethod]
        public string UnLockTaskOperUser(string strInStockInfoJson, string strUserJson)
        {
            BLL.Task.Task_Func TF = new Task_Func();
            return TF.UnLockTaskOperUser(strInStockInfoJson, strUserJson);
        }


        [WebMethod]
        public string CheckArea(string strAreaNo, string strUserJson)
        {
            BLL.Task.Task_Func TF = new BLL.Task.Task_Func();
            return TF.CheckArea(strAreaNo, strUserJson);
        }


        [WebMethod]
        public bool SaveQualityDetailInfo(DeliveryReceive_Model DeliveryModel, UserInfo userModel, ref string strErrMsg)
        {
            BLL.ReceiveGoods.ReceiveGoods_Func RGF = new ReceiveGoods_Func();
            return RGF.SaveQualityDetailInfo(DeliveryModel, userModel, ref strErrMsg);
        }

        //[WebMethod]
        //public string PostTaskInfoToSAP(string strTaskID, string strStorageLoc, string strUserJson)
        //{
        //    JXBLL.Task.Task_Func TF = new Task_Func();
        //    return TF.PostTaskInfoToSAP(strTaskID, strStorageLoc, strUserJson);
        //}
        #endregion

        [WebMethod]
        public bool GetQualityListByPage(ref List<DeliveryReceive_Model> modelList, DeliveryReceive_Model model, ref DividPage page, UserInfo user, ref string strError)
        {
            ReceiveGoods_Func RGF = new ReceiveGoods_Func();
            return RGF.GetQualityListByPage(ref modelList, model, ref page, user, ref strError);
        }

        [WebMethod]
        public bool GetQualityDetailInfo(DeliveryReceive_Model DeliveryInfo, ref List<DeliveryReceiveDetail_Model> lstDeliveryDetailInfo, UserInfo userModel, ref string strErrMsg)
        {
            ReceiveGoods_Func RGF = new ReceiveGoods_Func();
            return RGF.GetQualityDetailInfo(DeliveryInfo, ref lstDeliveryDetailInfo, userModel, ref strErrMsg);
        }

        [WebMethod]
        public bool GetQualityDetailListByPage(ref List<DeliveryReceiveDetail_Model> modelList, DeliveryReceiveDetail_Model model, ref DividPage page, UserInfo user, ref string strError)
        {
            ReceiveGoods_Func RGF = new ReceiveGoods_Func();
            return RGF.GetQualityDetailListByPage(ref modelList, model, ref page, user, ref strError);
        }

        [WebMethod]
        public bool GetQualityExportListByPage(ref List<QuanlityExportInfo> modelList, QuanlityExportInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            QualityExport_Func func = new QualityExport_Func();
            return func.GetQualityExportListByPage(ref modelList, model, ref page, user, ref strError);
        }

        #region 获取SAP物料信息
        //[WebMethod]
        //public bool GetMaterialInfoForSAP(string strMaterialNo, ref JXBLL.Task.TaskDetails_Model taskDetailsModel, ref string strErrMsg)
        //{
        //    JXBLL.Task.Task_Func TF = new JXBLL.Task.Task_Func();
        //    return TF.GetMaterialInfoForSAP(strMaterialNo, ref taskDetailsModel, ref strErrMsg);
        //}
        #endregion

        #region 库存查询
        [WebMethod]
        public string GetStockInfo(string strBarcodeOrMaterialNo, string strUserJson)
        {
            BLL.Stock.Stock_Func SF = new BLL.Stock.Stock_Func();
            return SF.GetStockInfoByMaterialNo(strBarcodeOrMaterialNo, strUserJson);

        }

        [WebMethod]
        public string GetStockInfoDistr(string strVoucherNo, string strArrayMaterialNo, string strUserJson)
        {
            BLL.Stock.Stock_Func SF = new BLL.Stock.Stock_Func();
            return SF.GetStockInfoByArrayMaterialNo(strVoucherNo, strArrayMaterialNo, strUserJson);
        }

        [WebMethod]
        public string GetStockInfoByBarcode(string strBarCode, string strUserJson)
        {
            BLL.Stock.Stock_Func SF = new BLL.Stock.Stock_Func();
            return SF.GetStockInfoBySerialNo(strBarCode, strUserJson);
        }

        [WebMethod]
        public string GetStockByAreaNo(string strAreaNo, string strUserJson)
        {
            BLL.Stock.Stock_Func SF = new BLL.Stock.Stock_Func();
            return SF.GetStockByAreaNo(strAreaNo, strUserJson);
        }

        #endregion

        #region 获取PO明细
        //[WebMethod]
        //public bool GetPOInfoForSAP(string strPONo, ref DeliveryReceive_Model DelivryModel, ref string strErrMsg)
        //{
        //    DeliveryReceive_Func DRF = new DeliveryReceive_Func();
        //    return DRF.GetPOInfoForSAP(strPONo, ref DelivryModel, ref strErrMsg);
        //}
        #endregion

        #region 根据工厂获取库存地点
        //[WebMethod]
        //public bool GetStorageLocByPlantForSAP(string strPlant, ref List<StorageLoc_Model> lstStorage, ref string strErrMsg)
        //{
        //    JXBLL.StorageLoc.StorageLoc_Func SF = new StorageLoc_Func();
        //    return SF.GetStorageLocByPlantForSAP(strPlant, ref lstStorage, ref strErrMsg);
        //}

        //[WebMethod]
        //public string GetStorageLocByPlantForSAPToAndroid(string strPlant)
        //{
        //    JXBLL.StorageLoc.StorageLoc_Func SF = new StorageLoc_Func();
        //    return SF.GetStorageLocByPlantForSAPToAndroid(strPlant);
        //}
        #endregion

        #region 获取供应商信息
        [WebMethod]
        public bool GetSupplierInfoForU8(ref Supplier_Model SupplierInfo, ref string strErrMsg)
        {
            BLL.Supplier.Supplier_Func SF = new Supplier_Func();
            return SF.GetSupplierInfoForU8(ref SupplierInfo, ref strErrMsg);
        }
        #endregion

        #region 外协获取和过账
        [WebMethod]
        public bool GetOutSideByDeliveryToSRM(ref DeliveryReceive_Model DeliveryModel, UserInfo userModel, ref string strErrMsg)
        {
            BLL.OutSideReceive.OutSideReceive_Func OSRF = new BLL.OutSideReceive.OutSideReceive_Func();
            return OSRF.GetOutSideByDeliveryToSRM(ref DeliveryModel, userModel, ref strErrMsg);
        }
        //[WebMethod]
        //public bool PostOutSideByDeliveryToSAP(ref DeliveryReceive_Model DeliveryInfo, UserInfo userModel, ref string strErrMsg)
        //{
        //    JXBLL.OutSideReceive.OutSideReceive_Func OSRF = new JXBLL.OutSideReceive.OutSideReceive_Func();
        //    return OSRF.PostOutSideByDeliveryToSAP(ref DeliveryInfo, userModel, ref strErrMsg);
        //}

        //[WebMethod]
        //public bool PostOutSideByDeliveryAndPOToSAP(ref DeliveryReceive_Model DeliveryInfo, UserInfo userModel, ref string strErrMsg)
        //{
        //    JXBLL.OutSideReceive.OutSideReceive_Func OSRF = new JXBLL.OutSideReceive.OutSideReceive_Func();
        //    return OSRF.PostOutSideByDeliveryAndPOToSAP(ref DeliveryInfo, userModel, ref strErrMsg);
        //}
        #endregion

        #region 出库领料单
        //[WebMethod]
        //public bool GetOutStockInfoForSAP(ref OutStock_Model outStockInfo, UserInfo userModel, ref string strErrMsg) 
        //{
        //    JXBLL.OutStock.OutStock_Func OSF = new JXBLL.OutStock.OutStock_Func();
        //    return OSF.GetOutStockInfoForSAP(ref outStockInfo, userModel, ref strErrMsg);
        //}

        public bool GetOutStockDetailsInfo(ref OutStockDetails_Model lstOutStockDetails, ref string strErrMsg) 
        {
            return true;
        }
        #endregion

        #region 测试用
        [WebMethod]
        public bool CreateShelveTaskTest(string vouchcode, string vouchtype, string cwhcode, UserInfo userModel, ref string strTaskNo, ref string strErrMsg)
        {
            //ReceiveGoods_DB rdb = new ReceiveGoods_DB();
            //return rdb.CreateShelveTask(vouchcode, vouchtype, cwhcode, userModel, ref strTaskNo, ref strErrMsg);

            OutStock_DB osb = new OutStock_DB();
            return osb.CreateUnShelveTask(vouchcode, vouchtype, cwhcode, userModel, ref strTaskNo, ref strErrMsg);

        }

        //[WebMethod]
        //public bool PostReceiveUnQualityReturnToSAP(ref DeliveryReceive_Model DeliveryInfo, UserInfo userModel, ref string strErrMsg)
        //{
        //    JXBLL.TEST.TestFunc TF = new JXBLL.TEST.TestFunc();
        //    return TF.PostReceiveUnQualityReturnToSAP(ref DeliveryInfo, userModel, ref strErrMsg);
        //}

        [WebMethod]
        public bool WriteLog(string strLog)
        {
            BLL.TOOL.WriteLogMethod.WriteLog(strLog);
            return true;
        }
        #endregion
        [WebMethod]
        public string TestMaterialOuterLabel(MaterialOuterLabel model, ref string strError)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.TestMaterialOuterLabel(model, ref strError);
        }
        [WebMethod]
        public string TestMaterialInnerLabel(MaterialInnerLabel model, ref string strError)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.TestMaterialInnerLabel(model, ref strError);
        }
        [WebMethod]
        public string TestProductLabel(ProductLabel_Model model, ref string strError)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.TestProductLabel(model,ref strError);
        }
        [WebMethod]
        public bool CheckSerialNo(string SerialNo, string BatchNo, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.CheckSerialNo(SerialNo, BatchNo, ref strErrMsg);
        }
        [WebMethod]
        public bool CreateInnerProductBarcode(ProductLabel_Model labelModel, int qty, ref List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.CreateInnerProductBarcode(labelModel, qty, ref label_lst, ref strErrMsg);
        }
        [WebMethod]
        public bool CreateOuterProductBarcode(ProductLabel_Model labelModel, int qty, ref List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.CreateOuterProductBarcode(labelModel, qty, ref label_lst, ref strErrMsg);
        }
        [WebMethod]
        public bool ImportStock(List<Stock_Model> dt, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.ImportStock(dt, ref strErrMsg);
        }
        [WebMethod]
        public bool RemoveStock(List<Stock_Model> dt, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.RemoveStock(dt, ref strErrMsg);
        }
        [WebMethod]
        public bool CreateInitialProductBarcode(BLL.Stock.Stock_Model stockmodel, ProductLabel_Model labelModel, int qty, ref List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.CreateInitialProductBarcode(stockmodel, labelModel, qty, ref label_lst, ref strErrMsg);
        }
        [WebMethod]
        public bool GetplantnoForPrint(string cInvCode, ref string plantno, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.GetplantnoForPrint(cInvCode, ref plantno, ref strErrMsg);
        }
        [WebMethod]
        public bool GetImportPrintStockByPage(ref List<BLL.PrintBarcode.Barcode_Func.ImportPrint_Model> modelList, BLL.Stock.Stock_Model model, ref DividPage page, UserInfo user, ref string strError)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.GetImportPrintStockByPage(ref modelList, model, ref page, user, ref strError);
        }
        [WebMethod]
        public System.DateTime GetSysTime()
        {
            return System.DateTime.Today;
        }
        [WebMethod]
        public bool RePrintByBarcode(bool isBunding, string serialno, int qty, ref List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.RePrintByBarcode(isBunding, serialno, qty, ref label_lst, ref strErrMsg);
        }
        [WebMethod]
        public bool RePrintChangeSave(List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.RePrintChangeSave(label_lst, ref strErrMsg);
        }
        [WebMethod]
        public bool PrintDelete(List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.PrintDelete(label_lst, ref strErrMsg);
        }
        [WebMethod]
        public bool CreateInnerProductBarcodeForRead(ProductLabel_Model labelModel, int qty, ref List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.CreateInnerProductBarcodeForRead(labelModel, qty, ref label_lst, ref strErrMsg);
        }
        [WebMethod]
        public bool SaveInnerProductBarcodeForRead(List<ProductLabel_Model> label_lst, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.SaveInnerProductBarcodeForRead(label_lst, ref strErrMsg);
        }
        [WebMethod]
        public bool CreateeOuterProductBarcodeForRead(ProductLabel_Model labelModel, int qty, ref List<ProductLabel_Model> label_inner, ref List<ProductLabel_Model> label_outer, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.CreateeOuterProductBarcodeForRead(labelModel, qty, ref label_inner, ref label_outer, ref strErrMsg);
        }
        [WebMethod]
        public bool SaveOuterProductBarcodeForRead(List<ProductLabel_Model> label_inner, List<ProductLabel_Model> label_outer, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.SaveOuterProductBarcodeForRead(label_inner, label_outer, ref strErrMsg);
        }
        [WebMethod]
        public bool NewCheckSerialNo(string SerialNo, int qty, string BatchNo, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.NewCheckSerialNo(SerialNo, qty, BatchNo, ref strErrMsg);
        }

        [WebMethod]
        public bool QueryPrintSerialNo(string BatchNo, ref List<string> querylist,ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.QueryPrintSerialNo(BatchNo, ref querylist, ref strErrMsg);
        }
        [WebMethod]
        public bool GetPrintedProductCount(string MoCode, string rowno, ref int qty, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.GetPrintedProductCount(MoCode, rowno, ref qty, ref strErrMsg);
        }
        [WebMethod]
        public bool QueryBarcodeDetailsReport(string barcode, string voucherno, string rowno, string Socode, string Covenantcode, string materialno, string materialdesc, string materialstd, out List<BarcodeReport_Model> lst, out string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.QueryBarcodeDetailsReport(barcode, voucherno, rowno, Socode, Covenantcode, materialno, materialdesc, materialstd, out lst, out strErrMsg);
        }
        [WebMethod]
        public bool QueryBarcodeDetailsReportRowDetail(BarcodeReport_Model row, out List<BarcodeReport_RowDetail> lst, out string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.QueryBarcodeDetailsReportRowDetail(row, out lst, out strErrMsg);
        }
        [WebMethod]
        public bool GetSaleBillVouchCodeByCustomer(string ccusname, out List<string> list, out string strErrMsg)
        {
            BLL.Stock.Stock_Func bf = new Stock_Func();
            return bf.GetSaleBillVouchCodeByCustomer(ccusname, out list, out strErrMsg);
        }
        [WebMethod]
        public bool GetSaleBillVouchByCode(string code, out SaleBillVouch_Model model, out string strErrMsg)
        {
            BLL.Stock.Stock_Func bf = new Stock_Func();
            return bf.GetSaleBillVouchByCode(code, out model, out strErrMsg);
        }
        [WebMethod]
        public bool GetOldSaleBillVouch(SaleBillDetails_Model detail, out List<SaleBillDetails_Model> list, out string strErrMsg)
        {
            BLL.Stock.Stock_Func bf = new Stock_Func();
            return bf.GetOldSaleBillVouch(detail, out list, out strErrMsg);
        }
        [WebMethod]
        public bool GetSaleBillDetailsForTrans(SaleBillDetails_Model detail, out List<SaleBillDetails_Model> list, out string strErrMsg)
        {
            BLL.Stock.Stock_Func bf = new Stock_Func();
            return bf.GetSaleBillDetailsForTrans(detail, out list, out strErrMsg);
        }
        [WebMethod]
        public bool SaveTempTrans(string creater, SaleBillDetails_Model detail, out string strErrMsg)
        {
            BLL.Stock.Stock_Func bf = new Stock_Func();
            return bf.SaveTempTrans(creater, detail, out strErrMsg);
        }
        [WebMethod]
        public bool VerifyTempTrans(SaleBillDetails_Model detail, out string strErrMsg)
        {
            BLL.Stock.Stock_Func bf = new Stock_Func();
            return bf.VerifyTempTrans(detail, out strErrMsg);
        }
        [WebMethod]
        public bool DelTempTrans(SaleBillDetails_Model detail, out string strErrMsg)
        {
            BLL.Stock.Stock_Func bf = new Stock_Func();
            return bf.DelTempTrans(detail, out strErrMsg);
        }
        [WebMethod]
        public bool GiveUpTempTrans(SaleBillDetails_Model detail, out string strErrMsg)
        {
            BLL.Stock.Stock_Func bf = new Stock_Func();
            return bf.GiveUpTempTrans(detail, out strErrMsg);
        }
        [WebMethod]
        public bool QueryTempTrans(string cinvcode, string cinvstd, string ssocode, string ssbvcode, string dsocode, string dsbvcode, out List<SaleBillDetails_Model> list, out string strErrMsg)
        {
            BLL.Stock.Stock_Func bf = new Stock_Func();
            return bf.QueryTempTrans(cinvcode, cinvstd, ssocode, ssbvcode, dsocode, dsbvcode, out list, out strErrMsg);
        }
        [WebMethod]
        public bool CreateAutomaticProductBarcode(ProductLabel_Model labelModel, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.CreateAutomaticProductBarcode(labelModel, ref strErrMsg);
        }
        [WebMethod]
        public bool QueryBarcodeTraceReport(string barcode, string voucherno, string CusName, string Socode, string Covenantcode, string materialno, string materialdesc, string materialstd, string StockOutCode, string TransMoveCode, out List<BarcodeTrace_Model> lst, out string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.QueryBarcodeTraceReport(barcode, voucherno, CusName, Socode, Covenantcode, materialno, materialdesc, materialstd, StockOutCode, TransMoveCode, out lst, out strErrMsg);
        }
        [WebMethod]
        public bool QueryBarcodeTraceReportRowDetail(BarcodeTrace_Model row, out List<BarcodeReport_RowDetail> lst, out string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.QueryBarcodeTraceReportRowDetail(row, out lst, out strErrMsg);
        }
        [WebMethod]
        public bool GetAutomaticProductByBarcode(string serialno, ref ProductLabel_Model labelModel, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.GetAutomaticProductByBarcode(serialno, ref labelModel, ref strErrMsg);
        }
        [WebMethod]
        public List<MaterialLabel_Model> GetPULstForPrint(string cpoid, string cvenabbname, string begindate, string enddate, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.GetPULstForPrint(cpoid, cvenabbname, begindate, enddate, ref strErrMsg);
        }
        [WebMethod]
        public Vendor VendorLogin(string cvencode)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.VendorLogin(cvencode);
        }
        [WebMethod]
        public List<MaterialLabel_Model> VenGetPULstForPrint(string cvencode, string cpoid, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.VenGetPULstForPrint(cvencode, cpoid, ref strErrMsg);
        }
        [WebMethod]
        public bool QueryStockSumByWHcode(string WHcode,out List<Stock_Model> list, out string strErrMsg)
        {
            BLL.Stock.Stock_Func sf = new Stock_Func();
            return sf.QueryStockSumByWHcode(WHcode, out list, out strErrMsg);
        }
        [WebMethod]
        public bool CreateMaterialBarcodeForPU(MaterialLabel_Model labelModel, int qty, string PackQty, string EndPackQty, ref List<MaterialLabel_Model> label_lst, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.CreateMaterialBarcodeForPU(labelModel, qty, PackQty, EndPackQty, ref label_lst, ref strErrMsg);
        }
        [WebMethod]
        public bool VenQueryPrintLst(string cvencode, string cpoid, string rowno, string materialno, string materialdesc, string invstd, string BarcodeExpress, ref  List<MaterialLabel_Model> list, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.VenQueryPrintLst(cvencode, cpoid, rowno, materialno, materialdesc, invstd, BarcodeExpress, ref list, ref strErrMsg);
        }
        [WebMethod]
        public bool VenQueryPrintDetails(MaterialLabel_Model model, ref  List<MaterialLabel_Model> list, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.VenQueryPrintDetails(model, ref list, ref strErrMsg);
        }
        [WebMethod]
        public bool VendorChangePW(string cvencode, string password)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.VendorChangePW(cvencode, password);
        }
        [WebMethod]
        public bool GetImportMaterialStockByPage(ref List<BLL.PrintBarcode.Barcode_Func.ImportPrint_Model> modelList, BLL.Stock.Stock_Model model, ref DividPage page, UserInfo user, ref string strError)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.GetImportMaterialStockByPage(ref modelList, model, ref page, user, ref strError);
        }
        [WebMethod]
        public bool ImportMaterialStock(List<Stock_Model> dt, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.ImportMaterialStock(dt, ref strErrMsg);
        }
        [WebMethod]
        public bool CreateInitialMaterialBarcode(Stock_Model stockmodel, MaterialLabel_Model labelModel, int qty, ref List<MaterialLabel_Model> label_lst, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.CreateInitialMaterialBarcode(stockmodel, labelModel, qty, ref label_lst, ref strErrMsg);
        }
        [WebMethod]
        public List<MaterialLabel_Model> GetOMLstForPrint(string ccode, string cvenabbname, string begindate, string enddate, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.GetOMLstForPrint(ccode, cvenabbname, begindate, enddate, ref strErrMsg);
        }
        [WebMethod]
        public bool CreateMaterialBarcodeForOM(MaterialLabel_Model labelModel, int qty, string PackQty, string EndPackQty, ref List<MaterialLabel_Model> label_lst, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.CreateMaterialBarcodeForOM(labelModel, qty, PackQty, EndPackQty, ref label_lst, ref strErrMsg);
        }
        [WebMethod]
        public bool GetMaterialLabelInfo(string cinvcode, string cinvname, string cinvstd, ref MaterialLabel_Model model, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.GetMaterialLabelInfo(cinvcode, cinvname, cinvstd, ref model, ref strErrMsg);
        }
        [WebMethod]
        public bool CreateMaterialBarcodeForNull(MaterialLabel_Model labelModel, Stock_Model stmodel, int qty, string PackQty, string EndPackQty, ref List<MaterialLabel_Model> label_lst, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.CreateMaterialBarcodeForNull(labelModel, stmodel, qty, PackQty, EndPackQty, ref label_lst, ref strErrMsg);
        }

        [WebMethod]
        public bool CheckbProxyWhBycWhCode(string cWhCode, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.CheckbProxyWhBycWhCode(cWhCode, ref strErrMsg);
        }
        [WebMethod]
        public bool GetVendorByCode(string cvencode, ref Vendor vendor, ref string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.GetVendorByCode(cvencode, ref vendor, ref strErrMsg);
        }
        [WebMethod]
        public bool QueryMaterialBarcodeReport(string barcode, string voucherno, string ArrivalCode, string InCode, string OutCode, string materialno, string materialdesc, string materialstd, out List<BarcodeReport_Model> lst, out string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.QueryMaterialBarcodeReport(barcode, voucherno, ArrivalCode, InCode, OutCode, materialno, materialdesc, materialstd, out lst, out strErrMsg);
        }
        [WebMethod]
        public bool QueryMaterialBarcodeReportRowDetail(BarcodeReport_Model row, out List<BarcodeReport_RowDetail> lst, out string strErrMsg)
        {
            BLL.PrintBarcode.Barcode_Func bf = new Barcode_Func();
            return bf.QueryMaterialBarcodeReportRowDetail(row, out lst, out strErrMsg);
        }
    }
}
