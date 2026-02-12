using IntegrationStudioPlaywrightAutomation.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;


namespace IntegrationStudioPlaywrightAutomation.Assertions
{
    public static class NavigationBarNotificationPanelAssertions
    {
        public static async Task VerifyAppBarIsVisible(NavigationBarPage page)
        {
            await page.AppBar.FocusAsync();
            await Expect(page.AppBar).ToBeVisibleAsync();

        }
        public static async Task VerifyPageTitle()
        {

        }
    }
}
