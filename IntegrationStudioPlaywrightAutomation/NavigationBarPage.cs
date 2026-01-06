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

        public ILocator AppBar => Page.Locator(".uilab-top-app-bar__title");
        public ILocator NotificationPanel => Page.Locator(".mdc-top-app-bar__action-item d-none d-md-inline-block uilab-top-app-bar__notification hydrated");
        //private ILocator AVEVAHelpIcon => Page.Locator("");
        //private ILocator UserProfileIcon => Page.Locator("");
        //private ILocator UserProfilePopup => Page.Locator("");
        //private ILocator NetworkSpeedTest => Page.Locator("");
        //private ILocator LogOutButton => Page.Locator("");
        //private ILocator LegalLink => Page.Locator("");
       

    }
}
