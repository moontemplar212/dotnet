using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

SetDefaultExpectTimeout(10_000);

var playwright = await PlaywrightSingleton.Instance.Setup();
// using var playwright = await Playwright.CreateAsync();
// await using var browser = await playwright.Chromium.LaunchAsync();
await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = false, SlowMo = 50 });
var page = await browser.NewPageAsync();
await page.GotoAsync("https://playwright.dev/dotnet");
await page.ScreenshotAsync(new() { Path = "screenshot.png"});
await Expect(page.GetByRole(AriaRole.Link, new() { Name = "Get Started" })).ToBeVisibleAsync();
