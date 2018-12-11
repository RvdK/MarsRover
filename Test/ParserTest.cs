using System;
using System.Collections.Generic;
using System.Text;
using Mars;
using Mars.Plateau;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void ParseGridTest()
        {
            var grid = new Grid(new Vector(6 ,7));

            Assert.AreEqual(Parser.ParseGrid("6 7").DebugString(), grid.DebugString());
        }

        [TestMethod]
        public void ParseRoverTest()
        {
            var grid = new Grid(new Vector(6, 7));
            var rover = new Rover(new Vector(2,2), new Vector(1,0),"MLR" );
            grid.AddRover(rover);
            var grid2 = new Grid(new Vector(6, 7));
            Assert.IsTrue(Parser.ParseRover("2 2 E","MLR",grid2));
            Assert.AreEqual(grid2.DebugString(),grid.DebugString());
        }

        [TestMethod]
        public void ParseRoverCollisionTest()
        {
            var grid2 = new Grid(new Vector(6, 7));
            Assert.IsTrue(Parser.ParseRover("2 2 W", "MLR", grid2));
            Assert.IsFalse(Parser.ParseRover("2 2 W", "MLR", grid2));
        }
    }
}
