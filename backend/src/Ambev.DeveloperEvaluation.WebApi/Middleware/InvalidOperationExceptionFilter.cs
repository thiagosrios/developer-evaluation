﻿using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.WebApi.Common;
using System;
using System.Text.Json;

namespace Ambev.DeveloperEvaluation.WebApi.Middleware
{
    public class InvalidOperationExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public InvalidOperationExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (InvalidOperationException ex)
            {
                await HandleInvalidOperationExceptionAsync(context, ex);
            }
        }

        private static Task HandleInvalidOperationExceptionAsync(HttpContext context, InvalidOperationException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var response = new ApiResponse
            {
                Success = false,
                Message = "Invalid Operation",
                Errors = new List<ValidationErrorDetail> 
                { 
                    new ValidationErrorDetail()
                    { 
                        Error = exception.Message, 
                        Detail = exception.StackTrace ?? string.Empty
                    } 
                }
            };

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response, jsonOptions));
        }
    }
}
