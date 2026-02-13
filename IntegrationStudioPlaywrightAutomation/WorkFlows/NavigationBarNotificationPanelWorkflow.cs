using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using IntegrationStudioPlaywrightAutomation.Locators;


namespace IntegrationStudioPlaywrightAutomation.WorkFlows
{
    public class NavigationBarNotificationPanelWorkflow
    {
        private readonly NavigationBarNotificationPanelPage NHPage;
        private readonly NavigationBarNotificationPanelPage NBPage;


        public NavigationBarNotificationPanelWorkflow(IPage page)
        {
            NHPage = new NavigationBarNotificationPanelPage(page);
            NBPage = new NavigationBarNotificationPanelPage(page);
        }
        public async Task OpenUserProfilePopupAsync()
        {
            await NBPage.ClickUserProfileButton();
        }
        public async Task OpenNotificationPanelAsync()
        {
            await NHPage.ClickNotificationPanelIcon();
        }

    }
}
