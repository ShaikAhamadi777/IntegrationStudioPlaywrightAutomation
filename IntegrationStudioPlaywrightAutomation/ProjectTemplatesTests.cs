using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationStudioPlaywrightAutomation
{
    public class ProjectTemplatesTests : BaseTest
    {

        [Test]
        public async Task Verify_AppBar()
        {

            var nav = new ProjectTemplatesPage(Page);

            //Verify if the AppBar is Visible
            await nav.AppBar.FocusAsync();
            await nav.AppBar.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NavigationBar.png"
            });
            await Expect(nav.AppBar).ToBeVisibleAsync();
            string title = await Page.TitleAsync();
            Console.WriteLine(title);
            await Expect(Page).ToHaveTitleAsync(title);

            //Verify if the Notification Bell Icon is Visible
            await nav.NotificationBellIcon.FocusAsync();
            await nav.NotificationBellIcon.ScreenshotAsync(new()
            {
                Path = "Screeshot_Of_NotificationBellIcon.png"
            });
            await Expect(nav.NotificationBellIcon).ToBeVisibleAsync();

            //Verify if the AVEVA Help Icon is Visible
            await nav.AVEVAHelpIcon.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_AVEVAHelpIcon.png"
            });
            await Expect(nav.AVEVAHelpIcon).ToBeVisibleAsync();

            //Verify if the User Profile Icon is Visible
            await nav.UserProfileIcon.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_UserProfileIcon.png"
            });
            await Expect(nav.UserProfileIcon).ToBeVisibleAsync();
        }

        [Test]
        public async Task Verify_HelpIcon_In_AppBar()
        {
            var helpicon = new ProjectTemplatesPage(Page);

            //Check for the AVEVA Help icon visibility
            await Expect(helpicon.AVEVAHelpIcon).ToBeVisibleAsync();

            //Capture the help page after clicking on the help icon
            var helppage = await Page.RunAndWaitForPopupAsync(async () =>
            {
                await helpicon.AVEVAHelpIcon.ClickAsync();
            });

            //Wait for the page to load
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            //Check if the Help Page URL is correct
            Assert.IsTrue(helppage.Url.Contains("https://aveva-dev.zoominsoftware.io/auth/login/?redirect"));
            await Expect(helppage).ToHaveURLAsync(new Regex(@".*/auth/login/.*"));

            //Wait for the page to load
            await Task.Delay(20000);

            //Check if the SignIn page is available then take a screenshot and click on the AVEVA Employee button
            if (await helppage.Locator("button[aria-label='AVEVA Employee']").IsVisibleAsync())
            {
                await helppage.ScreenshotAsync(new()
                {
                    Path = "Screenshot_Of_HelpPage_AfterClickingHelpIcon.png"
                });
                await helppage.Locator("button[aria-label='AVEVA Employee']").ClickAsync();

                //Wait for the AVEVA Help content to be loaded
                await helppage.WaitForURLAsync("https://aveva-dev.zoominsoftware.io/bundle/integration-studio/page/1370200.html");

                //Locate the AVEVA help page subheading and print the title
                await helppage.Locator("div.zDocsSubHeaderContainer").IsVisibleAsync();
                var Helppagetitle = await helppage.TitleAsync();
                Console.WriteLine(Helppagetitle);

                //Cick on the element present in the AVEVA Help page
                await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
                await helppage.Locator("button[aria-label='Hide table of contents']").ClickAsync();

            }
            await helppage.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_AVEVAHelpPage.png"
            });
        }

        [Test]
        public async Task Verify_LHS_Menu_Of_ProjectAdmin()
        {
            var projectadminlhsmenu = new ProjectTemplatesPage(Page);

            await Expect(projectadminlhsmenu.ProjectTemplatePage).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.LHSMenu).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.ProjectTemplates).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.SystemSuites).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.GlobalRDPRules).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.General).ToBeVisibleAsync();
            await projectadminlhsmenu.LHSMenu.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_LHSMenu.png"
            });
        }

    }
}
