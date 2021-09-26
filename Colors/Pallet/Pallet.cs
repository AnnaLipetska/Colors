using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace PalletLib
{
    public class Pallet
    {
        readonly Bitmap _bmp;

        public Pallet(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    _bmp = new Bitmap(fileName);
                }
                catch
                {
                    throw new Exception("Not a bitmap image!!!");
                }
            }
        }

        public IEnumerable<KeyValuePair<Color, int>> GetMostFrequentColors(int number)
        {
            var colors = GetAllColors();
            return colors.OrderByDescending(c => c.Value).Take(number);
        }

        IDictionary<Color, int> GetAllColors()
        {
            var colors = new Dictionary<Color, int>();

            if (_bmp != null)
            {
                for (int y = 0; y < _bmp.Size.Height; y++)
                {
                    for (int x = 0; x < _bmp.Size.Width; x++)
                    {
                        var pixel = _bmp.GetPixel(x, y);
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

            return colors;
        }

        public int CountImageColors()
        {
            var count = 0;
            var colors = new HashSet<Color>();

            if (_bmp != null)
            {
                for (int y = 0; y < _bmp.Size.Height; y++)
                {
                    for (int x = 0; x < _bmp.Size.Width; x++)
                    {
                        colors.Add(_bmp.GetPixel(x, y));
                    }
                }
                count = colors.Count;
            }

            return count;
        }
    }
}
