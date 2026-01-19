using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IntegrationStudioPlaywrightAutomation
{
    public static class RoleHelper
    {
        public static bool IsSystemAdmin()
        => HasRole("SystemAdmin");

        public static bool IsProjectUser()
            => HasRole("ProjectUser");

        public static bool IsExternalAdmin()
            => HasRole("ExternalAdmin");

        private static bool HasRole(string role)
        {
            var categories = TestContext.CurrentContext.Test.Properties["Category"] as IList;

            return categories != null && categories.Contains(role);
        }
    }
}
