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
            /*var options = new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1510,
                    Height = 820
                }
            };
            string role = RoleContext.Get();
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
            };*/

            //string role = RoleContext.Get();
            var args = TestContext.CurrentContext.Test.Arguments;

            if (args == null || args.Length == 0)
            {
                throw new Exception(
                    "Role not provided. Tests must use [TestCase(\"Role\")]"
                );
            }

            string role = args[0].ToString();

            TestContext.WriteLine($"[ContextOptions] Running as role: {role}");


            return new BrowserNewContextOptions
            {
                StorageStatePath = role switch
                {
                    "SystemAdmin" => "auth-systemadmin.json",
                    "ExternalAdmin" => "auth-externaladmin.json",
                    "ProjectUser" => "auth-projectuser.json",
                    _ => throw new Exception($"Unknown role: {role}")
                },
                ViewportSize = new ViewportSize
                {
                    Width = 1510,
                    Height = 820
                }
            };  
        }

        [SetUp] //Runs before every test
        public async Task SetUp()
        {
            //Navigating to the Integration studio URL
            await Page.GotoAsync("https://internal.integrationstudio.capdev-connect.aveva.com/");

            if (Page.Url.Contains("login") || Page.Url.Contains("signin") || Page.Url.Contains("solutions"))
            {
                throw new Exception(
                    "Authentication or tenant selection not completed. " +
                    "Regenerate auth JSON."
                );
            }

            //Waiting for the URL to sync with the integration studio url
            await Page.WaitForURLAsync("https://internal.integrationstudio.capdev-connect.aveva.com/projects");
        }
    }
}
