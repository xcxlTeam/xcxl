namespace WMS.FastIn
{
    partial class FrmAdd_FastIn
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.chensGroupBox3 = new ChensControl.ChensGroupBox();
            this.dgv_show = new ChensControl.ChensDataGridView();
            this.MATERIALNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MATERIALDESCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tTEMPMATERIALNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tTEMPMATERIALDESCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROWNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLANT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STORE_LOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chensGroupBox2 = new ChensControl.ChensGroupBox();
            this.btn_update = new ChensControl.ChensButton();
            this.chensLabel17 = new ChensControl.ChensLabel();
            this.txt_rownum = new ChensControl.ChensTextBox();
            this.btn_delete = new ChensControl.ChensButton();
            this.btn_add = new ChensControl.ChensButton();
            this.chensLabel13 = new ChensControl.ChensLabel();
            this.txt_num = new ChensControl.ChensTextBox();
            this.chensLabel12 = new ChensControl.ChensLabel();
            this.txt_matename = new ChensControl.ChensTextBox();
            this.chensLabel11 = new ChensControl.ChensLabel();
            this.txt_mateno = new ChensControl.ChensTextBox();
            this.chensGroupBox1 = new ChensControl.ChensGroupBox();
            this.chensLabel3 = new ChensControl.ChensLabel();
            this.txt_businessName = new ChensControl.ChensTextBox();
            this.chensLabel2 = new ChensControl.ChensLabel();
            this.cmb_store = new ChensControl.ChensComboBox();
            this.chensLabel15 = new ChensControl.ChensLabel();
            this.chensLabel14 = new ChensControl.ChensLabel();
            this.txt_time = new ChensControl.ChensDateTimePicker();
            this.txt_remark = new ChensControl.ChensTextBox();
            this.txt_reason = new ChensControl.ChensTextBox();
            this.txt_sapdoc = new ChensControl.ChensTextBox();
            this.txt_taskno = new ChensControl.ChensTextBox();
            this.txt_business = new ChensControl.ChensTextBox();
            this.txt_poe = new ChensControl.ChensTextBox();
            this.txt_VOUCHERNO = new ChensControl.ChensTextBox();
            this.chensCheckBox1 = new ChensControl.ChensCheckBox();
            this.chensLabel9 = new ChensControl.ChensLabel();
            this.chensLabel8 = new ChensControl.ChensLabel();
            this.chensLabel7 = new ChensControl.ChensLabel();
            this.chensLabel6 = new ChensControl.ChensLabel();
            this.chensLabel5 = new ChensControl.ChensLabel();
            this.chensLabel4 = new ChensControl.ChensLabel();
            this.chensLabel1 = new ChensControl.ChensLabel();
            this.chensMenuStrip1 = new ChensControl.ChensMenuStrip();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.chensGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).BeginInit();
            this.chensGroupBox2.SuspendLayout();
            this.chensGroupBox1.SuspendLayout();
            this.chensMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chensGroupBox3
            // 
            this.chensGroupBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chensGroupBox3.Controls.Add(this.dgv_show);
            this.chensGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chensGroupBox3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensGroupBox3.Location = new System.Drawing.Point(0, 298);
            this.chensGroupBox3.Name = "chensGroupBox3";
            this.chensGroupBox3.Size = new System.Drawing.Size(969, 297);
            this.chensGroupBox3.TabIndex = 3;
            this.chensGroupBox3.TabStop = false;
            this.chensGroupBox3.Text = "表单信息";
            // 
            // dgv_show
            // 
            this.dgv_show.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv_show.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_show.AutoGenerateColumns = false;
            this.dgv_show.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_show.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_show.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_show.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MATERIALNODataGridViewTextBoxColumn,
            this.MATERIALDESCDataGridViewTextBoxColumn,
            this.tTEMPMATERIALNODataGridViewTextBoxColumn,
            this.tTEMPMATERIALDESCDataGridViewTextBoxColumn,
            this.TaskQty,
            this.ROWNO,
            this.PLANT_NAME,
            this.STORE_LOC});
            this.dgv_show.DataSource = this.bindingSource1;
            this.dgv_show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_show.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_show.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgv_show.GridColor = System.Drawing.Color.LightGray;
            this.dgv_show.HaveCopyMenu = true;
            this.dgv_show.Location = new System.Drawing.Point(3, 19);
            this.dgv_show.Name = "dgv_show";
            this.dgv_show.ReadOnly = true;
            this.dgv_show.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgv_show.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_show.RowTemplate.Height = 23;
            this.dgv_show.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_show.Size = new System.Drawing.Size(963, 275);
            this.dgv_show.TabIndex = 0;
            this.dgv_show.SelectionChanged += new System.EventHandler(this.dgv_show_SelectionChanged);
            // 
            // MATERIALNODataGridViewTextBoxColumn
            // 
            this.MATERIALNODataGridViewTextBoxColumn.DataPropertyName = "MaterialNo";
            this.MATERIALNODataGridViewTextBoxColumn.HeaderText = "物料编号";
            this.MATERIALNODataGridViewTextBoxColumn.Name = "MATERIALNODataGridViewTextBoxColumn";
            this.MATERIALNODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // MATERIALDESCDataGridViewTextBoxColumn
            // 
            this.MATERIALDESCDataGridViewTextBoxColumn.DataPropertyName = "MaterialDesc";
            this.MATERIALDESCDataGridViewTextBoxColumn.HeaderText = "物料名称";
            this.MATERIALDESCDataGridViewTextBoxColumn.Name = "MATERIALDESCDataGridViewTextBoxColumn";
            this.MATERIALDESCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tTEMPMATERIALNODataGridViewTextBoxColumn
            // 
            this.tTEMPMATERIALNODataGridViewTextBoxColumn.DataPropertyName = "TMaterialNo";
            this.tTEMPMATERIALNODataGridViewTextBoxColumn.HeaderText = "临时物料号";
            this.tTEMPMATERIALNODataGridViewTextBoxColumn.Name = "tTEMPMATERIALNODataGridViewTextBoxColumn";
            this.tTEMPMATERIALNODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tTEMPMATERIALDESCDataGridViewTextBoxColumn
            // 
            this.tTEMPMATERIALDESCDataGridViewTextBoxColumn.DataPropertyName = "TMaterialDesc";
            this.tTEMPMATERIALDESCDataGridViewTextBoxColumn.HeaderText = "临时物料名称";
            this.tTEMPMATERIALDESCDataGridViewTextBoxColumn.Name = "tTEMPMATERIALDESCDataGridViewTextBoxColumn";
            this.tTEMPMATERIALDESCDataGridViewTextBoxColumn.ReadOnly = true;
            this.tTEMPMATERIALDESCDataGridViewTextBoxColumn.Width = 110;
            // 
            // TaskQty
            // 
            this.TaskQty.DataPropertyName = "TaskQty";
            this.TaskQty.HeaderText = "数量";
            this.TaskQty.Name = "TaskQty";
            this.TaskQty.ReadOnly = true;
            // 
            // ROWNO
            // 
            this.ROWNO.HeaderText = "行号";
            this.ROWNO.Name = "ROWNO";
            this.ROWNO.ReadOnly = true;
            // 
            // PLANT_NAME
            // 
            this.PLANT_NAME.HeaderText = "工厂";
            this.PLANT_NAME.Name = "PLANT_NAME";
            this.PLANT_NAME.ReadOnly = true;
            // 
            // STORE_LOC
            // 
            this.STORE_LOC.HeaderText = "库存地点";
            this.STORE_LOC.Name = "STORE_LOC";
            this.STORE_LOC.ReadOnly = true;
            // 
            // chensGroupBox2
            // 
            this.chensGroupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chensGroupBox2.Controls.Add(this.btn_update);
            this.chensGroupBox2.Controls.Add(this.chensLabel17);
            this.chensGroupBox2.Controls.Add(this.txt_rownum);
            this.chensGroupBox2.Controls.Add(this.btn_delete);
            this.chensGroupBox2.Controls.Add(this.btn_add);
            this.chensGroupBox2.Controls.Add(this.chensLabel13);
            this.chensGroupBox2.Controls.Add(this.txt_num);
            this.chensGroupBox2.Controls.Add(this.chensLabel12);
            this.chensGroupBox2.Controls.Add(this.txt_matename);
            this.chensGroupBox2.Controls.Add(this.chensLabel11);
            this.chensGroupBox2.Controls.Add(this.txt_mateno);
            this.chensGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.chensGroupBox2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensGroupBox2.Location = new System.Drawing.Point(0, 186);
            this.chensGroupBox2.Name = "chensGroupBox2";
            this.chensGroupBox2.Size = new System.Drawing.Size(969, 112);
            this.chensGroupBox2.TabIndex = 2;
            this.chensGroupBox2.TabStop = false;
            this.chensGroupBox2.Text = "物料信息";
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_update.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btn_update.ForeColor = System.Drawing.Color.White;
            this.btn_update.Location = new System.Drawing.Point(811, 57);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 26);
            this.btn_update.TabIndex = 12;
            this.btn_update.Text = "修改记录";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // chensLabel17
            // 
            this.chensLabel17.AutoSize = true;
            this.chensLabel17.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel17.Location = new System.Drawing.Point(413, 30);
            this.chensLabel17.Name = "chensLabel17";
            this.chensLabel17.Size = new System.Drawing.Size(90, 17);
            this.chensLabel17.TabIndex = 11;
            this.chensLabel17.Text = "SAP物料行号：";
            // 
            // txt_rownum
            // 
            this.txt_rownum.BackColor = System.Drawing.Color.White;
            this.txt_rownum.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_rownum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_rownum.Enabled = false;
            this.txt_rownum.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txt_rownum.HotTrack = false;
            this.txt_rownum.Location = new System.Drawing.Point(416, 59);
            this.txt_rownum.Name = "txt_rownum";
            this.txt_rownum.Size = new System.Drawing.Size(100, 23);
            this.txt_rownum.TabIndex = 10;
            this.txt_rownum.TextEnabled = false;
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btn_delete.ForeColor = System.Drawing.Color.White;
            this.btn_delete.Location = new System.Drawing.Point(707, 57);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 26);
            this.btn_delete.TabIndex = 9;
            this.btn_delete.Text = "删除记录";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(253)))));
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.Location = new System.Drawing.Point(603, 57);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 26);
            this.btn_add.TabIndex = 8;
            this.btn_add.Text = "新增记录";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // chensLabel13
            // 
            this.chensLabel13.AutoSize = true;
            this.chensLabel13.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel13.Location = new System.Drawing.Point(280, 31);
            this.chensLabel13.Name = "chensLabel13";
            this.chensLabel13.Size = new System.Drawing.Size(44, 17);
            this.chensLabel13.TabIndex = 5;
            this.chensLabel13.Text = "数量：";
            // 
            // txt_num
            // 
            this.txt_num.BackColor = System.Drawing.Color.White;
            this.txt_num.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_num.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_num.Enabled = false;
            this.txt_num.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txt_num.HotTrack = false;
            this.txt_num.Location = new System.Drawing.Point(283, 60);
            this.txt_num.Name = "txt_num";
            this.txt_num.Size = new System.Drawing.Size(100, 23);
            this.txt_num.TabIndex = 4;
            this.txt_num.TextEnabled = false;
            this.txt_num.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_num_KeyDown);
            // 
            // chensLabel12
            // 
            this.chensLabel12.AutoSize = true;
            this.chensLabel12.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel12.Location = new System.Drawing.Point(151, 31);
            this.chensLabel12.Name = "chensLabel12";
            this.chensLabel12.Size = new System.Drawing.Size(68, 17);
            this.chensLabel12.TabIndex = 3;
            this.chensLabel12.Text = "物料名称：";
            // 
            // txt_matename
            // 
            this.txt_matename.BackColor = System.Drawing.Color.White;
            this.txt_matename.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_matename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_matename.Enabled = false;
            this.txt_matename.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txt_matename.HotTrack = false;
            this.txt_matename.Location = new System.Drawing.Point(154, 60);
            this.txt_matename.Name = "txt_matename";
            this.txt_matename.Size = new System.Drawing.Size(100, 23);
            this.txt_matename.TabIndex = 2;
            this.txt_matename.TextEnabled = false;
            // 
            // chensLabel11
            // 
            this.chensLabel11.AutoSize = true;
            this.chensLabel11.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel11.Location = new System.Drawing.Point(20, 31);
            this.chensLabel11.Name = "chensLabel11";
            this.chensLabel11.Size = new System.Drawing.Size(68, 17);
            this.chensLabel11.TabIndex = 1;
            this.chensLabel11.Text = "物料编号：";
            // 
            // txt_mateno
            // 
            this.txt_mateno.BackColor = System.Drawing.Color.White;
            this.txt_mateno.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_mateno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_mateno.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txt_mateno.HotTrack = false;
            this.txt_mateno.Location = new System.Drawing.Point(23, 60);
            this.txt_mateno.Name = "txt_mateno";
            this.txt_mateno.Size = new System.Drawing.Size(100, 23);
            this.txt_mateno.TabIndex = 0;
            this.txt_mateno.TextEnabled = false;
            this.txt_mateno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_mateno_KeyDown);
            // 
            // chensGroupBox1
            // 
            this.chensGroupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chensGroupBox1.Controls.Add(this.chensLabel3);
            this.chensGroupBox1.Controls.Add(this.txt_businessName);
            this.chensGroupBox1.Controls.Add(this.chensLabel2);
            this.chensGroupBox1.Controls.Add(this.cmb_store);
            this.chensGroupBox1.Controls.Add(this.chensLabel15);
            this.chensGroupBox1.Controls.Add(this.chensLabel14);
            this.chensGroupBox1.Controls.Add(this.txt_time);
            this.chensGroupBox1.Controls.Add(this.txt_remark);
            this.chensGroupBox1.Controls.Add(this.txt_reason);
            this.chensGroupBox1.Controls.Add(this.txt_sapdoc);
            this.chensGroupBox1.Controls.Add(this.txt_taskno);
            this.chensGroupBox1.Controls.Add(this.txt_business);
            this.chensGroupBox1.Controls.Add(this.txt_poe);
            this.chensGroupBox1.Controls.Add(this.txt_VOUCHERNO);
            this.chensGroupBox1.Controls.Add(this.chensCheckBox1);
            this.chensGroupBox1.Controls.Add(this.chensLabel9);
            this.chensGroupBox1.Controls.Add(this.chensLabel8);
            this.chensGroupBox1.Controls.Add(this.chensLabel7);
            this.chensGroupBox1.Controls.Add(this.chensLabel6);
            this.chensGroupBox1.Controls.Add(this.chensLabel5);
            this.chensGroupBox1.Controls.Add(this.chensLabel4);
            this.chensGroupBox1.Controls.Add(this.chensLabel1);
            this.chensGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.chensGroupBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensGroupBox1.Location = new System.Drawing.Point(0, 27);
            this.chensGroupBox1.Name = "chensGroupBox1";
            this.chensGroupBox1.Size = new System.Drawing.Size(969, 159);
            this.chensGroupBox1.TabIndex = 1;
            this.chensGroupBox1.TabStop = false;
            this.chensGroupBox1.Text = "单据信息";
            // 
            // chensLabel3
            // 
            this.chensLabel3.AutoSize = true;
            this.chensLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel3.Location = new System.Drawing.Point(303, 119);
            this.chensLabel3.Name = "chensLabel3";
            this.chensLabel3.Size = new System.Drawing.Size(80, 17);
            this.chensLabel3.TabIndex = 31;
            this.chensLabel3.Text = "供应商名称：";
            // 
            // txt_businessName
            // 
            this.txt_businessName.BackColor = System.Drawing.Color.White;
            this.txt_businessName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_businessName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_businessName.Enabled = false;
            this.txt_businessName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txt_businessName.HotTrack = false;
            this.txt_businessName.Location = new System.Drawing.Point(455, 117);
            this.txt_businessName.Name = "txt_businessName";
            this.txt_businessName.Size = new System.Drawing.Size(301, 23);
            this.txt_businessName.TabIndex = 30;
            this.txt_businessName.TextEnabled = false;
            // 
            // chensLabel2
            // 
            this.chensLabel2.AutoSize = true;
            this.chensLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel2.Location = new System.Drawing.Point(11, 119);
            this.chensLabel2.Name = "chensLabel2";
            this.chensLabel2.Size = new System.Drawing.Size(72, 17);
            this.chensLabel2.TabIndex = 29;
            this.chensLabel2.Text = " 库存地点：";
            // 
            // cmb_store
            // 
            this.cmb_store.BackColor = System.Drawing.Color.White;
            this.cmb_store.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cmb_store.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_store.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_store.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cmb_store.FormattingEnabled = true;
            this.cmb_store.HotTrack = false;
            this.cmb_store.Location = new System.Drawing.Point(89, 116);
            this.cmb_store.Name = "cmb_store";
            this.cmb_store.Size = new System.Drawing.Size(165, 25);
            this.cmb_store.TabIndex = 28;
            // 
            // chensLabel15
            // 
            this.chensLabel15.AutoSize = true;
            this.chensLabel15.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel15.Location = new System.Drawing.Point(220, 61);
            this.chensLabel15.Name = "chensLabel15";
            this.chensLabel15.Size = new System.Drawing.Size(56, 17);
            this.chensLabel15.TabIndex = 27;
            this.chensLabel15.Text = "制单人：";
            // 
            // chensLabel14
            // 
            this.chensLabel14.AutoSize = true;
            this.chensLabel14.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel14.Location = new System.Drawing.Point(220, 89);
            this.chensLabel14.Name = "chensLabel14";
            this.chensLabel14.Size = new System.Drawing.Size(56, 17);
            this.chensLabel14.TabIndex = 25;
            this.chensLabel14.Text = "供应商：";
            // 
            // txt_time
            // 
            this.txt_time.Enabled = false;
            this.txt_time.Location = new System.Drawing.Point(538, 87);
            this.txt_time.Name = "txt_time";
            this.txt_time.Size = new System.Drawing.Size(133, 23);
            this.txt_time.TabIndex = 24;
            // 
            // txt_remark
            // 
            this.txt_remark.BackColor = System.Drawing.Color.White;
            this.txt_remark.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_remark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_remark.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txt_remark.HotTrack = false;
            this.txt_remark.Location = new System.Drawing.Point(762, 87);
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.Size = new System.Drawing.Size(124, 23);
            this.txt_remark.TabIndex = 19;
            this.txt_remark.TextEnabled = false;
            // 
            // txt_reason
            // 
            this.txt_reason.BackColor = System.Drawing.Color.White;
            this.txt_reason.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_reason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_reason.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txt_reason.HotTrack = false;
            this.txt_reason.Location = new System.Drawing.Point(762, 59);
            this.txt_reason.Name = "txt_reason";
            this.txt_reason.Size = new System.Drawing.Size(124, 23);
            this.txt_reason.TabIndex = 18;
            this.txt_reason.TextEnabled = false;
            // 
            // txt_sapdoc
            // 
            this.txt_sapdoc.BackColor = System.Drawing.Color.White;
            this.txt_sapdoc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_sapdoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_sapdoc.Enabled = false;
            this.txt_sapdoc.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txt_sapdoc.HotTrack = false;
            this.txt_sapdoc.Location = new System.Drawing.Point(82, 87);
            this.txt_sapdoc.Name = "txt_sapdoc";
            this.txt_sapdoc.Size = new System.Drawing.Size(120, 23);
            this.txt_sapdoc.TabIndex = 17;
            this.txt_sapdoc.TextEnabled = false;
            // 
            // txt_taskno
            // 
            this.txt_taskno.BackColor = System.Drawing.Color.White;
            this.txt_taskno.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_taskno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_taskno.Enabled = false;
            this.txt_taskno.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txt_taskno.HotTrack = false;
            this.txt_taskno.Location = new System.Drawing.Point(538, 59);
            this.txt_taskno.Name = "txt_taskno";
            this.txt_taskno.Size = new System.Drawing.Size(133, 23);
            this.txt_taskno.TabIndex = 15;
            this.txt_taskno.TextEnabled = false;
            // 
            // txt_business
            // 
            this.txt_business.BackColor = System.Drawing.Color.White;
            this.txt_business.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_business.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_business.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txt_business.HotTrack = false;
            this.txt_business.Location = new System.Drawing.Point(306, 87);
            this.txt_business.Name = "txt_business";
            this.txt_business.Size = new System.Drawing.Size(133, 23);
            this.txt_business.TabIndex = 14;
            this.txt_business.TextEnabled = false;
            this.txt_business.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_business_KeyDown);
            // 
            // txt_poe
            // 
            this.txt_poe.BackColor = System.Drawing.Color.White;
            this.txt_poe.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_poe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_poe.Enabled = false;
            this.txt_poe.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txt_poe.HotTrack = false;
            this.txt_poe.Location = new System.Drawing.Point(306, 60);
            this.txt_poe.Name = "txt_poe";
            this.txt_poe.Size = new System.Drawing.Size(133, 23);
            this.txt_poe.TabIndex = 13;
            this.txt_poe.TextEnabled = false;
            // 
            // txt_VOUCHERNO
            // 
            this.txt_VOUCHERNO.BackColor = System.Drawing.Color.White;
            this.txt_VOUCHERNO.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_VOUCHERNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_VOUCHERNO.Enabled = false;
            this.txt_VOUCHERNO.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txt_VOUCHERNO.HotTrack = false;
            this.txt_VOUCHERNO.Location = new System.Drawing.Point(82, 59);
            this.txt_VOUCHERNO.Name = "txt_VOUCHERNO";
            this.txt_VOUCHERNO.Size = new System.Drawing.Size(120, 23);
            this.txt_VOUCHERNO.TabIndex = 12;
            this.txt_VOUCHERNO.TextEnabled = false;
            this.txt_VOUCHERNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_VOUCHERNO_KeyDown);
            // 
            // chensCheckBox1
            // 
            this.chensCheckBox1.AutoSize = true;
            this.chensCheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chensCheckBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensCheckBox1.Location = new System.Drawing.Point(89, 26);
            this.chensCheckBox1.Name = "chensCheckBox1";
            this.chensCheckBox1.Size = new System.Drawing.Size(72, 21);
            this.chensCheckBox1.TabIndex = 11;
            this.chensCheckBox1.Text = "是否过账";
            this.chensCheckBox1.Textn = "是否过账";
            this.chensCheckBox1.UseVisualStyleBackColor = true;
            this.chensCheckBox1.CheckedChanged += new System.EventHandler(this.chensCheckBox1_CheckedChanged);
            // 
            // chensLabel9
            // 
            this.chensLabel9.AutoSize = true;
            this.chensLabel9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel9.Location = new System.Drawing.Point(12, 28);
            this.chensLabel9.Name = "chensLabel9";
            this.chensLabel9.Size = new System.Drawing.Size(68, 17);
            this.chensLabel9.TabIndex = 8;
            this.chensLabel9.Text = "过账类型：";
            // 
            // chensLabel8
            // 
            this.chensLabel8.AutoSize = true;
            this.chensLabel8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel8.Location = new System.Drawing.Point(688, 89);
            this.chensLabel8.Name = "chensLabel8";
            this.chensLabel8.Size = new System.Drawing.Size(44, 17);
            this.chensLabel8.TabIndex = 7;
            this.chensLabel8.Text = "备注：";
            // 
            // chensLabel7
            // 
            this.chensLabel7.AutoSize = true;
            this.chensLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel7.Location = new System.Drawing.Point(688, 61);
            this.chensLabel7.Name = "chensLabel7";
            this.chensLabel7.Size = new System.Drawing.Size(68, 17);
            this.chensLabel7.TabIndex = 6;
            this.chensLabel7.Text = "入库原因：";
            // 
            // chensLabel6
            // 
            this.chensLabel6.AutoSize = true;
            this.chensLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel6.Location = new System.Drawing.Point(12, 89);
            this.chensLabel6.Name = "chensLabel6";
            this.chensLabel6.Size = new System.Drawing.Size(68, 17);
            this.chensLabel6.TabIndex = 5;
            this.chensLabel6.Text = "物料凭证：";
            // 
            // chensLabel5
            // 
            this.chensLabel5.AutoSize = true;
            this.chensLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel5.Location = new System.Drawing.Point(452, 89);
            this.chensLabel5.Name = "chensLabel5";
            this.chensLabel5.Size = new System.Drawing.Size(68, 17);
            this.chensLabel5.TabIndex = 4;
            this.chensLabel5.Text = "制单时间：";
            // 
            // chensLabel4
            // 
            this.chensLabel4.AutoSize = true;
            this.chensLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel4.Location = new System.Drawing.Point(452, 61);
            this.chensLabel4.Name = "chensLabel4";
            this.chensLabel4.Size = new System.Drawing.Size(80, 17);
            this.chensLabel4.TabIndex = 3;
            this.chensLabel4.Text = "上架任务号：";
            // 
            // chensLabel1
            // 
            this.chensLabel1.AutoSize = true;
            this.chensLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensLabel1.Location = new System.Drawing.Point(12, 61);
            this.chensLabel1.Name = "chensLabel1";
            this.chensLabel1.Size = new System.Drawing.Size(56, 17);
            this.chensLabel1.TabIndex = 0;
            this.chensLabel1.Text = "单据号：";
            // 
            // chensMenuStrip1
            // 
            this.chensMenuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chensMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chensMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem,
            this.取消ToolStripMenuItem});
            this.chensMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.chensMenuStrip1.Name = "chensMenuStrip1";
            this.chensMenuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.chensMenuStrip1.Size = new System.Drawing.Size(969, 27);
            this.chensMenuStrip1.TabIndex = 0;
            this.chensMenuStrip1.Text = "chensMenuStrip1";
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 取消ToolStripMenuItem
            // 
            this.取消ToolStripMenuItem.Name = "取消ToolStripMenuItem";
            this.取消ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.取消ToolStripMenuItem.Text = "取消";
            this.取消ToolStripMenuItem.Click += new System.EventHandler(this.取消ToolStripMenuItem_Click);
            // 
            // FrmAdd_FastIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(969, 595);
            this.Controls.Add(this.chensGroupBox3);
            this.Controls.Add(this.chensGroupBox2);
            this.Controls.Add(this.chensGroupBox1);
            this.Controls.Add(this.chensMenuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.chensMenuStrip1;
            this.Name = "FrmAdd_FastIn";
            this.Text = "快速入库单编辑";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.chensGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).EndInit();
            this.chensGroupBox2.ResumeLayout(false);
            this.chensGroupBox2.PerformLayout();
            this.chensGroupBox1.ResumeLayout(false);
            this.chensGroupBox1.PerformLayout();
            this.chensMenuStrip1.ResumeLayout(false);
            this.chensMenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip chensMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消ToolStripMenuItem;
        private ChensControl.ChensGroupBox chensGroupBox1;
        private ChensControl.ChensLabel chensLabel6;
        private ChensControl.ChensLabel chensLabel5;
        private ChensControl.ChensLabel chensLabel4;
        private ChensControl.ChensLabel chensLabel1;
        private ChensControl.ChensLabel chensLabel8;
        private ChensControl.ChensLabel chensLabel7;
        private ChensControl.ChensLabel chensLabel9;
        private ChensControl.ChensTextBox txt_VOUCHERNO;
        private ChensControl.ChensCheckBox chensCheckBox1;
        private ChensControl.ChensTextBox txt_remark;
        private ChensControl.ChensTextBox txt_reason;
        private ChensControl.ChensTextBox txt_sapdoc;
        private ChensControl.ChensTextBox txt_taskno;
        private ChensControl.ChensTextBox txt_business;
        private ChensControl.ChensTextBox txt_poe;
        private ChensControl.ChensGroupBox chensGroupBox2;
        private ChensControl.ChensButton btn_delete;
        private ChensControl.ChensButton btn_add;
        private ChensControl.ChensLabel chensLabel13;
        private ChensControl.ChensTextBox txt_num;
        private ChensControl.ChensLabel chensLabel12;
        private ChensControl.ChensTextBox txt_matename;
        private ChensControl.ChensLabel chensLabel11;
        private ChensControl.ChensTextBox txt_mateno;
        private ChensControl.ChensGroupBox chensGroupBox3;
        private ChensControl.ChensDataGridView dgv_show;
        private System.Windows.Forms.BindingSource bindingSource1;
        private ChensControl.ChensDateTimePicker txt_time;
        private ChensControl.ChensLabel chensLabel15;
        private ChensControl.ChensLabel chensLabel14;
        private ChensControl.ChensLabel chensLabel17;
        private ChensControl.ChensTextBox txt_rownum;
        private System.Windows.Forms.DataGridViewTextBoxColumn tMATERIALNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tMATERIALDESCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pACKQTYDataGridViewTextBoxColumn;
        private ChensControl.ChensButton btn_update;
        private System.Windows.Forms.DataGridViewTextBoxColumn MATERIALNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MATERIALDESCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tTEMPMATERIALNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tTEMPMATERIALDESCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROWNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLANT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn STORE_LOC;
        private ChensControl.ChensLabel chensLabel2;
        private ChensControl.ChensComboBox cmb_store;
        private ChensControl.ChensLabel chensLabel3;
        private ChensControl.ChensTextBox txt_businessName;
    }
}