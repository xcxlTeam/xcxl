using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChensControl
{
    public partial class ChensPage : UserControl
    {
        private int _DefaultPageShowCounts = 10;
        //
        // 摘要: 
        //     获取或设置一个值，该值指示初始每页显示多少行数据。
        //
        // 返回结果: 
        //     表示控件每页显示行数（以行为单位）。
        [DefaultValue(10)]
        [System.ComponentModel.Description("获取或设置一个值，该值指示初始每页显示多少行数据。(已停用)"), System.ComponentModel.Category("Power Properties")]
        public int DefaultPageShowCounts
        {
            get { return _DefaultPageShowCounts; }
            set { _DefaultPageShowCounts = value; }
        }

        public ChensPage()
        {
            this.Font = ControlCommon.GetDefaultFont();
            this.BackColor = System.Drawing.Color.White;

            InitializeComponent();
            _dDividPage = new DividPage(DefaultPageShowCounts);
            this.CurrentPageShowCounts = DefaultPageShowCounts;
            this.txtPageRecords.Text = CurrentPageShowCounts.ToString();

            ShowPage();
        }

        //定义委托
        public delegate void PageChangeHandle(object sender, EventArgs e);

        //定义事件
        public event PageChangeHandle ChensPageChange;

        private DividPage _dDividPage;

        public DividPage dDividPage
        {
            get
            {
                return _dDividPage;
            }
            set
            {
                _dDividPage = value;
            }
        }

        [DefaultValue(10)]
        [System.ComponentModel.Description("获取或设置一个值，该值指示每页显示多少行数据。"), System.ComponentModel.Category("Power Properties")]
        public int CurrentPageShowCounts
        {
            get
            {
                return _dDividPage.CurrentPageShowCounts;
            }
            set
            {
                _dDividPage.CurrentPageShowCounts = value;
            }
        }

        [DefaultValue(1)]
        [System.ComponentModel.Description("获取或设置一个值，该值指示当前显示页数。"), System.ComponentModel.Category("Power Properties")]
        public int CurrentPageNumber
        {
            get
            {
                return _dDividPage.CurrentPageNumber;
            }
            set
            {
                _dDividPage.CurrentPageNumber = value;
            }
        }

        /// <summary>
        /// 根据DataGridView获取每页显示行数
        /// </summary>
        /// <param name="dgv"></param>
        public void GetShowCountsByDGV(DataGridView dgv)
        {
            this._dDividPage.CurrentPageNumber = 1;
            if (dgv.Height - dgv.ColumnHeadersHeight <= dgv.RowTemplate.Height || dgv.RowTemplate.Height <= 0) return;
            this._dDividPage.CurrentPageShowCounts = Convert.ToInt32(Math.Floor((decimal)(dgv.Height - dgv.ColumnHeadersHeight) / (decimal)dgv.RowTemplate.Height)) - 1;
        }

        /// <summary>
        /// 显示或更新分页信息
        /// </summary>
        public void ShowPage()
        {
            if (_dDividPage == null || _dDividPage.RecordCounts <= 0)
            {
                this.ClearAll();
                return;
            }

            lblRecords.Text = _dDividPage.GetRecordsDescribe();
            lblPages.Text = _dDividPage.GetPagesDescribe();
            txtPageRecords.Enabled = true;
            txtPageRecords.Text = _dDividPage.CurrentPageShowCounts.ToString();


            linkFirst.Enabled = _dDividPage.CanLinkFirst();
            linkPrevious.Enabled = _dDividPage.CanLinkPrevious();
            linkNext.Enabled = _dDividPage.CanLinkNext();
            linkLast.Enabled = _dDividPage.CanLinkLast();


        }

        private void ClearAll()
        {
            lblPages.Text = "";
            lblRecords.Text = "没有数据";
            txtPageRecords.Text = "";
            txtPageRecords.Enabled = false;

            linkFirst.Enabled = false;
            linkPrevious.Enabled = false;
            linkNext.Enabled = false;
            linkLast.Enabled = false;

        }

        private void linkFirst_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _dDividPage.CurrentPageNumber = 1;
            if (ChensPageChange != null) ChensPageChange(sender, e);
        }

        private void linkPrevious_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _dDividPage.CurrentPageNumber -= 1;
            if (ChensPageChange != null) ChensPageChange(sender, e);
        }

        private void linkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _dDividPage.CurrentPageNumber += 1;
            if (ChensPageChange != null) ChensPageChange(sender, e);
        }

        private void linkLast_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _dDividPage.CurrentPageNumber = _dDividPage.PagesCount;
            if (ChensPageChange != null) ChensPageChange(sender, e);
        }

        private void txtPageRecords_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    int i = _DefaultPageShowCounts;
                    if (!TransferInt(ref i))
                    {
                        MessageBox.Show("请输入正整数!");
                        return;
                    }

                    _dDividPage.CurrentPageShowCounts = i;
                    _dDividPage.CurrentPageNumber = 1;

                    if (ChensPageChange != null) ChensPageChange(sender, e);
                }
                catch (Exception ex)
                {
                    if (ex.Message.IndexOf("若要增加配额") >= 0)
                    {
                        MessageBox.Show("返回数据大于Webservice回传最大值");
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        public void AutoGetRows(DataGridView dgv)
        {
            int iRows = Convert.ToInt32(Math.Floor((decimal)dgv.Height / (decimal)dgv.RowTemplate.Height));
            if (iRows < DefaultPageShowCounts) iRows = DefaultPageShowCounts;
            this.CurrentPageShowCounts = iRows; ;
        }

        private bool TransferInt(ref int i)
        {
            if (string.IsNullOrEmpty(txtPageRecords.Text)) return false;

            try
            {
                i = Convert.ToInt32(txtPageRecords.Text.Trim());
                return i >= 1;
            }
            catch
            {
                return false;
            }
        }
    }
}
