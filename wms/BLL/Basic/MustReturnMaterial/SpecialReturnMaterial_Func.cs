using BLL.Basic.User;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BLL.Common;

namespace BLL.Basic.MustReturnMaterial
{
    public class SpecialReturnMaterial_Func
    {
        private SpecialReturnMaterial_DB _db = new SpecialReturnMaterial_DB();


        public bool SaveSpecialReturnMaterial(ref SpecialReturnMaterial model, UserInfo user, ref string strError)
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
                return _db.SaveSpecialReturnMaterial(ref model);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }


        public bool DeleteSpecialReturnMaterialByID(SpecialReturnMaterial model, UserInfo user, ref string strError)
        {
            try
            {
                return _db.DeleteSpecialReturnMaterialByID(model);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }


        public bool GetSpecialReturnMaterialByID(ref SpecialReturnMaterial model, UserInfo user, ref string strError)
        {
            try
            {
                using (SqlDataReader dr = _db.GetSpecialReturnMaterialByID(model))
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


        public bool GetSpecialReturnMaterialListByPage(ref List<SpecialReturnMaterial> modelList, SpecialReturnMaterial model, ref DividPage page, UserInfo user, ref string strError)
        {
            if (page == null) page = new DividPage();
            List<SpecialReturnMaterial> lstModel = new List<SpecialReturnMaterial>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_SpecialReturnMaterial", GetFilterSql(model, user), "*", "Order By InvtID,ID Desc"))
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

        public bool GetSpecialReturnMaterialList(ref List<SpecialReturnMaterial> modelList, SpecialReturnMaterial model, UserInfo user, ref string strError)
        {
            List<SpecialReturnMaterial> lstModel = new List<SpecialReturnMaterial>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryAll("V_SpecialReturnMaterial", GetFilterSql(model, user), "*", "Order By InvtID,ID Desc"))
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
        }

        private string GetFilterSql(SpecialReturnMaterial model, UserInfo user)
        {
            try
            {
                string strSql = " Where ISNULL(IsDel,1) = 1 ";
                bool hadWhere = true;

                if (!string.IsNullOrEmpty(model.InvtID))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (InvtID LIKE '%" + model.InvtID + "%' ) ";
                    hadWhere = true;
                }

                //if (!string.IsNullOrEmpty(model.pName))
                //{
                //    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                //    strSql += " HouseName LIKE '%" + model.pName + "%' ";
                //    hadWhere = true;
                //}

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

        private SpecialReturnMaterial GetModelFromDataReader(SqlDataReader dr)
        {
            SpecialReturnMaterial model = new SpecialReturnMaterial();
            model.ID = dr["ID"].ToInt32();
            model.IsDel = dr["ISDEL"].ToInt32();
            model.Creater = dr["CREATER"].ToDBString();
            model.CreateTime = dr["CREATETIME"].ToDateTime();
            model.Modifyer = dr["MODIFYER"].ToDBString();
            model.ModifyTime = dr["MODIFYTIME"].ToDateTimeNull();
            model.InvtID = dr["InvtID"].ToDBString();

            return model;
        }

    }
}
