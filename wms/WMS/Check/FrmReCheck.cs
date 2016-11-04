using WMS.Common;
using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WMS.Check
{
    public partial class FrmReCheck : Common.FrmBaseDialog
    {
        private CheckInfo _check;
        private CheckInfo _recheck;
        private DividPage _serverMainPage;
        private CheckDetailsInfo queryMain;
        private List<CheckDetailsInfo> lstMain;

        public FrmReCheck()
        {
            InitializeComponent();

            Common.Common_Func.DelDataGridViewSortable(dgvList);
            this._check = new CheckInfo();
        }

        public FrmReCheck(CheckInfo check)
        {
            InitializeComponent();
            Common.Common_Func.DelDataGridViewSortable(dgvList);
            // TODO: Complete member initialization
            this._check = check;
        }

        private void FrmReCheck_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void tsmiSearch_Click(object sender, EventArgs e)
        {
            BindList();
        }

        private void tsmiReCheck_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                this.Close();
            }
        }

        private void tsmiExport_Click(object sender, EventArgs e)
        {
            //ExportList();
        }

        private void tsmiCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lblDifferenceQty_TextChanged(object sender, EventArgs e)
        {
            if (_check.DifferenceQty < 0)
            {
                lblDifferenceQty.ForeColor = Color.Red;
            }
            else if (_check.DifferenceQty > 0)
            {
                lblDifferenceQty.ForeColor = Color.Green;
            }
            else
            {
                lblDifferenceQty.ForeColor = Color.Black;
            }
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //CheckTrans(e);
        }

        private void dgvList_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll) return;

            cbxSelectAll.Visible = e.NewValue == 0;
        }

        private void pageList_ChensPageChange(object sender, EventArgs e)
        {
            GetListQueryData();
        }

        private void cbxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            SelectAll();
        }

        #region Function

        private void InitForm()
        {
            InitMainQuery();

            BindComboBoxs();

            BindList();

            if (lstMain == null || lstMain.Count <= 0)
            {
                tsmiReCheck.Enabled = false;
                Common.Common_Func.ErrorMessage("此盘点单没有差异记录");
            }
        }

        private void BindComboBoxs()
        {
            bsMain.ResetBindings(false);
            bsMain.EndEdit();
        }

        private void InitMainQuery()
        {
            _recheck = new CheckInfo();
            _serverMainPage = new DividPage();
            queryMain = new CheckDetailsInfo();
            lstMain = new List<CheckDetailsInfo>();

            pageList.GetShowCountsByDGV(dgvList);
            bsMain.DataSource = queryMain;
            bsCheck.DataSource = _check;
            bsCheck.ResetBindings(false);
            bsCheck.EndEdit();

            switch (_check.CheckType)
            {
                case 1:
                    colWarehouseNo.Visible = true;
                    colWarehouseName.Visible = true;
                    break;

                case 2:
                    colHouseNo.Visible = true;
                    colHouseName.Visible = true;
                    break;

                case 3:
                    colAreaNo.Visible = true;
                    colAreaName.Visible = true;
                    break;

                case 4:
                    colMaterialNo.Visible = true;
                    colMaterialDesc.Visible = true;
                    break;

                case 5:
                    colWarehouseNo.Visible = true;
                    colWarehouseName.Visible = true;
                    colMaterialNo.Visible = true;
                    colMaterialDesc.Visible = true;
                    break;

                default:
                    Common.Common_Func.ErrorMessage("盘点类型传入错误,请重新打开", "错误");
                    this.Close();
                    break;
            }
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

                pageList.dDividPage.CurrentPageNumber = 1;
                pageList.CurrentPageShowCounts = -1;

                ChensControl.DividPage clientPage = pageList.dDividPage;
                Common.Common_Func.GetServerPageFromClientPage(ref _serverMainPage, clientPage);
                bResult = Check_Func.GetCheckAnalyseListByPage(ref lstMain, queryMain, ref _serverMainPage, ref strErr);
                Common.Common_Func.GetClientPageFromServerPage(_serverMainPage, ref clientPage);
                pageList.ShowPage();
                dgvList.DataSource = lstMain;

                if (!bResult || !string.IsNullOrEmpty(strErr)) Common.Common_Func.ErrorMessage(strErr, "查询失败", 2);

                if (dgvList.DataSource == null || dgvList.Rows.Count <= 0)
                {
                }
                else
                {
                    dgvList.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                }
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "查询失败", 2);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void GetQueryMain()
        {
            if (queryMain == null) { queryMain = new CheckDetailsInfo(); bsMain.DataSource = queryMain; }
            queryMain.CheckID = _check.ID;
            queryMain.CheckType = _check.CheckType;
            queryMain.HaveDiff = 2;
        }

        private void ShowProfitLoss(DataGridViewCellEventArgs e)
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList, e, "编辑", "查看")) return;
            if (!Common.Common_Func.CheckDgvOper(dgvList, e)) return;

            ShowProfitLossForm(e.RowIndex);
        }

        private void ShowProfitLossForm(int iRowIndex)
        {
            CheckDetailsInfo detail = GetListRowModel(iRowIndex);
            if (detail == null) return;

            using (FrmCheckProfitLoss frm = new FrmCheckProfitLoss(detail))
            {
                frm.ShowDialog();
            }
        }

        private CheckDetailsInfo GetListRowModel(int iRowIndex)
        {
            return lstMain[iRowIndex];
        }

        private void ExportList()
        {
            pageList.dDividPage.CurrentPageNumber = 1;
            pageList.CurrentPageShowCounts = -1;
            GetListQueryData();
            ExcelLibrary.ExcelLibrary_Func.SaveDataGridViewToExcelByNPOI(dgvList);
        }

        private bool SaveData()
        {
            cbxSelectAll.Focus();
            dgvList.EndEdit();
            bsMain.EndEdit();

            GetReCheckData();

            if (!CheckInput()) return false;

            string strErr = string.Empty;
            if (Check_Func.SaveCheck(ref _recheck, ref strErr))
            {
                Common.Common_Func.ErrorMessage(string.Format("复盘单保存成功！{0}盘点单号为：【{1}】", Environment.NewLine, _recheck.CheckNo), "保存成功");
                //bsMain.DataSource = _recheck;
                //InitForm();
                tsmiReCheck.Enabled = false;
                gbBottom.Enabled = false;
                return true;
            }
            else
            {
                Common.Common_Func.ErrorMessage(strErr, "保存失败", 2);
                //bsMain.DataSource = _recheck;
                return false;
            }
        }

        private void GetReCheckData()
        {
            _recheck = new CheckInfo();
            _recheck.ID = 0;
            _recheck.CheckType = _check.CheckType;
            _recheck.DutyUser = _check.DutyUser;
            _recheck.CheckDesc = _check.CheckDesc;
            _recheck.MainCheckID = _check.ID;
            _recheck.CheckStatus = 1;
            _recheck.CheckStyle = 2;
            _recheck.IsDel = 1;
            _recheck.lstDetails = new List<CheckDetailsInfo>();
            foreach (DataGridViewRow dgvr in dgvList.Rows)
            {
                if (dgvr.Cells["colSelect"].Value.ToBoolean())
                {
                    _recheck.lstDetails.Add(lstMain[dgvr.Index]);
                }
            }

        }

        private bool CheckInput()
        {
            if (_recheck.lstDetails == null || _recheck.lstDetails.Count <= 0)
            {
                return Common_Func.ErrorMessage("盘点信息必须勾选", "保存失败", 2);
            }

            return true;
        }

        private void SelectAll()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Common.Common_Func.SetSelectAll(dgvList, cbxSelectAll.Checked);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

    }
}
