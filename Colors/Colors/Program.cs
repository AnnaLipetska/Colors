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
            //var fileName = @"D:\test1.jpg";
            var fileName = @"D:\my_photo.jpg";
            //var fileName = @"D:\small.jpg";

            var pallet = ImageProcessor.GetPallet(fileName);

            var number = ImageProcessor.CountImageColors(fileName);

            Console.WriteLine($"Total number of colors: {number}");

            var abundantColors = pallet.GetMostCommonColors(10).ToList();

            foreach (ColorAbundance colorAbundance in abundantColors)
            {
                Console.WriteLine(colorAbundance.PalletColor + " -> " + colorAbundance.Abundance);
            }


            Console.ReadKey();
        }
    }
}
