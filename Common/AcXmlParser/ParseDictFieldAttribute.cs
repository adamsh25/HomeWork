using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace AcXmlParser
{
    public class ParseDictFieldAttribute : XmlParseAttribute
    {
        public string NodePath { get; set; }
        public string KeyPath { get; set; }

        protected override void SetValue<T>(T instance, XmlNode xmlElement, PropertyInfo clsProp)
        {
            try
            {
                if (instance != null && xmlElement != null && clsProp != null)
                {
                    var dicNode = xmlElement.SelectNodes(String.Format("*[name() = '{0}']", this.NodePath));
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    for (int i = 0; i <= dicNode.Count - 1; i++)
                    {
                        var current = dicNode[i];
                        string key = current.Attributes[this.KeyPath].Value;
                        dict[key] = current.InnerText;

                    }
                    clsProp.SetValue(instance, dict, null);
                }
            }
            catch (XPathException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
