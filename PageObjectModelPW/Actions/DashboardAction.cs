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

        await Page.GetByText(Dashboard.My_documents).ClickAsync();
        await Task.Delay(2000);
        await Page.GoBackAsync();

        await Page.GetByText(Dashboard.Visual_furnaces).ClickAsync();
        await Task.Delay(2000);
        await Page.GoBackAsync();

        await Page.GetByText(Dashboard.Text_database).ClickAsync();
        await Task.Delay(2000);
        await Page.GoBackAsync();

        await Page.GetByText(Dashboard.Text).ClickAsync();
        await Task.Delay(2000);
        await Page.GoBackAsync();

        await Page.GetByText(Dashboard.UI_mapping).ClickAsync();
        await Task.Delay(2000);
        await Page.GoBackAsync();

        await Page.GetByText(Dashboard.Text_groups).ClickAsync();
        await Task.Delay(2000);
        await Page.GoBackAsync();

        await Page.GetByText(Dashboard.Language).ClickAsync();
        await Task.Delay(2000);
        await Page.GoBackAsync();

        await Page.GetByText(Dashboard.Visitorsform).ClickAsync();
        await Task.Delay(2000);
        await Page.GoBackAsync();

        await Page.GetByText(Dashboard.Material_database).ClickAsync();
        await Task.Delay(2000);
        await Page.GoBackAsync();

        await Page.GetByText(Dashboard.Database).ClickAsync();
        await Task.Delay(2000);
        await Page.GoBackAsync();

        await Page.GetByText(Dashboard.Requests).ClickAsync();
        await Task.Delay(2000);
        await Page.GoBackAsync();

    }
}
