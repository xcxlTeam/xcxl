namespace ChensControl
{
    partial class ChensPage
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkFirst = new System.Windows.Forms.LinkLabel();
            this.linkPrevious = new System.Windows.Forms.LinkLabel();
            this.linkNext = new System.Windows.Forms.LinkLabel();
            this.linkLast = new System.Windows.Forms.LinkLabel();
            this.lblPages = new System.Windows.Forms.Label();
            this.txtPageRecords = new ChensControl.ChensTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(25, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "记录数:";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRecords.Location = new System.Drawing.Point(72, 0);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(63, 17);
            this.lblRecords.TabIndex = 1;
            this.lblRecords.Text = "35/16789";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(156, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "每页显示";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(278, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "记录";
            // 
            // linkFirst
            // 
            this.linkFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkFirst.AutoSize = true;
            this.linkFirst.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkFirst.Location = new System.Drawing.Point(397, 0);
            this.linkFirst.Name = "linkFirst";
            this.linkFirst.Size = new System.Drawing.Size(32, 17);
            this.linkFirst.TabIndex = 5;
            this.linkFirst.TabStop = true;
            this.linkFirst.Text = "首页";
            this.linkFirst.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFirst_LinkClicked);
            // 
            // linkPrevious
            // 
            this.linkPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkPrevious.AutoSize = true;
            this.linkPrevious.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkPrevious.Location = new System.Drawing.Point(440, 0);
            this.linkPrevious.Name = "linkPrevious";
            this.linkPrevious.Size = new System.Drawing.Size(32, 17);
            this.linkPrevious.TabIndex = 6;
            this.linkPrevious.TabStop = true;
            this.linkPrevious.Text = "上页";
            this.linkPrevious.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPrevious_LinkClicked);
            // 
            // linkNext
            // 
            this.linkNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkNext.AutoSize = true;
            this.linkNext.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkNext.Location = new System.Drawing.Point(483, 0);
            this.linkNext.Name = "linkNext";
            this.linkNext.Size = new System.Drawing.Size(32, 17);
            this.linkNext.TabIndex = 7;
            this.linkNext.TabStop = true;
            this.linkNext.Text = "下页";
            this.linkNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkNext_LinkClicked);
            // 
            // linkLast
            // 
            this.linkLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLast.AutoSize = true;
            this.linkLast.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLast.Location = new System.Drawing.Point(530, 0);
            this.linkLast.Name = "linkLast";
            this.linkLast.Size = new System.Drawing.Size(32, 17);
            this.linkLast.TabIndex = 8;
            this.linkLast.TabStop = true;
            this.linkLast.Text = "末页";
            this.linkLast.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLast_LinkClicked);
            // 
            // lblPages
            // 
            this.lblPages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPages.AutoSize = true;
            this.lblPages.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPages.Location = new System.Drawing.Point(590, 0);
            this.lblPages.Name = "lblPages";
            this.lblPages.Size = new System.Drawing.Size(35, 17);
            this.lblPages.TabIndex = 9;
            this.lblPages.Text = "1/50";
            // 
            // txtPageRecords
            // 
            this.txtPageRecords.BackColor = System.Drawing.Color.White;
            this.txtPageRecords.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtPageRecords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPageRecords.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPageRecords.HotTrack = false;
            this.txtPageRecords.Location = new System.Drawing.Point(210, -2);
            this.txtPageRecords.Name = "txtPageRecords";
            this.txtPageRecords.Size = new System.Drawing.Size(62, 23);
            this.txtPageRecords.TabIndex = 3;
            this.txtPageRecords.TextEnabled = false;
            this.txtPageRecords.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPageRecords_KeyDown);
            // 
            // ChensPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lblPages);
            this.Controls.Add(this.linkLast);
            this.Controls.Add(this.linkNext);
            this.Controls.Add(this.linkPrevious);
            this.Controls.Add(this.linkFirst);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPageRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ChensPage";
            this.Size = new System.Drawing.Size(700, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label3;
        private ChensTextBox txtPageRecords;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkFirst;
        private System.Windows.Forms.LinkLabel linkPrevious;
        private System.Windows.Forms.LinkLabel linkNext;
        private System.Windows.Forms.LinkLabel linkLast;
        private System.Windows.Forms.Label lblPages;
    }
}
