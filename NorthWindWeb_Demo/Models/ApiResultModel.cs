namespace NorthWindWeb_Demo.Models
{
    public class ApiResultModel
    {
        public int Code { get; set; } = 200;

        public string Message { get; set; } = "Success";

        public object Data { get; set; }
        public static ApiResultModel Success<T>(T data)
        {
            return new ApiResultModel
            {
                Data = data,
            };
        }
        public static ApiResultModel Failed<T>(int code, T data)
        {
            return new ApiResultModel
            {
                Message = "Failed",
                Code = code,
                Data = data,
            };
        }
    }

}
