using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace QsonLibrary
{
    public static class BinarySerializer
    {
        // public static byte[] BinarySerialize(this object data)
        // {
        //     BinaryFormatter binaryFormatter = new BinaryFormatter();
        //     using (var memoryStream=new MemoryStream())
        //     {
        //         binaryFormatter.Serialize(memoryStream, data);
        //         return memoryStream.ToArray();
        //     }
        // }
        //
        // public static object BinaryDeserialize(this byte[] data)
        // {
        //     using (var memoryStream=new MemoryStream())
        //     {
        //         var binaryFormatter = new BinaryFormatter();
        //         memoryStream.Write(data, 0, data.Length);
        //         memoryStream.Seek(0, SeekOrigin.Begin);
        //         return binaryFormatter.Deserialize(memoryStream);
        //     }
        // }

        public static byte[] BinarySerialize<T>(this T data)
        {
            var retVal = Array.Empty<byte>();

            var properties = typeof(T).GetProperties().ToList();
            properties.Sort((x, y) => String.Compare(x.Name, y.Name, StringComparison.Ordinal));
            foreach (var property in properties)
            {
                var value = property.GetValue(data);
                var res = value.ToByteArray(property);

                if (res == null)
                    throw new Exception($"{property.PropertyType} {property.Name} type not supported");

                var index = retVal.Length;
                Array.Resize(ref retVal, index + res.Length);
                res.CopyTo(retVal, index);
            }

            return retVal;
        }

        private static byte[] ToByteArray(this object data, PropertyInfo property)
        {
            if (property.PropertyType.IsPrimitive || property.PropertyType == typeof(string))
                return data.PrimitiveToByteArray(property);
            // Nullable
            // List
            // Array
            // Custom
            return null;
        }

        private static byte[] PrimitiveToByteArray(this object data, PropertyInfo property)
        {
            if (property.PropertyType == typeof(int))
                return BitConverter.GetBytes((int)data);
            if (property.PropertyType == typeof(long))
                return BitConverter.GetBytes((long)data);
            if (property.PropertyType == typeof(string))
            {
                var str = (string) data;
                var len = BitConverter.GetBytes(str.Length);
                var val = Encoding.UTF8.GetBytes(str);
                var retVal = new byte[len.Length + val.Length];
                len.CopyTo(retVal, 0);
                val.CopyTo(retVal, len.Length);
                return retVal;
            }

            return null;
        }
    }
}