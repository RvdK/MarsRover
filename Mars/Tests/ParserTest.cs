using System;
using System.Runtime.InteropServices;
using System.Xml;
using Mars.Plateau;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mars.Tests
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var north = new Vector() { X = 1, Y = 0 };

            Assert.AreEqual(Parser.ParseCardinal("N").ToString(), north.ToString());
        }
    }
}