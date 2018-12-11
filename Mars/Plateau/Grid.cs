using System.Collections.Generic;

namespace Mars.Plateau
{
    public class Grid
    {
        private readonly Vector dimensions;
        private readonly Dictionary<string, bool> roverLocations;

        private readonly List<Rover> rovers;

        public Grid(Vector dimensions)
        {
            roverLocations = new Dictionary<string, bool>();
            rovers = new List<Rover>();
            this.dimensions = dimensions;
        }

        public bool AddRover(Rover r)
        {
            if (roverLocations.ContainsKey(r.Position.ToString()) || !IsinRange(r.Position))
                return false;
            roverLocations.Add(r.Position.ToString(), true);
            rovers.Add(r);
            return true;
        }

        public void MoveRovers()
        {
            foreach (var rover in rovers)
                MoveRover(rover);
        }

        private void MoveRover(Rover rover)
        {
            foreach (var c in rover.Commands)
                switch (c)
                {
                    case 'L':
                        rover.TurnLeft();
                        break;
                    case 'R':
                        rover.TurnRight();
                        break;
                    default:  if(!TryMove(rover)) return;
                        break;
                }
        }

        private bool TryMove(Rover rover)
        {
            var newPos = rover.Position.Copy().Add(rover.Direction);
            if (roverLocations.ContainsKey(newPos.ToString()) || !IsinRange(newPos))
                return false;
            roverLocations.Remove(rover.Position.ToString());
            rover.Move();
            roverLocations.Add(rover.Position.ToString(),true);

            return true;
        }


        private bool IsinRange(Vector pos)
        {
            return pos.IsInRange(dimensions) && pos.IsPositive();
        }

        public string DebugString()
        {
            var str = $"dimension: {dimensions}\n";
            foreach (var rover in rovers)
                str += $"{rover.DebugString()} \n";

            return str;
        }
    }
}