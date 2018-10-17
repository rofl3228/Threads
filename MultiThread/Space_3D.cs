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
        public int Size { get; set; }
        public float Density { get; set; }
        const int THREAD_NUM = 4;
        Random rand = new Random(DateTime.Now.Millisecond);
        private List<Dot_3D> space = new List<Dot_3D>();


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

            public void print()
            {
                Console.WriteLine($"{x} | {y} | {z}");
            }

            public float Range(Dot_3D other)
            {
                return (float)Math.Sqrt(Math.Pow(x - other.x, 2) + Math.Pow(y - other.y, 2) + Math.Pow(z - other.z, 2));
            }
        }

        public Space_3D()
        {
            Size = 100;
            Density = 1;
            

            Task<List<Dot_3D>>[] tasks = new Task<List<Dot_3D>>[THREAD_NUM];

            for (int i = 0; i < THREAD_NUM; i++)
            {
                tasks[i] = new Task<List<Dot_3D>>(() =>
                {
                    List<Dot_3D> dots = new List<Dot_3D>();
                    for (int j = 0; j < (int)(Size * Density / THREAD_NUM); j++)
                    {
                        Dot_3D point = new Dot_3D(rand);
                        dots.Add(point);
                        Thread.Sleep(1);
                    }
                    return dots;
                });
            }

            foreach (var task in tasks)
                task.Start();
            Task.WaitAll(tasks);

            foreach (var task in tasks)
                space.AddRange(task.Result);
        }

        public Space_3D(int size, float density)
        {
            Size = size;
            Density = density;
            Task<List<Dot_3D>>[] tasks = new Task<List<Dot_3D>>[THREAD_NUM];

            for (int i = 0; i < THREAD_NUM; i++)
            {
                tasks[i] = new Task<List<Dot_3D>>(() =>
                {
                    List<Dot_3D> dots = new List<Dot_3D>();
                    for (int j = 0; j < (int)(Size * Density / THREAD_NUM); j++)
                    {
                        Dot_3D point = new Dot_3D(Size, rand);
                        dots.Add(point);
                        Thread.Sleep(1);
                    }
                    return dots;
                });
            }

            foreach (var task in tasks)
                task.Start();

            Task.WaitAll(tasks);

            foreach (var task in tasks)
                space.AddRange(task.Result);
        }

        public void _d_print()
        {
            foreach (var elem in space)
                elem.print();
        }

        public List<List<Dot_3D>> Clasters
        {
            get
            {
                List<List<Dot_3D>> clasters = new List<List<Dot_3D>>();
                //Алгоритм, который возврващет список списков-кластеров
            }
        }
    }
}
