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
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Space3D space3D = new Space3D(400, 4);
            //space3D.Print();
            stopwatch.Stop();
            //space3D.ClasterPrint();
            Console.WriteLine(space3D.NumOfClast());
            Console.WriteLine(space3D.NumOfElem());
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadKey();
        }
    }
}
