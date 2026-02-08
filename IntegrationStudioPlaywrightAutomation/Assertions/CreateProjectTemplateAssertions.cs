using IntegrationStudioPlaywrightAutomation.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;



namespace IntegrationStudioPlaywrightAutomation.Assertions
{
    public static class CreateProjectTemplateAssertions
    {
        public static async Task VerifyCreateProjectTemplateButtonAsync(CreateProjectTemplatePage page)
        {
            await Expect(page.ProjectTemplatePage).ToBeVisibleAsync();
            await Expect(page.CreateProjectTemplateButton).ToBeVisibleAsync();
            await Expect(page.CreateProjectTemplateButton).ToBeEnabledAsync();
        }
        public static async Task VerifyProjectTemplateTitleAndHeaderAsync(CreateProjectTemplatePage page)
        {
            await Expect(page.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(page.CreateProjectTemplatePageTitle).ToHaveTextAsync("Create project template");
            await Expect(page.CreateprojectTemplateSubTitle).ToBeVisibleAsync();
            await Expect(page.CreateProjectTemplateHeader).ToBeVisibleAsync();
            await Expect(page.CreateProjectTemplatePages).ToBeVisibleAsync();
            await Expect(page.ProjectTemplateInformationText).ToBeVisibleAsync();
        }
        public static async Task VerifyProjectTemplateNameFieldAsync(CreateProjectTemplatePage page)
        {

            await Expect(page.ProjectTemplateInformationPage).ToBeVisibleAsync();
            await Expect(page.ProjectTemplateNameTextBox).ToBeVisibleAsync();
            await Expect(page.ProjectTemplateNameTextBoxEdit).ToBeVisibleAsync();
            await Expect(page.ProjectTemplateNameTextBoxEdit).ToBeEditableAsync();
            await Expect(page.ProjectTemplateNameHelperText).ToBeVisibleAsync();
        }
        public static async Task VerifyProjectTemplateDescriptionFieldAsync(CreateProjectTemplatePage page)
        {
            await Expect(page.DescriptionTextBox).ToBeVisibleAsync();
            await Expect(page.DescriptionTextBoxEdit).ToBeEditableAsync();
        }
        public static async Task VerifyProjectTemplateSystemSuiteFieldAsync(CreateProjectTemplatePage page)
        {
            await Expect(page.SystemSuiteDefinitionField).ToBeVisibleAsync();
            await Expect(page.SystemSuiteDefinitionText).ToBeVisibleAsync();
            await Expect(page.SystemSuiteDefinitionDropDownIcon).ToBeVisibleAsync();
            await Expect(page.SystemSuiteDefinitionDropDownIcon).ToBeEnabledAsync();
            await Expect(page.SystemSuiteDefinitionHelperText).ToBeVisibleAsync();
        }
        public static async Task VerifyProjectTemplateDefaultHostingRegionFieldAsync(CreateProjectTemplatePage page)
        {
            await Expect(page.DefaultHostingRegionTextBox).ToBeVisibleAsync();
            await Expect(page.DefaultHostingRegionTextBox).ToBeEditableAsync();
            await Expect(page.DefaultHostingRegionHelperText).ToBeVisibleAsync();
            await Expect(page.DefaultHostingRegionDropDownIcon).ToBeVisibleAsync();
            await Expect(page.DefaultHostingRegionDropDownIcon).ToBeEnabledAsync();

        }
        public static async Task VerifyProjectTemplateInfoPageButtonsAsync(CreateProjectTemplatePage page)
        {
            await Expect(page.PTInfoCancelButton).ToBeVisibleAsync();
            await Expect(page.PTInfoCancelButton).ToBeEnabledAsync();
            await Expect(page.PTInfoNextButton).ToBeVisibleAsync();
            await Expect(page.PTInfoNextButton).ToBeEnabledAsync();
        }
        public static async Task VerifySystemSuiteSelectionPopupAsync(CreateProjectTemplatePage page)
        {
            await Expect(page.SystemSuiteSelectionDialog).ToBeVisibleAsync();
            await Expect(page.SystemSuiteSelectionHeader).ToBeVisibleAsync();
            await Expect(page.AVEVASystemSuiteHeader).ToBeVisibleAsync();
            await Expect(page.SS2023).ToBeVisibleAsync();
            await Expect(page.CustomSystemSuiteHeaer).ToBeVisibleAsync();
            await Expect(page.SSOkButton).ToBeVisibleAsync();
            await page.SSOkButton.HighlightAsync();
            await page.SSOkButton.FocusAsync();
            await Expect(page.SSCancelButton).ToBeVisibleAsync();
            await Expect(page.SSCancelButton).ToBeEnabledAsync();
        }
        public static async Task VerifySystemSuiteSelectedFromPopUpAsync(CreateProjectTemplatePage page)
        {
            await page.SS2023Selected.IsVisibleAsync();
        }
        public static async Task VerifyDefaultHostingRegionDropdownList(CreateProjectTemplatePage page)
        {
            await Expect(page.HostingRegionListBox).ToBeVisibleAsync();
        }
        public static async Task VerifyNodeConfigurationTitleAndHeaderAsync(CreateProjectTemplatePage page)
        {
            await Expect(page.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(page.NodeConfigSubTitle).ToBeVisibleAsync();
            await Expect(page.NodeConfigSubTitle).ToBeVisibleAsync();
        }
        public static async Task VerifyNodeConfigurationAddNodeButtonAsync(CreateProjectTemplatePage page)
        {
            await Expect(page.AddNodeButton).ToBeVisibleAsync();
            await Expect(page.AddNodeButton).ToBeEnabledAsync();
        }
        public static async Task VerifyNodeConfigurationTableHeaderAsync(CreateProjectTemplatePage page)
        {
            await Expect(page.NodeConfigPageTableHeader).ToBeVisibleAsync();
            await Expect(page.NodeConfigPageTableNameColumn).ToBeVisibleAsync();
            await Expect(page.NodeConfigPageTableTypeColumn).ToBeVisibleAsync();
            await Expect(page.NodeConfigPageTableMachineTypeColumn).ToBeVisibleAsync();
            await Expect(page.NodeConfigPageTableMachineConfigColumn).ToBeVisibleAsync();
            await Expect(page.NodeConfigPageTableCreditsColumn).ToBeVisibleAsync();
            await Expect(page.NodeConfigPageTableEnableMultiNICsColumn).ToBeVisibleAsync();
            await Expect(page.NodeConfigPageTableRows).ToBeVisibleAsync();

        }
        public static async Task VerifyNodeConfigurationPageButtonsAsync(CreateProjectTemplatePage page)
        {
            await Expect(page.NodeConfigPagePreviousButton).ToBeVisibleAsync();
            await Expect(page.NodeConfigPagePreviousButton).ToBeEnabledAsync();

            await Expect(page.NodeConfigPageCancelButton).ToBeVisibleAsync();
            await Expect(page.NodeConfigPageCancelButton).ToBeEnabledAsync();

            await Expect(page.NodeConfigPageNextButton).ToBeVisibleAsync();
            await Expect(page.NodeConfigPageNextButton).ToBeEnabledAsync();
        }
        public static async Task VerifyNodeConfigurationPageEmptyNodes(CreateProjectTemplatePage page)
        {
            var emptyrows = await page.NodeConfigPageTableRows.InnerTextAsync();
            Assert.That(emptyrows, Is.EqualTo("You have no nodes."));
        }
        public static async Task VerifyAddNodePopupDialogContent(CreateProjectTemplatePage page)
        {
            await Expect(page.AddNodeDialog).ToBeVisibleAsync();
            await Expect(page.AddNodeDialogContent).ToBeVisibleAsync();
            await Expect(page.AddNodeTitle).ToBeVisibleAsync();
        }
        public static async Task VerifyAddNodePopupNodeNameTextBox(CreateProjectTemplatePage page)
        {
            await Expect(page.NodeNameTextBox).ToBeVisibleAsync();
            await Expect(page.NodeNameTextBox).ToBeEnabledAsync();
            await Expect(page.NodeNameTextBoxEdit).ToBeEditableAsync();
        }
        public static async Task VerifyAddNodePopupNodeTypeTextBox(CreateProjectTemplatePage page)
        {
            await Expect(page.NodeTypeTextBox).ToBeVisibleAsync();
            await Expect(page.NodeTypeText).ToBeVisibleAsync();
            await Expect(page.NodeTypeDropDownIcon).ToBeVisibleAsync();
            await Expect(page.NodeTypeText).ToBeEditableAsync();
        }
        public static async Task VerifyAddNodePopupMachineTypeToolTip(CreateProjectTemplatePage page)
        {
            await Expect(page.MachineTypeToolTip).ToBeVisibleAsync();
            await page.MachineTypeToolTip.HoverAsync();
            await page.MachineTypeToolTip.WaitForAsync();
            await page.MachineTypeToolTipBox.WaitForAsync();
            await Expect(page.MachineTypeToolTipBox).ToBeVisibleAsync();
        }
        public static async Task VerifyAddNodePopupMachineTypeTextBox(CreateProjectTemplatePage page)
        {
            await Expect(page.MachineTypeTextBox).ToBeVisibleAsync();
            await Expect(page.MachineTypeText).ToBeVisibleAsync();
            await Expect(page.MachineTypeSize).ToBeVisibleAsync();
            await Expect(page.MachineTypeDropDown).ToBeVisibleAsync();
            await Expect(page.MachineTypeDropDown).ToBeEnabledAsync();
        }
        public static async Task VerifyAddNodePopupMachineTypeToolTipBox(CreateProjectTemplatePage page)
        {
            await Expect(page.MachineTypeToolTipCores).ToBeVisibleAsync();
            await Expect(page.MachineTypeToolTipRam).ToBeVisibleAsync();
        }
        public static async Task VerifyAddNodePopupNICsCheckBox(CreateProjectTemplatePage page)
        {
            await Expect(page.AddNodeNICsCheckBox).ToBeVisibleAsync();
            await Expect(page.AddNodeNICsCheckBox).ToBeCheckedAsync();
            await Expect(page.EnableMultiNICsText).ToBeVisibleAsync();
        }
        public static async Task VerifyAddNodePopupButtons(CreateProjectTemplatePage page)
        {
            await Expect(page.AddNodeCancelButton).ToBeVisibleAsync();
            await Expect(page.AddNodeCancelButton).ToBeEnabledAsync();
            await Expect(page.AddNodeAddButton).ToBeVisibleAsync();
            await Expect(page.AddNodeAddButton).ToBeEnabledAsync();
        }
        public static async Task VerifyAddNodePopupNodeTypeList(CreateProjectTemplatePage page)
        {
            await Expect(page.NodeTypeDropDownList).ToBeVisibleAsync();
        }
        public static async Task VerifyAddNodePopupMachineTypeDropDownList(CreateProjectTemplatePage page)
        {
            await page.MachineTypeDropDownList.WaitForAsync();
            await Expect(page.MachineTypeDropDownList).ToBeVisibleAsync();
        }
        public static async Task VerifyLaunchParametersPage(CreateProjectTemplatePage page)
        {
            await Expect(page.LaunchParameterPage).ToBeVisibleAsync();
            await Expect(page.CreateProjectTemplateHeader).ToBeVisibleAsync();
            await Expect(page.CreateProjectTemplateHeader).ToContainTextAsync("Specify the default values for all runtime parameters for your project template's applications.\r\n");
            await Expect(page.LaunchParametersText).ToBeVisibleAsync();
            await Expect(page.LaunchParameterNodeBlock).ToBeVisibleAsync();
            await Expect(page.LaunchParameterNodeBody).ToBeVisibleAsync();
        }

    }
}
