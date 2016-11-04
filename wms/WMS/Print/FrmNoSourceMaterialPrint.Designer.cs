namespace WMS.Print
{
    partial class FrmNoSourceMaterialPrint
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
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.采购原料标签打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtpBatchNo = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEndPackQty = new System.Windows.Forms.TextBox();
            this.txtCurrentSum = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtcinvstd = new ChensControl.ChensTextBox();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.txtCount = new ChensControl.ChensTextBox();
            this.lblReserveUser = new ChensControl.ChensLabel();
            this.txtPrintQty = new ChensControl.ChensTextBox();
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.txtPackQty = new ChensControl.ChensTextBox();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.txtMaterialDesc = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.txtMaterialNo = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtWhereAreaNo = new ChensControl.ChensTextBox();
            this.txtWhereHouseNo = new ChensControl.ChensTextBox();
            this.txtWhereWarehouseNo = new ChensControl.ChensTextBox();
            this.chensLabel8 = new ChensControl.ChensLabel();
            this.chensLabel9 = new ChensControl.ChensLabel();
            this.chensLabel12 = new ChensControl.ChensLabel();
            this.txtSupName = new ChensControl.ChensTextBox();
            this.lblSupName = new ChensControl.ChensLabel();
            this.txtSupCode = new ChensControl.ChensTextBox();
            this.lblSupCode = new ChensControl.ChensLabel();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSearch,
            this.tsmiPrint});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.msMain.Size = new System.Drawing.Size(976, 27);
            this.msMain.TabIndex = 5;
            this.msMain.Text = "chensMenuStrip1";
            // 
            // tsmiSearch
            // 
            this.tsmiSearch.Name = "tsmiSearch";
            this.tsmiSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.tsmiSearch.Size = new System.Drawing.Size(68, 21);
            this.tsmiSearch.Text = "查询订单";
            this.tsmiSearch.Visible = false;
            // 
            // tsmiPrint
            // 
            this.tsmiPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.采购原料标签打印ToolStripMenuItem});
            this.tsmiPrint.Name = "tsmiPrint";
            this.tsmiPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.tsmiPrint.Size = new System.Drawing.Size(68, 21);
            this.tsmiPrint.Text = "标签打印";
            // 
            // 采购原料标签打印ToolStripMenuItem
            // 
            this.采购原料标签打印ToolStripMenuItem.Name = "采购原料标签打印ToolStripMenuItem";
            this.采购原料标签打印ToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.采购原料标签打印ToolStripMenuItem.Text = "7*7采购原料标签打印";
            this.采购原料标签打印ToolStripMenuItem.Click += new System.EventHandler(this.采购原料标签打印ToolStripMenuItem_Click);
            // 
            // dtpBatchNo
            // 
            this.dtpBatchNo.Location = new System.Drawing.Point(370, 79);
            this.dtpBatchNo.Name = "dtpBatchNo";
            this.dtpBatchNo.Size = new System.Drawing.Size(138, 21);
            this.dtpBatchNo.TabIndex = 63;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(276, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 62;
            this.label10.Text = "尾箱包装量";
            // 
            // txtEndPackQty
            // 
            this.txtEndPackQty.Location = new System.Drawing.Point(371, 153);
            this.txtEndPackQty.Name = "txtEndPackQty";
            this.txtEndPackQty.Size = new System.Drawing.Size(138, 21);
            this.txtEndPackQty.TabIndex = 61;
            this.txtEndPackQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEndPackQty_KeyPress);
            // 
            // txtCurrentSum
            // 
            this.txtCurrentSum.Location = new System.Drawing.Point(120, 117);
            this.txtCurrentSum.Name = "txtCurrentSum";
            this.txtCurrentSum.Size = new System.Drawing.Size(150, 21);
            this.txtCurrentSum.TabIndex = 60;
            this.txtCurrentSum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurrentSum_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 59;
            this.label11.Text = "本批数量";
            // 
            // txtcinvstd
            // 
            this.txtcinvstd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtcinvstd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcinvstd.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtcinvstd.HotTrack = false;
            this.txtcinvstd.Location = new System.Drawing.Point(119, 79);
            this.txtcinvstd.Name = "txtcinvstd";
            this.txtcinvstd.Size = new System.Drawing.Size(150, 23);
            this.txtcinvstd.TabIndex = 57;
            this.txtcinvstd.TextEnabled = false;
            this.txtcinvstd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcinvstd_KeyPress);
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(21, 82);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(56, 17);
            this.chensLabel1.TabIndex = 58;
            this.chensLabel1.Text = "规格型号";
            // 
            // txtCount
            // 
            this.txtCount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCount.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtCount.HotTrack = false;
            this.txtCount.Location = new System.Drawing.Point(120, 189);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(150, 23);
            this.txtCount.TabIndex = 56;
            this.txtCount.TextEnabled = false;
            this.txtCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCount_KeyPress);
            // 
            // lblReserveUser
            // 
            this.lblReserveUser.AutoSize = true;
            this.lblReserveUser.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblReserveUser.Location = new System.Drawing.Point(22, 192);
            this.lblReserveUser.Name = "lblReserveUser";
            this.lblReserveUser.Size = new System.Drawing.Size(32, 17);
            this.lblReserveUser.TabIndex = 55;
            this.lblReserveUser.Text = "箱数";
            // 
            // txtPrintQty
            // 
            this.txtPrintQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtPrintQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrintQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPrintQty.HotTrack = false;
            this.txtPrintQty.Location = new System.Drawing.Point(371, 189);
            this.txtPrintQty.Name = "txtPrintQty";
            this.txtPrintQty.Size = new System.Drawing.Size(138, 23);
            this.txtPrintQty.TabIndex = 52;
            this.txtPrintQty.TextEnabled = false;
            // 
            // chensLabel7
            // 
            this.chensLabel7.AutoSize = true;
            this.chensLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel7.Location = new System.Drawing.Point(276, 192);
            this.chensLabel7.Name = "chensLabel7";
            this.chensLabel7.Size = new System.Drawing.Size(56, 17);
            this.chensLabel7.TabIndex = 51;
            this.chensLabel7.Text = "打印份数";
            // 
            // txtPackQty
            // 
            this.txtPackQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtPackQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPackQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPackQty.HotTrack = false;
            this.txtPackQty.Location = new System.Drawing.Point(120, 153);
            this.txtPackQty.Name = "txtPackQty";
            this.txtPackQty.Size = new System.Drawing.Size(150, 23);
            this.txtPackQty.TabIndex = 47;
            this.txtPackQty.TextEnabled = false;
            this.txtPackQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPackQty_KeyPress);
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(22, 156);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(44, 17);
            this.chensLabel6.TabIndex = 48;
            this.chensLabel6.Text = "包装量";
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(275, 82);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(56, 17);
            this.chensLabel4.TabIndex = 46;
            this.chensLabel4.Text = "生产批号";
            // 
            // txtMaterialDesc
            // 
            this.txtMaterialDesc.BackColor = System.Drawing.Color.White;
            this.txtMaterialDesc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialDesc.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialDesc.HotTrack = false;
            this.txtMaterialDesc.Location = new System.Drawing.Point(370, 43);
            this.txtMaterialDesc.Name = "txtMaterialDesc";
            this.txtMaterialDesc.Size = new System.Drawing.Size(138, 23);
            this.txtMaterialDesc.TabIndex = 44;
            this.txtMaterialDesc.TextEnabled = false;
            this.txtMaterialDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaterialDesc_KeyPress);
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(275, 46);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 45;
            this.chensLabel3.Text = "物料描述";
            // 
            // txtMaterialNo
            // 
            this.txtMaterialNo.BackColor = System.Drawing.Color.White;
            this.txtMaterialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialNo.HotTrack = false;
            this.txtMaterialNo.Location = new System.Drawing.Point(119, 43);
            this.txtMaterialNo.Name = "txtMaterialNo";
            this.txtMaterialNo.Size = new System.Drawing.Size(150, 23);
            this.txtMaterialNo.TabIndex = 43;
            this.txtMaterialNo.TextEnabled = false;
            this.txtMaterialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaterialNo_KeyPress);
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(21, 46);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 42;
            this.chensLabel2.Text = "物料编号";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(442, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 29);
            this.button1.TabIndex = 64;
            this.button1.Text = "重置";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(24, 233);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 65;
            this.checkBox1.Text = "是否在库";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtWhereAreaNo
            // 
            this.txtWhereAreaNo.BackColor = System.Drawing.Color.White;
            this.txtWhereAreaNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtWhereAreaNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWhereAreaNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtWhereAreaNo.HotTrack = false;
            this.txtWhereAreaNo.Location = new System.Drawing.Point(121, 302);
            this.txtWhereAreaNo.Name = "txtWhereAreaNo";
            this.txtWhereAreaNo.Size = new System.Drawing.Size(150, 23);
            this.txtWhereAreaNo.TabIndex = 71;
            this.txtWhereAreaNo.TextEnabled = false;
            // 
            // txtWhereHouseNo
            // 
            this.txtWhereHouseNo.BackColor = System.Drawing.Color.White;
            this.txtWhereHouseNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtWhereHouseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWhereHouseNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtWhereHouseNo.HotTrack = false;
            this.txtWhereHouseNo.Location = new System.Drawing.Point(373, 262);
            this.txtWhereHouseNo.Name = "txtWhereHouseNo";
            this.txtWhereHouseNo.Size = new System.Drawing.Size(136, 23);
            this.txtWhereHouseNo.TabIndex = 70;
            this.txtWhereHouseNo.TextEnabled = false;
            // 
            // txtWhereWarehouseNo
            // 
            this.txtWhereWarehouseNo.BackColor = System.Drawing.Color.White;
            this.txtWhereWarehouseNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtWhereWarehouseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWhereWarehouseNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtWhereWarehouseNo.HotTrack = false;
            this.txtWhereWarehouseNo.Location = new System.Drawing.Point(121, 262);
            this.txtWhereWarehouseNo.Name = "txtWhereWarehouseNo";
            this.txtWhereWarehouseNo.Size = new System.Drawing.Size(150, 23);
            this.txtWhereWarehouseNo.TabIndex = 69;
            this.txtWhereWarehouseNo.TextEnabled = false;
            // 
            // chensLabel8
            // 
            this.chensLabel8.AutoSize = true;
            this.chensLabel8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel8.Location = new System.Drawing.Point(22, 305);
            this.chensLabel8.Name = "chensLabel8";
            this.chensLabel8.Size = new System.Drawing.Size(56, 17);
            this.chensLabel8.TabIndex = 68;
            this.chensLabel8.Text = "库存货位";
            // 
            // chensLabel9
            // 
            this.chensLabel9.AutoSize = true;
            this.chensLabel9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel9.Location = new System.Drawing.Point(275, 264);
            this.chensLabel9.Name = "chensLabel9";
            this.chensLabel9.Size = new System.Drawing.Size(56, 17);
            this.chensLabel9.TabIndex = 67;
            this.chensLabel9.Text = "库存库区";
            // 
            // chensLabel12
            // 
            this.chensLabel12.AutoSize = true;
            this.chensLabel12.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel12.Location = new System.Drawing.Point(22, 264);
            this.chensLabel12.Name = "chensLabel12";
            this.chensLabel12.Size = new System.Drawing.Size(56, 17);
            this.chensLabel12.TabIndex = 66;
            this.chensLabel12.Text = "库存仓库";
            // 
            // txtSupName
            // 
            this.txtSupName.BackColor = System.Drawing.Color.White;
            this.txtSupName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSupName.HotTrack = false;
            this.txtSupName.Location = new System.Drawing.Point(370, 344);
            this.txtSupName.Name = "txtSupName";
            this.txtSupName.ReadOnly = true;
            this.txtSupName.Size = new System.Drawing.Size(138, 23);
            this.txtSupName.TabIndex = 73;
            this.txtSupName.TextEnabled = false;
            // 
            // lblSupName
            // 
            this.lblSupName.AutoSize = true;
            this.lblSupName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblSupName.Location = new System.Drawing.Point(275, 347);
            this.lblSupName.Name = "lblSupName";
            this.lblSupName.Size = new System.Drawing.Size(68, 17);
            this.lblSupName.TabIndex = 75;
            this.lblSupName.Text = "供应商名称";
            // 
            // txtSupCode
            // 
            this.txtSupCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupCode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSupCode.HotTrack = false;
            this.txtSupCode.Location = new System.Drawing.Point(119, 344);
            this.txtSupCode.Name = "txtSupCode";
            this.txtSupCode.Size = new System.Drawing.Size(150, 23);
            this.txtSupCode.TabIndex = 72;
            this.txtSupCode.TextEnabled = false;
            this.txtSupCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSupCode_KeyPress);
            // 
            // lblSupCode
            // 
            this.lblSupCode.AutoSize = true;
            this.lblSupCode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblSupCode.Location = new System.Drawing.Point(21, 347);
            this.lblSupCode.Name = "lblSupCode";
            this.lblSupCode.Size = new System.Drawing.Size(68, 17);
            this.lblSupCode.TabIndex = 74;
            this.lblSupCode.Text = "供应商代码";
            // 
            // FrmNoSourceMaterialPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 413);
            this.Controls.Add(this.txtSupName);
            this.Controls.Add(this.lblSupName);
            this.Controls.Add(this.txtSupCode);
            this.Controls.Add(this.lblSupCode);
            this.Controls.Add(this.txtWhereAreaNo);
            this.Controls.Add(this.txtWhereHouseNo);
            this.Controls.Add(this.txtWhereWarehouseNo);
            this.Controls.Add(this.chensLabel8);
            this.Controls.Add(this.chensLabel9);
            this.Controls.Add(this.chensLabel12);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtpBatchNo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtEndPackQty);
            this.Controls.Add(this.txtCurrentSum);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtcinvstd);
            this.Controls.Add(this.chensLabel1);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.lblReserveUser);
            this.Controls.Add(this.txtPrintQty);
            this.Controls.Add(this.chensLabel7);
            this.Controls.Add(this.txtPackQty);
            this.Controls.Add(this.chensLabel6);
            this.Controls.Add(this.chensLabel4);
            this.Controls.Add(this.txtMaterialDesc);
            this.Controls.Add(this.chensLabel3);
            this.Controls.Add(this.txtMaterialNo);
            this.Controls.Add(this.chensLabel2);
            this.Controls.Add(this.msMain);
            this.Name = "FrmNoSourceMaterialPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "无来源原料标签打印";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint;
        private System.Windows.Forms.ToolStripMenuItem 采购原料标签打印ToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dtpBatchNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEndPackQty;
        private System.Windows.Forms.TextBox txtCurrentSum;
        private System.Windows.Forms.Label label11;
        private ChensControl.ChensTextBox txtcinvstd;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensTextBox txtCount;
        private ChensControl.ChensLabel lblReserveUser;
        private ChensControl.ChensTextBox txtPrintQty;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensTextBox txtPackQty;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensTextBox txtMaterialDesc;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensTextBox txtMaterialNo;
        private ChensControl.ChensLabel chensLabel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private ChensControl.ChensTextBox txtWhereAreaNo;
        private ChensControl.ChensTextBox txtWhereHouseNo;
        private ChensControl.ChensTextBox txtWhereWarehouseNo;
        private ChensControl.ChensLabel chensLabel8;
        private ChensControl.ChensLabel chensLabel9;
        private ChensControl.ChensLabel chensLabel12;
        private ChensControl.ChensTextBox txtSupName;
        private ChensControl.ChensLabel lblSupName;
        private ChensControl.ChensTextBox txtSupCode;
        private ChensControl.ChensLabel lblSupCode;
    }
}