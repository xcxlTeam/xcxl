using System;
using BLL.Common;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;

namespace BLL.AppVersion
{
    public class AppVersion_Func
    {
        private AppVertsion_DB _db = new AppVertsion_DB();

        /// <summary>
        /// 检查版本更新
        /// </summary>
        /// <param name="appversion">版本信息</param>
        /// <returns>是否需要更新</returns>
        public bool VerifyVersion(ref AppVersionInfo appversion,ref string strError)
        {
            try
            {
                string ServicePath = string.Format("{0}{1}\\{2}", AppDomain.CurrentDomain.BaseDirectory, appversion.UpdateUrl, appversion.FileName);
                if (!File.Exists(ServicePath))
                {
                    return false;
                }

                FileVersionInfo fv = FileVersionInfo.GetVersionInfo(ServicePath);
                appversion.AppVersion = fv.FileVersion;

                if (CompareVersion(appversion))
                {                    
                    AppVersionInfo model = new AppVersionInfo();
                    model.AppVersion = appversion.AppVersion;
                    model.AppName = appversion.AppName;
                    if (GetAppVersionByVersion(ref model, ref strError))
                    {
                        model.LocalVersion = appversion.LocalVersion;
                        model.UpdateUrl = appversion.UpdateUrl;
                        model.UpdateAppName = appversion.UpdateAppName;
                        model.UpdateAppPath = appversion.UpdateAppPath;
                        model.FileName = appversion.FileName;
                        appversion = model;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        private bool CompareVersion(AppVersionInfo appversion)
        {
            if (string.IsNullOrEmpty(appversion.AppVersion)) return false;
            if (string.IsNullOrEmpty(appversion.LocalVersion)) return true;

            string[] arrService = appversion.AppVersion.Split('.');
            string[] arrLocal = appversion.LocalVersion.Split('.');

            if (arrService.Length != 4) return false;
            if (arrLocal.Length != 4) return true;

            long lService = arrService[0].ToInt32() * 1000000000 + arrService[1].ToInt32() * 1000000 + arrService[2].ToInt32() * 1000 + arrService[3].ToInt32();
            long lLocal = arrLocal[0].ToInt32() * 1000000000 + arrLocal[1].ToInt32() * 1000000 + arrLocal[2].ToInt32() * 1000 + arrLocal[3].ToInt32();

            return lService > lLocal;
        }


        public bool GetAppVersionByVersion(ref AppVersionInfo model, ref string strError)
        {
            try
            {
                using (SqlDataReader dr = _db.GetAppVersionByVersion(model))
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

        internal AppVersionInfo GetModelFromDataReader(SqlDataReader dr)
        {
            AppVersionInfo model = new AppVersionInfo();
            model.ID = dr["ID"].ToInt32();
            model.AppName = dr["AppName"].ToDBString();
            model.AppVersion = dr["AppVersion"].ToDBString();
            model.VersionType = dr["VersionType"].ToInt32();
            model.VersionLevel = dr["VersionLevel"].ToInt32();
            model.VersionTitle = dr["VersionTitle"].ToDBString();
            model.VersionDesc = dr["VersionDesc"].ToDBString();
            model.Creater = dr["Creater"].ToDBString();
            model.CreateTime = dr["CreateTime"].ToDateTime();

            if (Common_Func.readerExists(dr, "StrVersionType")) model.StrVersionType = dr["StrVersionType"].ToDBString();
            if (Common_Func.readerExists(dr, "StrVersionLevel")) model.StrVersionLevel = dr["StrVersionLevel"].ToDBString();

            return model;
        }

        /// <summary>
        /// 检查版本
        /// </summary>
        /// <param name="FileVersion">文件版本</param>
        /// <param name="FileName">文件名</param>
        /// <param name="path">更新地址</param>
        /// <returns>是否需要更新</returns>
        public bool VerifyVersion(string FileVersion, string FileName, string path)
        {
            try
            {
                string ServiceVersion = null;
                string strPath = AppDomain.CurrentDomain.BaseDirectory + path + "\\" + FileName;
                if (!File.Exists(strPath))
                {
                    return false;
                }

                FileVersionInfo fv = FileVersionInfo.GetVersionInfo(strPath);
                ServiceVersion = fv.FileVersion;

                if (ServiceVersion != FileVersion)
                {
                    return CompareVersion(ServiceVersion, FileVersion);
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private bool CompareVersion(string ServiceVersion, string FileVersion)
        {
            if (string.IsNullOrEmpty(ServiceVersion)) return false;
            if (string.IsNullOrEmpty(FileVersion)) return true;

            string[] arrService = ServiceVersion.Split('.');
            string[] arrFile = FileVersion.Split('.');

            if (arrService.Length != 4) return false;
            if (arrFile.Length != 4) return true;

            long lService = arrService[0].ToInt32() * 1000000000 + arrService[1].ToInt32() * 1000000 + arrService[2].ToInt32() * 1000 + arrService[3].ToInt32();
            long lFile = arrFile[0].ToInt32() * 1000000000 + arrFile[1].ToInt32() * 1000000 + arrFile[2].ToInt32() * 1000 + arrFile[3].ToInt32();

            return lService > lFile;
        }
    }
}
