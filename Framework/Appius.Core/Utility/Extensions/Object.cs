using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;

namespace Appius.Core.Utility.Extensions
{

    public static class ObjectExtensions
    {
        public static ExpandoObject ToExpando(this object AnonymousObject)
        {
            IDictionary<string, object> Expando = new ExpandoObject();

            foreach (PropertyDescriptor PropertyDescriptor in TypeDescriptor.GetProperties(AnonymousObject))
            {
                var obj = PropertyDescriptor.GetValue(AnonymousObject);
                Expando.Add(PropertyDescriptor.Name, obj);
            }

            return (ExpandoObject)Expando;
        }
    }
}
