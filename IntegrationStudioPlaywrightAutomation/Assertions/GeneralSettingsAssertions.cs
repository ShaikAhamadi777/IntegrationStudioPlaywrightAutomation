using IntegrationStudioPlaywrightAutomation.Locators;
using static Microsoft.Playwright.Assertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationStudioPlaywrightAutomation.Assertions
{
    public static class GeneralSettingsAssertions
    {
        public static async Task VerifyGeneralPage(GeneralSettingsPage page)
        {
            //General Settings page should be displayed
            await page.GeneralPage.WaitForAsync();
            await Expect(page.GeneralPage).ToBeVisibleAsync();
            await Expect(page.GeneralSettingPage).ToBeVisibleAsync();
        }
        public static async Task VerifyNumberOfVmsSnapshots(GeneralSettingsPage page)
        {
            //Verify that the Number of VMs text present
            await page.GeneralPage.WaitForAsync();
            await page.GeneralSettingPage.WaitForAsync();
            await Expect(page.GeneralSettingPage).ToBeVisibleAsync();
            await Expect(page.NumberOfVMsInUse).ToBeVisibleAsync();
            await Expect(page.NumberOfSnapshotsInUse).ToBeVisibleAsync();
        }

    }
}
