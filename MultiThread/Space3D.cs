using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread
{
    internal class Space3D : Space
    {
        private List<Point3D> Collection;

        public Space3D()
        {
            Density = 1f;
            Resolutin = 100f;

            Collection = Generate(Resolutin, Density);
        }

        public Space3D(float res, float den)
        {
            Resolutin = res;
            Density = den;

            Collection = Generate(Resolutin, Density);
        }

        public void Print()
        {
            foreach (Point3D element in Collection)
                element.Print();
        }

        private List<Point3D> Generate(float res, float den)
        {
            List<Point3D> result = new List<Point3D>();

            Task<List<Point3D>>[] tasks = new Task<List<Point3D>>[NUM_OF_THREADS];

            for (int threadNum = 0; threadNum < NUM_OF_THREADS; threadNum++)
            {
                tasks[threadNum] = new Task<List<Point3D>>(() =>
                {
                    List<Point3D> points = new List<Point3D>();
                    for (int i = 0; i < den * res / NUM_OF_THREADS; i++)
                    {
                        Point3D point = new Point3D(random, res);
                        points.Add(point);
                        Thread.Sleep(1);
                    }
                    return points;
                });
            }

            foreach (Task<List<Point3D>> task in tasks)
                task.Start();

            Task.WaitAll(tasks);

            foreach (Task<List<Point3D>> part in tasks)
            {
                result.AddRange(part.Result);
            }

            return result;
        }

        private List<List<Point3D>> GetClasters()
        {
            List<List<Point3D>> clasters = new List<List<Point3D>>();
            List<Point3D> Source = Collection.Select(p => p.Clone()).ToList();//копия списка точек

            return clasters;
        }

        private bool IsNear(List<Point3D> first, List<Point3D> second, float radius)//сравнивает два списка и возвращает true если есть есть точки на расстоянии меньше radius
        {
            foreach (var elem1 in first)
            {
                foreach (var elem2 in second)
                {
                    if (elem1.Distance(elem2) < radius)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
