namespace WMS.Warehouse
{
    partial class FrmTempTransQuery
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
            this.txtCinvstd = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDsocode = new ChensControl.ChensTextBox();
            this.chensLabel15 = new ChensControl.ChensLabel();
            this.txtSsbvcode = new ChensControl.ChensTextBox();
            this.chensLabel17 = new ChensControl.ChensLabel();
            this.txtDsbvcode = new ChensControl.ChensTextBox();
            this.txtCinvcode = new ChensControl.ChensTextBox();
            this.chensLabel9 = new ChensControl.ChensLabel();
            this.txtSsocode = new ChensControl.ChensTextBox();
            this.lblVoucherNo = new ChensControl.ChensLabel();
            this.gbMiddle = new ChensControl.ChensGroupBox();
            this.chensTextBox2 = new ChensControl.ChensTextBox();
            this.chensLabel10 = new ChensControl.ChensLabel();
            this.chensTextBox3 = new ChensControl.ChensTextBox();
            this.chensLabel13 = new ChensControl.ChensLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gbHeader.SuspendLayout();
            this.gbMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbHeader
            // 
            this.gbHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbHeader.Controls.Add(this.txtCinvstd);
            this.gbHeader.Controls.Add(this.chensLabel2);
            this.gbHeader.Controls.Add(this.chensLabel1);
            this.gbHeader.Controls.Add(this.button1);
            this.gbHeader.Controls.Add(this.txtDsocode);
            this.gbHeader.Controls.Add(this.chensLabel15);
            this.gbHeader.Controls.Add(this.txtSsbvcode);
            this.gbHeader.Controls.Add(this.chensLabel17);
            this.gbHeader.Controls.Add(this.txtDsbvcode);
            this.gbHeader.Controls.Add(this.txtCinvcode);
            this.gbHeader.Controls.Add(this.chensLabel9);
            this.gbHeader.Controls.Add(this.txtSsocode);
            this.gbHeader.Controls.Add(this.lblVoucherNo);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbHeader.Location = new System.Drawing.Point(0, 0);
            this.gbHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbHeader.Size = new System.Drawing.Size(976, 120);
            this.gbHeader.TabIndex = 7;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "查询条件";
            // 
            // txtCinvstd
            // 
            this.txtCinvstd.BackColor = System.Drawing.Color.White;
            this.txtCinvstd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtCinvstd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCinvstd.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtCinvstd.HotTrack = false;
            this.txtCinvstd.Location = new System.Drawing.Point(630, 58);
            this.txtCinvstd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCinvstd.Name = "txtCinvstd";
            this.txtCinvstd.Size = new System.Drawing.Size(150, 23);
            this.txtCinvstd.TabIndex = 25;
            this.txtCinvstd.TextEnabled = false;
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(553, 60);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 24;
            this.chensLabel2.Text = "规格型号";
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(284, 60);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(92, 17);
            this.chensLabel1.TabIndex = 23;
            this.chensLabel1.Text = "被借销售发票号";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(812, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 29);
            this.button1.TabIndex = 22;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDsocode
            // 
            this.txtDsocode.BackColor = System.Drawing.Color.White;
            this.txtDsocode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtDsocode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDsocode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDsocode.HotTrack = false;
            this.txtDsocode.Location = new System.Drawing.Point(382, 23);
            this.txtDsocode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDsocode.Name = "txtDsocode";
            this.txtDsocode.Size = new System.Drawing.Size(150, 23);
            this.txtDsocode.TabIndex = 16;
            this.txtDsocode.TextEnabled = false;
            // 
            // chensLabel15
            // 
            this.chensLabel15.AutoSize = true;
            this.chensLabel15.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel15.Location = new System.Drawing.Point(284, 25);
            this.chensLabel15.Name = "chensLabel15";
            this.chensLabel15.Size = new System.Drawing.Size(92, 17);
            this.chensLabel15.TabIndex = 15;
            this.chensLabel15.Text = "被借销售订单号";
            // 
            // txtSsbvcode
            // 
            this.txtSsbvcode.BackColor = System.Drawing.Color.White;
            this.txtSsbvcode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSsbvcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSsbvcode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSsbvcode.HotTrack = false;
            this.txtSsbvcode.Location = new System.Drawing.Point(102, 54);
            this.txtSsbvcode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSsbvcode.Name = "txtSsbvcode";
            this.txtSsbvcode.Size = new System.Drawing.Size(150, 23);
            this.txtSsbvcode.TabIndex = 12;
            this.txtSsbvcode.TextEnabled = false;
            // 
            // chensLabel17
            // 
            this.chensLabel17.AutoSize = true;
            this.chensLabel17.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel17.Location = new System.Drawing.Point(25, 56);
            this.chensLabel17.Name = "chensLabel17";
            this.chensLabel17.Size = new System.Drawing.Size(68, 17);
            this.chensLabel17.TabIndex = 11;
            this.chensLabel17.Text = "销售发票号";
            // 
            // txtDsbvcode
            // 
            this.txtDsbvcode.BackColor = System.Drawing.Color.White;
            this.txtDsbvcode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtDsbvcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDsbvcode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDsbvcode.HotTrack = false;
            this.txtDsbvcode.Location = new System.Drawing.Point(382, 56);
            this.txtDsbvcode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDsbvcode.Name = "txtDsbvcode";
            this.txtDsbvcode.Size = new System.Drawing.Size(150, 23);
            this.txtDsbvcode.TabIndex = 8;
            this.txtDsbvcode.TextEnabled = false;
            // 
            // txtCinvcode
            // 
            this.txtCinvcode.BackColor = System.Drawing.Color.White;
            this.txtCinvcode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtCinvcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCinvcode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtCinvcode.HotTrack = false;
            this.txtCinvcode.Location = new System.Drawing.Point(630, 23);
            this.txtCinvcode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCinvcode.Name = "txtCinvcode";
            this.txtCinvcode.Size = new System.Drawing.Size(150, 23);
            this.txtCinvcode.TabIndex = 6;
            this.txtCinvcode.TextEnabled = false;
            // 
            // chensLabel9
            // 
            this.chensLabel9.AutoSize = true;
            this.chensLabel9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel9.Location = new System.Drawing.Point(553, 25);
            this.chensLabel9.Name = "chensLabel9";
            this.chensLabel9.Size = new System.Drawing.Size(56, 17);
            this.chensLabel9.TabIndex = 5;
            this.chensLabel9.Text = "物料编号";
            // 
            // txtSsocode
            // 
            this.txtSsocode.BackColor = System.Drawing.Color.White;
            this.txtSsocode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSsocode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSsocode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtSsocode.HotTrack = false;
            this.txtSsocode.Location = new System.Drawing.Point(102, 23);
            this.txtSsocode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSsocode.Name = "txtSsocode";
            this.txtSsocode.Size = new System.Drawing.Size(150, 23);
            this.txtSsocode.TabIndex = 1;
            this.txtSsocode.TextEnabled = false;
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblVoucherNo.Location = new System.Drawing.Point(25, 25);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(68, 17);
            this.lblVoucherNo.TabIndex = 0;
            this.lblVoucherNo.Text = "销售订单号";
            // 
            // gbMiddle
            // 
            this.gbMiddle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbMiddle.Controls.Add(this.dataGridView1);
            this.gbMiddle.Controls.Add(this.chensTextBox2);
            this.gbMiddle.Controls.Add(this.chensLabel10);
            this.gbMiddle.Controls.Add(this.chensTextBox3);
            this.gbMiddle.Controls.Add(this.chensLabel13);
            this.gbMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMiddle.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbMiddle.Location = new System.Drawing.Point(0, 120);
            this.gbMiddle.Name = "gbMiddle";
            this.gbMiddle.Size = new System.Drawing.Size(976, 614);
            this.gbMiddle.TabIndex = 10;
            this.gbMiddle.TabStop = false;
            this.gbMiddle.Text = "查询结果";
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
            // chensTextBox3
            // 
            this.chensTextBox3.BackColor = System.Drawing.Color.White;
            this.chensTextBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chensTextBox3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensTextBox3.HotTrack = false;
            this.chensTextBox3.Location = new System.Drawing.Point(580, -85);
            this.chensTextBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chensTextBox3.Name = "chensTextBox3";
            this.chensTextBox3.Size = new System.Drawing.Size(150, 23);
            this.chensTextBox3.TabIndex = 8;
            this.chensTextBox3.TextEnabled = false;
            // 
            // chensLabel13
            // 
            this.chensLabel13.AutoSize = true;
            this.chensLabel13.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel13.Location = new System.Drawing.Point(503, -83);
            this.chensLabel13.Name = "chensLabel13";
            this.chensLabel13.Size = new System.Drawing.Size(68, 17);
            this.chensLabel13.TabIndex = 7;
            this.chensLabel13.Text = "生产订单号";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(970, 592);
            this.dataGridView1.TabIndex = 11;
            // 
            // FrmTempTransQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 734);
            this.Controls.Add(this.gbMiddle);
            this.Controls.Add(this.gbHeader);
            this.Name = "FrmTempTransQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "借调查询";
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.gbMiddle.ResumeLayout(false);
            this.gbMiddle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ChensControl.ChensGroupBox gbHeader;
        private ChensControl.ChensTextBox txtCinvstd;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensLabel chensLabel1;
        private System.Windows.Forms.Button button1;
        private ChensControl.ChensTextBox txtDsocode;
        private ChensControl.ChensLabel chensLabel15;
        private ChensControl.ChensTextBox txtSsbvcode;
        private ChensControl.ChensLabel chensLabel17;
        private ChensControl.ChensTextBox txtDsbvcode;
        private ChensControl.ChensTextBox txtCinvcode;
        private ChensControl.ChensLabel chensLabel9;
        private ChensControl.ChensTextBox txtSsocode;
        private ChensControl.ChensLabel lblVoucherNo;
        private ChensControl.ChensGroupBox gbMiddle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ChensControl.ChensTextBox chensTextBox2;
        private ChensControl.ChensLabel chensLabel10;
        private ChensControl.ChensTextBox chensTextBox3;
        private ChensControl.ChensLabel chensLabel13;
    }
}