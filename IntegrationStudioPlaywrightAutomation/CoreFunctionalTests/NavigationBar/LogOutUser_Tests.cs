using IntegrationStudioPlaywrightAutomation.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationStudioPlaywrightAutomation.CoreFunctionalTests.NavigationBar
{
    internal class LogOutUser_Tests : BaseTest
    {


        [Test]
        public async Task Verify_LogOut_Button()
        {
            var logout = new ProjectTemplatesPage(Page);

            await Expect(logout.UserProfileIcon).ToBeVisibleAsync();
            await logout.UserProfileIcon.ClickAsync();
            await logout.UserProfilePopUp.WaitForAsync();
            await Expect(logout.UserProfilePopUp).ToBeVisibleAsync();

            await Expect(logout.LogOut).ToBeVisibleAsync();
            await logout.LogOut.ClickAsync();
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Soon_AfterClicking_Logout_Button.png"
            });
            await Page.WaitForURLAsync("https://profile.capdev-connect.aveva.com/singlesignout?returnTo**");
            await Page.WaitForLoadStateAsync();
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_AfterClicking_Logout_Button_Later.png"
            });
        }
    }
}
