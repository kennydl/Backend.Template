using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace Backend.Template.Core.Exceptions
{
    public class DefaultException : Exception
    {
        public virtual int StatusCode { get; set; } = StatusCodes.Status500InternalServerError;
        public string NameSpace { get; set; }
        public string Caller { get; set; }
        public int? Line { get; set; }
        public string ExceptionMessage { get; set; }
    
        public DefaultException(
            string message,
            [CallerLineNumber] int? sourceLine = null,
            [CallerMemberName] string caller = null,
            [CallerFilePath] string path = null
        ) : base(message)
        {
            SetCallerValues(path, sourceLine, caller);
        }
        
        public DefaultException(
            string message,
            Exception exception,
            [CallerLineNumber] int? sourceLine = null,
            [CallerMemberName] string caller = null,
            [CallerFilePath] string path = null
        ) : base(message, exception)
        {
            SetCallerValues(path, sourceLine, caller);
            ExceptionMessage = exception.Message;
        }
        
        private void SetCallerValues(string path, int? sourceLine, string caller)
        {
            const string baseName = "Bstilt";
            var nameSpace = path == null ? null : 
                Regex.Match(path, @$"{baseName}\..*")
                    .Value
                    .Replace("/", ".")
                    .Replace(".cs", "");
    
            Line = sourceLine;
            Caller = caller;
            NameSpace = string.IsNullOrEmpty(nameSpace) ? null : nameSpace;
        }
    }
}
