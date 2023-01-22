using System;
using System.Text;

namespace TinnyClock.Converters
{
    public static class SubConverter
    {
        public static byte[] HexToByte(string msg)
        {
            msg = msg.Replace(" ", "");
            var comBuffer = new byte[msg.Length / 2];

            for (var i = 0; i < msg.Length; i += 2)
            {
                comBuffer[i / 2] = Convert.ToByte(msg.Substring(i, 2), 16);
            }

            return comBuffer;
        }

        public static string ByteToHex(byte[] comByte)
        {
            var builder = new StringBuilder(comByte.Length * 3);

            foreach (var data in comByte)
            {
                builder.Append(Convert.ToString(data, 16).PadLeft(2, '0').PadRight(3, ' '));
            }

            return builder.ToString().ToUpper();
        }
    }
}