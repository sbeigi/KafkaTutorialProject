using KafkaTest.Infra;

namespace KafkaTest.BackgroundServices;
public class SendSMSConsumer(KafkaConsumer _consumer) : BackgroundService
{
    private readonly string _topic = "SendSMS";
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _ = Task.Run(() =>
        {
            var consumer = _consumer.GetSMSConsumer();

            while (true)
            {
                consumer.Subscribe(_topic);
                var message = consumer.Consume();
                Console.WriteLine($"Consumer 1 --> {message.Message.Value.MobileNumber}");
            }
        }, stoppingToken);

        _ = Task.Run(() =>
        {
            var consumer = _consumer.GetSMSConsumer();

            while (true)
            {
                consumer.Subscribe(_topic);
                var message = consumer.Consume();
                Console.WriteLine($"Consumer 2 --> {message.Message.Value.MobileNumber}");
            }
        }, stoppingToken);
    }
}
