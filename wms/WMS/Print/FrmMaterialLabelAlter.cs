using WMS.Common;
using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WMS.Print
{
    public partial class FrmMaterialLabelAlter : Common.FrmBasic
    {
        private VoucherType _type;
        private Barcode_Model parameter;
        private List<Barcode_Model> lstBarcode;

        private DividPage _serverMainPage;
        private Barcode_Model queryMain;
        private List<Barcode_Model> lstMain;

        public FrmMaterialLabelAlter()
        {
            InitializeComponent();
        }

        private void FrmMaterialLabelAlter_Load(object sender, EventArgs e)
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

                AlterPrint();
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

        private void cbbVOUCHERTYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDisplayCol();
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!Common.Common_Func.CheckDgvClick(dgvList, e.RowIndex)) return;

                SetCreateInfo();
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

        private void pageList_ChensPageChange(object sender, EventArgs e)
        {
            GetListQueryData();
        }

        private void cbxNPlatedSilver_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                parameter.BPlatedGold = false;
                parameter.BPlatedTin = false;
                parameter.BPlatedOther = false;
            }
        }

        private void cbxNPlatedTin_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                parameter.BPlatedGold = false;
                parameter.BPlatedSilver = false;
                parameter.BPlatedOther = false;
            }
        }
    
        private void cbxNOther_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                parameter.BPlatedGold = false;
                parameter.BPlatedSilver = false;
                parameter.BPlatedTin = false;
            }
        }


        #region Function


        private void InitForm()
        {
            InitMainQuery();

            BindComboboxs();
        }

        private void BindComboboxs()
        {
            Common.Common_Func.BindComboBoxAddAll(Print_Func.GetOrderType(), cbbVoucherType);
        }

        private void InitMainQuery()
        {
            parameter = new Barcode_Model();
            lstBarcode = new List<Barcode_Model>();

            bsCreate.DataSource = parameter;

            _serverMainPage = new DividPage();
            queryMain = new Barcode_Model();
            lstMain = new List<Barcode_Model>();

            pageList.GetShowCountsByDGV(dgvList);
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

            ChensControl.DividPage clientPage = pageList.dDividPage;
            Common.Common_Func.GetServerPageFromClientPage(ref _serverMainPage, clientPage);
            bResult = Print_Func.GetOutBarcodeListByPage(ref lstMain, queryMain, ref _serverMainPage, ref strError);
            Common.Common_Func.GetClientPageFromServerPage(_serverMainPage, ref clientPage);
            pageList.ShowPage();
            dgvList.DataSource = lstMain;

            if (!bResult || !string.IsNullOrEmpty(strError)) Common.Common_Func.ErrorMessage(strError, "查询失败");

            txtVoucherNo.Focus();
        }

        private void GetQueryMain()
        {
            if (queryMain == null) { queryMain = new Barcode_Model(); bsMain.DataSource = queryMain; }
            queryMain.BARCODETYPE = 10;
            queryMain.VOUCHERTYPE = queryMain.iVoucherType >= 1 ? queryMain.iVoucherType.ToString() : string.Empty;
        }

        private void SetDisplayCol()
        {
            _type = (VoucherType)cbbVoucherType.SelectedValue.ToInt32();
        }

        private void SetCreateInfo()
        {
            Barcode_Model row = lstMain[dgvList.CurrentCell.RowIndex];
            if (row == null) return;

            parameter = row;
            parameter.PRINTQTY = 1;

            bsCreate.DataSource = parameter;
            bsCreate.ResetBindings(false);
            bsCreate.EndEdit();

            txtNQty.Focus();
            txtNQty.SelectAll();
        }

        private void AlterPrint()
        {
            if (!Print_Func.CheckPrinter(false)) return;

            if (AlterOutBarcode())
            {
                PrintLabel();
            }
        }

        private bool AlterOutBarcode()
        {
            bsCreate.EndEdit();

            bool bResult = false;
            string strError = string.Empty;

            if (!CheckCreate()) return false;

            bResult = Print_Func.SaveOutBarcode(ref parameter, ref strError);
            bsCreate.DataSource = parameter;

            if (!bResult || !string.IsNullOrEmpty(strError)) return Common.Common_Func.ErrorMessage(strError, "替换失败");
            if (parameter == null || parameter.ID <= 0) return Common.Common_Func.ErrorMessage("未获取到任何数据", "替换失败");

            lstBarcode = new List<Barcode_Model>();
            lstBarcode.Add(parameter);
            return true;
        }

        private bool CheckCreate()
        {
            if (string.IsNullOrEmpty(parameter.BATCHNO))
            {
                return Common.Common_Func.ErrorMessage("生产批号不能为空!", "替换失败");
            }

            if (parameter.OUTPACKQTY <= 0)
            {
                return Common.Common_Func.ErrorMessage("外箱包装量输入错误!", "替换失败");
            }

            if (parameter.QTY <= 0)
            {
                return Common.Common_Func.ErrorMessage("实际数量输入错误!", "替换失败");
            }

            if (parameter.QTY > parameter.OUTPACKQTY)
            {
                return Common.Common_Func.ErrorMessage("实际数量不能大于外箱包装量!", "替换失败");
            }

            if (parameter.PRINTQTY <= 0)
            {
                return Common.Common_Func.ErrorMessage("打印份数输入错误!", "替换失败");
            }

            if (parameter.PLATEDSILVER != 2 && parameter.PLATEDTIN != 2 && parameter.OTHERS != 2)
            {
                return Common.Common_Func.ErrorMessage("镀层物料必须选择!", "替换失败");
            }

            return true;
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
                    if (!string.IsNullOrEmpty(strPrintCode))
                    {
                        Print_Func.SendStringToPrinter(strPrintCode);
                    }

                    strPrintCode = string.Empty;
                }

                if (!PrintRow(barcode, iPrintQty, ref strPrintCode)) continue;

                iPrintCount += iPrintQty;

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

                //GetListQueryData();
            }
        }


        private bool PrintRow(Barcode_Model barcode, int iPrintQty, ref string sPrintCode)
        {
            VoucherType type = (VoucherType)barcode.VOUCHERTYPE.ToInt32();
            string strLogo = Print_Func.GetBoxLogoStr(type);
            string strClear = Print_Func.GetBoxClearStr(type);
            string strOnce = Print_Func.GetBoxContentStr(type, barcode);
            if (string.IsNullOrEmpty(strOnce))
            {
                return Common.Common_Func.ErrorMessage("外箱标签 " + barcode.SERIALNO + " 打印失败", "打印失败");
            }


            string strContent = string.Empty;
            for (int i = 1; i <= iPrintQty; i++)
            {
                strContent += strOnce;
            }

            sPrintCode += strLogo;
            sPrintCode += strContent;
            sPrintCode += strClear;
            return true;
        }

        private void SetSearchBtn()
        {
            Common_Func.SetSearchBtn(this, txtVoucherNo, btnSearch, tsmiSearch);
        }

        #endregion

    }
}
