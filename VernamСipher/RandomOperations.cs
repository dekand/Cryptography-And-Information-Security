namespace VernamСipher
{
    internal class RandomOperations
    {
        const string chars = "1234567890"
       + "QWERTYUIOPASDFGHJKLZXCVBNM"
       + "qwertyuiopasdfghjklzxcvbnm"
       + "~<>?!@#$%^&*()_-=+;:|[]{}";

        private static Random random = new Random();

        public static string GetString(int length)
        {
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
