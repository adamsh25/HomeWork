using AcXmlParser;
using GoogleSearcher;

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
            return System.EventID.ToString();
        }

        public string TextToSearch
        {
            get
            {
                return System.EventID.ToString();
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
