using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThread
{
    //Класс пространства с точками
    abstract public class Space
    {
        public int size { get; set; }
        public float Density { get; set; }
    }
}
