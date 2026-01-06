using Microsoft.Playwright;
using NUnit.Framework;



namespace IntegrationStudioPlaywrightAutomation
{
    public class Authentication 
    {
        [Test]
        public async Task AuthenticationSetUp()
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
            var context = await browser.NewContextAsync();

            //Creating a page object which is similar to browser tab
            var page = await context.NewPageAsync();

            //Navigate to the Integration Studio URL
            await page.GotoAsync("https://internal.integrationstudio.capdev-connect.aveva.com/");

            //Creating an environment variable for the email 
            var email = Environment.GetEnvironmentVariable("Authentication_Email");

            //Entering the email
            await page.FillAsync("#email", email);

            //Clicking on the sign in button 
            await page.ClickAsync("#submit");

            //Creating an environment variable for the email password
            var password = Environment.GetEnvironmentVariable("Authentication_Password");

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
                Path = "auth.json"
            });

            //Printing the directory 
            Console.WriteLine("Saved auth.json at: " + Directory.GetCurrentDirectory());

            //Closing the browser 
            await browser.CloseAsync();
        }
    }

}
