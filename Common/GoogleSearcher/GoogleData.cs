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

        public override string ToString()
        {
            return string.Format("Google Text To Search: {0}, Google Answer: {1}", this.TextToSearch, this.GoogleDataValue);
        }

        public override bool Equals(object obj)
        {
            return (obj as GoogleData).TextToSearch.Equals(this.TextToSearch);
        }

        public override int GetHashCode()
        {
            return this.TextToSearch.GetHashCode();
        }
    }
}
