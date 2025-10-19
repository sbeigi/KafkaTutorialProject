using Confluent.Kafka;
using Confluent.Kafka.Admin;

namespace KafkaTest.Infra;
public class KafkaInitializer
{
    public static async Task Init()
    {

        // Kafka configuration
        var config = new AdminClientConfig { BootstrapServers = "localhost:29092" };
        var topicName = "SendSMS";

        // Create topic if it doesn't exist
        using (var adminClient = new AdminClientBuilder(config).Build())
        {
            try
            {
                var topicSpec = new TopicSpecification
                {
                    Name = topicName,
                    NumPartitions = 3,
                    ReplicationFactor = 1
                };

                await adminClient.CreateTopicsAsync(new List<TopicSpecification> { topicSpec });
                Console.WriteLine($"Topic '{topicName}' created successfully.");
            }
            catch (CreateTopicsException e)
            {
                // Topic already exists
                if (e.Results[0].Error.Code != ErrorCode.TopicAlreadyExists)
                    throw;
                Console.WriteLine($"Topic '{topicName}' already exists.");
            }
        }
    }
}
