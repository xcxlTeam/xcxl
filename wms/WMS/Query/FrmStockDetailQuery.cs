using WMS.Common;
using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WMS.Query
{
    public partial class FrmStockDetailQuery : Common.FrmBasic
    {
        private DividPage _serverMainPage;
        private Stock_Model queryMain;
        private List<Stock_Model> lstMain;

        public FrmStockDetailQuery()
        {
            InitializeComponent();
        }

        private void FrmStockDetailQuery_Load(object sender, EventArgs e)
        {
            SetSearchBtn();
            InitForm();
        }

        private void FrmStockDetailQuery_FormClosed(object sender, FormClosedEventArgs e)
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

            //GetListQueryData();
        }

        private void InitMainQuery()
        {
            _serverMainPage = new DividPage();
            queryMain = new Stock_Model();
            lstMain = new List<Stock_Model>();

            pageList.GetShowCountsByDGV(dgvList);
            bsMain.DataSource = queryMain;

            if (Common.Common_Func.IsWarehouseUserNo(Common.Common_Var.CurrentUser.UserNo))
            {
                queryMain.WarehouseNo = Common.Common_Var.CurrentUser.UserNo.Substring(0, 1);
            }
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

            if (queryMain.StartTime != null && queryMain.EndTime != null)
            {
                if (queryMain.StartTime.ToDateTime().Date > queryMain.EndTime.ToDateTime().Date)
                {
                    Common.Common_Func.ErrorMessage("开始日期不能大于结束日期", "查询失败");
                    return;
                }
            }

            ChensControl.DividPage clientPage = pageList.dDividPage;
            Common.Common_Func.GetServerPageFromClientPage(ref _serverMainPage, clientPage);
            bResult = Query_Func.GetStockDetailListByPage(ref lstMain, queryMain, ref _serverMainPage, ref strErr);
            Common.Common_Func.GetClientPageFromServerPage(_serverMainPage, ref clientPage);
            pageList.ShowPage();
            //添加总计
            Stock_Model sum_model = new Stock_Model();
            foreach (Stock_Model st_model in lstMain)
            {
                sum_model.Qty += st_model.Qty;
            }
            sum_model.AreaName = "总计";
            lstMain.Add(sum_model);
            dgvList.DataSource = lstMain;

            if (!bResult || !string.IsNullOrEmpty(strErr)) Common.Common_Func.ErrorMessage(strErr, "查询失败");
            txtWarehouseNo.Focus();
        }

        private void GetQueryMain()
        {
            if (queryMain == null) { queryMain = new Stock_Model(); bsMain.DataSource = queryMain; }
            if (dtpBeginTime.Checked) queryMain.StartTime = dtpBeginTime.Value; else queryMain.StartTime = null;
            if (dtpEndTime.Checked) queryMain.EndTime = dtpEndTime.Value; else queryMain.EndTime = null;
        }

        private void ExportList()
        {
            ExcelLibrary.ExcelLibrary_Func.SaveDataGridViewToExcelByNPOI(dgvList);
        }

        private void SetSearchBtn()
        {
            Common.Common_Func.SetSearchBtn(this, txtAreaNo, btnSearch, tsmiSearch);
        }

        #endregion
    }
}
