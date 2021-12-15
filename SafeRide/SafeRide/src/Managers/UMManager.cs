using SafeRide.src.Interfaces;
using SafeRide.src.Models;

namespace SafeRide.src.Managers
{
    public class UMManager
    {
        private IUserDAO userDao;

        public UMManager(IUserDAO userDao)
        {
            this.userDao = userDao;
        }
        private bool CheckBulkOp(string bulkOps)
        {
            long numLines = bulkOps.Split("\n").Length;

            if (numLines > 10000) return false;

            return true;
        }
        private static bool CheckFile(string filePath)
        {
            long fileSize = 0;
            long lineCount = 0;

            try
            {
                lineCount = File.ReadLines(filePath).Count();
                fileSize = new FileInfo(filePath).Length;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (fileSize == 0 || lineCount == 0 || fileSize > 2e+9 || lineCount > 10000) return false;

            return true;
        }
        public List<bool> BulkOps(String pathOrStr, bool isFile)
        {
            List<bool> result = new List<bool>();
            IEnumerable<string> readLines;

            if (isFile)
            {
                if (!CheckFile(pathOrStr)) return result;
                readLines = File.ReadLines(pathOrStr);
            }
            else
            {
                if (!CheckBulkOp(pathOrStr)) return result;
                readLines = pathOrStr.Split("\n");
            }

            try
            {
                foreach (String line in readLines)
                {
                    var value = line.Split(",");

                    if (value[0].Equals("create"))
                    {
                        User user = new User();
                        user.FirstName = value[1];
                        user.LastName = value[2];
                        user.UserName = value[3];
                        user.UserId = value[4];
                        user.PhoneNum = value[5];
                        user.Password = value[6];

                        result.Append(userDao.Create(user));

                    }
                    else if (value[0].Equals("update"))
                    {

                    }
                    else if (value[0].Equals("delete"))
                    {

                    }
                    else if (value[0].Equals("enable"))
                    {
                        string userId = value[1];
                        result.Append(userDao.Enable(userId));

                    }
                    else if (value[0].Equals("disable"))
                    {
                        string userId = value[1];
                        result.Append(userDao.Enable(userId));
                    }

                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File is not found.");
            }

            return result;
        }
    }
}
