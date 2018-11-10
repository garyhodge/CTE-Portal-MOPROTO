using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiusMVC.ViewConfiguration
{
    public class AppiusViewEngineConfiguration
    {
        public static AppiusViewConfigurationSection ViewConfiguraton = ConfigurationManager.GetSection("AppiusViewEngine") as AppiusViewConfigurationSection;

        public static string[] Views
        {
            get
            {
                List<string> Views = new List<string>();

                foreach (ViewElement item in ViewConfiguraton.Views)
                {
                    Views.Add(item.SourcePath);
                }

                return Views.ToArray();
            }
        }

        public static string[] Master
        {
            get
            {
                List<string> Views = new List<string>();

                foreach (ViewElement item in ViewConfiguraton.Master)
                {
                    Views.Add(item.SourcePath);
                }

                return Views.ToArray();
            }
        }

        public static string[] Partial
        {
            get
            {
                List<string> Views = new List<string>();

                foreach (ViewElement item in ViewConfiguraton.Partial)
                {
                    Views.Add(item.SourcePath);
                }

                return Views.ToArray();
            }
        }
    }
}