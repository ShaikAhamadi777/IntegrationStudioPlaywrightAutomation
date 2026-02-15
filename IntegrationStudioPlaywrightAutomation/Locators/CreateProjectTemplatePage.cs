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
        public ILocator PageCancelButton => Page.Locator("#wizard-form-cancel-btn");
        public ILocator PageNextButton => Page.Locator("#wizard-form-next-btn");

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

        public ILocator NodeConfigSubTitle => Page.Locator("//div[contains(text(),'Configure a node for each application that runs in this project template')]");
        public ILocator NodeConfigText => Page.Locator("//div[text()='Node configuration']");
        public ILocator AddNodeButton => Page.Locator("#add-another-node");
        public ILocator NodeConfigPageTableHeader => Page.Locator("#node-configure-table-head");
        public ILocator NodeConfigPageTableRows => Page.Locator("//td[text()='You have no nodes.']");
        public ILocator PagePreviousButton => Page.Locator("#wizard-form-previous-btn");


        public ILocator NodeConfigPageTableNameColumn => Page.Locator("//th[text()='Name']");
        public ILocator NodeConfigPageTableTypeColumn => Page.Locator("//th[text()='Type']");
        public ILocator NodeConfigPageTableMachineTypeColumn => Page.Locator("//th[text()='Machine type']");
        public ILocator NodeConfigPageTableMachineConfigColumn => Page.Locator("//th[text()='Machine configuration']");
        public ILocator NodeConfigPageTableCreditsColumn => Page.Locator("//th[text()='Credits/hr']");
        public ILocator NodeConfigPageTableEnableMultiNICsColumn => Page.Locator("//th[text()='Enable multiple NICs']");

        public ILocator AddNodeDialog => Page.Locator("//div[contains(@class,'paperWidthSm css-uhb5lp')]");
        public ILocator AddNodeTitle => Page.Locator("//h2[text()='Add a node']");
        public ILocator AddNodeDialogContent => Page.Locator("#alert-dialog-content");
        public ILocator NodeNameTextBox => Page.Locator("#node-name-field");
        public ILocator NodeNameTextBoxEdit => Page.Locator("[aria-labelledby='Node name']");

        public ILocator NodeTypeTextBox => Page.Locator("#grid-tree-area");
        public ILocator NodeTypeText => Page.Locator("//span[text()='Node type']");
        public ILocator NodeTypeDropDownIcon => Page.Locator("[data-testid='ArrowDropDownIcon']").First;
        public ILocator NodeTypeDropDownList => Page.Locator("//ul[@class='MuiTreeView-root css-1fk0lbh']");

        
        public ILocator MachineTypeTextBox => Page.Locator(".chp-select-field");
        public ILocator MachineTypeText => Page.Locator("#demo-simple-select-standard-label");
        public ILocator MachineTypeSize => Page.Locator("#vm-size-field");
        public ILocator MachineTypeDropDown => Page.Locator("[data-testid='ArrowDropDownIcon']").Last;
        public ILocator MachineTypeDropDownList => Page.Locator("//ul[contains(@class,'MuiMenu-list css-r8u8y9')]");
        public ILocator AddNodeNICsCheckBox => Page.Locator(".mdc-checkbox__native-control");
        public ILocator EnableMultiNICsText => Page.Locator("//label[text()='Enable multiple NICs']");
        public ILocator MachineTypeToolTip => Page.Locator(".icon-opacity06");
        public ILocator MachineTypeToolTipBox => Page.Locator("//div[contains(@class,'MuiPopover-paper css-1dmzujt')]");

        public ILocator MachineTypeToolTipCores => Page.Locator("//div[contains(text(),'Cores')]");
        public ILocator MachineTypeToolTipRam => Page.Locator("//div[contains(text(),'Ram:')]");

        public ILocator AddNodeCancelButton => Page.Locator("#cancel-add-btn");
        public ILocator AddNodeAddButton => Page.Locator("//uilab-button[@type='submit']");

        public ILocator AddedNodeRow => Page.Locator("//tr[@class='MuiTableRow-root node-table-row css-axz6ke']");
        public ILocator AddNodeEnableMultiNIcs => Page.Locator(".mdc-checkbox__native-control");
        public ILocator AddNodeRowDeleteButton => Page.Locator(".icon-opacity06 ");

        public ILocator LaunchParametersSubTitle => Page.Locator("");
        public ILocator LaunchParametersText => Page.Locator("//div[text()='Launch parameters']");
        public ILocator LaunchParameterPage => Page.Locator("#launch-params-page");
        public ILocator LaunchParameterNodeName => Page.Locator("text=/^[A-Za-z0-9_]+$/");
        public ILocator LaunchParameterNodeType => Page.Locator("//div[text()='2023-SystemPlatform']");
        public ILocator LaunchParameterNodeBlock => Page.Locator(".node-param-node-describe");
        public ILocator LaunchParameterNodeBody => Page.Locator(".node-param-body");
        public ILocator CreateGalaxyRepoNameLabel => Page.Locator("//div[text()='Create Galaxy Repository?']");
        public ILocator CreateGalaxyRepoTextBox => Page.Locator("[value='TestGalaxy']");

        public ILocator NodeTypeSP2023 => Page.Locator("//div[@class='MuiTreeItem-label' and text()='SystemPlatform']");
        public ILocator NodeList => Page.Locator("li[role='treeitem']:not([aria-expanded])");
        
        public ILocator ShutdownBehaviourPageSubTitle => Page.Locator("//div[contains(text(),'Set a time when a running node')]");
        public ILocator ShutdownBehaviourText => Page.Locator("//div[text()='Shutdown behavior']");
        public ILocator ShutdownBehaviourField => Page.Locator("//div[@class='MuiFormControl-root MuiFormControl-fullWidth css-tzsjye']");
        public ILocator ShutdownBehaviourDropdownField => Page.Locator("[aria-haspopup='listbox']");
        public ILocator ShutdownBehaviourDropdownText => Page.Locator("#auto-shutdown-select-label");
        public ILocator ShutdownBehaviourDropdownIcon => Page.Locator("[data-testid='ArrowDropDownIcon']");
        public ILocator ShutdownBehaviourFieldHelperText => Page.Locator("//p[contains(@class,'MuiFormHelperText-root MuiFormHelperText')]");
        public ILocator ShutdownBehaviourDropdownList => Page.Locator("[aria-labelledby='auto-shutdown-select-label']");

        public ILocator ConfirmCompleteSubTitle => Page.Locator("//div[contains(text(),'Your project template is almost ready.')]");
        public ILocator ConfirmCompleteText => Page.Locator("//div[contains(text(),'Confirm and complete')]");
        public ILocator ProjectVisibilityArea => Page.Locator("#project-visible-area");
        public ILocator ProjectVisibilityTextField => Page.Locator("//div[@class='MuiFormControl-root css-13sljp9']");
        public ILocator ProjectVisiblityText => Page.Locator("#project-visible-select-label");
        public ILocator ProjectVisibilityDropdownIcon => Page.Locator("[data-testid='ArrowDropDownIcon']");
        public ILocator ProjectVisibilityDropdownList => Page.Locator("[aria-labelledby='project-visible-select-label']");
        public ILocator ProjectVisibilityHelpertext => Page.Locator("//p[contains(@class,'MuiFormHelperText-root')]");
        public ILocator ConfirmCompleteNodeDetailsGrid => Page.Locator("//div[@class='chp-card-grid']");
        public ILocator ConfirmCompleteNodeDetails => Page.Locator("//div[@class='chp-card-grid-body']");
        public ILocator CreateProjectTemplateCompletionButton => Page.Locator("#wizard-form-submit-action0");

        public ILocator CreateProjectTemplateSuccessfulPopup => Page.Locator("[aria-labelledby='alert-dialog-title']");
        public ILocator CreateSuccessfulTitle => Page.Locator("#alert-dialog-title");
        public ILocator CreateSuccessfulDialogContent => Page.Locator("#succeed-dialog-content");
        public ILocator CreateSuccessfulDialogOKButton => Page.Locator("#succeed-dialog-confirm");

        public async Task ClickProjectTemplateButtonAsync()
        {
            await CreateProjectTemplateButton.ClickAsync();
        }
        public async Task ClickSystemSuiteDefinitionDropdownAsync()
        {
            await SystemSuiteDefinitionDropDownIcon.ClickAsync();
        }
        public async Task FillProjectTemplateNameFieldAsync(string PTName)
        {
            await ProjectTemplateNameTextBoxEdit.FillAsync(PTName);
        }
        public async Task FillProjectTemplateDecriptionFieldAsync(string description)
        {
            await DescriptionTextBoxEdit.FillAsync(description);
        }
        public async Task ClickSystemSuiteFromSelectionPopupAsync()
        {
            await SS2023.ClickAsync();
        }
        public async Task ClickSystemSuiteOKButtonAsync()
        {
            await SSOkButton.ClickAsync();
        }
        public async Task ClickDefaultHostingRegionDropdownAsync()
        {
            await DefaultHostingRegionTextBox.ClickAsync();
        }
        public async Task ClickDefaultHostingRegionOptionAsync()
        {
            await HostingRegions.ClickAsync();
        }
        public async Task ClickPageNextBuuttonAsync()
        {
            await PageNextButton.ClickAsync();
        }
        public async Task ClickAddNodeButtonAsync()
        {
            await AddNodeButton.ClickAsync();
        }
        public async Task ClickAddNodeTypeBoxAsync()
        {
            await NodeTypeTextBox.ClickAsync();
        }
        public async Task ClickAddNodeMachineTypeBoxAsync()
        {
            await MachineTypeTextBox.ClickAsync();
        }
        public async Task ClickAndFillNodeNameAsync(string nodename)
        {
            await NodeNameTextBox.ClickAsync();
            await NodeNameTextBoxEdit.FillAsync(nodename);
        }
        public async Task ClickAddNodeAddButtonAsync()
        {
            await AddNodeAddButton.ClickAsync();
        }
        public async Task ClickShutdownBehaviourDropdownIconAsync()
        {
            await ShutdownBehaviourDropdownField.ClickAsync();
        }
        public async Task ClickShutdownBehaviourDropdownListAsync()
        {
            await ShutdownBehaviourDropdownList.ClickAsync();
        }
        public async Task ClickProjectVisibilityDrodown()
        {
            await ProjectVisibilityTextField.ClickAsync();
        }
        public async Task ClickProjectVisibilityDropdownList()
        {
            await ProjectVisibilityDropdownList.ClickAsync();
        }
        public async Task ClickCreateProjectTemplateButtonAsync()
        {
            await CreateProjectTemplateCompletionButton.ClickAsync();
        }
        public async Task ClickCreateSuccessfulDialogOKButtonAsync()
        {
            await CreateSuccessfulDialogOKButton.ClickAsync();
        }

    }
}
