using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiThread
{
    //Трехмерная реализация задачи
    public class Space_3D : Space
    {
        public float Size { get; set; }
        public float Density { get; set; }
        const int THREAD_NUM = 2;


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

            public Dot_3D(int _size)
            {
                x = (float)rand.NextDouble() * _size;
                y = (float)rand.NextDouble() * _size;
                z = (float)rand.NextDouble() * _size;
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

        public Space_3D()
        {
            Size = 100;
            Density = 1;
            List<Dot_3D> space = new List<Dot_3D>();
            for(int i = 0; i < 6*Size; i++)
            {
                Dot_3D point = new Dot_3D(); 
                space.Add(point);
                space[i].print();
                Thread.Sleep(1);
            }
        }
        public Space_3D(int size, float density)
        {
            Size = size;
            Density = density;
            List<Dot_3D> space = new List<Dot_3D>();
            
            Task<List<Dot_3D>> dot_3Ds1 = new Task<List<Dot_3D>>(() =>
            {
                List<Dot_3D> dots = new List<Dot_3D>();
                for (int i = 0; i < (int)(Size * 0.5 * Density); i++)
                {
                    Dot_3D point = new Dot_3D();
                    dots.Add(point);
                    Thread.Sleep(1);
                }
                return dots;
            });

            Task<List<Dot_3D>> dot_3Ds2 = new Task<List<Dot_3D>>(() =>
            {
                List<Dot_3D> dots = new List<Dot_3D>();
                for (int i = 0; i < (int)(Size * 0.5 * Density); i++)
                {
                    Dot_3D point = new Dot_3D();
                    dots.Add(point);
                    Thread.Sleep(1);
                }
                return dots;
            });

            dot_3Ds1.Start();
            dot_3Ds2.Start();

            space.AddRange(dot_3Ds1.Result);
            space.AddRange(dot_3Ds2.Result);
            Console.WriteLine(space.Capacity);
            //for(int i = 0; i < size * 6 * density; i++)
            //{
            //    Dot_3D point = new Dot_3D();
            //    space.Add(point);
            //    Thread.Sleep(1);

            //}
        }
        public void Generate(object obj)
        {
            int numOfElements = (int)obj;

        }
    }
}
