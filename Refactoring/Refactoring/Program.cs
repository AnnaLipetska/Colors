using System;
using System.Linq;

namespace Refactoring
{
    public class Program
    {
        public static void Main()
        {
            Func<int, int> triple = (int number) => number * 3;
            var results = new int[] { 100, 250 }.Select(i => triple(i)).ToArray();
            string info = string.Empty;
            for (int i = 0; i < results.Length; i++)
            {
                info += (results[i] > 500) ? $"Result {i + 1}: {results[i]} " : string.Empty;
            }

            info = info.Trim();
            if (!string.IsNullOrEmpty(info))
                Console.WriteLine(info);
        }
    }
}
