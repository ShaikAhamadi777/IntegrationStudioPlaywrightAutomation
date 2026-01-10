
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
    public class NotificationHubTests : BaseTest
    {
        
        [Test]
        public async Task Verify_NotificationPanel_Elements_Are_Visible()
        {
            var notify = new NotificationHubPage(Page);

            //Click on the Notification icon and check the notification panel visibility
            await notify.NotificationBellIcon.ClickAsync();
            await Expect(notify.NotificationPanel).ToBeVisibleAsync();
            await notify.NotificationPanel.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NotificationPanelPage.png"
            });

            //Fetch the number of Notifications in the Header
            await Expect(notify.NumberOfNotifications).ToBeVisibleAsync();
            var CountOfNotifications = await notify.NumberOfNotifications.InnerTextAsync();
            Console.WriteLine($"Number of Notifications in the Panel: {CountOfNotifications}");

            //Check for the Clear All Button
            await Expect(notify.NotificationClearAllButton).ToBeVisibleAsync();
            await notify.NotificationClearAllButton.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NotificationPanelClearAllButton.png"
            });

            //Check the Close button
            await notify.NotificationCloseButton.IsVisibleAsync();
            await Expect(notify.NotificationCloseButton).ToBeVisibleAsync();
            await notify.NotificationCloseButton.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NotificationCloseButton.png"
            });            
        }

        [Test]
        public async Task Verify_NotificationPanel_When_No_Notifications_Available()
        {
            var notification = new NotificationHubPage(Page);

            //Click on the notification bell icon
            await Expect(notification.NotificationBellIcon).ToBeVisibleAsync();
            await notification.NotificationBellIcon.ClickAsync();

            //Check if the Notification Panel is visible
            await Expect(notification.NotificationPanel).ToBeVisibleAsync();

            //Check if the ClearAll is disabled
            await Expect(notification.NotificationClearAllButton).ToBeDisabledAsync();

            //Check if the Header is equal to 0 notifications
            var CountOfNotifications = await notification.NumberOfNotifications.InnerTextAsync();
            Console.WriteLine($"{CountOfNotifications} are present in the notification panel");
            await Expect(notification.NumberOfNotifications).ToContainTextAsync("0 notifications");

            //Screenshot of 0 notifications 
            await notification.NotificationPanel.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NoNotificationsAvailablePanel.png"
            });
            
        }
        [Test]
        public async Task Verify_NotificationPanel_When_Notifications_Available()
        {
            var notificationsavail = new NotificationHubPage(Page);
            
            //Click on the notification bell icon
            await Expect(notificationsavail.NotificationBellIcon).ToBeVisibleAsync();
            await notificationsavail.NotificationBellIcon.ClickAsync();


            //Number of Notifications - Example 2 
            await Expect(notificationsavail.NumberOfNotifications).ToBeVisibleAsync();
            await Expect(notificationsavail.NumberOfNotifications).Not.ToContainTextAsync("0 notifications");
            var CountOfNotifications = await notificationsavail.NumberOfNotifications.InnerTextAsync();
            Console.WriteLine($"{CountOfNotifications} are present in the notification panel");

            //Close Button
            await notificationsavail.NotificationCloseButton.IsVisibleAsync();
            await Expect(notificationsavail.NotificationCloseButton).ToBeVisibleAsync();

            //Instance Deletion Notification
            

            //Instance Expiry Warning Notification
            


            //Check if the ClearAll Button Enabled
            await Expect(notificationsavail.NotificationClearAllButton).ToBeEnabledAsync();

            //Check the Close Button for Instance Expriy Deletion Notification



            //Check the Close button for the Instance Expiry Warning Notification



            //Check the Change button for the Instance Deletion Notification


        }

        [Test]
        public async Task Verify_CloseButton_Of_NotificationPanel()
        {
            var closebutton = new NotificationHubPage(Page);

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
                Path = "Screenshot_Of_Page_AfterNotificationClosed.png"
            });
        }

        [Test]
        public async Task Verify_NumberNearBellIcon_Equals_NumberOfMessages()
        {
            
            
            var number = new NotificationHubPage(Page);
            if (await number.NumberOnBellIcon.IsVisibleAsync())
            {


                //Check if the Notification Bell Icon is visible
                await number.NumberOnBellIcon.IsVisibleAsync();
                await number.NumberOnBellIcon.ScreenshotAsync(new()
                {
                    Path = "Screenshot_Of_NumberOnBellIcon.png"
                });

                //Extract the number of notifications from the bell icon and convert into int
                var numberonbellicon = await number.NumberOnBellIcon.InnerTextAsync();
                Console.WriteLine(numberonbellicon);
                int numberinint = Convert.ToInt32(numberonbellicon);


                //Click on the Notification Bell Icon and click
                await Expect(number.NotificationBellIcon).ToBeVisibleAsync();
                await number.NotificationBellIcon.ClickAsync();

                //To check if the number of notifications are not 0
                await Expect(number.NumberOfNotifications).ToBeVisibleAsync();
                await Expect(number.NumberOfNotifications).Not.ToContainTextAsync("0 notifications");

                //Extracting the text from the notification panel content
                var numberonpanel = await number.NumberOfNotifications.InnerTextAsync();
                Console.WriteLine($"{numberonpanel} are present in the notification panel");

                await number.NumberOfNotifications.ScreenshotAsync(new()
                {
                    Path = "Screenshot_Of_Notifications_Inside_Panel.png"
                });

                //Extracting the number for the panel notification content and convert into int
                string[] extractstring = numberonpanel.Split(' ');
                int numberextracted = Convert.ToInt32(extractstring[0]);

                //To Check if the number from the panel is same as the number on the bell icon
                if (numberextracted == numberinint)
                {
                    Console.WriteLine($"The Number {numberinint} on the BellIcon is equal to the Number {numberextracted} on the Notification panel");
                }
                else
                {
                    Console.WriteLine($"The Number {numberinint} on the BellIcon is not equal to the Number{numberextracted} on the Notification panel");
                }
            }
            else
            {
                await Expect(number.NotificationBellIcon).ToBeVisibleAsync();
                await number.NotificationBellIcon.ClickAsync();

                await number.NumberOfNotifications.IsVisibleAsync();
                var numberonpanel = await number.NumberOfNotifications.InnerTextAsync();
                Console.WriteLine($"{numberonpanel} Notifications are present");

                await Page.ScreenshotAsync(new()
                {
                    Path="Screenshot_If_No_Notifications_are_available.png"

                });
            }
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

            var clearallbutton = new NotificationHubPage(Page);
            
            //Check the Notification Bell Icon
            await Expect(clearallbutton.NotificationBellIcon).ToBeVisibleAsync();
            await clearallbutton.NotificationBellIcon.ClickAsync();
            await Expect(clearallbutton.NotificationPanel).ToBeVisibleAsync();
            var Count = await clearallbutton.NumberOfNotifications.InnerTextAsync();
            if (Count.Equals("0 notifications"))
            {
                await Expect(clearallbutton.NotificationClearAllButton).ToBeDisabledAsync();
                await Page.ScreenshotAsync(new()
                {
                    Path="Screenshot_When_ClearAllButton_IsDisabled_NoNotifications.png"
                });
            }
            else
            {
                //To check if the Clear all button is enabled
                await Expect(clearallbutton.NotificationClearAllButton).ToBeEnabledAsync();

                await Page.ScreenshotAsync(new()
                {
                    Path = "Screenshot_to_Check_ClearAll_Button_Enabled.png"
                });

                //Check and print the number of notifications available
                var NotificationsBeforeClicking = await clearallbutton.NumberOfNotifications.InnerTextAsync();
                Console.WriteLine($"{NotificationsBeforeClicking} are present in the notification panel");

                //Click on the clearall button
                await clearallbutton.NotificationClearAllButton.ClickAsync();


                await Expect(clearallbutton.NumberOfNotifications).ToHaveTextAsync("0 notifications");

                //Check and print the number of notifications available
                var NotificationsAfterClicking = await clearallbutton.NumberOfNotifications.InnerTextAsync();
                Console.WriteLine($"{NotificationsAfterClicking} are present in the notification panel");


                await Page.ScreenshotAsync(new()
                {
                    Path = "Screenshot_to_Check_After_Clicking_Clearall_Button.png"
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

        [Test]
        public async Task Verify_ChangeButton_Of_InstanceExpiry_Warning_Notification()
        {

        }
        [Test]
        public async Task Verify_Change_ExpiryPeriodPop_Message_From_NotificationPanel()
        {

        }
        [Test]
        public async Task Verify_ChangeExpiryDate_From_ChangeButton_Of_NotifiationPanel()
        {

        }
        [Test]
        public async Task Verify_NotificationGetting_Cleared_After_ExpriyPeriod_Change()
        {

        }
        [Test]
        public async Task Verify_ScrollBar_In_NotificationPanel_When_HighNumberOf_Notifications()
        {
            var scrollbar = new NotificationHubPage(Page);

            await scrollbar.NotificationBellIcon.IsVisibleAsync();
            await scrollbar.NotificationBellIcon.ClickAsync();
            await Expect(scrollbar.NotificationScrollBar).ToBeVisibleAsync();

            await Expect(scrollbar.NumberOfNotifications).Not.ToContainTextAsync("0 notifications");
            await Page.ScreenshotAsync(new()
            {
                Path="Screenshot_Of_NotificationPanel.png"
            });
            var isScrollBarPresent = await scrollbar.NotificationScrollBar.EvaluateAsync<bool>(
                "el => el.scrollheight > el.clientheight"
                );
            Assert.IsTrue(isScrollBarPresent,"ScrollBar is not present in the notificationpanel because of less number of notifications present" );
            await scrollbar.NotificationScrollBar.EvaluateAsync("el => el.style.overflowY = 'scroll'");
            await scrollbar.NotificationScrollBar.EvaluateAsync("el => el.scrollTop = 50");
            await scrollbar.NotificationScrollBar.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NotificationPanel_After_ScrollbarDetect.png"
            });
        }
        [Test]
        public async Task Verify_Notification_RemovedFromPanel_After_ExpiryPeriodChange_From_EditInstancePopup()
        {

        }

    }
}
