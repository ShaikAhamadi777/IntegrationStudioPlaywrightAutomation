using Microsoft.Playwright;
using NUnit.Framework;
using IntegrationStudioPlaywrightAutomation.Utilities;



namespace IntegrationStudioPlaywrightAutomation.Utilities
{
    public class AuthenticationSetUp
    {
        
        public static async Task GenerateAuthState(string role, string Authentication_Email, string Authentication_Password, string tenantEnvVar, string outputFile)
        {
            //Creating a playwright controller
            var playwright = await Playwright.CreateAsync();

            //Creating a browser object
            var browser = await playwright.Chromium.LaunchAsync(
                                new BrowserTypeLaunchOptions
                                {
                                    Headless = false
                                    
                                });

            //Creating a browser context or browser profile
            var context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = null
            });

            //Creating a page object which is similar to browser tab
            var page = await context.NewPageAsync();

            //Navigate to the Integration Studio URL
            await page.GotoAsync("https://internal.integrationstudio.capdev-connect.aveva.com/");

            //Creating an environment variable for the email 
            string email = Environment.GetEnvironmentVariable(Authentication_Email);
            string password = Environment.GetEnvironmentVariable(Authentication_Password);

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new Exception(
                    $"Missing environment variables for role: {role}");
            }
    
            //Entering the email
            await page.FillAsync("#email", email);
            //await page.ClickAsync("#email");
            await page.WaitForSelectorAsync("#submit");

            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

            bool isAvevaUser = email.EndsWith("@aveva.com", StringComparison.OrdinalIgnoreCase);

            if (isAvevaUser)
            { 
                // ===== AVEVA / Azure AD flow =====
                await page.Locator("#submit").IsVisibleAsync();
                await page.ClickAsync("#submit"); // Next
                await page.WaitForURLAsync("https://login.microsoftonline.com/aveva.onmicrosoft.com/**");

                //await page.Locator("#bannerLogo").IsVisibleAsync();
                await page.WaitForSelectorAsync("//div[text()='Enter password']");
                await page.Locator("//div[text()='Enter password']").IsVisibleAsync();
                await page.Locator("#i0118").IsVisibleAsync();
                await page.Locator("#i0118").IsEditableAsync();
                await page.FillAsync("#i0118", password);

                await page.WaitForSelectorAsync("#idSIButton9");
                await page.ClickAsync("#idSIButton9");

                //var mfaPrompt = page.Locator("text=Approve sign in request");
                //await mfaPrompt.IsVisibleAsync();

                await page.Locator("#idDiv_SAOTCAS_Title").IsVisibleAsync();

                await page.Locator("#idSIButton9").IsVisibleAsync();

                await page.Locator("//div[@class='row text-title']").IsVisibleAsync();
                await page.ClickAsync("#idSIButton9");
                await page.WaitForURLAsync("**/solutions**");
            }
            else
            {
                // ===== External user flow (Gmail / .tech) =====
                await page.ClickAsync("input[type='password']");
                await page.FillAsync("input[type='password']", password);
                await page.Locator("button[type='submit']").IsVisibleAsync();
                await page.Locator("button[type='submit']").IsEnabledAsync();
                await page.ClickAsync("button[type='submit']");
                await page.WaitForURLAsync("**/solutions**");
            }
            // Read tenant name from env var
            string tenantName = Environment.GetEnvironmentVariable(tenantEnvVar);

            if (string.IsNullOrWhiteSpace(tenantName))
            {
                throw new Exception($"Tenant env var missing for role {role}");
            }

            // Select tenant
            await page.GetByText(tenantName, new() { Exact = true }).ClickAsync();

            // Confirm we are inside tenant
            await page.WaitForURLAsync("https://internal.integrationstudio.capdev-connect.aveva.com/projects");


            //Creating a auth.json file to store the authentication state. Auth.json gets created in the bin directory
            await context.StorageStateAsync(new()
            {
                Path = outputFile
            });

            Console.WriteLine($"Auth state saved for {role}: {outputFile}");

            //Closing the browser 
            await browser.CloseAsync();
        }
    }
}
