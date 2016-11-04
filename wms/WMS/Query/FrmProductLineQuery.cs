using WMS.Common;
using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WMS.Query
{
    public partial class FrmProductLineQuery : Common.FrmBasic
    {
        private DividPage _serverMainPage;
        private Barcode_Model queryMain;
        private List<Barcode_Model> lstMain;

        public FrmProductLineQuery()
        {
            InitializeComponent();
            dtpStartTime.Value = DateTime.Today;
            dtpEndTime.Value = DateTime.Today;
        }

        private void FrmPrintRecordQuery_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.Common_Func.RemoveTabPageForm(this);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtpStartTime.Value > dtpEndTime.Value)
            {
                MessageBox.Show("开始时间大于结束时间");
                return;
            }
            //if(txtProductLineNo.Text.Trim().Equals(""))
            //{
            //    MessageBox.Show("请输入产线");
            //    txtProductLineNo.Focus();
            //    return;
            //}
            //if(txtProductLineNo.Text.Trim().Length != 3)
            //{
            //    MessageBox.Show("产线必须为3位");
            //    txtProductLineNo.SelectAll();
            //    txtProductLineNo.Focus();
            //    return;
            //}
            WebService.QueryConditions conditions = new QueryConditions();
            if (txtProductLineNo.Text.Trim().Length > 0)
            {
                conditions.ProductLineNo = txtProductLineNo.Text.Trim();
            }
            if(txtMaterialNo.Text.Trim().Length > 0)
            {
                conditions.MaterialNo = txtMaterialNo.Text.Trim();
            }
            if(txtMaterialDesc.Text.Trim().Length > 0)
            {
                conditions.MaterialDesc = txtMaterialDesc.Text.Trim();
            }
            if(txtMaterialStd.Text.Trim().Length > 0)
            {
                conditions.MaterialStd = txtMaterialStd.Text.Trim();
            }
            if(dtpStartTime.Checked)
            {
                conditions.StartTime = dtpStartTime.Value;
            }
            if (dtpEndTime.Checked)
            {
                conditions.EndTime = dtpEndTime.Value;
            }
            List<WebService.Stock_Model> modelList = null;
            string strError = "";
            if(!WMS.Common.WMSWebService.service.GetCapacityForWMS(ref modelList, conditions, ref strError))
            {
                MessageBox.Show("查询失败:" + strError);
                return;
            }
            //添加总计
            Stock_Model sum_model = new Stock_Model();
            foreach (Stock_Model st_model in modelList)
            {
                sum_model.ErpQty += st_model.ErpQty;
                sum_model.SaveQty += st_model.SaveQty;
                sum_model.TrayQty += st_model.TrayQty;
                sum_model.TotalQty += st_model.TotalQty;
            }
            sum_model.ProductLineNo = "总计";
            modelList.Add(sum_model);
            dataGridView1.DataSource = modelList;
            for(int i = 0;i<dataGridView1.Columns.Count;i++)
            {
                if (dataGridView1.Columns[i].Name.Equals("ProductLineNo"))
                {
                    dataGridView1.Columns[i].HeaderText = "产线";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("MaterialNo"))
                {
                    dataGridView1.Columns[i].HeaderText = "物料编码";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("MaterialDesc"))
                {
                    dataGridView1.Columns[i].HeaderText = "物料名称";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("MaterialStd"))
                {
                    dataGridView1.Columns[i].HeaderText = "规格型号";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("ErpQty"))
                {
                    dataGridView1.Columns[i].HeaderText = "已入库数量";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("SaveQty"))
                {
                    dataGridView1.Columns[i].HeaderText = "已保存未过账数量";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("TrayQty"))
                {
                    dataGridView1.Columns[i].HeaderText = "已组托未入库数量";
                    continue;
                }
                if (dataGridView1.Columns[i].Name.Equals("TotalQty"))
                {
                    dataGridView1.Columns[i].HeaderText = "总数量";
                    continue;
                }
                dataGridView1.Columns[i].Visible = false;
            }
            
        }

        private void chensButton1_Click(object sender, EventArgs e)
        {
            ExcelLibrary.ExcelLibrary_Func.SaveDataGridViewToExcelByNPOI(dataGridView1);
        }
    
    }
}
