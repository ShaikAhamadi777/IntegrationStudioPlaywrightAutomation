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
    public class NavigationBarPage
    {
        //Represents the broswer tab
        private readonly IPage Page;

        //Page Object doesnot create browser . It only receives it 
        public NavigationBarPage(IPage page)
        {
           Page = page;
        }

        //Navigation Bar Elements locators
        public ILocator AppBar => Page.Locator("section#app-bar");
        public ILocator NotificationBellIcon => Page.Locator("uilab-icon-button[aria-label='Notifications']");
        public ILocator AVEVAHelpIcon => Page.Locator("[aria-label='Help']");
        public ILocator UserProfileIcon => Page.Locator("[aria-label='Open menu']").Filter(new LocatorFilterOptions { Has = Page.Locator(":visible") });
        public ILocator AVEVAHelpSignInButton => Page.Locator("button[aria-label='AVEVA Employee']");

        //Notification Panel Elements locators
        public ILocator NotificationPanel => Page.Locator("#notifyContainer");
        public ILocator NumberOfNotifications => Page.Locator("#notifyCount");
        public ILocator NumberOfNotificationsInBellIcon => Page.Locator(".uilab-badge on-icon-btn--");
        public ILocator NotificationClearAllButton => Page.Locator("//button[text()='Clear all']");
        public ILocator NotificationCloseButton => Page.GetByTestId("CloseIcon");
        public ILocator NotificationsAvailable => Page.Locator("[data-testid='ErrorOutlineIcon']");
        
        //private ILocator UserProfilePopup => Page.Locator("");
        //private ILocator NetworkSpeedTest => Page.Locator("");
        //private ILocator LogOutButton => Page.Locator("");
        //private ILocator LegalLink => Page.Locator("");


    }
}
