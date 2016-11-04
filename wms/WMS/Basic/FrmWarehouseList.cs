using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WMS.Basic
{
    public partial class FrmWarehouseList : Common.FrmBasic
    {
        private DividPage _serverMainPage;
        private WarehouseInfo queryMain;
        private List<WarehouseInfo> lstMain;

        public FrmWarehouseList()
        {
            InitializeComponent();

            Common.Common_Func.DelDataGridViewSortable(dgvList);
        }

        private void FrmWarehouseList_Load(object sender, EventArgs e)
        {
            SetSearchBtn();
            InitForm();
        }

        private void FrmWarehouseList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.Common_Func.RemoveTabPageForm(this);
        }

        private void tsmiAddWarehouse_Click(object sender, EventArgs e)
        {
            AddWarehouse();
        }

        private void tsmiDelWarehouse_Click(object sender, EventArgs e)
        {
            DelWarehouse();
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
            EditWarehouse(e);
        }

        private void pageList_ChensPageChange(object sender, EventArgs e)
        {
            GetListQueryData();
        }

        #region Function

        private void InitForm()
        {
            InitMainQuery();

            //GetListQueryData();
        }

        private void InitMainQuery()
        {
            _serverMainPage = new DividPage();
            queryMain = new WarehouseInfo();
            lstMain = new List<WarehouseInfo>();

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
                bResult = Basic_Func.GetWarehouseListByPage(ref lstMain, queryMain, ref _serverMainPage, ref strErr);
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
                txtWarehouseNo.Focus();
            }
        }

        private void GetQueryMain()
        {
            if (queryMain == null) { queryMain = new WarehouseInfo(); bsMain.DataSource = queryMain; }
            queryMain.Creater = txtCreater.Text.Trim();
            if (dtpStartTime.Checked) queryMain.StartTime = dtpStartTime.Value;
            else queryMain.StartTime = null;
            if (dtpEndTime.Checked) queryMain.EndTime = dtpEndTime.Value;
            else queryMain.EndTime = null;
        }

        private void AddWarehouse()
        {
            WarehouseInfo warehouse = new WarehouseInfo() { ID = 0 };

            ShowFileForm(warehouse);
        }

        private void DelWarehouse()
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList))
            {
                Common.Common_Func.ErrorMessage("请先选中一行", "删除失败");
                return;
            }

            DeleteListRow(dgvList.CurrentCell.RowIndex);
        }

        private void DeleteListRow(int iRowIndex)
        {
            WarehouseInfo warehouse = GetListRowModel(iRowIndex);
            if (warehouse == null) return;

            if (MessageBox.Show(string.Format("是否确认删除仓库【{0}】?", warehouse.WarehouseName), "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No) return;

            try
            {
                if (warehouse.IsDel != 2)
                {
                    string strErr = string.Empty;
                    if (!Basic_Func.DeleteWarehouseByID(warehouse, ref strErr))
                    {
                        Common.Common_Func.ErrorMessage(strErr, "删除失败");
                        return;
                    }
                }

                Common.Common_Func.ErrorMessage("删除仓库成功", "删除成功");
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

        private void EditWarehouse(DataGridViewCellEventArgs e)
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList, e, "编辑")) return;

            EditListRow(e.RowIndex);
        }

        private void EditListRow(int iRowIndex)
        {
            WarehouseInfo warehouse = GetListRowModel(iRowIndex);
            if (warehouse == null) return;

            ShowFileForm(warehouse);
        }

        private WarehouseInfo GetListRowModel(int iRowIndex)
        {
            string strErr = string.Empty;
            WarehouseInfo warehouse = new WarehouseInfo();
            warehouse.ID = lstMain[iRowIndex].ID;

            if (!Basic_Func.GetWarehouseByID(ref warehouse, ref strErr))
            {
                Common.Common_Func.ErrorMessage(strErr, "读取失败");
                GetListQueryData();
                return null;
            }

            return warehouse;
        }

        private void ShowFileForm(WarehouseInfo warehouse)
        {
            using (FrmWarehouseFile frm = new FrmWarehouseFile(warehouse))
            {
                frm.ShowDialog();
            }

            this.Refresh();
            Application.DoEvents();

            GetListQueryData();
        }

        private void SetSearchBtn()
        {
            Common.Common_Func.SetSearchBtn(this, dtpEndTime, btnSearch, tsmiSearch);
        }

        #endregion
    }
}
