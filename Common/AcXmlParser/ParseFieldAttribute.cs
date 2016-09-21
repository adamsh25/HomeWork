using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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

                string value = xmlElement[this.NodePathName].InnerText;
                clsProp.SetValue(instance, Convert.ChangeType(value, clsProp.PropertyType), null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
