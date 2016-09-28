using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AcCommon;
using AcDAL;
using AcXmlParser;
using GoogleSearcher;

namespace AcBL
{
    public static class DataBL
    {
        /// <summary>
        /// Save Events In MongoDB
        /// </summary>
        /// <param name="eventsToSave"></param>
        public static void SaveEvents(IEnumerable<Event> eventsToSave)
        {

        }


        /// <summary>
        /// Save Google Data In MongoDB
        /// </summary>
        /// <param name="googleDataToSave"></param>
        public static void SaveGoogleData(IEnumerable<GoogleData> googleDataToSave)
        {
            var mongoDB = new AcMongoDAL();
            mongoDB.saveGoogleDocuments(googleDataToSave);
        }

        /// <summary>
        /// Fetch itemsToFetch with googleData results.
        /// </summary>
        /// <param name="itemsToFetch"></param>
        /// <param name="googleData"></param>
        public static void FetchObjectsWithGoogleData<T>(ref IEnumerable<T> itemsToFetch, IEnumerable<GoogleData> googleData) where T : IGotGoogleData
        {
            foreach (var data in googleData)
            {
                foreach(var itemToFetch in itemsToFetch.AsQueryable().Where(t=>t.TextToSearch == data.TextToSearch))
                {
                    itemToFetch.GoogleDataValue = data.GoogleDataValue;
                }
            }
        }


        public static IEnumerable<GoogleData> GetGoogleData(IEnumerable<ISearchWithGoogle> itemsToSearch)
        {
            IEnumerable<GoogleData> googleData = GoogleFetcher.GetGoogleDataList(itemsToSearch);
            return googleData;
        }

        public static void ProcessEvents(IEnumerable<Event> events)
        {
            SaveEvents(events);
            var googleData = GetGoogleData(events);
            SaveGoogleData(googleData);
            FetchObjectsWithGoogleData(ref events, googleData);
            events.ToList().ForEach(e => Console.WriteLine("Event: {0}, Google Data: {1} \n", e.ToString(), e.GoogleDataValue));

        }

        public static void Process()
        {
            FileInfo f = new FileInfo(@"d:\jav_logs.xml");
            var events = Parser.Parse<Event>(f);
            ProcessEvents(events);
        }
    }
}
