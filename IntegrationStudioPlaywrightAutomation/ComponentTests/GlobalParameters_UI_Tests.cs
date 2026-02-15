using IntegrationStudioPlaywrightAutomation.Assertions;
using IntegrationStudioPlaywrightAutomation.Locators;
using IntegrationStudioPlaywrightAutomation.Utilities.Models;
using IntegrationStudioPlaywrightAutomation.WorkFlows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var gpparameterss = new SystemSuitesPage(Page);
            var gpparametersworkflow = new GlobalParametersWorkflow(Page);
            var systemsuites = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(gpparameterss);
            await systemsuites.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(gpparameterss);
            await gpparametersworkflow.OpenGlobalParametersPageAsync();
            await GlobalParametersAssertions.VerifyGlobalParametersPage(gpparameters);
            
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
            var projecttempgpparameters = new ProjectTemplatesPage(Page);
            await ProjectTemplatesAssertions.VerifyLHSMenuForProjectUser(projecttempgpparameters);
            await Page.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_GlobalParametersPage_ForProjectUser.png"
            });
        }

        [Test]
        [TestCase("SystemAdmin")]
        [TestCase("ExternalAdmin")]
        [Category("Admins")]
        public async Task OpenGlobalParametersPage_ShouldContain_AVEVASPFields_ForAdmins(string role)
        {
            var sp = new GlobalParametersPage(Page);
            var spss = new SystemSuitesPage(Page);
            var spworkflow = new GlobalParametersWorkflow(Page);
            var spssworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(spss);
            await spssworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(spss);
            await spworkflow.OpenGlobalParametersPageAsync();
            await GlobalParametersAssertions.VerifyGlobalParametersPage(sp);
            await GlobalParametersAssertions.VerifyAVEVASystemPlatformFields(sp);
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
            var spss = new SystemSuitesPage(Page);
            var spworkflow = new GlobalParametersWorkflow(Page);
            var spssworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(spss);
            await spssworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(spss);
            await spworkflow.OpenGlobalParametersPageAsync();
            await GlobalParametersAssertions.VerifyGlobalParametersPage(edge);
            await GlobalParametersAssertions.VerifyAVEVAEdgeFields(edge);
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
            var spss = new SystemSuitesPage(Page);
            var spworkflow = new GlobalParametersWorkflow(Page);
            var spssworkflow = new SystemSuitesWorkflow(Page);

            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(spss);
            await spssworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(spss);
            await spworkflow.OpenGlobalParametersPageAsync();
            await GlobalParametersAssertions.VerifyGlobalParametersPage(plantscada);
            await GlobalParametersAssertions.VerifyAVEVAPlantSCADAFields(plantscada);
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
            var spss = new SystemSuitesPage(Page);
            var spworkflow = new GlobalParametersWorkflow(Page);
            var spssworkflow = new SystemSuitesWorkflow(Page);
            await SystemSuitesAssertions.VerifySystemSuitesOptionFromLHSMenu(spss);
            await spssworkflow.OpenSystemSuiteSubMenuAsync();
            await SystemSuitesAssertions.VerifySystemSuitesSubMenu(spss);
            await spworkflow.OpenGlobalParametersPageAsync();
            await GlobalParametersAssertions.VerifyGlobalParametersPage(button);
            await GlobalParametersAssertions.VerfifyCancelSaveButtons(button);
            await button.Buttons.ScreenshotAsync(new()
            {
                Path = "Screenshot_Of_CancelSaveButtons_ForAdmins.png"
            });
        }
    }
}
