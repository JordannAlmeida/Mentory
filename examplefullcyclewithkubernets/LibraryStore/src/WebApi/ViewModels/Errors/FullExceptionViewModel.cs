using System.Collections.Generic;

namespace WebApi.ViewModels.Errors
{
    public class FullExceptionViewModel : ExceptionViewModel
    {
        public IEnumerable<string> InnerMessage { get; set; }

        public IEnumerable<string> StackTrace { get; set; }

        public FullExceptionViewModel(string message) : base(message)
        {
            StackTrace = new List<string>();
        }

        public FullExceptionViewModel(string message, IEnumerable<string> innerMessage) : this(message)
        {
            InnerMessage = innerMessage;
        }

        public FullExceptionViewModel(string message, IEnumerable<string> innerMessage, IEnumerable<string> stackTrace) : this(message)
        {
            InnerMessage = innerMessage;
            StackTrace = stackTrace;
        }
    }
}