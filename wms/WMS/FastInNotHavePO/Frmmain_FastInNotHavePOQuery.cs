using WMS.WebService;
using WMS.FastIn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMS.Common;

namespace WMS.FastInNotHavePO
{
    public partial class Frmmain_FastInNotHavePOQuery : Common.FrmBasic
    {
        public Frmmain_FastInNotHavePOQuery()
        {
            InitializeComponent();
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            chensPage1.dDividPage.CurrentPageNumber = 1;
            GetQueryData();
        }

        private void GetQueryData()
        {
            WebService.DividPage server_page = new WebService.DividPage();
            ChensControl.DividPage client_page = chensPage1.dDividPage;
            if (client_page.CurrentPageNumber == 0)
            {
                client_page.CurrentPageNumber = 1;
            }

            FastIn_Func.GetServerPageFromClientPage(server_page, client_page);

            try
            {
                bool IsSuccess = false; // 判断是否成功返回数据
                string msg = string.Empty; //返回的消息
                List<Task_Model> tMdoels = new List<Task_Model>();
                Task_Model tm = new Task_Model();

                //tm.VoucherNo = txt_djno.Text;
                tm.CreateUserNo = txt_peo.Text;
                tm.MaterialDoc = txt_mateducment.Text;
                tm.TaskNo = txt_ontaskno.Text;
                if (begintime.Checked)
                    tm.CreateDateTime = begintime.Value;
                if (endtime.Checked)
                    tm.CreateDateTime = endtime.Value;
               
                tm.TaskStatus = Convert.ToInt32(cmb_state.SelectedValue);
                tm.SupCusName = txt_busname.Text;

                IsSuccess = WMSWebService.service.GetFastInNotHavePOInfo(tm,ref server_page,ref tMdoels,ref msg);

                FastIn_Func.GetClientPageFromServerPage(server_page, ref client_page);

                chensPage1.ShowPage();
                dgv_show.DataSource = tMdoels;

                if (IsSuccess == false)
                {
                    MessageBox.Show(msg);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void 新建入库单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmmain_FastInNotHavePO ffPO = new Frmmain_FastInNotHavePO();
            ffPO.ShowDialog();
        }

        private void 修改入库单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = "";
            try
            {
                id = dgv_show.SelectedRows[0].Cells["ID"].Value.ToString();
            }
            catch
            {
                MessageBox.Show("请选择要修改的行！");
                return;
            }
        }

        private void 删除入库单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "";
                try
                {
                    id = dgv_show.SelectedRows[0].Cells["ID"].Value.ToString();
                }
                catch
                {
                    MessageBox.Show("请选择要修改的行！");
                    return;
                }
                if (DialogResult.Cancel == MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                {
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
