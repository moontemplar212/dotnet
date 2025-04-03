using NUnit.Framework;
using Microsoft.Playwright;
using Microsoft.Extensions.Logging;
using PlaywrightDemo.src.main.common;
using Microsoft.Extensions.Configuration;
using PlaywrightDemo.src.main.framework;
using Microsoft.Playwright.NUnit;

namespace PlaywrightDemo.tests.e2e;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public partial class ShouldBeAbleToVisitPlaywrightDotNet : PlaywrightDotNet
{
    readonly static string name = nameof(ShouldBeAbleToVisitPlaywrightDotNet);
    readonly ILogger logger = Logger.Create(name);
    readonly Asserts asserts;
    readonly Actions actions;

    public ShouldBeAbleToVisitPlaywrightDotNet() {
        this.asserts = Asserts.Setup(Page);
        this.actions = Actions.Setup(Page);
    }

    [SetUp]
    public async Task Setup()
    {
        // https://dusted.codes/dotenv-in-dotnet
        // TODO Some global instantiation

        var root = Directory.GetCurrentDirectory();
        var dotenv = Path.Combine(root, ".env");
        EnvVar.Load(dotenv);

        new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true)
        .AddEnvironmentVariables() // System.Environment // Program // User // Machine
        .Build();

        await Page.Context.Tracing.StartAsync(new()
        {
            Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
            Screenshots = true, // screen cap
            Snapshots = true, // DOM and network
            Sources = true // browser sources
        });

        logger.LogInformation("{}", Environment.GetEnvironmentVariable("LOG_LEVEL"));
    }

    [TearDown]
    public async Task TearDown()
    {
        await Page.Context.Tracing.StopAsync(new()
        {
            Path = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                "playwright-traces",
                $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
            )
        });
    }

    [Test]
    public async Task HasTitle()
    {
        await Page.GotoAsync(url);

        logger.LogInformation("Has title {}", url);

        await asserts.HasTitle(title());
    }

    [Test]
    public async Task GetStartedLink()
    {
        await Page.GotoAsync(url);

        // Click the get started link.
        await actions.DoAction(Actions.Action.CLICK, GetByRole("Get started"));

        await asserts.HasHeading("Installation");
    }
}