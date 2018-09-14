using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThread
{
    class Program
    {
        static void Main(string[] args)
        {
            //Entry point
            TaskManager taskManager = new TaskManager();
            //taskManager.activate();//создает сокеты и кучу для заданий. Тут открывается окно для ввода заданий и мониторинга
            Console.ReadKey();
        }
    }
}
