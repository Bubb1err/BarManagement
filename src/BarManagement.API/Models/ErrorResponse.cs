using System.Net;

namespace BarManagement.API.Models
{
    public class ErrorResponse
    {
        public ErrorResponse(HttpStatusCode code, string message) 
        {
            Code = code;
            Message = message;
        }
        public HttpStatusCode Code { get; }
        public string Message { get; }

    }
}
