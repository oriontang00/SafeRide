using SafeRide.src.Interfaces;
using SafeRide.src.DataAccess;
using SafeRide.src.Models;
using SafeRide.src.Managers;
using SafeRide.src.Archiving;
using System.IO.Compression;
using System.Threading;
using SafeRide.src.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using SafeRide.src.Security;
using SafeRide.src.Security.UserSecurity;

using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.IdentityModel.Tokens;

//https://www.codemag.com/Article/2105051/Implementing-JWT-Authentication-in-ASP.NET-Core-5

var SECRET_KEY = "this is my custom Secret key for authnetication"; //needs many characters
var ISSUER = "www.saferide.net";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
                      builder =>
                      {
                          builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

/*builder.Services.AddSpaStaticFiles(options => { options.RootPath = "wwwroot"; });*/


/*var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";*/

// Add services to the container.
builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = ISSUER,
        ValidAudience = ISSUER,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY))
    };
});

/*builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("TokenAuth", policy => policy.Requirements.Add(new )
});*/

builder.Services.AddTransient<IUserSecurityDAO, UserSQLSecurityDAO>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IUserDAO, UserSQLServerDAO>();
builder.Services.AddTransient<IViewEventDAO, ViewEventSQLServerDAO>();
builder.Services.AddTransient<IAnalyticsService, AnalyticsService>();

var env = builder.Environment;
var app = builder.Build();

if (env.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}


/*app.Use(async (context, next) =>
{
    var token = context.Session.GetString("Token");
    if (!string.IsNullOrEmpty(token))
    {
        context.Request.Headers.Add("Authorization", "Bearer " + token);
    }
    await next();
});*/

app.UseHttpsRedirection();
/*app.UseSpaStaticFiles();*/
app.UseRouting();

app.UseCors();

/*app.Use(async (context, next) =>
{
    var token = context.Session.GetString("Token");
    if (!string.IsNullOrEmpty(token))
    {
        context.Request.Headers.Add("Authorization", "Bearer " + token);
    }
    await next();
});*/

app.UseAuthentication(); // auth
app.UseAuthorization(); // auth

app.MapControllers();



// for testing OTP auth
OTPService auth = new OTPService();
// auth.SendEmail();
// Console.WriteLine("OTP Sent");
// Console.WriteLine("Enter OTP:");
// string pass = Console.ReadLine();

// //testing 2min expiration
// Thread.Sleep(12001);
// auth.ValidateOTP(pass);

// testing 2min expiration
//  Thread.Sleep(12001);
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

/*app.UseSpa(builder =>
{
    if (env.IsDevelopment())
    {
        builder.UseProxyToSpaDevelopmentServer("http://localhost:5002");
    }
});*/



app.Run();

/*
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

    //Create new log messages to insert
    //
    Console.WriteLine("Testing adding logs....\n");
    LogMessage message1 = new LogMessage("this is a test log", Level.Information);
    LogMessage message2 = new LogMessage("this is a test log", Level.Debug);

    Console.WriteLine(logService.Write(message1));
    Console.WriteLine(logService.Write(message2));

    logListLogs = logDAO.GetAllLogs();

    Console.WriteLine("Here are all the logs in the database...\n");
    foreach (LogMessage log in logListLogs)
    {
            Console.WriteLine(log + "\n");
    }
    Console.WriteLine("------------------------------------\n");

    Console.WriteLine("Testing archive service...\n");

    List<LogMessage> logList = archiver.GetArchiveableLogs();

    //First, create a file to write the log messages to. This file will be added to a zip later.
    using (StreamWriter writer = File.AppendText(archiver.FilePath))
    {
        foreach (LogMessage message in logList)
        {
            writer.WriteLine(message);
        }
    }

    //Get the path to the zip file we are adding the log message file to.
    string zipPath = System.Configuration.ConfigurationManager.AppSettings["ZipPath"];

    //Append the log message file to the zip file.
    using (ZipArchive zipArchive = ZipFile.Open(zipPath, ZipArchiveMode.Update))
    {
        zipArchive.CreateEntryFromFile(archiver.FilePath, archiver.FilePath);
    }

    //Remove the plain text file, we don't need it anymore.
    if (File.Exists(archiver.FilePath))
        File.Delete(archiver.FilePath);

    //Remove the logs.
    int numLogsRemoved = archiver.RemoveArchivedLogs();

    //If the number of logs removed does not equal the number of logs archived, throw exception.
    if (numLogsRemoved != logList.Count)
        throw new Exception("Logs archived incorrectly");


    Console.WriteLine("Here are the logs that were archived..\n");
    foreach (LogMessage log in logList)
    {
        Console.WriteLine(log + "\n");
    }

    User user = new User("Andy", "Ta", "Orange", "mypassword123", "myUserId123", "00112233", "0", "1");
    Console.WriteLine(testDao.Create(user)); // test create

    Console.WriteLine(testDao.Read("myUserId123")); // test read
}
*/



