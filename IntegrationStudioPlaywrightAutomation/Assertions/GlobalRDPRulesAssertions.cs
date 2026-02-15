using IntegrationStudioPlaywrightAutomation.Locators;
using static Microsoft.Playwright.Assertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationStudioPlaywrightAutomation.Assertions
{
    public static class GlobalRDPRulesAssertions
    {
        public static async Task VerifyGlobalRDPRulesPageAndTitleVisible(GlobalRDPRulesPage page)
        {
            await page.GlobalRDPRulePage.WaitForAsync();
            await Expect(page.GlobalRDPRulePage).ToBeVisibleAsync();
            await Expect(page.GlobalRDPRulePageTitle).ToBeVisibleAsync();

        }
        public static async Task VerifyClientIPtextfield(GlobalRDPRulesPage page)
        {

            //Check for the Client Public IP address field
            await Expect(page.ClientPublicIP).ToBeVisibleAsync();
            await Expect(page.IPAddress.First).ToBeVisibleAsync();
            await page.ClientPublicIP.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_GlobalRDPRules_ClientIP.png"
            });

            //Check for the IP address and the text field
            await page.IPAddress.First.WaitForAsync();
            await page.IPAddress.First.IsVisibleAsync();
            await Expect(page.IPAddressTextField).ToBeVisibleAsync();
            await Expect(page.IPAddressTextField).ToBeEditableAsync();

            await Expect(page.IPAddressTextFiledText).ToBeVisibleAsync();

            //Check for the Helper text present under the client public IP text field
            await Expect(page.IPHelperText).ToBeVisibleAsync();
            await Expect(page.IPPart).ToBeVisibleAsync();

            await Expect(page.IPInUse.First).ToBeVisibleAsync();
            await page.IPInUse.First.HighlightAsync();
            await Expect(page.IPAddButton).ToBeVisibleAsync();


        }
        public static async Task VerifyFireWallTableHeadingTitle(GlobalRDPRulesPage page)
        {

            await Expect(page.FirewallTableHeading).ToBeVisibleAsync();
            await Expect(page.FirewallRuleNameTitle).ToBeVisibleAsync();
        }
        public static async Task VerifyGlobalRDPRuleNameIPAndDeleteIcon(GlobalRDPRulesPage page)
        {
            
                await page.GlobalRDPRuleNames.First.HighlightAsync();
                await Expect(page.FirewallIPAddressTitle).ToBeVisibleAsync();
                await Expect(page.IPAddress.Last).ToBeVisibleAsync();
                await page.IPAddress.Last.HighlightAsync();
                await page.FirewallRuleDeleteOptions.First.WaitForAsync();
                await Expect(page.FirewallRuleDeleteOptions.First).ToBeVisibleAsync();
        }
    }
}
