using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using QRCoder;

namespace QsonLibrary
{
    public static class QrCodeHelper
    {
        public static Bitmap[] ToQrCode(this byte[] data, int pixelPerModule)
        {
            const int h = 1273-2, q = 1663-2, m = 2331-2, l = 2953-2;

            int count = (int) Math.Ceiling((double) data.Length / l);
            int len = (int) Math.Ceiling((double) data.Length / count);
            var level = len switch
            {
                <= h => QRCodeGenerator.ECCLevel.H,
                <= q => QRCodeGenerator.ECCLevel.Q,
                <= m => QRCodeGenerator.ECCLevel.M,
                _ => QRCodeGenerator.ECCLevel.L
            };

            var retVal = new Bitmap[count];
            for (byte i = 0; i < count; i++)
            {
                var size = data.Length - i * len;
                if (size > len)
                    size = len;
                var dat = data.Skip(i * len).Take(size).ToArray();
                var header = new byte[2];
                header[0] = i;
                header[1] = i == count - 1 ? (byte) 1 : (byte) 0;
                dat = header.Concat(dat);

                var qGen = new QRCodeGenerator();
                var qData = qGen.CreateQrCode(dat, level);
                var qCode = new QRCode(qData);
                retVal[i] = qCode.GetGraphic(pixelPerModule);
            }

            return retVal;
        }

        public static byte[] FromQrCode(this Bitmap[] images)
        {

            return null;

            // var options = new DecodingOptions { PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.QR_CODE }, TryHarder = true };
            // var reader = new BarcodeReader(null, null, ls => new GlobalHistogramBinarizer(ls)) { AutoRotate = false, TryInverted = false, Options = options };
            // var result = reader.Decode(image);




        }
    }
}