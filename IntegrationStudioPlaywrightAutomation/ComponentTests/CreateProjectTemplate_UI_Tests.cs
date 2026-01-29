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


        }
}
