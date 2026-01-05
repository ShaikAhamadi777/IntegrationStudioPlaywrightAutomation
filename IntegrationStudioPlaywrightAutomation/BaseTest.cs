using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace IntegrationStudioPlaywrightAutomation.Tests
{
    public class BaseTest
    {
        //Creating the variables outside the methods so that all the methods can use them
        protected IPage Page;
        protected IBrowser browser;
        protected IPlaywright playwright;
        
        [SetUp] //Runs before every test
        public async Task SetUp()
        {
            //Creating a playwright object 
            playwright = await Playwright.CreateAsync();

            //Creating a browser object which is similar to broswer profile
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 50, });

            //Creating a browser context and checking the auth.json file
            var context = await browser.NewContextAsync(new BrowserNewContextOptions { StorageStatePath = "auth.json" });

            //Creating a new page or tab in the browser
            Page = await context.NewPageAsync();

            //Navigating to the Integration studio URL
            await Page.GotoAsync("https://internal.integrationstudio.capdev-connect.aveva.com/");

            //await page.ClickAsync("#submit");

            //Clicking the Tenant name displayed from the list of Connect accounts and tenants
            await Page.ClickAsync("text=AV-Test2 ");

            //Waiting for the URL to sync with the integration studio url
            await Page.WaitForURLAsync("https://internal.integrationstudio.capdev-connect.aveva.com/projects");
        }


        [TearDown] //Runs after every test
        public async Task TearDown()
        {
            await browser.CloseAsync();
        }
    }
}
