using System;
using System.Reflection;
using System.Xml;

namespace AcXmlParser
{
    public abstract class XmlParseAttribute : Attribute, IXmlParseAttribute
    {
        protected abstract void SetValue<T>(T instance, XmlNode xmlElement, PropertyInfo clsProp);
        
        public void SetValueByAttribute<T>(T instance, XmlNode xmlElement, PropertyInfo clsProp)
        {
            if (isValid(instance, xmlElement, clsProp))
            {
                SetValue(instance, xmlElement, clsProp);
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
