using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CTestExamAdamCheriki
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
            PropertyInfo[] clsProps = typeof(T).GetProperties();

            XmlNodeList xmlNodeList = xmldoc.GetElementsByTagName(clsAttribute.NodeName);
            foreach (XmlNode node in xmlNodeList)
            {
                T instance = (T)Activator.CreateInstance<T>();
                instance = (T)ParseClass<T>(node, instance);
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
                    xmlAttribute.SetValueByAttribute<T>(instance, xmlElement, clsProp);
                }
            }

            return instance;
        }
    }
}
