using WMS.Common;
using WMS.WebService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace WMS.Login
{
    public class Login_Func
    {
        public static void HelloWorld()
        {
            WMSWebService.service.HelloWorld();
        }

        public static bool VerifyVersion(string FileVersion, string FileName, string path)
        {
            return WMSWebService.service.VerifyVersion(FileVersion, FileName, path);
        }

        public static bool VerifyAppVersion(ref AppVersionInfo appversion, ref string strError)
        {
            return WMSWebService.service.VerifyAppVersion(ref appversion, ref strError);
        }

        public static bool GetAppVersionByVersion(ref AppVersionInfo appversion, ref string strError)
        {
            return WMSWebService.service.GetAppVersionByVersion(ref appversion, ref strError);
        }

        /// <summary>
        /// 找到xml的路径
        /// </summary>
        /// <returns>路径</returns>
        private static string searchXml()
        {
            try
            {
                string filePath = System.IO.Path.GetDirectoryName
                    (System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                filePath = System.IO.Path.Combine(filePath, "Config.xml");
                filePath = filePath.Replace("file:\\", "");
                return filePath;
            }
            catch //(System.Exception ex)
            {
                return string.Empty;
            }
        }


        public static string GetValue(string name)
        {
            try
            {
                string strPath = searchXml();
                if (!File.Exists(strPath)) return string.Empty;
                XmlDocument xd = new XmlDocument();
                xd.Load(strPath);
                return (xd.FirstChild.SelectSingleNode(name).InnerText);
            }
            catch //(System.Exception ex)
            {
                return string.Empty;
            }
        }


        public static string ObjectToJson<T>(T obj)
        {
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();   //实例化一个能够序列化数据的类             
            return js.Serialize(obj);
        }

        public static bool UserLogin(ref UserInfo user, ref string strError)
        {
            return WMSWebService.service.UserLogin(ref user, ref strError);
        }

        public static bool UpdateLoginTime(ref UserInfo user, ref string strError)
        {
            return WMSWebService.service.UpdateLoginTime(ref user, ref strError);
        }

        public static bool ChangeUserPassword(UserInfo user, ref string strError)
        {
            return WMSWebService.service.ChangeUserPassword(user, Common_Var.CurrentUser, ref strError);
        }


        public static string UserLoginForAndroid(string strUserJson)
        {
            return WMSWebService.service.UserLoginForAndroid(strUserJson);
        }


        public static string ChangeUserPasswordForAndroid(string strUserJson)
        {
            return WMSWebService.service.ChangeUserPasswordForAndroid(strUserJson);
        }


        public static string UpdateLoginTimeForAndroid(string strUserJson)
        {
            return WMSWebService.service.UpdateLoginTimeForAndroid(strUserJson);
        }


        public static string ClearLoginTimeForAndroid(string strUserJson)
        {
            return WMSWebService.service.ClearLoginTimeForAndroid(strUserJson);
        }

        public static string GetTaskInfo(string strUserJson, string strBarCode)
        {
            return WMSWebService.service.GetTaskInfo(strUserJson, strBarCode);
        }

    }
}
