namespace BurnerApp.API.PostgreSQL.Models
{
    public class Response<T>
    {
        public string Message { get; set; }
        public int Status { get; set; }
        public bool IsSuccess { get; set; }
        public T Data { get; set; }

        public Response(T data, string message, int status = 200)
        {
            IsSuccess = true;
            Data = data;
            Message = message;
            Status = status;
        }

        public Response(string message, int status)
        {
            IsSuccess = false;
            Message = message;
            Status = status;
        }

    }
}
