namespace Domain.Abstractions;

public class Result<T>
{
    private Result(T value, bool isSuccess, Error error)
    {
        Value = value;
        IsSuccess = isSuccess;
        Error = error;
    }

    public T Value { get; }
    public Error Error { get; }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public static Result<T> Success(T value)
    {
        return new Result<T>(value, true, Error.None);
    }

    public static Result<T?> Failure(Error error)
    {
        return new Result<T?>(default, false, error);
    }

    // Implicit operator to convert Error to Result<T> for failure cases
    public static implicit operator Result<T?>(Error error)
    {
        return Failure(error);
    }

    // Implicit operator to convert T to Result<T> for success cases
    public static implicit operator Result<T>(T value)
    {
        return Success(value);
    }
}