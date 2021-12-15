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
        public List<bool> BulkOp(String path)
        {
            List<bool> result = new List<bool>();

            try
            {
                foreach (String line in System.IO.File.ReadLines(path))
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

                    }
                    else if (value[0].Equals("disable"))
                    {

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
