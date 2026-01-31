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


        public ILocator ProjectTemplateInformationPage => Page.Locator("#wizard-form-current-page");
        public ILocator ProjectTemplateNameTextBox => Page.Locator("#textbox-project-name-field");
        public ILocator ProjectTemplateNameTextBoxEdit => Page.Locator("#uilab-textfield-0");
        public ILocator ProjectTemplateNameHelperText => Page.Locator("//span[text()='This field is required.']");


        public ILocator DescriptionTextBox => Page.Locator("#textbox-app-describ-field");
        public ILocator DescriptionTextBoxEdit => Page.Locator("#uilab-textfield-1");


        public ILocator SystemSuiteDefinitionField => Page.Locator("#app-suite");
        public ILocator SystemSuiteDefinitionText => Page.Locator("//div[text()='System suite definition']");
        public ILocator SystemSuiteDefinitionDropDownIcon => Page.Locator("[data-testid='ArrowDropDownIcon']").First;
        public ILocator SystemSuiteDefinitionHelperText => Page.Locator("//div[text()='This field is required.']").First;


        public ILocator DefaultHostingRegionTextBox => Page.Locator("#host-region-select");
        public ILocator DefaultHostingRegionHelperText => Page.Locator("//div[text()='This field is required.']").Last;
        public ILocator DefaultHostingRegionDropDownIcon => Page.Locator("[data-testid='ArrowDropDownIcon']").Last;
        public ILocator PTInfoCancelButton => Page.Locator("#wizard-form-cancel-btn");
        public ILocator PTInfoNextButton => Page.Locator("#wizard-form-next-btn");

        public ILocator SystemSuiteSelectionDialog => Page.Locator("[role='dialog']");
        public ILocator SystemSuiteSelectionHeader => Page.Locator("//h2[text()='System suite selection']");
        public ILocator AVEVASystemSuiteHeader => Page.Locator("//div[text()='AVEVA system suites']");
        public ILocator SS2023 => Page.Locator("//div[text()='2023 Global']");
        public ILocator SS2023Selected => Page.Locator("//div[@class='usc-suite-item usc-suite-item-seleted']");
        public ILocator SSOkButton => Page.Locator("//uilab-button[text()='OK']");
        public ILocator SSCancelButton => Page.Locator("//uilab-button[text()='Cancel']").Last;

        public ILocator CustomSystemSuiteHeaer => Page.Locator("//div[text()='Custom system suites']");

        public ILocator HostingRegionListBox => Page.Locator("//ul[contains(@class,'MuiMenu-list css-r8u8y9')]");
        public ILocator HostingRegions => Page.Locator("[role='option']").First;

        public ILocator NodeConfigSubTitle => Page.Locator("//div[contains(text(),'button to add nodes')]");
        public ILocator NodeConfigText => Page.Locator("//div[text()='Node configuration']");
        public ILocator AddNodeButton => Page.Locator("#add-another-node");
        public ILocator NodeConfigPageTableHeader => Page.Locator("#node-configure-table-head");
        public ILocator NodeConfigPageTableRows => Page.Locator("//td[text()='You have no nodes.']");
        public ILocator NodeConfigPagePreviousButton => Page.Locator("#wizard-form-previous-btn");
        public ILocator NodeConfigPageCancelButton => Page.Locator("#wizard-form-cancel-btn");
        public ILocator NodeConfigPageNextButton => Page.Locator("#wizard-form-next-btn");

        public ILocator NodeConfigPageTableNameColumn => Page.Locator("//th[text()='Name']");
        public ILocator NodeConfigPageTableTypeColumn => Page.Locator("//th[text()='Type']");
        public ILocator NodeConfigPageTableMachineTypeColumn => Page.Locator("//th[text()='Machine type']");
        public ILocator NodeConfigPageTableMachineConfigColumn => Page.Locator("//th[text()='Machine configuration']");
        public ILocator NodeConfigPageTableCreditsColumn => Page.Locator("//th[text()='Credits/hr']");
        public ILocator NodeConfigPageTableEnableMultiNICsColumn => Page.Locator("//th[text()='Enable multiple NICs']");









    }
}
