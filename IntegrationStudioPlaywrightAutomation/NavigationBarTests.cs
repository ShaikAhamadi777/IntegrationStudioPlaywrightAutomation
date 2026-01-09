
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
                Path = "Screenshot_Of_NavigationBar.png"
            });
            await Expect(nav.AppBar).ToBeVisibleAsync();
            string title = await Page.TitleAsync();
            Console.WriteLine(title);
            await Expect(Page).ToHaveTitleAsync(title);

            //Verify if the Notification Bell Icon is Visible
            await nav.NotificationBellIcon.FocusAsync();
            await nav.NotificationBellIcon.ScreenshotAsync(new()
            {
                Path = "Screeshot_Of_NotificationBellIcon.png"
            });
            await Expect(nav.NotificationBellIcon).ToBeVisibleAsync();

            //Verify if the AVEVA Help Icon is Visible
            await nav.AVEVAHelpIcon.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_AVEVAHelpIcon.png"
            });
            await Expect(nav.AVEVAHelpIcon).ToBeVisibleAsync();

            //Verify if the User Profile Icon is Visible
            await nav.UserProfileIcon.ScreenshotAsync(new()
            {
               Path = "Screenshot_Of_UserProfileIcon.png"
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
                    Path = "Screenshot_Of_HelpPage_AfterClickingHelpIcon.png"
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
                Path = "Screenshot_Of_AVEVAHelpPage.png"
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
            var notificationsavail = new NavigationBarPage(Page);
            
            //Click on the notification bell icon
            await Expect(notificationsavail.NotificationBellIcon).ToBeVisibleAsync();
            await notificationsavail.NotificationBellIcon.ClickAsync();


            //Number of Notifications - Example 2 
            var CountOfNotifications = await notificationsavail.NumberOfNotifications.InnerTextAsync();
            Console.WriteLine($"{CountOfNotifications} are present in the notification panel");

            //Close Button
            await notificationsavail.NotificationCloseButton.IsVisibleAsync();
            await Expect(notificationsavail.NotificationCloseButton).ToBeVisibleAsync();

            //Instance Deletion Notification
            var notif = notificationsavail.NotificationsAvailable;
            ILocator expiryWarning = null;

            int total = await notif.CountAsync();
            Console.WriteLine(total);

            for (int i = 0; i < total; i++)
            {
                var item = notif.Nth(i);

                var text = await item.InnerTextAsync();
                Console.WriteLine(text);

                // Check expiry text
                if (text.Contains("about to expire", StringComparison.OrdinalIgnoreCase))
                {
                    // Check presence of Change button
                    if (await item.Locator("button:has-text('Change')").CountAsync() > 0)
                    {
                        expiryWarning = item;
                        break;
                    }
                }
            }

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
                Path = "Screenshot_Of_Page_AfterNotificationClosed.png"
            });
        }

        [Test]
        public async Task Verify_NumberNearBellIcon_Equals_NumberOfMessages()
        {
            
            
            var number = new NavigationBarPage(Page);
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

            var clearallbutton = new NavigationBarPage(Page);
            
            //Check the Notification Bell Icon
            await Expect(clearallbutton.NotificationBellIcon).ToBeVisibleAsync();
            await clearallbutton.NotificationBellIcon.ClickAsync();
            await Expect(clearallbutton.NotificationPanel).ToBeVisibleAsync();

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
