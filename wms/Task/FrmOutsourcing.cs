using JingXinWMS.JXWebService;
using JingXinWMS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;


namespace JingXinWMS.Task
{
    public partial class FrmOutsourcing : Common.FrmBasic
    {
        private Supplier_Model supplier;

        private DividPage _serverMainPage;
        private DeliveryReceive_Model queryMain;
        private BindingList<DeliveryReceiveDetail_Model> lstMain;

        public FrmOutsourcing()
        {
            InitializeComponent();

            this.dgvList.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

            this.bsUser.DataSource = Common.Common_Var.CurrentUser;
        }

        private void FrmOutsourcing_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void txtDeliveryNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Cursor = Cursors.WaitCursor;

                    GetListQueryData();
                }
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "查询送货单异常");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void txtSupCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Cursor = Cursors.WaitCursor;

                    GetSupplier();
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

        private void tsmiSearch_Click(object sender, EventArgs e)
        {
            GetListQueryData();
        }

        private void tsmiPost_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("是否过账?","过账提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.No)
            {
                return;
            }
            PostOutsourcing();
        }

        private void cbxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    this.Cursor = Cursors.WaitCursor;

            //    if (!Common.Common_Func.CheckDgvClick(dgvList, e.RowIndex)) return;

            //    if (e.ColumnIndex == colSelect.Index)
            //    {
            //        SetSelected(e.RowIndex);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Common.Common_Func.ErrorMessage(ex.Message, "程序异常");
            //}
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvList_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll) return;

            cbxSelectAll.Visible = e.NewValue == 0;
        }

        #region Function

        private void InitForm()
        {
            InitMainQuery();
        }

        private void InitMainQuery()
        {
            supplier = null;

            _serverMainPage = new DividPage();
            queryMain = new DeliveryReceive_Model();
            lstMain = new BindingList<DeliveryReceiveDetail_Model>();

            bsMain.DataSource = queryMain;

            txtOutSideSupCode.Text = "";
            txtOutSideSupCode.Enabled = false;

            cbxSelectAll.Width = colSelect.Width;
            cbxSelectAll.BackColor = dgvList.ColumnHeadersDefaultCellStyle.BackColor;
            cbxSelectAll.Font = dgvList.ColumnHeadersDefaultCellStyle.Font;
        }

        private void BindList()
        {
            GetListQueryData();
        }

        private void GetListQueryData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bsMain.EndEdit();

                bool bResult = false;
                string strError = string.Empty;
                GetQueryMain();

                bResult = Task_Func.GetDeliveryInfoToSRM(ref queryMain, ref strError);
                bsMain.DataSource = queryMain;

                if (!bResult || !string.IsNullOrEmpty(strError)) Common.Common_Func.ErrorMessage(strError, "查询失败");

                if (queryMain.lstDeliveryDetail == null || queryMain.lstDeliveryDetail.Count <= 0)
                {
                    lstMain = new BindingList<DeliveryReceiveDetail_Model>();
                    dgvList.DataSource = lstMain;

                    txtOutSideSupCode.Enabled = false;
                    txtOutSideSupCode.Text = "";
                    txtDeliveryNo.Focus();
                    txtDeliveryNo.SelectAll();
                }
                else
                {
                    supplier = null;
                    queryMain.lstDeliveryDetail.ForEach(t => t.ReceiveQty = t.CurrentlyDeliveryNum);
                    lstMain = new BindingList<DeliveryReceiveDetail_Model>(queryMain.lstDeliveryDetail);
                    dgvList.DataSource = lstMain;

                    txtOutSideSupCode.Enabled = true;
                    txtOutSideSupCode.Focus();
                    txtOutSideSupCode.SelectAll();
                }

                if (queryMain.DocDate != null) dtpDocDate.Value = queryMain.DocDate.ToDateTime();
                if (queryMain.PostDate != null) dtpPostDate.Value = queryMain.PostDate.ToDateTime();
               
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "查询失败");
                txtDeliveryNo.Focus();
                txtDeliveryNo.SelectAll();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void GetQueryMain()
        {
            if (queryMain == null) { queryMain = new DeliveryReceive_Model(); bsMain.DataSource = queryMain; }
            queryMain.DeliveryNo = txtDeliveryNo.Text.Trim();
            //queryMain.Operator = Common_Var.CurrentUser.UserNo;
        }

        private bool PostOutsourcing()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bsMain.EndEdit();
                this.dgvList.EndEdit();
                if (supplier == null)
                {
                    if (!GetSupplier()) return false;
                }

                queryMain.DocDate = dtpDocDate.Value;
                queryMain.PostDate = dtpPostDate.Value;
                queryMain.OutSideSupCode = supplier.SupplierCode;
                queryMain.OutSideSupName = supplier.SupplierName;

                bool bResult = false;
                string strError = string.Empty;
                queryMain.lstDeliveryDetail = new List<DeliveryReceiveDetail_Model>(lstMain);
                bResult = Task_Func.PostOutSideByDeliveryAndPOToSAP(ref queryMain, ref strError);
                //queryMain.Operator = Common_Var.CurrentUser.UserName;
                bsMain.DataSource = queryMain;

                if (!bResult || !string.IsNullOrEmpty(strError)) return Common.Common_Func.ErrorMessage(strError, "过账失败");
                return true;
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "过账失败");
                return false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
                txtDeliveryNo.Focus();
            }
        }

        private void SelectAll()
        {
            try
            {
                dgvList.Enabled = false;
                bool isAll = cbxSelectAll.Checked;

                //foreach (DataGridViewRow dr in dgvList.Rows)
                //{
                //    dr.Cells["colSelect"].Value = isAll;
                //}

                foreach (DeliveryReceiveDetail_Model detail in lstMain)
                {
                    detail.OKSelect = isAll;
                }
            }
            finally
            {
                dgvList.Refresh();
                dgvList.Enabled = true;

                txtOutSideSupCode.Focus();
                txtOutSideSupCode.SelectAll();
            }
        }

        private void SetSelected(int index)
        {
            queryMain.lstDeliveryDetail[index].OKSelect = !queryMain.lstDeliveryDetail[index].OKSelect;

            dgvList.Refresh();

            txtOutSideSupCode.Focus();
            txtOutSideSupCode.SelectAll();
        }

        private bool GetSupplier()
        {
            string strError = string.Empty;
            supplier = new Supplier_Model();
            supplier.SupplierCode = txtOutSideSupCode.Text.Trim();

            if (string.IsNullOrEmpty(supplier.SupplierCode))
            {
                MessageBox.Show("供应商编码不能为空", "供应商信息获取错误");
                supplier = null;
                return false;
            }

            if (!JingXinWMS.Print.Print_Func.GetSupplierInfoForSAP(ref supplier, ref strError))
            {
                MessageBox.Show(strError,"供应商信息获取错误");
                supplier = null;
                return false;
            }

            if (supplier == null || string.IsNullOrEmpty(supplier.SupplierCode))
            {
                MessageBox.Show("供应商信息获取错误");
                supplier = null;
                return false;
            }
            else
            {
                txtOutSideSupCode.Text = supplier.SupplierCode;
                txtOutSideSupName.Text = supplier.SupplierName;
            }

            return true;
        }

        #endregion

    }
}
