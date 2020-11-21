using Backend.Template.Api.Converters;
using Backend.Template.Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Template.Api.Extensions
{
    public static class MvcBuilderJson
    {
        public static IMvcBuilder IncludeJsonOptions(this IMvcBuilder builder)
        {
            return builder.AddJsonOptions(SetJsonOptions);
        }
        
        private static void SetJsonOptions(JsonOptions options)
        {
            var apiJsonOptions = TextJsonSerializer.Options;
            var jsonOptions = options.JsonSerializerOptions;
            jsonOptions.PropertyNameCaseInsensitive = apiJsonOptions.PropertyNameCaseInsensitive;
            jsonOptions.PropertyNamingPolicy = apiJsonOptions.PropertyNamingPolicy;
            jsonOptions.WriteIndented = apiJsonOptions.WriteIndented;
            jsonOptions.IgnoreNullValues = apiJsonOptions.IgnoreNullValues;
            jsonOptions.AllowTrailingCommas = apiJsonOptions.AllowTrailingCommas;
            jsonOptions.Converters.Add(new JsonTimeSpanConverter());
        }
    }
}