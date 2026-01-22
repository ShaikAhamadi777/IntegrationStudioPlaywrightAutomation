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
        [TestCase("SystemAdmin")]
        [TestCase("ExternalAdmin")]
        [Category("Admins")]
        public async Task OpenGlobalParametersPage_ShouldBeVisible_ForAdmins(string role)
        {
            var gpparameters = new GlobalParametersPage(Page);

            await Expect(gpparameters.LHSMenu).ToBeVisibleAsync();
               
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
                Path = "Screenshot_Of_GlobalParametersPage_ForAdmins.png"
            });
            await Expect(gpparameters.GlobalParameters).ToBeHiddenAsync();
        }

        [Test]
        [TestCase("ProjectUser")]
        [Category("ProjectUser")]
        public async Task OpenGlobalParametersPage_ShouldNotBeVisible_ForProjectUser(string role)
        {
            var usergpparameters = new GlobalParametersPage(Page);

            await Expect(usergpparameters.LHSMenu).ToBeVisibleAsync();
            await Expect(usergpparameters.SystemSuites).ToBeHiddenAsync();
            await Expect(usergpparameters.GlobalParameters).ToBeHiddenAsync();
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_GlobalParametersPage_ForProjectUser.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [TestCase("ExternalAdmin")]
        [Category("Admins")]
        public async Task OpenGlobalParametersPage_ShouldContain_TitleAndHeadText_ForAdmins(string role)
        {
            var gptitle = new GlobalParametersPage(Page);

            await Expect(gptitle.LHSMenu).ToBeVisibleAsync();

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
        [TestCase("SystemAdmin")]
        [TestCase("ExternalAdmin")]
        [Category("Admins")]
        public async Task OpenGlobalParametersPage_ShouldContain_AVEVASPFields_ForAdmins(string role)
        {
            var sp = new GlobalParametersPage(Page);

            await Expect(sp.LHSMenu).ToBeVisibleAsync();

            await sp.SystemSuites.WaitForAsync();

            //Click on the System suites button
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

            //Check if the AVEVA System Platform fields are editable
            await Expect(sp.SPUsernameField).ToBeEditableAsync();
            await Expect(sp.SPPasswordFiled).ToBeEditableAsync();

            //Check the Eye icon
            await Expect(sp.EyeIcon).ToBeVisibleAsync();
            await Expect(sp.EyeIcon).ToBeEnabledAsync();

            //Check if the fields are not empty
            await Expect(sp.SPUsernameField).Not.ToBeEmptyAsync();
            await Expect(sp.SPPasswordFiled).Not.ToBeEmptyAsync();

            await Page.ScreenshotAsync(new()
            {
                Path = "ScreenShot_Of_AVEVASPFields.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [TestCase("ExternalAdmin")]
        [Category("Admins")]
        public async Task OpenGlobalParametersPage_ShouldContain_AVEVAEdgeFields_ForAdmins(string role)
        {
            var edge = new GlobalParametersPage(Page);
            await Expect(edge.LHSMenu).ToBeVisibleAsync();

            await edge.SystemSuites.WaitForAsync();
            
            //Click on the System suites button
            await edge.SystemSuites.ClickAsync();
            
            //Check and verify the system suites sub menu
            await Expect(edge.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(edge.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(edge.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(edge.GlobalParameters).ToBeVisibleAsync();
            await edge.GlobalParameters.ClickAsync();
            await edge.GlobalParameterPage.WaitForAsync();
            await Expect(edge.GlobalParameterPage).ToBeVisibleAsync();
            
            await edge.EdgeFamilyGroupHeading.WaitForAsync();
            await Expect(edge.EdgeFamilyGroupHeading).ToBeVisibleAsync();
            await Expect(edge.EdgeValue.First).ToBeVisibleAsync();
            await edge.EdgeValue.First.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_AVEVAEdgeValue_ForAdmins.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [TestCase("ExternalAdmin")]
        [Category("Admins")]
        public async Task OpenGlobalParametersPage_ShouldContain_PlantSCADAFields_ForAdmins(string role)
        {
            var plantscada = new GlobalParametersPage(Page);

            await Expect(plantscada.LHSMenu).ToBeVisibleAsync();

            await plantscada.SystemSuites.WaitForAsync();

            //Click on the System suites button
            await plantscada.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(plantscada.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(plantscada.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(plantscada.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(plantscada.GlobalParameters).ToBeVisibleAsync();
            await plantscada.GlobalParameters.ClickAsync();
            await plantscada.GlobalParameterPage.WaitForAsync();
            await Expect(plantscada.GlobalParameterPage).ToBeVisibleAsync();

            await plantscada.PlantSCADAGroupHeading.WaitForAsync();
            await Expect(plantscada.PlantSCADAGroupHeading).ToBeVisibleAsync();
            await Expect(plantscada.PlantSCADAValue.Last).ToBeVisibleAsync();
            await plantscada.PlantSCADAValue.Last.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_PlantSCADAValue_ForAdmins.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [TestCase("ExternalAdmin")]
        [Category("Admins")]
        public async Task OpeOpenGlobalParametersPage_ShouldContain_CancelSaveButton_ForAdmins(string role)
        {
            var button = new GlobalParametersPage(Page);

            await Expect(button.LHSMenu).ToBeVisibleAsync();

            await button.SystemSuites.WaitForAsync();
            await button.SystemSuites.ClickAsync();

            //Check and verify the system suites sub menu
            await Expect(button.SystemsuitesSubMenu).ToBeVisibleAsync();
            await Expect(button.SystemsuitesSubMenuTitle).ToBeVisibleAsync();
            await Expect(button.SystemsuitesSubMenuClose).ToBeVisibleAsync();
            await Expect(button.GlobalParameters).ToBeVisibleAsync();
            await button.GlobalParameters.ClickAsync();
            await button.GlobalParameterPage.WaitForAsync();
            await Expect(button.GlobalParameterPage).ToBeVisibleAsync();

            //Check for the Save and the Cancel button
            await Expect(button.GPCancelButton).ToBeVisibleAsync();
            await Expect(button.GPCancelButton).ToBeEnabledAsync();

            await Expect(button.GPSaveButton).ToBeVisibleAsync();
            await Expect(button.GPSaveButton).ToBeEnabledAsync();
            await button.Buttons.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_CancelSaveButtons_ForAdmins.png"
            });
        }
    }
}
