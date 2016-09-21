using AcXmlParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcCommon
{

    [ParseClass(NodeName="EventData")]
    public class EventData
    {
        [ParseDictField(NodePath = "Data", KeyPath="Name")]
        public Dictionary<string, string> Data { get; set; }
    }
}
