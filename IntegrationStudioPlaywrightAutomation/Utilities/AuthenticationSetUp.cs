using Microsoft.Playwright;
using NUnit.Framework;
using IntegrationStudioPlaywrightAutomation.Utilities;



namespace IntegrationStudioPlaywrightAutomation.Utilities
{
    public class AuthenticationSetUp
    {
        
        public static async Task GenerateAuthState(string role, string Authentication_Email, string Authentication_Password, string outputFile)
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


            /*string tenantName = Environment.GetEnvironmentVariable(Tenant);

            if (string.IsNullOrEmpty(tenantName))
            {
                throw new Exception($"Missing tenant env var for {role}");
            }

            //await page.GetByText(tenantName, new() { Exact = true }).ClickAsync();


            await page.Locator("text=" + tenantName).First.ClickAsync();*/

            //Entering the email
            await page.FillAsync("#email", email);

            //Clicking on the sign in button 
            await page.ClickAsync("#submit");

            //Entering the password in the textbox
            await page.FillAsync("#i0118", password);

            //Clicking the submit button
            await page.ClickAsync("#idSIButton9");

            //Clicking the yes button in the popup after authentication
            await page.ClickAsync("#idSIButton9");

            //Waiting for the URL to be displayed - the CONNECT Page 
            await page.WaitForURLAsync("**/solutions**");


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
