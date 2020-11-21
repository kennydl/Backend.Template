using System;
using AutoMapper;
using Backend.Template.Api.Dto;
using Backend.Template.Api.Models;
using Backend.Template.Core.Exceptions;
using Backend.Template.Infrastructure.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Backend.Template.Api.Filters
{
    public sealed class ExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<ExceptionFilter> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public ExceptionFilter(ILogger<ExceptionFilter> logger, IWebHostEnvironment env, IMapper mapper)
        {
            _logger = logger;
            _env = env;
            _mapper = mapper;
        }

        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var error = GetResponseError(exception, out var statusCode);
            context.Result = new JsonContentResult()
            {
                StatusCode = statusCode,
                Content = TextJsonSerializer.Serialize(error)
            };
            
            var logMessage = string.IsNullOrEmpty(error.ExceptionMessage)
                ? error.Message
                : $"{error.Message}\nException message: {error.ExceptionMessage}";
            _logger.LogError(exception, logMessage);
            
            base.OnException(context);
        }

        private ErrorDto GetResponseError(Exception exception, out int statusCode)
        {
            statusCode = StatusCodes.Status500InternalServerError;
            switch (exception)
            {
                // case DbUpdateException updateException:
                //     return MapToResponseError(updateException.InnerException ?? exception);
                case DefaultException ex:
                    statusCode = ex.StatusCode;
                    break;
            }
            return MapToResponseError(exception);
        }

        private ErrorDto MapToResponseError(Exception exception)
        {
            ErrorDto error;

            if (exception is DefaultException ex)
            {
                error = _mapper.Map<ErrorDto>(ex);
            }
            else
            {
                error = new ErrorDto()
                {
                    Message = exception.Message,
                    Source = exception.Source
                };
            }

            error.StackTrace = _env.IsDevelopment() ? exception.StackTrace : null;
            return error;
        }
    }
}