using SafeRide.src.DataAccess;
using SafeRide.src.Interfaces;
using SafeRide.src.Managers;
using SafeRide.src.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

IUserDAO testDao = new UserSQLServerDAO();

//User user = new User("Leon", "Chen", "Apple", "wowapassword?Crazy", "wowTestUsdId", "0001112222");
//Console.WriteLine(testDao.Create(user));


String fileName = @"D:\School Stuff\GitHub\SafeRide\SafeRide\SafeRide\src\test.csv";
Console.WriteLine(testDao.BulkOp(fileName));
//Console.WriteLine(testDao.Read("wowTestUsdId"));

Console.WriteLine("Testing string");

app.MapGet("/", () => "Hello World!");

app.Run();
