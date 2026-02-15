using IntegrationStudioPlaywrightAutomation.Locators;
using IntegrationStudioPlaywrightAutomation.Utilities.Models;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Microsoft.Playwright.Assertions;

namespace IntegrationStudioPlaywrightAutomation.Assertions
{
    public static class SystemSuitesAssertions
    {
        public static async Task VerifySystemSuitesOptionFromLHSMenu(SystemSuitesPage page)
        {
            await Expect(page.LHSMenu).ToBeVisibleAsync();
            await Expect(page.SystemSuites).ToBeVisibleAsync();
            await page.SystemSuites.WaitForAsync();
        }
        public static async Task VerifySystemSuitesSubMenu(SystemSuitesPage page)
        {
            await Expect(page.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(page.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(page.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(page.ManageSystemsuites).ToBeVisibleAsync();
            await Expect(page.GlobalParameters).ToBeVisibleAsync();

        }
        public static async Task VerifyManageSystemSuitesPage(SystemSuitesPage page)
        {
            await page.ManageSystemSuitesPage.WaitForAsync();
            await Expect(page.ManageSystemSuitesPage).ToBeVisibleAsync();
        }
        public static async Task VerifyManageSystemSuitesPageTitleAndSubTitle(SystemSuitesPage page)
        {
            await Expect(page.SystemSuiteTitle).ToBeVisibleAsync();
            page.SystemSuiteTitle.Equals("System suites");
            await Expect(page.SystemSuitesSubTitle).ToBeVisibleAsync();
            page.SystemSuitesSubTitle.Equals("Create and manage system suites used by your project templates.");
        }
        public static async Task VerifySystemSuitesInUse(SystemSuitesPage page)
        {
            await Expect(page.SystemSuitesInUse).ToBeVisibleAsync();
        }
        public static async Task VerifySystemSuiteUploadFileButton(SystemSuitesPage page)
        {
            await page.UploadFileButton.WaitForAsync();
            await Expect(page.UploadFileButton).ToBeVisibleAsync();
        }
        public static async Task VerifySystemSuiteUploadFileButtonHidden(SystemSuitesPage page)
        {
            await Expect(page.UploadFileButton).ToBeHiddenAsync();
        }
        public static async Task VerifySystemSuiteTableColumnHeadingsForSSAdmin(SystemSuitesPage page)
        {
            await Expect(page.SystemSuitesTable).ToBeVisibleAsync();
            await Expect(page.SystemSuitesTableColumns).ToBeVisibleAsync();
            await Expect(page.SystemSuitesColumnNameHeading).ToBeVisibleAsync();
            await Expect(page.SystemSuitesColumnSSType).ToBeVisibleAsync();
            await Expect(page.SystemSuitesColumnEdited).ToBeVisibleAsync();
        }
        public static async Task VerifySystemSuiteTableColumnHeadingsForExtAdmin(SystemSuitesPage page)
        {
            await Expect(page.SystemSuitesTable).ToBeVisibleAsync();
            await Expect(page.SystemSuitesTableColumns).ToBeVisibleAsync();
            await Expect(page.SystemSuitesColumnNameHeading).ToBeVisibleAsync();
            await Expect(page.SystemSuitesColumnSSType).ToBeHiddenAsync();
            await Expect(page.SystemSuitesColumnEdited).ToBeVisibleAsync();
        }
        public static async Task VerifySystemSuiteTableRows(SystemSuitesPage page)
        {
            await Expect(page.SystemSuitesTableRows.First).ToBeVisibleAsync();
        }
        public static async Task VerifyGlobalSystemSuiteForAdmins(SystemSuitesPage page)
        {
            await page.SystemSuiteTypeGlobal.First.WaitForAsync();
            await Expect(page.SystemSuiteTypeGlobal.First).ToBeVisibleAsync();
        }
        public static async Task VerifyGlobalSystemSuiteForExtAdmin(SystemSuitesPage page)
        {
            await Expect(page.SystemSuiteTypeGlobal.First).ToBeHiddenAsync();
        }
        public static async Task VerifyTenantLevelSystemSuiteVisible(SystemSuitesPage page)
        {
            await Expect(page.SystemSuiteTypeTenant.First).ToBeVisibleAsync();
        }
        public static async Task VerifyTenantLevelSystemSuiteHidden(SystemSuitesPage page)
        {
            await Expect(page.SystemSuiteTypeTenant.First).ToBeHiddenAsync();
        }
        public static async Task VerifyCustomLevelSystemSuiteVisible(SystemSuitesPage page)
        {
            await Expect(page.SystemSuiteTypeCustom.First).ToBeVisibleAsync();
        }
        public static async Task VerifyCustomLevelSystemSuiteHidden(SystemSuitesPage page)
        {
            await Expect(page.SystemSuiteTypeCustom.First).ToBeHiddenAsync();
        }
        public static async Task VerifyPublicSSVisible(SystemSuitesPage page)
        {
            await page.SystemSuiteTablePublicIcon.First.WaitForAsync();
            await Expect(page.SystemSuiteTablePublicIcon.First).ToBeVisibleAsync();
        }
        public static async Task VerifyPublicSSHidden(SystemSuitesPage page)
        {
            await Expect(page.SystemSuiteTablePublicIcon.First).ToBeHiddenAsync();
        }
        public static async Task VerifyPrivateSSVisible(SystemSuitesPage page)
        {
            await page.SystemSuiteTablePrivateIcon.First.WaitForAsync();
            await Expect(page.SystemSuiteTablePrivateIcon.First).ToBeVisibleAsync();
        }
        public static async Task VerifyPrivateSSHidden(SystemSuitesPage page)
        {
            await Expect(page.SystemSuiteTablePrivateIcon.First).ToBeHiddenAsync();
        }
        public static async Task VerifySystemSuiteEditedTime(SystemSuitesPage page)
        {
            await Expect(page.SystemSuiteEditedTime.First).ToBeVisibleAsync();
        }
        public static async Task VerifySystemSuiteInUseTickIconVisible(SystemSuitesPage page)
        {
            await page.SystemSuiteInUseTickIcon.First.HoverAsync();
            await page.SystemSuiteInUseTickIcon.First.HighlightAsync();
            await Expect(page.SystemSuiteInUseTickIcon.First).ToBeVisibleAsync();
        }
        public static async Task VerifySystemSuiteInUseTickIconHidden(SystemSuitesPage page)
        {
            await Expect(page.SystemSuiteInUseTickIcon).ToBeHiddenAsync();
        }
        public static async Task VerifyGlobalSystemSuite3DotMenu(SystemSuitesPage page)
        {
            await Expect(page.SystemSuite3DotMenuList).ToBeVisibleAsync();
            await Expect(page.SystemSuiteDownloadFile).ToBeVisibleAsync();
            await Expect(page.SystemSuiteDownloadFile).ToBeEnabledAsync();
        }
        public static async Task VerifyTenantLevelSystemSuite3DotMenu(SystemSuitesPage page)
        {
            await Expect(page.SystemSuite3DotMenuList).ToBeVisibleAsync();
            await Expect(page.SystemSuiteDownloadFile).ToBeVisibleAsync();
            await Expect(page.SystemSuiteDownloadFile).ToBeEnabledAsync();
            await Expect(page.SystemSuiteDeleteIcon).ToBeVisibleAsync();
            await Expect(page.SystemSuiteDeleteIcon).ToBeEnabledAsync();
        }
        public static async Task VerifyCustomSystemSuite3DotMenu(SystemSuitesPage page)
        {
        
        await Expect(page.SystemSuite3DotMenuList).ToBeVisibleAsync();
        await Expect(page.SystemSuiteDeleteIcon).ToBeVisibleAsync();
        await Expect(page.SystemSuiteDeleteIcon).ToBeEnabledAsync();
        }
        public static async Task VerifySystemSuiteRowToolbar(SystemSuitesPage page)
        {
            await Expect(page.SystemSuiteRowsToolbar).ToBeVisibleAsync();
            await Expect(page.SystemSuiteRowsPerpageName).ToBeVisibleAsync();
            await Expect(page.SystemSuitePageDropDown).ToBeVisibleAsync();
            await Expect(page.SystemSuitePageNumbers).ToBeVisibleAsync();
            await Expect(page.SystemSuitePreviousButton).ToBeVisibleAsync();
            await Expect(page.SystemSuitePreviousButton).ToBeDisabledAsync();
            await Expect(page.SystemSuiteNextButton).ToBeVisibleAsync();
        }
        public static async Task VerifySystemSuiteRowPageDropdownList(SystemSuitesPage page)
        {
            await Expect(page.SystemSuiteRowDropdownList).ToBeVisibleAsync();

            //Verify the numbers of the pages in the dropdown
            await Expect(page.SystemSuiteRowDropdownListNumber10).ToBeVisibleAsync();
            await Expect(page.SystemSuiteRowDropdownListNumber25).ToBeVisibleAsync();
            await Expect(page.SystemSuiteRowDropdownListNumber50).ToBeVisibleAsync();
            await Expect(page.SystemSuiteRowDropdownListNumber100).ToBeVisibleAsync();
        }

    }
}
