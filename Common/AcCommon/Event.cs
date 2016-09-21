using AcXmlParser;
using GoogleSearcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcCommon
{

    [ParseClass(NodeName = "Event")]
    public class Event : ISearchWithGoogle, IGotGoogleData
    {
        [ParseClass(NodeName = "System")]
        public System System { get; set; }

        [ParseClass(NodeName = "EventData")]
        public EventData Data { get; set; }

        public override string ToString()
        {
            return this.System.EventID.ToString();
        }

        public string TextToSearch
        {
            get
            {
                return this.System.EventID.ToString();
            }
            set { }
        }

        public string GoogleDataValue
        {
            get;
            set;
        }
    }
}
