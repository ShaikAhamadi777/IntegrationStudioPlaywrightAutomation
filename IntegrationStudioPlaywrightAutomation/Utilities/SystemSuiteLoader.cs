using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using IntegrationStudioPlaywrightAutomation.Utilities.Models;

namespace IntegrationStudioPlaywrightAutomation.Utilities
{
    public static class SystemSuiteLoader
    {
        public static SystemSuite Load(string suiteFileName)
        {
            var path = Path.Combine(AppContext.BaseDirectory, "TestData","SystemSuites", suiteFileName);
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<SystemSuite>(json);
        }
    }
}
