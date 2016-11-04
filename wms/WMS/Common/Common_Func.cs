using WMS.WebService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS.Common
{
    public class Common_Func
    {

        public static void UserLogout()
        {
            if (Common.Common_Var.CurrentUser != null && Common.Common_Var.CurrentUser.ID >= 1)
            {
                try
                {
                    string strError = string.Empty;
                    Basic.Basic_Func.ClearLoginTime(Common.Common_Var.CurrentUser, ref strError);
                }
                finally
                {
                    if (Login.Login_Var.tLoginTime != null) Login.Login_Var.tLoginTime.Dispose();
                    Common.Common_Var.CurrentUser = null;
                }
            }
        }

        public static bool GetComboBoxItemByKey(string key, ref List<ComboBoxItem> cbbItemList, ref string strError)
        {
            return WMSWebService.service.GetComboBoxItemByKey(key, ref cbbItemList, ref strError);
        }

        public static List<ComboBoxItem> GetComboBoxItem(string strSql)
        {
            return WMSWebService.service.GetComboBoxItem(strSql);
        }

        public static void BindComboBox(string strSql, ComboBox cbb)
        {
            cbb.DataSource = Common_Func.GetComboBoxItem(strSql);
            cbb.DisplayMember = "Name";
            cbb.ValueMember = "ID";
        }

        public static void BindComboBox(List<ComboBoxItem> comboxBoxItemList, ComboBox cbb)
        {
            cbb.DataSource = comboxBoxItemList;
            cbb.DisplayMember = "Name";
            cbb.ValueMember = "ID";
        }


        public static void BindComboBoxAddAll(List<ComboBoxItem> comboxBoxItemList, ComboBox cbb)
        {
            ComboBoxItem item = new ComboBoxItem();
            item.ID = 0;
            item.Name = "所有";
            comboxBoxItemList.Insert(0, item);

            cbb.DataSource = comboxBoxItemList;
            cbb.DisplayMember = "Name";
            cbb.ValueMember = "ID";
        }

        public static void BindComboBoxAddAll(string strSql, ComboBox cbb)
        {
            List<ComboBoxItem> itemList = Common_Func.GetComboBoxItem(strSql);

            List<ComboBoxItem> itemAll = new List<ComboBoxItem>();

            ComboBoxItem item = new ComboBoxItem();
            item.ID = 0;
            item.Name = "所有";

            itemAll.Add(item);

            foreach (ComboBoxItem item1 in itemList)
            {
                itemAll.Add(item1);
            }

            cbb.DataSource = itemAll;
            cbb.DisplayMember = "Name";
            cbb.ValueMember = "ID";
        }

        /// <summary>
        /// 关闭标签页显示的窗体
        /// </summary>
        /// <param name="frmShow">显示的窗体</param>
        /// <param name="typeParent">父窗体类型</param>
        /// <param name="CloseStyle">关闭方式 1-存在父窗体则激活;2-存在父窗体则激活,不存在父窗体则重建</param>
        public static void CloseTabPageForm(Form frmShow, Type typeParent = null, int CloseStyle = 1)
        {
            try
            {
                if (frmShow == null || frmShow.Parent == null || !(frmShow.Parent is TabPage))
                {
                    return;
                }

                TabPage tp = frmShow.Parent as TabPage;
                if (tp.Parent == null || !(tp.Parent is TabControl))
                {
                    return;
                }

                if (typeParent == null)
                {
                    MenuInfo menu = Login.Login_Var.lstMenu.FirstOrDefault(t => t.ProjectName == frmShow.GetType().Name);
                    if (menu == null)
                    {
                        return;
                    }

                    MenuInfo parent = Login.Login_Var.lstMenu.FirstOrDefault(t => t.ID == menu.ParentID);
                    if (parent == null)
                    {
                        return;
                    }

                    typeParent = frmShow.GetType().Assembly.GetType(Basic.Basic_Var.dicFormPath[parent.ProjectName]);
                }

                TabControl tc = tp.Parent as TabControl;
                foreach (TabPage p in tc.TabPages)
                {
                    if (p.Controls != null && p.Controls.Count >= 1)
                    {
                        if (p.Controls[0].GetType() == typeParent)
                        {
                            tc.SelectedTab = p;
                            return;
                        }
                    }
                }
                if (CloseStyle == 2)
                {
                    Form frm = (Form)Activator.CreateInstance(typeParent);
                    FrmMainTab frmMain = tc.TopLevelControl as FrmMainTab;
                    frmMain.ShowForm(frm.Text, frm);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
            }
            finally
            {
                //frmShow.Close();
            }
        }

        /// <summary>
        /// YES/NO提示框
        /// </summary>
        /// <param name="text">提示信息</param>
        /// <param name="caption">信息标题</param>
        /// <param name="grade">提示等级: 1-提示 2-警告 3-错误</param>
        /// <returns></returns>
        public static bool DialogMessage(string text, string caption = "", int grade = 2)
        {
            MessageBoxIcon icon;
            switch (grade)
            {
                case 1:
                    if (string.IsNullOrEmpty(caption)) caption = "提示";
                    icon = MessageBoxIcon.Information;
                    break;
                case 2:
                    if (string.IsNullOrEmpty(caption)) caption = "警告";
                    icon = MessageBoxIcon.Warning;
                    break;
                case 3:
                    if (string.IsNullOrEmpty(caption)) caption = "错误";
                    icon = MessageBoxIcon.Error;
                    break;
                default:
                    icon = MessageBoxIcon.None;
                    break;
            }

            return MessageBox.Show(text, caption, MessageBoxButtons.YesNo, icon, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        public static void BindComboBoxAddAllByKey(string key, ComboBox cbb)
        {
            try
            {
                List<ComboBoxItem> itemList = new List<ComboBoxItem>();
                string strError = "";
                bool succ = GetComboBoxItemByKey(key, ref  itemList, ref strError);

                if (!succ)
                {
                    MessageBox.Show(strError);
                    return;
                }

                List<ComboBoxItem> itemAll = new List<ComboBoxItem>();

                ComboBoxItem item = new ComboBoxItem();
                item.ID = 0;
                item.Name = "所有";

                itemAll.Add(item);

                foreach (ComboBoxItem item1 in itemList)
                {
                    itemAll.Add(item1);
                }

                cbb.DataSource = itemAll;
                cbb.DisplayMember = "Name";
                cbb.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void BindComboxBoxByKey(string key, ComboBox cbb)
        {
            try
            {
                string strError = "";
                List<ComboBoxItem> comboBoxItemList = new List<ComboBoxItem>();
                bool succ = GetComboBoxItemByKey(key, ref  comboBoxItemList, ref strError);
                if (succ)
                {
                    cbb.DataSource = comboBoxItemList;
                    cbb.DisplayMember = "Name";
                    cbb.ValueMember = "ID";

                    return;
                }
                else
                {
                    MessageBox.Show(strError);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void BindComboxBoxByKey(string key, DataGridViewComboBoxColumn cbb)
        {
            try
            {
                string strError = "";
                List<ComboBoxItem> comboBoxItemList = new List<ComboBoxItem>();
                bool succ = GetComboBoxItemByKey(key, ref  comboBoxItemList, ref strError);
                if (succ)
                {
                    cbb.DataSource = comboBoxItemList;
                    cbb.DisplayMember = "Name";
                    cbb.ValueMember = "ID";

                    return;
                }
                else
                {
                    MessageBox.Show(strError);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static bool ErrorMessage(string text, string caption = "", int grade = 1)
        {
            MessageBoxIcon icon;
            switch (grade)
            {
                case 1:
                    if (string.IsNullOrEmpty(caption)) caption = "提示";
                    icon = MessageBoxIcon.Information;
                    break;
                case 2:
                    if (string.IsNullOrEmpty(caption)) caption = "警告";
                    icon = MessageBoxIcon.Warning;
                    break;
                case 3:
                    if (string.IsNullOrEmpty(caption)) caption = "错误";
                    icon = MessageBoxIcon.Error;
                    break;
                default:
                    icon = MessageBoxIcon.None;
                    break;
            }
            MessageBox.Show(text, caption, MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1);
            return false;
        }

        public static bool ErrorMessage(string text, Control ctl, bool isLoud = true)
        {
            if (isLoud)
            {
                BeepUp.DoShine(ctl);

                BeepUp.Waringbeep();
            }

            ctl.Text = text;
            return false;
        }

        public static void RemoveTabPageForm(Form frm)
        {
            try
            {
                if (frm.Parent != null && frm.Parent.Parent != null)
                {
                    frm.Parent.Parent.Controls.Remove(frm.Parent);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
            }
        }

        public static void ShowTabPageForm(Form frmParent, Form frmShow, int OpenStyle = 1)
        {
            try
            {
                object obj = frmParent.Parent.Parent.Parent.Parent.Parent;
                if (obj == null || obj.GetType().Name != typeof(FrmMainTab).Name) return;

                FrmMainTab frmMain = obj as FrmMainTab;
                frmMain.ShowForm(frmShow.Text, frmShow, OpenStyle);
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
            }
        }
        public static void DelDataGridViewSortable(DataGridView dg)
        {
            dg.AutoGenerateColumns = false;
            foreach (DataGridViewColumn dgCol in dg.Columns)
            {
                dgCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        /// <summary>
        /// 把客户端的Page转换成服务器的Page
        /// </summary>
        /// <param name="serverPage"></param>
        /// <param name="clientPage"></param>
        /// <returns></returns>
        public static void GetServerPageFromClientPage(ref DividPage serverPage, ChensControl.DividPage clientPage)
        {
            if (serverPage == null) serverPage = new DividPage();
            serverPage.CurrentPageNumber = clientPage.CurrentPageNumber;
            serverPage.CurrentPageShowCounts = clientPage.CurrentPageShowCounts;
        }
        /// <summary>
        /// 把服务器的Page转换成客户端的Page
        /// </summary>
        /// <param name="serverPage"></param>
        /// <param name="clientPage"></param>
        public static void GetClientPageFromServerPage(DividPage serverPage, ref ChensControl.DividPage clientPage)
        {
            if (clientPage == null) clientPage = new ChensControl.DividPage();
            clientPage.RecordCounts = serverPage.RecordCounts;
            clientPage.CurrentPageNumber = serverPage.CurrentPageNumber;
            clientPage.CurrentPageShowCounts = serverPage.CurrentPageShowCounts;
            clientPage.CurrentPageRecordCounts = serverPage.CurrentPageRecordCounts;
            clientPage.PagesCount = serverPage.PagesCount;
        }

        public static bool EqualsValues(object objA, object objB)
        {
            if (objA.GetType() != objB.GetType()) return false;

            PropertyInfo[] arrPi = objA.GetType().GetProperties();
            object piA, piB;
            foreach (PropertyInfo pi in arrPi)
            {
                piA = pi.GetValue(objA, null);
                piB = pi.GetValue(objB, null);

                if (piA == null && piB == null) continue;
                if (piA == null || piB == null) return false;
                if (piA.ToString() != piB.ToString()) return false;
            }

            return true;
        }

        public static T ConvertToModel<T>(object model) where T : new()
        {
            T t = new T();
            if (typeof(T).Name != model.GetType().Name) return t;

            PropertyInfo[] arrMPi = model.GetType().GetProperties();
            PropertyInfo[] arrPi = t.GetType().GetProperties();

            PropertyInfo temp = null;
            foreach (PropertyInfo pi in arrPi)
            {
                temp = arrMPi.First<PropertyInfo>(p => p.Name == pi.Name);
                if (temp == null) continue;
                try
                {
                    pi.SetValue(t, temp.GetValue(model, null), null);
                }
                catch { }
            }

            return t;
        }

        public static bool CheckDgvOper(DataGridView dgv)
        {
            if (dgv.DataSource == null || dgv.Rows.Count <= 0) return false;

            if (dgv.CurrentCell.ColumnIndex < 0 || dgv.CurrentCell.ColumnIndex > dgv.Columns.Count) return false;

            if (dgv.CurrentCell.RowIndex < 0 || dgv.CurrentCell.RowIndex > dgv.Rows.Count) return false;

            return true;
        }

        public static bool CheckDgvOper(DataGridView dgv, DataGridViewCellEventArgs e, string oper = "")
        {
            if (dgv.DataSource == null || dgv.Rows.Count <= 0) return false;

            if (e.ColumnIndex < 0 || e.ColumnIndex > dgv.Columns.Count) return false;

            if (e.RowIndex < 0 || e.RowIndex > dgv.Rows.Count) return false;

            if (!string.IsNullOrEmpty(oper))
            {
                DataGridViewCell cell = dgv[e.ColumnIndex, e.RowIndex];
                if (cell.FormattedValue.ToString() != oper) return false;
            }

            return true;
        }

        public static bool CheckDgvOper(DataGridView dgv, DataGridViewCellEventArgs e, params string[] oper)
        {
            if (dgv.DataSource == null || dgv.Rows.Count <= 0) return false;

            if (e.ColumnIndex < 0 || e.ColumnIndex > dgv.Columns.Count) return false;

            if (e.RowIndex < 0 || e.RowIndex > dgv.Rows.Count) return false;

            if (oper != null)
            {
                DataGridViewCell cell = dgv[e.ColumnIndex, e.RowIndex];
                if (!oper.Contains(cell.FormattedValue.ToString())) return false;
            }

            return true;
        }

        public static bool CheckDgvClick(DataGridView dgv, int iRowIndex)
        {
            if (dgv.DataSource == null) return false;

            if (dgv.Rows.Count <= 0) return false;

            if (iRowIndex < 0 || iRowIndex >= dgv.Rows.Count) return false;

            return true;
        }

        public static void SetSelectAll(DataGridView dgv, bool isSelect, string colCheck = "colSelect")
        {
            try
            {
                dgv.Enabled = false;

                foreach (DataGridViewRow dr in dgv.Rows)
                {
                    dr.Cells[colCheck].Value = isSelect;
                }
            }
            finally
            {
                dgv.Enabled = true;
            }
        }

        public static void SetSearchBtn(Form frm, Control ctlRight, Button btnSearch, ToolStripMenuItem tsmiSearch)
        {
            if (ctlRight.Right >= btnSearch.Left || frm.Width <= ctlRight.Right + btnSearch.Width)
            {
                btnSearch.Visible = false;
                tsmiSearch.Visible = true;
            }
            else
            {
                btnSearch.Visible = true;
                tsmiSearch.Visible = false;
            }
        }

        public static bool IsIncludeChinese(string text)
        {
            return Regex.IsMatch(text, @"[\u4e00-\u9fa5]");
        }

        public static bool CheckImportTable(ImportType type, ref string strError)
        {
            return WMSWebService.service.CheckImportTable((int)type, Common_Var.CurrentUser, ref strError);
        }

        public static bool UpLoadSql(List<string> lstSql, ref string strError)
        {
            bool bResult = false;
            int UploadCount = 0;
            int ErrorCount = 0;
            int indexD = 0;
            int indexT = 0;

            try
            {
                ArrayOfString arr = new ArrayOfString();
                while (lstSql.Count >= Common_Var.OnceImportSize)
                {
                    arr = new ArrayOfString();
                    arr.AddRange(lstSql.GetRange(0, Common_Var.OnceImportSize - 1));
                    bResult = WMSWebService.service.UpLoadSql(arr, Common_Var.CurrentUser, ref strError);
                    if (bResult)
                    {
                        UploadCount += Common_Var.OnceImportSize;
                        lstSql.RemoveRange(0, Common_Var.OnceImportSize - 1);
                    }
                    else
                    {
                        indexD = strError.IndexOf("第");
                        indexT = strError.IndexOf("条");
                        if (indexT > indexD && indexD >= 0)
                        {
                            string strCount = strError.Substring(indexD + 1, indexT - indexD - 1);
                            ErrorCount = Convert.ToInt32(strCount);
                            strError = string.Format("{0}{1}{2}", strError.Substring(0, indexD + 1), UploadCount + ErrorCount, strError.Substring(indexT));
                        }
                        return bResult;
                    }
                }

                if (lstSql.Count >= 1)
                {
                    arr = new ArrayOfString();
                    arr.AddRange(lstSql);
                    bResult = WMSWebService.service.UpLoadSql(arr, Common_Var.CurrentUser, ref strError);
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                bResult = false;
            }

            if (bResult)
            {
                UploadCount += lstSql.Count;
                return bResult;
            }
            else
            {
                indexD = strError.IndexOf("第");
                indexT = strError.IndexOf("条");
                if (indexT > indexD && indexD >= 0)
                {
                    string strCount = strError.Substring(indexD + 1, indexT - indexD - 1);
                    ErrorCount = Convert.ToInt32(strCount);
                    strError = string.Format("{0}{1}{2}", strError.Substring(0, indexD + 1), UploadCount + ErrorCount, strError.Substring(indexT));
                }
                return bResult;
            }
        }

        //public static bool DealImport(ImportType type, ref string strError)
        //{
        //    return WMSWebService.service.DealImport((int)type, Common_Var.CurrentUser, ref strError);
        //}

        public static bool ShowSaveDialog(ref string strFileName, string strExtName = "xls")
        {
            //申明保存对话框   
            SaveFileDialog dlg = new SaveFileDialog();
            //默认文件后缀   
            dlg.DefaultExt = strExtName;
            //文件后缀列表  
            switch (strExtName)
            {
                case "xls":
                    dlg.Filter = "EXCEL 97-2003 工作簿(*.XLS)|*.xls|所有文件(*.*)|*.* ";
                    break;

                case "xlsx":
                    dlg.Filter = "EXCEL 工作簿(*.XLSX,*.XLS)|*.xlsx;*.xls|所有文件(*.*)|*.* ";
                    break;

                case "txt":
                    dlg.Filter = "文本文档(*.TXT)|*.txt|所有文件(*.*)|*.* ";
                    break;

                case "sql":
                    dlg.Filter = "SQL脚本(*.SQL)|*.sql|所有文件(*.*)|*.* ";
                    break;

                default:
                    dlg.Filter = "所有文件(*.*)|*.* ";
                    break;
            }
            //默然路径是桌面路径   
            if (string.IsNullOrEmpty(strFileName))
            {
                strFileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                dlg.InitialDirectory = strFileName;
            }
            else if (Directory.Exists(strFileName))
            {
                dlg.InitialDirectory = strFileName;
            }
            else if (File.Exists(strFileName))
            {
                dlg.InitialDirectory = Path.GetDirectoryName(strFileName);
                dlg.FileName = Path.GetFileName(strFileName);
            }
            else
            {
                if (strFileName.IndexOf('/') == -1 && strFileName.IndexOf('\\') == -1)
                {
                    strFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), strFileName);
                }
                dlg.FileName = strFileName;
                dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            //打开保存对话框   
            if (dlg.ShowDialog() == DialogResult.Cancel) return false;
            //返回文件路径   
            strFileName = dlg.FileName;
            return true;
        }

        public static bool SaveBytesToFile(string path, byte[] bytes)
        {
            try
            {
                File.WriteAllBytes(path, bytes);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool IsWarehouseUserNo(string text)
        {
            return Regex.IsMatch(text, @"^[A-Z]{1}[0-9]{4}$");
        }
    }
}
