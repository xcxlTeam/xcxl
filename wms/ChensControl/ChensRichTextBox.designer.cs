namespace ChensControl
{
    partial class ChensRichTextBox
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
            this.txtInner = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtInner
            // 
            this.txtInner.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInner.Location = new System.Drawing.Point(21, 17);
            this.txtInner.Multiline = true;
            this.txtInner.Name = "txtInner";
            this.txtInner.Size = new System.Drawing.Size(180, 21);
            this.txtInner.TabIndex = 1;
            // 
            // ChensRichTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtInner);
            this.Name = "ChensRichTextBox";
            this.Size = new System.Drawing.Size(326, 139);
            this.Load += new System.EventHandler(this.ChensRichTextBox_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ChensRichTextBox_Paint);
            this.Resize += new System.EventHandler(this.ChensRichTextBox_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInner;
    }
}
