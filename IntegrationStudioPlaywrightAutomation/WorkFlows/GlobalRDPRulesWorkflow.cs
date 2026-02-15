using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationStudioPlaywrightAutomation.Locators;
using Microsoft.Playwright;


namespace IntegrationStudioPlaywrightAutomation.WorkFlows
{
    public class GlobalRDPRulesWorkflow
    {
        private readonly GlobalRDPRulesPage Page;

        public GlobalRDPRulesWorkflow(IPage page)
        {
            Page = new GlobalRDPRulesPage(page);
        }

        public async Task OpenGlobalRDPRulesPage()
        {
            await Page.ClickGlobalRDPRulesOption();
        }
        public async Task Openn()
        {

        }



    }
}
