using BLL.Basic.User;
using BLL.Common;
using BLL.Task;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace BLL.Basic.TempMaterial
{
    public class TempMaterial_Func
    {
        private TempMaterial_DB _db = new TempMaterial_DB();

        public bool ExistsTempMaterialNo(TempMaterialInfo model, bool bIncludeDel, UserInfo user, ref string strError)
        {
            try
            {
                return _db.ExistsTempMaterialNo(model, bIncludeDel);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public bool SaveTempMaterial(ref TempMaterialInfo model, UserInfo user, ref string strError)
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

                bool bResult = _db.SaveTempMaterial(ref model);
                if (bResult)
                {
                    if (!GetTempMaterialByID(ref model, user, ref strError))
                    {
                        strError = string.Format("{0}{1}{2}", "保存成功,获取保存数据失败", Environment.NewLine, strError);
                    }
                }

                return bResult;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }


        public bool DeleteTempMaterialByID(TempMaterialInfo model, UserInfo user, ref string strError)
        {
            try
            {
                return _db.DeleteTempMaterialByID(model);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }


        public bool GetTempMaterialByID(ref TempMaterialInfo model, UserInfo user, ref string strError)
        {
            try
            {
                using (SqlDataReader dr = _db.GetTempMaterialByID(model))
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

        public bool GetTempMaterialNo(ref TempMaterialInfo model, UserInfo user, ref string strError)
        {
            try
            {
                string menuNo = _db.GetTempMaterialNo(model);
                if (string.IsNullOrEmpty(menuNo)) return false;
                model.TempMaterialNo = menuNo;
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }


        public bool GetTempMaterialListByPage(ref List<TempMaterialInfo> modelList, TempMaterialInfo model, ref DividPage page, UserInfo user, ref string strError)
        {
            if (page == null) page = new DividPage();
            List<TempMaterialInfo> lstModel = new List<TempMaterialInfo>();
            try
            {
                using (SqlDataReader dr = Common_DB.QueryByDividPage(ref page, "V_TempMaterial", GetFilterSql(model, user), "*", "Order By CreateTime Desc,TempMaterialNo,MaterialNo,ID Desc"))
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

        private string GetFilterSql(TempMaterialInfo model, UserInfo user)
        {
            try
            {
                string strSql = " Where ISNULL(IsDel,1) = 1 ";
                bool hadWhere = true;


                if (!string.IsNullOrEmpty(model.TempMaterialNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (TempMaterialNo Like '%" + model.TempMaterialNo + "%' or TempMaterialDesc Like '%" + model.TempMaterialNo + "%') ";
                    hadWhere = true;
                }

                if (!string.IsNullOrEmpty(model.MaterialNo))
                {
                    strSql = Common_Func.AddWhereAnd(strSql, hadWhere);
                    strSql += " (MaterialNo Like '%" + model.MaterialNo + "%' or MaterialDesc Like '%" + model.MaterialNo + "%') ";
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

        private TempMaterialInfo GetModelFromDataReader(SqlDataReader dr)
        {
            TempMaterialInfo model = new TempMaterialInfo();
            model.ID = dr["ID"].ToInt32();
            model.TempMaterialNo = dr["TempMaterialNo"].ToDBString();
            model.TempMaterialDesc = dr["TempMaterialDesc"].ToDBString();
            model.MaterialNo = dr["MaterialNo"].ToDBString();
            model.MaterialDesc = dr["MaterialDesc"].ToDBString();
            model.SapMaterialDoc = dr["SapMaterialDoc"].ToDBString();
            model.ReplaceUser = dr["ReplaceUser"].ToDBString();
            model.ReplaceTime = dr["ReplaceTime"].ToDateTimeNull();
            model.TempMaterialStatus = dr["TempMaterialStatus"].ToInt32();
            model.IsDel = dr["ISDEL"].ToInt32();
            model.Creater = dr["CREATER"].ToDBString();
            model.CreateTime = dr["CREATETIME"].ToDateTime();
            model.Modifyer = dr["MODIFYER"].ToDBString();
            model.ModifyTime = dr["MODIFYTIME"].ToDateTimeNull();

            if (Common_Func.readerExists(dr, "StrTempMaterialStatus")) model.StrTempMaterialStatus = dr["StrTempMaterialStatus"].ToDBString();

            model.Unit = string.Empty;
            model.IsRohs = 2;

            return model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type">获取类型 1-仅SAP; 2-仅临时物料; 3-先临时再SAP</param>
        /// <param name="user"></param>
        /// <param name="strError"></param>
        /// <returns></returns>
        public bool GetMaterialInfo(ref TempMaterialInfo model, int type, UserInfo user, ref string strError)
        {
            Task_Func TF = new Task_Func();
            TaskDetails_Model TM = new TaskDetails_Model();

            SqlDataReader dr = null;
            TempMaterialInfo temp = new TempMaterialInfo();
            try
            {
                switch (type)
                {
                    case 1:
                        //if (TF.GetMaterialInfoForSAP(model.MaterialNo, ref TM, ref strError))
                        //{
                        //    temp = TransferTaskDetailToTempMaterial(TM);
                        //}
                        //else
                        {
                            return false;
                        }
                        break;

                    case 2:
                        dr = _db.GetTempMaterialByNo(model);
                        if (dr != null && dr.Read())
                        {
                            temp = GetModelFromDataReader(dr);
                            temp.MaterialNo = temp.TempMaterialNo;
                            temp.MaterialDesc = temp.TempMaterialDesc;
                        }
                        else
                        {
                            strError = "没有获取到临时物料信息！";
                            return false;
                        }
                        break;

                    case 3:
                        dr = _db.GetTempMaterialByNo(model);
                        if (dr != null && dr.Read())
                        {
                            temp = GetModelFromDataReader(dr);
                            temp.MaterialNo = temp.TempMaterialNo;
                            temp.MaterialDesc = temp.TempMaterialDesc;
                        }
                        else
                        {
                            //if (TF.GetMaterialInfoForSAP(model.MaterialNo, ref TM, ref strError))
                            //{
                            //    temp = TransferTaskDetailToTempMaterial(TM);
                            //}
                            //else
                            {
                                strError = "没有获取到物料信息！";
                                return false;
                            }
                        }
                        break;

                    default:
                        strError = "传入类型错误";
                        return false;
                }

                model = temp;
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
            finally
            {
                if (dr != null && !dr.IsClosed) dr.Close();
            }
        }

        private TempMaterialInfo TransferTaskDetailToTempMaterial(TaskDetails_Model TM)
        {
            TempMaterialInfo model = new TempMaterialInfo();

            model.MaterialNo = TM.MaterialNo;
            model.MaterialDesc = TM.MaterialDesc;
            model.Unit = TM.Unit;
            model.IsRohs = TM.IsROHS;

            return model;
        }
    }
}
