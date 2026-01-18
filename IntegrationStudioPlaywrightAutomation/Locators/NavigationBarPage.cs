using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationStudioPlaywrightAutomation.Locators
{
    public class NavigationBarPage
    {

        private readonly IPage Page;

        //Page Object doesnot create browser . It only receives it 
        public NavigationBarPage(IPage page)
        {
            Page = page;
        }

        public ILocator AppBar => Page.Locator("//div[@class='MuiBox-root css-i9gxme']");
        public ILocator NotificationBellIcon => Page.Locator("uilab-icon-button[aria-label='Notifications']");
        public ILocator AVEVAHelpIcon => Page.Locator("[aria-label='Help']");
        //public ILocator UserProfileIcon => Page.Locator("[aria-label='Open menu']").Filter(new LocatorFilterOptions { Has = Page.Locator(":visible") });
        public ILocator UserProfileIcon => Page.Locator("//uilab-icon-button[@class='mdc-top-app-bar__action-item hydrated' and @aria-label='Open menu']");
        public ILocator AVEVAHelpSignInButton => Page.Locator("button[aria-label='AVEVA Employee']");


        //UserProfile Button Locators
        public ILocator UserProfilePopUp => Page.Locator("//section[contains(@class,'menu-surface--is-open-below')]");
        public ILocator UserName => Page.Locator("//a[contains(@title,'@')]");
        public ILocator TenantName => UserName.Locator("xpath=following::span[contains(@class,'mdc-list-item__text')][1]");
        public ILocator NetworkSpeedTest => Page.Locator("//a[@title='Network Speed Test']");
        public ILocator LogOut => Page.Locator("//a[@title='Log Out']");
        public ILocator CopyRightAndLegal => Page.Locator("//div[@class='uilab-list__legal' and text()=' © 2016 ']");

        public ILocator UserProfileDialog => Page.Locator("//h2[text()='User Profile']");
        public ILocator UserProfileContent => Page.Locator("#userprofile-dialog-content");
        public ILocator UserProfileEmail => Page.Locator("//div[text()='Email']");
        public ILocator UserProfileSubscription => Page.Locator("//div[text()='Subscription']");
        public ILocator UserProfileCloseButton => Page.Locator("#userprofile-dialog-close-btn");

        public ILocator Signout => Page.Locator("//h4[text()='Sign Out']");
        public ILocator LegalLink => Page.Locator("//a[text()=' Legal ']");
        public ILocator LegalResources => Page.Locator("//h1[text()='Legal Resources']");

        public ILocator NoProjectTemplates => Page.Locator("//td[text()='No project templates defined']");
    }
}
