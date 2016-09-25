﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleSearcher
{
    public static class GoogleSearcher
    {
        public static EventWaitHandle ResetEventHandler = new ManualResetEvent(false);

        public static bool IsAPISupported { get; set; }

        public static event EventHandler<GoogleAPINotSupportedEventArgs> OnGoogleAPIIsNotSupportedAnymore;

        public static string GetBestGoogleAnswer(ISearchWithGoogle itemForSearch)
        {
            string result = "Error Getting Answer";

            try
            {
                if (!GoogleSearcher.IsAPISupported)
                {
                    GoogleSearcher.ResetEventHandler.WaitOne();
                    Console.WriteLine("Wait For API To Be Supported Again...");
                }

                Console.WriteLine("Getting Google Answer For {0}", itemForSearch.TextToSearch);
                HtmlWeb htmlWeb = new HtmlWeb();
                HtmlDocument document = htmlWeb.Load(GoogleSearcher.GetGoogleSearcherURL(itemForSearch.TextToSearch));

                try
                {
                    result = document.DocumentNode.SelectSingleNode("//*[@id=\"search\"]").Descendants("a").ToList()[0].InnerText;
                    if (result.Length % 2 == 0)
                    {
                        throw new Exception("A Test For The Manual Reset Event Job");
                    }
                }
                catch (Exception e)
                {
                    GoogleSearcher.IsAPISupported = false;
                    GoogleSearcher.OnGoogleAPIIsNotSupportedAnymore(itemForSearch, new GoogleAPINotSupportedEventArgs(e.Message, DateTime.Now));
                }
                Console.WriteLine("Got Google Answer For {0}. Answer: {1}.", itemForSearch.TextToSearch, result);

            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Error in GetBestGoogleAnswer, e:{0}", e.Message));
            }

            return result;
        }

        public static string GetGoogleSearcherURL(string searchText){
            return string.Format(GoogleConsts.GOOGLE_SEARCHER_API, searchText);
        }
    }
}
