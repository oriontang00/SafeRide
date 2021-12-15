using SafeRide.src.Logging;
using SafeRide.src.Interfaces;
using SafeRide.src.DataAccess;
using SafeRide.src.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

DatabaseCheck checker = new DatabaseCheck();
if (!checker.CheckDatabaseExists("SafeRide_DB"))
{
    checker.CreateDatabase("SafeRide_DB");
}
/*
ILogService logService = new DBLogService();
ILogMessageDAO logDAO = new LogMessageSQLServerDAO();

LogMessage message1 = new LogMessage("this is a test log", Level.Information);
LogMessage message2 = new LogMessage("this is a test log", Level.Debug);

Console.WriteLine(logService.Write(message1));
Console.WriteLine(logService.Write(message2));

List<LogMessage> logList = new List<LogMessage>();

DateTime start = new DateTime(2021, 12, 14, 19, 15, 0);
DateTime end = new DateTime(2021, 12, 14, 20, 0, 0);

logList = logDAO.GetAllLogs();

foreach (LogMessage log in logList)
{
    Console.WriteLine(log + "\n");
}

Console.WriteLine("Deleting Logs between 7:15 and 8:00 ....\n");

logDAO.DeleteByTimeRange(start, end);

logList = logDAO.GetAllLogs();

foreach (LogMessage log in logList)
{
    Console.WriteLine(log + "\n");
}

IUserDAO testDao = new UserSQLServerDAO();

//User user = new User("Leon", "Chen", "Apple", "wowapassword?Crazy", "wowTestUsdId", "0001112222");
//Console.WriteLine(testDao.Create(user));

User user = new User("Andy", "Ta", "Orange", "wowapassword", "wowTestUsdId", "00112233", "0", "1");
Console.WriteLine(testDao.Create(user));

Console.WriteLine(testDao.Read("wowTestUsdId"));

//String fileName = @"D:\School Stuff\GitHub\SafeRide\SafeRide\SafeRide\src\test.csv";
//Console.WriteLine(testDao.BulkOp(fileName));
//Console.WriteLine(testDao.Read("wowTestUsdId"));

Console.WriteLine("Testing string");*/



