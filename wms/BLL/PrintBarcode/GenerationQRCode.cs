using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
//using ThoughtWorks.QRCode.Codec;

namespace PrintBarcode
{
    public class GenerationQRCode
    {
        public Image CreateQRCode(string strBarcode)
        {
            try
            {
                //QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                //qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                //qrCodeEncoder.QRCodeScale = 2;
                //qrCodeEncoder.QRCodeVersion = 0;
                //qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                //return qrCodeEncoder.Encode(strBarcode);
                return null;
            }
            catch (Exception ex)
            {
                //throw new Exception("生成发料通知单二维码错误。");
                throw new Exception(ex.Message);
            }
        }
    }
}
