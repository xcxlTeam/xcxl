using BLL.Basic.User;
using BLL.Basic.UserGroup;
using BLL.Common;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Basic.Menu
{
    public class Menu_Func
    {
        private Menu_DB _db = new Menu_DB();

        public bool ExistsMenuNo(MenuInfo model, bool bIncludeDel, UserInfo user, ref string strError)
        {
            try
            {
                return _db.ExistsMenuNo(model, bIncludeDel);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public bool SaveMenu(ref MenuInfo model, UserInfo user, ref string strError)
        {
            try
            {
                if (model.ID <= 0)
                {
                    model.Creater = user.UserNo;
                }
                else
                {
                    model.Modifyer = user.UserNo;
                }
                return _db.SaveMenu(ref model);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }


        public bool DeleteMenuByID(MenuInfo model, UserInfo user, ref string strError)
        {
            try
            {
                return _db.DeleteMenuByID(model);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }


        public bool GetMenuByID(ref MenuInfo model, UserInfo user, ref string strError)
        {
            try
            {
                using (SqlDataReader dr = _db.GetMenuByID(model))
                {
                    if (dr.Read())
                    {
                        model = (GetModelFromDataReader(dr));
                        return true;
                    }
                    else
                    {
                        strError = "找不到任何数据";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
            finally
            {
            }
        }

        public bool GetMenuNo(ref MenuInfo model, UserInfo user, ref string strError)
        {
            try
            {
                string menuNo = _db.GetMenuNo(model);
                if (string.IsNullOrEmpty(menuNo)) return false;
                model.MenuNo = menuNo;
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }


        public bool GetMenuListByPage(ref List<MenuInfo> modelList, MenuInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            if (page == null) page = new DividPage();
            List<MenuInfo> lstModel = new List<MenuInfo>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_Menu", GetFilterSql(model, user), "*", "Order By MenuNo,ID Desc"))
                {
                    while (dr.Read())
                    {
                        lstModel.Add(GetModelFromDataReader(dr));
                    }
                }

                modelList = lstModel;
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
            finally
            {
            }
        }

        private string GetFilterSql(MenuInfo model, UserInfo user)
        {
            try
            {
                string strSql = " Where ISNULL(IsDel,1) = 1 ";
                bool hadWhere = true;


                if (!string.IsNullOrEmpty(model.MenuNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " MenuNo Like '%" + model.MenuNo + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.MenuName))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " MenuName Like '%" + model.MenuName + "%' ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.Creater))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " Creater Like '%" + model.Creater + "%' ";
                    hadWhere = true;
                }

                if (model.StartTime != null)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " CreateTime >= " + model.StartTime.ToDateTime().Date.ToSqlTimeString() + " ";
                    hadWhere = true;
                }

                if (model.EndTime != null)
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " CreateTime <= " + model.EndTime.ToDateTime().AddDays(1).Date.ToSqlTimeString() + " ";
                    hadWhere = true;
                }


                return strSql;
            }
            catch
            {
                return string.Empty;
            }
        }

        internal MenuInfo GetModelFromDataReader(SqlDataReader dr)
        {
            MenuInfo model = new MenuInfo();
            model.ID = dr["ID"].ToInt32();
            model.MenuNo = dr["MenuNo"].ToDBString();
            model.MenuName = dr["MenuName"].ToDBString();
            model.MenuAbbName = dr["MenuAbbName"].ToDBString();
            model.MenuType = dr["MenuType"].ToInt32();
            model.ProjectName = dr["ProjectName"].ToDBString();
            model.IcoName = dr["IcoName"].ToDBString();
            model.SafeLevel = dr["SafeLevel"].ToInt32();
            model.IsDefault = dr["IsDefault"].ToInt32();
            model.Mnemonic = dr["Mnemonic"].ToInt32();
            model.MnemonicCode = dr["MnemonicCode"].ToDBString();
            model.NodeUrl = dr["NodeUrl"].ToDBString();
            model.NodeLevel = dr["NodeLevel"].ToInt32();
            model.NodeSort = dr["NodeSort"].ToInt32();
            model.ParentID = dr["ParentID"].ToInt32();
            model.MenuStatus = dr["MenuStatus"].ToInt32();
            model.Description = dr["Description"].ToDBString();
            model.IsDel = dr["ISDEL"].ToInt32();
            model.Creater = dr["CREATER"].ToString();
            model.CreateTime = dr["CREATETIME"].ToDateTime();
            model.Modifyer = dr["MODIFYER"].ToString();
            model.ModifyTime = dr["MODIFYTIME"].ToDateTimeNull();

            if (Common_Func.readerExists(dr, "IsChecked")) model.BIsChecked = dr["IsChecked"].ToBoolean();
            if (Common_Func.readerExists(dr, "StrMenuType")) model.StrMenuType = dr["StrMenuType"].ToDBString();
            if (Common_Func.readerExists(dr, "StrMenuStatus")) model.StrMenuStatus = dr["StrMenuStatus"].ToDBString();
            if (Common_Func.readerExists(dr, "SonQty")) model.SonQty = dr["SonQty"].ToInt32();
            

            model.BIsDefault = model.IsDefault.ToBoolean();
            model.BHaveParameter = model.MenuType == 2 && model.ProjectName.IndexOf(':') >= 0;

            return model;
        }

        public bool GetMenuListByUserGroup(ref List<MenuInfo> modelList, UserGroupInfo UserGroup, bool IncludNoCheck, UserInfo user, ref string strError)
        {
            List<MenuInfo> lstModel = new List<MenuInfo>();
            try
            {
                using (SqlDataReader dr = _db.GetMenuListByUserGroupID(UserGroup, IncludNoCheck))
                {
                    while (dr.Read())
                    {
                        lstModel.Add(GetModelFromDataReader(dr));
                    }
                }

                modelList = lstModel;
                return true;
            }
            catch (Exception ex)
            {
                strError = "获取用户组菜单权限列表失败！" + ex.Message + "\r\n" + ex.TargetSite;
                return false;
            }
            finally
            {
            }
        }

        public bool SaveUserGroupMenuToDB(MenuInfo model, UserGroupInfo UserGroup, UserInfo user, ref string strError)
        {
            try
            {
                if (UserGroup == null || UserGroup.ID <= 0)
                {
                    strError = "用户组信息不正确";
                    return false;
                }
                return _db.SaveUserGroupMenuToDB(model, UserGroup, ref strError);
            }
            catch (Exception ex)
            {
                strError = "保存用户组菜单权限失败！" + ex.Message + "\r\n" + ex.TargetSite;
                return false;
            }
        }


        public bool GetMenuListByUser(ref List<MenuInfo> modelList, UserInfo User, bool IncludNoCheck, UserInfo user, ref string strError)
        {
            List<MenuInfo> lstModel = new List<MenuInfo>();
            try
            {
                //if (User.UserType == 1)
                //{
                //    using (SqlDataReader dr = _db.GetAllMenuList(true))
                //    {
                //        while (dr.Read())
                //        {
                //            lstModel.Add(GetModelFromDataReader(dr));
                //        }
                //    }
                //}
                //else
                {
                    using (SqlDataReader dr = _db.GetMenuListByUserID(User, IncludNoCheck))
                    {
                        while (dr.Read())
                        {
                            lstModel.Add(GetModelFromDataReader(dr));
                        }
                    }
                }

                modelList = lstModel;
                return true;
            }
            catch (Exception ex)
            {
                strError = "获取用户菜单权限列表失败！" + ex.Message + "\r\n" + ex.TargetSite;
                return false;
            }
            finally
            {
            }
        }
    }
}
