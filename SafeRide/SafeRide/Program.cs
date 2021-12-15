using SafeRide.src.Logging;
using SafeRide.src.Interfaces;
using SafeRide.src.DataAccess;
using SafeRide.src.Models;

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



