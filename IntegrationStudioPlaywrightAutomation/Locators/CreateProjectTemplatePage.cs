using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace IntegrationStudioPlaywrightAutomation.Locators
{
    public class CreateProjectTemplatePage
    {
        private readonly IPage Page;

        public CreateProjectTemplatePage(IPage page)
        {
            Page = page;
        }

        
        public ILocator ProjectTemplatePage => Page.Locator("#app-layout-container");
        public ILocator CreateProjectTemplateButton => Page.Locator("#project-add-btn");
        public ILocator CreaterProjectTemplatePage => Page.Locator("#wizard-form-container");
        public ILocator CreateProjectTemplatePageTitle => Page.Locator("//div[text()='Create project template']");
        public ILocator CreateprojectTemplateSubTitle => Page.Locator("//div[contains(text(),'select the system suite it will run.')]");
        public ILocator CreateProjectTemplateHeader => Page.Locator("#wizard-form-header");
        public ILocator CreateProjectTemplatePages => Page.Locator("#wizard-form-steps");
        public ILocator ProjectTemplateInformationText => Page.Locator("//div[text()='Project template information']");














    }
}
