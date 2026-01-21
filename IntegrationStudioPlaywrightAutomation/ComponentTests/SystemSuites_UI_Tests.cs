using IntegrationStudioPlaywrightAutomation.Locators;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IntegrationStudioPlaywrightAutomation.ComponentTests
{
    public class SystemSuites_UI_Tests : BaseTest
    {

        [Test]
        [TestCase("SystemAdmin")]
        [TestCase("ExternalAdmin")]
        [Category("Admins")]
        public async Task OpenSystemSuitesPage_ShouldBeVisible_ForAdmins(string role)
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

            await systemsuites.ManageSystemSuitesPage.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_SystemSuitesPage_ForSystemAndExternalAdmins.png"
            });
        }

        [Test]
        [TestCase("ProjectUser")]
        [Category("ProjectUser")]
        public async Task OpenSystemSuitesPage_ShouldNot_BeVisible_ForProjectUser(string role)
        {
            var psystemsuites = new SystemSuitesPage(Page);

            await psystemsuites.LHSMenu.WaitForAsync();
            await Expect(psystemsuites.LHSMenu).ToBeVisibleAsync();
            await Expect(psystemsuites.SystemSuites).ToBeHiddenAsync();
            Console.WriteLine("ProjectUser: System Suites option is not visible as expected");
            await psystemsuites.LHSMenu.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_SystemSuitesPage_ForProjectuser.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [TestCase("ExternalAdmin")]
        [Category("Admins")]
        public async Task OpenSystemSuitesPage_ShouldContain_TitleSubTitle_ForAdmins(string role)
        {
            var title = new SystemSuitesPage(Page);
            await Expect(title.LHSMenu).ToBeVisibleAsync();

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

            await title.SystemSuiteTitle.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_SystemSuitesPage_Title.png"
            });

            //Check for the system suites sub title
            await Expect(title.SystemSuitesSubTitle).ToBeVisibleAsync();
            title.SystemSuitesSubTitle.Equals("Create and manage system suites used by your project templates.");

        }

        [Test]
        [TestCase("SystemAdmin")]
        [TestCase("ExternalAdmin")]
        [Category("Admins")]
        public async Task OpenSystemSuitesPage_ShouldContain_SystemSuitesInUse_ForAdmins(string role)
        {
            var InUse = new SystemSuitesPage(Page);

            await Expect(InUse.LHSMenu).ToBeVisibleAsync();

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
        [TestCase("SystemAdmin")]
        [Category("SystemAdmin")]
        public async Task OpenSystemSuitesPage_ShouldContain_UploadFileButton_ForSystemAdmin(string role)
        {
            var UploadFile = new SystemSuitesPage(Page);

            await Expect(UploadFile.LHSMenu).ToBeVisibleAsync();
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


            await UploadFile.UploadFileButton.WaitForAsync();
            await Expect(UploadFile.UploadFileButton).ToBeVisibleAsync();
            await UploadFile.UploadFileButton.ScreenshotAsync(new()
            {
                Path = "ScreenShot_Of_UploadFileButton_ForSystemAdmin.png"
            });
        }


        [Test]
        [TestCase("ExternalAdmin")]
        [Category("ExternalAdmin")]
        public async Task OpenSystemSuitesPage_ShouldNotContain_UploadFileButton_ForExternalAdmin(string role)
        {
            var ExtUploadFile = new SystemSuitesPage(Page);

            await Expect(ExtUploadFile.LHSMenu).ToBeVisibleAsync();
            await ExtUploadFile.SystemSuites.WaitForAsync();
            await ExtUploadFile.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(ExtUploadFile.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(ExtUploadFile.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(ExtUploadFile.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(ExtUploadFile.ManageSystemsuites).ToBeVisibleAsync();
            await ExtUploadFile.ManageSystemsuites.ClickAsync();
            await ExtUploadFile.ManageSystemSuitesPage.WaitForAsync();

            await Expect(ExtUploadFile.UploadFileButton).ToBeHiddenAsync();
            Console.WriteLine("The User is logged in as an external admin, hence the user should not see the upload file button");

            await ExtUploadFile.ManageSystemSuitesPage.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_UploadFileButton_NotPresent_ForExternalAdmin.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("SystemAdmin")]
        public async Task OpenSystemSuitesPage_ShouldContain_AllColumnHeadings_ForSystemAdmin(string role)
        {
            var table = new SystemSuitesPage(Page);

            await Expect(table.LHSMenu).ToBeVisibleAsync();
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

            await Expect(table.SystemSuitesTable).ToBeVisibleAsync();
            await Expect(table.SystemSuitesTableColumns).ToBeVisibleAsync();
            await Expect(table.SystemSuitesColumnNameHeading).ToBeVisibleAsync();
            await Expect(table.SystemSuitesColumnSSType).ToBeVisibleAsync();
            await Expect(table.SystemSuitesColumnEdited).ToBeVisibleAsync();
            await table.SystemSuitesTableColumns.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_SystemSuiteTableColumns_ForSystemAdmin.png"
            });
        }

        [Test]
        [TestCase("ExternalAdmin")]
        [Category("ExternalAdmin")]
        public async Task OpenSystemSuitesPage_ShouldNotContain_SystemSuiteTypeColumnHeading_ForExternalAdmin(string role)
        {
            var Exttable = new SystemSuitesPage(Page);

            await Expect(Exttable.LHSMenu).ToBeVisibleAsync();
            await Exttable.SystemSuites.WaitForAsync();
            await Exttable.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(Exttable.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(Exttable.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(Exttable.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(Exttable.ManageSystemsuites).ToBeVisibleAsync();
            await Exttable.ManageSystemsuites.ClickAsync();

            //Check if the Manage system suite page is visible
            await Exttable.ManageSystemSuitesPage.WaitForAsync();
            await Expect(Exttable.ManageSystemSuitesPage).ToBeVisibleAsync();
            await Expect(Exttable.SystemSuitesTable).ToBeVisibleAsync();
            await Expect(Exttable.SystemSuitesTableColumns).ToBeVisibleAsync();
            await Expect(Exttable.SystemSuitesColumnNameHeading).ToBeVisibleAsync();
            await Expect(Exttable.SystemSuitesColumnSSType).ToBeHiddenAsync();
            await Expect(Exttable.SystemSuitesColumnEdited).ToBeVisibleAsync();
            await Exttable.SystemSuitesTableColumns.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_SystemSuiteTableColumns_ForExternalAdmin.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("SystemAdmin")]
        public async Task OpenSystemSuitesPage_ShouldContain_AllColumnsRows_ForSystemAdmin(string role)
        {
            var tablerows = new SystemSuitesPage(Page);

            await Expect(tablerows.LHSMenu).ToBeVisibleAsync();

            await tablerows.SystemSuites.WaitForAsync();
            await tablerows.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(tablerows.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(tablerows.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(tablerows.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(tablerows.ManageSystemsuites).ToBeVisibleAsync();
            await tablerows.ManageSystemsuites.ClickAsync();

            //Check if the Manage system suite page is visible
            await tablerows.ManageSystemSuitesPage.WaitForAsync();
            await Expect(tablerows.ManageSystemSuitesPage).ToBeVisibleAsync();

            await Expect(tablerows.SystemSuitesTableRows.First).ToBeVisibleAsync();
            await tablerows.SystemSuitesTableRows.First.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_SystemSuiteTableRow_ForSystemAdmin.png"
            });
        }

        [Test]
        [TestCase("ExternalAdmin")]
        [Category("ExternalAdmin")]
        public async Task OpenSystemSuitesPage_ShouldNotContain_SystemSuiteTypeColumnRows_ForExternalAdmin(string role)
        {
            var tablerows = new SystemSuitesPage(Page);

            await Expect(tablerows.LHSMenu).ToBeVisibleAsync();

            await tablerows.SystemSuites.WaitForAsync();
            await tablerows.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(tablerows.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(tablerows.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(tablerows.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(tablerows.ManageSystemsuites).ToBeVisibleAsync();
            await tablerows.ManageSystemsuites.ClickAsync();

            //Check if the Manage system suite page is visible
            await tablerows.ManageSystemSuitesPage.WaitForAsync();
            await Expect(tablerows.ManageSystemSuitesPage).ToBeVisibleAsync();

            await Expect(tablerows.SystemSuitesTableRows.First).ToBeVisibleAsync();
            await tablerows.SystemSuitesTableRows.First.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_SystemSuiteTableRow_ForSystemAdmin.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("SystemAdmin")]
        public async Task OpenSystemSuitesPage_ShouldContain_GlobalSS_ForSystemAdmin(string role)
        {
            var SAdminglobal = new SystemSuitesPage(Page);

            await Expect(SAdminglobal.LHSMenu).ToBeVisibleAsync();

            await SAdminglobal.SystemSuites.WaitForAsync();
            await SAdminglobal.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(SAdminglobal.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(SAdminglobal.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(SAdminglobal.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(SAdminglobal.ManageSystemsuites).ToBeVisibleAsync();
            await SAdminglobal.ManageSystemsuites.ClickAsync();

            //Check if the Manage system suite page is visible
            await SAdminglobal.ManageSystemSuitesPage.WaitForAsync();
            await Expect(SAdminglobal.ManageSystemSuitesPage).ToBeVisibleAsync();
            await Expect(SAdminglobal.SystemSuitesTable).ToBeVisibleAsync();
            await Expect(SAdminglobal.SystemSuitesTableRows.First).ToBeVisibleAsync();

            await SAdminglobal.SystemSuiteTypeGlobal.First.WaitForAsync();
            await Expect(SAdminglobal.SystemSuiteTypeGlobal.First).ToBeVisibleAsync();
            Console.WriteLine("System suite type is Global which is present");

            await SAdminglobal.SystemSuiteTypeGlobal.First.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_SystemSuiteType_Global_ForSystemAdmin.png"
            });
        }

        [Test]
        [TestCase("ExternalAdmin")]
        [Category("ExternalAdmin")]
        public async Task OpenSystemSuitesPage_ShouldNotContain_GlobalSS_ForExternalAdmin(string role)
        {
            var EAdminglobal = new SystemSuitesPage(Page);

            await Expect(EAdminglobal.LHSMenu).ToBeVisibleAsync();

            await EAdminglobal.SystemSuites.WaitForAsync();
            await EAdminglobal.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(EAdminglobal.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(EAdminglobal.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(EAdminglobal.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(EAdminglobal.ManageSystemsuites).ToBeVisibleAsync();
            await EAdminglobal.ManageSystemsuites.ClickAsync();

            //Check if the Manage system suite page is visible
            await EAdminglobal.ManageSystemSuitesPage.WaitForAsync();
            await Expect(EAdminglobal.ManageSystemSuitesPage).ToBeVisibleAsync();
            await Expect(EAdminglobal.SystemSuitesTable).ToBeVisibleAsync();
            await Expect(EAdminglobal.SystemSuitesTableRows.First).ToBeVisibleAsync();
            await Expect(EAdminglobal.SystemSuiteTypeGlobal.First).ToBeHiddenAsync();
            Console.WriteLine("System suite type is Global which is not present because of external admin role");
            await EAdminglobal.SystemSuitesTable.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_SystemSuiteType_Global_NotPresent_ForExternalAdmin.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("SystemAdmin")]
        public async Task OpenSystemSuitesPage_ShouldContain_TenantLevelSS_ForSystemAdmin(string role)
        {
            var tenant = new SystemSuitesPage(Page);

            await Expect(tenant.LHSMenu).ToBeVisibleAsync();
            await tenant.SystemSuites.WaitForAsync();
            await tenant.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(tenant.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(tenant.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(tenant.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(tenant.ManageSystemsuites).ToBeVisibleAsync();
            await tenant.ManageSystemsuites.ClickAsync();

            //Check if the Manage system suite page is visible
            await tenant.ManageSystemSuitesPage.WaitForAsync();
            await Expect(tenant.ManageSystemSuitesPage).ToBeVisibleAsync();
            await Expect(tenant.SystemSuitesTable).ToBeVisibleAsync();
            await Expect(tenant.SystemSuitesTableRows.First).ToBeVisibleAsync();

            if (await tenant.SystemSuiteTypeTenant.First.CountAsync() > 0)
            {
                await Expect(tenant.SystemSuiteTypeTenant.First).ToBeVisibleAsync();
                Console.WriteLine("Tenant level system suite is present in the system suites page");
                await tenant.SystemSuitesTable.ScreenshotAsync(new()
                {
                    Path = "Screenshot_Of_TenantLevel_SystemSuites_ForSystemAdmin.png"
                });
            }
            else
            {
                await Expect(tenant.SystemSuiteTypeTenant.First).ToBeHiddenAsync();
                Console.WriteLine("Tenant level system suite is not yet uploaded to the system suites page");
                await tenant.SystemSuitesTable.ScreenshotAsync(new()
                {
                    Path = "Screenshot_Of_TenantLevel_SystemSuitesNotYetUploaded_ForSystemAdmin.png"
                });
            }
        }

        [Test]
        [TestCase("ExternalAdmin")]
        [Category("ExternalAdmin")]
        public async Task OpenSystemSuitesPage_ShouldNotContain_TenantLevelSS_ForExternalAdmin(string role)
        {
            var Etenant = new SystemSuitesPage(Page);

            await Expect(Etenant.LHSMenu).ToBeVisibleAsync();
            await Etenant.SystemSuites.WaitForAsync();
            await Etenant.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(Etenant.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(Etenant.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(Etenant.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(Etenant.ManageSystemsuites).ToBeVisibleAsync();
            await Etenant.ManageSystemsuites.ClickAsync();

            //Check if the Manage system suite page is visible
            await Etenant.ManageSystemSuitesPage.WaitForAsync();
            await Expect(Etenant.ManageSystemSuitesPage).ToBeVisibleAsync();
            await Expect(Etenant.SystemSuitesTable).ToBeVisibleAsync();
            await Expect(Etenant.SystemSuitesTableRows.First).ToBeVisibleAsync();

            await Expect(Etenant.SystemSuiteTypeTenant.First).ToBeHiddenAsync();
            Console.WriteLine("System suite type is Tenant which is not present because of external admin role");
            await Etenant.SystemSuitesTable.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_TenantLevel_SystemSuitesNotpresent_ForExternalAdmin.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("SystemAdmin")]
        public async Task OpenSystemSuitesPage_ShouldContain_CustomSystemSuite_ForSystemAdmin(string role)
        {
            var custom = new SystemSuitesPage(Page);
            await Expect(custom.LHSMenu).ToBeVisibleAsync();
            await custom.SystemSuites.WaitForAsync();
            await custom.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(custom.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(custom.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(custom.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(custom.ManageSystemsuites).ToBeVisibleAsync();
            await custom.ManageSystemsuites.ClickAsync();

            //Check if the Manage system suite page is visible
            await custom.ManageSystemSuitesPage.WaitForAsync();
            await Expect(custom.ManageSystemSuitesPage).ToBeVisibleAsync();
            await Expect(custom.SystemSuitesTable).ToBeVisibleAsync();
            await Expect(custom.SystemSuitesTableRows.First).ToBeVisibleAsync();


            if (await custom.SystemSuiteTypeCustom.CountAsync() > 0)
            {
                await Expect(custom.SystemSuiteTypeCustom.First).ToBeVisibleAsync();
                Console.WriteLine("System suite type is Custom which is present");
                await custom.SystemSuitesTable.ScreenshotAsync(new()
                {
                    Path = "Screenshot_Of_Custom_SystemSuites_ForSystemAdmin.png"
                });
            }
            else
            {
                await Expect(custom.SystemSuiteTypeCustom.First).ToBeHiddenAsync();
                Console.WriteLine("System suite type is Custom which is not present");
                await custom.SystemSuitesTable.ScreenshotAsync(new()
                {
                    Path = "Screenshot_Of_Custom_SystemSuitesNotYetPresent_ForSystemAdmin.png"
                });
            }
        }

        [Test]
        [TestCase("ExternalAdmin")]
        [Category("ExternalAdmin")]
        public async Task OpenSystemSuitesPage_ShouldNotContain_CustomSS_ForExternalAdmin(string role)
        {
            var Ecustom = new SystemSuitesPage(Page);
            await Expect(Ecustom.LHSMenu).ToBeVisibleAsync();
            await Ecustom.SystemSuites.WaitForAsync();
            await Ecustom.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(Ecustom.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(Ecustom.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(Ecustom.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(Ecustom.ManageSystemsuites).ToBeVisibleAsync();
            await Ecustom.ManageSystemsuites.ClickAsync();

            //Check if the Manage system suite page is visible
            await Ecustom.ManageSystemSuitesPage.WaitForAsync();
            await Expect(Ecustom.ManageSystemSuitesPage).ToBeVisibleAsync();
            await Expect(Ecustom.SystemSuitesTable).ToBeVisibleAsync();
            await Expect(Ecustom.SystemSuitesTableRows.First).ToBeVisibleAsync();
            await Expect(Ecustom.SystemSuiteTypeCustom.First).ToBeHiddenAsync();
            Console.WriteLine("Custom word is not present as user is an external admin");
            await Ecustom.SystemSuitesTable.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_Custom_SystemSuitesNotpresent_ForExternalAdmin.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [TestCase("ExternalAdmin")]
        [Category("Admins")]
        public async Task OpenSystemSuitesPage_ShouldContain_PublicIcon_ForAdmins(string role)
        {
            var pubIcon = new SystemSuitesPage(Page);
            await Expect(pubIcon.LHSMenu).ToBeVisibleAsync();

            await pubIcon.SystemSuites.WaitForAsync();
            await pubIcon.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(pubIcon.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(pubIcon.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(pubIcon.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(pubIcon.ManageSystemsuites).ToBeVisibleAsync();
            await pubIcon.ManageSystemsuites.ClickAsync();

            //Check if the Manage system suite page is visible
            await pubIcon.ManageSystemSuitesPage.WaitForAsync();
            await Expect(pubIcon.ManageSystemSuitesPage).ToBeVisibleAsync();
            await Expect(pubIcon.SystemSuitesTable).ToBeVisibleAsync();
            await Expect(pubIcon.SystemSuitesTableRows.First).ToBeVisibleAsync();

            if (await pubIcon.SystemSuiteTablePublicIcon.First.CountAsync() > 0)
            {
                await pubIcon.SystemSuiteTablePublicIcon.First.WaitForAsync();
                await Expect(pubIcon.SystemSuiteTablePublicIcon.First).ToBeVisibleAsync();
                Console.WriteLine("Public System suite is present");
                await pubIcon.SystemSuiteTablePublicIcon.First.ScreenshotAsync(new()
                {
                    Path = "Screenshot_Of_PublicIcon_ForAdmins.png"
                });
            }
            else
            {
                await Expect(pubIcon.SystemSuiteTablePublicIcon.First).ToBeHiddenAsync();
                Console.WriteLine("Public System suite is not present");
                await pubIcon.SystemSuitesTable.ScreenshotAsync(new()
                {
                    Path = "Screenshot_Of_PublicIcon_ForAdmins.png"
                });
            }
        }

        [Test]
        [TestCase("SystemAdmin")]
        [TestCase("ExternalAdmin")]
        [Category("Admins")]
        public async Task OpenSystemSuitesPage_ShouldContain_PrivateIcon_ForAdmins(string role)
        {
            var priIcon = new SystemSuitesPage(Page);
            await Expect(priIcon.LHSMenu).ToBeVisibleAsync();

            await priIcon.SystemSuites.WaitForAsync();
            await priIcon.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(priIcon.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(priIcon.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(priIcon.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(priIcon.ManageSystemsuites).ToBeVisibleAsync();
            await priIcon.ManageSystemsuites.ClickAsync();

            //Check if the Manage system suite page is visible
            await priIcon.ManageSystemSuitesPage.WaitForAsync();
            await Expect(priIcon.ManageSystemSuitesPage).ToBeVisibleAsync();
            await Expect(priIcon.SystemSuitesTable).ToBeVisibleAsync();
            await Expect(priIcon.SystemSuitesTableRows.First).ToBeVisibleAsync();

            if (await priIcon.SystemSuiteTablePrivateIcon.First.CountAsync() > 0)
            {
                await priIcon.SystemSuiteTablePrivateIcon.First.WaitForAsync();
                await Expect(priIcon.SystemSuiteTablePrivateIcon.First).ToBeVisibleAsync();
                Console.WriteLine("Private System suite is present");
                await priIcon.SystemSuiteTablePrivateIcon.First.ScreenshotAsync(new()
                {
                    Path = "Screenshot_Of_PrivateIcon_ForAdmins.png"
                });
            }
            else
            {
                await Expect(priIcon.SystemSuiteTablePrivateIcon.First).ToBeHiddenAsync();
                Console.WriteLine("Private System suite is not present");
                await priIcon.SystemSuitesTable.First.ScreenshotAsync(new()
                {
                    Path = "Screenshot_Of_PrivateIcon_ForAdmins.png"
                });
            }
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("SystemAdmin")]
        public async Task OpenSystemSuitesPage_ShouldContain_SystemSuiteRowElements_ForSystemAdmin(string role)
        {
            var sname = new SystemSuitesPage(Page);
            await Expect(sname.LHSMenu).ToBeVisibleAsync();

            await sname.SystemSuites.WaitForAsync();
            await sname.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(sname.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(sname.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(sname.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(sname.ManageSystemsuites).ToBeVisibleAsync();
            await sname.ManageSystemsuites.ClickAsync();

            //Check if the Manage system suite page is visible
            await sname.ManageSystemSuitesPage.WaitForAsync();
            await Expect(sname.ManageSystemSuitesPage).ToBeVisibleAsync();
            await Expect(sname.SystemSuitesTable).ToBeVisibleAsync();
            await Expect(sname.SystemSuitesTableRows.First).ToBeVisibleAsync();

            //await Expect(sname.SystemSuiteNameList.First).ToBeVisibleAsync();
            await Expect(sname.SystemSuiteEditedTime.First).ToBeVisibleAsync();
            await sname.SystemSuiteEditedTime.First.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_SystemSuiteRow_EditedTime_ForSystemAdmin.png"

            });

            if (await sname.SystemSuiteInUseTickIcon.CountAsync() > 0)
            {
                await sname.SystemSuiteInUseTickIcon.First.HoverAsync();
                await sname.SystemSuiteInUseTickIcon.First.HighlightAsync();
                await Expect(sname.SystemSuiteInUseTickIcon.First).ToBeVisibleAsync();
                await sname.SystemSuiteInUseTickIcon.First.ScreenshotAsync(new()
                {
                    Path = "Screenshot_Of_SystemSuiteRow_InUseTickIcon_ForSystemAdmin.png"

                });
            }
            else
            {
                await Expect(sname.SystemSuiteInUseTickIcon).ToBeHiddenAsync();
            }   
        }

        [Test]
        [TestCase("ExternalAdmin")]
        [Category("ExternalAdmin")]
        public async Task OpenSystemSuitesPage_ShouldContain_SystemSuiteRowElements_ForExternalAdmin(string role)
        {
            var ename = new SystemSuitesPage(Page);
            await Expect(ename.LHSMenu).ToBeVisibleAsync();

            await ename.SystemSuites.WaitForAsync();
            await ename.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(ename.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(ename.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(ename.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(ename.ManageSystemsuites).ToBeVisibleAsync();
            await ename.ManageSystemsuites.ClickAsync();

            //Check if the Manage system suite page is visible
            await ename.ManageSystemSuitesPage.WaitForAsync();
            await Expect(ename.ManageSystemSuitesPage).ToBeVisibleAsync();
            await Expect(ename.SystemSuitesTable).ToBeVisibleAsync();
            await Expect(ename.SystemSuitesTableRows.First).ToBeVisibleAsync();

            //await Expect(sname.SystemSuiteNameList.First).ToBeVisibleAsync();
            await Expect(ename.SystemSuiteEditedTime.First).ToBeVisibleAsync();
            await ename.SystemSuiteEditedTime.First.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_SystemSuiteRow_EditedTime_ForSystemAdmin.png"

            });

            if (await ename.SystemSuiteInUseTickIcon.CountAsync() > 0)
            {
                await ename.SystemSuiteInUseTickIcon.First.HoverAsync();
                await ename.SystemSuiteInUseTickIcon.First.HighlightAsync();
                await Expect(ename.SystemSuiteInUseTickIcon.First).ToBeVisibleAsync();
                await ename.SystemSuiteInUseTickIcon.First.ScreenshotAsync(new()
                {
                    Path = "Screenshot_Of_SystemSuiteRow_InUseTickIcon_ForSystemAdmin.png"

                });
            }
            else
            {
                await Expect(ename.SystemSuiteInUseTickIcon).ToBeHiddenAsync();
            }
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("SystemAdmin")]
        public async Task OpenSystemSuitesPage_ShouldContain_3DotMenuPopUp_OfGlobalSuite_ForSystemAdmin(string role)
        {
            var threedot = new SystemSuitesPage(Page);

            await Expect(threedot.LHSMenu).ToBeVisibleAsync();            
            await threedot.SystemSuites.WaitForAsync();
            await threedot.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(threedot.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(threedot.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(threedot.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(threedot.ManageSystemsuites).ToBeVisibleAsync();
            await threedot.ManageSystemsuites.ClickAsync();

            //Check if the Manage system suite page is visible
            await threedot.ManageSystemSuitesPage.WaitForAsync();
            await Expect(threedot.ManageSystemSuitesPage).ToBeVisibleAsync();
            await Expect(threedot.SystemSuitesTable).ToBeVisibleAsync();
            await Expect(threedot.SystemSuitesTableRows.First).ToBeVisibleAsync();

            ILocator globalRow = null;
            for (int i = 0; i < await threedot.SystemSuitesTableRows.CountAsync(); i++)
            {
                var row = threedot.SystemSuitesTableRows.Nth(i);
                string text = await row.InnerTextAsync();

                if (text.Contains("Global", StringComparison.OrdinalIgnoreCase))
                {
                    globalRow = row;
                    Assert.IsNotNull(globalRow, "Global system suite not found");
                    var threedotrow = globalRow.Locator("button").Last;
                    await Expect(threedotrow).ToBeVisibleAsync();
                    await threedotrow.ClickAsync();
                    await threedot.SystemSuite3DotMenuList.ScreenshotAsync(new()
                    {
                        Path = "ScreenShot_Of_3Dotmenu_Global_ForSystemAdmin.png"
                    });
                    await Expect(threedot.SystemSuite3DotMenuList).ToBeVisibleAsync();
                    await Expect(threedot.SystemSuiteDownloadFile).ToBeVisibleAsync();
                    await Expect(threedot.SystemSuiteDownloadFile).ToBeEnabledAsync();
                    await threedot.SystemSuiteDownloadFile.ClickAsync();
                    break;
                }
                else
                {
                    Console.WriteLine("The Global level system suite is not present.");
                }
            }            
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("SystemAdmin")]
        public async Task OpenSystemSuitesPage_ShouldContain_3DotMenuPopUp_OfTenantLevelSuite_ForSystemAdmine(string role)
        {
            var threedotTenant = new SystemSuitesPage(Page);

            await Expect(threedotTenant.LHSMenu).ToBeVisibleAsync();

            await threedotTenant.SystemSuites.WaitForAsync();
            await threedotTenant.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(threedotTenant.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(threedotTenant.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(threedotTenant.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(threedotTenant.ManageSystemsuites).ToBeVisibleAsync();
            await threedotTenant.ManageSystemsuites.ClickAsync();

            //Check if the Manage system suite page is visible
            await threedotTenant.ManageSystemSuitesPage.WaitForAsync();
            await Expect(threedotTenant.ManageSystemSuitesPage).ToBeVisibleAsync();
            await Expect(threedotTenant.SystemSuitesTable).ToBeVisibleAsync();
            await Expect(threedotTenant.SystemSuitesTableRows.First).ToBeVisibleAsync();

            ILocator TenantRow = null;
            
            for (int i = 0; i < await threedotTenant.SystemSuitesTableRows.CountAsync(); i++)
            {
                var trow = threedotTenant.SystemSuitesTableRows.Nth(i);
                string text = await trow.InnerTextAsync();
                if (text.Contains("Tenant", StringComparison.OrdinalIgnoreCase))
                {
                    TenantRow = trow;
                    Assert.IsNotNull(TenantRow, "Tenant system suite not found");
                    var threedotrow = TenantRow.Locator("button").Last;
                    await Expect(threedotrow).ToBeVisibleAsync();
                    await threedotrow.ClickAsync();
                    await threedotTenant.SystemSuite3DotMenuList.ScreenshotAsync(new()
                    {
                        Path = "Screenshot_Of_3dotmenu_OfTenantLevelSS_ForSystemAdmin.png"
                    });
                    await Expect(threedotTenant.SystemSuite3DotMenuList).ToBeVisibleAsync();
                    await Expect(threedotTenant.SystemSuiteDownloadFile).ToBeVisibleAsync();
                    await Expect(threedotTenant.SystemSuiteDeleteIcon).ToBeVisibleAsync();
                    await Expect(threedotTenant.SystemSuiteDeleteIcon).ToBeEnabledAsync();
                    break;
                }
                else
                {
                    Console.WriteLine("The Tenat level system suite is not present");
                }
            }
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("SystemAdmin")]
        public async Task OpenSystemSuitesPage_ShouldContain_3DotMenuPopUp_ofCustomSystemSuite_ForSystemAdmin(string role)
        {
            var threedotCustom = new SystemSuitesPage(Page);

            await Expect(threedotCustom.LHSMenu).ToBeVisibleAsync();
            await threedotCustom.SystemSuites.WaitForAsync();
            await threedotCustom.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(threedotCustom.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(threedotCustom.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(threedotCustom.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(threedotCustom.ManageSystemsuites).ToBeVisibleAsync();
            await threedotCustom.ManageSystemsuites.ClickAsync();

            //Check if the Manage system suite page is visible
            await threedotCustom.ManageSystemSuitesPage.WaitForAsync();
            await Expect(threedotCustom.ManageSystemSuitesPage).ToBeVisibleAsync();
            await Expect(threedotCustom.SystemSuitesTable).ToBeVisibleAsync();
            await Expect(threedotCustom.SystemSuitesTableRows.First).ToBeVisibleAsync();

            ILocator CustomRow = null;
            for (int i = 0; i < await threedotCustom.SystemSuitesTableRows.CountAsync(); i++)
            {
                var crow = threedotCustom.SystemSuitesTableRows.Nth(i);
                string text = await crow.InnerTextAsync();
                if (text.Contains("Custom", StringComparison.OrdinalIgnoreCase))
                {
                    CustomRow = crow;
                    Assert.IsNotNull(CustomRow, "Custom system suite not found");
                    var threedotrow = CustomRow.Locator("button").Last;
                    await Expect(threedotrow).ToBeVisibleAsync();
                    await threedotrow.ClickAsync();
                    await threedotCustom.SystemSuite3DotMenuList.ScreenshotAsync(new()
                    {
                        Path = "ScreenShot_Of_3DotMenuList_Of_CustomSS_ForSystemAdmin.png"
                    });
                    await Expect(threedotCustom.SystemSuite3DotMenuList).ToBeVisibleAsync();
                    await Expect(threedotCustom.SystemSuiteDeleteIcon).ToBeVisibleAsync();
                    await Expect(threedotCustom.SystemSuiteDeleteIcon).ToBeEnabledAsync();
                    break;
                }
                else
                {
                    Console.WriteLine("The Custom system suite is not present");
                }
            }
        }

        [Test]
        [TestCase("ExternalAdmin")]
        [Category("ExternalAdmin")]
        public async Task OpenSystemSuitesPage_ShouldContain_3DotMenuPopUp_ofCustomSystemSuite_ForExternalAdmin(string role)
        {
            var threedotCustom = new SystemSuitesPage(Page);

            await Expect(threedotCustom.LHSMenu).ToBeVisibleAsync();
            await threedotCustom.SystemSuites.WaitForAsync();
            await threedotCustom.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(threedotCustom.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(threedotCustom.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(threedotCustom.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(threedotCustom.ManageSystemsuites).ToBeVisibleAsync();
            await threedotCustom.ManageSystemsuites.ClickAsync();

            //Check if the Manage system suite page is visible
            await threedotCustom.ManageSystemSuitesPage.WaitForAsync();
            await Expect(threedotCustom.ManageSystemSuitesPage).ToBeVisibleAsync();
            await Expect(threedotCustom.SystemSuitesTable).ToBeVisibleAsync();
            
            if(await threedotCustom.SystemSuitesTableRows.First.IsVisibleAsync())
            {
                await threedotCustom.SystemSuite3DotMenu.Last.WaitForAsync();
                await Expect(threedotCustom.SystemSuite3DotMenu.Last).ToBeVisibleAsync();
                await threedotCustom.SystemSuite3DotMenu.Last.ClickAsync();
                await Expect(threedotCustom.SystemSuite3DotMenuList.Last).ToBeVisibleAsync();
                await Expect(threedotCustom.SystemSuiteDeleteIcon).ToBeVisibleAsync();
                await Expect(threedotCustom.SystemSuiteDeleteIcon).ToBeEnabledAsync();
                await threedotCustom.SystemSuite3DotMenuList.Last.ScreenshotAsync(new()
                {
                    Path = "ScreenShot_Of_3DotMenuList_Of_CustomSS_ForExternalAdmin"
                });
            }
            else
            {
                Console.WriteLine("No Custom system suite is present");

            }
    }

        [Test]
        [TestCase("SystemAdmin")]
        [TestCase("ExternalAdmin")]
        [Category("Admins")]
        public async Task OpenSystemSuitesPage_ShouldContain_SSRowsPerPageAndPageIndicators_ForAdmins(string role)
        {
            var indicator = new SystemSuitesPage(Page);

            await indicator.SystemSuites.WaitForAsync();
            await indicator.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(indicator.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(indicator.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(indicator.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(indicator.ManageSystemsuites).ToBeVisibleAsync();
            await indicator.ManageSystemsuites.ClickAsync();

            //Check if the Manage system suite page is visible
            await indicator.ManageSystemSuitesPage.WaitForAsync();
            await Expect(indicator.ManageSystemSuitesPage).ToBeVisibleAsync();
            await Expect(indicator.SystemSuitesTable).ToBeVisibleAsync();
            await Expect(indicator.SystemSuitesTableRows.First).ToBeVisibleAsync();

            //Check if the rows per page and toolbar is present
            await Expect(indicator.SystemSuiteRowsToolbar).ToBeVisibleAsync();
            await Expect(indicator.SystemSuiteRowsPerpageName).ToBeVisibleAsync();
            await Expect(indicator.SystemSuitePageDropDown).ToBeVisibleAsync();
            await Expect(indicator.SystemSuitePageNumbers).ToBeVisibleAsync();
            await Expect(indicator.SystemSuitePreviousButton).ToBeVisibleAsync();
            await Expect(indicator.SystemSuitePreviousButton).ToBeDisabledAsync();
            await Expect(indicator.SystemSuiteNextButton).ToBeVisibleAsync();

            await indicator.SystemSuiteRowsToolbar.ScreenshotAsync(new()
            {
                Path = "ScreenShot_Of_SystemSuites_RowsToolBar_ForAdmins.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [TestCase("ExternalAdmin")]
        [Category("Admins")]
        public async Task OpenSystemSuitesPage_ShouldContain_SSPageNumberDropDownList_ForAdmins(string role)
        {
            var rowsdropdown = new SystemSuitesPage(Page);
 
            await rowsdropdown.SystemSuites.WaitForAsync();
            await rowsdropdown.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(rowsdropdown.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(rowsdropdown.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(rowsdropdown.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(rowsdropdown.ManageSystemsuites).ToBeVisibleAsync();
            await rowsdropdown.ManageSystemsuites.ClickAsync();

            //Check if the Manage system suite page is visible
            await rowsdropdown.ManageSystemSuitesPage.WaitForAsync();
            await Expect(rowsdropdown.ManageSystemSuitesPage).ToBeVisibleAsync();
            await Expect(rowsdropdown.SystemSuitesTable).ToBeVisibleAsync();
            await Expect(rowsdropdown.SystemSuitesTableRows.First).ToBeVisibleAsync();

            //Check if the rows tool bar is present
            await Expect(rowsdropdown.SystemSuiteRowsToolbar).ToBeVisibleAsync();
            await Expect(rowsdropdown.SystemSuitePageDropDown).ToBeVisibleAsync();
            await rowsdropdown.SystemSuitePageDropDown.ClickAsync();
            await Expect(rowsdropdown.SystemSuiteRowDropdownList).ToBeVisibleAsync();
            await rowsdropdown.SystemSuiteRowDropdownList.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_SystemSuitePage_PageNumbersDropdownList_ForAdmins.png"
            });

            //Verify the numbers of the pages in the dropdown
            await Expect(rowsdropdown.SystemSuiteRowDropdownListNumber10).ToBeVisibleAsync();
            await Expect(rowsdropdown.SystemSuiteRowDropdownListNumber25).ToBeVisibleAsync();
            await Expect(rowsdropdown.SystemSuiteRowDropdownListNumber50).ToBeVisibleAsync();
            await Expect(rowsdropdown.SystemSuiteRowDropdownListNumber100).ToBeVisibleAsync();

        }
    }
}
