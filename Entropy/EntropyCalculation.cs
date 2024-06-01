namespace Entropy
{
    internal class EntropyCalculation
    {
        public List<double> Pi;
        public double E;

        private string fileText;
        private HashSet<char> uniqueValues;

        public EntropyCalculation(string filePath)
        {
            fileText = FileReader.Read(filePath);
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
                    probList.Add(fileText.Count(t => t == c) / fileText.Length);
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
            Console.WriteLine($"Прочитанный текст из файла: {fileText}\n\n" +
                              $"Уникальные символы: {string.Join(" ", uniqueValues)}\n\n" +
                              $"Вероятности появления символов: \n\t{string.Join("\n\t", Pi)}\n\n" +
                              $"Энтропия файла: {E}\n\n"+
                              $"Log2(размер алфавита): {Math.Log2(uniqueValues.Count)}\n");
            Console.WriteLine(new string('_', Console.WindowWidth));
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
