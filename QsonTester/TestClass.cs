using System;
using System.Collections.Generic;

namespace QsonTester
{
    public class TestClass
    {
        public bool BoolData { get; set; }
        public char CharData { get; set; }
        public sbyte SbyteData { get; set; }
        public byte ByteData { get; set; }
        public short ShortData { get; set; }
        public ushort UshortData { get; set; }
        public int IntData { get; set; }
        public uint UintData { get; set; }
        public long LongData { get; set; }
        public ulong UlongData { get; set; }
        public float FloatData { get; set; }
        public double DoubleData { get; set; }
        public decimal DecimalData { get; set; }
        public DateTime DateTimeData { get; set; }
        public string StringData { get; set; }

        public bool? NBoolData { get; set; }
        public char? NCharData { get; set; }
        public sbyte? NSbyteData { get; set; }
        public byte? NByteData { get; set; }
        public short? NShortData { get; set; }
        public ushort? NUshortData { get; set; }
        public int? NIntData { get; set; }
        public uint? NUintData { get; set; }
        public long? NLongData { get; set; }
        public ulong? NUlongData { get; set; }
        public float? NFloatData { get; set; }
        public double? NDoubleData { get; set; }
        public decimal? NDecimalData { get; set; }
        public DateTime? NDateTimeData { get; set; }

        public List<int> IntListData { get; set; }
        public int[] IntArrayData { get; set; }
        public List<string> StringListData { get; set; }
        public string[] StringArrayData { get; set; }

        public Person Person { get; set; }
        public List<Person> PersonList { get; set; }
        public Person[] PersonArray { get; set; }

        public static TestClass CreateSample1()
        {
            return new TestClass
            {
                BoolData = true,
                CharData = 'a',
                SbyteData = -12,
                ByteData = 12,
                ShortData = -34,
                UshortData = 34,
                IntData = -1120,
                UintData = 1120,
                LongData = -3450,
                UlongData = 3450,
                FloatData = (float) 12.3,
                DoubleData = -45.78,
                DecimalData = (decimal) 123.456,
                DateTimeData = DateTime.Now,
                StringData = "Test String",
                NBoolData = true,
                NCharData = null,
                NSbyteData = -12,
                NByteData = null,
                NShortData = -34,
                NUshortData = null,
                NIntData = -1120,
                NUintData = null,
                NLongData = -3450,
                NUlongData = null,
                NFloatData = (float) 12.3,
                NDoubleData = null,
                NDecimalData = (decimal) 123.456,
                NDateTimeData = null,
                IntListData = new List<int> {1, 2, 3, 4, 5},
                IntArrayData = new[] {6, 7, 8, 9, 10},
                StringListData = new List<string> {"123", "abc", null, "Test"},
                StringArrayData = new[] {"XYZ", null, "456", "Hello World!"},
                Person = new Person
                {
                    Name = "Ali",
                    Tels = new[] {"12", "34", "56"}
                },
                PersonList = new List<Person>
                {
                    new()
                    {
                        Name = "John",
                        Tels = null
                    },
                    new()
                    {
                        Name = "Mark",
                        Tels = new[] {"123456"}
                    },
                    new()
                    {
                        Name = "Smith",
                        Tels = new[] {"1234", "5678"}
                    }
                },
                PersonArray = new[]
                {
                    new Person
                    {
                        Name = "John2",
                        Tels = null
                    },
                    new Person
                    {
                        Name = "Mark2",
                        Tels = new[] {"123456"}
                    },
                    new Person
                    {
                        Name = "Smith2",
                        Tels = new[] {"1234", "5678"}
                    }
                }
            };
        }

        public static TestClass CreateSample2()
        {
            return new TestClass
            {
                BoolData = true,
                CharData = 'a',
                SbyteData = -12,
                ByteData = 12,
                ShortData = -34,
                UshortData = 34,
                IntData = -1120,
                UintData = 1120,
                LongData = -3450,
                UlongData = 3450,
                FloatData = (float) 12.3,
                DoubleData = -45.78,
                DecimalData = (decimal) 123.456,
                DateTimeData = DateTime.Now,
                StringData = "Test String",
                NBoolData = null,
                NCharData = 'a',
                NSbyteData = null,
                NByteData = 12,
                NShortData = null,
                NUshortData = 34,
                NIntData = null,
                NUintData = 1120,
                NLongData = null,
                NUlongData = 3450,
                NFloatData = null,
                NDoubleData = -45.78,
                NDecimalData = null,
                NDateTimeData = DateTime.Now,
                IntListData = new List<int> {1, 2, 3, 4, 5},
                IntArrayData = new[] {6, 7, 8, 9, 10},
                StringListData = new List<string> {"123", "abc", null, "Test"},
                StringArrayData = new[] {"XYZ", null, "456", "Hello World!"},
                Person = new Person
                {
                    Name = "Ali",
                    Tels = new[] {"12", "34", "56"}
                },
                PersonList = new List<Person>
                {
                    new()
                    {
                        Name = "John2",
                        Tels = null
                    },
                    new()
                    {
                        Name = "Mark2",
                        Tels = new[] {"123456"}
                    },
                    new()
                    {
                        Name = "Smith2",
                        Tels = new[] {"1234", "5678"}
                    }
                },
                PersonArray = new[]
                {
                    new Person
                    {
                        Name = "John2",
                        Tels = null
                    },
                    new Person
                    {
                        Name = "Mark2",
                        Tels = new[] {"123456"}
                    },
                    new Person
                    {
                        Name = "Smith2",
                        Tels = new[] {"1234", "5678"}
                    }
                }
            };
        }

        public bool IsEqual(TestClass c)
        {
            var retVal = true;
            retVal &= (BoolData == c.BoolData);
            retVal &= (BoolData == c.BoolData);
            retVal &= (BoolData == c.BoolData);
            retVal &= (BoolData == c.BoolData);
            retVal &= (BoolData == c.BoolData);


            return retVal;


            // BoolData  
            // CharData  
            // SbyteData  
            // ByteData  
            // ShortData  
            // UshortData  
            // IntData  
            // UintData  
            // LongData  
            // UlongData  
            // FloatData  
            // DoubleData  
            // DecimalData  
            // DateTime DateTimeData  
            // string StringData  
            // bool? NBoolData  
            // char? NCharData  
            // sbyte? NSbyteData  
            // byte? NByteData  
            // short? NShortData  
            // ushort? NUshortData  
            // int? NIntData  
            // uint? NUintData  
            // long? NLongData  
            // ulong? NUlongData  
            // float? NFloatData  
            // double? NDoubleData  
            // decimal? NDecimalData  
            // DateTime? NDateTimeData  
            // List<int> IntListData  
            // int[] IntArrayData  
            // List<string> StringListData  
            // string[] StringArrayData  
            // Person Person  
            // List<Person> PersonList  
            // Person[] PersonArray  



        }
    }
}