using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationStudioPlaywrightAutomation.Utilities;


namespace IntegrationStudioPlaywrightAutomation.Utilities
{
    public class AuthStateRunner
    {
        [Test]
        [Explicit]
        public async Task Generate_All_Auth_States()
        {
            await AuthenticationSetUp.GenerateAuthState(
                                                          "SystemAdmin",
                                                          "SystemAdmin_Authentication_Email",
                                                          "SystemAdmin_Authentication_Password",
                                                          "TenantName",
                                                          "auth-systemadmin.json");
            await AuthenticationSetUp.GenerateAuthState(
                                                          "ExternalAdmin",
                                                          "ExternalAdmin_Authentication_Email",
                                                          "ExternalAdmin_Authentication_Password",
                                                          "TenantName",
                                                          "auth-externaladmin.json");

            await AuthenticationSetUp.GenerateAuthState(
                                                          "ProjectUser",
                                                          "ProjectUser_Authentication_Email",
                                                          "ProjectUser_Authentication_Password",
                                                          "TenantName",
                                                          "auth-projectuser.json");
        }
    }
}
