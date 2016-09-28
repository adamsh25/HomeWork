using System.Collections.Generic;
using AcXmlParser;

namespace AcCommon
{

    [ParseClass(NodeName="EventData")]
    public class EventData
    {
        [ParseDictField(NodePath = "Data", KeyPath="Name")]
        public Dictionary<string, string> Data { get; set; }
    }
}
