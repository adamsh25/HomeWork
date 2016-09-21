using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AcXmlParser
{
    public abstract class XmlParseAttribute : Attribute, IXmlParseAttribute
    {
        protected abstract void SetValue<T>(T instance, XmlNode xmlElement, PropertyInfo clsProp);
        
        public void SetValueByAttribute<T>(T instance, XmlNode xmlElement, PropertyInfo clsProp)
        {
            if (this.isValid(instance, xmlElement, clsProp))
            {
                this.SetValue<T>(instance, xmlElement, clsProp);
            }
        }

        protected virtual bool isValid<T>(T instance, XmlNode xmlElement, PropertyInfo clsProp)
        {
            bool isValid = false;

            if (instance != null && xmlElement != null && clsProp != null)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
