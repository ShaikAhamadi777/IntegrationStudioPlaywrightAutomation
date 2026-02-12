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
        private readonly NotificationHubPage NHPage;
        private readonly NavigationBarPage NBPage;


        public NavigationBarNotificationPanelWorkflow(IPage page)
        {
            NHPage = new NotificationHubPage(page);
            NBPage = new NavigationBarPage(page);
        }
        public async Task Open()
        {

        }
        public async Task OpenNew()
        {

        }

    }
}
