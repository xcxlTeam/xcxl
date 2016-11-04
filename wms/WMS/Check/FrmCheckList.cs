using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WMS.Check
{
    public partial class FrmCheckList : Common.FrmBasic
    {
        private DividPage _serverMainPage;
        private CheckInfo queryMain;
        private List<CheckInfo> lstMain;

        public FrmCheckList()
        {
            InitializeComponent();

            Common.Common_Func.DelDataGridViewSortable(dgvList);
        }

        private void FrmCheckList_Load(object sender, EventArgs e)
        {
            SetSearchBtn();
            InitForm();
        }

        private void FrmCheckList_Enter(object sender, EventArgs e)
        {
            GetListQueryData();
        }

        private void FrmCheckList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.Common_Func.RemoveTabPageForm(this);
        }

        private void tsmiAddCheck_Click(object sender, EventArgs e)
        {
            AddCheck();
        }

        private void tsmiDelCheck_Click(object sender, EventArgs e)
        {
            DelCheck();
        }

        private void tsmiDoneCheck_Click(object sender, EventArgs e)
        {
            DoneCheck();
        }

        private void tsmiCancelCheck_Click(object sender, EventArgs e)
        {
            CancelCheck();
        }

        private void tsmiAnalyse_Click(object sender, EventArgs e)
        {
            AnalyseCheck();
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
                Common.Common_Func.ErrorMessage(ex.Message, "程序异常", 3);
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
            EditCheck(e);
        }

        private void pageList_ChensPageChange(object sender, EventArgs e)
        {
            GetListQueryData();
        }

        #region Function

        private void InitForm()
        {
            InitMainQuery();

            BindComboBoxs();
        }

        private void BindComboBoxs()
        {
            Common.Common_Func.BindComboBoxAddAllByKey(cbbCheckType.Name, cbbCheckType);

            Common.Common_Func.BindComboBoxAddAllByKey(cbbCheckStatus.Name, cbbCheckStatus);

            bsMain.ResetBindings(false);
            bsMain.EndEdit();
        }

        private void InitMainQuery()
        {
            _serverMainPage = new DividPage();
            queryMain = new CheckInfo();
            lstMain = new List<CheckInfo>();

            pageList.GetShowCountsByDGV(dgvList);
            bsMain.DataSource = queryMain;
        }

        private void BindList()
        {
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
                bResult = Check_Func.GetCheckListByPage(ref lstMain, queryMain, ref _serverMainPage, ref strErr);
                Common.Common_Func.GetClientPageFromServerPage(_serverMainPage, ref clientPage);
                pageList.ShowPage();
                dgvList.DataSource = lstMain;

                if (!bResult || !string.IsNullOrEmpty(strErr)) Common.Common_Func.ErrorMessage(strErr, "查询失败", 2);
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "查询失败", 2);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                txtCheckNo.Focus();
            }
        }

        private void GetQueryMain()
        {
            if (queryMain == null) { queryMain = new CheckInfo(); bsMain.DataSource = queryMain; }
            queryMain.Creater = txtCreater.Text.Trim();
            if (dtpStartTime.Checked) queryMain.StartTime = dtpStartTime.Value;
            else queryMain.StartTime = null;
            if (dtpEndTime.Checked) queryMain.EndTime = dtpEndTime.Value;
            else queryMain.EndTime = null;
        }

        private void AddCheck()
        {
            CheckInfo check = new CheckInfo() { ID = 0, CheckStyle = 1 };

            ShowFileForm(check);
        }

        private void DelCheck()
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList))
            {
                Common.Common_Func.ErrorMessage("请先选中一行", "删除失败", 2);
                return;
            }

            DeleteListRow(dgvList.CurrentCell.RowIndex);
        }

        private void CancelCheck()
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList)) return;
            CheckInfo check = GetListRowModel(dgvList.CurrentCell.RowIndex);
            if (check == null) return;
            switch (check.CheckStatus)
            {
                case 3:
                    Common.Common_Func.ErrorMessage("该盘点单已经取消盘点", "操作失败", 2);
                    return;

                case 5:
                    Common.Common_Func.ErrorMessage("该盘点单已经盈亏处理", "操作失败", 2);
                    return;
            }

            if (check.BIsMainCheck && check.ReCheckCount >= 1)
            {
                if (!Common.Common_Func.DialogMessage(string.Format("该盘点单生成的{1}张复盘单也将一起取消,是否确认取消盘点【{0}】?", check.CheckNo, check.ReCheckCount), "确认取消")) return;
            }
            else
            {
                if (!Common.Common_Func.DialogMessage(string.Format("是否确认取消盘点【{0}】?", check.CheckNo), "确认取消")) return;
            }

            check.CheckStatus = 3;
            UpdateCheckStatus(check);
        }

        private void DoneCheck()
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList)) return;
            CheckInfo check = GetListRowModel(dgvList.CurrentCell.RowIndex);
            if (check == null) return;
            switch (check.CheckStatus)
            {
                case 3:
                    Common.Common_Func.ErrorMessage("该盘点单已经取消盘点", "操作失败", 2);
                    return;

                case 4:
                    Common.Common_Func.ErrorMessage("该盘点单已经完成盘点", "操作失败", 2);
                    return;

                case 5:
                    Common.Common_Func.ErrorMessage("该盘点单已经盈亏处理", "操作失败", 2);
                    return;
            }

            if (!Common.Common_Func.DialogMessage(string.Format("是否确认完成盘点【{0}】?", check.CheckNo), "确认完成")) return;

            check.CheckStatus = 4;
            UpdateCheckStatus(check);
        }

        private void DeleteListRow(int iRowIndex)
        {
            CheckInfo check = GetListRowModel(iRowIndex);
            if (check == null) return;

            if (!Common.Common_Func.DialogMessage(string.Format("是否确认删除盘点【{0}】?", check.CheckNo), "确认删除")) return;

            try
            {
                if (check.IsDel != 2)
                {
                    string strErr = string.Empty;
                    if (!Check_Func.DeleteCheckByID(check, ref strErr))
                    {
                        Common.Common_Func.ErrorMessage(strErr, "删除失败", 2);
                        return;
                    }
                }

                Common.Common_Func.ErrorMessage("删除盘点成功", "删除成功");
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

        private void EditCheck(DataGridViewCellEventArgs e)
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList, e, "编辑", "查看")) return;

            EditListRow(e.RowIndex);
        }

        private void EditListRow(int iRowIndex)
        {
            CheckInfo check = GetListRowModel(iRowIndex);
            if (check == null) return;

            ShowFileForm(check);
        }

        private CheckInfo GetListRowModel(int iRowIndex)
        {
            string strErr = string.Empty;
            CheckInfo check = new CheckInfo();
            check.ID = lstMain[iRowIndex].ID;

            if (!Check_Func.GetCheckByID(ref check, ref strErr))
            {
                Common.Common_Func.ErrorMessage(strErr, "读取失败", 2);
                GetListQueryData();
                return null;
            }

            return check;
        }

        private void ShowFileForm(CheckInfo check)
        {
            using (FrmCheckFile frm = new FrmCheckFile(check))
            {
                frm.ShowDialog();
            }

            this.Refresh();
            Application.DoEvents();

            GetListQueryData();
        }

        private void AnalyseCheck()
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList)) return;
            CheckInfo check = GetListRowModel(dgvList.CurrentCell.RowIndex);
            if (check == null) return;
            switch (check.CheckStatus)
            {
                case 1:
                    Common.Common_Func.ErrorMessage("该盘点尚未开始", "提示");
                    return;

                case 2:
                    break;

                case 3:
                    Common.Common_Func.ErrorMessage("该盘点已经取消", "读取失败", 2);
                    return;

                case 4:
                case 5:
                    break;

                default:
                    Common.Common_Func.ErrorMessage("盘点信息获取错误", "读取失败", 2);
                    return;
            }

            FrmCheckAnalyse frm = new FrmCheckAnalyse(check);
            Common.Common_Func.ShowTabPageForm(this, frm, 2);
        }

        private void UpdateCheckStatus(CheckInfo check)
        {
            string strError = string.Empty;
            if (!Check_Func.UpdateCheckStatusByID(check, ref strError))
            {
                Common.Common_Func.ErrorMessage(strError, "操作失败", 2);
            }

            GetListQueryData();
        }

        private void SetSearchBtn()
        {
            Common.Common_Func.SetSearchBtn(this, cbbCheckStatus, btnSearch, tsmiSearch);
        }

        #endregion
    }
}
