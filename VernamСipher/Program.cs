using System.Text;

namespace VernamСipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var keyFile = new FileOperations("KeyFile.txt");
                var plaintextFile = new FileOperations("PlaintextFile.txt");
                var xorFile = new FileOperations("xorFile.txt");
                var xorReverseFile = new FileOperations("xorReverseFile.txt");

                Console.WriteLine("Введите текст для шифрования");
                plaintextFile.Write(Console.ReadLine());
                string plaintext = plaintextFile.Read();

                if (!plaintext.Any()) throw new Exception("Текст для шифрования не может пуст!");

                keyFile.Write(RandomOperations.GetString(plaintext.Length));
                string key = keyFile.Read();

                var vernam = new Vernam(plaintext, key);
                xorFile.Write(vernam.Run());
                vernam.DisplayResult(xorFile.Read());


                var vernamReverse = new Vernam(xorFile.Read(), key);
                xorReverseFile.Write(vernamReverse.Run());
                Console.WriteLine($"\tРасшифрование Вернома (XOR): {xorReverseFile.Read()}");
                Console.WriteLine(new string('_', Console.WindowWidth));

                //RC4
                Console.WriteLine("\tРезультаты работы RC4:");
                byte[] keyByte = ASCIIEncoding.ASCII.GetBytes(key);
                RC4 encoder = new RC4(keyByte);
                byte[] textBytes = ASCIIEncoding.ASCII.GetBytes(plaintext);

                byte[] result = encoder.Encode(textBytes, textBytes.Length);
                Console.WriteLine($"\tРезультат шифрования RC4: {ASCIIEncoding.ASCII.GetString(result)}");

                RC4 decoder = new RC4(keyByte);
                byte[] decryptedBytes = decoder.Decode(result, result.Length);
                Console.WriteLine($"\tРезультат расшифрования RC4: {ASCIIEncoding.ASCII.GetString(decryptedBytes)}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
