using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread
{
    public class Space2D : Space
    {
        private List<Point2D> Collection;

        public Space2D()
        {
            Density = 1f;
            Resolutin = 100f;

            Collection = Generate(Resolutin, Density);

        }

        public Space2D(float res, float den)
        {
            Resolutin = res;
            Density = den;

            Collection = Generate(Resolutin, Density);
        }

        public void Print()
        {
            foreach (Point2D element in Collection)
                element.Print();
        }

        private List<Point2D> Generate(float res, float den)
        {
            List<Point2D> result = new List<Point2D>();

            Task<List<Point2D>>[] tasks = new Task<List<Point2D>>[NUM_OF_THREADS];

            for (int threadNum = 0; threadNum < NUM_OF_THREADS; threadNum++)
            {
                tasks[threadNum] = new Task<List<Point2D>>(() =>
                {
                    List<Point2D> points = new List<Point2D>();
                    for (int i = 0; i < Density * Resolutin / NUM_OF_THREADS; i++)
                    {
                        Point2D point = new Point2D(random, Resolutin);
                        points.Add(point);
                        Thread.Sleep(1);
                    }
                    return points;
                });
            }

            foreach (Task<List<Point2D>> task in tasks)
                task.Start();

            Task.WaitAll(tasks);

            foreach (Task<List<Point2D>> part in tasks)
            {
                result.AddRange(part.Result);
            }

            return result;
        }

        private List<List<Point2D>> GetClasters()
        {
            List<List<Point2D>> clasters = new List<List<Point2D>>();
            List<Point2D> Source = Collection.Select(p => p.Clone()).ToList();//копия списка точек
            List<Point2D> Clast = new List<Point2D>();
            Clast.Add(Source[0]);
            while (Source.Count > 0)
            {
                
            }
            return clasters;
        }

        private bool IsNear(List<Point2D> first, List<Point2D> second, float radius)//сравнивает два списка и возвращает true если есть есть точки на расстоянии меньше radius
        {
            foreach(var elem1 in first)
            {
                foreach(var elem2 in second)
                {
                    if (elem1.Distance(elem2) < radius)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsNear(List<Point2D> list, Point2D point, float range)
        {
            foreach(var elem in list)
            {
                if (elem.Distance(point) < range)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
