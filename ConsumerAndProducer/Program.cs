using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Skyworth.Parallel;

namespace ConsumerAndProducer
{
    class Program
    {
        public static void Main(string[] args)
        {
            Basket<int> basket = new Basket<int>(5);

            Producer producer = new ProducerImpl(basket);
            Consumer consumer = new ConsumerImpl(basket);
            producer.produce();
            consumer.consume();

            Console.ReadLine();
        }
    }
}
