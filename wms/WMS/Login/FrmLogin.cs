using WMS.Common;
using WMS.WebService;
using System;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace WMS.Login
{
    public partial class FrmLogin : Form
    {
        private const string appUpdate = "UpdatePC.exe";

        private const decimal rateX_Label = 0.641m;
        private const decimal rateY_Service = 0.326m;
        private const decimal rateY_Message = 0.423m;
        private const decimal rateX_lblAccount = 0.540m;
        private const decimal rateX_Version = 0.743m;
        private const decimal rateY_Version = 0.761m;

        private const decimal rateX_TextBox = 0.630m;
        private const decimal rateY_Account = 0.514m;
        private const decimal rateY_Password = 0.573m;

        private const decimal rateX_Login = 0.597m;
        private const decimal rateX_Cancel = 0.695m;
        private const decimal rateY_Button = 0.645m;

        private const decimal rateW_TextBox = 0.146m;
        private const decimal rateH_TextBox = 0.030m;
        private const decimal rateW_Button = 0.084m;
        private const decimal rateH_Button = 0.052m;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            if (!ShowServiceVersion()) return;

            UpdateApplication();
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common_Func.UserLogout();
            Application.Exit();
        }

        private void txtAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtAccount.Text.Trim()))
                {
                    Focus_txtPassword();
                }
            }
        }

        private void txtAccount_Enter(object sender, EventArgs e)
        {
            Focus_txtAccount();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    UserLogin();
                }
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            Focus_txtPassword();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserLogin();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picBackground_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UserLogin();
            }
        }

        #region Function


        private void InitForm()
        {
            SetAnchor();

            SetBackColor();

            CheckApplication();

        }

        private void SetAnchor()
        {
            if (picBackground.Width >= 1366 && picBackground.Height >= 768) return;

            Point ptService = new Point((picBackground.Width * rateX_Label).ToInt32(), (picBackground.Height * rateY_Service).ToInt32());
            Point ptMessage = new Point((picBackground.Width * rateX_Label).ToInt32(), (picBackground.Height * rateY_Message).ToInt32());
            Point ptlblAcc = new Point((picBackground.Width * rateX_lblAccount).ToInt32(), (picBackground.Height * rateY_Account).ToInt32());
            Point ptlblPwd = new Point((picBackground.Width * rateX_lblAccount).ToInt32(), (picBackground.Height * rateY_Password).ToInt32());
            Point ptAccount = new Point((picBackground.Width * rateX_TextBox).ToInt32(), (picBackground.Height * rateY_Account).ToInt32());
            Point ptPassword = new Point((picBackground.Width * rateX_TextBox).ToInt32(), (picBackground.Height * rateY_Password).ToInt32());
            Point ptLogin = new Point((picBackground.Width * rateX_Login).ToInt32(), (picBackground.Height * rateY_Button).ToInt32());
            Point ptCancel = new Point((picBackground.Width * rateX_Cancel).ToInt32(), (picBackground.Height * rateY_Button).ToInt32());
            Point ptVersion = new Point((picBackground.Width * rateX_Version).ToInt32(), (picBackground.Height * rateY_Version).ToInt32());

            lblService.Location = ptService;
            lblMessage.Location = ptMessage;
            lblAccount.Location = ptlblAcc;
            lblPassword.Location = ptlblPwd;
            txtAccount.Location = ptAccount;
            txtPassword.Location = ptPassword;
            btnLogin.Location = ptLogin;
            btnCancel.Location = ptCancel;
            lblVersion.Location = ptVersion;

            Size szTextBox = new Size((picBackground.Width * rateW_TextBox).ToInt32(), (picBackground.Height * rateH_TextBox).ToInt32());
            Size szButton = new Size((picBackground.Width * rateW_Button).ToInt32(), (picBackground.Height * rateH_Button).ToInt32());

            txtAccount.Size = txtPassword.Size = szTextBox;
            btnLogin.Size = btnCancel.Size = szButton;
        }

        private void SetBackColor()
        {
            Bitmap bmp = new Bitmap(picBackground.Image, picBackground.Size);
            lblService.BackColor = bmp.GetPixel(lblService.Location.X, lblService.Location.Y);
            lblMessage.BackColor = bmp.GetPixel(lblMessage.Location.X, lblMessage.Location.Y);

            lblAccount.BackColor = bmp.GetPixel(lblAccount.Location.X, lblAccount.Location.Y);
            lblPassword.BackColor = bmp.GetPixel(lblPassword.Location.X, lblPassword.Location.Y);
        }

        private void CheckApplication()
        {
            try
            {
                string Namespace = this.GetType().Namespace;

                //Common.Common_Var.SolutionName = Namespace.Split('.')[0];
                Common.Common_Var.SolutionName = "XinJieWMS";

                Common.OperXml.CheckConfig();

                try { Common_Var.AppVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(); }
                catch { Common_Var.AppVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString(); }

                lblVersion.Text = string.Format("当前版本：{0}", Common_Var.AppVersion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ShowServiceVersion()
        {
            string ServiceAddress = GetAppConfigAdress();

            if (ServiceAddress.IndexOf("localhost") >= 0)
            {
                lblService.Text = "开发服务器";
                this.lblService.Refresh();
                return false;

            }
            else if (ServiceAddress.ToUpper().IndexOf("WEBSERVER") >= 0)
            {
                lblService.Text = "正式服务器";
                this.lblService.Refresh();
                return true;
            }
            else if (ServiceAddress.ToUpper().IndexOf("WEBTEST") >= 0)
            {
                lblService.Text = "测试服务器";
                this.lblService.Refresh();
                return true;
            }
            else
            {
                lblService.Text = "";
                this.lblService.Refresh();
                return true;
            }
        }


        private string GetAppConfigAdress()
        {
            try
            {
                string SolutionName = this.GetType().Namespace;
                string strPath = Path.Combine(Environment.CurrentDirectory, Common.Common_Var.SolutionName + ".vshost.exe.config");
                //string strPath = Path.Combine(Environment.CurrentDirectory, Common.Common_Var.SolutionName + ".exe.config");

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

        private void UpdateApplication()
        {
            try
            {
                AppVersionInfo appVersion = new AppVersionInfo();

                Cursor = Cursors.WaitCursor;
                txtAccount.Enabled = false;
                txtPassword.Enabled = false;
                btnLogin.Enabled = false;
                this.lblMessage.Text = "正在验证版本......";
                this.lblMessage.Refresh();
                Application.DoEvents();

                appVersion.LocalVersion = Common_Var.AppVersion;
                if (string.IsNullOrEmpty(appVersion.LocalVersion))
                {
                    this.lblMessage.Text = "版本获取错误";
                    this.lblMessage.Refresh();
                    MessageBox.Show(lblMessage.Text, "提示");
                    return;
                }

                appVersion.AppName = Login_Func.GetValue("AppName");
                if (string.IsNullOrEmpty(appVersion.AppName))
                {
                    this.lblMessage.Text = "程序文件名读取失败,请检查Config.xml文件配置";
                    this.lblMessage.Refresh();
                    MessageBox.Show(lblMessage.Text, "提示");
                    return;
                }
                appVersion.FileName = appVersion.AppName;

                AssemblyName an = Assembly.GetExecutingAssembly().GetName();
                appVersion.UpdateAppPath = Path.GetDirectoryName(an.CodeBase.Replace("file:///", "")).ToString() + "\\" + appUpdate;
                if (!File.Exists(appVersion.UpdateAppPath))
                {
                    this.lblMessage.Text = "更新程序不存在,程序将无法自动更新";
                    this.lblMessage.Refresh();
                    MessageBox.Show(lblMessage.Text, "提示");
                    return;
                }

                string filePath = Login_Func.GetValue("UpdateUrl").Trim('/');
                if (string.IsNullOrEmpty(filePath))
                {
                    this.lblMessage.Text = "更新地址读取失败,请检查Config.xml文件配置";
                    this.lblMessage.Refresh();
                    MessageBox.Show(lblMessage.Text, "提示");
                    return;
                }

                int index = filePath.LastIndexOf('/');
                if (index < 0)
                {
                    this.lblMessage.Text = "服务器更新路径格式错误,请检查Config.xml文件配置";
                    this.lblMessage.Refresh();
                    MessageBox.Show(lblMessage.Text, "提示");
                    return;
                }

                appVersion.UpdateUrl = filePath.Substring(index + 1, filePath.Length - index - 1);
                if (string.IsNullOrEmpty(appVersion.UpdateUrl))
                {
                    this.lblMessage.Text = "服务器更新目录获取失败,请检查Config.xml文件配置";
                    this.lblMessage.Refresh();
                    MessageBox.Show(lblMessage.Text, "提示");
                    return;
                }

                string strError = string.Empty;
                if (Login_Func.VerifyAppVersion(ref appVersion, ref strError))
                {
                    if (string.IsNullOrEmpty(appVersion.VersionDesc))
                    {
                        MessageBox.Show(string.Format("程序发现新的版本【{0}】，请确定后更新!", appVersion.AppVersion), "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        System.Diagnostics.Process.Start(appVersion.UpdateAppPath, null);
                    }
                    else
                    {
                        if (MessageBox.Show(string.Format("程序发现新的版本【{0}】，是否查看版本说明?", appVersion.AppVersion), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            using (FrmVersionInfo frm = new FrmVersionInfo(appVersion))
                            {
                                frm.ShowDialog();
                            }
                        }
                        else
                        {
                            System.Diagnostics.Process.Start(appVersion.UpdateAppPath, null);
                        }
                    }

                    Application.Exit();

                    System.Diagnostics.Process proc = System.Diagnostics.Process.GetCurrentProcess();
                    proc.Kill();
                    return;
                }
                else
                {
                    if (!string.IsNullOrEmpty(strError))
                    {
                        this.lblMessage.Text = strError;
                        this.lblMessage.Refresh();
                        MessageBox.Show(lblMessage.Text, "提示");
                    }
                }

                Application.DoEvents();
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message;
                this.lblMessage.Refresh();
                //MessageBox.Show(lblMessage.Text, "错误");
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
                txtAccount.Enabled = true;
                txtPassword.Enabled = true;
                btnLogin.Enabled = true;
                this.lblMessage.Text = "";
                txtAccount.Focus();
                txtPassword.SelectAll();
                Application.DoEvents();
            }
        }

        

        private void UserLogin()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!CheckInput()) return;

                string MacAddress = IPHelper.GetMacByWMI();

                string strError = string.Empty;
                UserInfo user = new UserInfo();
                user.UserNo = txtAccount.Text.Trim();
                //user.Password = Basic.Basic_Func.JiaMi(txtPassword.Text.Trim());
                //UFSoft.U8.Framework.Login.UI.clsLogin netLogin = new UFSoft.U8.Framework.Login.UI.clsLogin();
                user.Password = txtPassword.Text.Trim();// netLogin.EnPassWord(txtPassword.Text.Trim());

                user.LoginIP = string.Format("PC:{0}", MacAddress);
                user.LoginDevice = IPHelper.GetUserName();

                //string strUserJson;
                //user.Password = (txtPassword.Text.Trim());
                //strUserJson = Login_Func.ObjectToJson<UserInfo>(user);
                //strUserJson = Login_Func.UserLoginForAndroid(strUserJson);

                ////string strUpdTime = Login_Func.UpdateLoginTimeForAndroid(strUserJson);
                ////string strClrTime = Login_Func.ClearLoginTimeForAndroid(strUserJson);
                ////string strChangePwd = Login_Func.ChangeUserPasswordForAndroid(strUserJson);

                ////string strTaskJson = Login_Func.GetTaskInfo(strUserJson, "");
                //return;

                if (Login_Func.UserLogin(ref user, ref strError))
                {
                    Common.Common_Var.CurrentUser = user;
                    if (user.Password == Basic.Basic_Func.JiaMi(Common_Var.DefaultPwd))
                    {
                        MessageBox.Show(string.Format("您当前使用默认密码【{0}】登陆,请先修改密码!", Common_Var.DefaultPwd), "登陆提示");
                        FrmChangePwd frm = new FrmChangePwd();
                        DialogResult dr = frm.ShowDialog();
                        Application.Exit();
                    }
                }
                else
                {
                    MessageBox.Show(strError, "登陆提示");
                    if (strError.IndexOf("用户") >= 0)
                        Focus_txtAccount();
                    else
                        Focus_txtPassword();
                    return;
                }


                this.Opacity = 0;
                this.Hide();
                Application.DoEvents();

                Login_Var.lstMenu = user.lstMenu;
                //五分钟后每十分钟更新一次登录时间
                Login_Var.tLoginTime = new System.Threading.Timer(new System.Threading.TimerCallback(UpdateLoginTime), Common.Common_Var.CurrentUser, 300000, 600000);

                FrmMainTab frmMain = new FrmMainTab();
                frmMain.Show();
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "程序异常");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private bool CheckInput()
        {

            if (string.IsNullOrEmpty(txtAccount.Text.Trim()))
            {
                MessageBox.Show("用户名不能为空!");
                Focus_txtAccount();
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show(" 密码不能为空!");
                Focus_txtPassword();
                return false;
            }

            return true;
        }

        private void UpdateLoginTime(object user)
        {
            if (user == null) return;
            if (!(user is UserInfo)) return;

            string strError = string.Empty;
            UserInfo _user = user as UserInfo;

            Login_Func.UpdateLoginTime(ref _user, ref strError);
        }

        private void Focus_txtAccount()
        {
            txtAccount.Focus();
            txtAccount.SelectAll();
        }

        private void Focus_txtPassword()
        {
            txtPassword.Focus();
            txtPassword.SelectAll();
        }
        #endregion


    }
}
