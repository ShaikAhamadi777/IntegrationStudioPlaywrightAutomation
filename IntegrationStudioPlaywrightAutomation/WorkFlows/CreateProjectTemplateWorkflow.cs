using IntegrationStudioPlaywrightAutomation.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace IntegrationStudioPlaywrightAutomation.WorkFlows
{
    public class CreateProjectTemplateWorkflow
    {
        private readonly CreateProjectTemplatePage Page;

        public CreateProjectTemplateWorkflow(IPage page)
        {
            Page = new CreateProjectTemplatePage(page);
        }


        public async Task OpenProjectTemplatePageAsync()
        {
            await Page.ClickProjectTemplateButtonAsync();
        }
        public async Task OpenSystemSuiteSelectionPopupAsync()
        {
            await Page.ClickSystemSuiteDefinitionDropdownAsync();
        }
        public async Task OpenProjectTemplatePageFillPTNameAsync(string PTName)
        {
            await Page.FillProjectTemplateNameFieldAsync(PTName);
        }
        public async Task OpenProjectTemplatePageFillPTDescriptionAsync(string description)
        {
            await Page.FillProjectTemplateDecriptionFieldAsync(description);
        }
        public async Task SelectSystemSuiteAsync()
        {
            await Page.ClickSystemSuiteFromSelectionPopupAsync();
        }
        public async Task SelectSystemSuiteOKButtonAsync()
        {
            await Page.ClickSystemSuiteOKButtonAsync();
        }
        public async Task OpenDefaultHostingRegionPopupAsync()
        {
            await Page.ClickDefaultHostingRegionDropdownAsync();
        }
        public async Task SelectHostingRegionOptionAsync()
        {
            await Page.ClickDefaultHostingRegionOptionAsync();
        }
        public async Task SelectProjectTemplateInfoNextButtonAsync()
        {
            await Page.ClickProjectTemplateInfoNextBuuttonAsync();
        }
        public async Task OpenAddNodePopupAsync()
        {
            await Page.ClickAddNodeButtonAsync();
        }
        public async Task OpenAddNodePopupNodeTypeDropdownAsync()
        {
            await Page.ClickAddNodeTypeBoxAsync();
        }
        public async Task OpenAddNodePopupMachineTypeDropdownAsync()
        {
            await Page.ClickAddNodeMachineTypeBoxAsync();
        }
        public async Task OpenAddNodePopupNodeNameAsync(string nodename)
        {
            await Page.ClickAndFillNodeNameAsync(nodename);
        }
        public async Task CloseAddNodePopupAsync()
        {
            await Page.ClickAddNodeAddButtonAsync();
        }
        public async Task OpenLaunchParametersPageAsync()
        {
            await Page.ClickNodeConfigNextButtonAsync();
        }


        
        

    }
}
