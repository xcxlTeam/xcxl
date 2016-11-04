using WMS.Common;
using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WMS.Print
{
    public partial class FrmInnerBarcodePrint : Common.FrmBasic
    {
        //private Supplier_Model supplier;
        private VoucherType _type;
        private Barcode_Model parameter;
        private List<Barcode_Model> lstBarcode;

        private DividPage _serverMainPage;
        private Barcode_Model queryMain;
        private List<Barcode_Model> lstMain;

        public FrmInnerBarcodePrint()
        {
            InitializeComponent();

            Common.Common_Func.DelDataGridViewSortable(dgvList);

            _type = VoucherType.任意单据;
        }
        public FrmInnerBarcodePrint(string type)
        {
            InitializeComponent();

            Common.Common_Func.DelDataGridViewSortable(dgvList);

            _type = (VoucherType)type.ToInt32();

            SetForm();
        }

        private void FrmInnerBarcodePrint_Load(object sender, EventArgs e)
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
        private void txtSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    this.Cursor = Cursors.WaitCursor;

                    //if (GetSupplier())
                    //{
                    //    BindList();
                    //}
                    //else
                    //{
                    //    txtSupplier.Focus();
                    //    txtSupplier.SelectAll();
                    //}
                }
                else if (e.KeyChar == (char)Keys.Back)
                {
                    if (string.IsNullOrEmpty(txtSupplier.Text))
                    {
                        //supplier = null;
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


        #region Function

        private void SetForm()
        {
            switch (_type)
            {
                case VoucherType.送货单:
                    this.Text = "送货单内盒标签打印";
                    lblVoucherNo.Text = "送货单号";
                    colHVoucherNo.HeaderText = "采购订单号";
                    break;

                case VoucherType.生产订单:
                    this.Text = "生产订单内盒标签打印";
                    lblVoucherNo.Text = "生产订单";
                    colHVoucherNo.HeaderText = "生产订单号";
                    colHCurrentlyDeliveryNum.HeaderText = "订单数量";

                    colHVoucherNo.Visible = false;
                    colHDeliveryNo.Visible = false;
                    colHSupCode.Visible = false;
                    colHRowNo.Visible = false;

                    lblInnerPackQty.Visible = false;
                    txtInnerPackQty.Visible = false;
                    break;

                case VoucherType.采购订单:
                    this.Text = "采购订单内盒标签打印";
                    lblVoucherNo.Text = "采购订单";
                    colHCurrentlyDeliveryNum.HeaderText = "订单数量";

                    colHVoucherNo.Visible = false;
                    colHDeliveryNo.Visible = false;
                    colHRowNo.Visible = false;
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
            //supplier = null;
            parameter = new Barcode_Model() { PRINTQTY = 1 };
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

            //if (supplier == null)
            //{
            //    if (!GetSupplier()) return;
            //}

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

            //queryMain.Supplier = supplier.SupplierCode;
        }

        private void RePrint()
        {
            using (FrmOutBarcodeRePrint frm = new FrmOutBarcodeRePrint())
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
                parameter.BATCHQTY = 0;
                parameter.OUTPACKQTY = 0;
                parameter.INNERPACKQTY = 0;
                parameter.BPlatedSilver = false;
                parameter.BPlatedTin = false;
                parameter.BPlatedOther = false;
                parameter.BSHOWSUP = false;
                parameter.PRINTQTY = 1;

                //txtMaterialNo.Text = "";
                //txtMaterialDesc.Text = "";
                //txtBatchNo.Text = "";
                //txtOutPackQty.Text = "0";
                //txtInnerPackQty.Text = "0";
                //cbxPlatedSilver.Checked = false;
                //cbxPlatedTin.Checked = false;
                //cbxOther.Checked = false;
                //txtPrintQty.Text = "2";
            }
            else
            {
                parameter = new Barcode_Model();
                parameter.BARCODETYPE = 20;
                parameter.VOUCHERNO = lstMain[iRowIndex].VOUCHERNO;
                parameter.WaitDeliveryNum = lstMain[iRowIndex].WaitDeliveryNum;
                parameter.ROWNO = lstMain[iRowIndex].ROWNO;
                parameter.VOUCHERQTY = lstMain[iRowIndex].CURRENTLYDELIVERYNUM;
                parameter.BATCHQTY = lstMain[iRowIndex].CURRENTLYDELIVERYNUM;
                parameter.DELIVERYNO = lstMain[iRowIndex].DELIVERYNO;
                parameter.PRDVERSION = lstMain[iRowIndex].PRDVERSION;
                parameter.CUSNAME = "京信通信";
                parameter.SUPNAME = lstMain[iRowIndex].SUPNAME;
                parameter.SUPCODE = lstMain[iRowIndex].SUPCODE;
                parameter.VOUCHERTYPE = _type.ToInt32().ToString();
                parameter.ISROHS = lstMain[iRowIndex].ISROHS;
                parameter.PLATEDGOLD = parameter.BPlatedGold ? 2 : 1;
                parameter.PLATEDSILVER = parameter.BPlatedSilver ? 2 : 1;
                parameter.PLATEDTIN = parameter.BPlatedTin ? 2 : 1;
                parameter.OTHERS = parameter.BPlatedOther ? 2 : 1;
                parameter.OPERATOR = Common_Var.CurrentUser.UserName;
                parameter.MATERIALNO = lstMain[iRowIndex].MATERIALNO;
                parameter.MATERIALDESC = lstMain[iRowIndex].MATERIALDESC;
                parameter.BATCHNO = "";//DateTime.Now.ToString("yyyyMMdd");
                parameter.OUTPACKQTY = 0;
                parameter.INNERPACKQTY = 0;
                parameter.BPlatedSilver = false;
                parameter.BPlatedTin = false;
                parameter.BPlatedOther = false;
                parameter.BSHOWSUP = false;
                parameter.PRINTQTY = 1;

                //txtMaterialNo.Text = lstMain[iRowIndex].MATERIALNO; ;
                //txtMaterialDesc.Text = lstMain[iRowIndex].MATERIALDESC; ;
                //txtBatchNo.Text = DateTime.Now.ToString("yyyyMMdd");
                //txtOutPackQty.Text = lstMain[iRowIndex].WaitDeliveryNum.ToString();
                //txtInnerPackQty.Text = lstMain[iRowIndex].WaitDeliveryNum.ToString();
                //cbxPlatedSilver.Checked = false;
                //cbxPlatedTin.Checked = false;
                //cbxOther.Checked = false;
                //txtPrintQty.Text = "2";
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
                return Common.Common_Func.ErrorMessage("生产批号不能为空!", "生成失败");
            }

            if (parameter.OUTPACKQTY <= 0)
            {
                return Common.Common_Func.ErrorMessage("外箱包装量输入错误!", "生成失败");
            }

            if (parameter.INNERPACKQTY <= 0)
            {
                return Common.Common_Func.ErrorMessage("内盒包装量输入错误!", "生成失败");
            }

            if (parameter.PRINTQTY <= 0)
            {
                return Common.Common_Func.ErrorMessage("打印份数输入错误!", "生成失败");
            }

            if (parameter.INNERPACKQTY > parameter.BATCHQTY)
            {
                return Common.Common_Func.ErrorMessage(string.Format("内盒包装数量【{0}】不能大于本批次数量【{1}】!", parameter.INNERPACKQTY, parameter.BATCHQTY));
            }

            if (parameter.BATCHQTY > parameter.VOUCHERQTY)
            {
                return Common.Common_Func.ErrorMessage(string.Format("本批次数量【{0}】不能大于单据行数量【{1}】!", parameter.BATCHQTY, parameter.VOUCHERQTY));
            }

            if (parameter.PLATEDSILVER != 2 && parameter.PLATEDTIN != 2 && parameter.OTHERS != 2)
            {
                return Common.Common_Func.ErrorMessage("镀层物料必须选择!", "生成失败");
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
            int index = dgvList.CurrentCell.RowIndex;
            if (index < 0) index = 0;

            Barcode_Model row = lstMain[index];
            parameter.BARCODETYPE = 20;
            parameter.VOUCHERNO = row.VOUCHERNO;
            parameter.WaitDeliveryNum = row.WaitDeliveryNum;
            parameter.CURRENTLYDELIVERYNUM = row.CURRENTLYDELIVERYNUM;
            parameter.ROWNO = row.ROWNO;
            parameter.VOUCHERQTY = row.CURRENTLYDELIVERYNUM;
            parameter.DELIVERYNO = row.DELIVERYNO;
            parameter.PRDVERSION = row.PRDVERSION;
            parameter.CUSNAME = "京信通信";
            parameter.SUPNAME = row.SUPNAME;
            parameter.SUPCODE = row.SUPCODE;
            parameter.VOUCHERTYPE = _type.ToInt32().ToString();
            parameter.ISROHS = row.ISROHS;
            parameter.PLATEDGOLD = parameter.BPlatedGold ? 2 : 1;
            parameter.PLATEDSILVER = parameter.BPlatedSilver ? 2 : 1;
            parameter.PLATEDTIN = parameter.BPlatedTin ? 2 : 1;
            parameter.OTHERS = parameter.BPlatedOther ? 2 : 1;
            parameter.OPERATOR = Common_Var.CurrentUser.UserName;
            parameter.TrackNo = null;
            parameter.ReserveNumber = null;
            parameter.ReserveRowNo = null;
            parameter.SHOWSUP = parameter.BSHOWSUP ? 2 : 1;

            parameter.OUTPACKQTY = parameter.INNERPACKQTY;
        }

        //private bool GetSupplier()
        //{
        //    string strError = string.Empty;
        //    supplier = new Supplier_Model();
        //    supplier.SupplierCode = txtSupplier.Text.Trim();


        //    if (string.IsNullOrEmpty(supplier.SupplierCode))
        //    {
        //        MessageBox.Show("供应商代码不能为空");
        //        supplier = null;
        //        return false;
        //    }

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
