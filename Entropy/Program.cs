namespace Entropy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tПРИМЕР ФАЙЛА С ОБЫЧНОЙ ТЕКСТОВОЙ СТРОКОЙ");
            new EntropyCalculation(FilePaths.fileStr).DisplayResult();

            Console.WriteLine("\tПРИМЕР ФАЙЛА СО СТРОКОЙ, СОСТОЯЩЕЙ ИЗ ОДИНАКОВЫХ СИМВОЛОВ");
            new EntropyCalculation(FilePaths.fileIdentical).DisplayResult();

            Console.WriteLine("\tПРИМЕР ФАЙЛА СО СТРОКОЙ, СОСТОЯЩЕЙ ИЗ СЛУЧАЙНЫХ СИМВОЛОВ 0 И 1");
            new EntropyCalculation(FilePaths.fileBinary).DisplayResult();

            Console.WriteLine("\tПРИМЕР ФАЙЛА СО СТРОКОЙ, СОСТОЯЩЕЙ ИЗ СЛУЧАЙНЫХ СИМВОЛОВ");
            new EntropyCalculation(FilePaths.fileFullRandom).DisplayResult();
        }
    }
}
