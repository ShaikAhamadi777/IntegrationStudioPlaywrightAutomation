using IntegrationStudioPlaywrightAutomation.Locators;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationStudioPlaywrightAutomation.CoreFunctionalTests.NavigationBar
{
    internal class NetworkSpeed_Tests : BaseTest
    {
        [Test]
        public async Task Verify_NetworkSpeed_Test_Option()
        {
            var networkspeedtest = new ProjectTemplatesPage(Page);

            await Expect(networkspeedtest.UserProfileIcon).ToBeVisibleAsync();
            await networkspeedtest.UserProfileIcon.ClickAsync();
            await networkspeedtest.UserProfilePopUp.WaitForAsync();
            await Expect(networkspeedtest.UserProfilePopUp).ToBeVisibleAsync();

            await Expect(networkspeedtest.NetworkSpeedTest).ToBeVisibleAsync();

            var networkspeedtestpage = await Page.RunAndWaitForPopupAsync(async () =>
            {
                await networkspeedtest.NetworkSpeedTest.ClickAsync();
            });

            Assert.IsTrue(networkspeedtestpage.Url.Contains("https://verify.integrationstudio.dev-connect.aveva.com/speedtest"));

            await Expect(networkspeedtestpage).ToHaveURLAsync(new Regex(@".*/speedtest.*"));

            await Expect(networkspeedtestpage.Locator("//span[@role='progressbar']")).ToBeVisibleAsync();
            await networkspeedtestpage.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NetworkSpeedTest_ProgressBar.png"
            });

            Task.Delay(200000);
            //Check the network speed test page elements 
            await Expect(networkspeedtestpage.Locator("#speedtest-title")).ToBeVisibleAsync();
            await networkspeedtestpage.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NetworkSpeedTest_Title.png"
            });

            await Expect(networkspeedtestpage.Locator("//p[contains(text(),'We are testing your network speed')]")).ToContainTextAsync("We are testing your network speed to our data centers across the globe. Based on our tests, we will let you know the data center that can provide you with the best experience possible");
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            Task.Delay(700000);
            //await Expect(networkspeedtestpage.Locator("//span[@role='progressbar']")).Not.ToBeVisibleAsync();
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            Task.Delay(700000);
            await Expect(networkspeedtestpage.Locator("//p[contains(text(),'Based on our test')]")).ToBeVisibleAsync();
            Task.Delay(700000);
            await Expect(networkspeedtestpage.Locator("//p[contains(text(),'Based on our test')]")).ToContainTextAsync("Based on our test, these data centers will provide you with the best experience possible");
            //await Expect(networkspeedtestpage.Locator("#show-more-center-btn")).ToContainTextAsync("Show other data centers");
            //await Expect(networkspeedtestpage.Locator("#show-more-center-btn")).ToBeVisibleAsync();
            /*await Expect(networkspeedtestpage.Locator("#speedtest-rerun-btn")).ToContainTextAsync("Rerun tests");

            await networkspeedtestpage.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NetworkSpeedTest_Page.png"
            });

            //Click the show more data centers button
            await networkspeedtestpage.Locator("#show-more-center-btn").ClickAsync();
            await networkspeedtestpage.WaitForLoadStateAsync();

            await networkspeedtestpage.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NetworkSpeedTest_AfterClicking_ShowDataCentres_Button.png"
            });

            await networkspeedtestpage.Locator("#show-more-center-btn").IsHiddenAsync();
            await networkspeedtestpage.Locator("#speedtest-rerun-btn").ClickAsync();

            await networkspeedtestpage.WaitForLoadStateAsync();
            await Expect(networkspeedtestpage.Locator("//p[contains(text(),'We are testing your network speed')]")).ToBeVisibleAsync();
            await Expect(networkspeedtestpage.Locator("//span[@role='progressbar']")).ToBeVisibleAsync();

            await networkspeedtestpage.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NetworkSpeedTest_AfterClicking_Rerun_Button.png"
            });*/

        }


    }
}
