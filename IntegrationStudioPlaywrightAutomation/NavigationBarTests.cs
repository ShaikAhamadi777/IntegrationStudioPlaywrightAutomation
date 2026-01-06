
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
            await nav.NotificationPanel.FocusAsync();
            await nav.NotificationPanel.ScreenshotAsync(new()
            {
                Path = "NotificationPanelIcon.png"
            });
            await Expect(nav.NotificationPanel).ToBeVisibleAsync();

            //Help Icon
            await nav.AVEVAHelpIcon.ScreenshotAsync(new()
            {
                Path = "AVEVAHelpIcon.png"
            });
            await Expect(nav.AVEVAHelpIcon).ToBeVisibleAsync();

            //User Profile Icon
            /*await nav.UserProfileIcon.ScreenshotAsync(new()
            {
               Path = "UserProfile.png"
            });
            await Expect(nav.UserProfileIcon).ToBeVisibleAsync();*/









        }

    }
}
