using PageObjectModelPW.Actions;

namespace PageObjectModelPW.testcases;

[TestFixture]
internal class DashboardTest: TestBase
{
    [Test]
    public async Task DashBoardTabAsync()
    {
        var dashboardAction = new DashboardAction(Page);
        await dashboardAction.DashBoardTab();

    }
}
