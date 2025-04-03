using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System.Text.RegularExpressions;

public partial class PlaywrightDotNet : PageTest // : -> extends
{
    public readonly string fullTitle = "Fast and reliable end-to-end testing for modern web apps | Playwright .NET";

    [GeneratedRegex("Playwright")]
    public static partial Regex title();
    public static readonly string url = "https://playwright.dev/dotnet/";

    public IPage Get()
    {
        return Page;
    }

    public ILocator GetByRole(string name)
    {
        return Page.GetByRole(AriaRole.Link, new() { Name = name });
    }
}

