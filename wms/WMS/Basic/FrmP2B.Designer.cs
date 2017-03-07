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
            this.btnEditPreparation = new ChensControl.ChensButton();
            this.btnDelPreparation = new ChensControl.ChensButton();
            this.btnAddPreparation = new ChensControl.ChensButton();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.ckLstBoxPreparation = new System.Windows.Forms.CheckedListBox();
            this.lstBoxBuilding = new System.Windows.Forms.ListBox();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEditPreparation
            // 
            this.btnEditPreparation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btnEditPreparation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditPreparation.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnEditPreparation.ForeColor = System.Drawing.Color.White;
            this.btnEditPreparation.Location = new System.Drawing.Point(245, 368);
            this.btnEditPreparation.Name = "btnEditPreparation";
            this.btnEditPreparation.Size = new System.Drawing.Size(56, 31);
            this.btnEditPreparation.TabIndex = 9;
            this.btnEditPreparation.Text = "编辑";
            this.btnEditPreparation.UseVisualStyleBackColor = false;
            this.btnEditPreparation.Click += new System.EventHandler(this.btnEditPreparation_Click);
            // 
            // btnDelPreparation
            // 
            this.btnDelPreparation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btnDelPreparation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelPreparation.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnDelPreparation.ForeColor = System.Drawing.Color.White;
            this.btnDelPreparation.Location = new System.Drawing.Point(369, 368);
            this.btnDelPreparation.Name = "btnDelPreparation";
            this.btnDelPreparation.Size = new System.Drawing.Size(56, 31);
            this.btnDelPreparation.TabIndex = 8;
            this.btnDelPreparation.Text = "移除";
            this.btnDelPreparation.UseVisualStyleBackColor = false;
            this.btnDelPreparation.Click += new System.EventHandler(this.btnDelPreparation_Click);
            // 
            // btnAddPreparation
            // 
            this.btnAddPreparation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btnAddPreparation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPreparation.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnAddPreparation.ForeColor = System.Drawing.Color.White;
            this.btnAddPreparation.Location = new System.Drawing.Point(307, 368);
            this.btnAddPreparation.Name = "btnAddPreparation";
            this.btnAddPreparation.Size = new System.Drawing.Size(56, 31);
            this.btnAddPreparation.TabIndex = 7;
            this.btnAddPreparation.Text = "添加";
            this.btnAddPreparation.UseVisualStyleBackColor = false;
            this.btnAddPreparation.Click += new System.EventHandler(this.btnAddPreparation_Click);
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
            this.tsmiCancel});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(992, 25);
            this.msMain.TabIndex = 4;
            this.msMain.Text = "chensMenuStrip1";
            // 
            // tsmiCancel
            // 
            this.tsmiCancel.Name = "tsmiCancel";
            this.tsmiCancel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.tsmiCancel.Size = new System.Drawing.Size(44, 21);
            this.tsmiCancel.Text = "关闭";
            this.tsmiCancel.Click += new System.EventHandler(this.tsmiCancel_Click);
            // 
            // btnDown
            // 
            this.btnDown.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btnDown.Location = new System.Drawing.Point(180, 109);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(32, 33);
            this.btnDown.TabIndex = 3;
            this.btnDown.Text = "↓";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btnUp.Location = new System.Drawing.Point(180, 70);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(32, 33);
            this.btnUp.TabIndex = 2;
            this.btnUp.Text = "↑";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // ckLstBoxPreparation
            // 
            this.ckLstBoxPreparation.FormattingEnabled = true;
            this.ckLstBoxPreparation.Location = new System.Drawing.Point(248, 70);
            this.ckLstBoxPreparation.Name = "ckLstBoxPreparation";
            this.ckLstBoxPreparation.Size = new System.Drawing.Size(170, 292);
            this.ckLstBoxPreparation.TabIndex = 1;
            this.ckLstBoxPreparation.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ckLstBoxPreparation_ItemCheck);
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
            this.Controls.Add(this.btnEditPreparation);
            this.Controls.Add(this.btnDelPreparation);
            this.Controls.Add(this.btnAddPreparation);
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
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBoxBuilding;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancel;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensButton btnAddPreparation;
        private ChensControl.ChensButton btnDelPreparation;
        private ChensControl.ChensButton btnEditPreparation;
        private System.Windows.Forms.CheckedListBox ckLstBoxPreparation;
    }
}