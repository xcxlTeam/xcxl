using WMS.Common;
using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WMS.Print
{
    public partial class FrmOutBarcodeRePrint : Common.FrmBaseDialog
    {
        private VoucherType _type;

        private DividPage _serverMainPage;
        private Barcode_Model queryMain;
        private List<Barcode_Model> lstMain;

        public FrmOutBarcodeRePrint()
        {
            InitializeComponent();

            Common.Common_Func.DelDataGridViewSortable(dgvList);

            _type = VoucherType.任意单据;
            queryMain = new Barcode_Model();
        }
        public FrmOutBarcodeRePrint(string type)
        {
            InitializeComponent();

            Common.Common_Func.DelDataGridViewSortable(dgvList);

            _type = (VoucherType)type.ToInt32();

            SetForm();
        }
        public FrmOutBarcodeRePrint(VoucherType type, Barcode_Model barcode)
        {
            InitializeComponent();

            Common.Common_Func.DelDataGridViewSortable(dgvList);

            _type = type;
            queryMain = barcode;

            SetForm();
        }

        private void FrmOutBarcodeRePrint_Load(object sender, EventArgs e)
        {
            SetSearchBtn();
            InitForm();
            BindList();
           if (!Print_Func.CheckPrinter()) return;
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

        private void tsmiCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void dgvList_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll) return;

            cbxSelectAll.Visible = e.NewValue == 0;
        }

        private void pageList_ChensPageChange(object sender, EventArgs e)
        {
            GetListQueryData();
        }

        private void cbxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            SelectAll();
        }


        #region Function

        private void SetForm()
        {
            switch (_type)
            {
                case VoucherType.送货单:
                    this.Text = "送货单外箱标签重打";
                    lblVoucherNo.Text = "送货单号";
                    colVOUCHERNO.HeaderText = "采购订单号";

                    lblaAndalaNo.Visible = false;
                    txtAndalaNo.Visible = false;

                    colDepartment.Visible = false;
                    colReason.Visible = false;
                    colTrackNo.Visible = false;
                    colReserveNumber.Visible = false;
                    colReserveRowNo.Visible = false;
                    colAndalaNo.Visible = false;

                    txtVoucherNo.DataBindings.Clear();
                    txtVoucherNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "DELIVERYNO", true));
                    break;

                case VoucherType.生产退料:
                    this.Text = "生产退料单外箱标签重打";
                    lblVoucherNo.Text = "生产退料单";
                    lblaAndalaNo.Text = "生产订单";
                    colVOUCHERNO.HeaderText = "生产退料单号";
                    colTrackNo.HeaderText = "生产订单号";

                    lblaAndalaNo.Visible = false;
                    txtAndalaNo.Visible = false;

                    //colVOUCHERNO.Visible = false;
                    colDELIVERYNO.Visible = false;
                    //colSUPCODE.Visible = false;
                    //colSUPNAME.Visible = false;
                    colPlated.Visible = false;
                    colROWNO.Visible = false;
                    colPRDVERSION.Visible = false;
                    colAndalaNo.Visible = false;
                    break;

                case VoucherType.生产订单:
                    this.Text = "生产订单外箱标签重打";
                    lblVoucherNo.Text = "生产订单";
                    lblaAndalaNo.Text = "进仓单号";
                    colVOUCHERNO.HeaderText = "生产订单号";

                    //colVOUCHERNO.Visible = false;
                    colDELIVERYNO.Visible = false;
                    colSUPCODE.Visible = false;
                    colSUPNAME.Visible = false;
                    colPlated.Visible = false;
                    colROWNO.Visible = false;
                    colDepartment.Visible = false;
                    colReason.Visible = false;
                    colTrackNo.Visible = false;
                    colReserveNumber.Visible = false;
                    colReserveRowNo.Visible = false;
                    break;

                case VoucherType.采购订单:
                    this.Text = "采购订单外箱标签重打";
                    lblVoucherNo.Text = "采购订单";

                    lblaAndalaNo.Visible = false;
                    txtAndalaNo.Visible = false;

                    //colVOUCHERNO.Visible = false;
                    colDELIVERYNO.Visible = false;
                    colROWNO.Visible = false;
                    colDepartment.Visible = false;
                    colReason.Visible = false;
                    colTrackNo.Visible = false;
                    colReserveNumber.Visible = false;
                    colReserveRowNo.Visible = false;
                    colAndalaNo.Visible = false;
                    break;

                case VoucherType.无过账快速入:
                case VoucherType.需过账快速入:
                    this.Text = "快速入库单外箱标签打印";
                    lblVoucherNo.Text = "快速入库单";
                    colVOUCHERNO.HeaderText = "快速入库单号";

                    lblaAndalaNo.Visible = false;
                    txtAndalaNo.Visible = false;

                    //colVOUCHERNO.Visible = false;
                    colDELIVERYNO.Visible = false;
                    colROWNO.Visible = false;
                    colDepartment.Visible = false;
                    colReason.Visible = false;
                    colTrackNo.Visible = false;
                    colReserveNumber.Visible = false;
                    colReserveRowNo.Visible = false;
                    colAndalaNo.Visible = false;
                    break;

                default:
                    break;
            }
        }

        private void InitForm()
        {
            InitMainQuery();
        }

        private void InitMainQuery()
        {
            _serverMainPage = new DividPage();
            //queryMain = new Barcode_Model();
            lstMain = new List<Barcode_Model>();

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
                string strError = string.Empty;
                GetQueryMain();

                ChensControl.DividPage clientPage = pageList.dDividPage;
                Common.Common_Func.GetServerPageFromClientPage(ref _serverMainPage, clientPage);
                bResult = Print_Func.GetOutBarcodeListByPage(ref lstMain, queryMain, ref _serverMainPage, ref strError);
                Common.Common_Func.GetClientPageFromServerPage(_serverMainPage, ref clientPage);
                pageList.ShowPage();
                dgvList.DataSource = lstMain;

                if (!bResult || !string.IsNullOrEmpty(strError)) Common.Common_Func.ErrorMessage(strError, "查询失败");

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
                txtVoucherNo.Focus();
            }
        }

        private void GetQueryMain()
        {
            if (queryMain == null) { queryMain = new Barcode_Model(); bsMain.DataSource = queryMain; }
            queryMain.BARCODETYPE = 10;
            queryMain.VOUCHERTYPE = _type.ToInt32().ToString();
        }

        private void PrintLabel()
        {
            if (lstMain == null || lstMain.Count <= 0) return;

            btnSearch.Focus();

            if (!Print_Func.CheckPrinter(false)) return;

            bool isPrinted = false;

            string strPrintCode = string.Empty;
            int iPrintQty = 0;
            int iPrintCount = 0;
            string strLogo = Print_Func.GetBoxLogoStr(_type);
            string strContent = string.Empty;
            string strClear = Print_Func.GetBoxClearStr(_type);
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
                        if (!string.IsNullOrEmpty(strContent))
                        {
                            strPrintCode += strLogo;
                            strPrintCode += strContent;
                            strPrintCode += strClear;
                            Print_Func.SendStringToPrinter(strPrintCode);
                        }

                        strPrintCode = string.Empty;
                        strContent = string.Empty;
                    }

                    if (!PrintRow(lstMain[dgvr.Index], iPrintQty, ref strContent)) continue;

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
                if (iPrintCount >= 1 && !string.IsNullOrEmpty(strContent))
                {
                    strPrintCode += strLogo;
                    strPrintCode += strContent;
                    strPrintCode += strClear;
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


        private bool PrintRow(Barcode_Model barcode, int iPrintQty, ref string sPrintCode)
        {
            string strError = string.Empty;
            barcode.PRINTQTY = iPrintQty;
            if (!Print_Func.PrintBarcode(barcode, ref strError))
            {
                //return false;
            }

            string strOnce = Print_Func.GetBoxContentStr(_type, barcode);
            if (string.IsNullOrEmpty(strOnce))
            {
                return Common.Common_Func.ErrorMessage("外箱标签 " + barcode.SERIALNO + " 打印失败", "打印失败");
            }


            string strContent = string.Empty;
            for (int i = 1; i <= iPrintQty; i++)
            {
                strContent += strOnce;
            }

            sPrintCode += strContent;
            return true;
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
            if (btnSearch.Left > this.Width - btnSearch.Width)
            {
                int X = this.Width / 2;
                if (X >= txtVoucherNo.Location.X + txtVoucherNo.Width)
                {
                    btnSearch.Location = new System.Drawing.Point(X, btnSearch.Location.Y);
                    tsmiSearch.Visible = false;
                }
                else
                {
                    btnSearch.Visible = false;
                    tsmiSearch.Visible = true;
                }
            }
        }

        #endregion
    }
}
