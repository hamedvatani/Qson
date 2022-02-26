using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using QRCodeDecoderLibrary;
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

        public static byte[] ToByteArray(this Bitmap[] images)
        {
            var decodedData = new List<Tuple<int, bool, byte[]>>();

            foreach (var image in images)
            {
                QRDecoder decoder = new QRDecoder();
                var res = decoder.ImageDecoder(image);
                if (res == null || res.Length == 0 || res[0].Length < 3)
                    throw new Exception("Invalid image");
                decodedData.Add(new Tuple<int, bool, byte[]>(res[0][0], res[0][1] != 0, res[0].Separate(2)));
            }

            decodedData.Sort((x, y) => x.Item1.CompareTo(y.Item1));

            for (int i = 0; i < decodedData.Count; i++)
                if (decodedData[i].Item1 != i)
                    throw new Exception("Images are not complete");
            if (!decodedData[^1].Item2)
                throw new Exception("Last Image missing");

            var retVal = Array.Empty<byte>();
            for (int i = 0; i < decodedData.Count; i++)
                retVal = retVal.Concat(decodedData[i].Item3);

            return retVal;
        }
    }
}