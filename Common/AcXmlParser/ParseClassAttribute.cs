using System;
using System.Reflection;
using System.Xml;

namespace AcXmlParser
{
    public class ParseClassAttribute : XmlParseAttribute
    {
        public string NodeName { get; set; }

        protected override void SetValue<T>(T instance, XmlNode xmlElement, PropertyInfo clsProp)
        {
            try
            {
                object innerInstance = Activator.CreateInstance(clsProp.PropertyType);
                var innerNode = xmlElement[NodeName];
                innerInstance = Parser.ParseClass(innerNode, innerInstance);
                clsProp.SetValue(instance, innerInstance, null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
