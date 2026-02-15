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
            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(button);
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
            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(ptinfofields);
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_ProjectTemplateInfo_FilledFields.png"
            });
            await ptinfoworkflow.OpenNextPageButtonAsync();
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
            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(nodeconfigfields);
            await nodeconfigfieldsworkflow.OpenNextPageButtonAsync();

            await Page.WaitForLoadStateAsync();
            await nodeconfigfields.CreaterProjectTemplatePage.WaitForAsync();


            await CreateProjectTemplateAssertions.VerifyNodeConfigurationTitleAndHeaderAsync(nodeconfigfields);
            await CreateProjectTemplateAssertions.VerifyNodeConfigurationAddNodeButtonAsync(nodeconfigfields);
            await CreateProjectTemplateAssertions.VerifyNodeConfigurationTableHeaderAsync(nodeconfigfields);
            await CreateProjectTemplateAssertions.VerifyNodeConfigurationPageEmptyNodes(nodeconfigfields);
            await CreateProjectTemplateAssertions.VerifyPagePreviousButtonsAsync(nodeconfigfields);
            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(nodeconfigfields);
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
            var addnodeworkflow = new CreateProjectTemplateWorkflow(Page);

            await CreateProjectTemplateAssertions.VerifyCreateProjectTemplateButtonAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyProjectTemplateNameFieldAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageFillPTNameAsync(PTName: "TestAutomation");
            await CreateProjectTemplateAssertions.VerifyProjectTemplateDescriptionFieldAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageFillPTDescriptionAsync(description: "For Automation testing purpose");

            await CreateProjectTemplateAssertions.VerifyProjectTemplateSystemSuiteFieldAsync(addnode);
            await addnodeworkflow.OpenSystemSuiteSelectionPopupAsync();
            await CreateProjectTemplateAssertions.VerifySystemSuiteSelectionPopupAsync(addnode);

            await addnodeworkflow.SelectSystemSuiteAsync();
            await CreateProjectTemplateAssertions.VerifySystemSuiteSelectedFromPopUpAsync(addnode);

            await addnodeworkflow.SelectSystemSuiteOKButtonAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);

            await CreateProjectTemplateAssertions.VerifyProjectTemplateDefaultHostingRegionFieldAsync(addnode);
            await addnodeworkflow.OpenDefaultHostingRegionPopupAsync();
            await CreateProjectTemplateAssertions.VerifyDefaultHostingRegionDropdownList(addnode);
            await addnodeworkflow.SelectHostingRegionOptionAsync();

            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(addnode);
            await addnodeworkflow.OpenNextPageButtonAsync();
            await Page.WaitForLoadStateAsync();

            await CreateProjectTemplateAssertions.VerifyNodeConfigurationTitleAndHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyNodeConfigurationTableHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyNodeConfigurationAddNodeButtonAsync(addnode);

            await addnodeworkflow.OpenAddNodePopupAsync();

            await CreateProjectTemplateAssertions.VerifyAddNodePopupDialogContent(addnode);
            await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeNameTextBox(addnode);
            await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeTypeTextBox(addnode);
            await CreateProjectTemplateAssertions.VerifyAddNodePopupMachineTypeToolTip(addnode);
            await CreateProjectTemplateAssertions.VerifyAddNodePopupMachineTypeTextBox(addnode);
            await CreateProjectTemplateAssertions.VerifyAddNodePopupNICsCheckBox(addnode);
            await CreateProjectTemplateAssertions.VerifyAddNodePopupButtons(addnode);

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
            var addnodeworkflow = new CreateProjectTemplateWorkflow(Page);

            await CreateProjectTemplateAssertions.VerifyCreateProjectTemplateButtonAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyProjectTemplateNameFieldAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageFillPTNameAsync(PTName: "TestAutomation");
            await CreateProjectTemplateAssertions.VerifyProjectTemplateDescriptionFieldAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageFillPTDescriptionAsync(description: "For Automation testing purpose");

            await CreateProjectTemplateAssertions.VerifyProjectTemplateSystemSuiteFieldAsync(addnode);
            await addnodeworkflow.OpenSystemSuiteSelectionPopupAsync();
            await CreateProjectTemplateAssertions.VerifySystemSuiteSelectionPopupAsync(addnode);

            await addnodeworkflow.SelectSystemSuiteAsync();
            await CreateProjectTemplateAssertions.VerifySystemSuiteSelectedFromPopUpAsync(addnode);

            await addnodeworkflow.SelectSystemSuiteOKButtonAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);

            await CreateProjectTemplateAssertions.VerifyProjectTemplateDefaultHostingRegionFieldAsync(addnode);
            await addnodeworkflow.OpenDefaultHostingRegionPopupAsync();
            await CreateProjectTemplateAssertions.VerifyDefaultHostingRegionDropdownList(addnode);
            await addnodeworkflow.SelectHostingRegionOptionAsync();

            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(addnode);
            await addnodeworkflow.OpenNextPageButtonAsync();
            await Page.WaitForLoadStateAsync();

            await CreateProjectTemplateAssertions.VerifyNodeConfigurationTitleAndHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyNodeConfigurationTableHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyNodeConfigurationAddNodeButtonAsync(addnode);

            await addnodeworkflow.OpenAddNodePopupAsync();

            await CreateProjectTemplateAssertions.VerifyAddNodePopupDialogContent(addnode);
            await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeNameTextBox(addnode);
            await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeTypeTextBox(addnode);

            await addnodeworkflow.OpenAddNodePopupNodeTypeDropdownAsync();
            await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeTypeList(addnode);

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
            var addnodeworkflow = new CreateProjectTemplateWorkflow(Page);
            await CreateProjectTemplateAssertions.VerifyCreateProjectTemplateButtonAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyProjectTemplateNameFieldAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageFillPTNameAsync(PTName: "TestAutomation");
            await CreateProjectTemplateAssertions.VerifyProjectTemplateDescriptionFieldAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageFillPTDescriptionAsync(description: "For Automation testing purpose");

            await CreateProjectTemplateAssertions.VerifyProjectTemplateSystemSuiteFieldAsync(addnode);
            await addnodeworkflow.OpenSystemSuiteSelectionPopupAsync();
            await CreateProjectTemplateAssertions.VerifySystemSuiteSelectionPopupAsync(addnode);

            await addnodeworkflow.SelectSystemSuiteAsync();
            await CreateProjectTemplateAssertions.VerifySystemSuiteSelectedFromPopUpAsync(addnode);

            await addnodeworkflow.SelectSystemSuiteOKButtonAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);

            await CreateProjectTemplateAssertions.VerifyProjectTemplateDefaultHostingRegionFieldAsync(addnode);
            await addnodeworkflow.OpenDefaultHostingRegionPopupAsync();
            await CreateProjectTemplateAssertions.VerifyDefaultHostingRegionDropdownList(addnode);
            await addnodeworkflow.SelectHostingRegionOptionAsync();

            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(addnode); 
            await addnodeworkflow.OpenNextPageButtonAsync();
            await Page.WaitForLoadStateAsync();

            await CreateProjectTemplateAssertions.VerifyNodeConfigurationTitleAndHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyNodeConfigurationTableHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyNodeConfigurationAddNodeButtonAsync(addnode);
            await addnodeworkflow.OpenAddNodePopupAsync();

            await CreateProjectTemplateAssertions.VerifyAddNodePopupDialogContent(addnode);
            await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeNameTextBox(addnode);
            await CreateProjectTemplateAssertions.VerifyAddNodePopupMachineTypeTextBox(addnode);

            var machinerecsize = await addnode.MachineTypeSize.InnerTextAsync();
            Console.WriteLine(machinerecsize);
            Assert.That(machinerecsize, Is.EqualTo("HighPerformance - Standard_DS3_v2"));

            await addnodeworkflow.OpenAddNodePopupMachineTypeDropdownAsync();
            await CreateProjectTemplateAssertions.VerifyAddNodePopupMachineTypeDropDownList(addnode);

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
            var addnodeworkflow = new CreateProjectTemplateWorkflow(Page);
            await CreateProjectTemplateAssertions.VerifyCreateProjectTemplateButtonAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyProjectTemplateNameFieldAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageFillPTNameAsync(PTName: "TestAutomation");
            await CreateProjectTemplateAssertions.VerifyProjectTemplateDescriptionFieldAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageFillPTDescriptionAsync(description: "For Automation testing purpose");

            await CreateProjectTemplateAssertions.VerifyProjectTemplateSystemSuiteFieldAsync(addnode);
            await addnodeworkflow.OpenSystemSuiteSelectionPopupAsync();
            await CreateProjectTemplateAssertions.VerifySystemSuiteSelectionPopupAsync(addnode);

            await addnodeworkflow.SelectSystemSuiteAsync();
            await CreateProjectTemplateAssertions.VerifySystemSuiteSelectedFromPopUpAsync(addnode);

            await addnodeworkflow.SelectSystemSuiteOKButtonAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);

            await CreateProjectTemplateAssertions.VerifyProjectTemplateDefaultHostingRegionFieldAsync(addnode);
            await addnodeworkflow.OpenDefaultHostingRegionPopupAsync();
            await CreateProjectTemplateAssertions.VerifyDefaultHostingRegionDropdownList(addnode);
            await addnodeworkflow.SelectHostingRegionOptionAsync();

            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(addnode);
            await addnodeworkflow.OpenNextPageButtonAsync();
            await Page.WaitForLoadStateAsync();

            await CreateProjectTemplateAssertions.VerifyNodeConfigurationTitleAndHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyNodeConfigurationTableHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyNodeConfigurationAddNodeButtonAsync(addnode);
            await addnodeworkflow.OpenAddNodePopupAsync();

            await CreateProjectTemplateAssertions.VerifyAddNodePopupDialogContent(addnode);
            await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeNameTextBox(addnode);
            await CreateProjectTemplateAssertions.VerifyAddNodePopupMachineTypeToolTip(addnode);
            await CreateProjectTemplateAssertions.VerifyAddNodePopupMachineTypeToolTipBox(addnode);
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
            var addnodeworkflow = new CreateProjectTemplateWorkflow(Page);
            await CreateProjectTemplateAssertions.VerifyCreateProjectTemplateButtonAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyProjectTemplateNameFieldAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageFillPTNameAsync(PTName: "TestAutomation");
            await CreateProjectTemplateAssertions.VerifyProjectTemplateDescriptionFieldAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageFillPTDescriptionAsync(description: "For Automation testing purpose");

            await CreateProjectTemplateAssertions.VerifyProjectTemplateSystemSuiteFieldAsync(addnode);
            await addnodeworkflow.OpenSystemSuiteSelectionPopupAsync();
            await CreateProjectTemplateAssertions.VerifySystemSuiteSelectionPopupAsync(addnode);

            await addnodeworkflow.SelectSystemSuiteAsync();
            await CreateProjectTemplateAssertions.VerifySystemSuiteSelectedFromPopUpAsync(addnode);

            await addnodeworkflow.SelectSystemSuiteOKButtonAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);

            await CreateProjectTemplateAssertions.VerifyProjectTemplateDefaultHostingRegionFieldAsync(addnode);
            await addnodeworkflow.OpenDefaultHostingRegionPopupAsync();
            await CreateProjectTemplateAssertions.VerifyDefaultHostingRegionDropdownList(addnode);
            await addnodeworkflow.SelectHostingRegionOptionAsync();

            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(addnode);
            await addnodeworkflow.OpenNextPageButtonAsync();
            await Page.WaitForLoadStateAsync();

            await CreateProjectTemplateAssertions.VerifyNodeConfigurationTitleAndHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyNodeConfigurationTableHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyNodeConfigurationAddNodeButtonAsync(addnode);
            await addnodeworkflow.OpenAddNodePopupAsync();

            await CreateProjectTemplateAssertions.VerifyAddNodePopupDialogContent(addnode);
            await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeNameTextBox(addnode);
            await addnodeworkflow.OpenAddNodePopupNodeNameAsync(nodename: "TestNode");
            await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeTypeTextBox(addnode);

            await addnodeworkflow.OpenAddNodePopupNodeTypeDropdownAsync();
            
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

            await CreateProjectTemplateAssertions.VerifyAddNodePopupButtons(addnode);
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
                var addnodeworkflow = new CreateProjectTemplateWorkflow(Page);
                await CreateProjectTemplateAssertions.VerifyCreateProjectTemplateButtonAsync(addnode);
                await addnodeworkflow.OpenProjectTemplatePageAsync();
                await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);
                await CreateProjectTemplateAssertions.VerifyProjectTemplateNameFieldAsync(addnode);
                await addnodeworkflow.OpenProjectTemplatePageFillPTNameAsync(PTName: "TestAutomation");
                await CreateProjectTemplateAssertions.VerifyProjectTemplateDescriptionFieldAsync(addnode);
                await addnodeworkflow.OpenProjectTemplatePageFillPTDescriptionAsync(description: "For Automation testing purpose");

                await CreateProjectTemplateAssertions.VerifyProjectTemplateSystemSuiteFieldAsync(addnode);
                await addnodeworkflow.OpenSystemSuiteSelectionPopupAsync();
                await CreateProjectTemplateAssertions.VerifySystemSuiteSelectionPopupAsync(addnode);

                await addnodeworkflow.SelectSystemSuiteAsync();
                await CreateProjectTemplateAssertions.VerifySystemSuiteSelectedFromPopUpAsync(addnode);

                await addnodeworkflow.SelectSystemSuiteOKButtonAsync();
                await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);

                await CreateProjectTemplateAssertions.VerifyProjectTemplateDefaultHostingRegionFieldAsync(addnode);
                await addnodeworkflow.OpenDefaultHostingRegionPopupAsync();
                await CreateProjectTemplateAssertions.VerifyDefaultHostingRegionDropdownList(addnode);
                await addnodeworkflow.SelectHostingRegionOptionAsync();

            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(addnode); 
            await addnodeworkflow.OpenNextPageButtonAsync();
                await Page.WaitForLoadStateAsync();

                await CreateProjectTemplateAssertions.VerifyNodeConfigurationTitleAndHeaderAsync(addnode);
                await CreateProjectTemplateAssertions.VerifyNodeConfigurationTableHeaderAsync(addnode);
                await CreateProjectTemplateAssertions.VerifyNodeConfigurationAddNodeButtonAsync(addnode);
            
            var beforecount = await Page.Locator("tbody tr").CountAsync();

            await addnodeworkflow.OpenAddNodePopupAsync();

            await CreateProjectTemplateAssertions.VerifyAddNodePopupDialogContent(addnode);
            await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeNameTextBox(addnode);
            await addnodeworkflow.OpenAddNodePopupNodeNameAsync(nodename: "TestNode");
            await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeTypeTextBox(addnode);
            await addnodeworkflow.OpenAddNodePopupNodeTypeDropdownAsync();

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

            await CreateProjectTemplateAssertions.VerifyAddNodePopupButtons(addnode);
            await addnodeworkflow.CloseAddNodePopupAsync();
            await CreateProjectTemplateAssertions.VerifyNodeConfigurationAddNodeButtonAsync(addnode);

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
                var addnodeworkflow = new CreateProjectTemplateWorkflow(Page);
                await CreateProjectTemplateAssertions.VerifyCreateProjectTemplateButtonAsync(addnode);
                await addnodeworkflow.OpenProjectTemplatePageAsync();
                await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);
                await CreateProjectTemplateAssertions.VerifyProjectTemplateNameFieldAsync(addnode);
                await addnodeworkflow.OpenProjectTemplatePageFillPTNameAsync(PTName: "TestAutomation");
                await CreateProjectTemplateAssertions.VerifyProjectTemplateDescriptionFieldAsync(addnode);
                await addnodeworkflow.OpenProjectTemplatePageFillPTDescriptionAsync(description: "For Automation testing purpose");

                await CreateProjectTemplateAssertions.VerifyProjectTemplateSystemSuiteFieldAsync(addnode);
                await addnodeworkflow.OpenSystemSuiteSelectionPopupAsync();
                await CreateProjectTemplateAssertions.VerifySystemSuiteSelectionPopupAsync(addnode);

                await addnodeworkflow.SelectSystemSuiteAsync();
                await CreateProjectTemplateAssertions.VerifySystemSuiteSelectedFromPopUpAsync(addnode);

                await addnodeworkflow.SelectSystemSuiteOKButtonAsync();
                await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);

                await CreateProjectTemplateAssertions.VerifyProjectTemplateDefaultHostingRegionFieldAsync(addnode);
                await addnodeworkflow.OpenDefaultHostingRegionPopupAsync();
                await CreateProjectTemplateAssertions.VerifyDefaultHostingRegionDropdownList(addnode);
                await addnodeworkflow.SelectHostingRegionOptionAsync();

            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(addnode);
            await addnodeworkflow.OpenNextPageButtonAsync();
                await Page.WaitForLoadStateAsync();

                await CreateProjectTemplateAssertions.VerifyNodeConfigurationTitleAndHeaderAsync(addnode);
                await CreateProjectTemplateAssertions.VerifyNodeConfigurationTableHeaderAsync(addnode);
                await CreateProjectTemplateAssertions.VerifyNodeConfigurationAddNodeButtonAsync(addnode);

                var beforecount = await Page.Locator("tbody tr").CountAsync();
                await addnodeworkflow.OpenAddNodePopupAsync();

                await CreateProjectTemplateAssertions.VerifyAddNodePopupDialogContent(addnode);
                await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeNameTextBox(addnode);
                await addnodeworkflow.OpenAddNodePopupNodeNameAsync(nodename: "TestNode");
                await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeTypeTextBox(addnode);
                await addnodeworkflow.OpenAddNodePopupNodeTypeDropdownAsync();


            await Expect(addnode.NodeTypeSP2023).ToBeVisibleAsync();
            await addnode.NodeTypeSP2023.ClickAsync();
            await Expect(addnode.NodeTypeTextBox).ToContainTextAsync("2023-SystemPlatform");

            await CreateProjectTemplateAssertions.VerifyAddNodePopupButtons(addnode);
            await addnodeworkflow.CloseAddNodePopupAsync();

            await CreateProjectTemplateAssertions.VerifyPagePreviousButtonsAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(addnode);
            await addnodeworkflow.OpenNextPageButtonAsync();

            await CreateProjectTemplateAssertions.VerifyLaunchParametersPage(addnode);
            await CreateProjectTemplateAssertions.VerifyPagePreviousButtonsAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(addnode);
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
                var addnodeworkflow = new CreateProjectTemplateWorkflow(Page);
                await CreateProjectTemplateAssertions.VerifyCreateProjectTemplateButtonAsync(addnode);
                await addnodeworkflow.OpenProjectTemplatePageAsync();
                await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);
                await CreateProjectTemplateAssertions.VerifyProjectTemplateNameFieldAsync(addnode);
                await addnodeworkflow.OpenProjectTemplatePageFillPTNameAsync(PTName: "TestAutomation");
                await CreateProjectTemplateAssertions.VerifyProjectTemplateDescriptionFieldAsync(addnode);
                await addnodeworkflow.OpenProjectTemplatePageFillPTDescriptionAsync(description: "For Automation testing purpose");

                await CreateProjectTemplateAssertions.VerifyProjectTemplateSystemSuiteFieldAsync(addnode);
                await addnodeworkflow.OpenSystemSuiteSelectionPopupAsync();
                await CreateProjectTemplateAssertions.VerifySystemSuiteSelectionPopupAsync(addnode);

                await addnodeworkflow.SelectSystemSuiteAsync();
                await CreateProjectTemplateAssertions.VerifySystemSuiteSelectedFromPopUpAsync(addnode);

                await addnodeworkflow.SelectSystemSuiteOKButtonAsync();
                await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);

                await CreateProjectTemplateAssertions.VerifyProjectTemplateDefaultHostingRegionFieldAsync(addnode);
                await addnodeworkflow.OpenDefaultHostingRegionPopupAsync();
                await CreateProjectTemplateAssertions.VerifyDefaultHostingRegionDropdownList(addnode);
                await addnodeworkflow.SelectHostingRegionOptionAsync();

            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(addnode);
            await addnodeworkflow.OpenNextPageButtonAsync();
                await Page.WaitForLoadStateAsync();

                await CreateProjectTemplateAssertions.VerifyNodeConfigurationTitleAndHeaderAsync(addnode);
                await CreateProjectTemplateAssertions.VerifyNodeConfigurationTableHeaderAsync(addnode);
                await CreateProjectTemplateAssertions.VerifyNodeConfigurationAddNodeButtonAsync(addnode);

            var beforecount = await Page.Locator("tbody tr").CountAsync();
            await addnodeworkflow.OpenAddNodePopupAsync();

            await CreateProjectTemplateAssertions.VerifyAddNodePopupDialogContent(addnode);
            await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeNameTextBox(addnode);
            await addnodeworkflow.OpenAddNodePopupNodeNameAsync(nodename: "TestNode");
            await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeTypeTextBox(addnode);
            await addnodeworkflow.OpenAddNodePopupNodeTypeDropdownAsync();

            var addnodetypes = new List<string>();

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

            await CreateProjectTemplateAssertions.VerifyAddNodePopupButtons(addnode);
            await addnodeworkflow.CloseAddNodePopupAsync();

            await CreateProjectTemplateAssertions.VerifyPagePreviousButtonsAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(addnode);
            await addnodeworkflow.OpenNextPageButtonAsync();
            await CreateProjectTemplateAssertions.VerifyLaunchParametersPage(addnode);
            
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


        /*[Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenLaunchParametersPage_ShouldContain_ToggleButtonsAndHelperText(string role)
        {
            
                var addnode = new CreateProjectTemplatePage(Page);
                var addnodeworkflow = new CreateProjectTemplateWorkflow(Page);
                await CreateProjectTemplateAssertions.VerifyCreateProjectTemplateButtonAsync(addnode);
                await addnodeworkflow.OpenProjectTemplatePageAsync();
                await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);
                await CreateProjectTemplateAssertions.VerifyProjectTemplateNameFieldAsync(addnode);
                await addnodeworkflow.OpenProjectTemplatePageFillPTNameAsync(PTName: "TestAutomation");
                await CreateProjectTemplateAssertions.VerifyProjectTemplateDescriptionFieldAsync(addnode);
                await addnodeworkflow.OpenProjectTemplatePageFillPTDescriptionAsync(description: "For Automation testing purpose");

                await CreateProjectTemplateAssertions.VerifyProjectTemplateSystemSuiteFieldAsync(addnode);
                await addnodeworkflow.OpenSystemSuiteSelectionPopupAsync();
                await CreateProjectTemplateAssertions.VerifySystemSuiteSelectionPopupAsync(addnode);

                await addnodeworkflow.SelectSystemSuiteAsync();
                await CreateProjectTemplateAssertions.VerifySystemSuiteSelectedFromPopUpAsync(addnode);

                await addnodeworkflow.SelectSystemSuiteOKButtonAsync();
                await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);

                await CreateProjectTemplateAssertions.VerifyProjectTemplateDefaultHostingRegionFieldAsync(addnode);
                await addnodeworkflow.OpenDefaultHostingRegionPopupAsync();
                await CreateProjectTemplateAssertions.VerifyDefaultHostingRegionDropdownList(addnode);
                await addnodeworkflow.SelectHostingRegionOptionAsync();

            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(addnode);
        await addnodeworkflow.SelectProjectTemplateInfoNextButtonAsync();
                await Page.WaitForLoadStateAsync();

                await CreateProjectTemplateAssertions.VerifyNodeConfigurationTitleAndHeaderAsync(addnode);
                await CreateProjectTemplateAssertions.VerifyNodeConfigurationTableHeaderAsync(addnode);
                await CreateProjectTemplateAssertions.VerifyNodeConfigurationAddNodeButtonAsync(addnode);

                var beforecount = await Page.Locator("tbody tr").CountAsync();
                await addnodeworkflow.OpenAddNodePopupAsync();

                await CreateProjectTemplateAssertions.VerifyAddNodePopupDialogContent(addnode);
                await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeNameTextBox(addnode);
                await addnodeworkflow.OpenAddNodePopupNodeNameAsync(nodename: "TestNode");
                await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeTypeTextBox(addnode);
                await addnodeworkflow.OpenAddNodePopupNodeTypeDropdownAsync();

                var addnodetypes = new List<string>();

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

                await CreateProjectTemplateAssertions.VerifyAddNodePopupButtons(addnode);
                await addnodeworkflow.CloseAddNodePopupAsync();

            await CreateProjectTemplateAssertions.VerifyPagePreviousButtonsAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(addnode);
        await addnodeworkflow.OpenLaunchParametersPageAsync();
                await CreateProjectTemplateAssertions.VerifyLaunchParametersPage(addnode);

                var expectedLaunchParameters = suite.roles.Where(r => addnodetypes.Contains(r.nodeType))
                                                   .Where(r => r.parameters != null)
                                                   .SelectMany(r => r.parameters)
                                                   .Select(p => p.label.Trim())
                                                   .Distinct()
                                                   .OrderBy(x => x)
                                                   .ToList();

                Console.WriteLine("\nFinal expected launch parameters:");
                Console.WriteLine(string.Join(", ", expectedLaunchParameters));

                var actualLaunchParameters = await Page.Locator(".node-param-field-label").AllInnerTextsAsync();
                actualLaunchParameters = actualLaunchParameters.Select(p => p.Trim()).ToList();

                Console.WriteLine("\nFinal actual launch parameters:");
                Console.WriteLine(string.Join(", ", actualLaunchParameters));

                foreach (var param in expectedLaunchParameters)
                {
                    var section = Page.Locator(".node-section:has-text('{param.label}')");
                    await Expect(section).ToContainTextAsync(param.label);

                    if (param.parameterType == "Boolean")
                    {
                        var toggle = section.Locator("");
                        await Expect(toggle).ToBeVisibleAsync();

                        var actualState = await toggle.GetAttributeAsync("aria-checked");
                        Assert.AreEqual(param.default.ToLower(), actualState);

                    }
                    if (!string.IsNullOrEmpty(param.description))
                    {
                        await Expect(section).ToContainTextAsync(param.description);
                    }
                }
                Console.WriteLine("";)

            
        }*/


        [Test]
            [TestCase("SystemAdmin")]
            [Category("Common")]
            public async Task OpenLaunchParametersPage_ShouldContain_Buttons(string role)
            {

            var addnode = new CreateProjectTemplatePage(Page);
            var addnodeworkflow = new CreateProjectTemplateWorkflow(Page);
            await CreateProjectTemplateAssertions.VerifyCreateProjectTemplateButtonAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyProjectTemplateNameFieldAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageFillPTNameAsync(PTName: "TestAutomation");
            await CreateProjectTemplateAssertions.VerifyProjectTemplateDescriptionFieldAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageFillPTDescriptionAsync(description: "For Automation testing purpose");

            await CreateProjectTemplateAssertions.VerifyProjectTemplateSystemSuiteFieldAsync(addnode);
            await addnodeworkflow.OpenSystemSuiteSelectionPopupAsync();
            await CreateProjectTemplateAssertions.VerifySystemSuiteSelectionPopupAsync(addnode);

            await addnodeworkflow.SelectSystemSuiteAsync();
            await CreateProjectTemplateAssertions.VerifySystemSuiteSelectedFromPopUpAsync(addnode);

            await addnodeworkflow.SelectSystemSuiteOKButtonAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);

            await CreateProjectTemplateAssertions.VerifyProjectTemplateDefaultHostingRegionFieldAsync(addnode);
            await addnodeworkflow.OpenDefaultHostingRegionPopupAsync();
            await CreateProjectTemplateAssertions.VerifyDefaultHostingRegionDropdownList(addnode);
            await addnodeworkflow.SelectHostingRegionOptionAsync();

            await addnodeworkflow.OpenNextPageButtonAsync();
            await Page.WaitForLoadStateAsync();

            await CreateProjectTemplateAssertions.VerifyNodeConfigurationTitleAndHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyNodeConfigurationTableHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyNodeConfigurationAddNodeButtonAsync(addnode);

            var beforecount = await Page.Locator("tbody tr").CountAsync();
            await addnodeworkflow.OpenAddNodePopupAsync();

            await CreateProjectTemplateAssertions.VerifyAddNodePopupDialogContent(addnode);
            await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeNameTextBox(addnode);
            await addnodeworkflow.OpenAddNodePopupNodeNameAsync(nodename: "TestNode");
            await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeTypeTextBox(addnode);
            await CreateProjectTemplateAssertions.VerifyAddNodePopupButtons(addnode);
            await addnodeworkflow.CloseAddNodePopupAsync();

            await addnodeworkflow.OpenNextPageButtonAsync();
            await CreateProjectTemplateAssertions.VerifyLaunchParametersPage(addnode);
            await CreateProjectTemplateAssertions.VerifyPagePreviousButtonsAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(addnode);
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_LaunchParametersPage.png"
            });
            await addnodeworkflow.OpenNextPageButtonAsync();
        }


        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenShutdownBehaviourPageAndConfirmCompletePage_ShouldContain_FieldsAndButtons(string role)
        {

            var addnode = new CreateProjectTemplatePage(Page);
            var addnodeworkflow = new CreateProjectTemplateWorkflow(Page);
            await CreateProjectTemplateAssertions.VerifyCreateProjectTemplateButtonAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyProjectTemplateNameFieldAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageFillPTNameAsync(PTName: "TestAutomation");
            await CreateProjectTemplateAssertions.VerifyProjectTemplateDescriptionFieldAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageFillPTDescriptionAsync(description: "For Automation testing purpose");

            await CreateProjectTemplateAssertions.VerifyProjectTemplateSystemSuiteFieldAsync(addnode);
            await addnodeworkflow.OpenSystemSuiteSelectionPopupAsync();
            await CreateProjectTemplateAssertions.VerifySystemSuiteSelectionPopupAsync(addnode);

            await addnodeworkflow.SelectSystemSuiteAsync();
            await CreateProjectTemplateAssertions.VerifySystemSuiteSelectedFromPopUpAsync(addnode);

            await addnodeworkflow.SelectSystemSuiteOKButtonAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);

            await CreateProjectTemplateAssertions.VerifyProjectTemplateDefaultHostingRegionFieldAsync(addnode);
            await addnodeworkflow.OpenDefaultHostingRegionPopupAsync();
            await CreateProjectTemplateAssertions.VerifyDefaultHostingRegionDropdownList(addnode);
            await addnodeworkflow.SelectHostingRegionOptionAsync();

            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(addnode);
            await addnodeworkflow.OpenNextPageButtonAsync();
            await Page.WaitForLoadStateAsync();

            await CreateProjectTemplateAssertions.VerifyNodeConfigurationTitleAndHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyNodeConfigurationTableHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyNodeConfigurationAddNodeButtonAsync(addnode);

            var beforecount = await Page.Locator("tbody tr").CountAsync();
            await addnodeworkflow.OpenAddNodePopupAsync();

            await CreateProjectTemplateAssertions.VerifyAddNodePopupDialogContent(addnode);
            await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeNameTextBox(addnode);
            await addnodeworkflow.OpenAddNodePopupNodeNameAsync(nodename: "TestNode");
            await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeTypeTextBox(addnode);
            await CreateProjectTemplateAssertions.VerifyAddNodePopupButtons(addnode);
            await addnodeworkflow.CloseAddNodePopupAsync();

            await CreateProjectTemplateAssertions.VerifyPagePreviousButtonsAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(addnode);
            await addnodeworkflow.OpenNextPageButtonAsync();
            await CreateProjectTemplateAssertions.VerifyLaunchParametersPage(addnode);
            await CreateProjectTemplateAssertions.VerifyPagePreviousButtonsAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(addnode);
            await addnodeworkflow.OpenNextPageButtonAsync();

            await CreateProjectTemplateAssertions.VerifyShutdownBehaviourFields(addnode);
            await CreateProjectTemplateAssertions.VerifyPagePreviousButtonsAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(addnode);
            await addnodeworkflow.OpenShutdownBehaviourDropdownListAsync();
            await CreateProjectTemplateAssertions.VerifyShutdownBehaviourDropdownList(addnode);
            await addnodeworkflow.CloseShutdownBehaviourDropdownListAsync();
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_ShutdownBehaviourPage.png"
            });
            await addnodeworkflow.OpenNextPageButtonAsync();
            await CreateProjectTemplateAssertions.VerifyConfirmCompleteFields(addnode);
            await CreateProjectTemplateAssertions.VerifyPagePreviousButtonsAsync(addnode);
            await addnodeworkflow.OpenProjectVisibilityDropdown();
            await CreateProjectTemplateAssertions.VerifyProjectVisibilityDropdownList(addnode);
            await addnodeworkflow.CloseProjectVisibilityDropdownAsync();
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_ConfirmCompletePage.png"
            });
            await addnodeworkflow.CreateProjectTemplateAsync();

        }


        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenCreateSuccessfulDialog_ContainsFields(string role)
        {

            var addnode = new CreateProjectTemplatePage(Page);
            var addnodeworkflow = new CreateProjectTemplateWorkflow(Page);
            await CreateProjectTemplateAssertions.VerifyCreateProjectTemplateButtonAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyProjectTemplateNameFieldAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageFillPTNameAsync(PTName: "TestAutomation");
            await CreateProjectTemplateAssertions.VerifyProjectTemplateDescriptionFieldAsync(addnode);
            await addnodeworkflow.OpenProjectTemplatePageFillPTDescriptionAsync(description: "For Automation testing purpose");

            await CreateProjectTemplateAssertions.VerifyProjectTemplateSystemSuiteFieldAsync(addnode);
            await addnodeworkflow.OpenSystemSuiteSelectionPopupAsync();
            await CreateProjectTemplateAssertions.VerifySystemSuiteSelectionPopupAsync(addnode);

            await addnodeworkflow.SelectSystemSuiteAsync();
            await CreateProjectTemplateAssertions.VerifySystemSuiteSelectedFromPopUpAsync(addnode);

            await addnodeworkflow.SelectSystemSuiteOKButtonAsync();
            await CreateProjectTemplateAssertions.VerifyProjectTemplateTitleAndHeaderAsync(addnode);

            await CreateProjectTemplateAssertions.VerifyProjectTemplateDefaultHostingRegionFieldAsync(addnode);
            await addnodeworkflow.OpenDefaultHostingRegionPopupAsync();
            await CreateProjectTemplateAssertions.VerifyDefaultHostingRegionDropdownList(addnode);
            await addnodeworkflow.SelectHostingRegionOptionAsync();

            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(addnode);
            await addnodeworkflow.OpenNextPageButtonAsync();
            await Page.WaitForLoadStateAsync();

            await CreateProjectTemplateAssertions.VerifyNodeConfigurationTitleAndHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyNodeConfigurationTableHeaderAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyNodeConfigurationAddNodeButtonAsync(addnode);

            var beforecount = await Page.Locator("tbody tr").CountAsync();
            await addnodeworkflow.OpenAddNodePopupAsync();

            await CreateProjectTemplateAssertions.VerifyAddNodePopupDialogContent(addnode);
            await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeNameTextBox(addnode);
            await addnodeworkflow.OpenAddNodePopupNodeNameAsync(nodename: "TestNode");
            await CreateProjectTemplateAssertions.VerifyAddNodePopupNodeTypeTextBox(addnode);
            await CreateProjectTemplateAssertions.VerifyAddNodePopupButtons(addnode);
            await addnodeworkflow.CloseAddNodePopupAsync();

            await CreateProjectTemplateAssertions.VerifyPagePreviousButtonsAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(addnode);
            await addnodeworkflow.OpenNextPageButtonAsync();
            await CreateProjectTemplateAssertions.VerifyLaunchParametersPage(addnode);
            await CreateProjectTemplateAssertions.VerifyPagePreviousButtonsAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(addnode);
            await addnodeworkflow.OpenNextPageButtonAsync();

            await CreateProjectTemplateAssertions.VerifyShutdownBehaviourFields(addnode);
            await CreateProjectTemplateAssertions.VerifyPagePreviousButtonsAsync(addnode);
            await CreateProjectTemplateAssertions.VerifyPageNextCancelButtonsAsync(addnode);
            await addnodeworkflow.OpenShutdownBehaviourDropdownListAsync();
            await CreateProjectTemplateAssertions.VerifyShutdownBehaviourDropdownList(addnode);
            await addnodeworkflow.CloseShutdownBehaviourDropdownListAsync();
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_ShutdownBehaviourPage.png"
            });
            await addnodeworkflow.OpenNextPageButtonAsync();
            await CreateProjectTemplateAssertions.VerifyConfirmCompleteFields(addnode);
            await CreateProjectTemplateAssertions.VerifyPagePreviousButtonsAsync(addnode);
            await addnodeworkflow.OpenProjectVisibilityDropdown();
            await CreateProjectTemplateAssertions.VerifyProjectVisibilityDropdownList(addnode);
            await addnodeworkflow.CloseProjectVisibilityDropdownAsync();
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_ConfirmCompletePage.png"
            });
            await addnodeworkflow.CreateProjectTemplateAsync();
            await CreateProjectTemplateAssertions.VerifyCreateSuccessfulDialog(addnode);
            await addnodeworkflow.CloseCreateSuccessfulDialogAsync();
            await Page.ScreenshotAsync(new()
            {
               Path = "Screenshot_Of_CreateProjectTemplateCreationSuccessful.png"
            });

        }

    }
}
