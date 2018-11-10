using System;
using System.Linq;

namespace Appius.Core.Utility.Extensions
{
    public static class EnumExtensions
    {
        public static T GetAttributeOfEnumValue<T>(this object enumVal) where T : System.Attribute
        {
            T enumAttribute = null;

            var type = enumVal.GetType();

            var memInfo = type.GetMember(enumVal.ToString());

            if (memInfo == null || !memInfo.Any())
            {
                return null;
            }

            var attributes = memInfo.FirstOrDefault().GetCustomAttributes(typeof(T), false);

            if (attributes != null)
            {
                enumAttribute = attributes.EmptyIfNull().Any() ? (T)attributes.FirstOrDefault() : null;
            }

            return enumAttribute;
        }
    }
}