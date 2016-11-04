using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS.WebService;

namespace WMS.MaterialRequest
{
    public partial class FrmMaterialRequestList : Common.FrmBasic
    {
        //public OutStock_Model outStockModel = new OutStock_Model();
        //BindingList<OutStockDetails_Model> bindListOutStockDetails = null;

        public FrmMaterialRequestList()
        {
            InitializeComponent();
            //bsOutStock.DataSource = outStockModel;
            this.dgvList.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
        }

        private void BindComboBoxs()
        {
            Common.Common_Func.BindComboxBoxByKey(cbxType.Name, cbxType);
            
        }

        private void FrmMaterialRequestList_Load(object sender, EventArgs e)
        {
            BindComboBoxs();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //BindData();

                
            }
            catch (Exception ex) 
            {
                Common.Common_Func.ErrorMessage(ex.Message, "程序异常");
            }
        }

        //private void BindData()
        //{
        //    this.outStockModel.VoucherType = SelectVoucherType(this.cbxType.SelectedValue.ToString());

        //    bool bSucc = false;
        //    string strErrMsg = string.Empty;

        //    bSucc = MaterialRequest_Func.GetOutStockInfoForSAP(ref outStockModel, ref strErrMsg);
        //    if (bSucc == false)
        //    {
        //        Common.Common_Func.ErrorMessage(strErrMsg, "查询失败");
        //    }
        //    else
        //    {
        //        bindListOutStockDetails = new BindingList<OutStockDetails_Model>(outStockModel.lstOutStockDetails);
        //        this.dgvList.DataSource = bindListOutStockDetails;
        //    }
        //}

        private int SelectVoucherType(string strCbxValue) 
        {
            int iVoucherType = 0;

            switch (strCbxValue)
            {
                case "1":
                    iVoucherType = 80;
                    break;
                case "2":
                    iVoucherType = 90;
                    break;
                case "3":
                    iVoucherType = 100;
                    break;
                case "4":
                    iVoucherType = 110;
                    break;
                case "5":
                    iVoucherType = 120;
                    break;
                case "6":
                    iVoucherType = 130;
                    break;
                case "7":
                    iVoucherType = 140;
                    break;
                case "8":
                    iVoucherType = 150;
                    break;
                default:
                    iVoucherType = 0;
                    break;
            }
            return iVoucherType;
                
        
        }
    }
}
