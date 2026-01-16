using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationStudioPlaywrightAutomation
{
    public class BaseTest : PageTest
    {

        
        public override BrowserNewContextOptions ContextOptions()
        {
            return new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1510,
                    Height = 820
                },
                StorageStatePath = "auth.json"
                
            };
        }

        [SetUp] //Runs before every test
        public async Task SetUp()
        {

            //Navigating to the Integration studio URL
            await Page.GotoAsync("https://internal.integrationstudio.capdev-connect.aveva.com/");

            if (Page.Url.Contains("https://signin.dev-connect.aveva.com/login?state"))
            {
                var emailSignInButton = Page.Locator("#submit");
                await Expect(emailSignInButton).ToBeVisibleAsync();
                await emailSignInButton.ClickAsync();
            }
                await Page.WaitForURLAsync("https://profile.capdev-connect.aveva.com/solutions?state**");
                //Clicking the Tenant name displayed from the list of Connect accounts and tenants
                await Page.ClickAsync("text=Tenant Test 1");
            
            //Waiting for the URL to sync with the integration studio url
            await Page.WaitForURLAsync("https://internal.integrationstudio.capdev-connect.aveva.com/projects");
        }

    }
}
