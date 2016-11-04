namespace JingXinWMS.Task
{
    partial class FrmTaskTrans
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
            ChensControl.DividPage dividPage1 = new ChensControl.DividPage();
            this.msMain = new ChensControl.ChensMenuStrip();
            this.tsmiCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.gbMiddle = new ChensControl.ChensGroupBox();
            this.dgvList = new ChensControl.ChensDataGridView();
            this.pageList = new ChensControl.ChensPage();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMATERIALNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMATERIALDESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFROMAREANO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTOAREANO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCREATEUSERNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCREATEDATETIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTASKNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBARCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSERIALNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVOUCHERTYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTASKTYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSUPCUSNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWBS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTMATERIALNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTMATERIALDESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msMain.SuspendLayout();
            this.gbMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
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
            this.msMain.TabIndex = 0;
            this.msMain.Text = "chensMenuStrip1";
            // 
            // tsmiCancel
            // 
            this.tsmiCancel.Name = "tsmiCancel";
            this.tsmiCancel.Size = new System.Drawing.Size(44, 21);
            this.tsmiCancel.Text = "关闭";
            this.tsmiCancel.Click += new System.EventHandler(this.tsmiCancel_Click);
            // 
            // gbMiddle
            // 
            this.gbMiddle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbMiddle.Controls.Add(this.dgvList);
            this.gbMiddle.Controls.Add(this.pageList);
            this.gbMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMiddle.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbMiddle.Location = new System.Drawing.Point(0, 25);
            this.gbMiddle.Name = "gbMiddle";
            this.gbMiddle.Size = new System.Drawing.Size(992, 444);
            this.gbMiddle.TabIndex = 13;
            this.gbMiddle.TabStop = false;
            this.gbMiddle.Text = "扫描记录";
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
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colMATERIALNO,
            this.colMATERIALDESC,
            this.colFROMAREANO,
            this.colTOAREANO,
            this.colQTY,
            this.colCREATEUSERNO,
            this.colCREATEDATETIME,
            this.colTASKNO,
            this.colBARCODE,
            this.colSERIALNO,
            this.colVOUCHERTYPE,
            this.colTASKTYPE,
            this.colSUPCUSNAME,
            this.colWBS,
            this.colTMATERIALNO,
            this.colTMATERIALDESC});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvList.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgvList.GridColor = System.Drawing.Color.LightGray;
            this.dgvList.HaveCopyMenu = true;
            this.dgvList.Location = new System.Drawing.Point(3, 19);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(986, 395);
            this.dgvList.TabIndex = 1;
            // 
            // pageList
            // 
            this.pageList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pageList.CurrentPageNumber = 0;
            dividPage1.CurrentPageNumber = 0;
            dividPage1.CurrentPageRecordCounts = 0;
            dividPage1.CurrentPageShowCounts = 10;
            dividPage1.DefaultPageShowCounts = 10;
            dividPage1.PagesCount = 0;
            dividPage1.RecordCounts = 0;
            this.pageList.dDividPage = dividPage1;
            this.pageList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageList.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pageList.Location = new System.Drawing.Point(3, 414);
            this.pageList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(986, 27);
            this.pageList.TabIndex = 0;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colMATERIALNO
            // 
            this.colMATERIALNO.DataPropertyName = "MATERIALNO";
            this.colMATERIALNO.HeaderText = "物料编号";
            this.colMATERIALNO.Name = "colMATERIALNO";
            this.colMATERIALNO.ReadOnly = true;
            this.colMATERIALNO.Width = 150;
            // 
            // colMATERIALDESC
            // 
            this.colMATERIALDESC.DataPropertyName = "MATERIALDESC";
            this.colMATERIALDESC.HeaderText = "物料描述";
            this.colMATERIALDESC.Name = "colMATERIALDESC";
            this.colMATERIALDESC.ReadOnly = true;
            this.colMATERIALDESC.Width = 200;
            // 
            // colFROMAREANO
            // 
            this.colFROMAREANO.DataPropertyName = "FROMAREANO";
            this.colFROMAREANO.HeaderText = "清点货位";
            this.colFROMAREANO.Name = "colFROMAREANO";
            this.colFROMAREANO.ReadOnly = true;
            // 
            // colTOAREANO
            // 
            this.colTOAREANO.DataPropertyName = "TOAREANO";
            this.colTOAREANO.HeaderText = "入库货位";
            this.colTOAREANO.Name = "colTOAREANO";
            this.colTOAREANO.ReadOnly = true;
            // 
            // colQTY
            // 
            this.colQTY.DataPropertyName = "QTY";
            this.colQTY.HeaderText = "整箱数量";
            this.colQTY.Name = "colQTY";
            this.colQTY.ReadOnly = true;
            // 
            // colCREATEUSERNO
            // 
            this.colCREATEUSERNO.DataPropertyName = "CREATEUSERNO";
            this.colCREATEUSERNO.HeaderText = "创建人";
            this.colCREATEUSERNO.Name = "colCREATEUSERNO";
            this.colCREATEUSERNO.ReadOnly = true;
            this.colCREATEUSERNO.Visible = false;
            // 
            // colCREATEDATETIME
            // 
            this.colCREATEDATETIME.DataPropertyName = "CREATEDATETIME";
            this.colCREATEDATETIME.HeaderText = "扫描时间";
            this.colCREATEDATETIME.Name = "colCREATEDATETIME";
            this.colCREATEDATETIME.ReadOnly = true;
            this.colCREATEDATETIME.Width = 130;
            // 
            // colTASKNO
            // 
            this.colTASKNO.DataPropertyName = "TASKNO";
            this.colTASKNO.HeaderText = "任务号";
            this.colTASKNO.Name = "colTASKNO";
            this.colTASKNO.ReadOnly = true;
            this.colTASKNO.Visible = false;
            // 
            // colBARCODE
            // 
            this.colBARCODE.DataPropertyName = "BARCODE";
            this.colBARCODE.HeaderText = "条码";
            this.colBARCODE.Name = "colBARCODE";
            this.colBARCODE.ReadOnly = true;
            this.colBARCODE.Visible = false;
            // 
            // colSERIALNO
            // 
            this.colSERIALNO.DataPropertyName = "SERIALNO";
            this.colSERIALNO.HeaderText = "流水号";
            this.colSERIALNO.Name = "colSERIALNO";
            this.colSERIALNO.ReadOnly = true;
            // 
            // colVOUCHERTYPE
            // 
            this.colVOUCHERTYPE.DataPropertyName = "VOUCHERTYPE";
            this.colVOUCHERTYPE.HeaderText = "入库类型";
            this.colVOUCHERTYPE.Name = "colVOUCHERTYPE";
            this.colVOUCHERTYPE.ReadOnly = true;
            this.colVOUCHERTYPE.Visible = false;
            // 
            // colTASKTYPE
            // 
            this.colTASKTYPE.DataPropertyName = "TASKTYPE";
            this.colTASKTYPE.HeaderText = "任务类型";
            this.colTASKTYPE.Name = "colTASKTYPE";
            this.colTASKTYPE.ReadOnly = true;
            this.colTASKTYPE.Visible = false;
            // 
            // colSUPCUSNAME
            // 
            this.colSUPCUSNAME.DataPropertyName = "SUPCUSNAME";
            this.colSUPCUSNAME.HeaderText = "供应商";
            this.colSUPCUSNAME.Name = "colSUPCUSNAME";
            this.colSUPCUSNAME.ReadOnly = true;
            this.colSUPCUSNAME.Visible = false;
            // 
            // colWBS
            // 
            this.colWBS.DataPropertyName = "WBS";
            this.colWBS.HeaderText = "项目号";
            this.colWBS.Name = "colWBS";
            this.colWBS.ReadOnly = true;
            this.colWBS.Visible = false;
            // 
            // colTMATERIALNO
            // 
            this.colTMATERIALNO.DataPropertyName = "TMATERIALNO";
            this.colTMATERIALNO.HeaderText = "WMS临时物料号";
            this.colTMATERIALNO.Name = "colTMATERIALNO";
            this.colTMATERIALNO.ReadOnly = true;
            this.colTMATERIALNO.Visible = false;
            // 
            // colTMATERIALDESC
            // 
            this.colTMATERIALDESC.DataPropertyName = "TMATERIALDESC";
            this.colTMATERIALDESC.HeaderText = "WMS临时物料描述";
            this.colTMATERIALDESC.Name = "colTMATERIALDESC";
            this.colTMATERIALDESC.ReadOnly = true;
            this.colTMATERIALDESC.Visible = false;
            // 
            // FrmTaskTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 469);
            this.Controls.Add(this.gbMiddle);
            this.Controls.Add(this.msMain);
            this.Name = "FrmTaskTrans";
            this.Text = "入库扫描记录";
            this.Load += new System.EventHandler(this.FrmInTrans_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.gbMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChensControl.ChensMenuStrip msMain;
        private ChensControl.ChensGroupBox gbMiddle;
        private ChensControl.ChensDataGridView dgvList;
        private ChensControl.ChensPage pageList;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMATERIALNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMATERIALDESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFROMAREANO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTOAREANO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCREATEUSERNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCREATEDATETIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTASKNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBARCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSERIALNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVOUCHERTYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTASKTYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSUPCUSNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWBS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTMATERIALNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTMATERIALDESC;
    }
}