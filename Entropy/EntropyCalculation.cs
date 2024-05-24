//ПРАКТИЧЕСКОЕ ЗАДАНИЕ 2 ВЫЧИСЛЕНИЕ
//ИНФОРМАЦИОННОЙ ЭНТРОПИИ ФАЙЛА
//Цель задания – вычислить информационную энтропию различных файлов и
//сопоставить результаты.

//Задачи
//1 Напишите программу, которая по заданному файлу определяет
//частоты появления символов в нем.
//2 Усовершенствуйте программу 1, чтобы она вычисляла энтропию этого
//файла по вычисленным частотам.
//3 Сгенерируйте несколько различных файлов. Например, из одинаковых
//символов, из случайных символов 0 и 1, из случайных символов от 0 и
//255 Попробуйте другие варианты. Убедитесь, что при большом
//количестве одинаковых символов энтропия приближается к 0 В случае
//случайных символов энтропия приближается к Log2(размера алфавита).

namespace Entropy
{
    internal class EntropyCalculation
    {
        public List<double> Pi;
        public double E;

        private string fileText;
        private double totalNum;
        private HashSet<char> uniqueValues;

        public EntropyCalculation(string filePath)
        {
            fileText = FileReader.Read(filePath);
            totalNum = fileText.Length;
            uniqueValues = GetUniqueValues();

            Pi = GetProbabilities();
            E = GetEntropy();
        }

        public List<double> GetProbabilities()
        {
            var probList = new List<double>();
            try
            {
                foreach (var c in uniqueValues)
                {
                    probList.Add(fileText.Count(t => t == c) / totalNum);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return probList;
        }

        public double GetEntropy()
        {
            double entropy = 0;

            try
            {
                foreach (var p in Pi)
                {
                    entropy += p * Math.Log2(1 / p);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return entropy;
        }

        public void DisplayResult()
        {
            Console.WriteLine($"Прочитанный текст из файла: {fileText}\n" +
                              $"Уникальные символы: {string.Join(" ", uniqueValues)}\n" +
                              $"Вероятности появления символов: \n\t{string.Join("\n\t", Pi)}\n" +
                              $"Энтропия файла: {E}\n\n");
        }

        private HashSet<char> GetUniqueValues()
        {
            var uniqueValues = new HashSet<char>();

            foreach (var c in fileText)
            {
                uniqueValues.Add(c);
            }

            return uniqueValues;
        }
    }
}
