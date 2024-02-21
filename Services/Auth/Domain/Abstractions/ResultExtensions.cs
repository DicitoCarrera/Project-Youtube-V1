namespace Domain.Abstractions;

public static class ResultExtensions
{
    // Bind (FlatMap): Chains another operation that returns a Result.
    public static Result<TOut?> Bind<T, TOut>(
        this Result<T> result, Func<T, Result<TOut>> bind)
    {
        return result.IsSuccess
            ? bind(result.Value)
            : Result<TOut>.Failure(result.Error);
    }

    // Map: Transforms the success value without affecting an error.
    public static Result<TOut> Map<T, TOut>(
        this Result<T> result, Func<T, TOut> map)
    {
        return result.IsSuccess
            ? Result<TOut>.Success(map(result.Value))
            : Result<TOut>.Failure(result.Error);
    }

    // Match: Executes a function based on the Result state.
    public static TOut Match<T, TOut>(this Result<T> result,
        Func<T, TOut> onSuccess,
        Func<Error, TOut> onFailure)
    {
        return result.IsSuccess
            ? onSuccess(result.Value)
            : onFailure(result.Error);
    }
}