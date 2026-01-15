using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationStudioPlaywrightAutomation.Locators;
using Microsoft.Playwright;

namespace IntegrationStudioPlaywrightAutomation.ComponentTests
{
    public class SystemSuites_UI_Tests : BaseTest
    {
        [Test]
        public async Task OpenSystemSuitesPage()
        {
            var systemsuites = new SystemSuitesPage(Page);

            await Expect(systemsuites.LHSMenu).ToBeVisibleAsync();
            await Expect(systemsuites.SystemSuites).ToBeVisibleAsync();

            //Click on the System suites button
            await systemsuites.SystemSuites.WaitForAsync();
            await systemsuites.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(systemsuites.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(systemsuites.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(systemsuites.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(systemsuites.ManageSystemsuites).ToBeVisibleAsync();
            await systemsuites.ManageSystemsuites.ClickAsync();

            await systemsuites.ManageSystemSuitesPage.WaitForAsync();
            await Expect(systemsuites.ManageSystemSuitesPage).ToBeVisibleAsync();


        }
    }
}
