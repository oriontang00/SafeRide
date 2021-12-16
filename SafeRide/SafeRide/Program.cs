using SafeRide.src.Logging;
using SafeRide.src.Interfaces;
using SafeRide.src.DataAccess;
using SafeRide.src.Models;
using SafeRide.src.Managers;
using SafeRide.src.Archiving;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


IUserDAO testDao = new UserSQLServerDAO();
UMManager manager = new UMManager(testDao);

string db_name = "SafeRide_DB";

DatabaseCheck checker = new DatabaseCheck();
if (!checker.CheckDatabaseExists(db_name))
{
    checker.CreateDatabase(db_name);
    checker.CreateTables(db_name);
}

Console.WriteLine("Enter username please");
string? userName = Console.ReadLine();

Console.WriteLine("Enter userId please");
string? userId = Console.ReadLine();

Console.WriteLine("Enter password please");
string? passWord = Console.ReadLine();

bool userAuthorized = false;

if(manager.UserAuthenticate(userName, userId, passWord))
{
    if (manager.UserAuthorize(userId))
    {
        userAuthorized = true;
    }
}

if (userAuthorized)
{
    ILogArchiveService archiver = new LogArchiveService();
    List<LogMessage> logListArchives = archiver.GetArchiveableLogs();
    List<LogMessage> logListLogs = new List<LogMessage>();

    ILogService logService = new DBLogService();
    ILogMessageDAO logDAO = new LogMessageSQLServerDAO();
    
    LogMessage message1 = new LogMessage("this is a test log", Level.Information);
    LogMessage message2 = new LogMessage("this is a test log", Level.Debug);

    Console.WriteLine(logService.Write(message1));
    Console.WriteLine(logService.Write(message2));

    DateTime start = new DateTime(2021, 12, 14, 19, 15, 0);
    DateTime end = new DateTime(2021, 12, 14, 20, 0, 0);


    logListLogs = logDAO.GetAllLogs();

**/
/*IUserDAO testDao = new UserSQLServerDAO();


    foreach (LogMessage log in logListLogs)
    {
            Console.WriteLine(log + "\n");
    }

    Console.WriteLine("Deleting Logs between 7:15 and 8:00 ....\n");

    logDAO.DeleteByTimeRange(start, end);

    logListLogs = logDAO.GetAllLogs();

    foreach (LogMessage log in logListLogs)
    {
            Console.WriteLine(log + "\n");
    }

    User user = new User("Andy", "Ta", "Orange", "mypassword123", "myUserId123", "00112233", "0", "1");
    Console.WriteLine(testDao.Create(user)); // test create

    Console.WriteLine(testDao.Read("myUserId123")); // test read
}



