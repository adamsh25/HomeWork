using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTestExamAdamCheriki
{

    [ParseClass(NodeName="Event")]
    public class Event
    {
        [ParseClass(NodeName = "System")]
        public System System { get; set; }

        [ParseClass(NodeName = "EventData")]
        public EventData Data { get; set; }

        public override string ToString()
        {
            return this.System.EventID.ToString();
        }
    }
}
