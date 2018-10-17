using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiThread
{
    //Двумерная реализация задачи
    partial class Space_2D : Space
    {
        public int Size { get; set; }
        public float Density { get; set; }
        const int THREAD_NUM = 4;
        Random rand = new Random(DateTime.Now.Millisecond);
        private List<Dot_2D> space = new List<Dot_2D>();

        public Space_2D()
        {
            Size = 100;
            Density = 1;


            Task<List<Dot_2D>>[] tasks = new Task<List<Dot_2D>>[THREAD_NUM];

            for (int i = 0; i < THREAD_NUM; i++)
            {
                tasks[i] = new Task<List<Dot_2D>>(() =>
                {
                    List<Dot_2D> dots = new List<Dot_2D>();
                    for (int j = 0; j < (int)(Size * Density / THREAD_NUM); j++)
                    {
                        Dot_2D point = new Dot_2D(rand);
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

        public Space_2D(int size, float density)
        {
            Size = size;
            Density = density;
            Task<List<Dot_2D>>[] tasks = new Task<List<Dot_2D>>[THREAD_NUM];

            for (int i = 0; i < THREAD_NUM; i++)
            {
                tasks[i] = new Task<List<Dot_2D>>(() =>
                {
                    List<Dot_2D> dots = new List<Dot_2D>();
                    for (int j = 0; j < (int)(Size * Density / THREAD_NUM); j++)
                    {
                        Dot_2D point = new Dot_2D(Size, rand);
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

        public List<List<Dot_2D>> Clasters
        {
            get
            {
                List<List<Dot_2D>> clasters = new List<List<Dot_2D>>();
                //Алгоритм, который возврващет список списков-кластеров
            }
        }
    }
}
