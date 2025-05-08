using Microsoft.Playwright;
using PageObjectModelPW.pages;

namespace PageObjectModelPW.Actions;

public class LoginAction(IPage _page)
{
    public readonly IPage Page = _page;

    public async Task EbnerEmployeeLogin()
    {
        if (await Page.GetByText(Login.Login_as_an_EBNER_employee).IsVisibleAsync())
            await Page.GetByText(Login.Login_as_an_EBNER_employee).ClickAsync();

        await Page.GetByText(Login.EBNER_employee).ClickAsync();
        await Task.CompletedTask;
    }
}
