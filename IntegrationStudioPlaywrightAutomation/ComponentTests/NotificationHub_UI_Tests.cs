
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Text.RegularExpressions;
using IntegrationStudioPlaywrightAutomation.Locators;

namespace IntegrationStudioPlaywrightAutomation.ComponentTests
{
    [TestFixture]
    public class NotificationHub_UI_Tests : BaseTest
    {

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenNotificationBellIcon_ShouldOpen_NotificationPanel(string role)
        {
            var notify = new NotificationHubPage(Page);

            await notify.AppBar.WaitForAsync();
            await Expect(notify.AppBar).ToBeVisibleAsync();

            //Click on the Notification icon and check the notification panel visibility
            await notify.NotificationBellIcon.WaitForAsync();
            await Expect(notify.NotificationBellIcon).ToBeVisibleAsync();

            await notify.NotificationBellIcon.ClickAsync();
            await Expect(notify.NotificationPanel).ToBeVisibleAsync();
            await notify.NotificationPanel.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NotificationPanelPage_ForAllRoles.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenNotificationPanel_ShouldContain_NumberOfNotifications(string role)
        {
            var number = new NotificationHubPage(Page);

            await number.AppBar.WaitForAsync();
            await Expect(number.AppBar).ToBeVisibleAsync();

            //Click on the Notification icon and check the notification panel visibility
            await number.NotificationBellIcon.WaitForAsync();
            await Expect(number.NotificationBellIcon).ToBeVisibleAsync();

            await number.NotificationBellIcon.ClickAsync();
            await Expect(number.NotificationPanel).ToBeVisibleAsync();

            //Fetch the number of Notifications in the Header
            await Expect(number.NumberOfNotifications).ToBeVisibleAsync();
            var CountOfNotifications = await number.NumberOfNotifications.InnerTextAsync();
            Console.WriteLine($"Number of Notifications in the Panel: {CountOfNotifications}");

            await number.NumberOfNotifications.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NumberOfnotificationstext_ForAllRoles.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenNotificationPanel_ShouldContain_ClearAll_Button(string role)
        {
            var clearall = new NotificationHubPage(Page);

            await clearall.AppBar.WaitForAsync();
            await Expect(clearall.AppBar).ToBeVisibleAsync();

            await Expect(clearall.NotificationBellIcon).ToBeVisibleAsync();
            await clearall.NotificationBellIcon.ClickAsync();

            await clearall.NotificationPanel.WaitForAsync();
            await Expect(clearall.NotificationPanel).ToBeVisibleAsync();

            await clearall.NotificationClearAllButton.WaitForAsync();
            await Expect(clearall.NotificationClearAllButton).ToBeVisibleAsync();

            await clearall.NotificationClearAllButton.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NotificationClearAllButton_ForAllRoles.png"
            });
        }

        
        [Test]
        [TestCase("SystemAdmin")]
        [Category("Common")]
        public async Task OpenNotificationPanel_ShouldContain_CloseButton(string role)
        {

            var close = new NotificationHubPage(Page);

            await close.AppBar.WaitForAsync();
            await Expect(close.AppBar).ToBeVisibleAsync();

            await Expect(close.NotificationBellIcon).ToBeVisibleAsync();
            await close.NotificationBellIcon.ClickAsync();

            await close.NotificationPanel.WaitForAsync();
            await Expect(close.NotificationPanel).ToBeVisibleAsync();

            await close.NotificationCloseButton.WaitForAsync();
            await Expect(close.NotificationCloseButton).ToBeVisibleAsync();

            await close.NotificationCloseButton.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NotificationCloseButton_ForAllRoles.png"
            });
        }
    }
}
