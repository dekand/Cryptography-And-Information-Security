//Атака с выбранным открытым текстом (CPA) - это модель атаки для криптоанализа, 
//которая предполагает, что злоумышленник может получить зашифрованные тексты для произвольных открытых текстов.

namespace CipherAttackScenarios
{
    public class ChosenPlaintextAttack
    {
        private readonly List<string> _encryptedTexts = ["HWDUYTLWFUMD", "FSI", "NSKTWRFYNTS", "XJHZWNYD"];
        private string plaintext = "INFORMATION";

        public byte Run()
        {
            for (byte i = 0; i < 26; i++)
            {
                if (_encryptedTexts.Contains(new CaesarСipher(plaintext, i, false).Run())) { return i; }
            }

            throw new Exception("\t!--Ключ не найден!");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"\tИзвестен открытый текст \"{plaintext}\" и зашифрованные текста: {string.Join(" ", _encryptedTexts)}");
        }

        public void DisplayResult(byte key)
        {
            Console.WriteLine($"\t!--В результате выполнения атаки было найдено совпадение открытого текста с зашифрованным при значении ключа {key}");
            Console.WriteLine($"\t!--Расшифровка заданного текста с ключом {key} (без пробелов): {new CaesarСipher(string.Join("", _encryptedTexts), key, true).Run()}");
        }
    }
}
