using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Skyworth.Parallel
{
    public class Basket<T>
    {
        private int capacity;

        Queue<T> queue = new Queue<T>();

        private object locker = new object();

        public Basket(int max)
        {
            this.capacity = max;
        }

        public void put(T obj)
        {
            try
            {

                Monitor.Enter(locker);
                int count = queue.Count;
                if (count >= capacity)
                {
                    Monitor.Wait(locker);
                    queue.Enqueue(obj);

                }
                else
                {
                    queue.Enqueue(obj);
                }
                Monitor.Pulse(locker);
            }catch(Exception e)
            {

            }finally{
             Monitor.Exit(locker);
            }
        }

        public T poll()
        {
            Monitor.Enter(locker);
            T obj = default(T);
            int count = queue.Count;
            if (count <= 0)
            {
                Monitor.Wait(locker);
                obj = queue.Dequeue();
                Monitor.Pulse(locker);
            }
            else
            {
                obj = queue.Dequeue();
            }
            Monitor.Pulse(locker);
            Monitor.Exit(locker);
            return obj;
        }

    }
}
