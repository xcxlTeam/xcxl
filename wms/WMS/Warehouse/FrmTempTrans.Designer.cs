namespace WMS.Warehouse
{
    partial class FrmTempTrans
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtQueryWhereSoCode = new ChensControl.ChensTextBox();
            this.chensLabel15 = new ChensControl.ChensLabel();
            this.txtCustomer = new ChensControl.ChensTextBox();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtDetailQty = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.42408F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.57591F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.88556F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.11444F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(976, 733);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtQueryWhereSoCode);
            this.groupBox1.Controls.Add(this.chensLabel15);
            this.groupBox1.Controls.Add(this.txtCustomer);
            this.groupBox1.Controls.Add(this.chensLabel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 183);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询销售发票";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(3, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(268, 29);
            this.button1.TabIndex = 29;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtQueryWhereSoCode
            // 
            this.txtQueryWhereSoCode.BackColor = System.Drawing.Color.White;
            this.txtQueryWhereSoCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtQueryWhereSoCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQueryWhereSoCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtQueryWhereSoCode.Enabled = false;
            this.txtQueryWhereSoCode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtQueryWhereSoCode.HotTrack = false;
            this.txtQueryWhereSoCode.Location = new System.Drawing.Point(3, 74);
            this.txtQueryWhereSoCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQueryWhereSoCode.Name = "txtQueryWhereSoCode";
            this.txtQueryWhereSoCode.Size = new System.Drawing.Size(268, 23);
            this.txtQueryWhereSoCode.TabIndex = 28;
            this.txtQueryWhereSoCode.TextEnabled = false;
            // 
            // chensLabel15
            // 
            this.chensLabel15.AutoSize = true;
            this.chensLabel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.chensLabel15.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel15.Location = new System.Drawing.Point(3, 57);
            this.chensLabel15.Name = "chensLabel15";
            this.chensLabel15.Size = new System.Drawing.Size(68, 17);
            this.chensLabel15.TabIndex = 27;
            this.chensLabel15.Text = "销售发票号";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.White;
            this.txtCustomer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCustomer.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtCustomer.HotTrack = false;
            this.txtCustomer.Location = new System.Drawing.Point(3, 34);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(268, 23);
            this.txtCustomer.TabIndex = 25;
            this.txtCustomer.TextEnabled = false;
            this.txtCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomer_KeyPress);
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(3, 17);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(56, 17);
            this.chensLabel1.TabIndex = 24;
            this.chensLabel1.Text = "客户名称";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(283, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(666, 183);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(283, 192);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(666, 538);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.Click += new System.EventHandler(this.dataGridView2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txtDetailQty);
            this.groupBox2.Controls.Add(this.chensLabel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 538);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "表体数据";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.button6.Dock = System.Windows.Forms.DockStyle.Top;
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(3, 173);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(268, 29);
            this.button6.TabIndex = 35;
            this.button6.Text = "查询历史记录";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.Enabled = false;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(3, 144);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(268, 29);
            this.button5.TabIndex = 34;
            this.button5.Text = "弃审";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.Enabled = false;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(3, 115);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(268, 29);
            this.button3.TabIndex = 33;
            this.button3.Text = "审核";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.Enabled = false;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(3, 86);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(268, 29);
            this.button4.TabIndex = 32;
            this.button4.Text = "删除";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Enabled = false;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(3, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(268, 29);
            this.button2.TabIndex = 30;
            this.button2.Text = "保存";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtDetailQty
            // 
            this.txtDetailQty.BackColor = System.Drawing.Color.White;
            this.txtDetailQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtDetailQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetailQty.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDetailQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtDetailQty.HotTrack = false;
            this.txtDetailQty.Location = new System.Drawing.Point(3, 34);
            this.txtDetailQty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDetailQty.Name = "txtDetailQty";
            this.txtDetailQty.Size = new System.Drawing.Size(268, 23);
            this.txtDetailQty.TabIndex = 26;
            this.txtDetailQty.TextEnabled = false;
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(3, 17);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 25;
            this.chensLabel2.Text = "借调数量";
            // 
            // FrmTempTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 733);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmTempTrans";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "借调";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private ChensControl.ChensTextBox txtCustomer;
        private ChensControl.ChensLabel chensLabel1;
        private System.Windows.Forms.Button button1;
        private ChensControl.ChensTextBox txtQueryWhereSoCode;
        private ChensControl.ChensLabel chensLabel15;
        private System.Windows.Forms.GroupBox groupBox2;
        private ChensControl.ChensTextBox txtDetailQty;
        private ChensControl.ChensLabel chensLabel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;

    }
}