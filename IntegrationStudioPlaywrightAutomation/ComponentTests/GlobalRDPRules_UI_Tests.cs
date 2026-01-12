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
        public async Task OpenGlobalRDPRulePage_ShouldContain_TitleAndClientIP()
        {
            var gptitle = new GlobalRDPRulesPage(Page);

            await Expect(gptitle.LHSMenu).ToBeVisibleAsync();
            await Expect(gptitle.GlobalRDPRules).ToBeVisibleAsync();
            await gptitle.GlobalRDPRules.ClickAsync();
            await gptitle.GlobalRDPRulePage.WaitForAsync();
            await Expect(gptitle.GlobalRDPRulePage).ToBeVisibleAsync();

            await Expect(gptitle.GlobalRDPRulePageTitle).ToBeVisibleAsync();
            await gptitle.GlobalRDPRulePageTitle.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_GlobalRDPRules_Title.png"
            });

            await Expect(gptitle.ClientPublicIP).ToBeVisibleAsync();
            await Expect(gptitle.IPAddress.First).ToBeVisibleAsync();
            await gptitle.ClientPublicIP.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_GlobalRDPRules_ClientIP.png"
            });
            await 
        }

        
       
        

    }
}
