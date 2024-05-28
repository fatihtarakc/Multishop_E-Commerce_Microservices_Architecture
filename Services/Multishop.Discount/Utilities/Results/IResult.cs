namespace Multishop.Discount.Utilities.Results
{
    public interface IResult
    {
        bool ISSuccess {  get; }
        string Message { get; }
    }
}