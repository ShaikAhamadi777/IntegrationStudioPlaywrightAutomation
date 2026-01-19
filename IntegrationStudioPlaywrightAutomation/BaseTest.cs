using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace IntegrationStudioPlaywrightAutomation
{
    public class BaseTest : PageTest
    {


        public override BrowserNewContextOptions ContextOptions()
        {
            var options = new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1510,
                    Height = 820
                }
            };

            var categories = TestContext.CurrentContext.Test.Properties["Category"] as IList;

            if (categories == null || categories.Count == 0)
                throw new Exception("No Category found. Role is required.");

            //string role = categories[0].ToString();
            string role =  categories.Contains("SystemAdmin") ? "SystemAdmin" :
                           categories.Contains("ExternalAdmin") ? "ExternalAdmin" :
                           categories.Contains("ProjectUser") ? "ProjectUser" :
                           throw new Exception("No valid role category found");


            options.StorageStatePath = role switch
            {
                "SystemAdmin" => "auth-systemadmin.json",
                "ProjectUser" => "auth-projectuser.json",
                "ExternalAdmin" => "auth-externaladmin.json",
                _ => throw new Exception($"Unknown role: {role}")
            };

            return options;
        }

        [SetUp] //Runs before every test
        public async Task SetUp()
        {

            //Navigating to the Integration studio URL
            await Page.GotoAsync("https://internal.integrationstudio.capdev-connect.aveva.com/");
            //await Page.ClickAsync("text=M-AVEVACHPQA");

            //await Expect(Page).ToHaveURLAsync("**/projects**");


            if (Page.Url.Contains("https://signin.dev-connect.aveva.com/login?state"))
            {
                var emailSignInButton = Page.Locator("#submit");
                await Expect(emailSignInButton).ToBeVisibleAsync();
                await emailSignInButton.ClickAsync();
            }
                await Page.WaitForURLAsync("https://profile.capdev-connect.aveva.com/solutions?state**");
                //Clicking the Tenant name displayed from the list of Connect accounts and tenants
                await Page.ClickAsync("text=M-AVEVACHPQA");
            
            //Waiting for the URL to sync with the integration studio url
            await Page.WaitForURLAsync("https://internal.integrationstudio.capdev-connect.aveva.com/projects");
        }

    }
}
