using WMS.Common;
using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WMS.Print
{
    public partial class FrmOutBarcodePrint : Common.FrmBasic
    {
        //private Supplier_Model supplier;
        private VoucherType _type;
        private Barcode_Model parameter;
        private List<Barcode_Model> lstBarcode;

        private DividPage _serverMainPage;
        private Barcode_Model queryMain;
        private List<Barcode_Model> lstMain;

        public FrmOutBarcodePrint()
        {
            InitializeComponent();

            Common.Common_Func.DelDataGridViewSortable(dgvList);

            _type = VoucherType.任意单据;
        }
        public FrmOutBarcodePrint(string type)
        {
            InitializeComponent();

            Common.Common_Func.DelDataGridViewSortable(dgvList);

            _type = (VoucherType)type.ToInt32();

            SetForm();
        }

        private void FrmOutBarcodePrint_Load(object sender, EventArgs e)
        {
            SetSearchBtn();
            InitForm();

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
                //supplier = null;
                this.Cursor = Cursors.Default;
            }
        }

        private void tsmiRePrint_Click(object sender, EventArgs e)
        {
            try
            {
                //this.Cursor = Cursors.WaitCursor;

                RePrint();
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

        private void txtVoucherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    this.Cursor = Cursors.WaitCursor;

                    BindList();
                }
                else if (e.KeyChar == (char)Keys.Back)
                {
                    if (string.IsNullOrEmpty(txtVoucherNo.Text))
                    {
                        lstMain = new List<Barcode_Model>();
                        SetBarcodeParameter(0);
                    }
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

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetBarcodeParameter(e.RowIndex);
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

        private void txtPrintQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    this.Cursor = Cursors.WaitCursor;

                    PrintLabel();

                    //supplier = null;
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

        private void cbxPlatedSilver_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                parameter.BPlatedGold = false;
                parameter.BPlatedTin = false;
                parameter.BPlatedOther = false;
            }
        }

        private void cbxPlatedTin_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                parameter.BPlatedGold = false;
                parameter.BPlatedSilver = false;
                parameter.BPlatedOther = false;
            }
        }

        private void cbxOther_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                parameter.BPlatedGold = false;
                parameter.BPlatedSilver = false;
                parameter.BPlatedTin = false;
            }
        }

        private void tsmiTest_Click(object sender, EventArgs e)
        {

        }

        private void txtSupCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    this.Cursor = Cursors.WaitCursor;

                    if (string.IsNullOrEmpty(txtSupCode.Text)) return;

                    //if (GetSupplier())
                    //{
                    //    parameter.SUPCODE = supplier.SupplierCode;
                    //    parameter.SUPNAME = supplier.SupplierName;
                    //}
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

        private void txtSupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_type == VoucherType.无过账快速入 || _type == VoucherType.需过账快速入)
            {
                txtSupCode_KeyPress(sender, e);
            }
        }


        #region Function

        private void SetForm()
        {
            switch (_type)
            {
                case VoucherType.送货单:
                    this.Text = "送货单外箱标签打印";
                    lblVoucherNo.Text = "送货单号";
                    gbMiddle.Text = "送货单明细";
                    colHVoucherNo.HeaderText = "采购订单号";

                    colHTrackNo.Visible = false;
                    colHReserveNumber.Visible = false;
                    colHReserveRowNo.Visible = false;
                    colHReason.Visible = false;

                    lblSupCode.Visible = false;
                    txtSupCode.Visible = false;
                    lblSupName.Visible = false;
                    txtSupName.Visible = false;
                    lblReserveUser.Visible = false;
                    txtReserveUser.Visible = false;
                    cbxShowSup.Visible = true;
                    break;

                case VoucherType.生产退料:
                    this.Text = "生产退料单外箱标签打印";
                    lblVoucherNo.Text = "生产退料单";
                    gbMiddle.Text = "退料单明细";
                    colHVoucherNo.HeaderText = "生产退料单号";
                    colHRowNo.HeaderText = "退货单行号";
                    colHCurrentlyDeliveryNum.HeaderText = "退料数量";

                    colHVoucherNo.Visible = false;
                    colHDeliveryNo.Visible = false;
                    colHSupCode.Visible = false;
                    colHSupName.Visible = false;
                    colHRowNo.Visible = true;
                    colHTrackNo.Visible = true;
                    colHReserveNumber.Visible = true;
                    colHReserveRowNo.Visible = true;
                    colHReason.Visible = true;

                    //lblInnerPackQty.Visible = false;
                    //txtInnerPackQty.Visible = false;
                    //lblReserveUser.Visible = false;
                    //txtReserveUser.Visible = false;
                    cbxPlatedSilver.Visible = false;
                    cbxPlatedTin.Visible = false;
                    cbxOther.Visible = false;
                    cbxShowSup.Visible = false;

                    lblInnerPackQty.Text = "退仓部门";
                    txtInnerPackQty.DataBindings.Clear();
                    txtInnerPackQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "Department", true));
                    break;

                case VoucherType.生产订单:
                    this.Text = "生产订单外箱标签打印";
                    lblVoucherNo.Text = "生产订单";
                    gbMiddle.Text = "生产订单明细";
                    colHVoucherNo.HeaderText = "生产订单号";
                    colHCurrentlyDeliveryNum.HeaderText = "订单数量";

                    colHVoucherNo.Visible = false;
                    colHDeliveryNo.Visible = false;
                    colHSupCode.Visible = false;
                    colHSupName.Visible = false;
                    colHRowNo.Visible = false;
                    colHTrackNo.Visible = false;
                    colHReserveNumber.Visible = false;
                    colHReserveRowNo.Visible = false;
                    colHReason.Visible = false;

                    //lblInnerPackQty.Visible = false;
                    //txtInnerPackQty.Visible = false;
                    cbxPlatedSilver.Visible = false;
                    cbxPlatedTin.Visible = false;
                    cbxOther.Visible = false;
                    lblSupCode.Visible = true;
                    txtSupCode.Visible = true;
                    lblSupName.Visible = false;
                    txtSupName.Visible = false;
                    lblReserveUser.Visible = false;
                    txtReserveUser.Visible = false;
                    cbxShowSup.Visible = false;

                    lblSupCode.Text = "产品版本";
                    txtSupCode.DataBindings.Clear();
                    txtSupCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "PRDVERSION", true));
                    lblInnerPackQty.Text = "进仓单号";
                    txtInnerPackQty.DataBindings.Clear();
                    txtInnerPackQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "TrackNo", true));
                    //lblSupName.Text = "备注";
                    //txtSupName.DataBindings.Clear();
                    //txtSupName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "Reason", true));
                    break;

                case VoucherType.无过账快速入:
                case VoucherType.需过账快速入:
                    this.Text = "快速入库单外箱标签打印";
                    lblVoucherNo.Text = "快速入库单";
                    gbMiddle.Text = "快速入库单明细";
                    colHCurrentlyDeliveryNum.HeaderText = "单据数量";

                    colHVoucherNo.Visible = false;
                    colHDeliveryNo.Visible = false;
                    colHRowNo.Visible = false;
                    colHTrackNo.Visible = false;
                    colHReserveNumber.Visible = false;
                    colHReserveRowNo.Visible = false;
                    colHReason.Visible = false;

                    lblSupCode.Visible = false;
                    txtSupCode.Visible = false;
                    lblSupName.Visible = true;
                    txtSupName.Visible = true;
                    lblReserveUser.Visible = true;
                    txtReserveUser.Visible = true;
                    cbxShowSup.Visible = true;

                    lblSupName.Text = "供应商代码";
                    txtSupName.Enabled = true;
                    txtSupName.DataBindings.Clear();
                    txtSupName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "SUPCODE", true));
                    lblReserveUser.Text = "产品版本";
                    txtReserveUser.DataBindings.Clear();
                    txtReserveUser.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "PRDVERSION", true));
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
            parameter = new Barcode_Model();
            parameter.PRINTQTY = _type == VoucherType.送货单 ? 2 : 1;
            lstBarcode = new List<Barcode_Model>();

            _serverMainPage = new DividPage();
            queryMain = new Barcode_Model();
            lstMain = new List<Barcode_Model>();

            //pageList.GetShowCountsByDGV(dgvList);
            pageList.dDividPage.CurrentPageShowCounts = 1000;
            bsCreate.DataSource = parameter;
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
            string strError = string.Empty;
            GetQueryMain();

            bResult = Print_Func.GetPrintInfo(_type, queryMain, ref lstMain, ref strError);
            //ChensControl.DividPage clientPage = pageList.dDividPage;
            //Common.Common_Func.GetServerPageFromClientPage(ref _serverMainPage, clientPage);
            //bResult = Print_Func.GetPrintInfo(ref lstMain, queryMain, ref _serverMainPage, ref strError);
            //Common.Common_Func.GetClientPageFromServerPage(_serverMainPage, ref clientPage);
            //pageList.ShowPage();
            dgvList.DataSource = lstMain;

            if (!bResult || !string.IsNullOrEmpty(strError)) Common.Common_Func.ErrorMessage(strError, "查询失败");

            if (bResult)
            {
                SetBarcodeParameter(0);
            }
            else
            {
                txtVoucherNo.Focus();
                txtVoucherNo.SelectAll();
            }
        }

        private void GetQueryMain()
        {
            if (queryMain == null) { queryMain = new Barcode_Model(); bsMain.DataSource = queryMain; }
            queryMain.VOUCHERTYPE = _type.ToInt32().ToString();
        }

        private void RePrint()
        {
            Barcode_Model query = new Barcode_Model();
            if (parameter != null)
            {
                //query.VOUCHERTYPE = parameter.VOUCHERTYPE;
                //query.VOUCHERNO = parameter.VOUCHERNO;
                query.DELIVERYNO = parameter.DELIVERYNO;
            }

            using (FrmOutBarcodeRePrint frm = new FrmOutBarcodeRePrint(_type, query))
            {
                frm.ShowDialog();
            }
        }

        private void SetBarcodeParameter(int iRowIndex)
        {
            if (lstMain == null || lstMain.Count <= 0 || !Common.Common_Func.CheckDgvOper(dgvList))
            {
                parameter = new Barcode_Model();
                parameter.MATERIALNO = "";
                parameter.MATERIALDESC = "";
                parameter.BATCHNO = "";
                parameter.OUTPACKQTY = 0;
                parameter.INNERPACKQTY = 0;
                parameter.BPlatedSilver = false;
                parameter.BPlatedTin = false;
                parameter.BPlatedOther = false;
                parameter.BSHOWSUP = false;
                parameter.PRINTQTY = _type == VoucherType.送货单 ? 2 : 1;
                //supplier = null;

                //txtMaterialNo.Text = "";
                //txtMaterialDesc.Text = "";
                //txtBatchNo.Text = "";
                //txtOutPackQty.Text = "0";
                //txtInnerPackQty.Text = "0";
                //cbxPlatedSilver.Checked = false;
                //cbxPlatedTin.Checked = false;
                //cbxOther.Checked = false;
                //txtPrintQty.Text = "2";

                switch (_type)
                {
                    case VoucherType.送货单:
                        break;

                    case VoucherType.生产订单:
                        txtInnerPackQty.Text = "";
                        txtSupCode.Text = "";
                        txtSupName.Text = "";
                        break;

                    case VoucherType.生产退料:
                        txtInnerPackQty.Text = "";
                        txtSupCode.Text = "";
                        txtSupName.Text = "";
                        txtReserveUser.Text = "";
                        txtReserveUser.Enabled = false;
                        break;

                    case VoucherType.无过账快速入:
                    case VoucherType.需过账快速入:
                        txtSupCode.Text = "";
                        txtSupName.Text = "";
                        txtReserveUser.Text = "";
                        break;
                }

            }
            else
            {
                Barcode_Model row = lstMain[iRowIndex];

                parameter = new Barcode_Model();
                parameter.BARCODETYPE = 10;
                parameter.VOUCHERNO = row.VOUCHERNO;
                parameter.WaitDeliveryNum = row.WaitDeliveryNum;
                parameter.ROWNO = row.ROWNO;
                parameter.VOUCHERQTY = row.CURRENTLYDELIVERYNUM;
                parameter.BATCHQTY = row.CURRENTLYDELIVERYNUM;
                parameter.DELIVERYNO = row.DELIVERYNO;
                parameter.PRDVERSION = row.PRDVERSION;
                parameter.CUSNAME = row.Comba;
                parameter.SUPNAME = row.SUPNAME;
                parameter.SUPCODE = row.SUPCODE;
                parameter.Plant = row.Plant;
                parameter.VOUCHERTYPE = _type.ToInt32().ToString();
                parameter.ISROHS = row.ISROHS;
                parameter.PLATEDGOLD = parameter.BPlatedGold ? 2 : 1;
                parameter.PLATEDSILVER = parameter.BPlatedSilver ? 2 : 1;
                parameter.PLATEDTIN = parameter.BPlatedTin ? 2 : 1;
                parameter.OTHERS = parameter.BPlatedOther ? 2 : 1;
                parameter.OPERATOR = Common_Var.CurrentUser.UserName;
                parameter.MATERIALNO = row.MATERIALNO;
                parameter.MATERIALDESC = row.MATERIALDESC;
                parameter.BATCHNO = "";// DateTime.Now.ToString("yyyyMMdd");
                parameter.OUTPACKQTY = 0;
                parameter.INNERPACKQTY = 0;
                parameter.BPlatedSilver = false;
                parameter.BPlatedTin = false;
                parameter.BPlatedOther = false;
                parameter.BSHOWSUP = false;
                parameter.PRINTQTY = _type == VoucherType.送货单 ? 2 : 1;
                //supplier = null;

                //txtMaterialNo.Text = row.MATERIALNO; ;
                //txtMaterialDesc.Text = row.MATERIALDESC; ;
                //txtBatchNo.Text = DateTime.Now.ToString("yyyyMMdd");
                //txtOutPackQty.Text = row.WaitDeliveryNum.ToString();
                //txtInnerPackQty.Text = row.WaitDeliveryNum.ToString();
                //cbxPlatedSilver.Checked = false;
                //cbxPlatedTin.Checked = false;
                //cbxOther.Checked = false;
                //txtPrintQty.Text = "2";

                switch (_type)
                {
                    case VoucherType.送货单:
                        break;

                    case VoucherType.生产订单:
                        txtInnerPackQty.Text = row.AndalaNo;
                        txtSupCode.Text = row.PRDVERSION;
                        txtSupName.Text = row.Reason;
                        break;

                    case VoucherType.生产退料:
                        txtInnerPackQty.Text = row.Department;
                        txtSupCode.Text = row.SUPCODE;
                        txtSupName.Text = row.SUPNAME;
                        txtReserveUser.Enabled = false;
                        break;

                    case VoucherType.无过账快速入:
                    case VoucherType.需过账快速入:
                        txtSupName.Text = row.SUPCODE;
                        txtReserveUser.Text = row.PRDVERSION;
                        break;
                }
            }

            bsCreate.DataSource = parameter;
            txtBatchNo.Focus();
            txtBatchNo.SelectAll();
        }

        private void PrintLabel()
        {
            if (lstMain == null || lstMain.Count <= 0) return;

            if (!Print_Func.CheckPrinter(false)) return;

            if (CreateBarcode())
            {
                PrintBarcode();
            }
        }

        private bool CreateBarcode()
        {
            bsCreate.EndEdit();

            bool bResult = false;
            string strError = string.Empty;
            GetCreatePara();

            if (!CheckCreate()) return false;

            List<Barcode_Model> lst = new List<Barcode_Model>();
            bResult = Print_Func.CreateBarcodeInfo(parameter, ref lst, ref strError);


            if (!bResult || !string.IsNullOrEmpty(strError)) return Common.Common_Func.ErrorMessage(strError, "生成失败");
            if (lst == null || lst.Count <= 0) return Common.Common_Func.ErrorMessage("未获取到任何数据", "生成失败");

            lstBarcode = lst;
            return true;
        }

        private bool CheckCreate()
        {
            if (string.IsNullOrEmpty(parameter.BATCHNO))
            {
                return Common.Common_Func.ErrorMessage("生产批号不能为空!", "打印失败");
            }

            if (parameter.OUTPACKQTY <= 0)
            {
                return Common.Common_Func.ErrorMessage("外箱包装量输入错误!", "打印失败");
            }

            if (parameter.INNERPACKQTY <= 0)
            {
                return Common.Common_Func.ErrorMessage("内盒包装量输入错误!", "打印失败");
            }

            if (parameter.PRINTQTY <= 0)
            {
                return Common.Common_Func.ErrorMessage("打印份数输入错误!", "打印失败");
            }

            if (parameter.INNERPACKQTY > parameter.BATCHQTY)
            {
                return Common.Common_Func.ErrorMessage(string.Format("内盒包装数量【{0}】不能大于本批次数量【{1}】!", parameter.INNERPACKQTY, parameter.BATCHQTY), "打印失败");
            }

            if (parameter.INNERPACKQTY > parameter.OUTPACKQTY)
            {
                return Common.Common_Func.ErrorMessage(string.Format("内盒包装数量【{0}】不能大于外箱包装数量【{1}】!", parameter.INNERPACKQTY, parameter.OUTPACKQTY), "打印失败");
            }

            if (parameter.BATCHQTY > parameter.VOUCHERQTY)
            {
                return Common.Common_Func.ErrorMessage(string.Format("本批次数量【{0}】不能大于单据行数量【{1}】!", parameter.BATCHQTY, parameter.VOUCHERQTY), "打印失败");
            }

            //if (parameter.OUTPACKQTY % parameter.INNERPACKQTY >= 1)
            //{
            //    return Common.Common_Func.ErrorMessage(string.Format("外箱包装数量【{0}】必须是内盒包装数量的整数倍【{1}】!", parameter.OUTPACKQTY, parameter.INNERPACKQTY));
            //}

            switch (_type)
            {
                case VoucherType.送货单:
                case VoucherType.无过账快速入:
                case VoucherType.需过账快速入:
                    if (parameter.PLATEDSILVER != 2 && parameter.PLATEDTIN != 2 && parameter.OTHERS != 2)
                    {
                        return Common.Common_Func.ErrorMessage("镀层物料必须选择!", "打印失败");
                    }
                    break;

                case VoucherType.生产退料:
                    //if (string.IsNullOrEmpty(parameter.CUSNAME))
                    //{
                    //    return Common.Common_Func.ErrorMessage("退仓部门必须输入!", "打印失败");
                    //}
                    //if (supplier == null || string.IsNullOrEmpty(supplier.SupplierCode))
                    //{
                    //    return Common.Common_Func.ErrorMessage("供应商必须输入!", "打印失败");
                    //}
                    //parameter.SUPCODE = supplier.SupplierCode;
                    //parameter.SUPNAME = supplier.SupplierName;
                    break;

            }

            return true;
        }

        private void PrintBarcode()
        {
            btnSearch.Focus();

            bool isPrinted = false;

            string strPrintCode = string.Empty;
            int iPrintQty = 0;
            int iPrintCount = 0;
            string strLogo = Print_Func.GetBoxLogoStr(_type);
            string strContent = string.Empty;
            string strClear = Print_Func.GetBoxClearStr(_type);
            foreach (Barcode_Model barcode in lstBarcode)
            {
                iPrintQty = barcode.PRINTQTY.ToInt32();
                if (iPrintQty <= 0)
                {
                    Common.Common_Func.ErrorMessage("外箱标签 " + barcode.SERIALNO + " 打印份数输入错误", "打印失败");
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

                if (!PrintRow(barcode, iPrintQty, ref strContent)) continue;

                iPrintCount += iPrintQty;

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

                //GetListQueryData();
            }

            SetBarcodeParameter(dgvList.CurrentCell.RowIndex);
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

        private void GetCreatePara()
        {
            if (parameter == null) parameter = new Barcode_Model();
            if (lstMain == null || lstMain.Count <= 0 || dgvList.Rows.Count <= 0) return;
            int index = dgvList.CurrentCell.RowIndex;
            if (index < 0) index = 0;


            Barcode_Model row = lstMain[index];
            switch (_type)
            {
                case VoucherType.送货单:
                    parameter.PRDVERSION = row.PRDVERSION;
                    parameter.SUPNAME = row.SUPNAME;
                    parameter.SUPCODE = row.SUPCODE;
                    break;

                case VoucherType.生产订单:
                    parameter.INNERPACKQTY = parameter.OUTPACKQTY;
                    parameter.BPlatedGold = parameter.BPlatedSilver = parameter.BPlatedTin = parameter.BPlatedOther = false;
                    parameter.AndalaNo = txtInnerPackQty.Text;
                    parameter.PRDVERSION = txtSupCode.Text;
                    break;

                case VoucherType.生产退料:
                    parameter.INNERPACKQTY = parameter.OUTPACKQTY;
                    parameter.BPlatedGold = parameter.BPlatedSilver = parameter.BPlatedTin = parameter.BPlatedOther = false;
                    parameter.Department = txtInnerPackQty.Text;
                    if (!string.IsNullOrEmpty(txtSupCode.Text))
                    {
                        //if (supplier != null || GetSupplier())
                        //{
                        //    parameter.SUPCODE = supplier.SupplierCode;
                        //    parameter.SUPNAME = supplier.SupplierName;
                        //}
                    }
                    parameter.Reason = row.Reason;
                    parameter.ReserveUser = txtReserveUser.Text;
                    break;

                case VoucherType.无过账快速入:
                case VoucherType.需过账快速入:
                    parameter.PRDVERSION = txtReserveUser.Text;
                    if (!string.IsNullOrEmpty(txtSupName.Text))
                    {
                        //if (supplier != null || GetSupplier())
                        //{
                        //    parameter.SUPCODE = supplier.SupplierCode;
                        //    parameter.SUPNAME = supplier.SupplierName;
                        //}
                    }
                    break;
            }

            parameter.BARCODETYPE = 10;
            parameter.VOUCHERNO = row.VOUCHERNO;
            parameter.WaitDeliveryNum = row.WaitDeliveryNum;
            parameter.CURRENTLYDELIVERYNUM = row.CURRENTLYDELIVERYNUM;
            parameter.ROWNO = row.ROWNO;
            parameter.VOUCHERQTY = row.CURRENTLYDELIVERYNUM;
            parameter.DELIVERYNO = row.DELIVERYNO;
            parameter.VOUCHERTYPE = _type.ToInt32().ToString();
            parameter.ISROHS = row.ISROHS;
            parameter.PLATEDGOLD = parameter.BPlatedGold ? 2 : 1;
            parameter.PLATEDSILVER = parameter.BPlatedSilver ? 2 : 1;
            parameter.PLATEDTIN = parameter.BPlatedTin ? 2 : 1;
            parameter.OTHERS = parameter.BPlatedOther ? 2 : 1;
            parameter.OPERATOR = Common_Var.CurrentUser.UserName;
            parameter.TrackNo = row.TrackNo;
            parameter.ReserveNumber = row.ReserveNumber;
            parameter.ReserveRowNo = row.ReserveRowNo;
            parameter.SHOWSUP = parameter.BSHOWSUP ? 2 : 1;

            if (string.IsNullOrEmpty(parameter.CUSNAME))
            {
                parameter.CUSNAME = "京信通信";
            }

        }

        //private bool GetSupplier()
        //{
        //    string strError = string.Empty;
        //    supplier = new Supplier_Model();

        //    if (_type == VoucherType.无过账快速入 || _type == VoucherType.需过账快速入)
        //    {
        //        supplier.SupplierCode = txtSupName.Text.Trim();
        //    }
        //    else
        //    {
        //        supplier.SupplierCode = txtSupCode.Text.Trim();
        //    }

        //    //if (string.IsNullOrEmpty(supplier.SupplierCode))
        //    //{
        //    //    MessageBox.Show("找不到供应商代码对应的供应商信息");
        //    //    supplier = null;
        //    //    return false;
        //    //}

        //    if (!Print_Func.GetSupplierInfoForSAP(ref supplier, ref strError))
        //    {
        //        MessageBox.Show(string.Format("供应商信息获取错误!{0}", strError));
        //        supplier = null;
        //        return false;
        //    }

        //    if (supplier == null || string.IsNullOrEmpty(supplier.SupplierCode))
        //    {
        //        MessageBox.Show("供应商信息获取错误");
        //        supplier = null;
        //        return false;
        //    }

        //    return true;
        //}

        private void SetSearchBtn()
        {
            Common.Common_Func.SetSearchBtn(this, txtVoucherNo, btnSearch, tsmiSearch);
        }

        #endregion
    }
}
