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

        public ILocator AppBar => Page.Locator("section#app-bar");
        //private ILocator NotificationPanel => Page.Locator("");
        //private ILocator AVEVAHelpIcon => Page.Locator("");
        //private ILocator UserProfileIcon => Page.Locator("");
        //private ILocator UserProfilePopup => Page.Locator("");
        //private ILocator NetworkSpeedTest => Page.Locator("");
        //private ILocator LogOutButton => Page.Locator("");
        //private ILocator LegalLink => Page.Locator("");
       

    }
}
