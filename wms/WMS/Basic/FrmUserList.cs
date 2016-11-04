using WMS.Common;
//using ExcelLibrary;
using WMS.WebService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS.Basic
{
    public partial class FrmUserList : Common.FrmBasic
    {
        private DividPage _serverMainPage;
        private UserInfo queryMain;
        private List<UserInfo> lstMain;

        public FrmUserList()
        {
            InitializeComponent();

            Common.Common_Func.DelDataGridViewSortable(dgvList);
        }

        private void FrmUserList_Load(object sender, EventArgs e)
        {
            SetSearchBtn();
            InitForm();
        }

        private void FrmUserList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.Common_Func.RemoveTabPageForm(this);
        }

        private void tsmiAddUser_Click(object sender, EventArgs e)
        {
            AddUser();
        }

        private void tsmiDelUser_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        private void tsmiResetPwd_Click(object sender, EventArgs e)
        {
            ResetPwd();
        }

        private void tsmiOutput_Click(object sender, EventArgs e)
        {

        }

        private void tsmiClear_Click(object sender, EventArgs e)
        {
            ClearLoginInfo();
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    this.Cursor = Cursors.WaitCursor;

                    BindList();
                }
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindList();
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EditUser(e);
        }

        private void pageList_ChensPageChange(object sender, EventArgs e)
        {
            GetListQueryData();
        }


        #region Function

        private void InitForm()
        {
            if (!Common_Var.CurrentUser.BIsAdmin) tsmiClear.Visible = false;
            if (!Common_Var.CurrentUser.BIsAdmin) colHLoginDevice.Visible = false;

            InitMainQuery();

            BindComboboxs();

            //BindList();
        }

        private void BindComboboxs()
        {
            Common_Func.BindComboBoxAddAll(Basic_Func.GetIsOnline(), cbbIsOnline);
        }

        private void InitMainQuery()
        {
            _serverMainPage = new DividPage();
            queryMain = new UserInfo();
            lstMain = new List<UserInfo>();

            pageList.GetShowCountsByDGV(dgvList);
            bsMain.DataSource = queryMain;
        }

        private void AddUser()
        {
            AddListModel();
        }

        private void DeleteUser()
        {
            if (!CheckOpear("删除")) return;

            DelListModel(dgvList.SelectedRows[0].Index);
        }

        private void ResetPwd()
        {
            if (!CheckOpear("重置")) return;

            RePwdListModel(dgvList.SelectedRows[0].Index);
        }

        private void EditUser(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex >= dgvList.Rows.Count) return;

            EditListModel(e.RowIndex, e.ColumnIndex);
        }

        private void ClearLoginInfo()
        {
            if (!Common_Func.CheckDgvOper(dgvList)) return;

            ClearListModel(dgvList.SelectedRows[0].Index);
        }

        private void BindList()
        {
            bsMain.EndEdit();

            pageList.dDividPage.CurrentPageNumber = 1;
            GetListQueryData();
        }
        private void GetListQueryData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bsMain.EndEdit();

                bool bResult = false;
                string strErr = string.Empty;
                GetQueryMain();

                ChensControl.DividPage clientPage = pageList.dDividPage;
                Common.Common_Func.GetServerPageFromClientPage(ref _serverMainPage, clientPage);
                bResult = Basic_Func.GetUserListByPage(ref lstMain, queryMain, ref _serverMainPage, ref strErr);
                Common.Common_Func.GetClientPageFromServerPage(_serverMainPage, ref clientPage);
                pageList.ShowPage();
                dgvList.DataSource = lstMain;

                if (!bResult || !string.IsNullOrEmpty(strErr)) Common.Common_Func.ErrorMessage(strErr, "查询失败");
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "查询失败");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                txtUSERNO.Focus();
            }
        }

        private void GetQueryMain()
        {
            if (queryMain == null) { queryMain = new UserInfo(); bsMain.DataSource = queryMain; }
        }

        private void AddListModel()
        {
            UserInfo user = new UserInfo() { ID = 0 };

            ShowFileForm(user);

        }

        private void EditListModel(int iRowIndex, int iColIndex)
        {
            if (dgvList[iColIndex, iRowIndex].FormattedValue.ToString() == "编辑")
            {
                string strErr = string.Empty;
                UserInfo user = new UserInfo();
                user.ID = lstMain[iRowIndex].ID;

                if (!Basic_Func.GetUserByID(ref user, ref strErr))
                {
                    MessageBox.Show(strErr, "编辑失败");
                    GetListQueryData();
                    return;
                }

                ShowFileForm(user);
            }
        }

        private void ShowFileForm(UserInfo user)
        {

            using (FrmUserFile frm = new FrmUserFile(user))
            {
                frm.ShowDialog();
            }

            this.Refresh();
            Application.DoEvents();

            GetListQueryData();
        }
        private UserInfo GetListRowModel(int iRowIndex)
        {
            string strErr = string.Empty;
            UserInfo user = new UserInfo();
            user.ID = lstMain[iRowIndex].ID;

            if (!Basic_Func.GetUserByID(ref user, ref strErr))
            {
                MessageBox.Show(strErr, "读取失败");
                GetListQueryData();
                return null;
            }

            return user;
        }


        private void DelListModel(int iRowIndex)
        {
            UserInfo user = GetListRowModel(iRowIndex);
            if (user == null) return;

            if (MessageBox.Show(string.Format("是否确认删除用户【{0}】?", user.UserName), "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No) return;

            try
            {
                if (user.IsDel != 2)
                {
                    string strErr = string.Empty;
                    if (!Basic_Func.DeleteUserByID(user, ref strErr))
                    {
                        Common.Common_Func.ErrorMessage(strErr, "删除失败");
                        return;
                    }
                }

                Common.Common_Func.ErrorMessage("删除用户成功", "删除成功");
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message);
            }
            finally
            {
                GetListQueryData();
            }

        }

        private void RePwdListModel(int iRowIndex)
        {
            if (iRowIndex < 0 || iRowIndex >= dgvList.Rows.Count) return;

            string strErr = string.Empty;
            UserInfo user = new UserInfo();
            user.ID = lstMain[iRowIndex].ID;

            if (!Basic_Func.GetUserByID(ref user, ref strErr))
            {
                MessageBox.Show(strErr, "重置失败");
                GetListQueryData();
                return;
            }

            //user.Password = Basic_Func.JiaMi(Common_Var.DefaultPwd);
            user.Password = Common_Var.DefaultPwd;

            if (!Basic_Func.SaveUser(ref user, ref strErr))
            {
                MessageBox.Show(strErr, "重置失败");
                GetListQueryData();
                return;
            }
            else
            {
                MessageBox.Show("重置密码为【" + Common_Var.DefaultPwd + "】成功", "重置成功");
            }

            GetListQueryData();

        }

        private void ClearListModel(int iRowIndex)
        {
            UserInfo user = GetListRowModel(iRowIndex);
            if (user == null) return;

            if (MessageBox.Show(string.Format("是否确认清除用户【{0}】的登录记录?", user.UserName), "确认清除", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No) return;

            try
            {
                if (!string.IsNullOrEmpty(user.LoginIP))
                {
                    string strErr = string.Empty;
                    user.UserType = 2;
                    if (!Basic_Func.ClearLoginTime(user, ref strErr))
                    {
                        Common.Common_Func.ErrorMessage(strErr, "清除失败");
                        return;
                    }
                }

                Common.Common_Func.ErrorMessage("清除用户登录记录成功", "清除成功");
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message);
            }
            finally
            {
                GetListQueryData();
            }
        }

        private bool CheckOpear(string opear)
        {
            if (dgvList.SelectedRows == null || dgvList.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选中一行", opear + "失败");
                return false;
            }

            DialogResult dr = MessageBox.Show("您确定要" + opear + "用户 [" + lstMain[dgvList.SelectedRows[0].Index].UserName + "] 吗?", "确认" + opear, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            return dr == DialogResult.Yes;
        }

        private void SetSearchBtn()
        {
            Common.Common_Func.SetSearchBtn(this, cbbIsOnline, btnSearch, tsmiSearch);
        }

        #endregion


    }
}
