using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationStudioPlaywrightAutomation
{
    [Test]
    public class NavigationBarTests
    {
        var nav = new NavigationBarPage(Page);

        await nav.Verify_AppBar_Visibility();

        await nav.Verify_NotificationPanel();

        await nav.Verify_AVEVAHelpIcon();

        await nav.Verify_UserProfileIcon();

        await nav.Verify_UserProfilePopup();

        await nav.Verify_NetworkSpeedTest();

        await nav.Verify_LogOutButton();

        await nav.Verify_LegalLink();


    }
}
