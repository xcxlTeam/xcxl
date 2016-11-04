namespace WMS.Warehouse
{
    partial class FrmTempMaterialFile
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
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.chensTabControl1 = new ChensControl.ChensTabControl();
            this.tpBasic = new System.Windows.Forms.TabPage();
            this.txtTempMaterialDesc = new ChensControl.ChensTextBox();
            this.bsTempMaterial = new System.Windows.Forms.BindingSource(this.components);
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.txtTempMaterialNo = new ChensControl.ChensTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTempMaterialNo = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.msMain.SuspendLayout();
            this.chensTabControl1.SuspendLayout();
            this.tpBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTempMaterial)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdd,
            this.tsmiSave,
            this.tsmiSaveClose,
            this.tsmiSaveAdd,
            this.tsmiCancel});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(500, 25);
            this.msMain.TabIndex = 3;
            this.msMain.Text = "chensMenuStrip1";
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.Size = new System.Drawing.Size(44, 21);
            this.tsmiAdd.Text = "新增";
            this.tsmiAdd.Visible = false;
            this.tsmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(80, 21);
            this.tsmiSave.Text = "保存并查看";
            this.tsmiSave.Visible = false;
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiSaveClose
            // 
            this.tsmiSaveClose.Name = "tsmiSaveClose";
            this.tsmiSaveClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSaveClose.Size = new System.Drawing.Size(80, 21);
            this.tsmiSaveClose.Text = "保存并关闭";
            this.tsmiSaveClose.Click += new System.EventHandler(this.tsmiSaveClose_Click);
            // 
            // tsmiSaveAdd
            // 
            this.tsmiSaveAdd.Name = "tsmiSaveAdd";
            this.tsmiSaveAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmiSaveAdd.Size = new System.Drawing.Size(80, 21);
            this.tsmiSaveAdd.Text = "保存并新增";
            this.tsmiSaveAdd.Click += new System.EventHandler(this.tsmiSaveAdd_Click);
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
            this.chensTabControl1.Size = new System.Drawing.Size(500, 225);
            this.chensTabControl1.TabIndex = 4;
            this.chensTabControl1.TabStop = false;
            // 
            // tpBasic
            // 
            this.tpBasic.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpBasic.Controls.Add(this.txtTempMaterialDesc);
            this.tpBasic.Controls.Add(this.chensLabel2);
            this.tpBasic.Controls.Add(this.txtTempMaterialNo);
            this.tpBasic.Controls.Add(this.label4);
            this.tpBasic.Controls.Add(this.lblTempMaterialNo);
            this.tpBasic.Controls.Add(this.chensLabel1);
            this.tpBasic.Location = new System.Drawing.Point(4, 29);
            this.tpBasic.Name = "tpBasic";
            this.tpBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tpBasic.Size = new System.Drawing.Size(492, 192);
            this.tpBasic.TabIndex = 0;
            this.tpBasic.Text = "物料信息";
            // 
            // txtTempMaterialDesc
            // 
            this.txtTempMaterialDesc.BackColor = System.Drawing.Color.White;
            this.txtTempMaterialDesc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtTempMaterialDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTempMaterialDesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTempMaterial, "TempMaterialDesc", true));
            this.txtTempMaterialDesc.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtTempMaterialDesc.HotTrack = false;
            this.txtTempMaterialDesc.Location = new System.Drawing.Point(127, 83);
            this.txtTempMaterialDesc.Multiline = true;
            this.txtTempMaterialDesc.Name = "txtTempMaterialDesc";
            this.txtTempMaterialDesc.Size = new System.Drawing.Size(300, 50);
            this.txtTempMaterialDesc.TabIndex = 4;
            this.txtTempMaterialDesc.TextEnabled = false;
            // 
            // bsTempMaterial
            // 
            this.bsTempMaterial.DataSource = typeof(WMS.WebService.TempMaterialInfo);
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(65, 85);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 136;
            this.chensLabel2.Text = "物料描述";
            // 
            // txtTempMaterialNo
            // 
            this.txtTempMaterialNo.BackColor = System.Drawing.Color.White;
            this.txtTempMaterialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtTempMaterialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTempMaterialNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTempMaterial, "TempMaterialNo", true));
            this.txtTempMaterialNo.Enabled = false;
            this.txtTempMaterialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtTempMaterialNo.HotTrack = false;
            this.txtTempMaterialNo.Location = new System.Drawing.Point(127, 43);
            this.txtTempMaterialNo.Name = "txtTempMaterialNo";
            this.txtTempMaterialNo.Size = new System.Drawing.Size(300, 23);
            this.txtTempMaterialNo.TabIndex = 1;
            this.txtTempMaterialNo.TextEnabled = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(433, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 17);
            this.label4.TabIndex = 132;
            this.label4.Text = "*";
            // 
            // lblTempMaterialNo
            // 
            this.lblTempMaterialNo.AutoSize = true;
            this.lblTempMaterialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblTempMaterialNo.Location = new System.Drawing.Point(65, 45);
            this.lblTempMaterialNo.Name = "lblTempMaterialNo";
            this.lblTempMaterialNo.Size = new System.Drawing.Size(56, 17);
            this.lblTempMaterialNo.TabIndex = 3;
            this.lblTempMaterialNo.Text = "物料编号";
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
            this.chensLabel1.Text = "基本信息";
            // 
            // FrmTempMaterialFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 250);
            this.Controls.Add(this.chensTabControl1);
            this.Controls.Add(this.msMain);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmTempMaterialFile";
            this.Text = "新增临时物料";
            this.Load += new System.EventHandler(this.FrmTempInventoryFile_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.chensTabControl1.ResumeLayout(false);
            this.tpBasic.ResumeLayout(false);
            this.tpBasic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTempMaterial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancel;
        private ChensControl.ChensTabControl chensTabControl1;
        private System.Windows.Forms.TabPage tpBasic;
        private ChensControl.ChensTextBox txtTempMaterialDesc;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensTextBox txtTempMaterialNo;
        private System.Windows.Forms.Label label4;
        private ChensControl.ChensLabel lblTempMaterialNo;
        private ChensControl.ChensLabel chensLabel1;
        private System.Windows.Forms.BindingSource bsTempMaterial;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveClose;
    }
}