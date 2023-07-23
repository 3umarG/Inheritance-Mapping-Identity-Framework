namespace TPH.Models.Responses
{
    public class CustomResponse<T>
    {
        public bool Status { get; set; } = true;
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }

        public List<string>? Errors { get; set; }

        public static CustomResponse<object> CreateFailureCustomResponse(int statusCode, List<string> errors)
            => new()
            {
                Status = false,
                StatusCode = statusCode,
                Message = ResponseConstants.MessageFailure,
                Errors = errors
            };


        public static CustomResponse<T> CreateSuccessCustomResponse(int statusCode, T data)
            => new()
            {
                Data = data,
                StatusCode = statusCode,
                Message = ResponseConstants.MessageSuccess,
                Errors = { },
                Status = true
            };
    }

    public static class ResponseConstants
    {
        public const string MessageSuccess = "Success";
        public const string MessageFailure = "Failed";
    }
}
