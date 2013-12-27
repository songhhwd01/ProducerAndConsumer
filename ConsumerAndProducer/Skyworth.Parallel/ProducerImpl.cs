using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace Skyworth.Parallel
{
    public class ProducerImpl:Producer
    {
        public ProducerImpl(Basket<int> basket)
            : base(basket)
        {

        }

        private int product = -1;
        public override void DoWork()
        {
            while (isWorking)
            {
                try
                {
                    Debug.WriteLine("&&&&&&&&&&&& " + Thread.CurrentThread.Name + " DoWork ");
                    Random random = new Random();
                    int i = random.Next(5);
                    basket.put(++product);
                    Debug.WriteLine("&&&&&&&&&&&& " + Thread.CurrentThread.Name + " DoWork 生产" + product);
                    Thread.Sleep(i * 1000);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message.ToString());
                    Debug.WriteLine("生产者发生异常");
                }
                finally { }
            }
        }
    }
}
