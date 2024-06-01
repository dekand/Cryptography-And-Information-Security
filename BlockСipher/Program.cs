using System.Security.Cryptography;

namespace BlockСipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 4; i++)
            {
                try
                {
                    var plaintextFile = new FileOperations($"plaintext{i}.txt");
                    var decryptedFile = new FileOperations("decrypted.txt");
                    var ciphertextFile = new FileOperations("ciphertext.txt");

                    string original = plaintextFile.Read();

                    if (!original.Any()) throw new Exception("Текст для шифрования не может быть пуст.");

                    using (Aes myAes = Aes.Create())
                    {
                        byte[] encrypted = AES.Encrypt(original, myAes.Key, myAes.IV);
                        ciphertextFile.Write(encrypted);

                        string roundtrip = AES.Decrypt(encrypted, myAes.Key, myAes.IV);
                        decryptedFile.Write(roundtrip);

                        Console.WriteLine(new string('_', Console.WindowWidth));
                        Console.WriteLine($"Исходный открытый текст ({plaintextFile.FileName}): {original}\n");
                        Console.WriteLine($"Зашифрованный текст в байтах ({ciphertextFile.FileName}): {string.Join(" ", ciphertextFile.ReadBytes())}\n");
                        Console.WriteLine($"Результат расшифрования ({decryptedFile.FileName}): {roundtrip}\n");
                        Console.WriteLine(original == roundtrip ? "РАСШИФРОВАННЫЙ ТЕКСТ СОВПАЛ С ОРИГИНАЛОМ"
                                                                : "РАСШИФРОВАННЫЙ ТЕКСТ НЕ СОВПАДАЕТ С ОРИГИНАЛОМ");
                        Console.WriteLine(new string('_', Console.WindowWidth));
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
    }
}
