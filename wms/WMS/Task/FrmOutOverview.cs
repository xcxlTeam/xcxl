using JingXinWMS.JXWebService;
using JingXinWMS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace JingXinWMS.Task
{
    public partial class FrmOutOverview : Common.FrmBasic
    {
        private DividPage _serverMainPage;
        private DividPage _serverDetailsPage;
        private OverViewInfo queryMain;
        private List<OverViewInfo> lstMain;
        private OverViewDetailInfo queryDetails;
        private List<OverViewDetailInfo> lstDetails;
        private bool bShowCMS;


        public FrmOutOverview()
        {
            InitializeComponent();

            Common.Common_Func.DelDataGridViewSortable(dgvList);
            Common.Common_Func.DelDataGridViewSortable(dgvDetail);
        }

        private void FrmOutOverview_Load(object sender, EventArgs e)
        {
            SetSearchBtn();
            InitForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindList();
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BindDetails();
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pageList_ChensPageChange(object sender, EventArgs e)
        {
            GetListQueryData();
        }

        private void dgvList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //GetTransQueryData(e);
        }

        private void pageDetail_ChensPageChange(object sender, EventArgs e)
        {
            GetDetailsQueryData();
        }

        private void cmsAllotPick_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !bShowCMS;

        }

        private void dgvList_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            ShowAllot(e);
        }

        private void ShowAllot(DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                bShowCMS = false;
            }
            else if (e.ColumnIndex < 0)
            {
                bShowCMS = false;
            }
            else
            {
                //if (e.ColumnIndex != colHSAuditUserNo.Index)
                //{
                //    bShowCMS = false;
                //}
                //else
                //{

                //    //OverViewInfo tm = lstMain[e.RowIndex];
                //    //switch (tm.TaskStatus)
                //    //{
                //    //    case Common.Common_Var.taskstatus4:
                //    //    case Common.Common_Var.taskstatus5:
                //    //    case Common.Common_Var.taskstatus8:
                //    //        bShowCMS = false;
                //    //        return;
                //    //}

                //    bShowCMS = Common_Var.CurrentUser.BIsAdmin;
                //}
            }
        }

        #region Function

        private void InitForm()
        {
            InitMainQuery();

            InitDetailsQuery();

            ClearForm();

            BindComboboxs();
        }

        private void InitMainQuery()
        {
            _serverMainPage = new DividPage();
            queryMain = new OverViewInfo();
            lstMain = new List<OverViewInfo>();

            pageList.GetShowCountsByDGV(dgvList);
            bsMain.DataSource = queryMain;
        }

        private void InitDetailsQuery()
        {
            _serverDetailsPage = new DividPage();
            queryDetails = new OverViewDetailInfo();
            lstDetails = new List<OverViewDetailInfo>();

            pageDetail.GetShowCountsByDGV(dgvDetail);

        }

        private void BindComboboxs()
        {
            Common_Func.BindComboBoxAddAll(Task_Func.GetIsQuality(), cbbIsQuality);

            Common_Func.BindComboBoxAddAll(Task_Func.GetTaskStatus(false), cbbTaskStatus);

            Common_Func.BindComboBoxAddAll(Task_Func.GetOrderType(false), cbbVoucherType);

            Common_Func.BindComboBoxAddAll(Task_Func.GetPostStatus(), cbbPostStatus);

            Common_Func.BindComboBoxAddAllByKey(cbbWarehouse.Name, cbbWarehouse);
        }

        private void ClearForm()
        {
            _serverMainPage = new DividPage();
            queryMain = new OverViewInfo();

            bsMain.DataSource = queryMain;
            pageList.dDividPage.CurrentPageNumber = 1;
            pageDetail.dDividPage.CurrentPageNumber = 1;

            lstMain = new List<OverViewInfo>();
            lstDetails = new List<OverViewDetailInfo>();
            dgvList.DataSource = lstMain;
            dgvDetail.DataSource = lstDetails;
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
                bResult = Task_Func.GetTaskMainListByPage(ref lstMain, queryMain, ref _serverMainPage, ref strErr);
                Common.Common_Func.GetClientPageFromServerPage(_serverMainPage, ref clientPage);
                pageList.ShowPage();
                dgvList.DataSource = lstMain;

                if (!bResult || !string.IsNullOrEmpty(strErr)) Common.Common_Func.ErrorMessage(strErr, "查询失败");


                if (dgvList.DataSource == null || dgvList.Rows.Count <= 0)
                {
                    lstDetails = new List<OverViewDetailInfo>();
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
                txtTaskNo.Focus();
            }
        }

        private void GetQueryMain()
        {
            if (queryMain == null) { queryMain = new OverViewInfo(); bsMain.DataSource = queryMain; }
            queryMain.TaskType = 2;
            if (dtpStartTime.Checked) queryMain.StartTime = dtpStartTime.Value; else queryMain.StartTime = null;
            if (dtpEndTime.Checked) queryMain.EndTime = dtpEndTime.Value; else queryMain.EndTime = null;
        }

        private void BindDetails()
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList)) return;

            pageDetail.dDividPage.CurrentPageNumber = 1;
            GetDetailsQueryData();
        }

        private bool CheckListClick()
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList))
            {
                Common.Common_Func.ErrorMessage("请先选中一行任务", "查询失败");
                return false;
            }
            return true;
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
                bResult = Task_Func.GetTaskDetailListByPage(ref lstDetails, queryDetails, ref _serverDetailsPage, ref strErr);
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
            if (queryDetails == null) queryDetails = new OverViewDetailInfo();
            queryDetails.Task_ID = lstMain[dgvList.CurrentCell.RowIndex].ID;
        }

        private void GetTransQueryData(DataGridViewCellEventArgs e)
        {
            if (!Common.Common_Func.CheckDgvOper(dgvDetail, e, "")) return;

            FrmTaskTrans frm = new FrmTaskTrans(lstDetails[e.RowIndex]);
            frm.ShowDialog();
        }

        private void SetSearchBtn()
        {
            Common.Common_Func.SetSearchBtn(this, dtpEndTime, btnSearch, tsmiSearch);
        }


        #endregion

    }
}
