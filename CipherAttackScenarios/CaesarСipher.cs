using System.Text;

namespace CipherAttackScenarios
{
    public class CaesarСipher
    {
        public string Message;
        private byte Key;
        public bool IsEncrypted { get; }

        public CaesarСipher(string message, byte key, bool isEncrypted)
        {
            Message = message;
            Key = key;
            IsEncrypted = isEncrypted;
        }

        public string Run()
        {
            if (!Message.Any() || Key > 25) throw new ArgumentException();

            byte[] asciiBytes = Encoding.ASCII.GetBytes(Message.ToUpper());

            foreach (byte b in asciiBytes)
            {
                if (b < 65 || b > 90) throw new ArgumentException();
            }

            for (int i = 0; i < asciiBytes.Length; i++)
            {
                asciiBytes[i] = Shift(asciiBytes[i]);
            }

            var outputMessage = Encoding.ASCII.GetString(asciiBytes);

            return outputMessage;
        }

        public void DisplayResult()
        {
            Console.WriteLine($"Результат шифрования: {Run()}");
        }

        static public CaesarСipher СonsoleСreation(bool isEncrypted = false)
        {
            var inputData = Console.ReadLine().Split(' ').ToList();

            if (inputData.Count < 2) throw new Exception("Некорректный ввод пары значений: *открытый_текст* *ключ*");

            return new CaesarСipher(inputData[0], byte.Parse(inputData[1]), isEncrypted);
        }

        private byte Shift(byte asciiByte)
        {
            if (IsEncrypted)
            {
                asciiByte -= Key;
                if (asciiByte < 65) { asciiByte += 26; }
                return asciiByte;
            }
            asciiByte += Key;
            if (asciiByte > 90) { asciiByte -= 26; }
            return asciiByte;
        }
    }
}
