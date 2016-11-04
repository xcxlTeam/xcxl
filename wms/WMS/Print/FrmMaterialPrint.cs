using WMS.Common;
using WMS.WebService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS.Print
{
    public partial class FrmMaterialPrint : Common.FrmBasic
    {
        //private Supplier_Model supplier;
        private Barcode_Model parameter;
        private List<Barcode_Model> lstBarcode;

        public FrmMaterialPrint()
        {
            InitializeComponent();
        }

        private void FrmMaterialPrint_Load(object sender, EventArgs e)
        {
            InitForm();
           if (!Print_Func.CheckPrinter()) return;
        }

        private void tsmiImport_Click(object sender, EventArgs e)
        {

        }

        private void tsmiPrint_Click(object sender, EventArgs e)
        {
            PrintLabel();
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

        private void txtMaterialNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    this.Cursor = Cursors.WaitCursor;

                    GetMaterialInfo();
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

        private void btnGetMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                GetMaterialInfo();
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

        #region Function

        private void InitForm()
        {
            ClearForm();
        }

        private void ClearForm()
        {
            lstBarcode = new List<Barcode_Model>();
            parameter = new Barcode_Model();
            bsCreate.DataSource = parameter;

            txtMaterialNo.Enabled = true;
            btnGetMaterial.Enabled = true;
            txtMaterialDesc.Enabled = false;
            txtBatchNo.Enabled = false;
            txtSupCode.Enabled = false;
            txtSupName.Enabled = false;
            txtOutPackQty.Enabled = false;
            cbxPlatedSilver.Enabled = false;
            cbxPlatedTin.Enabled = false;
            cbxOther.Enabled = false;
            txtPrintQty.Enabled = false;
            tsmiPrint.Enabled = false;

            bsCreate.ResetBindings(false);
            bsCreate.EndEdit();
        }

        private bool GetMaterialInfo()
        {
            TempMaterialInfo material = new TempMaterialInfo();
            material.MaterialNo = txtMaterialNo.Text.Trim();
            string strError = string.Empty;
            if (Print_Func.GetMaterialInfo(ref material, 3, ref strError))
            {
                parameter.MATERIALNO = material.MaterialNo;
                parameter.MATERIALDESC = material.MaterialDesc;
                parameter.Unit = material.Unit;
                parameter.ISROHS = material.IsRohs;

                txtMaterialNo.Enabled = false;
                btnGetMaterial.Enabled = false;
                txtBatchNo.Enabled = true;
                txtSupCode.Enabled = true;
                txtSupName.Enabled = true;
                txtOutPackQty.Enabled = true;
                cbxPlatedSilver.Enabled = true;
                cbxPlatedTin.Enabled = true;
                cbxOther.Enabled = true;
                txtPrintQty.Enabled = true;
                tsmiPrint.Enabled = true;

                txtBatchNo.Focus();
                txtBatchNo.SelectAll();
                return true;
            }
            else
            {
                txtMaterialNo.Focus();
                txtMaterialNo.SelectAll();

                return false;
            }
        }

        private void PrintLabel()
        {
            if (!Print_Func.CheckPrinter(false)) return;

            if (CreateBarcode())
            {
                PrintBarcode();

                ClearForm();
            }
        }

        private bool CreateBarcode()
        {
            bsCreate.EndEdit();

            bool bResult = false;
            string strError = string.Empty;
            //GetCreatePara();

            if (!CheckCreate()) return false;

            bResult = Print_Func.SaveOutBarcode(ref parameter, ref strError);
            bsCreate.DataSource = parameter;

            if (!bResult || !string.IsNullOrEmpty(strError)) return Common.Common_Func.ErrorMessage(strError, "生成失败");
            if (parameter == null || parameter.ID <= 0) return Common.Common_Func.ErrorMessage("未获取到任何数据", "生成失败");

            lstBarcode = new List<Barcode_Model>();
            lstBarcode.Add(parameter);
            return true;
        }

        //private void GetCreatePara()
        //{
        //    if (parameter == null) parameter = new Barcode_Model();

        //    parameter.BARCODETYPE = 10;
        //    parameter.VOUCHERNO = null;
        //    parameter.WaitDeliveryNum = 0;
        //    parameter.CURRENTLYDELIVERYNUM = parameter.BATCHQTY;
        //    parameter.ROWNO = null;
        //    parameter.VOUCHERQTY = parameter.BATCHQTY;
        //    parameter.DELIVERYNO = null;
        //    parameter.PRDVERSION = null;
        //    parameter.CUSNAME = "京信通信";
        //    parameter.VOUCHERTYPE = "0";
        //    parameter.PLATEDGOLD = parameter.BPlatedGold ? 2 : 1;
        //    parameter.PLATEDSILVER = parameter.BPlatedSilver ? 2 : 1;
        //    parameter.PLATEDTIN = parameter.BPlatedTin ? 2 : 1;
        //    parameter.OTHERS = parameter.BPlatedOther ? 2 : 1;
        //    parameter.OPERATOR = Common_Var.CurrentUser.UserName;

        //    parameter.VOUCHERQTY = parameter.BATCHQTY = parameter.INNERPACKQTY = parameter.OUTPACKQTY;
        //    parameter.INNERCOUNT = parameter.OUTCOUNT = 1;

        //    if (!string.IsNullOrEmpty(parameter.SUPCODE))
        //    {
        //        string strError = string.Empty;
        //        supplier = new Supplier_Model();
        //        supplier.SupplierCode = parameter.SUPCODE;

        //        if (!Print_Func.GetSupplierInfoForSAP(ref supplier, ref strError))
        //        {
        //            supplier = null;
        //        }
        //        else
        //        {
        //            parameter.SUPNAME = supplier.SupplierName;
        //        }
        //    }
        //}

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

            if (parameter.PRINTQTY <= 0)
            {
                return Common.Common_Func.ErrorMessage("打印份数输入错误!", "生成失败");
            }

            if (parameter.PLATEDSILVER != 2 && parameter.PLATEDTIN != 2 && parameter.OTHERS != 2)
            {
                return Common.Common_Func.ErrorMessage("镀层物料必须选择!", "生成失败");
            }

            return true;
        }

        private void PrintBarcode()
        {
            btnGetMaterial.Focus();

            bool isPrinted = false;

            string strPrintCode = string.Empty;
            int iPrintQty = 0;
            int iPrintCount = 0;
            string strLogo = Print_Func.GetBoxLogoStr(VoucherType.任意单据);
            string strContent = string.Empty;
            string strClear = Print_Func.GetBoxClearStr(VoucherType.任意单据);
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
                Common.Common_Func.ErrorMessage("生成物料标签错误", "打印失败");
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

                ClearForm();
            }
        }

        private bool PrintRow(Barcode_Model barcode, int iPrintQty, ref string sPrintCode)
        {
            string strOnce = Print_Func.GetBoxContentStr(VoucherType.任意单据, barcode);
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

        #endregion
    }
}
