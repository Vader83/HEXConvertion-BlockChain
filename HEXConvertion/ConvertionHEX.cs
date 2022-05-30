using System.Numerics;

namespace HEXConvertion
{
    public static class ConvertionHEX
    {
        public static BigInteger HEXtoLittleEndian(string hexString)
        {                     
            ReadOnlySpan<byte> byteSpan = new ReadOnlySpan<byte>(StringToByteArray(hexString));
            return new BigInteger(byteSpan, isUnsigned: true, isBigEndian: false);
        }

        public static BigInteger HEXtoBigEndian(string hexString)
        {
            ReadOnlySpan<byte> byteSpan = new ReadOnlySpan<byte>(StringToByteArray(hexString));
            return new BigInteger(byteSpan, isUnsigned: true, isBigEndian: true);
        }

        public static string LittleEndianToHex(BigInteger littleEndian)
        {
            ReadOnlySpan<byte> byteSpan = new ReadOnlySpan<byte>(littleEndian.ToByteArray(isUnsigned: true));
            BigInteger le = new BigInteger(byteSpan , isUnsigned: true, isBigEndian: false);
            string leString = Convert.ToHexString(le.ToByteArray());
            return "0x" + leString.Substring(0, leString.Length - 2);
        }

        public static string BigEndianToHex(BigInteger bigEndian)
        {
            ReadOnlySpan<byte> byteSpan = new ReadOnlySpan<byte>(bigEndian.ToByteArray(isUnsigned: true, isBigEndian: true));
            BigInteger be = new BigInteger(byteSpan, isUnsigned: true, isBigEndian: true);
            string beString = Convert.ToHexString(be.ToByteArray());
            return "0x" + beString.Substring(0, beString.Length - 2);
        }

        public static byte[] StringToByteArray(string hexString)
        {
            string hex = hexString.Substring(startIndex: 2);
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
