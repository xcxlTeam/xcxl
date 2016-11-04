using WMS.Common;
using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WMS.Basic
{
    internal class Basic_Func
    {
        private const string pukey = "XianDa00";
        private const string pvkey = "CombaWMS";

        public static string JiaMi(string MingWen)
        {
            try
            {
                if (string.IsNullOrEmpty(MingWen))
                {
                    return string.Empty;
                }

                string strCipherText = "";
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray;
                inputByteArray = Encoding.Default.GetBytes(MingWen);
                des.Key = Encoding.Default.GetBytes(pukey);
                des.IV = Encoding.Default.GetBytes(pvkey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                StringBuilder ret = new StringBuilder();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                strCipherText = ret.ToString();
                return strCipherText;
            }
            catch
            {
                return string.Empty;
            }

        }

        public static string JieMi(string MiWen)
        {
            try
            {
                if (string.IsNullOrEmpty(MiWen))
                {
                    return string.Empty;
                }

                if (string.IsNullOrEmpty(MiWen) || MiWen.Length <= 0)
                    return null;

                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                int len;
                len = MiWen.Length / 2;
                byte[] inputByteArray = new byte[len];
                int x, i;
                for (x = 0; x < len; x++)
                {
                    i = Convert.ToInt32(MiWen.Substring(x * 2, 2), 16);
                    inputByteArray[x] = (byte)i;
                }
                des.Key = ASCIIEncoding.ASCII.GetBytes(pukey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(pvkey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Encoding.Default.GetString(ms.ToArray());
            }
            catch
            {
                return string.Empty;
            }
        }

        public static List<ComboBoxItem> GetIsOnline()
        {
            List<ComboBoxItem> lstItem = new List<ComboBoxItem>();
            lstItem.Add(new ComboBoxItem() { ID = 1, Name = "离线" });
            lstItem.Add(new ComboBoxItem() { ID = 2, Name = "在线" });
            return lstItem;
        }

        #region 用户设置

        //public static bool ExistsUserNo(UserInfo model, ref string strError)
        //{
        //    return WMSWebService.service.ExistsUserNo(model, false, Common_Var.CurrentUser, ref strError);
        //}

        public static bool SaveUser(ref UserInfo model, ref string strError)
        {
            return WMSWebService.service.SaveUser(ref model, Common_Var.CurrentUser, ref strError);
        }


        public static bool DeleteUserByID(UserInfo model, ref string strError)
        {
            return WMSWebService.service.DeleteUserByID(model, Common_Var.CurrentUser, ref strError);
        }


        public static bool GetUserByID(ref UserInfo model, ref string strError)
        {
            return WMSWebService.service.GetUserByID(ref model, Common_Var.CurrentUser, ref strError);
        }


        public static bool GetUserListByPage(ref List<UserInfo> modelList, UserInfo model, ref DividPage page, ref string strError)
        {
            return WMSWebService.service.GetUserListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }

        public static bool GetMenuListByUser(ref List<MenuInfo> menuList, UserInfo model, bool IncludNoCheck, ref string strError)
        {
            return WMSWebService.service.GetMenuListByUser(ref menuList, model, IncludNoCheck, Common_Var.CurrentUser, ref strError);
        }

        public static bool GetUserGroupListByUser(ref List<UserGroupInfo> usergroupList, UserInfo model, bool IncludNoCheck, ref string strError)
        {
            return WMSWebService.service.GetUserGroupListByUser(ref usergroupList, model, IncludNoCheck, Common_Var.CurrentUser, ref strError);
        }

        public static bool GetWarehouseListByUser(ref List<WarehouseInfo> warehouseList, UserInfo model, bool IncludNoCheck, ref string strError)
        {
            return WMSWebService.service.GetWarehouseListByUser(ref warehouseList, model, IncludNoCheck, Common_Var.CurrentUser, ref strError);
        }

        public static bool ClearLoginTime(UserInfo user, ref string strError)
        {
            return WMSWebService.service.ClearLoginTime(user, Common_Var.CurrentUser, ref strError);
        }


        #endregion

        #region 仓库设置

        //public static bool ExistsWarehouseNo(WarehouseInfo model, ref string strError)
        //{
        //    return WMSWebService.service.ExistsWarehouseNo(model, false, Common_Var.CurrentUser, ref strError);
        //}


        public static bool SaveWarehouse(ref WarehouseInfo model, ref string strError)
        {
            return WMSWebService.service.SaveWarehouse(ref model, Common_Var.CurrentUser, ref strError);
        }


        public static bool DeleteWarehouseByID(WarehouseInfo model, ref string strError)
        {
            return WMSWebService.service.DeleteWarehouseByID(model, Common_Var.CurrentUser, ref strError);
        }


        public static bool GetWarehouseByID(ref WarehouseInfo model, ref string strError)
        {
            return WMSWebService.service.GetWarehouseByID(ref model, Common_Var.CurrentUser, ref strError);
        }


        public static bool GetWarehouseListByPage(ref List<WarehouseInfo> modelList, WarehouseInfo model, ref DividPage page, ref string strError)
        {
            return WMSWebService.service.GetWarehouseListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }

        public static bool GetWarehouseList(ref List<WarehouseInfo> modelList, WarehouseInfo model, ref string strError)
        {
            return WMSWebService.service.GetWarehouseList(ref modelList, model, Common_Var.CurrentUser, ref strError);
        }
        #endregion

        #region 库区设置

        //public static bool ExistsHouseNo(HouseInfo model, ref string strError)
        //{
        //    return WMSWebService.service.ExistsHouseNo(model, false, Common_Var.CurrentUser, ref strError);
        //}


        public static bool SaveHouse(ref HouseInfo model, ref string strError)
        {
            return WMSWebService.service.SaveHouse(ref model, Common_Var.CurrentUser, ref strError);
        }


        public static bool DeleteHouseByID(HouseInfo model, ref string strError)
        {
            return WMSWebService.service.DeleteHouseByID(model, Common_Var.CurrentUser, ref strError);
        }


        public static bool GetHouseByID(ref HouseInfo model, ref string strError)
        {
            return WMSWebService.service.GetHouseByID(ref model, Common_Var.CurrentUser, ref strError);
        }


        public static bool GetHouseListByPage(ref List<HouseInfo> modelList, HouseInfo model, ref DividPage page, ref string strError)
        {
            return WMSWebService.service.GetHouseListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }

        public static bool GetHouseList(ref List<HouseInfo> modelList, HouseInfo model, ref string strError)
        {
            return WMSWebService.service.GetHouseList(ref modelList, model, Common_Var.CurrentUser, ref strError);
        }
        #endregion

        #region 货位设置

        //public static bool ExistsAreaNo(AreaInfo model, ref string strError)
        //{
        //    return WMSWebService.service.ExistsAreaNo(model, false, Common_Var.CurrentUser, ref strError);
        //}


        public static bool SaveArea(ref AreaInfo model, ref string strError)
        {
            return WMSWebService.service.SaveArea(ref model, Common_Var.CurrentUser, ref strError);
        }


        public static bool DeleteAreaByID(AreaInfo model, ref string strError)
        {
            return WMSWebService.service.DeleteAreaByID(model, Common_Var.CurrentUser, ref strError);
        }


        public static bool GetAreaByID(ref AreaInfo model, ref string strError)
        {
            return WMSWebService.service.GetAreaByID(ref model, Common_Var.CurrentUser, ref strError);
        }


        public static bool GetAreaListByPage(ref List<AreaInfo> modelList, AreaInfo model, ref DividPage page, ref string strError)
        {
            return WMSWebService.service.GetAreaListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }

        public static bool GetAreaList(ref List<AreaInfo> modelList, AreaInfo model, ref string strError)
        {
            return WMSWebService.service.GetAreaList(ref modelList, model, Common_Var.CurrentUser, ref strError);
        }
        #endregion

        #region 用户组设置

        //public static bool ExistsUserGroupNo(UserGroupInfo model, ref string strError)
        //{
        //    return WMSWebService.service.ExistsUserGroupNo(model, false, Common_Var.CurrentUser, ref strError);
        //}


        public static bool SaveUserGroup(ref UserGroupInfo model, ref string strError)
        {
            return WMSWebService.service.SaveUserGroup(ref model, Common_Var.CurrentUser, ref strError);
        }


        public static bool DeleteUserGroupByID(UserGroupInfo model, ref string strError)
        {
            return WMSWebService.service.DeleteUserGroupByID(model, Common_Var.CurrentUser, ref strError);
        }


        public static bool GetUserGroupByID(ref UserGroupInfo model, ref string strError)
        {
            return WMSWebService.service.GetUserGroupByID(ref model, Common_Var.CurrentUser, ref strError);
        }


        public static bool GetUserGroupListByPage(ref List<UserGroupInfo> modelList, UserGroupInfo model, ref DividPage page, ref string strError)
        {
            //UserGroupInfo[] modelArray = modelList.ToArray();
            //bool bResult = WMSWebService.service.GetUserGroupListByPage(ref modelArray, model, ref page, Common_Var.CurrentUser, ref strError);
            //if (bResult) modelList = modelArray.ToList();
            //return bResult;
            return WMSWebService.service.GetUserGroupListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }

        public static bool GetMenuListByUserGroup(ref List<MenuInfo> menuList, UserGroupInfo model, bool IncludNoCheck, ref string strError)
        {
            return WMSWebService.service.GetMenuListByUserGroup(ref menuList, model, IncludNoCheck, Common_Var.CurrentUser, ref strError);
        }

        public static bool SaveUserGroupMenuToDB(MenuInfo menu, UserGroupInfo model, ref string strError)
        {
            if (model == null)
            {
                strError = "获取用户组数据错误";
                return false;
            }
            return WMSWebService.service.SaveUserGroupMenuToDB(menu, model, Common_Var.CurrentUser, ref strError);
        }
        #endregion

        #region 菜单设置

        //public static bool ExistsMenuNo(MenuInfo model, ref string strError)
        //{
        //    return WMSWebService.service.ExistsMenuNo(model, false, Common_Var.CurrentUser, ref strError);
        //}


        public static bool SaveMenu(ref MenuInfo model, ref string strError)
        {
            return WMSWebService.service.SaveMenu(ref model, Common_Var.CurrentUser, ref strError);
        }


        public static bool DeleteMenuByID(MenuInfo model, ref string strError)
        {
            return WMSWebService.service.DeleteMenuByID(model, Common_Var.CurrentUser, ref strError);
        }


        public static bool GetMenuByID(ref MenuInfo model, ref string strError)
        {
            return WMSWebService.service.GetMenuByID(ref model, Common_Var.CurrentUser, ref strError);
        }


        public static bool GetMenuListByPage(ref List<MenuInfo> modelList, MenuInfo model, ref DividPage page, ref string strError)
        {
            //MenuInfo[] modelArray = modelList.ToArray();
            //bool bResult = WMSWebService.service.GetMenuListByPage(ref modelArray, model, ref page, Common_Var.CurrentUser, ref strError);
            //if (bResult) modelList = modelArray.ToList();
            //return bResult;
            return WMSWebService.service.GetMenuListByPage(ref modelList, model, ref page, Common_Var.CurrentUser, ref strError);
        }

        public static bool GetMenuNo(ref MenuInfo model, ref string strError)
        {
            return WMSWebService.service.GetMenuNo(ref model, Common_Var.CurrentUser, ref strError);
        }

        public static List<ComboBoxItem> GetParentMenuByMenu(MenuInfo menu)
        {
            return WMSWebService.service.GetParentMenuByMenu(menu);
        }
        #endregion
    }
}
