using WMS.WebService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS.FastIn
{
    public partial class Frmmain_FastIn :Common.FrmBasic
    {
        public Frmmain_FastIn()
        {
            try
            {
                InitializeComponent();
               
                List<ComboBoxItem> h = FastIn_Func.GetStatusList();
                BindComboBox(h, cmb_state);

                sAPMaterialDoc.DataPropertyName = "MaterialDoc";
                voucherNoDataGridViewTextBoxColumn.DataPropertyName = "VoucherNo";
                taskNoDataGridViewTextBoxColumn.DataPropertyName = "TaskNo";
                statusDataGridViewTextBoxColumn.DataPropertyName = "StatusName";
                cREATEUSERNODataGridViewTextBoxColumn.DataPropertyName = "CreateUserNo";
                createDateTimeDataGridViewTextBoxColumn.DataPropertyName = "CreateDateTime";
                reasonDataGridViewTextBoxColumn.DataPropertyName = "Reason";
                remarkDataGridViewTextBoxColumn.DataPropertyName = "Remark";
                tIDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void BindComboBox(List<ComboBoxItem> h, ChensControl.ChensComboBox cmb_state)
        {
            if (h.Count > 0)
            {
                cmb_state.DataSource = h;
                cmb_state.DisplayMember = "Name";
                cmb_state.ValueMember = "Id";
            }
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            try
            {
                chensPage1.dDividPage.CurrentPageNumber = 1;
                GetQueryData();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void GetQueryData()
        {
            ChensControl.DividPage clientPage = chensPage1.dDividPage;
            DividPage _serverMainPage = new DividPage();
            Common.Common_Func.GetServerPageFromClientPage(ref _serverMainPage, clientPage);
            Task_Model TM = new Task_Model();
            if(txt_djno.Text.Trim().Length > 0)//单据号
            {
                TM.VoucherNo = txt_djno.Text.Trim();
            }
            if(txt_mateducment.Text.Trim().Length > 0)//物料凭证号
            {
                TM.MaterialDoc = txt_mateducment.Text.Trim();
            }
            if(txt_ontaskno.Text.Trim().Length > 0)//上架任务号
            {
                TM.TaskNo = txt_ontaskno.Text.Trim();
            }
            if(txt_peo.Text.Trim().Length > 0)//制单人
            {
                TM.CreateUserNo = txt_peo.Text.Trim();
            }
            if(cmb_state.Text.Trim().Length > 0)//状态
            {
                TM.TaskStatus = (int)cmb_state.SelectedValue;
            }
            string BeginTime = "", EndTime = "";
            if(begintime.Checked)
            {
                BeginTime = begintime.Value.ToString("yyyy-MM-dd");
            }
            if(endtime.Checked)
            {
                EndTime = endtime.Value.ToString("yyyy-MM-dd");
            }
            List<Task_Model> lsttask = new List<Task_Model>();
            string strErr = "";
            bindingSource1.DataSource = null;
            try
            {
                bool bResult = WMS.Common.WMSWebService.service.QueryFastInList(TM, BeginTime, EndTime, ref _serverMainPage, ref lsttask, ref strErr);
                Common.Common_Func.GetClientPageFromServerPage(_serverMainPage, ref clientPage);
                chensPage1.ShowPage();
                bindingSource1.DataSource = lsttask;
                if (bResult == false)
                {
                    if (strErr.Equals("没有快速入库单信息！"))
                    {
                        return;
                    }
                    else
                    {
                        MessageBox.Show(strErr);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chensPage1_ChensPageChange(object sender, EventArgs e)
        {
            try
            {
                GetQueryData();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void 新建入库单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdd_FastIn add = new FrmAdd_FastIn();
            add.ShowDialog();
            btn_select_Click(null, null);
        }

        private void 修改入库单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = "";
            try
            {
                id = dgv_show.SelectedRows[0].Cells["tIDDataGridViewTextBoxColumn"].Value.ToString();
            }
            catch
            {
                MessageBox.Show("请选择要修改的行！");
                return;
            }
            if (dgv_show.SelectedRows[0].Cells["statusDataGridViewTextBoxColumn"].Value.ToString().Equals("已过账"))
            {
                MessageBox.Show("已过账不能修改");
                return;
            }
            FrmAdd_FastIn add = new FrmAdd_FastIn(id);
            add.ShowDialog();
            btn_select_Click(null, null);
            //FrmEdit_FastIn edit = new FrmEdit_FastIn(id);
            //edit.ShowDialog();
            //btn_select_Click(null, null);
        }

        private void 删除入库单ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                string id = "";
                try
                {
                    id = dgv_show.SelectedRows[0].Cells["tIDDataGridViewTextBoxColumn"].Value.ToString();
                }
                catch
                {
                    MessageBox.Show("请选择要删除的行！");
                    return;
                }
                if (DialogResult.Cancel == MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                {
                    return;
                }
                string strErrMsg = string.Empty;
                bool re = WMS.Common.WMSWebService.service.DeleteFastIn(id, Common.Common_Var.CurrentUser, ref strErrMsg);
                if (re == true)
                    MessageBox.Show("删除成功！");
                else
                    MessageBox.Show("删除失败:" + strErrMsg);
                btn_select_Click(null, null);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void 物料凭证引入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmMateDocIn_FastIn fi = new FrmMateDocIn_FastIn();
            //fi.ShowDialog();
            //btn_select_Click(null, null);
        }

        private void txt_djno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //WebService.Supplier_Model supplier = new WebService.Supplier_Model();
                //supplier.SupplierCode = txt_busname.Text.Trim();
                //string errMsg = "";
                //bool re = JingXinWMS.Common.WMSWebService.service.GetSupplierInfoForSAP(ref supplier, ref errMsg);
                //if (re == true)
                //{
                //    txt_businessName.Text = supplier.SupplierName;
                //}
                //else
                //{
                //    MessageBox.Show("获取供应商信息失败:" + errMsg);
                //    txt_businessName.Text = "";
                //    txt_busname.SelectAll();
                //    txt_busname.Focus();
                //}

                btn_select_Click(null, null);
            }
        }

        private void 过账ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //过账
            try
            {
                string id = "";
                try
                {
                    id = dgv_show.SelectedRows[0].Cells["tIDDataGridViewTextBoxColumn"].Value.ToString();
                }
                catch
                {
                    MessageBox.Show("请选择要过账的行！");
                    return;
                }
                string strErrMsg = string.Empty;
                //JingXinWMS.WebService.Task_Model sourceTask = null;
                //JingXinWMS.WebService.TaskVoucher sourceVoucher = null;
                //bool bSucc = JingXinWMS.Common.WMSWebService.service.GetFastInByID(id, ref sourceTask, ref sourceVoucher, ref strErrMsg);
                //bool bShelve = false;
                if (dgv_show.SelectedRows[0].Cells["statusDataGridViewTextBoxColumn"].Value.ToString().Equals("已完成"))
                {
                    //bool re = JingXinWMS.Common.WMSWebService.service.PostFastIn(id, Common.Common_Var.CurrentUser, ref strErrMsg);
                    //if (re == true)
                    //    MessageBox.Show("过账成功！");
                    //else
                    //    MessageBox.Show("过账失败:" + strErrMsg);
                    btn_select_Click(null, null);
                }
                else
                {
                    MessageBox.Show("物料还没有上架！");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            
        }

        private void dgv_show_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = "";
            try
            {
                id = dgv_show.SelectedRows[0].Cells["tIDDataGridViewTextBoxColumn"].Value.ToString();
            }
            catch
            {
                MessageBox.Show("请选择要修改的行！");
                return;
            }
            //if (dgv_show.SelectedRows[0].Cells["statusDataGridViewTextBoxColumn"].Value.ToString().Equals("已过账"))
            //{
            //    MessageBox.Show("已过账不能修改");
            //    return;
            //}
            FrmQuery_FastIn add = new FrmQuery_FastIn(id);
            add.ShowDialog();
            btn_select_Click(null, null);
        }

        private void txt_businessName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { btn_select_Click(null, null); }
        }

        private void begintime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { btn_select_Click(null, null); }
        }

        private void cmb_state_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { btn_select_Click(null, null); }
        }

       
    }
}
