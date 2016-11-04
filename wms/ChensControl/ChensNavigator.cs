using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChensControl
{
    public partial class ChensNavigator : UserControl
    {
        public ChensNavigator()
        {
            InitializeComponent();
            jsModules = new JSModules();
            //jsModules.InitJSMoudles();
            //CreateMenuButton1s();
        }

        public void SetMenu(JSModules _js)
        {
            jsModules = _js;
            CreateMenuButton1s();
            ResizeControls();
        }

        private void CreateMenuButton1s()
        {
            foreach (JSModule jsmodule in jsModules.modules)
            {

                //如果是一级菜单，则画按钮
                if (jsmodule.Level == "1")
                {
                    CreateMenuButton1(jsmodule);

                }
            }
        }

        public JSModules jsModules;

        private void CreateMenuButton1(JSModule module)
        {
            Panel panel = new Panel();
            panel.Visible = module.OpenFlag;
            this.Controls.Add(panel);
            
            ChensMenuButton1 button1 = new ChensMenuButton1(module,this.jsModules,panel);
            AddClickHandleToMenuButton2(panel);
            button1.Click += new EventHandler(MenuButton1_click);
            button1.Left = 0;
            button1.Width = this.Width-1;
            module.menuButton1 = button1;

            this.Controls.Add(button1);

            
        }

        private void AddClickHandleToMenuButton2(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                control.Click += new EventHandler(MenuButton2_Click);
            }
        }

        private void MenuButton1_click(object sender, EventArgs e)
        {
            ChensMenuButton1 button1 = (ChensMenuButton1)sender;
            bool oldFlag = button1.jsmodule.OpenFlag;
            foreach (JSModule jsmodule in jsModules.modules)
            {
                jsmodule.OpenFlag = false;
            }
            button1.jsmodule.OpenFlag = !oldFlag;
            

            this.ResizeControls();
        }

        //定义委托
        public delegate void MenuButton2ClickHandle(object sender, EventArgs e);

        //定义事件
        public event MenuButton2ClickHandle MenuButton2Click;

        private void MenuButton2_Click(object sender, EventArgs e)
        {
            //ChensMenuButton2 button2 = sender as ChensMenuButton2;
            //MessageBox.Show("you clike " + button2.jsmodule.Name);
            if (MenuButton2Click != null)
                MenuButton2Click(sender, e);
        }

        

        private void ChensNavigator_Paint(object sender, PaintEventArgs e)
        {
            //主背景色  52, 65, 74
            Graphics g = e.Graphics;
            SolidBrush b = new SolidBrush(Color.FromArgb(50, 140, 190));
            g.FillRectangle(b, 0, 0, this.Width, this.Height);

            b.Dispose();
        }

        private void ChensNavigator_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
            ResizeControls();
            
        }

        private void ResizePanelControl(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                control.Width = panel.Width;
            }
        }

        private void ResizeControls()
        {
            if (jsModules == null || jsModules.modules == null)
            {
                return;
            }

            int lastTop = 0;

            foreach (JSModule jsmodule in jsModules.modules)
            {

                //如果是一级菜单
                if (jsmodule.Level == "1")
                {
                    jsmodule.menuButton1.Top = lastTop;
                    jsmodule.menuButton1.Width = this.Width;
                    if (jsmodule.OpenFlag == true)
                    {
                        jsmodule.menuButton1.childPanel.Visible = true;
                        jsmodule.menuButton1.childPanel.Top = jsmodule.menuButton1.Top + jsmodule.menuButton1.Height;
                        jsmodule.menuButton1.childPanel.Width = this.Width;
                        ResizePanelControl(jsmodule.menuButton1.childPanel);
                        lastTop = jsmodule.menuButton1.childPanel.Top + jsmodule.menuButton1.childPanel.Height;
                    }
                    else
                    {
                        jsmodule.menuButton1.childPanel.Visible = false;
                        lastTop = jsmodule.menuButton1.Bottom ;
                    }

                }
            }
        }
    }
}
