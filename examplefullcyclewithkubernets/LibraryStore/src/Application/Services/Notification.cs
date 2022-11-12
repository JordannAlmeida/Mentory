namespace Application.Services
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// </summary>
    public sealed class Notification
    {
        /// <summary>
        ///     Error message.
        /// </summary>
        private readonly IDictionary<string, IList<string>> _errorMessagesDetails = new Dictionary<string, IList<string>>();

        public IDictionary<string, string[]> ModelState
        {
            get
            {
                Dictionary<string, string[]> modelState = _errorMessagesDetails
                    .ToDictionary(item => item.Key, item => item.Value.ToArray());

                return modelState;
            }
        }

        private readonly IList<string> _errorMessages = new List<string>();

        public List<string> Errors
        {
            get
            {
                List<string> errors = this._errorMessages.ToList();

                return errors;
            }
        }

        /// <summary>
        ///     Returns true when it does not contains error messages.
        /// </summary>
        public bool IsValid => _errorMessagesDetails.Count == 0;

        public bool IsInvalid => _errorMessagesDetails.Count > 0;

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="message"></param>
        public void Add(string key, string message)
        {
            if (!_errorMessagesDetails.ContainsKey(key))
                _errorMessagesDetails[key] = new List<string>();

            _errorMessagesDetails[key].Add(message);
            _errorMessages.Add($"{key} - {message}");
        }

        public Notification()
        {
        }
    }
}