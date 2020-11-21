using System.Text;
using System.Text.Json;
using Backend.Template.Core.Exceptions;

namespace Backend.Template.Infrastructure.Utilities
{
    public static class TextJsonSerializer
    {
        public static readonly JsonSerializerOptions Options = new JsonSerializerOptions()
        {
            WriteIndented = true,
            IgnoreNullValues = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            AllowTrailingCommas = false
        };

        public static string Serialize(object o)
        {
            return JsonSerializer.Serialize(o, Options);
        }

        public static T Deserialize<T>(string o)
        {
            return JsonSerializer.Deserialize<T>(o, Options) 
                   ?? throw new DefaultException(
                       $"Could not deserialize to type {typeof(T)}." +
                       $"The object is: {o}"
                    );
        }

        public static string SerializeWithBytes(object o)
        {
            var buffer = JsonSerializer.SerializeToUtf8Bytes(o, Options);
            return Encoding.UTF8.GetString(buffer, 0, buffer.Length);
        }
    }
}
