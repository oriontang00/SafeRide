using SafeRide.src.DataAccess;
using SafeRide.src.Interfaces;
using SafeRide.src.Managers;
using SafeRide.src.Models;
using System.Collections.Generic;
using Xunit;

namespace SRUnitTests
{
    public class UMUnitTest
    {
        [Fact]
        public void UserTest()
        {
            UserModel testUser = new UserModel();

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
            UserModel testUser = new UserModel("TFN", "TLN", "TUN", "TPW", "T_ID_0", "TPhoneNum", "0", "1", new System.DateTime(2022, 3, 7, 0, 0, 0), new System.DateTime(2022, 3, 1, 0, 0, 0));
            var testDAO = new UserSQLServerDAO();

            bool createSuccess = testDAO.Create(testUser);
            Assert.True(createSuccess);

            UserModel testUser2 = testDAO.Read("T_ID_0");
            Assert.Equal("TFN", testUser2.FirstName);
            Assert.Equal("TLN", testUser2.LastName);
            Assert.Equal("TUN", testUser2.UserName);
            Assert.Equal("TPW", testUser2.Password);
            Assert.Equal("T_ID_0", testUser2.UserId);
            Assert.Equal("TPhoneNum", testUser2.PhoneNum);
            Assert.Equal("0", testUser2.IsAdmin);
            Assert.Equal("1", testUser2.Enabled);

            UserModel testUser3 = new UserModel("TFN_NEW", "TLN_NEW", "TUN_NEW", "TPW", "T_ID_0", "TPhoneNum", "0", "0", new System.DateTime(2022, 3, 7, 0, 0, 0), new System.DateTime(2022, 3, 1, 0, 0, 0));
            bool updateSuccess = testDAO.Update("T_ID_0", testUser3);
            Assert.True(updateSuccess);

            UserModel testUser4 = testDAO.Read("T_ID_0"); // test only 3 new fields
            Assert.Equal("TFN_NEW", testUser4.FirstName);
            Assert.Equal("TLN_NEW", testUser4.LastName);
            Assert.Equal("0", testUser4.Enabled);

            bool enableSuccess = testDAO.Enable("T_ID_0");
            Assert.True(enableSuccess);

            UserModel testUser5 = testDAO.Read("T_ID_0");
            Assert.Equal("1", testUser5.Enabled);

            bool disableSuccess = testDAO.Disable("T_ID_0");
            Assert.True(disableSuccess);

            UserModel testUser6 = testDAO.Read("T_ID_0");
            Assert.Equal("0", testUser6.Enabled);

            bool deleteSuccess = testDAO.Delete("T_ID_0");
            Assert.True(deleteSuccess);
        }

        [Fact]
        public void TestFile()
        {
            string filepath = @"..\..\..\..\SafeRide\src\test.csv";
            var testDAO = new UserSQLServerDAO();
            var testManager = new UMManager(testDAO);

            List<bool> results = testManager.BulkOps(filepath, true);

            UserModel testUser1 = testDAO.Read("1234"); // hard coded id
            Assert.Equal("andy", testUser1.FirstName);
            Assert.Equal("lee", testUser1.LastName);
            Assert.Equal("dog", testUser1.UserName);
            Assert.Equal("catpw", testUser1.Password);
            Assert.Equal("1234", testUser1.UserId);
            Assert.Equal("51231234", testUser1.PhoneNum);
            Assert.Equal("0", testUser1.IsAdmin);
            Assert.Equal("1", testUser1.Enabled);

            Assert.True(testDAO.Delete("1234"));

        }

        [Fact]
        public void TestString()
        {
            string testString = "create,andy,lee,dog,12345,51231234,catpw,0,1\n";
            var testDAO = new UserSQLServerDAO();
            var testManager = new UMManager(testDAO);

            List<bool> results = testManager.BulkOps(testString, false);

            UserModel testUser1 = testDAO.Read("12345"); // hard coded id
            Assert.Equal("andy", testUser1.FirstName);
            Assert.Equal("lee", testUser1.LastName);
            Assert.Equal("dog", testUser1.UserName);
            Assert.Equal("catpw", testUser1.Password);
            Assert.Equal("12345", testUser1.UserId);
            Assert.Equal("51231234", testUser1.PhoneNum);
            Assert.Equal("0", testUser1.IsAdmin);
            Assert.Equal("1", testUser1.Enabled);

            Assert.True(testDAO.Delete("12345"));
        }
    }
}