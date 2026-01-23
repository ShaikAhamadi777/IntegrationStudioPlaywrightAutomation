using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationStudioPlaywrightAutomation.Locators
{
    public class ProjectTemplatesPage
    {
        //Represents the broswer tab
        private readonly IPage Page;

        //Page Object doesnot create browser . It only receives it 
        public ProjectTemplatesPage(IPage page)
        {
            Page = page;
        }

        //ProjectTemplate Elements Locators
        public ILocator AppBar => Page.Locator("section#app-bar");
        public ILocator NotificationBellIcon => Page.Locator("uilab-icon-button[aria-label='Notifications']");
        public ILocator AVEVAHelpIcon => Page.Locator("[aria-label='Help']");
        public ILocator UserProfileIcon => Page.Locator("[aria-label='Open menu']").Filter(new LocatorFilterOptions { Has = Page.Locator(":visible") });
        public ILocator AVEVAHelpSignInButton => Page.Locator("button[aria-label='AVEVA Employee']");

        
        //LHS Menu Locators
        public ILocator ProjectTemplatePage => Page.Locator("#app-layout-container");
        public ILocator LHSMenu => Page.Locator(".uilab-layout-nav");
        public ILocator ProjectTemplates => Page.Locator("[aria-label='Project templates']");
        public ILocator SystemSuites => Page.Locator("//a[@aria-label='System suites' and @href='/systemSuiteRoot']");
        public ILocator GlobalRDPRules => Page.Locator("[aria-label='Global RDP rules']");
        public ILocator General => Page.Locator("[aria-label='General']");
        public ILocator CollapseButtonContent => Page.Locator("//span[text()='Collapse']");
        public ILocator CollapseButtonIcon => Page.Locator(".uilab-nav-rail__footer");

        //System suites Locators
        public ILocator SystemsuitesSubMenu => Page.Locator("//uilab-sidesheet[@class='uilab-nav-rail__sidesheet open--']");
        public ILocator SystemsuitesSubMenuTitle => Page.Locator("//div[@class='uilab-sidesheet__title' and text()='System suites']");
        public ILocator SystemsuitesSubMenuClose => Page.Locator("[aria-label='Close']");
        public ILocator ManageSystemsuites => Page.Locator("[aria-label='Manage system suites']");
        public ILocator GlobalParameters => Page.Locator("[aria-label='Global parameters']");

        //System suite Page locators
        public ILocator SystemSuitesPage => Page.Locator("#app-main-container");
        public ILocator GlobalParametersPage => Page.Locator("//h2[text()='Global parameters']");
        public ILocator GlobalRDPRulesPage => Page.Locator("//div[text()='Global RDP rules']");
        public ILocator GeneralSettingsPage => Page.Locator("//div[text()='General settings']");

        //UserProfile Button Locators
        public ILocator UserProfilePopUp => Page.Locator("//section[contains(@class,'menu-surface--is-open-below')]");
        public ILocator UserName => Page.Locator("//a[contains(@title,'@')]");
        public ILocator TenantName => Page.Locator("text=/^[A-Za-z0-9_]+$/").First;
        public ILocator NetworkSpeedTest => Page.Locator("//a[@title='Network Speed Test']");
        public ILocator LogOut => Page.Locator("//a[@title='Log Out']");
        public ILocator CopyRightAndLegal => Page.Locator("//div[@class='uilab-list__legal' and text()=' © 2016 ']");

        public ILocator UserProfileDialog => Page.Locator("//h2[text()='User Profile']");
        public ILocator UserProfileContent => Page.Locator("#userprofile-dialog-content");
        public ILocator UserProfileEmail => Page.Locator("//div[text()='Email']");
        public ILocator UserProfileSubscription => Page.Locator("//div[text()='Subscription']");
        public ILocator UserProfileCloseButton => Page.Locator("#userprofile-dialog-close-btn");

        public ILocator Signout => Page.Locator("//h4[text()='Sign Out']");
        public ILocator LegalLink => Page.Locator("//a[text()=' Legal ']");
        public ILocator LegalResources => Page.Locator("//h1[text()='Legal Resources']");

        public ILocator NoProjectTemplates => Page.Locator("//td[text()='No project templates defined']");

        //Project templates Page Locators
        public ILocator ProjectTemplateTitle => Page.Locator("#project-page-toolbar");
        public ILocator CreateProjectTemplateButton => Page.Locator("#project-add-btn");
        public ILocator ProjectTemplateTable => Page.Locator("#project-table");
        public ILocator ProjectTableHead => Page.Locator("#project-table-head");
        public ILocator ProjectTableColumns => Page.Locator("#project-table-colunms");
        public ILocator InstanceColumnHeading => Page.Locator("//th[text()='Instances']");
        public ILocator NameColumnHeading => Page.Locator("//th[text()='Name']");
        public ILocator DescColumnHeading => Page.Locator("//th[text()='Description']");
        public ILocator LastUpdatedColumnHeading => Page.Locator("//th[text()='Last updated']");
        public ILocator ProjectTemplateRowToolBar => Page.Locator("//div[contains(@class,'MuiTablePagination-toolbar css-8nphli')]");
        public ILocator ProjectTemplateRowsPerPageText => Page.Locator("//p[text()='Rows per page:']");

        //Row Tool Bar Locators
        public ILocator ProjectTemplatePageDropDown => Page.Locator("[aria-haspopup='listbox']");
        public ILocator ProjectTemplatePageDropdownList => Page.Locator("//ul[contains(@class,'MuiMenu-list css-r8u8y9')]");
        public ILocator ProjectTemplatePageDropdownListNumber10 => Page.Locator("//li[@data-value='10']");
        public ILocator ProjectTemplatePageDropdownListNumber25 => Page.Locator("//li[@data-value='25']");
        public ILocator ProjectTemplatePageDropdownListNumber50 => Page.Locator("//li[@data-value='50']");
        public ILocator ProjectTemplatePageDropdownListNumber100 => Page.Locator("//li[@data-value='100']");
        public ILocator ProjectTemplatePageNumberRange => Page.Locator("//p[@class='MuiTablePagination-displayedRows css-14j95jv']");
        public ILocator ProjectTemplatePageArrows => Page.Locator(".MuiTablePagination-actions");
        public ILocator ProjectTemplatePageGoToFirstPageArrow => Page.Locator("[aria-label='Go to first page']");
        public ILocator ProjectTemplatePageGoToPreviousPageArrow => Page.Locator("[aria-label='Go to previous page']");
        public ILocator ProjectTemplatePageGoToNextPageArrow => Page.Locator("[aria-label='Go to next page']");
        public ILocator ProjectTemplatePageLastPageArrow => Page.Locator("[data-testid='LastPageIcon']");



        public ILocator projectrows => Page.Locator("//tr[contains(@class,'MuiTableRow-root project')]");
        public ILocator firstprojectrow => projectrows.First;
        public ILocator ThreeDot => firstprojectrow.Locator("//div[@class='project-row-actions']//button").Last;
        public ILocator ThreeDotmenuPopup => Page.Locator("//ul[contains(@class,'MuiMenu-list css-r8u8y9')]");
        public ILocator ThreeDotMenuNewinstance => Page.Locator("//span[contains(text(),'New instance')]");
        public ILocator ThreeDotMenuEdit => Page.Locator("//span[contains(text(),'Edit')]");
        public ILocator ThreeDotMenuDelete => Page.Locator("//span[contains(text(),'Delete')]");
        public ILocator ProjectTemplateEdit => Page.Locator("//div[text()='Edit project template']");


    }
}
