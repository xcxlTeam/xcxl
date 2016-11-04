namespace WMS.Warehouse
{
    partial class FrmTempMaterialAlter
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaterialDesc = new ChensControl.ChensTextBox();
            this.bsTempMaterial = new System.Windows.Forms.BindingSource(this.components);
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.txtMaterialNo = new ChensControl.ChensTextBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.txtTempMaterialDesc = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.txtTempMaterialNo = new ChensControl.ChensTextBox();
            this.chensLabel9 = new ChensControl.ChensLabel();
            this.msMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTempMaterial)).BeginInit();
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
            this.msMain.Size = new System.Drawing.Size(992, 25);
            this.msMain.TabIndex = 3;
            this.msMain.Text = "chensMenuStrip1";
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSave.Size = new System.Drawing.Size(44, 21);
            this.tsmiSave.Text = "替换";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMaterialDesc);
            this.groupBox1.Controls.Add(this.chensLabel1);
            this.groupBox1.Controls.Add(this.txtMaterialNo);
            this.groupBox1.Controls.Add(this.chensLabel3);
            this.groupBox1.Controls.Add(this.txtTempMaterialDesc);
            this.groupBox1.Controls.Add(this.chensLabel2);
            this.groupBox1.Controls.Add(this.txtTempMaterialNo);
            this.groupBox1.Controls.Add(this.chensLabel9);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(992, 225);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "物料信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(909, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 17);
            this.label1.TabIndex = 146;
            this.label1.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(442, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 17);
            this.label4.TabIndex = 145;
            this.label4.Text = "*";
            // 
            // txtMaterialDesc
            // 
            this.txtMaterialDesc.BackColor = System.Drawing.Color.White;
            this.txtMaterialDesc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialDesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTempMaterial, "MaterialDesc", true));
            this.txtMaterialDesc.Enabled = false;
            this.txtMaterialDesc.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialDesc.HotTrack = false;
            this.txtMaterialDesc.Location = new System.Drawing.Point(603, 88);
            this.txtMaterialDesc.Multiline = true;
            this.txtMaterialDesc.Name = "txtMaterialDesc";
            this.txtMaterialDesc.Size = new System.Drawing.Size(300, 50);
            this.txtMaterialDesc.TabIndex = 143;
            this.txtMaterialDesc.TextEnabled = false;
            // 
            // bsTempMaterial
            // 
            this.bsTempMaterial.DataSource = typeof(WMS.WebService.TempMaterialInfo);
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(519, 90);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(78, 17);
            this.chensLabel1.TabIndex = 144;
            this.chensLabel1.Text = "SAP物料描述";
            // 
            // txtMaterialNo
            // 
            this.txtMaterialNo.BackColor = System.Drawing.Color.White;
            this.txtMaterialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTempMaterial, "MaterialNo", true));
            this.txtMaterialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialNo.HotTrack = false;
            this.txtMaterialNo.Location = new System.Drawing.Point(603, 48);
            this.txtMaterialNo.Name = "txtMaterialNo";
            this.txtMaterialNo.Size = new System.Drawing.Size(300, 23);
            this.txtMaterialNo.TabIndex = 141;
            this.txtMaterialNo.TextEnabled = false;
            this.txtMaterialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaterialNo_KeyPress);
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(519, 50);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(78, 17);
            this.chensLabel3.TabIndex = 142;
            this.chensLabel3.Text = "SAP物料编号";
            // 
            // txtTempMaterialDesc
            // 
            this.txtTempMaterialDesc.BackColor = System.Drawing.Color.White;
            this.txtTempMaterialDesc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtTempMaterialDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTempMaterialDesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTempMaterial, "TempMaterialDesc", true));
            this.txtTempMaterialDesc.Enabled = false;
            this.txtTempMaterialDesc.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtTempMaterialDesc.HotTrack = false;
            this.txtTempMaterialDesc.Location = new System.Drawing.Point(136, 88);
            this.txtTempMaterialDesc.Multiline = true;
            this.txtTempMaterialDesc.Name = "txtTempMaterialDesc";
            this.txtTempMaterialDesc.Size = new System.Drawing.Size(300, 50);
            this.txtTempMaterialDesc.TabIndex = 139;
            this.txtTempMaterialDesc.TextEnabled = false;
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(50, 90);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(80, 17);
            this.chensLabel2.TabIndex = 140;
            this.chensLabel2.Text = "临时物料描述";
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
            this.txtTempMaterialNo.Location = new System.Drawing.Point(136, 48);
            this.txtTempMaterialNo.Name = "txtTempMaterialNo";
            this.txtTempMaterialNo.Size = new System.Drawing.Size(300, 23);
            this.txtTempMaterialNo.TabIndex = 137;
            this.txtTempMaterialNo.TextEnabled = false;
            this.txtTempMaterialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTempMaterialNo_KeyPress);
            // 
            // chensLabel9
            // 
            this.chensLabel9.AutoSize = true;
            this.chensLabel9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel9.Location = new System.Drawing.Point(50, 50);
            this.chensLabel9.Name = "chensLabel9";
            this.chensLabel9.Size = new System.Drawing.Size(80, 17);
            this.chensLabel9.TabIndex = 138;
            this.chensLabel9.Text = "临时物料编号";
            // 
            // FrmTempMaterialAlter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 250);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.msMain);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmTempMaterialAlter";
            this.Text = "替换临时物料";
            this.Load += new System.EventHandler(this.FrmTempInventoryAlter_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTempMaterial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancel;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private ChensControl.ChensTextBox txtTempMaterialDesc;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensTextBox txtTempMaterialNo;
        private ChensControl.ChensLabel chensLabel9;
        private ChensControl.ChensTextBox txtMaterialDesc;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensTextBox txtMaterialNo;
        private ChensControl.ChensLabel chensLabel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource bsTempMaterial;
    }
}