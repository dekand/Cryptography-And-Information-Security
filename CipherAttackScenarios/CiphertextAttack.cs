//В криптографии атака только с использованием зашифрованного текста (COA) 
//или атака с использованием известного зашифрованного текста — это модель атаки для криптоанализа, 
//при которой предполагается, что злоумышленник имеет доступ только к набору зашифрованных текстов.

namespace CipherAttackScenarios
{
    public class CiphertextAttack
    {
        private string encryptedText;
        private Dictionary<byte, string> iterationsDict;

        public CiphertextAttack(string encryptedText)
        {
            this.encryptedText = encryptedText;
            this.iterationsDict = Run();
        }

        public Dictionary<byte, string> Run()
        {
            var iterationsDict = new Dictionary<byte, string>();

            for (byte i = 0; i < 26; i++)
            {
                iterationsDict.Add(i, new CaesarСipher(encryptedText, i, true).Run());
            }

            return iterationsDict;
        }

        public void DisplayResult()
        {
            foreach (var iteration in iterationsDict)
            {
                Console.WriteLine($"\tКлюч: {iteration.Key} Текст: {iteration.Value};");
            }
        }

        public string DictionarySearch()
        {
            foreach (var iteration in iterationsDict)
            {
                if (TextDictionary._words.Contains(iteration.Value))
                { return $"\t!--Найдено совпадение со словарем при ключе {iteration.Key} и значении \"{iteration.Value}\""; }
            }
            return "\t!--Совпадения со словарем не найдены";
        }
    }
}
