using IntegrationStudioPlaywrightAutomation.Assertions;
using IntegrationStudioPlaywrightAutomation.Locators;
using IntegrationStudioPlaywrightAutomation.WorkFlows;
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
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task LoginIntegrationStudio_ShouldContain_NavigationBar(string role)
        {
            var nav = new NavigationBarNotificationPanelPage(Page);
            await NavigationBarNotificationPanelAssertions.VerifyAppBarIsVisible(nav);
            await nav.AppBar.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NavigationBar_ForAllRoles.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task LoginIntegrationStudio_ShouldContain_NavigationBarTitle(string role)
        {
            var AppBartitle = new NavigationBarNotificationPanelPage(Page);
            await NavigationBarNotificationPanelAssertions.VerifyAppBarIsVisible(AppBartitle);
            await AppBartitle.AppBar.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NavigationBarTitle_ForAllRoles.png"
            });
            string title = await Page.TitleAsync();
            Console.WriteLine(title);
            await Expect(Page).ToHaveTitleAsync(title);

        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task LoginIntegrationStudio_ShouldContain_NotificationIcon(string role)
        {

            var NotifyIcon = new NavigationBarNotificationPanelPage(Page);
            await NavigationBarNotificationPanelAssertions.VerifyAppBarIsVisible(NotifyIcon);
            await NavigationBarNotificationPanelAssertions.VerifyAppBarIcons(NotifyIcon);
            await NotifyIcon.NotificationBellIcon.ScreenshotAsync(new()
            {
                Path = "Screeshot_Of_NotificationBellIcon_ForAllRoles.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task LoginIntegrationStudio_ShouldContain_HelpIcon(string role)
        {
            var helpicon = new NavigationBarNotificationPanelPage(Page);
            await NavigationBarNotificationPanelAssertions.VerifyAppBarIsVisible(helpicon);
            await NavigationBarNotificationPanelAssertions.VerifyAppBarIcons(helpicon);
            await helpicon.AVEVAHelpIcon.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_AVEVAHelpIcon_ForAllRoles.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task LoginIntegrationStudio_ShouldContain_UserProfileIcon(string role)
        {
            var profileicon = new NavigationBarNotificationPanelPage(Page);
            await NavigationBarNotificationPanelAssertions.VerifyAppBarIsVisible(profileicon);
            await NavigationBarNotificationPanelAssertions.VerifyAppBarIcons(profileicon);
            await profileicon.UserProfileIcon.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_UserProfileIcon_ForAllRoles.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenUserProfileIcon_ShouldContain_Elements(string role)
        {
            var userprofileicon = new NavigationBarNotificationPanelPage(Page);
            var userprofileiconworkflow = new NavigationBarNotificationPanelWorkflow(Page);
            await NavigationBarNotificationPanelAssertions.VerifyAppBarIsVisible(userprofileicon);
            await userprofileiconworkflow.OpenUserProfilePopupAsync();

            //Popup appears
            await NavigationBarNotificationPanelAssertions.VerifyAppBarIsVisible(userprofileicon);

            var email = Page.Locator("span.mdc-list-item__text").Filter(new() { HasTextRegex = new Regex("@") });
            var tenant = email.Locator("xpath=following::span[contains(@class,'mdc-list-item__text')][1]");

            await Expect(email).ToBeVisibleAsync();
            await Expect(email).ToBeEnabledAsync();

            await tenant.WaitForAsync();
            await Expect(tenant).ToBeVisibleAsync();
            await NavigationBarNotificationPanelAssertions.VerifyUserProfileIcon(userprofileicon);
            await userprofileicon.UserProfilePopUp.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_UserProfile_Popup_ForAllRoles.png"
            });
        }
    }
}
