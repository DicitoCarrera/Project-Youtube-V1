namespace Core.Entities;

public readonly record struct UserId(Guid Id)
{
    public static UserId Empty = new(Guid.Empty);

    public static UserId NewUserId()
    {
        return new UserId(Guid.NewGuid());
    }
}