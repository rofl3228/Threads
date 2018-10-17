using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MultiThread
{
    class Program
    {
        static void Main(string[] args)
        {
            //Entry point
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Space_3D A = new Space_3D(1000, 2);
            sw.Stop();
            TimeSpan timeSpan = sw.Elapsed;
            Console.WriteLine(timeSpan);
            Console.ReadKey();
            A._d_print();
            Console.ReadKey();
        }
    }
}
