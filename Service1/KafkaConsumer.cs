using Confluent.Kafka;
using KafkaTest.Abstraction.Kafka;
using KafkaTest.Abstraction.Kafka.Base;

namespace KafkaTest.Infra;
public class KafkaConsumer
{
    private readonly string _lock = string.Empty;

    private IConsumer<SendSMSKey, SendSMSValue>? _ConsumerSMS = null;

    private IConsumer<Null, SendSMSValue>? _ConsumerSMSNull = null;
    public IConsumer<SendSMSKey, SendSMSValue> GetSMSConsumer()
    {
        lock (_lock)
        {
            if (_ConsumerSMS is not null)
                return _ConsumerSMS;

            _ConsumerSMS = GetConsumer<SendSMSKey, SendSMSValue>(new SendSMSKey());
            return _ConsumerSMS;
        }
    }
    public IConsumer<Null, SendSMSValue> GetSMSNullConsumer()
    {
        lock (_lock)
        {
            if (_ConsumerSMSNull is not null)
                return _ConsumerSMSNull;

            _ConsumerSMSNull = GetConsumer<Null, SendSMSValue>(null);
            return _ConsumerSMSNull;
        }
    }
    private IConsumer<T, K> GetConsumer<T, K>(T? sampleObject) where K : BaseValue<K>, new()
    {
        var producer = new ConsumerBuilder<T, K>(new ConsumerConfig
        {
            BootstrapServers = "localhost:29092",
            GroupId = "SendSMSGroup",
            AllowAutoCreateTopics = true,
            AutoOffsetReset = AutoOffsetReset.Earliest
        }).SetValueDeserializer(new K());

        if (typeof(T) != typeof(Null) && (IDeserializer<T>?)sampleObject is not null)
        {
            producer.SetKeyDeserializer((IDeserializer<T>)sampleObject);
        }

        return producer.Build();
    }
}
