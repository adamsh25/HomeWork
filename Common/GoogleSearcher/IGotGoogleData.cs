namespace GoogleSearcher
{
    public interface IGotGoogleData : ISearchWithGoogle
    {
        string GoogleDataValue { get; set; }
    }
}
