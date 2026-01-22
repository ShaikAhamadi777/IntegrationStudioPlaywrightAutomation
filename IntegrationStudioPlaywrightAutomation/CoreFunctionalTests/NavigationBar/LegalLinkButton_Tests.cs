using IntegrationStudioPlaywrightAutomation.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationStudioPlaywrightAutomation.CoreFunctionalTests.NavigationBar
{
    internal class LegalLinkButton_Tests : BaseTest
    {

        [Test]
        public async Task Verify_LegalLink_Button()
        {
            var legallink = new ProjectTemplatesPage(Page);
            await Expect(legallink.UserProfileIcon).ToBeVisibleAsync();
            await legallink.UserProfileIcon.ClickAsync();
            await legallink.UserProfilePopUp.WaitForAsync();
            await Expect(legallink.UserProfilePopUp).ToBeVisibleAsync();

            await Expect(legallink.CopyRightAndLegal).ToBeVisibleAsync();
            await Expect(legallink.LegalLink).ToBeEnabledAsync();

            var legallinkpage = await Page.RunAndWaitForPopupAsync(async () =>
            {
                await legallink.LegalLink.ClickAsync();
            });

            await Expect(legallinkpage).ToHaveURLAsync(new Regex(@".*/en/legal/.*"));
            await legallinkpage.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_LegalLinkPage.png"
            });
            await legallinkpage.Locator("//h1[text()='Legal Resources']").WaitForAsync();
            await Expect(legallinkpage.Locator("//h1[text()='Legal Resources']")).ToBeVisibleAsync();

        }
    }
}
