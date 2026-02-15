using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationStudioPlaywrightAutomation.Locators;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;



namespace IntegrationStudioPlaywrightAutomation.Assertions
{
    public static class GlobalParametersAssertions
    {
        public static async Task VerifyGlobalParametersPage(GlobalParametersPage page)
        {
            await page.GlobalParameterPage.WaitForAsync();
            await Expect(page.GlobalParameterPage).ToBeVisibleAsync();
            await Expect(page.GlobalParametersToolBar).ToBeVisibleAsync();
            await Expect(page.GlobalParameterTitle).ToBeVisibleAsync();
            await Expect(page.GlobalParameterSubTitle).ToBeVisibleAsync();
        }
        public static async Task VerifyAVEVASystemPlatformFields(GlobalParametersPage page)
        {

            //Check for the AVEVA System platform heading and text fields
            await page.SPFamilyGroupHeading.WaitForAsync();
            await Expect(page.SPFamilyGroupHeading).ToBeVisibleAsync();
            await Expect(page.SPUsernameField).ToBeVisibleAsync();
            await Expect(page.SPPasswordFiled).ToBeVisibleAsync();

            //Check if the AVEVA System Platform fields are editable
            await Expect(page.SPUsernameField).ToBeEditableAsync();
            await Expect(page.SPPasswordFiled).ToBeEditableAsync();

            //Check the Eye icon
            await Expect(page.EyeIcon).ToBeVisibleAsync();
            await Expect(page.EyeIcon).ToBeEnabledAsync();

            //Check if the fields are not empty
            await Expect(page.SPUsernameField).Not.ToBeEmptyAsync();
            await Expect(page.SPPasswordFiled).Not.ToBeEmptyAsync();

        }
        public static async Task VerifyAVEVAEdgeFields(GlobalParametersPage page)
        {
            await page.EdgeFamilyGroupHeading.WaitForAsync();
            await Expect(page.EdgeFamilyGroupHeading).ToBeVisibleAsync();
            await Expect(page.EdgeValue.First).ToBeVisibleAsync();
        }
        public static async Task VerifyAVEVAPlantSCADAFields(GlobalParametersPage page)
        {
            await page.PlantSCADAGroupHeading.WaitForAsync();
            await Expect(page.PlantSCADAGroupHeading).ToBeVisibleAsync();
            await Expect(page.PlantSCADAValue.Last).ToBeVisibleAsync();
        }
        public static async Task VerfifyCancelSaveButtons(GlobalParametersPage page)
        {

            //Check for the Save and the Cancel button
            await Expect(page.GPCancelButton).ToBeVisibleAsync();
            await Expect(page.GPCancelButton).ToBeEnabledAsync();

            await Expect(page.GPSaveButton).ToBeVisibleAsync();
            await Expect(page.GPSaveButton).ToBeEnabledAsync();
        }

    }
}
