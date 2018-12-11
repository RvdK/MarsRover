using System;
using System.Collections.Generic;

using System.Text;

namespace Mars.Plateau
{
    public class Rover
    {
        public Vector Direction;

        public Vector Position;

        public string Commands;

        public Rover(Vector pos, Vector dir,string commands)
        {
            Direction = dir;
            Position = pos;
            Commands = commands;
        }
        
        public void TurnRight()
        {
            // (y,-x)
            Direction = new Vector()
            {
                X = Direction.Y,
                Y = -Direction.X
            };
        }

        public void TurnLeft()
        {
            //  (-y,x)
            Direction = new Vector()
            {
                X = -Direction.Y,
                Y = Direction.X
            };
        }

        public void Move()
        {
            // this is currenlty a rather useless piece of code since it is all basically done at grid level but this is were the code should be expanded for the actual hardware control code
            Position.Add(Direction);
        }

        public string DebugString()
        {
            return $"Rover pos: {Position.ToString()} dir: {Direction.ToString()} commands: {Commands}";
        }
    }
}
