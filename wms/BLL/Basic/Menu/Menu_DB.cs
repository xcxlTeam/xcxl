using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BLL.Common;
using BLL.Basic.UserGroup;
using BLL.Basic.User;

namespace BLL.Basic.Menu
{
    class Menu_DB
    {

        private SqlParameter[] GetParameterFromModel(MenuInfo model)
        {
            int i;
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),
               
               new SqlParameter("@v_ID", model.ID.ToSqlValue()),
               new SqlParameter("@v_MenuNo", model.MenuNo.ToSqlValue()),
               new SqlParameter("@v_MenuName", model.MenuName.ToSqlValue()),
               new SqlParameter("@v_MenuAbbName", model.MenuAbbName.ToSqlValue()),
               new SqlParameter("@v_MenuType", model.MenuType.ToSqlValue()),
               new SqlParameter("@v_ProjectName", model.ProjectName.ToSqlValue()),
               new SqlParameter("@v_IcoName", model.IcoName.ToSqlValue()),
               new SqlParameter("@v_SafeLevel", model.SafeLevel.ToSqlValue()),
               new SqlParameter("@v_IsDefault", model.IsDefault.ToSqlValue()),
               new SqlParameter("@v_NodeUrl", model.NodeUrl.ToSqlValue()),
               new SqlParameter("@v_NodeLevel", model.NodeLevel.ToSqlValue()),
               new SqlParameter("@v_NodeSort", model.NodeSort.ToSqlValue()),
               new SqlParameter("@v_ParentID", model.ParentID.ToSqlValue()),
               new SqlParameter("@v_MenuStatus", model.MenuStatus.ToSqlValue()),
               new SqlParameter("@v_Description", model.Description.ToSqlValue()),
               new SqlParameter("@v_IsDel", model.IsDel.ToSqlValue()),
               new SqlParameter("@v_Creater", model.Creater.ToSqlValue()),
               new SqlParameter("@v_CreateTime", model.CreateTime.ToSqlValue()),
               new SqlParameter("@v_Modifyer", model.Modifyer.ToSqlValue()),
               new SqlParameter("@v_ModifyTime", model.ModifyTime.ToSqlValue()),
              };

            i = 0;
            param[i++].Direction = ParameterDirection.Output;
            param[i++].Direction = ParameterDirection.InputOutput;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.InputOutput;
            param[i++].Direction = ParameterDirection.Input;
            param[i++].Direction = ParameterDirection.InputOutput;

            i = 0;
            param[i++].Size = 1000;
            param[i++].Size = 18;
            param[i++].Size = 20;
            param[i++].Size = 50;
            param[i++].Size = 50;
            param[i++].Size = 18;
            param[i++].Size = 50;
            param[i++].Size = 50;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 50;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 18;
            param[i++].Size = 200;
            param[i++].Size = 18;
            param[i++].Size = 50;
            param[i++].Size = 30;
            param[i++].Size = 50;
            param[i++].Size = 30;

