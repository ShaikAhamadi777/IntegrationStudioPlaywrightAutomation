using IntegrationStudioPlaywrightAutomation.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace IntegrationStudioPlaywrightAutomation.WorkFlows
{
    public class GeneralSettingsWorkflow
    {
        private readonly GeneralSettingsPage Page;

        public GeneralSettingsWorkflow(IPage page)
        {
            Page = new GeneralSettingsPage(page);
        }
        public async Task OpenGeneralPage()
        {
            await Page.ClickGeneralSettingsOption();

        }

    }
}
