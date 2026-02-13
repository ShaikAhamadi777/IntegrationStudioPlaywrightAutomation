
using IntegrationStudioPlaywrightAutomation.Assertions;
using IntegrationStudioPlaywrightAutomation.Locators;
using IntegrationStudioPlaywrightAutomation.WorkFlows;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            var notify = new NavigationBarNotificationPanelPage(Page);
            var notifyworkflow = new NavigationBarNotificationPanelWorkflow(Page);

            await NavigationBarNotificationPanelAssertions.VerifyAppBarIsVisible(notify);
            await NavigationBarNotificationPanelAssertions.VerifyAppBarIcons(notify);

            await notifyworkflow.OpenNotificationPanelAsync();
            await NavigationBarNotificationPanelAssertions.VerifyNotificationPanelAndNumberOfNotifications(notify);

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
            var number = new NavigationBarNotificationPanelPage(Page);
            var numberworkflow = new NavigationBarNotificationPanelWorkflow(Page);

            await NavigationBarNotificationPanelAssertions.VerifyAppBarIsVisible(number);
            await NavigationBarNotificationPanelAssertions.VerifyAppBarIcons(number);
            await numberworkflow.OpenNotificationPanelAsync();
            await NavigationBarNotificationPanelAssertions.VerifyNotificationPanelAndNumberOfNotifications(number);

            //Fetch the number of Notifications in the Header
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
            var clearall = new NavigationBarNotificationPanelPage(Page);
            var clearallworkflow = new NavigationBarNotificationPanelWorkflow(Page);

            await NavigationBarNotificationPanelAssertions.VerifyAppBarIsVisible(clearall);
            await NavigationBarNotificationPanelAssertions.VerifyAppBarIcons(clearall);
            await clearallworkflow.OpenNotificationPanelAsync();
            await NavigationBarNotificationPanelAssertions.VerifyNotificationPanelAndNumberOfNotifications(clearall);
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

            var close = new NavigationBarNotificationPanelPage(Page);
            var closeworkflow = new NavigationBarNotificationPanelWorkflow(Page);
            await NavigationBarNotificationPanelAssertions.VerifyAppBarIsVisible(close);
            await NavigationBarNotificationPanelAssertions.VerifyAppBarIcons(close);
            await closeworkflow.OpenNotificationPanelAsync();
            await NavigationBarNotificationPanelAssertions.VerifyNotificationPanelAndNumberOfNotifications(close);
            await close.NotificationCloseButton.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NotificationCloseButton_ForAllRoles.png"
            });
        }
    }
}
