using System;
using System.Linq;

namespace Refactoring
{
    public class Program
    {
        public static void Main()
        {
            const int MIN = 500;
            var results = new int[] { 100, 250 }.Select(i => i * 3).ToList();

            string info = string.Empty;
            for (int i = 0; i < results.Count; i++)
            {
                info += (results[i] > MIN) ? $"Result {i + 1}: {results[i]} " : string.Empty;
            }

            info = info.TrimEnd();
            if (!string.IsNullOrEmpty(info))
                Console.WriteLine(info);
        }
    }
}