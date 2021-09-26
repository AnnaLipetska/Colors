using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using PalletLib;

namespace PalletLibTest
{
    [TestClass]
    public class PalletTest
    {
        [TestMethod]
        public void TestCountImageColorsJpg1()
        {
            var expected = 1;

            string file = @"D:\test1.jpg";
            var pallet = new Pallet(file);

            var actual = pallet.CountImageColors();

            Assert.AreEqual(expected, actual, $"Expected: {expected}, actual: {actual}"); 
        }
    }
}