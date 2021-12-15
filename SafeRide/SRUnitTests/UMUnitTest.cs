using SafeRide.src.DataAccess;
using SafeRide.src.Interfaces;
using SafeRide.src.Models;
using Xunit;

namespace SRUnitTests
{
    public class UMUnitTest
    {
        [Fact]
        public void UserTest()
        {
            User testUser = new User();

            Assert.NotNull(testUser);
            Assert.NotNull(testUser.FirstName);
            Assert.NotNull(testUser.LastName);
            Assert.NotNull(testUser.UserName);
            Assert.NotNull(testUser.Password);
            Assert.NotNull(testUser.UserId);
            Assert.NotNull(testUser.IsAdmin);
            Assert.NotNull(testUser.Enabled);
        }
        [Fact]
        public void UserTest1()
        {
            User testUser = new User("TFN", "TLN", "TUN", "TPW", "T_ID_0", "TPhoneNum", "0", "1");
            var testDAO = new UserSQLServerDAO();

            bool createSuccess = testDAO.Create(testUser);
            Assert.True(createSuccess);

            User testUser2 = testDAO.Read("T_ID_0");
            Assert.Equal("TFN", testUser2.FirstName);
            Assert.Equal("TLN", testUser2.LastName);
            Assert.Equal("TUN", testUser2.UserName);
            Assert.Equal("TPW", testUser2.Password);
            Assert.Equal("T_ID_0", testUser2.UserId);
            Assert.Equal("TPhoneNum", testUser2.PhoneNum);
            Assert.Equal("False", testUser2.IsAdmin);
            Assert.Equal("True", testUser2.Enabled);

            User testUser3 = new User("TFN_NEW", "TLN_NEW", "TUN_NEW", "TPW", "T_ID_0", "TPhoneNum", "0", "0");
            bool updateSuccess = testDAO.Update("T_ID_0", testUser3);
            Assert.True(updateSuccess);

            User testUser4 = testDAO.Read("T_ID_0"); // test only 3 new fields
            Assert.Equal("TFN_NEW", testUser4.FirstName);
            Assert.Equal("TLN_NEW", testUser4.LastName);
            Assert.Equal("False", testUser4.Enabled);

            bool enableSuccess = testDAO.Enable("T_ID_0");
            Assert.True(enableSuccess);

            User testUser5 = testDAO.Read("T_ID_0");
            Assert.Equal("True", testUser5.Enabled);

            bool disableSuccess = testDAO.Disable("T_ID_0");
            Assert.True(disableSuccess);

            User testUser6 = testDAO.Read("T_ID_0");
            Assert.Equal("False", testUser6.Enabled);

            bool deleteSuccess = testDAO.Delete("T_ID_0");
            Assert.True(deleteSuccess);
        }
    }
}