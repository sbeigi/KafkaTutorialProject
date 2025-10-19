using Confluent.Kafka;
using System.Text.Json;

namespace KafkaTest.Abstraction.Kafka.Base;
public abstract class BaseValue<T> : ISerializer<T>, IDeserializer<T>
{
    public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
    {
        if (isNull)
            return default;

        return JsonSerializer.Deserialize<T>(data) ?? throw new ApplicationException("SendSMSValue Deserialization Exception");
    }
    public byte[] Serialize(T data, SerializationContext context)
    {
        return JsonSerializer.SerializeToUtf8Bytes(data);
    }
}
