using Confluent.Kafka;
using System.Text.Json;

namespace KafkaTest.Abstraction.Kafka;

public abstract class BaseKey<T> : ISerializer<T>, IDeserializer<T> 
{
    public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
    {
        return JsonSerializer.Deserialize<T>(data) ?? throw new ApplicationException("SendSMSKey Deserialization Exception");
    }
    public byte[] Serialize(T data, SerializationContext context)
    {
        return JsonSerializer.SerializeToUtf8Bytes(data);
    }
}
