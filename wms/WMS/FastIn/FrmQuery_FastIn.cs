using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS.FastIn
{
    public partial class FrmQuery_FastIn : Form
    {
        public FrmQuery_FastIn()
        {
            InitializeComponent();
        }

        public FrmQuery_FastIn(string ID)
        {
            InitializeComponent();

            ROWNO.DataPropertyName = "RowNo";
            PLANT_NAME.DataPropertyName = "PlantName";
            STORE_LOC.DataPropertyName = "StorageLoc";


            txt_VOUCHERNO.Enabled = false;
            txt_sapdoc.Enabled = false;
            txt_taskno.Enabled = false;
            txt_time.Enabled = false;
            txt_poe.Enabled = false;
            txt_poe.Text = Common.Common_Var.CurrentUser.UserName;

            txt_business.Focus();
            txt_time.Value = DateTime.Now;

            WebService.Task_Model head = new WebService.Task_Model();
            head.ID = Convert.ToInt32(ID);
            List<WebService.TaskDetails_Model> body = new List<WebService.TaskDetails_Model>();
            string newTaskNo = string.Empty;
            string ErrMsg = string.Empty;
            //获取TASK表头和表体
            WebService.Task_Model sourceTask = null;
            WebService.TaskVoucher sourceVoucher = null;
            bool bSucc = WMS.Common.WMSWebService.service.GetFastInByID(ID, ref sourceTask, ref sourceVoucher, ref ErrMsg);
            if(!bSucc)
            {
                MessageBox.Show("加载数据失败" + ErrMsg);
                return;
            }
            txt_sapdoc.Text = sourceTask.MaterialDoc;
            txt_taskno.Text = sourceTask.TaskNo;
            txt_time.Value = sourceTask.CreateDateTime;
            txt_businessName.Text = sourceTask.SupCusName;
            txt_business.Text = sourceTask.SupCusNo;
            txt_reason.Text = sourceTask.Reason;
            txt_remark.Text = sourceTask.Remark;
            txt_poe.Text = sourceTask.CreateUserNo;
            if(sourceVoucher != null)
            {
                txt_VOUCHERNO.Text = sourceVoucher.VoucherNo;
                chensCheckBox1.Checked = true;
            }
            else
            {
                if (sourceTask.ShelvePost.Equals("过账"))
                {
                    chensCheckBox1.Checked = true;
                    txt_VOUCHERNO.Enabled = true;
                }
            }
            head = sourceTask;
            if (sourceVoucher != null && sourceVoucher.body != null && sourceVoucher.body.Count == sourceTask.lstTaskDetails.Count)
            {
                for(int i=0;i<sourceTask.lstTaskDetails.Count;i++)
                {
                    sourceTask.lstTaskDetails[i].RowNo = sourceVoucher.body[i].RowNo;
                    sourceTask.lstTaskDetails[i].PlantName = sourceVoucher.body[i].Factory;
                    sourceTask.lstTaskDetails[i].StorageLoc = sourceVoucher.body[i].Store;
                }
                cmb_store.Items.Add(sourceVoucher.body[0].Store);
                cmb_store.SelectedItem = sourceVoucher.body[0].Store;
            }
            body = sourceTask.lstTaskDetails;
            bindingSource1.DataSource = body;
            bindingSource1.ResetBindings(true);
            
            this.Refresh();
        }
    }
}
