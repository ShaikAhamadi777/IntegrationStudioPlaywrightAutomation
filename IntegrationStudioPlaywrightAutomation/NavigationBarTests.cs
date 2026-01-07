
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
        public async Task Verify_AppBar()
        {

            var nav = new NavigationBarPage(Page);

            //Verify if the AppBar is Visible
            await nav.AppBar.FocusAsync();
            await nav.AppBar.ScreenshotAsync(new()
            {
                Path = "NavigationBar.png"
            });
            await Expect(nav.AppBar).ToBeVisibleAsync();
            string title = await Page.TitleAsync();
            Console.WriteLine(title);
            await Expect(Page).ToHaveTitleAsync(title);

            //Verify if the Notification Bell Icon is Visible
            await nav.NotificationBellIcon.FocusAsync();
            await nav.NotificationBellIcon.ScreenshotAsync(new()
            {
                Path = "NotificationBellIcon.png"
            });
            await Expect(nav.NotificationBellIcon).ToBeVisibleAsync();

            //Verify if the AVEVA Help Icon is Visible
            await nav.AVEVAHelpIcon.ScreenshotAsync(new()
            {
                Path = "AVEVAHelpIcon.png"
            });
            await Expect(nav.AVEVAHelpIcon).ToBeVisibleAsync();

            //Verify if the User Profile Icon is Visible
            await nav.UserProfileIcon.ScreenshotAsync(new()
            {
               Path = "UserProfile.png"
            });
            await Expect(nav.UserProfileIcon).ToBeVisibleAsync();
        }

        [Test]
        public async Task Verify_NotificationPanel_Elements_Are_Visible()
        {
            var notify = new NavigationBarPage(Page);

            //Click on the Notification icon and check the notification panel visibility


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
            await Expect(notify.NotificationClearAllButton).ToBeVisibleAsync();
            await notify.NotificationClearAllButton.ScreenshotAsync(new()
            {
                Path = "NotificationPanelClearAllButton.png"
            });

            //Check the Close button
            await notify.NotificationCloseButton.IsVisibleAsync();
            await Expect(notify.NotificationCloseButton).ToBeVisibleAsync();
            await notify.NotificationCloseButton.ScreenshotAsync(new()
            {
                Path = "NotificationCloseButton.png"
            });
                        
        }

        [Test]
        public async Task Verify_NotificationPanel_When_No_Notifications_Available()
        {
            var notification = new NavigationBarPage(Page);

            //Click on the notification bell icon
            await Expect(notification.NotificationBellIcon).ToBeVisibleAsync();
            await notification.NotificationBellIcon.ClickAsync();
            await Expect(notification.NotificationPanel).ToBeVisibleAsync();
            var CountOfNotifications = await notification.NumberOfNotifications.CountAsync();
            Console.WriteLine($"Number of Notifications in the Panel: {CountOfNotifications}");
            
        }
        [Test]
        public async Task Verify_NotificationPanel_When_Notifications_Available()
        {

        }

        [Test]
        public async Task Verify_CloseButton_Of_NotificationPanel()
        {
            var closebutton = new NavigationBarPage(Page);
            
            //Check the Close button
            await Expect(closebutton.NotificationCloseButton).ToBeVisibleAsync();
            await closebutton.NotificationCloseButton.ClickAsync();
            await Expect(closebutton.NotificationCloseButton).ToBeHiddenAsync();
        }

        [Test]
        public async Task Verify_NumberNearBellIcon_Equals_NumberOfMessages()
        {

        }

        [Test]
        public async Task Verify_InstanceExpiry_Confirmation_Notification()
        {

        }
        [Test]
        public async Task Verify_InstanceExpiry_Warning_Notification()
        {

        }
        [Test]
        public async Task Veriyf_Notifications_Are_Sorted()
        {

        }

        [Test]
        public async Task Verify_ClearAll_Button_Of_NotificationPanel()
        {

            var clearallbutton = new NavigationBarPage(Page);
            //Check for the Clear All Button
            await Expect(clearallbutton.NotificationClearAllButton).ToBeVisibleAsync();
            await clearallbutton.NotificationClearAllButton.ScreenshotAsync(new()
            {
                Path = "NotificationPanelClearAllButton.png"
            });

            /*if (CountOfNotifications > 0)
            {
                await notify.ClearAllButton.FocusAsync();
                await Expect(notify.ClearAllButton).ToBeEnabledAsync();
            }*/
        }

        [Test]
        public async Task Verify_InstanceExpiryConfirmation_CloseButton()
        {

        }

        [Test]
        public async Task Verify_InstanceExpiryWarning_CloseButton()
        {

        }


    }
}
