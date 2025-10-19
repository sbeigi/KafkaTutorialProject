using Confluent.Kafka;
using KafkaTest.Abstraction.Kafka.Base;
using System.Text;
using System.Text.Json;

namespace KafkaTest.Abstraction.Kafka
{
    public class SendSMSValue : BaseValue<SendSMSValue> 
    {
        //public bool IsDelivered { get; set; }
        public string MobileNumber { get; set; }

        
    }
}
