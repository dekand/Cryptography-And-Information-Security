namespace Entropy
{
    internal class FileReader
    {

        public static string Read(string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return "";
        }
    }
}
