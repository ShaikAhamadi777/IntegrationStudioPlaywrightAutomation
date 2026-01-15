using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;


namespace IntegrationStudioPlaywrightAutomation.Locators
{
    public class GlobalParametersPage
    {

        private readonly IPage Page;

        public GlobalParametersPage(IPage page)
        {
            Page = page;
        }

        public ILocator LHSMenu => Page.Locator(".uilab-layout-nav");
        public ILocator SystemSuites => Page.Locator("//a[@aria-label='System suites' and @href='/systemSuiteRoot']");
        public ILocator SystemsuitesSubMenu => Page.Locator("//uilab-sidesheet[@class='uilab-nav-rail__sidesheet open--']");
        public ILocator SystemsuitesSubMenuTitle => Page.Locator("//div[@class='uilab-sidesheet__title' and text()='System suites']");
        public ILocator SystemsuitesSubMenuClose => Page.Locator("[aria-label='Close']");
        public ILocator GlobalParameters => Page.Locator("[aria-label='Global parameters']");
        public ILocator GlobalParameterPage => Page.Locator("#app-main-container");

        public ILocator GlobalParameterTitle => Page.Locator("#systemsuite-page-toolbar");
        public ILocator GlobalParameterSubTitle => Page.Locator("#systemsuite-page-subtitle");
        public ILocator GlobalParametersToolBar => Page.Locator("#page-toolbar");
        public ILocator SPFamilyGroupHeading => Page.Locator("//p[text()='AVEVA System Platform']");
        public ILocator SPUsernameField => Page.Locator("#uilab-textfield-0");
        public ILocator SPPasswordFiled => Page.Locator("#uilab-textfield-1");
        public ILocator EyeIcon => Page.Locator("//uilab-icon[@icon='view--show']");

        public ILocator EdgeFamilyGroupHeading => Page.Locator("//p[text()='AVEVA Edge']");
        public ILocator EdgeValue => Page.Locator("text=No parameters available");
        public ILocator PlantSCADAGroupHeading => Page.Locator("//p[text()='AVEVA Plant SCADA']");
        public ILocator PlantSCADAValue => Page.Locator("text=No parameters available");
        public ILocator GPCancelButton => Page.Locator("#instancelaunch-cancel-btn");
        public ILocator GPSaveButton => Page.Locator("#submit-launch-btn");
        public ILocator Buttons => Page.Locator("//div[@style='text-align: right;']");





    }
}
