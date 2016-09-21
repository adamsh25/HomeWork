using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleSearcher
{
    public static class GoogleFetcher
    {
        /// <summary>
        /// This Method Will Search In Google, The Best Result Using The Search Text Provided In The 
        /// ISearchWithGoogle Items, And Will Store The Result Inside The GoogleData Objects.
        /// </summary>
        /// <param name="itemsForSearch">The Items That Has The Option To Be Searched By Google</param>
        /// <returns>The GoogleData Object List Fetched With The Best Result<</returns>
        public static IEnumerable<GoogleData> GetGoogleDataList(IEnumerable<ISearchWithGoogle> itemsForSearch)
        {
            List<GoogleData> googleDataList = new List<GoogleData>();
            foreach (var itemForSearch in itemsForSearch)
            {
                // Here I will use Threading to get all the google data for all the items.
                GoogleData googleData = GoogleFetcher.GetGoogleData(itemForSearch);
                googleDataList.Add(googleData);
            }
            return googleDataList;
        }

        /// <summary>
        /// This Method Will Search In Google, The Best Result Using The Search Text Provided In The 
        /// ISearchWithGoogle Item, And Will Store The Result Inside The GoogleData Object.
        /// </summary>
        /// <param name="itemForSearch">The Item That Has The Option To Be Searched By Google</param>
        /// <returns>The GoogleData Object Fetched With The Best Result</returns>
        public static GoogleData GetGoogleData(ISearchWithGoogle itemForSearch)
        {
            GoogleData googleData = new GoogleData(itemForSearch.TextToSearch);
            // All the business logic to get google data from google will be written here.
            googleData.GoogleDataValue = "Best Result From Google";
            return googleData;
        }
    }
}
