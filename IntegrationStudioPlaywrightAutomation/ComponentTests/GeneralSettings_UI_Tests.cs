
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using IntegrationStudioPlaywrightAutomation.Locators;
using IntegrationStudioPlaywrightAutomation.WorkFlows;
using IntegrationStudioPlaywrightAutomation.Assertions;

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
            var generalworkflow = new GeneralSettingsWorkflow(Page);
            var projecttemp = new ProjectTemplatesPage(Page);

            await ProjectTemplatesAssertions.VerifyLHSMenuForProjectAdmin(projecttemp);
            await generalworkflow.OpenGeneralPage();
            await GeneralSettingsAssertions.VerifyGeneralPage(general);
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
            var generalworkflow = new GeneralSettingsWorkflow(Page);
            var projecttemp = new ProjectTemplatesPage(Page);

            await ProjectTemplatesAssertions.VerifyLHSMenuForProjectAdmin(projecttemp);
            await generalworkflow.OpenGeneralPage();
            await GeneralSettingsAssertions.VerifyGeneralPage(numberofvms);
            await GeneralSettingsAssertions.VerifyNumberOfVmsSnapshots(numberofvms);
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NumberOfVMandSnapshots_page_ForAllRoles.png"
            });
        }
    }
}
