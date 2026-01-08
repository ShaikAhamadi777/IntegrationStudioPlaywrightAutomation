
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
        public async Task Verify_HelpIcon_In_AppBar()
        {
            var helpicon = new NavigationBarPage(Page);

            //Check for the AVEVA Help icon visibility
            await Expect(helpicon.AVEVAHelpIcon).ToBeVisibleAsync();

            //Capture the help page after clicking on the help icon
            var helppage = await Page.RunAndWaitForPopupAsync(async () =>
            {
                await helpicon.AVEVAHelpIcon.ClickAsync();
            });

            //Wait for the page to load
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            //Check if the Help Page URL is correct
            Assert.IsTrue(helppage.Url.Contains("https://aveva-dev.zoominsoftware.io/auth/login/?redirect"));
            await Expect(helppage).ToHaveURLAsync(new Regex(@".*/auth/login/.*"));
            
            //Wait for the page to load
            await Task.Delay(20000);
            
            //Check if the SignIn page is available then take a screenshot and click on the AVEVA Employee button
            if(await helppage.Locator("button[aria-label='AVEVA Employee']").IsVisibleAsync())
            { 
                await helppage.ScreenshotAsync(new()
                {
                    Path = "HelpPageAfterClickingHelpIcon.png"
                });
                await helppage.Locator("button[aria-label='AVEVA Employee']").ClickAsync();

                //Wait for the AVEVA Help content to be loaded
                await helppage.WaitForURLAsync("https://aveva-dev.zoominsoftware.io/bundle/integration-studio/page/1370200.html");
                
                //Locate the AVEVA help page subheading and print the title
                await helppage.Locator("div.zDocsSubHeaderContainer").IsVisibleAsync();
                var Helppagetitle = await helppage.TitleAsync();
                Console.WriteLine(Helppagetitle);

                //Cick on the element present in the AVEVA Help page
                await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
               await helppage.Locator("button[aria-label='Hide table of contents']").ClickAsync();
               
            }
            await helppage.ScreenshotAsync(new()
            {
                Path = "AVEVAHelpPage.png"
            });
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

            //Fetch the number of Notifications in the Header
            await Expect(notify.NumberOfNotifications).ToBeVisibleAsync();
            var CountOfNotifications = await notify.NumberOfNotifications.InnerTextAsync();
            Console.WriteLine($"Number of Notifications in the Panel: {CountOfNotifications}");

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

            //Check if the Notification Panel is visible
            await Expect(notification.NotificationPanel).ToBeVisibleAsync();

            //Check if the ClearAll is disabled
            await Expect(notification.NotificationClearAllButton).ToBeDisabledAsync();

            //Check if the Header is equal to 0 notifications
            var CountOfNotifications = await notification.NumberOfNotifications.InnerTextAsync();
            Console.WriteLine($"{CountOfNotifications} Notifications are present in the notification panel");
            await Expect(notification.NumberOfNotifications).ToContainTextAsync("0 notifications");

            //Screenshot of 0 notifications 
            await notification.NotificationPanel.ScreenshotAsync(new()
            {
                Path = "NoNotificationsAvailablePanelScreenshot.png"
            });
            
        }
        [Test]
        public async Task Verify_NotificationPanel_When_Notifications_Available()
        {

        }

        [Test]
        public async Task Verify_CloseButton_Of_NotificationPanel()
        {
            var closebutton = new NavigationBarPage(Page);

            //Check the Notification Bell Icon
            await Expect(closebutton.NotificationBellIcon).ToBeVisibleAsync();
            await closebutton.NotificationBellIcon.ClickAsync();
            await Expect(closebutton.NotificationPanel).ToBeVisibleAsync();

            //Check for the Close button
            await Expect(closebutton.NotificationCloseButton).ToBeVisibleAsync();
            await closebutton.NotificationCloseButton.ClickAsync();
            await Expect(closebutton.NotificationCloseButton).ToBeHiddenAsync();

            await Page.ScreenshotAsync(new()
            {
                Path = "ScreenshotAfterNotificationClosed.png"
            });
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
            
            //Check the Notification Bell Icon
            await Expect(clearallbutton.NotificationBellIcon).ToBeVisibleAsync();
            await clearallbutton.NotificationBellIcon.ClickAsync();
            await Expect(clearallbutton.NotificationPanel).ToBeVisibleAsync();

            //Check if the Header is equal to 0 notifications
            if (await clearallbutton.NotificationsAvailable.IsVisibleAsync())
            {
                await clearallbutton.NotificationClearAllButton.IsEnabledAsync();
                await clearallbutton.NotificationPanel.ScreenshotAsync(new()
                {
                    Path = "Screenshot_When_Notifications_Are_Available.png"
                });
                /*await clearallbutton.NotificationClearAllButton.ClickAsync();
                await clearallbutton.NotificationClearAllButton.IsDisabledAsync();
                await clearallbutton.NotificationPanel.ScreenshotAsync(new()
                {
                    Path = "Screenshot_When_Notifications_Are_Cleared_Using_ClearAll_Button.png"
                });*/
            }

            else
            {
                await Expect(clearallbutton.NotificationClearAllButton).ToBeDisabledAsync();
                await clearallbutton.NotificationPanel.ScreenshotAsync(new()
                {
                    Path = "Screenshot_When_Notifications_Are_NotAvailable.png"
                });
            }
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
