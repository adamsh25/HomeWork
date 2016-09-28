using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace AcXmlParser
{
    public static class Parser
    {
        public static IEnumerable<T> Parse<T>(FileInfo xmlFile)
        {
            List<T> clsList = new List<T>();
            StreamReader sr = xmlFile.OpenText();
            XmlDataDocument xmldoc = new XmlDataDocument();
            xmldoc.Load(sr);

            ParseClassAttribute clsAttribute = typeof(T).GetCustomAttribute<ParseClassAttribute>();

            XmlNodeList xmlNodeList = xmldoc.GetElementsByTagName(clsAttribute.NodeName);
            foreach (XmlNode node in xmlNodeList)
            {
                T instance = Activator.CreateInstance<T>();
                instance = ParseClass(node, instance);
                clsList.Add(instance);
            }
            return clsList;
        }

        public static T ParseClass<T>(XmlNode xmlElement, T instance)
        {
            PropertyInfo[] clsProps = instance.GetType().GetProperties();

            foreach (var clsProp in clsProps)
            {
                IXmlParseAttribute xmlAttribute = clsProp
                    .GetCustomAttributes()
                    .SingleOrDefault(a=> a is IXmlParseAttribute) as IXmlParseAttribute;
                if (xmlAttribute != null)
                {
                    xmlAttribute.SetValueByAttribute(instance, xmlElement, clsProp);
                }
            }

            return instance;
        }
    }
}
