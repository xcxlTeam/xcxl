using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace UpdateWMS
{
    public class OperatingXML
    {
        /// <summary>
        /// 找到xml的路径
        /// </summary>
        /// <returns>路径</returns>
        private static string searchXml()
        {
            try
            {
                string filePath = Path.GetDirectoryName
                    (System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                filePath = Path.Combine(filePath, "Config.xml");
                filePath = filePath.Replace("file:\\", "");
                return filePath;
            }
            catch //(System.Exception ex)
            {
                return string.Empty;
            }
        }


        static public string GetValue(string name)
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
    }
}
