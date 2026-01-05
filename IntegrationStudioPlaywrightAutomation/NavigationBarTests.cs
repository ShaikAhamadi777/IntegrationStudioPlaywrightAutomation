using IntegrationStudioPlaywrightAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationStudioPlaywrightAutomation.Tests
{
    [TestFixture]
    public class NavigationBarTests : BaseTest
    {
        [Test]
        public async Task NavigationBar_Should_Display_All_Elements()
        {

            var nav = new NavigationBarPage(Page);
            await nav.VerifyAllNavigationBarElements();
        }
    }
}
