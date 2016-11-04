using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WMS.Task
{
    public partial class FrmTaskTrans : Common.FrmBaseDialog
    {
        private OverViewDetailInfo _detail;
        private DividPage _serverMainPage;
        private TaskTransInfo queryMain;
        private List<TaskTransInfo> lstMain;

        public FrmTaskTrans()
        {
            InitializeComponent();
        }

        public FrmTaskTrans(OverViewDetailInfo detail)
            :this()
        {
            _detail = detail;
        }


        private void FrmInTrans_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void tsmiCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
            queryMain = new TaskTransInfo();
            lstMain = new List<TaskTransInfo>();

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
                bResult = Task_Func.GetTaskTransListByPage(ref lstMain, queryMain, ref _serverMainPage, ref strErr);
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
            }
        }

        private void GetQueryMain()
        {
            if (queryMain == null) { queryMain = new TaskTransInfo(); }
            queryMain.TaskDetail_ID = _detail.ID;
        }
        
        #endregion
    }
}
