using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace IntegrationStudioPlaywrightAutomation.Tests
{
    public class NavigationBarPage:BaseTest
    {
        
        //Creating a browser page or a tab
        private readonly IPage Page;

        public NavigationBarPage(IPage page)
        {
           Page = page;
        }

        private ILocator AppBar => Page.Locator("");
        

         public async Task Verify_AppBar_Visibility()
        {

            await AppBar.TitleAsync();
            //Console.WriteLine(title);
            //Assert.Equals(title, "Integration Studio");
            await Page.ScreenshotAsync(new()
            {
                Path = "NavigationBarScreenshot.png"
            });
        }

        public async Task Verify_NotificationPanel()
        {

        }

        public async Task Verify_AVEVAHelpIcon()
        {

        }

        public async Task Verify_UserProfileIcon()
        {

        }

        public async Task Verify_UserProfilePopup()
        {

        }

        public async Task Verify_NetworkSpeedTest()
        {

        }

        public async Task Verify_LogOutButton()
        {

        }

        public async Task Verify_LegalLink()
        {

        }
    }
}