            return param;
        }



        public bool ExistsMenuNo(MenuInfo model, bool bIncludeDel)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),
               
               new SqlParameter("@v_UserNo", model.MenuNo.ToSqlValue()),
               new SqlParameter("@IncludeDel", bIncludeDel.ToSqlValue()),
            };
            param[0].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_ExistsMenuNo", param);

            string ErrorMsg = param[0].Value.ToDBString();
            if (ErrorMsg.StartsWith("执行错误"))
            {
                throw new Exception(ErrorMsg);
            }
            else
            {
                return string.IsNullOrEmpty(ErrorMsg);
            }
        }

        public bool SaveMenu(ref MenuInfo model)
        {
            SqlParameter[] param = GetParameterFromModel(model);

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_SaveMenu", param);

            string ErrorMsg = param[0].Value.ToDBString();
            if (ErrorMsg.StartsWith("执行错误"))
            {
                throw new Exception(ErrorMsg);
            }
            else
            {
                model.ID = param[1].Value.ToInt32();
                model.CreateTime = param[param.Length - 3].Value.ToDateTime();
                model.ModifyTime = param[param.Length - 1].Value.ToDateTimeNull();
                return true;
            }
        }


        public bool DeleteMenuByID(MenuInfo model)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),

               new SqlParameter("@v_ID", model.ID.ToSqlValue()),
               
            };
            param[0].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_DeleteMenuByID", param);

            string ErrorMsg = param[0].Value.ToDBString();
            if (ErrorMsg.StartsWith("执行错误"))
            {
                throw new Exception(ErrorMsg);
            }
            else
            {
                return true;
            }
        }


        public SqlDataReader GetMenuByID(MenuInfo model)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM V_Menu WHERE ID = {0}", model.ID);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }

        public string GetMenuNo(MenuInfo model)
        {
            string strSql = string.Empty;
            if (model.ID <= 0) strSql = "SELECT CONVERT(nvarchar,CONVERT(decimal(20,0),(ISNULL(MAX(MENUNO),10000000000000000000)))+ 1) FROM T_MENU";
            else strSql = string.Format("SELECT menuno FROM T_Menu WHERE ID = {0}", model.ID);

            object o;
            o = OperationSql.ExecuteScalar(CommandType.Text, strSql, null);
            return o.ToDBString();
        }

        internal SqlDataReader GetMenuListByUserGroupID(UserGroupInfo UserGroup, bool IncludNoCheck)
        {
            string strSql = string.Empty;
            if (UserGroup.ID >= 1)
            {
                strSql = string.Format("SELECT DISTINCT 2 AS IsChecked,T_Menu.* FROM T_Menu WHERE ISDEL <> 2 AND ID IN (SELECT MenuID FROM T_GroupWithMenu WHERE GroupID = {0}) ", UserGroup.ID);
                if (IncludNoCheck) strSql += string.Format("UNION SELECT DISTINCT 1 AS IsChecked,T_Menu.* FROM T_Menu WHERE ISDEL <> 2 AND ID NOT IN (SELECT MenuID FROM T_GroupWithMenu WHERE GroupID = {0}) ", UserGroup.ID);
                strSql = string.Format("SELECT * FROM ({0}) T ORDER BY NodeLevel, NodeSort, ID ", strSql);
            }
            else
            {
                if (IncludNoCheck) strSql = "SELECT DISTINCT 1 AS IsChecked,T_Menu.* FROM T_Menu WHERE ISDEL <> 2 ORDER BY NodeUrl, NodeSort, ID ";
                else strSql = "SELECT DISTINCT 2 AS IsChecked,T_Menu.* FROM T_Menu WHERE 1 = 2";
            }
            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }

        internal SqlDataReader GetParentSelectMenu(MenuInfo model)
        {
            string strSql = string.Empty;
            if (model.MenuType <= 2)
            {
                strSql = string.Format("SELECT ID, MenuName FROM (SELECT * FROM (SELECT 0 as ID, TO_CHAR('根节点') as MenuName, 0 as MenuType, 1 as NodeLevel FROM DUAL) UNION SELECT ID, TO_CHAR(MenuName) MenuName, MenuType, NodeLevel FROM T_MENU where ISDEL <> 2 ) T where menutype = {0} or (menutype = {1} and nodelevel < {2}) ", model.MenuType - 1, model.MenuType, model.NodeLevel);
            }
            else if (model.MenuType == 3)
            {
                strSql = string.Format("SELECT ID, MenuName FROM (SELECT * FROM (SELECT 0 as ID, TO_CHAR('根节点') as MenuName, 0 as MenuType, 1 as NodeLevel FROM DUAL) UNION SELECT ID, TO_CHAR(MenuName) MenuName, MenuType, NodeLevel FROM T_MENU where ISDEL <> 2 ) T where menutype = 2) ");
            }
            else
            {
                strSql = "SELECT 0 as ID, TO_CHAR('根节点') as MenuName FROM DUAL ";
            }
            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }

        internal bool SaveUserGroupMenuToDB(MenuInfo model, UserGroupInfo UserGroup, ref string strError)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ErrorMsg",SqlDbType.NVarChar,1000),
               
               new SqlParameter("@v_MenuID", model.ID.ToSqlValue()),
               new SqlParameter("@v_UserGroupID", UserGroup.ID.ToSqlValue()),
               new SqlParameter("@v_IsChecked", model.BIsChecked.ToSqlValue()),
            };
            param[0].Direction = ParameterDirection.Output;

            OperationSql.ExecuteNonQuery2(CommandType.StoredProcedure, "Proc_NewSaveGroupWithMenu", param);

            string ErrorMsg = param[0].Value.ToDBString();
            if (ErrorMsg.StartsWith("执行错误"))
            {
                throw new Exception(ErrorMsg);
            }
            else
            {
                return string.IsNullOrEmpty(ErrorMsg);
            }

        }

        internal SqlDataReader GetMenuListByUserID(UserInfo User, bool IncludNoCheck)
        {
            string strSql = string.Empty;
            if (User.ID >= 1)
            {
                strSql = string.Format("SELECT DISTINCT 2 AS IsChecked,T_Menu.* from T_Menu WHERE ISDEL <> 2 AND MenuStatus <> 2 AND ID IN (SELECT MenuID FROM T_GroupWithMenu WHERE GroupID IN (SELECT T_USERGROUP.ID FROM T_UserWithGroup JOIN T_USERGROUP ON T_UserWithGroup.Groupid = T_USERGROUP.ID WHERE T_USERGROUP.ISDEL <> 2 AND T_USERGROUP.USERGROUPSTATUS <> 2 AND T_UserWithGroup.UserID = {0})) ", User.ID);
                if (IncludNoCheck) strSql += string.Format("UNION SELECT DISTINCT 1 AS IsChecked,T_Menu.* from T_Menu WHERE ISDEL <> 2 AND MenuStatus <> 2 AND ID NOT IN (SELECT MenuID FROM T_GroupWithMenu WHERE GroupID IN (SELECT T_USERGROUP.ID FROM T_UserWithGroup JOIN T_USERGROUP ON T_UserWithGroup.Groupid = T_USERGROUP.ID WHERE T_USERGROUP.ISDEL <> 2 AND T_USERGROUP.USERGROUPSTATUS <> 2 AND T_UserWithGroup.UserID = {0})) ", User.ID);
                if (User.UserType == 1) strSql += "UNION SELECT DISTINCT 2 AS IsChecked,T_Menu.* from T_Menu WHERE ISDEL <> 2 AND MenuStatus <> 2 AND SafeLevel <> 0 ";
                strSql = string.Format("SELECT * FROM ({0}) T ORDER BY NodeLevel, NodeSort, ID  ", strSql);
            }
            else
            {
                if (IncludNoCheck) strSql = "SELECT DISTINCT 1 AS IsChecked,T_Menu.* FROM T_Menu WHERE ISDEL <> 2 AND MenuStatus <> 2 ORDER BY NodeLevel, NodeSort, ID ";
                else strSql = "SELECT DISTINCT 2 AS IsChecked,T_Menu.* FROM T_Menu WHERE 1 = 2";
            }
            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }

        internal SqlDataReader GetAllMenuList(bool IsChecked)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT {0} AS IsChecked,T_Menu.* FROM T_Menu WHERE ISDEL <> 2 ", IsChecked.ToInt32());

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }
    }
}
