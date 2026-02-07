using IntegrationStudioPlaywrightAutomation.Locators;
using IntegrationStudioPlaywrightAutomation.Utilities;
using IntegrationStudioPlaywrightAutomation.Utilities.Models;
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using IntegrationStudioPlaywrightAutomation.Assertions;
using IntegrationStudioPlaywrightAutomation.WorkFlows;

namespace IntegrationStudioPlaywrightAutomation.ComponentTests
{
    public class CreateProjectTemplate_UI_Tests : BaseTest
    {
        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenCreateProjectTemplatePage_ShouldContain_TitleAndSubTitleAndSteps(string role)
        {
            var cpttitle = new CreateProjectTemplatePage(Page);
            var cpworkflow = new CreateProjectTemplateWorkflow(Page);

            await CreateProjectTemplateAssertions.VerifyCreateProjectTemplateButtonAsync(cpttitle);
            await cpworkflow.OpenProjectTemplatePageAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(cpttitle);
            await cpttitle.CreateProjectTemplateHeader.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_CreateProjectTemplatePage_Header.png"
            });
            await cpttitle.CreateProjectTemplatePages.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_CreateProjectTemplatePage_Steps.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenCreateProjectTemplatePage_ShouldContain_ProjectInfoFields(string role)
        {
            var ptinfopage = new CreateProjectTemplatePage(Page);
            var ptworkflow = new CreateProjectTemplateWorkflow(Page);

            await CreateProjectTemplateAssertions.VerifyCreateProjectTemplateButtonAsync(ptinfopage);
            await ptworkflow.OpenProjectTemplatePageAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(ptinfopage);
            await CreateProjectTemplateAssertions.VerifyProjectTemplateNameFieldAsync(ptinfopage);
            await CreateProjectTemplateAssertions.VerifyProjectTemplateDescriptionFieldAsync(ptinfopage);
            await CreateProjectTemplateAssertions.VerifyProjectTemplateSystemSuiteFieldAsync(ptinfopage);
            await CreateProjectTemplateAssertions.VerifyProjectTemplateDefaultHostingRegionFieldAsync(ptinfopage);
            await ptinfopage.ProjectTemplateInformationPage.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_ProjectTemplateInfoPage_Fields.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenCreateProjectTemplatePage_ShouldContain_CancelNextButtons(string role)
        {
            var button = new CreateProjectTemplatePage(Page);
            var buttonworkflow = new CreateProjectTemplateWorkflow(Page);

            await CreateProjectTemplateAssertions.VerifyCreateProjectTemplateButtonAsync(button);
            await buttonworkflow.OpenProjectTemplatePageAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(button);
            await CreateProjectTemplateAssertions.VerifyProjectTemplateInfoPageButtonsAsync(button);
            await button.CreaterProjectTemplatePage.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_ProjectTemplateInfo_Page.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenCreateProjectTemplatePage_ShouldContain_SystemSuiteSelectionPopUp(string role)
        {

            var SSPopup = new CreateProjectTemplatePage(Page);
            var SSPopupworkflow = new CreateProjectTemplateWorkflow(Page);

            await CreateProjectTemplateAssertions.VerifyCreateProjectTemplateButtonAsync(SSPopup);
            await SSPopupworkflow.OpenProjectTemplatePageAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(SSPopup);
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(SSPopup);
            await SSPopupworkflow.OpenSystemSuiteSelectionPopupAsync();
            await CreateProjectTemplateAssertions.VerifySystemSuiteSelectionPopupAsync(SSPopup);
            await SSPopup.SystemSuiteSelectionDialog.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_SystemSuiteSelectionPopup.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenCreateProjectTemplatePage_ShouldFill_AllFileds(string role)
        {
            var ptinfofields = new CreateProjectTemplatePage(Page);
            var ptinfoworkflow = new CreateProjectTemplateWorkflow(Page);

            await CreateProjectTemplateAssertions.VerifyCreateProjectTemplateButtonAsync(ptinfofields);
            await ptinfoworkflow.OpenProjectTemplatePageAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(ptinfofields);
            await CreateProjectTemplateAssertions.VerifyProjectTemplateNameFieldAsync(ptinfofields);
            await ptinfoworkflow.OpenProjectTemplatePageFillPTNameAsync(PTName:"TestAutomation");

            await CreateProjectTemplateAssertions.VerifyProjectTemplateDescriptionFieldAsync(ptinfofields);
            await ptinfoworkflow.OpenProjectTemplatePageFillPTDescriptionAsync(description: "For Automation testing purpose");
            await ptinfoworkflow.OpenSystemSuiteSelectionPopupAsync();
            await CreateProjectTemplateAssertions.VerifySystemSuiteSelectionPopupAsync(ptinfofields);

            await ptinfoworkflow.SelectSystemSuiteAsync();
            await ptinfofields.SS2023Selected.IsVisibleAsync();
            await CreateProjectTemplateAssertions.VerifySystemSuiteSelectionPopupAsync(ptinfofields);
            await ptinfoworkflow.SelectSystemSuiteOKButtonAsync();

            await CreateProjectTemplateAssertions.VerifyProjectTemplateDefaultHostingRegionFieldAsync(ptinfofields);
            await ptinfoworkflow.OpenDefaultHostingRegionPopupAsync();
            await CreateProjectTemplateAssertions.VerifyDefaultHostingRegionDropdownList(ptinfofields);
            await ptinfoworkflow.SelectHostingRegionOptionAsync();

            await CreateProjectTemplateAssertions.VerifyProjectTemplateInfoPageButtonsAsync(ptinfofields);
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_ProjectTemplateInfo_FilledFields.png"
            });
            await ptinfoworkflow.SelectProjectTemplateInfoNextButtonAsync();
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenNodeConfigurationPage_ShouldContain_AllFileds(string role)
        {
            var nodeconfigfields = new CreateProjectTemplatePage(Page);
            var nodeconfigfieldsworkflow = new CreateProjectTemplateWorkflow(Page);

            await CreateProjectTemplateAssertions.VerifyCreateProjectTemplateButtonAsync(nodeconfigfields);
            await nodeconfigfieldsworkflow.OpenProjectTemplatePageAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(nodeconfigfields);
            await CreateProjectTemplateAssertions.VerifyProjectTemplateNameFieldAsync(nodeconfigfields);

            await nodeconfigfieldsworkflow.OpenProjectTemplatePageFillPTNameAsync(PTName: "TestAutomation");
            await CreateProjectTemplateAssertions.VerifyProjectTemplateDescriptionFieldAsync(nodeconfigfields);
            await nodeconfigfieldsworkflow.OpenProjectTemplatePageFillPTDescriptionAsync(description: "For Automation testing purpose");

            await CreateProjectTemplateAssertions.VerifyProjectTemplateSystemSuiteFieldAsync(nodeconfigfields);
            await nodeconfigfieldsworkflow.OpenSystemSuiteSelectionPopupAsync();
            await CreateProjectTemplateAssertions.VerifySystemSuiteSelectionPopupAsync(nodeconfigfields);

            await nodeconfigfieldsworkflow.SelectSystemSuiteAsync();
            await nodeconfigfields.SS2023Selected.IsVisibleAsync();

            await nodeconfigfieldsworkflow.SelectSystemSuiteOKButtonAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(nodeconfigfields);
            
            await CreateProjectTemplateAssertions.VerifyProjectTemplateDefaultHostingRegionFieldAsync(nodeconfigfields);

            await nodeconfigfieldsworkflow.OpenDefaultHostingRegionPopupAsync();
            await CreateProjectTemplateAssertions.VerifyDefaultHostingRegionDropdownList(nodeconfigfields);
            await nodeconfigfieldsworkflow.SelectHostingRegionOptionAsync();

            await CreateProjectTemplateAssertions.VerifyProjectTemplateInfoPageButtonsAsync(nodeconfigfields);
            await nodeconfigfieldsworkflow.SelectProjectTemplateInfoNextButtonAsync();

            await Page.WaitForLoadStateAsync();
            await nodeconfigfields.CreaterProjectTemplatePage.WaitForAsync();

            await CreateProjectTemplateAssertions.VerifyNodeConfigurationTitleAndHeaderAsync(nodeconfigfields);
            await CreateProjectTemplateAssertions.VerifyNodeConfigurationTableHeaderAsync(nodeconfigfields);

            var emptyrows = await nodeconfigfields.NodeConfigPageTableRows.InnerTextAsync();
            Assert.That(emptyrows, Is.EqualTo("You have no nodes."));
  
            await CreateProjectTemplateAssertions.VerifyNodeConfigurationPageButtonsAsync(nodeconfigfields);
            await nodeconfigfields.CreaterProjectTemplatePage.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NodeConfigurationPage.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenAddNodeButton_ShouldValidate_AddNodePopup(string role)
        {
            var addnode = new CreateProjectTemplatePage(Page);
            await Expect(addnode.CreateProjectTemplateButton).ToBeVisibleAsync();
            await Expect(addnode.CreateProjectTemplateButton).ToBeEnabledAsync();
            await addnode.CreateProjectTemplateButton.ClickAsync();

            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateInformationPage).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateNameTextBox).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateNameTextBoxEdit).ToBeEditableAsync();
            await addnode.ProjectTemplateNameTextBoxEdit.FillAsync("Test Template");

            await Expect(addnode.DescriptionTextBox).ToBeVisibleAsync();
            await Expect(addnode.DescriptionTextBoxEdit).ToBeVisibleAsync();
            await Expect(addnode.DescriptionTextBoxEdit).ToBeEditableAsync();
            await addnode.DescriptionTextBoxEdit.FillAsync("For Automation testing purpose");

            await addnode.SystemSuiteDefinitionDropDownIcon.ClickAsync();
            await Expect(addnode.SystemSuiteSelectionDialog).ToBeVisibleAsync();
            await Expect(addnode.SS2023).ToBeVisibleAsync();
            await addnode.SS2023.ClickAsync();
            await addnode.SS2023Selected.IsVisibleAsync();
            await Expect(addnode.SSOkButton).ToBeVisibleAsync();
            await addnode.SSOkButton.ClickAsync();

            await Expect(addnode.DefaultHostingRegionTextBox).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionTextBox).ToBeEditableAsync();
            await Expect(addnode.DefaultHostingRegionHelperText).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionDropDownIcon).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionDropDownIcon).ToBeEnabledAsync();
            await addnode.DefaultHostingRegionTextBox.ClickAsync();
            await Expect(addnode.HostingRegionListBox).ToBeVisibleAsync();
            await addnode.HostingRegions.ClickAsync();

            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.PTInfoNextButton).ToBeEnabledAsync();
            await addnode.PTInfoNextButton.ClickAsync();

            await addnode.CreaterProjectTemplatePage.WaitForAsync();
            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.NodeConfigSubTitle).ToBeVisibleAsync();
            await Expect(addnode.NodeConfigSubTitle).ToBeVisibleAsync();
            await Expect(addnode.AddNodeButton).ToBeVisibleAsync();
            await Expect(addnode.AddNodeButton).ToBeEnabledAsync();

            await addnode.AddNodeButton.ClickAsync();
            await Expect(addnode.AddNodeDialog).ToBeVisibleAsync();
            await Expect(addnode.AddNodeDialogContent).ToBeVisibleAsync();
            await Expect(addnode.AddNodeTitle).ToBeVisibleAsync();
            await Expect(addnode.NodeNameTextBox).ToBeVisibleAsync();
            await Expect(addnode.NodeNameTextBox).ToBeEnabledAsync();

            await Expect(addnode.NodeTypeTextBox).ToBeVisibleAsync();
            await Expect(addnode.NodeTypeText).ToBeVisibleAsync();
            await Expect(addnode.NodeTypeDropDownIcon).ToBeVisibleAsync();
            await Expect(addnode.NodeTypeText).ToBeEditableAsync();

            await Expect(addnode.MachineTypeToolTip).ToBeVisibleAsync();
            await addnode.MachineTypeToolTip.HoverAsync();
            await addnode.MachineTypeToolTip.WaitForAsync();
            await addnode.MachineTypeToolTipBox.WaitForAsync();
            await Expect(addnode.MachineTypeToolTipBox).ToBeVisibleAsync();

            await Expect(addnode.MachineTypeTextBox).ToBeVisibleAsync();
            await Expect(addnode.MachineTypeText).ToBeVisibleAsync();
            await Expect(addnode.MachineTypeSize).ToBeVisibleAsync();
            await Expect(addnode.MachineTypeDropDown).ToBeVisibleAsync();
            await Expect(addnode.MachineTypeDropDown).ToBeEnabledAsync();

            await Expect(addnode.AddNodeNICsCheckBox).ToBeVisibleAsync();
            await Expect(addnode.AddNodeNICsCheckBox).ToBeCheckedAsync();
            await Expect(addnode.EnableMultiNICsText).ToBeVisibleAsync();

            await Expect(addnode.AddNodeCancelButton).ToBeVisibleAsync();
            await Expect(addnode.AddNodeCancelButton).ToBeEnabledAsync();
            await Expect(addnode.AddNodeAddButton).ToBeVisibleAsync();
            await Expect(addnode.AddNodeAddButton).ToBeEnabledAsync();

            await addnode.AddNodeDialog.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_AddNodeDialog.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenAddNodePopup_ShouldContain_NodeTypeDropdownList(string role)
        {
            var addnode = new CreateProjectTemplatePage(Page);
            await Expect(addnode.CreateProjectTemplateButton).ToBeVisibleAsync();
            await Expect(addnode.CreateProjectTemplateButton).ToBeEnabledAsync();
            await addnode.CreateProjectTemplateButton.ClickAsync();

            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateInformationPage).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateNameTextBox).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateNameTextBoxEdit).ToBeEditableAsync();
            await addnode.ProjectTemplateNameTextBoxEdit.FillAsync("Test Template");

            await Expect(addnode.DescriptionTextBox).ToBeVisibleAsync();
            await Expect(addnode.DescriptionTextBoxEdit).ToBeVisibleAsync();
            await Expect(addnode.DescriptionTextBoxEdit).ToBeEditableAsync();
            await addnode.DescriptionTextBoxEdit.FillAsync("For Automation testing purpose");

            await addnode.SystemSuiteDefinitionDropDownIcon.ClickAsync();
            await Expect(addnode.SystemSuiteSelectionDialog).ToBeVisibleAsync();
            await Expect(addnode.SS2023).ToBeVisibleAsync();
            await addnode.SS2023.ClickAsync();
            await addnode.SS2023Selected.IsVisibleAsync();
            await Expect(addnode.SSOkButton).ToBeVisibleAsync();
            await addnode.SSOkButton.ClickAsync();

            await Expect(addnode.DefaultHostingRegionTextBox).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionTextBox).ToBeEditableAsync();
            await Expect(addnode.DefaultHostingRegionHelperText).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionDropDownIcon).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionDropDownIcon).ToBeEnabledAsync();
            await addnode.DefaultHostingRegionTextBox.ClickAsync();
            await Expect(addnode.HostingRegionListBox).ToBeVisibleAsync();
            await addnode.HostingRegions.ClickAsync();

            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.PTInfoNextButton).ToBeEnabledAsync();
            await addnode.PTInfoNextButton.ClickAsync();

            await addnode.CreaterProjectTemplatePage.WaitForAsync();
            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.NodeConfigSubTitle).ToBeVisibleAsync();
            await Expect(addnode.NodeConfigSubTitle).ToBeVisibleAsync();
            await Expect(addnode.AddNodeButton).ToBeVisibleAsync();
            await Expect(addnode.AddNodeButton).ToBeEnabledAsync();

            await addnode.AddNodeButton.ClickAsync();
            await Expect(addnode.AddNodeDialog).ToBeVisibleAsync();
            await Expect(addnode.AddNodeDialogContent).ToBeVisibleAsync();
            await Expect(addnode.NodeTypeTextBox).ToBeVisibleAsync();
            await addnode.NodeTypeTextBox.ClickAsync();
            await Expect(addnode.NodeTypeDropDownList).ToBeVisibleAsync();

            await addnode.NodeTypeDropDownList.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NodeTypeList.png"
            });

        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenAddNodePopup_ShouldContain_MachineTypeDropDownlist(string role)
        {
            var addnode = new CreateProjectTemplatePage(Page);
            await Expect(addnode.CreateProjectTemplateButton).ToBeVisibleAsync();
            await Expect(addnode.CreateProjectTemplateButton).ToBeEnabledAsync();
            await addnode.CreateProjectTemplateButton.ClickAsync();

            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateInformationPage).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateNameTextBox).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateNameTextBoxEdit).ToBeEditableAsync();
            await addnode.ProjectTemplateNameTextBoxEdit.FillAsync("Test Template");

            await Expect(addnode.DescriptionTextBox).ToBeVisibleAsync();
            await Expect(addnode.DescriptionTextBoxEdit).ToBeVisibleAsync();
            await Expect(addnode.DescriptionTextBoxEdit).ToBeEditableAsync();
            await addnode.DescriptionTextBoxEdit.FillAsync("For Automation testing purpose");

            await addnode.SystemSuiteDefinitionDropDownIcon.ClickAsync();
            await Expect(addnode.SystemSuiteSelectionDialog).ToBeVisibleAsync();
            await Expect(addnode.SS2023).ToBeVisibleAsync();
            await addnode.SS2023.ClickAsync();
            await addnode.SS2023Selected.IsVisibleAsync();
            await Expect(addnode.SSOkButton).ToBeVisibleAsync();
            await addnode.SSOkButton.ClickAsync();

            await Expect(addnode.DefaultHostingRegionTextBox).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionTextBox).ToBeEditableAsync();
            await Expect(addnode.DefaultHostingRegionHelperText).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionDropDownIcon).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionDropDownIcon).ToBeEnabledAsync();
            await addnode.DefaultHostingRegionTextBox.ClickAsync();
            await Expect(addnode.HostingRegionListBox).ToBeVisibleAsync();
            await addnode.HostingRegions.ClickAsync();

            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.PTInfoNextButton).ToBeEnabledAsync();
            await addnode.PTInfoNextButton.ClickAsync();

            await addnode.CreaterProjectTemplatePage.WaitForAsync();
            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.NodeConfigSubTitle).ToBeVisibleAsync();
            await Expect(addnode.NodeConfigSubTitle).ToBeVisibleAsync();
            await Expect(addnode.AddNodeButton).ToBeVisibleAsync();
            await Expect(addnode.AddNodeButton).ToBeEnabledAsync();

            await addnode.AddNodeButton.ClickAsync();
            await Expect(addnode.AddNodeDialog).ToBeVisibleAsync();
            await Expect(addnode.AddNodeDialogContent).ToBeVisibleAsync();
            await Expect(addnode.AddNodeTitle).ToBeVisibleAsync();
            await Expect(addnode.NodeNameTextBox).ToBeVisibleAsync();
            await Expect(addnode.NodeNameTextBox).ToBeEnabledAsync();

            await Expect(addnode.NodeTypeTextBox).ToBeVisibleAsync();
            await Expect(addnode.NodeTypeText).ToBeVisibleAsync();
            await Expect(addnode.NodeTypeDropDownIcon).ToBeVisibleAsync();
            await Expect(addnode.NodeTypeText).ToBeEditableAsync();

            await Expect(addnode.MachineTypeToolTip).ToBeVisibleAsync();

            await Expect(addnode.MachineTypeTextBox).ToBeVisibleAsync();
            await Expect(addnode.MachineTypeText).ToBeVisibleAsync();
            await Expect(addnode.MachineTypeSize).ToBeVisibleAsync();
            await Expect(addnode.MachineTypeDropDown).ToBeVisibleAsync();
            await Expect(addnode.MachineTypeDropDown).ToBeEnabledAsync();

            var machinerecsize = await addnode.MachineTypeSize.InnerTextAsync();
            Console.WriteLine(machinerecsize);
            Assert.That(machinerecsize, Is.EqualTo("HighPerformance - Standard_DS3_v2"));

            await addnode.MachineTypeTextBox.ClickAsync();
            await addnode.MachineTypeDropDownList.WaitForAsync();
            await Expect(addnode.MachineTypeDropDownList).ToBeVisibleAsync();

            await addnode.MachineTypeDropDownList.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_MachineTypeList.png"
            });
        }

        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenAddNodePopup_ShouldContain_MachineToolTipList(string role)
        {
            var addnode = new CreateProjectTemplatePage(Page);
            await Expect(addnode.CreateProjectTemplateButton).ToBeVisibleAsync();
            await Expect(addnode.CreateProjectTemplateButton).ToBeEnabledAsync();
            await addnode.CreateProjectTemplateButton.ClickAsync();

            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateInformationPage).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateNameTextBox).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateNameTextBoxEdit).ToBeEditableAsync();
            await addnode.ProjectTemplateNameTextBoxEdit.FillAsync("Test Template");

            await Expect(addnode.DescriptionTextBox).ToBeVisibleAsync();
            await Expect(addnode.DescriptionTextBoxEdit).ToBeVisibleAsync();
            await Expect(addnode.DescriptionTextBoxEdit).ToBeEditableAsync();
            await addnode.DescriptionTextBoxEdit.FillAsync("For Automation testing purpose");

            await addnode.SystemSuiteDefinitionDropDownIcon.ClickAsync();
            await Expect(addnode.SystemSuiteSelectionDialog).ToBeVisibleAsync();
            await Expect(addnode.SS2023).ToBeVisibleAsync();
            await addnode.SS2023.ClickAsync();
            await addnode.SS2023Selected.IsVisibleAsync();
            await Expect(addnode.SSOkButton).ToBeVisibleAsync();
            await addnode.SSOkButton.ClickAsync();

            await Expect(addnode.DefaultHostingRegionTextBox).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionTextBox).ToBeEditableAsync();
            await Expect(addnode.DefaultHostingRegionHelperText).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionDropDownIcon).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionDropDownIcon).ToBeEnabledAsync();
            await addnode.DefaultHostingRegionTextBox.ClickAsync();
            await Expect(addnode.HostingRegionListBox).ToBeVisibleAsync();
            await addnode.HostingRegions.ClickAsync();

            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.PTInfoNextButton).ToBeEnabledAsync();
            await addnode.PTInfoNextButton.ClickAsync();

            await addnode.CreaterProjectTemplatePage.WaitForAsync();
            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.NodeConfigSubTitle).ToBeVisibleAsync();
            await Expect(addnode.NodeConfigSubTitle).ToBeVisibleAsync();
            await Expect(addnode.AddNodeButton).ToBeVisibleAsync();
            await Expect(addnode.AddNodeButton).ToBeEnabledAsync();

            await addnode.AddNodeButton.ClickAsync();
            await Expect(addnode.AddNodeDialog).ToBeVisibleAsync();
            await Expect(addnode.AddNodeDialogContent).ToBeVisibleAsync();
            await Expect(addnode.AddNodeTitle).ToBeVisibleAsync();
            await Expect(addnode.NodeNameTextBox).ToBeVisibleAsync();
            await Expect(addnode.NodeNameTextBox).ToBeEnabledAsync();

            await Expect(addnode.NodeTypeTextBox).ToBeVisibleAsync();
            await Expect(addnode.NodeTypeText).ToBeVisibleAsync();
            await Expect(addnode.NodeTypeDropDownIcon).ToBeVisibleAsync();
            await Expect(addnode.NodeTypeText).ToBeEditableAsync();

            await Expect(addnode.MachineTypeToolTip).ToBeVisibleAsync();
            await addnode.MachineTypeToolTip.HoverAsync();
            await addnode.MachineTypeToolTip.WaitForAsync();
            await addnode.MachineTypeToolTipBox.WaitForAsync();
            await Expect(addnode.MachineTypeToolTipBox).ToBeVisibleAsync();

            await Expect(addnode.MachineTypeToolTipCores).ToBeVisibleAsync();
            await Expect(addnode.MachineTypeToolTipRam).ToBeVisibleAsync();

            await addnode.MachineTypeToolTipBox.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_MachineToolTipBox" +
                ".png"
            });

        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenAddNodePopup_ShouldValidateNodetypes_And_AddANode(string role)
        {
            var addnode = new CreateProjectTemplatePage(Page);
            await Expect(addnode.CreateProjectTemplateButton).ToBeVisibleAsync();
            await Expect(addnode.CreateProjectTemplateButton).ToBeEnabledAsync();
            await addnode.CreateProjectTemplateButton.ClickAsync();

            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateInformationPage).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateNameTextBox).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateNameTextBoxEdit).ToBeEditableAsync();
            await addnode.ProjectTemplateNameTextBoxEdit.FillAsync("Test Template");

            await Expect(addnode.DescriptionTextBox).ToBeVisibleAsync();
            await Expect(addnode.DescriptionTextBoxEdit).ToBeVisibleAsync();
            await Expect(addnode.DescriptionTextBoxEdit).ToBeEditableAsync();
            await addnode.DescriptionTextBoxEdit.FillAsync("For Automation testing purpose");

            await addnode.SystemSuiteDefinitionDropDownIcon.ClickAsync();
            await Expect(addnode.SystemSuiteSelectionDialog).ToBeVisibleAsync();
            await Expect(addnode.SS2023).ToBeVisibleAsync();
            await addnode.SS2023.ClickAsync();
            await addnode.SS2023Selected.IsVisibleAsync();
            await Expect(addnode.SSOkButton).ToBeVisibleAsync();
            await addnode.SSOkButton.ClickAsync();

            await Expect(addnode.DefaultHostingRegionTextBox).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionTextBox).ToBeEditableAsync();
            await Expect(addnode.DefaultHostingRegionHelperText).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionDropDownIcon).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionDropDownIcon).ToBeEnabledAsync();
            await addnode.DefaultHostingRegionTextBox.ClickAsync();
            await Expect(addnode.HostingRegionListBox).ToBeVisibleAsync();
            await addnode.HostingRegions.ClickAsync();

            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.PTInfoNextButton).ToBeEnabledAsync();
            await addnode.PTInfoNextButton.ClickAsync();

            await addnode.CreaterProjectTemplatePage.WaitForAsync();
            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.NodeConfigSubTitle).ToBeVisibleAsync();
            await Expect(addnode.NodeConfigSubTitle).ToBeVisibleAsync();
            await Expect(addnode.AddNodeButton).ToBeVisibleAsync();
            await Expect(addnode.AddNodeButton).ToBeEnabledAsync();

            await addnode.AddNodeButton.ClickAsync();
            await Expect(addnode.AddNodeDialog).ToBeVisibleAsync();
            await Expect(addnode.AddNodeDialogContent).ToBeVisibleAsync();
            await Expect(addnode.AddNodeTitle).ToBeVisibleAsync();
            await Expect(addnode.NodeNameTextBox).ToBeVisibleAsync();
            await addnode.NodeNameTextBox.ClickAsync();

            await Expect(addnode.NodeNameTextBoxEdit).ToBeEditableAsync();
            await addnode.NodeNameTextBoxEdit.FillAsync("TestNode");

            await Expect(addnode.NodeTypeTextBox).ToBeVisibleAsync();
            await Expect(addnode.NodeTypeDropDownIcon).ToBeVisibleAsync();
            await addnode.NodeTypeTextBox.ClickAsync();
            await Expect(addnode.NodeTypeDropDownList).ToBeVisibleAsync();
            await addnode.NodeTypeDropDownList.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_the_NodeTypes.png"
            });

            var suite = SystemSuiteLoader.Load("2023.json");
            var expectedNodeTypes = suite.roles.Select(n => n.nodeType).ToList();
            var normalizeexpectedNodeTypes = expectedNodeTypes.Select(t => t.Replace("2023-", "").Trim()).ToList();
            Console.WriteLine("The Nodetypes expected from the Json file are:");
            Console.WriteLine(string.Join(", ", normalizeexpectedNodeTypes));


            var actualNodeTypes = await addnode.NodeList.AllInnerTextsAsync();
            actualNodeTypes = actualNodeTypes.Select(t => t.Replace("2023", "")).
                                              Select(t => t.Trim()).
                                              Where(t => !string.IsNullOrEmpty(t)).ToList();
            Console.WriteLine("The Nodetypes expected from the UI are:");
            Console.WriteLine(string.Join(", ", actualNodeTypes));

            CollectionAssert.AreEquivalent(normalizeexpectedNodeTypes, actualNodeTypes, "Node type dropdown values do not match system suite JSON");

            await Expect(addnode.NodeTypeSP2023).ToBeVisibleAsync();
            await addnode.NodeTypeSP2023.ClickAsync();
            await Expect(addnode.NodeTypeTextBox).ToContainTextAsync("2023-SystemPlatform");

            await addnode.AddNodeAddButton.WaitForAsync();
            await Expect(addnode.AddNodeAddButton).ToBeVisibleAsync();
            await addnode.AddNodeAddButton.ClickAsync();

            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NodePage.png"
            });

        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenNodeConfigPage_ShouldContain_NodeDetails_AfterAdding_A_Node(string role)
        {
            var addnode = new CreateProjectTemplatePage(Page);
            await Expect(addnode.CreateProjectTemplateButton).ToBeVisibleAsync();
            await Expect(addnode.CreateProjectTemplateButton).ToBeEnabledAsync();
            await addnode.CreateProjectTemplateButton.ClickAsync();

            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateInformationPage).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateNameTextBox).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateNameTextBoxEdit).ToBeEditableAsync();
            await addnode.ProjectTemplateNameTextBoxEdit.FillAsync("Test Template");

            await Expect(addnode.DescriptionTextBox).ToBeVisibleAsync();
            await Expect(addnode.DescriptionTextBoxEdit).ToBeVisibleAsync();
            await Expect(addnode.DescriptionTextBoxEdit).ToBeEditableAsync();
            await addnode.DescriptionTextBoxEdit.FillAsync("For Automation testing purpose");

            await addnode.SystemSuiteDefinitionDropDownIcon.ClickAsync();
            await Expect(addnode.SystemSuiteSelectionDialog).ToBeVisibleAsync();
            await Expect(addnode.SS2023).ToBeVisibleAsync();
            await addnode.SS2023.ClickAsync();
            await addnode.SS2023Selected.IsVisibleAsync();
            await Expect(addnode.SSOkButton).ToBeVisibleAsync();
            await addnode.SSOkButton.ClickAsync();

            await Expect(addnode.DefaultHostingRegionTextBox).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionTextBox).ToBeEditableAsync();
            await Expect(addnode.DefaultHostingRegionHelperText).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionDropDownIcon).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionDropDownIcon).ToBeEnabledAsync();
            await addnode.DefaultHostingRegionTextBox.ClickAsync();
            await Expect(addnode.HostingRegionListBox).ToBeVisibleAsync();
            await addnode.HostingRegions.ClickAsync();

            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.PTInfoNextButton).ToBeEnabledAsync();
            await addnode.PTInfoNextButton.ClickAsync();

            await addnode.CreaterProjectTemplatePage.WaitForAsync();
            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.NodeConfigSubTitle).ToBeVisibleAsync();
            await Expect(addnode.NodeConfigSubTitle).ToBeVisibleAsync();
            await Expect(addnode.AddNodeButton).ToBeVisibleAsync();
            await Expect(addnode.AddNodeButton).ToBeEnabledAsync();

            var beforecount = await Page.Locator("tbody tr").CountAsync();
            await addnode.AddNodeButton.ClickAsync();
            await Expect(addnode.AddNodeDialog).ToBeVisibleAsync();
            await Expect(addnode.AddNodeDialogContent).ToBeVisibleAsync();
            await Expect(addnode.AddNodeTitle).ToBeVisibleAsync();
            await Expect(addnode.NodeNameTextBox).ToBeVisibleAsync();
            await addnode.NodeNameTextBox.ClickAsync();

            await Expect(addnode.NodeNameTextBoxEdit).ToBeEditableAsync();
            await addnode.NodeNameTextBoxEdit.FillAsync("TestNode");

            await Expect(addnode.NodeTypeTextBox).ToBeVisibleAsync();
            await Expect(addnode.NodeTypeDropDownIcon).ToBeVisibleAsync();
            await addnode.NodeTypeTextBox.ClickAsync();
            await Expect(addnode.NodeTypeDropDownList).ToBeVisibleAsync();
            await addnode.NodeTypeDropDownList.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_the_NodeTypes.png"
            });

            var suite = SystemSuiteLoader.Load("2023.json");
            var expectedNodeTypes = suite.roles.Select(n => n.nodeType).ToList();
            var normalizeexpectedNodeTypes = expectedNodeTypes.Select(t => t.Replace("2023-", "").Trim()).ToList();
            Console.WriteLine("The Nodetypes expected from the Json file are:");
            Console.WriteLine(string.Join(", ", normalizeexpectedNodeTypes));


            var actualNodeTypes = await addnode.NodeList.AllInnerTextsAsync();
            actualNodeTypes = actualNodeTypes.Select(t => t.Replace("2023", "")).
                                              Select(t => t.Trim()).
                                              Where(t => !string.IsNullOrEmpty(t)).ToList();
            Console.WriteLine("The Nodetypes expected from the UI are:");
            Console.WriteLine(string.Join(", ", actualNodeTypes));

            CollectionAssert.AreEquivalent(normalizeexpectedNodeTypes, actualNodeTypes, "Node type dropdown values do not match system suite JSON");

            await Expect(addnode.NodeTypeSP2023).ToBeVisibleAsync();
            await addnode.NodeTypeSP2023.ClickAsync();
            await Expect(addnode.NodeTypeTextBox).ToContainTextAsync("2023-SystemPlatform");

            await addnode.AddNodeAddButton.WaitForAsync();
            await Expect(addnode.AddNodeAddButton).ToBeVisibleAsync();
            await addnode.AddNodeAddButton.ClickAsync();
            await addnode.CreaterProjectTemplatePage.WaitForAsync();
            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.AddNodeButton).ToBeEnabledAsync();

            int afterCount = await Page.Locator("tbody tr").CountAsync();
            Assert.That(afterCount, Is.EqualTo(beforecount));

            await Expect(addnode.AddedNodeRow).ToBeVisibleAsync();

            var anode = await addnode.AddedNodeRow.First.AllInnerTextsAsync();
            anode.Select(t => t.Trim())
                 .Select(t => t.Replace("  ", "")).ToList();
            Console.WriteLine(string.Join(",", anode));

            var values = new List<string> { "You have no nodes." };
            CollectionAssert.AreNotEquivalent(anode, values, "Values match");
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NewlyAdded_NodeRows.png"
            });

        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenLaunchParametersPage_ShouldContain_AllFileds(string role)
        {
            var addnode = new CreateProjectTemplatePage(Page);
            await Expect(addnode.CreateProjectTemplateButton).ToBeVisibleAsync();
            await Expect(addnode.CreateProjectTemplateButton).ToBeEnabledAsync();
            await addnode.CreateProjectTemplateButton.ClickAsync();

            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateInformationPage).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateNameTextBox).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateNameTextBoxEdit).ToBeEditableAsync();
            await addnode.ProjectTemplateNameTextBoxEdit.FillAsync("Test Template");

            await Expect(addnode.DescriptionTextBox).ToBeVisibleAsync();
            await Expect(addnode.DescriptionTextBoxEdit).ToBeVisibleAsync();
            await Expect(addnode.DescriptionTextBoxEdit).ToBeEditableAsync();
            await addnode.DescriptionTextBoxEdit.FillAsync("For Automation testing purpose");

            await addnode.SystemSuiteDefinitionDropDownIcon.ClickAsync();
            await Expect(addnode.SystemSuiteSelectionDialog).ToBeVisibleAsync();
            await Expect(addnode.SS2023).ToBeVisibleAsync();
            await addnode.SS2023.ClickAsync();
            await addnode.SS2023Selected.IsVisibleAsync();
            await Expect(addnode.SSOkButton).ToBeVisibleAsync();
            await addnode.SSOkButton.ClickAsync();

            await Expect(addnode.DefaultHostingRegionTextBox).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionTextBox).ToBeEditableAsync();
            await Expect(addnode.DefaultHostingRegionHelperText).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionDropDownIcon).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionDropDownIcon).ToBeEnabledAsync();
            await addnode.DefaultHostingRegionTextBox.ClickAsync();
            await Expect(addnode.HostingRegionListBox).ToBeVisibleAsync();
            await addnode.HostingRegions.ClickAsync();

            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.PTInfoNextButton).ToBeEnabledAsync();
            await addnode.PTInfoNextButton.ClickAsync();

            await addnode.CreaterProjectTemplatePage.WaitForAsync();
            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.NodeConfigSubTitle).ToBeVisibleAsync();
            await Expect(addnode.NodeConfigSubTitle).ToBeVisibleAsync();
            await Expect(addnode.AddNodeButton).ToBeVisibleAsync();
            await Expect(addnode.AddNodeButton).ToBeEnabledAsync();

            var beforecount = await Page.Locator("tbody tr").CountAsync();
            await addnode.AddNodeButton.ClickAsync();
            await Expect(addnode.AddNodeDialog).ToBeVisibleAsync();
            await Expect(addnode.AddNodeDialogContent).ToBeVisibleAsync();
            await Expect(addnode.AddNodeTitle).ToBeVisibleAsync();
            await Expect(addnode.NodeNameTextBox).ToBeVisibleAsync();
            await addnode.NodeNameTextBox.ClickAsync();

            await Expect(addnode.NodeNameTextBoxEdit).ToBeEditableAsync();
            await addnode.NodeNameTextBoxEdit.FillAsync("TestNode");

            await Expect(addnode.NodeTypeTextBox).ToBeVisibleAsync();
            await Expect(addnode.NodeTypeDropDownIcon).ToBeVisibleAsync();
            await addnode.NodeTypeTextBox.ClickAsync();
            await Expect(addnode.NodeTypeDropDownList).ToBeVisibleAsync();

            await Expect(addnode.NodeTypeSP2023).ToBeVisibleAsync();
            await addnode.NodeTypeSP2023.ClickAsync();
            await Expect(addnode.NodeTypeTextBox).ToContainTextAsync("2023-SystemPlatform");
            await Expect(addnode.AddNodeAddButton).ToBeVisibleAsync();
            await addnode.AddNodeAddButton.ClickAsync();

            await Expect(addnode.NodeConfigPageNextButton).ToBeVisibleAsync();
            await addnode.NodeConfigPageNextButton.ClickAsync();

            await Expect(addnode.LaunchParameterPage).ToBeVisibleAsync();
            await Expect(addnode.CreateProjectTemplateHeader).ToBeVisibleAsync();
            await Expect(addnode.CreateProjectTemplateHeader).ToContainTextAsync("Specify the default values for all runtime parameters for your project template's applications.\r\n");
            await Expect(addnode.LaunchParametersText).ToBeVisibleAsync();
            await Expect(addnode.LaunchParameterNodeBlock).ToBeVisibleAsync();
            await Expect(addnode.LaunchParameterNodeBody).ToBeVisibleAsync();

            await Expect(addnode.NodeConfigPagePreviousButton).ToBeVisibleAsync();
            await Expect(addnode.NodeConfigPageNextButton).ToBeVisibleAsync();
            await Expect(addnode.NodeConfigPageCancelButton).ToBeVisibleAsync();

            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_LaunchParametersPage.png"
            });
        }


        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenLaunchParametersPage_ShouldContain_LaunchParameters(string role)
        {
            var addnode = new CreateProjectTemplatePage(Page);
            await Expect(addnode.CreateProjectTemplateButton).ToBeVisibleAsync();
            await Expect(addnode.CreateProjectTemplateButton).ToBeEnabledAsync();
            await addnode.CreateProjectTemplateButton.ClickAsync();

            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateInformationPage).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateNameTextBox).ToBeVisibleAsync();
            await Expect(addnode.ProjectTemplateNameTextBoxEdit).ToBeEditableAsync();
            await addnode.ProjectTemplateNameTextBoxEdit.FillAsync("Test Template");

            await Expect(addnode.DescriptionTextBox).ToBeVisibleAsync();
            await Expect(addnode.DescriptionTextBoxEdit).ToBeVisibleAsync();
            await Expect(addnode.DescriptionTextBoxEdit).ToBeEditableAsync();
            await addnode.DescriptionTextBoxEdit.FillAsync("For Automation testing purpose");

            await addnode.SystemSuiteDefinitionDropDownIcon.ClickAsync();
            await Expect(addnode.SystemSuiteSelectionDialog).ToBeVisibleAsync();
            await Expect(addnode.SS2023).ToBeVisibleAsync();
            await addnode.SS2023.ClickAsync();
            await addnode.SS2023Selected.IsVisibleAsync();
            await Expect(addnode.SSOkButton).ToBeVisibleAsync();
            await addnode.SSOkButton.ClickAsync();

            await Expect(addnode.DefaultHostingRegionTextBox).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionTextBox).ToBeEditableAsync();
            await Expect(addnode.DefaultHostingRegionHelperText).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionDropDownIcon).ToBeVisibleAsync();
            await Expect(addnode.DefaultHostingRegionDropDownIcon).ToBeEnabledAsync();
            await addnode.DefaultHostingRegionTextBox.ClickAsync();
            await Expect(addnode.HostingRegionListBox).ToBeVisibleAsync();
            await addnode.HostingRegions.ClickAsync();

            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.PTInfoNextButton).ToBeEnabledAsync();
            await addnode.PTInfoNextButton.ClickAsync();

            await addnode.CreaterProjectTemplatePage.WaitForAsync();
            await Expect(addnode.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(addnode.NodeConfigSubTitle).ToBeVisibleAsync();
            await Expect(addnode.NodeConfigSubTitle).ToBeVisibleAsync();
            await Expect(addnode.AddNodeButton).ToBeVisibleAsync();
            await Expect(addnode.AddNodeButton).ToBeEnabledAsync();

            var beforecount = await Page.Locator("tbody tr").CountAsync();
            await addnode.AddNodeButton.ClickAsync();
            await Expect(addnode.AddNodeDialog).ToBeVisibleAsync();
            await Expect(addnode.AddNodeDialogContent).ToBeVisibleAsync();
            await Expect(addnode.AddNodeTitle).ToBeVisibleAsync();
            await Expect(addnode.NodeNameTextBox).ToBeVisibleAsync();
            await addnode.NodeNameTextBox.ClickAsync();

            await Expect(addnode.NodeNameTextBoxEdit).ToBeEditableAsync();
            await addnode.NodeNameTextBoxEdit.FillAsync("TestNode");

            var addnodetypes = new List<string>();

            await Expect(addnode.NodeTypeTextBox).ToBeVisibleAsync();
            await Expect(addnode.NodeTypeDropDownIcon).ToBeVisibleAsync();
            await addnode.NodeTypeTextBox.ClickAsync();
            await Expect(addnode.NodeTypeDropDownList).ToBeVisibleAsync();

            await Expect(addnode.NodeTypeSP2023).ToBeVisibleAsync();

            var selectedNodeType = (await addnode.NodeTypeSP2023.InnerTextAsync()).Trim();
            selectedNodeType = $"2023-{selectedNodeType}";

            await addnode.NodeTypeSP2023.ClickAsync();
            addnodetypes.Add(selectedNodeType);

            Console.WriteLine("Node type added:");
            foreach (var nt in addnodetypes)
            {
                Console.WriteLine($"[{nt}] length={nt.Length}");
            }

            var suite = SystemSuiteLoader.Load("2023.json");
            Console.WriteLine("NODE TYPES FROM JSON:");
            foreach (var r in suite.roles)
            {
                Console.WriteLine($"[{r.nodeType}] length={r.nodeType.Length}");
            }

            await Expect(addnode.NodeTypeTextBox).ToContainTextAsync("2023-SystemPlatform");
            await Expect(addnode.AddNodeAddButton).ToBeVisibleAsync();
            await addnode.AddNodeAddButton.ClickAsync();

            await Expect(addnode.NodeConfigPageNextButton).ToBeVisibleAsync();
            await addnode.NodeConfigPageNextButton.ClickAsync();

            await Expect(addnode.LaunchParameterPage).ToBeVisibleAsync();
            await Expect(addnode.CreateProjectTemplateHeader).ToBeVisibleAsync();

            
            var expectedLaunchParameters = suite.roles.Where(r => addnodetypes.Contains(r.nodeType))
                                               .Where(r => r.parameters != null)
                                               .SelectMany(r => r.parameters)
                                               .Select(p => p.label.Trim())
                                               .Distinct()
                                               .OrderBy(x=>x)
                                               .ToList();


            Console.WriteLine("\nFinal expected launch parameters:");
            Console.WriteLine(string.Join(", ", expectedLaunchParameters));

            var actualLaunchParameters = await Page.Locator(".node-param-field-label").AllInnerTextsAsync();
            actualLaunchParameters = actualLaunchParameters.Select(p => p.Trim()).ToList();

            Console.WriteLine("\nFinal actual launch parameters:");
            Console.WriteLine(string.Join(", ", actualLaunchParameters));

            CollectionAssert.AreEquivalent(expectedLaunchParameters, actualLaunchParameters, "Launch parameters do not match system suite definition");
        
        }

    }
}
