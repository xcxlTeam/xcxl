namespace WMS.Check
{
    partial class FrmCheckProfitLoss
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            ChensControl.DividPage dividPage1 = new ChensControl.DividPage();
            this.gbBottom = new ChensControl.ChensGroupBox();
            this.dgvList = new ChensControl.ChensDataGridView();
            this.pageList = new ChensControl.ChensPage();
            this.colCheckNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStrCheckType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarehouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarehouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAreaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScanWarehouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScanHouseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScanAreaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScanQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStrProfitLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDifferenceQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // gbBottom
            // 
            this.gbBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbBottom.Controls.Add(this.dgvList);
            this.gbBottom.Controls.Add(this.pageList);
            this.gbBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBottom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gbBottom.Location = new System.Drawing.Point(0, 0);
            this.gbBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBottom.Name = "gbBottom";
            this.gbBottom.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBottom.Size = new System.Drawing.Size(992, 469);
            this.gbBottom.TabIndex = 7;
            this.gbBottom.TabStop = false;
            this.gbBottom.Text = "盈亏明细";
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheckNo,
            this.colCheckType,
            this.colStrCheckType,
            this.colWarehouseNo,
            this.colWarehouseName,
            this.colHouseNo,
            this.colHouseName,
            this.colAreaNo,
            this.colAreaName,
            this.colScanWarehouseNo,
            this.colScanHouseNo,
            this.colScanAreaNo,
            this.colBarcode,
            this.colSerialNo,
            this.colMaterialNo,
            this.colMaterialDesc,
            this.colBatchNo,
            this.colSN,
            this.colAccountQty,
            this.colScanQty,
            this.colStrProfitLoss,
            this.colDifferenceQty});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvList.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dgvList.GridColor = System.Drawing.Color.LightGray;
            this.dgvList.HaveCopyMenu = true;
            this.dgvList.Location = new System.Drawing.Point(3, 20);
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
            this.dgvList.Size = new System.Drawing.Size(986, 425);
            this.dgvList.TabIndex = 2;
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
            this.pageList.Location = new System.Drawing.Point(3, 445);
            this.pageList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(986, 20);
            this.pageList.TabIndex = 1;
            this.pageList.ChensPageChange += new ChensControl.ChensPage.PageChangeHandle(this.pageList_ChensPageChange);
            // 
            // colCheckNo
            // 
            this.colCheckNo.DataPropertyName = "CheckNo";
            this.colCheckNo.HeaderText = "盘点单号";
            this.colCheckNo.Name = "colCheckNo";
            this.colCheckNo.Visible = false;
            // 
            // colCheckType
            // 
            this.colCheckType.DataPropertyName = "CheckType";
            this.colCheckType.HeaderText = "盘点类型";
            this.colCheckType.Name = "colCheckType";
            this.colCheckType.Visible = false;
            // 
            // colStrCheckType
            // 
            this.colStrCheckType.DataPropertyName = "StrCheckType";
            this.colStrCheckType.HeaderText = "盘点类型";
            this.colStrCheckType.Name = "colStrCheckType";
            this.colStrCheckType.Visible = false;
            // 
            // colWarehouseNo
            // 
            this.colWarehouseNo.DataPropertyName = "WarehouseNo";
            this.colWarehouseNo.HeaderText = "仓库编号";
            this.colWarehouseNo.Name = "colWarehouseNo";
            this.colWarehouseNo.Visible = false;
            // 
            // colWarehouseName
            // 
            this.colWarehouseName.DataPropertyName = "WarehouseName";
            this.colWarehouseName.HeaderText = "仓库名称";
            this.colWarehouseName.Name = "colWarehouseName";
            this.colWarehouseName.Visible = false;
            // 
            // colHouseNo
            // 
            this.colHouseNo.DataPropertyName = "HouseNo";
            this.colHouseNo.HeaderText = "库区编号";
            this.colHouseNo.Name = "colHouseNo";
            this.colHouseNo.Visible = false;
            this.colHouseNo.Width = 150;
            // 
            // colHouseName
            // 
            this.colHouseName.DataPropertyName = "HouseName";
            this.colHouseName.HeaderText = "库区名称";
            this.colHouseName.Name = "colHouseName";
            this.colHouseName.Visible = false;
            // 
            // colAreaNo
            // 
            this.colAreaNo.DataPropertyName = "AreaNo";
            this.colAreaNo.HeaderText = "账存货位";
            this.colAreaNo.Name = "colAreaNo";
            // 
            // colAreaName
            // 
            this.colAreaName.DataPropertyName = "AreaName";
            this.colAreaName.HeaderText = "货位名称";
            this.colAreaName.Name = "colAreaName";
            this.colAreaName.Visible = false;
            // 
            // colScanWarehouseNo
            // 
            this.colScanWarehouseNo.DataPropertyName = "ScanWarehouseNo";
            this.colScanWarehouseNo.HeaderText = "实盘仓库";
            this.colScanWarehouseNo.Name = "colScanWarehouseNo";
            this.colScanWarehouseNo.Visible = false;
            // 
            // colScanHouseNo
            // 
            this.colScanHouseNo.DataPropertyName = "ScanHouseNo";
            this.colScanHouseNo.HeaderText = "实盘库区";
            this.colScanHouseNo.Name = "colScanHouseNo";
            this.colScanHouseNo.Visible = false;
            // 
            // colScanAreaNo
            // 
            this.colScanAreaNo.DataPropertyName = "ScanAreaNo";
            this.colScanAreaNo.HeaderText = "实盘货位";
            this.colScanAreaNo.Name = "colScanAreaNo";
            // 
            // colBarcode
            // 
            this.colBarcode.DataPropertyName = "Barcode";
            this.colBarcode.HeaderText = "扫描条码";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.Visible = false;
            // 
            // colSerialNo
            // 
            this.colSerialNo.DataPropertyName = "SerialNo";
            this.colSerialNo.HeaderText = "序列号";
            this.colSerialNo.Name = "colSerialNo";
            // 
            // colMaterialNo
            // 
            this.colMaterialNo.DataPropertyName = "MaterialNo";
            this.colMaterialNo.HeaderText = "物料编号";
            this.colMaterialNo.Name = "colMaterialNo";
            this.colMaterialNo.Width = 150;
            // 
            // colMaterialDesc
            // 
            this.colMaterialDesc.DataPropertyName = "MaterialDesc";
            this.colMaterialDesc.HeaderText = "物料描述";
            this.colMaterialDesc.Name = "colMaterialDesc";
            this.colMaterialDesc.Width = 200;
            // 
            // colBatchNo
            // 
            this.colBatchNo.DataPropertyName = "BatchNo";
            this.colBatchNo.HeaderText = "生产批次";
            this.colBatchNo.Name = "colBatchNo";
            // 
            // colSN
            // 
            this.colSN.DataPropertyName = "SN";
            this.colSN.HeaderText = "来料批次";
            this.colSN.Name = "colSN";
            // 
            // colAccountQty
            // 
            this.colAccountQty.DataPropertyName = "AccountQty";
            this.colAccountQty.HeaderText = "账存数量";
            this.colAccountQty.Name = "colAccountQty";
            // 
            // colScanQty
            // 
            this.colScanQty.DataPropertyName = "ScanQty";
            this.colScanQty.HeaderText = "实盘数量";
            this.colScanQty.Name = "colScanQty";
            // 
            // colStrProfitLoss
            // 
            this.colStrProfitLoss.DataPropertyName = "StrProfitLoss";
            this.colStrProfitLoss.HeaderText = "盈亏状态";
            this.colStrProfitLoss.Name = "colStrProfitLoss";
            // 
            // colDifferenceQty
            // 
            this.colDifferenceQty.DataPropertyName = "DifferenceQty";
            this.colDifferenceQty.HeaderText = "盈亏数量";
            this.colDifferenceQty.Name = "colDifferenceQty";
            // 
            // FrmCheckProfitLoss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 469);
            this.Controls.Add(this.gbBottom);
            this.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.Name = "FrmCheckProfitLoss";
            this.Text = "盈亏明细";
            this.Load += new System.EventHandler(this.FrmCheckProfitLoss_Load);
            this.gbBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ChensControl.ChensGroupBox gbBottom;
        private ChensControl.ChensDataGridView dgvList;
        private ChensControl.ChensPage pageList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStrCheckType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWarehouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWarehouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAreaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAreaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScanWarehouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScanHouseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScanAreaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScanQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStrProfitLoss;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDifferenceQty;

    }
}