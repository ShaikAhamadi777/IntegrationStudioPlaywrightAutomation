using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationStudioPlaywrightAutomation.Utilities.Models
{
    public class SystemSuite
    {
        public List<NodeDefinition> roles { get; set; }
    }

    public class NodeDefinition
    {
        public string nodeType { get; set; }
        public List<LaunchParameter> launchParameters { get; set; }
    }

    public class LaunchParameter
    {
        public string name { get; set; }
        public bool defaultValue { get; set; }
    }
}
