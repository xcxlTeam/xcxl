namespace WMS.Login
{
    partial class FrmChangePwd
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
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.chensTabControl1 = new ChensControl.ChensTabControl();
            this.tpBasic = new System.Windows.Forms.TabPage();
            this.txtUserNo = new ChensControl.ChensTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chensLabel9 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.txtUserName = new ChensControl.ChensTextBox();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.txtRePassword = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.txtPassword = new ChensControl.ChensTextBox();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.msMain.SuspendLayout();
            this.chensTabControl1.SuspendLayout();
            this.tpBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSave,
            this.tsmiCancel});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(500, 25);
            this.msMain.TabIndex = 4;
            this.msMain.Text = "chensMenuStrip1";
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSave.Size = new System.Drawing.Size(44, 21);
            this.tsmiSave.Text = "保存";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiCancel
            // 
            this.tsmiCancel.Name = "tsmiCancel";
            this.tsmiCancel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.tsmiCancel.Size = new System.Drawing.Size(44, 21);
            this.tsmiCancel.Text = "关闭";
            this.tsmiCancel.Click += new System.EventHandler(this.tsmiCancel_Click);
            // 
            // chensTabControl1
            // 
            this.chensTabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.chensTabControl1.Controls.Add(this.tpBasic);
            this.chensTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chensTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.chensTabControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.chensTabControl1.Location = new System.Drawing.Point(0, 25);
            this.chensTabControl1.Name = "chensTabControl1";
            this.chensTabControl1.SelectedIndex = 0;
            this.chensTabControl1.Size = new System.Drawing.Size(500, 275);
            this.chensTabControl1.TabIndex = 5;
            this.chensTabControl1.TabStop = false;
            // 
            // tpBasic
            // 
            this.tpBasic.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpBasic.Controls.Add(this.label1);
            this.tpBasic.Controls.Add(this.txtRePassword);
            this.tpBasic.Controls.Add(this.chensLabel4);
            this.tpBasic.Controls.Add(this.txtPassword);
            this.tpBasic.Controls.Add(this.chensLabel5);
            this.tpBasic.Controls.Add(this.chensLabel3);
            this.tpBasic.Controls.Add(this.txtUserName);
            this.tpBasic.Controls.Add(this.chensLabel2);
            this.tpBasic.Controls.Add(this.txtUserNo);
            this.tpBasic.Controls.Add(this.label4);
            this.tpBasic.Controls.Add(this.chensLabel9);
            this.tpBasic.Controls.Add(this.chensLabel1);
            this.tpBasic.Location = new System.Drawing.Point(4, 29);
            this.tpBasic.Name = "tpBasic";
            this.tpBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tpBasic.Size = new System.Drawing.Size(492, 242);
            this.tpBasic.TabIndex = 0;
            this.tpBasic.Text = "修改密码";
            // 
            // txtUserNo
            // 
            this.txtUserNo.BackColor = System.Drawing.Color.White;
            this.txtUserNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtUserNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "UserNo", true));
            this.txtUserNo.Enabled = false;
            this.txtUserNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtUserNo.HotTrack = false;
            this.txtUserNo.Location = new System.Drawing.Point(127, 43);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.Size = new System.Drawing.Size(300, 23);
            this.txtUserNo.TabIndex = 1;
            this.txtUserNo.TextEnabled = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(429, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 17);
            this.label4.TabIndex = 132;
            this.label4.Text = "*";
            // 
            // chensLabel9
            // 
            this.chensLabel9.AutoSize = true;
            this.chensLabel9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel9.Location = new System.Drawing.Point(65, 45);
            this.chensLabel9.Name = "chensLabel9";
            this.chensLabel9.Size = new System.Drawing.Size(56, 17);
            this.chensLabel9.TabIndex = 3;
            this.chensLabel9.Text = "用户编号";
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.BackColor = System.Drawing.Color.DarkOrange;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(25, 15);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(56, 17);
            this.chensLabel1.TabIndex = 1;
            this.chensLabel1.Text = "用户信息";
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(65, 85);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 133;
            this.chensLabel2.Text = "用户名称";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.White;
            this.txtUserName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "UserName", true));
            this.txtUserName.Enabled = false;
            this.txtUserName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtUserName.HotTrack = false;
            this.txtUserName.Location = new System.Drawing.Point(127, 83);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(300, 23);
            this.txtUserName.TabIndex = 2;
            this.txtUserName.TextEnabled = false;
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(WMS.WebService.UserInfo);
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.BackColor = System.Drawing.Color.DarkOrange;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(25, 125);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(56, 17);
            this.chensLabel3.TabIndex = 135;
            this.chensLabel3.Text = "修改密码";
            // 
            // txtRePassword
            // 
            this.txtRePassword.BackColor = System.Drawing.Color.White;
            this.txtRePassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtRePassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRePassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "RePassword", true));
            this.txtRePassword.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtRePassword.HotTrack = false;
            this.txtRePassword.Location = new System.Drawing.Point(127, 193);
            this.txtRePassword.Name = "txtRePassword";
            this.txtRePassword.PasswordChar = '●';
            this.txtRePassword.Size = new System.Drawing.Size(300, 23);
            this.txtRePassword.TabIndex = 4;
            this.txtRePassword.TextEnabled = false;
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(65, 195);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(56, 17);
            this.chensLabel4.TabIndex = 138;
            this.chensLabel4.Text = "确认密码";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "Password", true));
            this.txtPassword.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPassword.HotTrack = false;
            this.txtPassword.Location = new System.Drawing.Point(127, 153);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(300, 23);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TextEnabled = false;
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(65, 155);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(44, 17);
            this.chensLabel5.TabIndex = 137;
            this.chensLabel5.Text = "新密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(429, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 17);
            this.label1.TabIndex = 140;
            this.label1.Text = "*";
            // 
            // FrmChangePwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.chensTabControl1);
            this.Controls.Add(this.msMain);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmChangePwd";
            this.Text = "修改密码";
            this.Load += new System.EventHandler(this.FrmChangePwd_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.chensTabControl1.ResumeLayout(false);
            this.tpBasic.ResumeLayout(false);
            this.tpBasic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancel;
        private ChensControl.ChensTabControl chensTabControl1;
        private System.Windows.Forms.TabPage tpBasic;
        private ChensControl.ChensTextBox txtUserNo;
        private System.Windows.Forms.Label label4;
        private ChensControl.ChensLabel chensLabel9;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensTextBox txtUserName;
        private ChensControl.ChensLabel chensLabel2;
        private System.Windows.Forms.BindingSource bsMain;
        private ChensControl.ChensLabel chensLabel3;
        private System.Windows.Forms.Label label1;
        private ChensControl.ChensTextBox txtRePassword;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensTextBox txtPassword;
        private ChensControl.ChensLabel chensLabel5;

    }
}