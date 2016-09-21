using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleSearcher
{
    public class GoogleData : IGotGoogleData, ISearchWithGoogle
    {
        public string TextToSearch { get; set; }

        public string GoogleDataValue { get; set; }

        public GoogleData()
        {

        }

        public GoogleData(string textToSearch, string googleDataValue=null)
        {
            this.TextToSearch = textToSearch;
            this.GoogleDataValue = googleDataValue;
        }
    }
}
