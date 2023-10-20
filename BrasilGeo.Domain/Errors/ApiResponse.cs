namespace BrasilGeo.Domain.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string? Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request.",
                401 => "Unauthorized Access.",
                404 => "Resource Not Found.",
                500 => "Internal Server Error.",
                _ => "An Unexpected Error Occurred."
            };

        }
    }
}
