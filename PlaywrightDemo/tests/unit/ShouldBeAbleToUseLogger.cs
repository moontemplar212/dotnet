using Microsoft.Extensions.Logging;

namespace PlaywrightDemo.tests.unit
{
    [TestFixture]
    public class ShouldBeAbleToUseLogger
    {
        private readonly static string className = nameof(ShouldBeAbleToUseLogger);
        private readonly static ILogger logger = Logger.Create(className);
            
        [SetUp]
        public void Setup()
        {
            // TODO
        }

        [Test]
        public void Test()
        {
            logger.LogInformation("Hello world");
        }
    }
}