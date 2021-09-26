using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Colors
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = @"D:\my_photo.jpg";

            var number = CountImageColors(fileName);

            Console.WriteLine(number);

            IDictionary<Color, int> colors = GetAllColors(fileName);

            var frequentColors = GetMostFrequentColors(colors, 10).ToList();
            foreach (KeyValuePair<Color, int> color in frequentColors)
            {
                Console.WriteLine(color.Key + " -> " + color.Value);
            }


            Console.ReadKey();
        }

        private static IEnumerable<KeyValuePair<Color, int>> GetMostFrequentColors(IDictionary<Color, int> colors, int number)
        {
            return colors.OrderByDescending(c => c.Value).Take(number);
        }

        private static IDictionary<Color, int> GetAllColors(string fileName)
        {
            var colors = new Dictionary<Color, int>();
            Bitmap bmp = null;

            if (File.Exists(fileName))
            {
                try
                {
                    bmp = new Bitmap(fileName);
                    if (bmp != null)
                    {
                        for (int y = 0; y < bmp.Size.Height; y++)
                        {
                            for (int x = 0; x < bmp.Size.Width; x++)
                            {
                                var pixel = bmp.GetPixel(x, y);
                                if (colors.ContainsKey(pixel))
                                {
                                    colors[pixel] = colors[pixel] + 1;
                                }
                                else
                                {
                                    colors[pixel] = 1;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    bmp.Dispose();
                }
            }
            return colors;
        }

        public static int CountImageColors(string fileName)
        {
            var count = 0;
            var colors = new HashSet<Color>();
            Bitmap bmp = null;

            if (File.Exists(fileName))
            {
                try
                {
                    bmp = new Bitmap(fileName);
                    if (bmp != null)
                    {
                        for (int y = 0; y < bmp.Size.Height; y++)
                        {
                            for (int x = 0; x < bmp.Size.Width; x++)
                            {
                                colors.Add(bmp.GetPixel(x, y));
                            }
                        }
                        count = colors.Count;
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    colors.Clear();
                    bmp.Dispose();
                }
            }
            return count;
        }
    }
}
