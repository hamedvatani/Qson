using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace QsonTester
{
    [Serializable]
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
        // public int[] IntArrayData { get; set; }
        public List<string> StringListData { get; set; }
        //public string[] StringArrayData { get; set; }

        public Person Person { get; set; }
        public List<Person> PersonList { get; set; }
        // public Person[] PersonArray { get; set; }

        public bool IsEqual(TestClass c)
        {
            if (BoolData != c.BoolData) return false;
            if (CharData != c.CharData) return false;
            if (SbyteData != c.SbyteData) return false;
            if (ByteData != c.ByteData) return false;
            if (ShortData != c.ShortData) return false;
            if (UshortData != c.UshortData) return false;
            if (IntData != c.IntData) return false;
            if (UintData != c.UintData) return false;
            if (LongData != c.LongData) return false;
            if (UlongData != c.UlongData) return false;
            if (Math.Abs(FloatData - c.FloatData) > .001) return false;
            if (Math.Abs(DoubleData - c.DoubleData) > .001) return false;
            if (DecimalData != c.DecimalData) return false;
            if (DateTimeData != c.DateTimeData) return false;
            if (StringData != c.StringData) return false;



            if (NBoolData == null && c.NBoolData != null) return false;
            if (NBoolData != null && c.NBoolData == null) return false;
            if (NBoolData != null && c.NBoolData != null && NBoolData.Value != c.NBoolData.Value) return false;
            if (NCharData == null && c.NCharData != null) return false;
            if (NCharData != null && c.NCharData == null) return false;
            if (NCharData != null && c.NCharData != null && NCharData.Value != c.NCharData.Value) return false;
            if (NSbyteData == null && c.NSbyteData != null) return false;
            if (NSbyteData != null && c.NSbyteData == null) return false;
            if (NSbyteData != null && c.NSbyteData != null && NSbyteData.Value != c.NSbyteData.Value) return false;
            if (NByteData == null && c.NByteData != null) return false;
            if (NByteData != null && c.NByteData == null) return false;
            if (NByteData != null && c.NByteData != null && NByteData.Value != c.NByteData.Value) return false;
            if (NShortData == null && c.NShortData != null) return false;
            if (NShortData != null && c.NShortData == null) return false;
            if (NShortData != null && c.NShortData != null && NShortData.Value != c.NShortData.Value) return false;
            if (NUshortData == null && c.NUshortData != null) return false;
            if (NUshortData != null && c.NUshortData == null) return false;
            if (NUshortData != null && c.NUshortData != null && NUshortData.Value != c.NUshortData.Value) return false;
            if (NIntData == null && c.NIntData != null) return false;
            if (NIntData != null && c.NIntData == null) return false;
            if (NIntData != null && c.NIntData != null && NIntData.Value != c.NIntData.Value) return false;
            if (NUintData == null && c.NUintData != null) return false;
            if (NUintData != null && c.NUintData == null) return false;
            if (NUintData != null && c.NUintData != null && NUintData.Value != c.NUintData.Value) return false;
            if (NLongData == null && c.NLongData != null) return false;
            if (NLongData != null && c.NLongData == null) return false;
            if (NLongData != null && c.NLongData != null && NLongData.Value != c.NLongData.Value) return false;
            if (NUlongData == null && c.NUlongData != null) return false;
            if (NUlongData != null && c.NUlongData == null) return false;
            if (NUlongData != null && c.NUlongData != null && NUlongData.Value != c.NUlongData.Value) return false;
            if (NFloatData == null && c.NFloatData != null) return false;
            if (NFloatData != null && c.NFloatData == null) return false;
            if (NFloatData != null && c.NFloatData != null && Math.Abs(NFloatData.Value - c.NFloatData.Value) > .001) return false;
            if (NDoubleData == null && c.NDoubleData != null) return false;
            if (NDoubleData != null && c.NDoubleData == null) return false;
            if (NDoubleData != null && c.NDoubleData != null && Math.Abs(NDoubleData.Value - c.NDoubleData.Value) > .001) return false;
            if (NDecimalData == null && c.NDecimalData != null) return false;
            if (NDecimalData != null && c.NDecimalData == null) return false;
            if (NDecimalData != null && c.NDecimalData != null && NDecimalData.Value != c.NDecimalData.Value) return false;
            if (NDateTimeData == null && c.NDateTimeData != null) return false;
            if (NDateTimeData != null && c.NDateTimeData == null) return false;
            if (NDateTimeData != null && c.NDateTimeData != null && NDateTimeData.Value != c.NDateTimeData.Value) return false;

            if (!IntListIsEqual(IntListData, c.IntListData)) return false;
            // if (!IntArrayIsEqual(IntArrayData, c.IntArrayData)) return false;
            if (!StringListIsEqual(StringListData, c.StringListData)) return false;
            // if (!StringArrayIsEqual(StringArrayData, c.StringArrayData)) return false;

            if (!Person.IsEqual(c.Person)) return false;
            if (!PersonListIsEqual(PersonList, c.PersonList)) return false;
            // if (!PersonArrayIsEqual(PersonArray, c.PersonArray)) return false;

            return true;
        }

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
                DateTimeData = new DateTime(2000, 2, 2),
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
                // IntArrayData = new[] {6, 7, 8, 9, 10},
                StringListData = new List<string> {"123", "abc", null, "Test"},
                // StringArrayData = new[] {"XYZ", null, "456", "Hello World!"},
                Person = new Person
                {
                    Name = "Ali",
                    Tels = new List<string> {"12", "34", "56"}
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
                        Tels = new List<string> {"123456"}
                    },
                    new()
                    {
                        Name = "Smith",
                        Tels = new List<string> {"1234", "5678"}
                    }
                },
                // PersonArray = new[]
                // {
                //     new Person
                //     {
                //         Name = "John2",
                //         Tels = null
                //     },
                //     new Person
                //     {
                //         Name = "Mark2",
                //         Tels = new[] {"123456"}
                //     },
                //     new Person
                //     {
                //         Name = "Smith2",
                //         Tels = new[] {"1234", "5678"}
                //     }
                // }
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
                DateTimeData = new DateTime(2000, 2, 2),
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
                NDateTimeData = new DateTime(2000, 2, 2),
                IntListData = new List<int> {1, 2, 3, 4, 5},
                // IntArrayData = new[] {6, 7, 8, 9, 10},
                StringListData = new List<string> {"123", "abc", null, "Test"},
                // StringArrayData = new[] {"XYZ", null, "456", "Hello World!"},
                Person = new Person
                {
                    Name = "Ali",
                    Tels = new List<string> {"12", "34", "56"}
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
                        Tels = new List<string> {"123456"}
                    },
                    new()
                    {
                        Name = "Smith2",
                        Tels = new List<string> {"1234", "5678"}
                    }
                },
                // PersonArray = new[]
                // {
                //     new Person
                //     {
                //         Name = "John2",
                //         Tels = null
                //     },
                //     new Person
                //     {
                //         Name = "Mark2",
                //         Tels = new[] {"123456"}
                //     },
                //     new Person
                //     {
                //         Name = "Smith2",
                //         Tels = new[] {"1234", "5678"}
                //     }
                // }
            };
        }

        private bool IntListIsEqual(List<int> list1, List<int> list2)
        {
            if (list1 == null && list2 == null)
                return true;
            if (list1 != null && list2 != null)
            {
                if (list1.Count != list2.Count)
                    return false;
                for (int i = 0; i < list1.Count; i++)
                    if (list1[i] != list2[i])
                        return false;
                return true;
            }
            return false;
        }

        private bool StringListIsEqual(List<string> list1, List<string> list2)
        {
            if (list1 == null && list2 == null)
                return true;
            if (list1 != null && list2 != null)
            {
                if (list1.Count != list2.Count)
                    return false;
                for (int i = 0; i < list1.Count; i++)
                    if (list1[i] != list2[i])
                        return false;
                return true;
            }
            return false;
        }

        private bool PersonListIsEqual(List<Person> list1, List<Person> list2)
        {
            if (list1 == null && list2 == null)
                return true;
            if (list1 != null && list2 != null)
            {
                if (list1.Count != list2.Count)
                    return false;
                for (int i = 0; i < list1.Count; i++)
                    if (!list1[i].IsEqual(list2[i]))
                        return false;
                return true;
            }
            return false;
        }

        private bool IntArrayIsEqual(int[] list1, int[] list2)
        {
            if (list1 == null && list2 == null)
                return true;
            if (list1 != null && list2 != null)
            {
                if (list1.Length != list2.Length)
                    return false;
                for (int i = 0; i < list1.Length; i++)
                    if (list1[i] != list2[i])
                        return false;
                return true;
            }
            return false;
        }

        private bool StringArrayIsEqual(string[] list1, string[] list2)
        {
            if (list1 == null && list2 == null)
                return true;
            if (list1 != null && list2 != null)
            {
                if (list1.Length != list2.Length)
                    return false;
                for (int i = 0; i < list1.Length; i++)
                    if (list1[i] != list2[i])
                        return false;
                return true;
            }
            return false;
        }

        private bool PersonArrayIsEqual(Person[] list1, Person[] list2)
        {
            if (list1 == null && list2 == null)
                return true;
            if (list1 != null && list2 != null)
            {
                if (list1.Length != list2.Length)
                    return false;
                for (int i = 0; i < list1.Length; i++)
                    if (!list1[i].IsEqual(list2[i]))
                        return false;
                return true;
            }
            return false;
        }
    }
}