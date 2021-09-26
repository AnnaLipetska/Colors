using System;
using System.Linq;

namespace Refactoring
{
    public class Program
    {
        public static void Main()
        {
            const int MIN = 500;
            Func<int, int> triple = (int number) => number * 3;
            var results = new int[] { 100, 250 }.Select(i => triple(i)).ToArray();

            string info = string.Empty;
            for (int i = 0; i < results.Length; i++)
            {
                info += (results[i] > MIN) ? $"Result {i + 1}: {results[i]} " : string.Empty;
            }

            info = info.TrimEnd();
            if (!string.IsNullOrEmpty(info))
                Console.WriteLine(info);
        }
    }
}