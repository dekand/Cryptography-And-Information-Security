using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VernamСipher
{
    internal class Vernam
    {
        public byte[] Text;
        private byte[] Key;

        public Vernam(string text, string key)
        {
            Text = ToByteArrayASCII(text);
            Key = ToByteArrayASCII(key);
        }

        public string Run()
        {
            if (!Text.Any() || Key.Length!=Text.Length) throw new ArgumentException();

            byte[] xor = new byte[Text.Length];

            for(int i=0;i<Text.Length;i++)
            {
                xor[i] = (byte)((Text[i]) ^ (Key[i]));
            }

            return ToStringASCII(xor);
        }

        public void DisplayResult(string result)
        {
            Console.WriteLine(new string('_', Console.WindowWidth));
            Console.WriteLine($"\tТекст: {ToStringASCII(Text)}");
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.WriteLine($"\tКлюч: {ToStringASCII(Key)}");
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.WriteLine($"\tШифрование Вернома (XOR): {result}");
            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        public static byte[] ToByteArrayASCII(string text) => Encoding.ASCII.GetBytes(text);
        public static string ToStringASCII(byte[] bytes) => Encoding.ASCII.GetString(bytes);
    }
}
