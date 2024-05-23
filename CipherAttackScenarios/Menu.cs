
//ПРАКТИЧЕСКОЕ ЗАДАНИЕ 1 РЕАЛИЗАЦИЯ
//АТАК НА ШИФР В РАЗЛИЧНЫХ СЦЕНАРИЯХ
//Цель задания – реализовать зашифрование/расшифрование и атаку на
//шифр в двух сценариях: по известному открытому тексту (known-plaintext
//attack) и по шифрованному тексту (ciphertext-only attack) на примере шифра
//Цезаря.

//Задачи
//1 Реализуйте зашифрование/расшифрование шифром Цезаря для
//латинского алфавита (26 букв, ключ от 0 до 25).
//2 Реализуйте атаку на шифр Цезаря по известному открытому тексту.
//Вводится открытый и зашифрованный текст, требуется определить
//ключ шифрования.
//3 Реализуйте атаку на шифр Цезаря по шифрованному тексту. Вводится
//зашифрованный текст, требуется вывести варианты расшифрования со
//всеми ключами.
//4 Усовершенствуйте программу из пункта 3 Реализуйте интеграцию с
//каким-либо словарем, чтобы программа автоматически определяла
//ключ шифрования, находя осмысленный текст (тот, который есть в
//словаре).

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
                        case 4: break;
                        case 5: break;
                        default: f = false; break;
                    }
                }
                catch (Exception e) { Console.WriteLine(e.ToString()); }

                Console.ReadLine();
            }
        }

    }
}
