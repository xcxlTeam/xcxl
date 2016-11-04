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
    public partial class FrmHouseList : Common.FrmBasic
    {
        private DividPage _serverMainPage;
        private WarehouseInfo queryMain;
        private List<WarehouseInfo> lstMain;
        private DividPage _serverDetailsPage;
        private HouseInfo queryDetails;
        private List<HouseInfo> lstDetails;

        public FrmHouseList()
        {
            InitializeComponent();

            Common.Common_Func.DelDataGridViewSortable(dgvList);
            Common.Common_Func.DelDataGridViewSortable(dgvDetail);
        }

        private void FrmHouseList_Load(object sender, EventArgs e)
        {
            SetSearchBtn();
            InitForm();
        }

        private void FrmHouseList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.Common_Func.RemoveTabPageForm(this);
        }

        private void tsmiAddHouse_Click(object sender, EventArgs e)
        {
            AddHouse();
        }

        private void tsmiDelHouse_Click(object sender, EventArgs e)
        {
            DelHouse();
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
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BindDetails(e);
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pageList_ChensPageChange(object sender, EventArgs e)
        {
            GetListQueryData();
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EditHouse(e);
        }

        private void pageDetail_ChensPageChange(object sender, EventArgs e)
        {
            GetDetailsQueryData();
        }

        #region Function

        private void InitForm()
        {
            InitMainQuery();

            InitDetailsQuery();

            //BindList();
        }

        private void InitMainQuery()
        {
            _serverMainPage = new DividPage();
            queryMain = new WarehouseInfo();
            lstMain = new List<WarehouseInfo>();

            pageList.GetShowCountsByDGV(dgvList);
            bsMain.DataSource = queryMain;
        }

        private void InitDetailsQuery()
        {
            _serverDetailsPage = new DividPage();
            queryDetails = new HouseInfo();
            lstDetails = new List<HouseInfo>();

            pageDetail.GetShowCountsByDGV(dgvDetail);

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


                if (dgvList.DataSource == null || dgvList.Rows.Count <= 0)
                {
                    lstDetails = new List<HouseInfo>();
                    dgvDetail.DataSource = lstDetails;
                    return;
                }
                else
                {
                    //dgvList.CurrentCell = dgvList[0, 0];
                    pageDetail.dDividPage.CurrentPageNumber = 1;
                    GetDetailsQueryData();
                }

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
        }

        private void BindDetails(DataGridViewCellEventArgs e)
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList, e)) return;

            pageDetail.dDividPage.CurrentPageNumber = 1;
            GetDetailsQueryData();
        }

        private void GetDetailsQueryData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bool bResult = false;
                string strErr = string.Empty;
                GetQueryDetails();

                ChensControl.DividPage clientPage = pageDetail.dDividPage;
                Common.Common_Func.GetServerPageFromClientPage(ref _serverDetailsPage, clientPage);
                bResult = Basic_Func.GetHouseListByPage(ref lstDetails, queryDetails, ref _serverDetailsPage, ref strErr);
                Common.Common_Func.GetClientPageFromServerPage(_serverDetailsPage, ref clientPage);
                pageDetail.ShowPage();
                dgvDetail.DataSource = lstDetails;

                if (!bResult || !string.IsNullOrEmpty(strErr)) Common.Common_Func.ErrorMessage(strErr, "查询失败");
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "查询失败");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void GetQueryDetails()
        {
            if (queryDetails == null) queryDetails = new HouseInfo();
            queryDetails.WarehouseID = lstMain[dgvList.CurrentCell.RowIndex].ID;
            queryDetails.WarehouseNo = queryMain.WarehouseNo;
            queryDetails.HouseNo = queryMain.HouseNo;
            queryDetails.Creater = txtCreater.Text.Trim();
            if (dtpStartTime.Checked) queryDetails.StartTime = dtpStartTime.Value;
            else queryDetails.StartTime = null;
            if (dtpEndTime.Checked) queryDetails.EndTime = dtpEndTime.Value;
            else queryDetails.EndTime = null;
        }

        private void AddHouse()
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList))
            {
                Common.Common_Func.ErrorMessage("请先选中一行仓库", "删除失败");
                return;
            }

            HouseInfo house = new HouseInfo() { ID = 0, WarehouseID = lstMain[dgvList.CurrentCell.RowIndex].ID };

            ShowFileForm(house);
        }

        private void DelHouse()
        {
            if (!Common.Common_Func.CheckDgvOper(dgvDetail))
            {
                Common.Common_Func.ErrorMessage("请先选中一行库区", "删除失败");
                return;
            }

            DeleteDetailsRow(dgvDetail.CurrentCell.RowIndex);
        }

        private void DeleteDetailsRow(int iRowIndex)
        {
            HouseInfo house = GetDetailsRowModel(iRowIndex);
            if (house == null) return;

            if (MessageBox.Show(string.Format("是否确认删除库区【{0}】?", house.HouseName), "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No) return;

            try
            {
                if (house.IsDel != 2)
                {
                    string strErr = string.Empty;
                    if (!Basic_Func.DeleteHouseByID(house, ref strErr))
                    {
                        Common.Common_Func.ErrorMessage(strErr, "删除失败");
                        return;
                    }
                }

                Common.Common_Func.ErrorMessage("删除库区成功", "删除成功");
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

        private void EditHouse(DataGridViewCellEventArgs e)
        {
            if (!Common.Common_Func.CheckDgvOper(dgvDetail, e, "编辑")) return;

            EditDetailsRow(e.RowIndex);
        }

        private void EditDetailsRow(int iRowIndex)
        {
            HouseInfo house = GetDetailsRowModel(iRowIndex);
            if (house == null) return;

            ShowFileForm(house);
        }

        private HouseInfo GetDetailsRowModel(int iRowIndex)
        {
            string strErr = string.Empty;
            HouseInfo house = new HouseInfo();
            house.ID = lstDetails[iRowIndex].ID;

            if (!Basic_Func.GetHouseByID(ref house, ref strErr))
            {
                Common.Common_Func.ErrorMessage(strErr, "读取失败");
                GetListQueryData();
                return null;
            }

            return house;
        }

        private void ShowFileForm(HouseInfo house)
        {
            WarehouseInfo warehouse = GetBelongWarehouse(house.WarehouseID);
            if (warehouse == null) return;

            using (FrmHouseFile frm = new FrmHouseFile(house, warehouse))
            {
                frm.ShowDialog();
            }

            this.Refresh();
            Application.DoEvents();

            GetListQueryData();
        }

        private WarehouseInfo GetBelongWarehouse(int WarehouseID)
        {
            WarehouseInfo warehouse = new WarehouseInfo();

            if (WarehouseID <= 0)
            {
                Common.Common_Func.ErrorMessage("获取仓库信息失败", "错误");
                return null;
            }
            else
            {
                string strError = string.Empty;
                warehouse = new WarehouseInfo() { ID = WarehouseID };

                if (!Basic_Func.GetWarehouseByID(ref warehouse, ref strError))
                {
                    Common.Common_Func.ErrorMessage(strError, "错误");
                    return null;
                }
            }

            return warehouse;
        }

        private void SetSearchBtn()
        {
            Common.Common_Func.SetSearchBtn(this, dtpEndTime, btnSearch, tsmiSearch);
        }

        #endregion

    }
}
