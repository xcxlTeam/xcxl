namespace WMS.Query
{
    partial class FrmProductLineQuery
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
            this.gbHeader = new ChensControl.ChensGroupBox();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.txtProductLineNo = new ChensControl.ChensTextBox();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.txtMaterialStd = new ChensControl.ChensTextBox();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.txtMaterialDesc = new ChensControl.ChensTextBox();
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.txtMaterialNo = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.btnSearch = new ChensControl.ChensButton();
            this.gbBottom = new ChensControl.ChensGroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chensButton1 = new ChensControl.ChensButton();
            this.gbHeader.SuspendLayout();
            this.gbBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbHeader
            // 
            this.gbHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbHeader.Controls.Add(this.chensButton1);
            this.gbHeader.Controls.Add(this.dtpEndTime);
            this.gbHeader.Controls.Add(this.dtpStartTime);
            this.gbHeader.Controls.Add(this.txtProductLineNo);
            this.gbHeader.Controls.Add(this.chensLabel5);
            this.gbHeader.Controls.Add(this.txtMaterialStd);
            this.gbHeader.Controls.Add(this.chensLabel1);
            this.gbHeader.Controls.Add(this.txtMaterialDesc);
            this.gbHeader.Controls.Add(this.chensLabel7);
            this.gbHeader.Controls.Add(this.txtMaterialNo);
            this.gbHeader.Controls.Add(this.chensLabel4);
            this.gbHeader.Controls.Add(this.chensLabel3);
            this.gbHeader.Controls.Add(this.chensLabel2);
            this.gbHeader.Controls.Add(this.btnSearch);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbHeader.Location = new System.Drawing.Point(0, 0);
            this.gbHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Size = new System.Drawing.Size(992, 95);
            this.gbHeader.TabIndex = 12;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "查询条件";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(571, 23);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(150, 23);
            this.dtpEndTime.TabIndex = 22;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Location = new System.Drawing.Point(329, 23);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(150, 23);
            this.dtpStartTime.TabIndex = 21;
            // 
            // txtProductLineNo
            // 
            this.txtProductLineNo.BackColor = System.Drawing.Color.White;
            this.txtProductLineNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtProductLineNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductLineNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtProductLineNo.HotTrack = false;
            this.txtProductLineNo.Location = new System.Drawing.Point(87, 23);
            this.txtProductLineNo.Name = "txtProductLineNo";
            this.txtProductLineNo.Size = new System.Drawing.Size(150, 23);
            this.txtProductLineNo.TabIndex = 20;
            this.txtProductLineNo.TextEnabled = false;
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(25, 25);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(32, 17);
            this.chensLabel5.TabIndex = 19;
            this.chensLabel5.Text = "产线";
            // 
            // txtMaterialStd
            // 
            this.txtMaterialStd.BackColor = System.Drawing.Color.White;
            this.txtMaterialStd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialStd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialStd.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialStd.HotTrack = false;
            this.txtMaterialStd.Location = new System.Drawing.Point(329, 58);
            this.txtMaterialStd.Name = "txtMaterialStd";
            this.txtMaterialStd.Size = new System.Drawing.Size(150, 23);
            this.txtMaterialStd.TabIndex = 18;
            this.txtMaterialStd.TextEnabled = false;
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(267, 60);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(56, 17);
            this.chensLabel1.TabIndex = 17;
            this.chensLabel1.Text = "规格型号";
            // 
            // txtMaterialDesc
            // 
            this.txtMaterialDesc.BackColor = System.Drawing.Color.White;
            this.txtMaterialDesc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialDesc.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialDesc.HotTrack = false;
            this.txtMaterialDesc.Location = new System.Drawing.Point(87, 58);
            this.txtMaterialDesc.Name = "txtMaterialDesc";
            this.txtMaterialDesc.Size = new System.Drawing.Size(150, 23);
            this.txtMaterialDesc.TabIndex = 16;
            this.txtMaterialDesc.TextEnabled = false;
            // 
            // chensLabel7
            // 
            this.chensLabel7.AutoSize = true;
            this.chensLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel7.Location = new System.Drawing.Point(25, 60);
            this.chensLabel7.Name = "chensLabel7";
            this.chensLabel7.Size = new System.Drawing.Size(56, 17);
            this.chensLabel7.TabIndex = 15;
            this.chensLabel7.Text = "物料名称";
            // 
            // txtMaterialNo
            // 
            this.txtMaterialNo.BackColor = System.Drawing.Color.White;
            this.txtMaterialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialNo.HotTrack = false;
            this.txtMaterialNo.Location = new System.Drawing.Point(571, 58);
            this.txtMaterialNo.Name = "txtMaterialNo";
            this.txtMaterialNo.Size = new System.Drawing.Size(150, 23);
            this.txtMaterialNo.TabIndex = 10;
            this.txtMaterialNo.TextEnabled = false;
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(509, 60);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(56, 17);
            this.chensLabel4.TabIndex = 9;
            this.chensLabel4.Text = "物料编码";
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(509, 25);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 7;
            this.chensLabel3.Text = "结束日期";
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(267, 25);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 5;
            this.chensLabel2.Text = "开始日期";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(913, 19);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 29);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gbBottom
            // 
            this.gbBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbBottom.Controls.Add(this.dataGridView1);
            this.gbBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBottom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbBottom.Location = new System.Drawing.Point(0, 95);
            this.gbBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBottom.Name = "gbBottom";
            this.gbBottom.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBottom.Size = new System.Drawing.Size(992, 677);
            this.gbBottom.TabIndex = 13;
            this.gbBottom.TabStop = false;
            this.gbBottom.Text = "查询结果";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(986, 653);
            this.dataGridView1.TabIndex = 0;
            // 
            // chensButton1
            // 
            this.chensButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chensButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.chensButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chensButton1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensButton1.ForeColor = System.Drawing.Color.White;
            this.chensButton1.Location = new System.Drawing.Point(913, 56);
            this.chensButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chensButton1.Name = "chensButton1";
            this.chensButton1.Size = new System.Drawing.Size(67, 29);
            this.chensButton1.TabIndex = 23;
            this.chensButton1.Text = "导出";
            this.chensButton1.UseVisualStyleBackColor = false;
            this.chensButton1.Click += new System.EventHandler(this.chensButton1_Click);
            // 
            // FrmProductLineQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 772);
            this.Controls.Add(this.gbBottom);
            this.Controls.Add(this.gbHeader);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmProductLineQuery";
            this.Text = "产线查询";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPrintRecordQuery_FormClosed);
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.gbBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ChensControl.ChensGroupBox gbHeader;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensTextBox txtMaterialNo;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensButton btnSearch;
        private ChensControl.ChensGroupBox gbBottom;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ChensControl.ChensTextBox txtMaterialDesc;
        private ChensControl.ChensTextBox txtMaterialStd;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensTextBox txtProductLineNo;
        private ChensControl.ChensLabel chensLabel5;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private ChensControl.ChensButton chensButton1;
    }
}