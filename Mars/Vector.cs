namespace Mars
{
    public class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector()
        {
            
        }

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vector Add(Vector add)
        {
            X += add.X;
            Y += add.Y;
            return this;
        }


        public bool IsInRange(Vector large)
        {
            return large.X > X && large.Y > Y;
        }

        public bool IsPositive()
        {
            return X >= 0 && Y >= 0;
        }

        public Vector Copy()
        {
            return new Vector(X, Y);
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }


    }
}