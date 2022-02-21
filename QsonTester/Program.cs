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
                Data3 = "Sample Text"
            };

            var b = class1.BinarySerialize();



            Console.WriteLine("Hello World!");
        }
    }
}
