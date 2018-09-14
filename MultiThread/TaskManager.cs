using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThread
{
    class TaskManager
    {
        protected string Ex { set; get; }
        public TaskManager()
        {
            Ex = "Sample task";
            /*Создать сокет для регистрации юнитов
             * создать поток для опроса сокета. Если есть подключение, то добавить в список юнитов
             * создать кучу для задач (пустую)
             * Сделать POUNCE в окно.
             */
            Console.WriteLine(Ex);
        }
        void addTask(Task task)//направляет задание на юниты
        {

        }
    }
}
