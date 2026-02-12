using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationStudioPlaywrightAutomation.Locators;
using Microsoft.Playwright;

namespace IntegrationStudioPlaywrightAutomation.WorkFlows
{
    public class SystemSuitesWorkflow
    {
        private readonly SystemSuitesPage Page;

        public SystemSuitesWorkflow(IPage page)
        {
            Page = new SystemSuitesPage(page);
        }
        public async Task OpenSystemSuiteSubMenuAsync()
        {
            await Page.ClickSystemSuitesOptionFromLHSMenu();
        }
        public async Task OpenManageSystemSuitesPageAsync()
        {
            await Page.ClickManageSystemSuitesOption();
        }
        public async Task DownloadGlobalSS()
        {
            await Page.ClickDownloadGlobalSS();
        }
        public async Task OpenSystemSuitePageDropdownList()
        {
            await Page.ClickSystemSuitePageDropdown();
        }


    }
}
