using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WMS.Common;

namespace WMS.Print
{
    public partial class FrmCensorshipPrint : Common.FrmBasic
    {
        private DividPage _serverMainPage;
        private DeliveryReceive_Model queryMain;
        private List<DeliveryReceive_Model> lstMain;
        private DividPage _serverDetailsPage;
        private DeliveryReceiveDetail_Model queryDetails;
        private List<DeliveryReceiveDetail_Model> lstDetails;

        public FrmCensorshipPrint()
        {
            InitializeComponent();
        }

        private void FrmCensorshipPrint_Load(object sender, EventArgs e)
        {
            SetSearchBtn();
            InitForm();
        }

        private void FrmCensorshipPrint_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.Common_Func.RemoveTabPageForm(this);
        }

        private void tsmiPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                PrintLabel();
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

        private void tsmiChangePrinter_Click(object sender, EventArgs e)
        {
            try
            {
                //this.Cursor = Cursors.WaitCursor;

                Print_Func.ChangePrinter();
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

        private void dgvList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (lstMain == null || lstMain.Count <= e.RowIndex) return;

            if (lstMain[e.RowIndex].PrintedQty >= 1)
            {
                dgvList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            }
        }

        private void pageList_ChensPageChange(object sender, EventArgs e)
        {
            GetListQueryData();
        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pageDetail_ChensPageChange(object sender, EventArgs e)
        {
            GetDetailsQueryData();
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
            queryMain = new DeliveryReceive_Model();
            lstMain = new List<DeliveryReceive_Model>();

            pageList.GetShowCountsByDGV(dgvList);
            pageDetail.GetShowCountsByDGV(dgvDetail);

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
                bResult = Print_Func.GetCensorshipListByPage(ref lstMain, queryMain, ref _serverMainPage, ref strErr);
                Common.Common_Func.GetClientPageFromServerPage(_serverMainPage, ref clientPage);
                pageList.ShowPage();
                dgvList.DataSource = lstMain;

                if (!bResult || !string.IsNullOrEmpty(strErr)) Common.Common_Func.ErrorMessage(strErr, "查询失败");

                if (dgvList.DataSource == null || dgvList.Rows.Count <= 0)
                {
                    lstDetails = new List<DeliveryReceiveDetail_Model>();
                    dgvDetail.DataSource = lstMain;
                    return;
                }
                else
                {
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
                txtMaterialDoc.Focus();
            }
        }

        private void GetQueryMain()
        {
            if (queryMain == null) { queryMain = new DeliveryReceive_Model(); bsMain.DataSource = queryMain; }
            if (dtpStartDate.Checked) queryMain.StartTime = dtpStartDate.Value; else queryMain.StartTime = null;
            if (dtpEndDate.Checked) queryMain.EndTime = dtpEndDate.Value; else queryMain.EndTime = null;
        }

        private void BindDetails(DataGridViewCellEventArgs e)
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList, e)) return;

            pageDetail.dDividPage.CurrentPageNumber = 1;
            GetDetailsQueryData();
        }

        private void GetDetailsQueryData()
        {
            bool bResult = false;
            string strErr = string.Empty;
            GetQueryDetails();

            ChensControl.DividPage clientPage = pageDetail.dDividPage;
            Common.Common_Func.GetServerPageFromClientPage(ref _serverDetailsPage, clientPage);
            bResult = Print_Func.GetCensorshipDetailByPage(ref lstDetails, queryDetails, ref _serverDetailsPage, ref strErr);
            Common.Common_Func.GetClientPageFromServerPage(_serverDetailsPage, ref clientPage);
            pageDetail.ShowPage();
            dgvDetail.DataSource = lstDetails;

            if (!bResult || !string.IsNullOrEmpty(strErr)) Common.Common_Func.ErrorMessage(strErr, "查询失败");

        }

        private void GetQueryDetails()
        {
            if (queryDetails == null) queryDetails = new DeliveryReceiveDetail_Model();
            queryDetails.ID = lstMain[dgvList.CurrentCell.RowIndex].ID;
            queryDetails.VoucherNo = lstMain[dgvList.CurrentCell.RowIndex].VoucherNo;
        }

        private void PrintLabel()
        {
            if (lstMain == null || lstMain.Count <= 0) return;
            if (lstDetails == null || lstDetails.Count <= 0) return;
            if (!Common.Common_Func.CheckDgvOper(dgvDetail)) return;

            List<DeliveryReceiveDetail_Model> lstPrintDetail = new List<DeliveryReceiveDetail_Model>();
            lstPrintDetail = lstDetails.FindAll(delegate(DeliveryReceiveDetail_Model temp) { return temp.ReceiveQty >= 1; });
            if (lstPrintDetail == null || lstPrintDetail.Count <= 0)
            {
                MessageBox.Show("当前单据没有任何行收货", "提示");
                return;
            }

            int PrintRow = 0;
            foreach (DeliveryReceiveDetail_Model m in lstPrintDetail)
            {
                m.RowNumber = ++PrintRow;
            }

            string strError = string.Empty;
            DeliveryReceive_Model header = lstMain[dgvList.CurrentCell.RowIndex];

            //using (ReportView.FrmCensorshipPrinting frm = new ReportView.FrmCensorshipPrinting(header, lstPrintDetail))
            //{
            //    frm.ShowDialog();
            //}

            ReportView.FrmCensorshipPrinting frm = new ReportView.FrmCensorshipPrinting(header, lstPrintDetail);
            Common.Common_Func.ShowTabPageForm(this, frm, 2);
        }

        private void SetSearchBtn()
        {
            Common.Common_Func.SetSearchBtn(this, txtVoucherNo, btnSearch, tsmiSearch);
        }

        #endregion
    }
}
