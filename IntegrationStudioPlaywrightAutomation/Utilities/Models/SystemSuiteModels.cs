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
        public List<LaunchParameter> parameters { get; set; }
    }

    public class LaunchParameter
    {
        public string name { get; set; }
        public string label { get; set; }    
        public string @default { get; set; }
        public string userDefined { get; set; }
        public string parameterType { get; set; }
        public string description { get; set; }
        public string value { get; set; }

    }
}
