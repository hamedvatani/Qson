using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace QsonLibrary
{
    public static class BinarySerializer
    {
        public static byte[] BinarySerialize(this object data)
        {
            byte[] retVal = Array.Empty<byte>();

            if (data == null)
                return retVal;

            var properties = data.GetType().GetProperties().ToList();
            properties.Sort((x, y) => String.Compare(x.Name, y.Name, StringComparison.Ordinal));

            foreach (var property in properties)
            {
                var value = property.GetValue(data);
                var typeCode = Type.GetTypeCode(property.PropertyType);
                byte[] res = Array.Empty<byte>();
                switch (typeCode)
                {
                    case TypeCode.Boolean:
                    case TypeCode.Char:
                    case TypeCode.SByte:
                    case TypeCode.Byte:
                    case TypeCode.Int16:
                    case TypeCode.UInt16:
                    case TypeCode.Int32:
                    case TypeCode.UInt32:
                    case TypeCode.Int64:
                    case TypeCode.UInt64:
                    case TypeCode.Single:
                    case TypeCode.Double:
                    case TypeCode.Decimal:
                    case TypeCode.DateTime:
                        res = value.AtomicToByteArray(typeCode);
                        break;
                    case TypeCode.String:
                        res = value.StringToByteArray(typeCode);
                        break;
                    case TypeCode.Object:
                        if (property.PropertyType.IsGenericType &&
                            property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            int asd = 0;
                        }


                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                var index = retVal.Length;
                Array.Resize(ref retVal, retVal.Length + res.Length);
                res.CopyTo(retVal, index);
            }

            return retVal;
        }

        private static byte[] AtomicToByteArray(this object data, TypeCode typeCode)
        {
            return typeCode switch
            {
                TypeCode.Boolean => BitConverter.GetBytes((bool)data),
                TypeCode.Char => BitConverter.GetBytes((char)data),
                TypeCode.SByte => BitConverter.GetBytes((sbyte)data),
                TypeCode.Byte => BitConverter.GetBytes((byte)data),
                TypeCode.Int16 => BitConverter.GetBytes((short)data),
                TypeCode.UInt16 => BitConverter.GetBytes((ushort)data),
                TypeCode.Int32 => BitConverter.GetBytes((int)data),
                TypeCode.UInt32 => BitConverter.GetBytes((uint)data),
                TypeCode.Int64 => BitConverter.GetBytes((long)data),
                TypeCode.UInt64 => BitConverter.GetBytes((ulong)data),
                TypeCode.Single => BitConverter.GetBytes((float)data),
                TypeCode.Double => BitConverter.GetBytes((double)data),
                TypeCode.Decimal => BitConverter.GetBytes(decimal.ToDouble((decimal)data)),
                TypeCode.DateTime => BitConverter.GetBytes(((DateTime)data).Ticks),
                _ => throw new Exception("Not Atomic Type")
            };
        }

        private static byte[] StringToByteArray(this object data, TypeCode typeCode)
        {
            if (typeCode != TypeCode.String)
                throw new Exception("Not String Type");
            var str = (string) data;
            int len = str.Length;
            byte[] lenBytes = BitConverter.GetBytes(len);
            byte[] strBytes = Encoding.UTF8.GetBytes(str);
            byte[] retVal = new byte[lenBytes.Length + strBytes.Length];
            lenBytes.CopyTo(retVal, 0);
            strBytes.CopyTo(retVal, lenBytes.Length);
            return retVal;
        }
    }
}