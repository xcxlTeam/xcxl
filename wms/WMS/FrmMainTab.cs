using ChensControl;
using WMS.Common;
using WMS.WebService;
using WMS.Login;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WMS
{
    public partial class FrmMainTab : Form
    {
        private int index;
        private Dictionary<string, TabPage> dicTabPages;
        private Dictionary<string, string> dicFormPath;
        Dictionary<int, string> dicParent = new Dictionary<int, string>();

        public FrmMainTab()
        {
            InitializeComponent();
        }

        private void FrmMainTab_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void FrmMainTab_Shown(object sender, EventArgs e)
        {
            InitMenu();
        }

        private void FrmMainTab_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common_Func.UserLogout();
            Application.Exit();
        }

        private void picMin_Click(object sender, EventArgs e)
        {
            //plTop.Visible = false;
            this.WindowState = FormWindowState.Minimized;
        }

        private void picMin_MouseEnter(object sender, EventArgs e)
        {
            picMin.BackColor = Color.RoyalBlue;
        }

        private void picMin_MouseLeave(object sender, EventArgs e)
        {
            picMin.BackColor = plTop.BackColor;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void picClose_MouseEnter(object sender, EventArgs e)
        {
            picClose.BackColor = Color.IndianRed;
        }

        private void picClose_MouseLeave(object sender, EventArgs e)
        {
            picClose.BackColor = plTop.BackColor;
        }

        private void picHeader_MouseMove(object sender, MouseEventArgs e)
        {
            //plTop.Visible = e.Y <= plTop.Size.Height;
        }

        private void picUser_Click(object sender, EventArgs e)
        {
            plUser.Visible = !plUser.Visible;
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void spMain_SplitterMoved(object sender, SplitterEventArgs e)
        {
            Form frm = GetTabPageForm();
            if (frm == null) return;

            frm.WindowState = FormWindowState.Minimized;
            frm.WindowState = FormWindowState.Maximized;
        }

        private void navMenu_MenuButton2Click(object sender, EventArgs e)
        {
            ChensControl.ChensMenuButton2 button = sender as ChensControl.ChensMenuButton2;
            if (string.IsNullOrEmpty(button.jsmodule.moduleClassName)) return;

            BiuldForm(button.jsmodule);
        }

        private void tabForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form frm = GetTabPageForm();
            if (frm == null) return;

            frm.WindowState = FormWindowState.Minimized;
            frm.WindowState = FormWindowState.Maximized;
        }

        private void tabForms_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (tabForms.TabPages == null || tabForms.TabPages.Count <= 0)
            {
                picBackground.Visible = true;
            }
            else if (tabForms.Controls == null || tabForms.Controls.Count <= 0)
            {
                picBackground.Visible = true;
            }
        }

        private void tabForms_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //ClosePage(tabForms.SelectedTab);
        }

        private void tabForms_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < tabForms.TabPages.Count; i++)
                {
                    if (tabForms.GetTabRect(i).Contains(new Point(e.X, e.Y)))
                    {
                        tabForms.SelectedIndex = i;
                        tabForms.ContextMenuStrip = cmsTabPage;
                        break;
                    }
                }
            }
        }

        private void tabForms_MouseLeave(object sender, EventArgs e)
        {
            tabForms.ContextMenuStrip = null;
        }

        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            Form frm = GetTabPageForm();
            if (frm == null) return;

            frm.Refresh();
            ShowForm(frm.Text, frm, 2);
        }

        private void tsmiCloseThis_Click(object sender, EventArgs e)
        {
            ClosePage(tabForms.SelectedTab);
        }

        private void tsmiCloseOther_Click(object sender, EventArgs e)
        {
            foreach (TabPage page in tabForms.TabPages)
            {
                if (page == tabForms.SelectedTab) continue;

                ClosePage(page);
            }
        }

        private void tsmiCloseLeft_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tabForms.SelectedIndex; i++)
            {
                if (ClosePage(tabForms.TabPages[i])) i--;
            }
        }

        private void tsmiCloseRight_Click(object sender, EventArgs e)
        {
            for (int i = tabForms.SelectedIndex + 1; i < tabForms.TabPages.Count; i++)
            {
                if (ClosePage(tabForms.TabPages[i])) i--;
            }
        }
        private void tsmiCloseAll_Click(object sender, EventArgs e)
        {
            foreach (TabPage page in tabForms.TabPages)
            {
                ClosePage(page);
            }
        }

        private void btnChangePwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmChangePwd frm = new FrmChangePwd();
            DialogResult dr = frm.ShowDialog();
            Application.Exit();
        }

        private void lblVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowCurrentVersion();
        }

        #region Function


        private void InitForm()
        {
            this.WindowState = FormWindowState.Normal;
            this.Location = new Point(0, 0);
            this.Width = SystemInformation.WorkingArea.Width;// Screen.PrimaryScreen.Bounds.Width;
            this.Height = SystemInformation.WorkingArea.Height;//Screen.PrimaryScreen.Bounds.Height     

            dicTabPages = new Dictionary<string, TabPage>();
            dicFormPath = new Dictionary<string, string>();
            dicParent = new Dictionary<int, string>();

            index = 0;

            plTop.Size = new Size(this.Width, plTop.Size.Height);
            lblApplicationName.Text = this.Text;
            lblApplicationName.Location = new Point((this.Width - lblApplicationName.Width) / 2, lblApplicationName.Location.Y);

            picMin.BackColor = plTop.BackColor;
            picClose.BackColor = plTop.BackColor;

            picUser.Parent = picHeader;
            picExit.Parent = picHeader;

            lblVersion.Text = Common.Common_Var.AppVersion;
            lblVersion.Location = new Point(navMenu.Width - lblVersion.Width, lblVersion.Location.Y);

            tabForms.TabBackColor = Color.WhiteSmoke;

            spMain.Panel1Collapsed = true;
            this.Refresh();
        }

        private void InitMenu()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                GetFormPath();

                List<JSModule> lstMenu = SetUserMenu();
                if (lstMenu == null || lstMenu.Count <= 0)
                {
                    MessageBox.Show("当前用户没有任何菜单权限", "提示");
                    //JSModules js = new JSModules();
                    //js.InitJSMoudles();
                    //navMenu.SetMenu(js);
                }
                else
                {
                    //转成chenscontrol类的JSMOudles
                    JSModules js = new JSModules();
                    js.modules = lstMenu;
                    navMenu.SetMenu(js);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                spMain.Panel1Collapsed = false;
            }
        }

        private void GetFormPath()
        {
            dicFormPath = new Dictionary<string, string>();

            foreach (Type type in this.GetType().Assembly.GetTypes())
            {
                if (typeof(System.Windows.Forms.Form).IsAssignableFrom(type))
                {
                    if (!dicFormPath.ContainsKey(type.Name))
                    {
                        dicFormPath.Add(type.Name, type.FullName);
                    }
                }
            }

            Basic.Basic_Var.dicFormPath = dicFormPath;
        }

        private List<JSModule> SetUserMenu()
        {
            List<JSModule> lst = new List<JSModule>();
            if (Login.Login_Var.lstMenu == null || Login.Login_Var.lstMenu.Count <= 0) return lst;

            bool haveOpen = false;
            JSModule j;
            List<MenuInfo> _lstMenu;
            dicParent = new Dictionary<int, string>();
            dicParent.Add(0, "0");

            _lstMenu = Login.Login_Var.lstMenu.FindAll(delegate(MenuInfo temp) { return temp.MenuStatus == 1 && temp.MenuType == 1; });
            if (_lstMenu == null || _lstMenu.Count <= 0) return lst;

            //_lstMenu = _lstMenu.OrderBy(temp => temp.NodeLevel).ToList();
            foreach (MenuInfo menu in _lstMenu)
            {
                if (!menu.BIsChecked) continue;
                if (!dicParent.ContainsKey(menu.ParentID)) continue;

                j = new JSModule();
                j.ID = menu.ProjectName;
                j.Level = menu.NodeLevel.ToString();
                j.ParentID = dicParent[menu.ParentID];
                j.Name = menu.MenuName;
                j.moduleClassName = GetMenuForm(menu);
                if (string.IsNullOrEmpty(j.moduleClassName)) continue;
                if (!haveOpen) haveOpen = j.OpenFlag = menu.BIsDefault;
                lst.Add(j);

                if (!dicParent.ContainsKey(menu.ID))
                    dicParent.Add(menu.ID, menu.ProjectName);
            }

            return lst;
        }

        /// <summary>
        /// 获取二级菜单打开的窗体
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        private string GetMenuForm(MenuInfo menu)
        {
            if (menu.NodeLevel <= 1) return menu.NodeUrl;

            string strFormPath;
            Type type;
            //默认窗体或第一个窗体
            MenuInfo form = Login.Login_Var.lstMenu.FirstOrDefault(delegate(MenuInfo temp) { return temp.MenuType == 2 && temp.BIsDefault && temp.ParentID == menu.ID; });
            if (form == null) form = Login.Login_Var.lstMenu.FirstOrDefault(delegate(MenuInfo temp) { return temp.MenuType == 2 && temp.ParentID == menu.ID; });
            if (form == null) return string.Empty;

            strFormPath = form.NodeUrl.Split(':')[0];
            type = Type.GetType(strFormPath);
            if (type != null) return form.NodeUrl;

            string[] arrForm = form.ProjectName.Split(':');
            string strFormName = arrForm[0];

            if (dicFormPath.ContainsKey(strFormName))
            {
                strFormPath = dicFormPath[strFormName];
                return arrForm.Length >= 2 ? strFormPath + ":" + arrForm[1] : strFormPath;
            }

            strFormPath = string.Format("{0}.{1}.{2}", Common.Common_Var.SolutionName, dicParent[menu.ParentID], strFormName);
            type = Type.GetType(strFormPath);
            if (type == null)
            {
                //其他分支下相同窗体
                List<MenuInfo> lst = Login.Login_Var.lstMenu.FindAll(delegate(MenuInfo temp) { return temp.MenuType == 2 && temp.ProjectName == strFormName && temp.ID != form.ID; });
                if (lst == null || lst.Count <= 0) return string.Empty;

                MenuInfo parent;
                MenuInfo forlder;
                foreach (MenuInfo tm in lst)
                {
                    strFormPath = tm.NodeUrl.Split(':')[0];
                    type = Type.GetType(strFormPath);
                    if (type != null) return tm.NodeUrl;

                    parent = Login.Login_Var.lstMenu.FirstOrDefault(delegate(MenuInfo temp) { return temp.ID == tm.ParentID; });
                    if (parent == null) continue;
                    forlder = Login.Login_Var.lstMenu.FirstOrDefault(delegate(MenuInfo temp) { return temp.ID == parent.ParentID; });
                    if (forlder == null) continue;

                    strFormPath = string.Format("{0}.{1}.{2}", Common.Common_Var.SolutionName, forlder.ProjectName, strFormName);
                    type = Type.GetType(strFormPath);
                    if (type == null)
                    {
                        continue;
                    }
                    else
                    {
                        return arrForm.Length >= 2 ? strFormPath + ":" + arrForm[1] : strFormPath;
                    }
                }

                return string.Empty;
            }
            else
            {
                return arrForm.Length >= 2 ? strFormPath + ":" + arrForm[1] : strFormPath;
            }
        }

        private void BiuldForm(JSModule jSModule)
        {
            try
            {
                string moduleClassName = jSModule.moduleClassName;
                Form f;
                string[] arrModule = moduleClassName.Split(':');
                if (arrModule.Length <= 1)
                {
                    Type type = Type.GetType(moduleClassName);
                    if (type == null)
                    {
                        MessageBox.Show("找不到窗体:" + Environment.NewLine + moduleClassName, "错误");
                        return;
                    }
                    f = (Form)Activator.CreateInstance(type);

                    f.Tag = null;
                    ShowForm(jSModule.Name, f);
                }
                else
                {
                    f = CreateParamsForm(arrModule);
                    if (f == null) return;

                    f.Tag = arrModule[1];
                    ShowForm(jSModule.Name, f, 2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
                return;
            }
        }

        private Form CreateParamsForm(string[] arrModule)
        {
            object oForm;
            string strFormName = arrModule[0];
            Type type = Type.GetType(strFormName);
            if (type == null)
            {
                MessageBox.Show("找不到窗体:" + Environment.NewLine + strFormName, "错误");
                return null;
            }

            if (string.IsNullOrEmpty(arrModule[1]))
            {
                oForm = Activator.CreateInstance(type);

                if (oForm == null) return null;
                return (Form)oForm;
            }
            else
            {
                string[] arrParas = arrModule[1].Split(',');
                try
                {
                    oForm = Activator.CreateInstance(type, arrParas);
                }
                catch
                {
                    oForm = Activator.CreateInstance(type);
                }

                if (oForm == null) return null;

                return oForm as Form;
            }
        }

        public void ShowForm(string title, Form frm, int OpenStyle = 1)
        {
            title += "               ";
            TabPage page = CheckCreatePage(frm, OpenStyle);
            if (page == null)
            {
                page = new TabPage();
                page.Name = "Page" + index.ToString();
                page.Text = title;
                page.BorderStyle = BorderStyle.None;
                //page.TabIndex = index;
                tabForms.Controls.Add(page);
                tabForms.SelectedTab = page;

                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.WindowState = FormWindowState.Maximized;
                page.Controls.Add(frm);
                if (OpenStyle != 3) dicTabPages.Add(string.Format("{0}:{1}", frm.Name, frm.Tag), page);
                frm.Show();
            }
            else
            {
                tabForms.SelectedTab = page;
            }

            if (tabForms.TabPages != null && tabForms.TabPages.Count >= 1)
            {
                picBackground.Visible = false;
            }
        }

        /// <summary>
        /// 检查是否创建页签
        /// </summary>
        /// <param name="frm">打开窗体</param>
        /// <param name="OpenStyle">创建方式 1-显示现有窗体;2-覆盖现有窗体;3-打开新窗体</param>
        /// <returns>显示页签</returns>
        private TabPage CheckCreatePage(Form frm, int OpenStyle)
        {
            if (OpenStyle == 3) return null;

            string strFormName = string.Format("{0}:{1}", frm.Name, frm.Tag);
            if (dicTabPages.ContainsKey(strFormName))
            {
                switch (OpenStyle)
                {
                    case 1:
                        if (tabForms.Controls == null || tabForms.Controls.Count <= 0 || tabForms.TabCount <= 0)
                        {
                            dicTabPages.Remove(strFormName);
                            return null;
                        }
                        else
                        {
                            foreach (TabPage page in tabForms.TabPages)
                            {
                                if (page.Controls.Count <= 0) continue;
                                if (page.Controls[0].GetType() == frm.GetType())
                                {
                                    Form f = page.Controls[0] as Form;
                                    if (strFormName == string.Format("{0}:{1}", f.Name, f.Tag))
                                    {
                                        return page;
                                    }
                                }
                            }
                        }
                        dicTabPages.Remove(strFormName);
                        return null;

                    case 2:
                        tabForms.Controls.Remove(dicTabPages[strFormName]);
                        dicTabPages.Remove(strFormName);
                        return null;

                    case 3:
                        return null;

                    default:
                        foreach (TabPage page in tabForms.Controls)
                        {
                            if (page.Controls.Count <= 0) continue;
                            if (page.Controls[0].GetType() == frm.GetType())
                            {
                                return page;
                            }
                        }
                        return null;
                }
            }
            else
            {
                return null;
            }
        }

        private Form GetTabPageForm(TabPage page = null)
        {
            if (page == null) page = tabForms.SelectedTab;
            if (page == null) return null;
            if (page.Controls == null || page.Controls.Count <= 0) return null;
            if (!(page.Controls[0] is Form)) return null;

            Form f = page.Controls[0] as Form;
            return f;
        }

        private bool ClosePage(TabPage page)
        {
            try
            {
                if (page == null) return false;

                Form frm = GetTabPageForm(page);
                if (frm == null) return false;

                dicTabPages.Remove(string.Format("{0}:{1}", frm.Name, frm.Tag));
                frm.Close();
                frm.Dispose();
                page.Dispose();
                frm = null;
                page = null;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void CloseForm()
        {
            if (tabForms.TabPages == null || tabForms.TabPages.Count <= 0) this.Close();

            if (MessageBox.Show("是否确认退出系统?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void ShowCurrentVersion()
        {
            string strError = string.Empty;
            AppVersionInfo av = new AppVersionInfo();
            av.AppVersion = Common_Var.AppVersion;
            av.AppName = Common_Var.SolutionName + ".exe";
            if (!Login_Func.GetAppVersionByVersion(ref av, ref strError))
            {
                MessageBox.Show(strError);
                return;
            }

            using (FrmVersionInfo frm = new FrmVersionInfo(av, false))
            {
                frm.ShowDialog();
            }
        }

        #endregion

    }
}
