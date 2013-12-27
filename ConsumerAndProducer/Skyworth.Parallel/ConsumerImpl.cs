using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace Skyworth.Parallel
{
    public class ConsumerImpl:Consumer
    {
        public ConsumerImpl(Basket<int> basket)
            : base(basket)
        {

        }

        public override void DoWork()
        {
            while (isWorking)
            {

                Debug.WriteLine("***" + Thread.CurrentThread.Name + " DoWork ");
                int i = basket.poll();
                Debug.WriteLine("***" + Thread.CurrentThread.Name + " DoWork 获取到 " + i);
                i = new Random().Next(5);
                Thread.Sleep(i * 1000);
            }
        }
    }
}
