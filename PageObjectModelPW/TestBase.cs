
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using PageObjectModelPW.Actions;

namespace PageObjectModelPW;

public class TestBase
{
    public IPlaywright Playwright;
    protected IBrowser Browser;
    public IPage Page;
    private static ExtentReports extentReports;
    public static ExtentTest extentTest;
    private static readonly ILog log = LogManager.GetLogger(typeof(TestBase));
    IConfiguration configuration;

    // [OneTimeSetUp]
    // public void OneTimeSetUp()
    // {
    //     log.Info("Test Execution Started");
    //     configuration = new ConfigurationBuilder().SetBasePath(Directory.GetParent(Environment.CurrentDirectory)
    //         .Parent.Parent.FullName + "\\resources").AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    //         .Build();
    //     DateTime dateTime = DateTime.Now;
    //     string fileName = "Extent_" + dateTime.ToString("yyyyy-MM-dd_HH-mm-ss") + ".html";
    //     extentReports = CreateInstance(fileName);
    // }

    [SetUp]
    public async Task Setup()
    {
        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            Args = ["--start-maximzed"]
        });

        Page = await Browser.NewPageAsync();
        // await Page.SetViewportSizeAsync(1400, 900);
        var url = "https://staging-hub.ebner.cc/auth/login";
        await Page.GotoAsync(url);
        await Assertions.Expect(Page).ToHaveURLAsync(url);

        await Task.Delay(2000);
        var loginAction = new LoginAction(Page);
        await loginAction.EbnerEmployeeLogin();
        await Task.Delay(14000);
    }

    [OneTimeTearDown]
    public void Teardown()
    {
        extentReports.Flush();
        log.Info("Test Execution Completed");
    }

    [TearDown]
    public void AfterEachTest()
    {

    }

    private static ExtentReports CreateInstance(string fileName)
    {
        var htmlReporter = new ExtentSparkReporter(Directory.GetParent(Environment.CurrentDirectory)
            .Parent.Parent.FullName + "\\resources");
        htmlReporter.Config.Theme = Theme.Standard;
        htmlReporter.Config.DocumentTitle = "Ebner Test Suite";
        htmlReporter.Config.ReportName = "Ebner Automation Test Results";
        htmlReporter.Config.Encoding = "utf-8";

        extentReports = new ExtentReports();
        extentReports.AttachReporter(htmlReporter);

        return extentReports;
    }
}

