﻿using System;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace KafkaService
{
    public class Sender
    {
        private readonly ProducerConfig config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };

        public Sender()
        {
        }

        public ProducerBuilder<Null, string> Client { get; set; }

        public int KafkaOptions { get; set; }

        public async Task SendAlbumNameAsync(string albumName)
        {
            // If serializers are not specified, default serializers from
            // `Confluent.Kafka.Serializers` will be automatically used where available. Note: by
            // default strings are encoded as UTF8.
            using (var p = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    var dr = await p.ProduceAsync("Album", new Message<Null, string> { Value = albumName });
                    Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }
        }

        public async Task SendPhoto(string photoToShow)
        {
            using (var p = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    var dr = await p.ProduceAsync("Album", new Message<Null, string> { Value = photoToShow });
                    Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }
        }
    }
}