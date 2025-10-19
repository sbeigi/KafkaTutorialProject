using Confluent.Kafka;
using KafkaTest.Abstraction.Kafka;
using KafkaTest.Abstraction.Kafka.Base;

namespace KafkaTest.Infra;
public class KafkaProducer
{
    private readonly string _lock = string.Empty;

    private IProducer<SendSMSKey, SendSMSValue>? _ProducerSMS = null;

    private IProducer<Null, SendSMSValue>? _ProducerSMSNull = null;
    public IProducer<SendSMSKey, SendSMSValue> GetSMSProducer()
    {
        lock (_lock)
        {
            if (_ProducerSMS is not null)
                return _ProducerSMS;

            _ProducerSMS = GetProducer<SendSMSKey, SendSMSValue>(new SendSMSKey());
            return _ProducerSMS;
        }
    }
    public IProducer<Null, SendSMSValue> GetSMSNullProducer()
    {
        lock (_lock)
        {
            if (_ProducerSMSNull is not null)
                return _ProducerSMSNull;

            _ProducerSMSNull = GetProducer<Null, SendSMSValue>(null);
            return _ProducerSMSNull;
        }
    }
    private IProducer<T, K> GetProducer<T, K>(T? sampleObject) where K : BaseValue<K>, new()
    {
        var producer = new ProducerBuilder<T, K>(new ProducerConfig
        {
            BootstrapServers = "localhost:29092",
            ClientId = "P1",
            AllowAutoCreateTopics = true,
            EnableIdempotence = true,
            Partitioner = Partitioner.Consistent,
            Acks = Acks.All,
            CompressionType = CompressionType.Snappy
        }).SetValueSerializer(new K());

        if (typeof(T) != typeof(Null) && (ISerializer<T>?)sampleObject is not null)
        {
            producer.SetKeySerializer((ISerializer<T>)sampleObject);
        }

        return producer.Build();
    }
}
