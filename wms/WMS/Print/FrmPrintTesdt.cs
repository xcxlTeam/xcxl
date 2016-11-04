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

namespace WMS.Print
{
    public partial class FrmPrintTesdt : Common.FrmBasic
    {
        public FrmPrintTesdt()
        {
            InitializeComponent();
        }

        private void FrmPrintTesdt_Load(object sender, EventArgs e)
        {

        }

        private void tsmiPrint_Click(object sender, EventArgs e)
        {
            PrintLabel();
        }

        private void tsmiCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintLabel()
        {
            int StartX = nbStartX.Value.ToInt32();
            int StartY = nbStartY.Value.ToInt32();
            int Width = nbWidth.Value.ToInt32();
            int Heigh = nbHeigh.Value.ToInt32();

            string BasicFontName = txtBasicFontName.Text;
            int BasicFontSize = nbBasicFontSize.Value.ToInt32(); ;

            int BaiscColMargin = nbBaiscColMargin.Value.ToInt32();
            int BasicRowHeigh = nbBasicRowHeigh.Value.ToInt32();
            int MinRowMargin = nbMinRowMargin.Value.ToInt32();

            int PictrueTopPad = nbPictrueTopPad.Value.ToInt32();
            int PictrueRightPad = nbPictrueRightPad.Value.ToInt32();

            int CheckedMargin = nbCheckedMargin.Value.ToInt32();
            int CheckedOffset = nbCheckedOffset.Value.ToInt32();


            Barcode_Model barcode = new Barcode_Model();
            barcode.CUSNAME = "京信通信";
            barcode.SUPCODE = "600212";
            barcode.SUPNAME = "深圳市威凌科技有限公司";
            barcode.MATERIALNO = "102001-000055-00";
            barcode.MATERIALDESC = "DB15,直针焊板带螺母(三排) DB15,直针焊板带螺母(三排)";
            barcode.VOUCHERNO = "4700286343";
            barcode.ROWNO = "00010";
            barcode.QTY = 500;
            barcode.PRDVERSION = "TEST VER.";
            barcode.BATCHNO = "20140714";
            barcode.INNERCOUNT = 5;
            barcode.INNERPACKQTY = 100;
            barcode.MANTISSAQTY = 0;
            barcode.OUTCOUNT = 10;
            barcode.BATCHQTY = 5000;
            barcode.BARCODENO = 1;
            barcode.SERIALNO = "201507140044";
            barcode.BARCODE = "10@102001-000055-00@201507140044";
            barcode.BPlatedSilver = true;

            PrintLibrary.PrintLibrary_Func.PrintTest(Print_Func.GetPrintBarcodeByServiceBarcode(barcode), Print_Var.OutboxPrinter, 200, StartX, StartY, Width, Heigh, BasicFontName, BasicFontSize, BaiscColMargin, BasicRowHeigh, MinRowMargin, PictrueTopPad, PictrueRightPad, CheckedMargin, CheckedOffset);

        }
    }
}
