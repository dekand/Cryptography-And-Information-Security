namespace BlockСipher
{
    internal class FileOperations
    {
        private const string DefPath = "C:\\Users\\Andrey\\Desktop\\1to10 level\\CryptographyAndInformationSecurity\\BlockСipher\\src\\";
        public string Path { get; }
        public string FileName { get; }

        public FileOperations(string fileName)
        {
            Path = DefPath + fileName;
            FileName = fileName;
        }

        public void Write(string? contents)
        {
            DisplayWrite();
            File.WriteAllText(Path, contents);
        }

        public void Write(byte[] contents)
        {
            DisplayWrite();
            File.WriteAllBytes(Path, contents);
        }

        public string Read()
        {
            DisplayRead();
            return File.ReadAllText(Path);
        }

        public byte[] ReadBytes()
        {
            DisplayRead();
            return File.ReadAllBytes(Path);
        }

        private void DisplayRead() => Console.WriteLine($"Выполняется чтение файла {FileName}...");
        private void DisplayWrite() => Console.WriteLine($"Выполняется запись файла {FileName}...");
    }
}
