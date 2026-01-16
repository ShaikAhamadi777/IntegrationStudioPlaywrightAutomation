using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationStudioPlaywrightAutomation.Locators;
using Microsoft.Playwright;

namespace IntegrationStudioPlaywrightAutomation.ComponentTests
{
    public class SystemSuites_UI_Tests : BaseTest
    {
        [Test]
        public async Task OpenSystemSuitesPage()
        {
            var systemsuites = new SystemSuitesPage(Page);

            await Expect(systemsuites.LHSMenu).ToBeVisibleAsync();
            await Expect(systemsuites.SystemSuites).ToBeVisibleAsync();

            //Click on the System suites button
            await systemsuites.SystemSuites.WaitForAsync();
            await systemsuites.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(systemsuites.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(systemsuites.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(systemsuites.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(systemsuites.ManageSystemsuites).ToBeVisibleAsync();
            await systemsuites.ManageSystemsuites.ClickAsync();

            await systemsuites.ManageSystemSuitesPage.WaitForAsync();
            await Expect(systemsuites.ManageSystemSuitesPage).ToBeVisibleAsync();
        }

        [Test]
        public async Task OpenSystemSuitesPage_ShouldContain_TitleSubTitle()
        {
            var title = new SystemSuitesPage(Page);

            await Expect(title.SystemSuites).ToBeVisibleAsync();

            //Click on the System suites button
            await title.SystemSuites.WaitForAsync();
            await title.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(title.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(title.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(title.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(title.ManageSystemsuites).ToBeVisibleAsync();
            await title.ManageSystemsuites.ClickAsync();

            //Check if the Manage system suite page is visible
            await title.ManageSystemSuitesPage.WaitForAsync();
            await Expect(title.ManageSystemSuitesPage).ToBeVisibleAsync();

            //Check for the System suite title 
            await Expect(title.SystemSuiteTitle).ToBeVisibleAsync();
            title.SystemSuiteTitle.Equals("System suites");

            //Check for the system suites sub title
            await Expect(title.SystemSuitesSubTitle).ToBeVisibleAsync();
            title.SystemSuitesSubTitle.Equals("Create and manage system suites used by your project templates.");

        }

        [Test]
        public async Task OpenSystemSuitesPage_ShouldContain_SystemSuitesInUse()
        {
            var InUse = new SystemSuitesPage(Page);

            //Click on the System suites button
            await InUse.SystemSuites.WaitForAsync();
            await InUse.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(InUse.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(InUse.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(InUse.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(InUse.ManageSystemsuites).ToBeVisibleAsync();
            await InUse.ManageSystemsuites.ClickAsync();

            //Check if the Manage system suite page is visible
            await InUse.ManageSystemSuitesPage.WaitForAsync();
            await Expect(InUse.ManageSystemSuitesPage).ToBeVisibleAsync();

            //Check for the System suites words in use
            await Expect(InUse.SystemSuitesInUse).ToBeVisibleAsync();
            await InUse.SystemSuitesInUse.ScreenshotAsync(new()
            {
                Path = "ScreenShot_Of_SystemSuitesInUse_Wordings.png"
            });
        }

        [Test]
        public async Task OpenSystemSuitesPage_ShouldContain_UploadFileButton()
        {
            var UploadFile = new SystemSuitesPage(Page);

            if(await UploadFile.SystemSuites.IsVisibleAsync())
            {
                await UploadFile.SystemSuites.WaitForAsync();
                await UploadFile.SystemSuites.ClickAsync();

                //Check and verify the system suites sub menu
                await Expect(UploadFile.SystemsuitesSubMenu).ToBeVisibleAsync();
                await Expect(UploadFile.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
                await Expect(UploadFile.SystemsuitesSubMenuClose).ToBeVisibleAsync();
                await Expect(UploadFile.ManageSystemsuites).ToBeVisibleAsync();
                await UploadFile.ManageSystemsuites.ClickAsync();

                //Check if the Manage system suite page is visible
                await UploadFile.ManageSystemSuitesPage.WaitForAsync();
                await Expect(UploadFile.ManageSystemSuitesPage).ToBeVisibleAsync();

                if(await UploadFile.SystemSuiteTypeGlobal.First.IsVisibleAsync())
                {
                    await UploadFile.UploadFileButton.WaitForAsync();
                    await Expect(UploadFile.UploadFileButton).ToBeVisibleAsync();
                    await UploadFile.UploadFileButton.ScreenshotAsync(new()
                    {
                        Path = "ScreenShot_Of_UploadFileButton.png"
                    });
                }
                else
                {
                    await Expect(UploadFile.UploadFileButton).ToBeHiddenAsync();
                }
            }
            else
            {
                Console.WriteLine("The User is project user , hence system suites option is not visible");
                await Expect(UploadFile.SystemSuites).ToBeHiddenAsync();
            }
        }

        [Test]
        public async Task OpenSystemSuitesPage_ShouldContain_SystemSuiteTable_AndTableHeading()
        {
            var table = new SystemSuitesPage(Page);

            if (await table.SystemSuites.IsVisibleAsync())
            {
                await table.SystemSuites.WaitForAsync();
                await table.SystemSuites.ClickAsync();

                //Check and verify the system suites sub menu
                await Expect(table.SystemsuitesSubMenu).ToBeVisibleAsync();
                await Expect(table.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
                await Expect(table.SystemsuitesSubMenuClose).ToBeVisibleAsync();
                await Expect(table.ManageSystemsuites).ToBeVisibleAsync();
                await table.ManageSystemsuites.ClickAsync();

                //Check if the Manage system suite page is visible
                await table.ManageSystemSuitesPage.WaitForAsync();
                await Expect(table.ManageSystemSuitesPage).ToBeVisibleAsync();

                if (await table.UploadFileButton.IsVisibleAsync())
                {
                    await Expect(table.SystemSuitesTable).ToBeVisibleAsync();
                    await Expect(table.SystemSuitesTableColumns).ToBeVisibleAsync();
                    await Expect(table.SystemSuitesColumnNameHeading).ToBeVisibleAsync();
                    await Expect(table.SystemSuitesColumnSSType).ToBeVisibleAsync();
                    await Expect(table.SystemSuitesColumnEdited).ToBeVisibleAsync();
                    await table.SystemSuitesTableColumns.ScreenshotAsync(new()
                    {
                        Path = "Screenshot_Of_SystemSuiteTableColumns.png"
                    });
                }
                else
                {
                    await Expect(table.SystemSuitesTable).ToBeVisibleAsync();
                    await Expect(table.SystemSuitesTableColumns).ToBeVisibleAsync();
                    await Expect(table.SystemSuitesColumnNameHeading).ToBeVisibleAsync();
                    await Expect(table.SystemSuitesColumnSSType).ToBeHiddenAsync();
                    await Expect(table.SystemSuitesColumnEdited).ToBeVisibleAsync();
                    await table.SystemSuitesTableColumns.ScreenshotAsync(new()
                    {
                        Path = "Screenshot_Of_SystemSuiteTableColumns.png"
                    });
                }
            }
            else
            {
                Console.WriteLine("The User is project user , hence system suites option is not visible");
                await Expect(table.SystemSuites).ToBeHiddenAsync();
            }
        }

        [Test]
        public async Task OpenSystemSuitesPage_ShouldContain_SystemSuiteTableRows()
        {


        }
    }
}
