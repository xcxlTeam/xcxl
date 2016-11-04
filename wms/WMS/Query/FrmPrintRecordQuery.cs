using WMS.Common;
using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WMS.Query
{
    public partial class FrmPrintRecordQuery : Common.FrmBasic
    {
        private DividPage _serverMainPage;
        private Barcode_Model queryMain;
        private List<Barcode_Model> lstMain;

        public FrmPrintRecordQuery()
        {
            InitializeComponent();

            Common.Common_Func.DelDataGridViewSortable(dgvList);

            queryMain = new Barcode_Model();
        }

        private void FrmPrintRecordQuery_Load(object sender, EventArgs e)
        {
            SetSearchBtn();
            InitForm();
        }

        private void FrmPrintRecordQuery_FormClosed(object sender, FormClosedEventArgs e)
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

            BindComboboxs();

            //BindList();
        }

        private void BindComboboxs()
        {
            Common.Common_Func.BindComboBoxAddAll(Query_Func.GetOrderType(), cbbVoucherType);
        }

        private void InitMainQuery()
        {
            _serverMainPage = new DividPage();
            queryMain = new Barcode_Model();
            lstMain = new List<Barcode_Model>();

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
            bResult = Query_Func.GetPrintRecordListByPage(ref lstMain, queryMain, ref _serverMainPage, ref strErr);
            Common.Common_Func.GetClientPageFromServerPage(_serverMainPage, ref clientPage);
            pageList.ShowPage();
            dgvList.DataSource = lstMain;

            if (!bResult || !string.IsNullOrEmpty(strErr)) Common.Common_Func.ErrorMessage(strErr, "查询失败");
            txtSUPCODE.Focus();
        }

        private void GetQueryMain()
        {
            if (queryMain == null) { queryMain = new Barcode_Model(); bsMain.DataSource = queryMain; }
            if (dtpStartTime.Checked) queryMain.StartTime = dtpStartTime.Value; else queryMain.StartTime = null;
            if (dtpEndTime.Checked) queryMain.EndTime = dtpEndTime.Value; else queryMain.EndTime = null;
            queryMain.VOUCHERTYPE = queryMain.iVoucherType >= 1 ? queryMain.iVoucherType.ToString() : string.Empty;
        }

        private void ExportList()
        {
            ExcelLibrary.ExcelLibrary_Func.SaveDataGridViewToExcelByNPOI(dgvList);
        }

        private void SetSearchBtn()
        {
            Common.Common_Func.SetSearchBtn(this, dtpEndTime, btnSearch, tsmiSearch);
        }

        #endregion
    
    }
}
