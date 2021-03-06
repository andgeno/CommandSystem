﻿/*This File provides various Parser methods used for some common Types*/
namespace SickDev.CommandSystem {
    static class Parsers {
        const string nullObject = "null";

        [Parser(typeof(object))]
        static object ParseObject(string value) {
            return ParseString(value);
        }

        [Parser(typeof(string))]
        static string ParseString(string value) {
            return value.Equals(nullObject) ? null : value;
        }

        [Parser(typeof(byte))]
        static byte ParseByte(string value) {
            return byte.Parse(value.Trim());
        }

        [Parser(typeof(byte?))]
        static byte? ParseNullableByte(string value) {
            return value.Equals(nullObject) ? (byte?)null : ParseByte(value);
        }

        [Parser(typeof(sbyte))]
        static sbyte ParseSbyte(string value) {
            return sbyte.Parse(value.Trim());
        }

        [Parser(typeof(sbyte?))]
        static sbyte? ParseNullableSbyte(string value) {
            return value.Equals(nullObject) ? (sbyte?)null : ParseSbyte(value);
        }

        [Parser(typeof(short))]
        static short ParseShort(string value) {
            return short.Parse(value.Trim());
        }

        [Parser(typeof(short?))]
        static short? ParseNullableShort(string value) {
            return value.Equals(nullObject) ? (short?)null : ParseShort(value);
        }

        [Parser(typeof(ushort))]
        static ushort ParseUshort(string value) {
            return ushort.Parse(value.Trim());
        }

        [Parser(typeof(ushort?))]
        static ushort? ParseNullableUshort(string value) {
            return value.Equals(nullObject) ? (ushort?)null : ParseUshort(value);
        }

        [Parser(typeof(int))]
        static int ParseInt(string value) {
            return int.Parse(value.Trim());
        }

        [Parser(typeof(int?))]
        static int? ParseNullableInt(string value) {
            return value.Equals(nullObject) ? (int?)null : ParseInt(value);
        }

        [Parser(typeof(uint))]
        static uint ParseUint(string value) {
            return uint.Parse(value.Trim());
        }

        [Parser(typeof(uint?))]
        static uint? ParseNullableUint(string value) {
            return value.Equals(nullObject) ? (uint?)null : ParseUint(value);
        }

        [Parser(typeof(long))]
        static long ParseLong(string value) {
            return long.Parse(value.Trim());
        }

        [Parser(typeof(long?))]
        static long? ParseNullableLong(string value) {
            return value.Equals(nullObject) ? (long?)null : ParseLong(value);
        }

        [Parser(typeof(ulong))]
        static ulong ParseUlong(string value) {
            return ulong.Parse(value.Trim());
        }

        [Parser(typeof(ulong?))]
        static ulong? ParseNullableUlong(string value) {
            return value.Equals(nullObject) ? (ulong?)null : ParseUlong(value);
        }

        [Parser(typeof(float))]
        static float ParseFloat(string value) {
            return float.Parse(value.Trim());
        }

        [Parser(typeof(float?))]
        static float? ParseNullableFloat(string value) {
            return value.Equals(nullObject) ? (float?)null : ParseFloat(value);
        }

        [Parser(typeof(double))]
        static double ParseDouble(string value) {
            return double.Parse(value.Trim());
        }

        [Parser(typeof(double?))]
        static double? ParseNullableDouble(string value) {
            return value.Equals(nullObject) ? (double?)null : ParseDouble(value);
        }

        [Parser(typeof(decimal))]
        static decimal ParseDecimal(string value) {
            return decimal.Parse(value.Trim());
        }

        [Parser(typeof(decimal?))]
        static decimal? ParseNullableDecimal(string value) {
            return value.Equals(nullObject) ? (decimal?)null : ParseDecimal(value);
        }

        //TRUE-->	[true, 1, yes, y, t]
        //FALSE-->	[false, 0, no, n, f]
        [Parser(typeof(bool))]
        static bool ParseBool(string value) {
            bool bResult = false;
            if(bool.TryParse(value, out bResult))
                return bResult;
            else {
                int iResult;
                if(int.TryParse(value, out iResult)) {
                    if(iResult == 1)
                        return true;
                    else if(iResult == 0)
                        return false;
                    else
                        throw new InvalidArgumentFormatException<bool>(value);
                }
                else {
                    if(value.Equals("yes") || value.Equals("y") || value.Equals("t"))
                        return true;
                    else if(value.Equals("no") || value.Equals("n") || value.Equals("f"))
                        return false;
                    else
                        throw new InvalidArgumentFormatException<bool>(value);
                }
            }
        }

        [Parser(typeof(bool?))]
        static bool? ParseNullableBool(string value) {
            return value.Equals(nullObject) ? (bool?)null : ParseBool(value);
        }

        [Parser(typeof(char))]
        static char ParseChar(string value) {
            return char.Parse(value);
        }

        [Parser(typeof(char?))]
        static char? ParseNullableChar(string value) {
            return value.Equals(nullObject) ? (char?)null : ParseChar(value);
        }
    }
}