using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationStudioPlaywrightAutomation.Locators;

namespace IntegrationStudioPlaywrightAutomation.ComponentTests
{
    [TestFixture]
    public class GlobalParameters_UI_Tests : BaseTest
    {

        [Test]
        public async Task OpenGlobalParametersPage()
        {
            var gpparameters = new GlobalParametersPage(Page);

            await Expect(gpparameters.LHSMenu).ToBeVisibleAsync();
            await Expect(gpparameters.SystemSuites).ToBeVisibleAsync();

            //Click on the System suites button
            await gpparameters.SystemSuites.WaitForAsync();
            await gpparameters.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(gpparameters.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(gpparameters.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(gpparameters.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(gpparameters.GlobalParameters).ToBeVisibleAsync();
            
            await gpparameters.GlobalParameters.ClickAsync();
            await gpparameters.GlobalParameterPage.WaitForAsync();
            await Expect(gpparameters.GlobalParameterPage).ToBeVisibleAsync();

            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_GlobalParametersPage.png"
            });
        }

        [Test]
        public async Task OpenGlobalParametersPage_ShouldContain_TitleAndHeadText()
        {
            var gptitle = new GlobalParametersPage(Page);

            await Expect(gptitle.LHSMenu).ToBeVisibleAsync();
            await Expect(gptitle.SystemSuites).ToBeVisibleAsync();

            //Click on the System suites button
            await gptitle.SystemSuites.WaitForAsync();
            await gptitle.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(gptitle.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(gptitle.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(gptitle.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(gptitle.GlobalParameters).ToBeVisibleAsync();
            await gptitle.GlobalParameters.ClickAsync();
            await gptitle.GlobalParameterPage.WaitForAsync();
            await Expect(gptitle.GlobalParameterPage).ToBeVisibleAsync();

            await Expect(gptitle.GlobalParametersToolBar).ToBeVisibleAsync();
            await Expect(gptitle.GlobalParameterTitle).ToBeVisibleAsync();
            await Expect(gptitle.GlobalParameterSubTitle).ToBeVisibleAsync();
            
            
            await gptitle.GlobalParametersToolBar.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_GlobalParametersToolBar.png"
            });
        }

        [Test]
        public async Task OpenGlobalParametersPage_ShouldContain_AVEVASPFields()
        {
            var sp = new GlobalParametersPage(Page);

            await Expect(sp.LHSMenu).ToBeVisibleAsync();
            await Expect(sp.SystemSuites).ToBeVisibleAsync();

            //Click on the System suites button
            await sp.SystemSuites.WaitForAsync();
            await sp.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(sp.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(sp.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(sp.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(sp.GlobalParameters).ToBeVisibleAsync();
            await sp.GlobalParameters.ClickAsync();
            await sp.GlobalParameterPage.WaitForAsync();
            await Expect(sp.GlobalParameterPage).ToBeVisibleAsync();
            
            //Check for the AVEVA System platform heading and text fields
            await sp.SPFamilyGroupHeading.WaitForAsync();
            await Expect(sp.SPFamilyGroupHeading).ToBeVisibleAsync();
            await Expect(sp.SPUsernameField).ToBeVisibleAsync();
            await Expect(sp.SPPasswordFiled).ToBeVisibleAsync();

            await Expect(sp.SPUsernameField).ToBeEditableAsync();
            await Expect(sp.SPPasswordFiled).ToBeEditableAsync();

            await Expect(sp.EyeIcon).ToBeVisibleAsync();
            await Expect(sp.EyeIcon).ToBeEnabledAsync();

            await Expect(sp.SPUsernameField).Not.ToBeEmptyAsync();
            await Expect(sp.SPPasswordFiled).Not.ToBeEmptyAsync();
        }

    }
}
