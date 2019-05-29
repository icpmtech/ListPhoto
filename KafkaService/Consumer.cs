using System;
using System.Threading;
using Confluent.Kafka;

namespace KafkaService
{
    public static class Receiver
    {
        public static string GetAlbumName()
        {
            var conf = new ConsumerConfig
            {
                GroupId = "album-consumer-group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = true,
            };
            var c = new ConsumerBuilder<Ignore, string>(conf).Build();

            c.Subscribe("Album");

            CancellationTokenSource cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true; // prevent the process from terminating.
                cts.Cancel();
            };

            try
            {
                try

                {
                    var cr = c.Consume(cts.Token);

                    Console.WriteLine($"Consumed message '{cr.Value}' at: '{cr.TopicPartitionOffset}'.");
                    return cr.Value;
                }
                catch (ConsumeException e)
                {
                    Console.WriteLine($"Error occured: {e.Error.Reason}");
                }
            }
            catch (OperationCanceledException)
            {
                // Ensure the consumer leaves the group cleanly and final offsets are committed.
                c.Close();
            }

            return string.Empty;
        }

        public static string GetPhoto(string photoToShow)
        {
            var conf = new ConsumerConfig
            {
                GroupId = "album-consumer-group",
                BootstrapServers = "localhost:9092",

                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            using (var c = new ConsumerBuilder<Ignore, string>(conf).Build())
            {
                c.Subscribe("Album");

                CancellationTokenSource cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true; // prevent the process from terminating.
                    cts.Cancel();
                };

                try
                {
                    try
                    {
                        var cr = c.Consume(cts.Token);
                        Console.WriteLine($"Consumed message '{cr.Value}' at: '{cr.TopicPartitionOffset}'.");
                        return cr.Value;
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Error occured: {e.Error.Reason}");
                    }
                }
                catch (OperationCanceledException)
                {
                    // Ensure the consumer leaves the group cleanly and final offsets are committed.
                    c.Close();
                }
            }
            return string.Empty;
        }
    }
}