using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Modules.Common
{
    public static class ExceptionExtensions
    {
        public static IEnumerable<string> GetFullInnerException(this Exception exception)
        {
            var messages = new List<string>() { exception.Message };
            var ex = exception;
            while (ex != null)
            {
                messages.Add(ex.Message);
                ex = ex.InnerException;
            }
            return messages
                .Distinct()
                .ToList();
        }

        public static IEnumerable<string> ToFormatedStackTrace(this Exception exception)
        {
            var stackTrace = exception.StackTrace;
            var messages = new List<string>();
            if (!string.IsNullOrEmpty(stackTrace))
            {
                messages = stackTrace
                .Replace("\r\n", "")
                .Split("   ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            }
            return messages;
        }
    }
}