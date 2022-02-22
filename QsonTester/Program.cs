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
                    Data2 = "John"
                },
                Data2 = new List<Class3>
                {
                    new()
                    {
                        Data1 = 20,
                        Data2 = "20"
                    },
                    null,
                    new()
                    {
                        Data1 = 30,
                        Data2 = "30"
                    },
                    new()
                    {
                        Data1 = 40,
                        Data2 = "4040"
                    },
                }
            };

            var b2 = class2.BinarySerialize();

            var c2 = b2.BinaryDeserialize(typeof(Class2), out len);

            Console.WriteLine("Hello World!");
        }
    }
}
