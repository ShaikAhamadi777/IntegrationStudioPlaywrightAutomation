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

            if(await gpparameters.SystemSuites.IsVisibleAsync())
            {
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
            else
            {
                await Expect(gpparameters.GlobalParameters).ToBeHiddenAsync();
            }
        }

        [Test]
        public async Task OpenGlobalParametersPage_ShouldContain_TitleAndHeadText()
        {
            var gptitle = new GlobalParametersPage(Page);

            await Expect(gptitle.LHSMenu).ToBeVisibleAsync();

            if (await gptitle.SystemSuites.IsVisibleAsync())
            {
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
            else
            {
                await Expect(gptitle.GlobalParameters).ToBeHiddenAsync();
            }
        }

        [Test]
        public async Task OpenGlobalParametersPage_ShouldContain_AVEVASPFields()
        {
            var sp = new GlobalParametersPage(Page);

            await Expect(sp.LHSMenu).ToBeVisibleAsync();

            if (await sp.SystemSuites.IsVisibleAsync())
            {
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
            }
            else
            {
                await Expect(sp.GlobalParameters).ToBeHiddenAsync();
            }
        }

        [Test]
        public async Task OpenGlobalParametersPage_ShouldContain_AVEVAEdgeFields()
        {
            var edge = new GlobalParametersPage(Page);
            await Expect(edge.LHSMenu).ToBeVisibleAsync();

            if (await edge.SystemSuites.IsVisibleAsync())
            {
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
                await edge.EdgeValue.ScreenshotAsync(new()
                {
                    Path = "Screenshot_Of_AVEVAEdge_Value.png"
                });
            }
            else
            {
                await Expect(edge.GlobalParameters).ToBeHiddenAsync();
            }
        }

        [Test]
        public async Task OpenGlobalParametersPage_ShouldContain_PlantSCADAFields()
        {
            var plantscada = new GlobalParametersPage(Page);

            await Expect(plantscada.LHSMenu).ToBeVisibleAsync();

            if (await plantscada.SystemSuites.IsVisibleAsync())
            {
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
                    Path = "Screenshot_Of_PlantSCADA_Value.png"
                });
            }
            else
            {
                await Expect(plantscada.GlobalParameters).ToBeHiddenAsync();
            }
        }

        [Test]
        public async Task OpeOpenGlobalParametersPage_ShouldContain_CancelSaveButton()
        {
            var button = new GlobalParametersPage(Page);

            await Expect(button.LHSMenu).ToBeVisibleAsync();

            if (await button.SystemSuites.IsVisibleAsync())
            {

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
                    Path = "Screenshot_Of_CancelSaveButtons.png"
                });
            }
            else
            {
                await Expect(button.GlobalParameters).ToBeHiddenAsync();
            }
        }
    }
}
