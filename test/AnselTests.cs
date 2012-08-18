using System;
using System.Text;
using Xunit;

namespace ThunderMain.AnselEncoding.Tests
{
    public class AnselTests
    {
        [Fact]
        public void TestAnsel()
        {
            byte[] bytes1 = { 0xE2 };
            byte[] bytes2 = { 0x61 };
            var chars = new char[3];

            Decoder d = (new AnselEncoding()).GetDecoder();
            int charLen = d.GetChars(bytes1, 0, bytes1.Length, chars, 0);
            // charLen should be 2 now.
            charLen += d.GetChars(bytes2, 0, bytes2.Length, chars, charLen);
            Assert.Equal(2, charLen);

            Console.Write(new String(chars) + " = ");

            foreach (char c in chars)
            {
                Console.Write("U+" + ((ushort)c).ToString("x") + "  ");
            }
        }
    }
}