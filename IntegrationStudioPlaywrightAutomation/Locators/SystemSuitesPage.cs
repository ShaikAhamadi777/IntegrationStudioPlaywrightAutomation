using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace IntegrationStudioPlaywrightAutomation.Locators
{
    public class SystemSuitesPage
    {

        private readonly IPage Page;

        public SystemSuitesPage(IPage page)
        {
            Page = page;
        }

        public ILocator LHSMenu => Page.Locator(".uilab-layout-nav");
        public ILocator SystemSuites => Page.Locator("//a[@aria-label='System suites' and @href='/systemSuiteRoot']");
        public ILocator SystemsuitesSubMenu => Page.Locator("//uilab-sidesheet[@class='uilab-nav-rail__sidesheet open--']");
        public ILocator SystemsuitesSubMenuTitle => Page.Locator("//div[@class='uilab-sidesheet__title' and text()='System suites']");
        public ILocator SystemsuitesSubMenuClose => Page.Locator("[aria-label='Close']");
        public ILocator ManageSystemsuites => Page.Locator("[aria-label='Manage system suites']");
        public ILocator ManageSystemSuitesPage => Page.Locator("#app-main-container");
        public ILocator SystemSuiteTitle => Page.Locator("#systemsuite-page-toolbar");
        public ILocator SystemSuitesSubTitle => Page.Locator("#systemsuite-page-subtitle");
        public ILocator SystemSuitesInUse => Page.Locator(".chp-body-1");
        public ILocator UploadFileButton => Page.GetByTestId("FileUploadIcon");
        public ILocator SystemSuitesTable => Page.Locator("//table[@class='MuiTable-root css-28cyes']");
        public ILocator SystemSuitesTableColumns => Page.Locator("//thead[@class='MuiTableHead-root css-1wbz3t9']");
        public ILocator SystemSuitesTableRows => Page.Locator("//tr[@class='MuiTableRow-root css-axz6ke']");
        public ILocator SystemSuitesColumnNameHeading => Page.Locator("//th[text()='Name']");
        public ILocator SystemSuitesColumnSSType => Page.Locator("//th[text()='System suite type']");
        public ILocator SystemSuitesColumnEdited => Page.Locator("//th[text()='Edited']");
        public ILocator SystemSuiteTablePublicIcon => Page.GetByLabel("Public");
        public ILocator SystemSuiteTablePrivateIcon => Page.GetByLabel("Private");
        public ILocator SystemSuiteTypeGlobal => Page.Locator("text=Global");
        public ILocator SystemSuiteTypeCustom => Page.Locator("text=Custom");
        public ILocator SystemSuiteTypeTenant => Page.Locator("text=Tenant");
        public ILocator SystemSuiteEditedTime => Page.Locator("text=ago by");
        public ILocator SystemSuiteInUseTickIcon => Page.GetByTestId("CheckCircleOutlineIcon");
        public ILocator SystemSuite3DotMenu => Page.Locator("//span[@class='MuiTouchRipple-root css-w0pj6f']");
        public ILocator SystemSuite3DotMenuList => Page.Locator("//ul[contains(@class,'MuiMenu-list css-r8u8y9')]");
        public ILocator SystemSuiteDownloadFile => Page.Locator("//span[text()='Download system suite']");
        public ILocator SystemSuiteDeleteIcon => Page.Locator("//li[contains(@class,'MuiMenuItem-gutters css-174zwlc')]");
        public ILocator SystemSuiteNameList => Page.Locator("text=/^[A-Za-z0-9_]+$/");
        public ILocator SystemSuiteRowsPerpageName => Page.Locator("#mui-62");
        public ILocator SystemSuitePageDropDown => Page.GetByLabel("mui-62 mui-61");
        public ILocator SystemSuitePageNumbers => Page.Locator("text=1-10 of");
        public ILocator SystemSuitePreviousButton => Page.GetByLabel("Go to previous page");
        public ILocator SystemSuiteNextButton => Page.GetByTestId("KeyboardArrowRightIcon");


    }
}
