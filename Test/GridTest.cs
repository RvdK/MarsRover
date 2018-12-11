using System;
using System.Collections.Generic;
using System.Text;
using Mars;
using Mars.Plateau;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class GridTest
    {
        [TestMethod]
        public void AddRoversucces()
        {
            var grid = new Grid(new Vector(5,5));
            var rover = new Rover(new Vector(2,2),new Vector(1,0),"LLM");

            Assert.IsTrue(grid.AddRover(rover));
        }

        [TestMethod]
        public void AddRoverOutOfBounds()
        {

            var grid = new Grid(new Vector(5, 5));
            var rover = new Rover(new Vector(8, 2), new Vector(1, 0), "LLM");
            var gridString = grid.DebugString();
            Assert.IsFalse(grid.AddRover(rover));
            Assert.AreEqual(gridString, grid.DebugString());
        }

        [TestMethod]
        public void AddRoverPositionTaken()
        {
            var grid = new Grid(new Vector(5, 5));
            var rover = new Rover(new Vector(2, 2), new Vector(1, 0), "LLM");
            var rover2 = new Rover(new Vector(2, 2), new Vector(1, 0), "LLM");
            Assert.IsTrue(grid.AddRover(rover));
            var gridString = grid.DebugString();
            Assert.IsFalse(grid.AddRover(rover2));
            Assert.AreEqual(gridString,grid.DebugString());
        }

        [TestMethod]
        public void MoveRoverTest()
        {
            var grid = new Grid(new Vector(5, 5));
            var rover = new Rover(new Vector(2, 2), new Vector(1, 0), "M");
            grid.AddRover(rover);
            grid.MoveRovers();
            Assert.AreEqual(rover.Position.ToString(), (new Vector(3,2)).ToString());
        }

        [TestMethod]
        public void MultipleMoveRoverTest()
        {
            var grid = new Grid(new Vector(5, 5));
            var rover = new Rover(new Vector(2, 2), new Vector(1, 0), "MMLM");
            var rover2 = new Rover(new Vector(0, 0), new Vector(-1, 0), "LLM");
            grid.AddRover(rover);
            grid.AddRover(rover2);
            grid.MoveRovers();
            Assert.AreEqual(rover.Position.ToString(), (new Vector(4, 3)).ToString());
            Assert.AreEqual(rover2.Position.ToString(), (new Vector(1, 0)).ToString());
        }


        [TestMethod]
        public void MoveRoverTestoutOfBound()
        {
            var grid = new Grid(new Vector(5, 5));
            var rover = new Rover(new Vector(2, 2), new Vector(1, 0), "MMMMMMMMMM");
            grid.AddRover(rover);
            grid.MoveRovers();
            Assert.AreEqual(rover.Position.ToString(), (new Vector(4, 2)).ToString());
        }

        [TestMethod]
        public void MoveRoverTestCollision()
        {
            var grid = new Grid(new Vector(5, 5));
            var rover = new Rover(new Vector(2, 2), new Vector(1, 0), "MMM");
            var rover2 = new Rover(new Vector(4, 2), new Vector(-1, 0), "LL");
            grid.AddRover(rover);
            grid.AddRover(rover2);
            grid.MoveRovers();
            Assert.AreEqual(rover.Position.ToString(), (new Vector(3, 2)).ToString());
            Assert.AreEqual(rover2.Position.ToString(), (new Vector(4, 2)).ToString());
        }
    }
}
