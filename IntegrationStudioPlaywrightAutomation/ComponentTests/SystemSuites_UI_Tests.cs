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
        }

        [Test]
        [TestCase("ProjectUser")]
        public async Task OpenSystemSuitesPage_ShouldNot_BeVisible_ForProjectUser(string role)
        {
            var psystemsuites = new SystemSuitesPage(Page);

            await psystemsuites.LHSMenu.WaitForAsync();
            await Expect(psystemsuites.LHSMenu).ToBeVisibleAsync();
            await Expect(psystemsuites.SystemSuites).ToBeHiddenAsync();
            Console.WriteLine("ProjectUser: System Suites option is not visible as expected");

        }

        [Test]
        [TestCase("SystemAdmin")]
        [TestCase("ExternalAdmin")]
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

            //Check for the system suites sub title
            await Expect(title.SystemSuitesSubTitle).ToBeVisibleAsync();
            title.SystemSuitesSubTitle.Equals("Create and manage system suites used by your project templates.");
                       
        }

        [Test]
        [TestCase("SystemAdmin")]
        [TestCase("ExternalAdmin")]
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
        [Category("Common")]
        [Category("SystemAdmin")]
        [Category("ExternalAdmin")]
        public async Task OpenSystemSuitesPage_ShouldContain_UploadFileButton()
        {
            var UploadFile = new SystemSuitesPage(Page);

            await Expect(UploadFile.LHSMenu).ToBeVisibleAsync();
            if (await UploadFile.SystemSuites.IsVisibleAsync())
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

                //if (await UploadFile.SystemSuiteTypeGlobal.First.IsVisibleAsync())
                /*if (RoleContext.IsSystemAdmin())
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
                    Console.WriteLine("The User is logged in as an external admin, hence the user should not see the upload file button");
                }*/
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

            await Expect(table.LHSMenu).ToBeVisibleAsync();

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
            var tablerows = new SystemSuitesPage(Page);

            await Expect(tablerows.LHSMenu).ToBeVisibleAsync();

            if (await tablerows.SystemSuites.IsVisibleAsync())
            {
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
                    Path = "Screenshot_Of_SystemSuiteTable_Row.png"
                });
            }
            else
            {
                Console.WriteLine("The User is project user , hence system suites option is not visible");
                await Expect(tablerows.SystemSuites).ToBeHiddenAsync();
            }

        }

        [Test]
        public async Task OpenSystemSuitesPage_ShouldContain_SystemSuiteTypeGlobal()
        {
            var global = new SystemSuitesPage(Page);

            await Expect(global.LHSMenu).ToBeVisibleAsync();

            if (await global.SystemSuites.IsVisibleAsync())
            {
                await global.SystemSuites.WaitForAsync();
                await global.SystemSuites.ClickAsync();

                //Check and verify the system suites sub menu
                await Expect(global.SystemsuitesSubMenu).ToBeVisibleAsync();
                await Expect(global.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
                await Expect(global.SystemsuitesSubMenuClose).ToBeVisibleAsync();
                await Expect(global.ManageSystemsuites).ToBeVisibleAsync();
                await global.ManageSystemsuites.ClickAsync();

                //Check if the Manage system suite page is visible
                await global.ManageSystemSuitesPage.WaitForAsync();
                await Expect(global.ManageSystemSuitesPage).ToBeVisibleAsync();
                await Expect(global.SystemSuitesTable).ToBeVisibleAsync();
                await Expect(global.SystemSuitesTableRows.First).ToBeVisibleAsync();

                if (await global.UploadFileButton.IsVisibleAsync())
                {

                    if (await global.SystemSuiteTypeGlobal.First.CountAsync() > 0)
                    {
                        await global.SystemSuiteTypeGlobal.First.WaitForAsync();
                        await Expect(global.SystemSuiteTypeGlobal.First).ToBeVisibleAsync();
                        Console.WriteLine("System suite type is Global which is present");
                    }
                    else
                    {
                        await Expect(global.SystemSuiteTypeGlobal.First).ToBeHiddenAsync();
                        Console.WriteLine("System suite type is Global which is not present");
                    }
                }
                else
                {
                    await Expect(global.SystemSuiteTypeGlobal.First).ToBeHiddenAsync();
                    Console.WriteLine("System suite type is Global which is not present because of external admin role");
                }
            }
            else
            {
                Console.WriteLine("The User is project user , hence system suites option is not visible");
                await Expect(global.SystemSuites).ToBeHiddenAsync();
            }
        }

        [Test]
        public async Task OpenSystemSuitesPage_ShouldContain_SystemSuiteTypeTenant()
        {
            var tenant = new SystemSuitesPage(Page);

            await Expect(tenant.LHSMenu).ToBeVisibleAsync();

            if (await tenant.SystemSuites.IsVisibleAsync())
            {
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

                if (await tenant.UploadFileButton.IsVisibleAsync())
                {
                    if (await tenant.SystemSuiteTypeTenant.First.CountAsync() > 0)
                    {
                        await Expect(tenant.SystemSuiteTypeTenant.First).ToBeVisibleAsync();
                        Console.WriteLine("System suite type is Tenant which is present");
                    }
                    else
                    {
                        await Expect(tenant.SystemSuiteTypeTenant.First).ToBeHiddenAsync();
                        Console.WriteLine("System suite type is Tenant which is not present");
                    }
                }
                else
                {
                    await Expect(tenant.SystemSuiteTypeTenant.First).ToBeHiddenAsync();
                    Console.WriteLine("System suite type is Tenant which is not present because of external admin role");
                }
            }
            else
            {
                Console.WriteLine("The User is project user , hence system suites option is not visible");
                await Expect(tenant.SystemSuites).ToBeHiddenAsync();
            }
        }

        [Test]
        public async Task OpenSystemSuitesPage_ShouldContain_SystemSuiteTypeCustom()
        {
            var custom = new SystemSuitesPage(Page);
            await Expect(custom.LHSMenu).ToBeVisibleAsync();

            if (await custom.SystemSuites.IsVisibleAsync())
            {
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

                if (await custom.UploadFileButton.IsVisibleAsync())
                {
                    if (await custom.SystemSuiteTypeCustom.CountAsync() > 0)
                    {
                        await Expect(custom.SystemSuiteTypeCustom.First).ToBeVisibleAsync();
                        Console.WriteLine("System suite type is Custom which is present");
                    }
                    else
                    {
                        await Expect(custom.SystemSuiteTypeCustom.First).ToBeHiddenAsync();
                        Console.WriteLine("System suite type is Custom which is not present");
                    }
                }
                else
                {
                    await Expect(custom.SystemSuiteTypeCustom.First).ToBeHiddenAsync();
                    Console.WriteLine("Custom word is not present as user is an external admin");
                }
            }
            else
            {
                Console.WriteLine("The User is project user , hence system suites option is not visible");
                await Expect(custom.SystemSuites).ToBeHiddenAsync();
            }
        }

        [Test]
        public async Task OpenSystemSuitesPage_ShouldContain_PublicIcon()
        {
            var pubIcon = new SystemSuitesPage(Page);
            await Expect(pubIcon.LHSMenu).ToBeVisibleAsync();

            if (await pubIcon.SystemSuites.IsVisibleAsync())
            {
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
                }
                else
                {
                    await Expect(pubIcon.SystemSuiteTablePublicIcon.First).ToBeHiddenAsync();
                    Console.WriteLine("Public System suite is not present");
                }

            }
            else
            {
                Console.WriteLine("The User is project user , hence system suites option is not visible");
                await Expect(pubIcon.SystemSuites).ToBeHiddenAsync();
            }
        }

        [Test]
        public async Task OpenSystemSuitesPage_ShouldContain_PrivateIcon()
        {
            var priIcon = new SystemSuitesPage(Page);
            await Expect(priIcon.LHSMenu).ToBeVisibleAsync();

            if (await priIcon.SystemSuites.IsVisibleAsync())
            {
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
                }
                else
                {
                    await Expect(priIcon.SystemSuiteTablePrivateIcon.First).ToBeHiddenAsync();
                    Console.WriteLine("Private System suite is not present");
                }
            }
            else
            {
                Console.WriteLine("The User is project user , hence system suites option is not visible");
                await Expect(priIcon.SystemSuites).ToBeHiddenAsync();
            }
        }

        [Test]
        public async Task OpenSystemSuitesPage_ShouldContain_SuiteName_EditedBy_3DotMenu()
        {
            var sname = new SystemSuitesPage(Page);
            await Expect(sname.LHSMenu).ToBeVisibleAsync();

            if (await sname.SystemSuites.IsVisibleAsync())
            {
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
                    Path = "Screenshot_Of_EditedTime.png"

                });

                if (await sname.SystemSuiteInUseTickIcon.CountAsync() > 0)
                {
                    await sname.SystemSuiteInUseTickIcon.First.HoverAsync();
                    await sname.SystemSuiteInUseTickIcon.First.HighlightAsync();
                    await Expect(sname.SystemSuiteInUseTickIcon.First).ToBeVisibleAsync();
                }
                else
                {
                    await Expect(sname.SystemSuiteInUseTickIcon).ToBeHiddenAsync();
                }
                await Expect(sname.SystemSuite3DotMenu.Last).ToBeVisibleAsync();
                await sname.SystemSuite3DotMenu.Last.ScreenshotAsync(new()
                {
                    Path = "Screenshot_Of_3DotMenu.png"

                });
            }
            else
            {
                Console.WriteLine("The User is project user , hence system suites option is not visible");
                await Expect(sname.SystemSuites).ToBeHiddenAsync();
            }
        }

        [Test]
        public async Task OpenSystemSuitesPage_ShouldContain_3DotMenuPopUp_ForGlobalSuite()
        {
            var threedot = new SystemSuitesPage(Page);

            await Expect(threedot.LHSMenu).ToBeVisibleAsync();

            if (await threedot.SystemSuites.IsVisibleAsync())
            {
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
                            Path = "ScreenShot_Of_3Dotmenu_Global.png"
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
            else
            {
                Console.WriteLine("The User is project user , hence system suites option is not visible");
                await Expect(threedot.SystemSuites).ToBeHiddenAsync();
            }
        }

        [Test]
        public async Task OpenSystemSuitesPage_ShouldContain_3DotMenuPopUp_ForTenantSuite()
        {
            var threedotTenant = new SystemSuitesPage(Page);

            await Expect(threedotTenant.LHSMenu).ToBeVisibleAsync();

            if (await threedotTenant.SystemSuites.IsVisibleAsync())
            {
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

                for(int i = 0;i< await threedotTenant.SystemSuitesTableRows.CountAsync();i++)
                {
                    var trow = threedotTenant.SystemSuitesTableRows.Nth(i);
                    string text = await trow.InnerTextAsync();
                    if(text.Contains("Tenant", StringComparison.OrdinalIgnoreCase))
                    {
                        TenantRow = trow;
                        Assert.IsNotNull(TenantRow, "Tenant system suite not found");
                        var threedotrow = TenantRow.Locator("button").Last;
                        await Expect(threedotrow).ToBeVisibleAsync();
                        await threedotrow.ClickAsync();
                        await threedotTenant.SystemSuite3DotMenuList.ScreenshotAsync(new()
                        {
                            Path = "Screenshot_Of_3dotmenu_Tenant.png"
                        });
                        await Expect(threedotTenant.SystemSuite3DotMenuList).ToBeVisibleAsync();
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
            else
            {
                Console.WriteLine("The User is project user , hence system suites option is not visible");
                await Expect(threedotTenant.SystemSuites).ToBeHiddenAsync();
            }
        }

        [Test]
        public async Task OpenSystemSuitesPage_ShouldContain_3DotMenuPopUp_ForCustomSystemSuite()
        {
            var threedotCustom = new SystemSuitesPage(Page);

            await Expect(threedotCustom.LHSMenu).ToBeVisibleAsync();

            if (await threedotCustom.SystemSuites.IsVisibleAsync())
            {
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
                if (await threedotCustom.UploadFileButton.IsVisibleAsync())
                {
                    ILocator CustomRow = null;
                    for (int i = 0; i < await threedotCustom.SystemSuitesTableRows.CountAsync(); i++)
                    {
                        var crow = threedotCustom.SystemSuitesTableRows.Nth(i);
                        string text = await crow.InnerTextAsync();
                        if (text.Contains("Custom", StringComparison.OrdinalIgnoreCase))
                        {
                            CustomRow = crow;
                            Assert.IsNotNull(CustomRow, "Tenant system suite not found");
                            var threedotrow = CustomRow.Locator("button").Last;
                            await Expect(threedotrow).ToBeVisibleAsync();
                            await threedotrow.ClickAsync();
                            await threedotCustom.SystemSuite3DotMenuList.ScreenshotAsync(new()
                            {
                                Path = "Screenshot_Of_3dotmenu_Custom.png"
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
                else
                {
                    Console.WriteLine("The user is an  external admin.Hence the custom word will not be present");
                    await threedotCustom.SystemSuite3DotMenu.Last.WaitForAsync();
                    await Expect(threedotCustom.SystemSuite3DotMenu.Last).ToBeVisibleAsync();
                    await threedotCustom.SystemSuite3DotMenu.Last.ClickAsync();
                    await Expect(threedotCustom.SystemSuite3DotMenuList.Last).ToBeVisibleAsync();
                    await Expect(threedotCustom.SystemSuiteDeleteIcon).ToBeVisibleAsync();
                    await Expect(threedotCustom.SystemSuiteDeleteIcon).ToBeEnabledAsync();
                }
            }
            else
            {
                Console.WriteLine("The User is project user , hence system suites option is not visible");
                await Expect(threedotCustom.SystemSuites).ToBeHiddenAsync();
            }
        }

        [Test]
        public async Task OpenSystemSuitesPage_ShouldContain_RowsPerPage_And_PageIndicators()
        {
            var indicator = new SystemSuitesPage(Page);

            if (await indicator.SystemSuites.IsVisibleAsync())
            {
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
                    Path = "ScreenShot_Of_RowsToolBar.png"
                });
            }
            else
            {
                Console.WriteLine("The User is project user , hence system suites option is not visible");
                await Expect(indicator.SystemSuites).ToBeHiddenAsync();
            }
        }

        [Test]
        public async Task OpenSystemSuitesPage_ShouldContain_RowsDropDownList()
        {
            var rowsdropdown = new SystemSuitesPage(Page);
            if (await rowsdropdown.SystemSuites.IsVisibleAsync())
            {
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
                    Path = "Screenshot_Of_DropdownList.png"
                });

                //Verify the numbers of the pages in the dropdown
                await Expect(rowsdropdown.SystemSuiteRowDropdownListNumber10).ToBeVisibleAsync();
                await Expect(rowsdropdown.SystemSuiteRowDropdownListNumber25).ToBeVisibleAsync();
                await Expect(rowsdropdown.SystemSuiteRowDropdownListNumber50).ToBeVisibleAsync();
                await Expect(rowsdropdown.SystemSuiteRowDropdownListNumber100).ToBeVisibleAsync();

            }
            else
            {
                Console.WriteLine("The User is project user , hence system suites option is not visible");
                await Expect(rowsdropdown.SystemSuites).ToBeHiddenAsync();
            }
        }
    }
}
