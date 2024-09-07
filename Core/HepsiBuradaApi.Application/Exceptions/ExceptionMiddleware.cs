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
                    Errors = ((ValidationException)exception).Errors.Select(x => x.ErrorMessage).First(),
                    StatusCode = StatusCodes.Status400BadRequest,
                    Succes = false
                }.ToString());


            return context.Response.WriteAsync(new ExceptionModel
            {
                Errors = exception.Message,
                StatusCode = statusCode,
                Succes = false
            }.ToString());
        }

        private static int GetStatusCode(Exception exception) => exception switch
        {
            BadRequestException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            ValidationException => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError,
        };
    }
}
