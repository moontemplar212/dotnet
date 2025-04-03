using NUnit.Framework;
using Microsoft.Extensions.Logging;
using PlaywrightDemo.src.main.framework;

namespace PlaywrightDemo.tests.integration;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ShouldBeAbleToInstantiatePlaywright
{
    readonly static string name = nameof(ShouldBeAbleToInstantiatePlaywright);
    readonly ILogger logger = Logger.Create(name);

    [Test]
    public void InstantiatePlaywright()
    {
        PlaywrightDotNet playwrightDotNet = new();
        logger.LogInformation("Can instantiate playwright");
        Asserts.AssertIsNotNull(playwrightDotNet);
    }
}