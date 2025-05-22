using System.Reflection.Emit;
using Microsoft.Playwright;
using PageObjectModelPW.pages;

namespace PageObjectModelPW.Actions;

public class DashboardAction(IPage _page)
{
    public readonly IPage Page = _page;

    public async Task DashBoardTab()
    {
        if (!await Page.Locator(Dashboard.Ebner_image).IsVisibleAsync())
            throw new KeyNotFoundException("DashBoard Not found");

        // await Page.Locator(Dashboard.Industry_list).ClickAsync();
        // await Page.GetByText(Dashboard.VOESTALPINE).ClickAsync();
        // await Task.Delay(2000);

        await Page.GetByText(Dashboard.My_facilities).ClickAsync();
        await Task.Delay(2000);
        await Page.GoBackAsync();

    }
}
