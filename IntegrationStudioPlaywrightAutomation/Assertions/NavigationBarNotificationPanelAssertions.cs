using IntegrationStudioPlaywrightAutomation.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace IntegrationStudioPlaywrightAutomation.Assertions
{
    public static class NavigationBarNotificationPanelAssertions
    {
        public static async Task VerifyAppBarIsVisible(NavigationBarNotificationPanelPage page)
        {
            await page.AppBar.FocusAsync();
            await Expect(page.AppBar).ToBeVisibleAsync();

        }
        public static async Task VerifyAppBarIcons(NavigationBarNotificationPanelPage page)
        {
            await page.NotificationBellIcon.FocusAsync();
            await Expect(page.NotificationBellIcon).ToBeVisibleAsync();
            await page.AVEVAHelpIcon.WaitForAsync();
            await Expect(page.AVEVAHelpIcon).ToBeVisibleAsync();
            await page.UserProfileIcon.WaitForAsync();
            await Expect(page.UserProfileIcon).ToBeVisibleAsync();
        }
        public static async Task VerifyUserProfileIcon(NavigationBarNotificationPanelPage page)
        {

            await Expect(page.NetworkSpeedTest).ToBeVisibleAsync();
            await Expect(page.NetworkSpeedTest).ToBeEnabledAsync();

            await Expect(page.LogOut).ToBeVisibleAsync();
            await Expect(page.LogOut).ToBeEnabledAsync();

            await page.CopyRightAndLegal.WaitForAsync();
            await Expect(page.CopyRightAndLegal).ToBeVisibleAsync();

            await page.UserProfilePopUp.HighlightAsync();
        }
        public static async Task VerifyNotificationPanelAndNumberOfNotifications(NavigationBarNotificationPanelPage page)
        {
            await Expect(page.NotificationPanel).ToBeVisibleAsync();
            await Expect(page.NumberOfNotifications).ToBeVisibleAsync();
            await page.NotificationClearAllButton.WaitForAsync();
            await Expect(page.NotificationClearAllButton).ToBeVisibleAsync();
            await page.NotificationCloseButton.WaitForAsync();
            await Expect(page.NotificationCloseButton).ToBeVisibleAsync();
        }
    }
}
