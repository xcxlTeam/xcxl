namespace ChensControl
{
    partial class ChensReference
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
            this.lblInner = new System.Windows.Forms.Label();
            this.btnRefer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInner
            // 
            this.lblInner.AutoSize = true;
            this.lblInner.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInner.Location = new System.Drawing.Point(2, 2);
            this.lblInner.Name = "lblInner";
            this.lblInner.Size = new System.Drawing.Size(0, 17);
            this.lblInner.TabIndex = 3;
            // 
            // btnRefer
            // 
            this.btnRefer.BackColor = System.Drawing.SystemColors.Window;
            this.btnRefer.BackgroundImage = global::ChensControl.Properties.Resources.grey_search2;
            this.btnRefer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefer.Location = new System.Drawing.Point(115, 0);
            this.btnRefer.Name = "btnRefer";
            this.btnRefer.Size = new System.Drawing.Size(19, 19);
            this.btnRefer.TabIndex = 2;
            this.btnRefer.TabStop = false;
            this.btnRefer.Click += new System.EventHandler(this.btnRefer_Click);
            // 
            // ChensReference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.lblInner);
            this.Controls.Add(this.btnRefer);
            this.Name = "ChensReference";
            this.Size = new System.Drawing.Size(170, 40);
            this.Load += new System.EventHandler(this.ChensReference_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ChensReference_Paint);
            this.Resize += new System.EventHandler(this.ChensReference_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.btnRefer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnRefer;
        private System.Windows.Forms.Label lblInner;
    }
}
