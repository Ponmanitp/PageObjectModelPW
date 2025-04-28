
using Microsoft.Playwright;

namespace PageObjectModelPW;

public class TestBase
{
using var playwright = await Playwright.CreateAsync();
var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
var page = await browser.NewPageAsync();
await page.SetViewportSizeAsync(1400, 900);
await page.GotoAsync("https://staging-hub.ebner.cc/auth/login");
await Task.Delay(2000);
}

