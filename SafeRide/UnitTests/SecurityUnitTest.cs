
using System.Collections.Generic;
using SafeRide.src.DataAccess;
using SafeRide.src.Managers;
using SafeRide.src.Models;
using Xunit;

namespace SRUnitTests
{
    public class SecurityUnitTest
    {
        [Fact]
        public void AuthenticateTestPass()
        {
            string testString = "create,TFN,TLN,TUN,TUID0,UPHONE,UPW0,1,1\n";
            var testDAO = new UserSQLServerDAO();
            var testmanager = new UMManager(testDAO);
            testmanager.BulkOps(testString, false);
            UserModel testAdmin = testDAO.Read("TUID0"); // hard coded id

            Assert.True(testmanager.UserAuthenticate("TUN", "TUID0", "UPW0"));

            Assert.True(testDAO.Delete("TUID0"));
        }
        [Fact]
        public void AuthenticateTestFail()
        {
            string testString = "create,TFN,TLN,TUN,TUID2,UPHONE,UPW2,1,1\n";
            var testDAO = new UserSQLServerDAO();
            var testmanager = new UMManager(testDAO);
            testmanager.BulkOps(testString, false);
            UserModel testAdmin = testDAO.Read("TUID2"); // hard coded id      
            string testID = testAdmin.UserId;
            Assert.False(testmanager.UserAuthenticate("NotSAME", testID, "WRONGPW"));

            Assert.True(testDAO.Delete("TUID2"));
        }

        [Fact]
        public void AuthorizeTestPass() 
        {
            string testString = "create,TFN,TLN,TUN,TUID3,UPHONE,UPW,1,1\n";
            var testDAO = new UserSQLServerDAO();
            var testmanager = new UMManager(testDAO);
            testmanager.BulkOps(testString, false);
            UserModel testAdmin = testDAO.Read("TUID3"); // hard coded id
            
            string testID = testAdmin.UserId;
            Assert.True(testmanager.UserAuthorize(testID));

            Assert.True(testDAO.Delete("TUID3"));
        }
        [Fact]
        public void AuthorizeTestFail()
        {
            string testString = "create,TFN,TLN,TUN,TUID4,UPHONE,UPW,0,1\n";
            var testDAO = new UserSQLServerDAO();
            var testmanager = new UMManager(testDAO);
            testmanager.BulkOps(testString, false);
            UserModel testAdmin = testDAO.Read("TUID4"); // hard coded id

            string testID = testAdmin.UserId;
            Assert.False(testmanager.UserAuthorize(testID));

            Assert.True(testDAO.Delete("TUID4"));
        }

    }
}