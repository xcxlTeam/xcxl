namespace WMS.Print
{
    partial class Form15
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInvert = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.dgvMomOrder = new System.Windows.Forms.DataGridView();
            this.colbIsAllot = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMoCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chensMenuStrip1 = new ChensControl.ChensMenuStrip();
            this.锁定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.解锁ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMomOrder)).BeginInit();
            this.chensMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Location = new System.Drawing.Point(0, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 411);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "生产订单选择";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(6, 20);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblCount);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnInvert);
            this.splitContainer1.Panel1.Controls.Add(this.btnAll);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvMomOrder);
            this.splitContainer1.Size = new System.Drawing.Size(251, 387);
            this.splitContainer1.SplitterDistance = 30;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(45, 8);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(29, 17);
            this.lblCount.TabIndex = 2;
            this.lblCount.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "订单数:";
            // 
            // btnInvert
            // 
            this.btnInvert.Location = new System.Drawing.Point(173, 3);
            this.btnInvert.Name = "btnInvert";
            this.btnInvert.Size = new System.Drawing.Size(75, 23);
            this.btnInvert.TabIndex = 0;
            this.btnInvert.Text = "反选";
            this.btnInvert.UseVisualStyleBackColor = true;
            this.btnInvert.Visible = false;
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(92, 3);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 0;
            this.btnAll.Text = "全选";
            this.btnAll.UseVisualStyleBackColor = true;
            // 
            // dgvMomOrder
            // 
            this.dgvMomOrder.AllowUserToAddRows = false;
            this.dgvMomOrder.AllowUserToDeleteRows = false;
            this.dgvMomOrder.AllowUserToResizeRows = false;
            this.dgvMomOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMomOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colbIsAllot,
            this.colMoCode,
            this.colInvCode,
            this.colInvName});
            this.dgvMomOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMomOrder.Location = new System.Drawing.Point(0, 0);
            this.dgvMomOrder.Name = "dgvMomOrder";
            this.dgvMomOrder.RowHeadersVisible = false;
            this.dgvMomOrder.RowTemplate.Height = 23;
            this.dgvMomOrder.Size = new System.Drawing.Size(251, 353);
            this.dgvMomOrder.TabIndex = 1;
            // 
            // colbIsAllot
            // 
            this.colbIsAllot.DataPropertyName = "bIsAllot";
            this.colbIsAllot.HeaderText = "选择";
            this.colbIsAllot.Name = "colbIsAllot";
            this.colbIsAllot.Width = 40;
            // 
            // colMoCode
            // 
            this.colMoCode.DataPropertyName = "MoCode";
            this.colMoCode.HeaderText = "生产订单号";
            this.colMoCode.Name = "colMoCode";
            this.colMoCode.ReadOnly = true;
            // 
            // colInvCode
            // 
            this.colInvCode.DataPropertyName = "InvCode";
            this.colInvCode.HeaderText = "产品编号";
            this.colInvCode.Name = "colInvCode";
            this.colInvCode.ReadOnly = true;
            // 
            // colInvName
            // 
            this.colInvName.DataPropertyName = "InvName";
            this.colInvName.HeaderText = "产品名称";
            this.colInvName.Name = "colInvName";
            this.colInvName.ReadOnly = true;
            // 
            // chensMenuStrip1
            // 
            this.chensMenuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chensMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.锁定ToolStripMenuItem,
            this.解锁ToolStripMenuItem});
            this.chensMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.chensMenuStrip1.Name = "chensMenuStrip1";
            this.chensMenuStrip1.Size = new System.Drawing.Size(992, 25);
            this.chensMenuStrip1.TabIndex = 2;
            this.chensMenuStrip1.Text = "chensMenuStrip1";
            // 
            // 锁定ToolStripMenuItem
            // 
            this.锁定ToolStripMenuItem.Name = "锁定ToolStripMenuItem";
            this.锁定ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.锁定ToolStripMenuItem.Text = "锁定";
            // 
            // 解锁ToolStripMenuItem
            // 
            this.解锁ToolStripMenuItem.Name = "解锁ToolStripMenuItem";
            this.解锁ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.解锁ToolStripMenuItem.Text = "解锁";
            // 
            // Form15
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 772);
            this.Controls.Add(this.chensMenuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form15";
            this.Text = "Form15";
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMomOrder)).EndInit();
            this.chensMenuStrip1.ResumeLayout(false);
            this.chensMenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInvert;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.DataGridView dgvMomOrder;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colbIsAllot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvName;
        private ChensControl.ChensMenuStrip chensMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 锁定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 解锁ToolStripMenuItem;
    }
}