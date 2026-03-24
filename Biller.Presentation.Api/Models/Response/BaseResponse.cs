using System.Net;

namespace Biller.Presentation.Api.Models.Response;

public class BaseResponse<T>
{
    public T? Payload { get; set; }
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public int StatusCode { get; set; }
    public List<BaseError>? Errors { get; set; }

    public void SetSuccessResponse(T payload, string message = "Operación realiazada con éxito")
    {
        Payload = payload;
        IsSuccess = true;
        Message = message;
        StatusCode = (int) HttpStatusCode.OK;
        Errors = null;
    }

    public void SetErrorResponse(HttpStatusCode code = HttpStatusCode.BadRequest, string message = "Ocurrió un error al procesar la solicitud")
    {
        Payload = default;
        IsSuccess = false;
        Message = message;
        StatusCode = (int) code;
        Errors = null;
    }

    public void SetValidationErrorResponse(List<BaseError> errors)
    {
        Payload = default;
        IsSuccess = false;
        Message = "Error de validación de campos";
        StatusCode = (int) HttpStatusCode.BadRequest;
        Errors = errors;
    }
}
