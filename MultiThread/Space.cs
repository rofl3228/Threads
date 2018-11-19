using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread
{
    abstract public class Space
    {
        
        protected float Resolutin { get; set; }
        protected float Density { get; set; }
        protected const int NUM_OF_THREADS = 4;

        protected readonly Random random = new Random();

        public void Clastering() { }
        public void dPrint() { }
    }
}
