using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationStudioPlaywrightAutomation.Tests
{
    [SetUpFixture]
    public class TestSetUp
    {
        [OneTimeSetUp]
        public void CheckAuthFile()
        {
            if (!File.Exists("auth.json"))
            {
                throw new Exception("auth.json missing. Run Authentication.cs first.");
            }
        }
    }
}

