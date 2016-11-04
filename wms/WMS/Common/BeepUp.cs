using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace WMS.Common
{
    public class BeepUp
    {

        [DllImport("Kernel32.dll")] //引入命名空间 using System.Runtime.InteropServices;  
        public static extern bool Beep(int frequency, int duration);

        public static void Waringbeep()
        {
            Beep(1000, 1000);
        }

        public static void DoShine(System.Windows.Forms.Control control)
        {

            ParameterizedThreadStart ParStart = new ParameterizedThreadStart(Shine);
            Thread myThread = new Thread(ParStart);

            myThread.Start(control);
        }
        public static void Shine(object ParObjectl)
        {

            System.Windows.Forms.Control control = (System.Windows.Forms.Control)ParObjectl;
            Color color = control.ForeColor;
            int i = 0;
            while (i < 10)
            {
                control.ForeColor = Color.Blue;
                //control.Refresh();
                System.Threading.Thread.Sleep(500);
                control.ForeColor = Color.Red;
                //control.Refresh();
                System.Threading.Thread.Sleep(500);
                i++;
            }
            control.ForeColor = color;
        }
    }
}
