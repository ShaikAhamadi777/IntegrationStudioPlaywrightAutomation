using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace IntegrationStudioPlaywrightAutomation
{
    public class BaseTest : PageTest
    {

        
        public override BrowserNewContextOptions ContextOptions()
        {
            return new BrowserNewContextOptions
            {
                StorageStatePath = "auth.json"
            };
        }

        [SetUp] //Runs before every test
        public async Task SetUp()
        {

            //Navigating to the Integration studio URL
            await Page.GotoAsync("https://internal.integrationstudio.capdev-connect.aveva.com/");

            await Page.ClickAsync("#submit");

            //Clicking the Tenant name displayed from the list of Connect accounts and tenants
            await Page.ClickAsync("text=AV-Test2 ");

            //Waiting for the URL to sync with the integration studio url
            await Page.WaitForURLAsync("https://internal.integrationstudio.capdev-connect.aveva.com/projects");
        }

    }
}
