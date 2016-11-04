using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WMS.Check
{
    public partial class FrmCheckAnalyse : Common.FrmBasic
    {
        private CheckInfo _check;
        private DividPage _serverMainPage;
        private CheckDetailsInfo queryMain;
        private List<CheckDetailsInfo> lstMain;

        public FrmCheckAnalyse()
        {
            InitializeComponent();

            Common.Common_Func.DelDataGridViewSortable(dgvList);
            this._check = new CheckInfo();
        }

        public FrmCheckAnalyse(CheckInfo check)
        {
            InitializeComponent();
            Common.Common_Func.DelDataGridViewSortable(dgvList);
            // TODO: Complete member initialization
            this._check = check;
        }

        private void FrmCheckAnalyse_Load(object sender, EventArgs e)
        {
            SetSearchBtn();
            InitForm();
        }

        private void FrmCheckAnalyse_FormClosing(object sender, FormClosingEventArgs e)
        {
            Common.Common_Func.CloseTabPageForm(this, typeof(FrmCheckList));
        }

        private void tsmiDeal_Click(object sender, EventArgs e)
        {
            ProfitLossDeal();
        }

        private void tsmiExport_Click(object sender, EventArgs e)
        {
            ExcelLibrary.ExcelLibrary_Func.SaveDataGridViewToExcelByNPOI(dgvList, true, false, colEdit.Name);
        }

        private void tsmiReCheck_Click(object sender, EventArgs e)
        {
            ReCheck();
        }

        private void tsmiExportDetails_Click(object sender, EventArgs e)
        {
            ExportDetails();
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
                Common.Common_Func.ErrorMessage(ex.Message, "程序异常", 3);
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

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CheckTrans(e);
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //ShowProfitLoss(e);
        }

        private void lblDifferenceQty_TextChanged(object sender, EventArgs e)
        {
            if (_check.DifferenceQty < 0)
            {
                lblDifferenceQty.ForeColor = Color.Red;
            }
            else if (_check.DifferenceQty > 0)
            {
                lblDifferenceQty.ForeColor = Color.Green;
            }
            else
            {
                lblDifferenceQty.ForeColor = Color.Black;
            }
        }

        #region Function

        private void InitForm()
        {
            InitMainQuery();

            BindComboBoxs();

            BindList();
        }

        private void BindComboBoxs()
        {
            Common.Common_Func.BindComboBoxAddAll(Check_Func.GetProfitLoss(), cbbProfitLoss);

            bsMain.ResetBindings(false);
            bsMain.EndEdit();
        }

        private void InitMainQuery()
        {
            _serverMainPage = new DividPage();
            queryMain = new CheckDetailsInfo();
            lstMain = new List<CheckDetailsInfo>();

            pageList.GetShowCountsByDGV(dgvList);
            bsMain.DataSource = queryMain;
            bsCheck.DataSource = _check;
            bsCheck.ResetBindings(false);
            bsCheck.EndEdit();

            if (_check == null || !_check.BIsMainCheck || _check.CheckStatus != 4)
            {
                tsmiDeal.Enabled = false;
                tsmiReCheck.Enabled = false;
            }

            switch (_check.CheckType)
            {
                case 1:
                    lblAreaNo.Text = "盘点仓库";
                    colWarehouseNo.Visible = true;
                    colWarehouseName.Visible = true;
                    break;

                case 2:
                    lblAreaNo.Text = "盘点库区";
                    colHouseNo.Visible = true;
                    colHouseName.Visible = true;
                    break;

                case 3:
                    lblAreaNo.Text = "盘点货位";
                    colAreaNo.Visible = true;
                    colAreaName.Visible = true;
                    break;

                case 4:
                    lblAreaNo.Text = "盘点物料";
                    colWarehouseNo.Visible = true;
                    colWarehouseName.Visible = true;
                    colMaterialNo.Visible = true;
                    colMaterialDesc.Visible = true;
                    colMaterialStd.Visible = true;
                    break;

                case 5:
                    lblAreaNo.Text = "盘点物料";
                    colWarehouseNo.Visible = true;
                    colWarehouseName.Visible = true;
                    colMaterialNo.Visible = true;
                    colMaterialDesc.Visible = true;
                    colMaterialStd.Visible = true;
                    break;

                default:
                    Common.Common_Func.ErrorMessage("盘点类型传入错误,请重新打开", "错误");
                    this.Close();
                    break;
            }
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
                bResult = Check_Func.GetCheckAnalyseListByPage(ref lstMain, queryMain, ref _serverMainPage, ref strErr);
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
                txtAreaNo.Focus();
            }
        }

        private void GetQueryMain()
        {
            if (queryMain == null) { queryMain = new CheckDetailsInfo(); bsMain.DataSource = queryMain; }
            queryMain.CheckID = _check.ID;
            queryMain.CheckType = _check.CheckType;
            if (dtpStartTime.Checked) queryMain.StartTime = dtpStartTime.Value;
            else queryMain.StartTime = null;
            if (dtpEndTime.Checked) queryMain.EndTime = dtpEndTime.Value;
            else queryMain.EndTime = null;

            //queryMain.WarehouseNo = "";
            //queryMain.HouseNo = "";
            //queryMain.AreaNo = "";
            //queryMain.MaterialNo = "";
            //if (!string.IsNullOrEmpty(txtAreaNo.Text))
            //{
            //    switch (_check.CheckType)
            //    {
            //        case 1:
            //            queryMain.WarehouseNo = txtAreaNo.Text.Trim();
            //            break;

            //        case 2:
            //            queryMain.HouseNo = txtAreaNo.Text.Trim();
            //            break;

            //        case 3:
            //            queryMain.AreaNo = txtAreaNo.Text.Trim();
            //            break;

            //        case 4:
            //            queryMain.MaterialNo = txtAreaNo.Text.Trim();
            //            break;

            //        case 5:
            //            queryMain.MaterialNo = txtAreaNo.Text.Trim();
            //            break;
            //    }
            //}
        }

        private void ProfitLossDeal()
        {
            if (!Common.Common_Func.DialogMessage("是否确认进行盈亏处理?", "提示")) return;

            string strError = string.Empty;
            if (Check_Func.VerifyCheckStockChange(_check, ref strError))
            {
                if (!Common.Common_Func.DialogMessage("盘点库存在盘点期间发生过变动,是否继续进行盈亏处理?", "警告", 3)) return;
            }
            else
            {
            }

            if (!Check_Func.ProfitLossDeal(_check, ref strError))
            {
                Common.Common_Func.ErrorMessage(strError, "处理失败", 2);
            }
            else
            {
                Common.Common_Func.ErrorMessage("处理完成", "提示");
                tsmiDeal.Enabled = false;
            }
        }

        private void CheckTrans(DataGridViewCellEventArgs e)
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList, e, "编辑", "查看")) return;

            ShowProfitLoss(e);
        }

        private void ShowProfitLoss(DataGridViewCellEventArgs e)
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList, e)) return;

            ShowProfitLossForm(e.RowIndex);
        }

        private void ShowProfitLossForm(int iRowIndex)
        {
            CheckDetailsInfo detail = GetListRowModel(iRowIndex);
            if (detail == null) return;

            using (FrmCheckProfitLoss frm = new FrmCheckProfitLoss(detail))
            {
                frm.ShowDialog();
            }
        }

        private CheckDetailsInfo GetListRowModel(int iRowIndex)
        {
            return lstMain[iRowIndex];
        }

        private bool GetExportDetailData(ref List<ProfitLossInfo> lstExport)
        {
            bsMain.EndEdit();

            string strErrMsg = string.Empty;
            lstExport = new List<ProfitLossInfo>();
            ProfitLossInfo queryExport = new ProfitLossInfo();

            try
            {
                this.Cursor = Cursors.WaitCursor;

                queryExport.CheckID = queryMain.CheckID;
                //queryExport.AreaNo = queryMain.AreaNo;
                //queryExport.ProfitLoss = queryMain.ProfitLoss;

                DividPage serverPage = new DividPage();
                serverPage.CurrentPageNumber = 1;
                serverPage.CurrentPageShowCounts = -1;

                if (!Check_Func.GetProfitLossListByPage(ref lstExport, queryExport, ref serverPage, ref strErrMsg))
                {
                    Common.Common_Func.ErrorMessage(strErrMsg, "导出失败", 2);
                    return false;
                }

                lstExport.ForEach(t => t.CheckNo = _check.CheckNo);
                return true;
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "导出失败", 2);
                return false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ExportDetails()
        {
            if (dgvList.DataSource == null || dgvList.Rows.Count <= 0)
            {
                Common.Common_Func.ErrorMessage("请先查询到结果后再尝试导出明细", "导出失败", 2);
                return;
            }

            List<ProfitLossInfo> lstExport = new List<ProfitLossInfo>();
            if (!GetExportDetailData(ref lstExport)) return;

            try
            {
                string filename = string.Format("{0}_{1}.xlsx", _check.CheckNo, DateTime.Now.ToString("yyyyMMddHHmm"));
                string excludecol = "";
                Dictionary<string, string> dicFields = new Dictionary<string, string>();
                dicFields.Add("CheckNo", "盘点单号");
                //dicFields.Add("CheckType", "盘点类型");
                dicFields.Add("StrCheckType", "盘点类型");
                dicFields.Add("WarehouseNo", "账存仓库编号");
                //dicFields.Add("WarehouseName", "账存仓库名称");
                dicFields.Add("HouseNo", "账存库区编号");
                //dicFields.Add("HouseName", "账存库区名称");
                dicFields.Add("AreaNo", "账存货位编号");
                //dicFields.Add("AreaName", "账存货位名称");
                dicFields.Add("ScanWarehouseNo", "实盘仓库编号");
                //dicFields.Add("ScanWarehouseName", "实盘仓库名称");
                dicFields.Add("ScanHouseNo", "实盘库区编号");
                //dicFields.Add("ScanHouseName", "实盘库区名称");
                dicFields.Add("ScanAreaNo", "实盘货位编号");
                //dicFields.Add("ScanAreaName", "实盘货位名称");
                dicFields.Add("Barcode", "扫描条码");
                dicFields.Add("SerialNo", "序列号");
                dicFields.Add("MaterialNo", "物料编号");
                dicFields.Add("MaterialDesc", "物料描述");
                dicFields.Add("BatchNo", "生产批次");
                dicFields.Add("SN", "来料批次");
                dicFields.Add("AccountQty", "账存数量");
                dicFields.Add("ScanQty", "实盘数量");
                dicFields.Add("StrProfitLoss", "盈亏状态");
                dicFields.Add("DifferenceQty", "盈亏数量");
                ExcelLibrary.ExcelLibrary_Func.SaveListToExcelByNPOI(ref filename, lstExport, false, true, excludecol, dicFields, dgvList.DefaultCellStyle.Font);
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "导出失败", 2);
                return;
            }
        }

        private void ReCheck()
        {
            //string strError = string.Empty;
            //CheckInfo reCheck = new CheckInfo();
            //if (!Check_Func.ReCheckByCheck(_check, ref reCheck, ref strError))
            //{
            //    Common.Common_Func.ErrorMessage(strError, "复盘失败", 2);
            //}
            //else
            //{
            //    Common.Common_Func.ErrorMessage(string.Format("复盘成功!盘点号为【{0}】", reCheck.CheckNo), "复盘成功");
            //}

            using (FrmReCheck frm = new FrmReCheck(_check))
            {
                frm.ShowDialog();
            }
        }

        private void SetSearchBtn()
        {
            Common.Common_Func.SetSearchBtn(this, cbbProfitLoss, btnSearch, tsmiSearch);
        }

        #endregion
    }
}
