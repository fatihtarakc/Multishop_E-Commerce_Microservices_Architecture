namespace Multishop.Discount.Utilities.Results
{
    public class Result : IResult
    {
        public Result()
        {
            ISSuccess = false;
            Message = string.Empty;
        }

        public Result(bool isSuccess) : this()
        {
            ISSuccess = isSuccess;
        }

        public Result(bool isSuccess, string message) : this(isSuccess)
        {
            Message = message;
        }

        public bool ISSuccess { get; }
        public string Message { get; }
    }
}