using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationStudioPlaywrightAutomation.Locators;


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

            await Expect(cpttitle.ProjectTemplatePage).ToBeVisibleAsync();
            await Expect(cpttitle.CreateProjectTemplateButton).ToBeVisibleAsync();
            await Expect(cpttitle.CreateProjectTemplateButton).ToBeEnabledAsync();
            await cpttitle.CreateProjectTemplateButton.ClickAsync();
            await Expect(cpttitle.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(cpttitle.CreateProjectTemplatePageTitle).ToHaveTextAsync("Create project template");
            await Expect(cpttitle.CreateprojectTemplateSubTitle).ToBeVisibleAsync();
            await Expect(cpttitle.CreateProjectTemplateHeader).ToBeVisibleAsync();

            await cpttitle.CreateProjectTemplateHeader.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_CreateProjectTemplatePage_Header.png"
            });

            await Expect(cpttitle.CreateProjectTemplatePages).ToBeVisibleAsync();
            await Expect(cpttitle.ProjectTemplateInformationText).ToBeVisibleAsync();
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
            await Expect(ptinfopage.ProjectTemplatePage).ToBeVisibleAsync();
            await Expect(ptinfopage.CreateProjectTemplateButton).ToBeVisibleAsync();
            await Expect(ptinfopage.CreateProjectTemplateButton).ToBeEnabledAsync();
            await ptinfopage.CreateProjectTemplateButton.ClickAsync();
            await Expect(ptinfopage.CreaterProjectTemplatePage).ToBeVisibleAsync();

            await Expect(ptinfopage.ProjectTemplateInformationPage).ToBeVisibleAsync();
            await Expect(ptinfopage.ProjectTemplateNameTextBox).ToBeVisibleAsync();
            await Expect(ptinfopage.ProjectTemplateNameTextBoxEdit).ToBeVisibleAsync();
            await Expect(ptinfopage.ProjectTemplateNameTextBoxEdit).ToBeEditableAsync();
            await Expect(ptinfopage.ProjectTemplateNameHelperText).ToBeVisibleAsync();

            await Expect(ptinfopage.DescriptionTextBox).ToBeVisibleAsync();
            await Expect(ptinfopage.DescriptionTextBoxEdit).ToBeEditableAsync();

            await Expect(ptinfopage.SystemSuiteDefinitionField).ToBeVisibleAsync();
            await Expect(ptinfopage.SystemSuiteDefinitionText).ToBeVisibleAsync();
            await Expect(ptinfopage.SystemSuiteDefinitionDropDownIcon).ToBeVisibleAsync();
            await Expect(ptinfopage.SystemSuiteDefinitionDropDownIcon).ToBeEnabledAsync();
            await Expect(ptinfopage.SystemSuiteDefinitionHelperText).ToBeVisibleAsync();

            await Expect(ptinfopage.DefaultHostingRegionTextBox).ToBeVisibleAsync();
            await Expect(ptinfopage.DefaultHostingRegionTextBox).ToBeEditableAsync();
            await Expect(ptinfopage.DefaultHostingRegionHelperText).ToBeVisibleAsync();
            await Expect(ptinfopage.DefaultHostingRegionDropDownIcon).ToBeVisibleAsync();
            await Expect(ptinfopage.DefaultHostingRegionDropDownIcon).ToBeEnabledAsync();

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
            await Expect(button.ProjectTemplatePage).ToBeVisibleAsync();
            await Expect(button.CreateProjectTemplateButton).ToBeVisibleAsync();
            await Expect(button.CreateProjectTemplateButton).ToBeEnabledAsync();
            await button.CreateProjectTemplateButton.ClickAsync();
            await Expect(button.CreaterProjectTemplatePage).ToBeVisibleAsync();

            await Expect(button.ProjectTemplateInformationPage).ToBeVisibleAsync();
            await Expect(button.PTInfoCancelButton).ToBeVisibleAsync();
            await Expect(button.PTInfoCancelButton).ToBeEnabledAsync();
            await Expect(button.PTInfoNextButton).ToBeVisibleAsync();
            await Expect(button.PTInfoNextButton).ToBeEnabledAsync();

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
            await Expect(SSPopup.ProjectTemplatePage).ToBeVisibleAsync();
            await Expect(SSPopup.CreateProjectTemplateButton).ToBeVisibleAsync();
            await Expect(SSPopup.CreateProjectTemplateButton).ToBeEnabledAsync();
            await SSPopup.CreateProjectTemplateButton.ClickAsync();
            await Expect(SSPopup.CreaterProjectTemplatePage).ToBeVisibleAsync();

            await Expect(SSPopup.SystemSuiteDefinitionField).ToBeVisibleAsync();
            await Expect(SSPopup.SystemSuiteDefinitionText).ToBeVisibleAsync();
            await Expect(SSPopup.SystemSuiteDefinitionDropDownIcon).ToBeVisibleAsync();
            await Expect(SSPopup.SystemSuiteDefinitionDropDownIcon).ToBeEnabledAsync();
            await Expect(SSPopup.SystemSuiteDefinitionHelperText).ToBeVisibleAsync();

            await SSPopup.SystemSuiteDefinitionDropDownIcon.ClickAsync();
            await Expect(SSPopup.SystemSuiteSelectionDialog).ToBeVisibleAsync();
            await Expect(SSPopup.SystemSuiteSelectionHeader).ToBeVisibleAsync();
            await Expect(SSPopup.AVEVASystemSuiteHeader).ToBeVisibleAsync();
            await Expect(SSPopup.SS2023).ToBeVisibleAsync();

            await Expect(SSPopup.CustomSystemSuiteHeaer).ToBeVisibleAsync();
            await Expect(SSPopup.SSOkButton).ToBeVisibleAsync();
            await SSPopup.SSOkButton.HighlightAsync();
            await SSPopup.SSOkButton.FocusAsync();
            await Expect(SSPopup.SSCancelButton).ToBeVisibleAsync();
            await Expect(SSPopup.SSCancelButton).ToBeEnabledAsync();

            await SSPopup.SystemSuiteSelectionDialog.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_SystemSuiteSelectionPopup.png"
            }
            );
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenCreateProjectTemplatePage_ShouldContain_AllFileds(string role)
        {
            var ptinfofields = new CreateProjectTemplatePage(Page);
            await Expect(ptinfofields.ProjectTemplatePage).ToBeVisibleAsync();
            await Expect(ptinfofields.CreateProjectTemplateButton).ToBeVisibleAsync();
            await Expect(ptinfofields.CreateProjectTemplateButton).ToBeEnabledAsync();
            await ptinfofields.CreateProjectTemplateButton.ClickAsync();
            await Expect(ptinfofields.CreaterProjectTemplatePage).ToBeVisibleAsync();

            await Expect(ptinfofields.ProjectTemplateInformationPage).ToBeVisibleAsync();
            await Expect(ptinfofields.ProjectTemplateNameTextBox).ToBeVisibleAsync();
            await Expect(ptinfofields.ProjectTemplateNameTextBoxEdit).ToBeEditableAsync();
            await ptinfofields.ProjectTemplateNameTextBoxEdit.FillAsync("Test Template");

            await Expect(ptinfofields.DescriptionTextBox).ToBeVisibleAsync();
            await Expect(ptinfofields.DescriptionTextBoxEdit).ToBeVisibleAsync();
            await Expect(ptinfofields.DescriptionTextBoxEdit).ToBeEditableAsync();
            await ptinfofields.DescriptionTextBoxEdit.FillAsync("For Automation testing purpose");

            await ptinfofields.SystemSuiteDefinitionDropDownIcon.ClickAsync();
            await Expect(ptinfofields.SystemSuiteSelectionDialog).ToBeVisibleAsync();
            await Expect(ptinfofields.SystemSuiteSelectionHeader).ToBeVisibleAsync();
            await Expect(ptinfofields.AVEVASystemSuiteHeader).ToBeVisibleAsync();
            await Expect(ptinfofields.SS2023).ToBeVisibleAsync();
            await ptinfofields.SS2023.ClickAsync();
            await ptinfofields.SS2023Selected.IsVisibleAsync();
            await Expect(ptinfofields.SSOkButton).ToBeVisibleAsync();
            await ptinfofields.SSOkButton.ClickAsync();

            await Expect(ptinfofields.DefaultHostingRegionTextBox).ToBeVisibleAsync();
            await Expect(ptinfofields.DefaultHostingRegionTextBox).ToBeEditableAsync();
            await Expect(ptinfofields.DefaultHostingRegionHelperText).ToBeVisibleAsync();
            await Expect(ptinfofields.DefaultHostingRegionDropDownIcon).ToBeVisibleAsync();
            await Expect(ptinfofields.DefaultHostingRegionDropDownIcon).ToBeEnabledAsync();
            await ptinfofields.DefaultHostingRegionTextBox.ClickAsync();
            await Expect(ptinfofields.HostingRegionListBox).ToBeVisibleAsync();
            await ptinfofields.HostingRegions.ClickAsync();

            await Expect(ptinfofields.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(ptinfofields.PTInfoNextButton).ToBeEnabledAsync();
            await ptinfofields.PTInfoNextButton.ClickAsync();
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenNodeConfigurationPage_ShouldContain_AllFileds(string role)
        {
            var nodeconfigfields = new CreateProjectTemplatePage(Page);
            await Expect(nodeconfigfields.ProjectTemplatePage).ToBeVisibleAsync();
            await Expect(nodeconfigfields.CreateProjectTemplateButton).ToBeVisibleAsync();
            await Expect(nodeconfigfields.CreateProjectTemplateButton).ToBeEnabledAsync();
            await nodeconfigfields.CreateProjectTemplateButton.ClickAsync();

            await Expect(nodeconfigfields.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(nodeconfigfields.ProjectTemplateInformationPage).ToBeVisibleAsync();
            await Expect(nodeconfigfields.ProjectTemplateNameTextBox).ToBeVisibleAsync();
            await Expect(nodeconfigfields.ProjectTemplateNameTextBoxEdit).ToBeEditableAsync();
            await nodeconfigfields.ProjectTemplateNameTextBoxEdit.FillAsync("Test Template");

            await Expect(nodeconfigfields.DescriptionTextBox).ToBeVisibleAsync();
            await Expect(nodeconfigfields.DescriptionTextBoxEdit).ToBeVisibleAsync();
            await Expect(nodeconfigfields.DescriptionTextBoxEdit).ToBeEditableAsync();
            await nodeconfigfields.DescriptionTextBoxEdit.FillAsync("For Automation testing purpose");

            await nodeconfigfields.SystemSuiteDefinitionDropDownIcon.ClickAsync();
            await Expect(nodeconfigfields.SystemSuiteSelectionDialog).ToBeVisibleAsync();
            await Expect(nodeconfigfields.SS2023).ToBeVisibleAsync();
            await nodeconfigfields.SS2023.ClickAsync();
            await nodeconfigfields.SS2023Selected.IsVisibleAsync();
            await Expect(nodeconfigfields.SSOkButton).ToBeVisibleAsync();
            await nodeconfigfields.SSOkButton.ClickAsync();

            await Expect(nodeconfigfields.DefaultHostingRegionTextBox).ToBeVisibleAsync();
            await Expect(nodeconfigfields.DefaultHostingRegionTextBox).ToBeEditableAsync();
            await Expect(nodeconfigfields.DefaultHostingRegionHelperText).ToBeVisibleAsync();
            await Expect(nodeconfigfields.DefaultHostingRegionDropDownIcon).ToBeVisibleAsync();
            await Expect(nodeconfigfields.DefaultHostingRegionDropDownIcon).ToBeEnabledAsync();
            await nodeconfigfields.DefaultHostingRegionTextBox.ClickAsync();
            await Expect(nodeconfigfields.HostingRegionListBox).ToBeVisibleAsync();
            await nodeconfigfields.HostingRegions.ClickAsync();

            await Expect(nodeconfigfields.CreaterProjectTemplatePage).ToBeVisibleAsync();
            await Expect(nodeconfigfields.PTInfoNextButton).ToBeEnabledAsync();
            await nodeconfigfields.PTInfoNextButton.ClickAsync();
            await Expect(nodeconfigfields.CreaterProjectTemplatePage).ToBeVisibleAsync();

            await Expect(nodeconfigfields.NodeConfigSubTitle).ToBeVisibleAsync();
            await Expect(nodeconfigfields.NodeConfigSubTitle).ToBeVisibleAsync();
            await Expect(nodeconfigfields.AddNodeButton).ToBeVisibleAsync();
            await Expect(nodeconfigfields.AddNodeButton).ToBeEnabledAsync();

            await Expect(nodeconfigfields.NodeConfigPageTableHeader).ToBeVisibleAsync();
            await Expect(nodeconfigfields.NodeConfigPageTableNameColumn).ToBeVisibleAsync();
            await Expect(nodeconfigfields.NodeConfigPageTableTypeColumn).ToBeVisibleAsync();
            await Expect(nodeconfigfields.NodeConfigPageTableMachineTypeColumn).ToBeVisibleAsync();
            await Expect(nodeconfigfields.NodeConfigPageTableMachineConfigColumn).ToBeVisibleAsync();
            await Expect(nodeconfigfields.NodeConfigPageTableCreditsColumn).ToBeVisibleAsync();
            await Expect(nodeconfigfields.NodeConfigPageTableEnableMultiNICsColumn).ToBeVisibleAsync();

            await Expect(nodeconfigfields.NodeConfigPageTableRows).ToBeVisibleAsync();
            var emptyrows = await nodeconfigfields.NodeConfigPageTableRows.InnerTextAsync();
            //Assert.AreEqual(emptyrows, "You have no nodes.");
            Assert.That(emptyrows, Is.EqualTo("You have no nodes."));

            await Expect(nodeconfigfields.NodeConfigPagePreviousButton).ToBeVisibleAsync();
            await Expect(nodeconfigfields.NodeConfigPagePreviousButton).ToBeEnabledAsync();

            await Expect(nodeconfigfields.NodeConfigPageCancelButton).ToBeVisibleAsync();
            await Expect(nodeconfigfields.NodeConfigPageCancelButton).ToBeEnabledAsync();

            await Expect(nodeconfigfields.NodeConfigPageNextButton).ToBeVisibleAsync();
            await Expect(nodeconfigfields.NodeConfigPageNextButton).ToBeEnabledAsync();

            await nodeconfigfields.CreaterProjectTemplatePage.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NodeConfigurationPage.png"
            });

        }
    }
}
