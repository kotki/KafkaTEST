using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace KafkaTEST
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(3000);
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

            using (var p = new ProducerBuilder<Null, string>(config).Build())
            {
                for (var i = 0; i < 100000; ++i)
                {
                    var dr = p.ProduceAsync("test-topic", new Message<Null, string> { Value = i.ToString() }).Result;
                    Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
                }
                //while (true)
                //{
                //    Console.WriteLine("Publish something:");
                //    var message = Console.ReadLine();
                //    try
                //    {
                //        var dr = p.ProduceAsync("test-topic", new Message<Null, string> { Value = message }).Result;
                //        Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
                //    }
                //    catch (ProduceException<Null, string> e)
                //    {
                //        Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                //    }
                //    Console.WriteLine();
                //    Console.WriteLine();
                //    Console.WriteLine("Press any key to continue");
                //    Console.ReadKey();
                //    Console.Clear();
                //}
            }
        }
    }
}
