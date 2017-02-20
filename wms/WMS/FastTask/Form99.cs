using WMS.WebService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS.FastTask
{
    public partial class Form99 : Common.FrmBasic
    {
        public Form99()
        {
            InitializeComponent();

            //List<ComboBoxItem> h = FastOut_Func.GetStatusList();
            List<ComboBoxItem> h = new List<ComboBoxItem>();
            BindComboBox(h, cmb_state);

            voucherNoDataGridViewTextBoxColumn.DataPropertyName = "VoucherNo";
            taskNoDataGridViewTextBoxColumn.DataPropertyName = "TaskNo";
            statusDataGridViewTextBoxColumn.DataPropertyName = "StatusName";
            cREATEUSERNODataGridViewTextBoxColumn.DataPropertyName = "CreateUserNo";
            createDateTimeDataGridViewTextBoxColumn.DataPropertyName = "CreateDateTime";
            reasonDataGridViewTextBoxColumn.DataPropertyName = "Reason";
            remarkDataGridViewTextBoxColumn.DataPropertyName = "Remark";
            tIDDataGridViewTextBoxColumn.DataPropertyName = "ID";
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

        private void GetQueryData()
        {
            ChensControl.DividPage clientPage = chensPage1.dDividPage;
            DividPage _serverMainPage = new DividPage();
            Common.Common_Func.GetServerPageFromClientPage(ref _serverMainPage, clientPage);
            Task_Model TM = new Task_Model();
            if (txt_djno.Text.Trim().Length > 0)//单据号
            {
                TM.VoucherNo = txt_djno.Text.Trim();
            }
            if (txt_ontaskno.Text.Trim().Length > 0)//上架任务号
            {
                TM.TaskNo = txt_ontaskno.Text.Trim();
            }
            if (txt_peo.Text.Trim().Length > 0)//制单人
            {
                TM.CreateUserNo = txt_peo.Text.Trim();
            }
            if (cmb_state.Text.Trim().Length > 0)//状态
            {
                TM.TaskStatus = (int)cmb_state.SelectedValue;
            }
            string BeginTime = "", EndTime = "";
            if (begintime.Checked)
            {
                BeginTime = begintime.Value.ToString("yyyy-MM-dd");
            }
            if (endtime.Checked)
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
                    if (strErr.Equals("没有快速出库单信息！"))
                    {
                        return;
                    }
                    else
                    {
                        Common.Common_Func.ErrorMessage(strErr);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message);
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
                Common.Common_Func.ErrorMessage(ee.ToString());
            }
        }

        private void 新建出库单ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 修改出库单ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 删除出库单ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 过账ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dgv_show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
