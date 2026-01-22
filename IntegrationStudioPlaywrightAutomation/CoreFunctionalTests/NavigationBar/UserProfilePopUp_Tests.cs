using IntegrationStudioPlaywrightAutomation.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationStudioPlaywrightAutomation.CoreFunctionalTests.NavigationBar
{
    internal class UserProfilePopUp_Tests : BaseTest
    {

        [Test]
        public async Task Verify_UserProfile_Popup_Message()
        {
            var userprofilepopupmessage = new ProjectTemplatesPage(Page);

            await Expect(userprofilepopupmessage.UserProfileIcon).ToBeVisibleAsync();
            await userprofilepopupmessage.UserProfileIcon.ClickAsync();
            await userprofilepopupmessage.UserProfilePopUp.WaitForAsync();
            await Expect(userprofilepopupmessage.UserProfilePopUp).ToBeVisibleAsync();

            await Expect(userprofilepopupmessage.UserName).ToBeEnabledAsync();
            await userprofilepopupmessage.UserName.ClickAsync();

            await userprofilepopupmessage.UserProfileDialog.WaitForAsync();
            await Expect(userprofilepopupmessage.UserProfileDialog).ToBeVisibleAsync();

            await Expect(userprofilepopupmessage.UserProfileContent).ToBeVisibleAsync();
            await Expect(userprofilepopupmessage.UserProfileEmail).ToBeVisibleAsync();
            await Expect(userprofilepopupmessage.UserProfileSubscription).ToBeVisibleAsync();

            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_UserProfileDialog.png"
            });

            await Expect(userprofilepopupmessage.UserProfileCloseButton).ToBeVisibleAsync();
            await userprofilepopupmessage.UserProfileCloseButton.ClickAsync();
            await userprofilepopupmessage.UserProfileDialog.IsHiddenAsync();
        }

    }
}
