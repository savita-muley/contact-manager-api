namespace ContactManagement.API.Models.Response
{
    public class ErrorResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }

    public class SuccessResponse<T> where T : class
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
