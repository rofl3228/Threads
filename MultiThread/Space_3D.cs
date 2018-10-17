using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiThread
{
    //Трехмерная реализация задачи
    public partial class Space_3D : Space
    {
        public int Size { get; set; }
        public float Density { get; set; }
        const int THREAD_NUM = 4;
        Random rand = new Random(DateTime.Now.Millisecond);
        private List<Dot_3D> space = new List<Dot_3D>();

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
