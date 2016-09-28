using System;
using System.Reflection;
using System.Xml;

namespace AcXmlParser
{
    public class ParseFieldAttribute : XmlParseAttribute
    {
        public string NodePathName { get; set; }

        protected override void SetValue<T>(T instance, XmlNode xmlElement, PropertyInfo clsProp)
        {
            try
            {

                string value = xmlElement[NodePathName].InnerText;
                clsProp.SetValue(instance, Convert.ChangeType(value, clsProp.PropertyType), null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
