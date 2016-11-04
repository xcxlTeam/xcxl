using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WMS.WebService;
using WMS.Common;

namespace WMS.Quality
{
    public partial class FrmQualityList : Common.FrmBasic
    {
        private DividPage _serverMainPage;
        public List<DeliveryReceive_Model> lstDelivery;
        public DeliveryReceive_Model DeliveryModel = new DeliveryReceive_Model();
        public List<DeliveryReceiveDetail_Model> lstDeliveryDetails;

        public FrmQualityList()
        {
            InitializeComponent();
        }

        private void FrmQualityList_Load(object sender, EventArgs e)
        {
            SetSearchBtn();

            pageList.GetShowCountsByDGV(dgvList);

            bsDelivery.DataSource = DeliveryModel;
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
            try
            {
                BindList();
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "查询失败");
            }
        }

        private void pageList_ChensPageChange(object sender, EventArgs e)
        {
            GetListQueryData();
        }

        private void BindList()
        {
            pageList.dDividPage.CurrentPageNumber = 1;
            GetListQueryData();
        }

        private void GetListQueryData()
        {
            bsDelivery.EndEdit();

            bool bResult = false;
            string strErrMsg = string.Empty;

            GetQueryDelivery();

            if (DeliveryModel.StartTime != null && DeliveryModel.EndTime != null)
            {
                if (DeliveryModel.StartTime.ToDateTime().Date > DeliveryModel.EndTime.ToDateTime().Date)
                {
                    Common.Common_Func.ErrorMessage("开始日期不能大于结束日期", "查询失败");
                    return;
                }
            }

            ChensControl.DividPage clientPage = pageList.dDividPage;
            Common.Common_Func.GetServerPageFromClientPage(ref _serverMainPage, clientPage);
            bResult = Quality_Func.GetQualityList(ref lstDelivery, DeliveryModel, ref _serverMainPage, ref strErrMsg);
            Common.Common_Func.GetClientPageFromServerPage(_serverMainPage, ref clientPage);
            pageList.ShowPage();
            dgvList.DataSource = lstDelivery;

            if (!bResult) Common.Common_Func.ErrorMessage(strErrMsg, "查询失败");

        }

        private void GetQueryDelivery()
        {
            if (DeliveryModel == null) { DeliveryModel = new DeliveryReceive_Model(); bsDelivery.DataSource = DeliveryModel; }
            if (dtpStartDate.Checked) DeliveryModel.StartTime = dtpStartDate.Value; else DeliveryModel.StartTime = null;
            if (dtpEndDate.Checked) DeliveryModel.EndTime = dtpEndDate.Value; else DeliveryModel.EndTime = null;
        }

        private string AllowShowEditFormText = "编辑";
        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bool bSucc = false;
                string strErrMsg = string.Empty;
                string strHeaderText = this.dgvList.Columns[e.ColumnIndex].HeaderText;
                //if (AllowShowEditFormText.IndexOf(strHeaderText) < 0) return;

                if (e.RowIndex >= 0
                    && e.RowIndex < this.dgvList.Rows.Count && AllowShowEditFormText.IndexOf(strHeaderText) >= 0)
                {
                    DeliveryReceive_Model item = this.lstDelivery[e.RowIndex];

                    bSucc = Quality_Func.GetQualityDetails(item, ref lstDeliveryDetails, ref strErrMsg);

                    if (bSucc == false)
                    {
                        Common.Common_Func.ErrorMessage(strErrMsg, "编辑失败");
                        return;
                    }
                    using (FrmQuality FQ = new FrmQuality(item, lstDeliveryDetails))
                    {
                        FQ.ShowDialog();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsmiExport_Click(object sender, EventArgs e)
        {
            ExcelLibrary.ExcelLibrary_Func.SaveDataGridViewToExcelByNPOI(dgvList, true, false, Column12.Name);
        }

        private void tsmiExportDetail_Click(object sender, EventArgs e)
        {
            ExportDetail();
        }

        private void SetSearchBtn()
        {
            Common.Common_Func.SetSearchBtn(this, txtVoucherNo, btnSearch, tsmiSearch);
        }

        private void ExportDetail()
        {
            if (dgvList.DataSource == null || dgvList.Rows.Count <= 0)
            {
                MessageBox.Show("请先查询到结果后再尝试导出明细", "导出失败");
                return;
            }

            bsDelivery.EndEdit();

            if (dtpStartDate.Checked && DeliveryModel.StartTime != dtpStartDate.Value)
            {
                GetListQueryData();
            }
            else if (!dtpStartDate.Checked && DeliveryModel.StartTime != null)
            {
                GetListQueryData();
            }
            else if (dtpEndDate.Checked && DeliveryModel.EndTime != dtpEndDate.Value)
            {
                GetListQueryData();
            }
            else if (!dtpEndDate.Checked && DeliveryModel.EndTime != null)
            {
                GetListQueryData();
            }

            string strErrMsg = string.Empty;
            List<QuanlityExportInfo> lstExport = new List<QuanlityExportInfo>();
            QuanlityExportInfo queryExport = new QuanlityExportInfo();

            try
            {
                this.Cursor = Cursors.WaitCursor;
                queryExport.StartTime = DeliveryModel.StartTime;
                queryExport.EndTime = DeliveryModel.EndTime;
                queryExport.DeliveryNo = DeliveryModel.DeliveryNo;
                queryExport.MaterialDoc = DeliveryModel.MaterialDoc;
                queryExport.VoucherNo = DeliveryModel.VoucherNo;
                queryExport.MaterialNo = DeliveryModel.MaterialNo;
                DividPage serverPage = new DividPage();
                serverPage.CurrentPageNumber = 1;
                serverPage.CurrentPageShowCounts = -1;

                if (!Quality_Func.GetQualityExportListByPage(ref lstExport, queryExport, ref serverPage, ref strErrMsg))
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

                string excludecol = "ID,QualityType,StartTime,EndTime";
                Dictionary<string, string> dicFields = new Dictionary<string, string>();
                dicFields.Add("DeliveryNo", "送货单号");
                dicFields.Add("SupplierNo", "供应商代码");
                dicFields.Add("SupplierName", "供应商名称");
                dicFields.Add("Plant", "工厂");
                dicFields.Add("MaterialDoc", "凭证号");
                dicFields.Add("CreateDate", "创建时间");
                dicFields.Add("PrintedQty", "已打印次数");
                dicFields.Add("PrintTime", "最后打印时间");
                dicFields.Add("MoveType", "移动类型");
                dicFields.Add("VoucherNo", "采购单号");
                dicFields.Add("RowNo", "行号");
                dicFields.Add("MaterialNo", "物料编号");
                dicFields.Add("MaterialDesc", "物料描述");
                dicFields.Add("ReceiveQty", "收货数量");
                dicFields.Add("Unit", "计量单位");
                dicFields.Add("PrdVersion", "产品版本");
                dicFields.Add("QualityQty", "合格数量");
                dicFields.Add("UnQualityQty", "不合格数量");
                dicFields.Add("QualityType", "却先等级");
                dicFields.Add("StrQualityType", "缺陷等级");
                ExcelLibrary.ExcelLibrary_Func.SaveListToExcelByNPOI(lstExport, true, excludecol, dicFields, dgvList.DefaultCellStyle.Font);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "导出失败");
                return;
            }
        }
    }
}
