using System.Collections.Generic;

namespace WebApi.ViewModels.Errors
{
    public class ValidationExceptionViewModel
    {
        public string Title { get; set; }
        public IDictionary<string, IEnumerable<string>> Errors { get; set; }
        public IList<string> Mensagens { get; set; } = new List<string>();

        protected ValidationExceptionViewModel()
        {
            Errors = new Dictionary<string, IEnumerable<string>>();
        }

        public ValidationExceptionViewModel(string title, IDictionary<string, IEnumerable<string>> errors, IList<string> mensagens)
        {
            Title = title;
            Errors = errors;
            Mensagens = mensagens;
        }
    }
}