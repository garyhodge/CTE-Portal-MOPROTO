using System;
using System.Reflection;
using System.Web.Mvc;

namespace Appius.Utility.Atrtibutes
{
    public class ActionAttribute : ActionNameSelectorAttribute
    {
        public string Name { get; set; }

        public override bool IsValidName(ControllerContext controllerContext, string ActionName, MethodInfo Info)
        {
            var value = controllerContext.Controller.ValueProvider.GetValue(Name);

            if (value != null)
            {
                return true;
            }
            return false;

        }
    }
}
