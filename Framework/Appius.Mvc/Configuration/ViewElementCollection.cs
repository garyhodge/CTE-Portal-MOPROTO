using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiusMVC.ViewConfiguration
{
    [ConfigurationCollection(typeof(ViewElement))]
    public class ViewElementCollection : ConfigurationElementCollection
    {
        public ViewElement this[int index]
        {
            get { return (ViewElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);

                BaseAdd(index, value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ViewElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ViewElement)element).Name;
        }
    }
}