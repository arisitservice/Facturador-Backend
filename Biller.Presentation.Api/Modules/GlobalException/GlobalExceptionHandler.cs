

using Biller.Application.UseCase.Exceptions;
using Biller.Presentation.Api.Models.Response;
using System.Net;
using System.Text.Json;

namespace Biller.Presentation.Api.Modules.GlobalException;

public class GlobalExceptionHandler : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandler> logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ValidationExceptionCustom ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var responseErrors = ex.Errors.Select(r => new BaseError() { Property = r.PropertyName, ErrorMessage = r.ErrorMessage }).ToList();

            var response = new Response<Object>() { Message = "Errores de validación", Errors = responseErrors };

            await JsonSerializer.SerializeAsync(context.Response.Body, response);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.ToString());

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new Response<Object>();

            response.Message = "Ocurrió un error inesperado";

            await JsonSerializer.SerializeAsync(context.Response.Body, response);
        }
    }
}
