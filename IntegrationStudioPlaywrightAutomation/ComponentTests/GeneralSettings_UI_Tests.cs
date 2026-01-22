using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using IntegrationStudioPlaywrightAutomation.Locators;

namespace IntegrationStudioPlaywrightAutomation.ComponentTests
{
    public class GeneralSettings_UI_Tests : BaseTest
    {
        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenGeneralSettingsPage(string role)
        {
            var general = new GeneralSettingsPage(Page);

            //Click on the general option from the LHS Menu
            await Expect(general.LHSMenu).ToBeVisibleAsync();
            await Expect(general.General).ToBeVisibleAsync();
            await general.General.ClickAsync();

            //General Settings page should be displayed
            await general.GeneralPage.WaitForAsync();
            await Expect(general.GeneralPage).ToBeVisibleAsync();
            await Expect(general.GeneralSettingPage).ToBeVisibleAsync();
            await general.GeneralPage.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_GeneralSettings_page_ForAllRoles.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenGeneralSettings_ShouldContain_NumberOfVMsandSnapshots_InUse(string role)
        {

            var numberofvms = new GeneralSettingsPage(Page);

            //Click on the general option from the LHS Menu
            await Expect(numberofvms.LHSMenu).ToBeVisibleAsync();
            await Expect(numberofvms.General).ToBeVisibleAsync();
            await numberofvms.General.ClickAsync();


            //Verify that the Number of VMs text present
            await numberofvms.GeneralPage.WaitForAsync();
            await numberofvms.GeneralSettingPage.WaitForAsync();
            await Expect(numberofvms.GeneralSettingPage).ToBeVisibleAsync();
            await Expect(numberofvms.NumberOfVMsInUse).ToBeVisibleAsync();
            await Expect(numberofvms.NumberOfSnapshotsInUse).ToBeVisibleAsync();
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NumberOfVMandSnapshots_page_ForAllRoles.png"
            });
        }
    }
}
