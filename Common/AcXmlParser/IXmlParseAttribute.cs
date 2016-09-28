using System.Reflection;
using System.Xml;

namespace AcXmlParser
{
    public interface IXmlParseAttribute
    {
        void SetValueByAttribute<T>(T instance, XmlNode xmlElement, PropertyInfo clsProp);
    }
}
