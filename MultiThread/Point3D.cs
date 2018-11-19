using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThread
{
    internal class Point3D : Point, ICloneable
    {
        protected float Z { get; set; }

        public Point3D(Random random, float range)
        {
            X = (float)random.NextDouble() * range * 2 - range;
            Y = (float)random.NextDouble() * range * 2 - range;
            Z = (float)random.NextDouble() * range * 2 - range;
        }

        public Point3D(Random random)
        {
            X = (float)random.NextDouble() * 200 - 100;
            Y = (float)random.NextDouble() * 200 - 100;
            Z = (float)random.NextDouble() * 200 - 100;
        }

        public Point3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3D()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public void Print() => Console.WriteLine($"{X:f5}  |  {Y:f5}  |  {Z:f5}");

        public Point3D Clone() => new Point3D(X, Y, Z);

        public float Distance(Point3D another) => (float)Math.Sqrt(Math.Pow((X - another.X), 2) + Math.Pow((Y - another.Y), 2) + Math.Pow((Z - another.Z), 2));
    }
}
