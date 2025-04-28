using Microsoft.Playwright;
using PageObjectModelPW.pages;

namespace PageObjectModelPW.Actions;
public static class LoginAction
{
    static readonly IPage page;

    public static async Task EbnerEmployee()
    {
        await page.GetByText(Login.EBNER_employee).ClickAsync();
        
    }
}
