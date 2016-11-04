using WMS.Common;
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

namespace WMS.Basic
{
    public partial class FrmMenuFile : Common.FrmBaseDialog
    {
        private const string _urlsplit = ".";
        private MenuInfo rootMenu;
        private Type[] paraMenuForm = { typeof(string) };

        private MenuInfo _back;
        private MenuInfo _menu;
        private MenuInfo _parent;
        private bool isInit;

        public FrmMenuFile()
        {
            //SetNewModel();

            //_back = Common.Common_Func.ConvertToModel<MenuInfo>(_menu);

            InitializeComponent();

            //bsMenu.DataSource = _menu;
        }

        public FrmMenuFile(MenuInfo model, MenuInfo parent)
        {
            if (model == null) model = new MenuInfo();
            _menu = model;
            _parent = parent;
            if (model.ID == 0) SetNewModel();

            _back = Common.Common_Func.ConvertToModel<MenuInfo>(_menu);

            InitializeComponent();

            bsMenu.DataSource = _menu;
        }

        private void FrmMenuFile_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            AddData();
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void tsmiCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void tsmiSaveAdd_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                ClearForm();
            }
        }

        private void tsmiSaveClose_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                this.Close();
            }
        }

        private void cbbParentMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInit) return;

            GetParentMenu();

            SetMenuUrl();
        }

        private void cbbMenuType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInit) return;

            BindUrlComboBox();
        }
        private void cbxNamespace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInit) return;

            BindForm();

            BindParameterAndControl();
        }

        private void cbxForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInit) return;

            BindParameterAndControl();
        }

        private void cbxControls_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInit) return;

        }

        #region Function

        private void InitForm()
        {
            isInit = true;

            InitRootNode();

            InitMenuUrl();

            BindComboBoxs();

            if (Common.Common_Var.CurrentUser.UserType != 1) tsmiSaveAdd.Visible = false;

            if (this._menu.ID == 0)
            {
                this.Text = "新增菜单";
            }
            else
            {
                _menu.MenuType = _back.MenuType;
                _menu.MenuStatus = _back.MenuStatus;
                this.Text = "编辑菜单";
            }

            SetMenuUrl();

            bsMenu.ResetBindings(false);
            bsMenu.EndEdit();

            txtMenuNo.Focus();
            txtMenuNo.SelectAll();
            isInit = false;
        }

        private void ClearForm()
        {
            try
            {
                isInit = true;
                _menu = new MenuInfo();
                SetNewModel();

                BindUrlComboBox();

                string strError = string.Empty;
                Basic_Func.GetMenuNo(ref _menu, ref strError);
                _menu.ParentID = _back.ParentID;
                _menu.NodeUrl = _parent.NodeUrl;
                _menu.NodeSort = _back.NodeSort + 1;
                _menu.IsEnd = _back.IsEnd;
                _menu.MenuType = _back.MenuType;

                SetMenuUrl();

                bsMenu.DataSource = _menu;
                bsMenu.ResetBindings(false);
                bsMenu.EndEdit();
            }
            catch
            {
            }
            finally
            {
                isInit = false;
                txtMenuName.Focus();
            }
        }

        private void SetNewModel()
        {
            if (_menu == null) _menu = new MenuInfo();
            _menu.ID = 0;
            _menu.MenuType = 1;
            _menu.MenuStatus = 1;
            _menu.IsDefault = 1;
            _menu.IsDel = 1;

            if (_parent == null) _parent = new MenuInfo();
            _menu.ParentID = _parent.ID;
            _menu.NodeUrl = _parent.NodeUrl;
            _menu.NodeSort = _parent.SonQty + 1;
            _menu.NodeLevel = _parent.NodeLevel + 1;
        }

        private void InitRootNode()
        {
            rootMenu = new MenuInfo() { ID = 0, ParentID = -1, MenuNo = "root", MenuName = "京信通信WMS", NodeLevel = 0, NodeUrl = Common.Common_Var.SolutionName };
        }

        public void InitMenuUrl()
        {
            if (Basic_Var.dicNamespace != null && Basic_Var.dicNamespace.Count >= 1) return;
            if (Basic_Var.dicForms != null && Basic_Var.dicForms.Count >= 1) return;

            Dictionary<string, List<string>> dicNamespace = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> dicForms = new Dictionary<string, List<string>>();

            string NamespaceKey, NmaespaceValue;
            foreach (Type type in this.GetType().Assembly.GetTypes())
            {
                if (typeof(System.Windows.Forms.Form).IsAssignableFrom(type))
                {
                    if (type.Namespace == string.Format("{0}.Common", Common_Var.SolutionName)) continue;
                    if (type == typeof(FrmMainTab)) continue;
                    if (type == typeof(Common.FrmBasic)) continue;
                    if (type == typeof(Common.FrmBaseDialog)) continue;

                    string[] arrNamespace = type.Namespace.Split('.');
                    if (arrNamespace.Length == 1)
                    {
                        NamespaceKey = arrNamespace[0];
                        NmaespaceValue = string.Empty;
                    }
                    else
                    {
                        NamespaceKey = type.Namespace.Substring(0, type.Namespace.LastIndexOf('.'));
                        NmaespaceValue = arrNamespace[arrNamespace.Length - 1];
                    }

                    if (!dicNamespace.ContainsKey(NamespaceKey))
                    {
                        dicNamespace.Add(NamespaceKey, new List<string>());
                    }
                    if (!string.IsNullOrEmpty(NmaespaceValue))
                    {
                        if (dicNamespace[NamespaceKey].IndexOf(NmaespaceValue) < 0)
                            dicNamespace[NamespaceKey].Add(NmaespaceValue);
                    }

                    if (!dicForms.ContainsKey(type.Namespace))
                    {
                        dicForms.Add(type.Namespace, new List<string>());
                    }
                    dicForms[type.Namespace].Add(type.Name);
                }
            }

            Basic_Var.dicNamespace = dicNamespace;
            Basic_Var.dicForms = dicForms;
        }

        private void BindComboBoxs()
        {
            int parentID = _menu.ParentID;
            Common_Func.BindComboxBoxByKey(cbbParentMenu.Name, cbbParentMenu);
            //Common_Func.BindComboBox(Basic_Func.GetParentMenuByMenu(_menu), cbbParentMenu);
            _menu.ParentID = parentID;

            int type = _menu.MenuType;
            Common_Func.BindComboxBoxByKey(cbbMenuType.Name, cbbMenuType);
            _menu.MenuType = type;

            int status = _menu.MenuStatus;
            Common_Func.BindComboxBoxByKey(cbbMenuStatus.Name, cbbMenuStatus);
            _menu.MenuStatus = status;

            BindUrlComboBox();
        }

        private void BindUrlComboBox()
        {
            bsMenu.EndEdit();

            txtSolution.Enabled = false;
            txtSolution.Text = Common.Common_Var.SolutionName;

            switch (_menu.MenuType)
            {
                case 1:
                    cbxNamespace.Enabled = true;
                    cbxForms.Enabled = false;
                    txtParameter.Enabled = false;
                    cbxControls.Enabled = false;

                    BindNamespace();

                    //BindForm();

                    //BindParameterAndControl();

                    cbxNamespace.Focus();
                    break;

                case 2:
                    cbxNamespace.Enabled = true;
                    cbxForms.Enabled = true;
                    txtParameter.Enabled = true;
                    cbxControls.Enabled = false;

                    BindNamespace();
                    BindForm();

                    //BindParameterAndControl();

                    cbxForms.Focus();
                    break;

                case 3:
                    cbxNamespace.Enabled = true;
                    cbxForms.Enabled = true;
                    txtParameter.Enabled = true;
                    cbxControls.Enabled = true;

                    BindNamespace();
                    BindForm();
                    BindParameterAndControl();

                    cbxControls.Focus();
                    break;

                default:
                    cbxNamespace.Enabled = false;
                    cbxForms.Enabled = false;
                    cbxControls.Enabled = false;
                    break;
            }
        }

        private void BindParameterAndControl()
        {
            List<string> lstControl = new List<string>();
            string strFormPath = string.Format("{0}.{1}.{2}", txtSolution.Text, cbxNamespace.Text, cbxForms.Text);
            Type type = Type.GetType(strFormPath);
            if (type != null)
            {
                txtParameter.Enabled = IsHaveStringParameter(type);
                if (!txtParameter.Enabled) txtParameter.Text = "";

                try
                {
                    Form frm = (Form)Activator.CreateInstance(type);
                    ForeachControl(frm, ref lstControl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            cbxControls.DataSource = lstControl;
            if (cbxControls.Items.Count >= 1) cbxControls.SelectedIndex = 0;
            if (txtParameter.Enabled)
            {
                txtParameter.Focus();
                txtParameter.SelectAll();
            }
        }

        private void BindForm()
        {
            string strNamespace = string.Format("{0}.{1}", txtSolution.Text, cbxNamespace.Text);
            if (!Basic_Var.dicForms.ContainsKey(strNamespace)) return;

            cbxForms.DataSource = Basic_Var.dicForms[strNamespace];
            if (cbxForms.Items.Count >= 1) cbxForms.SelectedIndex = 0;
        }

        private void BindNamespace()
        {
            if (!Basic_Var.dicNamespace.ContainsKey(txtSolution.Text)) return;

            cbxNamespace.DataSource = Basic_Var.dicNamespace[txtSolution.Text];
            if (cbxNamespace.Items.Count >= 1) cbxNamespace.SelectedIndex = 0;
        }

        private bool IsHaveStringParameter(Type type)
        {
            System.Reflection.ConstructorInfo ci = type.GetConstructor(paraMenuForm);
            return ci != null;
        }

        private void ForeachControl(Control ctl, ref List<string> lst)
        {
            if (ctl == null) return;

            if (IsRightControl(ctl)) lst.Add(ctl.Name);
            foreach (Control c in ctl.Controls)
            {
                ForeachControl(c, ref lst);
            }

            if (ctl is ChensControl.ChensMenuStrip || ctl is MenuStrip)
            {
                foreach (ToolStripMenuItem tsmi in (ctl as MenuStrip).Items)
                {
                    if (!tsmi.Visible) continue;

                    lst.Add(tsmi.Name);
                }
            }
        }

        private bool IsRightControl(Control ctl)
        {
            string typeName = ctl.GetType().FullName;

            switch (typeName)
            {
                case "ChensControl.ChensButton":
                //case "ChensControl.ChensTextBox":
                //case "ChensControl.ChensComboBox":
                case "ChensControl.ChensCheckBox":
                case "System.Windows.Forms.Button":
                //case "System.Windows.Forms.TextBox":
                //case "System.Windows.Forms.ComboBox":
                case "System.Windows.Forms.CheckBox":
                case "System.Windows.Forms.ToolStripMenuItem":
                case "System.Windows.Forms.DataGridViewLinkColumn":
                    return true;

                default:
                    return false;
            }
        }

        private void CloseForm()
        {
            if (_menu.ID >= 1)
            {
                if (!SaveChange()) return;
            }

            this.Close();
        }

        private void AddData()
        {
            if (!SaveChange()) return;

            ClearForm();
        }

        private bool SaveChange()
        {
            bsMenu.EndEdit();

            if (!Common.Common_Func.EqualsValues(_menu, _back))
            {
                DialogResult dr = MessageBox.Show("当前菜单已经修改,是否保存当前的改动?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes) return SaveData();
            }

            return true;
        }

        private bool SaveData()
        {
            bsMenu.EndEdit();

            _menu.ParentID = _parent.ID;
            _menu.NodeLevel = _parent.NodeLevel + 1;
            _menu.IsEnd = (_menu.MenuType == 3).ToInt32();
            _menu.IsDefault = _menu.BIsDefault.ToInt32();
            if (_menu.ParentID >= 1 && _menu.ParentID == _back.ParentID) _menu.NodeSort = _back.NodeSort;
            GetMenuUrl();

            if (!CheckInput()) return false;

            string strErr = string.Empty;
            if (Basic_Func.SaveMenu(ref _menu, ref strErr))
            {
                Common.Common_Func.ErrorMessage("菜单保存成功！", "保存成功");
                _back = Common.Common_Func.ConvertToModel<MenuInfo>(_menu);
                bsMenu.DataSource = _menu;
                InitForm();
                _back = Common.Common_Func.ConvertToModel<MenuInfo>(_menu);
                return true;
            }
            else
            {
                Common.Common_Func.ErrorMessage(strErr, "保存失败");
                bsMenu.DataSource = _menu;
                return false;
            }
        }

        private void GetMenuUrl()
        {
            switch (_menu.MenuType)
            {
                case 1:
                    _menu.NodeUrl = string.Format("{0}.{1}", txtSolution.Text, cbxNamespace.Text);
                    _menu.ProjectName = cbxNamespace.Text;
                    break;

                case 2:
                    if (string.IsNullOrEmpty(txtParameter.Text))
                    {
                        _menu.NodeUrl = string.Format("{0}.{1}.{2}", txtSolution.Text, cbxNamespace.Text, cbxForms.Text);
                        _menu.ProjectName = cbxForms.Text;
                        _menu.BHaveParameter = false;
                    }
                    else
                    {
                        _menu.NodeUrl = string.Format("{0}.{1}.{2}:{3}", txtSolution.Text, cbxNamespace.Text, cbxForms.Text, txtParameter.Text);
                        _menu.ProjectName = string.Format("{0}:{1}", cbxForms.Text, txtParameter.Text);
                        _menu.BHaveParameter = true;
                    }
                    break;

                case 3:
                    if (string.IsNullOrEmpty(txtParameter.Text) || !txtParameter.Enabled)
                    {
                        _menu.NodeUrl = string.Format("{0}.{1}.{2}.{3}", txtSolution.Text, cbxNamespace.Text, cbxForms.Text, cbxControls.Text);
                        _menu.ProjectName = cbxControls.Text;
                    }
                    else
                    {
                        _menu.NodeUrl = string.Format("{0}.{1}.{2}:{3}.{4}", txtSolution.Text, cbxNamespace.Text, cbxForms.Text, txtParameter.Text.Trim(), cbxControls.Text);
                        _menu.ProjectName = cbxControls.Text;
                    }
                    break;

                default:
                    break;
            }
        }

        private void SetMenuUrl()
        {
            cbxNamespace.Enabled = false;
            cbxForms.Enabled = false;
            txtParameter.Enabled = false;
            cbxControls.Enabled = false;

            if (_menu == null || string.IsNullOrEmpty(_menu.NodeUrl))
            {
                txtSolution.Text = Common.Common_Var.SolutionName;
                return;
            }


            string[] arrUrl = _menu.NodeUrl.Split('.');
            string[] arrPara;
            string strNamespace;
            switch (_menu.MenuType)
            {
                case 1:
                    cbxNamespace.Enabled = true;
                    if (arrUrl.Length < 2) return;
                    txtSolution.Text = arrUrl[0];
                    cbxNamespace.Text = arrUrl[1];
                    break;

                case 2:
                    cbxNamespace.Enabled = true;
                    cbxForms.Enabled = true;
                    if (arrUrl.Length < 3) return;
                    txtSolution.Text = arrUrl[0];
                    cbxNamespace.Text = arrUrl[1];
                    strNamespace = string.Format("{0}.{1}", txtSolution.Text, cbxNamespace.Text);
                    if (!Basic_Var.dicForms.ContainsKey(strNamespace)) return;
                    cbxForms.DataSource = Basic_Var.dicForms[strNamespace];

                    arrPara = arrUrl[2].Split(':');
                    cbxForms.Text = arrPara[0];
                    if (arrPara.Length >= 2) txtParameter.Text = arrPara[1];
                    else txtParameter.Text = string.Empty;
                    break;

                case 3:
                    cbxNamespace.Enabled = true;
                    cbxForms.Enabled = true;
                    txtParameter.Enabled = _menu.BHaveParameter;
                    cbxControls.Enabled = true;
                    if (arrUrl.Length < 4) return;
                    txtSolution.Text = arrUrl[0];
                    cbxNamespace.Text = arrUrl[1];
                    strNamespace = string.Format("{0}.{1}", txtSolution.Text, cbxNamespace.Text);
                    if (!Basic_Var.dicForms.ContainsKey(strNamespace)) return;
                    cbxForms.DataSource = Basic_Var.dicForms[strNamespace];

                    arrPara = arrUrl[2].Split(':');
                    cbxForms.Text = arrPara[0];
                    if (arrPara.Length >= 2) txtParameter.Text = arrPara[1];
                    else txtParameter.Text = string.Empty;
                    cbxControls.Text = arrUrl[3];
                    break;

                default:
                    break;
            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(_menu.MenuNo))
            {
                Common.Common_Func.ErrorMessage("菜单编号不能为空", "保存失败");
                return false;
            }
            if (string.IsNullOrEmpty(_menu.MenuName))
            {
                Common.Common_Func.ErrorMessage("菜单名称不能为空", "保存失败");
                return false;
            }
            if (string.IsNullOrEmpty(_menu.MenuName))
            {
                Common.Common_Func.ErrorMessage("菜单路径不能为空", "保存失败");
                return false;
            }
            if (_menu.MenuType == 2 || _menu.MenuType == 3)
            {
                Type type = Type.GetType(string.Format("{0}.{1}.{2}", txtSolution.Text, cbxNamespace.Text, cbxForms.Text));
                if (type == null)
                {
                    Common.Common_Func.ErrorMessage("找不到对应的窗体", "保存失败");
                    return false;
                }
            }

            return true;
        }

        private void GetParentMenu()
        {
            bsMenu.EndEdit();

            if (_menu.ParentID <= 0)
            {
                _parent = rootMenu;
            }
            else
            {
                string strErr = string.Empty;
                _parent = new MenuInfo() { ID = _menu.ParentID };

                if (!Basic_Func.GetMenuByID(ref _parent, ref strErr))
                {
                    Common.Common_Func.ErrorMessage(strErr, "读取上级菜单失败");
                }
            }

            _menu.ParentID = _parent.ID;
            _menu.NodeUrl = _parent.NodeUrl;
            _menu.NodeSort = _parent.SonQty + 1;
            _menu.NodeLevel = _parent.NodeLevel + 1;
        }

        #endregion

    }
}
