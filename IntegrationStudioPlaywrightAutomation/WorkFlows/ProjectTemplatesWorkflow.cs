using IntegrationStudioPlaywrightAutomation.Locators;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationStudioPlaywrightAutomation.WorkFlows
{
    public class ProjectTemplatesWorkflow
    {
        private readonly ProjectTemplatesPage Page;

        public ProjectTemplatesWorkflow(IPage page)
        {
            Page = new ProjectTemplatesPage(page);
        }
        public async Task CloseOrOpenLHSMenuAsync()
        {
            await Page.ClickCollapseButtonInLHSMenu();
        }
        public async Task OpenPageNumberDropdownlist()
        {
            await Page.ClickPageDropdownIcon();
        }
            


    }
}
