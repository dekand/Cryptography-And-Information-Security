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

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
