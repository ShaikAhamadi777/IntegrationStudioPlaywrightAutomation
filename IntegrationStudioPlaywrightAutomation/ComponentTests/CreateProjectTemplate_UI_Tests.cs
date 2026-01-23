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
        public async Task OpenCreateProjectTemplatePage_ShouldContain_TitleAndSubTitle(string role)
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
        }




    }
}
