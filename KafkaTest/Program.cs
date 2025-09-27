using Confluent.Kafka;
using KafkaTest.Abstraction.Kafka;
using KafkaTest.BackgroundServices;
using KafkaTest.Endpoints;
using KafkaTest.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHostedService<SendSMSConsumer>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<KafkaProducer>();
builder.Services.AddSingleton<KafkaConsumer>();

await KafkaInitializer.Init();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.MapOpenApi();
//}

app.UseHttpsRedirection();

app.AddEndpoints();

app.UseSwagger();

app.UseSwaggerUI();

app.Run();

