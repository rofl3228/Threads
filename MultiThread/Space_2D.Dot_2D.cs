using System;

namespace MultiThread
{
    partial class Space_2D
    {
        public class Dot_2D
        {
            public float x { get; set; }
            public float y { get; set; }

            public Dot_2D(float x, float y)
            {
                this.x = x;
                this.y = y;
            }

            public Dot_2D()
            {
                x = 0;
                y = 0;
            }

            public Dot_2D(Random random)
            {
                x = (float)random.NextDouble() * 100;
                y = (float)random.NextDouble() * 100;
            }

            public Dot_2D(int _size, Random random)
            {
                x = (float)random.NextDouble() * _size;
                y = (float)random.NextDouble() * _size;
            }

            public void print() => Console.WriteLine($"{x} | {y}");

            public float Range(Dot_2D other) => (float)Math.Sqrt(Math.Pow(x - other.x, 2) + Math.Pow(y - other.y, 2));
        }
    }
}
