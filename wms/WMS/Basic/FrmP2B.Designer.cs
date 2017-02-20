namespace WMS.Basic
{
    partial class FrmP2B
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
            this.bsPreparation = new System.Windows.Forms.BindingSource(this.components);
            this.bsBuilding = new System.Windows.Forms.BindingSource(this.components);
            this.chensButton2 = new ChensControl.ChensButton();
            this.chensButton1 = new ChensControl.ChensButton();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.msMain = new ChensControl.ChensMenuStrip();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.ckLstBoxPreparation = new System.Windows.Forms.CheckedListBox();
            this.lstBoxBuilding = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsPreparation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBuilding)).BeginInit();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // chensButton2
            // 
            this.chensButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.chensButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chensButton2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensButton2.ForeColor = System.Drawing.Color.White;
            this.chensButton2.Location = new System.Drawing.Point(343, 368);
            this.chensButton2.Name = "chensButton2";
            this.chensButton2.Size = new System.Drawing.Size(75, 31);
            this.chensButton2.TabIndex = 8;
            this.chensButton2.Text = "移除";
            this.chensButton2.UseVisualStyleBackColor = false;
            // 
            // chensButton1
            // 
            this.chensButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.chensButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chensButton1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensButton1.ForeColor = System.Drawing.Color.White;
            this.chensButton1.Location = new System.Drawing.Point(248, 368);
            this.chensButton1.Name = "chensButton1";
            this.chensButton1.Size = new System.Drawing.Size(75, 31);
            this.chensButton1.TabIndex = 7;
            this.chensButton1.Text = "添加";
            this.chensButton1.UseVisualStyleBackColor = false;
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(254, 40);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(44, 17);
            this.chensLabel2.TabIndex = 6;
            this.chensLabel2.Text = "制法：";
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(12, 41);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(68, 17);
            this.chensLabel1.TabIndex = 5;
            this.chensLabel1.Text = "建筑编号：";
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关闭ToolStripMenuItem,
            this.关闭ToolStripMenuItem1});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(992, 25);
            this.msMain.TabIndex = 4;
            this.msMain.Text = "chensMenuStrip1";
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.关闭ToolStripMenuItem.Text = "保存并关闭";
            // 
            // 关闭ToolStripMenuItem1
            // 
            this.关闭ToolStripMenuItem1.Name = "关闭ToolStripMenuItem1";
            this.关闭ToolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.关闭ToolStripMenuItem1.Text = "关闭";
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(180, 109);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(32, 33);
            this.btnDown.TabIndex = 3;
            this.btnDown.Text = "↓";
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(180, 70);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(32, 33);
            this.btnUp.TabIndex = 2;
            this.btnUp.Text = "↑";
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // ckLstBoxPreparation
            // 
            this.ckLstBoxPreparation.FormattingEnabled = true;
            this.ckLstBoxPreparation.Location = new System.Drawing.Point(248, 70);
            this.ckLstBoxPreparation.Name = "ckLstBoxPreparation";
            this.ckLstBoxPreparation.Size = new System.Drawing.Size(170, 292);
            this.ckLstBoxPreparation.TabIndex = 1;
            // 
            // lstBoxBuilding
            // 
            this.lstBoxBuilding.FormattingEnabled = true;
            this.lstBoxBuilding.ItemHeight = 17;
            this.lstBoxBuilding.Location = new System.Drawing.Point(0, 71);
            this.lstBoxBuilding.Name = "lstBoxBuilding";
            this.lstBoxBuilding.Size = new System.Drawing.Size(177, 293);
            this.lstBoxBuilding.TabIndex = 0;
            this.lstBoxBuilding.SelectedIndexChanged += new System.EventHandler(this.lstBoxBuilding_SelectedIndexChanged);
            // 
            // FrmP2B
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 773);
            this.Controls.Add(this.chensButton2);
            this.Controls.Add(this.chensButton1);
            this.Controls.Add(this.chensLabel2);
            this.Controls.Add(this.chensLabel1);
            this.Controls.Add(this.msMain);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.ckLstBoxPreparation);
            this.Controls.Add(this.lstBoxBuilding);
            this.Name = "FrmP2B";
            this.Text = "FrmP2B";
            this.Load += new System.EventHandler(this.FrmP2B_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsPreparation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBuilding)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBoxBuilding;
        private System.Windows.Forms.CheckedListBox ckLstBoxPreparation;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem1;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensButton chensButton1;
        private ChensControl.ChensButton chensButton2;
        private System.Windows.Forms.BindingSource bsPreparation;
        private System.Windows.Forms.BindingSource bsBuilding;
    }
}