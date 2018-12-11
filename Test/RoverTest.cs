using Mars;
using Mars.Plateau;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class RoverTest
    {
        
        [TestMethod]
        public void TestTurnRight()
        {
            var pos = new Vector {X = 0, Y = 0};
            var dir = new Vector {X = 1, Y = 0};
            var expectedDir = new Vector {X = 0, Y = -1};
            
            var rover = new Rover(pos,dir,"MML");

            rover.TurnRight();
            Assert.AreEqual(rover.Direction.ToString(),expectedDir.ToString());
        }

        [TestMethod]
        public void TestTurnLeft()
        {
            var pos = new Vector { X = 0, Y = 0 };
            var dir = new Vector { X = -1, Y = 0 };
            var expectedDir = new Vector { X = 0, Y = -1 };

            var rover = new Rover(pos, dir, "MML");

            rover.TurnLeft();
            Assert.AreEqual(rover.Direction.ToString(), expectedDir.ToString());
        }

        [TestMethod]
        public void TestMove()
        {
            var pos = new Vector { X = 2, Y = 4 };
            var dir = new Vector { X = 1, Y = 0 };
            var expectedPos = new Vector { X = 3, Y = 4 };

            var rover = new Rover(pos, dir, "MML");

            rover.Move();
            Assert.AreEqual(rover.Position.ToString(), expectedPos.ToString());
        }
        
    }
}