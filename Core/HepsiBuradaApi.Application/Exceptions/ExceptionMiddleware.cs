using System;
using System.Net.Mime;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;

namespace HepsiBuradaApi.Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode = GetStatusCode(exception);
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = 200;
            if (exception.GetType() == typeof(ValidationException))
                return context.Response.WriteAsync(new ExceptionModel
                {
                    Message = ((ValidationException)exception).Errors.Select(x => x.ErrorMessage).First(),
                    StatusCode = StatusCodes.Status400BadRequest,
                    Success = false
                }.ToString());


            return context.Response.WriteAsync(new ExceptionModel
            {
                Message = exception.Message,
                StatusCode = statusCode,
                Success = false
            }.ToString());
        }

        private static int GetStatusCode(Exception exception)
        {
            return exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError,
            };
        }
    }
}
