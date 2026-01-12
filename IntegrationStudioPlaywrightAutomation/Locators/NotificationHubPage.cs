using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Text.RegularExpressions;



namespace IntegrationStudioPlaywrightAutomation.Locators
{
    public class NotificationHubPage
    {
        //Represents the broswer tab
        private readonly IPage Page;

        //Page Object doesnot create browser . It only receives it 
        public NotificationHubPage(IPage page)
        {
           Page = page;
        }

        //NotificationHub Elements locators
        public ILocator NotificationBellIcon => Page.Locator("uilab-icon-button[aria-label='Notifications']");
       
        //Notification Panel Elements locators
        public ILocator NotificationPanel => Page.Locator("#notifyContainer");
        public ILocator NotificationScrollBar => Page.Locator("//div[@class='MuiPaper-root MuiPaper-elevation MuiPaper-elevation16 MuiDrawer-paper MuiDrawer-paperAnchorRight css-1ab2xsx']");
        public ILocator NumberOfNotifications => Page.Locator("#notifyCount");
        public ILocator NumberOfNotificationsInBellIcon => Page.Locator(".uilab-badge on-icon-btn--");
        public ILocator NotificationClearAllButton => Page.Locator("//button[text()='Clear all']");
        public ILocator NotificationCloseButton => Page.Locator("//div[@id='notifyHeader']//button[@class='MuiButtonBase-root MuiIconButton-root MuiIconButton-sizeMedium css-1yxmbwk']");
        public ILocator NotificationsAvailable => Page.Locator(".notifyInfo");
        public ILocator NumberOnBellIcon => Page.Locator("//span[contains(@class,'uilab-badge on-icon-btn')]");
        public ILocator InstanceExpiryWarnings => Page.Locator("//div[@class='notifyCard decoration-line-warning']");
        public ILocator InstanceDeletion => Page.Locator("//div[contains(@class,'notifyCard') and contains(@class,'decoration-line-error')]");
        //public ILocator FirstInstanceDeletion => InstanceDeletion.First;


    }
}
