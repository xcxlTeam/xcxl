using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS.FastIn
{
    public partial class FrmAdd_FastIn : Common.FrmBasic
    {
        bool bNewTask;
        bool bhaveVoucher;
        bool oldVoucher;
        WebService.Task_Model sourceTask;
        WebService.TaskVoucher sourceVoucher;
        //表头
        WebService.Task_Model head;
        //表体
        List<WebService.TaskDetails_Model> body;
        List<string> lst_delID;
        public FrmAdd_FastIn()
        {
            InitializeComponent();

            ROWNO.DataPropertyName = "RowNo";
            PLANT_NAME.DataPropertyName = "PlantName";
            STORE_LOC.DataPropertyName = "StorageLoc";

            bNewTask = true;
            bhaveVoucher = false;

            txt_VOUCHERNO.Enabled = false;
            txt_sapdoc.Enabled = false;
            txt_taskno.Enabled = false;
            txt_time.Enabled = false;
            txt_poe.Enabled = false;
            txt_poe.Text = Common.Common_Var.CurrentUser.UserName;

            txt_rownum.Enabled = false;
            txt_business.Focus();
            txt_time.Value = DateTime.Now;

            head = new WebService.Task_Model();
            body = new List<WebService.TaskDetails_Model>();
            string newTaskNo = string.Empty;
            string ErrMsg = string.Empty;
            if (WMS.Common.WMSWebService.service.GetNewTASKNO(ref newTaskNo, ref ErrMsg))
            {
                txt_taskno.Text = newTaskNo;
            }
            else
            {
                MessageBox.Show("获取任务号失败");
            }
        }
        /// <summary>
        /// 修改界面
        /// </summary>
        /// <param name="ID"></param>
        public FrmAdd_FastIn(string ID)
        {
            InitializeComponent();

            oldVoucher = false;
            ROWNO.DataPropertyName = "RowNo";
            PLANT_NAME.DataPropertyName = "PlantName";
            STORE_LOC.DataPropertyName = "StorageLoc";

            bNewTask = false;
            lst_delID = new List<string>();

            txt_VOUCHERNO.Enabled = false;
            txt_sapdoc.Enabled = false;
            txt_taskno.Enabled = false;
            txt_time.Enabled = false;
            txt_poe.Enabled = false;
            txt_poe.Text = Common.Common_Var.CurrentUser.UserName;

            txt_rownum.Enabled = false;
            txt_business.Focus();
            txt_time.Value = DateTime.Now;

            head = new WebService.Task_Model();
            head.ID = Convert.ToInt32(ID);
            body = new List<WebService.TaskDetails_Model>();
            string newTaskNo = string.Empty;
            string ErrMsg = string.Empty;
            //获取TASK表头和表体
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
            txt_business.Text = sourceTask.SupCusNo.TrimStart('0');
            txt_reason.Text = sourceTask.Reason;
            txt_remark.Text = sourceTask.Remark;
            txt_poe.Text = sourceTask.CreateUserNo;
            bool bShelve = false;
            foreach(WebService.TaskDetails_Model dtm in sourceTask.lstTaskDetails)
            {
                if(dtm.ShelveQty > 0)
                {
                    bShelve = true;
                    oldVoucher = true;
                    break;
                }
            }
            if(bShelve)
            {
                bhaveVoucher = true;
                //保存ToolStripMenuItem.Enabled = false;
            }
            if (sourceVoucher != null)
            {
                txt_VOUCHERNO.Text = sourceVoucher.VoucherNo;
                chensCheckBox1.Checked = true;
                bhaveVoucher = true;
                chensCheckBox1.Enabled = false;
                if (sourceTask.PostStatus == 3)
                {
                    保存ToolStripMenuItem.Enabled = false;
                    txt_VOUCHERNO.Enabled = false;
                    txt_poe.Enabled = false;
                    txt_reason.Enabled = false;
                    txt_sapdoc.Enabled = false;
                    txt_business.Enabled = false;
                    txt_remark.Enabled = false;
                    cmb_store.Enabled = false;
                    txt_time.Enabled = false;
                    txt_businessName.Enabled = false;
                    txt_mateno.Enabled = false;
                }
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
        private void 取消ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txt_mateno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(txt_mateno.Text.Length < 10)
                {
                    MessageBox.Show("物料编号长度不正确");
                    txt_mateno.SelectAll();
                    txt_mateno.Focus();
                    txt_mateno.Tag = null;
                    txt_matename.Tag = null;
                    return;
                }
                //先查临时物料
                string strErr = string.Empty;
                WebService.TempMaterial tempmaterial = null;
                try
                {
                    bool bSucc = WMS.Common.WMSWebService.service.GetTempMaterialByTempNo(txt_mateno.Text, ref tempmaterial, ref strErr);
                    if(bSucc)
                    {
                        txt_matename.Text = tempmaterial.TempMaterialDesc;
                        txt_mateno.Tag = txt_mateno.Text;
                        txt_matename.Tag = tempmaterial;
                        txt_num.Enabled = true;
                        txt_num.SelectAll();
                        txt_num.Focus();
                        return;
                    }
                    else
                    {
                        //再查SAP物料
                        WebService.TaskDetails_Model tdm = null;
                        //bSucc = JingXinWMS.Common.WMSWebService.service.GetMaterialInfoForSAP(txt_mateno.Text, ref tdm, ref strErr);
                        if (bSucc)
                        {
                            txt_matename.Text = tdm.MaterialDesc;
                            txt_mateno.Tag = txt_mateno.Text;
                            txt_matename.Tag = tdm;
                            txt_num.Enabled = true;
                            txt_num.SelectAll();
                            txt_num.Focus();
                            return;
                        }
                    }
                    MessageBox.Show("物料号错误!");
                    txt_matename.Text = "";
                    txt_mateno.SelectAll();
                    txt_mateno.Focus();
                    txt_mateno.Tag = null;
                    txt_matename.Tag = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    txt_mateno.Tag = null;
                    txt_matename.Tag = null;
                }
            }
        }

        private void chensCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chensCheckBox1.Checked)
            {
                txt_VOUCHERNO.Enabled = true;
                txt_sapdoc.Enabled = true;
                //txt_taskno.Enabled = true;
                txt_time.Enabled = true;
                txt_poe.Enabled = true;
                //txt_rownum.Enabled = true;
            }
            else
            {
                txt_VOUCHERNO.Enabled = false;
                txt_sapdoc.Enabled = false;
                txt_taskno.Enabled = false;
                txt_time.Enabled = false;
                txt_poe.Enabled = false;
                txt_rownum.Enabled = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_num_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_add_Click(null, null);
            }
        }
        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            if(!txt_num.Enabled)
            {
                MessageBox.Show("请先输入物料编号");
                return;
            }
            if (bhaveVoucher)
            {
                MessageBox.Show("获取单据的表单数据不能新增记录");
                return;
            }
            //判断新增记录是否完整
            if (txt_mateno.Tag == null)
            {
                MessageBox.Show("请先输入物料编号");
                return;
            }
            Regex r = new Regex(@"^[1-9]\d*$");
            if(!r.IsMatch(txt_num.Text))
            {
                MessageBox.Show("数量格式不正确，请正确输入数量");
                txt_num.SelectAll();
                txt_num.Focus();
                return;
            }
            //判断新增记录是否已存在
            if(body.Count > 0)
            {
                int index;
                if (txt_matename.Tag.ToString().EndsWith("TempMaterial"))
                {
                    index = body.FindIndex(delegate(WebService.TaskDetails_Model v) { return v.TMaterialNo != null && v.TMaterialNo.Equals(txt_mateno.Tag.ToString()); });
                }
                else
                {
                    index = body.FindIndex(delegate(WebService.TaskDetails_Model v) { return v.MaterialNo != null && v.MaterialNo.Equals(txt_mateno.Tag.ToString()); });
                }
                if(index >= 0)
                {
                    body[index].TaskQty += int.Parse(txt_num.Text);
                    bindingSource1.DataSource = body;
                    bindingSource1.ResetBindings(true);
                    this.Refresh();
                    txt_mateno.SelectAll();
                    txt_mateno.Focus();
                    txt_num.Enabled = false;
                    return;
                }
            }
            WebService.TaskDetails_Model tdm = new WebService.TaskDetails_Model();
            if (txt_matename.Tag.ToString().EndsWith("TempMaterial"))
            {
                WebService.TempMaterial tempmaterial = (WebService.TempMaterial)txt_matename.Tag;
                tdm.TMaterialNo = tempmaterial.TempMaterialNo;
                tdm.TMaterialDesc = tempmaterial.TempMaterialDesc;
                tdm.MaterialNo = tempmaterial.MaterialNo;
                tdm.MaterialDesc = tempmaterial.MaterialDesc;
            }
            else
            {
                WebService.TaskDetails_Model material = (WebService.TaskDetails_Model)txt_matename.Tag;
                tdm.MaterialNo = material.MaterialNo;
                tdm.MaterialDesc = material.MaterialDesc;
            }
            //判断和来源单据表体物料号是否匹配

            tdm.TaskQty = int.Parse(txt_num.Text);
            if (!bNewTask)
            {
                tdm.ID = -1;
            }
            body.Add(tdm);
            bindingSource1.DataSource = body;
            bindingSource1.ResetBindings(true);
            this.Refresh();
            txt_mateno.SelectAll();
            txt_mateno.Focus();
            txt_num.Enabled = false;
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (body.Count > 0 && dgv_show.SelectedRows.Count > 0 && dgv_show.SelectedRows[0].Index >= 0 )
            {
                if ((!bNewTask) && body[dgv_show.SelectedRows[0].Index].ID >= 0)
                {
                    if (body[dgv_show.SelectedRows[0].Index].ShelveQty > 0)
                    {
                        MessageBox.Show("该物料已上架，不能修改");
                        return;
                    }
                    lst_delID.Add(body[dgv_show.SelectedRows[0].Index].ID.ToString());
                }
                if (bhaveVoucher)
                {
                    MessageBox.Show("获取单据的表单数据不能删除记录");
                    return;
                }
                body.RemoveAt(dgv_show.SelectedRows[0].Index);
                bindingSource1.DataSource = body;
                bindingSource1.ResetBindings(true);
                this.Refresh();
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (bNewTask)
            {
                if (bhaveVoucher)
                {
                    //SavePostFastIn有单据数据的新增
                    if (txt_businessName.Text.Trim().Length > 0)
                    {
                        head.SupCusName = txt_businessName.Text;
                        head.SupCusNo = txt_business.Text.TrimStart('0');
                    }
                    if (txt_reason.Text.Trim().Length > 0)
                    {
                        head.Reason = txt_reason.Text;
                    }
                    if (txt_remark.Text.Trim().Length > 0)
                    {
                        head.Remark = txt_remark.Text;
                    }
                    if (chensCheckBox1.Checked)
                    {
                        head.IsShelvePost = 2;
                    }
                    else
                    {
                        head.IsShelvePost = 1;
                    }
                    head.CreateUserNo = Common.Common_Var.CurrentUser.UserNo;
                    head.CreateDateTime = txt_time.Value;
                    head.TaskNo = txt_taskno.Text;

                    //检查表体是否完整
                    if (body.Count == 0)
                    {
                        MessageBox.Show("请增加物料记录");
                        return;
                    }
                    if (cmb_store.SelectedItem == null || cmb_store.Text.Equals(""))
                    {
                        MessageBox.Show("请选择库存地点");
                        return;
                    }

                    string strErrMsg = string.Empty;
                    head.lstTaskDetails = body;
                    //给库存地点赋值
                    string StorageLoc = cmb_store.SelectedItem.ToString();
                    //if (cmb_store.SelectedItem.ToString().Equals("JingXinWMS.WebService.StorageLoc_Model"))
                    //{ StorageLoc = ((JingXinWMS.WebService.StorageLoc_Model)cmb_store.SelectedItem).StorageLoc; }
                    head.lstTaskDetails.ForEach(delegate(WebService.TaskDetails_Model v) { v.StorageLoc = StorageLoc; });
                    sourceVoucher.body.ForEach(delegate(WebService.TaskVoucherDetails v) { v.Store = StorageLoc; });
                    bool bSucc = WMS.Common.WMSWebService.service.SavePostFastIn(head, Common.Common_Var.CurrentUser, sourceVoucher, ref strErrMsg);
                    if (bSucc)
                    {
                        MessageBox.Show(strErrMsg);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("保存失败:" + strErrMsg);
                    }
                }
                else
                {
                    //SaveFastIn没有单据数据的新增
                    //检查表头是否完整
                    if (txt_businessName.Text.Trim().Length > 0)
                    {
                        head.SupCusName = txt_businessName.Text;
                        head.SupCusNo = txt_business.Text.TrimStart('0');
                    }
                    if (txt_reason.Text.Trim().Length > 0)
                    {
                        head.Reason = txt_reason.Text;
                    }
                    if (txt_remark.Text.Trim().Length > 0)
                    {
                        head.Remark = txt_remark.Text;
                    }
                    if (chensCheckBox1.Checked)
                    {
                        head.IsShelvePost = 2;
                    }
                    else
                    {
                        head.IsShelvePost = 1;
                    }
                    head.CreateUserNo = Common.Common_Var.CurrentUser.UserNo;
                    head.CreateDateTime = txt_time.Value;
                    head.TaskNo = txt_taskno.Text;
                    //检查表体是否完整
                    if (body.Count == 0)
                    {
                        MessageBox.Show("请增加物料记录");
                        return;
                    }
                    string strErrMsg = string.Empty;
                    
                    head.lstTaskDetails = body;
                    bool bSucc = WMS.Common.WMSWebService.service.SaveFastIn(head, Common.Common_Var.CurrentUser, ref strErrMsg);
                    if (bSucc)
                    {
                        MessageBox.Show(strErrMsg);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("保存失败:" + strErrMsg);
                    }
                }
            }
            else
            {
                if (bhaveVoucher && sourceVoucher != null)
                {
                    string strErrMsg = string.Empty;
                    //UpdatePostFastIn有单据数据的修改
                    if (txt_businessName.Text.Trim().Length > 0)
                    {
                        head.SupCusName = txt_businessName.Text;
                        head.SupCusNo = txt_business.Text;
                    }
                    if (txt_reason.Text.Trim().Length > 0)
                    {
                        head.Reason = txt_reason.Text;
                    }
                    if (txt_remark.Text.Trim().Length > 0)
                    {
                        head.Remark = txt_remark.Text;
                    }
                    if (chensCheckBox1.Checked)
                    {
                        head.IsShelvePost = 2;
                    }
                    else
                    {
                        head.IsShelvePost = 1;
                    }
                    //head.CreateUserNo = Common.Common_Var.CurrentUser.UserNo;
                    //head.CreateDateTime = txt_time.Value;
                    head.TaskNo = txt_taskno.Text;
                    //检查表体是否完整
                    if (cmb_store.SelectedItem == null || cmb_store.Text.Equals(""))
                    {
                        MessageBox.Show("请选择库存地点");
                        return;
                    }

                    if (body.Count == 0)
                    {
                        MessageBox.Show("请增加物料记录");
                        return;
                    }
                    //修改单据
                    head.lstTaskDetails = body;
                    //给库存地点赋值
                    string StorageLoc = cmb_store.SelectedItem.ToString();
                    //if (cmb_store.SelectedItem.ToString().Equals("JingXinWMS.WebService.StorageLoc_Model"))
                    //{ StorageLoc = ((JingXinWMS.WebService.StorageLoc_Model)cmb_store.SelectedItem).StorageLoc; }
                    head.lstTaskDetails.ForEach(delegate(WebService.TaskDetails_Model v) { v.StorageLoc = StorageLoc; });
                    sourceVoucher.body.ForEach(delegate(WebService.TaskVoucherDetails v) { v.Store = StorageLoc; });
                    //head.lstTaskDetails.ForEach(delegate(WebService.TaskDetails_Model v) { v.StorageLoc = cmb_store.SelectedItem.ToString(); });
                    //sourceVoucher.body.ForEach(delegate(WebService.TaskVoucherDetails v) { v.Store = cmb_store.SelectedItem.ToString(); });
                    WMS.WebService.ArrayOfString aos = new WebService.ArrayOfString();
                    aos.AddRange(lst_delID);
                    if(oldVoucher)
                    {
                        strErrMsg = "old";
                    }
                    bool bSucc = WMS.Common.WMSWebService.service.UpdatePostFastIn(head.ID.ToString(), head, sourceVoucher, aos, ref strErrMsg);
                    if (bSucc)
                    {
                        MessageBox.Show(strErrMsg);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("保存失败:" + strErrMsg);
                    }
                }
                else
                {
                    //UpdateFastIn没有单据数据的修改
                    //检查表头是否完整
                    if (txt_businessName.Text.Trim().Length > 0)
                    {
                        head.SupCusName = txt_businessName.Text;
                        head.SupCusNo = txt_business.Text.TrimStart('0');
                    }
                    if (txt_reason.Text.Trim().Length > 0)
                    {
                        head.Reason = txt_reason.Text;
                    }
                    if (txt_remark.Text.Trim().Length > 0)
                    {
                        head.Remark = txt_remark.Text;
                    }
                    if (chensCheckBox1.Checked)
                    {
                        head.IsShelvePost = 2;
                    }
                    else
                    {
                        head.IsShelvePost = 1;
                    }
                    //head.CreateUserNo = Common.Common_Var.CurrentUser.UserNo;
                    //head.CreateDateTime = txt_time.Value;
                    head.TaskNo = txt_taskno.Text;
                    //检查表体是否完整
                    if (body.Count == 0)
                    {
                        MessageBox.Show("请增加物料记录");
                        return;
                    }
                    string strErrMsg = string.Empty;
                    if (oldVoucher)
                    {
                        strErrMsg = "old";
                    }
                    //修改单据
                    head.lstTaskDetails = body;
                    WMS.WebService.ArrayOfString aos = new WebService.ArrayOfString();
                    aos.AddRange(lst_delID);
                    bool bSucc = WMS.Common.WMSWebService.service.UpdateFastIn(head.ID.ToString(), head, aos, ref strErrMsg);
                    if (bSucc)
                    {
                        MessageBox.Show(strErrMsg);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("保存失败:" + strErrMsg);
                    }
                }
            }
        }

        private void txt_VOUCHERNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (bhaveVoucher && sourceVoucher != null)
                {
                    MessageBox.Show("只能加载一张单据表单!");
                    return;
                }
                //判断单据号是否在其它TASK表上
                WebService.TaskVoucher temptv = null;
                string strErrMsg = string.Empty;
                bool bSucc = WMS.Common.WMSWebService.service.GetVoucherByNo(txt_VOUCHERNO.Text, ref temptv, ref strErrMsg);
                if(bSucc)
                {
                    MessageBox.Show("该单号已用在其它任务单上!");
                    txt_VOUCHERNO.SelectAll();
                    txt_VOUCHERNO.Focus();
                    return;
                }
                //获取采购订单
                WebService.DeliveryReceive_Model tempDM = new WebService.DeliveryReceive_Model();
                //bSucc = JingXinWMS.Common.WMSWebService.service.GetPOInfoForSAP(txt_VOUCHERNO.Text, ref tempDM, ref strErrMsg);
                //if(!bSucc)
                //{
                //    MessageBox.Show("单据号错误!");
                //    txt_VOUCHERNO.SelectAll();
                //    txt_VOUCHERNO.Focus();
                //    return;
                //}
                //匹配表体数据
                if(body != null && body.Count == tempDM.lstDeliveryDetail.Count)
                {
                    //如果是新建TASK，则自动生成Voucher表头和表体
                    if (bNewTask)
                    {
                        bhaveVoucher = true;
                        head.VoucherNo = txt_VOUCHERNO.Text;
                        head.SupCusNo = tempDM.SupCode;
                        head.SupCusName = tempDM.SupName;
                        txt_businessName.Text = head.SupCusName;
                        txt_business.Text = head.SupCusNo.TrimStart('0');
                        sourceVoucher = new WebService.TaskVoucher();
                        sourceVoucher.VoucherNo = txt_VOUCHERNO.Text;
                        sourceVoucher.body = new List<WebService.TaskVoucherDetails>();
                        foreach (WebService.DeliveryReceiveDetail_Model drdm in tempDM.lstDeliveryDetail)
                        {
                            //匹配body的物料号和数量
                            WebService.TaskDetails_Model tdm = body.Find(delegate(WebService.TaskDetails_Model v) { return v.MaterialNo == drdm.MaterialNo && v.TaskQty == drdm.CurrentlyDeliveryNum; });
                            if(tdm == null)
                            {
                                MessageBox.Show("该任务的表单物料明细与单据表体不匹配!");
                                txt_VOUCHERNO.SelectAll();
                                txt_VOUCHERNO.Focus();
                                return;
                            }
                            tdm.RowNo = drdm.RowNo;
                            tdm.PlantName = drdm.PlantName;
                            tdm.StorageLoc = drdm.StorageLoc;
                            WebService.TaskVoucherDetails tvd = new WebService.TaskVoucherDetails();
                            tvd.MaterialNo = drdm.MaterialNo;
                            tvd.MaterialDesc = drdm.MaterialDesc;
                            tvd.Factory = drdm.Plant;
                            tvd.FactoryName = drdm.PlantName;
                            tvd.Store = drdm.StorageLoc;
                            tvd.Qty = drdm.CurrentlyDeliveryNum;
                            tvd.RowNo = drdm.RowNo;
                            sourceVoucher.body.Add(tvd);
                        }
                        bindingSource1.DataSource = body;
                        bindingSource1.ResetBindings(true);
                        this.Refresh();
                        if(sourceVoucher.body[0].Store == null || sourceVoucher.body[0].Store.Equals(""))
                        {
                            //List<WebService.StorageLoc_Model> lstStorage = null;
                            //bSucc = JingXinWMS.Common.WMSWebService.service.GetStorageLocByPlantForSAP(sourceVoucher.body[0].Factory, ref lstStorage, ref strErrMsg);
                            //if (bSucc)
                            //{
                            //    WebService.StorageLoc_Model NullStorage = new WebService.StorageLoc_Model();
                            //    NullStorage.StorageLoc = "";
                            //    lstStorage.Insert(0, NullStorage);
                            //    cmb_store.DataSource = lstStorage;
                            //    cmb_store.DisplayMember = "StorageLoc";
                            //    cmb_store.ValueMember = "StorageLoc";
                            //    //MessageBox.Show("请选择库存地点");
                            //}
                            //else
                            //{
                            //    MessageBox.Show("获取库存地点列表失败!");
                            //    return;
                            //}
                            //cmb_store.Items.Add("1101");
                            //MessageBox.Show("请选择库存地点");
                        }
                    }
                    else//否则通过SAP数据匹配已有的表体数据（原有临时物料匹配SAP物料）
                    {
                        if (sourceTask.lstTaskDetails.Count != tempDM.lstDeliveryDetail.Count)
                        {
                            MessageBox.Show("该任务的表单明细行数与单据表体行数不匹配!");
                            txt_VOUCHERNO.SelectAll();
                            txt_VOUCHERNO.Focus();
                            return;

                        }
                        if (!sourceTask.SupCusNo.TrimStart('0').Equals(txt_business.Text.TrimStart('0')))
                        {
                            MessageBox.Show("PO供应商错误，重新检查PO单号");
                            txt_VOUCHERNO.SelectAll();
                            txt_VOUCHERNO.Focus();
                            return;
                        }
                        foreach (WebService.TaskDetails_Model tdm in sourceTask.lstTaskDetails)
                        {
                            int index = tempDM.lstDeliveryDetail.FindIndex(delegate(WebService.DeliveryReceiveDetail_Model v) { return v.MaterialNo.Equals(tdm.MaterialNo) && v.CurrentlyDeliveryNum == tdm.TaskQty; });
                            if (index < 0)
                            {
                                WebService.TempMaterial tempmaterial = null;
                                bSucc = WMS.Common.WMSWebService.service.GetTempMaterialByTempNo(tdm.TMaterialNo, ref tempmaterial, ref strErrMsg);
                                if (bSucc)
                                {
                                    index = tempDM.lstDeliveryDetail.FindIndex(delegate(WebService.DeliveryReceiveDetail_Model v) { return v.MaterialNo.Equals(tempmaterial.MaterialNo) && v.CurrentlyDeliveryNum == tdm.TaskQty; });
                                    if (index < 0)
                                    {
                                        MessageBox.Show("该任务的表单物料明细与单据表体不匹配!");
                                        txt_VOUCHERNO.SelectAll();
                                        txt_VOUCHERNO.Focus();
                                        return;
                                    }
                                    tdm.MaterialNo = tempDM.lstDeliveryDetail[index].MaterialNo;
                                    tdm.MaterialDesc = tempDM.lstDeliveryDetail[index].MaterialDesc;
                                    tdm.TMaterialNo = tempmaterial.TempMaterialNo;
                                    tdm.TMaterialDesc = tempmaterial.TempMaterialDesc;
                                    tdm.TaskQty = tempDM.lstDeliveryDetail[index].CurrentlyDeliveryNum;
                                    tdm.RowNo = tempDM.lstDeliveryDetail[index].RowNo;
                                    tdm.Plant = tempDM.lstDeliveryDetail[index].Plant;
                                    tdm.PlantName = tempDM.lstDeliveryDetail[index].PlantName;
                                    tdm.StorageLoc = tempDM.lstDeliveryDetail[index].StorageLoc;
                                }
                                else
                                {
                                    MessageBox.Show("获取临时物料对应关系失败!");
                                    txt_VOUCHERNO.SelectAll();
                                    txt_VOUCHERNO.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                tdm.MaterialNo = tempDM.lstDeliveryDetail[index].MaterialNo;
                                tdm.MaterialDesc = tempDM.lstDeliveryDetail[index].MaterialDesc;
                                tdm.TaskQty = tempDM.lstDeliveryDetail[index].CurrentlyDeliveryNum;
                                tdm.RowNo = tempDM.lstDeliveryDetail[index].RowNo;
                                tdm.Plant = tempDM.lstDeliveryDetail[index].Plant;
                                tdm.PlantName = tempDM.lstDeliveryDetail[index].PlantName;
                                tdm.StorageLoc = tempDM.lstDeliveryDetail[index].StorageLoc;
                            }
                        }
                        bhaveVoucher = true;
                        head.SupCusNo = tempDM.SupCode;
                        head.SupCusName = tempDM.SupName;
                        txt_businessName.Text = head.SupCusName;
                        txt_business.Text = head.SupCusNo.TrimStart('0');

                        sourceVoucher = new WebService.TaskVoucher();
                        sourceVoucher.VoucherNo = txt_VOUCHERNO.Text;
                        sourceVoucher.body = new List<WebService.TaskVoucherDetails>();
                        foreach (WebService.DeliveryReceiveDetail_Model drdm in tempDM.lstDeliveryDetail)
                        {
                            WebService.TaskVoucherDetails tvd = new WebService.TaskVoucherDetails();
                            tvd.MaterialNo = drdm.MaterialNo;
                            tvd.MaterialDesc = drdm.MaterialDesc;
                            tvd.Factory = drdm.Plant;
                            tvd.FactoryName = drdm.PlantName;
                            tvd.Store = drdm.StorageLoc;
                            tvd.Qty = drdm.CurrentlyDeliveryNum;
                            tvd.RowNo = drdm.RowNo;
                            sourceVoucher.body.Add(tvd);
                        }
                        body = sourceTask.lstTaskDetails;
                        bindingSource1.DataSource = body;
                        bindingSource1.ResetBindings(true);
                        this.Refresh();
                        if (sourceVoucher.body[0].Store == null || sourceVoucher.body[0].Store.Equals(""))
                        {
                            //List<WebService.StorageLoc_Model> lstStorage = null;
                            //bSucc = JingXinWMS.Common.WMSWebService.service.GetStorageLocByPlantForSAP(sourceVoucher.body[0].Factory, ref lstStorage, ref strErrMsg);
                            //if (bSucc)
                            //{
                            //    WebService.StorageLoc_Model NullStorage = new WebService.StorageLoc_Model();
                            //    NullStorage.StorageLoc = "";
                            //    lstStorage.Insert(0, NullStorage);
                            //    cmb_store.DataSource = lstStorage;
                            //    cmb_store.DisplayMember = "StorageLoc";
                            //    cmb_store.ValueMember = "StorageLoc";
                            //    //MessageBox.Show("请选择库存地点");
                            //}
                            //else
                            //{
                            //    MessageBox.Show("获取库存地点列表失败!");
                            //    return;
                            //}
                            //cmb_store.Items.Add("1101");
                            //MessageBox.Show("请选择库存地点");
                        }
                        else
                        {
                            cmb_store.Items.Add(sourceVoucher.body[0].Store);
                            cmb_store.SelectedItem = sourceVoucher.body[0].Store;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("单据表单数据匹配错误!");
                    txt_VOUCHERNO.SelectAll();
                    txt_VOUCHERNO.Focus();
                    return;
                }
            }
        }

        private void dgv_show_SelectionChanged(object sender, EventArgs e)
        {
            if(dgv_show.SelectedRows != null && dgv_show.SelectedRows.Count > 0)
            {
                if(dgv_show.SelectedRows[0].Cells["MATERIALNODataGridViewTextBoxColumn"].Value.ToString().Length > 0)
                {
                    txt_mateno.Text = dgv_show.SelectedRows[0].Cells["MATERIALNODataGridViewTextBoxColumn"].Value.ToString();
                    txt_matename.Text = dgv_show.SelectedRows[0].Cells["MATERIALDESCDataGridViewTextBoxColumn"].Value.ToString();
                    WebService.TaskDetails_Model tdm = new WebService.TaskDetails_Model();
                    tdm.MaterialNo = txt_mateno.Text;
                    tdm.MaterialDesc = txt_matename.Text;
                    //tdm.TMaterialNo = dgv_show.SelectedRows[0].Cells["tTEMPMATERIALNODataGridViewTextBoxColumn"].Value.ToString();
                    //tdm.TMaterialDesc = dgv_show.SelectedRows[0].Cells["tTEMPMATERIALDESCDataGridViewTextBoxColumn"].Value.ToString();
                    txt_matename.Tag = tdm;
                    txt_mateno.Tag = txt_mateno.Text;
                }
                else
                {
                    txt_mateno.Text = dgv_show.SelectedRows[0].Cells["tTEMPMATERIALNODataGridViewTextBoxColumn"].Value.ToString();
                    txt_matename.Text = dgv_show.SelectedRows[0].Cells["tTEMPMATERIALDESCDataGridViewTextBoxColumn"].Value.ToString();
                    WebService.TempMaterial tempmaterial = new WebService.TempMaterial();
                    tempmaterial.TempMaterialNo = dgv_show.SelectedRows[0].Cells["tTEMPMATERIALNODataGridViewTextBoxColumn"].Value.ToString();
                    tempmaterial.TempMaterialDesc = dgv_show.SelectedRows[0].Cells["tTEMPMATERIALDESCDataGridViewTextBoxColumn"].Value.ToString();
                    txt_matename.Tag = tempmaterial;
                    txt_mateno.Tag = txt_mateno.Text;
                }
                txt_num.Text = dgv_show.SelectedRows[0].Cells["TaskQty"].Value.ToString();
                if (dgv_show.SelectedRows[0].Cells["ROWNO"].Value != null)
                {
                    txt_rownum.Text = dgv_show.SelectedRows[0].Cells["ROWNO"].Value.ToString();
                }
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            //判断新增记录是否完整
            if(bhaveVoucher)
            {
                MessageBox.Show("获取单据的表单数据不能修改");
                return;
            }
            Regex r = new Regex(@"^[1-9]\d*$");
            if (!r.IsMatch(txt_num.Text))
            {
                MessageBox.Show("数量格式不正确，请正确输入数量");
                txt_num.SelectAll();
                txt_num.Focus();
                return;
            }
            //判断新增记录是否已存在
            if (body.Count > 0)
            {
                int index;
                if (dgv_show.SelectedRows[0].Cells["MATERIALNODataGridViewTextBoxColumn"].Value.ToString().Length > 0)
                {
                    index = body.FindIndex(delegate(WebService.TaskDetails_Model v) { return v.MaterialNo != null && v.MaterialNo.Equals(txt_mateno.Text); });
                }
                else
                {
                    index = body.FindIndex(delegate(WebService.TaskDetails_Model v) { return v.TMaterialNo != null && v.TMaterialNo.Equals(txt_mateno.Text); });
                }
                if (index >= 0)
                {
                    if(body[index].ShelveQty > 0)
                    {
                        MessageBox.Show("该物料已上架，不能修改");
                        return;
                    }
                    body[index].TaskQty = int.Parse(txt_num.Text);
                    bindingSource1.DataSource = body;
                    bindingSource1.ResetBindings(true);
                    this.Refresh();
                    txt_mateno.SelectAll();
                    txt_mateno.Focus();
                    return;
                }
            }
            MessageBox.Show("无法修改表单中不存在的物料记录");
        }
        //供应商
        private void txt_business_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(txt_business.Text.Trim().Length > 0)
                {
                    //WebService.Supplier_Model supplier = new WebService.Supplier_Model();
                    //supplier.SupplierCode = txt_business.Text.Trim();
                    //string errMsg = "";
                    //bool re = JingXinWMS.Common.WMSWebService.service.GetSupplierInfoForSAP(ref supplier, ref errMsg);
                    //if (re == true)
                    //{
                    //    txt_businessName.Text = supplier.SupplierName;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("获取供应商信息失败:" + errMsg);
                    //}
                }
                else
                {
                    txt_businessName.Text = "";
                }
            }
        }
    }
}
