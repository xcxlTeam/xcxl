using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS.Print
{
    public partial class FrmPrinterSet : Common.FrmBaseDialog
    {
        public FrmPrinterSet()
        {
            InitializeComponent();
        }

        private void FrmPrinterSet_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void tsmiCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #region Function

        private void InitForm()
        {
            BindPrinter();
        }

        private void BindPrinter()
        {
            txtInnerPrinter.Text = Print_Var.InnerPrinter;
            txtOutPrinter.Text = Print_Var.OutboxPrinter;

            nudInnerPrinter.Value = Print_Var.InnerPrintNum;
            nudOutPrinter.Value = Print_Var.OutboxPrintNum;

            Common.Common_Func.BindComboBox(Print_Func.GetPrinterDPI(), cbbInnerDPI);
            cbbInnerDPI.SelectedValue = Print_Var.InnerDPI;

            Common.Common_Func.BindComboBox(Print_Func.GetPrinterDPI(), cbbOutDPI);
            cbbOutDPI.SelectedValue = Print_Var.OutboxDPI;

        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtInnerPrinter.Text.Trim()))
                return Common.Common_Func.ErrorMessage(lblInnerPrinter.Text + "不能为空!", "保存失败");

            if (string.IsNullOrEmpty(txtOutPrinter.Text.Trim()))
                return Common.Common_Func.ErrorMessage(lblOutPrinter.Text + "不能为空!", "保存失败");

            return true;
        }

        private bool SaveData()
        {
            if (!CheckInput()) return false;

            string innerprinter = txtInnerPrinter.Text.Trim();
            string outboxprinter = txtOutPrinter.Text.Trim();

            int innerdpi = Convert.ToInt32(cbbInnerDPI.SelectedValue);
            int outboxdpi = Convert.ToInt32(cbbOutDPI.SelectedValue);

            int innerprintnum = Convert.ToInt32(nudInnerPrinter.Value);
            int outboxprintnum = Convert.ToInt32(nudOutPrinter.Value);

            Common.OperXml.SetValuse("InnerPrinter", innerprinter);
            Common.OperXml.SetValuse("OutboxPrinter", outboxprinter);

            Common.OperXml.SetValuse("InnerDPI", innerdpi.ToString());
            Common.OperXml.SetValuse("OutboxDPI", outboxdpi.ToString());

            Common.OperXml.SetValuse("InnerPrintNum", innerprintnum.ToString());
            Common.OperXml.SetValuse("OutboxPrintNum", outboxprintnum.ToString());

            Print_Var.InnerPrinter = innerprinter;
            Print_Var.OutboxPrinter = outboxprinter;

            Print_Var.InnerDPI = innerdpi;
            Print_Var.OutboxDPI = outboxdpi;

            Print_Var.InnerPrintNum = innerprintnum;
            Print_Var.OutboxPrintNum = outboxprintnum;

            return true;
        }

        #endregion

    }
}
