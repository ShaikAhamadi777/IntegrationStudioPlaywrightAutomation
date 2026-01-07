
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace IntegrationStudioPlaywrightAutomation
{
    [TestFixture]
    public class NavigationBarTests : BaseTest
    {
        [Test]
        public async Task NavigationBar_Should_Display_All_Elements()
        {

            var nav = new NavigationBarPage(Page);

            //NavigationBar Title
            await nav.AppBar.FocusAsync();
            await nav.AppBar.ScreenshotAsync(new()
            {
                Path = "NavigationBar.png"
            });
            await Expect(nav.AppBar).ToBeVisibleAsync();
            string title = await Page.TitleAsync();
            Console.WriteLine(title);
            await Expect(Page).ToHaveTitleAsync(title);

            //Notification Icons
            await nav.NotificationBellIcon.FocusAsync();
            await nav.NotificationBellIcon.ScreenshotAsync(new()
            {
                Path = "NotificationBellIcon.png"
            });
            await Expect(nav.NotificationBellIcon).ToBeVisibleAsync();

            //Help Icon
            await nav.AVEVAHelpIcon.ScreenshotAsync(new()
            {
                Path = "AVEVAHelpIcon.png"
            });
            await Expect(nav.AVEVAHelpIcon).ToBeVisibleAsync();

            //User Profile Icon
            await nav.UserProfileIcon.ScreenshotAsync(new()
            {
               Path = "UserProfile.png"
            });
            await Expect(nav.UserProfileIcon).ToBeVisibleAsync();
        }

        [Test]
        public async Task Verify_NotificationPanel()
        {
            var notify = new NavigationBarPage(Page);

            //Click on the Notification icon
            await notify.NotificationBellIcon.ClickAsync();
            await Expect(notify.NotificationPanel).ToBeVisibleAsync();
            await notify.NotificationPanel.ScreenshotAsync(new()
            {
                Path = "NotificationPanelPage.png"
            });

            //Fetch the number of Notifications
            await Expect(notify.NumberOfNotifications).ToBeVisibleAsync();
            var CountOfNotifications = await notify.NumberOfNotifications.CountAsync();
            Console.WriteLine($"Number of Notifications in the Panel: {CountOfNotifications}");

            var CountOfNotificationInBellIcon = await notify.NumberOfNotificationsInBellIcon.IsVisibleAsync();
            Console.WriteLine($"The Number of Notifications in the Bell Icon is : {CountOfNotificationInBellIcon}");
            Console.WriteLine(CountOfNotificationInBellIcon);

            //Check for the Clear All Button
            await Expect(notify.ClearAllButton).ToBeVisibleAsync();
            await notify.ClearAllButton.ScreenshotAsync(new()
            {
                Path = "NotificationPanelClearAllButton.png"
            });

            if(CountOfNotifications > 0)
            {
                await notify.ClearAllButton.FocusAsync();
                await Expect(notify.ClearAllButton).ToBeEnabledAsync();
            }
        }

    }
}
