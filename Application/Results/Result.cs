using Domain.Entity.Errors;

namespace Application.Results;

public class Result<T>
    where T : class
{
    public T? Value { get; }
    public Error Errors { get; }
    private bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public Result(T? value)
    {
        Value = value;
        Errors = Error.None;
        IsSuccess = true;
    }

    public Result(Error error)
    {
        Errors = error;
        Value = default;
        IsSuccess = false;
    }

    public static implicit operator Result<T>(T value) => new(value);

    public static implicit operator Result<T>(Error error) => new(error);
}
