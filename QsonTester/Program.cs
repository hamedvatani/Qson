using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
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
                Data3 = "Sample Text",
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

        }
    }
}
