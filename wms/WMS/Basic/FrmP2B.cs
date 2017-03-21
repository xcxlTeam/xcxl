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

        private Preparation _preparation;
        private List<Preparation> lstPreparation;
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

        private void btnDelPreparation_Click(object sender, EventArgs e)
        {
            if (ckLstBoxPreparation.SelectedIndex < 0)
            {
                Common.Common_Func.ErrorMessage("请先选中一行", "删除失败");
                return;
            }
            DelPreparation();
        }

        int bid = 0;
        bool isCheck = false;
        private void lstBoxBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBuilding != null)
            {
                if (lstBoxBuilding.SelectedIndex <= 0)
                {
                    btnUp.Enabled = false;
                }
                else
                {
                    btnUp.Enabled = true;
                }

                if (lstBoxBuilding.SelectedIndex == lstBuilding.Count - 1)
                {
                    btnDown.Enabled = false;
                }
                else
                {
                    btnDown.Enabled = true;
                }
            }
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

        private void btnAddPreparation_Click(object sender, EventArgs e)
        {
            AddPreparation();
        }

        private void btnEditPreparation_Click(object sender, EventArgs e)
        {
            if (ckLstBoxPreparation.SelectedIndex < 0)
            {
                Common.Common_Func.ErrorMessage("请先选中一行", "编辑失败");
                return;
            }

            EditListRow(ckLstBoxPreparation.SelectedIndex);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            IndexExChange(lstBuilding, lstBoxBuilding.SelectedIndex, lstBoxBuilding.SelectedIndex - 1);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            IndexExChange(lstBuilding, lstBoxBuilding.SelectedIndex, lstBoxBuilding.SelectedIndex + 1);

        }

        private void ckLstBoxPreparation_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            if (lstBuilding != null)
            {
                if (lstPreparation[e.Index].bid == bid)
                {
                    if (e.NewValue != CheckState.Checked)
                    {
                        e.NewValue = CheckState.Checked;
                        Common.Common_Func.ErrorMessage("请通过编辑按钮来操作制法选中状态", "提示");
                    }
                }
                else
                {
                    if (e.NewValue == CheckState.Checked)
                    {
                        e.NewValue = CheckState.Unchecked;
                        Common.Common_Func.ErrorMessage("请通过编辑按钮来操作制法选中状态", "提示");
                    }
                }
            }
        }

        private void tsmiCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        #region Function
        void InitForm()
        {
            _building = new Building();
            _preparation = new Preparation();
            GetListQueryData();
        }

        private void GetListQueryData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bool bResult = false;
                string strErr = string.Empty;

                bResult = Basic_Func.GetPreparationList(ref lstPreparation, _preparation, ref strErr);
                ckLstBoxPreparation.DataSource = lstPreparation;
                ckLstBoxPreparation.DisplayMember = "pCode";
                ckLstBoxPreparation.ValueMember = "bid";

                bResult = Basic_Func.GetBuildingList(ref lstBuilding, _building, ref strErr);
                lstBoxBuilding.DataSource = lstBuilding;
                lstBoxBuilding.DisplayMember = "bName";
                lstBoxBuilding.ValueMember = "bNo";

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

        private void DelPreparation()
        {

            DeleteListRow(ckLstBoxPreparation.SelectedIndex);
        }

        private void DeleteListRow(int iRowIndex)
        {
            Preparation preparation = GetListRowModel(iRowIndex);
            if (preparation == null) return;

            if (MessageBox.Show(string.Format("是否确认删除制法【{0}】?", preparation.pCode), "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No) return;

            try
            {
                if (preparation.IsDel != 2)
                {
                    string strErr = string.Empty;
                    if (!Basic_Func.DeletePreparationByID(preparation, ref strErr))
                    {
                        Common.Common_Func.ErrorMessage(strErr, "删除失败");
                        return;
                    }
                }

                Common.Common_Func.ErrorMessage("删除制法成功", "删除成功");
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message);
            }
            finally
            {
                GetListQueryData();
            }
        }

        private void EditListRow(int iRowIndex)
        {
            Preparation preparation = GetListRowModel(iRowIndex);
            if (preparation == null) return;

            ShowFileForm(preparation);
        }

        private Preparation GetListRowModel(int iRowIndex)
        {
            string strErr = string.Empty;
            Preparation preparation = new Preparation();
            preparation.ID = lstPreparation[iRowIndex].ID;

            if (!Basic_Func.GetPreparationByID(ref preparation, ref strErr))
            {
                Common.Common_Func.ErrorMessage(strErr, "读取失败");
                GetListQueryData();
                return null;
            }

            return preparation;
        }

        private void AddPreparation()
        {
            Preparation preparation = new Preparation() { ID = 0 };

            ShowFileForm(preparation);
        }

        private void ShowFileForm(Preparation preparation)
        {
            using (FrmP2BFile frm = new FrmP2BFile(preparation))
            {
                frm.ShowDialog();
            }

            this.Refresh();
            Application.DoEvents();

            GetListQueryData();

        }

        private bool IndexExChange(List<Building> list, int oldIndex, int newIndex)
        {
            if (oldIndex > list.Count - 1 || newIndex > list.Count - 1 || oldIndex < 0 || newIndex < 0 || oldIndex == newIndex) { return false; }

            try
            {
                var sel = list[oldIndex];
                list[oldIndex] = list[newIndex];
                list[newIndex] = sel;
                for (int i = 0; i < list.Count - 1; i++)
                {
                    list[i].iGrade = i;
                }
                list = (from model in list orderby model.iGrade select model).ToList();
                lstBoxBuilding.DataSource = list;
                lstBoxBuilding.SelectedIndex = newIndex;
                //lstBoxBuilding.DataSource = new BindingList<Building>(list);
                return true;
            }
            catch (Exception)
            {
                return false; ;
            }
        }

        private void CloseForm()
        {
            this.Close();
        }


        #endregion

       








    }
}
