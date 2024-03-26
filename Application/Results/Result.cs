using Domain.Common.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Application.Results;

public class Result
{
    internal Result(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        Errors = error;
    }

    public Error Errors { get; }

    private bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public static Result<T> Success<T>(T value) => new(value, true, Error.None);

    public static Result Success() => new(true, Error.None);

    public static Result<T> Failure<T>(Error error) => new(default, false, error);

    public static Result Failure(Error error) => new(false, error);
}

public class Result<T> : Result
{
    internal Result(T? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }

    private readonly T? _value;
    public T Value => _value!;
}


