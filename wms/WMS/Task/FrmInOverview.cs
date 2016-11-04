using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WMS.Common;

namespace WMS.Task
{
    public partial class FrmInOverview : Common.FrmBasic
    {
        private DividPage _serverMainPage;
        private DividPage _serverDetailsPage;
        private OverViewInfo queryMain;
        private List<OverViewInfo> lstMain;
        private OverViewDetailInfo queryDetails;
        private List<OverViewDetailInfo> lstDetails;


        public FrmInOverview()
        {
            InitializeComponent();

            Common.Common_Func.DelDataGridViewSortable(dgvList);
            Common.Common_Func.DelDataGridViewSortable(dgvDetail);
        }

        private void FrmInOverview_Load(object sender, EventArgs e)
        {
            SetSearchBtn();
            InitForm();
        }

        private void tsmiExportDetail_Click(object sender, EventArgs e)
        {
            ExportDetail();
        }

        private void tsmiAudit_Click(object sender, EventArgs e)
        {

        }

        private void tsmiUnAudit_Click(object sender, EventArgs e)
        {

        }

        private void tsmiTaskIssue_Click(object sender, EventArgs e)
        {

        }

        private void tsmiTaskCancel_Click(object sender, EventArgs e)
        {

        }

        private void tsmiQuality_Click(object sender, EventArgs e)
        {

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
            BindDetails();
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

        }
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //GetTransQueryData(e);
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

            Common_Func.BindComboBoxAddAll(Task_Func.GetTaskStatus(true), cbbTaskStatus);

            Common_Func.BindComboBoxAddAll(Task_Func.GetOrderType(true), cbbVoucherType);

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
            queryMain.TaskType = 1;
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

                //colBPostQty.Visible = lstMain[dgvList.CurrentCell.RowIndex].IsShelvePost.ToBoolean();

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

            using (FrmTaskTrans frm = new FrmTaskTrans(lstDetails[e.RowIndex]))
            {
                frm.ShowDialog();
            }
        }

        private void SetSearchBtn()
        {
            Common.Common_Func.SetSearchBtn(this, dtpEndTime, btnSearch, tsmiSearch);
        }

        private void ExportDetail()
        {
            if (dgvList.DataSource == null || dgvList.Rows.Count <= 0)
            {
                MessageBox.Show("请先查询到结果后再尝试导出明细", "导出失败");
                return;
            }

            bsMain.EndEdit();

            string strErrMsg = string.Empty;
            List<OverViewExportInfo> lstExport = new List<OverViewExportInfo>();
            OverViewExportInfo queryExport = new OverViewExportInfo();

            try
            {
                this.Cursor = Cursors.WaitCursor;

                queryExport.TaskType = queryMain.TaskType;
                queryExport.StartTime = queryMain.StartTime;
                queryExport.EndTime = queryMain.EndTime;
                queryExport.DeliveryNo = queryMain.DeliveryNo;
                queryExport.MaterialDoc = queryMain.MaterialDoc;
                queryExport.TaskNo = queryMain.TaskNo;
                queryExport.SupCusNo = queryMain.SupcusNo;
                queryExport.ReceiveUserNo = queryMain.ReceiveUserNo;
                queryExport.TaskStatus = queryMain.TaskStatus;
                queryExport.VoucherType = queryMain.VoucherType;
                queryExport.PostStatus = queryMain.PostStatus;
                queryExport.IsQuality = queryMain.IsQuality;
                queryExport.WarehouseID = queryMain.WarehouseID;
                DividPage serverPage = new DividPage();
                serverPage.CurrentPageNumber = 1;
                serverPage.CurrentPageShowCounts = -1;

                if (!Task_Func.GetOverViewExportListByPage(ref lstExport, queryExport, ref serverPage, ref strErrMsg))
                {
                    MessageBox.Show(strErrMsg, "导出失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "导出失败");
                return;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            try
            {
                string excludecol = "ID,Task_ID,TaskStatus,PlantName,Remark,Reason,PostStatus,StartTime,EndTime,WarehouseCode,WarehouseID,ReceiveUserNo,OperatorUserNo,CreateUserNo,IsShelvePost,IsQuality,IsReceivePost,VoucherType,TaskType,StrTaskType,VoucherNo,Status,IsQualityComp,Unit,CompleteDateTime";
                Dictionary<string, string> dicFields = new Dictionary<string, string>();
                dicFields.Add("TaskNo", "任务单号");
                dicFields.Add("DeliveryNo", "单据编号");
                dicFields.Add("SupCusNo", "供应商代码");
                dicFields.Add("SupCusName", "供应商名称");
                dicFields.Add("TaskIssued", "任务下发时间");
                dicFields.Add("ReceiveUserName", "收货人");
                dicFields.Add("Plant", "工厂");
                dicFields.Add("StrVoucherType", "入库类型");
                dicFields.Add("StrTaskType", "任务类型");
                dicFields.Add("StrIsQuality", "是否质检");
                dicFields.Add("StrIsShelvePost", "是否上架过账");
                dicFields.Add("StrIsReceivePost", "是否收货过账");
                dicFields.Add("StrTaskStatus", "任务状态");
                dicFields.Add("StrPostStatus", "过账状态");
                dicFields.Add("MaterialDoc", "物料凭证");
                dicFields.Add("WarehouseName", "仓库名称");
                dicFields.Add("CreateUserName", "创建人");
                dicFields.Add("CreateDateTime", "创建时间");
                dicFields.Add("ToAreaNo", "入库货位");
                dicFields.Add("RowNo", "行号");
                dicFields.Add("VoucherNo", "订单号");
                dicFields.Add("MaterialNo", "物料编号");
                dicFields.Add("MaterialDesc", "物料描述");
                dicFields.Add("TaskQty", "任务数量");
                dicFields.Add("QualityQty", "质检数量");
                dicFields.Add("RemainQty", "剩余数量");
                dicFields.Add("ShelveQty", "已上架数量");
                dicFields.Add("UnQualityQty", "不合格数量");
                dicFields.Add("PostQty", "过账数量");
                dicFields.Add("OperatorUserName", "操作人");
                dicFields.Add("OperatorDateTime", "操作时间");
                dicFields.Add("Unit", "计量单位");
                dicFields.Add("StrStatus", "状态");
                dicFields.Add("StrIsQualityComp", "是否质检完成");
                dicFields.Add("CompleteDateTime", "完成时间");
                ExcelLibrary.ExcelLibrary_Func.SaveListToExcelByNPOI(lstExport, true, excludecol, dicFields, dgvList.DefaultCellStyle.Font);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "导出失败");
                return;
            }
        }


        #endregion


    }
}
