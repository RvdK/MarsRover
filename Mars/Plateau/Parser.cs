namespace Mars.Plateau
{
    public static class Parser
    {
        public static Grid ParseGrid(string paramString)
        {
            var lineElements = paramString.Split(' ');

            var gridSize = new Vector
            {
                X = int.Parse(lineElements[0]),
                Y = int.Parse(lineElements[1])
            };
            return new Grid(gridSize);
        }

        public static bool ParseRover(string loc, string commands, Grid grid)
        {
            var lineElements = loc.Split(' ');

            var position = new Vector
            {
                X = int.Parse(lineElements[0]),
                Y = int.Parse(lineElements[1])
            };

            var rover = new Rover(position, ParseCardinal(lineElements[2]), commands);

            return grid.AddRover(rover);
        }

        public static Vector ParseCardinal(string compass)
        {
            switch (compass)
            {
                case "N": return new Vector {X = 0, Y = 1};
                case "S": return new Vector {X = 0, Y = -1};
                case "E": return new Vector {X = 1, Y = 0};
                case "W": return new Vector {X = -1, Y = 0};
                default: return new Vector {X = 0, Y = 0};
            }
        }
    }
}