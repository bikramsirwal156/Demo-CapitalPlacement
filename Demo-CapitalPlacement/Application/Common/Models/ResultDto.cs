namespace Demo_CapitalPlacement.Application.Common.Models
{
    public class ResultDto<T>
    {

        public ResultDto(T data, bool isSuccess, string message)
        {
            Data = data;
            IsSuccess = isSuccess;
            Message = message;
        }

        public ResultDto(T data, bool isSuccess)
        {
            Data = data;
            IsSuccess = isSuccess;
            Message = string.Empty;
        }

        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
