using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using QRCodeDecoderLibrary;
using QRCoder;
using QsonLibrary;

namespace QsonTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1
            {
                Data1 = 10,
                Data2 = 20,
                Data3 = "متن تستی",
                Data4 = 1234,
                Data5 = new List<int> {1, 2, 3},
                Data6 = new List<int?> {1, null, 3},
                Data7 = new List<string> {"a","bcd","ef"}
            };
            
            var b = class1.BinarySerialize();

            var c1 = b.BinaryDeserialize(typeof(Class1), out int len);


            Class2 class2 = new Class2
            {
                Data1 = new Class3
                {
                    Data1 = 10,
                    Data2 = "John",
                    Data3 = new List<string>{"1",null,"2","3"}
                },
                Data2 = new List<Class3>
                {
                    new()
                    {
                        Data1 = 20,
                        Data2 = "20",
                        Data3 = new List<string>{"1","2","3"}
                    },
                    null,
                    new()
                    {
                        Data1 = 30,
                        Data2 = "30",
                        Data3 = new List<string>{"1","2",null,"3"}
                    },
                    new()
                    {
                        Data1 = 40,
                        Data2 = "4040",
                        Data3 = new List<string>{"1","2","3"}
                    },
                }
            };

            var b2 = class2.BinarySerialize();

            var c2 = b2.BinaryDeserialize(typeof(Class2), out len);

            try
            {
                TestClass testClass1 = TestClass.CreateSample1();
                var bytes1 = testClass1.BinarySerialize();
                Console.WriteLine(bytes1.Length);
                var tc1 = (TestClass)bytes1.BinaryDeserialize(typeof(TestClass), out int length);
                Console.WriteLine(length);
                Console.WriteLine(testClass1.IsEqual(tc1));

                Console.WriteLine();

                TestClass testClass2 = TestClass.CreateSample2();
                var bytes2 = testClass2.BinarySerialize();
                Console.WriteLine(bytes2.Length);
                var tc2 = (TestClass)bytes2.BinaryDeserialize(typeof(TestClass), out length);
                Console.WriteLine(length);
                Console.WriteLine(testClass2.IsEqual(tc2));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine();

            var bytes = new byte[500];
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = (byte) (i % byte.MaxValue);
            var res = bytes.ToQrCode(20);
            var dbytes = res.ToByteArray();
            var r = true;
            for (int i = 0; i < dbytes.Length; i++)
                if (dbytes[i] != bytes[i])
                {
                    r = false;
                    return;
                }

            Console.WriteLine(r);

            bytes = new byte[5000];
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = (byte)(i % byte.MaxValue);
            res = bytes.ToQrCode(20);
            dbytes = res.ToByteArray();
            r = true;
            for (int i = 0; i < dbytes.Length; i++)
                if (dbytes[i] != bytes[i])
                {
                    r = false;
                    return;
                }
            Console.WriteLine();

            var res2 = new Bitmap[res.Length - 1];
            for (int i = 0; i < res2.Length; i++)
                res2[i] = res[i + 1];
            try
            {
                dbytes = res2.ToByteArray();
                r = true;
                for (int i = 0; i < dbytes.Length; i++)
                    if (dbytes[i] != bytes[i])
                    {
                        r = false;
                        return;
                    }

                Console.WriteLine(r);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();

            var res3 = new Bitmap[res.Length - 1];
            for (int i = 0; i < res3.Length; i++)
                res3[i] = res[i];
            try
            {
                dbytes = res3.ToByteArray();
                r = true;
                for (int i = 0; i < dbytes.Length; i++)
                    if (dbytes[i] != bytes[i])
                    {
                        r = false;
                        return;
                    }

                Console.WriteLine(r);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
        }
    }
}
