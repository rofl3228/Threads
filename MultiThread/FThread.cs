using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThread
{
    class FThread<S, SResult>
    {
        private Thread MyThread;

        public SResult Result { get; internal set; }

        public FThread(S listOne, S listTwo, Func<S, S, SResult> func)
        {
            MyThread = new Thread(() => Result = func(listOne, listTwo));
        }

        public void Start() => MyThread.Start();

    }
}
