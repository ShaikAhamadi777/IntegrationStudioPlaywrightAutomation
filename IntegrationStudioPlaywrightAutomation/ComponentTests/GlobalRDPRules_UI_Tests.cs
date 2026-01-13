using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationStudioPlaywrightAutomation.Locators;

namespace IntegrationStudioPlaywrightAutomation.ComponentTests
{
    [TestFixture]
    public class GlobalRDPRules_UI_Tests : BaseTest
    {
        [Test]
        public async Task OpenGlobalRDPRulesPage()
        {
            var gprules = new GlobalRDPRulesPage(Page);

            //Click on the Global RDP rules button and check the page
            await Expect(gprules.LHSMenu).ToBeVisibleAsync();
            await Expect(gprules.GlobalRDPRules).ToBeVisibleAsync();
            await gprules.GlobalRDPRules.ClickAsync();
            await gprules.GlobalRDPRulePage.WaitForAsync();
            await Expect(gprules.GlobalRDPRulePage).ToBeVisibleAsync();

            //Check the Global RDP rules title
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_GlobalRDPRulesPage.png"
            });
        }

        [Test]
        public async Task OpenGlobalRDPRulesPage_ShouldContain_TitleClientIPAndText()
        {
            var gptitle = new GlobalRDPRulesPage(Page);

            //Click on the Global RDP rules and open the page
            await Expect(gptitle.LHSMenu).ToBeVisibleAsync();
            await Expect(gptitle.GlobalRDPRules).ToBeVisibleAsync();
            await gptitle.GlobalRDPRules.ClickAsync();
            await gptitle.GlobalRDPRulePage.WaitForAsync();
            await Expect(gptitle.GlobalRDPRulePage).ToBeVisibleAsync();

            //Check for the Global RDP Rule title
            await Expect(gptitle.GlobalRDPRulePageTitle).ToBeVisibleAsync();
            await gptitle.GlobalRDPRulePageTitle.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_GlobalRDPRules_Title.png"
            });

            //Check for the Client Public IP address field
            await Expect(gptitle.ClientPublicIP).ToBeVisibleAsync();
            await Expect(gptitle.IPAddress.First).ToBeVisibleAsync();
            await gptitle.ClientPublicIP.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_GlobalRDPRules_ClientIP.png"
            });

            //Check for the IP address and the text field
            await gptitle.IPAddress.First.WaitForAsync();
            await gptitle.IPAddress.First.IsVisibleAsync();
            await Expect(gptitle.IPAddressTextField).ToBeVisibleAsync();
            await Expect(gptitle.IPAddressTextField).ToBeEditableAsync();

            await Expect(gptitle.IPAddressTextFiledText).ToBeVisibleAsync();

            //Check for the Helper text present under the client public IP text field
            await Expect(gptitle.IPHelperText).ToBeVisibleAsync();
            await Expect(gptitle.IPPart).ToBeVisibleAsync();

            //Take a screeshot of the IP address part 
            await gptitle.IPPart.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_GRDPRules_IPAddressFields.png"
            });
        }

        [Test]
        public async Task OpenGlobalRDPRulesPage_ShouldContain_AddButtonAndIPInUse()
        {
            var add = new GlobalRDPRulesPage(Page);

            await Expect(add.LHSMenu).ToBeVisibleAsync();
            await Expect(add.GlobalRDPRules).ToBeVisibleAsync();
            await add.GlobalRDPRules.ClickAsync();
            await add.GlobalRDPRulePage.WaitForAsync();
            await Expect(add.GlobalRDPRulePage).ToBeVisibleAsync();

            await add.GlobalRDPRulePage.FocusAsync();
            await Expect(add.GlobalRDPRulePageTitle).ToBeVisibleAsync();

            await Expect(add.IPInUse.First).ToBeVisibleAsync();
            await add.IPInUse.First.HighlightAsync();
            await add.IPInUse.First.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NumberOf_IPs_Inuse.png"
            });

            await Expect(add.IPAddButton).ToBeVisibleAsync();
           
            await add.IPPart.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_GRDPRules_IPAddressFields.png"
            });
        }

        [Test]
        public async Task OpenGlobalRDPRulesPage_ShouldContain_FirewallRulesNames()
        {
            var firewall = new GlobalRDPRulesPage(Page);
            await Expect(firewall.LHSMenu).ToBeVisibleAsync();
            await Expect(firewall.GlobalRDPRules).ToBeVisibleAsync();
            await firewall.GlobalRDPRules.ClickAsync();
            await firewall.GlobalRDPRulePage.WaitForAsync();
            await Expect(firewall.GlobalRDPRulePage).ToBeVisibleAsync();

            await Expect(firewall.FirewallTableHeading).ToBeVisibleAsync();
            await Expect(firewall.FirewallRuleNameTitle).ToBeVisibleAsync();
            await Expect(firewall.GlobalRDPRuleNames.First).ToBeVisibleAsync();
            
            await firewall.GlobalRDPRuleNames.First.HighlightAsync();
            await firewall.GlobalRDPRulesTable.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_GlobalRDPRules_Table.png"
            });

        }

        [Test]
        public async Task OpenGlobalRDPRulesPage_ShouldContain_IPAddressAndRange()
        {
            var globalrdpruleips = new GlobalRDPRulesPage(Page);

            await Expect(globalrdpruleips.LHSMenu).ToBeVisibleAsync();
            await Expect(globalrdpruleips.GlobalRDPRules).ToBeVisibleAsync();
            await globalrdpruleips.GlobalRDPRules.ClickAsync();
            await globalrdpruleips.GlobalRDPRulePage.WaitForAsync();
            await Expect(globalrdpruleips.GlobalRDPRulePage).ToBeVisibleAsync();

            await Expect(globalrdpruleips.FirewallIPAddressTitle).ToBeVisibleAsync();
            await Expect(globalrdpruleips.IPAddress.Last).ToBeVisibleAsync();
            await globalrdpruleips.IPAddress.Last.HighlightAsync();

            await globalrdpruleips.IPAddress.Last.ScreenshotAsync(new()
            {
                Path = "Screenshot_of_IPPresent_InTable.png"
            });
        }

        [Test]
        public async Task OpenGlobalRDPRulesPage_ShouldContain_DeleteRuleOption()
        {
            var globalrdpruledelete = new GlobalRDPRulesPage(Page);
            await Expect(globalrdpruledelete.LHSMenu).ToBeVisibleAsync();
            await Expect(globalrdpruledelete.GlobalRDPRules).ToBeVisibleAsync();
            await globalrdpruledelete.GlobalRDPRules.ClickAsync();
            await globalrdpruledelete.GlobalRDPRulePage.WaitForAsync();
            await Expect(globalrdpruledelete.GlobalRDPRulePage).ToBeVisibleAsync();

            await globalrdpruledelete.FirewallRuleDeleteOptions.First.WaitForAsync();
            await Expect(globalrdpruledelete.FirewallRuleDeleteOptions.First).ToBeVisibleAsync();
            await globalrdpruledelete.FirewallRuleDeleteOptions.First.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_DeleteOption.png"
            });
        }

        [Test]
        public async Task OpenGlobalRDPRulesPage_ShouldContain_FirewallRuleNamesRows()
        {
            var rows = new GlobalRDPRulesPage(Page);
            await Expect(rows.LHSMenu).ToBeVisibleAsync();
            await Expect(rows.GlobalRDPRules).ToBeVisibleAsync();
            await rows.GlobalRDPRules.ClickAsync();
            await rows.GlobalRDPRulePage.WaitForAsync();
            await Expect(rows.GlobalRDPRulePage).ToBeVisibleAsync();

            await rows.FirewallRuleRows.First.WaitForAsync();
            await Expect(rows.FirewallRuleRows.First).ToContainTextAsync("GlobalRDPRule_");
            await Expect(rows.FirewallRuleRows.First).ToBeVisibleAsync();
            await rows.FirewallRuleRows.First.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_FirewallRuleName_Row.png"
            });




        }



    }
}
