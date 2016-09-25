using AcBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTestExamAdamCheriki
{
    class Program
    {
        static void Main(string[] args)
        {
            GoogleSearcher.GoogleSearcher.IsAPISupported = true;
            GoogleSearcher.GoogleSearcher.OnGoogleAPIIsNotSupportedAnymore += OnGoogleAPIIsNotSupportedAnymore;
            DataBL.Process();
            Console.Read();
        }

        static void OnGoogleAPIIsNotSupportedAnymore(object sender, GoogleSearcher.GoogleAPINotSupportedEventArgs e)
        {
            Console.WriteLine("Send Error By Email, e:{0}, date:{1}", e.ErrorMessage, e.DateReported.ToLongTimeString());
            Console.WriteLine("Save Error To Mongo DB For Future Analysis, e:{0}, date:{1}", e.ErrorMessage, e.DateReported.ToLongTimeString());
            Console.WriteLine("Please Type \"Continue\" If The Issue Was Fixed");
            string response = Console.ReadLine();
            if (response == "Continue")
            {
                GoogleSearcher.GoogleSearcher.IsAPISupported = true;
                GoogleSearcher.GoogleSearcher.ResetEventHandler.Set();
            }

        }
    }
}
