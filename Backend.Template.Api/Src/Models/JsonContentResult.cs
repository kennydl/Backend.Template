using Microsoft.AspNetCore.Mvc;

namespace Backend.Template.Api.Models
{
    public sealed class JsonContentResult : ContentResult
    {
        public JsonContentResult()
        {
            ContentType = "application/json";
        }
    }
}