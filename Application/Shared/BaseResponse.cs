namespace Application.Shared
{
    public class BaseResponse(string message, bool success)
    {
        public string Message { get; set; } = message;
        public bool Success { get; set; } = success;
    }
}
