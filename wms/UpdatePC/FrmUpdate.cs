using System;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;

namespace UpdateWMS
{
    public partial class FrmUpdate : Form
    {
        private const int SC_CLOSE = 0xF060;
        private const int MF_ENABLED = 0x00000000;
        private const int MF_GRAYED = 0x00000001;
        private const int MF_DISABLED = 0x00000002;
        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, int bRevert);
        [DllImport("User32.dll")]
        public static extern bool EnableMenuItem(IntPtr hMenu, int uIDEnableItem, int uEnable);

        string UpdExeName = "Update.exe";
        string UpdateUrl = "http://localhost/update/";
        string AppName = "DefaultApp";
        string AppService = "http://localhost/default.asmx";
        string m_workPath = "";
        string xmlFile = null;
        string strTemp = "";

        public FrmUpdate()
        {
            InitializeComponent();
        }

        private void FrmUpdate_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, 0);
            EnableMenuItem(hMenu, SC_CLOSE, MF_DISABLED | MF_GRAYED);

            InitForm();
        }

        private void FrmUpdate_Resize(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, 0);
            EnableMenuItem(hMenu, SC_CLOSE, MF_DISABLED | MF_GRAYED);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartUpdate();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void InitForm()
        {
            UpdExeName = Path.GetFileNameWithoutExtension(Application.ExecutablePath);

            pbUpdate.Minimum = 0;
            pbUpdate.Value = pbUpdate.Minimum;

            UpdateUrl = OperatingXML.GetValue("UpdateUrl");
            strTemp = System.IO.Path.GetFullPath(Path.GetTempPath() + "//Update//");
            AppName = OperatingXML.GetValue("AppName");
            AppService = GetAppConfigAdress();

            if(string.IsNullOrEmpty(UpdateUrl))
            {
                MessageBox.Show("更新地址配置不正确,请配置后重试!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            if (string.IsNullOrEmpty(AppName))
            {
                MessageBox.Show("更新程序名配置不正确,请配置后重试!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (!string.IsNullOrEmpty(AppService) && !CompareUrl())
            {
                if (MessageBox.Show(string.Format("更新地址【{0}】与服务地址【{1}】不在同一服务器上,是否继续更新?", UpdateUrl, AppService), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    Application.Exit();
                }
            }
        }

        private bool CompareUrl()
        {
            int UpdHttpIndex = 0;
            int SvrHttpIndex = 0;
            UpdHttpIndex = UpdateUrl.IndexOf("http://");
            SvrHttpIndex = AppService.IndexOf("http://");
            if (UpdHttpIndex != SvrHttpIndex) return false;

            int SecondLineIndex = 0;
            string UpdWebUrl;
            string SvrWebUrl;
            if (UpdHttpIndex >= 0)
            {
                //if (UpdateUrl.Length < UpdHttpIndex + 7) return false;
                //if (AppService.Length < SvrHttpIndex + 7) return false;
                if (AppService.Length < UpdHttpIndex + 7) return false;

                SecondLineIndex = UpdateUrl.IndexOf('/', UpdHttpIndex + 7);
                if (SecondLineIndex < 0) SecondLineIndex = UpdateUrl.Length - 1;
                if (SecondLineIndex != AppService.IndexOf('/', SvrHttpIndex + 7)) return false;

                UpdWebUrl = UpdateUrl.Substring(UpdHttpIndex, SecondLineIndex - UpdHttpIndex).ToLower();
                SvrWebUrl = AppService.Substring(SvrHttpIndex, SecondLineIndex - SvrHttpIndex).ToLower();

                return UpdWebUrl == SvrWebUrl;
            }
            else
            {
                SecondLineIndex = UpdateUrl.IndexOf('/');
                if (SecondLineIndex < 0) SecondLineIndex = UpdateUrl.Length - 1;
                if (SecondLineIndex != AppService.IndexOf('/')) return false;

                UpdWebUrl = UpdateUrl.Substring(0, SecondLineIndex ).ToLower();
                SvrWebUrl = AppService.Substring(0, SecondLineIndex).ToLower();

                return UpdWebUrl == SvrWebUrl;
            }
        }


        private string GetAppConfigAdress()
        {
            try
            {
                if (string.IsNullOrEmpty(AppName)) AppName = OperatingXML.GetValue("AppName");
                string strPath = Path.Combine(Environment.CurrentDirectory, AppName + ".config");
                if (!File.Exists(strPath)) return string.Empty;
                XmlDocument xd = new XmlDocument();
                string strValue = string.Empty;
                xd.Load(strPath);
                XmlNode xn;
                //string s = xd.SelectSingleNode("configuration").SelectSingleNode("system.serviceModel").SelectSingleNode("client").SelectSingleNode(name).OuterXml;
                xn = xd.SelectSingleNode("configuration");
                if (xn == null) return string.Empty;
                xn = xn.SelectSingleNode("system.serviceModel");
                if (xn == null) return string.Empty;
                xn = xn.SelectSingleNode("client");
                if (xn == null) return string.Empty;
                xn = xn.SelectSingleNode("endpoint");
                if (xn == null) return string.Empty;
                xn = xn.Attributes.GetNamedItem("address");
                if (xn == null) return string.Empty;

                string strAddress = xn.Value;

                return strAddress;
            }
            catch //(System.Exception ex)
            {
                return string.Empty;
            }
        }

        private void StartUpdate()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.btnStart.Enabled = false;
                this.btnCancel.Enabled = false;
                this.Refresh();

                string path = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
                path = path.Replace("file:///", "");
                m_workPath = System.IO.Path.GetFullPath(path);
                m_workPath = System.IO.Path.GetDirectoryName(m_workPath);
                xmlFile = m_workPath;
                Download();
            }
            catch //(System.Exception ex)
            {
                //Cursor.Current = Cursors.Help;
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                this.btnStart.Enabled = true;
                this.btnCancel.Enabled = true;

                Cursor.Current = Cursors.Default;
            }
        }
        /// <summary>
        /// 开始下载
        /// </summary>
        private void Download()
        {
            DirectoryInfo theFolder = new DirectoryInfo(Path.GetDirectoryName(this.m_workPath + "\\"));

            try
            {
                if (!Directory.Exists(strTemp))
                    Directory.CreateDirectory(strTemp);

                lblStatus.Text = "正在连接更新服务器：" + UpdateUrl;
                lblStatus.Refresh();
                if(!UrlCheck(UpdateUrl))
                {
                    lblStatus.Text = "更新出错！连接不上远程服务器！";
                    lblStatus.Refresh();
                    MessageBox.Show(lblStatus.Text, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (FileInfo theFile in theFolder.GetFiles())
                {
                    if (theFile.Name != UpdExeName + ".exe" && theFile.Name != UpdExeName + ".pdb" && theFile.Name != "Config.xml")
                    {
                        lblStatus.Text = "正在下载：" + theFile.Name;
                        lblStatus.Refresh();
                        DownloadFile(theFile.Name, UpdateUrl + theFile.Name);
                    }
                }

                lblStatus.Text = "正在替换旧版本文件";
                lblStatus.Refresh();
                MoveFolderTo(strTemp);
                lblStatus.Text = "更新完成！";
                lblStatus.Refresh();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                lblStatus.Text = "更新出错！" + ex.Message;
                lblStatus.Refresh();
            }
            finally
            {
                //if (Directory.Exists(strTemp))
                //    Directory.Delete(strTemp, true);
            }
            //启动程序 
            if (AppName.EndsWith(".dll"))
            {
                AppName = AppName.Replace(".dll",".exe");
            }
            System.Diagnostics.Process.Start(this.m_workPath + "\\" + AppName, "");
            Application.Exit();
            Close();

        }

        private bool UrlCheck(string strUrl)
        {
            HttpWebRequest webRequest;
            HttpWebResponse webResponse = null;
            FileWebRequest fileRequest;
            FileWebResponse fileResponse = null;
            bool isFile = false;

            try
            {
                isFile = (HttpWebRequest.Create(strUrl) is FileWebRequest);

                if (isFile)
                {
                    fileRequest = (FileWebRequest)FileWebRequest.Create(strUrl);
                    fileResponse = (FileWebResponse)fileRequest.GetResponse();
                    if (fileResponse == null)
                        return false;
                    return true;
                }
                else
                {
                    webRequest = (HttpWebRequest)HttpWebRequest.Create(strUrl);
                    webResponse = (HttpWebResponse)webRequest.GetResponse();
                    if (webResponse == null)
                        return false;
                    return webResponse.StatusCode == HttpStatusCode.OK;
                }
            }
            catch
            {
                if (fileResponse != null)
                    fileResponse.Close();

                if (webResponse != null)
                    webResponse.Close();

                return false;
            }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="strUrl"></param>
        private void DownloadFile(string FileName, string strUrl)
        {
            HttpWebRequest webRequest;
            HttpWebResponse webResponse = null;
            FileWebRequest fileRequest;
            FileWebResponse fileResponse = null;
            bool isFile = false;
            try
            {
                System.Globalization.DateTimeFormatInfo dfi = null;
                System.Globalization.CultureInfo ci = null;
                ci = new System.Globalization.CultureInfo("zh-CN");
                dfi = new System.Globalization.DateTimeFormatInfo();

                //WebRequest wr = WebRequest.Create("");

                //System.Net.WebResponse w=wr.
                DateTime fileDate;
                long totalBytes;
                DirectoryInfo theFolder = new DirectoryInfo(strTemp);
                string fileName = theFolder + FileName;
                if (strUrl.EndsWith(".exe"))
                {
                    strUrl = strUrl.Replace(".exe", ".dll");
                }
                isFile = (HttpWebRequest.Create(strUrl) is FileWebRequest);

                if (isFile)
                {
                    fileRequest = (FileWebRequest)FileWebRequest.Create(strUrl);
                    fileResponse = (FileWebResponse)fileRequest.GetResponse();
                    if (fileResponse == null)
                        return;
                    fileDate = DateTime.Now;
                    totalBytes = fileResponse.ContentLength;
                } 
                else
                {
                    webRequest = (HttpWebRequest)HttpWebRequest.Create(strUrl);
                    webResponse = (HttpWebResponse)webRequest.GetResponse();
                    if (webResponse == null)
                        return;
                    fileDate = webResponse.LastModified;
                    totalBytes = webResponse.ContentLength;
                }

                pbUpdate.Maximum = Convert.ToInt32(totalBytes);

                Stream stream ;
                if (isFile)
                {
                    stream = fileResponse.GetResponseStream();
                } 
                else
                {
                    stream = webResponse.GetResponseStream();
                }
                FileStream sw = new FileStream(fileName, FileMode.Create);
                int totalDownloadedByte = 0;
                Byte[] @by = new byte[1024];
                int osize = stream.Read(@by, 0, @by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    Application.DoEvents();
                    sw.Write(@by, 0, osize);
                    pbUpdate.Value = totalDownloadedByte;
                    osize = stream.Read(@by, 0, @by.Length);
                }
                sw.Close();
                stream.Close();

                //System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName(AppName);

                ////关闭原有应用程序的所有进程 
                //foreach (System.Diagnostics.Process pro in proc)
                //{
                //    pro.Kill();
                //}


                //DirectoryInfo theFolder = new DirectoryInfo(Path.GetTempPath() + "ysy");
                if (theFolder.Exists)
                {
                    foreach (FileInfo theFile in theFolder.GetFiles())
                    {
                        if (theFile.Name != UpdExeName + ".exe" && theFile.Name != UpdExeName + ".pdb" && theFile.Name != "Config.xml")
                        {
                            //如果临时文件夹下存在与应用程序所在目录下的文件同名的文件，则删除应用程序目录下的文件 
                            if (File.Exists(this.m_workPath + "\\" + Path.GetFileName(theFile.FullName)))
                            {
                                File.Delete(this.m_workPath + "\\" + Path.GetFileName(theFile.FullName));
                                //将临时文件夹的文件移到应用程序所在的目录下 
                                File.Move(theFile.FullName, this.m_workPath + "\\" + Path.GetFileName(theFile.FullName));

                            }
                            
                        }
                    }
                }
                File.SetLastWriteTime(FileName, fileDate);

            }
            catch (Exception ex)
            {
                if (fileResponse != null)
                    fileResponse.Close();

                if (webResponse != null)
                    webResponse.Close();

                // MessageBox.Show(ex.Message);
                lblStatus.Text = "更新出错！" + ex.Message;
                lblStatus.Refresh();
            }
        }
        /// <summary>
        /// 从一个目录将其内容移动到另一目录
        /// </summary>
        /// <param name="strSource">源目录</param>
        private void MoveFolderTo(string strSource)
        {
            try
            {
                //先来移动文件
                DirectoryInfo info = new DirectoryInfo(strSource);
                FileInfo[] files = info.GetFiles();
                string filename;
                foreach (FileInfo file in files)
                {
                    filename = Path.GetFileName(file.FullName);
                    try
                    {
                        if (filename != UpdExeName + ".exe" && filename != UpdExeName + ".pdb" && filename != "Config.xml")
                        {
                            File.Copy(file.FullName, this.m_workPath + "\\" + Path.GetFileName(file.FullName), true);
                            
                        }
                        file.Delete();
                    }
                    catch (System.Exception ex)
                    {
                        lblStatus.Text = ex.Message;
                        lblStatus.Refresh();
                    }
                }
                //删除缓存文件夹
                info.Delete(true);
            }
            catch
            { }
        }
    }
}
