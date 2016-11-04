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
    public partial class FrmGroupMenu : Common.FrmBasic
    {
        private DividPage _serverMainPage;
        private UserGroupInfo queryMain;
        private List<UserGroupInfo> lstMain;
        private UserGroupInfo queryDetails;
        private List<MenuInfo> lstDetails;
        private MenuInfo rootMenu;
        private TreeNode rootNode;
        private TreeNode curNode;
        private bool isLocal;

        public FrmGroupMenu()
        {
            InitializeComponent();

            Common.Common_Func.DelDataGridViewSortable(dgvList);
        }

        private void FrmGroupMenu_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void FrmGroupMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.Common_Func.RemoveTabPageForm(this);
        }

        private void tsmiAddGroup_Click(object sender, EventArgs e)
        {
            AddGroup();
        }

        private void tsmiDelGroup_Click(object sender, EventArgs e)
        {
            DelGroup();
        }

        private void tsmiAddMenu_Click(object sender, EventArgs e)
        {
            AddMenu();
        }

        private void tsmiDelMenu_Click(object sender, EventArgs e)
        {
            DelMenu();
        }

        private void dgvGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BindDetails(e);
        }

        private void dgvGroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EditGroup(e);
        }

        private void pageGroup_ChensPageChange(object sender, EventArgs e)
        {
            GetListQueryData();
        }

        private void tvMenu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            EditMenu(e);
        }

        private void tvMenu_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            curNode = e.Node;
        }

        private void tvMenu_AfterCheck(object sender, TreeViewEventArgs e)
        {
            SetGroupMenu(e);
        }

        private void tvMenu_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ImageKey == "root" || e.Node.ImageKey == "leaf") return;
            e.Node.SelectedImageKey = e.Node.ImageKey = "show";
        }

        private void tvMenu_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ImageKey == "root" || e.Node.ImageKey == "leaf") return;
            e.Node.SelectedImageKey = e.Node.ImageKey = "hide";
        }

        private void scBasic_SplitterMoved(object sender, SplitterEventArgs e)
        {
            pageList.Visible = scBasic.Panel1.Width >= 650;
        }

        #region Function

        private void InitForm()
        {
            if (Common.Common_Var.CurrentUser.UserType != 1) tsmiAddMenu.Visible = false;
            if (Common.Common_Var.CurrentUser.UserType != 1) tsmiDelMenu.Visible = false;

            InitMainQuery();

            BindList();
        }

        private void InitMainQuery()
        {
            _serverMainPage = new DividPage();
            queryMain = new UserGroupInfo();
            lstMain = new List<UserGroupInfo>();

            pageList.GetShowCountsByDGV(dgvList);

            InitRootNode();
        }

        private void InitRootNode()
        {
            rootMenu = new MenuInfo() { ID = 0, ParentID = -1, MenuNo = "root", MenuName = "小川香料WMS", NodeLevel = 0, NodeUrl = Common.Common_Var.SolutionName };
            rootNode = new TreeNode(rootMenu.MenuName);
            rootNode.Tag = rootMenu;
            rootNode.Nodes.Clear();
            rootNode.SelectedImageKey = rootNode.ImageKey = "root";
        }

        private void BindList()
        {
            pageList.dDividPage.CurrentPageNumber = 1;
            GetListQueryData();
        }

        private void AddGroup()
        {
            UserGroupInfo group = new UserGroupInfo() { ID = 0 };

            ShowFileForm(group);
        }

        private void DelGroup()
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList))
            {
                Common.Common_Func.ErrorMessage("请先选中一行分组", "删除失败");
                return;
            }

            DeleteListRow(dgvList.CurrentCell.RowIndex);
        }

        private void DeleteListRow(int iRowIndex)
        {
            UserGroupInfo group = GetListRowModel(iRowIndex);
            if (group == null) return;

            if (MessageBox.Show(string.Format("是否确认删除用户组【{0}】?", group.UserGroupName), "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No) return;

            try
            {
                if (group.IsDel != 2)
                {
                    string strErr = string.Empty;
                    if (!Basic_Func.DeleteUserGroupByID(group, ref strErr))
                    {
                        Common.Common_Func.ErrorMessage(strErr, "删除失败");
                        return;
                    }
                }

                Common.Common_Func.ErrorMessage("删除用户组成功", "删除成功");
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

        private void AddMenu()
        {
            MenuInfo menu = new MenuInfo() { ID = 0 };
            MenuInfo parent = GetCurrentMenu();
            if (parent.IsEnd == 1)
            {
                Common.Common_Func.ErrorMessage("当前菜单已经是末级节点", "新增失败");
                return;
            }
            menu.ParentID = parent.ID;
            if (SelectNode())
            {
                if (curNode.Nodes == null || curNode.Nodes.Count <= 0) menu.NodeSort = 1;
                else menu.NodeSort = (curNode.Nodes[curNode.Nodes.Count - 1].Tag as MenuInfo).NodeSort + 1;
            }
            else
            {
                menu.NodeSort = 1;
            }

            string strError = string.Empty;
            Basic_Func.GetMenuNo(ref menu, ref strError);
            ShowFileForm(menu);
        }

        private void DelMenu()
        {
            if (!SelectNode())
            {
                Common.Common_Func.ErrorMessage("请先选中一个菜单", "删除失败");
                return;
            }

            DeleteDetailsModel(curNode);
        }

        private MenuInfo GetCurrentMenu()
        {
            MenuInfo parent = rootMenu;
            if (!SelectNode()) return parent;
            parent = curNode.Tag as MenuInfo;
            parent.BIsChecked = curNode.Checked;
            return parent;
        }

        private bool SelectNode()
        {
            if (tvMenu.Nodes == null || tvMenu.Nodes.Count <= 0) return false;
            if (curNode == null) curNode = tvMenu.SelectedNode;
            if (curNode == null) return false;

            return true;
        }

        private void DeleteDetailsModel(TreeNode treeNode)
        {
            if (treeNode.Nodes != null && treeNode.Nodes.Count >= 1)
            {
                Common.Common_Func.ErrorMessage("请先删除下级菜单", "删除失败");
                return;
            }

            MenuInfo menu = GetDetailRowModel(treeNode);
            if (menu == null) return;
            if (menu.ID <= 0) return;

            if (MessageBox.Show(string.Format("是否确认删除菜单【{0}】?", menu.MenuName), "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No) return;

            try
            {
                if (menu.IsDel != 2)
                {

                    string strErr = string.Empty;
                    if (!Basic_Func.DeleteMenuByID(menu, ref strErr))
                    {
                        Common.Common_Func.ErrorMessage(strErr, "删除失败");
                        return;
                    }
                }

                Common.Common_Func.ErrorMessage("删除菜单成功", "删除成功");
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message);
            }
            finally
            {
                GetDetailsQueryData();
            }
        }

        private void GetListQueryData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bool bResult = false;
                string strErr = string.Empty;
                GetQueryMain();

                ChensControl.DividPage clientPage = pageList.dDividPage;
                Common.Common_Func.GetServerPageFromClientPage(ref _serverMainPage, clientPage);
                bResult = Basic_Func.GetUserGroupListByPage(ref lstMain, queryMain, ref _serverMainPage, ref strErr);
                Common.Common_Func.GetClientPageFromServerPage(_serverMainPage, ref clientPage);
                pageList.ShowPage();
                dgvList.DataSource = lstMain;

                if (!bResult || !string.IsNullOrEmpty(strErr)) Common.Common_Func.ErrorMessage(strErr, "查询失败");


                GetDetailsQueryData();

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

        private void GetQueryMain()
        {
            if (queryMain == null) queryMain = new UserGroupInfo();
        }

        private void BindDetails(DataGridViewCellEventArgs e)
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList, e)) return;

            GetDetailsQueryData();
        }

        private void GetDetailsQueryData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bool bResult = true;
                string strErr = string.Empty;
                GetQueryDetails();

                bResult = Basic_Func.GetMenuListByUserGroup(ref lstDetails, queryDetails, true, ref strErr);

                SetDetailsQueryData();

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

        private void GetQueryDetails()
        {
            if (queryDetails == null) queryDetails = new UserGroupInfo();

            if (Common.Common_Func.CheckDgvOper(dgvList))
            {
                queryDetails.ID = lstMain[dgvList.CurrentCell.RowIndex].ID;
            }
        }

        private void SetDetailsQueryData()
        {
            try
            {
                tvMenu.Enabled = false;
                InitRootNode();
                tvMenu.Nodes.Clear();
                tvMenu.Nodes.Add(rootNode);
                LoopSetNode(rootNode, rootMenu);
                SetRootNode();
                if (curNode == null) curNode = rootNode;
                if (tvMenu.Height >= lstDetails.Count * 25)
                {
                    tvMenu.ExpandAll();
                }
                else
                {
                    if (curNode.Parent != null)
                        ExpandParent(curNode);
                    else
                        rootNode.Expand();
                }
                tvMenu.SelectedNode = curNode;
            }
            catch { }
            finally
            {
                tvMenu.Enabled = true;
                tvMenu.Refresh();
            }
        }

        private void ExpandParent(TreeNode tn)
        {
            if (tn.Parent != null)
            {
                ExpandParent(tn.Parent);

                if (tn.Parent.ImageKey != "root")
                    tn.Parent.ExpandAll();
            }
            else
            {
                rootNode.Expand();
            }
        }

        private void SetRootNode()
        {
            try
            {
                isLocal = true;
                foreach (TreeNode node in rootNode.Nodes)
                {
                    if (node.Checked)
                    {
                        rootNode.Checked = true;
                        return;
                    }
                }

                rootNode.Checked = false;
            }
            finally
            {
                isLocal = false;
            }
        }

        private void LoopSetNode(TreeNode tnParent, MenuInfo tParent)
        {
            if (lstDetails == null || lstDetails.Count <= 0) return;

            List<MenuInfo> lst;
            lst = lstDetails.Where(delegate(MenuInfo temp) { return temp.ParentID == tParent.ID; }).ToList();
            if (lst == null || lst.Count <= 0)
            {
                if (tnParent.ImageKey != "root") tnParent.SelectedImageKey = tnParent.ImageKey = "leaf";
                tParent.SonQty = 0;
                return;
            }

            TreeNode tnChild;
            foreach (MenuInfo model in lst)
            {
                tnChild = new TreeNode(model.MenuName);
                tnChild.Tag = model;
                tnChild.Checked = model.BIsChecked;
                tnChild.ToolTipText = model.ToolTipText;
                if (model.IsEnd == 1) tnChild.ImageKey = "leaf";
                else tnChild.ImageKey = "show";
                tnChild.SelectedImageKey = tnChild.ImageKey;

                if (tnParent == null)
                {
                    tvMenu.Nodes.Add(tnChild);
                }
                else
                {
                    tnParent.Nodes.Add(tnChild);
                }

                LoopSetNode(tnChild, model);
            }
            tParent.SonQty = lst.Count;
        }

        private void SetGroupMenu(TreeViewEventArgs e)
        {
            if (isLocal) return;

            if (!Common.Common_Func.CheckDgvOper(dgvList)) return;

            RefreshLocalNode(e.Node);

            if (!RefreshServiceNode(e.Node)) GetDetailsQueryData();
        }

        private bool RefreshServiceNode(TreeNode tnChecked)
        {
            if (isLocal) return true;

            MenuInfo menu = GetDetailRowModel(tnChecked);
            string strError = string.Empty;
            if (!Basic_Func.SaveUserGroupMenuToDB(menu, GetListRowModel(dgvList.CurrentCell.RowIndex), ref strError))
            {
                return Common.Common_Func.ErrorMessage(strError, "设置权限失败");
            }
            else
            {
                return true;
            }
        }

        private void RefreshLocalNode(TreeNode tnChecked)
        {
            if (tnChecked == null) tnChecked = curNode;
            if (tnChecked == null) return;

            try
            {
                tvMenu.Enabled = false;
                isLocal = true;
                LoopRefreshChildNode(tnChecked);
                LoopRefreshParentNode(tnChecked);
                tvMenu.SelectedNode = curNode = tnChecked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                isLocal = false;
                tvMenu.Enabled = true;
                tvMenu.Refresh();
            }
        }

        private void LoopRefreshChildNode(TreeNode tnParent)
        {
            if (tnParent == null || tnParent.Nodes.Count <= 0) return;

            try
            {
                foreach (TreeNode tnChild in tnParent.Nodes)
                {
                    tnChild.Checked = tnParent.Checked;
                    LoopRefreshChildNode(tnChild);
                }
            }
            catch //(Exception ex)
            {
                //Common.Common_Func.ErrorMessage(ex.Message);
            }
        }

        private void LoopRefreshParentNode(TreeNode tnChild)
        {
            if (tnChild == null || tnChild.Parent == null) return;

            try
            {
                TreeNode tnParent = tnChild.Parent;
                bool isChecked = false;
                foreach (TreeNode tnLevel in tnParent.Nodes)
                {
                    if (tnLevel.Checked)
                    {
                        isChecked = true;
                        break;
                    }
                }
                tnParent.Checked = isChecked;
                LoopRefreshParentNode(tnParent);
            }
            catch //(Exception ex)
            {
                //Common.Common_Func.ErrorMessage(ex.Message);
            }
        }

        private void EditGroup(DataGridViewCellEventArgs e)
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList, e, "编辑")) return;

            EditListRow(e.RowIndex);
        }

        private void EditListRow(int iRowIndex)
        {
            UserGroupInfo group = GetListRowModel(iRowIndex);
            if (group == null) return;

            ShowFileForm(group);
        }

        private UserGroupInfo GetListRowModel(int iRowIndex)
        {
            string strErr = string.Empty;
            UserGroupInfo group = new UserGroupInfo();
            group.ID = lstMain[iRowIndex].ID;

            if (!Basic_Func.GetUserGroupByID(ref group, ref strErr))
            {
                Common.Common_Func.ErrorMessage(strErr, "读取失败");
                GetListQueryData();
                return null;
            }

            return group;
        }

        private void ShowFileForm(UserGroupInfo group)
        {
            using (FrmGroupFile frm = new FrmGroupFile(group))
            {
                frm.ShowDialog();
            }

            this.Refresh();
            Application.DoEvents();

            GetListQueryData();
        }

        private void EditMenu(TreeNodeMouseClickEventArgs e)
        {
            if (Common.Common_Var.CurrentUser.UserType != 1) return;

            MenuInfo menu = GetDetailRowModel(e.Node);
            if (menu == null) return;
            if (menu.ID <= 0) return;

            ShowFileForm(menu);
        }

        private MenuInfo GetDetailRowModel(TreeNode node)
        {
            MenuInfo menu = node.Tag as MenuInfo;
            menu.BIsChecked = node.Checked;
            return menu;
        }

        private void ShowFileForm(MenuInfo menu)
        {
            MenuInfo parent = GetParentMenu(menu.ParentID);
            if (parent == null) return;

            using (FrmMenuFile frm = new FrmMenuFile(menu, parent))
            {
                frm.ShowDialog();
            }

            this.Refresh();
            Application.DoEvents();

            GetDetailsQueryData();
            SetDetailsQueryData();
        }

        private MenuInfo GetParentMenu(int ParentID)
        {
            MenuInfo parent = new MenuInfo();

            if (ParentID <= 0)
            {
                parent = rootMenu;
            }
            else
            {
                string strError = string.Empty;
                parent = new MenuInfo() { ID = ParentID };

                if (!Basic_Func.GetMenuByID(ref parent, ref strError))
                {
                    Common.Common_Func.ErrorMessage(strError, "读取上级菜单失败");
                    return null;
                }
            }

            return parent;
        }

        #endregion
    }
}
