using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThread
{
    //Трехмерная реализация задачи
    public class Space_3D : Space
    {
        public class Dot_3D
        {
            public float x { get; set; }
            public float y { get; set; }
            public float z { get; set; }

            Random rand = new Random(DateTime.Now.Millisecond);

            Dot_3D(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public Dot_3D()
            {
                x = (float)rand.NextDouble() * 100;
                y = (float)rand.NextDouble() * 100;
                z = (float)rand.NextDouble() * 100;
            }

            public Dot_3D(int size)
            {
                x = (float)rand.NextDouble() * size;
                y = (float)rand.NextDouble() * size;
                z = (float)rand.NextDouble() * size;
            }
            public void print()
            {
                Console.Write(this.x);
                Console.Write(" | ");
                Console.Write(this.y);
                Console.Write(" | ");
                Console.Write(this.z);
                Console.WriteLine();
            }
        }
        

        Random rand = new Random(DateTime.Now.Millisecond);

        public Space_3D()
        {
            size = 100;
            dencity = 1;
            List<Dot_3D> space = new List<Dot_3D>();
            for(int i = 0; i < 10; i++)
            {
                Dot_3D point = new Dot_3D(); 
                space.Add(point);
                space[i].print();
                
            }
        }
        public Space_3D(int size, float dencity)
        {
            this.size = size;
            this.dencity = dencity;
        }
    }
}
