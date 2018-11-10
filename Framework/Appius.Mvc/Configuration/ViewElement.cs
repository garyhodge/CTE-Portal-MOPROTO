using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiusMVC.ViewConfiguration
{
    public class ViewElement : ConfigurationElement
    {
        public ViewElement() { }

        [ConfigurationProperty("name", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("path", DefaultValue = "", IsRequired = true)]
        public string SourcePath
        {
            get { return (string)this["path"]; }
            set { this["path"] = value; }
        }
    }
}