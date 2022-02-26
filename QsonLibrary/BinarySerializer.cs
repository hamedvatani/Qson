using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace QsonLibrary
{
    public static class BinarySerializer
    {
        public static byte[] BinarySerialize(this object data)
        {
            if (data == null)
                return new byte[] {0};

            var retVal = new byte[] {1};

            var properties = data.GetType().GetProperties().ToList();
            properties.Sort((x, y) => String.Compare(x.Name, y.Name, StringComparison.Ordinal));
            foreach (var property in properties)
            {
                var value = property.GetValue(data);
                var res = value.ToByteArray(property.PropertyType);

                if (res == null)
                    throw new Exception($"{property.PropertyType} {property.Name} type not supported in Serializer");

                retVal = retVal.Concat(res);
            }

            return retVal;
        }

        public static byte[] Concat(this byte[] arr1, byte[] arr2)
        {
            if (arr1 == null && arr2 == null)
                return null;
            if (arr1 != null && arr2 == null)
                return arr1;
            if (arr1 == null)
                return arr2;
            var retVal = new byte[arr1.Length + arr2.Length];
            arr1.CopyTo(retVal, 0);
            arr2.CopyTo(retVal, arr1.Length);
            return retVal;
        }

        private static byte[] ToByteArray(this object data, Type type)
        {
            // Primitive
            if (type.IsPrimitive || type == typeof(decimal) || type == typeof(DateTime) || type == typeof(string))
                return data.PrimitiveToByteArray(type);
            // Nullable
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return data.NullableToByteArray(type);
            // List
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
                return data.ListToByteArray(type);
            // Array, not supported now
            // Custom
            if (!type.IsArray)
                return data.BinarySerialize();
            return null;
        }

        private static byte[] PrimitiveToByteArray(this object data, Type type)
        {
            if (type == typeof(bool))
                return BitConverter.GetBytes((bool)data);
            if (type == typeof(char))
                return BitConverter.GetBytes((char)data);
            if (type == typeof(sbyte))
                return BitConverter.GetBytes((sbyte)data);
            if (type == typeof(byte))
                return BitConverter.GetBytes((byte)data);
            if (type == typeof(short))
                return BitConverter.GetBytes((short)data);
            if (type == typeof(ushort))
                return BitConverter.GetBytes((ushort)data);
            if (type == typeof(int))
                return BitConverter.GetBytes((int)data);
            if (type == typeof(uint))
                return BitConverter.GetBytes((uint)data);
            if (type == typeof(long))
                return BitConverter.GetBytes((long)data);
            if (type == typeof(ulong))
                return BitConverter.GetBytes((ulong)data);
            if (type == typeof(float))
                return BitConverter.GetBytes((float)data);
            if (type == typeof(double))
                return BitConverter.GetBytes((double)data);
            if (type == typeof(decimal))
                return BitConverter.GetBytes(decimal.ToDouble((decimal)data));
            if (type == typeof(DateTime))
                return BitConverter.GetBytes(((DateTime)data).Ticks);
            if (type == typeof(string))
            {
                if (data == null)
                    return new byte[] { 0 };
                var str = (string)data;
                var len = BitConverter.GetBytes(str.Length);
                var val = Encoding.UTF8.GetBytes(str);
                return new byte[] { 1 }.Concat(len).Concat(val);
            }

            return null;
        }

        private static byte[] NullableToByteArray(this object data, Type type)
        {
            var genericArguments = type.GetGenericArguments();
            if (genericArguments.Length != 1)
                return null;
            var underlyingType = genericArguments.First();
            if (data == null)
                return new byte[] { 0 };
            return (new byte[] { 1 }).Concat(data.ToByteArray(underlyingType));
        }

        private static byte[] ListToByteArray(this object data, Type type)
        {
            var genericArguments = type.GetGenericArguments();
            if (genericArguments.Length != 1)
                return null;
            var underlyingType = genericArguments.First();
            if (data == null)
                return new byte[] { 0 };

            var list = data as IList;
            if (list == null)
                return null;

            var retVal = (new byte[] { 1 }).Concat(BitConverter.GetBytes(list.Count));
            for (int i = 0; i < list.Count; i++)
                retVal = retVal.Concat(list[i].ToByteArray(underlyingType));

            return retVal;
        }

        public static object BinaryDeserialize(this byte[] data, Type type, out int length)
        {
            if (data == null || data.Length == 0)
            {
                length = 0;
                return null;
            }

            if (data[0] == 0)
            {
                length = 1;
                return null;
            }

            object retVal = Activator.CreateInstance(type);
            length = 1;
            byte[] bytes = data.Separate(1);

            var properties = type.GetProperties().ToList();
            properties.Sort((x, y) => String.Compare(x.Name, y.Name, StringComparison.Ordinal));
            foreach (var property in properties)
            {
                var value = bytes.GetValue(property.PropertyType, out int len);
                if (len == 0)
                    throw new Exception($"{property.PropertyType} {property.Name} type not supported in Deserializer");
                length += len;
                property.SetValue(retVal, value);

                bytes = bytes.Separate(len);
            }
            
            return retVal;
        }
        
        public static byte[] Separate(this byte[] arr, int length)
        {
            if (arr == null)
                return null;
            if (arr.Length < length)
                return arr;
            return arr.Skip(length).ToArray();
        }

        private static object GetValue(this byte[] data, Type type, out int length)
        {
            // Primitive
            if (type.IsPrimitive || type == typeof(decimal) || type == typeof(DateTime) || type == typeof(string))
                return data.GetPrimitiveValue(type, out length);
            // Nullable
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return data.GetNullableValue(type, out length);
            // List
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
                return data.GetListValue(type, out length);
            // Array, not supported now
            // Custom
            if (!type.IsArray)
                return data.BinaryDeserialize(type, out length);
            length = 0;
            return null;
        }
        
        private static object GetPrimitiveValue(this byte[] data, Type type, out int length)
        {
            if (type == typeof(bool))
            {
                length = BitConverter.GetBytes(false).Length;
                return BitConverter.ToBoolean(data, 0);
            }
            if (type == typeof(char))
            {
                length = BitConverter.GetBytes('a').Length;
                return BitConverter.ToChar(data, 0);
            }
            if (type == typeof(sbyte))
            {
                length = BitConverter.GetBytes((sbyte)0).Length;
                return (sbyte)data[0];
            }
            if (type == typeof(byte))
            {
                length = BitConverter.GetBytes((byte)0).Length;
                return data[0];
            }
            if (type == typeof(short))
            {
                length = BitConverter.GetBytes((short)0).Length;
                return BitConverter.ToInt16(data, 0);
            }
            if (type == typeof(ushort))
            {
                length = BitConverter.GetBytes((ushort)0).Length;
                return BitConverter.ToUInt16(data, 0);
            }
            if (type == typeof(int))
            {
                length = BitConverter.GetBytes(0).Length;
                return BitConverter.ToInt32(data, 0);
            }
            if (type == typeof(uint))
            {
                length = BitConverter.GetBytes((uint)0).Length;
                return BitConverter.ToUInt32(data, 0);
            }
            if (type == typeof(long))
            {
                length = BitConverter.GetBytes((long)0).Length;
                return BitConverter.ToInt64(data, 0);
            }
            if (type == typeof(ulong))
            {
                length = BitConverter.GetBytes((ulong)0).Length;
                return BitConverter.ToUInt64(data, 0);
            }
            if (type == typeof(float))
            {
                length = BitConverter.GetBytes((float)0).Length;
                return BitConverter.ToSingle(data, 0);
            }
            if (type == typeof(double))
            {
                length = BitConverter.GetBytes((double)0).Length;
                return BitConverter.ToDouble(data, 0);
            }
            if (type == typeof(decimal))
            {
                length = BitConverter.GetBytes((double)0).Length;
                return (decimal)BitConverter.ToDouble(data, 0);
            }
            if (type == typeof(DateTime))
            {
                length = BitConverter.GetBytes((long)0).Length;
                var ticks = BitConverter.ToInt64(data, 0);
                return new DateTime(ticks);
            }
            if (type == typeof(string))
            {
                if (data[0] == 0)
                {
                    length = 1;
                    return null;
                }

                var strLength = BitConverter.ToInt32(data, 1);
                length = strLength + 5;
                return Encoding.UTF8.GetString(data, 5, strLength);
            }

            length = 0;
            return null;
        }
        
        private static object GetNullableValue(this byte[] data, Type type, out int length)
        {
            var genericArguments = type.GetGenericArguments();
            if (genericArguments.Length != 1)
            {
                length = 0;
                return null;
            }

            var underlyingType = genericArguments.First();

            if (data[0] == 0)
            {
                length = 1;
                return null;
            }

            var dat = data.Separate(1);
            var res = dat.GetValue(underlyingType, out int len);
            length = len + 1;
            return res;
        }
        
        private static object GetListValue(this byte[] data, Type type, out int length)
        {
            var genericArguments = type.GetGenericArguments();
            if (genericArguments.Length != 1)
            {
                length = 0;
                return null;
            }

            var underlyingType = genericArguments.First();

            if (data[0] == 0)
            {
                length = 1;
                return null;
            }

            length = 1;
            var dat = data.Separate(1);
            var list = (IList) Activator.CreateInstance(typeof(List<>).MakeGenericType(underlyingType));

            var listCount = BitConverter.ToInt32(dat, 0);
            length += 4;
            dat = dat.Separate(4);

            for (int i = 0; i < listCount; i++)
            {
                var res = dat.GetValue(underlyingType, out int len);
                list.Add(res);
                length += len;
                dat = dat.Separate(len);
            }

            return list;
        }
    }
}