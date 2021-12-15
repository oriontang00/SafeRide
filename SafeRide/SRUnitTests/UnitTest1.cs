using SafeRide.src.DataAccess;
using SafeRide.src.Interfaces;
using SafeRide.src.Managers;
using SafeRide.src.Models;
using System.Collections.Generic;
using Xunit;

namespace SRUnitTests
{
    public class SecurityUnitTest
    {
        [Fact]
        public void AuthenticateTestPass()
        {
            string testString = "create,TFN,TLN,TUN,TUID,UPHONE,UPW,1,1\n";
            var testDAO = new UserSQLServerDAO();
            var testmanager = new UMManager(testDAO);
            testmanager.BulkOps(testString, false);
            User testAdmin = testDAO.Read("TUID"); // hard coded id
            string testPW = testAdmin.Password;
            string testUN = testAdmin.UserName;
            string testID = testAdmin.UserId;
            Assert.True(testmanager.UserAuthenticate(testUN, testID, testPW));

            Assert.True(testDAO.Delete("TUID"));
        }

        public void AuthenticateTestFail()
        {
            string testString = "create,TFN,TLN,TUN,TUID,UPHONE,UPW,0,1\n";
            var testDAO = new UserSQLServerDAO();
            var testmanager = new UMManager(testDAO);
            testmanager.BulkOps(testString, false);
            User testAdmin = testDAO.Read("TUID"); // hard coded id
            string testPW = testAdmin.Password;
            string testUN = testAdmin.UserName;
            string testID = testAdmin.UserId;
            Assert.False(testmanager.UserAuthenticate(testUN, testID, testPW));

            Assert.True(testDAO.Delete("TUID"));
        }

        [Fact]
        public void AuthorizeTestPass() 
        {
            string testString = "create,TFN,TLN,TUN,TUID,UPHONE,UPW,1,1\n";
            var testDAO = new UserSQLServerDAO();
            var testmanager = new UMManager(testDAO);
            testmanager.BulkOps(testString, false);
            User testAdmin = testDAO.Read("TUID"); // hard coded id
            
            string testID = testAdmin.UserId;
            Assert.True(testmanager.UserAuthorize(testID));

            Assert.True(testDAO.Delete("TUID"));
        }
        [Fact]
        public void AuthorizeTestFail()
        {
            string testString = "create,TFN,TLN,TUN,TUID,UPHONE,UPW,0,1\n";
            var testDAO = new UserSQLServerDAO();
            var testmanager = new UMManager(testDAO);
            testmanager.BulkOps(testString, false);
            User testAdmin = testDAO.Read("TUID"); // hard coded id

            string testID = testAdmin.UserId;
            Assert.False(testmanager.UserAuthorize(testID));

            Assert.True(testDAO.Delete("TUID"));
        }

    }
}