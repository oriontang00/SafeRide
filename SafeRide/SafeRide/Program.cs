using SafeRide.src.DataAccess;
using SafeRide.src.Interfaces;
using SafeRide.src.Managers;
using SafeRide.src.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

IUserDAO testDao = new UserSQLServerDAO();

User user = new User();
Console.WriteLine(user);

Console.WriteLine($"User firstname = {user.FirstName}");
user.FirstName = "test";

Console.WriteLine(user);

Console.WriteLine("Testing string");

app.MapGet("/", () => "Hello World!");

app.Run();
