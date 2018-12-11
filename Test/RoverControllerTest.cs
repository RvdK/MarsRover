using System;
using System.Collections.Generic;
using System.Text;
using Mars;
using Mars.Controllers;
using Mars.Plateau;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
   public class RoverControllerTest
    {
        [TestMethod]
        public void TestHappyFlow()
        {
            var grid = new Grid(new Vector(5, 5));
            var rover = new Rover(new Vector(2, 2), new Vector(1, 0), "M");
            var rover2 = new Rover(new Vector(3, 1), new Vector(0, 1), "LMR");
            grid.AddRover(rover);
            grid.AddRover(rover2);
            grid.MoveRovers();


            var controller = new RoverController();
            var result = controller.Debug("5 5\n2 2 E\nM\n3 1 N\nLMR");

            Assert.AreEqual(grid.DebugString(),result);
        }

        [TestMethod]
        public void TestUnmovingRover()
        {
            var grid = new Grid(new Vector(5, 5));
            var rover = new Rover(new Vector(2, 2), new Vector(1, 0), "");
            var rover2 = new Rover(new Vector(3, 1), new Vector(0, 1), "LMR");
            grid.AddRover(rover);
            grid.AddRover(rover2);
            grid.MoveRovers();


            var controller = new RoverController();
            var result = controller.Debug("5 5\n2 2 E\n\n3 1 N\nLMR");

            Assert.AreEqual(grid.DebugString(), result);
        }

        [TestMethod]
        public void TestSyntaxErrorDimensions()
        {
            var controller = new RoverController();
            Assert.AreEqual(controller.Debug("6 6n\n1 2 N\nLLM"), "invalid syntax");
        }

        [TestMethod]
        public void TestSyntaxErrorunknownCommand()
        {
            var controller = new RoverController();
            Assert.AreEqual(controller.Debug("6 6\n1 2 N\nL3M"), "invalid syntax");
        }

        [TestMethod]
        public void TestSyntaxErrorDirection()
        {
            var controller = new RoverController();
            Assert.AreEqual(controller.Debug("6 6\n1 2 G\nLLM"), "invalid syntax");
        }

        [TestMethod]
        public void TestSyntaxErrorPadded()
        {
            var controller = new RoverController();
            Assert.AreEqual(controller.Debug("6 6\n1 2 G\nLLM\nhello world"), "invalid syntax");
        }

        [TestMethod]
        public void testSyntaxErrorNoRover()
        {
            var controller = new RoverController();
            Assert.AreEqual(controller.Debug("6 6\n"), "invalid syntax");
        }

    }
}
