namespace WMS.Query
{
    partial class FrmBarcodeTrace
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
            this.gbMiddle = new ChensControl.ChensGroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chensTextBox2 = new ChensControl.ChensTextBox();
            this.chensLabel10 = new ChensControl.ChensLabel();
            this.gbBottom = new ChensControl.ChensGroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.chensTextBox4 = new ChensControl.ChensTextBox();
            this.chensLabel17 = new ChensControl.ChensLabel();
            this.gbHeader = new ChensControl.ChensGroupBox();
            this.txtTransMoveCode = new ChensControl.ChensTextBox();
            this.chensLabel11 = new ChensControl.ChensLabel();
            this.txtStockOutCode = new ChensControl.ChensTextBox();
            this.chensLabel9 = new ChensControl.ChensLabel();
            this.txtCusName = new ChensControl.ChensTextBox();
            this.chensLabel8 = new ChensControl.ChensLabel();
            this.txtMaterialStd = new ChensControl.ChensTextBox();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.txtMaterialDesc = new ChensControl.ChensTextBox();
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.txtMaterialNo = new ChensControl.ChensTextBox();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.txtCovenantcode = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.txtvoucherno = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.txtSocode = new ChensControl.ChensTextBox();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.txtBarcode = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.btnSearch = new ChensControl.ChensButton();
            this.gbMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.gbHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMiddle
            // 
            this.gbMiddle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbMiddle.Controls.Add(this.dataGridView1);
            this.gbMiddle.Controls.Add(this.chensTextBox2);
            this.gbMiddle.Controls.Add(this.chensLabel10);
            this.gbMiddle.Controls.Add(this.gbBottom);
            this.gbMiddle.Controls.Add(this.chensTextBox4);
            this.gbMiddle.Controls.Add(this.chensLabel17);
            this.gbMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMiddle.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbMiddle.Location = new System.Drawing.Point(0, 153);
            this.gbMiddle.Name = "gbMiddle";
            this.gbMiddle.Size = new System.Drawing.Size(976, 580);
            this.gbMiddle.TabIndex = 19;
            this.gbMiddle.TabStop = false;
            this.gbMiddle.Text = "查询结果";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(970, 461);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // chensTextBox2
            // 
            this.chensTextBox2.BackColor = System.Drawing.Color.White;
            this.chensTextBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chensTextBox2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensTextBox2.HotTrack = false;
            this.chensTextBox2.Location = new System.Drawing.Point(825, -85);
            this.chensTextBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chensTextBox2.Name = "chensTextBox2";
            this.chensTextBox2.Size = new System.Drawing.Size(150, 23);
            this.chensTextBox2.TabIndex = 10;
            this.chensTextBox2.TextEnabled = false;
            // 
            // chensLabel10
            // 
            this.chensLabel10.AutoSize = true;
            this.chensLabel10.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel10.Location = new System.Drawing.Point(748, -83);
            this.chensLabel10.Name = "chensLabel10";
            this.chensLabel10.Size = new System.Drawing.Size(68, 17);
            this.chensLabel10.TabIndex = 9;
            this.chensLabel10.Text = "生产订单号";
            // 
            // gbBottom
            // 
            this.gbBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbBottom.Controls.Add(this.splitContainer1);
            this.gbBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbBottom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbBottom.Location = new System.Drawing.Point(3, 480);
            this.gbBottom.Name = "gbBottom";
            this.gbBottom.Size = new System.Drawing.Size(970, 97);
            this.gbBottom.TabIndex = 7;
            this.gbBottom.TabStop = false;
            this.gbBottom.Text = "详细数据";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 19);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView2);
            this.splitContainer1.Size = new System.Drawing.Size(964, 75);
            this.splitContainer1.SplitterDistance = 504;
            this.splitContainer1.TabIndex = 12;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(504, 75);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView2_RowPostPaint);
            // 
            // chensTextBox4
            // 
            this.chensTextBox4.BackColor = System.Drawing.Color.White;
            this.chensTextBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chensTextBox4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensTextBox4.HotTrack = false;
            this.chensTextBox4.Location = new System.Drawing.Point(580, -85);
            this.chensTextBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chensTextBox4.Name = "chensTextBox4";
            this.chensTextBox4.Size = new System.Drawing.Size(150, 23);
            this.chensTextBox4.TabIndex = 8;
            this.chensTextBox4.TextEnabled = false;
            // 
            // chensLabel17
            // 
            this.chensLabel17.AutoSize = true;
            this.chensLabel17.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel17.Location = new System.Drawing.Point(503, -83);
            this.chensLabel17.Name = "chensLabel17";
            this.chensLabel17.Size = new System.Drawing.Size(68, 17);
            this.chensLabel17.TabIndex = 7;
            this.chensLabel17.Text = "生产订单号";
            // 
            // gbHeader
            // 
            this.gbHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbHeader.Controls.Add(this.txtTransMoveCode);
            this.gbHeader.Controls.Add(this.chensLabel11);
            this.gbHeader.Controls.Add(this.txtStockOutCode);
            this.gbHeader.Controls.Add(this.chensLabel9);
            this.gbHeader.Controls.Add(this.txtCusName);
            this.gbHeader.Controls.Add(this.chensLabel8);
            this.gbHeader.Controls.Add(this.txtMaterialStd);
            this.gbHeader.Controls.Add(this.chensLabel5);
            this.gbHeader.Controls.Add(this.txtMaterialDesc);
            this.gbHeader.Controls.Add(this.chensLabel7);
            this.gbHeader.Controls.Add(this.txtMaterialNo);
            this.gbHeader.Controls.Add(this.chensLabel6);
            this.gbHeader.Controls.Add(this.txtCovenantcode);
            this.gbHeader.Controls.Add(this.chensLabel3);
            this.gbHeader.Controls.Add(this.txtvoucherno);
            this.gbHeader.Controls.Add(this.chensLabel2);
            this.gbHeader.Controls.Add(this.txtSocode);
            this.gbHeader.Controls.Add(this.chensLabel1);
            this.gbHeader.Controls.Add(this.txtBarcode);
            this.gbHeader.Controls.Add(this.chensLabel4);
            this.gbHeader.Controls.Add(this.btnSearch);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbHeader.Location = new System.Drawing.Point(0, 0);
            this.gbHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Size = new System.Drawing.Size(976, 153);
            this.gbHeader.TabIndex = 18;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "查询条件";
            // 
            // txtTransMoveCode
            // 
            this.txtTransMoveCode.BackColor = System.Drawing.Color.White;
            this.txtTransMoveCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtTransMoveCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransMoveCode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtTransMoveCode.HotTrack = false;
            this.txtTransMoveCode.Location = new System.Drawing.Point(633, 130);
            this.txtTransMoveCode.Name = "txtTransMoveCode";
            this.txtTransMoveCode.Size = new System.Drawing.Size(150, 23);
            this.txtTransMoveCode.TabIndex = 30;
            this.txtTransMoveCode.TextEnabled = false;
            // 
            // chensLabel11
            // 
            this.chensLabel11.AutoSize = true;
            this.chensLabel11.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel11.Location = new System.Drawing.Point(559, 132);
            this.chensLabel11.Name = "chensLabel11";
            this.chensLabel11.Size = new System.Drawing.Size(56, 17);
            this.chensLabel11.TabIndex = 29;
            this.chensLabel11.Text = "调拨单号";
            // 
            // txtStockOutCode
            // 
            this.txtStockOutCode.BackColor = System.Drawing.Color.White;
            this.txtStockOutCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtStockOutCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStockOutCode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtStockOutCode.HotTrack = false;
            this.txtStockOutCode.Location = new System.Drawing.Point(410, 130);
            this.txtStockOutCode.Name = "txtStockOutCode";
            this.txtStockOutCode.Size = new System.Drawing.Size(106, 23);
            this.txtStockOutCode.TabIndex = 28;
            this.txtStockOutCode.TextEnabled = false;
            // 
            // chensLabel9
            // 
            this.chensLabel9.AutoSize = true;
            this.chensLabel9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel9.Location = new System.Drawing.Point(292, 132);
            this.chensLabel9.Name = "chensLabel9";
            this.chensLabel9.Size = new System.Drawing.Size(121, 17);
            this.chensLabel9.TabIndex = 27;
            this.chensLabel9.Text = "发货单号/销售发票号";
            // 
            // txtCusName
            // 
            this.txtCusName.BackColor = System.Drawing.Color.White;
            this.txtCusName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtCusName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCusName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtCusName.HotTrack = false;
            this.txtCusName.Location = new System.Drawing.Point(99, 130);
            this.txtCusName.Name = "txtCusName";
            this.txtCusName.Size = new System.Drawing.Size(150, 23);
            this.txtCusName.TabIndex = 26;
            this.txtCusName.TextEnabled = false;
            // 
            // chensLabel8
            // 
            this.chensLabel8.AutoSize = true;
            this.chensLabel8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel8.Location = new System.Drawing.Point(25, 132);
            this.chensLabel8.Name = "chensLabel8";
            this.chensLabel8.Size = new System.Drawing.Size(56, 17);
            this.chensLabel8.TabIndex = 25;
            this.chensLabel8.Text = "发货客户";
            // 
            // txtMaterialStd
            // 
            this.txtMaterialStd.BackColor = System.Drawing.Color.White;
            this.txtMaterialStd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialStd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialStd.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialStd.HotTrack = false;
            this.txtMaterialStd.Location = new System.Drawing.Point(366, 93);
            this.txtMaterialStd.Name = "txtMaterialStd";
            this.txtMaterialStd.Size = new System.Drawing.Size(150, 23);
            this.txtMaterialStd.TabIndex = 24;
            this.txtMaterialStd.TextEnabled = false;
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(292, 95);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(56, 17);
            this.chensLabel5.TabIndex = 23;
            this.chensLabel5.Text = "规格型号";
            // 
            // txtMaterialDesc
            // 
            this.txtMaterialDesc.BackColor = System.Drawing.Color.White;
            this.txtMaterialDesc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialDesc.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialDesc.HotTrack = false;
            this.txtMaterialDesc.Location = new System.Drawing.Point(99, 93);
            this.txtMaterialDesc.Name = "txtMaterialDesc";
            this.txtMaterialDesc.Size = new System.Drawing.Size(150, 23);
            this.txtMaterialDesc.TabIndex = 22;
            this.txtMaterialDesc.TextEnabled = false;
            // 
            // chensLabel7
            // 
            this.chensLabel7.AutoSize = true;
            this.chensLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel7.Location = new System.Drawing.Point(25, 95);
            this.chensLabel7.Name = "chensLabel7";
            this.chensLabel7.Size = new System.Drawing.Size(56, 17);
            this.chensLabel7.TabIndex = 21;
            this.chensLabel7.Text = "物料名称";
            // 
            // txtMaterialNo
            // 
            this.txtMaterialNo.BackColor = System.Drawing.Color.White;
            this.txtMaterialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialNo.HotTrack = false;
            this.txtMaterialNo.Location = new System.Drawing.Point(633, 93);
            this.txtMaterialNo.Name = "txtMaterialNo";
            this.txtMaterialNo.Size = new System.Drawing.Size(150, 23);
            this.txtMaterialNo.TabIndex = 20;
            this.txtMaterialNo.TextEnabled = false;
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(559, 95);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(56, 17);
            this.chensLabel6.TabIndex = 19;
            this.chensLabel6.Text = "物料编码";
            // 
            // txtCovenantcode
            // 
            this.txtCovenantcode.BackColor = System.Drawing.Color.White;
            this.txtCovenantcode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtCovenantcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCovenantcode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtCovenantcode.HotTrack = false;
            this.txtCovenantcode.Location = new System.Drawing.Point(633, 58);
            this.txtCovenantcode.Name = "txtCovenantcode";
            this.txtCovenantcode.Size = new System.Drawing.Size(150, 23);
            this.txtCovenantcode.TabIndex = 16;
            this.txtCovenantcode.TextEnabled = false;
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(559, 60);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(44, 17);
            this.chensLabel3.TabIndex = 15;
            this.chensLabel3.Text = "合同号";
            // 
            // txtvoucherno
            // 
            this.txtvoucherno.BackColor = System.Drawing.Color.White;
            this.txtvoucherno.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtvoucherno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtvoucherno.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtvoucherno.HotTrack = false;
            this.txtvoucherno.Location = new System.Drawing.Point(99, 58);
            this.txtvoucherno.Name = "txtvoucherno";
            this.txtvoucherno.Size = new System.Drawing.Size(150, 23);
            this.txtvoucherno.TabIndex = 14;
            this.txtvoucherno.TextEnabled = false;
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(25, 60);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(68, 17);
            this.chensLabel2.TabIndex = 13;
            this.chensLabel2.Text = "生产订单号";
            // 
            // txtSocode
            // 
            this.txtSocode.BackColor = System.Drawing.Color.White;
            this.txtSocode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSocode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSocode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSocode.HotTrack = false;
            this.txtSocode.Location = new System.Drawing.Point(366, 58);
            this.txtSocode.Name = "txtSocode";
            this.txtSocode.Size = new System.Drawing.Size(150, 23);
            this.txtSocode.TabIndex = 12;
            this.txtSocode.TextEnabled = false;
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(292, 60);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(68, 17);
            this.chensLabel1.TabIndex = 11;
            this.chensLabel1.Text = "销售订单号";
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.Color.White;
            this.txtBarcode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtBarcode.HotTrack = false;
            this.txtBarcode.Location = new System.Drawing.Point(99, 23);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(150, 23);
            this.txtBarcode.TabIndex = 10;
            this.txtBarcode.TextEnabled = false;
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(25, 25);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(32, 17);
            this.chensLabel4.TabIndex = 9;
            this.chensLabel4.Text = "条码";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(716, 17);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 29);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FrmBarcodeTrace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 733);
            this.Controls.Add(this.gbMiddle);
            this.Controls.Add(this.gbHeader);
            this.Name = "FrmBarcodeTrace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "条码追溯查询";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmBarcodeTrace_FormClosed);
            this.gbMiddle.ResumeLayout(false);
            this.gbMiddle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbBottom.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ChensControl.ChensGroupBox gbHeader;
        private ChensControl.ChensTextBox txtCusName;
        private ChensControl.ChensLabel chensLabel8;
        private ChensControl.ChensTextBox txtMaterialStd;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensTextBox txtMaterialDesc;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensTextBox txtMaterialNo;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensTextBox txtCovenantcode;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensTextBox txtvoucherno;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensTextBox txtSocode;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensTextBox txtBarcode;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensButton btnSearch;
        private ChensControl.ChensGroupBox gbMiddle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ChensControl.ChensTextBox chensTextBox2;
        private ChensControl.ChensLabel chensLabel10;
        private ChensControl.ChensGroupBox gbBottom;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private ChensControl.ChensTextBox chensTextBox4;
        private ChensControl.ChensLabel chensLabel17;
        private ChensControl.ChensTextBox txtTransMoveCode;
        private ChensControl.ChensLabel chensLabel11;
        private ChensControl.ChensTextBox txtStockOutCode;
        private ChensControl.ChensLabel chensLabel9;
    }
}