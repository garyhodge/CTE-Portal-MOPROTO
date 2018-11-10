using System.Web.Mvc;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

using AppiusMVC.ViewConfiguration;

namespace AppiusMVC
{
    public class AppiusViewEngine : RazorViewEngine
    {
        /// <summary>
        /// add additional locations to the current view engine
        /// </summary>
        public AppiusViewEngine()
        {
            ViewLocationFormats = AppiusViewEngineConfiguration.Views;
            MasterLocationFormats = AppiusViewEngineConfiguration.Master;
            PartialViewLocationFormats = AppiusViewEngineConfiguration.Partial;
        }
    }
}
