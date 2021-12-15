using Xunit;
using SafeRide.src.Models;
using SafeRide.src.Logging;
using SafeRide.src.Interfaces;
using SafeRide.src.DataAccess;

namespace SRUnitTests
{
    public class LoggingTest
    {
        [Fact]
        public void CreateShould()
        {
           //   Arrange
            var logDAO = new LogMessageSQLServerDAO();
            LogMessage message = new LogMessage("this is a test message", Level.Information);
            int expected = 1;

            //  Act
            int actual = logDAO.Create(message);

            //  Assert
            Assert.Equal(expected, actual);

        }
    }
}