using ExcelLibrary;
using WMS.Basic;
using WMS.Common;
using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WMS.Print
{
    public partial class FrmAreaPrint : Common.FrmBasic
    {
        private DividPage _serverMainPage;
        private AreaInfo queryMain;
        private List<AreaInfo> lstMain;

        public FrmAreaPrint()
        {
            InitializeComponent();

            Common.Common_Func.DelDataGridViewSortable(dgvList);
        }

        private void FrmAreaPrint_Load(object sender, EventArgs e)
        {
            SetSearchBtn();
            InitForm();

            if (!Print_Func.CheckPrinter()) return;
        }

        private void tsmiEditArea_Click(object sender, EventArgs e)
        {
            EditDetailsRow();
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
            try
            {
                this.Cursor = Cursors.WaitCursor;

                BindList();
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

        private void cbxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            SelectAll();
        }
        
        private void dgvList_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll) return;

            cbxSelectAll.Visible = e.NewValue == 0;
        }

        private void pageList_ChensPageChange(object sender, EventArgs e)
        {
            GetListQueryData();
        }


        #region Function

        private void InitForm()
        {
            InitMainQuery();

            //BindList();
        }

        private void InitMainQuery()
        {
            _serverMainPage = new DividPage();
            queryMain = new AreaInfo();
            lstMain = new List<AreaInfo>();

            pageList.GetShowCountsByDGV(dgvList);
            bsMain.DataSource = queryMain;

            cbxSelectAll.Width = colSelect.Width;
            cbxSelectAll.BackColor = dgvList.ColumnHeadersDefaultCellStyle.BackColor;
            cbxSelectAll.Font = dgvList.ColumnHeadersDefaultCellStyle.Font;
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
                bResult = Basic_Func.GetAreaListByPage(ref lstMain, queryMain, ref _serverMainPage, ref strErr);
                Common.Common_Func.GetClientPageFromServerPage(_serverMainPage, ref clientPage);
                pageList.ShowPage();
                dgvList.DataSource = lstMain;

                if (!bResult || !string.IsNullOrEmpty(strErr)) Common.Common_Func.ErrorMessage(strErr, "查询失败");

                if (dgvList.DataSource == null || dgvList.Rows.Count <= 0)
                {
                }
                else
                {
                    dgvList.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                }
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "查询失败");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                cbxSelectAll.Checked = false;
                txtAreaNo.Focus();
            }
        }

        private void GetQueryMain()
        {
            if (queryMain == null) { queryMain = new AreaInfo(); bsMain.DataSource = queryMain; }
            if (dtpStartTime.Checked) queryMain.StartTime = dtpStartTime.Value;
            else queryMain.StartTime = null;
            if (dtpEndTime.Checked) queryMain.EndTime = dtpEndTime.Value;
            else queryMain.EndTime = null;
        }

        private void PrintLabel()
        {
            btnSearch.Focus();

            if (!Print_Func.CheckPrinter(false)) return;

            if (dgvList.Rows.Count <= 0)
            {
                Common.Common_Func.ErrorMessage("请先选中需要打印的货位", "打印失败");
                return;
            }

            bool isPrinted = false;

            string strPrintCode = string.Empty;
            int iPrintQty = 0;
            int iPrintCount = 0;
            foreach (DataGridViewRow dgvr in dgvList.Rows)
            {
                if (dgvr.Cells["colSelect"].Value.ToBoolean())
                {
                    if (dgvr.Cells["colPrintQty"].Value == null)
                    {
                        iPrintQty = colPrintQty.DefaultCellStyle.NullValue.ToInt32();
                    }
                    else
                    {
                        try { iPrintQty = Convert.ToInt32(dgvr.Cells["colPrintQty"].Value); }
                        catch { iPrintQty = 0; }
                    }
                    if (iPrintQty <= 0)
                    {
                        Common.Common_Func.ErrorMessage("第" + dgvr.Index + 1 + "行数量输入错误", "打印失败");
                        continue;
                    }

                    isPrinted = true;

                    if (iPrintCount / Print_Var.OutboxPrintNum >= 1 || iPrintCount % Print_Var.OutboxPrintNum == 0)
                    {
                        iPrintCount = 0;
                        if (!string.IsNullOrEmpty(strPrintCode))
                        {
                            Print_Func.SendStringToPrinter(strPrintCode);
                        }

                        strPrintCode = string.Empty;
                    }

                    if (!PrintRow(lstMain[dgvr.Index], iPrintQty, ref strPrintCode)) continue;

                    iPrintCount += iPrintQty;
                }
            }

            if (!isPrinted)
            {
                Common.Common_Func.ErrorMessage("请先选中需要打印的货位", "打印失败");
                return;
            }
            else
            {
                if (iPrintCount >= 1 && !string.IsNullOrEmpty(strPrintCode))
                {
                    Print_Func.SendStringToPrinter(strPrintCode);
                }

                if (cbxSelectAll.Checked)
                {
                    cbxSelectAll.Checked = false;
                }
                else
                {
                    SelectAll();
                }

                //GetListQueryData();
            }
        }

        private bool PrintRow(AreaInfo area, int iPrintQty, ref string sPrintCode)
        {
            string strOnce = "";
            if(area.AreaType == 2)
            {
                strOnce = Print_Func.GetTempAreaPrintStr(area.AreaNo);
            }
            else
            {
                strOnce = Print_Func.GetAreaPrintStr(area.AreaNo);
            }
            if (string.IsNullOrEmpty(strOnce))
            {
                return Common.Common_Func.ErrorMessage("货位标签 " + area.AreaName + " 打印失败", "打印失败");
            }


            string strContent = string.Empty;
            for (int i = 1; i <= iPrintQty; i++)
            {
                strContent += strOnce;
            }

            sPrintCode += strContent;
            return true;
        }

        private void EditDetailsRow()
        {
            //Basic.FrmAreaList frm = new FrmAreaList();
            //Common_Func.ShowTabPageForm(this, frm);
        }

        private AreaInfo GetListRowModel()
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList))
            {
                Common.Common_Func.ErrorMessage("请先选中一行", "删除失败");
                return null;
            }

            string strErr = string.Empty;
            AreaInfo warehouse = new AreaInfo();
            warehouse.ID = lstMain[dgvList.CurrentCell.RowIndex].ID;

            if (!Basic_Func.GetAreaByID(ref warehouse, ref strErr))
            {
                Common.Common_Func.ErrorMessage(strErr, "读取失败");
                GetListQueryData();
                return null;
            }

            return warehouse;
        }

        private void ShowFileForm(AreaInfo area)
        {
            HouseInfo house = GetBelongHouse(area.HouseID);
            if (house == null) return;

            using (FrmAreaFile frm = new FrmAreaFile(area, house))
            {
                frm.ShowDialog();
            }

            this.Refresh();
            Application.DoEvents();

            GetListQueryData();
        }

        private HouseInfo GetBelongHouse(int HouseID)
        {
            HouseInfo house = new HouseInfo();

            if (HouseID <= 0)
            {
                Common.Common_Func.ErrorMessage("获取库区信息失败", "错误");
                return null;
            }
            else
            {
                string strError = string.Empty;
                house = new HouseInfo() { ID = HouseID };

                if (!Basic_Func.GetHouseByID(ref house, ref strError))
                {
                    Common.Common_Func.ErrorMessage(strError, "错误");
                    return null;
                }
            }

            return house;
        }

        private void SelectAll()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Common.Common_Func.SetSelectAll(dgvList, cbxSelectAll.Checked);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void SetSearchBtn()
        {
            Common.Common_Func.SetSearchBtn(this, txtAreaNo, btnSearch, tsmiSearch);
        }

        #endregion


    }
}
