using WMS.WebService;
using WMS.Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace WMS.Check
{
    public partial class FrmCheckProfitLoss : Common.FrmBaseDialog
    {
        private System.Drawing.Size showsize;

        private CheckDetailsInfo _detail;
        private DividPage _serverMainPage;
        private ProfitLossInfo queryMain;
        private List<ProfitLossInfo> lstMain;

        public FrmCheckProfitLoss()
        {
            InitializeComponent();
        }
        public FrmCheckProfitLoss(CheckDetailsInfo detail)
        {
            InitializeComponent();
            showsize = this.Size;
            // TODO: Complete member initialization

            _detail = detail;
        }

        private void FrmCheckProfitLoss_Load(object sender, EventArgs e)
        {
            this.Size = showsize;

            InitForm();
        }

        private void pageList_ChensPageChange(object sender, EventArgs e)
        {
            GetListQueryData();
        }

        #region Function
        private void InitForm()
        {
            InitMainQuery();

            BindInTrans();
        }

        private void InitMainQuery()
        {
            _serverMainPage = new DividPage();
            queryMain = new ProfitLossInfo();
            lstMain = new List<ProfitLossInfo>();
            if (_detail == null) _detail = new CheckDetailsInfo();

            pageList.GetShowCountsByDGV(dgvList);
        }


        private void BindInTrans()
        {
            pageList.dDividPage.CurrentPageNumber = 1;
            GetListQueryData();
        }

        private void GetListQueryData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bool bResult = false;
                string strErr = string.Empty;
                GetQueryMain();

                ChensControl.DividPage clientPage = pageList.dDividPage;
                Common.Common_Func.GetServerPageFromClientPage(ref _serverMainPage, clientPage);
                bResult = Check_Func.GetProfitLossListByPage(ref lstMain, queryMain, ref _serverMainPage, ref strErr);
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
            }
        }

        private void GetQueryMain()
        {
            if (queryMain == null) { queryMain = new ProfitLossInfo(); }
            queryMain.CheckID = _detail.CheckID;
            queryMain.WarehouseNo = _detail.WarehouseNo;
            queryMain.HouseNo = _detail.HouseNo;
            queryMain.AreaNo = _detail.AreaNo;
            queryMain.MaterialNo = _detail.MaterialNo;
        }

        #endregion
    }
}
