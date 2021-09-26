using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using PalletLib;

namespace Colors
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = @"D:\my_photo.jpg";

            var pallet = new Pallet(fileName);

            var number = pallet.CountImageColors();

            Console.WriteLine($"Total number of colors: {number}");

            var frequentColors = pallet.GetMostFrequentColors(10).ToList();

            foreach (KeyValuePair<Color, int> color in frequentColors)
            {
                Console.WriteLine(color.Key + " -> " + color.Value);
            }


            Console.ReadKey();
        }
    }
}
