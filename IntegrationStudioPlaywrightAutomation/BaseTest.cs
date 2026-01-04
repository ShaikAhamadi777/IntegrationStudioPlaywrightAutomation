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
        protected IPage page;
        protected IBrowser browser;
        protected IPlaywright playwright;
        
        [SetUp]
        public async Task SetUp()
        {
            playwright = await Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 50, });
            var context = await browser.NewContextAsync(new BrowserNewContextOptions { StorageStatePath = "auth.json" });
            page = await context.NewPageAsync();
            await page.GotoAsync("https://internal.integrationstudio.capdev-connect.aveva.com/");
            //await page.ClickAsync("#submit");
            await page.ClickAsync("text=AV-Test2 ");
            await page.WaitForURLAsync("https://internal.integrationstudio.capdev-connect.aveva.com/projects");
        }
        [TearDown]
        public async Task TearDown()
        {
            await browser.CloseAsync();
        }
    }
}
