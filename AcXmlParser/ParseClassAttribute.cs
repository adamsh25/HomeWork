using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
                var innerNode = xmlElement[this.NodeName];
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
