using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace Skyworth.Parallel
{
    public abstract class Consumer : Worker
    {
        public Consumer(Basket<int> basket)
        {
            this.basket = basket;
        }

        public void consume()
        {
            Work("消费者");
        }

    }
}
