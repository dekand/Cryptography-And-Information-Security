namespace VernamСipher
{
    internal class FileOperations
    {
        private const string DefPath = "C:\\Users\\Andrey\\Desktop\\1to10 level\\CryptographyAndInformationSecurity\\VernamСipher\\src\\";
        public string Path { get; }
        public string FileName { get; }

        public FileOperations(string fileName)
        {
            Path = DefPath + fileName;
            FileName = fileName;
        }

        public void Write(string? contents)
        {
            Console.WriteLine($"Выполняется запись файла {FileName}...");
            File.WriteAllText(Path, contents);
        }

        public string Read()
        {
            Console.WriteLine($"Выполняется чтение файла {FileName}...");
            return File.ReadAllText(Path);
        }

        public void Append(string contents)
        {
            Console.WriteLine($"Выполняется изменение файла {FileName}...");
            File.AppendAllText(Path, contents);
        }
    }
}
