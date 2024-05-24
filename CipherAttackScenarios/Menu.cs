namespace CipherAttackScenarios
{
    public class Menu
    {
        static private readonly string menuText =
            "1. Зашифровать шифром Цезаря.\n" +
            "2. Расшифровать шифр Цезаря.\n" +
            "3. Произвести атаку по известному открытому тексту (определить ключ).\n" +
            "4. Произвести атаку по шифрованному тексту.\n" +
            "5. Произвести атаку по шифрованному тексту с определением ключа.\n" +
            "0. Выйти.\n";

        static public void Display()
        {
            bool f = true;
            while (f)
            {
                Console.Clear();
                Console.WriteLine(menuText);
                if (!int.TryParse(Console.ReadLine(), out int choise))
                {
                    Console.WriteLine("Fail choise!");
                    break;
                }

                try
                {
                    switch (choise)
                    {
                        case 1:
                            Console.WriteLine("\tВведите пару значений: *открытый_текст* *ключ*");
                            CaesarСipher.СonsoleСreation().DisplayResult();
                            break;
                        case 2:
                            Console.WriteLine("\tВведите пару значений: *зашифрованный_текст* *ключ*");
                            CaesarСipher.СonsoleСreation(true).DisplayResult();
                            break;
                        case 3:
                            var cpa = new ChosenPlaintextAttack();
                            cpa.DisplayInfo();
                            cpa.DisplayResult(cpa.Run());
                            break;
                        case 4:
                            Console.WriteLine("\tВведите известный зашифрованный текст:");
                            var coa = new CiphertextAttack(Console.ReadLine());
                            coa.DisplayResult();
                            break;
                        case 5:
                            Console.WriteLine("\tВведите известный зашифрованный текст:");
                            var coa2 = new CiphertextAttack(Console.ReadLine());
                            coa2.DisplayResult();
                            Console.WriteLine(coa2.DictionarySearch());
                            break;
                        default: f = false; break;
                    }
                }
                catch (Exception e) { Console.WriteLine(e.ToString()); }

                Console.ReadLine();
            }
        }
    }
}
