using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace IntegrationStudioPlaywrightAutomation
{
    public class ProjectTemplatesPage
    {
        //Represents the broswer tab
        private readonly IPage Page;

        //Page Object doesnot create browser . It only receives it 
        public ProjectTemplatesPage(IPage page)
        {
            Page = page;
        }

        //ProjectTemplate Elements Locators
        public ILocator AppBar => Page.Locator("section#app-bar");
        public ILocator NotificationBellIcon => Page.Locator("uilab-icon-button[aria-label='Notifications']");
        public ILocator AVEVAHelpIcon => Page.Locator("[aria-label='Help']");
        public ILocator UserProfileIcon => Page.Locator("[aria-label='Open menu']").Filter(new LocatorFilterOptions { Has = Page.Locator(":visible") });
        public ILocator AVEVAHelpSignInButton => Page.Locator("button[aria-label='AVEVA Employee']");

        //private ILocator UserProfilePopup => Page.Locator("");
        //private ILocator NetworkSpeedTest => Page.Locator("");
        //private ILocator LogOutButton => Page.Locator("");
        //private ILocator LegalLink => Page.Locator("");

        public ILocator ProjectTemplatePage => Page.Locator("#app-layout-container");
        public ILocator LHSMenu => Page.Locator("//li[@class='uilab-nav-rail__item add-border-- selected--']");
        public ILocator ProjectTemplates => Page.Locator("//a[@class='mdc-list-item uilab-nav-rail__link top-level-padding--']//span[text()='Project templates']");
        public ILocator SystemSuites => Page.Locator("//span[@class='mdc-list-item__text uilab-nav-rail__text' and text()='System suites']");
        public ILocator GlobalRDPRules => Page.Locator("[aria-label='Global RDP rules']");
        public ILocator General => Page.Locator("[aria-label='General']");
    }
}
