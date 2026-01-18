using IntegrationStudioPlaywrightAutomation.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationStudioPlaywrightAutomation.ComponentTests
{
    public class NavigationBar_UI_Tests : BaseTest
    {
        [Test]
        public async Task LoginIntegrationStudio_ShouldContain_NavigationBar()
        {
            var nav = new ProjectTemplatesPage(Page);

            //Verify if the AppBar is Visible
            await nav.AppBar.FocusAsync();
            await nav.AppBar.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NavigationBar.png"
            });
            await Expect(nav.AppBar).ToBeVisibleAsync();
        }

        [Test]
        public async Task LoginIntegrationStudio_ShouldContain_NavigationBarTitle()
        {
            var AppBartitle = new ProjectTemplatesPage(Page);

            //Verify if the AppBar is Visible
            await AppBartitle.AppBar.FocusAsync();
            await AppBartitle.AppBar.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NavigationBarTitle.png"
            });
            await Expect(AppBartitle.AppBar).ToBeVisibleAsync();
            string title = await Page.TitleAsync();
            Console.WriteLine(title);
            await Expect(Page).ToHaveTitleAsync(title);
        }

        [Test]
        public async Task LoginIntegrationStudio_ShouldContain_NotificationIcon()
        {

            var NotifyIcon = new ProjectTemplatesPage(Page);
            await NotifyIcon.AppBar.FocusAsync();
            await Expect(NotifyIcon.AppBar).ToBeVisibleAsync();

            //Verify if the Notification Bell Icon is Visible
            await NotifyIcon.NotificationBellIcon.FocusAsync();
            await NotifyIcon.NotificationBellIcon.ScreenshotAsync(new()
            {
                Path = "Screeshot_Of_NotificationBellIcon.png"
            });
            await Expect(NotifyIcon.NotificationBellIcon).ToBeVisibleAsync();
        }

        [Test]
        public async Task LoginIntegrationStudio_ShouldContain_HelpIcon()
        {
            var helpicon = new ProjectTemplatesPage(Page);

            //Verify if the AppBar is Visible
            await helpicon.AppBar.FocusAsync();
            await Expect(helpicon.AppBar).ToBeVisibleAsync();
            await helpicon.AVEVAHelpIcon.WaitForAsync();

            //Verify if the AVEVA Help Icon is Visible
            await Expect(helpicon.AVEVAHelpIcon).ToBeVisibleAsync();
            await helpicon.AVEVAHelpIcon.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_AVEVAHelpIcon.png"
            });
        }

        [Test]
        public async Task LoginIntegrationStudio_ShouldContain_UserProfileIcon()
        {
            var profileicon = new ProjectTemplatesPage(Page);

            //Verify if the AppBar is Visible
            await profileicon.AppBar.FocusAsync();
            await Expect(profileicon.AppBar).ToBeVisibleAsync();

            //Verify if the User Profile Icon is Visible
            await Expect(profileicon.UserProfileIcon).ToBeVisibleAsync();
            await profileicon.UserProfileIcon.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_UserProfileIcon.png"
            });
        }

        [Test]
        public async Task OpenUserProfileIcon_ShouldContain_Elements()
        {
            var userprofileicon = new ProjectTemplatesPage(Page);

            //Check the user profile button and items in it
            await userprofileicon.UserProfileIcon.WaitForAsync();
            await Expect(userprofileicon.UserProfileIcon).ToBeVisibleAsync();
            await userprofileicon.UserProfileIcon.ClickAsync();

            //Popup appears
            await userprofileicon.UserProfilePopUp.WaitForAsync();
            await Expect(userprofileicon.UserProfilePopUp).ToBeVisibleAsync();

            var email = Page.Locator("span.mdc-list-item__text").Filter(new() { HasTextRegex = new Regex("@") });
            var tenant = email.Locator("xpath=following::span[contains(@class,'mdc-list-item__text')][1]");

            await Expect(email).ToBeVisibleAsync();
            await Expect(email).ToBeEnabledAsync();

            await tenant.WaitForAsync();
            await Expect(tenant).ToBeVisibleAsync();

            await Expect(userprofileicon.NetworkSpeedTest).ToBeVisibleAsync();
            await Expect(userprofileicon.NetworkSpeedTest).ToBeEnabledAsync();

            await Expect(userprofileicon.LogOut).ToBeVisibleAsync();
            await Expect(userprofileicon.LogOut).ToBeEnabledAsync();

            await userprofileicon.CopyRightAndLegal.WaitForAsync();
            await Expect(userprofileicon.CopyRightAndLegal).ToBeVisibleAsync();

            await userprofileicon.UserProfilePopUp.HighlightAsync();
            await userprofileicon.UserProfilePopUp.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_UserProfile_Popup.png"
            });
        }
    }
}
