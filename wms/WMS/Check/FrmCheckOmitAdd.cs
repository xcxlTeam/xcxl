using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS.WebService;

namespace WMS.Check
{
    public partial class FrmCheckOmitAdd  : Common.FrmBasic
    {
        List<Barcode_Model> lstBarcode;
        Barcode_Model barcode;
        AreaInfo areainfo;
        public FrmCheckOmitAdd()
        {
            InitializeComponent();
            lstBarcode = new List<Barcode_Model>();
        }

        private void FrmCheckOmitAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.Common_Func.RemoveTabPageForm(this);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            BindList();
        }

        private void BindList()
        {
            string strErrMsg = string.Empty;
            if (areainfo==null)
            {
                strErrMsg = "请先输入一个有效的货位！";
                MessageBox.Show(strErrMsg);
                return;
            }
            try
            {
                barcode = WMS.Common.WMSWebService.service.GetCheckBarcodeInfo(txtBarcode.Text.Trim(), ref strErrMsg);
                if(barcode==null||!string.IsNullOrEmpty(strErrMsg))
                {
                    if (string.IsNullOrEmpty(strErrMsg))
                        strErrMsg = "条码有误！";
                    throw new Exception(strErrMsg);
                }
                if (!WMS.Common.WMSWebService.service.SaveCheckOmitAdd(barcode.SERIALNO, areainfo, ref strErrMsg))
                {
                    throw new Exception(strErrMsg);
                }
                barcode.AreaNo = areainfo.AreaNo;
                lstBarcode.Add(barcode);
                chensDataGridView1.DataSource = lstBarcode;
                chensDataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                MessageBox.Show(strErrMsg);
            }
            finally
            {
                txtBarcode.SelectAll();
                txtBarcode.Focus();
            }
        }

        private void txtAreaNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    this.Cursor = Cursors.WaitCursor;
                    string strError = string.Empty;
                    if (!WMS.Common.WMSWebService.service.GetAreaInfoByAreaNo(txtAreaNo.Text, ref areainfo, ref strError))
                    {
                        MessageBox.Show("查询失败:" + strError);
                        return;
                    }
                    lblAreaNo.Text = areainfo.AreaNo;
                }
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "程序异常");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
