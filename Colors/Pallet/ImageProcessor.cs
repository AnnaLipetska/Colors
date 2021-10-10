using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalletLib
{
    public class ImageProcessor
    {
        public static Bitmap GetBitmap(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    using (FileStream fs = File.OpenRead(path))
                    {
                        return new Bitmap(fs);
                    }

                    // return new Bitmap(path); // Alternative way
                }
                catch
                {
                    throw new Exception("Not a bitmap image!!!");
                }
            }
            else
            {
                throw new FileNotFoundException($"File {path} does not exist!!!");
            }
        }

        public static Pallet GetPallet(string path)
        {
            var bitmap = GetBitmap(path);
            return new Pallet(bitmap);
        }

        public static int CountImageColors(string path)
        {
            var bmp = GetBitmap(path);

            var count = 0;
            var colors = new HashSet<Color>();

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

            return count;
        }
    }
}
