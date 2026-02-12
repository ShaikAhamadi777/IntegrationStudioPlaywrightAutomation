using IntegrationStudioPlaywrightAutomation.Assertions;
using IntegrationStudioPlaywrightAutomation.Locators;
using IntegrationStudioPlaywrightAutomation.Utilities.Models;
using IntegrationStudioPlaywrightAutomation.WorkFlows;
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
            var systemsuitesworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(systemsuites);
            await systemsuitesworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(systemsuites);
            await systemsuitesworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(systemsuites);
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
            var psystemsuites = new ProjectTemplatesPage(Page);

            await ProjectTemplatesAssertions.VerifyLHSMenuForProjectUser(psystemsuites);
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
            var titleworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(title);
            await titleworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(title);
            await titleworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(title);
            await SystemSuitesAssertions.VerifyManageSystemSuitesPageTitleAndSubTitle(title);
            
            await title.SystemSuiteTitle.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_SystemSuitesPage_Title.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [TestCase("ExternalAdmin")]
        [Category("Admins")]
        public async Task OpenSystemSuitesPage_ShouldContain_SystemSuitesInUse_ForAdmins(string role)
        {
            var InUse = new SystemSuitesPage(Page);
            var InUseworkflow = new SystemSuitesWorkflow(Page);
          
            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(InUse);
            await InUseworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(InUse);
            await InUseworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(InUse);
            await SystemSuitesAssertions.VerifySystemSuitesInUse(InUse);
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
            var UploadFileworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(UploadFile);
            await UploadFileworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(UploadFile);
            await UploadFileworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(UploadFile);
            await SystemSuitesAssertions.VerifySystemSuiteUploadFileButton(UploadFile);

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
            var ExtUploadFileworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(ExtUploadFile);
            await ExtUploadFileworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(ExtUploadFile);
            await ExtUploadFileworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(ExtUploadFile);
            await SystemSuitesAssertions.VerifySystemSuiteUploadFileButtonHidden(ExtUploadFile);
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
            var tableworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(table);
            await tableworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(table);
            await tableworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(table);
            await SystemSuitesAssertions.VerifySystemSuiteTableColumnHeadingsForSSAdmin(table);
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
            var Exttableworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(Exttable);
            await Exttableworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(Exttable);
            await Exttableworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(Exttable);
            await SystemSuitesAssertions.VerifySystemSuiteTableColumnHeadingsForExtAdmin(Exttable);

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
            var tablerowsworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(tablerows);
            await tablerowsworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(tablerows);
            await tablerowsworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(tablerows);
            await SystemSuitesAssertions.VerifySystemSuiteTableRows(tablerows);

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
            var tablerowsworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(tablerows);
            await tablerowsworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(tablerows);
            await tablerowsworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(tablerows);
            await SystemSuitesAssertions.VerifySystemSuiteTableRows(tablerows);

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
            var SAdminglobalworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(SAdminglobal);
            await SAdminglobalworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(SAdminglobal);
            await SAdminglobalworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(SAdminglobal);
            await SystemSuitesAssertions.VerifySystemSuiteTableRows(SAdminglobal);
            await SystemSuitesAssertions.VerifyGlobalSystemSuiteForAdmins(SAdminglobal);
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
            var EAdminglobalworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(EAdminglobal);
            await EAdminglobalworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(EAdminglobal);
            await EAdminglobalworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(EAdminglobal);
            await SystemSuitesAssertions.VerifySystemSuiteTableRows(EAdminglobal);
            await SystemSuitesAssertions.VerifyGlobalSystemSuiteForExtAdmin(EAdminglobal);

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
            var tenantworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(tenant);
            await tenantworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(tenant);
            await tenantworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(tenant);
            await SystemSuitesAssertions.VerifySystemSuiteTableRows(tenant);


            if (await tenant.SystemSuiteTypeTenant.First.CountAsync() > 0)
            {
                await SystemSuitesAssertions.VerifyTenantLevelSystemSuiteVisible(tenant);
                Console.WriteLine("Tenant level system suite is present in the system suites page");
                await tenant.SystemSuitesTable.ScreenshotAsync(new()
                {
                    Path = "Screenshot_Of_TenantLevel_SystemSuites_ForSystemAdmin.png"
                });
            }
            else
            {
                await SystemSuitesAssertions.VerifyTenantLevelSystemSuiteHidden(tenant);
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
            var ETenantWorkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(Etenant);
            await ETenantWorkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(Etenant);
            await ETenantWorkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(Etenant);
            await SystemSuitesAssertions.VerifySystemSuiteTableRows(Etenant);

            await SystemSuitesAssertions.VerifyTenantLevelSystemSuiteHidden(Etenant);
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
            var customworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(custom);
            await customworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(custom);
            await customworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(custom);
            await SystemSuitesAssertions.VerifySystemSuiteTableRows(custom);

            if (await custom.SystemSuiteTypeCustom.CountAsync() > 0)
            {
                await SystemSuitesAssertions.VerifyCustomLevelSystemSuiteVisible(custom);
                Console.WriteLine("System suite type is Custom which is present");
                await custom.SystemSuitesTable.ScreenshotAsync(new()
                {
                    Path = "Screenshot_Of_Custom_SystemSuites_ForSystemAdmin.png"
                });
            }
            else
            {
                await SystemSuitesAssertions.VerifyCustomLevelSystemSuiteHidden(custom);
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
        public async Task OpenSystemSuitesPage_ShouldNotContain_CustomWordSS_ForExternalAdmin(string role)
        {
            var Ecustom = new SystemSuitesPage(Page);
            var Ecustomworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(Ecustom);
            await Ecustomworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(Ecustom);
            await Ecustomworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(Ecustom);
            await SystemSuitesAssertions.VerifySystemSuiteTableColumnHeadingsForExtAdmin(Ecustom);
            await SystemSuitesAssertions.VerifySystemSuiteTableRows(Ecustom);
            await SystemSuitesAssertions.VerifyCustomLevelSystemSuiteHidden(Ecustom);
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
            var pubIconworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(pubIcon);
            await pubIconworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(pubIcon);
            await pubIconworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(pubIcon);
            await SystemSuitesAssertions.VerifySystemSuiteTableRows(pubIcon);

            if (await pubIcon.SystemSuiteTablePublicIcon.First.CountAsync() > 0)
            {
                await SystemSuitesAssertions.VerifyPublicSSVisible(pubIcon);
                Console.WriteLine("Public System suite is present");
                await pubIcon.SystemSuiteTablePublicIcon.First.ScreenshotAsync(new()
                {
                    Path = "Screenshot_Of_PublicIcon_ForAdmins.png"
                });
            }
            else
            {
                await SystemSuitesAssertions.VerifyPublicSSHidden(pubIcon);
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
            var priIconworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(priIcon);
            await priIconworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(priIcon);
            await priIconworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(priIcon);
            await SystemSuitesAssertions.VerifySystemSuiteTableRows(priIcon);

            if (await priIcon.SystemSuiteTablePrivateIcon.First.CountAsync() > 0)
            {
                await SystemSuitesAssertions.VerifyPrivateSSVisible(priIcon);
                Console.WriteLine("Private System suite is present");
                await priIcon.SystemSuiteTablePrivateIcon.First.ScreenshotAsync(new()
                {
                    Path = "Screenshot_Of_PrivateIcon_ForAdmins.png"
                });
            }
            else
            {
                await SystemSuitesAssertions.VerifyPrivateSSHidden(priIcon);
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
            var snameworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(sname);
            await snameworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(sname);
            await snameworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(sname);
            await SystemSuitesAssertions.VerifySystemSuiteTableRows(sname);


            //await Expect(sname.SystemSuiteNameList.First).ToBeVisibleAsync();
            await SystemSuitesAssertions.VerifySystemSuiteEditedTime(sname);
            await sname.SystemSuiteEditedTime.First.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_SystemSuiteRow_EditedTime_ForSystemAdmin.png"

            });

            if (await sname.SystemSuiteInUseTickIcon.CountAsync() > 0)
            {
                
                await SystemSuitesAssertions.VerifySystemSuiteInUseTickIconVisible(sname);
                await sname.SystemSuiteInUseTickIcon.First.ScreenshotAsync(new()
                {
                    Path = "Screenshot_Of_SystemSuiteRow_InUseTickIcon_ForSystemAdmin.png"

                });
            }
            else
            {
                await SystemSuitesAssertions.VerifySystemSuiteInUseTickIconHidden(sname);
            }   
        }

        [Test]
        [TestCase("ExternalAdmin")]
        [Category("ExternalAdmin")]
        public async Task OpenSystemSuitesPage_ShouldContain_SystemSuiteRowElements_ForExternalAdmin(string role)
        {
            var ename = new SystemSuitesPage(Page);
            var enameworkflow = new SystemSuitesWorkflow (Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(ename);
            await enameworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(ename);
            await enameworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(ename);
            await SystemSuitesAssertions.VerifySystemSuiteTableRows(ename);
            await SystemSuitesAssertions.VerifySystemSuiteEditedTime(ename);

            await ename.SystemSuiteEditedTime.First.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_SystemSuiteRow_EditedTime_ForSystemAdmin.png"

            });

            if (await ename.SystemSuiteInUseTickIcon.CountAsync() > 0)
            {
                await SystemSuitesAssertions.VerifySystemSuiteInUseTickIconVisible(ename);
                await ename.SystemSuiteInUseTickIcon.First.ScreenshotAsync(new()
                {
                    Path = "Screenshot_Of_SystemSuiteRow_InUseTickIcon_ForSystemAdmin.png"

                });
            }
            else
            {
                await SystemSuitesAssertions.VerifySystemSuiteInUseTickIconHidden(ename);
            }
        }

        [Test]
        [TestCase("SystemAdmin")]
        [Category("SystemAdmin")]
        public async Task OpenSystemSuitesPage_ShouldContain_3DotMenuPopUp_OfGlobalSuite_ForSystemAdmin(string role)
        {
            var threedot = new SystemSuitesPage(Page);
            var threedotworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(threedot); 
            await threedotworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(threedot);
            await threedotworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(threedot);
            await SystemSuitesAssertions.VerifySystemSuiteTableRows(threedot);

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
                    await SystemSuitesAssertions.VerifyGlobalSystemSuite3DotMenu(threedot);
                    await threedotworkflow.DownloadGlobalSS();
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
            var threedotTenantworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(threedotTenant);
            await threedotTenantworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(threedotTenant);
            await threedotTenantworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(threedotTenant);
            await SystemSuitesAssertions.VerifySystemSuiteTableRows(threedotTenant);

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
                    await SystemSuitesAssertions.VerifyTenantLevelSystemSuite3DotMenu(threedotTenant);
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
            var threedotCustomWorkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(threedotCustom);
            await threedotCustomWorkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(threedotCustom);
            await threedotCustomWorkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(threedotCustom);
            await SystemSuitesAssertions.VerifySystemSuiteTableRows(threedotCustom);

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
                    await SystemSuitesAssertions.VerifyCustomSystemSuite3DotMenu(threedotCustom);
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
            var threedotCustomworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(threedotCustom);
            await threedotCustomworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(threedotCustom);
            await threedotCustomworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(threedotCustom);

            if (await threedotCustom.SystemSuitesTableRows.First.IsVisibleAsync())
            {
                await threedotCustom.SystemSuite3DotMenu.Last.WaitForAsync();
                await Expect(threedotCustom.SystemSuite3DotMenu.Last).ToBeVisibleAsync();
                await threedotCustom.SystemSuite3DotMenu.Last.ClickAsync();
                await Expect(threedotCustom.SystemSuite3DotMenuList.Last).ToBeVisibleAsync();
               // await Expect(threedotCustom.SystemSuite3DotMenuList).ToBeVisibleAsync();

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
            var indicatorworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(indicator);
            await indicatorworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(indicator);
            await indicatorworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(indicator);

            //Check if the rows per page and toolbar is present
            await SystemSuitesAssertions.VerifySystemSuiteRowToolbar(indicator);
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
            var rowsdropdownworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(rowsdropdown);
            await rowsdropdownworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(rowsdropdown);
            await rowsdropdownworkflow.OpenManageSystemSuitesPageAsync();
            await SystemSuitesAssertions.VerifyManageSystemSuitesPage(rowsdropdown);

            //Check if the rows tool bar is present
            await SystemSuitesAssertions.VerifySystemSuiteRowToolbar(rowsdropdown);
            await rowsdropdownworkflow.OpenSystemSuitePageDropdownList();
            await SystemSuitesAssertions.VerifySystemSuiteRowPageDropdownList(rowsdropdown);
            await rowsdropdown.SystemSuiteRowDropdownList.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_SystemSuitePage_PageNumbersDropdownList_ForAdmins.png"
            });

        }
    }
}
