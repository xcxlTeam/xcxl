namespace WMS.FastTask
{
    partial class frmFastOutEdit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiSaveClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.gbBottom = new System.Windows.Forms.GroupBox();
            this.dgvList = new ChensControl.ChensDataGridView();
            this.gbMiddle = new System.Windows.Forms.GroupBox();
            this.chensComboBox2 = new ChensControl.ChensComboBox();
            this.chensTextBox5 = new ChensControl.ChensTextBox();
            this.chensLabel17 = new ChensControl.ChensLabel();
            this.chensTextBox4 = new ChensControl.ChensTextBox();
            this.chensLabel16 = new ChensControl.ChensLabel();
            this.chensLabel15 = new ChensControl.ChensLabel();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.chensDateTimePicker2 = new ChensControl.ChensDateTimePicker();
            this.chensComboBox1 = new ChensControl.ChensComboBox();
            this.chensTextBox2 = new ChensControl.ChensTextBox();
            this.chensLabel13 = new ChensControl.ChensLabel();
            this.txtBQty = new ChensControl.ChensTextBox();
            this.txtBMaterialNo = new ChensControl.ChensTextBox();
            this.chensLabel9 = new ChensControl.ChensLabel();
            this.btnDel = new ChensControl.ChensButton();
            this.btnUpd = new ChensControl.ChensButton();
            this.btnAdd = new ChensControl.ChensButton();
            this.chensLabel12 = new ChensControl.ChensLabel();
            this.txtRemarks = new ChensControl.ChensTextBox();
            this.chensLabel11 = new ChensControl.ChensLabel();
            this.chensLabel10 = new ChensControl.ChensLabel();
            this.gbHeader = new System.Windows.Forms.GroupBox();
            this.chensTextBox1 = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.chensDateTimePicker1 = new ChensControl.ChensDateTimePicker();
            this.txtReason = new ChensControl.ChensTextBox();
            this.txtMaterialDoc = new ChensControl.ChensTextBox();
            this.chensLabel8 = new ChensControl.ChensLabel();
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.txtVoucherNo = new ChensControl.ChensTextBox();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.cbbStorageLoc = new ChensControl.ChensComboBox();
            this.txtTaskNo = new ChensControl.ChensTextBox();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chensTextBox3 = new ChensControl.ChensTextBox();
            this.chensLabel14 = new ChensControl.ChensLabel();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            this.gbBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.gbMiddle.SuspendLayout();
            this.gbHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.msMain.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSaveClose,
            this.tsmiCancel});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(992, 25);
            this.msMain.TabIndex = 4;
            this.msMain.Text = "chensMenuStrip1";
            // 
            // tsmiSaveClose
            // 
            this.tsmiSaveClose.Name = "tsmiSaveClose";
            this.tsmiSaveClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSaveClose.Size = new System.Drawing.Size(80, 21);
            this.tsmiSaveClose.Text = "保存并关闭";
            // 
            // tsmiCancel
            // 
            this.tsmiCancel.Name = "tsmiCancel";
            this.tsmiCancel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.tsmiCancel.Size = new System.Drawing.Size(44, 21);
            this.tsmiCancel.Text = "关闭";
            // 
            // gbBottom
            // 
            this.gbBottom.Controls.Add(this.dgvList);
            this.gbBottom.Location = new System.Drawing.Point(0, 281);
            this.gbBottom.Name = "gbBottom";
            this.gbBottom.Size = new System.Drawing.Size(992, 491);
            this.gbBottom.TabIndex = 9;
            this.gbBottom.TabStop = false;
            this.gbBottom.Text = "出库表体";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column4,
            this.Column2,
            this.Column3,
            this.Column1,
            this.Column6});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvList.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgvList.GridColor = System.Drawing.Color.LightGray;
            this.dgvList.HaveCopyMenu = true;
            this.dgvList.Location = new System.Drawing.Point(3, 19);
            this.dgvList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvList.Name = "dgvList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvList.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(986, 469);
            this.dgvList.TabIndex = 3;
            // 
            // gbMiddle
            // 
            this.gbMiddle.Controls.Add(this.chensTextBox3);
            this.gbMiddle.Controls.Add(this.chensLabel14);
            this.gbMiddle.Controls.Add(this.chensComboBox2);
            this.gbMiddle.Controls.Add(this.chensTextBox5);
            this.gbMiddle.Controls.Add(this.chensLabel17);
            this.gbMiddle.Controls.Add(this.chensTextBox4);
            this.gbMiddle.Controls.Add(this.chensLabel16);
            this.gbMiddle.Controls.Add(this.chensLabel15);
            this.gbMiddle.Controls.Add(this.chensLabel3);
            this.gbMiddle.Controls.Add(this.chensDateTimePicker2);
            this.gbMiddle.Controls.Add(this.chensComboBox1);
            this.gbMiddle.Controls.Add(this.chensTextBox2);
            this.gbMiddle.Controls.Add(this.chensLabel13);
            this.gbMiddle.Controls.Add(this.txtBQty);
            this.gbMiddle.Controls.Add(this.txtBMaterialNo);
            this.gbMiddle.Controls.Add(this.chensLabel9);
            this.gbMiddle.Controls.Add(this.btnDel);
            this.gbMiddle.Controls.Add(this.btnUpd);
            this.gbMiddle.Controls.Add(this.btnAdd);
            this.gbMiddle.Controls.Add(this.chensLabel12);
            this.gbMiddle.Controls.Add(this.txtRemarks);
            this.gbMiddle.Controls.Add(this.chensLabel11);
            this.gbMiddle.Controls.Add(this.chensLabel10);
            this.gbMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbMiddle.Location = new System.Drawing.Point(0, 155);
            this.gbMiddle.Name = "gbMiddle";
            this.gbMiddle.Size = new System.Drawing.Size(992, 120);
            this.gbMiddle.TabIndex = 8;
            this.gbMiddle.TabStop = false;
            this.gbMiddle.Text = "物料信息";
            // 
            // chensComboBox2
            // 
            this.chensComboBox2.BackColor = System.Drawing.Color.White;
            this.chensComboBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chensComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chensComboBox2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensComboBox2.FormattingEnabled = true;
            this.chensComboBox2.HotTrack = false;
            this.chensComboBox2.Location = new System.Drawing.Point(364, 42);
            this.chensComboBox2.Name = "chensComboBox2";
            this.chensComboBox2.Size = new System.Drawing.Size(115, 25);
            this.chensComboBox2.TabIndex = 34;
            // 
            // chensTextBox5
            // 
            this.chensTextBox5.BackColor = System.Drawing.Color.White;
            this.chensTextBox5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensTextBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chensTextBox5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensTextBox5.HotTrack = false;
            this.chensTextBox5.Location = new System.Drawing.Point(184, 43);
            this.chensTextBox5.Name = "chensTextBox5";
            this.chensTextBox5.Size = new System.Drawing.Size(67, 23);
            this.chensTextBox5.TabIndex = 33;
            this.chensTextBox5.TextEnabled = false;
            // 
            // chensLabel17
            // 
            this.chensLabel17.AutoSize = true;
            this.chensLabel17.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel17.Location = new System.Drawing.Point(181, 23);
            this.chensLabel17.Name = "chensLabel17";
            this.chensLabel17.Size = new System.Drawing.Size(32, 17);
            this.chensLabel17.TabIndex = 32;
            this.chensLabel17.Text = "个数";
            // 
            // chensTextBox4
            // 
            this.chensTextBox4.BackColor = System.Drawing.Color.White;
            this.chensTextBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chensTextBox4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensTextBox4.HotTrack = false;
            this.chensTextBox4.Location = new System.Drawing.Point(111, 43);
            this.chensTextBox4.Name = "chensTextBox4";
            this.chensTextBox4.Size = new System.Drawing.Size(67, 23);
            this.chensTextBox4.TabIndex = 31;
            this.chensTextBox4.TextEnabled = false;
            // 
            // chensLabel16
            // 
            this.chensLabel16.AutoSize = true;
            this.chensLabel16.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel16.Location = new System.Drawing.Point(108, 23);
            this.chensLabel16.Name = "chensLabel16";
            this.chensLabel16.Size = new System.Drawing.Size(32, 17);
            this.chensLabel16.TabIndex = 30;
            this.chensLabel16.Text = "净重";
            // 
            // chensLabel15
            // 
            this.chensLabel15.AutoSize = true;
            this.chensLabel15.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel15.Location = new System.Drawing.Point(122, 71);
            this.chensLabel15.Name = "chensLabel15";
            this.chensLabel15.Size = new System.Drawing.Size(56, 17);
            this.chensLabel15.TabIndex = 29;
            this.chensLabel15.Text = "过期日期";
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(509, 23);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(32, 17);
            this.chensLabel3.TabIndex = 21;
            this.chensLabel3.Text = "仓库";
            // 
            // chensDateTimePicker2
            // 
            this.chensDateTimePicker2.Location = new System.Drawing.Point(114, 91);
            this.chensDateTimePicker2.Name = "chensDateTimePicker2";
            this.chensDateTimePicker2.Size = new System.Drawing.Size(141, 23);
            this.chensDateTimePicker2.TabIndex = 28;
            // 
            // chensComboBox1
            // 
            this.chensComboBox1.BackColor = System.Drawing.Color.White;
            this.chensComboBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chensComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chensComboBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensComboBox1.FormattingEnabled = true;
            this.chensComboBox1.HotTrack = false;
            this.chensComboBox1.Location = new System.Drawing.Point(485, 42);
            this.chensComboBox1.Name = "chensComboBox1";
            this.chensComboBox1.Size = new System.Drawing.Size(150, 25);
            this.chensComboBox1.TabIndex = 18;
            // 
            // chensTextBox2
            // 
            this.chensTextBox2.BackColor = System.Drawing.Color.White;
            this.chensTextBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chensTextBox2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensTextBox2.HotTrack = false;
            this.chensTextBox2.Location = new System.Drawing.Point(8, 91);
            this.chensTextBox2.Name = "chensTextBox2";
            this.chensTextBox2.Size = new System.Drawing.Size(100, 23);
            this.chensTextBox2.TabIndex = 25;
            this.chensTextBox2.TextEnabled = false;
            // 
            // chensLabel13
            // 
            this.chensLabel13.AutoSize = true;
            this.chensLabel13.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel13.Location = new System.Drawing.Point(17, 71);
            this.chensLabel13.Name = "chensLabel13";
            this.chensLabel13.Size = new System.Drawing.Size(44, 17);
            this.chensLabel13.TabIndex = 24;
            this.chensLabel13.Text = "原因码";
            // 
            // txtBQty
            // 
            this.txtBQty.BackColor = System.Drawing.Color.White;
            this.txtBQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtBQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBQty.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtBQty.HotTrack = false;
            this.txtBQty.Location = new System.Drawing.Point(258, 43);
            this.txtBQty.Name = "txtBQty";
            this.txtBQty.Size = new System.Drawing.Size(100, 23);
            this.txtBQty.TabIndex = 19;
            this.txtBQty.TextEnabled = false;
            // 
            // txtBMaterialNo
            // 
            this.txtBMaterialNo.BackColor = System.Drawing.Color.White;
            this.txtBMaterialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtBMaterialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBMaterialNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtBMaterialNo.HotTrack = false;
            this.txtBMaterialNo.Location = new System.Drawing.Point(3, 45);
            this.txtBMaterialNo.Name = "txtBMaterialNo";
            this.txtBMaterialNo.Size = new System.Drawing.Size(102, 23);
            this.txtBMaterialNo.TabIndex = 17;
            this.txtBMaterialNo.TextEnabled = true;
            // 
            // chensLabel9
            // 
            this.chensLabel9.AutoSize = true;
            this.chensLabel9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel9.Location = new System.Drawing.Point(275, 71);
            this.chensLabel9.Name = "chensLabel9";
            this.chensLabel9.Size = new System.Drawing.Size(32, 17);
            this.chensLabel9.TabIndex = 14;
            this.chensLabel9.Text = "备注";
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnDel.ForeColor = System.Drawing.Color.White;
            this.btnDel.Location = new System.Drawing.Point(905, 43);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 25);
            this.btnDel.TabIndex = 23;
            this.btnDel.Text = "删除记录";
            this.btnDel.UseVisualStyleBackColor = false;
            // 
            // btnUpd
            // 
            this.btnUpd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btnUpd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpd.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnUpd.ForeColor = System.Drawing.Color.White;
            this.btnUpd.Location = new System.Drawing.Point(824, 43);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(75, 25);
            this.btnUpd.TabIndex = 22;
            this.btnUpd.Text = "修改记录";
            this.btnUpd.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(743, 43);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 25);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "新增记录";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // chensLabel12
            // 
            this.chensLabel12.AutoSize = true;
            this.chensLabel12.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel12.Location = new System.Drawing.Point(267, 23);
            this.chensLabel12.Name = "chensLabel12";
            this.chensLabel12.Size = new System.Drawing.Size(32, 17);
            this.chensLabel12.TabIndex = 2;
            this.chensLabel12.Text = "数量";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "Remark", true));
            this.txtRemarks.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtRemarks.HotTrack = false;
            this.txtRemarks.Location = new System.Drawing.Point(261, 91);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(73, 23);
            this.txtRemarks.TabIndex = 16;
            this.txtRemarks.TextEnabled = false;
            // 
            // chensLabel11
            // 
            this.chensLabel11.AutoSize = true;
            this.chensLabel11.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel11.Location = new System.Drawing.Point(389, 23);
            this.chensLabel11.Name = "chensLabel11";
            this.chensLabel11.Size = new System.Drawing.Size(32, 17);
            this.chensLabel11.TabIndex = 1;
            this.chensLabel11.Text = "批号";
            // 
            // chensLabel10
            // 
            this.chensLabel10.AutoSize = true;
            this.chensLabel10.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel10.Location = new System.Drawing.Point(13, 25);
            this.chensLabel10.Name = "chensLabel10";
            this.chensLabel10.Size = new System.Drawing.Size(56, 17);
            this.chensLabel10.TabIndex = 0;
            this.chensLabel10.Text = "物料编号";
            // 
            // gbHeader
            // 
            this.gbHeader.Controls.Add(this.chensTextBox1);
            this.gbHeader.Controls.Add(this.chensLabel2);
            this.gbHeader.Controls.Add(this.chensDateTimePicker1);
            this.gbHeader.Controls.Add(this.txtReason);
            this.gbHeader.Controls.Add(this.txtMaterialDoc);
            this.gbHeader.Controls.Add(this.chensLabel8);
            this.gbHeader.Controls.Add(this.chensLabel7);
            this.gbHeader.Controls.Add(this.chensLabel6);
            this.gbHeader.Controls.Add(this.chensLabel5);
            this.gbHeader.Controls.Add(this.txtVoucherNo);
            this.gbHeader.Controls.Add(this.chensLabel4);
            this.gbHeader.Controls.Add(this.cbbStorageLoc);
            this.gbHeader.Controls.Add(this.txtTaskNo);
            this.gbHeader.Controls.Add(this.chensLabel1);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHeader.Location = new System.Drawing.Point(0, 25);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Size = new System.Drawing.Size(992, 130);
            this.gbHeader.TabIndex = 7;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "出库单头";
            // 
            // chensTextBox1
            // 
            this.chensTextBox1.BackColor = System.Drawing.Color.White;
            this.chensTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chensTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "MaterialDoc", true));
            this.chensTextBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensTextBox1.HotTrack = false;
            this.chensTextBox1.Location = new System.Drawing.Point(87, 88);
            this.chensTextBox1.Name = "chensTextBox1";
            this.chensTextBox1.Size = new System.Drawing.Size(150, 23);
            this.chensTextBox1.TabIndex = 20;
            this.chensTextBox1.TextEnabled = false;
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(25, 90);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(56, 17);
            this.chensLabel2.TabIndex = 19;
            this.chensLabel2.Text = "部门代码";
            // 
            // chensDateTimePicker1
            // 
            this.chensDateTimePicker1.Location = new System.Drawing.Point(571, 55);
            this.chensDateTimePicker1.Name = "chensDateTimePicker1";
            this.chensDateTimePicker1.Size = new System.Drawing.Size(150, 23);
            this.chensDateTimePicker1.TabIndex = 17;
            // 
            // txtReason
            // 
            this.txtReason.BackColor = System.Drawing.Color.White;
            this.txtReason.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReason.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "Reason", true));
            this.txtReason.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtReason.HotTrack = false;
            this.txtReason.Location = new System.Drawing.Point(571, 23);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(150, 23);
            this.txtReason.TabIndex = 14;
            this.txtReason.TextEnabled = false;
            // 
            // txtMaterialDoc
            // 
            this.txtMaterialDoc.BackColor = System.Drawing.Color.White;
            this.txtMaterialDoc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtMaterialDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialDoc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "MaterialDoc", true));
            this.txtMaterialDoc.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtMaterialDoc.HotTrack = false;
            this.txtMaterialDoc.Location = new System.Drawing.Point(329, 58);
            this.txtMaterialDoc.Name = "txtMaterialDoc";
            this.txtMaterialDoc.Size = new System.Drawing.Size(150, 23);
            this.txtMaterialDoc.TabIndex = 8;
            this.txtMaterialDoc.TextEnabled = false;
            // 
            // chensLabel8
            // 
            this.chensLabel8.AutoSize = true;
            this.chensLabel8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel8.Location = new System.Drawing.Point(25, 60);
            this.chensLabel8.Name = "chensLabel8";
            this.chensLabel8.Size = new System.Drawing.Size(56, 17);
            this.chensLabel8.TabIndex = 13;
            this.chensLabel8.Text = "出库类型";
            // 
            // chensLabel7
            // 
            this.chensLabel7.AutoSize = true;
            this.chensLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel7.Location = new System.Drawing.Point(509, 60);
            this.chensLabel7.Name = "chensLabel7";
            this.chensLabel7.Size = new System.Drawing.Size(56, 17);
            this.chensLabel7.TabIndex = 12;
            this.chensLabel7.Text = "制单时间";
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(279, 60);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(44, 17);
            this.chensLabel6.TabIndex = 11;
            this.chensLabel6.Text = "制单人";
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(509, 25);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(56, 17);
            this.chensLabel5.TabIndex = 8;
            this.chensLabel5.Text = "出库原因";
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.BackColor = System.Drawing.Color.White;
            this.txtVoucherNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtVoucherNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVoucherNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "VoucherNo", true));
            this.txtVoucherNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtVoucherNo.HotTrack = false;
            this.txtVoucherNo.Location = new System.Drawing.Point(329, 23);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.Size = new System.Drawing.Size(150, 23);
            this.txtVoucherNo.TabIndex = 6;
            this.txtVoucherNo.TextEnabled = false;
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(255, 25);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(68, 17);
            this.chensLabel4.TabIndex = 6;
            this.chensLabel4.Text = "下架任务号";
            // 
            // cbbStorageLoc
            // 
            this.cbbStorageLoc.BackColor = System.Drawing.Color.White;
            this.cbbStorageLoc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbbStorageLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStorageLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbStorageLoc.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbbStorageLoc.FormattingEnabled = true;
            this.cbbStorageLoc.HotTrack = false;
            this.cbbStorageLoc.Location = new System.Drawing.Point(87, 57);
            this.cbbStorageLoc.Name = "cbbStorageLoc";
            this.cbbStorageLoc.Size = new System.Drawing.Size(150, 25);
            this.cbbStorageLoc.TabIndex = 12;
            // 
            // txtTaskNo
            // 
            this.txtTaskNo.BackColor = System.Drawing.Color.White;
            this.txtTaskNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtTaskNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaskNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "TaskNo", true));
            this.txtTaskNo.Enabled = false;
            this.txtTaskNo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtTaskNo.HotTrack = false;
            this.txtTaskNo.Location = new System.Drawing.Point(87, 23);
            this.txtTaskNo.Name = "txtTaskNo";
            this.txtTaskNo.Size = new System.Drawing.Size(150, 23);
            this.txtTaskNo.TabIndex = 1;
            this.txtTaskNo.TextEnabled = false;
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(25, 25);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(56, 17);
            this.chensLabel1.TabIndex = 0;
            this.chensLabel1.Text = "出库单号";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "行号";
            this.Column5.Name = "Column5";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "MaterialNo";
            this.Column4.HeaderText = "物料编号";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "批次";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "数量";
            this.Column3.Name = "Column3";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "中文名称";
            this.Column1.Name = "Column1";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "英文名称";
            this.Column6.Name = "Column6";
            // 
            // chensTextBox3
            // 
            this.chensTextBox3.BackColor = System.Drawing.SystemColors.Control;
            this.chensTextBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chensTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chensTextBox3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensTextBox3.HotTrack = false;
            this.chensTextBox3.Location = new System.Drawing.Point(340, 91);
            this.chensTextBox3.Name = "chensTextBox3";
            this.chensTextBox3.Size = new System.Drawing.Size(295, 23);
            this.chensTextBox3.TabIndex = 36;
            this.chensTextBox3.TextEnabled = true;
            // 
            // chensLabel14
            // 
            this.chensLabel14.AutoSize = true;
            this.chensLabel14.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel14.Location = new System.Drawing.Point(350, 71);
            this.chensLabel14.Name = "chensLabel14";
            this.chensLabel14.Size = new System.Drawing.Size(56, 17);
            this.chensLabel14.TabIndex = 35;
            this.chensLabel14.Text = "中文名称";
            // 
            // frmFastOutEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 772);
            this.Controls.Add(this.gbBottom);
            this.Controls.Add(this.gbMiddle);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.msMain);
            this.Name = "frmFastOutEdit";
            this.Text = "frmFastOutEdit";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).EndInit();
            this.gbBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.gbMiddle.ResumeLayout(false);
            this.gbMiddle.PerformLayout();
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveClose;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancel;
        private System.Windows.Forms.BindingSource bsMain;
        private System.Windows.Forms.GroupBox gbBottom;
        private ChensControl.ChensDataGridView dgvList;
        private System.Windows.Forms.GroupBox gbMiddle;
        private ChensControl.ChensTextBox chensTextBox2;
        private ChensControl.ChensLabel chensLabel13;
        private ChensControl.ChensTextBox txtBQty;
        private ChensControl.ChensTextBox txtBMaterialNo;
        private ChensControl.ChensButton btnDel;
        private ChensControl.ChensButton btnUpd;
        private ChensControl.ChensButton btnAdd;
        private ChensControl.ChensLabel chensLabel12;
        private ChensControl.ChensLabel chensLabel11;
        private ChensControl.ChensLabel chensLabel10;
        private System.Windows.Forms.GroupBox gbHeader;
        private ChensControl.ChensTextBox chensTextBox1;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensComboBox chensComboBox1;
        private ChensControl.ChensDateTimePicker chensDateTimePicker1;
        private ChensControl.ChensTextBox txtReason;
        private ChensControl.ChensTextBox txtMaterialDoc;
        private ChensControl.ChensLabel chensLabel9;
        private ChensControl.ChensLabel chensLabel8;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensTextBox txtRemarks;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensTextBox txtVoucherNo;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensComboBox cbbStorageLoc;
        private ChensControl.ChensTextBox txtTaskNo;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensLabel chensLabel15;
        private ChensControl.ChensDateTimePicker chensDateTimePicker2;
        private ChensControl.ChensComboBox chensComboBox2;
        private ChensControl.ChensTextBox chensTextBox5;
        private ChensControl.ChensLabel chensLabel17;
        private ChensControl.ChensTextBox chensTextBox4;
        private ChensControl.ChensLabel chensLabel16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private ChensControl.ChensTextBox chensTextBox3;
        private ChensControl.ChensLabel chensLabel14;
    }
}