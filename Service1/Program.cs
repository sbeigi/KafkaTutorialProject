using KafkaTest.Infra;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service1;

Console.WriteLine("Service1 is running...");

var builder = Host.CreateApplicationBuilder();

builder.Services.AddSingleton<KafkaConsumer>();

builder.Services.AddHostedService<MessagePrinter>();

var app = builder.Build();

await KafkaInitializer.Init();

app.Run();