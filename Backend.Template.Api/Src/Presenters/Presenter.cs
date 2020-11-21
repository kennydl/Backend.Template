using Backend.Template.Api.Models;
using Backend.Template.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;

namespace Backend.Template.Api.Presenters
{
    public abstract class Presenter
    {
        protected static JsonContentResult ResultObject(object response, int statusCode = StatusCodes.Status200OK)
        {
            return JsonResult(response, statusCode);
        }

        protected static JsonContentResult ResultArray(object response, int statusCode = StatusCodes.Status200OK)
        {
            return JsonResult(response, statusCode);
        }

        private static JsonContentResult JsonResult(object response, int statusCode = StatusCodes.Status200OK)
        {
            return new JsonContentResult()
            {
                StatusCode = statusCode,
                Content = TextJsonSerializer.Serialize(response)
            };
        }
    }
}
