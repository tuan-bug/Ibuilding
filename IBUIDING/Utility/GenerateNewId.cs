namespace IBUIDING.Utility
{
    public class GenerateNewId
    {
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly Random Random = new Random();

        public static string Id(int length)
        {
            char[] randomChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                randomChars[i] = Chars[Random.Next(Chars.Length)];
            }

            return new string(randomChars);
        }
    }
}
