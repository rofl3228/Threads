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
            List<Point3D> Source = new List<Point3D>(Collection);//копия списка точек
            
            while(Source.Count > 0)
            {
                List<Point3D> points = new List<Point3D>();;
                do
                {
                    if(points.Count == 0)
                    {
                        points.Add(Source[0]);
                        Source.RemoveAt(0);
                    }
                    List<int> ToRemove = new List<int>();
                    for (int i = 0; i < Source.Count; i++)
                    {
                        Point3D elem = Source[i];
                        if (IsNear(elem, points, CLAST_RADIUS))
                        {
                            points.Add(elem);
                            ToRemove.Add(i);
                        }
                    }
                    foreach(int index in ToRemove)
                    {
                        Source.RemoveAt(index);
                    }
                }
                while (IsNear(Source, points, CLAST_RADIUS));
                clasters.Add(points);
            }
            return clasters;
        }

        public void ClasterPrint()
        {
            List<List<Point3D>> clasters = GetClasters();
            foreach(List<Point3D> clast in clasters)
            {
                foreach(Point3D elem in clast)
                {
                    elem.Print();
                }
                Console.WriteLine();
            }
        }

        static bool IsNear(List<Point3D> first, List<Point3D> second, float radius)//сравнивает два списка и возвращает true если есть есть точки на расстоянии меньше radius
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

        static bool IsNear(Point3D first, List<Point3D> list, float radius)
        {
            for(int i = 0; i < list.Count; i++)
            {
                if (first.Distance(list[i]) < radius)
                    return true;
            }
            return false;
        }

        static List<Point3D> GetNear(List<Point3D> scources, List<Point3D> collected, float radius)
        {
            List<Point3D> result = new List<Point3D>();
            List<int> ToRemove = new List<int>();

            for (int i = 0; i < scources.Count; i++)
            {
                if(IsNear(scources[i], result, radius))
                {
                    result.Add(scources[i]);
                    ToRemove.Add(i);
                }
            }
            foreach (int index in ToRemove)
                scources.RemoveAt(index);
            
            return result;
        }
    }
}