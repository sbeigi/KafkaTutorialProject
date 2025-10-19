using KafkaTest.Infra;
using Microsoft.Extensions.Hosting;

namespace Service1;
public class MessagePrinter(KafkaConsumer consumer) : BackgroundService
{
    private readonly string _topic = "SendSMS";
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var con = consumer.GetSMSConsumer();
        while (!stoppingToken.IsCancellationRequested)
        {
            con.Subscribe(_topic);
            var message = con.Consume(stoppingToken);

            Console.WriteLine($"Service1   --->   {message.Message.Value.MobileNumber}");
        }
    }
}
