using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GoogleSearcher
{
    public static class GoogleFetcher
    {
        /// <summary>
        /// This Method Will Search In Google, The Best Result Using The Search Text Provided In The 
        /// ISearchWithGoogle Items, And Will Store The Result Inside The GoogleData Objects.
        /// </summary>
        /// <param name="itemsForSearch">The Items That Has The Option To Be Searched By Google</param>
        /// <returns>The GoogleData Object List Fetched With The Best Result</returns>
        public static IEnumerable<GoogleData> GetGoogleDataList(IEnumerable<ISearchWithGoogle> itemsForSearch)
        {
            List<GoogleData> googleDataList = new List<GoogleData>();
            var dicOfItemsToSearch = itemsForSearch.GroupBy(t => t.TextToSearch);
            GoogleSearcher.OnGoogleAPIIsNotSupportedAnymore += OnGoogleAPIIsNotSupportedAnymore;
            foreach (var itemForSearch in dicOfItemsToSearch)
            {
                // Here I will use Threading to get all the Google data for all the items.
                GoogleData googleData = GetGoogleData(itemForSearch.Key);
                googleDataList.Add(googleData);
            }
            return googleDataList;
        }

        private static void OnGoogleAPIIsNotSupportedAnymore(object sender, GoogleAPINotSupportedEventArgs e)
        {
            if (!GoogleSearcher.IsAPISupported)
            {
                Console.WriteLine("Wait For API To Be Fixed Automatically...");
            }
        }

        /// <summary>
        /// This Method Will Search In Google The Best Result Using The Search Text Provided In The 
        /// ISearchWithGoogle Item, And Will Store The Result Inside The GoogleData Object.
        /// </summary>
        /// <param name="itemForSearch">The Item That Has The Option To Be Searched By Google</param>
        /// <returns>The GoogleData Object Fetched With The Best Result</returns>
        public static GoogleData GetGoogleData(string searchText)
        {
            GoogleData googleData = new GoogleData(searchText);
            Thread t = new Thread(() => { googleData.GoogleDataValue = GoogleSearcher.GetBestGoogleAnswer(googleData); });
            t.Start();
            t.Join();
            return googleData;
        }

    }
}
