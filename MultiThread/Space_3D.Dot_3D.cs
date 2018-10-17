using System;

namespace MultiThread
{

    public partial class Space_3D
    {
        public class Dot_3D
        {
            public float x { get; set; }
            public float y { get; set; }
            public float z { get; set; }

            

            Dot_3D(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public Dot_3D(Random rand)
            {
                x = (float)rand.NextDouble() * 100;
                y = (float)rand.NextDouble() * 100;
                z = (float)rand.NextDouble() * 100;
            }

            public Dot_3D(int _size, Random rand)
            {
                x = (float)rand.NextDouble() * _size;
                y = (float)rand.NextDouble() * _size;
                z = (float)rand.NextDouble() * _size;
            }

            public Dot_3D()
            {
                x = 0;
                y = 0;
                z = 0;
            }

            public void print() => Console.WriteLine($"{x} | {y} | {z}");

            public float Range(Dot_3D other) => (float)Math.Sqrt(Math.Pow(x - other.x, 2) + Math.Pow(y - other.y, 2) + Math.Pow(z - other.z, 2));
        }
    }
}
