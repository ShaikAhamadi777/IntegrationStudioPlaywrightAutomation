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
        public ILocator IPAddressTextFiledText => Page.Locator(".mdc-floating-label");
        public ILocator IPAddButton => Page.Locator("//uilab-button[text()='Add']");
        public ILocator IPHelperText => Page.Locator("#firewall-tips");
        public ILocator IPPart => Page.Locator("#firewall-form");
        public ILocator IPInUse => Page.Locator("text=in use");


        public ILocator FirewallTableHeading => Page.Locator("//tr[contains(@class,'firewall-table-columns css-axz6ke')]");
        public ILocator FirewallRuleRows => Page.Locator("//tr[@class='MuiTableRow-root firewall-table-row css-axz6ke']");
        public ILocator FirewallRuleNameTitle => Page.Locator("//th[text()='Firewall rule name']");
        public ILocator GlobalRDPRuleNames => Page.Locator("text=GlobalRDPRule_");
        public ILocator GlobalRDPRulesTable => Page.Locator("//table[contains(@class,'MuiTable-root firewall-table css-28cyes')]");

        public ILocator FirewallIPAddressTitle => Page.Locator("//th[text()='IP address/range']");
        public ILocator FirewallRuleDeleteOptions => Page.Locator("//uilab-button[@class='firewall-item-delete-btn hydrated']");

    }
}
