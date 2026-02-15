using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationStudioPlaywrightAutomation.Locators;
using Microsoft.Playwright;

namespace IntegrationStudioPlaywrightAutomation.WorkFlows
{
    public class GlobalParametersWorkflow
    {
        private readonly GlobalParametersPage Page;

        public GlobalParametersWorkflow(IPage page) 
        { 

            Page = new GlobalParametersPage(page);
        }
        public async Task OpenGlobalParametersPageAsync()
        {
            await Page.ClickGlobalParametersOption();
        }


    }
}
