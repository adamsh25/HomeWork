namespace GoogleSearcher
{
    public class GoogleData : IGotGoogleData, ISearchWithGoogle
    {
        public string TextToSearch { get; set; }

        public string GoogleDataValue { get; set; }

        public GoogleData()
        {

        }

        public GoogleData(string textToSearch, string googleDataValue = null)
        {
            TextToSearch = textToSearch;
            GoogleDataValue = googleDataValue;
        }


        public override string ToString()
        {
            return string.Format("Google Text To Search: {0}, Google Answer: {1}", TextToSearch, GoogleDataValue);
        }

        public override bool Equals(object obj)
        {
            var googleData = (obj as GoogleData);
            var areEquals = googleData != null && googleData.TextToSearch.Equals(TextToSearch);
            return (areEquals);
        }

        public override int GetHashCode()
        {
            return TextToSearch.GetHashCode();
        }
    }
}
