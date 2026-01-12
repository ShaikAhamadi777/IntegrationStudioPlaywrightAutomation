using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using System.Text.RegularExpressions;


namespace IntegrationStudioPlaywrightAutomation.Locators
{
    public class GeneralSettingsPage 
    {
        private readonly IPage Page;

        public GeneralSettingsPage(IPage page)
        {
            Page = page;
        }

        //Loators of General Settings page
        public ILocator LHSMenu => Page.Locator(".uilab-layout-nav");
        public ILocator General => Page.Locator("[aria-label='General']");
        public ILocator GeneralPage => Page.Locator("#app-main-container");
        public ILocator GeneralSettingPage => Page.Locator("//div[text()='General settings']");
        public ILocator NumberOfVMsInUse => Page.Locator("//div[text()='Number of VMs in use']");
        public ILocator NumberOfSnapshotsInUse => Page.Locator("//div[text()='Number of snapshots in use']");


    }
}
