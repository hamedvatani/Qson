using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using QsonLibrary;

namespace QsonTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var c1 = TestClass.CreateSample1();
            var c2 = TestClass.CreateSample2();

            var b1 = c1.BinarySerialize();
            var b2 = c2.BinarySerialize();

            Console.WriteLine("Hello World!");
        }
    }
}
