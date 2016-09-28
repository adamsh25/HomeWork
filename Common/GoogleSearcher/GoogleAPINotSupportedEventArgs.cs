using System;

namespace GoogleSearcher
{
    public class GoogleAPINotSupportedEventArgs : EventArgs
    {
        public string ErrorMessage { get; set; }

        public DateTime DateReported { get; set; }

        public GoogleAPINotSupportedEventArgs(string errorMessage, DateTime dateReported)
        {
            ErrorMessage = errorMessage;
            DateReported = dateReported;
        }
    }
}
