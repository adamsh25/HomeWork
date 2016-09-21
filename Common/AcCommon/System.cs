using AcXmlParser;
using GoogleSearcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcCommon
{
    public class System
    {
        [ParseField(NodePathName = "EventID")]
        public int EventID { get; set; }

        [ParseField(NodePathName = "Computer")]
        public string Computer { get; set; }

        [ParseField(NodePathName = "Security")]
        public string Security { get; set; }

        [ParseAtrField(NodePath = "Provider", AttrPath = "Name")]
        public string Provider { get; set; }

    }
}
