using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace PlaywrightDemo.tests.unit
{
    [TestFixture]
    public class ShouldBeAbleToUseLogger
    {
        private readonly static string className = nameof(ShouldBeAbleToUseLogger);
        private readonly static ILogger logger = Logger.Create(className);

        [Test]
        public void Test()
        {
            logger.LogInformation("Hello world");
        }
    }
}