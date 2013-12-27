using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Skyworth.Parallel
{
    public abstract class Worker:IDisposable
    {
        protected volatile bool isWorking = false;
        private Thread workThread = null;
        protected Basket<int> basket;
        public void Work(string name = null)
        {
            if (isWorking)
            {
                throw new Exception(this.GetType().ToString() + " Work() " + " is working ");
            }
            isWorking = true;
            workThread = new Thread(() => {
                Debug.WriteLine(name + " 开始 ");
                DoWork();
            });
            workThread.Name = name;
            workThread.IsBackground = true;
            workThread.Start();
        }

        public abstract void DoWork();

        public void Dispose()
        {
            isWorking = false;
            if (workThread != null)
            {
                workThread.Abort();
            }
        }
    }
}
