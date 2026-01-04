using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace IntegrationStudioPlaywrightAutomation.Tests
{
    public class NavigationBarPage:BaseTest
    {
        [Test]
        public async Task NavigationBar_Should_Be_Visible()
        {

            var title = await page.TitleAsync();
            Console.WriteLine(title);
            //Assert.Equals(title, "Integration Studio");
            await page.ScreenshotAsync(new()
            {
                Path = "NavigationBarScreenshot.png"
            });
        }
    }
}
