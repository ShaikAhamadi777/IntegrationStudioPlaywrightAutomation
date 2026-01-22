using Microsoft.Playwright;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using IntegrationStudioPlaywrightAutomation.Locators;

namespace IntegrationStudioPlaywrightAutomation.ComponentTests
{
    public class ProjectTemplates_UI_Tests : BaseTest
    {

        [Test]
        [TestCase("SystemAdmin")]
        [TestCase("ExternalAdmin")]
        [Category("Admins")]
        public async Task OpenProjectTemplatePage_ShouldContain_LHSMenu_ForAdmins(string role)
        {
            var projectadminlhsmenu = new ProjectTemplatesPage(Page);

            await Expect(projectadminlhsmenu.ProjectTemplatePage).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.LHSMenu).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.ProjectTemplates).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.SystemSuites).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.GlobalRDPRules).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.General).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.CollapseButtonContent).ToBeVisibleAsync();
            await projectadminlhsmenu.LHSMenu.WaitForAsync();
            await projectadminlhsmenu.LHSMenu.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_LHSMenu_For_Admins.png"
            });

            //Click on the collapse button and check for the functionality
            await projectadminlhsmenu.CollapseButtonIcon.ClickAsync();
            await projectadminlhsmenu.CollapseButtonIcon.WaitForAsync();
            await Expect(projectadminlhsmenu.CollapseButtonContent).ToBeHiddenAsync();
            await projectadminlhsmenu.LHSMenu.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_Collapsed_LHSMenu_ForAdmins.png"
            });

            //Click on the expand button
            await projectadminlhsmenu.CollapseButtonIcon.ClickAsync();
            await projectadminlhsmenu.LHSMenu.WaitForAsync();
            await Expect(projectadminlhsmenu.CollapseButtonContent).ToBeVisibleAsync();
        }

        [Test]
        [TestCase("ProjectUser")]
        [Category("ProjectUser")]
        public async Task OpenProjectTemplatePage_ShouldContain_LHSMenu_ForProjectUser(string role)
        {
            var projectadminlhsmenu = new ProjectTemplatesPage(Page);

            await Expect(projectadminlhsmenu.ProjectTemplatePage).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.LHSMenu).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.ProjectTemplates).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.SystemSuites).ToBeHiddenAsync();
            await Expect(projectadminlhsmenu.GlobalRDPRules).ToBeHiddenAsync();
            await Expect(projectadminlhsmenu.General).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.CollapseButtonContent).ToBeVisibleAsync();
            await projectadminlhsmenu.LHSMenu.WaitForAsync();
            await projectadminlhsmenu.LHSMenu.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_LHSMenu_For_ProjectUser.png"
            });

            //Click on the collapse button and check for the functionality
            await projectadminlhsmenu.CollapseButtonIcon.ClickAsync();
            await projectadminlhsmenu.CollapseButtonIcon.WaitForAsync();
            await Expect(projectadminlhsmenu.CollapseButtonContent).ToBeHiddenAsync();
            await projectadminlhsmenu.LHSMenu.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_Collapsed_LHSMenu_ForProjectUser.png"
            });

            //Click on the expand button
            await projectadminlhsmenu.CollapseButtonIcon.ClickAsync();
            await projectadminlhsmenu.LHSMenu.WaitForAsync();
            await Expect(projectadminlhsmenu.CollapseButtonContent).ToBeVisibleAsync();
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenProjectTemplatePage_ShouldContain_ProjectTemplate_Title(string role)
        {
            var pttitle = new ProjectTemplatesPage(Page);

            await Expect(pttitle.ProjectTemplatePage).ToBeVisibleAsync();
            await pttitle.ProjectTemplateTitle.IsVisibleAsync();
            var title = await pttitle.ProjectTemplateTitle.InnerTextAsync();
            Console.WriteLine($"The Page title is :{title}");
            Assert.AreEqual(title, "Project templates");
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenProjectTemplatePage_ShouldContain_CreateProjectTemplate_Button(string role)
        {
            var createptbutton = new ProjectTemplatesPage(Page);
            await Expect(createptbutton.ProjectTemplatePage).ToBeVisibleAsync();
            await createptbutton.CreateProjectTemplateButton.WaitForAsync();
            await Expect(createptbutton.CreateProjectTemplateButton).ToBeVisibleAsync();
            await createptbutton.CreateProjectTemplateButton.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_CreateProjectTemplateButton.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenProjectTemplatePage_ShouldContain_PTTableAndColumnsHeadings(string role)
        {
            var table = new ProjectTemplatesPage(Page);
            await Expect(table.ProjectTemplatePage).ToBeVisibleAsync();
            await Expect(table.ProjectTemplateTable).ToBeVisibleAsync();
        }   
}
