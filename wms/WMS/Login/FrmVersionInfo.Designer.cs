namespace WMS.Login
{
    partial class FrmVersionInfo
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCreateTime = new ChensControl.ChensLabel();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.lblCreater = new ChensControl.ChensLabel();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.txtVersionDesc = new ChensControl.ChensTextBox();
            this.lblAppVersion = new ChensControl.ChensLabel();
            this.lblVersionTitle = new ChensControl.ChensLabel();
            this.btnCancel = new ChensControl.ChensButton();
            this.btnUpdate = new ChensControl.ChensButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.lblAppVersion);
            this.splitContainer1.Panel1.Controls.Add(this.lblVersionTitle);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnUpdate);
            this.splitContainer1.Size = new System.Drawing.Size(992, 469);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCreateTime);
            this.groupBox1.Controls.Add(this.lblCreater);
            this.groupBox1.Controls.Add(this.chensLabel4);
            this.groupBox1.Controls.Add(this.chensLabel3);
            this.groupBox1.Controls.Add(this.txtVersionDesc);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(992, 337);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "版本说明";
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "CreateTime", true));
            this.lblCreateTime.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblCreateTime.Location = new System.Drawing.Point(842, 310);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(0, 17);
            this.lblCreateTime.TabIndex = 4;
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(WMS.WebService.AppVersionInfo);
            // 
            // lblCreater
            // 
            this.lblCreater.AutoSize = true;
            this.lblCreater.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "Creater", true));
            this.lblCreater.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblCreater.Location = new System.Drawing.Point(650, 310);
            this.lblCreater.Name = "lblCreater";
            this.lblCreater.Size = new System.Drawing.Size(0, 17);
            this.lblCreater.TabIndex = 3;
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(780, 310);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(56, 17);
            this.chensLabel4.TabIndex = 2;
            this.chensLabel4.Text = "更新时间";
            // 
            // chensLabel3
            // 
            this.chensLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(600, 310);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(44, 17);
            this.chensLabel3.TabIndex = 1;
            this.chensLabel3.Text = "更新人";
            // 
            // txtVersionDesc
            // 
            this.txtVersionDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVersionDesc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtVersionDesc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtVersionDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVersionDesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "VersionDesc", true));
            this.txtVersionDesc.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtVersionDesc.HotTrack = false;
            this.txtVersionDesc.Location = new System.Drawing.Point(96, 19);
            this.txtVersionDesc.Multiline = true;
            this.txtVersionDesc.Name = "txtVersionDesc";
            this.txtVersionDesc.ReadOnly = true;
            this.txtVersionDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtVersionDesc.Size = new System.Drawing.Size(800, 280);
            this.txtVersionDesc.TabIndex = 0;
            this.txtVersionDesc.TextEnabled = false;
            // 
            // lblAppVersion
            // 
            this.lblAppVersion.AutoSize = true;
            this.lblAppVersion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "AppVersion", true));
            this.lblAppVersion.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblAppVersion.Location = new System.Drawing.Point(567, 40);
            this.lblAppVersion.Name = "lblAppVersion";
            this.lblAppVersion.Size = new System.Drawing.Size(45, 17);
            this.lblAppVersion.TabIndex = 1;
            this.lblAppVersion.Text = "1.0.0.0";
            // 
            // lblVersionTitle
            // 
            this.lblVersionTitle.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "VersionTitle", true));
            this.lblVersionTitle.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.lblVersionTitle.Location = new System.Drawing.Point(346, 10);
            this.lblVersionTitle.Name = "lblVersionTitle";
            this.lblVersionTitle.Size = new System.Drawing.Size(300, 23);
            this.lblVersionTitle.TabIndex = 0;
            this.lblVersionTitle.Text = "版本名";
            this.lblVersionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(440, 17);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(440, 17);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(115, 30);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // FrmVersionInfo
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(992, 469);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.Name = "FrmVersionInfo";
            this.Text = "版本更新";
            this.Load += new System.EventHandler(this.FrmVersionInfo_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ChensControl.ChensButton btnUpdate;
        private ChensControl.ChensButton btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private ChensControl.ChensLabel lblCreateTime;
        private ChensControl.ChensLabel lblCreater;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensTextBox txtVersionDesc;
        private ChensControl.ChensLabel lblAppVersion;
        private ChensControl.ChensLabel lblVersionTitle;
        private System.Windows.Forms.BindingSource bsMain;
    }
}