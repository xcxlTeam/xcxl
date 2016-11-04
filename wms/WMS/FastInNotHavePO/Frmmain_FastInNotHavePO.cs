using WMS.WebService;
using WMS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WMS.FastInNotHavePO
{
    public partial class Frmmain_FastInNotHavePO : Common.FrmBasic
    {

        private int MaterialType = 0; //物料类型  10-临时物料  20-SAP物料
        public Frmmain_FastInNotHavePO()
        {
            InitializeComponent();
           
        }

        //保存输入的物料号编码，用于检验输入的物料号编码是否相同，相同的物料号编码，数量相加
        List<TaskDetails_Model> tmlist = new List<TaskDetails_Model>();
       // 临时List集合 用于Datagridview显示使用
        List<TaskDetails_Model> tempList = new List<TaskDetails_Model>();
        private void btn_add_Click(object sender, EventArgs e)
        {
            MaterialType = 10; //测试

            TaskDetails_Model tm = new TaskDetails_Model();
            TaskDetails_Model temp = new TaskDetails_Model(); // 临时对象
            try
            {
                string materialNo = txt_mateno.Text.Trim();
                string materialNum = txt_num.Text.Trim();
                string materialDesc = txt_matename.Text.Trim();

                if (string.IsNullOrEmpty(materialNo) || string.IsNullOrEmpty(materialNum))
                {
                    MessageBox.Show("请输入物料号以及数量！");
                    return;
                }
                int i;
                if (!int.TryParse(materialNum, out i))
                {
                    MessageBox.Show("数量处请输入数字！");
                    return;
                }

                    temp = tempList.Find(delegate(TaskDetails_Model t) { return t.MaterialNo == materialNo; });
                   if (temp == null)
                   {
                       temp = new TaskDetails_Model();
                       temp.MaterialNo = materialNo;
                       temp.MaterialDesc = materialDesc;
                       temp.TaskQty = int.Parse(materialNum);

                       tempList.Add(temp);
                   }
                   else
                   {
                       temp.TaskQty += int.Parse(materialNum);
                   }

                   // 判断物料的类型
                   switch (MaterialType)
                   {
                       case 10:  //临时物料
                           tm = tmlist.Find(delegate(TaskDetails_Model t) { return t.TMaterialNo == materialNo; });
                           if (tm == null)
                           {
                               tm = new TaskDetails_Model();

                               tm.TMaterialNo = materialNo;
                               tm.TMaterialDesc = materialDesc;
                               tm.TaskQty = int.Parse(materialNum);
                               tmlist.Add(tm);
                           }
                           else
                           {
                               tm.TaskQty += int.Parse(materialNum);
                           }

                           break;
                       case 20: //SAP物料
                           tm = tmlist.Find(delegate(TaskDetails_Model t) { return t.MaterialNo == materialNo; });
                           if (tm == null)
                           {
                               tm = new TaskDetails_Model();

                               tm.MaterialNo = materialNo;
                               tm.MaterialDesc = materialDesc;
                               tm.TaskQty = int.Parse(materialNum);
                               tmlist.Add(tm);
                           }
                           else
                           {
                               tm.TaskQty += int.Parse(materialNum);
                           }

                           break;
                       default:
                           break;
                   }


                    RefurbishList();

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_mateno_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                MaterialType = 0;

                string materialNo = txt_mateno.Text.Trim();

                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(materialNo))
                    {
                        MessageBox.Show("请输入物料号！");
                        return;
                    }

                    //判断当前物料是否是临时物料
                    bool isTempMaterial =  WMSWebService.service.ExistsTempMaterialByMaterialNo(materialNo);
                   
                    if (isTempMaterial)
                    {
                        string matetialName ="";
                        bool isHaveName = WMSWebService.service.GetTempMaterialName(materialNo ,ref matetialName);
                        if(isHaveName)
                        {
                            txt_matename.Text = matetialName;
                            MaterialType = 10;
                        }
                     
                        return;
                    }
                    else 
                    {
                        TaskDetails_Model tmSAP = new TaskDetails_Model();
                        string msg = "";
                        //判断当前物料是否是SAP物料
                        //bool isMaterialForSAP = WMSWebService.service.GetMaterialInfoForSAP(materialNo,ref tmSAP,ref msg);
                        //if (isMaterialForSAP)
                        //{
                        //    txt_matename.Text = tmSAP.MaterialDesc;
                        //    MaterialType = 20;
                        //    return;
                        //}
                        //else
                        //{
                        //    MessageBox.Show("sap物料和临时物料都不存在，请重新输入物料号！");
                        //}
                    }
                   
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void RefurbishList()
        {
            dgv_show.DataSource = null;
            dgv_show.DataSource = tempList;
            txt_mateno.Text = "";
            txt_matename.Text = "";
            txt_num.Text = ""; 
            txt_mateno.Select();
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                string mateno = "";
                try
                {
                    mateno = dgv_show.SelectedRows[0].Cells["tMATERIALNODataGridViewTextBoxColumn"].Value.ToString();
                }
                catch
                {
                    MessageBox.Show("请选择删除行！");
                    return;
                }

                deletemate(mateno);
                dgv_show.DataSource = null;
                dgv_show.DataSource = tempList;
              
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void deletemate(string mateno)
        {
            for (int i = 0; i < tempList.Count; i++)
            {
                if (tempList[i].MaterialNo == mateno)
                {
                    tempList.RemoveAt(i);
                    break;
                }
            }

            for(int i= 0; i < tmlist.Count; i++)
            {
                if (tmlist[i].MaterialNo == mateno || tmlist[i].TMaterialNo == mateno)
                {
                    tmlist.RemoveAt(i);
                    break;
                }
            }


        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 取消ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
