using Microsoft.Playwright;
using NUnit.Framework;



namespace IntegrationStudioPlaywrightAutomation.Auth
{
    public class Authentication
    {
        [Test]
        public async Task AuthenticationSetUp()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(
                                new BrowserTypeLaunchOptions
                                {
                                    Headless = false
                                });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.GotoAsync("https://internal.integrationstudio.capdev-connect.aveva.com/");
            var email = Environment.GetEnvironmentVariable("Authentication_Email");
            await page.FillAsync("#email", email);
            await page.ClickAsync("#submit");
            var password = Environment.GetEnvironmentVariable("Authentication_Password");
            await page.FillAsync("#i0118", password);
            await page.ClickAsync("#idSIButton9");
            await page.ClickAsync("#idSIButton9");

            await page.WaitForURLAsync("**/solutions**");
            await context.StorageStateAsync(new()
            {
                Path = "auth.json"
            });
            Console.WriteLine("Saved auth.json at: " + Directory.GetCurrentDirectory());
            await browser.CloseAsync();
        }
    }

}
