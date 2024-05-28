namespace Multishop.Discount.Utilities.Results
{
    public interface IDataResult<T> : IResult
    {
        T? Data { get; }
    }
}