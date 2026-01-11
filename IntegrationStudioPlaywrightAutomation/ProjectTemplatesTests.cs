using Microsoft.Playwright;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public async Task Verify_LHS_Menu_For_ProjectAdmin()
        {
            var projectadminlhsmenu = new ProjectTemplatesPage(Page);

            await Expect(projectadminlhsmenu.ProjectTemplatePage).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.LHSMenu).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.ProjectTemplates).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.SystemSuites).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.GlobalRDPRules).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.General).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.CollapseButtonContent).ToBeVisibleAsync();
            await projectadminlhsmenu.LHSMenu.WaitForAsync();
            await projectadminlhsmenu.LHSMenu.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_LHSMenu_For_ProjectAdmin.png"
            });

            //Click on the collapse button and check for the functionality
            await projectadminlhsmenu.CollapseButtonIcon.ClickAsync();
            await projectadminlhsmenu.CollapseButtonIcon.WaitForAsync();
            await Expect(projectadminlhsmenu.CollapseButtonContent).ToBeHiddenAsync();
            await projectadminlhsmenu.LHSMenu.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_Collapsed_LHSMenu.png"
            });

            //Click on the expand button
            await projectadminlhsmenu.CollapseButtonIcon.ClickAsync();
            await projectadminlhsmenu.LHSMenu.WaitForAsync();
            await Expect(projectadminlhsmenu.CollapseButtonContent).ToBeVisibleAsync();

            //Click on the System suites button
            await projectadminlhsmenu.SystemSuites.WaitForAsync();
            await projectadminlhsmenu.SystemSuites.ClickAsync();
           
            //Check and verify the system suites sub menu
            await Expect(projectadminlhsmenu.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.ManageSystemsuites).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.GlobalParameters).ToBeVisibleAsync();

            await projectadminlhsmenu.SystemsuitesSubMenu.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_Systemsuites_Submenu.png"
            });

            //Click on Manage system suites button
            await projectadminlhsmenu.ManageSystemsuites.ClickAsync();
            await projectadminlhsmenu.SystemSuitesPage.WaitForAsync();
            await Expect(projectadminlhsmenu.SystemSuitesPage).ToBeVisibleAsync();
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_SystemsuitesPage.png"
            });


            //Click on the Global Parameters button
            await projectadminlhsmenu.SystemSuites.WaitForAsync();
            await projectadminlhsmenu.SystemSuites.ClickAsync();
            await Expect(projectadminlhsmenu.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(projectadminlhsmenu.GlobalParameters).ToBeVisibleAsync();
            await projectadminlhsmenu.GlobalParameters.ClickAsync();
            await projectadminlhsmenu.GlobalParametersPage.WaitForAsync();
            await Expect(projectadminlhsmenu.GlobalParametersPage).ToBeVisibleAsync();
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_GlobalParametersPage.png"
            });

            //Click on the GlobalRDP rule button
            await projectadminlhsmenu.GlobalRDPRules.WaitForAsync();
            await projectadminlhsmenu.GlobalRDPRules.ClickAsync();
            await Expect(projectadminlhsmenu.GlobalRDPRulesPage).ToBeVisibleAsync();
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_GlobalRDPRulesPage.png"
            });

            //Click on the General option
            await projectadminlhsmenu.General.IsVisibleAsync();
            await projectadminlhsmenu.General.ClickAsync();
            await projectadminlhsmenu.GeneralSettingsPage.WaitForAsync();
            await Expect(projectadminlhsmenu.GeneralSettingsPage).ToBeVisibleAsync();
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_GeneralPage.png"
            });
        }

        [Test]
        public async Task Verify_LHSMenu_For_ProjectUser()
        {
            var projectuserlhsmenu = new ProjectTemplatesPage(Page);

            //Check for the project template page and General Page
            await Expect(projectuserlhsmenu.ProjectTemplatePage).ToBeVisibleAsync();
            await Expect(projectuserlhsmenu.LHSMenu).ToBeVisibleAsync();
            await Expect(projectuserlhsmenu.ProjectTemplates).ToBeVisibleAsync();
            await Expect(projectuserlhsmenu.General).ToBeVisibleAsync();
            await Expect(projectuserlhsmenu.CollapseButtonContent).ToBeVisibleAsync();
            await projectuserlhsmenu.LHSMenu.WaitForAsync();

            //Verify that the system suites and Global RDP rules page is not visible
            await Expect(projectuserlhsmenu.SystemSuites).Not.ToBeVisibleAsync();
            await Expect(projectuserlhsmenu.GlobalRDPRules).Not.ToBeVisibleAsync();
            await projectuserlhsmenu.LHSMenu.WaitForAsync();
            await projectuserlhsmenu.LHSMenu.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_LHSMenu_for_ProjectUser.png"
            });
            
        }

        [Test]
        public async Task Verify_UserProfile_Button()
        {
            var userprofile = new ProjectTemplatesPage(Page);

            //Check the user profile button and items in it
            await userprofile.UserProfileIcon.WaitForAsync();
            await Expect(userprofile.UserProfileIcon).ToBeVisibleAsync();
            await userprofile.UserProfileIcon.ClickAsync();

            //Popup appears
            await userprofile.UserProfilePopUp.WaitForAsync();
            await Expect(userprofile.UserProfilePopUp).ToBeVisibleAsync();

            await Expect(userprofile.UserName).ToBeVisibleAsync();
            await Expect(userprofile.UserName).ToBeEnabledAsync();

            await userprofile.TenantName.WaitForAsync();
            await Expect(userprofile.TenantName).ToBeVisibleAsync();

            await Expect(userprofile.NetworkSpeedTest).ToBeVisibleAsync();
            await Expect(userprofile.NetworkSpeedTest).ToBeEnabledAsync();

            await Expect(userprofile.LogOut).ToBeVisibleAsync();
            await Expect(userprofile.LogOut).ToBeEnabledAsync();

            await userprofile.CopyRightAndLegal.WaitForAsync();
            await Expect(userprofile.CopyRightAndLegal).ToBeVisibleAsync();

            await userprofile.UserProfilePopUp.HighlightAsync();
            await userprofile.UserProfilePopUp.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_UserProfile_Popup.png"
            });
        }

        [Test]
        public async Task Verify_UserProfile_Popup_Message()
        {
            var userprofilepopupmessage = new ProjectTemplatesPage(Page);

            await Expect(userprofilepopupmessage.UserProfileIcon).ToBeVisibleAsync();
            await userprofilepopupmessage.UserProfileIcon.ClickAsync();
            await userprofilepopupmessage.UserProfilePopUp.WaitForAsync();
            await Expect(userprofilepopupmessage.UserProfilePopUp).ToBeVisibleAsync();

            await Expect(userprofilepopupmessage.UserName).ToBeEnabledAsync();
            await userprofilepopupmessage.UserName.ClickAsync();

            await userprofilepopupmessage.UserProfileDialog.WaitForAsync();
            await Expect(userprofilepopupmessage.UserProfileDialog).ToBeVisibleAsync();

            await Expect(userprofilepopupmessage.UserProfileContent).ToBeVisibleAsync();
            await Expect(userprofilepopupmessage.UserProfileEmail).ToBeVisibleAsync();
            await Expect(userprofilepopupmessage.UserProfileSubscription).ToBeVisibleAsync();

            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_UserProfileDialog.png"
            });

            await Expect(userprofilepopupmessage.UserProfileCloseButton).ToBeVisibleAsync();
            await userprofilepopupmessage.UserProfileCloseButton.ClickAsync();
            await userprofilepopupmessage.UserProfileDialog.IsHiddenAsync();
        }

        [Test]
        public async Task Verify_NetworkSpeed_Test_Option()
        {
            var networkspeedtest = new ProjectTemplatesPage(Page);

            await Expect(networkspeedtest.UserProfileIcon).ToBeVisibleAsync();
            await networkspeedtest.UserProfileIcon.ClickAsync();
            await networkspeedtest.UserProfilePopUp.WaitForAsync();
            await Expect(networkspeedtest.UserProfilePopUp).ToBeVisibleAsync();

            await Expect(networkspeedtest.NetworkSpeedTest).ToBeVisibleAsync();

            var networkspeedtestpage = await Page.RunAndWaitForPopupAsync(async() =>
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

        [Test]
        public async Task Verify_LogOut_Button()
        {
            var logout = new ProjectTemplatesPage(Page);

            await Expect(logout.UserProfileIcon).ToBeVisibleAsync();
            await logout.UserProfileIcon.ClickAsync();
            await logout.UserProfilePopUp.WaitForAsync();
            await Expect(logout.UserProfilePopUp).ToBeVisibleAsync();

            await Expect(logout.LogOut).ToBeVisibleAsync();
            await logout.LogOut.ClickAsync();
            await Page.ScreenshotAsync(new()
            {
                Path="Screenshot_Soon_AfterClicking_Logout_Button.png"
            });
            await Page.WaitForURLAsync("https://profile.capdev-connect.aveva.com/singlesignout?returnTo**");
            await Page.WaitForLoadStateAsync();
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_AfterClicking_Logout_Button_Later.png"
            });
        }

        [Test]
        public async Task Verify_LegalLink_Button()
        {
            var legallink = new ProjectTemplatesPage(Page);
            await Expect(legallink.UserProfileIcon).ToBeVisibleAsync();
            await legallink.UserProfileIcon.ClickAsync();
            await legallink.UserProfilePopUp.WaitForAsync();
            await Expect(legallink.UserProfilePopUp).ToBeVisibleAsync();

            await Expect(legallink.CopyRightAndLegal).ToBeVisibleAsync();
            await Expect(legallink.LegalLink).ToBeEnabledAsync();

            var legallinkpage = await Page.RunAndWaitForPopupAsync(async() =>
            {
                await legallink.LegalLink.ClickAsync();
            });

            await Expect(legallinkpage).ToHaveURLAsync(new Regex(@".*/en/legal/.*"));
            await legallinkpage.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_LegalLinkPage.png"
            });
            await legallinkpage.Locator("//h1[text()='Legal Resources']").WaitForAsync();
            await Expect(legallinkpage.Locator("//h1[text()='Legal Resources']")).ToBeVisibleAsync();

        }

        [Test]
        public async Task Verify_ProjectTemplatePage_when_no_templates_added()
        {
            var noprojecttemplates = new ProjectTemplatesPage(Page);
            await Expect(noprojecttemplates.LHSMenu).ToBeVisibleAsync();
            await Expect(noprojecttemplates.NoProjectTemplates).ToBeVisibleAsync();
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_NoProjectTemplatesPage.png"
            });
        }

        [Test]
        public async Task Verify_3dots_menu_Of_ProjectTemplate()
        {
            var threedotmenu = new ProjectTemplatesPage(Page);
            int rowcount = await threedotmenu.projectrows.CountAsync();
            Assert.Greater(rowcount, 0, "No project templates are available");
            await Expect(threedotmenu.ThreeDot).ToBeVisibleAsync();
            await threedotmenu.ThreeDot.ClickAsync();

            await Page.ScreenshotAsync(new()
            {
               Path = "Screenshot_Of_3DotMenu.png"
            });

            await Expect(threedotmenu.ThreeDotmenuPopup).ToBeVisibleAsync();
            await Expect(threedotmenu.ThreeDotMenuNewinstance).ToBeVisibleAsync();
            await Expect(threedotmenu.ThreeDotMenuEdit).ToBeVisibleAsync();
            await Expect(threedotmenu.ThreeDotMenuDelete).ToBeVisibleAsync();
        }

        [Test]
        public async Task Verify_ProjectTemplates_Can_Be_Edited()
        {
            var projecttemplateedit = new ProjectTemplatesPage(Page);
            int rowcount = await projecttemplateedit.projectrows.CountAsync();
            Assert.Greater(rowcount, 0, "No project templates are available");
            await Expect(projecttemplateedit.ThreeDot).ToBeVisibleAsync();
            await projecttemplateedit.ThreeDot.ClickAsync();
         
            await Expect(projecttemplateedit.ThreeDotmenuPopup).ToBeVisibleAsync();
            await Expect(projecttemplateedit.ThreeDotMenuEdit).ToBeVisibleAsync();
            await projecttemplateedit.ThreeDotMenuEdit.ClickAsync();

            await projecttemplateedit.ProjectTemplateEdit.WaitForAsync();
            await Expect(projecttemplateedit.ProjectTemplateEdit).ToBeVisibleAsync();
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_EditProjectTemplate.png"
            });
        }

    }
}
