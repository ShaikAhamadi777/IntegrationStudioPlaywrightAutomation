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

        //LHS Menu Locators
        public ILocator ProjectTemplatePage => Page.Locator("#app-layout-container");
        public ILocator LHSMenu => Page.Locator(".uilab-layout-nav");
        public ILocator ProjectTemplates => Page.Locator("[aria-label='Project templates']");
        public ILocator SystemSuites => Page.Locator("[aria-label='System suites']");
        public ILocator GlobalRDPRules => Page.Locator("[aria-label='Global RDP rules']");
        public ILocator General => Page.Locator("[aria-label='General']");
        public ILocator CollapseButtonContent => Page.Locator("//span[text()='Collapse']");
        public ILocator CollapseButtonIcon => Page.Locator(".uilab-nav-rail__footer");

        //System suites Locators
        public ILocator SystemsuitesSubMenu => Page.Locator("//uilab-sidesheet[@class='uilab-nav-rail__sidesheet open--']");
        public ILocator SystemsuitesSubMenuTitle => Page.Locator("//div[@class='uilab-sidesheet__title' and text()='System suites']");
        public ILocator SystemsuitesSubMenuClose => Page.Locator("[aria-label='Close']");
        public ILocator ManageSystemsuites => Page.Locator("[aria-label='Manage system suites']");
        public ILocator GlobalParameters => Page.Locator("[aria-label='Global parameters']");



    }
}
