using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CTestExamAdamCheriki
{
    public interface IXmlParseAttribute
    {
        void SetValueByAttribute<T>(T instance, XmlNode xmlElement, PropertyInfo clsProp);
        bool isValid<T>(T instance, XmlNode xmlElement, PropertyInfo clsProp);
    }
}
