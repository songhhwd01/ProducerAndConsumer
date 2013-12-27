using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Skyworth.Parallel
{
    public abstract class Producer:Worker
    {
        public Producer(Basket<int> basket)
        {
            this.basket = basket;
        }

        public void produce()
        {
            Work("生产者");
        }
    }
}
