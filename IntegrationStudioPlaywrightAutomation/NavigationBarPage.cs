using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.Assertions;


namespace IntegrationStudioPlaywrightAutomation.Pages
{
    public class NavigationBarPage
    {
        //Represents the broswer tab
        private readonly IPage Page;

        //Page Object doesnot create browser . It only receives it 
        public NavigationBarPage(IPage page)
        {
           Page = page;
        }

        private ILocator AppBar => Page.Locator("");
        private ILocator NotificationPanel => Page.Locator("");
        private ILocator AVEVAHelpIcon => Page.Locator("");
        private ILocator UserProfileIcon => Page.Locator("");
        private ILocator UserProfilePopup => Page.Locator("");
        private ILocator NetworkSpeedTest => Page.Locator("");
        private ILocator LogOutButton => Page.Locator("");
        private ILocator LegalLink => Page.Locator("");

        public async Task VerifyAllNavigationBarElements()
        {
            await VerifyAppBarIsVisible();
            await VerifyNotificationPanel();
            await VerifyAVEVAHelpIcon();
            await VerifyUserProfileIconIsVisible();
            await VerifyUserProfilePopupIsDisplayed();
            await VerifyNetworkSpeedTest();
            await VerifyLogOutButton();
            await VerifyLegalLink();
        }

        public async Task VerifyAppBarIsVisible()
        {
           // await Expect(AppBar).IsVisibleAsync();
        }

        public async Task VerifyNotificationPanel()
        {

        }

        public async Task VerifyAVEVAHelpIcon()
        {

        }

        public async Task VerifyUserProfileIconIsVisible()
        {

        }

        public async Task VerifyUserProfilePopupIsDisplayed()
        {

        }

        public async Task VerifyNetworkSpeedTest()
        {

        }

        public async Task VerifyLogOutButton()
        {

        }

        public async Task VerifyLegalLink()
        {

        }
    }
}
