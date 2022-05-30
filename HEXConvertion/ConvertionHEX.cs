using System.Numerics;

namespace HEXConvertion
{
    public static class ConvertionHEX
    {
        public static BigInteger HEXtoInt(string hexString)
        {
            return new BigInteger(Convert.ToByte(hexString, 16));
        }

        public static BigInteger HEXtoInt(int hex)
        {
            return new BigInteger();
        }
    }
}
