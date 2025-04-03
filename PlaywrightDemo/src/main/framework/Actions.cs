using Microsoft.Playwright;

namespace PlaywrightDemo.src.main.framework;

public class Actions
{
        /**Action	Description
    Locator.CheckAsync()	Check the input checkbox
    Locator.ClickAsync()	Click the element
    Locator.UncheckAsync()	Uncheck the input checkbox
    Locator.HoverAsync()	Hover mouse over the element
    Locator.FillAsync()	Fill the form field, input text
    Locator.FocusAsync()	Focus the element
    Locator.PressAsync()	Press single key
    Locator.SetInputFilesAsync()	Pick files to upload
    Locator.SelectOptionAsync()	Select option in the drop down
        */
    IPage? Page;

    private Actions() {}

    public static Actions Setup(IPage page) {
        Actions actions = new()
        {
            Page = page
        };
        return actions;
    }

    public enum Action : uint
    {
        CHECK,
        CLICK,
        UNCHECK,
        HOVER,
        FILL,
        FOCUS,
        KEY_PRESS,
        SET_FILES,
        SELECT_OPTION,
        SCREEN_SHOT
    } 

    public async Task DoAction(Action action, ILocator locator)
    {
        switch (action)
        {
            case Action.CHECK:
                await locator.CheckAsync();
                break;
            case Action.CLICK:
                await locator.ClickAsync();
                break;
            case Action.FOCUS:
                await locator.FocusAsync();
                break;
            case Action.HOVER:
                await locator.HoverAsync();
                break;
            case Action.UNCHECK:
                await locator.UncheckAsync();
                break;
        }
    }

    public static async Task DoAction(Action action, ILocator locator, string value)
    {
        switch (action)
        {
            case Action.FILL:
                await locator.FillAsync(value);
                break;
            case Action.KEY_PRESS:
                await locator.PressAsync(value);
                break;
            case Action.SET_FILES:
                // TODO if ILocator typeof IHTMLElement is IInputElement
                await locator.SetInputFilesAsync(value);
                break;
            case Action.SELECT_OPTION:
                await locator.SelectOptionAsync(value);
                break;
        }
    }

    public static async Task SetFiles(ILocator locator, string directoryOrFilename)
    {
        await locator.SetInputFilesAsync(directoryOrFilename);
    }

    public static async Task SetFiles(ILocator locator, string[] files)
    {
        await locator.SetInputFilesAsync(files);
    }

    public static async Task RemoveFiles(ILocator locator)
    {
        await locator.SetInputFilesAsync(Array.Empty<string>());
    }

    public static async Task UploadBuffer(ILocator locator, string name, string mimeType, byte[] bytes)
    {
        await locator.SetInputFilesAsync(
            new FilePayload
            {
                Name = name,
                MimeType = mimeType,
                Buffer = bytes,
            });
    }

    public static async Task Check(ILocator locator)
    {
        await locator.CheckAsync();
    }

    public async Task Check()
    {
        // TODO Fix warning
        await Page.GetByRole(AriaRole.Checkbox).CheckAsync();
    }

    public async Task Check(string label)
    {
        // TODO Fix warning
        await Page.GetByLabel(label).CheckAsync();
    }
}