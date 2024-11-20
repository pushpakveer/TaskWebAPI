namespace TaskWebAPI.Models
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse(bool isSuccess, string message, T data = default)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }
    }
}
