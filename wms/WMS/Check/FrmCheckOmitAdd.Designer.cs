namespace WMS.Check
{
    partial class FrmCheckOmitAdd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnEnter = new ChensControl.ChensButton();
            this.txtBarcode = new ChensControl.ChensTextBox();
            this.chensGroupBox1 = new ChensControl.ChensGroupBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.lblAreaNo = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.txtAreaNo = new ChensControl.ChensTextBox();
            this.chensGroupBox2 = new ChensControl.ChensGroupBox();
            this.chensDataGridView1 = new ChensControl.ChensDataGridView();
            this.colAreaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcInvStd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcInvCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcInvName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chensGroupBox1.SuspendLayout();
            this.chensGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chensDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnEnter.ForeColor = System.Drawing.Color.White;
            this.btnEnter.Location = new System.Drawing.Point(331, 57);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(95, 26);
            this.btnEnter.TabIndex = 0;
            this.btnEnter.Text = "录入";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtBarcode.HotTrack = false;
            this.txtBarcode.Location = new System.Drawing.Point(60, 60);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(246, 23);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.TextEnabled = false;
            // 
            // chensGroupBox1
            // 
            this.chensGroupBox1.Controls.Add(this.chensLabel2);
            this.chensGroupBox1.Controls.Add(this.lblAreaNo);
            this.chensGroupBox1.Controls.Add(this.chensLabel1);
            this.chensGroupBox1.Controls.Add(this.txtAreaNo);
            this.chensGroupBox1.Controls.Add(this.btnEnter);
            this.chensGroupBox1.Controls.Add(this.txtBarcode);
            this.chensGroupBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.chensGroupBox1.Name = "chensGroupBox1";
            this.chensGroupBox1.Size = new System.Drawing.Size(968, 100);
            this.chensGroupBox1.TabIndex = 2;
            this.chensGroupBox1.TabStop = false;
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(22, 62);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(32, 17);
            this.chensLabel2.TabIndex = 5;
            this.chensLabel2.Text = "条码";
            // 
            // lblAreaNo
            // 
            this.lblAreaNo.AutoSize = true;
            this.lblAreaNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblAreaNo.Location = new System.Drawing.Point(276, 26);
            this.lblAreaNo.Name = "lblAreaNo";
            this.lblAreaNo.Size = new System.Drawing.Size(0, 17);
            this.lblAreaNo.TabIndex = 4;
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(22, 26);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(32, 17);
            this.chensLabel1.TabIndex = 3;
            this.chensLabel1.Text = "货位";
            // 
            // txtAreaNo
            // 
            this.txtAreaNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtAreaNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAreaNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAreaNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtAreaNo.HotTrack = false;
            this.txtAreaNo.Location = new System.Drawing.Point(60, 24);
            this.txtAreaNo.Name = "txtAreaNo";
            this.txtAreaNo.Size = new System.Drawing.Size(127, 23);
            this.txtAreaNo.TabIndex = 2;
            this.txtAreaNo.TextEnabled = false;
            this.txtAreaNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAreaNo_KeyPress);
            // 
            // chensGroupBox2
            // 
            this.chensGroupBox2.Controls.Add(this.chensDataGridView1);
            this.chensGroupBox2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensGroupBox2.Location = new System.Drawing.Point(12, 118);
            this.chensGroupBox2.Name = "chensGroupBox2";
            this.chensGroupBox2.Size = new System.Drawing.Size(968, 642);
            this.chensGroupBox2.TabIndex = 3;
            this.chensGroupBox2.TabStop = false;
            // 
            // chensDataGridView1
            // 
            this.chensDataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.chensDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.chensDataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.chensDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chensDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.chensDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chensDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAreaNo,
            this.colSerialNo,
            this.colcInvStd,
            this.colQty,
            this.colcInvCode,
            this.colcInvName});
            this.chensDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chensDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.chensDataGridView1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensDataGridView1.GridColor = System.Drawing.Color.LightGray;
            this.chensDataGridView1.HaveCopyMenu = true;
            this.chensDataGridView1.Location = new System.Drawing.Point(3, 19);
            this.chensDataGridView1.Name = "chensDataGridView1";
            this.chensDataGridView1.ReadOnly = true;
            this.chensDataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.chensDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.chensDataGridView1.RowTemplate.Height = 23;
            this.chensDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.chensDataGridView1.Size = new System.Drawing.Size(962, 620);
            this.chensDataGridView1.TabIndex = 0;
            // 
            // colAreaNo
            // 
            this.colAreaNo.DataPropertyName = "AreaNo";
            this.colAreaNo.HeaderText = "货位";
            this.colAreaNo.Name = "colAreaNo";
            this.colAreaNo.ReadOnly = true;
            this.colAreaNo.Width = 120;
            // 
            // colSerialNo
            // 
            this.colSerialNo.DataPropertyName = "SerialNo";
            this.colSerialNo.HeaderText = "序列号";
            this.colSerialNo.Name = "colSerialNo";
            this.colSerialNo.ReadOnly = true;
            this.colSerialNo.Width = 150;
            // 
            // colcInvStd
            // 
            this.colcInvStd.DataPropertyName = "MaterialStd";
            this.colcInvStd.HeaderText = "型号";
            this.colcInvStd.Name = "colcInvStd";
            this.colcInvStd.ReadOnly = true;
            this.colcInvStd.Width = 150;
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "Qty";
            this.colQty.HeaderText = "数量";
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            this.colQty.Width = 40;
            // 
            // colcInvCode
            // 
            this.colcInvCode.DataPropertyName = "MaterialNo";
            this.colcInvCode.HeaderText = "编码";
            this.colcInvCode.Name = "colcInvCode";
            this.colcInvCode.ReadOnly = true;
            this.colcInvCode.Width = 150;
            // 
            // colcInvName
            // 
            this.colcInvName.DataPropertyName = "MaterialDesc";
            this.colcInvName.HeaderText = "名称";
            this.colcInvName.Name = "colcInvName";
            this.colcInvName.ReadOnly = true;
            this.colcInvName.Width = 200;
            // 
            // FrmCheckOmitAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 772);
            this.Controls.Add(this.chensGroupBox2);
            this.Controls.Add(this.chensGroupBox1);
            this.Name = "FrmCheckOmitAdd";
            this.Text = "FrmCheckOmitAdd";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCheckOmitAdd_FormClosed);
            this.chensGroupBox1.ResumeLayout(false);
            this.chensGroupBox1.PerformLayout();
            this.chensGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chensDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ChensControl.ChensButton btnEnter;
        private ChensControl.ChensTextBox txtBarcode;
        private ChensControl.ChensGroupBox chensGroupBox1;
        private ChensControl.ChensGroupBox chensGroupBox2;
        private ChensControl.ChensDataGridView chensDataGridView1;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensLabel lblAreaNo;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensTextBox txtAreaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAreaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcInvStd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcInvCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcInvName;
    }
}