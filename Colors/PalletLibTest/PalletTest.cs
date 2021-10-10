using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using PalletLib;

namespace PalletLibTest
{
    [TestClass]
    public class ImageProcessorTest
    {
        [TestMethod]
        public void TestCountImageColorsJpg1()
        {
            var expected = 1;

            string path = @"D:\test1.jpg";
            //var pallet = ImageProcessor.GetPallet(path);

            var actual = ImageProcessor.CountImageColors(path);

            Assert.AreEqual(expected, actual, $"Expected: {expected}, actual: {actual}"); 
        }
    }
}
