using IntegrationStudioPlaywrightAutomation.Assertions;
using IntegrationStudioPlaywrightAutomation.Locators;
using IntegrationStudioPlaywrightAutomation.WorkFlows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationStudioPlaywrightAutomation.ComponentTests
{
    [TestFixture]
    public class GlobalRDPRules_UI_Tests : BaseTest
    {
        [Test]
        [TestCase("SystemAdmin")]
        [TestCase("ExternalAdmin")]
        [Category("Admins")]
        public async Task OpenGlobalRDPRulesPage_Should_BeVisible_ForAdmins(string role)
        {
            var gprules = new GlobalRDPRulesPage(Page);
            var gpruless = new ProjectTemplatesPage(Page);
            var gprulesworkflow = new GlobalRDPRulesWorkflow(Page);

            //Click on the Global RDP rules button and check the page
            await ProjectTemplatesAssertions.VerifyLHSMenuForProjectAdmin(gpruless);
            await gprulesworkflow.OpenGlobalRDPRulesPage();
            await GlobalRDPRulesAssertions.VerifyGlobalRDPRulesPageAndTitleVisible(gprules);

            //Check the Global RDP rules title
            await gprules.GlobalRDPRulePage.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_GlobalRDPRulesPage_ForAdmins.png"
            });
        }

        [Test]
        [TestCase("ProjectUser")]
        [Category("ProjectUser")]
        public async Task OpenGlobalRDPRulesPage_ShouldNot_BeVisible_ForProjectUsers(string role)
        {

            var pusergprules = new GlobalRDPRulesPage(Page);
            var pusergpruless = new ProjectTemplatesPage (Page);
            await ProjectTemplatesAssertions.VerifyLHSMenuForProjectUser(pusergpruless);
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_GlobalRDPRulesPage_ForProjectUser.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [TestCase("ExternalAdmin")]
        [Category("Admins")]
        public async Task OpenGlobalRDPRulesPage_ShouldContain_TitleClientIPTextAndAddButton_ForAdmins(string role)
        {
            var gptitle = new GlobalRDPRulesPage(Page);
            var gptitles = new ProjectTemplatesPage(Page);
            var gptitleworkflow = new GlobalRDPRulesWorkflow(Page);     

            //Click on the Global RDP rules button and check the page
            await ProjectTemplatesAssertions.VerifyLHSMenuForProjectAdmin(gptitles);
            await gptitleworkflow.OpenGlobalRDPRulesPage();
            await GlobalRDPRulesAssertions.VerifyGlobalRDPRulesPageAndTitleVisible(gptitle);
            await gptitle.GlobalRDPRulePageTitle.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_GlobalRDPRules_Title.png"
            });
            await GlobalRDPRulesAssertions.VerifyClientIPtextfield(gptitle);
            await gptitle.IPPart.ScreenshotAsync(new()
            {
               Path = "Screenshot_Of_GRDPRules_IPAddressFields.png"
            });
            await gptitle.IPInUse.First.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NumberOf_IPs_Inuse_ForAdmins.png"
            });
        }


        [Test]
        [TestCase("SystemAdmin")]
        [TestCase("ExternalAdmin")]
        [Category("Admins")]
        public async Task OpenGlobalRDPRulesPage_ShouldContain_FirewallRulesNamesIPAddress_ForAdmins(string role)
        {
            var firewall = new GlobalRDPRulesPage(Page);
            var firewalls = new ProjectTemplatesPage(Page);
            var firewallworkflow = new GlobalRDPRulesWorkflow(Page);

            //Click on the Global RDP rules button and check the page
            await ProjectTemplatesAssertions.VerifyLHSMenuForProjectAdmin(firewalls);
            await firewallworkflow.OpenGlobalRDPRulesPage();
            await GlobalRDPRulesAssertions.VerifyGlobalRDPRulesPageAndTitleVisible(firewall);
            await GlobalRDPRulesAssertions.VerifyFireWallTableHeadingTitle(firewall);
            if (await firewall.FirewallRuleRows.First.IsVisibleAsync())
            { 
                await GlobalRDPRulesAssertions.VerifyGlobalRDPRuleNameIPAndDeleteIcon(firewall);
                await firewall.GlobalRDPRulesTable.ScreenshotAsync(new()
                {
                    Path = "Screenshot_Of_GlobalRDPRules_Table.png"
                });
            }
            else
            {
                Console.WriteLine("No Firewall rules are present in the Global RDP rules page");
            }
        }
    }
}
