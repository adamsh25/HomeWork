using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleSearcher
{
    public class GoogleAPINotSupportedEventArgs : EventArgs
    {
        public string ErrorMessage { get; set; }

        public DateTime DateReported { get; set; }

        public GoogleAPINotSupportedEventArgs(string errorMessage, DateTime dateReported)
        {
            this.ErrorMessage = errorMessage;
            this.DateReported = dateReported;
        }
    }
}
