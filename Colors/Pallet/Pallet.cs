using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace PalletLib
{
    public struct ColorAbundance
    {
        public Color PalletColor { get; set; }
        public int Abundance { get; set; }

        public ColorAbundance(Color color, int abundance)
        {
            PalletColor = color;
            Abundance = abundance;
        }
    }

    public class Pallet
    {
        readonly Bitmap _bmp;

        IList<ColorAbundance> _colors = new List<ColorAbundance>();

        int this[Color color]
        {
            get => _colors.Where(c => c.PalletColor == color).Select(c => c.Abundance).FirstOrDefault();
            set 
            {
                if (_colors.Any(c => c.PalletColor == color))
                {
                    var colorAbundance = _colors.Where(c => c.PalletColor == color).FirstOrDefault();
                    _colors.Remove(colorAbundance);
                }
                if (value > 0)
                {
                    _colors.Add(new ColorAbundance(color, value));
                }
            } 
        }

        public Pallet(Bitmap bmp)
        {
            _bmp = bmp;
            //InitColors();
            InitColorsForBiggerPicturesBruteForce();
        }

        public Pallet(Bitmap bmp, int downgradeSquares)
        {
            _bmp = bmp;
            InitColorsWithDownGrade(downgradeSquares);
        }

        public IEnumerable<ColorAbundance> GetMostCommonColors(int number)
        {
            return _colors.OrderByDescending(c => c.Abundance).Take(number);
        }

        void InitColorsForSmallPicturesOnlyBruteForce() // Looks nice, but awfully slow for bigger pictures
        {
            if (_bmp != null)
            {
                for (int y = 0; y < _bmp.Size.Height; y++)
                {
                    for (int x = 0; x < _bmp.Size.Width; x++)
                    {
                        var pixel = _bmp.GetPixel(x, y);

                        this[pixel]++;
                    }
                }
            }
        }

        void InitColorsForBiggerPicturesBruteForce() // Faster because dictionaries work with HashCodes
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

            foreach (var color in colors)
            {
                _colors.Add(new ColorAbundance(color.Key, color.Value));
            }
        }

        void InitColorsWithDownGrade(int squares)
        {
            //TODO: Write some code here
        }
    }
}
