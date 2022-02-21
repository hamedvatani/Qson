using System.Drawing.Imaging;
using QRCoder;

namespace QsonLibrary
{
    public static class QrcodeHelper
    {
        public static void ToQrCode(this byte[] data)
        {
            var qrCodeGenerator = new QRCodeGenerator();
            var qrCodeData = qrCodeGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.H);
            var qrCode = new QRCode(qrCodeData);
            var bmp=qrCode.GetGraphic(100);
            bmp.Save(@"c:\test.bmp", ImageFormat.Bmp);
        }
    }
}