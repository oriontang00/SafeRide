var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Console.WriteLine("Testing string");

app.MapGet("/", () => "Hello World!");

app.Run();
