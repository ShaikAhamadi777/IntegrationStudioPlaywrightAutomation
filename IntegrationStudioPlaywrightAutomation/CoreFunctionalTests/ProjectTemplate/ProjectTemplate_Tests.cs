using IntegrationStudioPlaywrightAutomation.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationStudioPlaywrightAutomation.CoreFunctionalTests.ProjectTemplate
{
    internal class ProjectTemplate_Tests : BaseTest
    {

        [Test]
        public async Task Verify_ProjectTemplatePage_when_no_templates_added()
        {
            var noprojecttemplates = new ProjectTemplatesPage(Page);
            await Expect(noprojecttemplates.LHSMenu).ToBeVisibleAsync();
            await Expect(noprojecttemplates.NoProjectTemplates).ToBeVisibleAsync();
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NoProjectTemplatesPage.png"
            });
        }

        [Test]
        public async Task Verify_3dots_menu_Of_ProjectTemplate()
        {
            var threedotmenu = new ProjectTemplatesPage(Page);
            int rowcount = await threedotmenu.projectrows.CountAsync();
            Assert.Greater(rowcount, 0, "No project templates are available");
            await Expect(threedotmenu.ThreeDot).ToBeVisibleAsync();
            await threedotmenu.ThreeDot.ClickAsync();

            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_3DotMenu.png"
            });

            await Expect(threedotmenu.ThreeDotmenuPopup).ToBeVisibleAsync();
            await Expect(threedotmenu.ThreeDotMenuNewinstance).ToBeVisibleAsync();
            await Expect(threedotmenu.ThreeDotMenuEdit).ToBeVisibleAsync();
            await Expect(threedotmenu.ThreeDotMenuDelete).ToBeVisibleAsync();
        }

        [Test]
        public async Task Verify_ProjectTemplates_Can_Be_Edited()
        {
            var projecttemplateedit = new ProjectTemplatesPage(Page);
            int rowcount = await projecttemplateedit.projectrows.CountAsync();
            Assert.Greater(rowcount, 0, "No project templates are available");
            await Expect(projecttemplateedit.ThreeDot).ToBeVisibleAsync();
            await projecttemplateedit.ThreeDot.ClickAsync();

            await Expect(projecttemplateedit.ThreeDotmenuPopup).ToBeVisibleAsync();
            await Expect(projecttemplateedit.ThreeDotMenuEdit).ToBeVisibleAsync();
            await projecttemplateedit.ThreeDotMenuEdit.ClickAsync();

            await projecttemplateedit.ProjectTemplateEdit.WaitForAsync();
            await Expect(projecttemplateedit.ProjectTemplateEdit).ToBeVisibleAsync();
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_EditProjectTemplate.png"
            });
        }

    }
}

