using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Microsoft.Playwright;

namespace PlaywrightDemo.src.main.framework;

public class Asserts
{
    IPage? Page;

    private Asserts() {}

    public static Asserts Setup(IPage page)
    {
        Asserts asserts = new()
        {
            Page = page
        };
        return asserts;
    }

    public static void AssertIsNotNull([NotNull] object? nullableReference) {
        ArgumentNullException.ThrowIfNull(nullableReference);
    }

    public async Task HasTitle(string title)
    {
        // TODO Fix warning
        await Assertions.Expect(Page).ToHaveTitleAsync(title);
    }

    public async Task HasTitle(Regex title)
    {
        await Assertions.Expect(Page).ToHaveTitleAsync(title);
    }

    public async Task HasURL(string url)
    {
        await Assertions.Expect(Page).ToHaveTitleAsync(url);
    }

    public async Task HasHeading(string text)
    {
        await Assertions.Expect(Page.GetByRole(AriaRole.Heading, new() { Name = text })).ToBeVisibleAsync();
    }

    public async Task IsChecked(ILocator locator)
    {
        await Assertions.Expect(locator).ToBeCheckedAsync();
    }

    public async Task IsEnabled(ILocator locator)
    {
        await Assertions.Expect(locator).ToBeEnabledAsync();
    }

    public async Task IsVisible(ILocator locator)
    {
        await Assertions.Expect(locator).ToBeVisibleAsync();
    }

    public async Task HasText(ILocator locator, string text)
    {
        await Assertions.Expect(locator).ToHaveTextAsync(text);
    }

    public async Task HasAttribute(ILocator locator, string attribute, string? value)
    {
        if (value != null) {
            await Assertions.Expect(locator).ToHaveAttributeAsync(attribute, value);
        } 
        else
        {
            await Assertions.Expect(locator).ToHaveAttributeAsync(attribute, "");
        }
    }

    public async Task HasInputValue(ILocator locator, string text)
    {
        await Assertions.Expect(locator).ToHaveValueAsync(text);
    }

    public enum CssProperty
    {
        BACKGROUND_COLOR,
        HEIGHT,
        WIDTH,
        DISPLAY
    }

    public async Task HasCSS(ILocator locator, CssProperty name, string value)
    {
        await Assertions.Expect(locator).ToHaveCSSAsync(name.ToString().ToLower(), value);
    }
}