using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThread
{
    internal class Point2D : Point, ICloneable
    {
        public Point2D(Random random, float range)
        {
            X = (float)random.NextDouble() * range * 2 - range;
            Y = (float)random.NextDouble() * range * 2 - range;
        }

        public Point2D(Random random)
        {
            X = (float)random.NextDouble() * 200 - 100;
            Y = (float)random.NextDouble() * 200 - 100;
        }

        public Point2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Point2D()
        {
            X = 0;
            Y = 0;
        }

        public void Print() => Console.WriteLine($"{X:f5}  |  {Y:f5}");

        public Point2D Clone() => new Point2D(X, Y);

        public float Distance(Point2D another) => (float)Math.Sqrt(Math.Pow((X - another.X), 2) + Math.Pow((Y - another.Y), 2));
    }
}
