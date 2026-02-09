using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationStudioPlaywrightAutomation.Locators;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;


namespace IntegrationStudioPlaywrightAutomation.Assertions
{
    public static class ProjectTemplatesAssertions
    {
        public static async Task VerifyLHSMenuForProjectAdmin(ProjectTemplatesPage page)
        {
            await Expect(page.ProjectTemplatePage).ToBeVisibleAsync();
            await Expect(page.LHSMenu).ToBeVisibleAsync();
            await Expect(page.ProjectTemplates).ToBeVisibleAsync();
            await Expect(page.SystemSuites).ToBeVisibleAsync();
            await Expect(page.GlobalRDPRules).ToBeVisibleAsync();
            await Expect(page.General).ToBeVisibleAsync();
            await Expect(page.CollapseButtonContent).ToBeVisibleAsync();
            await page.LHSMenu.WaitForAsync();
        }
        public static async Task VerifyLHSMenuForProjectUser(ProjectTemplatesPage page)
        {
            await Expect(page.ProjectTemplatePage).ToBeVisibleAsync();
            await Expect(page.LHSMenu).ToBeVisibleAsync();
            await Expect(page.ProjectTemplates).ToBeVisibleAsync();
            await Expect(page.SystemSuites).ToBeHiddenAsync();
            await Expect(page.GlobalRDPRules).ToBeHiddenAsync();
            await Expect(page.General).ToBeVisibleAsync();
            await Expect(page.CollapseButtonContent).ToBeVisibleAsync();
            await page.LHSMenu.WaitForAsync();
        }
        public static async Task VerifyCollapseButtonContentHidden(ProjectTemplatesPage page)
        {
            await page.CollapseButtonIcon.WaitForAsync();
            await Expect(page.CollapseButtonContent).ToBeHiddenAsync();
        }
        public static async Task VerifyCollapseButtonContentVisible(ProjectTemplatesPage page)
        {
            await page.LHSMenu.WaitForAsync();
            await Expect(page.CollapseButtonContent).ToBeVisibleAsync();
        }
        public static async Task VerifyProjectTemplatePageTitleVisible(ProjectTemplatesPage page)
        {
            await Expect(page.ProjectTemplatePage).ToBeVisibleAsync();
            await Expect(page.ProjectTemplateTitle).ToBeVisibleAsync();
        }
    }
}
