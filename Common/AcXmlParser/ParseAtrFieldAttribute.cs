using System;
using System.Reflection;
using System.Xml;

namespace AcXmlParser
{
    public class ParseAtrFieldAttribute : XmlParseAttribute
    {
        public string AttrPath { get; set; }
        public string NodePath { get; set; }

        protected override void SetValue<T>(T instance, XmlNode xmlElement, PropertyInfo clsProp)
        {
            try
            {

                string value = xmlElement[NodePath].GetAttribute(AttrPath);
                clsProp.SetValue(instance, Convert.ChangeType(value, clsProp.PropertyType), null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
