using WebApi.Modules.Common;

namespace WebApi.ViewModels.Errors
{
    public class ExceptionViewModel
    {
        public string Message { get; set; }

        public ExceptionViewModel(string message)
        {
            Message = message;
        }

        public override string ToString()
        {
            return this.AsJson();
        }
    }
}