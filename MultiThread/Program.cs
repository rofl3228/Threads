using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MultiThread
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Entry point
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //Space2D space2D = new Space2D(200, 2);
            //space2D.Print();
            //sw.Stop();
            //TimeSpan timeSpan = sw.Elapsed;
            //Console.WriteLine(timeSpan);
            //Console.ReadKey();
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //Space3D space3D = new Space3D(500, 2);
            //space3D.Print();
            //stopwatch.Stop();
            //Console.WriteLine(stopwatch.Elapsed);
            //Console.ReadKey();

            Space3D space3D = new Space3D(100, 2);
            //space3D.Print();
            Console.WriteLine();
            space3D.ClasterPrint();

            Console.ReadKey();
        }
    }
}
