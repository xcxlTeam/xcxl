using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WMS.Query
{
    public partial class FrmStockOutQuery : Common.FrmBasic
    {
        private DividPage _serverMainPage;
        private TaskTransInfo queryMain;
        private List<TaskTransInfo> lstMain;

        public FrmStockOutQuery()
        {
            InitializeComponent();
        }

        private void FrmStockOutQuery_Load(object sender, EventArgs e)
        {
            SetSearchBtn();
            InitForm();
        }

        private void FrmStockOutQuery_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.Common_Func.RemoveTabPageForm(this);
        }

        private void tsmiExport_Click(object sender, EventArgs e)
        {
            ExportList();
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

        private void pageList_ChensPageChange(object sender, EventArgs e)
        {
            GetListQueryData();
        }

        #region Function

        private void InitForm()
        {
            InitMainQuery();

            //BindComboboxs();

            //GetListQueryData();
        }

        private void InitMainQuery()
        {
            _serverMainPage = new DividPage();
            queryMain = new TaskTransInfo();
            lstMain = new List<TaskTransInfo>();

            pageList.GetShowCountsByDGV(dgvList);
            bsMain.DataSource = queryMain;

            if (Common.Common_Func.IsWarehouseUserNo(Common.Common_Var.CurrentUser.UserNo))
            {
                queryMain.FromWarehouseNo = Common.Common_Var.CurrentUser.UserNo.Substring(0, 1);
            }
        }

        //private void BindComboboxs()
        //{
        //    Common.Common_Func.BindComboBoxAddAll(JingXinWMS.Task.Task_Func.GetOrderType(false), cbbVoucherType);
        //}

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
            bResult = Query_Func.GetTaskTransListByPage(ref lstMain, queryMain, ref _serverMainPage, ref strErr);
            Common.Common_Func.GetClientPageFromServerPage(_serverMainPage, ref clientPage);
            pageList.ShowPage();
            dgvList.DataSource = lstMain;

            if (!bResult || !string.IsNullOrEmpty(strErr)) Common.Common_Func.ErrorMessage(strErr, "查询失败");            
            txtFromWarehouseNo.Focus();
        }

        private void GetQueryMain()
        {
            if (queryMain == null) { queryMain = new TaskTransInfo(); bsMain.DataSource = queryMain; }
            queryMain.TaskType = 2;
            if (dtpStartTime.Checked) queryMain.StartTime = new DateTime(dtpStartTime.Value.Year, dtpStartTime.Value.Month, dtpStartTime.Value.Day); else queryMain.StartTime = null;
            if (dtpEndTime.Checked) queryMain.EndTime = new DateTime(dtpEndTime.Value.Year, dtpEndTime.Value.Month, dtpEndTime.Value.Day); else queryMain.EndTime = null;
        }

        private void ExportList()
        {
            ExcelLibrary.ExcelLibrary_Func.SaveDataGridViewToExcelByNPOI(dgvList);
        }

        private void SetSearchBtn()
        {
            Common.Common_Func.SetSearchBtn(this, txtFromAreaNo, btnSearch, tsmiSearch);
        }

        #endregion
    }
}
