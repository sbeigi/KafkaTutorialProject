using Confluent.Kafka;
using KafkaTest.Abstraction.Kafka;
using KafkaTest.Infra;
using Microsoft.AspNetCore.Mvc;

namespace KafkaTest.Endpoints;
public static class EndpointManager
{
    public static void AddEndpoints(this WebApplication app)
    {
        string topic = "SendSMS";

        /*
         * When uses key , messages with the same key will persist in the same partition , it uses for ordered processing 
         */
        app.MapPost("ProduceKeyMessage", async ([FromServices] KafkaProducer KafkaProducer, [FromQuery] int key) =>
        {
            try
            {
                var prd = KafkaProducer.GetSMSProducer();
                var pr = await prd.ProduceAsync(topic, new Message<SendSMSKey, SendSMSValue>
                {
                    Key = new SendSMSKey
                    {
                        Id = key,
                    },
                    Value = new SendSMSValue
                    {
                        MobileNumber = "09183195156"
                    }
                });

                return Results.Ok($"{pr.Status} --> {pr.Message}");
            }
            catch(Exception ex)
            {
                return Results.InternalServerError(ex);
            }
        }).WithOpenApi();

        /*
         * When using Null Key the messages will persists on deffrent partitions, it will be round rubin 
         * */
        app.MapPost("ProduceNoKeyMessage", async ([FromServices] KafkaProducer KafkaProducer) =>
        {
            try
            {
                var prd = KafkaProducer.GetSMSNullProducer();
                var pr = await prd.ProduceAsync(topic, new Message<Null, SendSMSValue>
                {
                    Value = new SendSMSValue
                    {
                        MobileNumber = "09183195156"
                    }
                });

                return Results.Ok($"{pr.Status} --> {pr.Message}");
            }
            catch (Exception ex)
            {
                return Results.InternalServerError(ex);
            }
        }).WithOpenApi();
    }
}
