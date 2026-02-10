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
using IntegrationStudioPlaywrightAutomation.WorkFlows;
using IntegrationStudioPlaywrightAutomation.Assertions;

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
            var projectadminlhsmenuworkflow = new ProjectTemplatesWorkflow(Page);

            await ProjectTemplatesAssertions.VerifyLHSMenuForProjectAdmin(projectadminlhsmenu);
            await projectadminlhsmenu.LHSMenu.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_LHSMenu_For_Admins.png"
            });

            await projectadminlhsmenuworkflow.CloseOrOpenLHSMenuAsync();
            await ProjectTemplatesAssertions.VerifyCollapseButtonContentHidden(projectadminlhsmenu);

            await projectadminlhsmenu.LHSMenu.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_Collapsed_LHSMenu_ForAdmins.png"
            });

            await projectadminlhsmenuworkflow.CloseOrOpenLHSMenuAsync();
            await ProjectTemplatesAssertions.VerifyCollapseButtonContentVisible(projectadminlhsmenu);
        }

        [Test]
        [TestCase("ProjectUser")]
        [Category("ProjectUser")]
        public async Task OpenProjectTemplatePage_ShouldContain_LHSMenu_ForProjectUser(string role)
        {
            var projectadminlhsmenu = new ProjectTemplatesPage(Page);
            var projectadminlhsmenuworkflow = new ProjectTemplatesWorkflow(Page);

            await ProjectTemplatesAssertions.VerifyLHSMenuForProjectUser(projectadminlhsmenu);
            await projectadminlhsmenu.LHSMenu.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_LHSMenu_For_ProjectUser.png"
            });

            //Click on the collapse button and check for the functionality
            await projectadminlhsmenuworkflow.CloseOrOpenLHSMenuAsync();
            await ProjectTemplatesAssertions.VerifyCollapseButtonContentHidden(projectadminlhsmenu);

            await projectadminlhsmenu.LHSMenu.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_Collapsed_LHSMenu_ForProjectUser.png"
            });

            //Click on the expand button
            await projectadminlhsmenuworkflow.CloseOrOpenLHSMenuAsync();
            await ProjectTemplatesAssertions.VerifyCollapseButtonContentVisible(projectadminlhsmenu);
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenProjectTemplatePage_ShouldContain_ProjectTemplate_Title(string role)
        {
            var pttitle = new ProjectTemplatesPage(Page);

            await ProjectTemplatesAssertions.VerifyProjectTemplatePageTitleVisible(pttitle);
            var title = await pttitle.ProjectTemplateTitle.InnerTextAsync();
            Console.WriteLine($"The Page title is :{title}");
            Assert.AreEqual(title, "Project templates");
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenProjectTemplatePage_ShouldContain_CreateProjectTemplate_Button(string role)
        {
            var createptbutton = new CreateProjectTemplatePage(Page);
            
            await CreateProjectTemplateAssertions.VerifyCreateProjectTemplateButtonAsync(createptbutton);
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
            await ProjectTemplatesAssertions.VerifyProjectTemplateTableHeaders(table);
            await table.ProjectTableColumns.ScreenshotAsync(new()
            {
                Path = "ScreenShot_Of_PTTableAndColumns_ForAll.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenProjectTemplatePage_ShouldContain_RowToolBar_PageIndicators(string role)
        {
            var ptrowtoolbar = new ProjectTemplatesPage(Page);

            await ProjectTemplatesAssertions.VerifyProjectTemplatePageRowToolBar_PageIndicators(ptrowtoolbar);
            await ptrowtoolbar.ProjectTemplateRowToolBar.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_RowToolBar.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenProjectTemplatePage_ShouldContain_PageNumberDropDownList(string role)
        {
            var pageind = new ProjectTemplatesPage(Page);
            var pageindworkflow = new ProjectTemplatesWorkflow(Page);

            await ProjectTemplatesAssertions.VerifyProjectTemplatePageRowToolBar_PageIndicators(pageind);
            await pageindworkflow.OpenPageNumberDropdownlist();
            await ProjectTemplatesAssertions.VerifyPageDropdownListNumbers(pageind);
            await pageind.ProjectTemplatePageDropdownList.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_PageNumberDropDownList.png"
            });

        }
    }
}
