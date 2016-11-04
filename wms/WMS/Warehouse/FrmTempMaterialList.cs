using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WMS.Warehouse
{
    public partial class FrmTempMaterialList : Common.FrmBasic
    {
        private DividPage _serverMainPage;
        private TempMaterialInfo queryMain;
        private List<TempMaterialInfo> lstMain;

        public FrmTempMaterialList()
        {
            InitializeComponent();

            Common.Common_Func.DelDataGridViewSortable(dgvList);
        }

        private void FrmTempInventoryList_Load(object sender, EventArgs e)
        {
            SetSearchBtn();

            InitForm();
        }

        private void FrmTempMaterialList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.Common_Func.RemoveTabPageForm(this);
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            AddTempMaterial();
        }

        private void tsmiDel_Click(object sender, EventArgs e)
        {
            DelTempMaterial();
        }

        private void tsmiAlter_Click(object sender, EventArgs e)
        {
            AlterTempMaterial();
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
            EditTempMaterialInfo(e);
        }

        private void pageList_ChensPageChange(object sender, EventArgs e)
        {
            GetListQueryData();
        }

        #region Function

        private void InitForm()
        {
            InitMainQuery();

            GetListQueryData();
        }

        private void InitMainQuery()
        {
            _serverMainPage = new DividPage();
            queryMain = new TempMaterialInfo();
            lstMain = new List<TempMaterialInfo>();

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
            bsMain.EndEdit();

            bool bResult = false;
            string strErr = string.Empty;
            GetQueryMain();

            ChensControl.DividPage clientPage = pageList.dDividPage;
            Common.Common_Func.GetServerPageFromClientPage(ref _serverMainPage, clientPage);
            bResult = Warehouse_Func.GetTempMaterialListByPage(ref lstMain, queryMain, ref _serverMainPage, ref strErr);
            Common.Common_Func.GetClientPageFromServerPage(_serverMainPage, ref clientPage);
            pageList.ShowPage();
            dgvList.DataSource = lstMain;

            if (!bResult || !string.IsNullOrEmpty(strErr)) Common.Common_Func.ErrorMessage(strErr, "查询失败");
            txtMaterialNo.Focus();
        }

        private void GetQueryMain()
        {
            if (queryMain == null) { queryMain = new TempMaterialInfo(); bsMain.DataSource = queryMain; }
            if (dtpStartTime.Checked) queryMain.StartTime = dtpStartTime.Value;
            else queryMain.StartTime = null;
            if (dtpEndTime.Checked) queryMain.EndTime = dtpEndTime.Value;
            else queryMain.EndTime = null;
        }

        private void AddTempMaterial()
        {
            TempMaterialInfo tempmaterial = new TempMaterialInfo() { ID = 0 };

            string strError = string.Empty;
            //Warehouse_Func.GetTempMaterialNo(ref tempmaterial, ref strError);
            ShowFileForm(tempmaterial);
        }

        private void DelTempMaterial()
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
            TempMaterialInfo tempmaterial = GetListRowModel(iRowIndex);
            if (tempmaterial == null) return;

            if (MessageBox.Show(string.Format("是否确认删除临时物料【{0}】?", tempmaterial.TempMaterialDesc), "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No) return;

            try
            {
                if (tempmaterial.IsDel != 2)
                {
                    string strErr = string.Empty;
                    if (!Warehouse_Func.DeleteTempMaterialByID(tempmaterial, ref strErr))
                    {
                        Common.Common_Func.ErrorMessage(strErr, "删除失败");
                        return;
                    }
                }

                Common.Common_Func.ErrorMessage("删除临时物料成功", "删除成功");
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

        private void EditTempMaterialInfo(DataGridViewCellEventArgs e)
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList, e, "编辑")) return;

            EditListRow(e.RowIndex);
        }

        private void EditListRow(int iRowIndex)
        {
            TempMaterialInfo warehouse = GetListRowModel(iRowIndex);
            if (warehouse == null) return;

            ShowFileForm(warehouse);
        }

        private void AlterTempMaterial()
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList))
            {
                Common.Common_Func.ErrorMessage("请先选中一行", "删除失败");
                return;
            }

            ShowAlterForm(dgvList.CurrentCell.RowIndex);
        }

        private void ShowAlterForm(int iRowIndex)
        {
            TempMaterialInfo tempmaterial = GetListRowModel(iRowIndex);
            if (tempmaterial == null) return;

            if (!string.IsNullOrEmpty(tempmaterial.MaterialNo))
            {
                Common.Common_Func.ErrorMessage(string.Format("临时物料【{0}】已与SAP物料【{1}】发生绑定，不允许重新替换", tempmaterial.TempMaterialDesc, tempmaterial.MaterialDesc), "替换失败");
                return;
            }

            using (FrmTempMaterialAlter frm = new FrmTempMaterialAlter(tempmaterial))
            {
                frm.ShowDialog();
            }

            GetListQueryData();

        }

        private TempMaterialInfo GetListRowModel(int iRowIndex)
        {
            string strErr = string.Empty;
            TempMaterialInfo tempmaterial = new TempMaterialInfo();
            tempmaterial.ID = lstMain[iRowIndex].ID;

            if (!Warehouse_Func.GetTempMaterialByID(ref tempmaterial, ref strErr))
            {
                Common.Common_Func.ErrorMessage(strErr, "读取失败");
                GetListQueryData();
                return null;
            }

            return tempmaterial;
        }

        private void ShowFileForm(TempMaterialInfo tempmaterail)
        {
            using (FrmTempMaterialFile frm = new FrmTempMaterialFile(tempmaterail))
            {
                frm.ShowDialog();
            }

            GetListQueryData();
        }

        private void SetSearchBtn()
        {
            Common.Common_Func.SetSearchBtn(this, txtMaterialNo, btnSearch, tsmiSearch);
        }

        #endregion
    }
}
