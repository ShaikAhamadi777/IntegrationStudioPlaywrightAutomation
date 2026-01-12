using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace IntegrationStudioPlaywrightAutomation.Locators
{
    public class GlobalRDPRulesPage
    {
        private readonly IPage Page;

        public GlobalRDPRulesPage(IPage page)
        {
            Page = page;
        }

        //Loators of Global RDP Rules page
        public ILocator LHSMenu => Page.Locator(".uilab-layout-nav");
        public ILocator GlobalRDPRules => Page.Locator("[aria-label='Global RDP rules']");
        public ILocator GlobalRDPRulePage => Page.Locator("#app-main-section");
        public ILocator GlobalRDPRulePageTitle => Page.Locator("#firewall-title");
        public ILocator ClientPublicIP => Page.Locator("//div[text()='Client public IP: ']");
        public ILocator IPAddress => Page.Locator("text=/\\b(?:\\d{1,3}\\.){3}\\d{1,3}\\b/");
        public ILocator IPAddressTextField => Page.Locator("#text-field-ip");
    }
}
