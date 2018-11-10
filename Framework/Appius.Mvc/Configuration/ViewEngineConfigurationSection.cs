using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiusMVC.ViewConfiguration
{
    public class AppiusViewConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("Views")]
        public ViewElementCollection Views
        {
            get { return (ViewElementCollection)this["Views"]; }
        }

        [ConfigurationProperty("Master")]
        public ViewElementCollection Master
        {
            get { return (ViewElementCollection)this["Master"]; }
        }

        [ConfigurationProperty("Partial")]
        public ViewElementCollection Partial
        {
            get { return (ViewElementCollection)this["Master"]; }
        }
    }
}