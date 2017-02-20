using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS.WebService;

namespace WMS.Basic
{
    public partial class FrmP2B : Common.FrmBasic
    {

        private Preparation _backPreparation;
        private Preparation _preparation;
        private List<Preparation> lstPreparation;
        private Building _backBuilding;
        private Building _building;
        private List<Building> lstBuilding;

        public FrmP2B()
        {
            InitializeComponent();
        }

        private void FrmP2B_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        #region Function
        void InitForm()
        {
            _building = new Building();
            _preparation = new Preparation();
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bsBuilding.EndEdit();
                bsPreparation.EndEdit();

                bool bResult = false;
                string strErr = string.Empty;

                bResult = Basic_Func.GetBuildingList(ref lstBuilding, _building, ref strErr);
                lstBoxBuilding.DataSource = lstBuilding;
                lstBoxBuilding.DisplayMember = "bName";
                lstBoxBuilding.ValueMember = "bNo";

                bResult = Basic_Func.GetPreparationList(ref lstPreparation, _preparation, ref strErr);
                ckLstBoxPreparation.DataSource = lstPreparation;
                ckLstBoxPreparation.DisplayMember = "pCode";
                ckLstBoxPreparation.ValueMember = "bid";



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
        int bid = 0;
        bool isCheck = false;
        private void lstBoxBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBoxBuilding.SelectedIndex >= 0 && lstPreparation != null)
            {
                bid = lstBuilding[lstBoxBuilding.SelectedIndex].ID;
                for (int i = 0; i < lstPreparation.Count; i++)
                {
                    isCheck = lstPreparation[i].bid == bid;
                    ckLstBoxPreparation.SetItemChecked(i, isCheck);
                }
            }
        }
    }
}
