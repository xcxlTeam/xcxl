using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS.WebService;

namespace WMS.Warehouse
{

    /// <summary>
    /// 核心功能界面
    /// </summary>
    public partial class FrmAllot  : Common.FrmBasic
    {
        private ProdHead  _prod;
        private List<ProdHead> _lstprod;
        private List<ProdDetails> lstproddetails;
        public FrmAllot()
        {
            InitializeComponent();
        }

        private void chensButton2_Click(object sender, EventArgs e)
        {
            //TODO: 刷新订单数据
            //MessageBox.Show("123");
            //MessageBox.Show("456");
        }

        #region Function
        void InitForm()
        {
            _prod = new ProdHead();
            _lstprod = new List<ProdHead>();
            lstproddetails = new List<ProdDetails>();
        }

        private void GetListQueryData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bool bResult = false;
                string strErr = string.Empty;

                bResult = Warehouse_Func.GetAllotData(_lstprod, ref _prod, ref strErr);

                dgvData.DataSource = _prod.lstDetails;

                if (!bResult || !string.IsNullOrEmpty(strErr)) Common.Common_Func.ErrorMessage(strErr, "查询失败");
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "查询失败");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion
    }
}
