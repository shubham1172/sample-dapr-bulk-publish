using System.Text.Json.Serialization;
using Dapr;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Dapr will send serialized event object vs. being raw CloudEvent
app.UseCloudEvents();

// needed for Dapr pub/sub routing
app.MapSubscribeHandler();

// Dapr subscription in [Topic] routes orders topic to this route
app.MapPost("/orders", [Topic("pubsub", "topic")] (Entry entry) =>
{
    Console.WriteLine("Subscriber received : " + entry);
    return Results.Ok(entry);
});

await app.RunAsync("http://localhost:5001");

public record Entry(
    [property: JsonPropertyName("name")] string name,
    [property: JsonPropertyName("age")] int age,
    [property: JsonPropertyName("event")] string event_);