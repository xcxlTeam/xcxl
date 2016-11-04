namespace WMS.Print
{
    partial class FrmPrintProductLabelReview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.msMain = new ChensControl.ChensMenuStrip();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.txtVoucherNo = new ChensControl.ChensTextBox();
            this.lblVoucherNo = new ChensControl.ChensLabel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ProductLabelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DS_ProductLabel = new WMS.Print.DS_ProductLabel();
            this.txtQty = new ChensControl.ChensTextBox();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.txtSupCode = new ChensControl.ChensTextBox();
            this.lblSupCode = new ChensControl.ChensLabel();
            this.txtcinvstd = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtOrderCode = new ChensControl.ChensTextBox();
            this.chensLabel8 = new ChensControl.ChensLabel();
            this.chkOuter = new System.Windows.Forms.CheckBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductLabelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_ProductLabel)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询ToolStripMenuItem,
            this.tsmiPrint});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.msMain.Size = new System.Drawing.Size(992, 27);
            this.msMain.TabIndex = 6;
            this.msMain.Text = "chensMenuStrip1";
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.查询ToolStripMenuItem.Text = "查询";
            this.查询ToolStripMenuItem.Click += new System.EventHandler(this.查询ToolStripMenuItem_Click);
            // 
            // tsmiPrint
            // 
            this.tsmiPrint.Name = "tsmiPrint";
            this.tsmiPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.tsmiPrint.Size = new System.Drawing.Size(68, 21);
            this.tsmiPrint.Text = "标签打印";
            this.tsmiPrint.Visible = false;
            this.tsmiPrint.Click += new System.EventHandler(this.tsmiPrint_Click);
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.BackColor = System.Drawing.Color.White;
            this.txtVoucherNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtVoucherNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVoucherNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtVoucherNo.HotTrack = false;
            this.txtVoucherNo.Location = new System.Drawing.Point(114, 55);
            this.txtVoucherNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.Size = new System.Drawing.Size(150, 23);
            this.txtVoucherNo.TabIndex = 8;
            this.txtVoucherNo.TextEnabled = false;
            this.txtVoucherNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVoucherNo_KeyPress);
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblVoucherNo.Location = new System.Drawing.Point(37, 58);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(32, 17);
            this.lblVoucherNo.TabIndex = 7;
            this.lblVoucherNo.Text = "条码";
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "JingXinWMS.Print.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(40, 201);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(592, 338);
            this.reportViewer1.TabIndex = 9;
            // 
            // ProductLabelBindingSource
            // 
            this.ProductLabelBindingSource.DataMember = "ProductLabel";
            this.ProductLabelBindingSource.DataSource = this.DS_ProductLabel;
            // 
            // DS_ProductLabel
            // 
            this.DS_ProductLabel.DataSetName = "DS_ProductLabel";
            this.DS_ProductLabel.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.Color.White;
            this.txtQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtQty.HotTrack = false;
            this.txtQty.Location = new System.Drawing.Point(469, 55);
            this.txtQty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(150, 23);
            this.txtQty.TabIndex = 11;
            this.txtQty.TextEnabled = false;
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(354, 58);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(32, 17);
            this.chensLabel1.TabIndex = 10;
            this.chensLabel1.Text = "数量";
            // 
            // txtSupCode
            // 
            this.txtSupCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupCode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSupCode.HotTrack = false;
            this.txtSupCode.Location = new System.Drawing.Point(114, 147);
            this.txtSupCode.Name = "txtSupCode";
            this.txtSupCode.Size = new System.Drawing.Size(150, 23);
            this.txtSupCode.TabIndex = 25;
            this.txtSupCode.TextEnabled = false;
            this.txtSupCode.Visible = false;
            // 
            // lblSupCode
            // 
            this.lblSupCode.AutoSize = true;
            this.lblSupCode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblSupCode.Location = new System.Drawing.Point(37, 150);
            this.lblSupCode.Name = "lblSupCode";
            this.lblSupCode.Size = new System.Drawing.Size(56, 17);
            this.lblSupCode.TabIndex = 26;
            this.lblSupCode.Text = "客户名称";
            this.lblSupCode.Visible = false;
            // 
            // txtcinvstd
            // 
            this.txtcinvstd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtcinvstd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcinvstd.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtcinvstd.HotTrack = false;
            this.txtcinvstd.Location = new System.Drawing.Point(114, 101);
            this.txtcinvstd.Name = "txtcinvstd";
            this.txtcinvstd.Size = new System.Drawing.Size(150, 23);
            this.txtcinvstd.TabIndex = 19;
            this.txtcinvstd.TextEnabled = false;
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(37, 104);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(56, 17);
            this.chensLabel4.TabIndex = 21;
            this.chensLabel4.Text = "规格型号";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(469, 146);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "保存修改";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtOrderCode
            // 
            this.txtOrderCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtOrderCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderCode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtOrderCode.HotTrack = false;
            this.txtOrderCode.Location = new System.Drawing.Point(469, 101);
            this.txtOrderCode.Name = "txtOrderCode";
            this.txtOrderCode.Size = new System.Drawing.Size(150, 23);
            this.txtOrderCode.TabIndex = 31;
            this.txtOrderCode.TextEnabled = false;
            // 
            // chensLabel8
            // 
            this.chensLabel8.AutoSize = true;
            this.chensLabel8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel8.Location = new System.Drawing.Point(354, 103);
            this.chensLabel8.Name = "chensLabel8";
            this.chensLabel8.Size = new System.Drawing.Size(109, 17);
            this.chensLabel8.TabIndex = 30;
            this.chensLabel8.Text = "销售订单号/合同号";
            // 
            // chkOuter
            // 
            this.chkOuter.AutoSize = true;
            this.chkOuter.Location = new System.Drawing.Point(357, 149);
            this.chkOuter.Name = "chkOuter";
            this.chkOuter.Size = new System.Drawing.Size(80, 21);
            this.chkOuter.TabIndex = 32;
            this.chkOuter.Text = "外箱/内盒";
            this.chkOuter.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(557, 146);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 33;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FrmPrintProductLabelReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 772);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.chkOuter);
            this.Controls.Add(this.txtOrderCode);
            this.Controls.Add(this.chensLabel8);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSupCode);
            this.Controls.Add(this.lblSupCode);
            this.Controls.Add(this.txtcinvstd);
            this.Controls.Add(this.chensLabel4);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.chensLabel1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.txtVoucherNo);
            this.Controls.Add(this.lblVoucherNo);
            this.Controls.Add(this.msMain);
            this.Name = "FrmPrintProductLabelReview";
            this.Text = "FrmPrintProductLabelReview";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductLabelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_ProductLabel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint;
        private ChensControl.ChensTextBox txtVoucherNo;
        private ChensControl.ChensLabel lblVoucherNo;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ProductLabelBindingSource;
        private DS_ProductLabel DS_ProductLabel;
        private ChensControl.ChensTextBox txtQty;
        private ChensControl.ChensLabel chensLabel1;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private ChensControl.ChensTextBox txtSupCode;
        private ChensControl.ChensLabel lblSupCode;
        private ChensControl.ChensTextBox txtcinvstd;
        private ChensControl.ChensLabel chensLabel4;
        private System.Windows.Forms.Button btnSave;
        private ChensControl.ChensTextBox txtOrderCode;
        private ChensControl.ChensLabel chensLabel8;
        private System.Windows.Forms.CheckBox chkOuter;
        private System.Windows.Forms.Button btnDelete;
    }
}