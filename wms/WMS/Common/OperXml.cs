using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WMS.Common
{
    public class OperXml
    {
        private const string configName = "Config.xml";

        private static string SearchXml()
        {
            string filePath = System.IO.Path.GetDirectoryName
                (System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            filePath = string.Format("{0}\\{1}", filePath, Common_Var.SolutionName);
            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
            filePath = System.IO.Path.Combine(filePath, configName);
            filePath = filePath.Replace("file:\\", "");
            return filePath;
        }

        public static void CheckConfig()
        {
            if (!File.Exists(SearchXml()))
            {
                try
                {
                    using (FileStream fs = File.Create(SearchXml()))
                    {
                        AddText(fs, "<?xml version=\"1.0\" encoding=\"GB2312\"?>");
                        AddText(fs, "<Config>");
                        AddText(fs, "<InnerPrinter></InnerPrinter>");
                        AddText(fs, "<OutboxPrinter></OutboxPrinter>");
                        AddText(fs, "<InnerDPI>300</InnerDPI>");
                        AddText(fs, "<OutboxDPI>300</OutboxDPI>");
                        AddText(fs, "<InnerPrintNum>10</InnerPrintNum>");
                        AddText(fs, "<OutboxPrintNum>10</OutboxPrintNum>");
                        AddText(fs, "</Config>");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message + Environment.NewLine + "无法创建打印配置文件,可能导致打印功能无法正常使用！");
                }
            }
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value + "\r\n");
            fs.Write(info, 0, info.Length);
        }
        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        static public void AddNode(string Node, string value)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(SearchXml());

            if (xd.FirstChild.SelectSingleNode(Node) == null)
            {

                XmlElement xe = xd.CreateElement(Node);
                xe.InnerText = value;
                XmlNode xn = xd.SelectSingleNode("/Config");
                xn.AppendChild(xe);
                xd.Save(SearchXml());
            }

        }

        static public string GetValue(string name)
        {
            XmlDocument xd = new XmlDocument();

            try
            {
                xd.Load(SearchXml());
                return (xd.GetElementsByTagName(name)[0].InnerText);
                //return (xd.FirstChild.SelectSingleNode(name).InnerText);
            }
            catch
            {
                if (name == "InnerDPI")
                {
                    AddNode("InnerDPI", "300");
                    return "300";
                }
                if (name == "OutboxDPI")
                {
                    AddNode("OutboxDPI", "300");
                    return "300";
                }

                return string.Empty;
            }
        }

        static public void SetValuse(string name, string value)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                string xml = SearchXml();
                xd.Load(xml);
                xd.GetElementsByTagName(name)[0].InnerText = value;
                //xd.FirstChild.SelectSingleNode(name).InnerText = value;
                xd.Save(xml);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + Environment.NewLine + "无法写入打印配置文件,可能导致打印功能无法正常使用！");
            }
        }


    }
}
