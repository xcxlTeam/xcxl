using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMS.WebService;
using WMS.Common;

namespace WMS.Quality
{
    public partial class FrmQuality : Form
    {
        BindingList<DeliveryReceiveDetail_Model> bindListDeliveryDetails = null;
        DeliveryReceive_Model DeliveryModel = new DeliveryReceive_Model();

        public FrmQuality()
        {
            InitializeComponent();
        }
        public FrmQuality(DeliveryReceive_Model DeliveryModel, List<DeliveryReceiveDetail_Model> lstDeliveryDetails)
        {
            InitializeComponent();

            this.bsDelivery.DataSource = DeliveryModel;
            DeliveryModel.lstDeliveryDetail = lstDeliveryDetails;
            this.bindListDeliveryDetails = new System.ComponentModel.BindingList<DeliveryReceiveDetail_Model>(DeliveryModel.lstDeliveryDetail);
            this.dgvList.DataSource = this.bindListDeliveryDetails;
            this.DeliveryModel = DeliveryModel;
            this.dgvList.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

        }

        private void FrmQuality_Load(object sender, EventArgs e)
        {
            Common.Common_Func.BindComboxBoxByKey(colQualityType.Name, colQualityType);

            cbxSelectAll.Width = colSelect.Width;
            cbxSelectAll.BackColor = dgvList.ColumnHeadersDefaultCellStyle.BackColor;
            cbxSelectAll.Font = dgvList.ColumnHeadersDefaultCellStyle.Font;

            for (int i = 0; i < this.DeliveryModel.lstDeliveryDetail.Count;i++ )
            {
                ((DataGridViewComboBoxCell)dgvList.Rows[i].Cells["colQualityType"]).Value = this.DeliveryModel.lstDeliveryDetail[i].QualityType;
            }
                
        }

        private void tsmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool bSucc = false;
                string strErrMsg = string.Empty;

                this.dgvList.EndEdit();

                bSucc = Quality_Func.SaveQualityDetailInfo(DeliveryModel, ref strErrMsg);

                if (bSucc == false)
                {
                    Common.Common_Func.ErrorMessage(strErrMsg, "保存");
                }
                else
                {
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "异常");
            }
        }

        private void dgvList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DeliveryReceiveDetail_Model row = bindListDeliveryDetails[e.RowIndex];
            if(!string.IsNullOrEmpty(row.QualityType))
                dgvList[colQualityType.Name, e.RowIndex].Value = row.QualityType.ToInt32();
        }

        private void dgvList_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll) return;

            cbxSelectAll.Visible = e.NewValue == 0;
        }

        private void cbxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void SelectAll()
        {
            try
            {
                dgvList.Enabled = false;
                bool isAll = cbxSelectAll.Checked;

                foreach (DeliveryReceiveDetail_Model detail in bindListDeliveryDetails)
                {
                    detail.OKSelect = isAll;
                }
            }
            finally
            {
                dgvList.Refresh();
                dgvList.Enabled = true;
            }
        }

        private void dgvList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvList.IsCurrentCellDirty)
            {
                if (dgvList.CurrentCell.ColumnIndex != colQualityType.Index) return;

                dgvList.CommitEdit(DataGridViewDataErrorContexts.Commit);

                bindListDeliveryDetails[dgvList.CurrentCell.RowIndex].QualityType = dgvList.CurrentCell.Value.ToString();
            }
        }



    }
}
