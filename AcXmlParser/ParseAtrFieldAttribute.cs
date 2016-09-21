using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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

                string value = xmlElement[this.NodePath].GetAttribute(this.AttrPath);
                clsProp.SetValue(instance, Convert.ChangeType(value, clsProp.PropertyType), null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
