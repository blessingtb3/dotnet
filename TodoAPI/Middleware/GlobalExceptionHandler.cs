using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using TodoApi.Models;
using TodoAPI.Models;

namespace TodoAPI.Middleware{

    // implements the IExceptionHandler interface, enabling global exception handling in our application.
    public class GlobalExceptionHandler : IExceptionHandler{

        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger){
            _logger = logger;
        }

        /* invoked when an exception occurs. It logs the error message, creates an ErrorResponse object, 
        sets the status code and title based on the exception type, and returns a consistent error response to the client.*/
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext, 
            Exception exception,
            CancellationToken cancellationToken){

            //loggin the error message {
            _logger .LogError($"An error occurred while processing your request: {exception.Message}");

            /* This class represents the error response returned to the client when an exception occurs. 
            It contains properties for the error message, status code, and title.*/
            var errorResponse = new ErrorResponse{
                Message = exception.Message
            };

            switch(exception){
                case BadHttpRequestException: // This case handles exceptions of type BadHttpRequestException and sets the status code and title accordingly.
                    errorResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse.Title = exception.GetType().Name;
                    break;

                default: 
                    errorResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse.Title = "Internal Server Error";
                    break;
            }

            httpContext.Response.StatusCode = errorResponse.StatusCode;

            await httpContext   
                .Response
                .WriteAsJsonAsync(errorResponse, cancellationToken);

            return true;
        }  
    }
}