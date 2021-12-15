using SafeRide.src.Interfaces;
using SafeRide.src.Archiving;
using SafeRide.src.Models;
using System.IO.Compression;

/// <summary>
/// This file provides the code which will be run to archive log messages by compressing any log messages older than 30 days
/// into a zip files, and deleting said logs from the database.
/// </summary>

ILogArchiveService archiver = new LogArchiveService();

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

foreach (LogMessage log in logList)
{
    Console.WriteLine(log + "\n");
}
