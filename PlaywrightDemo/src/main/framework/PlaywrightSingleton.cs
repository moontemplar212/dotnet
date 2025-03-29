using Microsoft.Playwright;

// https://csharpindepth.com/articles/Singleton

sealed class PlaywrightSingleton // sealed -> no inheritence
{
    private static readonly Lazy<PlaywrightSingleton> singleton =
        new(() => new PlaywrightSingleton());
    private PlaywrightSingleton() {}
    public static PlaywrightSingleton Instance { get { return singleton.Value; } }

    public async Task<IPlaywright> Setup()
    {
        return await Playwright.CreateAsync();
    }
}